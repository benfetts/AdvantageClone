Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class StandardGLAccountAllocationReport
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
            Me.SubReport_AllocationDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelDetail_TotalNumberOfEmployees = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TotalSquareFeet = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Type = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Account = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Comment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_TotalNumberOfEmployeesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_ToalSquareFeetLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_CommentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_TypeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AccountLabel = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubReport_AllocationDetails, Me.LabelDetail_TotalNumberOfEmployees, Me.LabelDetail_TotalSquareFeet, Me.LabelDetail_Type, Me.LabelDetail_Account, Me.LabelDetail_Comment, Me.LabelDetails_TotalNumberOfEmployeesLabel, Me.LabelDetails_ToalSquareFeetLabel, Me.LabelDetails_CommentLabel, Me.LabelDetails_TypeLabel, Me.LabelDetail_AccountLabel})
            Me.Detail.HeightF = 104.1249!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubReport_AllocationDetails
            '
            Me.SubReport_AllocationDetails.Id = 0
            Me.SubReport_AllocationDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 70.08321!)
            Me.SubReport_AllocationDetails.Name = "SubReport_AllocationDetails"
            Me.SubReport_AllocationDetails.ReportSource = New AdvantageFramework.Reporting.Reports.GeneralLedger.AccountAllocationDetailsSubReport()
            Me.SubReport_AllocationDetails.SizeF = New System.Drawing.SizeF(749.0!, 23.0!)
            '
            'LabelDetail_TotalNumberOfEmployees
            '
            Me.LabelDetail_TotalNumberOfEmployees.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TotalNumberOfEmployees.LocationFloat = New DevExpress.Utils.PointFloat(619.78!, 18.99999!)
            Me.LabelDetail_TotalNumberOfEmployees.Name = "LabelDetail_TotalNumberOfEmployees"
            Me.LabelDetail_TotalNumberOfEmployees.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TotalNumberOfEmployees.SizeF = New System.Drawing.SizeF(130.22!, 19.0!)
            Me.LabelDetail_TotalNumberOfEmployees.StylePriority.UseFont = False
            Me.LabelDetail_TotalNumberOfEmployees.Text = "LabelDetail_TotalNumberOfEmployees"
            '
            'LabelDetail_TotalSquareFeet
            '
            Me.LabelDetail_TotalSquareFeet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TotalSquareFeet.LocationFloat = New DevExpress.Utils.PointFloat(325.0051!, 18.99999!)
            Me.LabelDetail_TotalSquareFeet.Name = "LabelDetail_TotalSquareFeet"
            Me.LabelDetail_TotalSquareFeet.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TotalSquareFeet.SizeF = New System.Drawing.SizeF(118.7617!, 19.0!)
            Me.LabelDetail_TotalSquareFeet.StylePriority.UseFont = False
            Me.LabelDetail_TotalSquareFeet.Text = "LabelDetail_TotalSquareFeet"
            '
            'LabelDetail_Type
            '
            Me.LabelDetail_Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Type.LocationFloat = New DevExpress.Utils.PointFloat(65.625!, 18.99999!)
            Me.LabelDetail_Type.Name = "LabelDetail_Type"
            Me.LabelDetail_Type.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Type.SizeF = New System.Drawing.SizeF(141.6718!, 19.0!)
            Me.LabelDetail_Type.StylePriority.UseFont = False
            Me.LabelDetail_Type.Text = "LabelDetail_Type"
            '
            'LabelDetail_Account
            '
            Me.LabelDetail_Account.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Account.LocationFloat = New DevExpress.Utils.PointFloat(65.625!, 0.0!)
            Me.LabelDetail_Account.Name = "LabelDetail_Account"
            Me.LabelDetail_Account.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Account.SizeF = New System.Drawing.SizeF(683.38!, 19.0!)
            Me.LabelDetail_Account.StylePriority.UseFont = False
            Me.LabelDetail_Account.Text = "LabelDetail_Account"
            '
            'LabelDetail_Comment
            '
            Me.LabelDetail_Comment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Comment")})
            Me.LabelDetail_Comment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Comment.LocationFloat = New DevExpress.Utils.PointFloat(65.625!, 37.99998!)
            Me.LabelDetail_Comment.Name = "LabelDetail_Comment"
            Me.LabelDetail_Comment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Comment.SizeF = New System.Drawing.SizeF(683.38!, 19.0!)
            Me.LabelDetail_Comment.StylePriority.UseFont = False
            Me.LabelDetail_Comment.Text = "LabelDetail_Comment"
            '
            'LabelDetails_TotalNumberOfEmployeesLabel
            '
            Me.LabelDetails_TotalNumberOfEmployeesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_TotalNumberOfEmployeesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_TotalNumberOfEmployeesLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_TotalNumberOfEmployeesLabel.BorderWidth = 1
            Me.LabelDetails_TotalNumberOfEmployeesLabel.CanGrow = False
            Me.LabelDetails_TotalNumberOfEmployeesLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_TotalNumberOfEmployeesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_TotalNumberOfEmployeesLabel.LocationFloat = New DevExpress.Utils.PointFloat(455.2251!, 18.99999!)
            Me.LabelDetails_TotalNumberOfEmployeesLabel.Name = "LabelDetails_TotalNumberOfEmployeesLabel"
            Me.LabelDetails_TotalNumberOfEmployeesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_TotalNumberOfEmployeesLabel.SizeF = New System.Drawing.SizeF(163.5416!, 19.0!)
            Me.LabelDetails_TotalNumberOfEmployeesLabel.StylePriority.UseFont = False
            Me.LabelDetails_TotalNumberOfEmployeesLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetails_TotalNumberOfEmployeesLabel.Text = "Total Number of Employees:"
            Me.LabelDetails_TotalNumberOfEmployeesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails_ToalSquareFeetLabel
            '
            Me.LabelDetails_ToalSquareFeetLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_ToalSquareFeetLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_ToalSquareFeetLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_ToalSquareFeetLabel.BorderWidth = 1
            Me.LabelDetails_ToalSquareFeetLabel.CanGrow = False
            Me.LabelDetails_ToalSquareFeetLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_ToalSquareFeetLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_ToalSquareFeetLabel.LocationFloat = New DevExpress.Utils.PointFloat(217.7134!, 18.99999!)
            Me.LabelDetails_ToalSquareFeetLabel.Name = "LabelDetails_ToalSquareFeetLabel"
            Me.LabelDetails_ToalSquareFeetLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_ToalSquareFeetLabel.SizeF = New System.Drawing.SizeF(107.2916!, 19.0!)
            Me.LabelDetails_ToalSquareFeetLabel.StylePriority.UseFont = False
            Me.LabelDetails_ToalSquareFeetLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetails_ToalSquareFeetLabel.Text = "Total Square Feet:"
            Me.LabelDetails_ToalSquareFeetLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails_CommentLabel
            '
            Me.LabelDetails_CommentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_CommentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_CommentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_CommentLabel.BorderWidth = 1
            Me.LabelDetails_CommentLabel.CanGrow = False
            Me.LabelDetails_CommentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_CommentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_CommentLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 37.99998!)
            Me.LabelDetails_CommentLabel.Name = "LabelDetails_CommentLabel"
            Me.LabelDetails_CommentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_CommentLabel.SizeF = New System.Drawing.SizeF(65.62489!, 19.0!)
            Me.LabelDetails_CommentLabel.StylePriority.UseFont = False
            Me.LabelDetails_CommentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetails_CommentLabel.Text = "Comment:"
            Me.LabelDetails_CommentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails_TypeLabel
            '
            Me.LabelDetails_TypeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_TypeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_TypeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_TypeLabel.BorderWidth = 1
            Me.LabelDetails_TypeLabel.CanGrow = False
            Me.LabelDetails_TypeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_TypeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails_TypeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 18.99999!)
            Me.LabelDetails_TypeLabel.Name = "LabelDetails_TypeLabel"
            Me.LabelDetails_TypeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_TypeLabel.SizeF = New System.Drawing.SizeF(65.62489!, 19.0!)
            Me.LabelDetails_TypeLabel.StylePriority.UseFont = False
            Me.LabelDetails_TypeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetails_TypeLabel.Text = "Type:"
            Me.LabelDetails_TypeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_AccountLabel
            '
            Me.LabelDetail_AccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AccountLabel.BorderWidth = 1
            Me.LabelDetail_AccountLabel.CanGrow = False
            Me.LabelDetail_AccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelDetail_AccountLabel.Name = "LabelDetail_AccountLabel"
            Me.LabelDetail_AccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AccountLabel.SizeF = New System.Drawing.SizeF(65.62489!, 19.0!)
            Me.LabelDetail_AccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AccountLabel.Text = "Account:"
            Me.LabelDetail_AccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelPageHeader_Title.Text = "Standard GL Account Allocation Report"
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
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Database.Entities.GLAllocation)
            '
            'StandardGLAccountAllocationReport
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
        Private WithEvents LabelDetails_TotalNumberOfEmployeesLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetails_ToalSquareFeetLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetails_CommentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetails_TypeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents LabelDetail_TotalNumberOfEmployees As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TotalSquareFeet As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Type As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Account As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Comment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubReport_AllocationDetails As DevExpress.XtraReports.UI.XRSubreport

    End Class

End Namespace
