Namespace Invoices

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BillingHistorySubReport
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
            Me.XrLabelAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.XrLabelAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelBillingHistoryHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrLabelTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineTotal = New DevExpress.XtraReports.UI.XRLine()
            Me.InvoiceNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.OrderNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ComponentNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobNumbers = New DevExpress.XtraReports.Parameters.Parameter()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelAmount, Me.XrLabelInvoiceDate, Me.XrLabelInvoiceNumber})
            Me.Detail.HeightF = 17.0!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Item", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.StylePriority.UsePadding = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelAmount
            '
            Me.XrLabelAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.XrLabelAmount.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 0!)
            Me.XrLabelAmount.Name = "XrLabelAmount"
            Me.XrLabelAmount.SizeF = New System.Drawing.SizeF(150.0!, 17.0!)
            Me.XrLabelAmount.StylePriority.UsePadding = False
            Me.XrLabelAmount.StylePriority.UseTextAlignment = False
            Me.XrLabelAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceDate
            '
            Me.XrLabelInvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.XrLabelInvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(160.0!, 0!)
            Me.XrLabelInvoiceDate.Name = "XrLabelInvoiceDate"
            Me.XrLabelInvoiceDate.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            Me.XrLabelInvoiceDate.StylePriority.UsePadding = False
            Me.XrLabelInvoiceDate.StylePriority.UseTextAlignment = False
            Me.XrLabelInvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceNumber
            '
            Me.XrLabelInvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.XrLabelInvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 0!)
            Me.XrLabelInvoiceNumber.Name = "XrLabelInvoiceNumber"
            Me.XrLabelInvoiceNumber.SizeF = New System.Drawing.SizeF(150.0!, 17.0!)
            Me.XrLabelInvoiceNumber.StylePriority.UsePadding = False
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.StylePriority.UsePadding = False
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelAmountLabel
            '
            Me.XrLabelAmountLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 26.3333!)
            Me.XrLabelAmountLabel.Name = "XrLabelAmountLabel"
            Me.XrLabelAmountLabel.SizeF = New System.Drawing.SizeF(150.0!, 17.0!)
            Me.XrLabelAmountLabel.StylePriority.UseFont = False
            Me.XrLabelAmountLabel.StylePriority.UsePadding = False
            Me.XrLabelAmountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelAmountLabel.Text = "Amount"
            Me.XrLabelAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceDateLabel
            '
            Me.XrLabelInvoiceDateLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(160.0!, 26.3333!)
            Me.XrLabelInvoiceDateLabel.Name = "XrLabelInvoiceDateLabel"
            Me.XrLabelInvoiceDateLabel.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            Me.XrLabelInvoiceDateLabel.StylePriority.UseFont = False
            Me.XrLabelInvoiceDateLabel.StylePriority.UsePadding = False
            Me.XrLabelInvoiceDateLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelInvoiceDateLabel.Text = "Invoice Date"
            Me.XrLabelInvoiceDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceNumberLabel
            '
            Me.XrLabelInvoiceNumberLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 26.3333!)
            Me.XrLabelInvoiceNumberLabel.Name = "XrLabelInvoiceNumberLabel"
            Me.XrLabelInvoiceNumberLabel.SizeF = New System.Drawing.SizeF(150.0!, 17.0!)
            Me.XrLabelInvoiceNumberLabel.StylePriority.UseFont = False
            Me.XrLabelInvoiceNumberLabel.StylePriority.UsePadding = False
            Me.XrLabelInvoiceNumberLabel.Text = "Invoice No."
            '
            'XrLabelBillingHistoryHeader
            '
            Me.XrLabelBillingHistoryHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelBillingHistoryHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelBillingHistoryHeader.Name = "XrLabelBillingHistoryHeader"
            Me.XrLabelBillingHistoryHeader.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            Me.XrLabelBillingHistoryHeader.StylePriority.UseFont = False
            Me.XrLabelBillingHistoryHeader.StylePriority.UsePadding = False
            Me.XrLabelBillingHistoryHeader.Text = "Billing History:"
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelTotalLabel
            '
            Me.XrLabelTotalLabel.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 2.000014!)
            Me.XrLabelTotalLabel.Name = "XrLabelTotalLabel"
            Me.XrLabelTotalLabel.SizeF = New System.Drawing.SizeF(250.0!, 17.0!)
            Me.XrLabelTotalLabel.StylePriority.UseFont = False
            Me.XrLabelTotalLabel.StylePriority.UsePadding = False
            Me.XrLabelTotalLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelTotalLabel.Text = "Total Billed to Date:"
            Me.XrLabelTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTotal
            '
            Me.XrLabelTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.XrLabelTotal.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 2.000014!)
            Me.XrLabelTotal.Name = "XrLabelTotal"
            Me.XrLabelTotal.SizeF = New System.Drawing.SizeF(150.0!, 17.0!)
            Me.XrLabelTotal.StylePriority.UsePadding = False
            Me.XrLabelTotal.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelTotal.Summary = XrSummary1
            Me.XrLabelTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineTotal
            '
            Me.XrLineTotal.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0!)
            Me.XrLineTotal.Name = "XrLineTotal"
            Me.XrLineTotal.SizeF = New System.Drawing.SizeF(110.0!, 2.0!)
            '
            'InvoiceNumber
            '
            Me.InvoiceNumber.Name = "InvoiceNumber"
            Me.InvoiceNumber.Type = GetType(Integer)
            Me.InvoiceNumber.ValueInfo = "0"
            Me.InvoiceNumber.Visible = False
            '
            'JobNumber
            '
            Me.JobNumber.Name = "JobNumber"
            Me.JobNumber.Type = GetType(Integer)
            Me.JobNumber.ValueInfo = "0"
            Me.JobNumber.Visible = False
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelInvoiceNumberLabel, Me.XrLabelBillingHistoryHeader, Me.XrLabelInvoiceDateLabel, Me.XrLabelAmountLabel})
            Me.ReportHeader.HeightF = 43.3333!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotal, Me.XrLineTotal, Me.XrLabelTotalLabel})
            Me.ReportFooter.HeightF = 19.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'OrderNumber
            '
            Me.OrderNumber.Name = "OrderNumber"
            Me.OrderNumber.Type = GetType(Integer)
            Me.OrderNumber.ValueInfo = "0"
            Me.OrderNumber.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)
            '
            'ComponentNumber
            '
            Me.ComponentNumber.Name = "ComponentNumber"
            Me.ComponentNumber.Type = GetType(Short)
            Me.ComponentNumber.ValueInfo = "0"
            Me.ComponentNumber.Visible = False
            '
            'JobNumbers
            '
            Me.JobNumbers.Description = "JobNumbers"
            Me.JobNumbers.Name = "JobNumbers"
            Me.JobNumbers.ValueInfo = "0"
            Me.JobNumbers.Visible = False
            '
            'BillingHistorySubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.InvoiceNumber, Me.JobNumber, Me.OrderNumber, Me.ComponentNumber, Me.JobNumbers})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents InvoiceNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents JobNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelBillingHistoryHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTotal As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents OrderNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ComponentNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents JobNumbers As DevExpress.XtraReports.Parameters.Parameter
    End Class

End Namespace
