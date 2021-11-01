Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class OfficeAndDepartmentCrossReferenceReport
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
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.SubReport_OfficeCrossReference = New DevExpress.XtraReports.UI.XRSubreport()
            Me.SubReport_DepartmentCrossReference = New DevExpress.XtraReports.UI.XRSubreport()
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubReport_DepartmentCrossReference, Me.SubReport_OfficeCrossReference})
            Me.Detail.HeightF = 24.95817!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.BottomMargin.HeightF = 59.375!
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
            Me.Line1.SizeF = New System.Drawing.SizeF(999.0!, 4.0!)
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
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(488.0414!, 19.0!)
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
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
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
            Me.LabelPageHeader_Title.Text = "Office and Department Cross Reference Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_DateAndUserCode, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 27.0!
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
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 5.0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'SubReport_OfficeCrossReference
            '
            Me.SubReport_OfficeCrossReference.Id = 0
            Me.SubReport_OfficeCrossReference.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.SubReport_OfficeCrossReference.Name = "SubReport_OfficeCrossReference"
            Me.SubReport_OfficeCrossReference.ReportSource = New AdvantageFramework.Reporting.Reports.GeneralLedger.OfficeCrossReferenceSubReport()
            Me.SubReport_OfficeCrossReference.SizeF = New System.Drawing.SizeF(490.0!, 23.0!)
            '
            'SubReport_DepartmentCrossReference
            '
            Me.SubReport_DepartmentCrossReference.Id = 0
            Me.SubReport_DepartmentCrossReference.LocationFloat = New DevExpress.Utils.PointFloat(508.9585!, 0.0!)
            Me.SubReport_DepartmentCrossReference.Name = "SubReport_DepartmentCrossReference"
            Me.SubReport_DepartmentCrossReference.ReportSource = New AdvantageFramework.Reporting.Reports.GeneralLedger.DepartmentCrossReferenceSubReport()
            Me.SubReport_DepartmentCrossReference.SizeF = New System.Drawing.SizeF(490.0!, 23.0!)
            '
            'OfficeAndDepartmentCrossReferenceReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource1
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 51, 39, 59)
            Me.PageHeight = 850
            Me.PageWidth = 1100
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
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Friend WithEvents SubReport_DepartmentCrossReference As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents SubReport_OfficeCrossReference As DevExpress.XtraReports.UI.XRSubreport

    End Class

End Namespace
