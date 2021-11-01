Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Detail1099DisbursementSubReport
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
            Me.LabelDetail_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_DisbursedAmount, Me.LabelDetail_GLAccount})
            Me.Detail.Dpi = 100.0!
            Me.Detail.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Detail.HeightF = 23.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DisbursedAmount
            '
            Me.LabelDetail_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:c2}")})
            Me.LabelDetail_DisbursedAmount.Dpi = 100.0!
            Me.LabelDetail_DisbursedAmount.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelDetail_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(257.3334!, 0!)
            Me.LabelDetail_DisbursedAmount.Name = "LabelDetail_DisbursedAmount"
            Me.LabelDetail_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DisbursedAmount.SizeF = New System.Drawing.SizeF(141.6667!, 23.0!)
            Me.LabelDetail_DisbursedAmount.StylePriority.UseFont = False
            Me.LabelDetail_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DisbursedAmount.Text = "LabelDetail_DisbursedAmount"
            Me.LabelDetail_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLAccount
            '
            Me.LabelDetail_GLAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DetailGLAccount")})
            Me.LabelDetail_GLAccount.Dpi = 100.0!
            Me.LabelDetail_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelDetail_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_GLAccount.Name = "LabelDetail_GLAccount"
            Me.LabelDetail_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLAccount.SizeF = New System.Drawing.SizeF(257.3334!, 23.0!)
            Me.LabelDetail_GLAccount.StylePriority.UseFont = False
            Me.LabelDetail_GLAccount.Text = "LabelDetail_GLAccount"
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 33.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'FormattingRule1
            '
            Me.FormattingRule1.Name = "FormattingRule1"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.IRS1099DetailDisbursementReport)
            '
            'Detail1099DisbursementSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
            Me.Margins = New System.Drawing.Printing.Margins(75, 375, 0, 33)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents LabelDetail_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLAccount As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
