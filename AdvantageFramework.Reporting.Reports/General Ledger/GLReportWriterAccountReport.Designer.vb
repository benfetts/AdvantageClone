Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class GLReportWriterAccountReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrCheckBox4 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrCheckBox3 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrCheckBox2 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrCheckBox1 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_TemplateNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_TemplateName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.XrCheckBox5 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrCheckBox5, Me.XrCheckBox4, Me.XrCheckBox3, Me.XrCheckBox2, Me.XrCheckBox1, Me.XrLabel17, Me.XrLabel16, Me.XrLabel8, Me.XrLabel6, Me.XrLabel3, Me.XrLabel1})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 19.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("RowIndex", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrCheckBox4
            '
            Me.XrCheckBox4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "DoubleUnderlineAmount")})
            Me.XrCheckBox4.Dpi = 100.0!
            Me.XrCheckBox4.LocationFloat = New DevExpress.Utils.PointFloat(697.4996!, 0!)
            Me.XrCheckBox4.Name = "XrCheckBox4"
            Me.XrCheckBox4.SizeF = New System.Drawing.SizeF(47.91656!, 19.0!)
            '
            'XrCheckBox3
            '
            Me.XrCheckBox3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "UnderlineAmount")})
            Me.XrCheckBox3.Dpi = 100.0!
            Me.XrCheckBox3.LocationFloat = New DevExpress.Utils.PointFloat(623.6247!, 0!)
            Me.XrCheckBox3.Name = "XrCheckBox3"
            Me.XrCheckBox3.SizeF = New System.Drawing.SizeF(42.75!, 19.0!)
            '
            'XrCheckBox2
            '
            Me.XrCheckBox2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "IsBold")})
            Me.XrCheckBox2.Dpi = 100.0!
            Me.XrCheckBox2.LocationFloat = New DevExpress.Utils.PointFloat(550.9166!, 0!)
            Me.XrCheckBox2.Name = "XrCheckBox2"
            Me.XrCheckBox2.SizeF = New System.Drawing.SizeF(39.66675!, 19.0!)
            '
            'XrCheckBox1
            '
            Me.XrCheckBox1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "RollUp")})
            Me.XrCheckBox1.Dpi = 100.0!
            Me.XrCheckBox1.LocationFloat = New DevExpress.Utils.PointFloat(500.6663!, 0!)
            Me.XrCheckBox1.Name = "XrCheckBox1"
            Me.XrCheckBox1.SizeF = New System.Drawing.SizeF(29.20834!, 19.0!)
            '
            'XrLabel17
            '
            Me.XrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IndentSpaces")})
            Me.XrLabel17.Dpi = 100.0!
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(441.2496!, 0!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(49.33374!, 19.0!)
            Me.XrLabel17.Text = "XrLabel17"
            '
            'XrLabel16
            '
            Me.XrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisplayType")})
            Me.XrLabel16.Dpi = 100.0!
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(306.0415!, 0!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(122.0417!, 19.0!)
            Me.XrLabel16.Text = "XrLabel16"
            '
            'XrLabel8
            '
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceType")})
            Me.XrLabel8.Dpi = 100.0!
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(236.2498!, 0!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(56.33342!, 19.0!)
            Me.XrLabel8.Text = "XrLabel8"
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Type")})
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(161.0413!, 0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(61.54175!, 19.0!)
            Me.XrLabel6.Text = "XrLabel6"
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RowIndex")})
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(37.45844!, 19.0!)
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "XrLabel3"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.XrLabel1.Dpi = 100.0!
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(47.74997!, 0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.0417!, 19.0!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 48.95833!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel19, Me.LabelPageHeader_TemplateNameLabel, Me.XrLabel15, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel7, Me.XrLabel5, Me.LabelPageHeader_TemplateName, Me.LabelHeader_Description, Me.LabelPageHeader_Agency, Me.LinePageHeader_Bottom, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 119.3751!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_TemplateNameLabel
            '
            Me.LabelPageHeader_TemplateNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_TemplateNameLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TemplateNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_TemplateNameLabel.BorderWidth = 1.0!
            Me.LabelPageHeader_TemplateNameLabel.CanGrow = False
            Me.LabelPageHeader_TemplateNameLabel.Dpi = 100.0!
            Me.LabelPageHeader_TemplateNameLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_TemplateNameLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TemplateNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 65.20834!)
            Me.LabelPageHeader_TemplateNameLabel.Name = "LabelPageHeader_TemplateNameLabel"
            Me.LabelPageHeader_TemplateNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_TemplateNameLabel.SizeF = New System.Drawing.SizeF(97.91666!, 19.0!)
            Me.LabelPageHeader_TemplateNameLabel.StylePriority.UseFont = False
            Me.LabelPageHeader_TemplateNameLabel.Text = "Template Name:"
            Me.LabelPageHeader_TemplateNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Dpi = 100.0!
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(697.4997!, 90.37508!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(109.4999!, 29.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.Text = "Double Underline Amount"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel14
            '
            Me.XrLabel14.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel14.BorderColor = System.Drawing.Color.Black
            Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel14.BorderWidth = 1.0!
            Me.XrLabel14.CanGrow = False
            Me.XrLabel14.Dpi = 100.0!
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.ForeColor = System.Drawing.Color.Black
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(623.6247!, 90.37508!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(57.37506!, 29.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            Me.XrLabel14.Text = "Underline Amount"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1.0!
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.Dpi = 100.0!
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel13.ForeColor = System.Drawing.Color.Black
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(550.9166!, 90.37508!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(61.50005!, 19.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.Text = "Bold"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel12
            '
            Me.XrLabel12.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel12.BorderColor = System.Drawing.Color.Black
            Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel12.BorderWidth = 1.0!
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.Dpi = 100.0!
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.ForeColor = System.Drawing.Color.Black
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(500.708!, 90.37508!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(39.66675!, 29.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            Me.XrLabel12.Text = "Roll Up"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel11
            '
            Me.XrLabel11.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel11.BorderColor = System.Drawing.Color.Black
            Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel11.BorderWidth = 1.0!
            Me.XrLabel11.CanGrow = False
            Me.XrLabel11.Dpi = 100.0!
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.ForeColor = System.Drawing.Color.Black
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(441.2913!, 90.37508!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(49.29205!, 29.00001!)
            Me.XrLabel11.StylePriority.UseFont = False
            Me.XrLabel11.Text = "Indent Spaces"
            Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1.0!
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.Dpi = 100.0!
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.ForeColor = System.Drawing.Color.Black
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(305.9164!, 90.37508!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(66.79166!, 29.00001!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.Text = "Display Type"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel9
            '
            Me.XrLabel9.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel9.BorderColor = System.Drawing.Color.Black
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel9.BorderWidth = 1.0!
            Me.XrLabel9.CanGrow = False
            Me.XrLabel9.Dpi = 100.0!
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.ForeColor = System.Drawing.Color.Black
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(236.2915!, 100.3751!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(56.29172!, 19.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            Me.XrLabel9.Text = "Balance"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1.0!
            Me.XrLabel7.CanGrow = False
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.ForeColor = System.Drawing.Color.Black
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(161.0413!, 100.3751!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(61.50005!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.Text = "Row Type"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.ForeColor = System.Drawing.Color.Black
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 90.37508!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(37.41673!, 29.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.Text = "Row Index"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_TemplateName
            '
            Me.LabelPageHeader_TemplateName.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_TemplateName.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TemplateName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_TemplateName.BorderWidth = 1.0!
            Me.LabelPageHeader_TemplateName.CanGrow = False
            Me.LabelPageHeader_TemplateName.Dpi = 100.0!
            Me.LabelPageHeader_TemplateName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_TemplateName.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TemplateName.LocationFloat = New DevExpress.Utils.PointFloat(107.0831!, 65.20834!)
            Me.LabelPageHeader_TemplateName.Name = "LabelPageHeader_TemplateName"
            Me.LabelPageHeader_TemplateName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_TemplateName.SizeF = New System.Drawing.SizeF(674.8333!, 18.58334!)
            Me.LabelPageHeader_TemplateName.StylePriority.UseBackColor = False
            Me.LabelPageHeader_TemplateName.StylePriority.UseFont = False
            Me.LabelPageHeader_TemplateName.StylePriority.UseForeColor = False
            Me.LabelPageHeader_TemplateName.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_TemplateName.Text = "TemplateName"
            Me.LabelPageHeader_TemplateName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_Description
            '
            Me.LabelHeader_Description.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Description.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Description.BorderWidth = 1.0!
            Me.LabelHeader_Description.CanGrow = False
            Me.LabelHeader_Description.Dpi = 100.0!
            Me.LabelHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Description.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(47.79167!, 100.3751!)
            Me.LabelHeader_Description.Name = "LabelHeader_Description"
            Me.LabelHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Description.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelHeader_Description.StylePriority.UseFont = False
            Me.LabelHeader_Description.Text = "Description"
            Me.LabelHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Dpi = 100.0!
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "GL Row Format"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.Dpi = 100.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.08337!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.Dpi = 100.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportTitle.CanGrow = False
            Me.LabelPageHeader_ReportTitle.Dpi = 100.0!
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "GL Row Format"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Dpi = 100.0!
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083347!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LinePageFooter, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.Dpi = 100.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Dpi = 100.0!
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083347!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_Date
            '
            Me.LabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Date.BorderWidth = 1.0!
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Dpi = 100.0!
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 4.083379!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(234.9999!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'DetailReport
            '
            Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1, Me.GroupHeader1})
            Me.DetailReport.DataMember = "GLReportWriterAccountReportList"
            Me.DetailReport.DataSource = Me.BindingSource
            Me.DetailReport.Dpi = 100.0!
            Me.DetailReport.Level = 0
            Me.DetailReport.Name = "DetailReport"
            '
            'Detail1
            '
            Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4})
            Me.Detail1.Dpi = 100.0!
            Me.Detail1.HeightF = 19.0!
            Me.Detail1.Name = "Detail1"
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLReportWriterAccountReportList.GLACodeDescription")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(107.0414!, 0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(882.9586!, 19.0!)
            Me.XrLabel4.Text = "XrLabel4"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel18, Me.XrLabel2})
            Me.GroupHeader1.Dpi = 100.0!
            Me.GroupHeader1.HeightF = 19.0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'XrLabel18
            '
            Me.XrLabel18.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel18.BorderColor = System.Drawing.Color.Black
            Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel18.BorderWidth = 1.0!
            Me.XrLabel18.CanGrow = False
            Me.XrLabel18.Dpi = 100.0!
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel18.ForeColor = System.Drawing.Color.Black
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(9.958267!, 0!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(87.9584!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            Me.XrLabel18.Text = "Account Type:"
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLReportWriterAccountReportList.GLAType")})
            Me.XrLabel2.Dpi = 100.0!
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(107.9166!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(99.99998!, 19.0!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport)
            '
            'XrCheckBox5
            '
            Me.XrCheckBox5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "SuppressIfAllZeros")})
            Me.XrCheckBox5.Dpi = 100.0!
            Me.XrCheckBox5.LocationFloat = New DevExpress.Utils.PointFloat(812.4166!, 0!)
            Me.XrCheckBox5.Name = "XrCheckBox5"
            Me.XrCheckBox5.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            '
            'XrLabel19
            '
            Me.XrLabel19.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel19.BorderColor = System.Drawing.Color.Black
            Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel19.BorderWidth = 1.0!
            Me.XrLabel19.CanGrow = False
            Me.XrLabel19.Dpi = 100.0!
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel19.ForeColor = System.Drawing.Color.Black
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(812.4166!, 90.37508!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(109.4999!, 29.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            Me.XrLabel19.Text = "Suppress If All Zeros"
            Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GLReportWriterAccountReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.DetailReport})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReport As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_TemplateName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrCheckBox2 As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrCheckBox1 As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_TemplateNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrCheckBox4 As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrCheckBox3 As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrCheckBox5 As DevExpress.XtraReports.UI.XRCheckBox
        Private WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
