Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class BankReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Time = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Database = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel18, Me.XrLabel16, Me.XrLabel17, Me.XrLabel14, Me.XrLabel11, Me.XrLabel9, Me.XrLabel7, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1})
            Me.Detail.HeightF = 49.125!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel18
            '
            Me.XrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "GeneralLedgerAccount7.Description")})
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(597.8337!, 22.99999!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(147.0832!, 23.0!)
            Me.XrLabel18.Text = "XrLabel18"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Bank)
            '
            'XrLabel16
            '
            Me.XrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "GeneralLedgerAccount5.Description")})
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(752.9167!, 22.99999!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(147.0832!, 23.0!)
            Me.XrLabel16.Text = "XrLabel16"
            '
            'XrLabel17
            '
            Me.XrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "CurrencyCode")})
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(44.79167!, 22.99999!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel17.Text = "XrLabel17"
            '
            'XrLabel14
            '
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "APCashAccount")})
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(752.9167!, 0.0!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(147.0831!, 23.0!)
            Me.XrLabel14.Text = "XrLabel14"
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "ARCashAccount")})
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(597.8337!, 0.0!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(147.0831!, 23.0!)
            Me.XrLabel11.Text = "XrLabel11"
            '
            'XrLabel9
            '
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "LastManualCheck")})
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(526.2087!, 0.0!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(65.62503!, 23.0!)
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            Me.XrLabel9.Text = "XrLabel9"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "LastComputerCheck")})
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(449.1254!, 0.0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.62503!, 23.0!)
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            Me.XrLabel7.Text = "XrLabel7"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "AccountNumber")})
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(312.9587!, 0.0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(129.1667!, 23.0!)
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "Description")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(44.79167!, 0.0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(257.2917!, 23.0!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSource, "Code")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(36.45833!, 23.0!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'TopMargin
            '
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.LabelPageHeader_Date, Me.LabelPageHeader_Time, Me.LabelPageHeader_Database, Me.XrLabel13, Me.XrLabel15, Me.XrLabel12, Me.XrLabel10, Me.XrLabel8, Me.XrLabel6, Me.XrLabel5, Me.XrLabel3, Me.XrLine1, Me.XrLabel19, Me.LineTopLine, Me.XrLabel20})
            Me.PageHeader.HeightF = 117.7083!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 0
            Me.XrLine2.ForeColor = System.Drawing.Color.Black
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 107.7083!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(900.0!, 4.000004!)
            Me.XrLine2.StylePriority.UseBorderColor = False
            Me.XrLine2.StylePriority.UseBorderWidth = False
            Me.XrLine2.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_Date
            '
            Me.LabelPageHeader_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Date.BorderWidth = 1
            Me.LabelPageHeader_Date.CanGrow = False
            Me.LabelPageHeader_Date.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelPageHeader_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Date.LocationFloat = New DevExpress.Utils.PointFloat(752.9167!, 44.0!)
            Me.LabelPageHeader_Date.Name = "LabelPageHeader_Date"
            Me.LabelPageHeader_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Date.SizeF = New System.Drawing.SizeF(147.0832!, 19.0!)
            Me.LabelPageHeader_Date.StylePriority.UseFont = False
            Me.LabelPageHeader_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Time
            '
            Me.LabelPageHeader_Time.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Time.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Time.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Time.BorderWidth = 1
            Me.LabelPageHeader_Time.CanGrow = False
            Me.LabelPageHeader_Time.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelPageHeader_Time.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Time.LocationFloat = New DevExpress.Utils.PointFloat(752.9167!, 24.00001!)
            Me.LabelPageHeader_Time.Name = "LabelPageHeader_Time"
            Me.LabelPageHeader_Time.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Time.SizeF = New System.Drawing.SizeF(147.0832!, 19.0!)
            Me.LabelPageHeader_Time.StylePriority.UseFont = False
            Me.LabelPageHeader_Time.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Time.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Database
            '
            Me.LabelPageHeader_Database.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Database.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Database.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Database.BorderWidth = 1
            Me.LabelPageHeader_Database.CanGrow = False
            Me.LabelPageHeader_Database.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelPageHeader_Database.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Database.LocationFloat = New DevExpress.Utils.PointFloat(55.00005!, 24.00001!)
            Me.LabelPageHeader_Database.Name = "LabelPageHeader_Database"
            Me.LabelPageHeader_Database.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Database.SizeF = New System.Drawing.SizeF(147.0832!, 19.0!)
            Me.LabelPageHeader_Database.StylePriority.UseFont = False
            Me.LabelPageHeader_Database.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel13.ForeColor = System.Drawing.Color.Black
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 24.00001!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(55.0!, 19.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.Text = "Database:"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(752.9167!, 88.70831!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(120.8333!, 19.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.StylePriority.UseTextAlignment = False
            Me.XrLabel15.Text = "A/P Cash Account"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel12
            '
            Me.XrLabel12.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel12.BorderColor = System.Drawing.Color.Black
            Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel12.BorderWidth = 1
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel12.ForeColor = System.Drawing.Color.Black
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(597.8337!, 88.70831!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(120.8333!, 19.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            Me.XrLabel12.StylePriority.UseTextAlignment = False
            Me.XrLabel12.Text = "A/R Cash Account"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel10.ForeColor = System.Drawing.Color.Black
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(526.2087!, 88.70831!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(65.62503!, 19.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.StylePriority.UseTextAlignment = False
            Me.XrLabel10.Text = "Manual"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel8.BorderColor = System.Drawing.Color.Black
            Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel8.BorderWidth = 1
            Me.XrLabel8.CanGrow = False
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel8.ForeColor = System.Drawing.Color.Black
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(449.1254!, 88.70831!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(65.62506!, 19.0!)
            Me.XrLabel8.StylePriority.UseFont = False
            Me.XrLabel8.StylePriority.UseTextAlignment = False
            Me.XrLabel8.Text = "Computer"
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel6.BorderWidth = 1
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel6.ForeColor = System.Drawing.Color.Black
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(449.1254!, 72.70829!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(142.7083!, 16.0!)
            Me.XrLabel6.StylePriority.UseBorders = False
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "Last Check Used"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.ForeColor = System.Drawing.Color.Black
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(312.9588!, 88.70831!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(112.5!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.Text = "Bank Account Nbr."
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(44.79167!, 88.70831!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.Text = "Description / Currency"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 63.7083!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(900.0!, 4.000004!)
            '
            'XrLabel19
            '
            Me.XrLabel19.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel19.BorderColor = System.Drawing.Color.Black
            Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel19.BorderWidth = 1
            Me.XrLabel19.CanGrow = False
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel19.ForeColor = System.Drawing.Color.Black
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 88.70831!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(36.45833!, 19.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            Me.XrLabel19.Text = "Code"
            Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(900.0!, 4.000004!)
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.ForeColor = System.Drawing.Color.Black
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(301.0417!, 20.00001!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(301.0417!, 26.0!)
            Me.XrLabel20.StylePriority.UseBackColor = False
            Me.XrLabel20.StylePriority.UseFont = False
            Me.XrLabel20.StylePriority.UseForeColor = False
            Me.XrLabel20.StylePriority.UseTextAlignment = False
            Me.XrLabel20.Text = "Bank Report"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
            Me.PageFooter.HeightF = 22.91667!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrPageInfo1
            '
            Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo1.Format = "Page {0} of {1}"
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(349.8332!, 0.0!)
            Me.XrPageInfo1.Name = "XrPageInfo1"
            Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(201.2085!, 20.99997!)
            Me.XrPageInfo1.StylePriority.UseFont = False
            Me.XrPageInfo1.StylePriority.UseTextAlignment = False
            Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'BankReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Database As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Time As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    End Class

End Namespace
