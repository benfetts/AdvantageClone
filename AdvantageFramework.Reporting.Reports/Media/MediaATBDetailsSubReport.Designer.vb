Namespace Media

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class MediaATBDetailsSubReport
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
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetails_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelRevisionDetailsHeader_MarkupAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_AdServingAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelRevisionDetailsHeader_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_MarkupPercent = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_AdServingPercent = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_NetSpend = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_TotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRevisionDetailsHeader_CostType = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6, Me.XrLabel4, Me.XrLabel3, Me.LabelRevisionDetails_Vendor, Me.XrLabel35, Me.XrLabel36, Me.XrLabel37, Me.XrLabel38, Me.XrLabel39, Me.XrLabel40, Me.XrLabel41})
            Me.Detail.HeightF = 21.91652!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostType", "{0:n4}")})
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(274.456!, 0.0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(35.0!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "CPC"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity", "{0:n0}")})
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(156.3731!, 0.0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(52.07997!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.Text = "XrLabel4"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate", "{0:n4}")})
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(210.4564!, 0.00001589457!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(62.0!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "XrLabel3"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelRevisionDetails_Vendor
            '
            Me.LabelRevisionDetails_Vendor.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.LabelRevisionDetails_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelRevisionDetails_Vendor.Name = "LabelRevisionDetails_Vendor"
            Me.LabelRevisionDetails_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetails_Vendor.SizeF = New System.Drawing.SizeF(154.37!, 19.0!)
            Me.LabelRevisionDetails_Vendor.StylePriority.UseFont = False
            Me.LabelRevisionDetails_Vendor.Text = "[Vendor.Name]"
            '
            'XrLabel35
            '
            Me.XrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.XrLabel35.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(311.4511!, 0.0!)
            Me.XrLabel35.Name = "XrLabel35"
            Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel35.SizeF = New System.Drawing.SizeF(65.13!, 19.0!)
            Me.XrLabel35.StylePriority.UseFont = False
            Me.XrLabel35.StylePriority.UseTextAlignment = False
            Me.XrLabel35.Text = "XrLabel35"
            Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel36
            '
            Me.XrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupPercent", "{0:n4}")})
            Me.XrLabel36.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(378.583!, 0.0!)
            Me.XrLabel36.Name = "XrLabel36"
            Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel36.SizeF = New System.Drawing.SizeF(50.0!, 19.0!)
            Me.XrLabel36.StylePriority.UseFont = False
            Me.XrLabel36.StylePriority.UseTextAlignment = False
            Me.XrLabel36.Text = "XrLabel36"
            Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel37
            '
            Me.XrLabel37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount", "{0:n2}")})
            Me.XrLabel37.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(430.5864!, 0.0!)
            Me.XrLabel37.Name = "XrLabel37"
            Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel37.SizeF = New System.Drawing.SizeF(57.08!, 19.0!)
            Me.XrLabel37.StylePriority.UseFont = False
            Me.XrLabel37.StylePriority.UseTextAlignment = False
            Me.XrLabel37.Text = "XrLabel37"
            Me.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel38
            '
            Me.XrLabel38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetChargeAmount", "{0:n2}")})
            Me.XrLabel38.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(541.8763!, 0.00001589457!)
            Me.XrLabel38.Name = "XrLabel38"
            Me.XrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel38.SizeF = New System.Drawing.SizeF(56.79!, 19.0!)
            Me.XrLabel38.StylePriority.UseFont = False
            Me.XrLabel38.StylePriority.UseTextAlignment = False
            Me.XrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel39
            '
            Me.XrLabel39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetChargePercent", "{0:n4}")})
            Me.XrLabel39.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(489.6646!, 0.00001589457!)
            Me.XrLabel39.Name = "XrLabel39"
            Me.XrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel39.SizeF = New System.Drawing.SizeF(50.21!, 19.0!)
            Me.XrLabel39.StylePriority.UseFont = False
            Me.XrLabel39.StylePriority.UseTextAlignment = False
            Me.XrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel40
            '
            Me.XrLabel40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetSpend", "{0:n2}")})
            Me.XrLabel40.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(600.6632!, 0.0!)
            Me.XrLabel40.Name = "XrLabel40"
            Me.XrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel40.SizeF = New System.Drawing.SizeF(73.42!, 19.0!)
            Me.XrLabel40.StylePriority.UseFont = False
            Me.XrLabel40.StylePriority.UseTextAlignment = False
            Me.XrLabel40.Text = "XrLabel40"
            Me.XrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel41
            '
            Me.XrLabel41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineTotal", "{0:n2}")})
            Me.XrLabel41.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(676.0804!, 0.0!)
            Me.XrLabel41.Name = "XrLabel41"
            Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel41.SizeF = New System.Drawing.SizeF(73.92!, 19.0!)
            Me.XrLabel41.StylePriority.UseFont = False
            Me.XrLabel41.StylePriority.UseTextAlignment = False
            Me.XrLabel41.Text = "XrLabel41"
            Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.BottomMargin.HeightF = 10.16663!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelRevisionDetailsHeader_MarkupAmount, Me.LabelRevisionDetailsHeader_AdServingAmount, Me.LabelRevisionDetailsHeader_Quantity, Me.LabelRevisionDetailsHeader_Rate, Me.XrLine1, Me.LabelRevisionDetailsHeader_Vendor, Me.LabelRevisionDetailsHeader_Amount, Me.LabelRevisionDetailsHeader_MarkupPercent, Me.LabelRevisionDetailsHeader_AdServingPercent, Me.LabelRevisionDetailsHeader_NetSpend, Me.LabelRevisionDetailsHeader_TotalAmount, Me.LabelRevisionDetailsHeader_CostType})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 59.12503!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'LabelRevisionDetailsHeader_MarkupAmount
            '
            Me.LabelRevisionDetailsHeader_MarkupAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_MarkupAmount.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_MarkupAmount.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_MarkupAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_MarkupAmount.LocationFloat = New DevExpress.Utils.PointFloat(428.5831!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_MarkupAmount.Multiline = True
            Me.LabelRevisionDetailsHeader_MarkupAmount.Name = "LabelRevisionDetailsHeader_MarkupAmount"
            Me.LabelRevisionDetailsHeader_MarkupAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_MarkupAmount.SizeF = New System.Drawing.SizeF(59.08328!, 49.13!)
            Me.LabelRevisionDetailsHeader_MarkupAmount.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_MarkupAmount.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_MarkupAmount.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_MarkupAmount.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_MarkupAmount.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_MarkupAmount.Text = "Markup" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.LabelRevisionDetailsHeader_MarkupAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_AdServingAmount
            '
            Me.LabelRevisionDetailsHeader_AdServingAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_AdServingAmount.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_AdServingAmount.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_AdServingAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_AdServingAmount.LocationFloat = New DevExpress.Utils.PointFloat(539.8746!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_AdServingAmount.Multiline = True
            Me.LabelRevisionDetailsHeader_AdServingAmount.Name = "LabelRevisionDetailsHeader_AdServingAmount"
            Me.LabelRevisionDetailsHeader_AdServingAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_AdServingAmount.SizeF = New System.Drawing.SizeF(58.79169!, 49.13!)
            Me.LabelRevisionDetailsHeader_AdServingAmount.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_AdServingAmount.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_AdServingAmount.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_AdServingAmount.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_AdServingAmount.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_AdServingAmount.Text = "Ad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Serving" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.LabelRevisionDetailsHeader_AdServingAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_Quantity
            '
            Me.LabelRevisionDetailsHeader_Quantity.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_Quantity.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_Quantity.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_Quantity.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(154.37!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_Quantity.Name = "LabelRevisionDetailsHeader_Quantity"
            Me.LabelRevisionDetailsHeader_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_Quantity.SizeF = New System.Drawing.SizeF(54.08307!, 49.13!)
            Me.LabelRevisionDetailsHeader_Quantity.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_Quantity.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_Quantity.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_Quantity.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_Quantity.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_Quantity.Text = "Qty"
            Me.LabelRevisionDetailsHeader_Quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_Rate
            '
            Me.LabelRevisionDetailsHeader_Rate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_Rate.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_Rate.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_Rate.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_Rate.LocationFloat = New DevExpress.Utils.PointFloat(208.4531!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_Rate.Name = "LabelRevisionDetailsHeader_Rate"
            Me.LabelRevisionDetailsHeader_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_Rate.SizeF = New System.Drawing.SizeF(64.00333!, 49.13!)
            Me.LabelRevisionDetailsHeader_Rate.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_Rate.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_Rate.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_Rate.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_Rate.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_Rate.Text = "Rate"
            Me.LabelRevisionDetailsHeader_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.75002!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(748.9998!, 7.374996!)
            '
            'LabelRevisionDetailsHeader_Vendor
            '
            Me.LabelRevisionDetailsHeader_Vendor.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_Vendor.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_Vendor.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_Vendor.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.2083337!)
            Me.LabelRevisionDetailsHeader_Vendor.Name = "LabelRevisionDetailsHeader_Vendor"
            Me.LabelRevisionDetailsHeader_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_Vendor.SizeF = New System.Drawing.SizeF(154.37!, 49.13!)
            Me.LabelRevisionDetailsHeader_Vendor.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_Vendor.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_Vendor.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_Vendor.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_Vendor.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_Vendor.Text = "Vendor"
            Me.LabelRevisionDetailsHeader_Vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelRevisionDetailsHeader_Amount
            '
            Me.LabelRevisionDetailsHeader_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_Amount.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_Amount.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_Amount.LocationFloat = New DevExpress.Utils.PointFloat(309.4561!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_Amount.Multiline = True
            Me.LabelRevisionDetailsHeader_Amount.Name = "LabelRevisionDetailsHeader_Amount"
            Me.LabelRevisionDetailsHeader_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_Amount.SizeF = New System.Drawing.SizeF(67.12506!, 49.13!)
            Me.LabelRevisionDetailsHeader_Amount.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_Amount.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_Amount.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_Amount.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_Amount.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_Amount.Text = "Net" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.LabelRevisionDetailsHeader_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_MarkupPercent
            '
            Me.LabelRevisionDetailsHeader_MarkupPercent.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_MarkupPercent.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_MarkupPercent.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_MarkupPercent.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_MarkupPercent.LocationFloat = New DevExpress.Utils.PointFloat(376.5811!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_MarkupPercent.Multiline = True
            Me.LabelRevisionDetailsHeader_MarkupPercent.Name = "LabelRevisionDetailsHeader_MarkupPercent"
            Me.LabelRevisionDetailsHeader_MarkupPercent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_MarkupPercent.SizeF = New System.Drawing.SizeF(52.00189!, 49.13!)
            Me.LabelRevisionDetailsHeader_MarkupPercent.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_MarkupPercent.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_MarkupPercent.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_MarkupPercent.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_MarkupPercent.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_MarkupPercent.Text = "Markup" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%"
            Me.LabelRevisionDetailsHeader_MarkupPercent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_AdServingPercent
            '
            Me.LabelRevisionDetailsHeader_AdServingPercent.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_AdServingPercent.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_AdServingPercent.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_AdServingPercent.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_AdServingPercent.LocationFloat = New DevExpress.Utils.PointFloat(487.6664!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_AdServingPercent.Multiline = True
            Me.LabelRevisionDetailsHeader_AdServingPercent.Name = "LabelRevisionDetailsHeader_AdServingPercent"
            Me.LabelRevisionDetailsHeader_AdServingPercent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_AdServingPercent.SizeF = New System.Drawing.SizeF(52.20822!, 49.13!)
            Me.LabelRevisionDetailsHeader_AdServingPercent.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_AdServingPercent.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_AdServingPercent.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_AdServingPercent.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_AdServingPercent.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_AdServingPercent.Text = "Ad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Serving" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%"
            Me.LabelRevisionDetailsHeader_AdServingPercent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_NetSpend
            '
            Me.LabelRevisionDetailsHeader_NetSpend.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_NetSpend.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_NetSpend.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_NetSpend.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_NetSpend.LocationFloat = New DevExpress.Utils.PointFloat(598.6663!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_NetSpend.Multiline = True
            Me.LabelRevisionDetailsHeader_NetSpend.Name = "LabelRevisionDetailsHeader_NetSpend"
            Me.LabelRevisionDetailsHeader_NetSpend.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_NetSpend.SizeF = New System.Drawing.SizeF(75.41687!, 49.13!)
            Me.LabelRevisionDetailsHeader_NetSpend.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_NetSpend.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_NetSpend.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_NetSpend.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_NetSpend.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_NetSpend.Text = "Net" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Spend"
            Me.LabelRevisionDetailsHeader_NetSpend.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_TotalAmount
            '
            Me.LabelRevisionDetailsHeader_TotalAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_TotalAmount.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_TotalAmount.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_TotalAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_TotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(674.0832!, 0.2083248!)
            Me.LabelRevisionDetailsHeader_TotalAmount.Multiline = True
            Me.LabelRevisionDetailsHeader_TotalAmount.Name = "LabelRevisionDetailsHeader_TotalAmount"
            Me.LabelRevisionDetailsHeader_TotalAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_TotalAmount.SizeF = New System.Drawing.SizeF(75.91718!, 49.13!)
            Me.LabelRevisionDetailsHeader_TotalAmount.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_TotalAmount.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_TotalAmount.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_TotalAmount.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_TotalAmount.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_TotalAmount.Text = "Total Amount"
            Me.LabelRevisionDetailsHeader_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelRevisionDetailsHeader_CostType
            '
            Me.LabelRevisionDetailsHeader_CostType.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRevisionDetailsHeader_CostType.BorderWidth = 1.0!
            Me.LabelRevisionDetailsHeader_CostType.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold)
            Me.LabelRevisionDetailsHeader_CostType.ForeColor = System.Drawing.Color.Black
            Me.LabelRevisionDetailsHeader_CostType.LocationFloat = New DevExpress.Utils.PointFloat(272.4564!, 0.2083282!)
            Me.LabelRevisionDetailsHeader_CostType.Multiline = True
            Me.LabelRevisionDetailsHeader_CostType.Name = "LabelRevisionDetailsHeader_CostType"
            Me.LabelRevisionDetailsHeader_CostType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRevisionDetailsHeader_CostType.SizeF = New System.Drawing.SizeF(36.9996!, 49.13!)
            Me.LabelRevisionDetailsHeader_CostType.StylePriority.UseBorders = False
            Me.LabelRevisionDetailsHeader_CostType.StylePriority.UseBorderWidth = False
            Me.LabelRevisionDetailsHeader_CostType.StylePriority.UseFont = False
            Me.LabelRevisionDetailsHeader_CostType.StylePriority.UseForeColor = False
            Me.LabelRevisionDetailsHeader_CostType.StylePriority.UseTextAlignment = False
            Me.LabelRevisionDetailsHeader_CostType.Text = "Cost" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Type"
            Me.LabelRevisionDetailsHeader_CostType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.XrLabel12, Me.XrLabel13, Me.XrLabel14, Me.XrLabel15, Me.XrLine5})
            Me.GroupFooter1.HeightF = 29.00003!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineTotal")})
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(676.0804!, 10.00001!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(73.92!, 18.99998!)
            Me.XrLabel11.StylePriority.UseFont = False
            Me.XrLabel11.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel11.Summary = XrSummary1
            Me.XrLabel11.Text = "XrLabel11"
            Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel12
            '
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetSpend")})
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(600.6632!, 10.00001!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(73.42!, 18.99998!)
            Me.XrLabel12.StylePriority.UseFont = False
            Me.XrLabel12.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel12.Summary = XrSummary2
            Me.XrLabel12.Text = "XrLabel12"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel13
            '
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetChargeAmount")})
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(541.8763!, 10.00001!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(56.79!, 18.99998!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel13.Summary = XrSummary3
            Me.XrLabel13.Text = "XrLabel13"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel14
            '
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount")})
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(430.5864!, 10.00001!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(57.08!, 19.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            Me.XrLabel14.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel14.Summary = XrSummary4
            Me.XrLabel14.Text = "XrLabel14"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel15
            '
            Me.XrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 7.5!)
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(311.4511!, 10.00001!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(65.13!, 19.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel15.Summary = XrSummary5
            Me.XrLabel15.Text = "XrLabel15"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine5
            '
            Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine5.Name = "XrLine5"
            Me.XrLine5.SizeF = New System.Drawing.SizeF(748.9998!, 7.374996!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.MediaATBRevisionDetail)
            '
            'MediaATBDetailsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter1})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 10)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelRevisionDetailsHeader_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_MarkupPercent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_AdServingPercent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_NetSpend As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_TotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetails_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_Quantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_CostType As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_MarkupAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRevisionDetailsHeader_AdServingAmount As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
