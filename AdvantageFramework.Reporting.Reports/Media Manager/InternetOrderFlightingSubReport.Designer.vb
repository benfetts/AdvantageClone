Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class InternetOrderFlightingSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_EndLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_EndLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2})
            Me.Detail.HeightF = 19.00002!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel7
            '
            Me.XrLabel7.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Cost]")})
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(620.21!, 0.00003178914!)
            Me.XrLabel7.Multiline = True
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(129.79!, 18.99999!)
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            Me.XrLabel7.Text = "XrLabel7"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel7.TextFormatString = "{0:n2}"
            '
            'XrLabel6
            '
            Me.XrLabel6.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Units]")})
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(458.1301!, 0!)
            Me.XrLabel6.Multiline = True
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(82.29166!, 18.99999!)
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "XrLabel6"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel6.TextFormatString = "{0:#,#}"
            '
            'XrLabel5
            '
            Me.XrLabel5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Rate]")})
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(545.4218!, 0!)
            Me.XrLabel5.Multiline = True
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(69.78824!, 19.00002!)
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            Me.XrLabel5.Text = "XrLabel5"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel5.TextFormatString = "{0:n2}"
            '
            'XrLabel4
            '
            Me.XrLabel4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EndDate]")})
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(188.5!, 0!)
            Me.XrLabel4.Multiline = True
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(67.71004!, 19.00001!)
            Me.XrLabel4.Text = "XrLabel4"
            Me.XrLabel4.TextFormatString = "{0:M/d/yyyy}"
            '
            'XrLabel2
            '
            Me.XrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StartDate]")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(104.13!, 0!)
            Me.XrLabel2.Multiline = True
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(67.70998!, 19.0!)
            Me.XrLabel2.Text = "XrLabel2"
            Me.XrLabel2.TextFormatString = "{0:M/d/yyyy}"
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
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.LabelHeaderOrderNumber_EndLabel2, Me.LabelHeaderOrderNumber_EndLabel1, Me.LabelHeaderOrderNumber_TypeHeadlineLabel, Me.XrLabel1})
            Me.ReportHeader.HeightF = 16.67!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(620.21!, 0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(129.79!, 16.67!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UsePadding = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Cost"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelHeaderOrderNumber_EndLabel2
            '
            Me.LabelHeaderOrderNumber_EndLabel2.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_EndLabel2.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_EndLabel2.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_EndLabel2.CanGrow = False
            Me.LabelHeaderOrderNumber_EndLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_EndLabel2.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel2.LocationFloat = New DevExpress.Utils.PointFloat(104.13!, 0!)
            Me.LabelHeaderOrderNumber_EndLabel2.Name = "LabelHeaderOrderNumber_EndLabel2"
            Me.LabelHeaderOrderNumber_EndLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_EndLabel2.SizeF = New System.Drawing.SizeF(67.71!, 16.67!)
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_EndLabel2.Text = "Start Date"
            Me.LabelHeaderOrderNumber_EndLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_EndLabel1
            '
            Me.LabelHeaderOrderNumber_EndLabel1.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_EndLabel1.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_EndLabel1.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_EndLabel1.CanGrow = False
            Me.LabelHeaderOrderNumber_EndLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_EndLabel1.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel1.LocationFloat = New DevExpress.Utils.PointFloat(188.5!, 0!)
            Me.LabelHeaderOrderNumber_EndLabel1.Name = "LabelHeaderOrderNumber_EndLabel1"
            Me.LabelHeaderOrderNumber_EndLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_EndLabel1.SizeF = New System.Drawing.SizeF(67.71!, 16.67!)
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_EndLabel1.Text = "End Date"
            Me.LabelHeaderOrderNumber_EndLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_TypeHeadlineLabel
            '
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.LocationFloat = New DevExpress.Utils.PointFloat(458.1301!, 0!)
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Name = "LabelHeaderOrderNumber_TypeHeadlineLabel"
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.SizeF = New System.Drawing.SizeF(82.29169!, 16.67!)
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.Text = "Units"
            Me.LabelHeaderOrderNumber_TypeHeadlineLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(545.4218!, 0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(69.78821!, 16.67!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UsePadding = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "Rate"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.MediaManager.Classes.InternetOrderFlightingSubReport)
            '
            'InternetOrderFlightingSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 32)
            Me.PageWidth = 750
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
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_EndLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_EndLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_TypeHeadlineLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
