Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientInvoicePaymentCheckSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Detail_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeader_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_CheckDetail = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupFooterLabel_TotalAmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Detail_AmountPaid, Me.Detail_InvoiceDate, Me.Detail_InvoiceNumber})
            Me.Detail.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Detail.HeightF = 19.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Detail_AmountPaid
            '
            Me.Detail_AmountPaid.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountPaid", "{0:n2}")})
            Me.Detail_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(252.0833!, 0.0!)
            Me.Detail_AmountPaid.Name = "Detail_AmountPaid"
            Me.Detail_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Detail_AmountPaid.SizeF = New System.Drawing.SizeF(99.99998!, 19.0!)
            Me.Detail_AmountPaid.StylePriority.UseTextAlignment = False
            Me.Detail_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Detail_InvoiceDate
			'
			Me.Detail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
			Me.Detail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(122.9167!, 0.0!)
            Me.Detail_InvoiceDate.Name = "Detail_InvoiceDate"
            Me.Detail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Detail_InvoiceDate.SizeF = New System.Drawing.SizeF(99.99999!, 19.0!)
            '
            'Detail_InvoiceNumber
            '
            Me.Detail_InvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.Detail_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Detail_InvoiceNumber.Name = "Detail_InvoiceNumber"
            Me.Detail_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Detail_InvoiceNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.Detail_InvoiceNumber.Text = "Detail_InvoiceNumber"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0.0!
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
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoicePaymentCheckDetail)
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeader_AmountPaid, Me.LabelGroupHeader_InvoiceNumber, Me.LabelGroupHeader_CheckDetail, Me.LabelGroupHeader_InvoiceDate})
            Me.GroupHeader.HeightF = 38.00001!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'LabelGroupHeader_AmountPaid
            '
            Me.LabelGroupHeader_AmountPaid.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_AmountPaid.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_AmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_AmountPaid.BorderWidth = 1.0!
            Me.LabelGroupHeader_AmountPaid.CanGrow = False
            Me.LabelGroupHeader_AmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeader_AmountPaid.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(252.0833!, 19.00001!)
            Me.LabelGroupHeader_AmountPaid.Name = "LabelGroupHeader_AmountPaid"
            Me.LabelGroupHeader_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_AmountPaid.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeader_AmountPaid.StylePriority.UseFont = False
            Me.LabelGroupHeader_AmountPaid.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_AmountPaid.Text = "Amount Paid"
            Me.LabelGroupHeader_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeader_InvoiceNumber
            '
            Me.LabelGroupHeader_InvoiceNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_InvoiceNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_InvoiceNumber.BorderWidth = 1.0!
            Me.LabelGroupHeader_InvoiceNumber.CanGrow = False
            Me.LabelGroupHeader_InvoiceNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeader_InvoiceNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 19.00001!)
            Me.LabelGroupHeader_InvoiceNumber.Name = "LabelGroupHeader_InvoiceNumber"
            Me.LabelGroupHeader_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_InvoiceNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeader_InvoiceNumber.StylePriority.UseFont = False
            Me.LabelGroupHeader_InvoiceNumber.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_InvoiceNumber.Text = "Invoice Number"
            Me.LabelGroupHeader_InvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_CheckDetail
            '
            Me.LabelGroupHeader_CheckDetail.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_CheckDetail.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_CheckDetail.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupHeader_CheckDetail.BorderWidth = 1.0!
            Me.LabelGroupHeader_CheckDetail.CanGrow = False
            Me.LabelGroupHeader_CheckDetail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_CheckDetail.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_CheckDetail.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelGroupHeader_CheckDetail.Name = "LabelGroupHeader_CheckDetail"
            Me.LabelGroupHeader_CheckDetail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_CheckDetail.SizeF = New System.Drawing.SizeF(352.0833!, 19.0!)
            Me.LabelGroupHeader_CheckDetail.StylePriority.UseBorders = False
            Me.LabelGroupHeader_CheckDetail.StylePriority.UseFont = False
            Me.LabelGroupHeader_CheckDetail.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_CheckDetail.Text = "Check Detail"
            Me.LabelGroupHeader_CheckDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LabelGroupHeader_InvoiceDate
            '
            Me.LabelGroupHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_InvoiceDate.BorderWidth = 1.0!
            Me.LabelGroupHeader_InvoiceDate.CanGrow = False
            Me.LabelGroupHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(122.9166!, 19.00001!)
            Me.LabelGroupHeader_InvoiceDate.Name = "LabelGroupHeader_InvoiceDate"
            Me.LabelGroupHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeader_InvoiceDate.StylePriority.UseFont = False
            Me.LabelGroupHeader_InvoiceDate.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_InvoiceDate.Text = "Invoice Date"
            Me.LabelGroupHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.GroupFooterLabel_TotalAmountPaid})
            Me.GroupFooter.HeightF = 19.0!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'GroupFooterLabel_TotalAmountPaid
            '
            Me.GroupFooterLabel_TotalAmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.GroupFooterLabel_TotalAmountPaid.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountPaid", "{0:n2}")})
            Me.GroupFooterLabel_TotalAmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupFooterLabel_TotalAmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(252.0833!, 0.0!)
            Me.GroupFooterLabel_TotalAmountPaid.Name = "GroupFooterLabel_TotalAmountPaid"
            Me.GroupFooterLabel_TotalAmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.GroupFooterLabel_TotalAmountPaid.SizeF = New System.Drawing.SizeF(99.99998!, 19.0!)
            Me.GroupFooterLabel_TotalAmountPaid.StylePriority.UseBorders = False
            Me.GroupFooterLabel_TotalAmountPaid.StylePriority.UseFont = False
            Me.GroupFooterLabel_TotalAmountPaid.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.GroupFooterLabel_TotalAmountPaid.Summary = XrSummary1
            Me.GroupFooterLabel_TotalAmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ClientInvoicePaymentCheckSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
            Me.Margins = New System.Drawing.Printing.Margins(25, 426, 0, 0)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeader_CheckDetail As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooterLabel_TotalAmountPaid As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
