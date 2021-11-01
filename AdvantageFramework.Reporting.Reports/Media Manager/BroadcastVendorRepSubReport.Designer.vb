Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class BroadcastVendorRepSubReport
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
            Me.LabelDetail_Fax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Phone = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_EmailAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Country = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_County = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CSZ = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Address2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Address1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_RepName = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.CalculatedFieldCityStateZip = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldPhone = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldFax = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldRepName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.LabelDetail_FirmName = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_FirmName, Me.LabelDetail_Fax, Me.LabelDetail_Phone, Me.LabelDetail_EmailAddress, Me.LabelDetail_Country, Me.LabelDetail_County, Me.LabelDetail_CSZ, Me.LabelDetail_Address2, Me.LabelDetail_Address1, Me.LabelDetail_RepName})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 187.7083!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Fax
            '
            Me.LabelDetail_Fax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldFax")})
            Me.LabelDetail_Fax.LocationFloat = New DevExpress.Utils.PointFloat(0!, 170.7083!)
            Me.LabelDetail_Fax.Name = "LabelDetail_Fax"
            Me.LabelDetail_Fax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Fax.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Fax.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_Phone
            '
            Me.LabelDetail_Phone.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldPhone")})
            Me.LabelDetail_Phone.LocationFloat = New DevExpress.Utils.PointFloat(0!, 153.7083!)
            Me.LabelDetail_Phone.Name = "LabelDetail_Phone"
            Me.LabelDetail_Phone.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Phone.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Phone.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_EmailAddress
            '
            Me.LabelDetail_EmailAddress.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmailAddress")})
            Me.LabelDetail_EmailAddress.LocationFloat = New DevExpress.Utils.PointFloat(0!, 136.0!)
            Me.LabelDetail_EmailAddress.Name = "LabelDetail_EmailAddress"
            Me.LabelDetail_EmailAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_EmailAddress.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_EmailAddress.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_Country
            '
            Me.LabelDetail_Country.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Country")})
            Me.LabelDetail_Country.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.0!)
            Me.LabelDetail_Country.Name = "LabelDetail_Country"
            Me.LabelDetail_Country.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Country.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Country.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_County
            '
            Me.LabelDetail_County.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "County")})
            Me.LabelDetail_County.LocationFloat = New DevExpress.Utils.PointFloat(0!, 84.99999!)
            Me.LabelDetail_County.Name = "LabelDetail_County"
            Me.LabelDetail_County.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_County.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_County.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_CSZ
            '
            Me.LabelDetail_CSZ.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldCityStateZip")})
            Me.LabelDetail_CSZ.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.0!)
            Me.LabelDetail_CSZ.Name = "LabelDetail_CSZ"
            Me.LabelDetail_CSZ.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CSZ.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CSZ.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_Address2
            '
            Me.LabelDetail_Address2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address2")})
            Me.LabelDetail_Address2.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 51.0!)
            Me.LabelDetail_Address2.Name = "LabelDetail_Address2"
            Me.LabelDetail_Address2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Address2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Address2.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_Address1
            '
            Me.LabelDetail_Address1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address1")})
            Me.LabelDetail_Address1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.00001!)
            Me.LabelDetail_Address1.Name = "LabelDetail_Address1"
            Me.LabelDetail_Address1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Address1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Address1.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'LabelDetail_RepName
            '
            Me.LabelDetail_RepName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldRepName")})
            Me.LabelDetail_RepName.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_RepName.Name = "LabelDetail_RepName"
            Me.LabelDetail_RepName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_RepName.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_RepName.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
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
            Me.BottomMargin.HeightF = 26.87496!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'CalculatedFieldCityStateZip
            '
            Me.CalculatedFieldCityStateZip.Expression = "Iif( IsNullOrEmpty([City]) And IsNullOrEmpty([State]) And IsNullOrEmpty([Zip]), N" &
    "ull, ([City] + ', ' + [State] + '  ' + [Zip]))"
            Me.CalculatedFieldCityStateZip.Name = "CalculatedFieldCityStateZip"
            '
            'CalculatedFieldPhone
            '
            Me.CalculatedFieldPhone.Expression = "Iif(IsNullOrEmpty([Telephone]), Null , 'Phone: ' +" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Iif(IsNullOrEmpty([TelephoneE" &
    "xtension]), [Telephone] , [Telephone] + ' #' + [TelephoneExtension] )" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ")"
            Me.CalculatedFieldPhone.Name = "CalculatedFieldPhone"
            '
            'CalculatedFieldFax
            '
            Me.CalculatedFieldFax.Expression = "Iif(IsNullOrEmpty([Fax]), Null , 'Fax: ' +" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Iif(IsNullOrEmpty( [FaxExtension] ), " &
    "[Fax], [Fax]+ ' #' + [FaxExtension])" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ")"
            Me.CalculatedFieldFax.Name = "CalculatedFieldFax"
            '
            'CalculatedFieldRepName
            '
            Me.CalculatedFieldRepName.Expression = "[FirstName] + Iif(IsNullOrEmpty([MiddleInitial]) , ' ', ' ' + [MiddleInitial] + '" &
    ". ') + [LastName]"
            Me.CalculatedFieldRepName.Name = "CalculatedFieldRepName"
            '
            'LabelDetail_FirmName
            '
            Me.LabelDetail_FirmName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FirmName")})
            Me.LabelDetail_FirmName.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00001!)
            Me.LabelDetail_FirmName.Name = "LabelDetail_FirmName"
            Me.LabelDetail_FirmName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_FirmName.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_FirmName.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.VendorRepresentative)
            '
            'BroadcastVendorRepSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedFieldCityStateZip, Me.CalculatedFieldPhone, Me.CalculatedFieldFax, Me.CalculatedFieldRepName})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 27)
            Me.PageWidth = 325
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents CalculatedFieldCityStateZip As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldPhone As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldFax As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetail_Fax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Phone As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_EmailAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Country As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_County As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CSZ As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Address2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Address1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_RepName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedFieldRepName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetail_FirmName As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
