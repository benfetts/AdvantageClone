Namespace PurchaseOrder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class PurchaseOrderDetail

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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartingDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PONumberHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Vendor = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.VendorHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.VendorFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DateRangeCriteria = New DevExpress.XtraReports.UI.CalculatedField()
            Me.PONumberFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.EndingDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label8
            '
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeName")})
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(513.9585!, 0!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(173.7499!, 23.0!)
            Me.label8.Text = "label8"
            Me.label8.WordWrap = False
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "POLineDescription")})
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(87.5!, 0!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(213.5417!, 23.0!)
            Me.label11.Text = "label11"
            Me.label11.WordWrap = False
            '
            'StartingDate
            '
            Me.StartingDate.Description = "Starting Date"
            Me.StartingDate.Name = "StartingDate"
            Me.StartingDate.Visible = False
            '
            'label37
            '
            Me.label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(814.5833!, 74.16671!)
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.StylePriority.UseTextAlignment = False
            Me.label37.Text = "Due Date"
            Me.label37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label32
            '
            Me.label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(875.0001!, 97.16669!)
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.StylePriority.UseTextAlignment = False
            Me.label32.Text = "Total"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PONumberHeader
            '
            Me.PONumberHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label8, Me.label13, Me.label12, Me.label7, Me.label9, Me.label3})
            Me.PONumberHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("PONumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.PONumberHeader.HeightF = 23.0!
            Me.PONumberHeader.Name = "PONumberHeader"
            Me.PONumberHeader.RepeatEveryPage = True
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PODueDate", "{0:d}")})
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(814.5833!, 0!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:d}"
            Me.label13.Summary = XrSummary1
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.WordWrap = False
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PODate", "{0:d}")})
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(700.0001!, 0!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:d}"
            Me.label12.Summary = XrSummary2
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label12.WordWrap = False
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PODescription")})
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(87.5!, 0!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(408.1251!, 23.0!)
            Me.label7.Text = "label7"
            Me.label7.WordWrap = False
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PONumber", "{0:000000}")})
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 0!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label9.WordWrap = False
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Voided")})
            Me.label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(929.1667!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(70.83331!, 23.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.StylePriority.UseTextAlignment = False
            Me.label3.Text = "label3"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label39
            '
            Me.label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(579.2917!, 0!)
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.StylePriority.UseTextAlignment = False
            Me.label39.Text = "Total for Vendor:"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "POLineNumber")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 0!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "label10"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label10.WordWrap = False
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(382.6249!, 0!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label15.Text = "label15"
            Me.label15.WordWrap = False
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.Transparent
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label18
            '
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentNumber", "{0:000}")})
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(579.2916!, 0!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(33.0!, 23.0!)
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label18.WordWrap = False
            '
            'label2
            '
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateRangeCriteria")})
            Me.label2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 37.16666!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(352.0834!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "label2"
            '
            'label36
            '
            Me.label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(700.0001!, 74.16671!)
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.StylePriority.UseTextAlignment = False
            Me.label36.Text = "PO Date"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber", "{0:000000}")})
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(524.2916!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(55.0!, 23.0!)
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "label17"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label17.WordWrap = False
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCode")})
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(622.7084!, 0!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label19.Text = "label19"
            Me.label19.WordWrap = False
            '
            'label34
            '
            Me.label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 74.16671!)
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(483.1251!, 23.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.Text = "Purchase Order Number & Description"
            '
            'Vendor
            '
            Me.Vendor.Expression = "[VendorCode]+' - '+[VendorName]"
            Me.Vendor.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Vendor.Name = "Vendor"
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label24, Me.label22, Me.label21, Me.label20, Me.label19, Me.label18, Me.label17, Me.label16, Me.label15, Me.label14, Me.label11, Me.label10})
            Me.Detail.HeightF = 23.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("POLineNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "POComplete")})
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(960.0!, 0!)
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(40.0!, 23.0!)
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "label24"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label24.WordWrap = False
            '
            'label22
            '
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PONetAmount", "{0:n2}")})
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 0!)
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label22.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            Me.label22.Summary = XrSummary3
            Me.label22.Text = "label22"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label22.WordWrap = False
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PORate")})
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(787.5!, 0!)
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label21.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            Me.label21.Summary = XrSummary4
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label21.TextFormatString = "{0:n4}"
            Me.label21.WordWrap = False
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "POQuantity", "{0:#,#}")})
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 0!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label20.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            Me.label20.Summary = XrSummary5
            Me.label20.Text = "label20"
            Me.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label20.WordWrap = False
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(447.625!, 0!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label16.Text = "label16"
            Me.label16.WordWrap = False
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(317.6249!, 0!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label14.Text = "label14"
            Me.label14.WordWrap = False
            '
            'label30
            '
            Me.label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(700.0001!, 97.16669!)
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "Quantity"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label27
            '
            Me.label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(447.6251!, 97.16669!)
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(65.00003!, 23.0!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.Text = "Product"
            '
            'VendorHeader
            '
            Me.VendorHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label6})
            Me.VendorHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.VendorHeader.HeightF = 23.0!
            Me.VendorHeader.Level = 1
            Me.VendorHeader.Name = "VendorHeader"
            Me.VendorHeader.RepeatEveryPage = True
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(289.1666!, 23.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(317.6251!, 97.16669!)
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.Text = "Client"
            '
            'label38
            '
            Me.label38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PONetAmount")})
            Me.label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 0!)
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label38.Summary = XrSummary6
            Me.label38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label38.WordWrap = False
            '
            'label26
            '
            Me.label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(382.625!, 97.16669!)
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(65.00006!, 23.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.Text = "Division"
            '
            'label33
            '
            Me.label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(960.0001!, 97.16669!)
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(39.99994!, 23.0!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.Text = "Cmplt"
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 14.49998!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(301.0417!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.TextFormatString = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            '
            'VendorFooter
            '
            Me.VendorFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label39, Me.label38})
            Me.VendorFooter.HeightF = 34.375!
            Me.VendorFooter.Level = 1
            Me.VendorFooter.Name = "VendorFooter"
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.Transparent
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.16668!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 10.00001!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(352.0833!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Purchase Order Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.label2, Me.line2, Me.line1, Me.label33, Me.label1, Me.label32, Me.label23, Me.label25, Me.label26, Me.label27, Me.label28, Me.label29, Me.label30, Me.label31, Me.label34, Me.label35, Me.label36, Me.label37})
            Me.PageHeader.HeightF = 126.4167!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLine1
            '
            Me.XrLine1.BackColor = System.Drawing.Color.LightGray
            Me.XrLine1.BorderColor = System.Drawing.Color.Transparent
            Me.XrLine1.ForeColor = System.Drawing.Color.LightGray
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 120.1667!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.XrLine1.StylePriority.UseBackColor = False
            Me.XrLine1.StylePriority.UseBorderColor = False
            Me.XrLine1.StylePriority.UseForeColor = False
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.Transparent
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label23
            '
            Me.label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(26.04179!, 97.16669!)
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(275.0!, 23.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.Text = "Line Number & Description"
            '
            'label28
            '
            Me.label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(522.7084!, 97.16669!)
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.Text = "Job/Comp #"
            '
            'label29
            '
            Me.label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(622.7085!, 97.16669!)
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(65.00006!, 23.0!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.Text = "Function"
            '
            'label31
            '
            Me.label31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(787.5001!, 97.16669!)
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(85.00006!, 23.0!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.StylePriority.UseTextAlignment = False
            Me.label31.Text = "Rate"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label35
            '
            Me.label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(513.9587!, 74.16671!)
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(173.7499!, 23.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.Text = "Employee"
            '
            'DateRangeCriteria
            '
            Me.DateRangeCriteria.Expression = "[Parameters.StartingDate]+ ' to ' +[Parameters.EndingDate]"
            Me.DateRangeCriteria.Name = "DateRangeCriteria"
            '
            'PONumberFooter
            '
            Me.PONumberFooter.HeightF = 0!
            Me.PONumberFooter.Name = "PONumberFooter"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line4, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.HeightF = 37.5!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 14.49998!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'EndingDate
            '
            Me.EndingDate.Description = "Ending Date"
            Me.EndingDate.Name = "EndingDate"
            Me.EndingDate.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.OpenPurchaseOrderDetail)
            '
            'PurchaseOrderDetail
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.VendorHeader, Me.VendorFooter, Me.PONumberHeader, Me.PONumberFooter, Me.PageHeader, Me.PageFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Vendor, Me.DateRangeCriteria})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "01-Purchase Order Detail"
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartingDate, Me.EndingDate})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartingDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PONumberHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Vendor As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents VendorFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DateRangeCriteria As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents PONumberFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents EndingDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
