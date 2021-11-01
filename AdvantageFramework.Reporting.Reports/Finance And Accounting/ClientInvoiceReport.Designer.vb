Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientInvoiceReport
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
			Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
			Me.LineDetail_Break = New DevExpress.XtraReports.UI.XRLine()
			Me.LabelPageHeader_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_DueDate = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_InvoiceSequence = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_InvoiceCategory = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
			Me.LabelPageHeader_DateTo = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_DateFrom = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_Client = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_DateToLabel = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_DateFromLabel = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
			Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
			Me.LabelPageHeader_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
			Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
			Me.LabelPageHeader_BalanceDue = New DevExpress.XtraReports.UI.XRLabel()
			Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
			Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
			Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
			Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
			Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.DetailReportPayments = New DevExpress.XtraReports.UI.DetailReportBand()
			Me.DetailPayments = New DevExpress.XtraReports.UI.DetailBand()
			Me.SubreportDetail_CheckDetail = New DevExpress.XtraReports.UI.XRSubreport()
			Me.Detail_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
			Me.Detail_CheckDate = New DevExpress.XtraReports.UI.XRLabel()
			Me.Detail_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
			Me.Detail_AdjustmentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.Detail_GLACodeAdjustment = New DevExpress.XtraReports.UI.XRLabel()
			Me.GroupHeaderPayments = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.LabelGroupHeader_PaymentHistory = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupHeader_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupHeader_CheckDate = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupHeader_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupHeader_AdjustmentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupHeader_AdjustmentGLAccount = New DevExpress.XtraReports.UI.XRLabel()
			Me.BindingSourcePayments = New System.Windows.Forms.BindingSource(Me.components)
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.BindingSourcePayments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			'
			'Detail
			'
			Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1})
			Me.Detail.Dpi = 100.0!
			Me.Detail.HeightF = 19.0!
			Me.Detail.KeepTogetherWithDetailReports = True
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'XrLabel9
			'
			Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Category")})
			Me.XrLabel9.Dpi = 100.0!
			Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(381.2497!, 0!)
			Me.XrLabel9.Name = "XrLabel9"
			Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel9.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.XrLabel9.Text = "XrLabel9"
			'
			'XrLabel8
			'
			Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
			Me.XrLabel8.Dpi = 100.0!
			Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(491.6667!, 0!)
			Me.XrLabel8.Name = "XrLabel8"
			Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel8.SizeF = New System.Drawing.SizeF(73.95847!, 19.0!)
			'
			'XrLabel7
			'
			Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueDate", "{0:d}")})
			Me.XrLabel7.Dpi = 100.0!
			Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(578.125!, 0!)
			Me.XrLabel7.Name = "XrLabel7"
			Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel7.SizeF = New System.Drawing.SizeF(73.95831!, 19.0!)
			'
			'XrLabel6
			'
			Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
			Me.XrLabel6.Dpi = 100.0!
			Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(667.6667!, 0!)
			Me.XrLabel6.Name = "XrLabel6"
			Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			'
			'XrLabel5
			'
			Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountPaid", "{0:n2}")})
			Me.XrLabel5.Dpi = 100.0!
			Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(778.0834!, 0!)
			Me.XrLabel5.Name = "XrLabel5"
			Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			'
			'XrLabel4
			'
			Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceDue", "{0:n2}")})
			Me.XrLabel4.Dpi = 100.0!
			Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(890.0!, 0!)
			Me.XrLabel4.Name = "XrLabel4"
			Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			'
			'XrLabel3
			'
			Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
			Me.XrLabel3.Dpi = 100.0!
			Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(151.7505!, 0!)
			Me.XrLabel3.Name = "XrLabel3"
			Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel3.SizeF = New System.Drawing.SizeF(201.3742!, 19.0!)
			Me.XrLabel3.Text = "XrLabel3"
			'
			'XrLabel2
			'
			Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SequenceNumber")})
			Me.XrLabel2.Dpi = 100.0!
			Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(105.4583!, 0!)
			Me.XrLabel2.Name = "XrLabel2"
			Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel2.SizeF = New System.Drawing.SizeF(42.70783!, 19.0!)
			Me.XrLabel2.Text = "XrLabel2"
			'
			'XrLabel1
			'
			Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
			Me.XrLabel1.Dpi = 100.0!
			Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 0!)
			Me.XrLabel1.Name = "XrLabel1"
			Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.XrLabel1.Text = "XrLabel1"
			'
			'LineDetail_Break
			'
			Me.LineDetail_Break.BorderColor = System.Drawing.Color.Silver
			Me.LineDetail_Break.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LineDetail_Break.BorderWidth = 1.0!
			Me.LineDetail_Break.Dpi = 100.0!
			Me.LineDetail_Break.ForeColor = System.Drawing.Color.Silver
			Me.LineDetail_Break.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 41.74999!)
			Me.LineDetail_Break.Name = "LineDetail_Break"
			Me.LineDetail_Break.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
			Me.LineDetail_Break.StylePriority.UseBorderWidth = False
			'
			'LabelPageHeader_InvoiceNumber
			'
			Me.LabelPageHeader_InvoiceNumber.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_InvoiceNumber.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_InvoiceNumber.BorderWidth = 1.0!
			Me.LabelPageHeader_InvoiceNumber.CanGrow = False
			Me.LabelPageHeader_InvoiceNumber.Dpi = 100.0!
			Me.LabelPageHeader_InvoiceNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_InvoiceNumber.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 106.125!)
			Me.LabelPageHeader_InvoiceNumber.Name = "LabelPageHeader_InvoiceNumber"
			Me.LabelPageHeader_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_InvoiceNumber.SizeF = New System.Drawing.SizeF(99.99977!, 19.0!)
			Me.LabelPageHeader_InvoiceNumber.StylePriority.UseFont = False
			Me.LabelPageHeader_InvoiceNumber.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_InvoiceNumber.Text = "Invoice Number"
			Me.LabelPageHeader_InvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_AmountPaid
			'
			Me.LabelPageHeader_AmountPaid.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_AmountPaid.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_AmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_AmountPaid.BorderWidth = 1.0!
			Me.LabelPageHeader_AmountPaid.CanGrow = False
			Me.LabelPageHeader_AmountPaid.Dpi = 100.0!
			Me.LabelPageHeader_AmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_AmountPaid.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(778.0834!, 106.125!)
			Me.LabelPageHeader_AmountPaid.Name = "LabelPageHeader_AmountPaid"
			Me.LabelPageHeader_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_AmountPaid.SizeF = New System.Drawing.SizeF(99.99963!, 19.0!)
			Me.LabelPageHeader_AmountPaid.StylePriority.UseFont = False
			Me.LabelPageHeader_AmountPaid.Text = "Amount Paid"
			Me.LabelPageHeader_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_InvoiceDate
			'
			Me.LabelPageHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_InvoiceDate.BorderWidth = 1.0!
			Me.LabelPageHeader_InvoiceDate.CanGrow = False
			Me.LabelPageHeader_InvoiceDate.Dpi = 100.0!
			Me.LabelPageHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(491.6667!, 106.125!)
			Me.LabelPageHeader_InvoiceDate.Name = "LabelPageHeader_InvoiceDate"
			Me.LabelPageHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(73.9584!, 19.0!)
			Me.LabelPageHeader_InvoiceDate.StylePriority.UseFont = False
			Me.LabelPageHeader_InvoiceDate.Text = "Invoice Date"
			Me.LabelPageHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_DueDate
			'
			Me.LabelPageHeader_DueDate.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_DueDate.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_DueDate.BorderWidth = 1.0!
			Me.LabelPageHeader_DueDate.CanGrow = False
			Me.LabelPageHeader_DueDate.Dpi = 100.0!
			Me.LabelPageHeader_DueDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_DueDate.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DueDate.LocationFloat = New DevExpress.Utils.PointFloat(578.125!, 106.125!)
			Me.LabelPageHeader_DueDate.Name = "LabelPageHeader_DueDate"
			Me.LabelPageHeader_DueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_DueDate.SizeF = New System.Drawing.SizeF(73.95834!, 19.0!)
			Me.LabelPageHeader_DueDate.StylePriority.UseFont = False
			Me.LabelPageHeader_DueDate.Text = "Due Date"
			Me.LabelPageHeader_DueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_InvoiceAmount
			'
			Me.LabelPageHeader_InvoiceAmount.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_InvoiceAmount.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_InvoiceAmount.BorderWidth = 1.0!
			Me.LabelPageHeader_InvoiceAmount.CanGrow = False
			Me.LabelPageHeader_InvoiceAmount.Dpi = 100.0!
			Me.LabelPageHeader_InvoiceAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_InvoiceAmount.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(667.6667!, 106.125!)
			Me.LabelPageHeader_InvoiceAmount.Name = "LabelPageHeader_InvoiceAmount"
			Me.LabelPageHeader_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_InvoiceAmount.SizeF = New System.Drawing.SizeF(99.99977!, 19.0!)
			Me.LabelPageHeader_InvoiceAmount.StylePriority.UseFont = False
			Me.LabelPageHeader_InvoiceAmount.Text = "Invoice Amount"
			Me.LabelPageHeader_InvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_InvoiceSequence
			'
			Me.LabelPageHeader_InvoiceSequence.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_InvoiceSequence.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceSequence.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_InvoiceSequence.BorderWidth = 1.0!
			Me.LabelPageHeader_InvoiceSequence.CanGrow = False
			Me.LabelPageHeader_InvoiceSequence.Dpi = 100.0!
			Me.LabelPageHeader_InvoiceSequence.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_InvoiceSequence.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceSequence.LocationFloat = New DevExpress.Utils.PointFloat(105.4583!, 106.125!)
			Me.LabelPageHeader_InvoiceSequence.Name = "LabelPageHeader_InvoiceSequence"
			Me.LabelPageHeader_InvoiceSequence.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_InvoiceSequence.SizeF = New System.Drawing.SizeF(42.70782!, 19.0!)
			Me.LabelPageHeader_InvoiceSequence.StylePriority.UseFont = False
			Me.LabelPageHeader_InvoiceSequence.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_InvoiceSequence.Text = "Inv Seq"
			Me.LabelPageHeader_InvoiceSequence.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_InvoiceCategory
			'
			Me.LabelPageHeader_InvoiceCategory.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_InvoiceCategory.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceCategory.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_InvoiceCategory.BorderWidth = 1.0!
			Me.LabelPageHeader_InvoiceCategory.CanGrow = False
			Me.LabelPageHeader_InvoiceCategory.Dpi = 100.0!
			Me.LabelPageHeader_InvoiceCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_InvoiceCategory.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_InvoiceCategory.LocationFloat = New DevExpress.Utils.PointFloat(381.2497!, 106.125!)
			Me.LabelPageHeader_InvoiceCategory.Name = "LabelPageHeader_InvoiceCategory"
			Me.LabelPageHeader_InvoiceCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_InvoiceCategory.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.LabelPageHeader_InvoiceCategory.StylePriority.UseFont = False
			Me.LabelPageHeader_InvoiceCategory.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_InvoiceCategory.Text = "Invoice Category"
			Me.LabelPageHeader_InvoiceCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_Description
			'
			Me.LabelPageHeader_Description.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_Description.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_Description.BorderWidth = 1.0!
			Me.LabelPageHeader_Description.CanGrow = False
			Me.LabelPageHeader_Description.Dpi = 100.0!
			Me.LabelPageHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_Description.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(151.7505!, 106.125!)
			Me.LabelPageHeader_Description.Name = "LabelPageHeader_Description"
			Me.LabelPageHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_Description.SizeF = New System.Drawing.SizeF(81.2495!, 19.0!)
			Me.LabelPageHeader_Description.StylePriority.UseFont = False
			Me.LabelPageHeader_Description.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_Description.Text = "Description"
			Me.LabelPageHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'TopMargin
			'
			Me.TopMargin.Dpi = 100.0!
			Me.TopMargin.HeightF = 50.0!
			Me.TopMargin.Name = "TopMargin"
			Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'BottomMargin
			'
			Me.BottomMargin.Dpi = 100.0!
			Me.BottomMargin.HeightF = 50.0!
			Me.BottomMargin.Name = "BottomMargin"
			Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'PageHeader
			'
			Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_DateTo, Me.LabelPageHeader_DateFrom, Me.LabelPageHeader_Client, Me.LabelPageHeader_DateToLabel, Me.LabelPageHeader_DateFromLabel, Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ClientLabel, Me.LabelPageHeader_ReportTitle, Me.LinePageHeader_Bottom, Me.LabelPageHeader_InvoiceNumber, Me.LabelPageHeader_Description, Me.LabelPageHeader_InvoiceCategory, Me.LabelPageHeader_InvoiceDate, Me.LabelPageHeader_DueDate, Me.LabelPageHeader_InvoiceAmount, Me.LabelPageHeader_AmountPaid, Me.LabelPageHeader_BalanceDue, Me.LabelPageHeader_InvoiceSequence})
			Me.PageHeader.Dpi = 100.0!
			Me.PageHeader.HeightF = 125.125!
			Me.PageHeader.Name = "PageHeader"
			Me.PageHeader.StylePriority.UseTextAlignment = False
			Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelPageHeader_DateTo
			'
			Me.LabelPageHeader_DateTo.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_DateTo.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateTo.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_DateTo.BorderWidth = 1.0!
			Me.LabelPageHeader_DateTo.CanGrow = False
			Me.LabelPageHeader_DateTo.Dpi = 100.0!
			Me.LabelPageHeader_DateTo.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.LabelPageHeader_DateTo.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateTo.LocationFloat = New DevExpress.Utils.PointFloat(79.16665!, 83.75002!)
			Me.LabelPageHeader_DateTo.Name = "LabelPageHeader_DateTo"
			Me.LabelPageHeader_DateTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_DateTo.SizeF = New System.Drawing.SizeF(153.8333!, 17.00001!)
			Me.LabelPageHeader_DateTo.StylePriority.UseFont = False
			Me.LabelPageHeader_DateTo.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_DateTo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_DateFrom
			'
			Me.LabelPageHeader_DateFrom.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_DateFrom.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_DateFrom.BorderWidth = 1.0!
			Me.LabelPageHeader_DateFrom.CanGrow = False
			Me.LabelPageHeader_DateFrom.Dpi = 100.0!
			Me.LabelPageHeader_DateFrom.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.LabelPageHeader_DateFrom.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateFrom.LocationFloat = New DevExpress.Utils.PointFloat(79.16681!, 66.75002!)
			Me.LabelPageHeader_DateFrom.Name = "LabelPageHeader_DateFrom"
			Me.LabelPageHeader_DateFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_DateFrom.SizeF = New System.Drawing.SizeF(153.8332!, 17.0!)
			Me.LabelPageHeader_DateFrom.StylePriority.UseFont = False
			Me.LabelPageHeader_DateFrom.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_DateFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_Client
			'
			Me.LabelPageHeader_Client.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_Client.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_Client.BorderWidth = 1.0!
			Me.LabelPageHeader_Client.CanGrow = False
			Me.LabelPageHeader_Client.Dpi = 100.0!
			Me.LabelPageHeader_Client.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.LabelPageHeader_Client.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Client.LocationFloat = New DevExpress.Utils.PointFloat(79.16666!, 49.75001!)
			Me.LabelPageHeader_Client.Name = "LabelPageHeader_Client"
			Me.LabelPageHeader_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_Client.SizeF = New System.Drawing.SizeF(486.4583!, 17.0!)
			Me.LabelPageHeader_Client.StylePriority.UseFont = False
			Me.LabelPageHeader_Client.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_DateToLabel
			'
			Me.LabelPageHeader_DateToLabel.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_DateToLabel.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateToLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_DateToLabel.BorderWidth = 1.0!
			Me.LabelPageHeader_DateToLabel.CanGrow = False
			Me.LabelPageHeader_DateToLabel.Dpi = 100.0!
			Me.LabelPageHeader_DateToLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
			Me.LabelPageHeader_DateToLabel.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateToLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 83.75002!)
			Me.LabelPageHeader_DateToLabel.Name = "LabelPageHeader_DateToLabel"
			Me.LabelPageHeader_DateToLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_DateToLabel.SizeF = New System.Drawing.SizeF(79.16666!, 17.00001!)
			Me.LabelPageHeader_DateToLabel.StylePriority.UseFont = False
			Me.LabelPageHeader_DateToLabel.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_DateToLabel.Text = "Date To:"
			Me.LabelPageHeader_DateToLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_DateFromLabel
			'
			Me.LabelPageHeader_DateFromLabel.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_DateFromLabel.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateFromLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_DateFromLabel.BorderWidth = 1.0!
			Me.LabelPageHeader_DateFromLabel.CanGrow = False
			Me.LabelPageHeader_DateFromLabel.Dpi = 100.0!
			Me.LabelPageHeader_DateFromLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
			Me.LabelPageHeader_DateFromLabel.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_DateFromLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 66.75002!)
			Me.LabelPageHeader_DateFromLabel.Name = "LabelPageHeader_DateFromLabel"
			Me.LabelPageHeader_DateFromLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_DateFromLabel.SizeF = New System.Drawing.SizeF(79.16666!, 17.00001!)
			Me.LabelPageHeader_DateFromLabel.StylePriority.UseFont = False
			Me.LabelPageHeader_DateFromLabel.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_DateFromLabel.Text = "Date From:"
			Me.LabelPageHeader_DateFromLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_Agency
			'
			Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_Agency.BorderWidth = 1.0!
			Me.LabelPageHeader_Agency.CanGrow = False
			Me.LabelPageHeader_Agency.Dpi = 100.0!
			Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!)
			Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(762.4999!, 4.083347!)
			Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
			Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(237.5001!, 18.58334!)
			Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
			Me.LabelPageHeader_Agency.StylePriority.UseFont = False
			Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
			Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_Agency.Text = "Client Invoice Report"
			Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LinePageHeader_Top
			'
			Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
			Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LinePageHeader_Top.BorderWidth = 4.0!
			Me.LinePageHeader_Top.Dpi = 100.0!
			Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
			Me.LinePageHeader_Top.LineWidth = 4
			Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
			Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
			'
			'LabelPageHeader_ClientLabel
			'
			Me.LabelPageHeader_ClientLabel.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_ClientLabel.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_ClientLabel.BorderWidth = 1.0!
			Me.LabelPageHeader_ClientLabel.CanGrow = False
			Me.LabelPageHeader_ClientLabel.Dpi = 100.0!
			Me.LabelPageHeader_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
			Me.LabelPageHeader_ClientLabel.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 49.75001!)
			Me.LabelPageHeader_ClientLabel.Name = "LabelPageHeader_ClientLabel"
			Me.LabelPageHeader_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_ClientLabel.SizeF = New System.Drawing.SizeF(79.16666!, 17.0!)
			Me.LabelPageHeader_ClientLabel.StylePriority.UseFont = False
			Me.LabelPageHeader_ClientLabel.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_ClientLabel.Text = "Client:"
			Me.LabelPageHeader_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelPageHeader_ReportTitle
			'
			Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_ReportTitle.BorderWidth = 1.0!
			Me.LabelPageHeader_ReportTitle.CanGrow = False
			Me.LabelPageHeader_ReportTitle.Dpi = 100.0!
			Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
			Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083347!)
			Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
			Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
			Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
			Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
			Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
			Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
			Me.LabelPageHeader_ReportTitle.Text = "Client Invoices Report"
			Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LinePageHeader_Bottom
			'
			Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
			Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LinePageHeader_Bottom.BorderWidth = 4.0!
			Me.LinePageHeader_Bottom.Dpi = 100.0!
			Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
			Me.LinePageHeader_Bottom.LineWidth = 4
			Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 33.08336!)
			Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
			Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
			'
			'LabelPageHeader_BalanceDue
			'
			Me.LabelPageHeader_BalanceDue.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageHeader_BalanceDue.BorderColor = System.Drawing.Color.Black
			Me.LabelPageHeader_BalanceDue.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageHeader_BalanceDue.BorderWidth = 1.0!
			Me.LabelPageHeader_BalanceDue.CanGrow = False
			Me.LabelPageHeader_BalanceDue.Dpi = 100.0!
			Me.LabelPageHeader_BalanceDue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelPageHeader_BalanceDue.ForeColor = System.Drawing.Color.Black
			Me.LabelPageHeader_BalanceDue.LocationFloat = New DevExpress.Utils.PointFloat(890.0!, 106.125!)
			Me.LabelPageHeader_BalanceDue.Name = "LabelPageHeader_BalanceDue"
			Me.LabelPageHeader_BalanceDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelPageHeader_BalanceDue.SizeF = New System.Drawing.SizeF(99.99963!, 19.0!)
			Me.LabelPageHeader_BalanceDue.StylePriority.UseFont = False
			Me.LabelPageHeader_BalanceDue.Text = "Balance Due"
			Me.LabelPageHeader_BalanceDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'PageInfo_Pages
			'
			Me.PageInfo_Pages.Dpi = 100.0!
			Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
			Me.PageInfo_Pages.Format = "Page {0} of {1}"
			Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5417!, 4.083379!)
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
			Me.PageFooter.Dpi = 100.0!
			Me.PageFooter.HeightF = 25.08335!
			Me.PageFooter.Name = "PageFooter"
			'
			'LinePageFooter
			'
			Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
			Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LinePageFooter.BorderWidth = 4.0!
			Me.LinePageFooter.Dpi = 100.0!
			Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
			Me.LinePageFooter.LineWidth = 4
			Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.LinePageFooter.Name = "LinePageFooter"
			Me.LinePageFooter.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
			'
			'LabelPageFooter_UserCode
			'
			Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
			Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
			Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
			Me.LabelPageFooter_UserCode.CanGrow = False
			Me.LabelPageFooter_UserCode.Dpi = 100.0!
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
			Me.LabelPageFooter_Date.Dpi = 100.0!
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
			Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice)
			'
			'DetailReportPayments
			'
			Me.DetailReportPayments.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailPayments, Me.GroupHeaderPayments})
			Me.DetailReportPayments.DataSource = Me.BindingSourcePayments
			Me.DetailReportPayments.Dpi = 100.0!
			Me.DetailReportPayments.Level = 0
			Me.DetailReportPayments.Name = "DetailReportPayments"
			'
			'DetailPayments
			'
			Me.DetailPayments.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubreportDetail_CheckDetail, Me.Detail_CheckNumber, Me.Detail_CheckDate, Me.Detail_AmountPaid, Me.Detail_AdjustmentAmount, Me.Detail_GLACodeAdjustment, Me.LineDetail_Break})
			Me.DetailPayments.Dpi = 100.0!
			Me.DetailPayments.HeightF = 43.74999!
			Me.DetailPayments.Name = "DetailPayments"
			'
			'SubreportDetail_CheckDetail
			'
			Me.SubreportDetail_CheckDetail.CanShrink = True
			Me.SubreportDetail_CheckDetail.Dpi = 100.0!
			Me.SubreportDetail_CheckDetail.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 18.99999!)
			Me.SubreportDetail_CheckDetail.Name = "SubreportDetail_CheckDetail"
			Me.SubreportDetail_CheckDetail.ReportSource = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoicePaymentCheckSubReport()
			Me.SubreportDetail_CheckDetail.SizeF = New System.Drawing.SizeF(484.4167!, 22.75!)
			'
			'Detail_CheckNumber
			'
			Me.Detail_CheckNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
			Me.Detail_CheckNumber.Dpi = 100.0!
			Me.Detail_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(175.0!, 0!)
			Me.Detail_CheckNumber.Name = "Detail_CheckNumber"
			Me.Detail_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Detail_CheckNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.Detail_CheckNumber.Text = "Detail_CheckNumber"
			'
			'Detail_CheckDate
			'
			Me.Detail_CheckDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate", "{0:d}")})
			Me.Detail_CheckDate.Dpi = 100.0!
			Me.Detail_CheckDate.LocationFloat = New DevExpress.Utils.PointFloat(289.5833!, 0!)
			Me.Detail_CheckDate.Name = "Detail_CheckDate"
			Me.Detail_CheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Detail_CheckDate.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			'
			'Detail_AmountPaid
			'
			Me.Detail_AmountPaid.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountPaid")})
			Me.Detail_AmountPaid.Dpi = 100.0!
			Me.Detail_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 0!)
			Me.Detail_AmountPaid.Name = "Detail_AmountPaid"
			Me.Detail_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Detail_AmountPaid.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.Detail_AmountPaid.StylePriority.UseTextAlignment = False
			Me.Detail_AmountPaid.Text = "Detail_AmountPaid"
			Me.Detail_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Detail_AdjustmentAmount
			'
			Me.Detail_AdjustmentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdjustmentAmount")})
			Me.Detail_AdjustmentAmount.Dpi = 100.0!
			Me.Detail_AdjustmentAmount.LocationFloat = New DevExpress.Utils.PointFloat(511.9166!, 0!)
			Me.Detail_AdjustmentAmount.Name = "Detail_AdjustmentAmount"
			Me.Detail_AdjustmentAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Detail_AdjustmentAmount.SizeF = New System.Drawing.SizeF(115.625!, 19.0!)
			Me.Detail_AdjustmentAmount.StylePriority.UseTextAlignment = False
			Me.Detail_AdjustmentAmount.Text = "Detail_AdjustmentAmount"
			Me.Detail_AdjustmentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Detail_GLACodeAdjustment
			'
			Me.Detail_GLACodeAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeAdjustment")})
			Me.Detail_GLACodeAdjustment.Dpi = 100.0!
			Me.Detail_GLACodeAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(638.5417!, 0!)
			Me.Detail_GLACodeAdjustment.Name = "Detail_GLACodeAdjustment"
			Me.Detail_GLACodeAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Detail_GLACodeAdjustment.SizeF = New System.Drawing.SizeF(186.4583!, 19.0!)
			Me.Detail_GLACodeAdjustment.Text = "Detail_GLACodeAdjustment"
			'
			'GroupHeaderPayments
			'
			Me.GroupHeaderPayments.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeader_PaymentHistory, Me.LabelGroupHeader_CheckNumber, Me.LabelGroupHeader_CheckDate, Me.LabelGroupHeader_AmountPaid, Me.LabelGroupHeader_AdjustmentAmount, Me.LabelGroupHeader_AdjustmentGLAccount})
			Me.GroupHeaderPayments.Dpi = 100.0!
			Me.GroupHeaderPayments.HeightF = 37.99999!
			Me.GroupHeaderPayments.Name = "GroupHeaderPayments"
			'
			'LabelGroupHeader_PaymentHistory
			'
			Me.LabelGroupHeader_PaymentHistory.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_PaymentHistory.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_PaymentHistory.Borders = DevExpress.XtraPrinting.BorderSide.Top
			Me.LabelGroupHeader_PaymentHistory.BorderWidth = 1.0!
			Me.LabelGroupHeader_PaymentHistory.CanGrow = False
			Me.LabelGroupHeader_PaymentHistory.Dpi = 100.0!
			Me.LabelGroupHeader_PaymentHistory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_PaymentHistory.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_PaymentHistory.LocationFloat = New DevExpress.Utils.PointFloat(175.0!, 0!)
			Me.LabelGroupHeader_PaymentHistory.Name = "LabelGroupHeader_PaymentHistory"
			Me.LabelGroupHeader_PaymentHistory.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_PaymentHistory.SizeF = New System.Drawing.SizeF(599.0!, 19.0!)
			Me.LabelGroupHeader_PaymentHistory.StylePriority.UseBorders = False
			Me.LabelGroupHeader_PaymentHistory.StylePriority.UseFont = False
			Me.LabelGroupHeader_PaymentHistory.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_PaymentHistory.Text = "Payment History"
			Me.LabelGroupHeader_PaymentHistory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
			'
			'LabelGroupHeader_CheckNumber
			'
			Me.LabelGroupHeader_CheckNumber.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_CheckNumber.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_CheckNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroupHeader_CheckNumber.BorderWidth = 1.0!
			Me.LabelGroupHeader_CheckNumber.CanGrow = False
			Me.LabelGroupHeader_CheckNumber.Dpi = 100.0!
			Me.LabelGroupHeader_CheckNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_CheckNumber.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(175.0!, 18.99999!)
			Me.LabelGroupHeader_CheckNumber.Name = "LabelGroupHeader_CheckNumber"
			Me.LabelGroupHeader_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_CheckNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.LabelGroupHeader_CheckNumber.StylePriority.UseFont = False
			Me.LabelGroupHeader_CheckNumber.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_CheckNumber.Text = "Check Number"
			Me.LabelGroupHeader_CheckNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroupHeader_CheckDate
			'
			Me.LabelGroupHeader_CheckDate.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_CheckDate.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_CheckDate.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroupHeader_CheckDate.BorderWidth = 1.0!
			Me.LabelGroupHeader_CheckDate.CanGrow = False
			Me.LabelGroupHeader_CheckDate.Dpi = 100.0!
			Me.LabelGroupHeader_CheckDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_CheckDate.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_CheckDate.LocationFloat = New DevExpress.Utils.PointFloat(289.5833!, 18.99999!)
			Me.LabelGroupHeader_CheckDate.Name = "LabelGroupHeader_CheckDate"
			Me.LabelGroupHeader_CheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_CheckDate.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.LabelGroupHeader_CheckDate.StylePriority.UseFont = False
			Me.LabelGroupHeader_CheckDate.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_CheckDate.Text = "Check Date"
			Me.LabelGroupHeader_CheckDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroupHeader_AmountPaid
			'
			Me.LabelGroupHeader_AmountPaid.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_AmountPaid.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroupHeader_AmountPaid.BorderWidth = 1.0!
			Me.LabelGroupHeader_AmountPaid.CanGrow = False
			Me.LabelGroupHeader_AmountPaid.Dpi = 100.0!
			Me.LabelGroupHeader_AmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_AmountPaid.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(401.25!, 18.99999!)
			Me.LabelGroupHeader_AmountPaid.Name = "LabelGroupHeader_AmountPaid"
			Me.LabelGroupHeader_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_AmountPaid.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
			Me.LabelGroupHeader_AmountPaid.StylePriority.UseFont = False
			Me.LabelGroupHeader_AmountPaid.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_AmountPaid.Text = "Amount Paid"
			Me.LabelGroupHeader_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelGroupHeader_AdjustmentAmount
			'
			Me.LabelGroupHeader_AdjustmentAmount.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_AdjustmentAmount.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AdjustmentAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroupHeader_AdjustmentAmount.BorderWidth = 1.0!
			Me.LabelGroupHeader_AdjustmentAmount.CanGrow = False
			Me.LabelGroupHeader_AdjustmentAmount.Dpi = 100.0!
			Me.LabelGroupHeader_AdjustmentAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_AdjustmentAmount.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AdjustmentAmount.LocationFloat = New DevExpress.Utils.PointFloat(511.9166!, 18.99999!)
			Me.LabelGroupHeader_AdjustmentAmount.Name = "LabelGroupHeader_AdjustmentAmount"
			Me.LabelGroupHeader_AdjustmentAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_AdjustmentAmount.SizeF = New System.Drawing.SizeF(115.6251!, 19.0!)
			Me.LabelGroupHeader_AdjustmentAmount.StylePriority.UseFont = False
			Me.LabelGroupHeader_AdjustmentAmount.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_AdjustmentAmount.Text = "Adjustment Amount"
			Me.LabelGroupHeader_AdjustmentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelGroupHeader_AdjustmentGLAccount
			'
			Me.LabelGroupHeader_AdjustmentGLAccount.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroupHeader_AdjustmentGLAccount.BorderColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AdjustmentGLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroupHeader_AdjustmentGLAccount.BorderWidth = 1.0!
			Me.LabelGroupHeader_AdjustmentGLAccount.CanGrow = False
			Me.LabelGroupHeader_AdjustmentGLAccount.Dpi = 100.0!
			Me.LabelGroupHeader_AdjustmentGLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroupHeader_AdjustmentGLAccount.ForeColor = System.Drawing.Color.Black
			Me.LabelGroupHeader_AdjustmentGLAccount.LocationFloat = New DevExpress.Utils.PointFloat(638.5417!, 18.99999!)
			Me.LabelGroupHeader_AdjustmentGLAccount.Name = "LabelGroupHeader_AdjustmentGLAccount"
			Me.LabelGroupHeader_AdjustmentGLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroupHeader_AdjustmentGLAccount.SizeF = New System.Drawing.SizeF(135.4584!, 19.0!)
			Me.LabelGroupHeader_AdjustmentGLAccount.StylePriority.UseFont = False
			Me.LabelGroupHeader_AdjustmentGLAccount.StylePriority.UseTextAlignment = False
			Me.LabelGroupHeader_AdjustmentGLAccount.Text = "Adjustment GL Account"
			Me.LabelGroupHeader_AdjustmentGLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'BindingSourcePayments
			'
			Me.BindingSourcePayments.DataSource = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment)
			'
			'ClientInvoiceReport
			'
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.DetailReportPayments})
			Me.DataSource = Me.BindingSource
			Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Landscape = True
			Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
			Me.PageHeight = 850
			Me.PageWidth = 1100
			Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
			Me.Version = "16.2"
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.BindingSourcePayments, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelPageHeader_DueDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceCategory As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceSequence As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineDetail_Break As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_DateToLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DateFromLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_BalanceDue As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Client As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DateTo As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DateFrom As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportPayments As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailPayments As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderPayments As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeader_PaymentHistory As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_CheckDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_AdjustmentAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_AdjustmentGLAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourcePayments As System.Windows.Forms.BindingSource
        Friend WithEvents Detail_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_CheckDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_AdjustmentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_GLACodeAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubreportDetail_CheckDetail As DevExpress.XtraReports.UI.XRSubreport
    End Class

End Namespace
