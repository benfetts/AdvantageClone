Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ChargeToSubReport
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
            Me.LabelDetail_ChargeTo = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ChargeToLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Addr1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Addr2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CityStateZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CardNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CalculatedFieldCityStateZip = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_ChargeTo, Me.LabelDetail_ChargeToLabel, Me.LabelDetail_Name, Me.LabelDetail_Addr1, Me.LabelDetail_Addr2, Me.LabelDetail_CityStateZip, Me.LabelDetail_CardNumberLabel})
            Me.Detail.HeightF = 85.00003!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ChargeTo
            '
            Me.LabelDetail_ChargeTo.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_ChargeTo.LocationFloat = New DevExpress.Utils.PointFloat(175.9586!, 68.00003!)
            Me.LabelDetail_ChargeTo.Name = "LabelDetail_ChargeTo"
            Me.LabelDetail_ChargeTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ChargeTo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ChargeTo.SizeF = New System.Drawing.SizeF(324.0414!, 17.0!)
            Me.LabelDetail_ChargeTo.StylePriority.UseFont = False
            '
            'LabelDetail_ChargeToLabel
            '
            Me.LabelDetail_ChargeToLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ChargeToLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ChargeToLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ChargeToLabel.BorderWidth = 1.0!
            Me.LabelDetail_ChargeToLabel.CanGrow = False
            Me.LabelDetail_ChargeToLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_ChargeToLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ChargeToLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_ChargeToLabel.Name = "LabelDetail_ChargeToLabel"
            Me.LabelDetail_ChargeToLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ChargeToLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_ChargeToLabel.SizeF = New System.Drawing.SizeF(175.9585!, 17.0!)
            Me.LabelDetail_ChargeToLabel.StylePriority.UseFont = False
            Me.LabelDetail_ChargeToLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ChargeToLabel.Text = "Charge To:"
            Me.LabelDetail_ChargeToLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Name
            '
            Me.LabelDetail_Name.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Name")})
            Me.LabelDetail_Name.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Name.LocationFloat = New DevExpress.Utils.PointFloat(175.9585!, 0!)
            Me.LabelDetail_Name.Name = "LabelDetail_Name"
            Me.LabelDetail_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Name.SizeF = New System.Drawing.SizeF(324.0414!, 17.0!)
            Me.LabelDetail_Name.StylePriority.UseFont = False
            '
            'LabelDetail_Addr1
            '
            Me.LabelDetail_Addr1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address")})
            Me.LabelDetail_Addr1.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Addr1.LocationFloat = New DevExpress.Utils.PointFloat(175.9585!, 17.00001!)
            Me.LabelDetail_Addr1.Name = "LabelDetail_Addr1"
            Me.LabelDetail_Addr1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Addr1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Addr1.SizeF = New System.Drawing.SizeF(324.0414!, 17.0!)
            Me.LabelDetail_Addr1.StylePriority.UseFont = False
            '
            'LabelDetail_Addr2
            '
            Me.LabelDetail_Addr2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address2")})
            Me.LabelDetail_Addr2.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_Addr2.LocationFloat = New DevExpress.Utils.PointFloat(175.9585!, 34.00002!)
            Me.LabelDetail_Addr2.Name = "LabelDetail_Addr2"
            Me.LabelDetail_Addr2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Addr2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Addr2.SizeF = New System.Drawing.SizeF(324.0414!, 17.0!)
            Me.LabelDetail_Addr2.StylePriority.UseFont = False
            '
            'LabelDetail_CityStateZip
            '
            Me.LabelDetail_CityStateZip.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldCityStateZip")})
            Me.LabelDetail_CityStateZip.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelDetail_CityStateZip.LocationFloat = New DevExpress.Utils.PointFloat(175.9585!, 51.00002!)
            Me.LabelDetail_CityStateZip.Name = "LabelDetail_CityStateZip"
            Me.LabelDetail_CityStateZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CityStateZip.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CityStateZip.SizeF = New System.Drawing.SizeF(324.0414!, 17.0!)
            Me.LabelDetail_CityStateZip.StylePriority.UseFont = False
            '
            'LabelDetail_CardNumberLabel
            '
            Me.LabelDetail_CardNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CardNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CardNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CardNumberLabel.BorderWidth = 1.0!
            Me.LabelDetail_CardNumberLabel.CanGrow = False
            Me.LabelDetail_CardNumberLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_CardNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CardNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.00003!)
            Me.LabelDetail_CardNumberLabel.Name = "LabelDetail_CardNumberLabel"
            Me.LabelDetail_CardNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CardNumberLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CardNumberLabel.SizeF = New System.Drawing.SizeF(175.9585!, 17.0!)
            Me.LabelDetail_CardNumberLabel.StylePriority.UseFont = False
            Me.LabelDetail_CardNumberLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CardNumberLabel.Text = "Card Number:"
            Me.LabelDetail_CardNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.BottomMargin.HeightF = 32.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Agency)
            '
            'CalculatedFieldCityStateZip
            '
            Me.CalculatedFieldCityStateZip.Expression = "Iif(IsNullOrEmpty([City]), '', [City]) + ', ' + Iif(IsNullOrEmpty([State]), '', [" &
    "State]) + '  ' + Iif(IsNullOrEmpty([Zip]), '', [Zip])"
            Me.CalculatedFieldCityStateZip.Name = "CalculatedFieldCityStateZip"
            '
            'ChargeToSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedFieldCityStateZip})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 32)
            Me.PageWidth = 500
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
        Friend WithEvents LabelDetail_Name As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CityStateZip As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Addr2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Addr1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedFieldCityStateZip As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelDetail_ChargeToLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CardNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ChargeTo As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
