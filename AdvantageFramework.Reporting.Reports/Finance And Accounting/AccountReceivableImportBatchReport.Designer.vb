Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountReceivableImportBatchReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary14 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_DueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineDetail_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelDetail_AmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CountyAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CityAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StateAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLCity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLCounty = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLState = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CountyLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CityLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientPO = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_COSAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OffsetAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ARAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLCOS = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLOffset = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLSales = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAR = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Type = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesClass = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ProductCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DivisionCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ARLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OffsetLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_COSLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_AdvantageInvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineReportFooter_2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_DueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Office = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ClientPO = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_RecType = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_SCcmpn = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_SumCity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumCounty = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumState = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumCOS = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumOffset = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumSaleAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumInvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeaderPostPeriodCode = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeader_PostPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_PostPeriodCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterPostPeriodCode = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooter_Subtotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumInvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumSaleAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumOffsetAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumCOSAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumStateAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumCountyAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_SumCityAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.PostPeriodSubtotal = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_DueDate, Me.LineDetail_Bottom, Me.LabelDetail_AmountLabel, Me.LabelDetail_AccountLabel, Me.LabelDetail_InvoiceAmount, Me.LabelDetail_CountyAmount, Me.LabelDetail_CityAmount, Me.LabelDetail_StateAmount, Me.LabelDetail_GLCity, Me.LabelDetail_GLCounty, Me.LabelDetail_GLState, Me.LabelDetail_StateLabel, Me.LabelDetail_CountyLabel, Me.LabelDetail_CityLabel, Me.LabelDetail_OfficeCode, Me.LabelDetail_Description, Me.LabelDetail_ClientPO, Me.LabelDetail_InvoiceDate, Me.LabelDetail_COSAmount, Me.LabelDetail_OffsetAmount, Me.LabelDetail_SalesAmount, Me.LabelDetail_ARAmount, Me.LabelDetail_GLCOS, Me.LabelDetail_GLOffset, Me.LabelDetail_GLSales, Me.LabelDetail_GLAR, Me.LabelDetail_Type, Me.LabelDetail_SalesClass, Me.LabelDetail_ProductCode, Me.LabelDetail_DivisionCode, Me.LabelDetail_ClientCode, Me.LabelDetail_InvoiceNumber, Me.LabelDetail_ARLabel, Me.LabelDetail_SalesLabel, Me.LabelDetail_OffsetLabel, Me.LabelDetail_COSLabel})
            Me.Detail.HeightF = 94.24998!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DueDate
            '
            Me.LabelDetail_DueDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueDate", "{0:d}")})
            Me.LabelDetail_DueDate.LocationFloat = New DevExpress.Utils.PointFloat(907.6667!, 0.0!)
            Me.LabelDetail_DueDate.Name = "LabelDetail_DueDate"
            Me.LabelDetail_DueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DueDate.SizeF = New System.Drawing.SizeF(64.58337!, 23.0!)
            Me.LabelDetail_DueDate.Text = "LabelDetail_DueDate"
            '
            'LineDetail_Bottom
            '
            Me.LineDetail_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineDetail_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetail_Bottom.BorderWidth = 0.0!
            Me.LineDetail_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineDetail_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 92.16662!)
            Me.LineDetail_Bottom.Name = "LineDetail_Bottom"
            Me.LineDetail_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.LineDetail_Bottom.StylePriority.UseBorderColor = False
            Me.LineDetail_Bottom.StylePriority.UseBorderWidth = False
            Me.LineDetail_Bottom.StylePriority.UseForeColor = False
            '
            'LabelDetail_AmountLabel
            '
            Me.LabelDetail_AmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AmountLabel.CanGrow = False
            Me.LabelDetail_AmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(95.95804!, 69.16663!)
            Me.LabelDetail_AmountLabel.Name = "LabelDetail_AmountLabel"
            Me.LabelDetail_AmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AmountLabel.SizeF = New System.Drawing.SizeF(65.62502!, 19.0!)
            Me.LabelDetail_AmountLabel.StylePriority.UseBorders = False
            Me.LabelDetail_AmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AmountLabel.Text = "Amount:"
            Me.LabelDetail_AmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_AccountLabel
            '
            Me.LabelDetail_AccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AccountLabel.CanGrow = False
            Me.LabelDetail_AccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(95.95804!, 46.16664!)
            Me.LabelDetail_AccountLabel.Name = "LabelDetail_AccountLabel"
            Me.LabelDetail_AccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AccountLabel.SizeF = New System.Drawing.SizeF(65.62502!, 19.0!)
            Me.LabelDetail_AccountLabel.StylePriority.UseBorders = False
            Me.LabelDetail_AccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AccountLabel.Text = "Account:"
            Me.LabelDetail_AccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceAmount
            '
            Me.LabelDetail_InvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount", "{0:c2}")})
            Me.LabelDetail_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(401.0418!, 0.0!)
            Me.LabelDetail_InvoiceAmount.Name = "LabelDetail_InvoiceAmount"
            Me.LabelDetail_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_InvoiceAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceAmount.Text = "LabelDetail_InvoiceAmount"
            Me.LabelDetail_InvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_CountyAmount
            '
            Me.LabelDetail_CountyAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CountyAmount")})
            Me.LabelDetail_CountyAmount.LocationFloat = New DevExpress.Utils.PointFloat(746.5486!, 69.16662!)
            Me.LabelDetail_CountyAmount.Name = "LabelDetail_CountyAmount"
            Me.LabelDetail_CountyAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CountyAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_CountyAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CountyAmount.Text = "LabelDetail_CountyAmount"
            Me.LabelDetail_CountyAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_CityAmount
            '
            Me.LabelDetail_CityAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CityAmount")})
            Me.LabelDetail_CityAmount.LocationFloat = New DevExpress.Utils.PointFloat(863.5418!, 69.16662!)
            Me.LabelDetail_CityAmount.Name = "LabelDetail_CityAmount"
            Me.LabelDetail_CityAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CityAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_CityAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CityAmount.Text = "LabelDetail_CityAmount"
            Me.LabelDetail_CityAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_StateAmount
            '
            Me.LabelDetail_StateAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StateAmount")})
            Me.LabelDetail_StateAmount.LocationFloat = New DevExpress.Utils.PointFloat(629.5555!, 69.16662!)
            Me.LabelDetail_StateAmount.Name = "LabelDetail_StateAmount"
            Me.LabelDetail_StateAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_StateAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_StateAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_StateAmount.Text = "LabelDetail_StateAmount"
            Me.LabelDetail_StateAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLCity
            '
            Me.LabelDetail_GLCity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeCity")})
            Me.LabelDetail_GLCity.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 46.1666!)
            Me.LabelDetail_GLCity.Name = "LabelDetail_GLCity"
            Me.LabelDetail_GLCity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLCity.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLCity.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLCity.Text = "LabelDetail_GLCity"
            Me.LabelDetail_GLCity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLCounty
            '
            Me.LabelDetail_GLCounty.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeCounty")})
            Me.LabelDetail_GLCounty.LocationFloat = New DevExpress.Utils.PointFloat(746.5486!, 46.1666!)
            Me.LabelDetail_GLCounty.Name = "LabelDetail_GLCounty"
            Me.LabelDetail_GLCounty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLCounty.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLCounty.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLCounty.Text = "LabelDetail_GLCounty"
            Me.LabelDetail_GLCounty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLState
            '
            Me.LabelDetail_GLState.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeState")})
            Me.LabelDetail_GLState.LocationFloat = New DevExpress.Utils.PointFloat(629.5555!, 46.1666!)
            Me.LabelDetail_GLState.Name = "LabelDetail_GLState"
            Me.LabelDetail_GLState.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLState.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLState.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLState.Text = "LabelDetail_GLState"
            Me.LabelDetail_GLState.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_StateLabel
            '
            Me.LabelDetail_StateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_StateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_StateLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_StateLabel.BorderWidth = 1.0!
            Me.LabelDetail_StateLabel.CanGrow = False
            Me.LabelDetail_StateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_StateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_StateLabel.LocationFloat = New DevExpress.Utils.PointFloat(629.5555!, 27.16661!)
            Me.LabelDetail_StateLabel.Name = "LabelDetail_StateLabel"
            Me.LabelDetail_StateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_StateLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_StateLabel.StylePriority.UseBorders = False
            Me.LabelDetail_StateLabel.StylePriority.UseFont = False
            Me.LabelDetail_StateLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_StateLabel.Text = "State"
            Me.LabelDetail_StateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CountyLabel
            '
            Me.LabelDetail_CountyLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CountyLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CountyLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_CountyLabel.BorderWidth = 1.0!
            Me.LabelDetail_CountyLabel.CanGrow = False
            Me.LabelDetail_CountyLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CountyLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CountyLabel.LocationFloat = New DevExpress.Utils.PointFloat(746.5486!, 27.16661!)
            Me.LabelDetail_CountyLabel.Name = "LabelDetail_CountyLabel"
            Me.LabelDetail_CountyLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CountyLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_CountyLabel.StylePriority.UseBorders = False
            Me.LabelDetail_CountyLabel.StylePriority.UseFont = False
            Me.LabelDetail_CountyLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CountyLabel.Text = "County"
            Me.LabelDetail_CountyLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CityLabel
            '
            Me.LabelDetail_CityLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CityLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CityLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_CityLabel.BorderWidth = 1.0!
            Me.LabelDetail_CityLabel.CanGrow = False
            Me.LabelDetail_CityLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CityLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CityLabel.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 27.16661!)
            Me.LabelDetail_CityLabel.Name = "LabelDetail_CityLabel"
            Me.LabelDetail_CityLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CityLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_CityLabel.StylePriority.UseBorders = False
            Me.LabelDetail_CityLabel.StylePriority.UseFont = False
            Me.LabelDetail_CityLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CityLabel.Text = "City"
            Me.LabelDetail_CityLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OfficeCode
            '
            Me.LabelDetail_OfficeCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeCode")})
            Me.LabelDetail_OfficeCode.LocationFloat = New DevExpress.Utils.PointFloat(278.5762!, 0.0!)
            Me.LabelDetail_OfficeCode.Name = "LabelDetail_OfficeCode"
            Me.LabelDetail_OfficeCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_OfficeCode.SizeF = New System.Drawing.SizeF(57.29147!, 23.0!)
            Me.LabelDetail_OfficeCode.Text = "LabelDetail_OfficeCode"
            '
            'LabelDetail_Description
            '
            Me.LabelDetail_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.LabelDetail_Description.LocationFloat = New DevExpress.Utils.PointFloat(505.0418!, 0.0!)
            Me.LabelDetail_Description.Name = "LabelDetail_Description"
            Me.LabelDetail_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Description.SizeF = New System.Drawing.SizeF(220.3752!, 23.0!)
            Me.LabelDetail_Description.Text = "LabelDetail_Description"
            '
            'LabelDetail_ClientPO
            '
            Me.LabelDetail_ClientPO.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductPONumber")})
            Me.LabelDetail_ClientPO.LocationFloat = New DevExpress.Utils.PointFloat(769.5415!, 0.0!)
            Me.LabelDetail_ClientPO.Name = "LabelDetail_ClientPO"
            Me.LabelDetail_ClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ClientPO.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_ClientPO.Text = "LabelDetail_ClientPO"
            '
            'LabelDetail_InvoiceDate
            '
            Me.LabelDetail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(335.8677!, 0.0!)
            Me.LabelDetail_InvoiceDate.Name = "LabelDetail_InvoiceDate"
            Me.LabelDetail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDate.SizeF = New System.Drawing.SizeF(64.58334!, 23.0!)
            '
            'LabelDetail_COSAmount
            '
            Me.LabelDetail_COSAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostOfSalesAmount")})
            Me.LabelDetail_COSAmount.LocationFloat = New DevExpress.Utils.PointFloat(395.5693!, 69.16662!)
            Me.LabelDetail_COSAmount.Name = "LabelDetail_COSAmount"
            Me.LabelDetail_COSAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_COSAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_COSAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_COSAmount.Text = "LabelDetail_COSAmount"
            Me.LabelDetail_COSAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_OffsetAmount
            '
            Me.LabelDetail_OffsetAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OffsetAmount")})
            Me.LabelDetail_OffsetAmount.LocationFloat = New DevExpress.Utils.PointFloat(512.5624!, 69.16662!)
            Me.LabelDetail_OffsetAmount.Name = "LabelDetail_OffsetAmount"
            Me.LabelDetail_OffsetAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_OffsetAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_OffsetAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OffsetAmount.Text = "LabelDetail_OffsetAmount"
            Me.LabelDetail_OffsetAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_SalesAmount
            '
            Me.LabelDetail_SalesAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleAmount")})
            Me.LabelDetail_SalesAmount.LocationFloat = New DevExpress.Utils.PointFloat(278.5761!, 69.16662!)
            Me.LabelDetail_SalesAmount.Name = "LabelDetail_SalesAmount"
            Me.LabelDetail_SalesAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_SalesAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_SalesAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_SalesAmount.Text = "LabelDetail_SalesAmount"
            Me.LabelDetail_SalesAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_ARAmount
            '
            Me.LabelDetail_ARAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.LabelDetail_ARAmount.LocationFloat = New DevExpress.Utils.PointFloat(161.5831!, 69.16662!)
            Me.LabelDetail_ARAmount.Name = "LabelDetail_ARAmount"
            Me.LabelDetail_ARAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ARAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_ARAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ARAmount.Text = "LabelDetail_ARAmount"
            Me.LabelDetail_ARAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLCOS
            '
            Me.LabelDetail_GLCOS.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostOfSalesGLACode")})
            Me.LabelDetail_GLCOS.LocationFloat = New DevExpress.Utils.PointFloat(395.5693!, 46.1666!)
            Me.LabelDetail_GLCOS.Name = "LabelDetail_GLCOS"
            Me.LabelDetail_GLCOS.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLCOS.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLCOS.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLCOS.Text = "LabelDetail_GLCOS"
            Me.LabelDetail_GLCOS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLOffset
            '
            Me.LabelDetail_GLOffset.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeOffset")})
            Me.LabelDetail_GLOffset.LocationFloat = New DevExpress.Utils.PointFloat(512.5624!, 46.16663!)
            Me.LabelDetail_GLOffset.Name = "LabelDetail_GLOffset"
            Me.LabelDetail_GLOffset.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLOffset.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLOffset.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLOffset.Text = "LabelDetail_GLOffset"
            Me.LabelDetail_GLOffset.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLSales
            '
            Me.LabelDetail_GLSales.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeSales")})
            Me.LabelDetail_GLSales.LocationFloat = New DevExpress.Utils.PointFloat(278.5761!, 46.16663!)
            Me.LabelDetail_GLSales.Name = "LabelDetail_GLSales"
            Me.LabelDetail_GLSales.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLSales.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLSales.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLSales.Text = "LabelDetail_GLSales"
            Me.LabelDetail_GLSales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLAR
            '
            Me.LabelDetail_GLAR.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeAR")})
            Me.LabelDetail_GLAR.LocationFloat = New DevExpress.Utils.PointFloat(161.5831!, 46.16663!)
            Me.LabelDetail_GLAR.Name = "LabelDetail_GLAR"
            Me.LabelDetail_GLAR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLAR.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLAR.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLAR.Text = "LabelDetail_GLAR"
            Me.LabelDetail_GLAR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Type
            '
            Me.LabelDetail_Type.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RecordType")})
            Me.LabelDetail_Type.LocationFloat = New DevExpress.Utils.PointFloat(869.5417!, 0.0!)
            Me.LabelDetail_Type.Name = "LabelDetail_Type"
            Me.LabelDetail_Type.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Type.SizeF = New System.Drawing.SizeF(28.125!, 23.0!)
            Me.LabelDetail_Type.Text = "LabelDetail_Type"
            '
            'LabelDetail_SalesClass
            '
            Me.LabelDetail_SalesClass.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassCode")})
            Me.LabelDetail_SalesClass.LocationFloat = New DevExpress.Utils.PointFloat(725.417!, 0.0!)
            Me.LabelDetail_SalesClass.Name = "LabelDetail_SalesClass"
            Me.LabelDetail_SalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_SalesClass.SizeF = New System.Drawing.SizeF(38.54144!, 23.0!)
            Me.LabelDetail_SalesClass.Text = "LabelDetail_SalesClass"
            '
            'LabelDetail_ProductCode
            '
            Me.LabelDetail_ProductCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.LabelDetail_ProductCode.LocationFloat = New DevExpress.Utils.PointFloat(218.8746!, 0.0!)
            Me.LabelDetail_ProductCode.Name = "LabelDetail_ProductCode"
            Me.LabelDetail_ProductCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ProductCode.SizeF = New System.Drawing.SizeF(57.2915!, 23.0!)
            Me.LabelDetail_ProductCode.Text = "LabelDetail_ProductCode"
            '
            'LabelDetail_DivisionCode
            '
            Me.LabelDetail_DivisionCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.LabelDetail_DivisionCode.LocationFloat = New DevExpress.Utils.PointFloat(161.5831!, 0.0!)
            Me.LabelDetail_DivisionCode.Name = "LabelDetail_DivisionCode"
            Me.LabelDetail_DivisionCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DivisionCode.SizeF = New System.Drawing.SizeF(57.2915!, 23.0!)
            Me.LabelDetail_DivisionCode.Text = "LabelDetail_DivisionCode"
            '
            'LabelDetail_ClientCode
            '
            Me.LabelDetail_ClientCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.LabelDetail_ClientCode.LocationFloat = New DevExpress.Utils.PointFloat(103.7498!, 0.0!)
            Me.LabelDetail_ClientCode.Name = "LabelDetail_ClientCode"
            Me.LabelDetail_ClientCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ClientCode.SizeF = New System.Drawing.SizeF(57.2915!, 23.0!)
            Me.LabelDetail_ClientCode.Text = "LabelDetail_ClientCode"
            '
            'LabelDetail_InvoiceNumber
            '
            Me.LabelDetail_InvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.LabelDetail_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelDetail_InvoiceNumber.Name = "LabelDetail_InvoiceNumber"
            Me.LabelDetail_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceNumber.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_InvoiceNumber.Text = "LabelDetail_InvoiceNumber"
            '
            'LabelDetail_ARLabel
            '
            Me.LabelDetail_ARLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ARLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ARLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_ARLabel.BorderWidth = 1.0!
            Me.LabelDetail_ARLabel.CanGrow = False
            Me.LabelDetail_ARLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ARLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ARLabel.LocationFloat = New DevExpress.Utils.PointFloat(161.583!, 27.16661!)
            Me.LabelDetail_ARLabel.Name = "LabelDetail_ARLabel"
            Me.LabelDetail_ARLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ARLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_ARLabel.StylePriority.UseBorders = False
            Me.LabelDetail_ARLabel.StylePriority.UseFont = False
            Me.LabelDetail_ARLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ARLabel.Text = "A/R"
            Me.LabelDetail_ARLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_SalesLabel
            '
            Me.LabelDetail_SalesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_SalesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_SalesLabel.BorderWidth = 1.0!
            Me.LabelDetail_SalesLabel.CanGrow = False
            Me.LabelDetail_SalesLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_SalesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesLabel.LocationFloat = New DevExpress.Utils.PointFloat(278.5761!, 27.16661!)
            Me.LabelDetail_SalesLabel.Name = "LabelDetail_SalesLabel"
            Me.LabelDetail_SalesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_SalesLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_SalesLabel.StylePriority.UseBorders = False
            Me.LabelDetail_SalesLabel.StylePriority.UseFont = False
            Me.LabelDetail_SalesLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_SalesLabel.Text = "Sales"
            Me.LabelDetail_SalesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OffsetLabel
            '
            Me.LabelDetail_OffsetLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OffsetLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OffsetLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_OffsetLabel.BorderWidth = 1.0!
            Me.LabelDetail_OffsetLabel.CanGrow = False
            Me.LabelDetail_OffsetLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OffsetLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OffsetLabel.LocationFloat = New DevExpress.Utils.PointFloat(512.5624!, 27.16661!)
            Me.LabelDetail_OffsetLabel.Name = "LabelDetail_OffsetLabel"
            Me.LabelDetail_OffsetLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OffsetLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_OffsetLabel.StylePriority.UseBorders = False
            Me.LabelDetail_OffsetLabel.StylePriority.UseFont = False
            Me.LabelDetail_OffsetLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OffsetLabel.Text = "Offset"
            Me.LabelDetail_OffsetLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_COSLabel
            '
            Me.LabelDetail_COSLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_COSLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_COSLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_COSLabel.BorderWidth = 1.0!
            Me.LabelDetail_COSLabel.CanGrow = False
            Me.LabelDetail_COSLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_COSLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_COSLabel.LocationFloat = New DevExpress.Utils.PointFloat(395.5693!, 27.16661!)
            Me.LabelDetail_COSLabel.Name = "LabelDetail_COSLabel"
            Me.LabelDetail_COSLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_COSLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_COSLabel.StylePriority.UseBorders = False
            Me.LabelDetail_COSLabel.StylePriority.UseFont = False
            Me.LabelDetail_COSLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_COSLabel.Text = "Cost of Sales"
            Me.LabelDetail_COSLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_AdvantageInvoiceNumber
            '
            Me.LabelPageHeader_AdvantageInvoiceNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_AdvantageInvoiceNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_AdvantageInvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_AdvantageInvoiceNumber.BorderWidth = 1.0!
            Me.LabelPageHeader_AdvantageInvoiceNumber.CanGrow = False
            Me.LabelPageHeader_AdvantageInvoiceNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_AdvantageInvoiceNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_AdvantageInvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 72.16676!)
            Me.LabelPageHeader_AdvantageInvoiceNumber.Name = "LabelPageHeader_AdvantageInvoiceNumber"
            Me.LabelPageHeader_AdvantageInvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_AdvantageInvoiceNumber.SizeF = New System.Drawing.SizeF(99.99991!, 32.0!)
            Me.LabelPageHeader_AdvantageInvoiceNumber.StylePriority.UseFont = False
            Me.LabelPageHeader_AdvantageInvoiceNumber.Text = "Advantage Invoice Number"
            Me.LabelPageHeader_AdvantageInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_1
            '
            Me.LineReportFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_1.BorderWidth = 0.0!
            Me.LineReportFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
            Me.LineReportFooter_1.Name = "LineReportFooter_1"
            Me.LineReportFooter_1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_1.StylePriority.UseBorderColor = False
            Me.LineReportFooter_1.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_1.StylePriority.UseForeColor = False
            '
            'LineReportFooter_2
            '
            Me.LineReportFooter_2.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_2.BorderWidth = 0.0!
            Me.LineReportFooter_2.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LineReportFooter_2.Name = "LineReportFooter_2"
            Me.LineReportFooter_2.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_2.StylePriority.UseBorderColor = False
            Me.LineReportFooter_2.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_2.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(21.87498!, 3.999964!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(111.4584!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Grand Totals:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_DueDate, Me.LabelPageHeader_Amount, Me.LabelPageHeader_Office, Me.LabelPageHeader_Product, Me.LabelPageHeader_Division, Me.LabelPageHeader_Client, Me.LabelPageHeader_InvoiceDate, Me.LabelPageHeader_Description, Me.LabelPageHeader_ClientPO, Me.LinePageHeader_Bottom2, Me.LabelPageHeader_RecType, Me.LabelPageHeader_SCcmpn, Me.LabelPageHeader_Agency, Me.LinePageHeader_Bottom, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle, Me.LabelPageHeader_AdvantageInvoiceNumber})
            Me.PageHeader.HeightF = 106.1667!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_DueDate
            '
            Me.LabelPageHeader_DueDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_DueDate.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_DueDate.BorderWidth = 1.0!
            Me.LabelPageHeader_DueDate.CanGrow = False
            Me.LabelPageHeader_DueDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_DueDate.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DueDate.LocationFloat = New DevExpress.Utils.PointFloat(907.6666!, 85.16661!)
            Me.LabelPageHeader_DueDate.Name = "LabelPageHeader_DueDate"
            Me.LabelPageHeader_DueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_DueDate.SizeF = New System.Drawing.SizeF(64.58334!, 19.0!)
            Me.LabelPageHeader_DueDate.StylePriority.UseFont = False
            Me.LabelPageHeader_DueDate.Text = "Due Date"
            Me.LabelPageHeader_DueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Amount
            '
            Me.LabelPageHeader_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Amount.BorderWidth = 1.0!
            Me.LabelPageHeader_Amount.CanGrow = False
            Me.LabelPageHeader_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Amount.LocationFloat = New DevExpress.Utils.PointFloat(401.0418!, 85.16668!)
            Me.LabelPageHeader_Amount.Name = "LabelPageHeader_Amount"
            Me.LabelPageHeader_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Amount.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelPageHeader_Amount.StylePriority.UseFont = False
            Me.LabelPageHeader_Amount.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Amount.Text = "Amount"
            Me.LabelPageHeader_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Office
            '
            Me.LabelPageHeader_Office.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Office.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Office.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Office.BorderWidth = 1.0!
            Me.LabelPageHeader_Office.CanGrow = False
            Me.LabelPageHeader_Office.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Office.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Office.LocationFloat = New DevExpress.Utils.PointFloat(278.5762!, 85.16668!)
            Me.LabelPageHeader_Office.Name = "LabelPageHeader_Office"
            Me.LabelPageHeader_Office.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Office.SizeF = New System.Drawing.SizeF(57.29147!, 18.99998!)
            Me.LabelPageHeader_Office.StylePriority.UseFont = False
            Me.LabelPageHeader_Office.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Office.Text = "Office"
            Me.LabelPageHeader_Office.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Product
            '
            Me.LabelPageHeader_Product.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Product.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Product.BorderWidth = 1.0!
            Me.LabelPageHeader_Product.CanGrow = False
            Me.LabelPageHeader_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(218.8746!, 85.16668!)
            Me.LabelPageHeader_Product.Name = "LabelPageHeader_Product"
            Me.LabelPageHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Product.SizeF = New System.Drawing.SizeF(57.29147!, 18.99998!)
            Me.LabelPageHeader_Product.StylePriority.UseFont = False
            Me.LabelPageHeader_Product.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Product.Text = "Product"
            Me.LabelPageHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Division
            '
            Me.LabelPageHeader_Division.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Division.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Division.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Division.BorderWidth = 1.0!
            Me.LabelPageHeader_Division.CanGrow = False
            Me.LabelPageHeader_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Division.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Division.LocationFloat = New DevExpress.Utils.PointFloat(161.5831!, 85.16668!)
            Me.LabelPageHeader_Division.Name = "LabelPageHeader_Division"
            Me.LabelPageHeader_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Division.SizeF = New System.Drawing.SizeF(57.2915!, 18.99998!)
            Me.LabelPageHeader_Division.StylePriority.UseFont = False
            Me.LabelPageHeader_Division.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Division.Text = "Division"
            Me.LabelPageHeader_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Client
            '
            Me.LabelPageHeader_Client.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Client.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Client.BorderWidth = 1.0!
            Me.LabelPageHeader_Client.CanGrow = False
            Me.LabelPageHeader_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Client.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Client.LocationFloat = New DevExpress.Utils.PointFloat(103.7498!, 85.16668!)
            Me.LabelPageHeader_Client.Name = "LabelPageHeader_Client"
            Me.LabelPageHeader_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Client.SizeF = New System.Drawing.SizeF(57.29147!, 18.99998!)
            Me.LabelPageHeader_Client.StylePriority.UseFont = False
            Me.LabelPageHeader_Client.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Client.Text = "Client"
            Me.LabelPageHeader_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_InvoiceDate
            '
            Me.LabelPageHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_InvoiceDate.BorderWidth = 1.0!
            Me.LabelPageHeader_InvoiceDate.CanGrow = False
            Me.LabelPageHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(335.8677!, 85.16668!)
            Me.LabelPageHeader_InvoiceDate.Name = "LabelPageHeader_InvoiceDate"
            Me.LabelPageHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(64.58334!, 19.0!)
            Me.LabelPageHeader_InvoiceDate.StylePriority.UseFont = False
            Me.LabelPageHeader_InvoiceDate.Text = "Date"
            Me.LabelPageHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Description
            '
            Me.LabelPageHeader_Description.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Description.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Description.BorderWidth = 1.0!
            Me.LabelPageHeader_Description.CanGrow = False
            Me.LabelPageHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Description.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(505.0418!, 85.16664!)
            Me.LabelPageHeader_Description.Name = "LabelPageHeader_Description"
            Me.LabelPageHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Description.SizeF = New System.Drawing.SizeF(220.3751!, 19.0!)
            Me.LabelPageHeader_Description.StylePriority.UseFont = False
            Me.LabelPageHeader_Description.Text = "Description"
            Me.LabelPageHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ClientPO
            '
            Me.LabelPageHeader_ClientPO.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ClientPO.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ClientPO.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ClientPO.BorderWidth = 1.0!
            Me.LabelPageHeader_ClientPO.CanGrow = False
            Me.LabelPageHeader_ClientPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_ClientPO.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ClientPO.LocationFloat = New DevExpress.Utils.PointFloat(769.5415!, 85.16664!)
            Me.LabelPageHeader_ClientPO.Name = "LabelPageHeader_ClientPO"
            Me.LabelPageHeader_ClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ClientPO.SizeF = New System.Drawing.SizeF(100.0001!, 18.99998!)
            Me.LabelPageHeader_ClientPO.StylePriority.UseFont = False
            Me.LabelPageHeader_ClientPO.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ClientPO.Text = "Client PO"
            Me.LabelPageHeader_ClientPO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom2
            '
            Me.LinePageHeader_Bottom2.BorderColor = System.Drawing.Color.Black
            Me.LinePageHeader_Bottom2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom2.BorderWidth = 0.0!
            Me.LinePageHeader_Bottom2.ForeColor = System.Drawing.Color.Gray
            Me.LinePageHeader_Bottom2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 104.1667!)
            Me.LinePageHeader_Bottom2.Name = "LinePageHeader_Bottom2"
            Me.LinePageHeader_Bottom2.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.LinePageHeader_Bottom2.StylePriority.UseBorderColor = False
            Me.LinePageHeader_Bottom2.StylePriority.UseBorderWidth = False
            Me.LinePageHeader_Bottom2.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_RecType
            '
            Me.LabelPageHeader_RecType.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_RecType.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_RecType.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_RecType.BorderWidth = 1.0!
            Me.LabelPageHeader_RecType.CanGrow = False
            Me.LabelPageHeader_RecType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_RecType.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_RecType.LocationFloat = New DevExpress.Utils.PointFloat(869.5416!, 85.16664!)
            Me.LabelPageHeader_RecType.Name = "LabelPageHeader_RecType"
            Me.LabelPageHeader_RecType.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_RecType.SizeF = New System.Drawing.SizeF(28.12497!, 18.99998!)
            Me.LabelPageHeader_RecType.StylePriority.UseFont = False
            Me.LabelPageHeader_RecType.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_RecType.Text = "Type"
            Me.LabelPageHeader_RecType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_SCcmpn
            '
            Me.LabelPageHeader_SCcmpn.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_SCcmpn.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_SCcmpn.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_SCcmpn.BorderWidth = 1.0!
            Me.LabelPageHeader_SCcmpn.CanGrow = False
            Me.LabelPageHeader_SCcmpn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_SCcmpn.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_SCcmpn.LocationFloat = New DevExpress.Utils.PointFloat(725.4169!, 72.16676!)
            Me.LabelPageHeader_SCcmpn.Name = "LabelPageHeader_SCcmpn"
            Me.LabelPageHeader_SCcmpn.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_SCcmpn.SizeF = New System.Drawing.SizeF(38.5415!, 31.99999!)
            Me.LabelPageHeader_SCcmpn.StylePriority.UseFont = False
            Me.LabelPageHeader_SCcmpn.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_SCcmpn.Text = "Sales Class"
            Me.LabelPageHeader_SCcmpn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Accounts Receivable Import Batch Report"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.08337!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportCriteria.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 33.08335!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(501.0417!, 17.00001!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.Text = "For:"
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportTitle.CanGrow = False
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Accounts Receivable Import Batch Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_SumCity, Me.LabelReportFooter_SumCounty, Me.LabelReportFooter_SumState, Me.LabelReportFooter_SumCOS, Me.LabelReportFooter_SumOffset, Me.LabelReportFooter_SumSaleAmount, Me.LabelReportFooter_SumInvoiceAmount, Me.LineReportFooter_2, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_1})
            Me.ReportFooter.HeightF = 32.99997!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_SumCity
            '
            Me.LabelReportFooter_SumCity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CityAmount")})
            Me.LabelReportFooter_SumCity.LocationFloat = New DevExpress.Utils.PointFloat(863.5419!, 3.999964!)
            Me.LabelReportFooter_SumCity.Name = "LabelReportFooter_SumCity"
            Me.LabelReportFooter_SumCity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumCity.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelReportFooter_SumCity.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:c2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumCity.Summary = XrSummary1
            Me.LabelReportFooter_SumCity.Text = "XrLabel31"
            Me.LabelReportFooter_SumCity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumCounty
            '
            Me.LabelReportFooter_SumCounty.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CountyAmount")})
            Me.LabelReportFooter_SumCounty.LocationFloat = New DevExpress.Utils.PointFloat(746.5486!, 4.000028!)
            Me.LabelReportFooter_SumCounty.Name = "LabelReportFooter_SumCounty"
            Me.LabelReportFooter_SumCounty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumCounty.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelReportFooter_SumCounty.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:c2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumCounty.Summary = XrSummary2
            Me.LabelReportFooter_SumCounty.Text = "XrLabel32"
            Me.LabelReportFooter_SumCounty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumState
            '
            Me.LabelReportFooter_SumState.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StateAmount")})
            Me.LabelReportFooter_SumState.LocationFloat = New DevExpress.Utils.PointFloat(629.5554!, 4.000028!)
            Me.LabelReportFooter_SumState.Name = "LabelReportFooter_SumState"
            Me.LabelReportFooter_SumState.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumState.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelReportFooter_SumState.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumState.Summary = XrSummary3
            Me.LabelReportFooter_SumState.Text = "XrLabel30"
            Me.LabelReportFooter_SumState.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumCOS
            '
            Me.LabelReportFooter_SumCOS.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostOfSalesAmount")})
            Me.LabelReportFooter_SumCOS.LocationFloat = New DevExpress.Utils.PointFloat(395.5693!, 4.000028!)
            Me.LabelReportFooter_SumCOS.Name = "LabelReportFooter_SumCOS"
            Me.LabelReportFooter_SumCOS.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumCOS.SizeF = New System.Drawing.SizeF(99.99982!, 23.0!)
            Me.LabelReportFooter_SumCOS.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:c2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumCOS.Summary = XrSummary4
            Me.LabelReportFooter_SumCOS.Text = "XrLabel29"
            Me.LabelReportFooter_SumCOS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumOffset
            '
            Me.LabelReportFooter_SumOffset.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OffsetAmount")})
            Me.LabelReportFooter_SumOffset.LocationFloat = New DevExpress.Utils.PointFloat(512.5625!, 4.0!)
            Me.LabelReportFooter_SumOffset.Name = "LabelReportFooter_SumOffset"
            Me.LabelReportFooter_SumOffset.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumOffset.SizeF = New System.Drawing.SizeF(99.99988!, 23.0!)
            Me.LabelReportFooter_SumOffset.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:c2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumOffset.Summary = XrSummary5
            Me.LabelReportFooter_SumOffset.Text = "XrLabel28"
            Me.LabelReportFooter_SumOffset.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumSaleAmount
            '
            Me.LabelReportFooter_SumSaleAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleAmount")})
            Me.LabelReportFooter_SumSaleAmount.LocationFloat = New DevExpress.Utils.PointFloat(278.5762!, 3.999964!)
            Me.LabelReportFooter_SumSaleAmount.Name = "LabelReportFooter_SumSaleAmount"
            Me.LabelReportFooter_SumSaleAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumSaleAmount.SizeF = New System.Drawing.SizeF(99.99994!, 23.0!)
            Me.LabelReportFooter_SumSaleAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:c2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumSaleAmount.Summary = XrSummary6
            Me.LabelReportFooter_SumSaleAmount.Text = "XrLabel26"
            Me.LabelReportFooter_SumSaleAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumInvoiceAmount
            '
            Me.LabelReportFooter_SumInvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.LabelReportFooter_SumInvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(161.5831!, 3.999964!)
            Me.LabelReportFooter_SumInvoiceAmount.Name = "LabelReportFooter_SumInvoiceAmount"
            Me.LabelReportFooter_SumInvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumInvoiceAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelReportFooter_SumInvoiceAmount.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:c2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumInvoiceAmount.Summary = XrSummary7
            Me.LabelReportFooter_SumInvoiceAmount.Text = "XrLabel25"
            Me.LabelReportFooter_SumInvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083347!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LinePageFooter, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083347!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_Date
            '
            Me.LabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Date.BorderWidth = 1.0!
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 4.083379!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(234.9999!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.AccountReceivable)
            '
            'GroupHeaderPostPeriodCode
            '
            Me.GroupHeaderPostPeriodCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeader_PostPeriodLabel, Me.LabelGroupHeader_PostPeriodCode})
            Me.GroupHeaderPostPeriodCode.Expanded = False
            Me.GroupHeaderPostPeriodCode.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("PostPeriodCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderPostPeriodCode.HeightF = 19.0!
            Me.GroupHeaderPostPeriodCode.Name = "GroupHeaderPostPeriodCode"
            Me.GroupHeaderPostPeriodCode.Visible = False
            '
            'LabelGroupHeader_PostPeriodLabel
            '
            Me.LabelGroupHeader_PostPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_PostPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_PostPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_PostPeriodLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_PostPeriodLabel.CanGrow = False
            Me.LabelGroupHeader_PostPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeader_PostPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_PostPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0.0!)
            Me.LabelGroupHeader_PostPeriodLabel.Name = "LabelGroupHeader_PostPeriodLabel"
            Me.LabelGroupHeader_PostPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_PostPeriodLabel.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelGroupHeader_PostPeriodLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_PostPeriodLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_PostPeriodLabel.Text = "Post Period"
            Me.LabelGroupHeader_PostPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_PostPeriodCode
            '
            Me.LabelGroupHeader_PostPeriodCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelGroupHeader_PostPeriodCode.LocationFloat = New DevExpress.Utils.PointFloat(100.0001!, 0.0!)
            Me.LabelGroupHeader_PostPeriodCode.Name = "LabelGroupHeader_PostPeriodCode"
            Me.LabelGroupHeader_PostPeriodCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeader_PostPeriodCode.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeader_PostPeriodCode.Text = "LabelGroupHeader_PostPeriodCode"
            '
            'GroupFooterPostPeriodCode
            '
            Me.GroupFooterPostPeriodCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooter_Subtotal, Me.LabelGroupFooter_SumInvoiceAmount, Me.LabelGroupFooter_SumSaleAmount, Me.LabelGroupFooter_SumOffsetAmount, Me.LabelGroupFooter_SumCOSAmount, Me.LabelGroupFooter_SumStateAmount, Me.LabelGroupFooter_SumCountyAmount, Me.LabelGroupFooter_SumCityAmount})
            Me.GroupFooterPostPeriodCode.HeightF = 51.12508!
            Me.GroupFooterPostPeriodCode.Name = "GroupFooterPostPeriodCode"
            '
            'LabelGroupFooter_Subtotal
            '
            Me.LabelGroupFooter_Subtotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodSubtotal")})
            Me.LabelGroupFooter_Subtotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooter_Subtotal.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0.00006357829!)
            Me.LabelGroupFooter_Subtotal.Name = "LabelGroupFooter_Subtotal"
            Me.LabelGroupFooter_Subtotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_Subtotal.SizeF = New System.Drawing.SizeF(161.0412!, 23.0!)
            Me.LabelGroupFooter_Subtotal.StylePriority.UseFont = False
            Me.LabelGroupFooter_Subtotal.Text = "LabelGroupFooter_Subtotal"
            '
            'LabelGroupFooter_SumInvoiceAmount
            '
            Me.LabelGroupFooter_SumInvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.LabelGroupFooter_SumInvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(161.583!, 0.0!)
            Me.LabelGroupFooter_SumInvoiceAmount.Name = "LabelGroupFooter_SumInvoiceAmount"
            Me.LabelGroupFooter_SumInvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumInvoiceAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooter_SumInvoiceAmount.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:c2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumInvoiceAmount.Summary = XrSummary8
            Me.LabelGroupFooter_SumInvoiceAmount.Text = "XrLabel25"
            Me.LabelGroupFooter_SumInvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumSaleAmount
            '
            Me.LabelGroupFooter_SumSaleAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleAmount")})
            Me.LabelGroupFooter_SumSaleAmount.LocationFloat = New DevExpress.Utils.PointFloat(278.5761!, 0.0!)
            Me.LabelGroupFooter_SumSaleAmount.Name = "LabelGroupFooter_SumSaleAmount"
            Me.LabelGroupFooter_SumSaleAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumSaleAmount.SizeF = New System.Drawing.SizeF(99.99994!, 23.0!)
            Me.LabelGroupFooter_SumSaleAmount.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:c2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumSaleAmount.Summary = XrSummary9
            Me.LabelGroupFooter_SumSaleAmount.Text = "XrLabel26"
            Me.LabelGroupFooter_SumSaleAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumOffsetAmount
            '
            Me.LabelGroupFooter_SumOffsetAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OffsetAmount")})
            Me.LabelGroupFooter_SumOffsetAmount.LocationFloat = New DevExpress.Utils.PointFloat(512.5624!, 0.0!)
            Me.LabelGroupFooter_SumOffsetAmount.Name = "LabelGroupFooter_SumOffsetAmount"
            Me.LabelGroupFooter_SumOffsetAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumOffsetAmount.SizeF = New System.Drawing.SizeF(99.99988!, 23.0!)
            Me.LabelGroupFooter_SumOffsetAmount.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:c2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumOffsetAmount.Summary = XrSummary10
            Me.LabelGroupFooter_SumOffsetAmount.Text = "XrLabel28"
            Me.LabelGroupFooter_SumOffsetAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumCOSAmount
            '
            Me.LabelGroupFooter_SumCOSAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostOfSalesAmount")})
            Me.LabelGroupFooter_SumCOSAmount.LocationFloat = New DevExpress.Utils.PointFloat(395.5692!, 0.00006357829!)
            Me.LabelGroupFooter_SumCOSAmount.Name = "LabelGroupFooter_SumCOSAmount"
            Me.LabelGroupFooter_SumCOSAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumCOSAmount.SizeF = New System.Drawing.SizeF(99.99982!, 23.0!)
            Me.LabelGroupFooter_SumCOSAmount.StylePriority.UseTextAlignment = False
            XrSummary11.FormatString = "{0:c2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumCOSAmount.Summary = XrSummary11
            Me.LabelGroupFooter_SumCOSAmount.Text = "XrLabel29"
            Me.LabelGroupFooter_SumCOSAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumStateAmount
            '
            Me.LabelGroupFooter_SumStateAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StateAmount")})
            Me.LabelGroupFooter_SumStateAmount.LocationFloat = New DevExpress.Utils.PointFloat(629.5553!, 0.00006357829!)
            Me.LabelGroupFooter_SumStateAmount.Name = "LabelGroupFooter_SumStateAmount"
            Me.LabelGroupFooter_SumStateAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumStateAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooter_SumStateAmount.StylePriority.UseTextAlignment = False
            XrSummary12.FormatString = "{0:c2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumStateAmount.Summary = XrSummary12
            Me.LabelGroupFooter_SumStateAmount.Text = "XrLabel30"
            Me.LabelGroupFooter_SumStateAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumCountyAmount
            '
            Me.LabelGroupFooter_SumCountyAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CountyAmount")})
            Me.LabelGroupFooter_SumCountyAmount.LocationFloat = New DevExpress.Utils.PointFloat(746.5485!, 0.00006357829!)
            Me.LabelGroupFooter_SumCountyAmount.Name = "LabelGroupFooter_SumCountyAmount"
            Me.LabelGroupFooter_SumCountyAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumCountyAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooter_SumCountyAmount.StylePriority.UseTextAlignment = False
            XrSummary13.FormatString = "{0:c2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumCountyAmount.Summary = XrSummary13
            Me.LabelGroupFooter_SumCountyAmount.Text = "XrLabel32"
            Me.LabelGroupFooter_SumCountyAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_SumCityAmount
            '
            Me.LabelGroupFooter_SumCityAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CityAmount")})
            Me.LabelGroupFooter_SumCityAmount.LocationFloat = New DevExpress.Utils.PointFloat(863.5418!, 0.0!)
            Me.LabelGroupFooter_SumCityAmount.Name = "LabelGroupFooter_SumCityAmount"
            Me.LabelGroupFooter_SumCityAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_SumCityAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooter_SumCityAmount.StylePriority.UseTextAlignment = False
            XrSummary14.FormatString = "{0:c2}"
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_SumCityAmount.Summary = XrSummary14
            Me.LabelGroupFooter_SumCityAmount.Text = "XrLabel31"
            Me.LabelGroupFooter_SumCityAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PostPeriodSubtotal
            '
            Me.PostPeriodSubtotal.Expression = "[PostPeriodCode] + ' Total:'"
            Me.PostPeriodSubtotal.Name = "PostPeriodSubtotal"
            '
            'AccountReceivableImportBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.GroupHeaderPostPeriodCode, Me.GroupFooterPostPeriodCode})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.PostPeriodSubtotal})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_AdvantageInvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineReportFooter_1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ProductCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DivisionCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ClientCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Type As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_SalesClass As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_SCcmpn As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_COSAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_OffsetAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_SalesAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ARAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLCOS As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLOffset As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLSales As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLAR As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_COSLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_SalesLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ARLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_RecType As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumCOS As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumOffset As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumSaleAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumInvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Bottom2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CountyAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CityAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_StateAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLCity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLCounty As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLState As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_StateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CountyLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CityLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_OfficeCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ClientPO As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OffsetLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Office As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Product As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Division As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Client As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ClientPO As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumCity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumCounty As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumState As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineDetail_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_DueDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DueDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderPostPeriodCode As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeader_PostPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupHeader_PostPeriodCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterPostPeriodCode As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelGroupFooter_Subtotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumInvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumSaleAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumOffsetAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumCOSAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumStateAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumCountyAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_SumCityAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PostPeriodSubtotal As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
