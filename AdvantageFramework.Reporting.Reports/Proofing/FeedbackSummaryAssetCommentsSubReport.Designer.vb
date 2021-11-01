Namespace Proofing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class FeedbackSummaryAssetCommentsSubReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeedbackSummaryAssetCommentsSubReport))
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.RichText_Comment = New DevExpress.XtraReports.UI.XRRichText()
            Me.Label_NameAndDate = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.RichText_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 5.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Visible = False
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 5.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Visible = False
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.RichText_Comment, Me.Label_NameAndDate})
            Me.Detail.HeightF = 33.87706!
            Me.Detail.Name = "Detail"
            '
            'RichText_Comment
            '
            Me.RichText_Comment.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
            Me.RichText_Comment.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top
            Me.RichText_Comment.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.RichText_Comment.LocationFloat = New DevExpress.Utils.PointFloat(9.999969!, 10.00001!)
            Me.RichText_Comment.Name = "RichText_Comment"
            Me.RichText_Comment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.RichText_Comment.SerializableRtfString = resources.GetString("RichText_Comment.SerializableRtfString")
            Me.RichText_Comment.SizeF = New System.Drawing.SizeF(339.1005!, 23.0!)
            '
            'Label_NameAndDate
            '
            Me.Label_NameAndDate.BackColor = System.Drawing.Color.Transparent
            Me.Label_NameAndDate.BorderColor = System.Drawing.Color.Black
            Me.Label_NameAndDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_NameAndDate.BorderWidth = 1.0!
            Me.Label_NameAndDate.CanGrow = False
            Me.Label_NameAndDate.Font = New System.Drawing.Font("Arial", 6.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_NameAndDate.ForeColor = System.Drawing.Color.Black
            Me.Label_NameAndDate.LocationFloat = New DevExpress.Utils.PointFloat(9.999969!, 0.00002167442!)
            Me.Label_NameAndDate.Name = "Label_NameAndDate"
            Me.Label_NameAndDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_NameAndDate.SizeF = New System.Drawing.SizeF(292.2255!, 8.895211!)
            Me.Label_NameAndDate.StylePriority.UseFont = False
            Me.Label_NameAndDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'FeedbackSummaryAssetCommentsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(6, 10, 5, 5)
            Me.Version = "20.1"
            CType(Me.RichText_Comment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Private WithEvents Label_NameAndDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents RichText_Comment As DevExpress.XtraReports.UI.XRRichText
    End Class
End Namespace
