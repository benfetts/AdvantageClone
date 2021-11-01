Namespace JobAnalysisDetail.Version30

    Partial Public Class FunctionDetailSubReport

        Private Detail As DevExpress.XtraReports.UI.DetailBand
        Private Text3 As DevExpress.XtraReports.UI.XRLabel
        Private Text8 As DevExpress.XtraReports.UI.XRLabel
        Private Text9 As DevExpress.XtraReports.UI.XRLabel
        Private GroupHeader0 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private GroupFooter0 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
        Private components As System.ComponentModel.IContainer
        Friend WithEvents Invoice As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents UnbilledTotal As DevExpress.XtraReports.UI.CalculatedField
        Public WithEvents JobNumb As DevExpress.XtraReports.Parameters.Parameter
        Public WithEvents JobComponentNumb As DevExpress.XtraReports.Parameters.Parameter
        Private _resources As System.Resources.ResourceManager
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader0 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Invoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.UnbilledTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.Amount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ItemDateLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARInvPadded = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.BackColor = System.Drawing.Color.Transparent
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.Text3, Me.Text8, Me.Text9})
            Me.Detail.HeightF = 18.16667!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.White
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
			Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDateLabel", "{0:d}")})
			Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(868.75!, 0.0!)
			Me.XrLabel5.Name = "XrLabel5"
			Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.XrLabel5.SizeF = New System.Drawing.SizeF(73.95667!, 13.0!)
			Me.XrLabel5.StylePriority.UseFont = False
			Me.XrLabel5.StylePriority.UseTextAlignment = False
			XrSummary1.FormatString = "{0:C2}"
			Me.XrLabel5.Summary = XrSummary1
			Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabel4
			'
			Me.XrLabel4.BackColor = System.Drawing.Color.White
			Me.XrLabel4.BorderColor = System.Drawing.Color.Black
			Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.XrLabel4.BorderWidth = 1.0!
			Me.XrLabel4.CanGrow = False
			Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARInvPadded")})
			Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(782.2917!, 0.0!)
			Me.XrLabel4.Name = "XrLabel4"
			Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.XrLabel4.SizeF = New System.Drawing.SizeF(73.95667!, 13.0!)
			Me.XrLabel4.StylePriority.UseFont = False
			Me.XrLabel4.StylePriority.UseTextAlignment = False
			XrSummary2.FormatString = "{0:C2}"
			Me.XrLabel4.Summary = XrSummary2
			Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabel3
			'
			Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
			Me.XrLabel3.BorderColor = System.Drawing.Color.Black
			Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.XrLabel3.BorderWidth = 1.0!
			Me.XrLabel3.CanGrow = False
			Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARLabel")})
			Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabel3.ForeColor = System.Drawing.Color.Black
			Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(702.9584!, 0.0!)
			Me.XrLabel3.Name = "XrLabel3"
			Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.XrLabel3.SizeF = New System.Drawing.SizeF(79.33331!, 13.0!)
			Me.XrLabel3.StylePriority.UseFont = False
			Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabel2
			'
			Me.XrLabel2.BackColor = System.Drawing.Color.White
			Me.XrLabel2.BorderColor = System.Drawing.Color.Black
			Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.XrLabel2.BorderWidth = 1.0!
			Me.XrLabel2.CanGrow = False
			Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:C2}")})
			Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(600.4983!, 0.0!)
			Me.XrLabel2.Name = "XrLabel2"
			Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.XrLabel2.SizeF = New System.Drawing.SizeF(67.70667!, 13.0!)
			Me.XrLabel2.StylePriority.UseFont = False
			Me.XrLabel2.StylePriority.UseTextAlignment = False
			XrSummary3.FormatString = "{0:C2}"
			Me.XrLabel2.Summary = XrSummary3
			Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabel1
			'
			Me.XrLabel1.BackColor = System.Drawing.Color.White
			Me.XrLabel1.BorderColor = System.Drawing.Color.Black
			Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.XrLabel1.BorderWidth = 1.0!
			Me.XrLabel1.CanGrow = False
			Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceReference")})
			Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(300.7083!, 0.0!)
			Me.XrLabel1.Name = "XrLabel1"
			Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.XrLabel1.SizeF = New System.Drawing.SizeF(146.6667!, 13.0!)
			Me.XrLabel1.StylePriority.UseFont = False
			XrSummary4.FormatString = "{0}"
			Me.XrLabel1.Summary = XrSummary4
			Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'Text3
			'
			Me.Text3.BackColor = System.Drawing.Color.White
			Me.Text3.BorderColor = System.Drawing.Color.Black
			Me.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.Text3.BorderWidth = 1.0!
			Me.Text3.CanGrow = False
			Me.Text3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDate", "{0:d}")})
			Me.Text3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text3.LocationFloat = New DevExpress.Utils.PointFloat(464.2499!, 0.0!)
            Me.Text3.Name = "Text3"
            Me.Text3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text3.SizeF = New System.Drawing.SizeF(81.04169!, 13.0!)
            Me.Text3.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0}"
            Me.Text3.Summary = XrSummary5
            Me.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text8
            '
            Me.Text8.BackColor = System.Drawing.Color.White
            Me.Text8.BorderColor = System.Drawing.Color.Black
            Me.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text8.BorderWidth = 1.0!
            Me.Text8.CanGrow = False
            Me.Text8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDescription")})
            Me.Text8.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(32.29168!, 0.0!)
            Me.Text8.Name = "Text8"
            Me.Text8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text8.SizeF = New System.Drawing.SizeF(212.1667!, 13.0!)
            Me.Text8.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0}"
            Me.Text8.Summary = XrSummary6
            Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text9
            '
            Me.Text9.BackColor = System.Drawing.Color.White
            Me.Text9.BorderColor = System.Drawing.Color.Black
            Me.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text9.BorderWidth = 1.0!
            Me.Text9.CanGrow = False
            Me.Text9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours")})
            Me.Text9.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text9.LocationFloat = New DevExpress.Utils.PointFloat(545.2916!, 0.0!)
            Me.Text9.Name = "Text9"
            Me.Text9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100.0!)
            Me.Text9.SizeF = New System.Drawing.SizeF(55.20667!, 13.0!)
            Me.Text9.StylePriority.UseFont = False
            Me.Text9.StylePriority.UsePadding = False
            Me.Text9.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:C2}"
            Me.Text9.Summary = XrSummary7
            Me.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader0
            '
            Me.GroupHeader0.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader0.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader0.HeightF = 0.0!
            Me.GroupHeader0.KeepTogether = True
            Me.GroupHeader0.Name = "GroupHeader0"
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.HeightF = 0.0!
            Me.GroupFooter0.KeepTogether = True
            Me.GroupFooter0.Name = "GroupFooter0"
            '
            'TopMarginBand1
            '
            Me.TopMarginBand1.HeightF = 0.0!
            Me.TopMarginBand1.Name = "TopMarginBand1"
            '
            'BottomMarginBand1
            '
            Me.BottomMarginBand1.HeightF = 0.0!
            Me.BottomMarginBand1.Name = "BottomMarginBand1"
            '
            'Invoice
            '
            Me.Invoice.Expression = "Iif([ARInvoiceNumber] == ?, 'Pending',[ARInvoiceNumber] + ' ' + [ARType] )"
            Me.Invoice.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Invoice.Name = "Invoice"
            '
            'UnbilledTotal
            '
            Me.UnbilledTotal.Expression = "[TotalAmount] - [TotalBilledAmount]"
            Me.UnbilledTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.UnbilledTotal.Name = "UnbilledTotal"
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Database.Classes.JobDetailAnalysisQVADetail)
            '
            'Amount
            '
            Me.Amount.Expression = "Iif([InvoiceReference] = 'Advance Billing', [Billed] ,[ActualAmount] )"
            Me.Amount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.Amount.Name = "Amount"
            '
            'ARLabel
            '
            Me.ARLabel.Expression = "Iif([ARInvoiceNumber] IS NULL, '' , 'A/R Invoice:')"
            Me.ARLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ARLabel.Name = "ARLabel"
            '
            'ItemDateLabel
            '
            Me.ItemDateLabel.Expression = "Iif([ARInvoiceNumber] IS NULL, '' ,[AdjustedDate] )"
            Me.ItemDateLabel.FieldType = DevExpress.XtraReports.UI.FieldType.DateTime
            Me.ItemDateLabel.Name = "ItemDateLabel"
            '
            'ARInvPadded
            '
            Me.ARInvPadded.Expression = "PadLeft([ARInvoiceNumber],6 , '0')"
            Me.ARInvPadded.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ARInvPadded.Name = "ARInvPadded"
            '
            'FunctionDetailSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.GroupHeader0, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Invoice, Me.UnbilledTotal, Me.Amount, Me.ARLabel, Me.ItemDateLabel, Me.ARInvPadded})
            Me.DataSource = Me.BindingSource1
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageHeight = 1190
            Me.PageWidth = 1000
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Public WithEvents FunctionCo As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents Amount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ItemDateLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARInvPadded As DevExpress.XtraReports.UI.CalculatedField

    End Class

End Namespace