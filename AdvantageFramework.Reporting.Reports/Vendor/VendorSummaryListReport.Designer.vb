Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class VendorSummaryListReport
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
            Me.Label_Category = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Category = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_LastPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Active = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_1099 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PhoneAndExt = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Zip = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_State = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_City = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Address = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Code = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_VendorCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelHeader_SortedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_LastPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.Active = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_1099TaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_PhoneFax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Zip = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_State = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_City = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Address = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_Category, Me.LabelDetail_Category, Me.Label_TaxID, Me.XrLine1, Me.Label_LastPaid, Me.Label_Active, Me.Label_1099, Me.Label_PhoneAndExt, Me.Label_Zip, Me.Label_State, Me.Label_City, Me.Label_Address, Me.Label_Name, Me.Label_Code})
            Me.Detail.HeightF = 56.20816!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Category
            '
            Me.Label_Category.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Category.LocationFloat = New DevExpress.Utils.PointFloat(65.83328!, 23.99998!)
            Me.Label_Category.Multiline = True
            Me.Label_Category.Name = "Label_Category"
            Me.Label_Category.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Category.SizeF = New System.Drawing.SizeF(159.6255!, 18.0!)
            Me.Label_Category.StylePriority.UseFont = False
            Me.Label_Category.StylePriority.UseTextAlignment = False
            Me.Label_Category.Text = "None"
            Me.Label_Category.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelDetail_Category
            '
            Me.LabelDetail_Category.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_Category.BorderWidth = 0
            Me.LabelDetail_Category.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Category.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Category.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 23.99998!)
            Me.LabelDetail_Category.Name = "LabelDetail_Category"
            Me.LabelDetail_Category.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Category.SizeF = New System.Drawing.SizeF(65.83321!, 18.00002!)
            Me.LabelDetail_Category.StylePriority.UseBorders = False
            Me.LabelDetail_Category.StylePriority.UseBorderWidth = False
            Me.LabelDetail_Category.StylePriority.UseFont = False
            Me.LabelDetail_Category.StylePriority.UseForeColor = False
            Me.LabelDetail_Category.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Category.Text = "Category:"
            Me.LabelDetail_Category.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'Label_TaxID
            '
            Me.Label_TaxID.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxID")})
            Me.Label_TaxID.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_TaxID.LocationFloat = New DevExpress.Utils.PointFloat(811.9169!, 24.0!)
            Me.Label_TaxID.Name = "Label_TaxID"
            Me.Label_TaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_TaxID.SizeF = New System.Drawing.SizeF(187.0831!, 18.0!)
            Me.Label_TaxID.StylePriority.UseFont = False
            Me.Label_TaxID.Text = "Label_TaxID"
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 42.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(998.9999!, 13.33316!)
            '
            'Label_LastPaid
            '
            Me.Label_LastPaid.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_LastPaid.LocationFloat = New DevExpress.Utils.PointFloat(910.2501!, 6.0!)
            Me.Label_LastPaid.Name = "Label_LastPaid"
            Me.Label_LastPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_LastPaid.SizeF = New System.Drawing.SizeF(88.74988!, 18.0!)
            Me.Label_LastPaid.StylePriority.UseFont = False
            '
            'Label_Active
            '
            Me.Label_Active.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Active.LocationFloat = New DevExpress.Utils.PointFloat(861.0835!, 6.0!)
            Me.Label_Active.Name = "Label_Active"
            Me.Label_Active.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Active.SizeF = New System.Drawing.SizeF(49.1665!, 18.0!)
            Me.Label_Active.StylePriority.UseFont = False
            '
            'Label_1099
            '
            Me.Label_1099.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_1099.LocationFloat = New DevExpress.Utils.PointFloat(811.9169!, 6.0!)
            Me.Label_1099.Name = "Label_1099"
            Me.Label_1099.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_1099.SizeF = New System.Drawing.SizeF(49.16656!, 18.0!)
            Me.Label_1099.StylePriority.UseFont = False
            '
            'Label_PhoneAndExt
            '
            Me.Label_PhoneAndExt.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_PhoneAndExt.LocationFloat = New DevExpress.Utils.PointFloat(669.0002!, 6.0!)
            Me.Label_PhoneAndExt.Multiline = True
            Me.Label_PhoneAndExt.Name = "Label_PhoneAndExt"
            Me.Label_PhoneAndExt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PhoneAndExt.SizeF = New System.Drawing.SizeF(142.9166!, 18.0!)
            Me.Label_PhoneAndExt.StylePriority.UseFont = False
            '
            'Label_Zip
            '
            Me.Label_Zip.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ZipCode")})
            Me.Label_Zip.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Zip.LocationFloat = New DevExpress.Utils.PointFloat(609.417!, 6.0!)
            Me.Label_Zip.Name = "Label_Zip"
            Me.Label_Zip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Zip.SizeF = New System.Drawing.SizeF(59.58319!, 18.0!)
            Me.Label_Zip.StylePriority.UseFont = False
            Me.Label_Zip.Text = "Label_Zip"
            '
            'Label_State
            '
            Me.Label_State.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "State")})
            Me.Label_State.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_State.LocationFloat = New DevExpress.Utils.PointFloat(555.042!, 6.0!)
            Me.Label_State.Name = "Label_State"
            Me.Label_State.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_State.SizeF = New System.Drawing.SizeF(54.37488!, 18.0!)
            Me.Label_State.StylePriority.UseFont = False
            Me.Label_State.Text = "Label_State"
            '
            'Label_City
            '
            Me.Label_City.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "City")})
            Me.Label_City.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_City.LocationFloat = New DevExpress.Utils.PointFloat(412.1254!, 6.0!)
            Me.Label_City.Name = "Label_City"
            Me.Label_City.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_City.SizeF = New System.Drawing.SizeF(142.9165!, 18.0!)
            Me.Label_City.StylePriority.UseFont = False
            Me.Label_City.Text = "Label_City"
            '
            'Label_Address
            '
            Me.Label_Address.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Address.LocationFloat = New DevExpress.Utils.PointFloat(225.4588!, 6.0!)
            Me.Label_Address.Multiline = True
            Me.Label_Address.Name = "Label_Address"
            Me.Label_Address.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Address.SizeF = New System.Drawing.SizeF(186.6665!, 18.0!)
            Me.Label_Address.StylePriority.UseFont = False
            '
            'Label_Name
            '
            Me.Label_Name.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Name")})
            Me.Label_Name.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Name.LocationFloat = New DevExpress.Utils.PointFloat(51.24995!, 6.0!)
            Me.Label_Name.Multiline = True
            Me.Label_Name.Name = "Label_Name"
            Me.Label_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Name.SizeF = New System.Drawing.SizeF(174.2088!, 18.0!)
            Me.Label_Name.StylePriority.UseFont = False
            Me.Label_Name.Text = "Label_Name"
            '
            'Label_Code
            '
            Me.Label_Code.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.Label_Code.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Code.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 6.0!)
            Me.Label_Code.Name = "Label_Code"
            Me.Label_Code.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Code.SizeF = New System.Drawing.SizeF(51.24987!, 18.0!)
            Me.Label_Code.StylePriority.UseFont = False
            Me.Label_Code.Text = "Label_Code"
            '
            'Label_VendorCode
            '
            Me.Label_VendorCode.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_VendorCode.BorderWidth = 0
            Me.Label_VendorCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_VendorCode.ForeColor = System.Drawing.Color.Black
            Me.Label_VendorCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 72.54163!)
            Me.Label_VendorCode.Name = "Label_VendorCode"
            Me.Label_VendorCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_VendorCode.SizeF = New System.Drawing.SizeF(51.24988!, 39.87501!)
            Me.Label_VendorCode.StylePriority.UseBorders = False
            Me.Label_VendorCode.StylePriority.UseBorderWidth = False
            Me.Label_VendorCode.StylePriority.UseFont = False
            Me.Label_VendorCode.StylePriority.UseForeColor = False
            Me.Label_VendorCode.StylePriority.UseTextAlignment = False
            Me.Label_VendorCode.Text = "Vendor Code"
            Me.Label_VendorCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 39.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 59.375!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_SortedBy, Me.LabelHeader_LastPaid, Me.Active, Me.LabelHeader_1099TaxID, Me.LabelHeader_PhoneFax, Me.LabelHeader_Zip, Me.LabelHeader_State, Me.LabelHeader_City, Me.LabelHeader_Address, Me.XrLabel2, Me.Line1, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title, Me.Label_VendorCode})
            Me.PageHeader.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic)
            Me.PageHeader.HeightF = 112.4166!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseFont = False
            '
            'LabelHeader_SortedBy
            '
            Me.LabelHeader_SortedBy.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelHeader_SortedBy.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 46.0!)
            Me.LabelHeader_SortedBy.Name = "LabelHeader_SortedBy"
            Me.LabelHeader_SortedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_SortedBy.SizeF = New System.Drawing.SizeF(439.9167!, 18.0!)
            Me.LabelHeader_SortedBy.StylePriority.UseFont = False
            Me.LabelHeader_SortedBy.StylePriority.UseTextAlignment = False
            Me.LabelHeader_SortedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelHeader_LastPaid
            '
            Me.LabelHeader_LastPaid.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_LastPaid.BorderWidth = 0
            Me.LabelHeader_LastPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_LastPaid.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_LastPaid.LocationFloat = New DevExpress.Utils.PointFloat(910.2501!, 72.54163!)
            Me.LabelHeader_LastPaid.Name = "LabelHeader_LastPaid"
            Me.LabelHeader_LastPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_LastPaid.SizeF = New System.Drawing.SizeF(88.74988!, 39.87501!)
            Me.LabelHeader_LastPaid.StylePriority.UseBorders = False
            Me.LabelHeader_LastPaid.StylePriority.UseBorderWidth = False
            Me.LabelHeader_LastPaid.StylePriority.UseFont = False
            Me.LabelHeader_LastPaid.StylePriority.UseForeColor = False
            Me.LabelHeader_LastPaid.StylePriority.UseTextAlignment = False
            Me.LabelHeader_LastPaid.Text = "Last Paid"
            Me.LabelHeader_LastPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Active
            '
            Me.Active.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Active.BorderWidth = 0
            Me.Active.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Active.ForeColor = System.Drawing.Color.Black
            Me.Active.LocationFloat = New DevExpress.Utils.PointFloat(861.0835!, 72.54163!)
            Me.Active.Name = "Active"
            Me.Active.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Active.SizeF = New System.Drawing.SizeF(49.16656!, 39.87501!)
            Me.Active.StylePriority.UseBorders = False
            Me.Active.StylePriority.UseBorderWidth = False
            Me.Active.StylePriority.UseFont = False
            Me.Active.StylePriority.UseForeColor = False
            Me.Active.StylePriority.UseTextAlignment = False
            Me.Active.Text = "Active"
            Me.Active.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_1099TaxID
            '
            Me.LabelHeader_1099TaxID.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_1099TaxID.BorderWidth = 0
            Me.LabelHeader_1099TaxID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_1099TaxID.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_1099TaxID.LocationFloat = New DevExpress.Utils.PointFloat(811.9169!, 72.54163!)
            Me.LabelHeader_1099TaxID.Name = "LabelHeader_1099TaxID"
            Me.LabelHeader_1099TaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_1099TaxID.SizeF = New System.Drawing.SizeF(49.16656!, 39.87501!)
            Me.LabelHeader_1099TaxID.StylePriority.UseBorders = False
            Me.LabelHeader_1099TaxID.StylePriority.UseBorderWidth = False
            Me.LabelHeader_1099TaxID.StylePriority.UseFont = False
            Me.LabelHeader_1099TaxID.StylePriority.UseForeColor = False
            Me.LabelHeader_1099TaxID.StylePriority.UseTextAlignment = False
            Me.LabelHeader_1099TaxID.Text = "1099? Tax ID"
            Me.LabelHeader_1099TaxID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_PhoneFax
            '
            Me.LabelHeader_PhoneFax.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_PhoneFax.BorderWidth = 0
            Me.LabelHeader_PhoneFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_PhoneFax.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_PhoneFax.LocationFloat = New DevExpress.Utils.PointFloat(669.0002!, 72.54163!)
            Me.LabelHeader_PhoneFax.Name = "LabelHeader_PhoneFax"
            Me.LabelHeader_PhoneFax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_PhoneFax.SizeF = New System.Drawing.SizeF(142.9165!, 39.87501!)
            Me.LabelHeader_PhoneFax.StylePriority.UseBorders = False
            Me.LabelHeader_PhoneFax.StylePriority.UseBorderWidth = False
            Me.LabelHeader_PhoneFax.StylePriority.UseFont = False
            Me.LabelHeader_PhoneFax.StylePriority.UseForeColor = False
            Me.LabelHeader_PhoneFax.StylePriority.UseTextAlignment = False
            Me.LabelHeader_PhoneFax.Text = "Phone / Fax"
            Me.LabelHeader_PhoneFax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Zip
            '
            Me.LabelHeader_Zip.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Zip.BorderWidth = 0
            Me.LabelHeader_Zip.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Zip.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Zip.LocationFloat = New DevExpress.Utils.PointFloat(609.417!, 72.54163!)
            Me.LabelHeader_Zip.Name = "LabelHeader_Zip"
            Me.LabelHeader_Zip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Zip.SizeF = New System.Drawing.SizeF(59.58319!, 39.87501!)
            Me.LabelHeader_Zip.StylePriority.UseBorders = False
            Me.LabelHeader_Zip.StylePriority.UseBorderWidth = False
            Me.LabelHeader_Zip.StylePriority.UseFont = False
            Me.LabelHeader_Zip.StylePriority.UseForeColor = False
            Me.LabelHeader_Zip.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Zip.Text = "Zip"
            Me.LabelHeader_Zip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_State
            '
            Me.LabelHeader_State.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_State.BorderWidth = 0
            Me.LabelHeader_State.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_State.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_State.LocationFloat = New DevExpress.Utils.PointFloat(555.042!, 72.54163!)
            Me.LabelHeader_State.Name = "LabelHeader_State"
            Me.LabelHeader_State.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_State.SizeF = New System.Drawing.SizeF(54.37491!, 39.87501!)
            Me.LabelHeader_State.StylePriority.UseBorders = False
            Me.LabelHeader_State.StylePriority.UseBorderWidth = False
            Me.LabelHeader_State.StylePriority.UseFont = False
            Me.LabelHeader_State.StylePriority.UseForeColor = False
            Me.LabelHeader_State.StylePriority.UseTextAlignment = False
            Me.LabelHeader_State.Text = "State"
            Me.LabelHeader_State.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_City
            '
            Me.LabelHeader_City.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_City.BorderWidth = 0
            Me.LabelHeader_City.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_City.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_City.LocationFloat = New DevExpress.Utils.PointFloat(412.1254!, 72.54163!)
            Me.LabelHeader_City.Name = "LabelHeader_City"
            Me.LabelHeader_City.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_City.SizeF = New System.Drawing.SizeF(142.9165!, 39.87501!)
            Me.LabelHeader_City.StylePriority.UseBorders = False
            Me.LabelHeader_City.StylePriority.UseBorderWidth = False
            Me.LabelHeader_City.StylePriority.UseFont = False
            Me.LabelHeader_City.StylePriority.UseForeColor = False
            Me.LabelHeader_City.StylePriority.UseTextAlignment = False
            Me.LabelHeader_City.Text = "City"
            Me.LabelHeader_City.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Address
            '
            Me.LabelHeader_Address.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Address.BorderWidth = 0
            Me.LabelHeader_Address.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Address.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Address.LocationFloat = New DevExpress.Utils.PointFloat(225.4588!, 72.54163!)
            Me.LabelHeader_Address.Name = "LabelHeader_Address"
            Me.LabelHeader_Address.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Address.SizeF = New System.Drawing.SizeF(186.6665!, 39.87501!)
            Me.LabelHeader_Address.StylePriority.UseBorders = False
            Me.LabelHeader_Address.StylePriority.UseBorderWidth = False
            Me.LabelHeader_Address.StylePriority.UseFont = False
            Me.LabelHeader_Address.StylePriority.UseForeColor = False
            Me.LabelHeader_Address.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Address.Text = "Address"
            Me.LabelHeader_Address.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabel2
            '
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel2.BorderWidth = 0
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(51.24995!, 72.54163!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(174.2088!, 39.87501!)
            Me.XrLabel2.StylePriority.UseBorders = False
            Me.XrLabel2.StylePriority.UseBorderWidth = False
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseForeColor = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "Vendor Name"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Line1
            '
            Me.Line1.BorderColor = System.Drawing.Color.Silver
            Me.Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line1.BorderWidth = 4
            Me.Line1.ForeColor = System.Drawing.Color.Silver
            Me.Line1.LineWidth = 4
            Me.Line1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 68.54163!)
            Me.Line1.Name = "Line1"
            Me.Line1.SizeF = New System.Drawing.SizeF(999.0!, 4.0!)
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(449.9168!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(539.0831!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 9.916656!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(439.9167!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Vendor Report - 005 - Summary - Vendor List"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_DateAndUserCode, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 27.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'LabelPageFooter_DateAndUserCode
            '
            Me.LabelPageFooter_DateAndUserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_DateAndUserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_DateAndUserCode.BorderWidth = 1
            Me.LabelPageFooter_DateAndUserCode.CanGrow = False
            Me.LabelPageFooter_DateAndUserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_DateAndUserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 5.0!)
            Me.LabelPageFooter_DateAndUserCode.Name = "LabelPageFooter_DateAndUserCode"
            Me.LabelPageFooter_DateAndUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_DateAndUserCode.SizeF = New System.Drawing.SizeF(490.0!, 19.0!)
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_DateAndUserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 5.0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'VendorSummaryListReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource1
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 51, 39, 59)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents Label_VendorCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Code As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_LastPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Active As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_1099TaxID As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_PhoneFax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Zip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_State As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_City As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Address As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_TaxID As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents Label_LastPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Active As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_1099 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PhoneAndExt As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Zip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_State As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_City As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Address As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Name As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents Label_Category As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Category As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    End Class

End Namespace
