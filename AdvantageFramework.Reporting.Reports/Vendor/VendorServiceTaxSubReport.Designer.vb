Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class VendorServiceTaxSubReport
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
            Me.Label_ServiceTaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_WaiverExpirationDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBox_Waiver = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.Label_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.CheckBox_Enabled = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.Label_ServiceTaxType = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_WaiverExpirationDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Type = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Code = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_ServiceTaxCode, Me.Label_WaiverExpirationDate, Me.CheckBox_Waiver, Me.Label_Rate, Me.XrLine1, Me.CheckBox_Enabled, Me.Label_ServiceTaxType, Me.LabelDetail_WaiverExpirationDate, Me.LabelDetail_Rate, Me.LabelDetail_Type, Me.LabelDetail_Code})
            Me.Detail.HeightF = 53.00003!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ServiceTaxCode
            '
            Me.Label_ServiceTaxCode.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ServiceTaxCode.LocationFloat = New DevExpress.Utils.PointFloat(115.4168!, 0.0!)
            Me.Label_ServiceTaxCode.Name = "Label_ServiceTaxCode"
            Me.Label_ServiceTaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ServiceTaxCode.SizeF = New System.Drawing.SizeF(108.5832!, 19.00001!)
            Me.Label_ServiceTaxCode.StylePriority.UseFont = False
			'
			'Label_WaiverExpirationDate
			'
			Me.Label_WaiverExpirationDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ServiceTaxWaiverExpirationDate", "{0:d}")})
			Me.Label_WaiverExpirationDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_WaiverExpirationDate.LocationFloat = New DevExpress.Utils.PointFloat(613.375!, 0.00001589457!)
            Me.Label_WaiverExpirationDate.Name = "Label_WaiverExpirationDate"
            Me.Label_WaiverExpirationDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_WaiverExpirationDate.SizeF = New System.Drawing.SizeF(80.20819!, 19.00001!)
            Me.Label_WaiverExpirationDate.StylePriority.UseFont = False
            '
            'CheckBox_Waiver
            '
            Me.CheckBox_Waiver.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBox_Waiver.LocationFloat = New DevExpress.Utils.PointFloat(401.0833!, 0.00001589457!)
            Me.CheckBox_Waiver.Name = "CheckBox_Waiver"
            Me.CheckBox_Waiver.SizeF = New System.Drawing.SizeF(67.70837!, 18.99999!)
            Me.CheckBox_Waiver.StylePriority.UseFont = False
            Me.CheckBox_Waiver.StylePriority.UseTextAlignment = False
            Me.CheckBox_Waiver.Text = "Waiver"
            '
            'Label_Rate
            '
            Me.Label_Rate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ServiceTaxRate", "{0:n2}")})
            Me.Label_Rate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Rate.LocationFloat = New DevExpress.Utils.PointFloat(299.8334!, 0.00001589457!)
            Me.Label_Rate.Name = "Label_Rate"
            Me.Label_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Rate.SizeF = New System.Drawing.SizeF(80.20813!, 19.0!)
            Me.Label_Rate.StylePriority.UseFont = False
            Me.Label_Rate.StylePriority.UseTextAlignment = False
            Me.Label_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 38.00003!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(748.0!, 15.0!)
            '
            'CheckBox_Enabled
            '
            Me.CheckBox_Enabled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBox_Enabled.LocationFloat = New DevExpress.Utils.PointFloat(0.00009139379!, 0.0!)
            Me.CheckBox_Enabled.Name = "CheckBox_Enabled"
            Me.CheckBox_Enabled.SizeF = New System.Drawing.SizeF(67.70834!, 18.99999!)
            Me.CheckBox_Enabled.StylePriority.UseFont = False
            Me.CheckBox_Enabled.StylePriority.UseTextAlignment = False
            Me.CheckBox_Enabled.Text = "Enabled"
            '
            'Label_ServiceTaxType
            '
            Me.Label_ServiceTaxType.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ServiceTaxType.LocationFloat = New DevExpress.Utils.PointFloat(115.4168!, 19.00002!)
            Me.Label_ServiceTaxType.Name = "Label_ServiceTaxType"
            Me.Label_ServiceTaxType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ServiceTaxType.SizeF = New System.Drawing.SizeF(108.5832!, 19.00001!)
            Me.Label_ServiceTaxType.StylePriority.UseFont = False
            '
            'LabelDetail_WaiverExpirationDate
            '
            Me.LabelDetail_WaiverExpirationDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_WaiverExpirationDate.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_WaiverExpirationDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_WaiverExpirationDate.BorderWidth = 1.0!
            Me.LabelDetail_WaiverExpirationDate.CanGrow = False
            Me.LabelDetail_WaiverExpirationDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_WaiverExpirationDate.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_WaiverExpirationDate.LocationFloat = New DevExpress.Utils.PointFloat(468.7917!, 0.00001589457!)
            Me.LabelDetail_WaiverExpirationDate.Name = "LabelDetail_WaiverExpirationDate"
            Me.LabelDetail_WaiverExpirationDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_WaiverExpirationDate.SizeF = New System.Drawing.SizeF(144.5834!, 18.99999!)
            Me.LabelDetail_WaiverExpirationDate.StylePriority.UseFont = False
            Me.LabelDetail_WaiverExpirationDate.Text = "Waiver Expiration Date:"
            Me.LabelDetail_WaiverExpirationDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Rate
            '
            Me.LabelDetail_Rate.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Rate.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Rate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Rate.BorderWidth = 1.0!
            Me.LabelDetail_Rate.CanGrow = False
            Me.LabelDetail_Rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Rate.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Rate.LocationFloat = New DevExpress.Utils.PointFloat(251.0833!, 0.00001589457!)
            Me.LabelDetail_Rate.Name = "LabelDetail_Rate"
            Me.LabelDetail_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Rate.SizeF = New System.Drawing.SizeF(48.75012!, 19.0!)
            Me.LabelDetail_Rate.StylePriority.UseFont = False
            Me.LabelDetail_Rate.Text = "Rate:"
            Me.LabelDetail_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Type
            '
            Me.LabelDetail_Type.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Type.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Type.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Type.BorderWidth = 1.0!
            Me.LabelDetail_Type.CanGrow = False
            Me.LabelDetail_Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Type.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Type.LocationFloat = New DevExpress.Utils.PointFloat(67.70845!, 19.00002!)
            Me.LabelDetail_Type.Name = "LabelDetail_Type"
            Me.LabelDetail_Type.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Type.SizeF = New System.Drawing.SizeF(47.70833!, 19.0!)
            Me.LabelDetail_Type.StylePriority.UseFont = False
            Me.LabelDetail_Type.Text = "Type:"
            Me.LabelDetail_Type.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Code
            '
            Me.LabelDetail_Code.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Code.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Code.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Code.BorderWidth = 1.0!
            Me.LabelDetail_Code.CanGrow = False
            Me.LabelDetail_Code.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Code.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Code.LocationFloat = New DevExpress.Utils.PointFloat(67.70844!, 0.0!)
            Me.LabelDetail_Code.Name = "LabelDetail_Code"
            Me.LabelDetail_Code.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Code.SizeF = New System.Drawing.SizeF(47.70832!, 19.0!)
            Me.LabelDetail_Code.StylePriority.UseFont = False
            Me.LabelDetail_Code.Text = "Code:"
            Me.LabelDetail_Code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 26.83331!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabel1
            '
            Me.XrLabel1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(749.0!, 26.83331!)
            Me.XrLabel1.StylePriority.UseBorders = False
            Me.XrLabel1.StylePriority.UseBorderWidth = False
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseForeColor = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "Service Tax"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'VendorServiceTaxSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 101, 0, 7)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_WaiverExpirationDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Rate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Type As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Code As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ServiceTaxType As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBox_Enabled As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents CheckBox_Waiver As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents Label_WaiverExpirationDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ServiceTaxCode As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace