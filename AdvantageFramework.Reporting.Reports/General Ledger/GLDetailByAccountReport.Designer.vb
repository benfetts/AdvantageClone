Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class GLDetailByAccountReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_GroupCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_SortedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.Line26 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.AccountGroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelAccountBeginningBalance = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AccountGroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LineReportFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LastGroup = New DevExpress.XtraReports.UI.FormattingRule()
            Me.AccountDetailGroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelCodeAndDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.AccountDetailGroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Balance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.NoDetailsFormattingRule = New DevExpress.XtraReports.UI.FormattingRule()
            Me.PostPeriodGroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.PostPeriodGroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelAccountEndingBalance = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.NoTransactions = New DevExpress.XtraReports.UI.FormattingRule()
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_CDP, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.Label_GroupCode})
            Me.Detail.HeightF = 29.99999!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CDP
            '
            Me.LabelDetail_CDP.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.LabelDetail_CDP.CanGrow = False
            Me.LabelDetail_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CDP")})
            Me.LabelDetail_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CDP.LocationFloat = New DevExpress.Utils.PointFloat(210.2455!, 14.99999!)
            Me.LabelDetail_CDP.Name = "LabelDetail_CDP"
            Me.LabelDetail_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CDP.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CDP.SizeF = New System.Drawing.SizeF(344.9998!, 15.0!)
            Me.LabelDetail_CDP.StylePriority.UseFont = False
            '
            'XrLabel14
            '
            Me.XrLabel14.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount", "{0:c}")})
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(652.1251!, 0!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(97.87488!, 15.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            Me.XrLabel14.StylePriority.UseTextAlignment = False
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel13
            '
            Me.XrLabel13.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount", "{0:c}")})
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(555.2501!, 0!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(96.87494!, 15.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.StylePriority.UseTextAlignment = False
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel12
            '
            Me.XrLabel12.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Remark")})
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(210.2502!, 0!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(344.9998!, 15.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(155.0419!, 0!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(55.20828!, 15.0!)
            Me.XrLabel11.StylePriority.UseFont = False
            '
            'XrLabel10
            '
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TransactionDate", "{0:d}")})
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(80.04203!, 0!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(74.99994!, 15.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            '
            'Label_GroupCode
            '
            Me.Label_GroupCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TransactionID")})
            Me.Label_GroupCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_GroupCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Label_GroupCode.Name = "Label_GroupCode"
            Me.Label_GroupCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_GroupCode.SizeF = New System.Drawing.SizeF(80.04204!, 15.0!)
            Me.Label_GroupCode.StylePriority.UseFont = False
            '
            'FormattingRule1
            '
            Me.FormattingRule1.Condition = "IsNull([PostPeriodCode])"
            Me.FormattingRule1.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRule1.Name = "FormattingRule1"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.XrLabel16, Me.XrLabel19, Me.XrLabel20, Me.XrLabel21, Me.XrLabel22, Me.LabelHeader_SortedBy, Me.Line1, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic)
            Me.PageHeader.HeightF = 109.2379!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseFont = False
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 87.49664!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(80.04202!, 19.00001!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.StylePriority.UseTextAlignment = False
            Me.XrLabel15.Text = "Transaction"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1.0!
            Me.XrLabel16.CanGrow = False
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel16.ForeColor = System.Drawing.Color.Black
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(80.04202!, 87.49665!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(74.99994!, 19.0!)
            Me.XrLabel16.StylePriority.UseFont = False
            Me.XrLabel16.StylePriority.UseTextAlignment = False
            Me.XrLabel16.Text = "Entry Date"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel19
            '
            Me.XrLabel19.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel19.BorderColor = System.Drawing.Color.Black
            Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel19.BorderWidth = 1.0!
            Me.XrLabel19.CanGrow = False
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel19.ForeColor = System.Drawing.Color.Black
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(155.0419!, 74.64665!)
            Me.XrLabel19.Multiline = True
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(55.2083!, 31.85!)
            Me.XrLabel19.StylePriority.UseFont = False
            Me.XrLabel19.StylePriority.UseTextAlignment = False
            Me.XrLabel19.Text = "Posting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Period"
            Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel20
            '
            Me.XrLabel20.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel20.ForeColor = System.Drawing.Color.Black
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(210.2502!, 87.49665!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(345.0!, 19.0!)
            Me.XrLabel20.StylePriority.UseFont = False
            Me.XrLabel20.StylePriority.UseTextAlignment = False
            Me.XrLabel20.Text = "Remark/CDP"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel21
            '
            Me.XrLabel21.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel21.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel21.BorderColor = System.Drawing.Color.Black
            Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel21.BorderWidth = 1.0!
            Me.XrLabel21.CanGrow = False
            Me.XrLabel21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel21.ForeColor = System.Drawing.Color.Black
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(555.2502!, 87.49665!)
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(96.87494!, 19.0!)
            Me.XrLabel21.StylePriority.UseFont = False
            Me.XrLabel21.StylePriority.UseTextAlignment = False
            Me.XrLabel21.Text = "Debit"
            Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'XrLabel22
            '
            Me.XrLabel22.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel22.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel22.BorderColor = System.Drawing.Color.Black
            Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel22.BorderWidth = 1.0!
            Me.XrLabel22.CanGrow = False
            Me.XrLabel22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel22.ForeColor = System.Drawing.Color.Black
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(652.1252!, 87.49665!)
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(97.87482!, 19.0!)
            Me.XrLabel22.StylePriority.UseFont = False
            Me.XrLabel22.StylePriority.UseTextAlignment = False
            Me.XrLabel22.Text = "Credit"
            Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
            Me.Line1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.Line1.BorderColor = System.Drawing.Color.Silver
            Me.Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line1.BorderWidth = 4.0!
            Me.Line1.ForeColor = System.Drawing.Color.Silver
            Me.Line1.LineWidth = 4.0!
            Me.Line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.54163!)
            Me.Line1.Name = "Line1"
            Me.Line1.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
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
            Me.LineTopLine.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4.0!
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.916656!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(479.9999!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "General Ledger Detail by Account"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line26, Me.LabelPageFooter_DateAndUserCode, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 27.00001!
            Me.PageFooter.Name = "PageFooter"
            Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.PageFooter.StylePriority.UsePadding = False
            '
            'Line26
            '
            Me.Line26.BorderColor = System.Drawing.Color.Silver
            Me.Line26.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line26.BorderWidth = 4.0!
            Me.Line26.ForeColor = System.Drawing.Color.Silver
            Me.Line26.LineWidth = 4.0!
            Me.Line26.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Line26.Name = "Line26"
            Me.Line26.SizeF = New System.Drawing.SizeF(749.0!, 4.0!)
            '
            'LabelPageFooter_DateAndUserCode
            '
            Me.LabelPageFooter_DateAndUserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_DateAndUserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_DateAndUserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_DateAndUserCode.CanGrow = False
            Me.LabelPageFooter_DateAndUserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_DateAndUserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
            Me.LabelPageFooter_DateAndUserCode.Name = "LabelPageFooter_DateAndUserCode"
            Me.LabelPageFooter_DateAndUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_DateAndUserCode.SizeF = New System.Drawing.SizeF(490.0!, 19.0!)
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_DateAndUserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(614.5416!, 5.0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.PageInfo_Pages.TextFormatString = "Page {0} of {1}"
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.BackColor = System.Drawing.Color.Gainsboro
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'AccountGroupHeader
            '
            Me.AccountGroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelAccountBeginningBalance, Me.XrLabel1})
            Me.AccountGroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.AccountGroupHeader.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail
            Me.AccountGroupHeader.HeightF = 33.16669!
            Me.AccountGroupHeader.KeepTogether = True
            Me.AccountGroupHeader.Level = 2
            Me.AccountGroupHeader.Name = "AccountGroupHeader"
            Me.AccountGroupHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.AccountGroupHeader.StylePriority.UsePadding = False
            '
            'LabelAccountBeginningBalance
            '
            Me.LabelAccountBeginningBalance.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.LabelAccountBeginningBalance.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountBeginningBalance")})
            Me.LabelAccountBeginningBalance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelAccountBeginningBalance.LocationFloat = New DevExpress.Utils.PointFloat(587.5168!, 10.00001!)
            Me.LabelAccountBeginningBalance.Name = "LabelAccountBeginningBalance"
            Me.LabelAccountBeginningBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelAccountBeginningBalance.SizeF = New System.Drawing.SizeF(152.4832!, 19.0!)
            Me.LabelAccountBeginningBalance.StylePriority.UseFont = False
            Me.LabelAccountBeginningBalance.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:c}"
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelAccountBeginningBalance.Summary = XrSummary1
            Me.LabelAccountBeginningBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(418.7669!, 10.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(168.7499!, 19.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "Account Beginning Balance:"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'AccountGroupFooter
            '
            Me.AccountGroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineReportFooter_1})
            Me.AccountGroupFooter.FormattingRules.Add(Me.LastGroup)
            Me.AccountGroupFooter.HeightF = 6.399155!
            Me.AccountGroupFooter.KeepTogether = True
            Me.AccountGroupFooter.Level = 2
            Me.AccountGroupFooter.Name = "AccountGroupFooter"
            Me.AccountGroupFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.AccountGroupFooter.PrintAtBottom = True
            Me.AccountGroupFooter.StylePriority.UsePadding = False
            '
            'LineReportFooter_1
            '
            Me.LineReportFooter_1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.LineReportFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_1.BorderWidth = 0!
            Me.LineReportFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.LineReportFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineReportFooter_1.Name = "LineReportFooter_1"
            Me.LineReportFooter_1.SizeF = New System.Drawing.SizeF(750.0!, 5.0!)
            Me.LineReportFooter_1.StylePriority.UseBorderColor = False
            Me.LineReportFooter_1.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_1.StylePriority.UseForeColor = False
            '
            'LastGroup
            '
            Me.LastGroup.Condition = "[DataSource.CurrentRowIndex] == ([DataSource.RowCount]  - 1)"
            Me.LastGroup.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.LastGroup.Name = "LastGroup"
            '
            'AccountDetailGroupHeader
            '
            Me.AccountDetailGroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelCodeAndDescription})
            Me.AccountDetailGroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.AccountDetailGroupHeader.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail
            Me.AccountDetailGroupHeader.HeightF = 22.12499!
            Me.AccountDetailGroupHeader.KeepTogether = True
            Me.AccountDetailGroupHeader.Level = 1
            Me.AccountDetailGroupHeader.Name = "AccountDetailGroupHeader"
            Me.AccountDetailGroupHeader.RepeatEveryPage = True
            '
            'LabelCodeAndDescription
            '
            Me.LabelCodeAndDescription.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.LabelCodeAndDescription.BackColor = System.Drawing.Color.Gainsboro
            Me.LabelCodeAndDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelCodeAndDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCodeAndDescription.BorderWidth = 1.0!
            Me.LabelCodeAndDescription.CanGrow = False
            Me.LabelCodeAndDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCodeAndDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelCodeAndDescription.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelCodeAndDescription.Name = "LabelCodeAndDescription"
            Me.LabelCodeAndDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
            Me.LabelCodeAndDescription.SizeF = New System.Drawing.SizeF(748.9951!, 19.0!)
            Me.LabelCodeAndDescription.StylePriority.UseBackColor = False
            Me.LabelCodeAndDescription.StylePriority.UseFont = False
            Me.LabelCodeAndDescription.StylePriority.UsePadding = False
            Me.LabelCodeAndDescription.StylePriority.UseTextAlignment = False
            Me.LabelCodeAndDescription.Text = "[AccountCode] [AccountDescription]"
            Me.LabelCodeAndDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'AccountDetailGroupFooter
            '
            Me.AccountDetailGroupFooter.FormattingRules.Add(Me.FormattingRule1)
            Me.AccountDetailGroupFooter.HeightF = 0!
            Me.AccountDetailGroupFooter.KeepTogether = True
            Me.AccountDetailGroupFooter.Level = 1
            Me.AccountDetailGroupFooter.Name = "AccountDetailGroupFooter"
            '
            'Balance
            '
            Me.Balance.Expression = "Iif(IsNull([AccountBeginningBalance]), 0, [AccountBeginningBalance]) + " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Iif(IsNu" &
    "ll([DebitAmount]), 0, [DebitAmount]) -" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Iif(IsNull([CreditAmount]), 0, [CreditAm" &
    "ount])"
            Me.Balance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.Balance.Name = "Balance"
            '
            'NoDetailsFormattingRule
            '
            Me.NoDetailsFormattingRule.Condition = "[DataSource.RowCount] > 0"
            Me.NoDetailsFormattingRule.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.NoDetailsFormattingRule.Name = "NoDetailsFormattingRule"
            '
            'PostPeriodGroupHeader
            '
            Me.PostPeriodGroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("PostPeriodCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.PostPeriodGroupHeader.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail
            Me.PostPeriodGroupHeader.HeightF = 0!
            Me.PostPeriodGroupHeader.Name = "PostPeriodGroupHeader"
            '
            'PostPeriodGroupFooter
            '
            Me.PostPeriodGroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelAccountEndingBalance, Me.XrLabel2, Me.XrLabel9, Me.XrLabel17, Me.XrLabel18})
            Me.PostPeriodGroupFooter.HeightF = 58.95834!
            Me.PostPeriodGroupFooter.Name = "PostPeriodGroupFooter"
            '
            'LabelAccountEndingBalance
            '
            Me.LabelAccountEndingBalance.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.LabelAccountEndingBalance.BackColor = System.Drawing.Color.Transparent
            Me.LabelAccountEndingBalance.BorderColor = System.Drawing.Color.Black
            Me.LabelAccountEndingBalance.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelAccountEndingBalance.BorderWidth = 1.0!
            Me.LabelAccountEndingBalance.CanGrow = False
            Me.LabelAccountEndingBalance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelAccountEndingBalance.ForeColor = System.Drawing.Color.Black
            Me.LabelAccountEndingBalance.LocationFloat = New DevExpress.Utils.PointFloat(587.5168!, 29.95834!)
            Me.LabelAccountEndingBalance.Name = "LabelAccountEndingBalance"
            Me.LabelAccountEndingBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelAccountEndingBalance.SizeF = New System.Drawing.SizeF(152.4832!, 19.0!)
            Me.LabelAccountEndingBalance.StylePriority.UseFont = False
            Me.LabelAccountEndingBalance.StylePriority.UseTextAlignment = False
            Me.LabelAccountEndingBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel2
            '
            Me.XrLabel2.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel2.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel2.BorderColor = System.Drawing.Color.Black
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel2.BorderWidth = 1.0!
            Me.XrLabel2.CanGrow = False
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(200.0169!, 29.95834!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(387.4999!, 19.0!)
            Me.XrLabel2.StylePriority.UseBorders = False
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "Account Ending Balance [AccountCode]:"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel9
            '
            Me.XrLabel9.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount")})
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(652.1203!, 0!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(97.8797!, 19.0!)
            Me.XrLabel9.StylePriority.UseBorders = False
            Me.XrLabel9.StylePriority.UseFont = False
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:c}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel9.Summary = XrSummary2
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel17
            '
            Me.XrLabel17.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.XrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount")})
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(555.2454!, 0!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(96.87494!, 19.0!)
            Me.XrLabel17.StylePriority.UseBorders = False
            Me.XrLabel17.StylePriority.UseFont = False
            Me.XrLabel17.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel17.Summary = XrSummary3
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel18
            '
            Me.XrLabel18.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(321.895!, 0!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(233.3503!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            Me.XrLabel18.StylePriority.UseTextAlignment = False
            Me.XrLabel18.Text = "[PostPeriodCode] Period Change Total:"
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'NoTransactions
            '
            Me.NoTransactions.Name = "NoTransactions"
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport)
            '
            'XrLabel4
            '
            Me.XrLabel4.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount")})
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(652.1203!, 48.65459!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(97.8797!, 19.0!)
            Me.XrLabel4.StylePriority.UseBorders = False
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:c}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel4.Summary = XrSummary4
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel5, Me.XrLine1, Me.XrLabel4})
            Me.ReportFooter.HeightF = 77.65459!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabel3
            '
            Me.XrLabel3.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(342.7083!, 48.65459!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(212.537!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Report Total:"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel5
            '
            Me.XrLabel5.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount")})
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(555.2454!, 48.65459!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(96.87494!, 19.0!)
            Me.XrLabel5.StylePriority.UseBorders = False
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:c}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel5.Summary = XrSummary5
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel5.WordWrap = False
            '
            'XrLine1
            '
            Me.XrLine1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Gray
            Me.XrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 29.6546!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 6.49999!)
            Me.XrLine1.StylePriority.UseBorderColor = False
            Me.XrLine1.StylePriority.UseBorderWidth = False
            Me.XrLine1.StylePriority.UseForeColor = False
            '
            'GLDetailByAccountReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.AccountGroupHeader, Me.AccountGroupFooter, Me.AccountDetailGroupHeader, Me.AccountDetailGroupFooter, Me.PostPeriodGroupHeader, Me.PostPeriodGroupFooter, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Balance})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource1})
            Me.DataSource = Me.BindingSource1
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1, Me.NoDetailsFormattingRule, Me.NoTransactions, Me.LastGroup})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 59)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.Version = "20.1"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents Label_GroupCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents AccountGroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelAccountBeginningBalance As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents AccountGroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents AccountDetailGroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelCodeAndDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents AccountDetailGroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents Balance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents NoDetailsFormattingRule As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents PostPeriodGroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents PostPeriodGroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents NoTransactions As DevExpress.XtraReports.UI.FormattingRule
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelAccountEndingBalance As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LastGroup As DevExpress.XtraReports.UI.FormattingRule
        Private WithEvents Line26 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
