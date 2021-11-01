Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountPayableBatchDetailReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_TotalInvoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTrans = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DiscountPercent = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Terms = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Office = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBoxDetail_Hold = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.CheckBoxDetail_1099Invoice = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.LabelDetail_TermsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesTaxLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToPay = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_VendorLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToPayLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TotalInvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DiscountPercentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineReportFooter_2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_BatchTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalInvoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportNonClient = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailNonClient = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailNonClient_Comment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_POLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderNonClient = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderNonClient_Complete = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_POLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_NonClient = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderNonClient_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupHeaderNonClient_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterNonClient = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterNonClient_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterNonClient_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceNonClient = New System.Windows.Forms.BindingSource(Me.components)
            Me.PrintComment = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportProduction = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailProduction = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailProduction_Comment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_Complete = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_POLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailProduction_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderProduction = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderProduction_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderProduction_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderProduction_Complete = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_Production = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderProduction_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderProduction_POLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderProduction_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterProduction = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterProduction_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterProduction_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceProduction = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProdPOLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProdIsPOComplete = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProdJobComp = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProdCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProdPrintComment = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooter_2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupFooter_InvoiceTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupFooter_InvoiceTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.DetailReportMagazine = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailMagazine = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailMagazine_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailMagazine_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailMagazine_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailMagazine_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailMagazine_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailMagazine_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderMagazine = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderMagazine_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderMagazine_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderMagazine_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderMagazine_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderMagazine_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderMagazine_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderMagazine_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderMagazine_Magazine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderMagazine_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterMagazine = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterMagazine_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterMagazine_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceMagazine = New System.Windows.Forms.BindingSource(Me.components)
            Me.MagCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.MagOrderLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DetailReportNewspaper = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailNewspaper = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailNewspaper_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNewspaper_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNewspaper_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNewspaper_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNewspaper_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNewspaper_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderNewspaper = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LineGroupHeaderNewspaper_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderNewspaper_Newspaper = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNewspaper_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderNewspaper_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderNewspaper_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNewspaper_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNewspaper_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNewspaper_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNewspaper_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterNewspaper = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterNewspaper_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterNewspaper_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceNewspaper = New System.Windows.Forms.BindingSource(Me.components)
            Me.NewsCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.NewsOrderLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportInternet = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailInternet = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailInternet_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailInternet_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailInternet_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailInternet_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailInternet_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailInternet_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderInternet = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderInternet_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderInternet_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderInternet_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderInternet_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderInternet_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderInternet_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderInternet_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderInternet_Internet = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderInternet_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterInternet = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterInternet_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterInternet_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceInternet = New System.Windows.Forms.BindingSource(Me.components)
            Me.InternetCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.InternetOrderLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportOutOfHome = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailOutOfHome = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailOutOfHome_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOutOfHome_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOutOfHome_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOutOfHome_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOutOfHome_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOutOfHome_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderOutOfHome = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LineGroupHeaderOutofHomeTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupHeaderOutofHomeBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderOutOfHome_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_OutOfHome = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderOutOfHome_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterOutOfHome = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterOutOfHome_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOutOfHome_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceOutOfHome = New System.Windows.Forms.BindingSource(Me.components)
            Me.OutOfHomeCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OutOfHomeOrderLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportRadio = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailRadio = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailRadio_LineNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_OrderMonth = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_Spots = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailRadio_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderRadio = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderRadio_LineNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_Spots = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_OrderMonth = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_Radio = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderRadio_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderRadioBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupHeaderRadioTop = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterRadio = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterRadio_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterRadio_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceRadio = New System.Windows.Forms.BindingSource(Me.components)
            Me.DetailReportTV = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailTV = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailTV_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_LineNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_OrderMonth = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_Spots = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailTV_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderTV = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LineGroupHeaderTVTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupHeaderTVBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderTV_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_TV = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_OrderMonth = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_Spots = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderTV_LineNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterTV = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterTV_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterTV_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceTV = New System.Windows.Forms.BindingSource(Me.components)
            Me.RadioCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.RadioOrderMonth = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TVCDP = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TVOrderMonth = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSourceNonClient, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceProduction, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceMagazine, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceNewspaper, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceInternet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceOutOfHome, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceRadio, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceTV, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_TotalInvoice, Me.LabelDetail_GLTrans, Me.LabelDetail_GLAccount, Me.LabelDetail_PostingPeriod, Me.LabelDetail_DiscountPercent, Me.LabelDetail_Terms, Me.LabelDetail_GLAccountLabel, Me.LabelDetail_Office, Me.CheckBoxDetail_Hold, Me.CheckBoxDetail_1099Invoice, Me.LabelDetail_TermsLabel, Me.LabelDetail_OfficeLabel, Me.LabelDetail_Status, Me.LabelDetail_SalesTaxLabel, Me.LabelDetail_AmountLabel, Me.LabelDetail_SalesTax, Me.LabelDetail_Amount, Me.LabelDetail_DateToPay, Me.LabelDetail_Date, Me.LabelDetail_Invoice, Me.LabelDetail_Vendor, Me.LabelDetail_VendorLabel, Me.LabelDetail_InvoiceLabel, Me.LabelDetail_DateLabel, Me.LabelDetail_StatusLabel, Me.LabelDetail_DateToPayLabel, Me.LabelDetail_TotalInvoiceLabel, Me.LabelDetail_PostingPeriodLabel, Me.LabelDetail_GLTransLabel, Me.LabelDetail_DiscountPercentLabel})
            Me.Detail.HeightF = 161.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TotalInvoice
            '
            Me.LabelDetail_TotalInvoice.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelDetail_TotalInvoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalInvoice", "{0:c2}")})
            Me.LabelDetail_TotalInvoice.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 138.0!)
            Me.LabelDetail_TotalInvoice.Name = "LabelDetail_TotalInvoice"
            Me.LabelDetail_TotalInvoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TotalInvoice.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_TotalInvoice.StylePriority.UseBorders = False
            Me.LabelDetail_TotalInvoice.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TotalInvoice.Text = "LabelDetail_TotalInvoice"
            Me.LabelDetail_TotalInvoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLTrans
            '
            Me.LabelDetail_GLTrans.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTrans.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 138.0!)
            Me.LabelDetail_GLTrans.Name = "LabelDetail_GLTrans"
            Me.LabelDetail_GLTrans.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTrans.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLTrans.Text = "LabelDetail_GLTrans"
            '
            'LabelDetail_GLAccount
            '
            Me.LabelDetail_GLAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccount")})
            Me.LabelDetail_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(694.7916!, 92.00001!)
            Me.LabelDetail_GLAccount.Name = "LabelDetail_GLAccount"
            Me.LabelDetail_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLAccount.SizeF = New System.Drawing.SizeF(295.2083!, 22.99999!)
            Me.LabelDetail_GLAccount.Text = "LabelDetail_GLAccount"
            '
            'LabelDetail_PostingPeriod
            '
            Me.LabelDetail_PostingPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostingPeriod.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 115.0!)
            Me.LabelDetail_PostingPeriod.Name = "LabelDetail_PostingPeriod"
            Me.LabelDetail_PostingPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriod.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_PostingPeriod.Text = "LabelDetail_PostingPeriod"
            '
            'LabelDetail_DiscountPercent
            '
            Me.LabelDetail_DiscountPercent.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountPercent")})
            Me.LabelDetail_DiscountPercent.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 68.99999!)
            Me.LabelDetail_DiscountPercent.Name = "LabelDetail_DiscountPercent"
            Me.LabelDetail_DiscountPercent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DiscountPercent.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_DiscountPercent.Text = "LabelDetail_DiscountPercent"
            '
            'LabelDetail_Terms
            '
            Me.LabelDetail_Terms.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Terms")})
            Me.LabelDetail_Terms.LocationFloat = New DevExpress.Utils.PointFloat(694.7916!, 46.0!)
            Me.LabelDetail_Terms.Name = "LabelDetail_Terms"
            Me.LabelDetail_Terms.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Terms.SizeF = New System.Drawing.SizeF(295.2083!, 23.0!)
            Me.LabelDetail_Terms.Text = "LabelDetail_Terms"
            '
            'LabelDetail_GLAccountLabel
            '
            Me.LabelDetail_GLAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GLAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLAccountLabel.CanGrow = False
            Me.LabelDetail_GLAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 91.99995!)
            Me.LabelDetail_GLAccountLabel.Name = "LabelDetail_GLAccountLabel"
            Me.LabelDetail_GLAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLAccountLabel.SizeF = New System.Drawing.SizeF(88.54163!, 19.0!)
            Me.LabelDetail_GLAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLAccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLAccountLabel.Text = "GL Account:"
            Me.LabelDetail_GLAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Office
            '
            Me.LabelDetail_Office.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Office")})
            Me.LabelDetail_Office.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 0!)
            Me.LabelDetail_Office.Name = "LabelDetail_Office"
            Me.LabelDetail_Office.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Office.SizeF = New System.Drawing.SizeF(295.2083!, 23.0!)
            Me.LabelDetail_Office.Text = "LabelDetail_Office"
            '
            'CheckBoxDetail_Hold
            '
            Me.CheckBoxDetail_Hold.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckBoxState", Nothing, "PaymentHold")})
            Me.CheckBoxDetail_Hold.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBoxDetail_Hold.LocationFloat = New DevExpress.Utils.PointFloat(850.0!, 22.99999!)
            Me.CheckBoxDetail_Hold.Name = "CheckBoxDetail_Hold"
            Me.CheckBoxDetail_Hold.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.CheckBoxDetail_Hold.StylePriority.UseFont = False
            Me.CheckBoxDetail_Hold.Text = "Hold"
            '
            'CheckBoxDetail_1099Invoice
            '
            Me.CheckBoxDetail_1099Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckBoxState", Nothing, "Is1099Flag")})
            Me.CheckBoxDetail_1099Invoice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBoxDetail_1099Invoice.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 22.99999!)
            Me.CheckBoxDetail_1099Invoice.Name = "CheckBoxDetail_1099Invoice"
            Me.CheckBoxDetail_1099Invoice.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.CheckBoxDetail_1099Invoice.StylePriority.UseFont = False
            Me.CheckBoxDetail_1099Invoice.Text = "1099 Invoice"
            '
            'LabelDetail_TermsLabel
            '
            Me.LabelDetail_TermsLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TermsLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TermsLabel.BorderWidth = 1.0!
            Me.LabelDetail_TermsLabel.CanGrow = False
            Me.LabelDetail_TermsLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TermsLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 46.0!)
            Me.LabelDetail_TermsLabel.Name = "LabelDetail_TermsLabel"
            Me.LabelDetail_TermsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TermsLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_TermsLabel.StylePriority.UseFont = False
            Me.LabelDetail_TermsLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TermsLabel.Text = "Terms:"
            Me.LabelDetail_TermsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OfficeLabel
            '
            Me.LabelDetail_OfficeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OfficeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OfficeLabel.BorderWidth = 1.0!
            Me.LabelDetail_OfficeLabel.CanGrow = False
            Me.LabelDetail_OfficeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OfficeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7918!, 0!)
            Me.LabelDetail_OfficeLabel.Name = "LabelDetail_OfficeLabel"
            Me.LabelDetail_OfficeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OfficeLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_OfficeLabel.StylePriority.UseFont = False
            Me.LabelDetail_OfficeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OfficeLabel.Text = "Office:"
            Me.LabelDetail_OfficeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Status
            '
            Me.LabelDetail_Status.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.LabelDetail_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_Status.LocationFloat = New DevExpress.Utils.PointFloat(416.6667!, 22.99999!)
            Me.LabelDetail_Status.Name = "LabelDetail_Status"
            Me.LabelDetail_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Status.SizeF = New System.Drawing.SizeF(173.7514!, 23.0!)
            Me.LabelDetail_Status.StylePriority.UseFont = False
            Me.LabelDetail_Status.Text = "LabelDetail_Status"
            '
            'LabelDetail_SalesTaxLabel
            '
            Me.LabelDetail_SalesTaxLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_SalesTaxLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesTaxLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_SalesTaxLabel.BorderWidth = 1.0!
            Me.LabelDetail_SalesTaxLabel.CanGrow = False
            Me.LabelDetail_SalesTaxLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_SalesTaxLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesTaxLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 115.0!)
            Me.LabelDetail_SalesTaxLabel.Name = "LabelDetail_SalesTaxLabel"
            Me.LabelDetail_SalesTaxLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_SalesTaxLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_SalesTaxLabel.StylePriority.UseFont = False
            Me.LabelDetail_SalesTaxLabel.Text = "Sales Tax:"
            Me.LabelDetail_SalesTaxLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelDetail_AmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 91.99995!)
            Me.LabelDetail_AmountLabel.Name = "LabelDetail_AmountLabel"
            Me.LabelDetail_AmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AmountLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_AmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AmountLabel.Text = "Amount:"
            Me.LabelDetail_AmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_SalesTax
            '
            Me.LabelDetail_SalesTax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumSalesTax", "{0:c2}")})
            Me.LabelDetail_SalesTax.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 115.0!)
            Me.LabelDetail_SalesTax.Name = "LabelDetail_SalesTax"
            Me.LabelDetail_SalesTax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_SalesTax.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_SalesTax.StylePriority.UseTextAlignment = False
            Me.LabelDetail_SalesTax.Text = "LabelDetail_SalesTax"
            Me.LabelDetail_SalesTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Amount
            '
            Me.LabelDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumAmount", "{0:c2}")})
            Me.LabelDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 91.99995!)
            Me.LabelDetail_Amount.Name = "LabelDetail_Amount"
            Me.LabelDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Amount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Amount.Text = "LabelDetail_Amount"
            Me.LabelDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_DateToPay
            '
            Me.LabelDetail_DateToPay.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateToPay", "{0:d}")})
            Me.LabelDetail_DateToPay.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 68.99995!)
            Me.LabelDetail_DateToPay.Name = "LabelDetail_DateToPay"
            Me.LabelDetail_DateToPay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DateToPay.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            '
            'LabelDetail_Date
            '
            Me.LabelDetail_Date.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_Date.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 45.99997!)
            Me.LabelDetail_Date.Name = "LabelDetail_Date"
            Me.LabelDetail_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Date.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            '
            'LabelDetail_Invoice
            '
            Me.LabelDetail_Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Invoice")})
            Me.LabelDetail_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 22.99999!)
            Me.LabelDetail_Invoice.Name = "LabelDetail_Invoice"
            Me.LabelDetail_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Invoice.SizeF = New System.Drawing.SizeF(261.4583!, 23.0!)
            Me.LabelDetail_Invoice.Text = "LabelDetail_Invoice"
            '
            'LabelDetail_Vendor
            '
            Me.LabelDetail_Vendor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Vendor")})
            Me.LabelDetail_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 0!)
            Me.LabelDetail_Vendor.Name = "LabelDetail_Vendor"
            Me.LabelDetail_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Vendor.SizeF = New System.Drawing.SizeF(388.5417!, 23.0!)
            Me.LabelDetail_Vendor.Text = "LabelDetail_Vendor"
            '
            'LabelDetail_VendorLabel
            '
            Me.LabelDetail_VendorLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_VendorLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_VendorLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_VendorLabel.BorderWidth = 1.0!
            Me.LabelDetail_VendorLabel.CanGrow = False
            Me.LabelDetail_VendorLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_VendorLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_VendorLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_VendorLabel.Name = "LabelDetail_VendorLabel"
            Me.LabelDetail_VendorLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_VendorLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_VendorLabel.StylePriority.UseFont = False
            Me.LabelDetail_VendorLabel.Text = "Vendor:"
            Me.LabelDetail_VendorLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceLabel
            '
            Me.LabelDetail_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceLabel.CanGrow = False
            Me.LabelDetail_InvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 22.99999!)
            Me.LabelDetail_InvoiceLabel.Name = "LabelDetail_InvoiceLabel"
            Me.LabelDetail_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceLabel.Text = "Invoice:"
            Me.LabelDetail_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateLabel
            '
            Me.LabelDetail_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateLabel.CanGrow = False
            Me.LabelDetail_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 45.99997!)
            Me.LabelDetail_DateLabel.Name = "LabelDetail_DateLabel"
            Me.LabelDetail_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateLabel.SizeF = New System.Drawing.SizeF(61.45837!, 19.0!)
            Me.LabelDetail_DateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateLabel.Text = "Date:"
            Me.LabelDetail_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_StatusLabel
            '
            Me.LabelDetail_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_StatusLabel.BorderWidth = 1.0!
            Me.LabelDetail_StatusLabel.CanGrow = False
            Me.LabelDetail_StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(363.5417!, 22.99999!)
            Me.LabelDetail_StatusLabel.Name = "LabelDetail_StatusLabel"
            Me.LabelDetail_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_StatusLabel.SizeF = New System.Drawing.SizeF(53.12503!, 19.0!)
            Me.LabelDetail_StatusLabel.StylePriority.UseFont = False
            Me.LabelDetail_StatusLabel.Text = "Status:"
            Me.LabelDetail_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateToPayLabel
            '
            Me.LabelDetail_DateToPayLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateToPayLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateToPayLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateToPayLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateToPayLabel.CanGrow = False
            Me.LabelDetail_DateToPayLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateToPayLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateToPayLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 68.99995!)
            Me.LabelDetail_DateToPayLabel.Name = "LabelDetail_DateToPayLabel"
            Me.LabelDetail_DateToPayLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateToPayLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_DateToPayLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateToPayLabel.Text = "Date to Pay:"
            Me.LabelDetail_DateToPayLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TotalInvoiceLabel
            '
            Me.LabelDetail_TotalInvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TotalInvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalInvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TotalInvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_TotalInvoiceLabel.CanGrow = False
            Me.LabelDetail_TotalInvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TotalInvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalInvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 138.0!)
            Me.LabelDetail_TotalInvoiceLabel.Name = "LabelDetail_TotalInvoiceLabel"
            Me.LabelDetail_TotalInvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TotalInvoiceLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_TotalInvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_TotalInvoiceLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TotalInvoiceLabel.Text = "Total Invoice:"
            Me.LabelDetail_TotalInvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_PostingPeriodLabel
            '
            Me.LabelDetail_PostingPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PostingPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PostingPeriodLabel.BorderWidth = 1.0!
            Me.LabelDetail_PostingPeriodLabel.CanGrow = False
            Me.LabelDetail_PostingPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PostingPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 115.0!)
            Me.LabelDetail_PostingPeriodLabel.Name = "LabelDetail_PostingPeriodLabel"
            Me.LabelDetail_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(88.54163!, 19.0!)
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseFont = False
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PostingPeriodLabel.Text = "Posting Period:"
            Me.LabelDetail_PostingPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLTransLabel
            '
            Me.LabelDetail_GLTransLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLTransLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLTransLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GLTransLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLTransLabel.CanGrow = False
            Me.LabelDetail_GLTransLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLTransLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLTransLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7919!, 138.0!)
            Me.LabelDetail_GLTransLabel.Name = "LabelDetail_GLTransLabel"
            Me.LabelDetail_GLTransLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLTransLabel.SizeF = New System.Drawing.SizeF(88.54138!, 19.0!)
            Me.LabelDetail_GLTransLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLTransLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLTransLabel.Text = "GL Trans:"
            Me.LabelDetail_GLTransLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DiscountPercentLabel
            '
            Me.LabelDetail_DiscountPercentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DiscountPercentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DiscountPercentLabel.BorderWidth = 1.0!
            Me.LabelDetail_DiscountPercentLabel.CanGrow = False
            Me.LabelDetail_DiscountPercentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DiscountPercentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 68.99995!)
            Me.LabelDetail_DiscountPercentLabel.Name = "LabelDetail_DiscountPercentLabel"
            Me.LabelDetail_DiscountPercentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DiscountPercentLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseFont = False
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DiscountPercentLabel.Text = "Discount %:"
            Me.LabelDetail_DiscountPercentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_1
            '
            Me.LineReportFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_1.BorderWidth = 0!
            Me.LineReportFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
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
            Me.LineReportFooter_2.BorderWidth = 0!
            Me.LineReportFooter_2.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
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
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 10.0!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(115.62!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 48.95833!
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Bottom, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.HeightF = 54.16672!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Accounts Payable Batch Report - Detail"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4.0!
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.08337!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4.0!
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
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
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Accounts Payable Batch Report - Detail"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_BatchTotal, Me.LineReportFooter_2, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_1})
            Me.ReportFooter.HeightF = 36.37498!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_BatchTotal
            '
            Me.LabelReportFooter_BatchTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotal.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotal.CanGrow = False
            Me.LabelReportFooter_BatchTotal.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelReportFooter_BatchTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotal.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 10.0!)
            Me.LabelReportFooter_BatchTotal.Name = "LabelReportFooter_BatchTotal"
            Me.LabelReportFooter_BatchTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotal.SizeF = New System.Drawing.SizeF(98.12491!, 19.0!)
            Me.LabelReportFooter_BatchTotal.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotal.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TotalInvoice
            '
            Me.TotalInvoice.Expression = "[SumAmount] + [SumSalesTax] + [SumShipping]"
            Me.TotalInvoice.Name = "TotalInvoice"
            '
            'DetailReportNonClient
            '
            Me.DetailReportNonClient.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailNonClient, Me.GroupHeaderNonClient, Me.GroupFooterNonClient})
            Me.DetailReportNonClient.DataSource = Me.BindingSourceNonClient
            Me.DetailReportNonClient.Level = 0
            Me.DetailReportNonClient.Name = "DetailReportNonClient"
            '
            'DetailNonClient
            '
            Me.DetailNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailNonClient_Comment, Me.LabelDetailNonClient_POLine, Me.LabelDetailNonClient_Amount, Me.LabelDetailNonClient_GLDescription, Me.LabelDetailNonClient_GLACode})
            Me.DetailNonClient.HeightF = 46.00002!
            Me.DetailNonClient.Name = "DetailNonClient"
            '
            'LabelDetailNonClient_Comment
            '
            Me.LabelDetailNonClient_Comment.CanShrink = True
            Me.LabelDetailNonClient_Comment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PrintComment")})
            Me.LabelDetailNonClient_Comment.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
            Me.LabelDetailNonClient_Comment.Name = "LabelDetailNonClient_Comment"
            Me.LabelDetailNonClient_Comment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_Comment.SizeF = New System.Drawing.SizeF(989.9999!, 23.0!)
            Me.LabelDetailNonClient_Comment.Text = "LabelDetailNonClient_Comment"
            '
            'LabelDetailNonClient_POLine
            '
            Me.LabelDetailNonClient_POLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "POLine")})
            Me.LabelDetailNonClient_POLine.LocationFloat = New DevExpress.Utils.PointFloat(474.9999!, 0!)
            Me.LabelDetailNonClient_POLine.Name = "LabelDetailNonClient_POLine"
            Me.LabelDetailNonClient_POLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_POLine.SizeF = New System.Drawing.SizeF(77.08496!, 23.0!)
            Me.LabelDetailNonClient_POLine.Text = "XrLabel9"
            '
            'LabelDetailNonClient_Amount
            '
            Me.LabelDetailNonClient_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:#,#.00}")})
            Me.LabelDetailNonClient_Amount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailNonClient_Amount.Name = "LabelDetailNonClient_Amount"
            Me.LabelDetailNonClient_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_Amount.SizeF = New System.Drawing.SizeF(99.99997!, 23.0!)
            Me.LabelDetailNonClient_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetailNonClient_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailNonClient_GLDescription
            '
            Me.LabelDetailNonClient_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerAccount.Description")})
            Me.LabelDetailNonClient_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailNonClient_GLDescription.Name = "LabelDetailNonClient_GLDescription"
            Me.LabelDetailNonClient_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailNonClient_GLDescription.Text = "LabelDetailNonClient_GLDescription"
            '
            'LabelDetailNonClient_GLACode
            '
            Me.LabelDetailNonClient_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailNonClient_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailNonClient_GLACode.Name = "LabelDetailNonClient_GLACode"
            Me.LabelDetailNonClient_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailNonClient_GLACode.Text = "XrLabel4"
            '
            'GroupHeaderNonClient
            '
            Me.GroupHeaderNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderNonClient_Complete, Me.LabelGroupHeaderNonClient_Amount, Me.LabelGroupHeaderNonClient_POLine, Me.LabelGroupHeaderNonClient_GLAccount, Me.LabelGroupHeaderNonClient_NonClient, Me.LabelGroupHeaderNonClient_GLDescription, Me.LineGroupHeaderNonClient_Top, Me.LineGroupHeaderNonClient_Bottom})
            Me.GroupHeaderNonClient.HeightF = 44.0!
            Me.GroupHeaderNonClient.Name = "GroupHeaderNonClient"
            '
            'LabelGroupHeaderNonClient_Complete
            '
            Me.LabelGroupHeaderNonClient_Complete.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_Complete.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Complete.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_Complete.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_Complete.CanGrow = False
            Me.LabelGroupHeaderNonClient_Complete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_Complete.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Complete.LocationFloat = New DevExpress.Utils.PointFloat(562.4999!, 3.999996!)
            Me.LabelGroupHeaderNonClient_Complete.Name = "LabelGroupHeaderNonClient_Complete"
            Me.LabelGroupHeaderNonClient_Complete.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_Complete.SizeF = New System.Drawing.SizeF(89.58331!, 19.0!)
            Me.LabelGroupHeaderNonClient_Complete.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_Complete.Text = "Complete"
            Me.LabelGroupHeaderNonClient_Complete.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNonClient_Amount
            '
            Me.LabelGroupHeaderNonClient_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_Amount.CanGrow = False
            Me.LabelGroupHeaderNonClient_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Amount.LocationFloat = New DevExpress.Utils.PointFloat(390.415!, 3.999996!)
            Me.LabelGroupHeaderNonClient_Amount.Name = "LabelGroupHeaderNonClient_Amount"
            Me.LabelGroupHeaderNonClient_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderNonClient_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderNonClient_Amount.Text = "Amount"
            Me.LabelGroupHeaderNonClient_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderNonClient_POLine
            '
            Me.LabelGroupHeaderNonClient_POLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_POLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_POLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_POLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_POLine.CanGrow = False
            Me.LabelGroupHeaderNonClient_POLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_POLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_POLine.LocationFloat = New DevExpress.Utils.PointFloat(474.9999!, 3.999996!)
            Me.LabelGroupHeaderNonClient_POLine.Name = "LabelGroupHeaderNonClient_POLine"
            Me.LabelGroupHeaderNonClient_POLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_POLine.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderNonClient_POLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_POLine.Text = "PO/Line #"
            Me.LabelGroupHeaderNonClient_POLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNonClient_GLAccount
            '
            Me.LabelGroupHeaderNonClient_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_GLAccount.CanGrow = False
            Me.LabelGroupHeaderNonClient_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 4.000004!)
            Me.LabelGroupHeaderNonClient_GLAccount.Name = "LabelGroupHeaderNonClient_GLAccount"
            Me.LabelGroupHeaderNonClient_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNonClient_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderNonClient_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNonClient_NonClient
            '
            Me.LabelGroupHeaderNonClient_NonClient.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_NonClient.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_NonClient.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_NonClient.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_NonClient.CanGrow = False
            Me.LabelGroupHeaderNonClient_NonClient.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderNonClient_NonClient.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_NonClient.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.0!)
            Me.LabelGroupHeaderNonClient_NonClient.Name = "LabelGroupHeaderNonClient_NonClient"
            Me.LabelGroupHeaderNonClient_NonClient.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_NonClient.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderNonClient_NonClient.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_NonClient.Text = "Non-Client"
            Me.LabelGroupHeaderNonClient_NonClient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNonClient_GLDescription
            '
            Me.LabelGroupHeaderNonClient_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_GLDescription.CanGrow = False
            Me.LabelGroupHeaderNonClient_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 4.000004!)
            Me.LabelGroupHeaderNonClient_GLDescription.Name = "LabelGroupHeaderNonClient_GLDescription"
            Me.LabelGroupHeaderNonClient_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNonClient_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_GLDescription.Text = "Description"
            Me.LabelGroupHeaderNonClient_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderNonClient_Top
            '
            Me.LineGroupHeaderNonClient_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNonClient_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNonClient_Top.BorderWidth = 0!
            Me.LineGroupHeaderNonClient_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNonClient_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderNonClient_Top.Name = "LineGroupHeaderNonClient_Top"
            Me.LineGroupHeaderNonClient_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseForeColor = False
            '
            'LineGroupHeaderNonClient_Bottom
            '
            Me.LineGroupHeaderNonClient_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNonClient_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNonClient_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderNonClient_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNonClient_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 23.0!)
            Me.LineGroupHeaderNonClient_Bottom.Name = "LineGroupHeaderNonClient_Bottom"
            Me.LineGroupHeaderNonClient_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseForeColor = False
            '
            'GroupFooterNonClient
            '
            Me.GroupFooterNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterNonClient_DisbursedAmount, Me.LabelGroupFooterNonClient_Total})
            Me.GroupFooterNonClient.HeightF = 23.0!
            Me.GroupFooterNonClient.Name = "GroupFooterNonClient"
            '
            'LabelGroupFooterNonClient_DisbursedAmount
            '
            Me.LabelGroupFooterNonClient_DisbursedAmount.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterNonClient_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:$0.00}")})
            Me.LabelGroupFooterNonClient_DisbursedAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic)
            Me.LabelGroupFooterNonClient_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.Name = "LabelGroupFooterNonClient_DisbursedAmount"
            Me.LabelGroupFooterNonClient_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseBorders = False
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseFont = False
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:c2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterNonClient_DisbursedAmount.Summary = XrSummary1
            Me.LabelGroupFooterNonClient_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterNonClient_Total
            '
            Me.LabelGroupFooterNonClient_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterNonClient_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNonClient_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterNonClient_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterNonClient_Total.CanGrow = False
            Me.LabelGroupFooterNonClient_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterNonClient_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNonClient_Total.LocationFloat = New DevExpress.Utils.PointFloat(247.9116!, 0!)
            Me.LabelGroupFooterNonClient_Total.Name = "LabelGroupFooterNonClient_Total"
            Me.LabelGroupFooterNonClient_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterNonClient_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterNonClient_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterNonClient_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterNonClient_Total.Text = "Non-Client Total:"
            Me.LabelGroupFooterNonClient_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceNonClient
            '
            Me.BindingSourceNonClient.DataSource = GetType(AdvantageFramework.Database.Entities.AccountPayableGLDistribution)
            '
            'PrintComment
            '
            Me.PrintComment.DataSource = Me.BindingSourceNonClient
            Me.PrintComment.Expression = "Iif(IsNullOrEmpty([Comment]), '', 'Comment: ' + [Comment])"
            Me.PrintComment.Name = "PrintComment"
            '
            'DetailReportProduction
            '
            Me.DetailReportProduction.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailProduction, Me.GroupHeaderProduction, Me.GroupFooterProduction})
            Me.DetailReportProduction.DataSource = Me.BindingSourceProduction
            Me.DetailReportProduction.Level = 1
            Me.DetailReportProduction.Name = "DetailReportProduction"
            '
            'DetailProduction
            '
            Me.DetailProduction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailProduction_Comment, Me.LabelDetailProduction_Function, Me.LabelDetailProduction_TaxCode, Me.LabelDetailProduction_JobComp, Me.LabelDetailProduction_CDP, Me.LabelDetailProduction_Complete, Me.LabelDetailProduction_POLine, Me.LabelDetailProduction_DisbursedAmount, Me.LabelDetailProduction_GLDescription, Me.LabelDetailProduction_GLACode})
            Me.DetailProduction.HeightF = 46.00002!
            Me.DetailProduction.Name = "DetailProduction"
            '
            'LabelDetailProduction_Comment
            '
            Me.LabelDetailProduction_Comment.CanShrink = True
            Me.LabelDetailProduction_Comment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProdPrintComment")})
            Me.LabelDetailProduction_Comment.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 23.00002!)
            Me.LabelDetailProduction_Comment.Name = "LabelDetailProduction_Comment"
            Me.LabelDetailProduction_Comment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_Comment.SizeF = New System.Drawing.SizeF(989.9999!, 23.0!)
            Me.LabelDetailProduction_Comment.Text = "LabelDetailProduction_Comment"
            '
            'LabelDetailProduction_Function
            '
            Me.LabelDetailProduction_Function.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCode")})
            Me.LabelDetailProduction_Function.LocationFloat = New DevExpress.Utils.PointFloat(863.5416!, 0!)
            Me.LabelDetailProduction_Function.Name = "LabelDetailProduction_Function"
            Me.LabelDetailProduction_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_Function.SizeF = New System.Drawing.SizeF(64.58331!, 23.0!)
            Me.LabelDetailProduction_Function.Text = "LabelDetailProduction_Function"
            '
            'LabelDetailProduction_TaxCode
            '
            Me.LabelDetailProduction_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailProduction_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 0!)
            Me.LabelDetailProduction_TaxCode.Name = "LabelDetailProduction_TaxCode"
            Me.LabelDetailProduction_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_TaxCode.SizeF = New System.Drawing.SizeF(56.25006!, 23.0!)
            Me.LabelDetailProduction_TaxCode.Text = "LabelDetailProduction_TaxCode"
            '
            'LabelDetailProduction_JobComp
            '
            Me.LabelDetailProduction_JobComp.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProdJobComp")})
            Me.LabelDetailProduction_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailProduction_JobComp.Name = "LabelDetailProduction_JobComp"
            Me.LabelDetailProduction_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_JobComp.SizeF = New System.Drawing.SizeF(83.33331!, 23.0!)
            Me.LabelDetailProduction_JobComp.Text = "LabelDetailProduction_JobComp"
            '
            'LabelDetailProduction_CDP
            '
            Me.LabelDetailProduction_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProdCDP")})
            Me.LabelDetailProduction_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailProduction_CDP.Name = "LabelDetailProduction_CDP"
            Me.LabelDetailProduction_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 23.0!)
            Me.LabelDetailProduction_CDP.Text = "LabelDetailProduction_CDP"
            '
            'LabelDetailProduction_Complete
            '
            Me.LabelDetailProduction_Complete.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProdIsPOComplete")})
            Me.LabelDetailProduction_Complete.LocationFloat = New DevExpress.Utils.PointFloat(562.4999!, 0!)
            Me.LabelDetailProduction_Complete.Name = "LabelDetailProduction_Complete"
            Me.LabelDetailProduction_Complete.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_Complete.SizeF = New System.Drawing.SizeF(56.25!, 23.0!)
            Me.LabelDetailProduction_Complete.Text = "LabelDetailProduction_Complete"
            '
            'LabelDetailProduction_POLine
            '
            Me.LabelDetailProduction_POLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProdPOLine")})
            Me.LabelDetailProduction_POLine.LocationFloat = New DevExpress.Utils.PointFloat(474.9999!, 0!)
            Me.LabelDetailProduction_POLine.Name = "LabelDetailProduction_POLine"
            Me.LabelDetailProduction_POLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_POLine.SizeF = New System.Drawing.SizeF(77.0849!, 23.0!)
            Me.LabelDetailProduction_POLine.Text = "LabelDetailProduction_POLine"
            '
            'LabelDetailProduction_DisbursedAmount
            '
            Me.LabelDetailProduction_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Disbursed", "{0:#,#.00}")})
            Me.LabelDetailProduction_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailProduction_DisbursedAmount.Name = "LabelDetailProduction_DisbursedAmount"
            Me.LabelDetailProduction_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_DisbursedAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailProduction_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailProduction_DisbursedAmount.Text = "LabelDetailProduction_DisbursedAmount"
            Me.LabelDetailProduction_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailProduction_GLDescription
            '
            Me.LabelDetailProduction_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailProduction_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailProduction_GLDescription.Name = "LabelDetailProduction_GLDescription"
            Me.LabelDetailProduction_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailProduction_GLDescription.Text = "LabelDetailProduction_GLDescription"
            '
            'LabelDetailProduction_GLACode
            '
            Me.LabelDetailProduction_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailProduction_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailProduction_GLACode.Name = "LabelDetailProduction_GLACode"
            Me.LabelDetailProduction_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailProduction_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailProduction_GLACode.Text = "LabelDetailProduction_GLACode"
            '
            'GroupHeaderProduction
            '
            Me.GroupHeaderProduction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderProduction_CDP, Me.LineGroupHeaderProduction_Top, Me.LabelGroupHeaderProduction_Complete, Me.LabelGroupHeaderProduction_TaxCode, Me.LabelGroupHeaderProduction_Function, Me.LabelGroupHeaderProduction_JobComp, Me.LabelGroupHeaderProduction_Amount, Me.LabelGroupHeaderProduction_Production, Me.LineGroupHeaderProduction_Bottom, Me.LabelGroupHeaderProduction_POLine, Me.LabelGroupHeaderProduction_GLAccount, Me.LabelGroupHeaderProduction_GLDescription})
            Me.GroupHeaderProduction.HeightF = 44.0!
            Me.GroupHeaderProduction.Name = "GroupHeaderProduction"
            '
            'LabelGroupHeaderProduction_CDP
            '
            Me.LabelGroupHeaderProduction_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_CDP.CanGrow = False
            Me.LabelGroupHeaderProduction_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 3.999964!)
            Me.LabelGroupHeaderProduction_CDP.Name = "LabelGroupHeaderProduction_CDP"
            Me.LabelGroupHeaderProduction_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderProduction_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderProduction_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderProduction_Top
            '
            Me.LineGroupHeaderProduction_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderProduction_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderProduction_Top.BorderWidth = 0!
            Me.LineGroupHeaderProduction_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderProduction_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderProduction_Top.Name = "LineGroupHeaderProduction_Top"
            Me.LineGroupHeaderProduction_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderProduction_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderProduction_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderProduction_Top.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderProduction_Complete
            '
            Me.LabelGroupHeaderProduction_Complete.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_Complete.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Complete.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_Complete.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_Complete.CanGrow = False
            Me.LabelGroupHeaderProduction_Complete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_Complete.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Complete.LocationFloat = New DevExpress.Utils.PointFloat(562.4999!, 3.999964!)
            Me.LabelGroupHeaderProduction_Complete.Name = "LabelGroupHeaderProduction_Complete"
            Me.LabelGroupHeaderProduction_Complete.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_Complete.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderProduction_Complete.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_Complete.Text = "Complete"
            Me.LabelGroupHeaderProduction_Complete.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_TaxCode
            '
            Me.LabelGroupHeaderProduction_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_TaxCode.CanGrow = False
            Me.LabelGroupHeaderProduction_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 3.999964!)
            Me.LabelGroupHeaderProduction_TaxCode.Name = "LabelGroupHeaderProduction_TaxCode"
            Me.LabelGroupHeaderProduction_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderProduction_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderProduction_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_Function
            '
            Me.LabelGroupHeaderProduction_Function.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_Function.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Function.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_Function.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_Function.CanGrow = False
            Me.LabelGroupHeaderProduction_Function.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_Function.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Function.LocationFloat = New DevExpress.Utils.PointFloat(863.5416!, 3.999964!)
            Me.LabelGroupHeaderProduction_Function.Name = "LabelGroupHeaderProduction_Function"
            Me.LabelGroupHeaderProduction_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_Function.SizeF = New System.Drawing.SizeF(64.58331!, 19.0!)
            Me.LabelGroupHeaderProduction_Function.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_Function.Text = "Function"
            Me.LabelGroupHeaderProduction_Function.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_JobComp
            '
            Me.LabelGroupHeaderProduction_JobComp.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_JobComp.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_JobComp.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_JobComp.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_JobComp.CanGrow = False
            Me.LabelGroupHeaderProduction_JobComp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_JobComp.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 3.999964!)
            Me.LabelGroupHeaderProduction_JobComp.Name = "LabelGroupHeaderProduction_JobComp"
            Me.LabelGroupHeaderProduction_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_JobComp.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderProduction_JobComp.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_JobComp.Text = "Job/Comp"
            Me.LabelGroupHeaderProduction_JobComp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_Amount
            '
            Me.LabelGroupHeaderProduction_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_Amount.CanGrow = False
            Me.LabelGroupHeaderProduction_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 3.999964!)
            Me.LabelGroupHeaderProduction_Amount.Name = "LabelGroupHeaderProduction_Amount"
            Me.LabelGroupHeaderProduction_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderProduction_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderProduction_Amount.Text = "Amount"
            Me.LabelGroupHeaderProduction_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderProduction_Production
            '
            Me.LabelGroupHeaderProduction_Production.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_Production.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Production.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_Production.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_Production.CanGrow = False
            Me.LabelGroupHeaderProduction_Production.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderProduction_Production.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_Production.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.0!)
            Me.LabelGroupHeaderProduction_Production.Name = "LabelGroupHeaderProduction_Production"
            Me.LabelGroupHeaderProduction_Production.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_Production.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderProduction_Production.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_Production.Text = "Production"
            Me.LabelGroupHeaderProduction_Production.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderProduction_Bottom
            '
            Me.LineGroupHeaderProduction_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderProduction_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderProduction_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderProduction_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderProduction_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
            Me.LineGroupHeaderProduction_Bottom.Name = "LineGroupHeaderProduction_Bottom"
            Me.LineGroupHeaderProduction_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderProduction_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderProduction_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderProduction_Bottom.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderProduction_POLine
            '
            Me.LabelGroupHeaderProduction_POLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_POLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_POLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_POLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_POLine.CanGrow = False
            Me.LabelGroupHeaderProduction_POLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_POLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_POLine.LocationFloat = New DevExpress.Utils.PointFloat(474.9999!, 3.999964!)
            Me.LabelGroupHeaderProduction_POLine.Name = "LabelGroupHeaderProduction_POLine"
            Me.LabelGroupHeaderProduction_POLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_POLine.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderProduction_POLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_POLine.Text = "PO/Line #"
            Me.LabelGroupHeaderProduction_POLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_GLAccount
            '
            Me.LabelGroupHeaderProduction_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_GLAccount.CanGrow = False
            Me.LabelGroupHeaderProduction_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(24.99986!, 4.000028!)
            Me.LabelGroupHeaderProduction_GLAccount.Name = "LabelGroupHeaderProduction_GLAccount"
            Me.LabelGroupHeaderProduction_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderProduction_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderProduction_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderProduction_GLDescription
            '
            Me.LabelGroupHeaderProduction_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderProduction_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderProduction_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderProduction_GLDescription.CanGrow = False
            Me.LabelGroupHeaderProduction_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderProduction_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderProduction_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 3.999964!)
            Me.LabelGroupHeaderProduction_GLDescription.Name = "LabelGroupHeaderProduction_GLDescription"
            Me.LabelGroupHeaderProduction_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderProduction_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderProduction_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderProduction_GLDescription.Text = "Description"
            Me.LabelGroupHeaderProduction_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterProduction
            '
            Me.GroupFooterProduction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterProduction_DisbursedAmount, Me.LabelGroupFooterProduction_Total})
            Me.GroupFooterProduction.HeightF = 23.0!
            Me.GroupFooterProduction.Name = "GroupFooterProduction"
            '
            'LabelGroupFooterProduction_DisbursedAmount
            '
            Me.LabelGroupFooterProduction_DisbursedAmount.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterProduction_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Disbursed", "{0:$0.00}")})
            Me.LabelGroupFooterProduction_DisbursedAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic)
            Me.LabelGroupFooterProduction_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterProduction_DisbursedAmount.Name = "LabelGroupFooterProduction_DisbursedAmount"
            Me.LabelGroupFooterProduction_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterProduction_DisbursedAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooterProduction_DisbursedAmount.StylePriority.UseBorders = False
            Me.LabelGroupFooterProduction_DisbursedAmount.StylePriority.UseFont = False
            Me.LabelGroupFooterProduction_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:c2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterProduction_DisbursedAmount.Summary = XrSummary2
            Me.LabelGroupFooterProduction_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterProduction_Total
            '
            Me.LabelGroupFooterProduction_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterProduction_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterProduction_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterProduction_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterProduction_Total.CanGrow = False
            Me.LabelGroupFooterProduction_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterProduction_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterProduction_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterProduction_Total.Name = "LabelGroupFooterProduction_Total"
            Me.LabelGroupFooterProduction_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterProduction_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterProduction_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterProduction_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterProduction_Total.Text = "Production Total:"
            Me.LabelGroupFooterProduction_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceProduction
            '
            Me.BindingSourceProduction.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)
            '
            'ProdPOLine
            '
            Me.ProdPOLine.DataSource = Me.BindingSourceProduction
            Me.ProdPOLine.Expression = "Iif(IsNullOrEmpty([PONumber]), '' , PadLeft([PONumber],6 , '0')  + '-' + PadLeft(" &
    "[PODetailLineNumber],3 , '0'))"
            Me.ProdPOLine.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProdPOLine.Name = "ProdPOLine"
            '
            'ProdIsPOComplete
            '
            Me.ProdIsPOComplete.DataSource = Me.BindingSourceProduction
            Me.ProdIsPOComplete.Expression = "Iif([POComplete]=1, 'Yes' , 'No')"
            Me.ProdIsPOComplete.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProdIsPOComplete.Name = "ProdIsPOComplete"
            '
            'ProdJobComp
            '
            Me.ProdJobComp.DataSource = Me.BindingSourceProduction
            Me.ProdJobComp.Expression = "PadLeft([JobNumber], 6, '0') + '-' + PadLeft([JobComponentNumber], 3, '0')"
            Me.ProdJobComp.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProdJobComp.Name = "ProdJobComp"
            '
            'ProdCDP
            '
            Me.ProdCDP.DataSource = Me.BindingSourceProduction
            Me.ProdCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.ProdCDP.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProdCDP.Name = "ProdCDP"
            '
            'ProdPrintComment
            '
            Me.ProdPrintComment.DataSource = Me.BindingSourceProduction
            Me.ProdPrintComment.Expression = "Iif(IsNullOrEmpty([Comment]), '', 'Comment: ' + [Comment])"
            Me.ProdPrintComment.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProdPrintComment.Name = "ProdPrintComment"
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooter_InvoiceForeignCurrencyTotal, Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel, Me.LineGroupFooter_2, Me.LabelGroupFooter_InvoiceTotal, Me.LineGroupFooter_1, Me.LabelGroupFooter_InvoiceTotalLabel})
            Me.GroupFooter.HeightF = 43.83329!
            Me.GroupFooter.Name = "GroupFooter"
            Me.GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'LabelGroupFooter_InvoiceForeignCurrencyTotal
            '
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.BorderWidth = 1.0!
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.CanGrow = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.LocationFloat = New DevExpress.Utils.PointFloat(367.4997!, 22.99999!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.Name = "LabelGroupFooter_InvoiceForeignCurrencyTotal"
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.SizeF = New System.Drawing.SizeF(98.12491!, 19.0!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.StylePriority.UseFont = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooter_InvoiceForeignCurrencyTotalLabel
            '
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.BorderWidth = 1.0!
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.CanGrow = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 22.99999!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.Name = "LabelGroupFooter_InvoiceForeignCurrencyTotalLabel"
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.SizeF = New System.Drawing.SizeF(115.62!, 19.0!)
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.StylePriority.UseFont = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineGroupFooter_2
            '
            Me.LineGroupFooter_2.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooter_2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooter_2.BorderWidth = 0!
            Me.LineGroupFooter_2.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupFooter_2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.LineGroupFooter_2.Name = "LineGroupFooter_2"
            Me.LineGroupFooter_2.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupFooter_2.StylePriority.UseBorderColor = False
            Me.LineGroupFooter_2.StylePriority.UseBorderWidth = False
            Me.LineGroupFooter_2.StylePriority.UseForeColor = False
            '
            'LabelGroupFooter_InvoiceTotal
            '
            Me.LabelGroupFooter_InvoiceTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooter_InvoiceTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooter_InvoiceTotal.BorderWidth = 1.0!
            Me.LabelGroupFooter_InvoiceTotal.CanGrow = False
            Me.LabelGroupFooter_InvoiceTotal.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooter_InvoiceTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceTotal.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 4.0!)
            Me.LabelGroupFooter_InvoiceTotal.Name = "LabelGroupFooter_InvoiceTotal"
            Me.LabelGroupFooter_InvoiceTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooter_InvoiceTotal.SizeF = New System.Drawing.SizeF(98.12491!, 19.0!)
            Me.LabelGroupFooter_InvoiceTotal.StylePriority.UseFont = False
            Me.LabelGroupFooter_InvoiceTotal.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooter_InvoiceTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineGroupFooter_1
            '
            Me.LineGroupFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooter_1.BorderWidth = 0!
            Me.LineGroupFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupFooter_1.Name = "LineGroupFooter_1"
            Me.LineGroupFooter_1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupFooter_1.StylePriority.UseBorderColor = False
            Me.LineGroupFooter_1.StylePriority.UseBorderWidth = False
            Me.LineGroupFooter_1.StylePriority.UseForeColor = False
            '
            'LabelGroupFooter_InvoiceTotalLabel
            '
            Me.LabelGroupFooter_InvoiceTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooter_InvoiceTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooter_InvoiceTotalLabel.BorderWidth = 1.0!
            Me.LabelGroupFooter_InvoiceTotalLabel.CanGrow = False
            Me.LabelGroupFooter_InvoiceTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooter_InvoiceTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooter_InvoiceTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.0!)
            Me.LabelGroupFooter_InvoiceTotalLabel.Name = "LabelGroupFooter_InvoiceTotalLabel"
            Me.LabelGroupFooter_InvoiceTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooter_InvoiceTotalLabel.SizeF = New System.Drawing.SizeF(115.62!, 19.0!)
            Me.LabelGroupFooter_InvoiceTotalLabel.StylePriority.UseFont = False
            Me.LabelGroupFooter_InvoiceTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooter_InvoiceTotalLabel.Text = "Invoice Total:"
            Me.LabelGroupFooter_InvoiceTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader
            '
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 68.75!
            Me.GroupHeader.Name = "GroupHeader"
            Me.GroupHeader.Visible = False
            '
            'DetailReportMagazine
            '
            Me.DetailReportMagazine.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailMagazine, Me.GroupHeaderMagazine, Me.GroupFooterMagazine})
            Me.DetailReportMagazine.DataSource = Me.BindingSourceMagazine
            Me.DetailReportMagazine.Level = 2
            Me.DetailReportMagazine.Name = "DetailReportMagazine"
            '
            'DetailMagazine
            '
            Me.DetailMagazine.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailMagazine_OrderLine, Me.LabelDetailMagazine_CDP, Me.LabelDetailMagazine_GLDescription, Me.LabelDetailMagazine_GLACode, Me.LabelDetailMagazine_TaxCode, Me.LabelDetailMagazine_DisbursedAmount})
            Me.DetailMagazine.HeightF = 23.0!
            Me.DetailMagazine.Name = "DetailMagazine"
            '
            'LabelDetailMagazine_OrderLine
            '
            Me.LabelDetailMagazine_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MagOrderLine")})
            Me.LabelDetailMagazine_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailMagazine_OrderLine.Name = "LabelDetailMagazine_OrderLine"
            Me.LabelDetailMagazine_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_OrderLine.SizeF = New System.Drawing.SizeF(83.33319!, 23.0!)
            Me.LabelDetailMagazine_OrderLine.Text = "LabelDetailMagazine_OrderLine"
            '
            'LabelDetailMagazine_CDP
            '
            Me.LabelDetailMagazine_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MagCDP")})
            Me.LabelDetailMagazine_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailMagazine_CDP.Name = "LabelDetailMagazine_CDP"
            Me.LabelDetailMagazine_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 23.0!)
            Me.LabelDetailMagazine_CDP.Text = "LabelDetailMagazine_CDP"
            '
            'LabelDetailMagazine_GLDescription
            '
            Me.LabelDetailMagazine_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeDescription")})
            Me.LabelDetailMagazine_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 0!)
            Me.LabelDetailMagazine_GLDescription.Name = "LabelDetailMagazine_GLDescription"
            Me.LabelDetailMagazine_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_GLDescription.SizeF = New System.Drawing.SizeF(232.5001!, 23.0!)
            Me.LabelDetailMagazine_GLDescription.Text = "LabelDetailMagazine_GLDescription"
            '
            'LabelDetailMagazine_GLACode
            '
            Me.LabelDetailMagazine_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailMagazine_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailMagazine_GLACode.Name = "LabelDetailMagazine_GLACode"
            Me.LabelDetailMagazine_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailMagazine_GLACode.Text = "LabelDetailMagazine_GLACode"
            '
            'LabelDetailMagazine_TaxCode
            '
            Me.LabelDetailMagazine_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailMagazine_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 0!)
            Me.LabelDetailMagazine_TaxCode.Name = "LabelDetailMagazine_TaxCode"
            Me.LabelDetailMagazine_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_TaxCode.SizeF = New System.Drawing.SizeF(56.25018!, 23.0!)
            Me.LabelDetailMagazine_TaxCode.Text = "LabelDetailMagazine_TaxCode"
            '
            'LabelDetailMagazine_DisbursedAmount
            '
            Me.LabelDetailMagazine_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailMagazine_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailMagazine_DisbursedAmount.Name = "LabelDetailMagazine_DisbursedAmount"
            Me.LabelDetailMagazine_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailMagazine_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12491!, 23.0!)
            Me.LabelDetailMagazine_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailMagazine_DisbursedAmount.Text = "LabelDetailMagazine_DisbursedAmount"
            Me.LabelDetailMagazine_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeaderMagazine
            '
            Me.GroupHeaderMagazine.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderMagazine_TaxCode, Me.LabelGroupHeaderMagazine_OrderLine, Me.LabelGroupHeaderMagazine_CDP, Me.LabelGroupHeaderMagazine_GLDescription, Me.LabelGroupHeaderMagazine_GLAccount, Me.LineGroupHeaderMagazine_Top, Me.LabelGroupHeaderMagazine_Amount, Me.LabelGroupHeaderMagazine_Magazine, Me.LineGroupHeaderMagazine_Bottom})
            Me.GroupHeaderMagazine.HeightF = 44.0!
            Me.GroupHeaderMagazine.Name = "GroupHeaderMagazine"
            '
            'LabelGroupHeaderMagazine_TaxCode
            '
            Me.LabelGroupHeaderMagazine_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_TaxCode.CanGrow = False
            Me.LabelGroupHeaderMagazine_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 4.000004!)
            Me.LabelGroupHeaderMagazine_TaxCode.Name = "LabelGroupHeaderMagazine_TaxCode"
            Me.LabelGroupHeaderMagazine_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderMagazine_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderMagazine_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderMagazine_OrderLine
            '
            Me.LabelGroupHeaderMagazine_OrderLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_OrderLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_OrderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_OrderLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_OrderLine.CanGrow = False
            Me.LabelGroupHeaderMagazine_OrderLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_OrderLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 4.000004!)
            Me.LabelGroupHeaderMagazine_OrderLine.Name = "LabelGroupHeaderMagazine_OrderLine"
            Me.LabelGroupHeaderMagazine_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_OrderLine.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderMagazine_OrderLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_OrderLine.Text = "Order/Line"
            Me.LabelGroupHeaderMagazine_OrderLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderMagazine_CDP
            '
            Me.LabelGroupHeaderMagazine_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_CDP.CanGrow = False
            Me.LabelGroupHeaderMagazine_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 4.000004!)
            Me.LabelGroupHeaderMagazine_CDP.Name = "LabelGroupHeaderMagazine_CDP"
            Me.LabelGroupHeaderMagazine_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderMagazine_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderMagazine_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderMagazine_GLDescription
            '
            Me.LabelGroupHeaderMagazine_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_GLDescription.CanGrow = False
            Me.LabelGroupHeaderMagazine_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 4.000004!)
            Me.LabelGroupHeaderMagazine_GLDescription.Name = "LabelGroupHeaderMagazine_GLDescription"
            Me.LabelGroupHeaderMagazine_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderMagazine_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_GLDescription.Text = "Description"
            Me.LabelGroupHeaderMagazine_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderMagazine_GLAccount
            '
            Me.LabelGroupHeaderMagazine_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_GLAccount.CanGrow = False
            Me.LabelGroupHeaderMagazine_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(24.99986!, 4.000004!)
            Me.LabelGroupHeaderMagazine_GLAccount.Name = "LabelGroupHeaderMagazine_GLAccount"
            Me.LabelGroupHeaderMagazine_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderMagazine_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderMagazine_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderMagazine_Top
            '
            Me.LineGroupHeaderMagazine_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderMagazine_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderMagazine_Top.BorderWidth = 0!
            Me.LineGroupHeaderMagazine_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderMagazine_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderMagazine_Top.Name = "LineGroupHeaderMagazine_Top"
            Me.LineGroupHeaderMagazine_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderMagazine_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderMagazine_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderMagazine_Top.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderMagazine_Amount
            '
            Me.LabelGroupHeaderMagazine_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_Amount.CanGrow = False
            Me.LabelGroupHeaderMagazine_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderMagazine_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 4.000004!)
            Me.LabelGroupHeaderMagazine_Amount.Name = "LabelGroupHeaderMagazine_Amount"
            Me.LabelGroupHeaderMagazine_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderMagazine_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderMagazine_Amount.Text = "Amount"
            Me.LabelGroupHeaderMagazine_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderMagazine_Magazine
            '
            Me.LabelGroupHeaderMagazine_Magazine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderMagazine_Magazine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_Magazine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderMagazine_Magazine.BorderWidth = 1.0!
            Me.LabelGroupHeaderMagazine_Magazine.CanGrow = False
            Me.LabelGroupHeaderMagazine_Magazine.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderMagazine_Magazine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderMagazine_Magazine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.0!)
            Me.LabelGroupHeaderMagazine_Magazine.Name = "LabelGroupHeaderMagazine_Magazine"
            Me.LabelGroupHeaderMagazine_Magazine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderMagazine_Magazine.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderMagazine_Magazine.StylePriority.UseFont = False
            Me.LabelGroupHeaderMagazine_Magazine.Text = "Magazine"
            Me.LabelGroupHeaderMagazine_Magazine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderMagazine_Bottom
            '
            Me.LineGroupHeaderMagazine_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderMagazine_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderMagazine_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderMagazine_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderMagazine_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.0!)
            Me.LineGroupHeaderMagazine_Bottom.Name = "LineGroupHeaderMagazine_Bottom"
            Me.LineGroupHeaderMagazine_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderMagazine_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderMagazine_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderMagazine_Bottom.StylePriority.UseForeColor = False
            '
            'GroupFooterMagazine
            '
            Me.GroupFooterMagazine.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterMagazine_DisbursedAmount, Me.LabelGroupFooterMagazine_Total})
            Me.GroupFooterMagazine.HeightF = 23.0!
            Me.GroupFooterMagazine.Name = "GroupFooterMagazine"
            '
            'LabelGroupFooterMagazine_DisbursedAmount
            '
            Me.LabelGroupFooterMagazine_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:c2}")})
            Me.LabelGroupFooterMagazine_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterMagazine_DisbursedAmount.Name = "LabelGroupFooterMagazine_DisbursedAmount"
            Me.LabelGroupFooterMagazine_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterMagazine_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12491!, 23.0!)
            Me.LabelGroupFooterMagazine_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterMagazine_DisbursedAmount.Summary = XrSummary3
            Me.LabelGroupFooterMagazine_DisbursedAmount.Text = "LabelGroupFooterMagazine_DisbursedAmount"
            Me.LabelGroupFooterMagazine_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterMagazine_Total
            '
            Me.LabelGroupFooterMagazine_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterMagazine_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterMagazine_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterMagazine_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterMagazine_Total.CanGrow = False
            Me.LabelGroupFooterMagazine_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterMagazine_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterMagazine_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterMagazine_Total.Name = "LabelGroupFooterMagazine_Total"
            Me.LabelGroupFooterMagazine_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterMagazine_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterMagazine_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterMagazine_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterMagazine_Total.Text = "Magazine Total:"
            Me.LabelGroupFooterMagazine_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceMagazine
            '
            Me.BindingSourceMagazine.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail)
            '
            'MagCDP
            '
            Me.MagCDP.DataSource = Me.BindingSourceMagazine
            Me.MagCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.MagCDP.Name = "MagCDP"
            '
            'MagOrderLine
            '
            Me.MagOrderLine.DataSource = Me.BindingSourceMagazine
            Me.MagOrderLine.Expression = "PadLeft([OrderNumber], 6, '0') + '-' + PadLeft([OrderLineNumber], 3, '0')"
            Me.MagOrderLine.Name = "MagOrderLine"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)
            '
            'DetailReportNewspaper
            '
            Me.DetailReportNewspaper.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailNewspaper, Me.GroupHeaderNewspaper, Me.GroupFooterNewspaper})
            Me.DetailReportNewspaper.DataSource = Me.BindingSourceNewspaper
            Me.DetailReportNewspaper.Level = 3
            Me.DetailReportNewspaper.Name = "DetailReportNewspaper"
            '
            'DetailNewspaper
            '
            Me.DetailNewspaper.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailNewspaper_GLDescription, Me.LabelDetailNewspaper_GLACode, Me.LabelDetailNewspaper_TaxCode, Me.LabelDetailNewspaper_OrderLine, Me.LabelDetailNewspaper_CDP, Me.LabelDetailNewspaper_DisbursedAmount})
            Me.DetailNewspaper.HeightF = 23.0!
            Me.DetailNewspaper.Name = "DetailNewspaper"
            '
            'LabelDetailNewspaper_GLDescription
            '
            Me.LabelDetailNewspaper_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailNewspaper_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailNewspaper_GLDescription.Name = "LabelDetailNewspaper_GLDescription"
            Me.LabelDetailNewspaper_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailNewspaper_GLDescription.Text = "LabelDetailNewspaper_GLDescription"
            '
            'LabelDetailNewspaper_GLACode
            '
            Me.LabelDetailNewspaper_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailNewspaper_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailNewspaper_GLACode.Name = "LabelDetailNewspaper_GLACode"
            Me.LabelDetailNewspaper_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailNewspaper_GLACode.Text = "LabelDetailNewspaper_GLACode"
            '
            'LabelDetailNewspaper_TaxCode
            '
            Me.LabelDetailNewspaper_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSourceMagazine, "SalesTaxCode")})
            Me.LabelDetailNewspaper_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 0!)
            Me.LabelDetailNewspaper_TaxCode.Name = "LabelDetailNewspaper_TaxCode"
            Me.LabelDetailNewspaper_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_TaxCode.SizeF = New System.Drawing.SizeF(56.24994!, 23.0!)
            Me.LabelDetailNewspaper_TaxCode.Text = "LabelDetailNewspaper_TaxCode"
            '
            'LabelDetailNewspaper_OrderLine
            '
            Me.LabelDetailNewspaper_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewsOrderLine")})
            Me.LabelDetailNewspaper_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailNewspaper_OrderLine.Name = "LabelDetailNewspaper_OrderLine"
            Me.LabelDetailNewspaper_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_OrderLine.SizeF = New System.Drawing.SizeF(83.33331!, 23.0!)
            Me.LabelDetailNewspaper_OrderLine.Text = "LabelDetailNewspaper_OrderLine"
            '
            'LabelDetailNewspaper_CDP
            '
            Me.LabelDetailNewspaper_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewsCDP")})
            Me.LabelDetailNewspaper_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailNewspaper_CDP.Name = "LabelDetailNewspaper_CDP"
            Me.LabelDetailNewspaper_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 23.0!)
            Me.LabelDetailNewspaper_CDP.Text = "LabelDetailNewspaper_CDP"
            '
            'LabelDetailNewspaper_DisbursedAmount
            '
            Me.LabelDetailNewspaper_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailNewspaper_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailNewspaper_DisbursedAmount.Name = "LabelDetailNewspaper_DisbursedAmount"
            Me.LabelDetailNewspaper_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNewspaper_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12488!, 23.0!)
            Me.LabelDetailNewspaper_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailNewspaper_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeaderNewspaper
            '
            Me.GroupHeaderNewspaper.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupHeaderNewspaper_Top, Me.LabelGroupHeaderNewspaper_Newspaper, Me.LabelGroupHeaderNewspaper_Amount, Me.LineGroupHeaderNewspaper_Bottom, Me.LabelGroupHeaderNewspaper_GLAccount, Me.LabelGroupHeaderNewspaper_GLDescription, Me.LabelGroupHeaderNewspaper_CDP, Me.LabelGroupHeaderNewspaper_OrderLine, Me.LabelGroupHeaderNewspaper_TaxCode})
            Me.GroupHeaderNewspaper.HeightF = 44.00002!
            Me.GroupHeaderNewspaper.Name = "GroupHeaderNewspaper"
            '
            'LineGroupHeaderNewspaper_Top
            '
            Me.LineGroupHeaderNewspaper_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNewspaper_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNewspaper_Top.BorderWidth = 0!
            Me.LineGroupHeaderNewspaper_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNewspaper_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderNewspaper_Top.Name = "LineGroupHeaderNewspaper_Top"
            Me.LineGroupHeaderNewspaper_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderNewspaper_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNewspaper_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNewspaper_Top.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderNewspaper_Newspaper
            '
            Me.LabelGroupHeaderNewspaper_Newspaper.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_Newspaper.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_Newspaper.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_Newspaper.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_Newspaper.CanGrow = False
            Me.LabelGroupHeaderNewspaper_Newspaper.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderNewspaper_Newspaper.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_Newspaper.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.00002!)
            Me.LabelGroupHeaderNewspaper_Newspaper.Name = "LabelGroupHeaderNewspaper_Newspaper"
            Me.LabelGroupHeaderNewspaper_Newspaper.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_Newspaper.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderNewspaper_Newspaper.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_Newspaper.Text = "Newspaper"
            Me.LabelGroupHeaderNewspaper_Newspaper.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNewspaper_Amount
            '
            Me.LabelGroupHeaderNewspaper_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_Amount.CanGrow = False
            Me.LabelGroupHeaderNewspaper_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_Amount.Name = "LabelGroupHeaderNewspaper_Amount"
            Me.LabelGroupHeaderNewspaper_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderNewspaper_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderNewspaper_Amount.Text = "Amount"
            Me.LabelGroupHeaderNewspaper_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineGroupHeaderNewspaper_Bottom
            '
            Me.LineGroupHeaderNewspaper_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNewspaper_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNewspaper_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderNewspaper_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNewspaper_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
            Me.LineGroupHeaderNewspaper_Bottom.Name = "LineGroupHeaderNewspaper_Bottom"
            Me.LineGroupHeaderNewspaper_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderNewspaper_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNewspaper_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNewspaper_Bottom.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderNewspaper_GLAccount
            '
            Me.LabelGroupHeaderNewspaper_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_GLAccount.CanGrow = False
            Me.LabelGroupHeaderNewspaper_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(24.99986!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_GLAccount.Name = "LabelGroupHeaderNewspaper_GLAccount"
            Me.LabelGroupHeaderNewspaper_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNewspaper_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderNewspaper_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNewspaper_GLDescription
            '
            Me.LabelGroupHeaderNewspaper_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_GLDescription.CanGrow = False
            Me.LabelGroupHeaderNewspaper_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_GLDescription.Name = "LabelGroupHeaderNewspaper_GLDescription"
            Me.LabelGroupHeaderNewspaper_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNewspaper_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_GLDescription.Text = "Description"
            Me.LabelGroupHeaderNewspaper_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNewspaper_CDP
            '
            Me.LabelGroupHeaderNewspaper_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_CDP.CanGrow = False
            Me.LabelGroupHeaderNewspaper_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_CDP.Name = "LabelGroupHeaderNewspaper_CDP"
            Me.LabelGroupHeaderNewspaper_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderNewspaper_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderNewspaper_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNewspaper_OrderLine
            '
            Me.LabelGroupHeaderNewspaper_OrderLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_OrderLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_OrderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_OrderLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_OrderLine.CanGrow = False
            Me.LabelGroupHeaderNewspaper_OrderLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_OrderLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_OrderLine.Name = "LabelGroupHeaderNewspaper_OrderLine"
            Me.LabelGroupHeaderNewspaper_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_OrderLine.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderNewspaper_OrderLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_OrderLine.Text = "Order/Line"
            Me.LabelGroupHeaderNewspaper_OrderLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNewspaper_TaxCode
            '
            Me.LabelGroupHeaderNewspaper_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNewspaper_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNewspaper_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderNewspaper_TaxCode.CanGrow = False
            Me.LabelGroupHeaderNewspaper_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNewspaper_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNewspaper_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 4.000004!)
            Me.LabelGroupHeaderNewspaper_TaxCode.Name = "LabelGroupHeaderNewspaper_TaxCode"
            Me.LabelGroupHeaderNewspaper_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNewspaper_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderNewspaper_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderNewspaper_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderNewspaper_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterNewspaper
            '
            Me.GroupFooterNewspaper.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterNewspaper_DisbursedAmount, Me.LabelGroupFooterNewspaper_Total})
            Me.GroupFooterNewspaper.HeightF = 23.0!
            Me.GroupFooterNewspaper.Name = "GroupFooterNewspaper"
            '
            'LabelGroupFooterNewspaper_DisbursedAmount
            '
            Me.LabelGroupFooterNewspaper_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount")})
            Me.LabelGroupFooterNewspaper_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterNewspaper_DisbursedAmount.Name = "LabelGroupFooterNewspaper_DisbursedAmount"
            Me.LabelGroupFooterNewspaper_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterNewspaper_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12488!, 23.0!)
            Me.LabelGroupFooterNewspaper_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:c2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterNewspaper_DisbursedAmount.Summary = XrSummary4
            Me.LabelGroupFooterNewspaper_DisbursedAmount.Text = "LabelGroupFooterNewspaper_DisbursedAmount"
            Me.LabelGroupFooterNewspaper_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterNewspaper_Total
            '
            Me.LabelGroupFooterNewspaper_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterNewspaper_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNewspaper_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterNewspaper_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterNewspaper_Total.CanGrow = False
            Me.LabelGroupFooterNewspaper_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterNewspaper_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNewspaper_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterNewspaper_Total.Name = "LabelGroupFooterNewspaper_Total"
            Me.LabelGroupFooterNewspaper_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterNewspaper_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterNewspaper_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterNewspaper_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterNewspaper_Total.Text = "Newspaper Total:"
            Me.LabelGroupFooterNewspaper_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceNewspaper
            '
            Me.BindingSourceNewspaper.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail)
            '
            'NewsCDP
            '
            Me.NewsCDP.DataSource = Me.BindingSourceNewspaper
            Me.NewsCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.NewsCDP.Name = "NewsCDP"
            '
            'NewsOrderLine
            '
            Me.NewsOrderLine.DataSource = Me.BindingSourceNewspaper
            Me.NewsOrderLine.Expression = "PadLeft([OrderNumber], 6, '0') + '-' + PadLeft([OrderLineNumber], 3, '0')"
            Me.NewsOrderLine.Name = "NewsOrderLine"
            '
            'DetailReportInternet
            '
            Me.DetailReportInternet.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailInternet, Me.GroupHeaderInternet, Me.GroupFooterInternet})
            Me.DetailReportInternet.DataSource = Me.BindingSourceInternet
            Me.DetailReportInternet.Level = 4
            Me.DetailReportInternet.Name = "DetailReportInternet"
            '
            'DetailInternet
            '
            Me.DetailInternet.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailInternet_TaxCode, Me.LabelDetailInternet_OrderLine, Me.LabelDetailInternet_GLDescription, Me.LabelDetailInternet_GLACode, Me.LabelDetailInternet_CDP, Me.LabelDetailInternet_DisbursedAmount})
            Me.DetailInternet.HeightF = 23.0!
            Me.DetailInternet.Name = "DetailInternet"
            '
            'LabelDetailInternet_TaxCode
            '
            Me.LabelDetailInternet_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailInternet_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 0!)
            Me.LabelDetailInternet_TaxCode.Name = "LabelDetailInternet_TaxCode"
            Me.LabelDetailInternet_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_TaxCode.SizeF = New System.Drawing.SizeF(56.25018!, 23.0!)
            Me.LabelDetailInternet_TaxCode.Text = "LabelDetailInternet_TaxCode"
            '
            'LabelDetailInternet_OrderLine
            '
            Me.LabelDetailInternet_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InternetOrderLine")})
            Me.LabelDetailInternet_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailInternet_OrderLine.Name = "LabelDetailInternet_OrderLine"
            Me.LabelDetailInternet_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_OrderLine.SizeF = New System.Drawing.SizeF(83.54193!, 23.0!)
            Me.LabelDetailInternet_OrderLine.Text = "LabelDetailInternet_OrderLine"
            '
            'LabelDetailInternet_GLDescription
            '
            Me.LabelDetailInternet_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailInternet_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailInternet_GLDescription.Name = "LabelDetailInternet_GLDescription"
            Me.LabelDetailInternet_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailInternet_GLDescription.Text = "LabelDetailInternet_GLDescription"
            '
            'LabelDetailInternet_GLACode
            '
            Me.LabelDetailInternet_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailInternet_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailInternet_GLACode.Name = "LabelDetailInternet_GLACode"
            Me.LabelDetailInternet_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailInternet_GLACode.Text = "LabelDetailInternet_GLACode"
            '
            'LabelDetailInternet_CDP
            '
            Me.LabelDetailInternet_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InternetCDP")})
            Me.LabelDetailInternet_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailInternet_CDP.Name = "LabelDetailInternet_CDP"
            Me.LabelDetailInternet_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_CDP.SizeF = New System.Drawing.SizeF(130.2082!, 23.0!)
            Me.LabelDetailInternet_CDP.Text = "LabelDetailInternet_CDP"
            '
            'LabelDetailInternet_DisbursedAmount
            '
            Me.LabelDetailInternet_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailInternet_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailInternet_DisbursedAmount.Name = "LabelDetailInternet_DisbursedAmount"
            Me.LabelDetailInternet_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailInternet_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12469!, 23.0!)
            Me.LabelDetailInternet_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailInternet_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeaderInternet
            '
            Me.GroupHeaderInternet.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderInternet_TaxCode, Me.LabelGroupHeaderInternet_OrderLine, Me.LabelGroupHeaderInternet_CDP, Me.LabelGroupHeaderInternet_GLDescription, Me.LabelGroupHeaderInternet_GLAccount, Me.LineGroupHeaderInternet_Bottom, Me.LabelGroupHeaderInternet_Amount, Me.LabelGroupHeaderInternet_Internet, Me.LineGroupHeaderInternet_Top})
            Me.GroupHeaderInternet.HeightF = 44.0!
            Me.GroupHeaderInternet.Name = "GroupHeaderInternet"
            '
            'LabelGroupHeaderInternet_TaxCode
            '
            Me.LabelGroupHeaderInternet_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_TaxCode.CanGrow = False
            Me.LabelGroupHeaderInternet_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7497!, 4.000004!)
            Me.LabelGroupHeaderInternet_TaxCode.Name = "LabelGroupHeaderInternet_TaxCode"
            Me.LabelGroupHeaderInternet_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderInternet_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderInternet_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderInternet_OrderLine
            '
            Me.LabelGroupHeaderInternet_OrderLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_OrderLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_OrderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_OrderLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_OrderLine.CanGrow = False
            Me.LabelGroupHeaderInternet_OrderLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_OrderLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3748!, 4.000004!)
            Me.LabelGroupHeaderInternet_OrderLine.Name = "LabelGroupHeaderInternet_OrderLine"
            Me.LabelGroupHeaderInternet_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_OrderLine.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderInternet_OrderLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_OrderLine.Text = "Order/Line"
            Me.LabelGroupHeaderInternet_OrderLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderInternet_CDP
            '
            Me.LabelGroupHeaderInternet_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_CDP.CanGrow = False
            Me.LabelGroupHeaderInternet_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7498!, 4.000004!)
            Me.LabelGroupHeaderInternet_CDP.Name = "LabelGroupHeaderInternet_CDP"
            Me.LabelGroupHeaderInternet_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderInternet_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderInternet_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderInternet_GLDescription
            '
            Me.LabelGroupHeaderInternet_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_GLDescription.CanGrow = False
            Me.LabelGroupHeaderInternet_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9998!, 4.000004!)
            Me.LabelGroupHeaderInternet_GLDescription.Name = "LabelGroupHeaderInternet_GLDescription"
            Me.LabelGroupHeaderInternet_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderInternet_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_GLDescription.Text = "Description"
            Me.LabelGroupHeaderInternet_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderInternet_GLAccount
            '
            Me.LabelGroupHeaderInternet_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_GLAccount.CanGrow = False
            Me.LabelGroupHeaderInternet_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(24.99971!, 4.000004!)
            Me.LabelGroupHeaderInternet_GLAccount.Name = "LabelGroupHeaderInternet_GLAccount"
            Me.LabelGroupHeaderInternet_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderInternet_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderInternet_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderInternet_Bottom
            '
            Me.LineGroupHeaderInternet_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderInternet_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderInternet_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderInternet_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderInternet_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.0!)
            Me.LineGroupHeaderInternet_Bottom.Name = "LineGroupHeaderInternet_Bottom"
            Me.LineGroupHeaderInternet_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderInternet_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderInternet_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderInternet_Bottom.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderInternet_Amount
            '
            Me.LabelGroupHeaderInternet_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_Amount.CanGrow = False
            Me.LabelGroupHeaderInternet_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderInternet_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5398!, 4.000004!)
            Me.LabelGroupHeaderInternet_Amount.Name = "LabelGroupHeaderInternet_Amount"
            Me.LabelGroupHeaderInternet_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderInternet_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderInternet_Amount.Text = "Amount"
            Me.LabelGroupHeaderInternet_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderInternet_Internet
            '
            Me.LabelGroupHeaderInternet_Internet.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderInternet_Internet.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_Internet.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderInternet_Internet.BorderWidth = 1.0!
            Me.LabelGroupHeaderInternet_Internet.CanGrow = False
            Me.LabelGroupHeaderInternet_Internet.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderInternet_Internet.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderInternet_Internet.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.0!)
            Me.LabelGroupHeaderInternet_Internet.Name = "LabelGroupHeaderInternet_Internet"
            Me.LabelGroupHeaderInternet_Internet.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderInternet_Internet.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderInternet_Internet.StylePriority.UseFont = False
            Me.LabelGroupHeaderInternet_Internet.Text = "Internet"
            Me.LabelGroupHeaderInternet_Internet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderInternet_Top
            '
            Me.LineGroupHeaderInternet_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderInternet_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderInternet_Top.BorderWidth = 0!
            Me.LineGroupHeaderInternet_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderInternet_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderInternet_Top.Name = "LineGroupHeaderInternet_Top"
            Me.LineGroupHeaderInternet_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderInternet_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderInternet_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderInternet_Top.StylePriority.UseForeColor = False
            '
            'GroupFooterInternet
            '
            Me.GroupFooterInternet.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterInternet_Total, Me.LabelGroupFooterInternet_DisbursedAmount})
            Me.GroupFooterInternet.HeightF = 23.0!
            Me.GroupFooterInternet.Name = "GroupFooterInternet"
            '
            'LabelGroupFooterInternet_Total
            '
            Me.LabelGroupFooterInternet_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterInternet_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterInternet_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterInternet_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterInternet_Total.CanGrow = False
            Me.LabelGroupFooterInternet_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterInternet_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterInternet_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterInternet_Total.Name = "LabelGroupFooterInternet_Total"
            Me.LabelGroupFooterInternet_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterInternet_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterInternet_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterInternet_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterInternet_Total.Text = "Internet Total:"
            Me.LabelGroupFooterInternet_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterInternet_DisbursedAmount
            '
            Me.LabelGroupFooterInternet_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount")})
            Me.LabelGroupFooterInternet_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterInternet_DisbursedAmount.Name = "LabelGroupFooterInternet_DisbursedAmount"
            Me.LabelGroupFooterInternet_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterInternet_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12473!, 23.0!)
            Me.LabelGroupFooterInternet_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:c2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterInternet_DisbursedAmount.Summary = XrSummary5
            Me.LabelGroupFooterInternet_DisbursedAmount.Text = "LabelGroupFooterInternet_DisbursedAmount"
            Me.LabelGroupFooterInternet_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceInternet
            '
            Me.BindingSourceInternet.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail)
            '
            'InternetCDP
            '
            Me.InternetCDP.DataSource = Me.BindingSourceInternet
            Me.InternetCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.InternetCDP.Name = "InternetCDP"
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083347!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.PageInfo_Pages.TextFormatString = "Page {0} of {1}"
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
            Me.LinePageFooter.LineWidth = 4.0!
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
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
            'InternetOrderLine
            '
            Me.InternetOrderLine.DataSource = Me.BindingSourceInternet
            Me.InternetOrderLine.Expression = "PadLeft([InternetOrderNumber], 6, '0') + '-' + PadLeft([InternetDetailLineNumber]" &
    ", 3, '0')"
            Me.InternetOrderLine.Name = "InternetOrderLine"
            '
            'DetailReportOutOfHome
            '
            Me.DetailReportOutOfHome.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailOutOfHome, Me.GroupHeaderOutOfHome, Me.GroupFooterOutOfHome})
            Me.DetailReportOutOfHome.DataSource = Me.BindingSourceOutOfHome
            Me.DetailReportOutOfHome.Level = 5
            Me.DetailReportOutOfHome.Name = "DetailReportOutOfHome"
            '
            'DetailOutOfHome
            '
            Me.DetailOutOfHome.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailOutOfHome_TaxCode, Me.LabelDetailOutOfHome_OrderLine, Me.LabelDetailOutOfHome_CDP, Me.LabelDetailOutOfHome_DisbursedAmount, Me.LabelDetailOutOfHome_GLDescription, Me.LabelDetailOutOfHome_GLACode})
            Me.DetailOutOfHome.HeightF = 23.0!
            Me.DetailOutOfHome.Name = "DetailOutOfHome"
            '
            'LabelDetailOutOfHome_TaxCode
            '
            Me.LabelDetailOutOfHome_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailOutOfHome_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7497!, 0!)
            Me.LabelDetailOutOfHome_TaxCode.Name = "LabelDetailOutOfHome_TaxCode"
            Me.LabelDetailOutOfHome_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_TaxCode.SizeF = New System.Drawing.SizeF(55.25037!, 23.0!)
            Me.LabelDetailOutOfHome_TaxCode.Text = "LabelDetailOutOfHome_TaxCode"
            '
            'LabelDetailOutOfHome_OrderLine
            '
            Me.LabelDetailOutOfHome_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OutOfHomeOrderLine")})
            Me.LabelDetailOutOfHome_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailOutOfHome_OrderLine.Name = "LabelDetailOutOfHome_OrderLine"
            Me.LabelDetailOutOfHome_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_OrderLine.SizeF = New System.Drawing.SizeF(83.33319!, 23.0!)
            Me.LabelDetailOutOfHome_OrderLine.Text = "LabelDetailOutOfHome_OrderLine"
            '
            'LabelDetailOutOfHome_CDP
            '
            Me.LabelDetailOutOfHome_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OutOfHomeCDP")})
            Me.LabelDetailOutOfHome_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailOutOfHome_CDP.Name = "LabelDetailOutOfHome_CDP"
            Me.LabelDetailOutOfHome_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_CDP.SizeF = New System.Drawing.SizeF(130.2082!, 23.0!)
            Me.LabelDetailOutOfHome_CDP.Text = "LabelDetailOutOfHome_CDP"
            '
            'LabelDetailOutOfHome_DisbursedAmount
            '
            Me.LabelDetailOutOfHome_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailOutOfHome_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailOutOfHome_DisbursedAmount.Name = "LabelDetailOutOfHome_DisbursedAmount"
            Me.LabelDetailOutOfHome_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12466!, 23.0!)
            Me.LabelDetailOutOfHome_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailOutOfHome_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailOutOfHome_GLDescription
            '
            Me.LabelDetailOutOfHome_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailOutOfHome_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailOutOfHome_GLDescription.Name = "LabelDetailOutOfHome_GLDescription"
            Me.LabelDetailOutOfHome_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailOutOfHome_GLDescription.Text = "LabelDetailOutOfHome_GLDescription"
            '
            'LabelDetailOutOfHome_GLACode
            '
            Me.LabelDetailOutOfHome_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailOutOfHome_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.LabelDetailOutOfHome_GLACode.Name = "LabelDetailOutOfHome_GLACode"
            Me.LabelDetailOutOfHome_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOutOfHome_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailOutOfHome_GLACode.Text = "LabelDetailOutOfHome_GLACode"
            '
            'GroupHeaderOutOfHome
            '
            Me.GroupHeaderOutOfHome.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupHeaderOutofHomeTop, Me.LineGroupHeaderOutofHomeBottom, Me.LabelGroupHeaderOutOfHome_Amount, Me.LabelGroupHeaderOutOfHome_OutOfHome, Me.LabelGroupHeaderOutOfHome_GLAccount, Me.LabelGroupHeaderOutOfHome_GLDescription, Me.LabelGroupHeaderOutOfHome_CDP, Me.LabelGroupHeaderOutOfHome_OrderLine, Me.LabelGroupHeaderOutOfHome_TaxCode})
            Me.GroupHeaderOutOfHome.HeightF = 44.0!
            Me.GroupHeaderOutOfHome.Name = "GroupHeaderOutOfHome"
            '
            'LineGroupHeaderOutofHomeTop
            '
            Me.LineGroupHeaderOutofHomeTop.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOutofHomeTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderOutofHomeTop.BorderWidth = 0!
            Me.LineGroupHeaderOutofHomeTop.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderOutofHomeTop.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderOutofHomeTop.Name = "LineGroupHeaderOutofHomeTop"
            Me.LineGroupHeaderOutofHomeTop.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderOutofHomeTop.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderOutofHomeTop.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderOutofHomeTop.StylePriority.UseForeColor = False
            '
            'LineGroupHeaderOutofHomeBottom
            '
            Me.LineGroupHeaderOutofHomeBottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOutofHomeBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderOutofHomeBottom.BorderWidth = 0!
            Me.LineGroupHeaderOutofHomeBottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderOutofHomeBottom.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 23.0!)
            Me.LineGroupHeaderOutofHomeBottom.Name = "LineGroupHeaderOutofHomeBottom"
            Me.LineGroupHeaderOutofHomeBottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderOutofHomeBottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderOutofHomeBottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderOutofHomeBottom.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderOutOfHome_Amount
            '
            Me.LabelGroupHeaderOutOfHome_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_Amount.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 4.000004!)
            Me.LabelGroupHeaderOutOfHome_Amount.Name = "LabelGroupHeaderOutOfHome_Amount"
            Me.LabelGroupHeaderOutOfHome_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderOutOfHome_Amount.Text = "Amount"
            Me.LabelGroupHeaderOutOfHome_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderOutOfHome_OutOfHome
            '
            Me.LabelGroupHeaderOutOfHome_OutOfHome.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_OutOfHome.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_OutOfHome.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_OutOfHome.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_OutOfHome.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_OutOfHome.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderOutOfHome_OutOfHome.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_OutOfHome.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 25.0!)
            Me.LabelGroupHeaderOutOfHome_OutOfHome.Name = "LabelGroupHeaderOutOfHome_OutOfHome"
            Me.LabelGroupHeaderOutOfHome_OutOfHome.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_OutOfHome.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_OutOfHome.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_OutOfHome.Text = "Out Of Home"
            Me.LabelGroupHeaderOutOfHome_OutOfHome.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderOutOfHome_GLAccount
            '
            Me.LabelGroupHeaderOutOfHome_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_GLAccount.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 3.999996!)
            Me.LabelGroupHeaderOutOfHome_GLAccount.Name = "LabelGroupHeaderOutOfHome_GLAccount"
            Me.LabelGroupHeaderOutOfHome_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderOutOfHome_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderOutOfHome_GLDescription
            '
            Me.LabelGroupHeaderOutOfHome_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_GLDescription.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 4.000004!)
            Me.LabelGroupHeaderOutOfHome_GLDescription.Name = "LabelGroupHeaderOutOfHome_GLDescription"
            Me.LabelGroupHeaderOutOfHome_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_GLDescription.Text = "Description"
            Me.LabelGroupHeaderOutOfHome_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderOutOfHome_CDP
            '
            Me.LabelGroupHeaderOutOfHome_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_CDP.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 4.000004!)
            Me.LabelGroupHeaderOutOfHome_CDP.Name = "LabelGroupHeaderOutOfHome_CDP"
            Me.LabelGroupHeaderOutOfHome_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderOutOfHome_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderOutOfHome_OrderLine
            '
            Me.LabelGroupHeaderOutOfHome_OrderLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_OrderLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_OrderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_OrderLine.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_OrderLine.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_OrderLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_OrderLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 4.000004!)
            Me.LabelGroupHeaderOutOfHome_OrderLine.Name = "LabelGroupHeaderOutOfHome_OrderLine"
            Me.LabelGroupHeaderOutOfHome_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_OrderLine.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_OrderLine.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_OrderLine.Text = "Order/Line"
            Me.LabelGroupHeaderOutOfHome_OrderLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderOutOfHome_TaxCode
            '
            Me.LabelGroupHeaderOutOfHome_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderOutOfHome_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderOutOfHome_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderOutOfHome_TaxCode.CanGrow = False
            Me.LabelGroupHeaderOutOfHome_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOutOfHome_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderOutOfHome_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 4.000004!)
            Me.LabelGroupHeaderOutOfHome_TaxCode.Name = "LabelGroupHeaderOutOfHome_TaxCode"
            Me.LabelGroupHeaderOutOfHome_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOutOfHome_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderOutOfHome_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderOutOfHome_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderOutOfHome_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterOutOfHome
            '
            Me.GroupFooterOutOfHome.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterOutOfHome_DisbursedAmount, Me.LabelGroupFooterOutOfHome_Total})
            Me.GroupFooterOutOfHome.HeightF = 23.0!
            Me.GroupFooterOutOfHome.Name = "GroupFooterOutOfHome"
            '
            'LabelGroupFooterOutOfHome_DisbursedAmount
            '
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount")})
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.Name = "LabelGroupFooterOutOfHome_DisbursedAmount"
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12469!, 23.0!)
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:c2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.Summary = XrSummary6
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.Text = "LabelGroupFooterOutOfHome_DisbursedAmount"
            Me.LabelGroupFooterOutOfHome_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOutOfHome_Total
            '
            Me.LabelGroupFooterOutOfHome_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOutOfHome_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOutOfHome_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOutOfHome_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterOutOfHome_Total.CanGrow = False
            Me.LabelGroupFooterOutOfHome_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterOutOfHome_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOutOfHome_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterOutOfHome_Total.Name = "LabelGroupFooterOutOfHome_Total"
            Me.LabelGroupFooterOutOfHome_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOutOfHome_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterOutOfHome_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterOutOfHome_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOutOfHome_Total.Text = "Out Of Home Total:"
            Me.LabelGroupFooterOutOfHome_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceOutOfHome
            '
            Me.BindingSourceOutOfHome.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail)
            '
            'OutOfHomeCDP
            '
            Me.OutOfHomeCDP.DataSource = Me.BindingSourceOutOfHome
            Me.OutOfHomeCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.OutOfHomeCDP.Name = "OutOfHomeCDP"
            '
            'OutOfHomeOrderLine
            '
            Me.OutOfHomeOrderLine.DataSource = Me.BindingSourceOutOfHome
            Me.OutOfHomeOrderLine.Expression = "PadLeft([OutdoorOrderNumber], 6, '0') + '-' + PadLeft([OutdoorDetailLineNumber], " &
    "3, '0')"
            Me.OutOfHomeOrderLine.Name = "OutOfHomeOrderLine"
            '
            'DetailReportRadio
            '
            Me.DetailReportRadio.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailRadio, Me.GroupHeaderRadio, Me.GroupFooterRadio})
            Me.DetailReportRadio.DataSource = Me.BindingSourceRadio
            Me.DetailReportRadio.Level = 6
            Me.DetailReportRadio.Name = "DetailReportRadio"
            '
            'DetailRadio
            '
            Me.DetailRadio.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailRadio_LineNumber, Me.LabelDetailRadio_OrderMonth, Me.LabelDetailRadio_TaxCode, Me.LabelDetailRadio_CDP, Me.LabelDetailRadio_Spots, Me.LabelDetailRadio_DisbursedAmount, Me.LabelDetailRadio_GLDescription, Me.LabelDetailRadio_GLACode})
            Me.DetailRadio.HeightF = 23.0!
            Me.DetailRadio.Name = "DetailRadio"
            '
            'LabelDetailRadio_LineNumber
            '
            Me.LabelDetailRadio_LineNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderLineNumber")})
            Me.LabelDetailRadio_LineNumber.LocationFloat = New DevExpress.Utils.PointFloat(860.4166!, 0!)
            Me.LabelDetailRadio_LineNumber.Name = "LabelDetailRadio_LineNumber"
            Me.LabelDetailRadio_LineNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_LineNumber.SizeF = New System.Drawing.SizeF(67.70831!, 23.0!)
            Me.LabelDetailRadio_LineNumber.Text = "LabelDetailRadio_LineNumber"
            '
            'LabelDetailRadio_OrderMonth
            '
            Me.LabelDetailRadio_OrderMonth.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RadioOrderMonth")})
            Me.LabelDetailRadio_OrderMonth.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailRadio_OrderMonth.Name = "LabelDetailRadio_OrderMonth"
            Me.LabelDetailRadio_OrderMonth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_OrderMonth.SizeF = New System.Drawing.SizeF(83.33319!, 23.0!)
            Me.LabelDetailRadio_OrderMonth.Text = "LabelDetailRadio_OrderMonth"
            '
            'LabelDetailRadio_TaxCode
            '
            Me.LabelDetailRadio_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailRadio_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 0!)
            Me.LabelDetailRadio_TaxCode.Name = "LabelDetailRadio_TaxCode"
            Me.LabelDetailRadio_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_TaxCode.SizeF = New System.Drawing.SizeF(56.25018!, 23.0!)
            Me.LabelDetailRadio_TaxCode.Text = "LabelDetailRadio_TaxCode"
            '
            'LabelDetailRadio_CDP
            '
            Me.LabelDetailRadio_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RadioCDP")})
            Me.LabelDetailRadio_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 0!)
            Me.LabelDetailRadio_CDP.Name = "LabelDetailRadio_CDP"
            Me.LabelDetailRadio_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_CDP.SizeF = New System.Drawing.SizeF(130.2082!, 23.0!)
            Me.LabelDetailRadio_CDP.Text = "LabelDetailRadio_CDP"
            '
            'LabelDetailRadio_Spots
            '
            Me.LabelDetailRadio_Spots.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalSpots")})
            Me.LabelDetailRadio_Spots.LocationFloat = New DevExpress.Utils.PointFloat(500.8349!, 0!)
            Me.LabelDetailRadio_Spots.Name = "LabelDetailRadio_Spots"
            Me.LabelDetailRadio_Spots.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_Spots.SizeF = New System.Drawing.SizeF(76.25006!, 23.0!)
            Me.LabelDetailRadio_Spots.StylePriority.UseTextAlignment = False
            Me.LabelDetailRadio_Spots.Text = "LabelDetailRadio_Spots"
            Me.LabelDetailRadio_Spots.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailRadio_DisbursedAmount
            '
            Me.LabelDetailRadio_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailRadio_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailRadio_DisbursedAmount.Name = "LabelDetailRadio_DisbursedAmount"
            Me.LabelDetailRadio_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12466!, 23.0!)
            Me.LabelDetailRadio_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailRadio_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailRadio_GLDescription
            '
            Me.LabelDetailRadio_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailRadio_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailRadio_GLDescription.Name = "LabelDetailRadio_GLDescription"
            Me.LabelDetailRadio_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailRadio_GLDescription.Text = "LabelDetailRadio_GLDescription"
            '
            'LabelDetailRadio_GLACode
            '
            Me.LabelDetailRadio_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailRadio_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(24.99971!, 0!)
            Me.LabelDetailRadio_GLACode.Name = "LabelDetailRadio_GLACode"
            Me.LabelDetailRadio_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailRadio_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailRadio_GLACode.Text = "LabelDetailRadio_GLACode"
            '
            'GroupHeaderRadio
            '
            Me.GroupHeaderRadio.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderRadio_LineNumber, Me.LabelGroupHeaderRadio_Spots, Me.LabelGroupHeaderRadio_TaxCode, Me.LabelGroupHeaderRadio_OrderMonth, Me.LabelGroupHeaderRadio_CDP, Me.LabelGroupHeaderRadio_GLDescription, Me.LabelGroupHeaderRadio_GLAccount, Me.LabelGroupHeaderRadio_Radio, Me.LabelGroupHeaderRadio_Amount, Me.LineGroupHeaderRadioBottom, Me.LineGroupHeaderRadioTop})
            Me.GroupHeaderRadio.Expanded = False
            Me.GroupHeaderRadio.HeightF = 44.0!
            Me.GroupHeaderRadio.Name = "GroupHeaderRadio"
            '
            'LabelGroupHeaderRadio_LineNumber
            '
            Me.LabelGroupHeaderRadio_LineNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_LineNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_LineNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_LineNumber.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_LineNumber.CanGrow = False
            Me.LabelGroupHeaderRadio_LineNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_LineNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_LineNumber.LocationFloat = New DevExpress.Utils.PointFloat(860.4166!, 3.999964!)
            Me.LabelGroupHeaderRadio_LineNumber.Name = "LabelGroupHeaderRadio_LineNumber"
            Me.LabelGroupHeaderRadio_LineNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_LineNumber.SizeF = New System.Drawing.SizeF(67.70837!, 19.0!)
            Me.LabelGroupHeaderRadio_LineNumber.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_LineNumber.Text = "Line Nbr"
            Me.LabelGroupHeaderRadio_LineNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_Spots
            '
            Me.LabelGroupHeaderRadio_Spots.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_Spots.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Spots.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_Spots.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_Spots.CanGrow = False
            Me.LabelGroupHeaderRadio_Spots.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_Spots.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Spots.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 3.999996!)
            Me.LabelGroupHeaderRadio_Spots.Name = "LabelGroupHeaderRadio_Spots"
            Me.LabelGroupHeaderRadio_Spots.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_Spots.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderRadio_Spots.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_Spots.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderRadio_Spots.Text = "Spots"
            Me.LabelGroupHeaderRadio_Spots.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderRadio_TaxCode
            '
            Me.LabelGroupHeaderRadio_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_TaxCode.CanGrow = False
            Me.LabelGroupHeaderRadio_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 4.000004!)
            Me.LabelGroupHeaderRadio_TaxCode.Name = "LabelGroupHeaderRadio_TaxCode"
            Me.LabelGroupHeaderRadio_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderRadio_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderRadio_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_OrderMonth
            '
            Me.LabelGroupHeaderRadio_OrderMonth.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_OrderMonth.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_OrderMonth.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_OrderMonth.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_OrderMonth.CanGrow = False
            Me.LabelGroupHeaderRadio_OrderMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_OrderMonth.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_OrderMonth.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 4.000004!)
            Me.LabelGroupHeaderRadio_OrderMonth.Name = "LabelGroupHeaderRadio_OrderMonth"
            Me.LabelGroupHeaderRadio_OrderMonth.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_OrderMonth.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderRadio_OrderMonth.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_OrderMonth.Text = "Order/Month"
            Me.LabelGroupHeaderRadio_OrderMonth.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_CDP
            '
            Me.LabelGroupHeaderRadio_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_CDP.CanGrow = False
            Me.LabelGroupHeaderRadio_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 4.000004!)
            Me.LabelGroupHeaderRadio_CDP.Name = "LabelGroupHeaderRadio_CDP"
            Me.LabelGroupHeaderRadio_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderRadio_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderRadio_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_GLDescription
            '
            Me.LabelGroupHeaderRadio_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_GLDescription.CanGrow = False
            Me.LabelGroupHeaderRadio_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 4.000004!)
            Me.LabelGroupHeaderRadio_GLDescription.Name = "LabelGroupHeaderRadio_GLDescription"
            Me.LabelGroupHeaderRadio_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderRadio_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_GLDescription.Text = "Description"
            Me.LabelGroupHeaderRadio_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_GLAccount
            '
            Me.LabelGroupHeaderRadio_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_GLAccount.CanGrow = False
            Me.LabelGroupHeaderRadio_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 4.000004!)
            Me.LabelGroupHeaderRadio_GLAccount.Name = "LabelGroupHeaderRadio_GLAccount"
            Me.LabelGroupHeaderRadio_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderRadio_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderRadio_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_Radio
            '
            Me.LabelGroupHeaderRadio_Radio.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_Radio.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Radio.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_Radio.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_Radio.CanGrow = False
            Me.LabelGroupHeaderRadio_Radio.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderRadio_Radio.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Radio.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 25.0!)
            Me.LabelGroupHeaderRadio_Radio.Name = "LabelGroupHeaderRadio_Radio"
            Me.LabelGroupHeaderRadio_Radio.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_Radio.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderRadio_Radio.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_Radio.Text = "Radio"
            Me.LabelGroupHeaderRadio_Radio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderRadio_Amount
            '
            Me.LabelGroupHeaderRadio_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderRadio_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderRadio_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderRadio_Amount.CanGrow = False
            Me.LabelGroupHeaderRadio_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderRadio_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderRadio_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 4.000004!)
            Me.LabelGroupHeaderRadio_Amount.Name = "LabelGroupHeaderRadio_Amount"
            Me.LabelGroupHeaderRadio_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderRadio_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderRadio_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderRadio_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderRadio_Amount.Text = "Amount"
            Me.LabelGroupHeaderRadio_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineGroupHeaderRadioBottom
            '
            Me.LineGroupHeaderRadioBottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderRadioBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderRadioBottom.BorderWidth = 0!
            Me.LineGroupHeaderRadioBottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderRadioBottom.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 23.0!)
            Me.LineGroupHeaderRadioBottom.Name = "LineGroupHeaderRadioBottom"
            Me.LineGroupHeaderRadioBottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderRadioBottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderRadioBottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderRadioBottom.StylePriority.UseForeColor = False
            '
            'LineGroupHeaderRadioTop
            '
            Me.LineGroupHeaderRadioTop.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderRadioTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderRadioTop.BorderWidth = 0!
            Me.LineGroupHeaderRadioTop.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderRadioTop.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderRadioTop.Name = "LineGroupHeaderRadioTop"
            Me.LineGroupHeaderRadioTop.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderRadioTop.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderRadioTop.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderRadioTop.StylePriority.UseForeColor = False
            '
            'GroupFooterRadio
            '
            Me.GroupFooterRadio.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterRadio_DisbursedAmount, Me.LabelGroupFooterRadio_Total})
            Me.GroupFooterRadio.HeightF = 23.0!
            Me.GroupFooterRadio.Name = "GroupFooterRadio"
            '
            'LabelGroupFooterRadio_DisbursedAmount
            '
            Me.LabelGroupFooterRadio_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount")})
            Me.LabelGroupFooterRadio_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterRadio_DisbursedAmount.Name = "LabelGroupFooterRadio_DisbursedAmount"
            Me.LabelGroupFooterRadio_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterRadio_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12466!, 23.0!)
            Me.LabelGroupFooterRadio_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:c2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterRadio_DisbursedAmount.Summary = XrSummary7
            Me.LabelGroupFooterRadio_DisbursedAmount.Text = "LabelGroupFooterRadio_DisbursedAmount"
            Me.LabelGroupFooterRadio_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterRadio_Total
            '
            Me.LabelGroupFooterRadio_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterRadio_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterRadio_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterRadio_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterRadio_Total.CanGrow = False
            Me.LabelGroupFooterRadio_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterRadio_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterRadio_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterRadio_Total.Name = "LabelGroupFooterRadio_Total"
            Me.LabelGroupFooterRadio_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterRadio_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterRadio_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterRadio_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterRadio_Total.Text = "Radio Total:"
            Me.LabelGroupFooterRadio_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceRadio
            '
            Me.BindingSourceRadio.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail)
            '
            'DetailReportTV
            '
            Me.DetailReportTV.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailTV, Me.GroupHeaderTV, Me.GroupFooterTV})
            Me.DetailReportTV.DataSource = Me.BindingSourceTV
            Me.DetailReportTV.Level = 7
            Me.DetailReportTV.Name = "DetailReportTV"
            '
            'DetailTV
            '
            Me.DetailTV.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailTV_TaxCode, Me.LabelDetailTV_LineNumber, Me.LabelDetailTV_OrderMonth, Me.LabelDetailTV_CDP, Me.LabelDetailTV_Spots, Me.LabelDetailTV_DisbursedAmount, Me.LabelDetailTV_GLDescription, Me.LabelDetailTV_GLACode})
            Me.DetailTV.HeightF = 23.0!
            Me.DetailTV.Name = "DetailTV"
            '
            'LabelDetailTV_TaxCode
            '
            Me.LabelDetailTV_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesTaxCode")})
            Me.LabelDetailTV_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(944.7496!, 0!)
            Me.LabelDetailTV_TaxCode.Name = "LabelDetailTV_TaxCode"
            Me.LabelDetailTV_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_TaxCode.SizeF = New System.Drawing.SizeF(55.25037!, 23.0!)
            Me.LabelDetailTV_TaxCode.Text = "LabelDetailTV_TaxCode"
            '
            'LabelDetailTV_LineNumber
            '
            Me.LabelDetailTV_LineNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderLineNumber")})
            Me.LabelDetailTV_LineNumber.LocationFloat = New DevExpress.Utils.PointFloat(860.4167!, 0!)
            Me.LabelDetailTV_LineNumber.Name = "LabelDetailTV_LineNumber"
            Me.LabelDetailTV_LineNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_LineNumber.SizeF = New System.Drawing.SizeF(67.70825!, 23.0!)
            Me.LabelDetailTV_LineNumber.Text = "LabelDetailTV_LineNumber"
            '
            'LabelDetailTV_OrderMonth
            '
            Me.LabelDetailTV_OrderMonth.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TVOrderMonth")})
            Me.LabelDetailTV_OrderMonth.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 0!)
            Me.LabelDetailTV_OrderMonth.Name = "LabelDetailTV_OrderMonth"
            Me.LabelDetailTV_OrderMonth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_OrderMonth.SizeF = New System.Drawing.SizeF(83.33319!, 23.0!)
            Me.LabelDetailTV_OrderMonth.Text = "LabelDetailTV_OrderMonth"
            '
            'LabelDetailTV_CDP
            '
            Me.LabelDetailTV_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TVCDP")})
            Me.LabelDetailTV_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7498!, 0!)
            Me.LabelDetailTV_CDP.Name = "LabelDetailTV_CDP"
            Me.LabelDetailTV_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_CDP.SizeF = New System.Drawing.SizeF(130.2084!, 23.0!)
            Me.LabelDetailTV_CDP.Text = "LabelDetailTV_CDP"
            '
            'LabelDetailTV_Spots
            '
            Me.LabelDetailTV_Spots.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalSpots")})
            Me.LabelDetailTV_Spots.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0!)
            Me.LabelDetailTV_Spots.Name = "LabelDetailTV_Spots"
            Me.LabelDetailTV_Spots.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_Spots.SizeF = New System.Drawing.SizeF(77.08496!, 23.0!)
            Me.LabelDetailTV_Spots.StylePriority.UseTextAlignment = False
            Me.LabelDetailTV_Spots.Text = "LabelDetailTV_Spots"
            Me.LabelDetailTV_Spots.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailTV_DisbursedAmount
            '
            Me.LabelDetailTV_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount", "{0:#,#.00}")})
            Me.LabelDetailTV_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelDetailTV_DisbursedAmount.Name = "LabelDetailTV_DisbursedAmount"
            Me.LabelDetailTV_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12463!, 23.0!)
            Me.LabelDetailTV_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailTV_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailTV_GLDescription
            '
            Me.LabelDetailTV_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLADescription")})
            Me.LabelDetailTV_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 0!)
            Me.LabelDetailTV_GLDescription.Name = "LabelDetailTV_GLDescription"
            Me.LabelDetailTV_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailTV_GLDescription.Text = "LabelDetailTV_GLDescription"
            '
            'LabelDetailTV_GLACode
            '
            Me.LabelDetailTV_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailTV_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(24.99971!, 0!)
            Me.LabelDetailTV_GLACode.Name = "LabelDetailTV_GLACode"
            Me.LabelDetailTV_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailTV_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailTV_GLACode.Text = "LabelDetailTV_GLACode"
            '
            'GroupHeaderTV
            '
            Me.GroupHeaderTV.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupHeaderTVTop, Me.LineGroupHeaderTVBottom, Me.LabelGroupHeaderTV_Amount, Me.LabelGroupHeaderTV_TV, Me.LabelGroupHeaderTV_GLAccount, Me.LabelGroupHeaderTV_GLDescription, Me.LabelGroupHeaderTV_CDP, Me.LabelGroupHeaderTV_OrderMonth, Me.LabelGroupHeaderTV_TaxCode, Me.LabelGroupHeaderTV_Spots, Me.LabelGroupHeaderTV_LineNumber})
            Me.GroupHeaderTV.HeightF = 44.0!
            Me.GroupHeaderTV.Name = "GroupHeaderTV"
            '
            'LineGroupHeaderTVTop
            '
            Me.LineGroupHeaderTVTop.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderTVTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderTVTop.BorderWidth = 0!
            Me.LineGroupHeaderTVTop.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderTVTop.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderTVTop.Name = "LineGroupHeaderTVTop"
            Me.LineGroupHeaderTVTop.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderTVTop.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderTVTop.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderTVTop.StylePriority.UseForeColor = False
            '
            'LineGroupHeaderTVBottom
            '
            Me.LineGroupHeaderTVBottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderTVBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderTVBottom.BorderWidth = 0!
            Me.LineGroupHeaderTVBottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderTVBottom.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 23.0!)
            Me.LineGroupHeaderTVBottom.Name = "LineGroupHeaderTVBottom"
            Me.LineGroupHeaderTVBottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderTVBottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderTVBottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderTVBottom.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderTV_Amount
            '
            Me.LabelGroupHeaderTV_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_Amount.CanGrow = False
            Me.LabelGroupHeaderTV_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_Amount.LocationFloat = New DevExpress.Utils.PointFloat(388.5399!, 4.000004!)
            Me.LabelGroupHeaderTV_Amount.Name = "LabelGroupHeaderTV_Amount"
            Me.LabelGroupHeaderTV_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderTV_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderTV_Amount.Text = "Amount"
            Me.LabelGroupHeaderTV_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderTV_TV
            '
            Me.LabelGroupHeaderTV_TV.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_TV.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_TV.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_TV.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_TV.CanGrow = False
            Me.LabelGroupHeaderTV_TV.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupHeaderTV_TV.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_TV.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 25.0!)
            Me.LabelGroupHeaderTV_TV.Name = "LabelGroupHeaderTV_TV"
            Me.LabelGroupHeaderTV_TV.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_TV.SizeF = New System.Drawing.SizeF(84.37503!, 19.0!)
            Me.LabelGroupHeaderTV_TV.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_TV.Text = "TV"
            Me.LabelGroupHeaderTV_TV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_GLAccount
            '
            Me.LabelGroupHeaderTV_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_GLAccount.CanGrow = False
            Me.LabelGroupHeaderTV_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 4.000004!)
            Me.LabelGroupHeaderTV_GLAccount.Name = "LabelGroupHeaderTV_GLAccount"
            Me.LabelGroupHeaderTV_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderTV_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderTV_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_GLDescription
            '
            Me.LabelGroupHeaderTV_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_GLDescription.CanGrow = False
            Me.LabelGroupHeaderTV_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(134.9999!, 4.000004!)
            Me.LabelGroupHeaderTV_GLDescription.Name = "LabelGroupHeaderTV_GLDescription"
            Me.LabelGroupHeaderTV_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderTV_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_GLDescription.Text = "Description"
            Me.LabelGroupHeaderTV_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_CDP
            '
            Me.LabelGroupHeaderTV_CDP.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_CDP.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_CDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_CDP.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_CDP.CanGrow = False
            Me.LabelGroupHeaderTV_CDP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_CDP.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_CDP.LocationFloat = New DevExpress.Utils.PointFloat(618.7499!, 4.000004!)
            Me.LabelGroupHeaderTV_CDP.Name = "LabelGroupHeaderTV_CDP"
            Me.LabelGroupHeaderTV_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_CDP.SizeF = New System.Drawing.SizeF(130.2083!, 19.0!)
            Me.LabelGroupHeaderTV_CDP.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_CDP.Text = "Client/Division/Product"
            Me.LabelGroupHeaderTV_CDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_OrderMonth
            '
            Me.LabelGroupHeaderTV_OrderMonth.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_OrderMonth.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_OrderMonth.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_OrderMonth.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_OrderMonth.CanGrow = False
            Me.LabelGroupHeaderTV_OrderMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_OrderMonth.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_OrderMonth.LocationFloat = New DevExpress.Utils.PointFloat(759.3749!, 4.000004!)
            Me.LabelGroupHeaderTV_OrderMonth.Name = "LabelGroupHeaderTV_OrderMonth"
            Me.LabelGroupHeaderTV_OrderMonth.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_OrderMonth.SizeF = New System.Drawing.SizeF(83.33325!, 19.0!)
            Me.LabelGroupHeaderTV_OrderMonth.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_OrderMonth.Text = "Order/Month"
            Me.LabelGroupHeaderTV_OrderMonth.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_TaxCode
            '
            Me.LabelGroupHeaderTV_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_TaxCode.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_TaxCode.CanGrow = False
            Me.LabelGroupHeaderTV_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(943.7498!, 4.000004!)
            Me.LabelGroupHeaderTV_TaxCode.Name = "LabelGroupHeaderTV_TaxCode"
            Me.LabelGroupHeaderTV_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_TaxCode.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderTV_TaxCode.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_TaxCode.Text = "Tax Code"
            Me.LabelGroupHeaderTV_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderTV_Spots
            '
            Me.LabelGroupHeaderTV_Spots.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_Spots.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_Spots.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_Spots.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_Spots.CanGrow = False
            Me.LabelGroupHeaderTV_Spots.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_Spots.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_Spots.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 4.000004!)
            Me.LabelGroupHeaderTV_Spots.Name = "LabelGroupHeaderTV_Spots"
            Me.LabelGroupHeaderTV_Spots.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_Spots.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderTV_Spots.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_Spots.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderTV_Spots.Text = "Spots"
            Me.LabelGroupHeaderTV_Spots.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderTV_LineNumber
            '
            Me.LabelGroupHeaderTV_LineNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderTV_LineNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_LineNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderTV_LineNumber.BorderWidth = 1.0!
            Me.LabelGroupHeaderTV_LineNumber.CanGrow = False
            Me.LabelGroupHeaderTV_LineNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderTV_LineNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderTV_LineNumber.LocationFloat = New DevExpress.Utils.PointFloat(860.4166!, 4.000004!)
            Me.LabelGroupHeaderTV_LineNumber.Name = "LabelGroupHeaderTV_LineNumber"
            Me.LabelGroupHeaderTV_LineNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderTV_LineNumber.SizeF = New System.Drawing.SizeF(67.70837!, 19.0!)
            Me.LabelGroupHeaderTV_LineNumber.StylePriority.UseFont = False
            Me.LabelGroupHeaderTV_LineNumber.Text = "Line Nbr"
            Me.LabelGroupHeaderTV_LineNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterTV
            '
            Me.GroupFooterTV.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterTV_DisbursedAmount, Me.LabelGroupFooterTV_Total})
            Me.GroupFooterTV.HeightF = 23.0!
            Me.GroupFooterTV.Name = "GroupFooterTV"
            '
            'LabelGroupFooterTV_DisbursedAmount
            '
            Me.LabelGroupFooterTV_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DisbursedAmount")})
            Me.LabelGroupFooterTV_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(367.5!, 0!)
            Me.LabelGroupFooterTV_DisbursedAmount.Name = "LabelGroupFooterTV_DisbursedAmount"
            Me.LabelGroupFooterTV_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterTV_DisbursedAmount.SizeF = New System.Drawing.SizeF(98.12463!, 23.0!)
            Me.LabelGroupFooterTV_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:c2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterTV_DisbursedAmount.Summary = XrSummary8
            Me.LabelGroupFooterTV_DisbursedAmount.Text = "LabelGroupFooterTV_DisbursedAmount"
            Me.LabelGroupFooterTV_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterTV_Total
            '
            Me.LabelGroupFooterTV_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterTV_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTV_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterTV_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterTV_Total.CanGrow = False
            Me.LabelGroupFooterTV_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterTV_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTV_Total.LocationFloat = New DevExpress.Utils.PointFloat(245.8332!, 0!)
            Me.LabelGroupFooterTV_Total.Name = "LabelGroupFooterTV_Total"
            Me.LabelGroupFooterTV_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterTV_Total.SizeF = New System.Drawing.SizeF(117.7084!, 19.0!)
            Me.LabelGroupFooterTV_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterTV_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterTV_Total.Text = "TV Total:"
            Me.LabelGroupFooterTV_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceTV
            '
            Me.BindingSourceTV.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail)
            '
            'RadioCDP
            '
            Me.RadioCDP.DataSource = Me.BindingSourceRadio
            Me.RadioCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.RadioCDP.Name = "RadioCDP"
            '
            'RadioOrderMonth
            '
            Me.RadioOrderMonth.DataSource = Me.BindingSourceRadio
            Me.RadioOrderMonth.Expression = "[OrderNumber] + '-' + [BroadcastMonth]"
            Me.RadioOrderMonth.Name = "RadioOrderMonth"
            '
            'TVCDP
            '
            Me.TVCDP.DataSource = Me.BindingSourceTV
            Me.TVCDP.Expression = "[ClientCode] + '/'  + [DivisionCode] + '/' + [ProductCode]"
            Me.TVCDP.Name = "TVCDP"
            '
            'TVOrderMonth
            '
            Me.TVOrderMonth.DataSource = Me.BindingSourceTV
            Me.TVOrderMonth.Expression = "[OrderNumber] + '-' + [BroadcastMonth]"
            Me.TVOrderMonth.Name = "TVOrderMonth"
            '
            'AccountPayableBatchDetailReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.DetailReportNonClient, Me.DetailReportProduction, Me.GroupFooter, Me.GroupHeader, Me.DetailReportMagazine, Me.DetailReportNewspaper, Me.DetailReportInternet, Me.PageFooter, Me.DetailReportOutOfHome, Me.DetailReportRadio, Me.DetailReportTV})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalInvoice, Me.PrintComment, Me.ProdPOLine, Me.ProdIsPOComplete, Me.ProdJobComp, Me.ProdCDP, Me.ProdPrintComment, Me.MagCDP, Me.MagOrderLine, Me.NewsCDP, Me.NewsOrderLine, Me.InternetCDP, Me.InternetOrderLine, Me.OutOfHomeCDP, Me.OutOfHomeOrderLine, Me.RadioCDP, Me.RadioOrderMonth, Me.TVCDP, Me.TVOrderMonth})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSourceNonClient, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceProduction, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceMagazine, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceNewspaper, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceInternet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceOutOfHome, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceRadio, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceTV, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_VendorLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateToPayLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLTransLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TotalInvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DiscountPercentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents LabelDetail_DateToPay As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Date As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Invoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_SalesTaxLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_SalesTax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTrans As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostingPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DiscountPercent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Terms As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Office As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBoxDetail_Hold As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents CheckBoxDetail_1099Invoice As DevExpress.XtraReports.UI.XRCheckBox
        Private WithEvents LabelDetail_TermsLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OfficeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TotalInvoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalInvoice As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineReportFooter_1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents DetailReportNonClient As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailNonClient As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BindingSourceNonClient As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderNonClient As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderNonClient_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_NonClient As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderNonClient_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupHeaderNonClient_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetailNonClient_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNonClient_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNonClient_POLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNonClient_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_Complete As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_POLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PrintComment As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupFooterNonClient As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelGroupFooterNonClient_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterNonClient_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportProduction As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailProduction As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderProduction As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSourceProduction As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDetailProduction_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_GLACode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderProduction_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderProduction_Complete As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_Function As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_JobComp As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_Production As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderProduction_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderProduction_POLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderProduction_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterProduction As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelGroupFooterProduction_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterProduction_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ProdPOLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailProduction_POLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ProdIsPOComplete As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProdJobComp As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProdCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProdPrintComment As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailProduction_Comment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_Function As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_JobComp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailProduction_Complete As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LineGroupFooter_2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupFooter_InvoiceTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooter_1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupFooter_InvoiceTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelDetailNonClient_Comment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportMagazine As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailMagazine As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderMagazine As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderMagazine_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderMagazine_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderMagazine_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderMagazine_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderMagazine_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderMagazine_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderMagazine_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderMagazine_Magazine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderMagazine_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupFooterMagazine As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LabelGroupFooterMagazine_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceMagazine As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDetailMagazine_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailMagazine_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailMagazine_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailMagazine_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents MagCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents MagOrderLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailMagazine_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailMagazine_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterMagazine_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportNewspaper As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailNewspaper As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderNewspaper As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterNewspaper As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LineGroupHeaderNewspaper_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderNewspaper_Newspaper As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNewspaper_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderNewspaper_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderNewspaper_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNewspaper_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNewspaper_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNewspaper_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNewspaper_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterNewspaper_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNewspaper_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNewspaper_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNewspaper_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNewspaper_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceNewspaper As System.Windows.Forms.BindingSource
        Friend WithEvents NewsCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents NewsOrderLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailNewspaper_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNewspaper_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterNewspaper_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportInternet As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailInternet As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderInternet As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderInternet_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderInternet_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderInternet_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderInternet_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderInternet_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderInternet_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderInternet_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderInternet_Internet As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderInternet_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupFooterInternet As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LabelGroupFooterInternet_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailInternet_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceInternet As System.Windows.Forms.BindingSource
        Friend WithEvents InternetCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailInternet_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailInternet_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailInternet_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterInternet_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents InternetOrderLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailInternet_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailInternet_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportOutOfHome As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailOutOfHome As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents GroupHeaderOutOfHome As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LineGroupHeaderOutofHomeTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupHeaderOutofHomeBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderOutOfHome_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_OutOfHome As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderOutOfHome_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterOutOfHome As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelDetailOutOfHome_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOutOfHome_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOutOfHome_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceOutOfHome As System.Windows.Forms.BindingSource
        Friend WithEvents OutOfHomeCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailOutOfHome_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOutOfHome_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOutOfHome_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OutOfHomeOrderLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelGroupFooterOutOfHome_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOutOfHome_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportRadio As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailRadio As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents DetailReportTV As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailTV As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BindingSourceRadio As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderRadio As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderRadio_Spots As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_OrderMonth As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_Radio As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderRadioBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupHeaderRadioTop As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetailRadio_Spots As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailRadio_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailRadio_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailRadio_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailRadio_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents RadioCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailRadio_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderRadio_LineNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterRadio As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LabelGroupFooterRadio_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailRadio_OrderMonth As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents RadioOrderMonth As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailRadio_LineNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterRadio_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceTV As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderTV As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterTV As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LineGroupHeaderTVTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupHeaderTVBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderTV_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_TV As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_CDP As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_OrderMonth As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_Spots As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderTV_LineNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_Spots As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TVCDP As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetailTV_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_LineNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_OrderMonth As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailTV_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TVOrderMonth As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelGroupFooterTV_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterTV_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooter_InvoiceForeignCurrencyTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooter_InvoiceForeignCurrencyTotalLabel As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
