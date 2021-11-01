Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GLAccountGroupReport
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
            Me.XrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.Line_HeaderSeparator = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_CodeType = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_GroupCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_CodeType = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_DescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GroupCodeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelHeader_SortedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreport1, Me.Line_HeaderSeparator, Me.Label_CodeType, Me.Label_Description, Me.Label_GroupCode, Me.LabelDetails_CodeType, Me.LabelDetails_DescriptionLabel, Me.LabelDetail_GroupCodeLabel})
            Me.Detail.HeightF = 72.87486!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrSubreport1
            '
            Me.XrSubreport1.Id = 0
            Me.XrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 46.99999!)
            Me.XrSubreport1.Name = "XrSubreport1"
            Me.XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.GeneralLedger.GLAccountGroupFullAccountCodeSubReport()
            Me.XrSubreport1.SizeF = New System.Drawing.SizeF(749.0001!, 18.87488!)
            '
            'Line_HeaderSeparator
            '
            Me.Line_HeaderSeparator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 41.99997!)
            Me.Line_HeaderSeparator.Name = "Line_HeaderSeparator"
            Me.Line_HeaderSeparator.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            '
            'Label_CodeType
            '
            Me.Label_CodeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_CodeType.LocationFloat = New DevExpress.Utils.PointFloat(515.6418!, 0.0!)
            Me.Label_CodeType.Name = "Label_CodeType"
            Me.Label_CodeType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_CodeType.SizeF = New System.Drawing.SizeF(233.3583!, 19.0!)
            Me.Label_CodeType.StylePriority.UseFont = False
            Me.Label_CodeType.Text = "Label_CodeType"
            '
            'Label_Description
            '
            Me.Label_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(79.16666!, 18.99999!)
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(669.8334!, 19.0!)
            Me.Label_Description.StylePriority.UseFont = False
            Me.Label_Description.Text = "Label_Description"
            '
            'Label_GroupCode
            '
            Me.Label_GroupCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.Label_GroupCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_GroupCode.LocationFloat = New DevExpress.Utils.PointFloat(79.16666!, 0.0!)
            Me.Label_GroupCode.Name = "Label_GroupCode"
            Me.Label_GroupCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_GroupCode.SizeF = New System.Drawing.SizeF(364.6003!, 19.0!)
            Me.Label_GroupCode.StylePriority.UseFont = False
            Me.Label_GroupCode.Text = "Label_GroupCode"
            '
            'LabelDetails_CodeType
            '
            Me.LabelDetails_CodeType.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_CodeType.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_CodeType.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_CodeType.BorderWidth = 1
            Me.LabelDetails_CodeType.CanGrow = False
            Me.LabelDetails_CodeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_CodeType.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_CodeType.LocationFloat = New DevExpress.Utils.PointFloat(443.7668!, 0.0!)
            Me.LabelDetails_CodeType.Name = "LabelDetails_CodeType"
            Me.LabelDetails_CodeType.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_CodeType.SizeF = New System.Drawing.SizeF(71.87488!, 19.0!)
            Me.LabelDetails_CodeType.StylePriority.UseFont = False
            Me.LabelDetails_CodeType.StylePriority.UseTextAlignment = False
            Me.LabelDetails_CodeType.Text = "Code Type:"
            Me.LabelDetails_CodeType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails_DescriptionLabel
            '
            Me.LabelDetails_DescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_DescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_DescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_DescriptionLabel.BorderWidth = 1
            Me.LabelDetails_DescriptionLabel.CanGrow = False
            Me.LabelDetails_DescriptionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_DescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_DescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 18.99999!)
            Me.LabelDetails_DescriptionLabel.Name = "LabelDetails_DescriptionLabel"
            Me.LabelDetails_DescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_DescriptionLabel.SizeF = New System.Drawing.SizeF(79.16656!, 19.0!)
            Me.LabelDetails_DescriptionLabel.StylePriority.UseFont = False
            Me.LabelDetails_DescriptionLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetails_DescriptionLabel.Text = "Description:"
            Me.LabelDetails_DescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GroupCodeLabel
            '
            Me.LabelDetail_GroupCodeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GroupCodeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GroupCodeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GroupCodeLabel.BorderWidth = 1
            Me.LabelDetail_GroupCodeLabel.CanGrow = False
            Me.LabelDetail_GroupCodeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GroupCodeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GroupCodeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelDetail_GroupCodeLabel.Name = "LabelDetail_GroupCodeLabel"
            Me.LabelDetail_GroupCodeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GroupCodeLabel.SizeF = New System.Drawing.SizeF(79.16656!, 19.0!)
            Me.LabelDetail_GroupCodeLabel.StylePriority.UseFont = False
            Me.LabelDetail_GroupCodeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GroupCodeLabel.Text = "Group Code:"
            Me.LabelDetail_GroupCodeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.BottomMargin.HeightF = 59.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_SortedBy, Me.Line1, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic)
            Me.PageHeader.HeightF = 78.79162!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseFont = False
            '
            'LabelHeader_SortedBy
            '
            Me.LabelHeader_SortedBy.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelHeader_SortedBy.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 46.0!)
            Me.LabelHeader_SortedBy.Name = "LabelHeader_SortedBy"
            Me.LabelHeader_SortedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_SortedBy.SizeF = New System.Drawing.SizeF(479.9999!, 18.0!)
            Me.LabelHeader_SortedBy.StylePriority.UseFont = False
            Me.LabelHeader_SortedBy.StylePriority.UseTextAlignment = False
            Me.LabelHeader_SortedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
            Me.Line1.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(500.9585!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(248.0415!, 19.0!)
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
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
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
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(479.9999!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "GL Account Group"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_DateAndUserCode, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 27.00001!
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
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(614.5416!, 5.0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.BackColor = System.Drawing.Color.Gainsboro
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Database.Entities.AccountGroup)
            '
            'GLAccountGroupReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource1
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 59)
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
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
        Friend WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetails_CodeType As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetails_DescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GroupCodeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents Label_CodeType As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_GroupCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Line_HeaderSeparator As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrSubreport1 As DevExpress.XtraReports.UI.XRSubreport

    End Class

End Namespace
