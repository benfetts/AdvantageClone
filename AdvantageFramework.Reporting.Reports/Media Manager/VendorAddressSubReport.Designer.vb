Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class VendorAddressSubReport
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
            Me.LabelDetail_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Addr1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Addr2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Addr3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CityStateZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_County = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Country = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Email = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Phone = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Fax = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CalculatedFieldCityStateZip = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldPhone = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldFax = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_Name, Me.LabelDetail_Addr1, Me.LabelDetail_Addr2, Me.LabelDetail_Addr3, Me.LabelDetail_CityStateZip, Me.LabelDetail_County, Me.LabelDetail_Country, Me.LabelDetail_Email, Me.LabelDetail_Phone, Me.LabelDetail_Fax})
            Me.Detail.HeightF = 170.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Name
            '
            Me.LabelDetail_Name.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Name")})
            Me.LabelDetail_Name.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Name.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_Name.Name = "LabelDetail_Name"
            Me.LabelDetail_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Name.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Name.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Name.StylePriority.UseFont = False
            '
            'LabelDetail_Addr1
            '
            Me.LabelDetail_Addr1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StreetAddressLine1")})
            Me.LabelDetail_Addr1.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Addr1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.0!)
            Me.LabelDetail_Addr1.Name = "LabelDetail_Addr1"
            Me.LabelDetail_Addr1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Addr1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Addr1.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Addr1.StylePriority.UseFont = False
            '
            'LabelDetail_Addr2
            '
            Me.LabelDetail_Addr2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StreetAddressLine2")})
            Me.LabelDetail_Addr2.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Addr2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.0!)
            Me.LabelDetail_Addr2.Name = "LabelDetail_Addr2"
            Me.LabelDetail_Addr2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Addr2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Addr2.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Addr2.StylePriority.UseFont = False
            '
            'LabelDetail_Addr3
            '
            Me.LabelDetail_Addr3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StreetAddressLine3")})
            Me.LabelDetail_Addr3.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Addr3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 51.0!)
            Me.LabelDetail_Addr3.Name = "LabelDetail_Addr3"
            Me.LabelDetail_Addr3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Addr3.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Addr3.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Addr3.StylePriority.UseFont = False
            '
            'LabelDetail_CityStateZip
            '
            Me.LabelDetail_CityStateZip.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldCityStateZip")})
            Me.LabelDetail_CityStateZip.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_CityStateZip.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.0!)
            Me.LabelDetail_CityStateZip.Name = "LabelDetail_CityStateZip"
            Me.LabelDetail_CityStateZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CityStateZip.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CityStateZip.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_CityStateZip.StylePriority.UseFont = False
            '
            'LabelDetail_County
            '
            Me.LabelDetail_County.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "County")})
            Me.LabelDetail_County.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_County.LocationFloat = New DevExpress.Utils.PointFloat(0!, 85.0!)
            Me.LabelDetail_County.Name = "LabelDetail_County"
            Me.LabelDetail_County.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_County.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_County.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_County.StylePriority.UseFont = False
            '
            'LabelDetail_Country
            '
            Me.LabelDetail_Country.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Country")})
            Me.LabelDetail_Country.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Country.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 102.0!)
            Me.LabelDetail_Country.Name = "LabelDetail_Country"
            Me.LabelDetail_Country.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Country.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Country.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Country.StylePriority.UseFont = False
            '
            'LabelDetail_Email
            '
            Me.LabelDetail_Email.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmailAddress")})
            Me.LabelDetail_Email.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Email.LocationFloat = New DevExpress.Utils.PointFloat(0!, 119.0!)
            Me.LabelDetail_Email.Name = "LabelDetail_Email"
            Me.LabelDetail_Email.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Email.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Email.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Email.StylePriority.UseFont = False
            '
            'LabelDetail_Phone
            '
            Me.LabelDetail_Phone.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldPhone")})
            Me.LabelDetail_Phone.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Phone.LocationFloat = New DevExpress.Utils.PointFloat(0!, 136.0!)
            Me.LabelDetail_Phone.Name = "LabelDetail_Phone"
            Me.LabelDetail_Phone.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Phone.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Phone.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Phone.StylePriority.UseFont = False
            '
            'LabelDetail_Fax
            '
            Me.LabelDetail_Fax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldFax")})
            Me.LabelDetail_Fax.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Fax.LocationFloat = New DevExpress.Utils.PointFloat(0!, 153.0!)
            Me.LabelDetail_Fax.Name = "LabelDetail_Fax"
            Me.LabelDetail_Fax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Fax.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Fax.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_Fax.StylePriority.UseFont = False
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
            Me.BottomMargin.HeightF = 38.33332!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'CalculatedFieldCityStateZip
            '
            Me.CalculatedFieldCityStateZip.Expression = "[City] + ', ' + [State] + '  ' + [ZipCode]"
            Me.CalculatedFieldCityStateZip.Name = "CalculatedFieldCityStateZip"
            '
            'CalculatedFieldPhone
            '
            Me.CalculatedFieldPhone.Expression = "Iif(IsNullOrEmpty([PhoneNumberExtension]), [PhoneNumber] , [PhoneNumber] + ' #' +" &
    " [PhoneNumberExtension] )"
            Me.CalculatedFieldPhone.Name = "CalculatedFieldPhone"
            '
            'CalculatedFieldFax
            '
            Me.CalculatedFieldFax.Expression = "Iif(IsNullOrEmpty( [FaxPhoneNumberExtension] ), [FaxPhoneNumber], [FaxPhoneNumber" &
    "]+ ' #' + [FaxPhoneNumberExtension])"
            Me.CalculatedFieldFax.Name = "CalculatedFieldFax"
            '
            'VendorAddressSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedFieldCityStateZip, Me.CalculatedFieldPhone, Me.CalculatedFieldFax})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 38)
            Me.PageWidth = 325
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDetail_Name As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Fax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Phone As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Email As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Country As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_County As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CityStateZip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Addr3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Addr2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Addr1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedFieldCityStateZip As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldPhone As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldFax As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
