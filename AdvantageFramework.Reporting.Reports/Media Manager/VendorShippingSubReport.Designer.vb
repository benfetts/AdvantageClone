Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class VendorShippingSubReport
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
            Me.LabelDetail_ShipToName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToAddr1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToAddr2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToAddr3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToCityStateZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToCounty = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ShipToCountry = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CalculatedFieldShipCityStateZip = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldPhone = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldFax = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_ShipToName, Me.LabelDetail_ShipToAddr1, Me.LabelDetail_ShipToAddr2, Me.LabelDetail_ShipToAddr3, Me.LabelDetail_ShipToCityStateZip, Me.LabelDetail_ShipToCounty, Me.LabelDetail_ShipToCountry})
            Me.Detail.HeightF = 136.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ShipToName
            '
            Me.LabelDetail_ShipToName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToName")})
            Me.LabelDetail_ShipToName.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToName.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_ShipToName.Name = "LabelDetail_ShipToName"
            Me.LabelDetail_ShipToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToName.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToName.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToName.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToAddr1
            '
            Me.LabelDetail_ShipToAddr1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToAddress")})
            Me.LabelDetail_ShipToAddr1.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToAddr1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 16.99999!)
            Me.LabelDetail_ShipToAddr1.Name = "LabelDetail_ShipToAddr1"
            Me.LabelDetail_ShipToAddr1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToAddr1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToAddr1.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToAddr1.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToAddr2
            '
            Me.LabelDetail_ShipToAddr2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToAddress2")})
            Me.LabelDetail_ShipToAddr2.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToAddr2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.99998!)
            Me.LabelDetail_ShipToAddr2.Name = "LabelDetail_ShipToAddr2"
            Me.LabelDetail_ShipToAddr2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToAddr2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToAddr2.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToAddr2.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToAddr3
            '
            Me.LabelDetail_ShipToAddr3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToAddress3")})
            Me.LabelDetail_ShipToAddr3.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToAddr3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.99999!)
            Me.LabelDetail_ShipToAddr3.Name = "LabelDetail_ShipToAddr3"
            Me.LabelDetail_ShipToAddr3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToAddr3.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToAddr3.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToAddr3.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToCityStateZip
            '
            Me.LabelDetail_ShipToCityStateZip.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldShipCityStateZip")})
            Me.LabelDetail_ShipToCityStateZip.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToCityStateZip.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.0!)
            Me.LabelDetail_ShipToCityStateZip.Name = "LabelDetail_ShipToCityStateZip"
            Me.LabelDetail_ShipToCityStateZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToCityStateZip.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToCityStateZip.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToCityStateZip.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToCounty
            '
            Me.LabelDetail_ShipToCounty.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToCounty")})
            Me.LabelDetail_ShipToCounty.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToCounty.LocationFloat = New DevExpress.Utils.PointFloat(0!, 85.00001!)
            Me.LabelDetail_ShipToCounty.Name = "LabelDetail_ShipToCounty"
            Me.LabelDetail_ShipToCounty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToCounty.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToCounty.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToCounty.StylePriority.UseFont = False
            '
            'LabelDetail_ShipToCountry
            '
            Me.LabelDetail_ShipToCountry.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ShipToCountry")})
            Me.LabelDetail_ShipToCountry.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ShipToCountry.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.0!)
            Me.LabelDetail_ShipToCountry.Name = "LabelDetail_ShipToCountry"
            Me.LabelDetail_ShipToCountry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ShipToCountry.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ShipToCountry.SizeF = New System.Drawing.SizeF(311.0!, 17.0!)
            Me.LabelDetail_ShipToCountry.StylePriority.UseFont = False
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
            Me.BottomMargin.HeightF = 31.74998!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'CalculatedFieldShipCityStateZip
            '
            Me.CalculatedFieldShipCityStateZip.Expression = "Iif( IsNullOrEmpty([ShipToCity]) And IsNullOrEmpty([ShipToState]) And IsNullOrEmp" &
    "ty([ShipToZip]), Null, ([ShipToCity] + ', ' + [ShipToState] + '  ' + [ShipToZip]" &
    "))"
            Me.CalculatedFieldShipCityStateZip.Name = "CalculatedFieldShipCityStateZip"
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
            'VendorShippingSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedFieldShipCityStateZip, Me.CalculatedFieldPhone, Me.CalculatedFieldFax})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 32)
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
        Friend WithEvents LabelDetail_ShipToName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToCountry As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToCounty As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToCityStateZip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToAddr3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToAddr2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ShipToAddr1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedFieldShipCityStateZip As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldPhone As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedFieldFax As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
