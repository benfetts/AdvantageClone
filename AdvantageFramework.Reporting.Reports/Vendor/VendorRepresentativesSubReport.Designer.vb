Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class VendorRepresentativesSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Cell = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Label = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Label = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_FaxExt = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PhoneExt = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBox_Inactive = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.Label_Email = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Fax = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Phone = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Country = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_County = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_FirmName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CityStateZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Address2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Address1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FirmName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Email = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PhoneAndExt = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FaxAndExt = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CountyAndCountry = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CityStateAndZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Address2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Address1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Representative = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Code = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.LabelDetail_Cell, Me.LabelDetail_Label, Me.Label_Label, Me.XrLine1, Me.Label_FaxExt, Me.Label_PhoneExt, Me.CheckBox_Inactive, Me.Label_Email, Me.Label_Fax, Me.Label_Phone, Me.Label_Country, Me.Label_County, Me.Label_FirmName, Me.Label_CityStateZip, Me.Label_Address2, Me.Label_Address1, Me.Label_Name, Me.LabelDetail_FirmName, Me.LabelDetail_Email, Me.LabelDetail_PhoneAndExt, Me.LabelDetail_FaxAndExt, Me.LabelDetail_CountyAndCountry, Me.LabelDetail_CityStateAndZip, Me.LabelDetail_Address2, Me.LabelDetail_Address1, Me.LabelDetail_Name, Me.LabelDetail_Representative, Me.Label_Code})
            Me.Detail.HeightF = 241.0001!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CellPhone")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 188.0001!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(145.29!, 18.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.Text = "XrLabel1"
            '
            'LabelDetail_Cell
            '
            Me.LabelDetail_Cell.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Cell.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Cell.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Cell.BorderWidth = 1
            Me.LabelDetail_Cell.CanGrow = False
            Me.LabelDetail_Cell.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Cell.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Cell.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 188.0001!)
            Me.LabelDetail_Cell.Name = "LabelDetail_Cell"
            Me.LabelDetail_Cell.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Cell.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Cell.StylePriority.UseFont = False
            Me.LabelDetail_Cell.Text = "Cell:"
            Me.LabelDetail_Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Label
            '
            Me.LabelDetail_Label.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Label.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Label.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Label.BorderWidth = 1
            Me.LabelDetail_Label.CanGrow = False
            Me.LabelDetail_Label.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Label.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Label.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 37.0!)
            Me.LabelDetail_Label.Name = "LabelDetail_Label"
            Me.LabelDetail_Label.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Label.SizeF = New System.Drawing.SizeF(105.0!, 18.0!)
            Me.LabelDetail_Label.StylePriority.UseFont = False
            Me.LabelDetail_Label.Text = "Label:"
            Me.LabelDetail_Label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Label
            '
            Me.Label_Label.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Label")})
            Me.Label_Label.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Label.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 37.0!)
            Me.Label_Label.Name = "Label_Label"
            Me.Label_Label.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Label.SizeF = New System.Drawing.SizeF(219.0!, 18.0!)
            Me.Label_Label.StylePriority.UseFont = False
            Me.Label_Label.Text = "Label_Label"
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 226.0001!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(748.0!, 15.0!)
            '
            'Label_FaxExt
            '
            Me.Label_FaxExt.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FaxExtension")})
            Me.Label_FaxExt.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_FaxExt.LocationFloat = New DevExpress.Utils.PointFloat(250.2899!, 169.0001!)
            Me.Label_FaxExt.Name = "Label_FaxExt"
            Me.Label_FaxExt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FaxExt.SizeF = New System.Drawing.SizeF(73.71014!, 17.99998!)
            Me.Label_FaxExt.StylePriority.UseFont = False
            Me.Label_FaxExt.Text = "Label_FaxExt"
            '
            'Label_PhoneExt
            '
            Me.Label_PhoneExt.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TelephoneExtension")})
            Me.Label_PhoneExt.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_PhoneExt.LocationFloat = New DevExpress.Utils.PointFloat(250.2899!, 150.0001!)
            Me.Label_PhoneExt.Name = "Label_PhoneExt"
            Me.Label_PhoneExt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PhoneExt.SizeF = New System.Drawing.SizeF(73.71014!, 17.99998!)
            Me.Label_PhoneExt.StylePriority.UseFont = False
            Me.Label_PhoneExt.Text = "Label_PhoneExt"
            '
            'CheckBox_Inactive
            '
            Me.CheckBox_Inactive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBox_Inactive.LocationFloat = New DevExpress.Utils.PointFloat(256.2917!, 0.0!)
            Me.CheckBox_Inactive.Name = "CheckBox_Inactive"
            Me.CheckBox_Inactive.SizeF = New System.Drawing.SizeF(67.70834!, 18.0!)
            Me.CheckBox_Inactive.StylePriority.UseFont = False
            Me.CheckBox_Inactive.StylePriority.UseTextAlignment = False
            Me.CheckBox_Inactive.Text = "Inactive"
            '
            'Label_Email
            '
            Me.Label_Email.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmailAddress")})
            Me.Label_Email.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Email.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 207.0001!)
            Me.Label_Email.Name = "Label_Email"
            Me.Label_Email.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Email.SizeF = New System.Drawing.SizeF(306.4998!, 18.0!)
            Me.Label_Email.StylePriority.UseFont = False
            Me.Label_Email.Text = "Label_Email"
            '
            'Label_Fax
            '
            Me.Label_Fax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Fax")})
            Me.Label_Fax.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Fax.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 169.0001!)
            Me.Label_Fax.Name = "Label_Fax"
            Me.Label_Fax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Fax.SizeF = New System.Drawing.SizeF(145.29!, 18.0!)
            Me.Label_Fax.StylePriority.UseFont = False
            Me.Label_Fax.Text = "Label_Fax"
            '
            'Label_Phone
            '
            Me.Label_Phone.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Telephone")})
            Me.Label_Phone.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Phone.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 150.0!)
            Me.Label_Phone.Name = "Label_Phone"
            Me.Label_Phone.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Phone.SizeF = New System.Drawing.SizeF(145.29!, 18.0!)
            Me.Label_Phone.StylePriority.UseFont = False
            Me.Label_Phone.Text = "Label_Phone"
            '
            'Label_Country
            '
            Me.Label_Country.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Country")})
            Me.Label_Country.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Country.LocationFloat = New DevExpress.Utils.PointFloat(219.8301!, 131.0!)
            Me.Label_Country.Name = "Label_Country"
            Me.Label_Country.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Country.SizeF = New System.Drawing.SizeF(104.17!, 18.0!)
            Me.Label_Country.StylePriority.UseFont = False
            Me.Label_Country.Text = "Label_Country"
            '
            'Label_County
            '
            Me.Label_County.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "County")})
            Me.Label_County.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_County.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 131.0!)
            Me.Label_County.Name = "Label_County"
            Me.Label_County.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_County.SizeF = New System.Drawing.SizeF(114.83!, 18.0!)
            Me.Label_County.StylePriority.UseFont = False
            Me.Label_County.Text = "Label_County"
            '
            'Label_FirmName
            '
            Me.Label_FirmName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FirmName")})
            Me.Label_FirmName.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_FirmName.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 19.00001!)
            Me.Label_FirmName.Name = "Label_FirmName"
            Me.Label_FirmName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FirmName.SizeF = New System.Drawing.SizeF(218.9999!, 18.0!)
            Me.Label_FirmName.StylePriority.UseFont = False
            Me.Label_FirmName.Text = "Label_FirmName"
            '
            'Label_CityStateZip
            '
            Me.Label_CityStateZip.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_CityStateZip.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 112.0!)
            Me.Label_CityStateZip.Name = "Label_CityStateZip"
            Me.Label_CityStateZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_CityStateZip.SizeF = New System.Drawing.SizeF(219.0!, 18.0!)
            Me.Label_CityStateZip.StylePriority.UseFont = False
            '
            'Label_Address2
            '
            Me.Label_Address2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address2")})
            Me.Label_Address2.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Address2.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 92.99998!)
            Me.Label_Address2.Name = "Label_Address2"
            Me.Label_Address2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Address2.SizeF = New System.Drawing.SizeF(219.0!, 18.0!)
            Me.Label_Address2.StylePriority.UseFont = False
            Me.Label_Address2.Text = "Label_Address2"
            '
            'Label_Address1
            '
            Me.Label_Address1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address1")})
            Me.Label_Address1.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Address1.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 73.99999!)
            Me.Label_Address1.Name = "Label_Address1"
            Me.Label_Address1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Address1.SizeF = New System.Drawing.SizeF(219.0!, 18.0!)
            Me.Label_Address1.StylePriority.UseFont = False
            Me.Label_Address1.Text = "Label_Address1"
            '
            'Label_Name
            '
            Me.Label_Name.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Name.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 55.0!)
            Me.Label_Name.Name = "Label_Name"
            Me.Label_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Name.SizeF = New System.Drawing.SizeF(219.0!, 18.0!)
            Me.Label_Name.StylePriority.UseFont = False
            '
            'LabelDetail_FirmName
            '
            Me.LabelDetail_FirmName.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_FirmName.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_FirmName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_FirmName.BorderWidth = 1
            Me.LabelDetail_FirmName.CanGrow = False
            Me.LabelDetail_FirmName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_FirmName.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_FirmName.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 19.00001!)
            Me.LabelDetail_FirmName.Name = "LabelDetail_FirmName"
            Me.LabelDetail_FirmName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_FirmName.SizeF = New System.Drawing.SizeF(105.0!, 18.0!)
            Me.LabelDetail_FirmName.StylePriority.UseFont = False
            Me.LabelDetail_FirmName.Text = "Firm Name:"
            Me.LabelDetail_FirmName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Email
            '
            Me.LabelDetail_Email.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Email.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Email.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Email.BorderWidth = 1
            Me.LabelDetail_Email.CanGrow = False
            Me.LabelDetail_Email.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Email.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Email.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 207.0001!)
            Me.LabelDetail_Email.Name = "LabelDetail_Email"
            Me.LabelDetail_Email.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Email.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Email.StylePriority.UseFont = False
            Me.LabelDetail_Email.Text = "Email:"
            Me.LabelDetail_Email.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_PhoneAndExt
            '
            Me.LabelDetail_PhoneAndExt.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PhoneAndExt.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PhoneAndExt.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PhoneAndExt.BorderWidth = 1
            Me.LabelDetail_PhoneAndExt.CanGrow = False
            Me.LabelDetail_PhoneAndExt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PhoneAndExt.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PhoneAndExt.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 150.0001!)
            Me.LabelDetail_PhoneAndExt.Name = "LabelDetail_PhoneAndExt"
            Me.LabelDetail_PhoneAndExt.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PhoneAndExt.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_PhoneAndExt.StylePriority.UseFont = False
            Me.LabelDetail_PhoneAndExt.Text = "Phone / Ext:"
            Me.LabelDetail_PhoneAndExt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_FaxAndExt
            '
            Me.LabelDetail_FaxAndExt.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_FaxAndExt.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_FaxAndExt.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_FaxAndExt.BorderWidth = 1
            Me.LabelDetail_FaxAndExt.CanGrow = False
            Me.LabelDetail_FaxAndExt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_FaxAndExt.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_FaxAndExt.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 169.0001!)
            Me.LabelDetail_FaxAndExt.Name = "LabelDetail_FaxAndExt"
            Me.LabelDetail_FaxAndExt.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_FaxAndExt.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_FaxAndExt.StylePriority.UseFont = False
            Me.LabelDetail_FaxAndExt.Text = "Fax / Ext:"
            Me.LabelDetail_FaxAndExt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CountyAndCountry
            '
            Me.LabelDetail_CountyAndCountry.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CountyAndCountry.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CountyAndCountry.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CountyAndCountry.BorderWidth = 1
            Me.LabelDetail_CountyAndCountry.CanGrow = False
            Me.LabelDetail_CountyAndCountry.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CountyAndCountry.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CountyAndCountry.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 131.0!)
            Me.LabelDetail_CountyAndCountry.Name = "LabelDetail_CountyAndCountry"
            Me.LabelDetail_CountyAndCountry.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CountyAndCountry.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_CountyAndCountry.StylePriority.UseFont = False
            Me.LabelDetail_CountyAndCountry.Text = "County/Country:"
            Me.LabelDetail_CountyAndCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CityStateAndZip
            '
            Me.LabelDetail_CityStateAndZip.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CityStateAndZip.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CityStateAndZip.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CityStateAndZip.BorderWidth = 1
            Me.LabelDetail_CityStateAndZip.CanGrow = False
            Me.LabelDetail_CityStateAndZip.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CityStateAndZip.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CityStateAndZip.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 112.0!)
            Me.LabelDetail_CityStateAndZip.Name = "LabelDetail_CityStateAndZip"
            Me.LabelDetail_CityStateAndZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CityStateAndZip.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_CityStateAndZip.StylePriority.UseFont = False
            Me.LabelDetail_CityStateAndZip.Text = "City/State/Zip:"
            Me.LabelDetail_CityStateAndZip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Address2
            '
            Me.LabelDetail_Address2.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Address2.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Address2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Address2.BorderWidth = 1
            Me.LabelDetail_Address2.CanGrow = False
            Me.LabelDetail_Address2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Address2.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Address2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 92.99998!)
            Me.LabelDetail_Address2.Name = "LabelDetail_Address2"
            Me.LabelDetail_Address2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Address2.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Address2.StylePriority.UseFont = False
            Me.LabelDetail_Address2.Text = "Address 2:"
            Me.LabelDetail_Address2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Address1
            '
            Me.LabelDetail_Address1.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Address1.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Address1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Address1.BorderWidth = 1
            Me.LabelDetail_Address1.CanGrow = False
            Me.LabelDetail_Address1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Address1.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Address1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 73.99999!)
            Me.LabelDetail_Address1.Name = "LabelDetail_Address1"
            Me.LabelDetail_Address1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Address1.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Address1.StylePriority.UseFont = False
            Me.LabelDetail_Address1.Text = "Address 1:"
            Me.LabelDetail_Address1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Name
            '
            Me.LabelDetail_Name.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Name.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Name.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Name.BorderWidth = 1
            Me.LabelDetail_Name.CanGrow = False
            Me.LabelDetail_Name.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Name.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Name.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 55.0!)
            Me.LabelDetail_Name.Name = "LabelDetail_Name"
            Me.LabelDetail_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Name.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Name.StylePriority.UseFont = False
            Me.LabelDetail_Name.Text = "Name:"
            Me.LabelDetail_Name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Representative
            '
            Me.LabelDetail_Representative.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Representative.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Representative.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Representative.BorderWidth = 1
            Me.LabelDetail_Representative.CanGrow = False
            Me.LabelDetail_Representative.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Representative.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Representative.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelDetail_Representative.Name = "LabelDetail_Representative"
            Me.LabelDetail_Representative.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Representative.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_Representative.StylePriority.UseFont = False
            Me.LabelDetail_Representative.Text = "Representative:"
            Me.LabelDetail_Representative.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Code
            '
            Me.Label_Code.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.Label_Code.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Code.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 0.0!)
            Me.Label_Code.Name = "Label_Code"
            Me.Label_Code.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Code.SizeF = New System.Drawing.SizeF(86.66663!, 18.0!)
            Me.Label_Code.StylePriority.UseFont = False
            Me.Label_Code.Text = "Label_Code"
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
            Me.BottomMargin.HeightF = 6.791592!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 1.833312!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.VendorRepresentative)
            '
            'VendorRepresentativesSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 101, 0, 7)
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
        Friend WithEvents Label_Code As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_FirmName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Email As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PhoneAndExt As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_FaxAndExt As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CountyAndCountry As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CityStateAndZip As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Address2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Address1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Name As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Representative As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_CityStateZip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Address2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Address1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Name As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_FirmName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Email As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Fax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Phone As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Country As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_County As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_FaxExt As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PhoneExt As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBox_Inactive As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelDetail_Label As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Label As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Cell As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace