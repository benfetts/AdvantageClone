Namespace MediaManager

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class NewspaperChargesSubReport
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
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeaderChargeDescription = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterChargeDescription = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterChargeDescription_ChargeDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ChargeDesc = New DevExpress.XtraReports.UI.CalculatedField()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseTextAlignment = False
            Me.Detail.Visible = False
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
            Me.BottomMargin.HeightF = 0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.NewspaperOtherCharge)
            '
            'GroupHeaderChargeDescription
            '
            Me.GroupHeaderChargeDescription.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ChargeDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderChargeDescription.HeightF = 0!
            Me.GroupHeaderChargeDescription.Name = "GroupHeaderChargeDescription"
            Me.GroupHeaderChargeDescription.Visible = False
            '
            'GroupFooterChargeDescription
            '
            Me.GroupFooterChargeDescription.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.LabelGroupFooterChargeDescription_ChargeDescription, Me.XrLabel1})
            Me.GroupFooterChargeDescription.HeightF = 19.0!
            Me.GroupFooterChargeDescription.Name = "GroupFooterChargeDescription"
            '
            'LabelGroupFooterChargeDescription_ChargeDescription
            '
            Me.LabelGroupFooterChargeDescription_ChargeDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ChargeDesc")})
            Me.LabelGroupFooterChargeDescription_ChargeDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterChargeDescription_ChargeDescription.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelGroupFooterChargeDescription_ChargeDescription.Name = "LabelGroupFooterChargeDescription_ChargeDescription"
            Me.LabelGroupFooterChargeDescription_ChargeDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterChargeDescription_ChargeDescription.SizeF = New System.Drawing.SizeF(253.0417!, 19.0!)
            Me.LabelGroupFooterChargeDescription_ChargeDescription.StylePriority.UseFont = False
            Me.LabelGroupFooterChargeDescription_ChargeDescription.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterChargeDescription_ChargeDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(263.4585!, 0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(97.99988!, 19.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel1.Summary = XrSummary2
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ChargeDesc
            '
            Me.ChargeDesc.Expression = "[ChargeDescription] + ':'"
            Me.ChargeDesc.Name = "ChargeDesc"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(381.2965!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(97.99988!, 19.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel2.Summary = XrSummary1
            Me.XrLabel2.Text = "XrLabel1"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'NewspaperChargesSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderChargeDescription, Me.GroupFooterChargeDescription})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ChargeDesc})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageWidth = 495
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderChargeDescription As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterChargeDescription As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelGroupFooterChargeDescription_ChargeDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ChargeDesc As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel

    End Class

End Namespace
