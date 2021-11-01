Namespace JobAnalysisDetail.Version11

    Partial Public Class AdvanceReconciliationHistorySubReport

        Private Detail As DevExpress.XtraReports.UI.DetailBand
        Private OUTSTANDING As DevExpress.XtraReports.UI.XRLabel
        Private Text3 As DevExpress.XtraReports.UI.XRLabel
        Private Text8 As DevExpress.XtraReports.UI.XRLabel
        Private Text9 As DevExpress.XtraReports.UI.XRLabel
        Private GroupHeader0 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private Label10 As DevExpress.XtraReports.UI.XRLabel
        Private Label11 As DevExpress.XtraReports.UI.XRLabel
        Private Label12 As DevExpress.XtraReports.UI.XRLabel
        Private Label13 As DevExpress.XtraReports.UI.XRLabel
        Private Label22 As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter0 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Billed As DevExpress.XtraReports.UI.XRLabel
        Private Total As DevExpress.XtraReports.UI.XRLabel
        Private Label18 As DevExpress.XtraReports.UI.XRLabel
        Private Text20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
        Private components As System.ComponentModel.IContainer
        Friend WithEvents Invoice As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents UnbilledTotal As DevExpress.XtraReports.UI.CalculatedField
        Public WithEvents JobNumb As DevExpress.XtraReports.Parameters.Parameter
        Public WithEvents JobComponentNumb As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
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
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OUTSTANDING = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader0 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Billed = New DevExpress.XtraReports.UI.XRLabel()
            Me.Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Invoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.UnbilledTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobNumb = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComponentNumb = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.BackColor = System.Drawing.Color.Transparent
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6, Me.XrLabel5, Me.XrLabel1, Me.OUTSTANDING, Me.Text3, Me.Text8, Me.Text9})
            Me.Detail.HeightF = 14.0!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ARInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ARType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("BillTypeSort", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.White
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.BorderWidth = 1
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FinalRecAdj", "{0:n2}")})
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(661.4583!, 0.0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(92.79169!, 13.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:C2}"
            Me.XrLabel6.Summary = XrSummary1
            Me.XrLabel6.Text = "XrLabel6"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.White
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdvanceResaleTax", "{0:n2}")})
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(544.1615!, 0.0!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(92.79169!, 13.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:C2}"
            Me.XrLabel5.Summary = XrSummary2
            Me.XrLabel5.Text = "XrLabel5"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.White
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Balance", "{0:n2}")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(408.3333!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(117.1632!, 13.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:C2}"
            Me.XrLabel1.Summary = XrSummary3
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'OUTSTANDING
            '
            Me.OUTSTANDING.BackColor = System.Drawing.Color.White
            Me.OUTSTANDING.BorderColor = System.Drawing.Color.Black
            Me.OUTSTANDING.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.OUTSTANDING.BorderWidth = 1
            Me.OUTSTANDING.CanGrow = False
            Me.OUTSTANDING.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RecognizedToDate", "{0:n2}")})
            Me.OUTSTANDING.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OUTSTANDING.LocationFloat = New DevExpress.Utils.PointFloat(295.2032!, 0.9999911!)
            Me.OUTSTANDING.Name = "OUTSTANDING"
            Me.OUTSTANDING.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.OUTSTANDING.SizeF = New System.Drawing.SizeF(92.79169!, 13.0!)
            Me.OUTSTANDING.StylePriority.UseFont = False
            Me.OUTSTANDING.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:C2}"
            Me.OUTSTANDING.Summary = XrSummary4
            Me.OUTSTANDING.Text = "OUTSTANDING"
            Me.OUTSTANDING.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text3
            '
            Me.Text3.BackColor = System.Drawing.Color.White
            Me.Text3.BorderColor = System.Drawing.Color.Black
            Me.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text3.BorderWidth = 1
            Me.Text3.CanGrow = False
            Me.Text3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledToDate", "{0:n2}")})
            Me.Text3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text3.LocationFloat = New DevExpress.Utils.PointFloat(106.9583!, 0.0!)
            Me.Text3.Name = "Text3"
            Me.Text3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text3.SizeF = New System.Drawing.SizeF(77.95834!, 13.0!)
            Me.Text3.StylePriority.UseFont = False
            Me.Text3.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0}"
            Me.Text3.Summary = XrSummary5
            Me.Text3.Text = "Text3"
            Me.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text8
            '
            Me.Text8.BackColor = System.Drawing.Color.White
            Me.Text8.BorderColor = System.Drawing.Color.Black
            Me.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text8.BorderWidth = 1
            Me.Text8.CanGrow = False
            Me.Text8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingPeriod")})
            Me.Text8.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Text8.Name = "Text8"
            Me.Text8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text8.SizeF = New System.Drawing.SizeF(106.9583!, 13.0!)
            Me.Text8.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0}"
            Me.Text8.Summary = XrSummary6
            Me.Text8.Text = "Text8"
            Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text9
            '
            Me.Text9.BackColor = System.Drawing.Color.White
            Me.Text9.BorderColor = System.Drawing.Color.Black
            Me.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text9.BorderWidth = 1
            Me.Text9.CanGrow = False
            Me.Text9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReconciledToDate", "{0:n2}")})
            Me.Text9.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Text9.LocationFloat = New DevExpress.Utils.PointFloat(199.8716!, 0.0!)
            Me.Text9.Name = "Text9"
            Me.Text9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text9.SizeF = New System.Drawing.SizeF(75.62498!, 13.0!)
            Me.Text9.StylePriority.UseFont = False
            Me.Text9.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:C2}"
            Me.Text9.Summary = XrSummary7
            Me.Text9.Text = "Text9"
            Me.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader0
            '
            Me.GroupHeader0.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label22})
            Me.GroupHeader0.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader0.HeightF = 52.83334!
            Me.GroupHeader0.KeepTogether = True
            Me.GroupHeader0.Name = "GroupHeader0"
            '
            'XrLabel4
            '
            Me.XrLabel4.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel4.BorderColor = System.Drawing.Color.Black
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel4.BorderWidth = 1
            Me.XrLabel4.CanGrow = False
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.ForeColor = System.Drawing.Color.Black
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(661.4583!, 19.00002!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(92.79166!, 33.20833!)
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.Text = "Final Rec. Adj."
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(544.1614!, 19.00001!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(92.79166!, 33.20833!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Advance Resale Tax"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel2
            '
            Me.XrLabel2.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel2.BorderColor = System.Drawing.Color.Black
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel2.BorderWidth = 1
            Me.XrLabel2.CanGrow = False
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(408.3333!, 19.00001!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(117.1632!, 33.20833!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "Advance Balance to Recognize/Reconcile"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.BorderColor = System.Drawing.Color.Black
            Me.Label10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label10.BorderWidth = 1
            Me.Label10.CanGrow = False
            Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 35.66667!)
            Me.Label10.Name = "Label10"
            Me.Label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label10.SizeF = New System.Drawing.SizeF(92.16666!, 16.54166!)
            Me.Label10.StylePriority.UseBorders = False
            Me.Label10.StylePriority.UseFont = False
            Me.Label10.StylePriority.UseTextAlignment = False
            Me.Label10.Text = "Billing Period"
            Me.Label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.BorderColor = System.Drawing.Color.Black
            Me.Label11.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label11.BorderWidth = 1
            Me.Label11.CanGrow = False
            Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.LocationFloat = New DevExpress.Utils.PointFloat(106.9583!, 19.00001!)
            Me.Label11.Name = "Label11"
            Me.Label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label11.SizeF = New System.Drawing.SizeF(58.16667!, 33.20833!)
            Me.Label11.StylePriority.UseFont = False
            Me.Label11.StylePriority.UseTextAlignment = False
            Me.Label11.Text = "Billed to Date"
            Me.Label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.BorderColor = System.Drawing.Color.Black
            Me.Label12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label12.BorderWidth = 1
            Me.Label12.CanGrow = False
            Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.LocationFloat = New DevExpress.Utils.PointFloat(199.8716!, 19.00001!)
            Me.Label12.Name = "Label12"
            Me.Label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label12.SizeF = New System.Drawing.SizeF(75.62502!, 33.20834!)
            Me.Label12.StylePriority.UseFont = False
            Me.Label12.StylePriority.UseTextAlignment = False
            Me.Label12.Text = "Reconciled to Date"
            Me.Label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.BorderColor = System.Drawing.Color.Black
            Me.Label13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label13.BorderWidth = 1
            Me.Label13.CanGrow = False
            Me.Label13.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Label13.Name = "Label13"
            Me.Label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label13.SizeF = New System.Drawing.SizeF(238.0!, 19.0!)
            Me.Label13.StylePriority.UseFont = False
            Me.Label13.Text = "Advance  Reconciliation  History:  "
            Me.Label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label22
            '
            Me.Label22.BackColor = System.Drawing.Color.Transparent
            Me.Label22.BorderColor = System.Drawing.Color.Black
            Me.Label22.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label22.BorderWidth = 1
            Me.Label22.CanGrow = False
            Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.LocationFloat = New DevExpress.Utils.PointFloat(295.2032!, 19.00001!)
            Me.Label22.Name = "Label22"
            Me.Label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label22.SizeF = New System.Drawing.SizeF(92.79166!, 33.20833!)
            Me.Label22.StylePriority.UseFont = False
            Me.Label22.StylePriority.UseTextAlignment = False
            Me.Label22.Text = "Recognized to Date"
            Me.Label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.Billed, Me.Total, Me.Label18, Me.Text20})
            Me.GroupFooter0.HeightF = 26.00001!
            Me.GroupFooter0.KeepTogether = True
            Me.GroupFooter0.Name = "GroupFooter0"
            '
            'XrLabel9
            '
            Me.XrLabel9.BackColor = System.Drawing.Color.White
            Me.XrLabel9.BorderColor = System.Drawing.Color.Black
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel9.BorderWidth = 1
            Me.XrLabel9.CanGrow = False
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FinalRecAdj")})
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(661.4583!, 0.0!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(92.79163!, 19.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel9.Summary = XrSummary8
            Me.XrLabel9.Text = "XrLabel9"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.BackColor = System.Drawing.Color.White
            Me.XrLabel8.BorderColor = System.Drawing.Color.Black
            Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel8.BorderWidth = 1
            Me.XrLabel8.CanGrow = False
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdvanceResaleTax")})
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(544.1615!, 0.0!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(92.79163!, 19.0!)
            Me.XrLabel8.StylePriority.UseFont = False
            Me.XrLabel8.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel8.Summary = XrSummary9
            Me.XrLabel8.Text = "XrLabel8"
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.White
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1
            Me.XrLabel7.CanGrow = False
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Balance")})
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(408.3333!, 0.0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(117.1631!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel7.Summary = XrSummary10
            Me.XrLabel7.Text = "XrLabel7"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Billed
            '
            Me.Billed.BackColor = System.Drawing.Color.White
            Me.Billed.BorderColor = System.Drawing.Color.Black
            Me.Billed.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Billed.BorderWidth = 1
            Me.Billed.CanGrow = False
            Me.Billed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReconciledToDate")})
            Me.Billed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Billed.LocationFloat = New DevExpress.Utils.PointFloat(199.8716!, 0.0!)
            Me.Billed.Name = "Billed"
            Me.Billed.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Billed.SizeF = New System.Drawing.SizeF(75.62498!, 19.0!)
            Me.Billed.StylePriority.UseFont = False
            Me.Billed.StylePriority.UseTextAlignment = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.Billed.Summary = XrSummary11
            Me.Billed.Text = "Billed"
            Me.Billed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Total
            '
            Me.Total.BackColor = System.Drawing.Color.White
            Me.Total.BorderColor = System.Drawing.Color.Black
            Me.Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Total.BorderWidth = 1
            Me.Total.CanGrow = False
            Me.Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledToDate")})
            Me.Total.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Total.LocationFloat = New DevExpress.Utils.PointFloat(106.9583!, 0.0!)
            Me.Total.Name = "Total"
            Me.Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Total.SizeF = New System.Drawing.SizeF(77.95834!, 19.0!)
            Me.Total.StylePriority.UseFont = False
            Me.Total.StylePriority.UseTextAlignment = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.Total.Summary = XrSummary12
            Me.Total.Text = "Total"
            Me.Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.BorderColor = System.Drawing.Color.Black
            Me.Label18.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label18.BorderWidth = 1
            Me.Label18.CanGrow = False
            Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label18.ForeColor = System.Drawing.Color.Black
            Me.Label18.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Label18.Name = "Label18"
            Me.Label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label18.SizeF = New System.Drawing.SizeF(92.16667!, 13.0!)
            Me.Label18.StylePriority.UseFont = False
            Me.Label18.Text = "Totals:"
            Me.Label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text20
            '
            Me.Text20.BackColor = System.Drawing.Color.White
            Me.Text20.BorderColor = System.Drawing.Color.Black
            Me.Text20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text20.BorderWidth = 1
            Me.Text20.CanGrow = False
            Me.Text20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RecognizedToDate")})
            Me.Text20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text20.LocationFloat = New DevExpress.Utils.PointFloat(295.2032!, 0.0!)
            Me.Text20.Name = "Text20"
            Me.Text20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text20.SizeF = New System.Drawing.SizeF(92.79163!, 19.0!)
            Me.Text20.StylePriority.UseFont = False
            Me.Text20.StylePriority.UseTextAlignment = False
            XrSummary13.FormatString = "{0:n2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.Text20.Summary = XrSummary13
            Me.Text20.Text = "Text20"
            Me.Text20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            'JobNumb
            '
            Me.JobNumb.Name = "JobNumb"
            Me.JobNumb.Type = GetType(Integer)
            Me.JobNumb.ValueInfo = "0"
            Me.JobNumb.Visible = False
            '
            'JobComponentNumb
            '
            Me.JobComponentNumb.Name = "JobComponentNumb"
            Me.JobComponentNumb.Type = GetType(Short)
            Me.JobComponentNumb.ValueInfo = "0"
            Me.JobComponentNumb.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.AdvanceReconciliationReport)
            '
            'AdvanceReconciliationHistorySubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.GroupHeader0, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Invoice, Me.UnbilledTotal})
            Me.DataSource = Me.BindingSource
            Me.FilterString = "[JobNumber] = ?JobNumb And [JobComponentNumber] = ?JobComponentNumb"
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageHeight = 1190
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.JobNumb, Me.JobComponentNumb})
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel

    End Class

End Namespace