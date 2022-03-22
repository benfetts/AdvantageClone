Namespace MediaManager
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class BroadcastMonthYearSubReport
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
            Me.LabelMonthYear = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelTotalNet = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSpots = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelTotalNetWhenGrossOrder = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelTotalNetWhenGrossOrder, Me.LabelMonthYear, Me.LabelTotalNet, Me.LabelSpots})
            Me.Detail.HeightF = 68.00002!
            Me.Detail.MultiColumn.ColumnWidth = 70.83!
            Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
            Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("YearMonth", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelMonthYear
            '
            Me.LabelMonthYear.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelMonthYear.BorderWidth = 0.5!
            Me.LabelMonthYear.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MonthYear")})
            Me.LabelMonthYear.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelMonthYear.Name = "LabelMonthYear"
            Me.LabelMonthYear.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelMonthYear.SizeF = New System.Drawing.SizeF(70.83!, 17.00001!)
            Me.LabelMonthYear.StylePriority.UseBorders = False
            Me.LabelMonthYear.StylePriority.UseBorderWidth = False
            Me.LabelMonthYear.StylePriority.UseTextAlignment = False
            Me.LabelMonthYear.Text = "LabelMonthYear"
            Me.LabelMonthYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LabelTotalNet
            '
            Me.LabelTotalNet.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelTotalNet.BorderWidth = 0.5!
            Me.LabelTotalNet.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalNet", "{0:n2}")})
            Me.LabelTotalNet.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.00002!)
            Me.LabelTotalNet.Name = "LabelTotalNet"
            Me.LabelTotalNet.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelTotalNet.SizeF = New System.Drawing.SizeF(70.83!, 17.0!)
            Me.LabelTotalNet.StylePriority.UseBorders = False
            Me.LabelTotalNet.StylePriority.UseBorderWidth = False
            Me.LabelTotalNet.StylePriority.UseTextAlignment = False
            Me.LabelTotalNet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LabelSpots
            '
            Me.LabelSpots.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelSpots.BorderWidth = 0.5!
            Me.LabelSpots.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Spots")})
            Me.LabelSpots.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00001!)
            Me.LabelSpots.Name = "LabelSpots"
            Me.LabelSpots.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSpots.SizeF = New System.Drawing.SizeF(70.83!, 17.0!)
            Me.LabelSpots.StylePriority.UseBorders = False
            Me.LabelSpots.StylePriority.UseBorderWidth = False
            Me.LabelSpots.StylePriority.UseTextAlignment = False
            Me.LabelSpots.Text = "LabelSpots"
            Me.LabelSpots.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TopMargin.Visible = False
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
            Me.BindingSource.DataSource = GetType(AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth)
            '
            'LabelTotalNetWhenGrossOrder
            '
            Me.LabelTotalNetWhenGrossOrder.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelTotalNetWhenGrossOrder.BorderWidth = 0.5!
            Me.LabelTotalNetWhenGrossOrder.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalNetWhenGrossOrder", "{0:n2}")})
            Me.LabelTotalNetWhenGrossOrder.LocationFloat = New DevExpress.Utils.PointFloat(0!, 51.00002!)
            Me.LabelTotalNetWhenGrossOrder.Name = "LabelTotalNetWhenGrossOrder"
            Me.LabelTotalNetWhenGrossOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelTotalNetWhenGrossOrder.SizeF = New System.Drawing.SizeF(70.83!, 17.0!)
            Me.LabelTotalNetWhenGrossOrder.StylePriority.UseBorders = False
            Me.LabelTotalNetWhenGrossOrder.StylePriority.UseBorderWidth = False
            Me.LabelTotalNetWhenGrossOrder.StylePriority.UseTextAlignment = False
            Me.LabelTotalNetWhenGrossOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'BroadcastMonthYearSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageWidth = 932
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelTotalNet As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelSpots As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelMonthYear As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelTotalNetWhenGrossOrder As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
