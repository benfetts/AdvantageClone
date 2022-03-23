Namespace InvoicePrinting

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MediaTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Outdoor")>
            Outdoor = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            TV = 6
        End Enum
        Public Enum InvoiceFormatTypes As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client Default")>
            ClientDefault = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Agency")>
            Agency = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "One-Time")>
            OneTime = 3
        End Enum
        <System.ComponentModel.TypeConverter(GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))>
        Public Enum AddressBlockTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client Address")>
            ClientAddress = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Division Address")>
            DivisionAddress = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Product Address")>
            ProductAddress = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Invoice/Job Contact Address")>
            InvoiceJobContactAddress = 4
        End Enum
        <System.ComponentModel.TypeConverter(GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))>
        Public Enum MediaAddressBlockTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client Address")>
            ClientAddress = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Division Address")>
            DivisionAddress = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Product Address")>
            ProductAddress = 3
        End Enum
        Public Enum ReportFormatTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Current Only")>
            CurrentOnly = 1
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Current/TTD")>
			CurrentTTD = 2
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Estimate/Current/TTD")>
			EstimateCurrentTTD = 7
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Estimate/Prior/Current/TTD")>
            EstimatePriorCurrentTTD = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Net/Commission/Tax/Total")>
            NetCommissionTaxTotal = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Grand Total Only")>
            GrandTotalOnly = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Job Description Roll Up")>
            JobDescriptionRollUp = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Job Description Roll Up/Comment")>
            JobDescriptionRollUpComment = 9
        End Enum
        Public Enum GroupingOptionTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Function")>
            [Function] = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Function Type and Function")>
            FunctionTypeAndFunction = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Function Heading and Function")>
            FunctionHeadingAndFunction = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Inside/Outside and Function")>
            InsideOutsideAndFunction = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Function Type Total Only")>
            FunctionTypeTotalOnly = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Function Heading Total Only")>
            FunctionHeadingTotalOnly = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Inside/Outside Total Only")>
            InsideOutsideTotalOnly = 6
        End Enum
        Public Enum SortFunctionByTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Sort By Function Code")>
            SortByFunctionCode = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Sort By Function Order")>
            SortByFunctionOrder = 2
        End Enum
        Public Enum PrintFunctionTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Print Function from Product Default")>
            PrintFunctionFromProductDefault = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Print Standard Function")>
            PrintStandardFunction = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Print Consolidated Function")>
            PrintConsolidatedFunction = 3
        End Enum
        Public Enum InvoiceFooterCommentTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "None")>
            None = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "From Default")>
            FromDefault = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "User Defined")>
            UserDefined = 3
        End Enum
        Public Enum BackupReportColumnOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Date/Hours/Amount")>
            DateHoursAmount = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Date/Hours/Amount/Commission/Tax/Total")>
            DateHoursAmountCommissionTaxTotal = 2
        End Enum
        Public Enum NonBroadcastVendorOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show")>
            Show = 1
        End Enum
        Public Enum NonBroadcastAmountsOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Column 4")>
            Column4 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Column 5")>
            Column5 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Column 6")>
            Column6 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Column 7")>
            Column7 = 7
        End Enum
        Public Enum NonBroadcastLineOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Column 4")>
            Column4 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Column 5")>
            Column5 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Column 6")>
            Column6 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Column 7")>
            Column7 = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Show As Row")>
            ShowAsRow = 8
        End Enum
        Public Enum ExtraChargesOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show As Row")>
            ShowAsRow = 1
        End Enum
        Public Enum BroadcastVendorOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show")>
            Show = 1
        End Enum
        Public Enum BroadcastAmountsOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Column 3")>
            Column3 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Column 4")>
            Column4 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Column 5")>
            Column5 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Column 6")>
            Column6 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Column 7")>
            Column7 = 7
        End Enum
        Public Enum BroadcastLineOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Column 2")>
            Column2 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Column 3")>
            Column3 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Column 4")>
            Column4 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Column 5")>
            Column5 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Column 6")>
            Column6 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Column 7")>
            Column7 = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Show As Row")>
            ShowAsRow = 8
        End Enum
        Public Enum OrderNumberOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Show")>
            Show = 1
        End Enum
        Public Enum OrderLineNumberOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Do Not Show")>
            DoNotShow = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Column 1")>
            Column1 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Column 2")>
            Column2 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Column 3")>
            Column3 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Column 4")>
            Column4 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Column 5")>
            Column5 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Column 6")>
            Column6 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Column 7")>
            Column7 = 7
        End Enum
        Public Enum InvoiceTypes As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Production")>
            Production = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Production Current/TTD")>
            ProductionCurrentTTD = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Production Estimate/Prior/Current/TTD")>
            ProductionEstimatePriorCurrentTTD = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Production Net/Commission/Tax/Current")>
            ProductionNetCommissionTaxCurrent = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Production Grand Total")>
            ProductionGrandTotal = 5
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Media")>
			Media = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Production Estimate/Current/TTD")>
            ProductionEstimateCurrentTTD = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Production Job Description Roll Up")>
            ProductionJobDescriptionRollUp = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Production Job Description Roll Up/Comment")>
            ProductionJobDescriptionRollUpComment = 9
        End Enum
        Public Enum TaxTotalLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "All")>
            All = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Invoice Total Only")>
            InvoiceTotalOnly = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Job Total Only")>
            JobTotalOnly = 3
        End Enum
        Public Enum ClientPOLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job\Component")>
            JobComponent = 2
        End Enum
        Public Enum ClientReferenceLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job\Component")>
            JobComponent = 2
        End Enum
        Public Enum SalesClassLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job\Component")>
            JobComponent = 2
        End Enum
        Public Enum CampaignLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job\Component")>
            JobComponent = 2
        End Enum
        Public Enum HeaderGroupByOptions As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "[Default]")>
            [Default] = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Campaign")>
            Campaign = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Sales Class")>
            SalesClass = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Campaign/Sales Class")>
            CampaignSalesClass = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Sales Class/Campaign")>
            SalesClassCampaign = 4
        End Enum
        Public Enum ToFileOptions
            PDF
            RTF
            XLS
            XLSX
            Image
            DocumentManager
        End Enum
        Public Enum PackageTypes
            None = 0
            OneZip = 1
            OneZipPerInvoice = 2
        End Enum
        Public Enum PackageDocumentSortOptions
            APInvoiceDateAPInvoiceNumber = 1
            APInvoiceNumberAPInvoiceDate = 2
        End Enum
        Public Enum AddressContactTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Invoice Contact | None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Invoice Contact | Attn Line")>
            AttnLine = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Invoice Contact | Job | Attn Line")>
            InvoiceContactJob = 2
        End Enum
        Public Enum MediaAddressContactTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Invoice Contact | None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Invoice Contact | Attn Line")>
            AttnLine = 1
        End Enum
        Public Enum MediaOrderGroupBy
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "[None]")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Group By Market")>
            GroupByMarket = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Group By Campaign")>
            GroupByCampaign = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Group By Sales Class")>
            GroupBySalesClass = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Group By Vendor")>
            GroupByVendor = 4
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Group By Order Month")>
			GroupByOrderMonth = 5
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Group By Vendor Invoice Category")>
			GroupByVendorInvoiceCategory = 6
		End Enum
        Public Enum MediaClientPOLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Media Order")>
            MediaOrder = 2
        End Enum
        Public Enum MediaSalesClassLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Media Order")>
            MediaOrder = 2
        End Enum
        Public Enum MediaCampaignLocations As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Header")>
            Header = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Media Order")>
            MediaOrder = 2
        End Enum
        Public Enum InvoicePrintingTypes As Integer
            Print = 1
            Preview = 2
            SMTP = 3
            All = 4
            AutoEmail = 6
            Individual = 7
        End Enum
        Public Enum MediaShowLineDetails As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Order")>
            Order = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Order/Line")>
            OrderLine = 1
        End Enum
        Public Enum MediaSortLinesBy As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Line Number")>
            LineNumber = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Line Date")>
            LineDate = 2
        End Enum
        Public Enum MediaTypeSortOrder
            P = 0
            I = 1
            M = 2
            N = 3
            O = 4
            R = 5
            T = 6
        End Enum
        Public Enum SummaryLevels
            None = 0
            Job = 1
            Invoice = 2
        End Enum
        Public Enum CoversheetLayouts As Short
            [Default] = 0
            Alternate = 1
        End Enum
        Public Enum CoversheetContacts As Short
            [None] = 0
            ContactType = 1
            FirstFound = 2
        End Enum
        Public Enum CoversheetContactLocations As Short
            AttnLine = 0
            AddressBlock = 1
        End Enum
        Public Enum OverrideInvoiceFilename As Short
            [Default] = 1
            InvoiceNumberWithSequence = 2
            InvoiceNumberOnly = 3
            InvoiceNumberWithSequenceCDPCodesCampaignCode = 4
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadCoverSheet(ByVal DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumbers As String, IsDraft As Boolean, Batches As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumbersParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumbers", InvoiceNumbers)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchesParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrWhiteSpace(Batches) Then

                BatchesParameter = New System.Data.SqlClient.SqlParameter("@Batches", System.Data.SqlDbType.VarChar, -1)
                BatchesParameter.Value = ""

            Else

                BatchesParameter = New System.Data.SqlClient.SqlParameter("@Batches", Batches)

            End If

            LoadCoverSheet = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet)("EXEC dbo.advsp_invoice_printing_load_cover_sheet @UserCode, @InvoiceNumbers, @IsDraft, @Batches", UserCodeParameter, InvoiceNumbersParameter, IsDraftParameter, BatchesParameter)

        End Function
        Public Function LoadStandardInvoiceDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumber As Integer,
                                                   SequenceNumber As Short, AddressBlockType As Short, PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean,
                                                   PrintContactAfterAddress As Boolean, PrintFunctionType As Short, SortFunctionByType As Short,
                                                   ApplyExchangeRate As Short, ExchangeRateAmount As Decimal, TotalsShowTaxSeparately As Boolean,
                                                   TotalsShowCommissionSeparately As Boolean, UseInvoiceCategoryDescription As Boolean, InvoiceTitle As String, InvoiceFooterCommentType As Short,
                                                   InvoiceFooterComment As String, GroupingOptionInsideDescription As String, GroupingOptionOutsideDescription As String, ShowCodes As Boolean,
                                                   ContactType As Integer, IsDraft As Boolean, Batch As String, IncludeEstimateComment As Boolean, IncludeEstimateComponentComment As Boolean, IncludeEstimateQuoteComment As Boolean,
                                                   IncludeEstimateRevisionComment As Boolean, IncludeEstimateFunctionComment As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim PrintFunctionTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintFunctionType", PrintFunctionType)
            Dim SortFunctionByTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SortFunctionByType", SortFunctionByType)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim TotalsShowTaxSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowTaxSeparately", TotalsShowTaxSeparately)
            Dim TotalsShowCommissionSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowCommissionSeparately", TotalsShowCommissionSeparately)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceFooterCommentTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterCommentType", InvoiceFooterCommentType)
            Dim InvoiceFooterCommentParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionInsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionOutsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeEstimateCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComment", IncludeEstimateComment)
            Dim IncludeEstimateComponentCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComponentComment", IncludeEstimateComponentComment)
            Dim IncludeEstimateQuoteCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateQuoteComment", IncludeEstimateQuoteComment)
            Dim IncludeEstimateRevisionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateRevisionComment", IncludeEstimateRevisionComment)
            Dim IncludeEstimateFunctionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateFunctionComment", IncludeEstimateFunctionComment)

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(InvoiceFooterComment) Then

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", System.Data.SqlDbType.VarChar, -1)
                InvoiceFooterCommentParameter.Value = ""

            Else

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", InvoiceFooterComment)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionInsideDescription) Then

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionInsideDescriptionParameter.Value = ""

            Else

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", GroupingOptionInsideDescription)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionOutsideDescription) Then

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionOutsideDescriptionParameter.Value = ""

            Else

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", GroupingOptionOutsideDescription)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadStandardInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)("EXEC dbo.advsp_invoice_printing_load_standardinvoicedetails @UserCode, @InvoiceNumber, @SequenceNumber, @AddressBlockType, " &
                                                                                                                                          "@PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress, @PrintFunctionType, " &
                                                                                                                                          "@SortFunctionByType, @ApplyExchangeRate, @ExchangeRateAmount, @TotalsShowTaxSeparately, " &
                                                                                                                                          "@TotalsShowCommissionSeparately, @UseInvoiceCategoryDescription, @InvoiceTitle, " &
                                                                                                                                          "@InvoiceFooterCommentType, @InvoiceFooterComment, @GroupingOptionInsideDescription, " &
                                                                                                                                          "@GroupingOptionOutsideDescription, @ShowCodes, @ContactType, @IsDraft, @Batch, @IncludeEstimateComment, @IncludeEstimateComponentComment, " &
                                                                                                                                          "@IncludeEstimateQuoteComment, @IncludeEstimateRevisionComment, @IncludeEstimateFunctionComment",
                                                                                                                                          UserCodeParameter, InvoiceNumberParameter, SequenceNumberParameter, AddressBlockTypeParameter,
                                                                                                                                          PrintClientNameParameter, PrintDivisionNameParameter, PrintProductDescriptionParameter, PrintContactAfterAddressParameter, PrintFunctionTypeParameter,
                                                                                                                                          SortFunctionByTypeParameter, ApplyExchangeRateParameter, ExchangeRateAmountParameter, TotalsShowTaxSeparatelyParameter,
                                                                                                                                          TotalsShowCommissionSeparatelyParameter, UseInvoiceCategoryDescriptionParameter, InvoiceTitleParameter,
                                                                                                                                          InvoiceFooterCommentTypeParameter, InvoiceFooterCommentParameter, GroupingOptionInsideDescriptionParameter,
                                                                                                                                          GroupingOptionOutsideDescriptionParameter, ShowCodesParameter, ContactTypeParameter, IsDraftParameter, BatchParameter, IncludeEstimateCommentParameter,
                                                                                                                                          IncludeEstimateComponentCommentParameter, IncludeEstimateQuoteCommentParameter, IncludeEstimateRevisionCommentParameter, IncludeEstimateFunctionCommentParameter)

        End Function
        Public Function LoadComboInvoiceDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumber As Integer,
                                                   SequenceNumber As Short, AddressBlockType As Short, PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean,
                                                   PrintContactAfterAddress As Boolean, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal, UseInvoiceCategoryDescription As Boolean, InvoiceTitle As String, InvoiceFooterCommentType As Short,
                                                   InvoiceFooterComment As String, ShowCodes As Boolean, ContactType As Integer, IsDraft As Boolean, Batch As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceFooterCommentTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterCommentType", InvoiceFooterCommentType)
            Dim InvoiceFooterCommentParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(InvoiceFooterComment) Then

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", System.Data.SqlDbType.VarChar, -1)
                InvoiceFooterCommentParameter.Value = ""

            Else

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", InvoiceFooterComment)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadComboInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)("EXEC dbo.advsp_invoice_printing_load_comboinvoicedetails @UserCode, @InvoiceNumber, @SequenceNumber, @AddressBlockType, " &
                                                                                                                                              "@PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress, @ApplyExchangeRate, @ExchangeRateAmount, " &
                                                                                                                                              "@UseInvoiceCategoryDescription, @InvoiceTitle, @InvoiceFooterCommentType, @InvoiceFooterComment, " &
                                                                                                                                              "@ShowCodes, @ContactType, @IsDraft, @Batch",
                                                                                                                                              UserCodeParameter, InvoiceNumberParameter, SequenceNumberParameter, AddressBlockTypeParameter,
                                                                                                                                              PrintClientNameParameter, PrintDivisionNameParameter, PrintProductDescriptionParameter, PrintContactAfterAddressParameter, ApplyExchangeRateParameter, ExchangeRateAmountParameter,
                                                                                                                                              UseInvoiceCategoryDescriptionParameter, InvoiceTitleParameter, InvoiceFooterCommentTypeParameter, InvoiceFooterCommentParameter,
                                                                                                                                              ShowCodesParameter, ContactTypeParameter, IsDraftParameter, BatchParameter)

        End Function
        Public Function LoadFunctionDetails(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String, InvoiceNumber As Integer, InvoiceSequenceNumber As Short,
                                            InvoiceType As String, JobNumber As Integer, ComponentNumber As Short, FunctionCode As String, PrintFunctionType As Short, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal,
                                            TotalsShowTaxSeparately As Boolean, TotalsShowCommissionSeparately As Boolean, ShowZeroFunctionAmounts As Boolean, IsDraft As Boolean, Batch As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail)

            Dim ClientCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ClientCode", ClientCode)
            Dim DivisionCodeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProductCodeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim InvoiceSequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceSequenceNumber", InvoiceSequenceNumber)
            Dim InvoiceTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceType", InvoiceType)
            Dim JobNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", JobNumber)
            Dim ComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ComponentNumber", ComponentNumber)
            Dim FunctionCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@FunctionCode", FunctionCode)
            Dim PrintFunctionTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintFunctionType", PrintFunctionType)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim TotalsShowTaxSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowTaxSeparately", TotalsShowTaxSeparately)
            Dim TotalsShowCommissionSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowCommissionSeparately", TotalsShowCommissionSeparately)
            Dim ShowZeroFunctionAmountsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowZeroFunctionAmounts", ShowZeroFunctionAmounts)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrWhiteSpace(DivisionCode) Then

                DivisionCodeParameter = New System.Data.SqlClient.SqlParameter("@DivisionCode", System.Data.SqlDbType.VarChar, 6)
                DivisionCodeParameter.Value = ""

            Else

                DivisionCodeParameter = New System.Data.SqlClient.SqlParameter("@DivisionCode", DivisionCode)

            End If

            If String.IsNullOrWhiteSpace(ProductCode) Then

                ProductCodeParameter = New System.Data.SqlClient.SqlParameter("@ProductCode", System.Data.SqlDbType.VarChar, 6)
                ProductCodeParameter.Value = ""

            Else

                ProductCodeParameter = New System.Data.SqlClient.SqlParameter("@ProductCode", ProductCode)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, 100)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadFunctionDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail)("EXEC dbo.advsp_invoice_printing_load_functiondetails @ClientCode, @DivisionCode, @ProductCode, @InvoiceNumber, @InvoiceSequenceNumber, @InvoiceType, @JobNumber, @ComponentNumber, @FunctionCode, @PrintFunctionType, @ApplyExchangeRate, @ExchangeRateAmount, @TotalsShowTaxSeparately, @TotalsShowCommissionSeparately, @ShowZeroFunctionAmounts, @IsDraft, @Batch",
                                                                                                                                        ClientCodeParameter, DivisionCodeParameter, ProductCodeParameter, InvoiceNumberParameter,
                                                                                                                                        InvoiceSequenceNumberParameter, InvoiceTypeParameter, JobNumberParameter, ComponentNumberParameter, FunctionCodeParameter, PrintFunctionTypeParameter, ApplyExchangeRateParameter,
                                                                                                                                        ExchangeRateAmountParameter, TotalsShowTaxSeparatelyParameter, TotalsShowCommissionSeparatelyParameter, ShowZeroFunctionAmountsParameter, IsDraftParameter, BatchParameter)

        End Function
        Public Function LoadStandardInvoiceBillingHistory(DbContext As AdvantageFramework.Database.DbContext, InvoiceNumber As Integer, JobNumber As Integer, ComponentNumber As Short, IsDraft As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)

            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim JobNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", JobNumber)
            Dim ComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ComponentNumber", ComponentNumber)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)

            LoadStandardInvoiceBillingHistory = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)("EXEC dbo.advsp_invoice_printing_load_standardinvoicebillinghistory @InvoiceNumber, @JobNumber, @ComponentNumber, @IsDraft", InvoiceNumberParameter, JobNumberParameter, ComponentNumberParameter, IsDraftParameter)

        End Function
        Public Function LoadCurrentTTDInvoiceDetails(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumber As Integer,
                                                     SequenceNumber As Short, AddressBlockType As Short,
                                                     PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean, PrintContactAfterAddress As Boolean, PrintFunctionType As Short,
                                                     SortFunctionByType As Short, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal, TotalsShowTaxSeparately As Boolean,
                                                     TotalsShowCommissionSeparately As Boolean, UseInvoiceCategoryDescription As Boolean,
                                                     InvoiceTitle As String, InvoiceFooterCommentType As Short, InvoiceFooterComment As String, GroupingOptionInsideDescription As String, GroupingOptionOutsideDescription As String,
                                                     ShowCodes As Boolean, ContactType As Integer, IsDraft As Boolean, Batch As String, IncludeEstimateComment As Boolean, IncludeEstimateComponentComment As Boolean, IncludeEstimateQuoteComment As Boolean,
                                                     IncludeEstimateRevisionComment As Boolean, IncludeEstimateFunctionComment As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim PrintFunctionTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintFunctionType", PrintFunctionType)
            Dim SortFunctionByTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SortFunctionByType", SortFunctionByType)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim TotalsShowTaxSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowTaxSeparately", TotalsShowTaxSeparately)
            Dim TotalsShowCommissionSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowCommissionSeparately", TotalsShowCommissionSeparately)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceFooterCommentTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterCommentType", InvoiceFooterCommentType)
            Dim InvoiceFooterCommentParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionInsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionOutsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeEstimateCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComment", IncludeEstimateComment)
            Dim IncludeEstimateComponentCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComponentComment", IncludeEstimateComponentComment)
            Dim IncludeEstimateQuoteCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateQuoteComment", IncludeEstimateQuoteComment)
            Dim IncludeEstimateRevisionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateRevisionComment", IncludeEstimateRevisionComment)
            Dim IncludeEstimateFunctionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateFunctionComment", IncludeEstimateFunctionComment)

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(InvoiceFooterComment) Then

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", System.Data.SqlDbType.VarChar, -1)
                InvoiceFooterCommentParameter.Value = ""

            Else

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", InvoiceFooterComment)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionInsideDescription) Then

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionInsideDescriptionParameter.Value = ""

            Else

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", GroupingOptionInsideDescription)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionOutsideDescription) Then

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionOutsideDescriptionParameter.Value = ""

            Else

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", GroupingOptionOutsideDescription)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadCurrentTTDInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)("EXEC dbo.advsp_invoice_printing_load_currentttdinvoicedetails @UserCode, @InvoiceNumber, @SequenceNumber, @AddressBlockType, @PrintClientName, @PrintDivisionName, @PrintProductDescription, " &
                                                                                                                                                  "@PrintContactAfterAddress, @PrintFunctionType, @SortFunctionByType, @ApplyExchangeRate, @ExchangeRateAmount, " &
                                                                                                                                                  "@TotalsShowTaxSeparately, @TotalsShowCommissionSeparately, @UseInvoiceCategoryDescription, @InvoiceTitle, @InvoiceFooterCommentType, @InvoiceFooterComment, " &
                                                                                                                                                  "@GroupingOptionInsideDescription, @GroupingOptionOutsideDescription, @ShowCodes, @ContactType, @IsDraft, @Batch, @IncludeEstimateComment, @IncludeEstimateComponentComment, " &
                                                                                                                                                  "@IncludeEstimateQuoteComment, @IncludeEstimateRevisionComment, @IncludeEstimateFunctionComment",
                                                                                                                                                  UserCodeParameter, InvoiceNumberParameter, SequenceNumberParameter, AddressBlockTypeParameter,
                                                                                                                                                  PrintClientNameParameter, PrintDivisionNameParameter, PrintProductDescriptionParameter, PrintContactAfterAddressParameter, PrintFunctionTypeParameter,
                                                                                                                                                  SortFunctionByTypeParameter, ApplyExchangeRateParameter, ExchangeRateAmountParameter, TotalsShowTaxSeparatelyParameter,
                                                                                                                                                  TotalsShowCommissionSeparatelyParameter, UseInvoiceCategoryDescriptionParameter,
                                                                                                                                                  InvoiceTitleParameter, InvoiceFooterCommentTypeParameter, InvoiceFooterCommentParameter, GroupingOptionInsideDescriptionParameter,
                                                                                                                                                  GroupingOptionOutsideDescriptionParameter, ShowCodesParameter, ContactTypeParameter, IsDraftParameter, BatchParameter, IncludeEstimateCommentParameter,
                                                                                                                                                  IncludeEstimateComponentCommentParameter, IncludeEstimateQuoteCommentParameter, IncludeEstimateRevisionCommentParameter, IncludeEstimateFunctionCommentParameter)

        End Function
        Public Function LoadEstimatePriorCurrentTTDInvoiceDetails(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumber As Integer,
                                                                  SequenceNumber As Short, AddressBlockType As Short,
                                                                  PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean, PrintContactAfterAddress As Boolean,
                                                                  PrintFunctionType As Short, SortFunctionByType As Short, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal,
                                                                  TotalsShowTaxSeparately As Boolean, TotalsShowCommissionSeparately As Boolean,
                                                                  UseInvoiceCategoryDescription As Boolean, InvoiceTitle As String, InvoiceFooterCommentType As Short, InvoiceFooterComment As String,
                                                                  GroupingOptionInsideDescription As String, GroupingOptionOutsideDescription As String, ShowCodes As Boolean,
                                                                  ContactType As Integer, IsDraft As Boolean, Batch As String, IncludeEstimateComment As Boolean, IncludeEstimateComponentComment As Boolean, IncludeEstimateQuoteComment As Boolean,
                                                                  IncludeEstimateRevisionComment As Boolean, IncludeEstimateFunctionComment As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim PrintFunctionTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintFunctionType", PrintFunctionType)
            Dim SortFunctionByTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SortFunctionByType", SortFunctionByType)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim TotalsShowTaxSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowTaxSeparately", TotalsShowTaxSeparately)
            Dim TotalsShowCommissionSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowCommissionSeparately", TotalsShowCommissionSeparately)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceFooterCommentTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterCommentType", InvoiceFooterCommentType)
            Dim InvoiceFooterCommentParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionInsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupingOptionOutsideDescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeEstimateCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComment", IncludeEstimateComment)
            Dim IncludeEstimateComponentCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateComponentComment", IncludeEstimateComponentComment)
            Dim IncludeEstimateQuoteCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateQuoteComment", IncludeEstimateQuoteComment)
            Dim IncludeEstimateRevisionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateRevisionComment", IncludeEstimateRevisionComment)
            Dim IncludeEstimateFunctionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeEstimateFunctionComment", IncludeEstimateFunctionComment)

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(InvoiceFooterComment) Then

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", System.Data.SqlDbType.VarChar, -1)
                InvoiceFooterCommentParameter.Value = ""

            Else

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", InvoiceFooterComment)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionInsideDescription) Then

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionInsideDescriptionParameter.Value = ""

            Else

                GroupingOptionInsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionInsideDescription", GroupingOptionInsideDescription)

            End If

            If String.IsNullOrWhiteSpace(GroupingOptionOutsideDescription) Then

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", System.Data.SqlDbType.VarChar, -1)
                GroupingOptionOutsideDescriptionParameter.Value = ""

            Else

                GroupingOptionOutsideDescriptionParameter = New System.Data.SqlClient.SqlParameter("@GroupingOptionOutsideDescription", GroupingOptionOutsideDescription)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadEstimatePriorCurrentTTDInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)("EXEC dbo.advsp_invoice_printing_load_estimatepriorcurrentttdinvoicedetails @UserCode, @InvoiceNumber, @SequenceNumber, @AddressBlockType, " &
                                                                                                                                                                            "@PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress, @PrintFunctionType, @SortFunctionByType, " &
                                                                                                                                                                            "@ApplyExchangeRate, @ExchangeRateAmount, @TotalsShowTaxSeparately, @TotalsShowCommissionSeparately, @UseInvoiceCategoryDescription, " &
                                                                                                                                                                            "@InvoiceTitle, @InvoiceFooterCommentType, @InvoiceFooterComment, @GroupingOptionInsideDescription, @GroupingOptionOutsideDescription, " &
                                                                                                                                                                            "@ShowCodes, @ContactType, @IsDraft, @Batch, @IncludeEstimateComment, @IncludeEstimateComponentComment, " &
                                                                                                                                                                            "@IncludeEstimateQuoteComment, @IncludeEstimateRevisionComment, @IncludeEstimateFunctionComment",
                                                                                                                                                                             UserCodeParameter, InvoiceNumberParameter, SequenceNumberParameter, AddressBlockTypeParameter, PrintClientNameParameter, PrintDivisionNameParameter,
                                                                                                                                                                             PrintProductDescriptionParameter, PrintContactAfterAddressParameter, PrintFunctionTypeParameter,
                                                                                                                                                                             SortFunctionByTypeParameter, ApplyExchangeRateParameter, ExchangeRateAmountParameter,
                                                                                                                                                                             TotalsShowTaxSeparatelyParameter, TotalsShowCommissionSeparatelyParameter,
                                                                                                                                                                             UseInvoiceCategoryDescriptionParameter, InvoiceTitleParameter, InvoiceFooterCommentTypeParameter,
                                                                                                                                                                             InvoiceFooterCommentParameter, GroupingOptionInsideDescriptionParameter, GroupingOptionOutsideDescriptionParameter,
                                                                                                                                                                             ShowCodesParameter, ContactTypeParameter, IsDraftParameter, BatchParameter, IncludeEstimateCommentParameter,
                                                                                                                                                                             IncludeEstimateComponentCommentParameter, IncludeEstimateQuoteCommentParameter, IncludeEstimateRevisionCommentParameter, IncludeEstimateFunctionCommentParameter)

        End Function
        Private Function LoadLocationSettings(DbContext As AdvantageFramework.Database.DbContext, LocationCode As String) As AdvantageFramework.InvoicePrinting.Classes.LocationSetting

            Dim LocationCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@LocationCode", LocationCode)

            LoadLocationSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.LocationSetting)("EXEC dbo.advsp_invoice_printing_load_location_settings @LocationCode", LocationCodeParameter).FirstOrDefault

        End Function
        Private Function LoadInvoicePrintingComboSettings(DbContext As AdvantageFramework.Database.DbContext, IsOneTime As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)

            Dim IsOneTimeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsOneTime", IsOneTime)

            LoadInvoicePrintingComboSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)("EXEC dbo.advsp_invoice_printing_combo_settings @IsOneTime", IsOneTimeParameter)

        End Function
        Public Function LoadInvoicePrintingComboSettings(DbContext As AdvantageFramework.Database.DbContext, InvoiceFormatType As InvoiceFormatTypes, Optional ClientCode As String = Nothing) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)

            'objects
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
            Dim ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing
            Dim ComboInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim LocationSetting As AdvantageFramework.InvoicePrinting.Classes.LocationSetting = Nothing

            If DbContext IsNot Nothing Then

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_invoice_printing_cleanup_settings")

                If InvoiceFormatType = InvoiceFormatTypes.ClientDefault Then

                    If AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 0) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime)

                    End If

                    If AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 1) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency)

                    End If

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, False).Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                    Else

                        InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, False).ToList

                    End If

                ElseIf InvoiceFormatType = InvoiceFormatTypes.Agency Then

                    ComboInvoiceDefault = AdvantageFramework.Database.Procedures.ComboInvoiceDefault.LoadAgencyDefault(DbContext)

                    If ComboInvoiceDefault Is Nothing Then

                        ComboInvoiceDefault = New AdvantageFramework.Database.Entities.ComboInvoiceDefault
                        ComboInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting()

                        ComboInvoiceSetting.Save(ComboInvoiceDefault)
                        ComboInvoiceDefault.ClientOrDefault = 1

                    Else

                        ComboInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting(ComboInvoiceDefault)

                    End If

                    InvoicePrintingComboSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting
                    ComboInvoiceSetting.Save(InvoicePrintingComboSetting)

                    'InvoicePrintingComboSetting.CustomFormatName = ComboInvoiceDefault.CustomFormatName

                    If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingComboSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingComboSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingComboSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingComboSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingComboSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingComboSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingComboSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingComboSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingComboSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If DbContext.ComboInvoiceDefaults.Find(ComboInvoiceDefault.ID) Is Nothing Then

                        AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Insert(DbContext, ComboInvoiceDefault)

                    End If

                    InvoicePrintingComboSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)({InvoicePrintingComboSetting})

                ElseIf InvoiceFormatType = InvoiceFormatTypes.OneTime Then

                    ComboInvoiceDefault = AdvantageFramework.Database.Procedures.ComboInvoiceDefault.LoadOneTimeSettings(DbContext)

                    If ComboInvoiceDefault Is Nothing Then

                        ComboInvoiceDefault = New AdvantageFramework.Database.Entities.ComboInvoiceDefault
                        ComboInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting()

                        ComboInvoiceSetting.Save(ComboInvoiceDefault)
                        ComboInvoiceDefault.ClientOrDefault = 0

                    Else

                        ComboInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting(ComboInvoiceDefault)

                    End If

                    InvoicePrintingComboSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting
                    ComboInvoiceSetting.Save(InvoicePrintingComboSetting)

                    InvoicePrintingComboSetting.IsOneTime = True
                    'InvoicePrintingComboSetting.CustomFormatName = ComboInvoiceDefault.CustomFormatName

                    If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingComboSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingComboSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingComboSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingComboSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingComboSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingComboSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingComboSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingComboSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingComboSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If DbContext.ComboInvoiceDefaults.Find(ComboInvoiceDefault.ID) Is Nothing Then

                        AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Insert(DbContext, ComboInvoiceDefault)

                    End If

                    InvoicePrintingComboSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)({InvoicePrintingComboSetting})

                End If

            End If

            LoadInvoicePrintingComboSettings = InvoicePrintingComboSettings

        End Function
        Private Function LoadInvoicePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, IsOneTime As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

            Dim IsOneTimeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsOneTime", IsOneTime)

            LoadInvoicePrintingSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)("EXEC dbo.advsp_invoice_printing_settings @IsOneTime", IsOneTimeParameter)

        End Function
        Public Function LoadInvoicePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, InvoiceFormatType As InvoiceFormatTypes) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

            LoadInvoicePrintingSettings = LoadInvoicePrintingSettings(DbContext, InvoiceFormatType, Nothing)

        End Function
        Public Function LoadInvoicePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, InvoiceFormatType As InvoiceFormatTypes, ClientCode As String) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

            'objects
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim LocationSetting As AdvantageFramework.InvoicePrinting.Classes.LocationSetting = Nothing

            If DbContext IsNot Nothing Then

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_invoice_printing_cleanup_settings")

                If InvoiceFormatType = InvoiceFormatTypes.ClientDefault Then

                    If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 0) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime)

                    End If

                    If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 1) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency)

                    End If

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, ClientCode)

                        If ProductionInvoiceDefault Is Nothing Then

                            ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault
                            ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting()

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)
                            ProductionInvoiceDefault.ClientOrDefault = 2
                            ProductionInvoiceDefault.ClientCode = ClientCode

                        Else

                            ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(ProductionInvoiceDefault)

                        End If

                        InvoicePrintingSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
                        ProductionInvoiceSetting.Save(InvoicePrintingSetting)

                        InvoicePrintingSetting.CustomFormatName = ProductionInvoiceDefault.CustomFormatName
                        InvoicePrintingSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                        InvoicePrintingSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                        InvoicePrintingSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.LocationCode) = False Then

                            LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingSetting.LocationCode)

                            If LocationSetting IsNot Nothing Then

                                InvoicePrintingSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                                InvoicePrintingSetting.PageFooterComment = LocationSetting.PageFooterComment
                                InvoicePrintingSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                                InvoicePrintingSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                                InvoicePrintingSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                                InvoicePrintingSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape

                            End If

                        End If

                        If ProductionInvoiceDefault.IsEntityBeingAdded() Then

                            If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault) Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PROD_INV_DEF SET FNC_ET_FNC_COMM = 0,FNC_AP_FNC_COMM = 0,FNC_IO_FNC_COMM = 0,FNC_BILL_APPR_CL_COMM = 0,LOGO_BLOCK_INCL = 0,NAME_OVERIDE = 0,INV_USER_INCL = 0 WHERE PROD_INV_DEF_ID = {0}", ProductionInvoiceDefault.ID))

                            End If

                        End If

                        InvoicePrintingSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)({InvoicePrintingSetting})

                    Else

                        InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, False).ToList

                    End If

                ElseIf InvoiceFormatType = InvoiceFormatTypes.Agency Then

                    ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                    If ProductionInvoiceDefault Is Nothing Then

                        ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault
                        ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting()

                        ProductionInvoiceSetting.Save(ProductionInvoiceDefault)
                        ProductionInvoiceDefault.ClientOrDefault = 1

                    Else

                        ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(ProductionInvoiceDefault)

                    End If

                    InvoicePrintingSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
                    ProductionInvoiceSetting.Save(InvoicePrintingSetting)

                    InvoicePrintingSetting.IsOneTime = False
                    InvoicePrintingSetting.CustomFormatName = ProductionInvoiceDefault.CustomFormatName
                    InvoicePrintingSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                    InvoicePrintingSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                    InvoicePrintingSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If ProductionInvoiceDefault.IsEntityBeingAdded() Then

                        If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault) Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PROD_INV_DEF SET FNC_ET_FNC_COMM = 0,FNC_AP_FNC_COMM = 0,FNC_IO_FNC_COMM = 0,FNC_BILL_APPR_CL_COMM = 0,LOGO_BLOCK_INCL = 0,NAME_OVERIDE = 0,INV_USER_INCL = 0 WHERE PROD_INV_DEF_ID = {0}", ProductionInvoiceDefault.ID))

                        End If

                    End If

                    InvoicePrintingSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)({InvoicePrintingSetting})

                ElseIf InvoiceFormatType = InvoiceFormatTypes.OneTime Then

                    ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadOneTimeSettings(DbContext)

                    If ProductionInvoiceDefault Is Nothing Then

                        ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault
                        ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting()

                        ProductionInvoiceSetting.Save(ProductionInvoiceDefault)
                        ProductionInvoiceDefault.ClientOrDefault = 0

                    Else

                        ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(ProductionInvoiceDefault)

                    End If

                    InvoicePrintingSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
                    ProductionInvoiceSetting.Save(InvoicePrintingSetting)

                    InvoicePrintingSetting.IsOneTime = True
                    InvoicePrintingSetting.CustomFormatName = ProductionInvoiceDefault.CustomFormatName
                    InvoicePrintingSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                    InvoicePrintingSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                    InvoicePrintingSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If ProductionInvoiceDefault.IsEntityBeingAdded() Then

                        If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault) Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PROD_INV_DEF SET FNC_ET_FNC_COMM = 0,FNC_AP_FNC_COMM = 0,FNC_IO_FNC_COMM = 0,FNC_BILL_APPR_CL_COMM = 0,LOGO_BLOCK_INCL = 0,NAME_OVERIDE = 0,INV_USER_INCL = 0 WHERE PROD_INV_DEF_ID = {0}", ProductionInvoiceDefault.ID))

                        End If

                    End If

                    InvoicePrintingSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)({InvoicePrintingSetting})

                End If

            End If

            LoadInvoicePrintingSettings = InvoicePrintingSettings

        End Function
        Private Function LoadInvoicePrintingMediaSettings(DbContext As AdvantageFramework.Database.DbContext, IsOneTime As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)

            Dim IsOneTimeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsOneTime", IsOneTime)

            LoadInvoicePrintingMediaSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)("EXEC dbo.advsp_invoice_printing_media_settings @IsOneTime", IsOneTimeParameter)

        End Function
        Private Function LoadInvoicePrintingMediaSettingsForClients(DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)

            'objects
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim LocationSetting As AdvantageFramework.InvoicePrinting.Classes.LocationSetting = Nothing

            If DbContext IsNot Nothing Then



            End If

            LoadInvoicePrintingMediaSettingsForClients = InvoicePrintingMediaSettings

        End Function
        Public Function LoadInvoicePrintingMediaSettings(DbContext As AdvantageFramework.Database.DbContext, InvoiceFormatType As InvoiceFormatTypes) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)

            LoadInvoicePrintingMediaSettings = LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType, Nothing)

        End Function
        Public Function LoadInvoicePrintingMediaSettings(DbContext As AdvantageFramework.Database.DbContext, InvoiceFormatType As InvoiceFormatTypes, ClientCode As String) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)

            'objects
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim LocationSetting As AdvantageFramework.InvoicePrinting.Classes.LocationSetting = Nothing

            If DbContext IsNot Nothing Then

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_invoice_printing_cleanup_settings")

                If InvoiceFormatType = InvoiceFormatTypes.ClientDefault Then

                    If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 0) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime)

                    End If

                    If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 1) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency)

                    End If

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, ClientCode)

                        If MediaInvoiceDefault Is Nothing Then

                            MediaInvoiceDefault = New AdvantageFramework.Database.Entities.MediaInvoiceDefault
                            MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting()

                            MediaInvoiceSetting.Save(MediaInvoiceDefault)
                            MediaInvoiceDefault.ClientOrDefault = 2
                            MediaInvoiceDefault.ClientCode = ClientCode

                        Else

                            MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(MediaInvoiceDefault)

                        End If

                        InvoicePrintingMediaSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
                        MediaInvoiceSetting.Save(InvoicePrintingMediaSetting)

                        InvoicePrintingMediaSetting.MagazineCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                        InvoicePrintingMediaSetting.NewspaperCustomFormatName = MediaInvoiceDefault.NewspaperCustomFormat
                        InvoicePrintingMediaSetting.InternetCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                        InvoicePrintingMediaSetting.OutdoorCustomFormatName = MediaInvoiceDefault.InternetCustomFormat
                        InvoicePrintingMediaSetting.RadioCustomFormatName = MediaInvoiceDefault.RadioCustomFormat
                        InvoicePrintingMediaSetting.TVCustomFormatName = MediaInvoiceDefault.TVCustomFormat
                        InvoicePrintingMediaSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                        InvoicePrintingMediaSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                        InvoicePrintingMediaSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                        If String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.LocationCode) = False Then

                            LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingMediaSetting.LocationCode)

                            If LocationSetting IsNot Nothing Then

                                InvoicePrintingMediaSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                                InvoicePrintingMediaSetting.PageFooterComment = LocationSetting.PageFooterComment
                                InvoicePrintingMediaSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                                InvoicePrintingMediaSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                                InvoicePrintingMediaSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                                InvoicePrintingMediaSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape

                            End If

                        End If

                        If MediaInvoiceDefault.IsEntityBeingAdded() Then

                            AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                        End If

                        InvoicePrintingMediaSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)({InvoicePrintingMediaSetting})

                    Else

                        InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, False).ToList

                    End If

                ElseIf InvoiceFormatType = InvoiceFormatTypes.Agency Then

                    MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)

                    If MediaInvoiceDefault Is Nothing Then

                        MediaInvoiceDefault = New AdvantageFramework.Database.Entities.MediaInvoiceDefault
                        MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting()

                        MediaInvoiceSetting.Save(MediaInvoiceDefault)
                        MediaInvoiceDefault.ClientOrDefault = 1

                    Else

                        MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(MediaInvoiceDefault)

                    End If

                    InvoicePrintingMediaSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
                    MediaInvoiceSetting.Save(InvoicePrintingMediaSetting)

                    InvoicePrintingMediaSetting.IsOneTime = False
                    InvoicePrintingMediaSetting.MagazineCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                    InvoicePrintingMediaSetting.NewspaperCustomFormatName = MediaInvoiceDefault.NewspaperCustomFormat
                    InvoicePrintingMediaSetting.InternetCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                    InvoicePrintingMediaSetting.OutdoorCustomFormatName = MediaInvoiceDefault.InternetCustomFormat
                    InvoicePrintingMediaSetting.RadioCustomFormatName = MediaInvoiceDefault.RadioCustomFormat
                    InvoicePrintingMediaSetting.TVCustomFormatName = MediaInvoiceDefault.TVCustomFormat
                    InvoicePrintingMediaSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                    InvoicePrintingMediaSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                    InvoicePrintingMediaSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                    If String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingMediaSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingMediaSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingMediaSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingMediaSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingMediaSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingMediaSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingMediaSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingMediaSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingMediaSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If MediaInvoiceDefault.IsEntityBeingAdded() Then

                        AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                    End If

                    InvoicePrintingMediaSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)({InvoicePrintingMediaSetting})

                ElseIf InvoiceFormatType = InvoiceFormatTypes.OneTime Then

                    MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadOneTimeSettings(DbContext)

                    If MediaInvoiceDefault Is Nothing Then

                        MediaInvoiceDefault = New AdvantageFramework.Database.Entities.MediaInvoiceDefault
                        MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting()

                        MediaInvoiceSetting.Save(MediaInvoiceDefault)
                        MediaInvoiceDefault.ClientOrDefault = 0

                    Else

                        MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(MediaInvoiceDefault)

                    End If

                    InvoicePrintingMediaSetting = New AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
                    MediaInvoiceSetting.Save(InvoicePrintingMediaSetting)

                    InvoicePrintingMediaSetting.IsOneTime = True
                    InvoicePrintingMediaSetting.MagazineCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                    InvoicePrintingMediaSetting.NewspaperCustomFormatName = MediaInvoiceDefault.NewspaperCustomFormat
                    InvoicePrintingMediaSetting.InternetCustomFormatName = MediaInvoiceDefault.MagazineCustomFormat
                    InvoicePrintingMediaSetting.OutdoorCustomFormatName = MediaInvoiceDefault.InternetCustomFormat
                    InvoicePrintingMediaSetting.RadioCustomFormatName = MediaInvoiceDefault.RadioCustomFormat
                    InvoicePrintingMediaSetting.TVCustomFormatName = MediaInvoiceDefault.TVCustomFormat
                    InvoicePrintingMediaSetting.CityTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCityTaxLabel(DbContext)
                    InvoicePrintingMediaSetting.CountyTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadCountyTaxLabel(DbContext)
                    InvoicePrintingMediaSetting.StateTaxLabel = AdvantageFramework.Database.Procedures.GeneralDescription.LoadStateTaxLabel(DbContext)

                    If String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.LocationCode) = False Then

                        LocationSetting = LoadLocationSettings(DbContext, InvoicePrintingMediaSetting.LocationCode)

                        If LocationSetting IsNot Nothing Then

                            InvoicePrintingMediaSetting.PageHeaderComment = LocationSetting.PageHeaderComment
                            InvoicePrintingMediaSetting.PageFooterComment = LocationSetting.PageFooterComment
                            InvoicePrintingMediaSetting.PageHeaderLogoPath = LocationSetting.PageHeaderLogoPath
                            InvoicePrintingMediaSetting.PageHeaderLogoPathLandscape = LocationSetting.PageHeaderLogoPathLandscape
                            InvoicePrintingMediaSetting.PageFooterLogoPath = LocationSetting.PageFooterLogoPath
                            InvoicePrintingMediaSetting.PageFooterLogoPathLandscape = LocationSetting.PageFooterLogoPathLandscape
                            InvoicePrintingMediaSetting.ShowPageHeaderLogo = LocationSetting.ShowPageHeaderLogo
                            InvoicePrintingMediaSetting.ShowPageFooterLogo = LocationSetting.ShowPageFooterLogo

                        End If

                    End If

                    If MediaInvoiceDefault.IsEntityBeingAdded() Then

                        AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                    End If

                    InvoicePrintingMediaSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)({InvoicePrintingMediaSetting})

                End If

            End If

            LoadInvoicePrintingMediaSettings = InvoicePrintingMediaSettings

        End Function
        Public Function LoadMediaInvoiceDetails(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, InvoiceNumber As Integer,
                                                SequenceNumber As Short, InvoiceType As String,
                                                AddressBlockType As Short, PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean,
                                                PrintContactAfterAddress As Boolean, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal, TotalsShowTaxSeparately As Boolean,
                                                TotalsShowCommissionSeparately As Boolean, TotalsShowRebateSeparately As Boolean, UseInvoiceCategoryDescription As Boolean,
                                                InvoiceTitle As String, InvoiceFooterCommentType As Short, InvoiceFooterComment As String, ShowCodes As Boolean,
                                                ContactType As Integer, IsDraft As Boolean, Batch As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetail)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", UserCode)
            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim InvoiceTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceType", InvoiceType)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim TotalsShowTaxSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowTaxSeparately", TotalsShowTaxSeparately)
            Dim TotalsShowCommissionSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowCommissionSeparately", TotalsShowCommissionSeparately)
            Dim TotalsShowRebateSeparatelyParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TotalsShowRebateSeparately", TotalsShowRebateSeparately)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceFooterCommentTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterCommentType", InvoiceFooterCommentType)
            Dim InvoiceFooterCommentParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(InvoiceFooterComment) Then

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", System.Data.SqlDbType.VarChar, -1)
                InvoiceFooterCommentParameter.Value = ""

            Else

                InvoiceFooterCommentParameter = New System.Data.SqlClient.SqlParameter("@InvoiceFooterComment", InvoiceFooterComment)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadMediaInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetail)("EXEC dbo.advsp_invoice_printing_load_mediainvoicedetail @UserCode, @InvoiceNumber, @SequenceNumber, @InvoiceType, @AddressBlockType, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress, @ApplyExchangeRate, @ExchangeRateAmount, @TotalsShowTaxSeparately, @TotalsShowCommissionSeparately, @TotalsShowRebateSeparately, @UseInvoiceCategoryDescription, @InvoiceTitle, @InvoiceFooterCommentType, @InvoiceFooterComment, @ShowCodes, @ContactType, @IsDraft, @Batch",
                                                                                                                                        UserCodeParameter, InvoiceNumberParameter, SequenceNumberParameter, InvoiceTypeParameter, AddressBlockTypeParameter,
                                                                                                                                        PrintClientNameParameter, PrintDivisionNameParameter, PrintProductDescriptionParameter, PrintContactAfterAddressParameter, ApplyExchangeRateParameter,
                                                                                                                                        ExchangeRateAmountParameter, TotalsShowTaxSeparatelyParameter, TotalsShowCommissionSeparatelyParameter, TotalsShowRebateSeparatelyParameter,
                                                                                                                                        UseInvoiceCategoryDescriptionParameter, InvoiceTitleParameter, InvoiceFooterCommentTypeParameter, InvoiceFooterCommentParameter,
                                                                                                                                        ShowCodesParameter, ContactTypeParameter, IsDraftParameter, BatchParameter)

        End Function
        Public Function LoadMediaInvoiceBillingHistory(DbContext As AdvantageFramework.Database.DbContext, InvoiceNumber As Integer, OrderNumber As Integer, IsDraft As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)

            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim OrderNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@OrderNumber", OrderNumber)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)

            LoadMediaInvoiceBillingHistory = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)("EXEC dbo.advsp_invoice_printing_load_mediainvoicebillinghistory @InvoiceNumber, @OrderNumber, @IsDraft", InvoiceNumberParameter, OrderNumberParameter, IsDraftParameter)

        End Function
        Public Function SaveInvoice(DbContext As AdvantageFramework.Database.DbContext, AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            Try

				DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ACCT_REC SET DUE_DATE = {0}, INV_CAT = {1}, CDP_CONTACT_ID = {2} WHERE AR_INV_NBR = {3} And [AR_INV_SEQ] = {4} And [AR_TYPE] = '{5}'",
																If(AccountReceivableInvoice.DueDate.HasValue, "'" & AccountReceivableInvoice.DueDate.Value.ToString("MM/dd/yyyy") & "'", "NULL"),
																If(String.IsNullOrWhiteSpace(AccountReceivableInvoice.InvoiceCategoryCode) = False, "'" & AccountReceivableInvoice.InvoiceCategoryCode & "'", "NULL"),
																If(AccountReceivableInvoice.InvoiceContact.HasValue, AccountReceivableInvoice.InvoiceContact.Value, "NULL"),
																AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType))

				If AccountReceivableInvoice.BillingCommentID.HasValue Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[BILL_COMMENT] SET BILL_COMMENT = {3} WHERE [AR_INV_NBR] = {0} AND [AR_INV_SEQ] = {1} AND [AR_TYPE] = '{2}'",
                                                                    AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType,
                                                                    If(String.IsNullOrWhiteSpace(AccountReceivableInvoice.InvoiceComment) = False, "'" & AccountReceivableInvoice.InvoiceComment.Replace("'", "''") & "'", "NULL")))

                Else

                    If String.IsNullOrWhiteSpace(AccountReceivableInvoice.InvoiceComment) = False Then

                        If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.BILL_COMMENT").First = 0 Then

                            AccountReceivableInvoice.BillingCommentID = 1

                        Else

                            AccountReceivableInvoice.BillingCommentID = DbContext.Database.SqlQuery(Of Integer)("SELECT MAX(ISNULL(BC_ID, 0)) + 1 FROM dbo.BILL_COMMENT").First

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[BILL_COMMENT]([BC_ID], [AR_INV_NBR], [AR_INV_SEQ], [AR_TYPE], [BILL_COMMENT]) VALUES ({0}, {1}, {2}, '{3}', '{4}')",
                                                                        AccountReceivableInvoice.BillingCommentID, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType,
                                                                        AccountReceivableInvoice.InvoiceComment.Replace("'", "''")))

                    End If

                End If

                If AccountReceivableInvoice.InvoiceContact.HasValue Then

                    ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, AccountReceivableInvoice.InvoiceContact.Value)

                    If ClientContact IsNot Nothing Then

                        AccountReceivableInvoice.InvoiceContactName = ClientContact.ToString

                    End If

                Else

                    AccountReceivableInvoice.InvoiceContactName = Nothing

                End If

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

            SaveInvoice = Saved

        End Function
        Public Function LoadAccountReceivableInvoices(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, StartDate As Date, EndDate As Date,
                                                      IncludeProduction As Boolean, IncludeMagazine As Boolean, IncludeNewspaper As Boolean, IncludeInternet As Boolean,
                                                      IncludeOutOfHome As Boolean, IncludeRadio As Boolean, IncludeTV As Boolean, IsDraft As Boolean, InvoiceNumber As Integer,
                                                      CombineCoopInvoices As Boolean) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim StartDateString As String = ""
            Dim EndDateString As String = ""

            Try

                If StartDate <> Date.MinValue Then

                    StartDate = CDate(StartDate.ToShortDateString)

                    StartDateString = "'" & StartDate.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'"

                Else

                    StartDateString = "NULL"

                End If

            Catch ex As Exception
                StartDateString = "NULL"
            End Try

            Try

                If EndDate <> Date.MinValue Then

                    EndDate = CDate(EndDate.ToShortDateString)

                    EndDateString = "'" & EndDate.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'"

                Else

                    EndDateString = "NULL"

                End If

            Catch ex As Exception
                EndDateString = "NULL"
            End Try

            Try

                AccountReceivableInvoices = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)(String.Format("EXEC [dbo].[advsp_invoice_printing_load] '{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}",
                                                                                                                                                               UserCode, StartDateString, EndDateString,
                                                                                                                                                               If(IncludeProduction, 1, 0),
                                                                                                                                                               If(IncludeMagazine, 1, 0),
                                                                                                                                                               If(IncludeNewspaper, 1, 0),
                                                                                                                                                               If(IncludeInternet, 1, 0),
                                                                                                                                                               If(IncludeOutOfHome, 1, 0),
                                                                                                                                                               If(IncludeRadio, 1, 0),
                                                                                                                                                               If(IncludeTV, 1, 0),
                                                                                                                                                               If(IsDraft, 1, 0),
                                                                                                                                                               InvoiceNumber,
                                                                                                                                                               If(CombineCoopInvoices, 1, 0))).ToList

            Catch ex As Exception
                AccountReceivableInvoices = Nothing
            End Try

            LoadAccountReceivableInvoices = AccountReceivableInvoices

        End Function
        Public Function LoadAccountReceivableBillingInvoices(DbContext As AdvantageFramework.Database.DbContext, UserCode As String) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            Try

                AccountReceivableInvoices = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)(String.Format("EXEC [dbo].[advsp_invoice_printing_load_billing_invoices] '{0}'", UserCode)).ToList

            Catch ex As Exception
                AccountReceivableInvoices = Nothing
            End Try

            LoadAccountReceivableBillingInvoices = AccountReceivableInvoices

        End Function
        Public Function LoadAvailableInvoices() As Generic.List(Of Generic.KeyValuePair(Of Long, String))

            'objects
            Dim InvoiceDataSetsList As Generic.List(Of Generic.KeyValuePair(Of Long, String)) = Nothing

            InvoiceDataSetsList = New Generic.List(Of Generic.KeyValuePair(Of Long, String))

            For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.InvoicePrinting.InvoiceTypes))

                InvoiceDataSetsList.Add(New Generic.KeyValuePair(Of Long, String)(CLng(EnumObject.Code), EnumObject.Description))

            Next

            LoadAvailableInvoices = InvoiceDataSetsList

        End Function
        Public Function ShowFunctionDetails(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting, ByVal FunctionType As String) As Boolean

            'objects
            Dim CanShowFunctionDetails As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(FunctionType) = False Then

                    If FunctionType = "E" Then

                        CanShowFunctionDetails = (InvoicePrintingSetting.ShowEmployeeTimeDescription OrElse InvoicePrintingSetting.ShowEmployeeTimeDate OrElse InvoicePrintingSetting.ShowEmployeeTimeRate OrElse InvoicePrintingSetting.ShowEmployeeTimeFunctionComment)

                    ElseIf FunctionType = "I" Then

                        CanShowFunctionDetails = (InvoicePrintingSetting.ShowIncomeOnlyDescription OrElse InvoicePrintingSetting.ShowIncomeOnlyDate OrElse InvoicePrintingSetting.ShowIncomeOnlyRate OrElse InvoicePrintingSetting.ShowIncomeOnlyFunctionComment)

                    ElseIf FunctionType = "V" Then

                        CanShowFunctionDetails = (InvoicePrintingSetting.ShowAPDescription OrElse InvoicePrintingSetting.ShowAPDate OrElse InvoicePrintingSetting.ShowAPRate OrElse InvoicePrintingSetting.ShowAccountsPayableFunctionComment)

                    End If

                End If

            End If

            ShowFunctionDetails = CanShowFunctionDetails

        End Function
        Public Function ShowRate(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) As Boolean

            'objects
            Dim CanShowRate As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                CanShowRate = (InvoicePrintingSetting.ShowEmployeeTimeRate OrElse InvoicePrintingSetting.ShowIncomeOnlyRate OrElse InvoicePrintingSetting.ShowAPRate)

            End If

            ShowRate = CanShowRate

        End Function
        Public Function ShowRate(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting, ByVal FunctionType As String) As Boolean

            'objects
            Dim CanShowRate As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(FunctionType) = False Then

                    If FunctionType = "E" Then

                        CanShowRate = InvoicePrintingSetting.ShowEmployeeTimeRate

                    ElseIf FunctionType = "I" Then

                        CanShowRate = InvoicePrintingSetting.ShowIncomeOnlyRate

                    ElseIf FunctionType = "V" Then

                        CanShowRate = InvoicePrintingSetting.ShowAPRate

                    End If

                End If

            End If

            ShowRate = CanShowRate

        End Function
        Public Function ShowDate(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) As Boolean

            'objects
            Dim CanShowDate As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                CanShowDate = (InvoicePrintingSetting.ShowEmployeeTimeDate OrElse InvoicePrintingSetting.ShowIncomeOnlyDate OrElse InvoicePrintingSetting.ShowAPDate)

            End If

            ShowDate = CanShowDate

        End Function
        Public Function ShowDate(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting, ByVal FunctionType As String) As Boolean

            'objects
            Dim CanShowDate As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(FunctionType) = False Then

                    If FunctionType = "E" Then

                        CanShowDate = InvoicePrintingSetting.ShowEmployeeTimeDate

                    ElseIf FunctionType = "I" Then

                        CanShowDate = InvoicePrintingSetting.ShowIncomeOnlyDate

                    ElseIf FunctionType = "V" Then

                        CanShowDate = InvoicePrintingSetting.ShowAPDate

                    End If

                End If

            End If

            ShowDate = CanShowDate

        End Function
        Public Function ShowDescription(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) As Boolean

            'objects
            Dim CanShowDescription As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                CanShowDescription = (InvoicePrintingSetting.ShowEmployeeTimeDescription OrElse InvoicePrintingSetting.ShowIncomeOnlyDescription OrElse InvoicePrintingSetting.ShowAPDescription)

            End If

            ShowDescription = CanShowDescription

        End Function
        Public Function ShowDescription(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting, ByVal FunctionType As String) As Boolean

            'objects
            Dim CanShowDescription As Boolean = False

            If InvoicePrintingSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(FunctionType) = False Then

                    If FunctionType = "E" Then

                        CanShowDescription = InvoicePrintingSetting.ShowEmployeeTimeDescription

                    ElseIf FunctionType = "I" Then

                        CanShowDescription = InvoicePrintingSetting.ShowIncomeOnlyDescription

                    ElseIf FunctionType = "V" Then

                        CanShowDescription = InvoicePrintingSetting.ShowAPDescription

                    End If

                End If

            End If

            ShowDescription = CanShowDescription

        End Function
        Public Function LoadInvoiceBackupDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, InvoiceNumber As Integer, SequenceNumber As Short,
                                                 AddressBlockType As Short, PrintClientName As Boolean, PrintDivisionName As Boolean, PrintProductDescription As Boolean, PrintContactAfterAddress As Boolean,
                                                 PrintFunctionType As Short, SortFunctionByType As Short, ApplyExchangeRate As Short, ExchangeRateAmount As Decimal,
                                                 UseInvoiceCategoryDescription As Boolean, InvoiceTitle As String, ShowCodes As Boolean,
                                                 ContactType As Integer, ShowZeroFunctionAmounts As Boolean, IsDraft As Boolean, Batch As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBackupDetail)

            Dim InvoiceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@InvoiceNumber", InvoiceNumber)
            Dim SequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SequenceNumber)
            Dim AddressBlockTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@AddressBlockType", AddressBlockType)
            Dim PrintClientNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintClientName", PrintClientName)
            Dim PrintDivisionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintDivisionName", PrintDivisionName)
            Dim PrintProductDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintProductDescription", PrintProductDescription)
            Dim PrintContactAfterAddressParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintContactAfterAddress", PrintContactAfterAddress)
            Dim PrintFunctionTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintFunctionType", PrintFunctionType)
            Dim SortFunctionByTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@SortFunctionByType", SortFunctionByType)
            Dim ApplyExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ApplyExchangeRate", ApplyExchangeRate)
            Dim ExchangeRateAmountParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRateAmount", ExchangeRateAmount)
            Dim UseInvoiceCategoryDescriptionParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UseInvoiceCategoryDescription", UseInvoiceCategoryDescription)
            Dim InvoiceTitleParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowCodesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowCodes", ShowCodes)
            Dim ContactTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ContactType", ContactType)
            Dim ShowZeroFunctionAmountsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowZeroFunctionAmounts", ShowZeroFunctionAmounts)
            Dim IsDraftParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsDraft", IsDraft)
            Dim BatchParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrEmpty(InvoiceTitle) Then

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", System.Data.SqlDbType.VarChar, -1)
                InvoiceTitleParameter.Value = ""

            Else

                InvoiceTitleParameter = New System.Data.SqlClient.SqlParameter("@InvoiceTitle", InvoiceTitle)

            End If

            If String.IsNullOrWhiteSpace(Batch) Then

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", System.Data.SqlDbType.VarChar, -1)
                BatchParameter.Value = ""

            Else

                BatchParameter = New System.Data.SqlClient.SqlParameter("@Batch", Batch)

            End If

            LoadInvoiceBackupDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBackupDetail)("EXEC dbo.advsp_invoice_printing_load_invoicebackupdetail " &
                                                                                                                                          "@InvoiceNumber, @SequenceNumber, @AddressBlockType, @PrintClientName, @PrintDivisionName, " &
                                                                                                                                          "@PrintProductDescription, @PrintContactAfterAddress, @PrintFunctionType, " &
                                                                                                                                          "@SortFunctionByType, @ApplyExchangeRate, @ExchangeRateAmount, " &
                                                                                                                                          "@UseInvoiceCategoryDescription, @InvoiceTitle, @ShowCodes, @ContactType, @ShowZeroFunctionAmounts, @IsDraft, @Batch",
                                                                                                                                          InvoiceNumberParameter, SequenceNumberParameter, AddressBlockTypeParameter, PrintClientNameParameter, PrintDivisionNameParameter,
                                                                                                                                          PrintProductDescriptionParameter, PrintContactAfterAddressParameter, PrintFunctionTypeParameter,
                                                                                                                                          SortFunctionByTypeParameter, ApplyExchangeRateParameter, ExchangeRateAmountParameter,
                                                                                                                                          UseInvoiceCategoryDescriptionParameter, InvoiceTitleParameter, ShowCodesParameter, ContactTypeParameter, ShowZeroFunctionAmountsParameter, IsDraftParameter, BatchParameter)

        End Function
        Public Function LoadDefaultSenderName(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SenderName As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SENDERNAME.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                SenderName = Setting.Value

            End If

            LoadDefaultSenderName = SenderName

        End Function
        Public Function LoadDefaultFromEmail(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim FromEmail As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_FROMEMAIL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                FromEmail = Setting.Value

            End If

            LoadDefaultFromEmail = FromEmail

        End Function
        Public Function LoadDefaultReplyTo(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ReplyTo As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_REPLYTO.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                ReplyTo = Setting.Value

            End If

            LoadDefaultReplyTo = ReplyTo

        End Function
        Public Function LoadDefaultEmailSubject(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EmailSubject As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_EMAILSUBJECT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EmailSubject = Setting.Value

            End If

            LoadDefaultEmailSubject = EmailSubject

        End Function
        Public Function LoadDefaultEmailBody(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EmailBody As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_EMAILBODY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EmailBody = Setting.Value

            End If

            LoadDefaultEmailBody = EmailBody

        End Function
		Public Function LoadDefaultUploadDocumentManager(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim UploadDocumentManager As Boolean = False

			Try

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_UPDOC.ToString)

			Catch ex As Exception
				Setting = Nothing
			End Try

			If Setting IsNot Nothing Then

				UploadDocumentManager = Setting.Value

			End If

			LoadDefaultUploadDocumentManager = UploadDocumentManager

		End Function
		Public Function LoadDefaultSinglePDF(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim SinglePDF As Boolean = False

			Try

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SINGLEPDF.ToString)

			Catch ex As Exception
				Setting = Nothing
			End Try

			If Setting IsNot Nothing Then

				SinglePDF = Setting.Value

			End If

			LoadDefaultSinglePDF = SinglePDF

		End Function
		Public Function LoadDefaultIncludeCoverSheet(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim IncludeCoverSheet As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_INCL_CS.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                IncludeCoverSheet = Setting.Value

            End If

            LoadDefaultIncludeCoverSheet = IncludeCoverSheet

        End Function
        Public Function LoadDefaultCCSender(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CCSender As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_CCSENDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CCSender = Setting.Value

            End If

            LoadDefaultCCSender = CCSender

        End Function
        Public Function LoadDefaultPackageType(ByVal DataContext As AdvantageFramework.Database.DataContext) As Integer

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PackageType As Integer = 1

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_PACKAGETYPE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                PackageType = Setting.Value

            End If

            LoadDefaultPackageType = PackageType

        End Function
        Public Function LoadDefaultSortOption(ByVal DataContext As AdvantageFramework.Database.DataContext) As Integer

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SortOption As Integer = 1

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SORTOPTION.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                SortOption = Setting.Value

            End If

            LoadDefaultSortOption = SortOption

        End Function
        Public Function LoadDefaultEmailProductContact(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EmailProductContact As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_PRINTPRD.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EmailProductContact = Setting.Value

            End If

            LoadDefaultEmailProductContact = EmailProductContact

        End Function
        Public Function LoadCombineCoopInvoices(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CombineCoopInvoices As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COMB_COOP_INV.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CombineCoopInvoices = Setting.Value

            End If

            LoadCombineCoopInvoices = CombineCoopInvoices

        End Function
        Public Function LoadCoversheetLayout(ByVal DataContext As AdvantageFramework.Database.DataContext) As CoversheetLayouts

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CoversheetLayout As CoversheetLayouts = CoversheetLayouts.Default

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_LAYOUT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CoversheetLayout = Setting.Value

            End If

            LoadCoversheetLayout = CoversheetLayout

        End Function
        Public Function LoadCoversheetTitle(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CoversheetTitle As String = String.Empty

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_TITLE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CoversheetTitle = Setting.Value

            End If

            If String.IsNullOrWhiteSpace(CoversheetTitle) Then

                CoversheetTitle = "Invoice Cover Sheet"

            End If

            LoadCoversheetTitle = CoversheetTitle

        End Function
        Public Function LoadCoversheetContact(ByVal DataContext As AdvantageFramework.Database.DataContext) As CoversheetContacts

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CoversheetContact As CoversheetContacts = CoversheetContacts.None

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CoversheetContact = Setting.Value

            End If

            LoadCoversheetContact = CoversheetContact

        End Function
        Public Function LoadOverrideInvoiceFilename(DataContext As AdvantageFramework.Database.DataContext) As OverrideInvoiceFilename

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim OverrideInvoiceFilename As OverrideInvoiceFilename = OverrideInvoiceFilename.Default

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_FILE_NAME.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                OverrideInvoiceFilename = Setting.Value

            End If

            LoadOverrideInvoiceFilename = OverrideInvoiceFilename

        End Function
        Public Function LoadCoversheetContactType(ByVal DataContext As AdvantageFramework.Database.DataContext) As Integer

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ContactType As Integer = 0

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_TYPE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                ContactType = Setting.Value

            End If

            LoadCoversheetContactType = ContactType

        End Function
        Public Function LoadCoversheetContactLocation(ByVal DataContext As AdvantageFramework.Database.DataContext) As CoversheetContactLocations

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CoversheetContactLocation As CoversheetContactLocations = CoversheetContactLocations.AttnLine

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_LOC.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CoversheetContactLocation = Setting.Value

            End If

            LoadCoversheetContactLocation = CoversheetContactLocation

        End Function
        Public Function LoadDefaultSendSingleEmail(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SendSingleEmail As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SINGLEEMAIL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                SendSingleEmail = Setting.Value

            End If

            LoadDefaultSendSingleEmail = SendSingleEmail

        End Function
        Public Function SaveDefaultSenderName(ByVal DataContext As AdvantageFramework.Database.DataContext, SenderName As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SENDERNAME.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = SenderName

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_SENDERNAME.ToString
                Setting.Value = SenderName
                Setting.OrderNumber = 1
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultSenderName = Saved

        End Function
        Public Function SaveDefaultFromEmail(ByVal DataContext As AdvantageFramework.Database.DataContext, FromEmail As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_FROMEMAIL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = FromEmail

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_FROMEMAIL.ToString
                Setting.Value = FromEmail
                Setting.OrderNumber = 1
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultFromEmail = Saved

        End Function
        Public Function SaveDefaultReplyTo(ByVal DataContext As AdvantageFramework.Database.DataContext, ReplyTo As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_REPLYTO.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = ReplyTo

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_REPLYTO.ToString
                Setting.Value = ReplyTo
                Setting.OrderNumber = 1
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultReplyTo = Saved

        End Function
        Public Function SaveDefaultEmailSubject(ByVal DataContext As AdvantageFramework.Database.DataContext, EmailSubject As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_EMAILSUBJECT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EmailSubject

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_EMAILSUBJECT.ToString
                Setting.Value = EmailSubject
                Setting.OrderNumber = 1
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultEmailSubject = Saved

        End Function
        Public Function SaveDefaultEmailBody(ByVal DataContext As AdvantageFramework.Database.DataContext, EmailBody As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_EMAILBODY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EmailBody

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_EMAILBODY.ToString
                Setting.Value = EmailBody
                Setting.OrderNumber = 2
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultEmailBody = Saved

        End Function
		Public Function SaveDefaultUploadDocumentManager(ByVal DataContext As AdvantageFramework.Database.DataContext, UploadDocumentManager As Boolean) As Boolean

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim Saved As Boolean = False

			Try

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_UPDOC.ToString)

			Catch ex As Exception
				Setting = Nothing
			End Try

			If Setting IsNot Nothing Then

				Setting.Value = UploadDocumentManager

				Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

			Else

				Setting = New AdvantageFramework.Database.Entities.Setting

				Setting.DataContext = DataContext
				Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_UPDOC.ToString
				Setting.Value = UploadDocumentManager
				Setting.OrderNumber = 3
				Setting.SettingDatabaseTypeID = 16

				Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

			End If

			SaveDefaultUploadDocumentManager = Saved

		End Function
		Public Function SaveDefaultSinglePDF(ByVal DataContext As AdvantageFramework.Database.DataContext, SinglePDF As Boolean) As Boolean

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim Saved As Boolean = False

			Try

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SINGLEPDF.ToString)

			Catch ex As Exception
				Setting = Nothing
			End Try

			If Setting IsNot Nothing Then

				Setting.Value = SinglePDF

				Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

			Else

				Setting = New AdvantageFramework.Database.Entities.Setting

				Setting.DataContext = DataContext
				Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_SINGLEPDF.ToString
				Setting.Value = SinglePDF
				Setting.OrderNumber = 3
				Setting.SettingDatabaseTypeID = 16

				Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

			End If

			SaveDefaultSinglePDF = Saved

		End Function
		Public Function SaveDefaultIncludeCoverSheet(ByVal DataContext As AdvantageFramework.Database.DataContext, IncludeCoverSheet As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_INCL_CS.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = IncludeCoverSheet

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_INCL_CS.ToString
                Setting.Value = IncludeCoverSheet
                Setting.OrderNumber = 7
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultIncludeCoverSheet = Saved

        End Function
        Public Function SaveDefaultCCSender(ByVal DataContext As AdvantageFramework.Database.DataContext, CCSender As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_CCSENDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CCSender

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_CCSENDER.ToString
                Setting.Value = CCSender
                Setting.OrderNumber = 4
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultCCSender = Saved

        End Function
        Public Function SaveDefaultPackageType(ByVal DataContext As AdvantageFramework.Database.DataContext, PackageType As Short) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_PACKAGETYPE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = PackageType

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_PACKAGETYPE.ToString
                Setting.Value = PackageType
                Setting.OrderNumber = 5
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultPackageType = Saved

        End Function
        Public Function SaveDefaultSortOption(ByVal DataContext As AdvantageFramework.Database.DataContext, SortOption As Short) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SORTOPTION.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = SortOption

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_SORTOPTION.ToString
                Setting.Value = SortOption
                Setting.OrderNumber = 6
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultSortOption = Saved

        End Function
        Public Function SaveDefaultEmailProductContact(ByVal DataContext As AdvantageFramework.Database.DataContext, EmailProductContact As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_PRINTPRD.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EmailProductContact

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_PRINTPRD.ToString
                Setting.Value = EmailProductContact
                Setting.OrderNumber = 10
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultEmailProductContact = Saved

        End Function
        Public Function SaveCombineCoopInvoices(ByVal DataContext As AdvantageFramework.Database.DataContext, CombineCoopInvoices As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COMB_COOP_INV.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CombineCoopInvoices

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COMB_COOP_INV.ToString
                Setting.Value = CombineCoopInvoices
                Setting.OrderNumber = 11
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCombineCoopInvoices = Saved

        End Function
        Public Function SaveCoversheetLayout(ByVal DataContext As AdvantageFramework.Database.DataContext, CoversheetLayout As CoversheetLayouts) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_LAYOUT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CShort(CoversheetLayout)

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COVER_LAYOUT.ToString
                Setting.Value = CShort(CoversheetLayout)
                Setting.OrderNumber = 12
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCoversheetLayout = Saved

        End Function
        Public Function SaveCoversheetTitle(ByVal DataContext As AdvantageFramework.Database.DataContext, CoversheetTitle As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_TITLE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CoversheetTitle

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COVER_TITLE.ToString
                Setting.Value = CoversheetTitle
                Setting.SettingDatabaseTypeID = 8

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCoversheetTitle = Saved

        End Function
        Public Function SaveCoversheetContact(ByVal DataContext As AdvantageFramework.Database.DataContext, CoversheetContact As CoversheetContacts) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CShort(CoversheetContact)

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COVER_CC.ToString
                Setting.Value = CShort(CoversheetContact)
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCoversheetContact = Saved

        End Function
        Public Function SaveCoversheetContactType(ByVal DataContext As AdvantageFramework.Database.DataContext, ContactType As Integer) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_TYPE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = ContactType

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_TYPE.ToString
                Setting.Value = ContactType
                Setting.SettingDatabaseTypeID = 19

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCoversheetContactType = Saved

        End Function
        Public Function SaveCoversheetContactLocation(ByVal DataContext As AdvantageFramework.Database.DataContext, CoversheetContactLocation As CoversheetContactLocations) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_LOC.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CShort(CoversheetContactLocation)

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_COVER_CC_LOC.ToString
                Setting.Value = CShort(CoversheetContactLocation)
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCoversheetContactLocation = Saved

        End Function
        Public Function SaveDefaultSendSingleEmail(ByVal DataContext As AdvantageFramework.Database.DataContext, SendSingleEmail As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.INVPRT_SINGLEEMAIL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = SendSingleEmail

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_SINGLEEMAIL.ToString
                Setting.Value = SendSingleEmail
                Setting.OrderNumber = 13
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultSendSingleEmail = Saved

        End Function
        Public Function SaveShowSequenceNumberInInvoicePrinting(ByVal Session As AdvantageFramework.Security.Session, ByVal ShowSequenceNumberInInvoicePrinting As Boolean) As Boolean

            SaveShowSequenceNumberInInvoicePrinting = AdvantageFramework.Security.SaveUserSetting(Session, Session.User.ID, Security.UserSettings.ShowSequenceNumberInInvoicePrinting, If(ShowSequenceNumberInInvoicePrinting = True, 1, 0))

        End Function
        Public Function LoadShowSequenceNumberInInvoicePrinting(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim ShowSequenceNumberInInvoicePrinting As Boolean = True

            Try

                ShowSequenceNumberInInvoicePrinting = AdvantageFramework.Security.LoadUserSetting(Session, Session.User.ID, Security.UserSettings.ShowSequenceNumberInInvoicePrinting)

            Catch ex As Exception
                ShowSequenceNumberInInvoicePrinting = True
            End Try

            LoadShowSequenceNumberInInvoicePrinting = ShowSequenceNumberInInvoicePrinting

        End Function
        Public Function SaveShowDivisionProductJobCompInInvoicePrinting(ByVal Session As AdvantageFramework.Security.Session, ByVal ShowDivisionProductJobComp As Boolean) As Boolean

            SaveShowDivisionProductJobCompInInvoicePrinting = AdvantageFramework.Security.SaveUserSetting(Session, Session.User.ID, Security.UserSettings.ShowDivisionProductJobCompInInvoicePrinting, If(ShowDivisionProductJobComp = True, 1, 0))

        End Function
        Public Function LoadShowDivisionProductJobCompInInvoicePrinting(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim ShowDivisionProductJobComp As Boolean = False

            Try

                ShowDivisionProductJobComp = AdvantageFramework.Security.LoadUserSetting(Session, Session.User.ID, Security.UserSettings.ShowDivisionProductJobCompInInvoicePrinting)

            Catch ex As Exception
                ShowDivisionProductJobComp = False
            End Try

            LoadShowDivisionProductJobCompInInvoicePrinting = ShowDivisionProductJobComp

        End Function

#End Region

    End Module

End Namespace
