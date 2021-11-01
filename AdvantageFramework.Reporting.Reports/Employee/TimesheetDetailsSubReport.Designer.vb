Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TimesheetDetailsSubReport
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
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Label_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Saturday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Friday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Thursday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Wednesday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Tuesday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Monday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Sunday = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Department = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_FunctionCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Comp = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProductCat = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelHeader_Department = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelHeader_Sunday = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_FunctionCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Component = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_ProductCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Monday = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelFooter_WeekTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_SaturdayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_FridayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_ThursdayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_WednesdayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_TuesdayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_MondayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineFooter_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelFooter_Totals = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_SundayTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.EntryHoursSum = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_Total, Me.Label_Saturday, Me.Label_Friday, Me.Label_Thursday, Me.Label_Wednesday, Me.Label_Tuesday, Me.Label_Monday, Me.Label_Sunday, Me.Label_Department, Me.Label_FunctionCategory, Me.Label_Comp, Me.Label_Job, Me.Label_ProductCat, Me.Label_Product, Me.Label_Division, Me.Label_Client})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 19.87502!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Total
            '
            Me.Label_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EntryHoursSum")})
            Me.Label_Total.Dpi = 100.0!
            Me.Label_Total.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Total.LocationFloat = New DevExpress.Utils.PointFloat(943.0001!, 0!)
            Me.Label_Total.Name = "Label_Total"
            Me.Label_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Total.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Total.StylePriority.UseFont = False
            Me.Label_Total.StylePriority.UseTextAlignment = False
            Me.Label_Total.Text = "Label_Total"
            Me.Label_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Saturday
            '
            Me.Label_Saturday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day7Hours", "{0:n2}")})
            Me.Label_Saturday.Dpi = 100.0!
            Me.Label_Saturday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Saturday.LocationFloat = New DevExpress.Utils.PointFloat(887.0!, 0!)
            Me.Label_Saturday.Name = "Label_Saturday"
            Me.Label_Saturday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Saturday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Saturday.StylePriority.UseFont = False
            Me.Label_Saturday.StylePriority.UseTextAlignment = False
            Me.Label_Saturday.Text = "Label_Saturday"
            Me.Label_Saturday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Friday
            '
            Me.Label_Friday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day6Hours", "{0:n2}")})
            Me.Label_Friday.Dpi = 100.0!
            Me.Label_Friday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Friday.LocationFloat = New DevExpress.Utils.PointFloat(831.0!, 0!)
            Me.Label_Friday.Name = "Label_Friday"
            Me.Label_Friday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Friday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Friday.StylePriority.UseFont = False
            Me.Label_Friday.StylePriority.UseTextAlignment = False
            Me.Label_Friday.Text = "Label_Friday"
            Me.Label_Friday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Thursday
            '
            Me.Label_Thursday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day5Hours", "{0:n2}")})
            Me.Label_Thursday.Dpi = 100.0!
            Me.Label_Thursday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Thursday.LocationFloat = New DevExpress.Utils.PointFloat(775.0!, 0!)
            Me.Label_Thursday.Name = "Label_Thursday"
            Me.Label_Thursday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Thursday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Thursday.StylePriority.UseFont = False
            Me.Label_Thursday.StylePriority.UseTextAlignment = False
            Me.Label_Thursday.Text = "Label_Thursday"
            Me.Label_Thursday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Wednesday
            '
            Me.Label_Wednesday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day4Hours", "{0:n2}")})
            Me.Label_Wednesday.Dpi = 100.0!
            Me.Label_Wednesday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Wednesday.LocationFloat = New DevExpress.Utils.PointFloat(719.0!, 0!)
            Me.Label_Wednesday.Name = "Label_Wednesday"
            Me.Label_Wednesday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Wednesday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Wednesday.StylePriority.UseFont = False
            Me.Label_Wednesday.StylePriority.UseTextAlignment = False
            Me.Label_Wednesday.Text = "Label_Wednesday"
            Me.Label_Wednesday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Tuesday
            '
            Me.Label_Tuesday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day3Hours", "{0:n2}")})
            Me.Label_Tuesday.Dpi = 100.0!
            Me.Label_Tuesday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Tuesday.LocationFloat = New DevExpress.Utils.PointFloat(663.0!, 0!)
            Me.Label_Tuesday.Name = "Label_Tuesday"
            Me.Label_Tuesday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Tuesday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Tuesday.StylePriority.UseFont = False
            Me.Label_Tuesday.StylePriority.UseTextAlignment = False
            Me.Label_Tuesday.Text = "Label_Tuesday"
            Me.Label_Tuesday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Monday
            '
            Me.Label_Monday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day2Hours", "{0:n2}")})
            Me.Label_Monday.Dpi = 100.0!
            Me.Label_Monday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Monday.LocationFloat = New DevExpress.Utils.PointFloat(607.0!, 0!)
            Me.Label_Monday.Name = "Label_Monday"
            Me.Label_Monday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Monday.SizeF = New System.Drawing.SizeF(56.0!, 18.0!)
            Me.Label_Monday.StylePriority.UseFont = False
            Me.Label_Monday.StylePriority.UseTextAlignment = False
            Me.Label_Monday.Text = "Label_Monday"
            Me.Label_Monday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Sunday
            '
            Me.Label_Sunday.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day1Hours", "{0:n2}")})
            Me.Label_Sunday.Dpi = 100.0!
            Me.Label_Sunday.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Sunday.LocationFloat = New DevExpress.Utils.PointFloat(550.9999!, 0!)
            Me.Label_Sunday.Name = "Label_Sunday"
            Me.Label_Sunday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Sunday.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.Label_Sunday.StylePriority.UseFont = False
            Me.Label_Sunday.StylePriority.UseTextAlignment = False
            Me.Label_Sunday.Text = "Label_Sunday"
            Me.Label_Sunday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Department
            '
            Me.Label_Department.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeamCode")})
            Me.Label_Department.Dpi = 100.0!
            Me.Label_Department.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Department.LocationFloat = New DevExpress.Utils.PointFloat(482.1299!, 0!)
            Me.Label_Department.Name = "Label_Department"
            Me.Label_Department.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Department.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Department.StylePriority.UseFont = False
            Me.Label_Department.Text = "Label_Department"
            '
            'Label_FunctionCategory
            '
            Me.Label_FunctionCategory.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCode")})
            Me.Label_FunctionCategory.Dpi = 100.0!
            Me.Label_FunctionCategory.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_FunctionCategory.LocationFloat = New DevExpress.Utils.PointFloat(413.2599!, 0!)
            Me.Label_FunctionCategory.Name = "Label_FunctionCategory"
            Me.Label_FunctionCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FunctionCategory.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_FunctionCategory.StylePriority.UseFont = False
            Me.Label_FunctionCategory.Text = "Label_FunctionCategory"
            '
            'Label_Comp
            '
            Me.Label_Comp.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobCompNumber")})
            Me.Label_Comp.Dpi = 100.0!
            Me.Label_Comp.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Comp.LocationFloat = New DevExpress.Utils.PointFloat(344.3899!, 0!)
            Me.Label_Comp.Name = "Label_Comp"
            Me.Label_Comp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Comp.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Comp.StylePriority.UseFont = False
            Me.Label_Comp.Text = "Label_Comp"
            '
            'Label_Job
            '
            Me.Label_Job.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.Label_Job.Dpi = 100.0!
            Me.Label_Job.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Job.LocationFloat = New DevExpress.Utils.PointFloat(275.5198!, 0!)
            Me.Label_Job.Name = "Label_Job"
            Me.Label_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Job.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Job.StylePriority.UseFont = False
            Me.Label_Job.Text = "Label_Job"
            '
            'Label_ProductCat
            '
            Me.Label_ProductCat.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCategoryCode")})
            Me.Label_ProductCat.Dpi = 100.0!
            Me.Label_ProductCat.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ProductCat.LocationFloat = New DevExpress.Utils.PointFloat(206.6498!, 0!)
            Me.Label_ProductCat.Name = "Label_ProductCat"
            Me.Label_ProductCat.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ProductCat.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_ProductCat.StylePriority.UseFont = False
            Me.Label_ProductCat.Text = "Label_ProductCat"
            '
            'Label_Product
            '
            Me.Label_Product.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.Label_Product.Dpi = 100.0!
            Me.Label_Product.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Product.LocationFloat = New DevExpress.Utils.PointFloat(137.7797!, 0!)
            Me.Label_Product.Name = "Label_Product"
            Me.Label_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Product.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Product.StylePriority.UseFont = False
            Me.Label_Product.Text = "Label_Product"
            '
            'Label_Division
            '
            Me.Label_Division.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.Label_Division.Dpi = 100.0!
            Me.Label_Division.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Division.LocationFloat = New DevExpress.Utils.PointFloat(68.90971!, 0!)
            Me.Label_Division.Name = "Label_Division"
            Me.Label_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Division.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Division.StylePriority.UseFont = False
            Me.Label_Division.Text = "Label_Division"
            '
            'Label_Client
            '
            Me.Label_Client.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.Label_Client.Dpi = 100.0!
            Me.Label_Client.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Client.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Label_Client.Name = "Label_Client"
            Me.Label_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Client.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.Label_Client.StylePriority.UseFont = False
            Me.Label_Client.Text = "Label_Client"
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 2.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_Department
            '
            Me.LabelHeader_Department.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Department.Dpi = 100.0!
            Me.LabelHeader_Department.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Department.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Department.LocationFloat = New DevExpress.Utils.PointFloat(482.1299!, 0.003321965!)
            Me.LabelHeader_Department.Name = "LabelHeader_Department"
            Me.LabelHeader_Department.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Department.SizeF = New System.Drawing.SizeF(68.87!, 17.58!)
            Me.LabelHeader_Department.StylePriority.UseBorders = False
            Me.LabelHeader_Department.StylePriority.UseFont = False
            Me.LabelHeader_Department.StylePriority.UseForeColor = False
            Me.LabelHeader_Department.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Department.Text = "Dept"
            Me.LabelHeader_Department.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Client
            '
            Me.LabelHeader_Client.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Client.Dpi = 100.0!
            Me.LabelHeader_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Client.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Client.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelHeader_Client.Name = "LabelHeader_Client"
            Me.LabelHeader_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Client.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_Client.StylePriority.UseBorders = False
            Me.LabelHeader_Client.StylePriority.UseFont = False
            Me.LabelHeader_Client.StylePriority.UseForeColor = False
            Me.LabelHeader_Client.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Client.Text = "Client"
            Me.LabelHeader_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_Sunday, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.LabelHeader_FunctionCategory, Me.LabelHeader_Component, Me.LabelHeader_Job, Me.LabelHeader_ProductCategory, Me.LabelHeader_Product, Me.LabelHeader_Division, Me.LabelHeader_Monday, Me.LabelHeader_Client, Me.LabelHeader_Department})
            Me.GroupHeader.Dpi = 100.0!
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 17.58665!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'LabelHeader_Sunday
            '
            Me.LabelHeader_Sunday.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Sunday.Dpi = 100.0!
            Me.LabelHeader_Sunday.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Sunday.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Sunday.LocationFloat = New DevExpress.Utils.PointFloat(550.9999!, 0!)
            Me.LabelHeader_Sunday.Name = "LabelHeader_Sunday"
            Me.LabelHeader_Sunday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Sunday.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.LabelHeader_Sunday.StylePriority.UseBorders = False
            Me.LabelHeader_Sunday.StylePriority.UseFont = False
            Me.LabelHeader_Sunday.StylePriority.UseForeColor = False
            Me.LabelHeader_Sunday.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Sunday.Text = "Sun"
            Me.LabelHeader_Sunday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel7
            '
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.ForeColor = System.Drawing.Color.Black
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(943.0001!, 0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel7.StylePriority.UseBorders = False
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseForeColor = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            Me.XrLabel7.Text = "Total"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel6
            '
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.ForeColor = System.Drawing.Color.Black
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(887.0!, 0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel6.StylePriority.UseBorders = False
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseForeColor = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "Sat"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel5
            '
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.ForeColor = System.Drawing.Color.Black
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(831.0!, 0!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel5.StylePriority.UseBorders = False
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseForeColor = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            Me.XrLabel5.Text = "Fri"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel4
            '
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.ForeColor = System.Drawing.Color.Black
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(775.0!, 0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel4.StylePriority.UseBorders = False
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseForeColor = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.Text = "Thu"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel3
            '
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(719.0!, 0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel3.StylePriority.UseBorders = False
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseForeColor = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Wed"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabel2
            '
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel2.Dpi = 100.0!
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(663.0!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.XrLabel2.StylePriority.UseBorders = False
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseForeColor = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "Tue"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'LabelHeader_FunctionCategory
            '
            Me.LabelHeader_FunctionCategory.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_FunctionCategory.Dpi = 100.0!
            Me.LabelHeader_FunctionCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_FunctionCategory.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_FunctionCategory.LocationFloat = New DevExpress.Utils.PointFloat(413.2599!, 0!)
            Me.LabelHeader_FunctionCategory.Name = "LabelHeader_FunctionCategory"
            Me.LabelHeader_FunctionCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_FunctionCategory.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_FunctionCategory.StylePriority.UseBorders = False
            Me.LabelHeader_FunctionCategory.StylePriority.UseFont = False
            Me.LabelHeader_FunctionCategory.StylePriority.UseForeColor = False
            Me.LabelHeader_FunctionCategory.StylePriority.UseTextAlignment = False
            Me.LabelHeader_FunctionCategory.Text = "Func/Cat"
            Me.LabelHeader_FunctionCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Component
            '
            Me.LabelHeader_Component.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Component.Dpi = 100.0!
            Me.LabelHeader_Component.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Component.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Component.LocationFloat = New DevExpress.Utils.PointFloat(344.3899!, 0.003321965!)
            Me.LabelHeader_Component.Name = "LabelHeader_Component"
            Me.LabelHeader_Component.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Component.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_Component.StylePriority.UseBorders = False
            Me.LabelHeader_Component.StylePriority.UseFont = False
            Me.LabelHeader_Component.StylePriority.UseForeColor = False
            Me.LabelHeader_Component.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Component.Text = "Comp"
            Me.LabelHeader_Component.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Job
            '
            Me.LabelHeader_Job.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Job.Dpi = 100.0!
            Me.LabelHeader_Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Job.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Job.LocationFloat = New DevExpress.Utils.PointFloat(275.5198!, 0.003321965!)
            Me.LabelHeader_Job.Name = "LabelHeader_Job"
            Me.LabelHeader_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Job.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_Job.StylePriority.UseBorders = False
            Me.LabelHeader_Job.StylePriority.UseFont = False
            Me.LabelHeader_Job.StylePriority.UseForeColor = False
            Me.LabelHeader_Job.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Job.Text = "Job"
            Me.LabelHeader_Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_ProductCategory
            '
            Me.LabelHeader_ProductCategory.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_ProductCategory.Dpi = 100.0!
            Me.LabelHeader_ProductCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_ProductCategory.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_ProductCategory.LocationFloat = New DevExpress.Utils.PointFloat(206.6498!, 0!)
            Me.LabelHeader_ProductCategory.Name = "LabelHeader_ProductCategory"
            Me.LabelHeader_ProductCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_ProductCategory.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_ProductCategory.StylePriority.UseBorders = False
            Me.LabelHeader_ProductCategory.StylePriority.UseFont = False
            Me.LabelHeader_ProductCategory.StylePriority.UseForeColor = False
            Me.LabelHeader_ProductCategory.StylePriority.UseTextAlignment = False
            Me.LabelHeader_ProductCategory.Text = "Prod Cat"
            Me.LabelHeader_ProductCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Product
            '
            Me.LabelHeader_Product.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Product.Dpi = 100.0!
            Me.LabelHeader_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(137.7797!, 0!)
            Me.LabelHeader_Product.Name = "LabelHeader_Product"
            Me.LabelHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Product.SizeF = New System.Drawing.SizeF(68.87!, 17.58332!)
            Me.LabelHeader_Product.StylePriority.UseBorders = False
            Me.LabelHeader_Product.StylePriority.UseFont = False
            Me.LabelHeader_Product.StylePriority.UseForeColor = False
            Me.LabelHeader_Product.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Product.Text = "Product"
            Me.LabelHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Division
            '
            Me.LabelHeader_Division.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Division.Dpi = 100.0!
            Me.LabelHeader_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Division.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Division.LocationFloat = New DevExpress.Utils.PointFloat(68.87003!, 0!)
            Me.LabelHeader_Division.Name = "LabelHeader_Division"
            Me.LabelHeader_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Division.SizeF = New System.Drawing.SizeF(68.90971!, 17.58332!)
            Me.LabelHeader_Division.StylePriority.UseBorders = False
            Me.LabelHeader_Division.StylePriority.UseFont = False
            Me.LabelHeader_Division.StylePriority.UseForeColor = False
            Me.LabelHeader_Division.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Division.Text = "Division"
            Me.LabelHeader_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Monday
            '
            Me.LabelHeader_Monday.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Monday.Dpi = 100.0!
            Me.LabelHeader_Monday.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Monday.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Monday.LocationFloat = New DevExpress.Utils.PointFloat(607.0!, 0!)
            Me.LabelHeader_Monday.Name = "LabelHeader_Monday"
            Me.LabelHeader_Monday.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Monday.SizeF = New System.Drawing.SizeF(56.0!, 17.58332!)
            Me.LabelHeader_Monday.StylePriority.UseBorders = False
            Me.LabelHeader_Monday.StylePriority.UseFont = False
            Me.LabelHeader_Monday.StylePriority.UseForeColor = False
            Me.LabelHeader_Monday.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Monday.Text = "Mon"
            Me.LabelHeader_Monday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelFooter_WeekTotal, Me.LabelFooter_SaturdayTotal, Me.LabelFooter_FridayTotal, Me.LabelFooter_ThursdayTotal, Me.LabelFooter_WednesdayTotal, Me.LabelFooter_TuesdayTotal, Me.LabelFooter_MondayTotal, Me.LineFooter_Bottom, Me.LabelFooter_Totals, Me.LabelFooter_SundayTotal, Me.LineFooter_Top})
            Me.GroupFooter1.Dpi = 100.0!
            Me.GroupFooter1.HeightF = 41.66667!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'LabelFooter_WeekTotal
            '
            Me.LabelFooter_WeekTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EntryHoursSum")})
            Me.LabelFooter_WeekTotal.Dpi = 100.0!
            Me.LabelFooter_WeekTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_WeekTotal.LocationFloat = New DevExpress.Utils.PointFloat(943.0001!, 10.00001!)
            Me.LabelFooter_WeekTotal.Name = "LabelFooter_WeekTotal"
            Me.LabelFooter_WeekTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_WeekTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_WeekTotal.StylePriority.UseFont = False
            Me.LabelFooter_WeekTotal.StylePriority.UseTextAlignment = False
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_WeekTotal.Summary = XrSummary1
            Me.LabelFooter_WeekTotal.Text = "LabelFooter_WeekTotal"
            Me.LabelFooter_WeekTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_SaturdayTotal
            '
            Me.LabelFooter_SaturdayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day7Hours")})
            Me.LabelFooter_SaturdayTotal.Dpi = 100.0!
            Me.LabelFooter_SaturdayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_SaturdayTotal.LocationFloat = New DevExpress.Utils.PointFloat(887.0!, 10.00001!)
            Me.LabelFooter_SaturdayTotal.Name = "LabelFooter_SaturdayTotal"
            Me.LabelFooter_SaturdayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_SaturdayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_SaturdayTotal.StylePriority.UseFont = False
            Me.LabelFooter_SaturdayTotal.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_SaturdayTotal.Summary = XrSummary2
            Me.LabelFooter_SaturdayTotal.Text = "LabelFooter_SaturdayTotal"
            Me.LabelFooter_SaturdayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_FridayTotal
            '
            Me.LabelFooter_FridayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day6Hours")})
            Me.LabelFooter_FridayTotal.Dpi = 100.0!
            Me.LabelFooter_FridayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_FridayTotal.LocationFloat = New DevExpress.Utils.PointFloat(831.0!, 10.00001!)
            Me.LabelFooter_FridayTotal.Name = "LabelFooter_FridayTotal"
            Me.LabelFooter_FridayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_FridayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_FridayTotal.StylePriority.UseFont = False
            Me.LabelFooter_FridayTotal.StylePriority.UseTextAlignment = False
            XrSummary3.IgnoreNullValues = True
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_FridayTotal.Summary = XrSummary3
            Me.LabelFooter_FridayTotal.Text = "LabelFooter_FridayTotal"
            Me.LabelFooter_FridayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_ThursdayTotal
            '
            Me.LabelFooter_ThursdayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day5Hours")})
            Me.LabelFooter_ThursdayTotal.Dpi = 100.0!
            Me.LabelFooter_ThursdayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_ThursdayTotal.LocationFloat = New DevExpress.Utils.PointFloat(775.0!, 10.00001!)
            Me.LabelFooter_ThursdayTotal.Name = "LabelFooter_ThursdayTotal"
            Me.LabelFooter_ThursdayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_ThursdayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_ThursdayTotal.StylePriority.UseFont = False
            Me.LabelFooter_ThursdayTotal.StylePriority.UseTextAlignment = False
            XrSummary4.IgnoreNullValues = True
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_ThursdayTotal.Summary = XrSummary4
            Me.LabelFooter_ThursdayTotal.Text = "LabelFooter_ThursdayTotal"
            Me.LabelFooter_ThursdayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_WednesdayTotal
            '
            Me.LabelFooter_WednesdayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day4Hours")})
            Me.LabelFooter_WednesdayTotal.Dpi = 100.0!
            Me.LabelFooter_WednesdayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_WednesdayTotal.LocationFloat = New DevExpress.Utils.PointFloat(719.0!, 10.00001!)
            Me.LabelFooter_WednesdayTotal.Name = "LabelFooter_WednesdayTotal"
            Me.LabelFooter_WednesdayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_WednesdayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_WednesdayTotal.StylePriority.UseFont = False
            Me.LabelFooter_WednesdayTotal.StylePriority.UseTextAlignment = False
            XrSummary5.IgnoreNullValues = True
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_WednesdayTotal.Summary = XrSummary5
            Me.LabelFooter_WednesdayTotal.Text = "LabelFooter_WednesdayTotal"
            Me.LabelFooter_WednesdayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_TuesdayTotal
            '
            Me.LabelFooter_TuesdayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day3Hours")})
            Me.LabelFooter_TuesdayTotal.Dpi = 100.0!
            Me.LabelFooter_TuesdayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_TuesdayTotal.LocationFloat = New DevExpress.Utils.PointFloat(663.0!, 10.00001!)
            Me.LabelFooter_TuesdayTotal.Name = "LabelFooter_TuesdayTotal"
            Me.LabelFooter_TuesdayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_TuesdayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_TuesdayTotal.StylePriority.UseFont = False
            Me.LabelFooter_TuesdayTotal.StylePriority.UseTextAlignment = False
            XrSummary6.IgnoreNullValues = True
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_TuesdayTotal.Summary = XrSummary6
            Me.LabelFooter_TuesdayTotal.Text = "LabelFooter_TuesdayTotal"
            Me.LabelFooter_TuesdayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooter_MondayTotal
            '
            Me.LabelFooter_MondayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day2Hours")})
            Me.LabelFooter_MondayTotal.Dpi = 100.0!
            Me.LabelFooter_MondayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_MondayTotal.LocationFloat = New DevExpress.Utils.PointFloat(607.0!, 10.00001!)
            Me.LabelFooter_MondayTotal.Name = "LabelFooter_MondayTotal"
            Me.LabelFooter_MondayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_MondayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_MondayTotal.StylePriority.UseFont = False
            Me.LabelFooter_MondayTotal.StylePriority.UseTextAlignment = False
            XrSummary7.IgnoreNullValues = True
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_MondayTotal.Summary = XrSummary7
            Me.LabelFooter_MondayTotal.Text = "LabelFooter_MondayTotal"
            Me.LabelFooter_MondayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineFooter_Bottom
            '
            Me.LineFooter_Bottom.Dpi = 100.0!
            Me.LineFooter_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.00001!)
            Me.LineFooter_Bottom.Name = "LineFooter_Bottom"
            Me.LineFooter_Bottom.SizeF = New System.Drawing.SizeF(999.0001!, 5.291668!)
            '
            'LabelFooter_Totals
            '
            Me.LabelFooter_Totals.Dpi = 100.0!
            Me.LabelFooter_Totals.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_Totals.LocationFloat = New DevExpress.Utils.PointFloat(482.1299!, 10.00001!)
            Me.LabelFooter_Totals.Name = "LabelFooter_Totals"
            Me.LabelFooter_Totals.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_Totals.SizeF = New System.Drawing.SizeF(68.87!, 18.0!)
            Me.LabelFooter_Totals.StylePriority.UseFont = False
            Me.LabelFooter_Totals.Text = "Totals:"
            '
            'LabelFooter_SundayTotal
            '
            Me.LabelFooter_SundayTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Day1Hours")})
            Me.LabelFooter_SundayTotal.Dpi = 100.0!
            Me.LabelFooter_SundayTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_SundayTotal.LocationFloat = New DevExpress.Utils.PointFloat(550.9999!, 10.00001!)
            Me.LabelFooter_SundayTotal.Name = "LabelFooter_SundayTotal"
            Me.LabelFooter_SundayTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_SundayTotal.SizeF = New System.Drawing.SizeF(56.00006!, 18.0!)
            Me.LabelFooter_SundayTotal.StylePriority.UseFont = False
            Me.LabelFooter_SundayTotal.StylePriority.UseTextAlignment = False
            XrSummary8.IgnoreNullValues = True
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelFooter_SundayTotal.Summary = XrSummary8
            Me.LabelFooter_SundayTotal.Text = "LabelFooter_SundayTotal"
            Me.LabelFooter_SundayTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineFooter_Top
            '
            Me.LineFooter_Top.Dpi = 100.0!
            Me.LineFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineFooter_Top.Name = "LineFooter_Top"
            Me.LineFooter_Top.SizeF = New System.Drawing.SizeF(999.0001!, 5.291668!)
            '
            'EntryHoursSum
            '
            Me.EntryHoursSum.Expression = "IsNull([Day1Hours], 0) + IsNull([Day2Hours], 0) + IsNull([Day3Hours], 0) + IsNull" &
    "([Day4Hours], 0) + IsNull([Day5Hours], 0) + IsNull([Day6Hours], 0) + IsNull([Day" &
    "7Hours], 0)"
            Me.EntryHoursSum.Name = "EntryHoursSum"
            '
            'TimesheetDetailsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter1})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.EntryHoursSum})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(0, 101, 0, 2)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Label_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Department As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelHeader_Monday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_FunctionCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Component As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_ProductCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Sunday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Saturday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Friday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Thursday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Wednesday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Tuesday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Monday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Sunday As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Department As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_FunctionCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Comp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ProductCat As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelFooter_WeekTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_SaturdayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_FridayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_ThursdayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_WednesdayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_TuesdayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_MondayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineFooter_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelFooter_Totals As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFooter_SundayTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineFooter_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents EntryHoursSum As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace