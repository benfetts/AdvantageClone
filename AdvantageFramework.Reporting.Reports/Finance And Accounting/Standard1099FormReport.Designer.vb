Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Standard1099FormReport
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
            Me.Label_PayToAddress3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Box17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_MedicalHealthCare = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PayToName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PayToAddress2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PayToCSZ = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PayToAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_FederalTaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CompanyFederalTaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_BranchReporting = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_GrossProceeds = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_OtherIncome = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Royalties = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Rents = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CompanyTelephone = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CompanyCityStateZip = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CompanyAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CompanyName = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.VendorCSZ = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_PayToAddress3, Me.Label_Box17, Me.Label_MedicalHealthCare, Me.Label_PayToName, Me.Label_PayToAddress2, Me.Label_PayToCSZ, Me.Label_PayToAddress, Me.Label_FederalTaxID, Me.Label_CompanyFederalTaxID, Me.Label_BranchReporting, Me.Label_GrossProceeds, Me.Label_OtherIncome, Me.Label_Royalties, Me.Label_Rents, Me.Label_CompanyTelephone, Me.Label_CompanyCityStateZip, Me.Label_CompanyAddress, Me.Label_CompanyName})
            Me.Detail.HeightF = 550.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PayToAddress3
            '
            Me.Label_PayToAddress3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress3")})
            Me.Label_PayToAddress3.Font = New System.Drawing.Font("Arial", 7.0!)
            Me.Label_PayToAddress3.LocationFloat = New DevExpress.Utils.PointFloat(15.00003!, 297.04!)
            Me.Label_PayToAddress3.Name = "Label_PayToAddress3"
            Me.Label_PayToAddress3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PayToAddress3.SizeF = New System.Drawing.SizeF(312.5!, 12.0!)
            Me.Label_PayToAddress3.StylePriority.UseFont = False
            '
            'Label_Box17
            '
            Me.Label_Box17.BackColor = System.Drawing.Color.Transparent
            Me.Label_Box17.BorderColor = System.Drawing.Color.Black
            Me.Label_Box17.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Box17.BorderWidth = 1.0!
            Me.Label_Box17.CanGrow = False
            Me.Label_Box17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_Box17.ForeColor = System.Drawing.Color.Black
            Me.Label_Box17.LocationFloat = New DevExpress.Utils.PointFloat(502.0833!, 406.16!)
            Me.Label_Box17.Name = "Label_Box17"
            Me.Label_Box17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Box17.SizeF = New System.Drawing.SizeF(125.0!, 20.83!)
            Me.Label_Box17.StylePriority.UseFont = False
            Me.Label_Box17.StylePriority.UseTextAlignment = False
            Me.Label_Box17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_MedicalHealthCare
            '
            Me.Label_MedicalHealthCare.BackColor = System.Drawing.Color.Transparent
            Me.Label_MedicalHealthCare.BorderColor = System.Drawing.Color.Black
            Me.Label_MedicalHealthCare.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_MedicalHealthCare.BorderWidth = 1.0!
            Me.Label_MedicalHealthCare.CanGrow = False
            Me.Label_MedicalHealthCare.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_MedicalHealthCare.ForeColor = System.Drawing.Color.Black
            Me.Label_MedicalHealthCare.LocationFloat = New DevExpress.Utils.PointFloat(502.0833!, 185.0!)
            Me.Label_MedicalHealthCare.Name = "Label_MedicalHealthCare"
            Me.Label_MedicalHealthCare.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_MedicalHealthCare.SizeF = New System.Drawing.SizeF(90.63!, 20.83!)
            Me.Label_MedicalHealthCare.StylePriority.UseFont = False
            Me.Label_MedicalHealthCare.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PayToName
            '
            Me.Label_PayToName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToName")})
            Me.Label_PayToName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PayToName.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 228.7!)
            Me.Label_PayToName.Name = "Label_PayToName"
            Me.Label_PayToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PayToName.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_PayToName.StylePriority.UseFont = False
            Me.Label_PayToName.Text = "Label_PayToName"
            '
            'Label_PayToAddress2
            '
            Me.Label_PayToAddress2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress2")})
            Me.Label_PayToAddress2.Font = New System.Drawing.Font("Arial", 7.0!)
            Me.Label_PayToAddress2.LocationFloat = New DevExpress.Utils.PointFloat(15.00003!, 285.0401!)
            Me.Label_PayToAddress2.Name = "Label_PayToAddress2"
            Me.Label_PayToAddress2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PayToAddress2.SizeF = New System.Drawing.SizeF(312.5!, 12.0!)
            Me.Label_PayToAddress2.StylePriority.UseFont = False
            Me.Label_PayToAddress2.Text = "Label_PayToAddress2"
            '
            'Label_PayToCSZ
            '
            Me.Label_PayToCSZ.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCSZ")})
            Me.Label_PayToCSZ.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_PayToCSZ.LocationFloat = New DevExpress.Utils.PointFloat(15.00001!, 320.83!)
            Me.Label_PayToCSZ.Name = "Label_PayToCSZ"
            Me.Label_PayToCSZ.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PayToCSZ.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_PayToCSZ.StylePriority.UseFont = False
            Me.Label_PayToCSZ.Text = "Label_PayToCSZ"
            '
            'Label_PayToAddress
            '
            Me.Label_PayToAddress.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress")})
            Me.Label_PayToAddress.Font = New System.Drawing.Font("Arial", 7.0!)
            Me.Label_PayToAddress.LocationFloat = New DevExpress.Utils.PointFloat(15.00003!, 273.0401!)
            Me.Label_PayToAddress.Name = "Label_PayToAddress"
            Me.Label_PayToAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PayToAddress.SizeF = New System.Drawing.SizeF(312.5!, 12.0!)
            Me.Label_PayToAddress.StylePriority.UseFont = False
            Me.Label_PayToAddress.Text = "Label_PayToAddress"
            '
            'Label_FederalTaxID
            '
            Me.Label_FederalTaxID.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FederalTaxID")})
            Me.Label_FederalTaxID.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_FederalTaxID.LocationFloat = New DevExpress.Utils.PointFloat(180.8299!, 187.0!)
            Me.Label_FederalTaxID.Name = "Label_FederalTaxID"
            Me.Label_FederalTaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FederalTaxID.SizeF = New System.Drawing.SizeF(150.0!, 16.67!)
            Me.Label_FederalTaxID.StylePriority.UseFont = False
            Me.Label_FederalTaxID.Text = "Label_FederalTaxID"
            '
            'Label_CompanyFederalTaxID
            '
            Me.Label_CompanyFederalTaxID.BackColor = System.Drawing.Color.Transparent
            Me.Label_CompanyFederalTaxID.BorderColor = System.Drawing.Color.Black
            Me.Label_CompanyFederalTaxID.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CompanyFederalTaxID.BorderWidth = 1.0!
            Me.Label_CompanyFederalTaxID.CanGrow = False
            Me.Label_CompanyFederalTaxID.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_CompanyFederalTaxID.ForeColor = System.Drawing.Color.Black
            Me.Label_CompanyFederalTaxID.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 187.0!)
            Me.Label_CompanyFederalTaxID.Name = "Label_CompanyFederalTaxID"
            Me.Label_CompanyFederalTaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CompanyFederalTaxID.SizeF = New System.Drawing.SizeF(150.0!, 16.67!)
            Me.Label_CompanyFederalTaxID.StylePriority.UseFont = False
            Me.Label_CompanyFederalTaxID.Text = "CompanyFederalTaxID"
            Me.Label_CompanyFederalTaxID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_BranchReporting
            '
            Me.Label_BranchReporting.BackColor = System.Drawing.Color.Transparent
            Me.Label_BranchReporting.BorderColor = System.Drawing.Color.Black
            Me.Label_BranchReporting.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_BranchReporting.BorderWidth = 1.0!
            Me.Label_BranchReporting.CanGrow = False
            Me.Label_BranchReporting.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Label_BranchReporting.ForeColor = System.Drawing.Color.Black
            Me.Label_BranchReporting.LocationFloat = New DevExpress.Utils.PointFloat(310.0!, 145.83!)
            Me.Label_BranchReporting.Name = "Label_BranchReporting"
            Me.Label_BranchReporting.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_BranchReporting.SizeF = New System.Drawing.SizeF(20.83!, 18.75!)
            Me.Label_BranchReporting.StylePriority.UseFont = False
            Me.Label_BranchReporting.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_GrossProceeds
            '
            Me.Label_GrossProceeds.BackColor = System.Drawing.Color.Transparent
            Me.Label_GrossProceeds.BorderColor = System.Drawing.Color.Black
            Me.Label_GrossProceeds.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_GrossProceeds.BorderWidth = 1.0!
            Me.Label_GrossProceeds.CanGrow = False
            Me.Label_GrossProceeds.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_GrossProceeds.ForeColor = System.Drawing.Color.Black
            Me.Label_GrossProceeds.LocationFloat = New DevExpress.Utils.PointFloat(502.0833!, 276.2101!)
            Me.Label_GrossProceeds.Name = "Label_GrossProceeds"
            Me.Label_GrossProceeds.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_GrossProceeds.SizeF = New System.Drawing.SizeF(90.63!, 20.83!)
            Me.Label_GrossProceeds.StylePriority.UseFont = False
            Me.Label_GrossProceeds.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_OtherIncome
            '
            Me.Label_OtherIncome.BackColor = System.Drawing.Color.Transparent
            Me.Label_OtherIncome.BorderColor = System.Drawing.Color.Black
            Me.Label_OtherIncome.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_OtherIncome.BorderWidth = 1.0!
            Me.Label_OtherIncome.CanGrow = False
            Me.Label_OtherIncome.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_OtherIncome.ForeColor = System.Drawing.Color.Black
            Me.Label_OtherIncome.LocationFloat = New DevExpress.Utils.PointFloat(369.9999!, 117.0!)
            Me.Label_OtherIncome.Name = "Label_OtherIncome"
            Me.Label_OtherIncome.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_OtherIncome.SizeF = New System.Drawing.SizeF(90.63!, 20.83!)
            Me.Label_OtherIncome.StylePriority.UseFont = False
            Me.Label_OtherIncome.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Royalties
            '
            Me.Label_Royalties.BackColor = System.Drawing.Color.Transparent
            Me.Label_Royalties.BorderColor = System.Drawing.Color.Black
            Me.Label_Royalties.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Royalties.BorderWidth = 1.0!
            Me.Label_Royalties.CanGrow = False
            Me.Label_Royalties.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_Royalties.ForeColor = System.Drawing.Color.Black
            Me.Label_Royalties.LocationFloat = New DevExpress.Utils.PointFloat(369.9999!, 79.17999!)
            Me.Label_Royalties.Name = "Label_Royalties"
            Me.Label_Royalties.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Royalties.SizeF = New System.Drawing.SizeF(90.63!, 20.83!)
            Me.Label_Royalties.StylePriority.UseFont = False
            Me.Label_Royalties.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Rents
            '
            Me.Label_Rents.BackColor = System.Drawing.Color.Transparent
            Me.Label_Rents.BorderColor = System.Drawing.Color.Black
            Me.Label_Rents.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Rents.BorderWidth = 1.0!
            Me.Label_Rents.CanGrow = False
            Me.Label_Rents.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label_Rents.ForeColor = System.Drawing.Color.Black
            Me.Label_Rents.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 29.16999!)
            Me.Label_Rents.Name = "Label_Rents"
            Me.Label_Rents.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Rents.SizeF = New System.Drawing.SizeF(90.63!, 20.83!)
            Me.Label_Rents.StylePriority.UseFont = False
            Me.Label_Rents.StylePriority.UseForeColor = False
            Me.Label_Rents.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CompanyTelephone
            '
            Me.Label_CompanyTelephone.BackColor = System.Drawing.Color.Transparent
            Me.Label_CompanyTelephone.BorderColor = System.Drawing.Color.Black
            Me.Label_CompanyTelephone.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CompanyTelephone.BorderWidth = 1.0!
            Me.Label_CompanyTelephone.CanGrow = False
            Me.Label_CompanyTelephone.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_CompanyTelephone.ForeColor = System.Drawing.Color.Black
            Me.Label_CompanyTelephone.LocationFloat = New DevExpress.Utils.PointFloat(15.00001!, 83.33999!)
            Me.Label_CompanyTelephone.Name = "Label_CompanyTelephone"
            Me.Label_CompanyTelephone.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CompanyTelephone.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_CompanyTelephone.StylePriority.UseFont = False
            Me.Label_CompanyTelephone.Text = "CompanyTelephone"
            Me.Label_CompanyTelephone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CompanyCityStateZip
            '
            Me.Label_CompanyCityStateZip.BackColor = System.Drawing.Color.Transparent
            Me.Label_CompanyCityStateZip.BorderColor = System.Drawing.Color.Black
            Me.Label_CompanyCityStateZip.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CompanyCityStateZip.BorderWidth = 1.0!
            Me.Label_CompanyCityStateZip.CanGrow = False
            Me.Label_CompanyCityStateZip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_CompanyCityStateZip.ForeColor = System.Drawing.Color.Black
            Me.Label_CompanyCityStateZip.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 66.66999!)
            Me.Label_CompanyCityStateZip.Name = "Label_CompanyCityStateZip"
            Me.Label_CompanyCityStateZip.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CompanyCityStateZip.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_CompanyCityStateZip.StylePriority.UseFont = False
            Me.Label_CompanyCityStateZip.Text = "CompanyCityStateZip"
            Me.Label_CompanyCityStateZip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CompanyAddress
            '
            Me.Label_CompanyAddress.BackColor = System.Drawing.Color.Transparent
            Me.Label_CompanyAddress.BorderColor = System.Drawing.Color.Black
            Me.Label_CompanyAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CompanyAddress.BorderWidth = 1.0!
            Me.Label_CompanyAddress.CanGrow = False
            Me.Label_CompanyAddress.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_CompanyAddress.ForeColor = System.Drawing.Color.Black
            Me.Label_CompanyAddress.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 49.99999!)
            Me.Label_CompanyAddress.Name = "Label_CompanyAddress"
            Me.Label_CompanyAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CompanyAddress.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_CompanyAddress.StylePriority.UseFont = False
            Me.Label_CompanyAddress.Text = "CompanyAddress"
            Me.Label_CompanyAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CompanyName
            '
            Me.Label_CompanyName.BackColor = System.Drawing.Color.Transparent
            Me.Label_CompanyName.BorderColor = System.Drawing.Color.Black
            Me.Label_CompanyName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CompanyName.BorderWidth = 1.0!
            Me.Label_CompanyName.CanGrow = False
            Me.Label_CompanyName.CanShrink = True
            Me.Label_CompanyName.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.Label_CompanyName.ForeColor = System.Drawing.Color.Black
            Me.Label_CompanyName.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 33.32999!)
            Me.Label_CompanyName.Name = "Label_CompanyName"
            Me.Label_CompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CompanyName.SizeF = New System.Drawing.SizeF(312.5!, 16.67!)
            Me.Label_CompanyName.StylePriority.UseFont = False
            Me.Label_CompanyName.Text = "CompanyName"
            Me.Label_CompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'VendorCSZ
            '
            Me.VendorCSZ.Expression = "[PayToCity] + ', ' + [PayToState] + '  ' + [PayToZipCode]"
            Me.VendorCSZ.Name = "VendorCSZ"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.IRS1099Processing)
            '
            'Standard1099FormReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.VendorCSZ})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents Label_CompanyName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CompanyAddress As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CompanyTelephone As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CompanyCityStateZip As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Rents As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_GrossProceeds As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_OtherIncome As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Royalties As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_BranchReporting As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CompanyFederalTaxID As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_FederalTaxID As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PayToAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorCSZ As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Label_PayToCSZ As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PayToAddress2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PayToName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_MedicalHealthCare As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Box17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PayToAddress3 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
