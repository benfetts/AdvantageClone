Namespace InvoicePrinting.Classes

    Public Class MediaInvoicePrintingSetting

#Region " Constants "

        Private Const ProgramColumnHeader As String = "Program"
        Private Const SpotLengthColumnHeader As String = "Spot" & vbNewLine & "Length"
        Private Const TagColumnHeader As String = "Tag"
        Private Const StartEndTimesColumnHeader As String = "Start-End" & vbNewLine & "Times"
        Private Const NumberOfSpotsColumnHeader As String = "# of" & vbNewLine & "Spots"
        Private Const RemarksColumnHeader As String = "Remarks"
		Private Const OrderNumberColumnHeader As String = "Order"
		Private Const VendorNameColumnHeader As String = "Vendor Name"
        Private Const VendorCodeColumnHeader As String = "Vendor" & vbNewLine & "Code"
        Private Const OrderMonthsColumnHeader As String = "Order" & vbNewLine & "Months"
        Private Const NetAmountColumnHeader As String = "Net" & vbNewLine & "Amount"
        Private Const CommissionAmountColumnHeader As String = "Commission" & vbNewLine & "Amount"
        Private Const TaxAmountColumnHeader As String = "Tax" & vbNewLine & "Amount"
        Private Const BillAmountColumnHeader As String = "Bill" & vbNewLine & "Amount"
        Private Const PriorBillAmountColumnHeader As String = "Prior Bill" & vbNewLine & "Amount"
        Private Const BilledToDateAmountColumnHeader As String = "Billed" & vbNewLine & "to Date"
        Private Const HeadlineColumnHeader As String = "Headline"
        Private Const InsertDatesColumnHeader As String = "Insert" & vbNewLine & "Date(s)"
        Private Const MaterialColumnHeader As String = "Material"
        Private Const AdNumberColumnHeader As String = "Ad" & vbNewLine & "Number"
        Private Const EditorialIssueColumnHeader As String = "Editorial" & vbNewLine & "Issue"
        Private Const URLColumnHeader As String = "URL"
        Private Const StartDateColumnHeader As String = "Start" & vbNewLine & "Date"
        Private Const EndDateColumnHeader As String = "End" & vbNewLine & "Date"
        Private Const SizeColumnHeader As String = "Size"
        Private Const SectionColumnHeader As String = "Section"
        Private Const QuantityColumnHeader As String = "Quantity"
        Private Const InternetTypeColumnHeader As String = "Internet" & vbNewLine & "Type"
        Private Const OutdoorTypeColumnHeader As String = "Outdoor" & vbNewLine & "Type"
        Private Const LocationColumnHeader As String = "Location"
        Private Const CopyAreaColumnHeader As String = "Copy" & vbNewLine & "Area"
        Private Const CreativeSizeColumnHeader As String = "Creative" & vbNewLine & "Size"
        Private Const AdSizeColumnHeader As String = "Ad Size"
        Private Const JobComponentNumberColumnHeader As String = "Job-Comp."
        Private Const JobDescriptionColumnHeader As String = "Job" & vbNewLine & "Description"
        Private Const ComponentDescriptionColumnHeader As String = "Component" & vbNewLine & "Description"
        Private Const OrderDetailCommentColumnHeader As String = "Order Dtl." & vbNewLine & "Comment"
        Private Const OrderHouseDetailCommentColumnHeader As String = "Hse. Dtl." & vbNewLine & "Comment"
		Private Const ExtraChargesColumnHeader As String = "Charges & Discounts (included)"
        Private Const LineNumberColumnHeader As String = "Line"
        Private Const CloseDateColumnHeader As String = "Close" & vbNewLine & "Date"
        Private Const GuaranteedImpressionsColumnHeader As String = "Guar Imps"

#End Region

#Region " Enum "

        Private Enum HeaderType
            [Default]
            [TotalAmounts]
            [OtherTotalAmounts]
        End Enum

        Public Enum TextAlignment
            Near = 0
            Center = 1
            Far = 2
        End Enum

        Public Enum Properties
            IsOneTime
            Type
            ClientCode
            AddressBlockType
            CustomFormatName
            PrintClientName
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            ContactType
            ShowCodes
            IncludeBillingComment
            ApplyExchangeRate
            ExchangeRateAmount
            InvoiceFooterCommentType
            InvoiceFooterComment
            LocationCode
            InvoiceTitle
            UseInvoiceCategoryDescription
            GroupByMarket
            ShowOrderDescription
            ShowClientReference
            ShowClientPO
            ShowOrderComment
            ShowOrderHouseComment
            PrintInvoiceDueDate
            OrderNumberColumn
            VendorNameColumn
            ShowVendorCode
            OrderMonthsColumn
            NetAmountColumn
            CommissionAmountColumn
            TaxAmountColumn
            BillAmountColumn
            PriorBillAmountColumn
            BilledToDateAmountColumn
            ShowLineDetail
            ProgramColumn
            SpotLengthColumn
            TagColumn
            StartEndTimesColumn
            NumberOfSpotsColumn
            RemarksColumn
            HeadlineColumn
            StartDatesColumn
            EndDatesColumn
            CreativeSizeColumn
			InsertDatesColumn
			OutdoorEndDateColumn
			CopyAreaColumn
            MaterialColumn
            AdNumberColumn
            LocationColumn
            OutdoorTypeColumn
            SizeColumn
            EditorialIssueColumn
            SectionColumn
            QuantityColumn
            AdSizeColumn
            URLColumn
            InternetTypeColumn
            JobComponentNumberColumn
            JobDescriptionColumn
            ComponentDescriptionColumn
            OrderDetailCommentColumn
            OrderHouseDetailCommentColumn
            ExtraChargesColumn
            ShowCommissionSeparately
            ShowRebateSeparately
            ShowTaxSeparately
            ShowBillingHistory
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
            PageHeaderLineVisible
            ColumnHeader1
            ColumnHeader2
            ColumnHeader3
            ColumnHeader4
            ColumnHeader5
            ColumnHeader6
            ColumnHeader7
            InvoiceTotalVerbiage
            ExchangeRateNote
            ExchangeRateNoteVisible
            Column1Alignment
            Column2Alignment
            Column3Alignment
            Column4Alignment
            Column5Alignment
            Column6Alignment
            Column7Alignment
            TotalColumnVisible3
            TotalColumnVisible4
            TotalColumnVisible5
            TotalColumnVisible6
            TotalColumnVisible7
            CommissionLabel
            RebateLabel
            CityTaxLabel
            CountyTaxLabel
            StateTaxLabel
            GrandTotalColumnVisible3
            GrandTotalColumnVisible4
            GrandTotalColumnVisible5
            GrandTotalColumnVisible6
            GrandTotalColumnVisible7
            ShowCampaign
            ShowCampaignComment
            UseLocationPrintOptions
            ShowOrderSubtotals
            ShowSalesClass
            ClientPOLocation
            SalesClassLocation
            CampaignLocation
            HeaderGroupBy
            SortLinesBy
            LineNumberColumn
            ShowZeroFunctionAmounts
            CloseDateColumn
            ShowPageHeaderLogo
            ShowPageFooterLogo
            GuaranteedImpressionsColumn
            StartDateColumn
        End Enum

#End Region

#Region " Variables "

        Private _IsOneTime As Boolean = Nothing
        Private _Type As Short = Nothing
        Private _ClientCode As String = Nothing
        Private _AddressBlockType As Short = Nothing
        Private _CustomFormatName As String = Nothing
        Private _PrintClientName As Boolean = Nothing
        Private _PrintDivisionName As Boolean = Nothing
        Private _PrintProductDescription As Boolean = Nothing
        Private _PrintContactAfterAddress As Boolean = Nothing
        Private _ContactType As Integer = Nothing
        Private _ShowCodes As Boolean = Nothing
        Private _IncludeBillingComment As Boolean = Nothing
        Private _ApplyExchangeRate As Short = Nothing
        Private _ExchangeRateAmount As Decimal = Nothing
        Private _InvoiceFooterCommentType As Short = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _LocationCode As String = Nothing
        Private _InvoiceTitle As String = Nothing
        Private _UseInvoiceCategoryDescription As Boolean = Nothing
        Private _GroupByMarket As Boolean = Nothing
        Private _ShowOrderDescription As Boolean = Nothing
        Private _ShowClientReference As Boolean = Nothing
        Private _ShowClientPO As Boolean = Nothing
        Private _ShowOrderComment As Boolean = Nothing
        Private _ShowOrderHouseComment As Boolean = Nothing
        Private _PrintInvoiceDueDate As Boolean = Nothing
        Private _OrderNumberColumn As Short = Nothing
        Private _VendorNameColumn As Short = Nothing
        Private _ShowVendorCode As Short = Nothing
        Private _OrderMonthsColumn As Short = Nothing
        Private _NetAmountColumn As Short = Nothing
        Private _CommissionAmountColumn As Short = Nothing
        Private _TaxAmountColumn As Short = Nothing
        Private _BillAmountColumn As Short = Nothing
        Private _PriorBillAmountColumn As Short = Nothing
        Private _BilledToDateAmountColumn As Short = Nothing
        Private _ShowLineDetail As Integer = 1
        Private _ProgramColumn As Short = Nothing
        Private _SpotLengthColumn As Short = Nothing
        Private _TagColumn As Short = Nothing
        Private _StartEndTimesColumn As Short = Nothing
        Private _NumberOfSpotsColumn As Short = Nothing
        Private _RemarksColumn As Short = Nothing
        Private _HeadlineColumn As Short = Nothing
        Private _StartDatesColumn As Short = Nothing
        Private _EndDatesColumn As Short = Nothing
        Private _CreativeSizeColumn As Short = Nothing
		Private _InsertDatesColumn As Short = Nothing
		Private _OutdoorEndDateColumn As Short = Nothing
		Private _CopyAreaColumn As Short = Nothing
        Private _MaterialColumn As Short = Nothing
        Private _AdNumberColumn As Short = Nothing
        Private _LocationColumn As Short = Nothing
        Private _OutdoorTypeColumn As Short = Nothing
        Private _SizeColumn As Short = Nothing
        Private _URLColumn As Short = Nothing
        Private _InternetTypeColumn As Short = Nothing
        Private _EditorialIssueColumn As Short = Nothing
        Private _SectionColumn As Short = Nothing
        Private _QuantityColumn As Short = Nothing
        Private _AdSizeColumn As Short = Nothing
        Private _JobComponentNumberColumn As Short = Nothing
        Private _JobDescriptionColumn As Short = Nothing
        Private _ComponentDescriptionColumn As Short = Nothing
        Private _OrderDetailCommentColumn As Short = Nothing
        Private _OrderHouseDetailCommentColumn As Short = Nothing
        Private _ExtraChargesColumn As Short = Nothing
        Private _ShowCommissionSeparately As Boolean = Nothing
        Private _ShowRebateSeparately As Boolean = Nothing
        Private _ShowTaxSeparately As Boolean = Nothing
        Private _ShowBillingHistory As Boolean = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing
        Private _PageHeaderLineVisible As Boolean = Nothing
        Private _ColumnHeader1 As String = Nothing
        Private _ColumnHeader2 As String = Nothing
        Private _ColumnHeader3 As String = Nothing
        Private _ColumnHeader4 As String = Nothing
        Private _ColumnHeader5 As String = Nothing
        Private _ColumnHeader6 As String = Nothing
        Private _ColumnHeader7 As String = Nothing
        Private _InvoiceTotalVerbiage As String = Nothing
        Private _ExchangeRateNote As String = Nothing
        Private _ExchangeRateNoteVisible As Boolean = Nothing
        Private _ColumnAlignment1 As Short = 1
        Private _ColumnAlignment2 As Short = 1
        Private _ColumnAlignment3 As Short = 1
        Private _ColumnAlignment4 As Short = 1
        Private _ColumnAlignment5 As Short = 1
        Private _ColumnAlignment6 As Short = 1
        Private _ColumnAlignment7 As Short = 1
        Private _TotalColumnVisible3 As Boolean = False
        Private _TotalColumnVisible4 As Boolean = False
        Private _TotalColumnVisible5 As Boolean = False
        Private _TotalColumnVisible6 As Boolean = False
        Private _TotalColumnVisible7 As Boolean = False
        Private _CommissionLabel As String = Nothing
        Private _RebateLabel As String = Nothing
        Private _CityTaxLabel As String = Nothing
        Private _CountyTaxLabel As String = Nothing
        Private _StateTaxLabel As String = Nothing
        Private _GrandTotalColumnVisible3 As Boolean = False
        Private _GrandTotalColumnVisible4 As Boolean = False
        Private _GrandTotalColumnVisible5 As Boolean = False
        Private _GrandTotalColumnVisible6 As Boolean = False
        Private _GrandTotalColumnVisible7 As Boolean = False
        Private _ShowCampaign As Boolean = False
        Private _ShowCampaignComment As Boolean = False
        Private _UseLocationPrintOptions As Boolean = Nothing
        Private _ShowOrderSubtotals As Boolean = True
        Private _ShowSalesClass As Boolean = False
        Private _ClientPOLocation As Integer = 1
        Private _SalesClassLocation As Integer = 1
        Private _CampaignLocation As Integer = 1
        Private _HeaderGroupBy As Integer = 0
        Private _SortLinesBy As Integer = 1
        Private _LineNumberColumn As Short = 0
        Private _ShowZeroFunctionAmounts As Boolean = False
        Private _CloseDateColumn As Short = 0

        Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing
        Private _MediaType As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOneTime() As Boolean
            Get
                IsOneTime = _IsOneTime
            End Get
            Set(ByVal value As Boolean)
                _IsOneTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As Short
            Get
                Type = _Type
            End Get
            Set(ByVal value As Short)
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddressBlockType() As Short
            Get
                AddressBlockType = _AddressBlockType
            End Get
            Set(ByVal value As Short)
                _AddressBlockType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CustomFormatName() As String
            Get
                CustomFormatName = _CustomFormatName
            End Get
            Set(ByVal value As String)
                _CustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(ByVal value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDivisionName() As Boolean
            Get
                PrintDivisionName = _PrintDivisionName
            End Get
            Set(ByVal value As Boolean)
                _PrintDivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintProductDescription() As Boolean
            Get
                PrintProductDescription = _PrintProductDescription
            End Get
            Set(ByVal value As Boolean)
                _PrintProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintContactAfterAddress() As Boolean
            Get
                PrintContactAfterAddress = _PrintContactAfterAddress
            End Get
            Set(ByVal value As Boolean)
                _PrintContactAfterAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactType() As Integer
            Get
                ContactType = _ContactType
            End Get
            Set(value As Integer)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(ByVal value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeBillingComment() As Boolean
            Get
                IncludeBillingComment = _IncludeBillingComment
            End Get
            Set(ByVal value As Boolean)
                _IncludeBillingComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApplyExchangeRate() As Short
            Get
                ApplyExchangeRate = _ApplyExchangeRate
            End Get
            Set(ByVal value As Short)
                _ApplyExchangeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateAmount() As Decimal
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As Decimal)
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterCommentType() As Short
            Get
                InvoiceFooterCommentType = _InvoiceFooterCommentType
            End Get
            Set(ByVal value As Short)
                _InvoiceFooterCommentType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String
            Get
                LocationCode = _LocationCode
            End Get
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTitle() As String
            Get
                InvoiceTitle = _InvoiceTitle
            End Get
            Set(ByVal value As String)
                _InvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseInvoiceCategoryDescription() As Boolean
            Get
                UseInvoiceCategoryDescription = _UseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Boolean)
                _UseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupByMarket() As Boolean
            Get
                GroupByMarket = _GroupByMarket
            End Get
            Set(ByVal value As Boolean)
                _GroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowOrderDescription() As Boolean
            Get
                ShowOrderDescription = _ShowOrderDescription
            End Get
            Set(ByVal value As Boolean)
                _ShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowClientReference() As Boolean
            Get
                ShowClientReference = _ShowClientReference
            End Get
            Set(ByVal value As Boolean)
                _ShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowClientPO() As Boolean
            Get
                ShowClientPO = _ShowClientPO
            End Get
            Set(ByVal value As Boolean)
                _ShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowOrderComment() As Boolean
            Get
                ShowOrderComment = _ShowOrderComment
            End Get
            Set(ByVal value As Boolean)
                _ShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowOrderHouseComment() As Boolean
            Get
                ShowOrderHouseComment = _ShowOrderHouseComment
            End Get
            Set(ByVal value As Boolean)
                _ShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintInvoiceDueDate() As Boolean
            Get
                PrintInvoiceDueDate = _PrintInvoiceDueDate
            End Get
            Set(ByVal value As Boolean)
                _PrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumberColumn() As Short
            Get
                OrderNumberColumn = _OrderNumberColumn
            End Get
            Set(ByVal value As Short)
                _OrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorNameColumn() As Short
            Get
                VendorNameColumn = _VendorNameColumn
            End Get
            Set(ByVal value As Short)
                _VendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowVendorCode() As Short
            Get
                ShowVendorCode = _ShowVendorCode
            End Get
            Set(ByVal value As Short)
                _ShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderMonthsColumn() As Short
            Get
                OrderMonthsColumn = _OrderMonthsColumn
            End Get
            Set(ByVal value As Short)
                _OrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetAmountColumn() As Short
            Get
                NetAmountColumn = _NetAmountColumn
            End Get
            Set(ByVal value As Short)
                _NetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmountColumn() As Short
            Get
                CommissionAmountColumn = _CommissionAmountColumn
            End Get
            Set(ByVal value As Short)
                _CommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxAmountColumn() As Short
            Get
                TaxAmountColumn = _TaxAmountColumn
            End Get
            Set(ByVal value As Short)
                _TaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmountColumn() As Short
            Get
                BillAmountColumn = _BillAmountColumn
            End Get
            Set(ByVal value As Short)
                _BillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountColumn() As Short
            Get
                PriorBillAmountColumn = _PriorBillAmountColumn
            End Get
            Set(ByVal value As Short)
                _PriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateAmountColumn() As Short
            Get
                BilledToDateAmountColumn = _BilledToDateAmountColumn
            End Get
            Set(ByVal value As Short)
                _BilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowLineDetail() As Integer
            Get
                ShowLineDetail = _ShowLineDetail
            End Get
            Set(ByVal value As Integer)
                _ShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramColumn() As Short
            Get
                ProgramColumn = _ProgramColumn
            End Get
            Set(ByVal value As Short)
                _ProgramColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotLengthColumn() As Short
            Get
                SpotLengthColumn = _SpotLengthColumn
            End Get
            Set(ByVal value As Short)
                _SpotLengthColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TagColumn() As Short
            Get
                TagColumn = _TagColumn
            End Get
            Set(ByVal value As Short)
                _TagColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartEndTimesColumn() As Short
            Get
                StartEndTimesColumn = _StartEndTimesColumn
            End Get
            Set(ByVal value As Short)
                _StartEndTimesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfSpotsColumn() As Short
            Get
                NumberOfSpotsColumn = _NumberOfSpotsColumn
            End Get
            Set(ByVal value As Short)
                _NumberOfSpotsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RemarksColumn() As Short
            Get
                RemarksColumn = _RemarksColumn
            End Get
            Set(ByVal value As Short)
                _RemarksColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeadlineColumn() As Short
            Get
                HeadlineColumn = _HeadlineColumn
            End Get
            Set(ByVal value As Short)
                _HeadlineColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDatesColumn() As Short
            Get
                StartDatesColumn = _StartDatesColumn
            End Get
            Set(ByVal value As Short)
                _StartDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDatesColumn() As Short
            Get
                EndDatesColumn = _EndDatesColumn
            End Get
            Set(ByVal value As Short)
                _EndDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreativeSizeColumn() As Short
            Get
                CreativeSizeColumn = _CreativeSizeColumn
            End Get
            Set(ByVal value As Short)
                _CreativeSizeColumn = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InsertDatesColumn() As Short
			Get
				InsertDatesColumn = _InsertDatesColumn
			End Get
			Set(ByVal value As Short)
				_InsertDatesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorEndDateColumn() As Short
			Get
				OutdoorEndDateColumn = _OutdoorEndDateColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorEndDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CopyAreaColumn() As Short
            Get
                CopyAreaColumn = _CopyAreaColumn
            End Get
            Set(ByVal value As Short)
                _CopyAreaColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialColumn() As Short
            Get
                MaterialColumn = _MaterialColumn
            End Get
            Set(ByVal value As Short)
                _MaterialColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberColumn() As Short
            Get
                AdNumberColumn = _AdNumberColumn
            End Get
            Set(ByVal value As Short)
                _AdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationColumn() As Short
            Get
                LocationColumn = _LocationColumn
            End Get
            Set(ByVal value As Short)
                _LocationColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorTypeColumn() As Short
            Get
                OutdoorTypeColumn = _OutdoorTypeColumn
            End Get
            Set(ByVal value As Short)
                _OutdoorTypeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SizeColumn() As Short
            Get
                SizeColumn = _SizeColumn
            End Get
            Set(ByVal value As Short)
                _SizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property URLColumn() As Short
            Get
                URLColumn = _URLColumn
            End Get
            Set(ByVal value As Short)
                _URLColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTypeColumn() As Short
            Get
                InternetTypeColumn = _InternetTypeColumn
            End Get
            Set(ByVal value As Short)
                _InternetTypeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditorialIssueColumn() As Short
            Get
                EditorialIssueColumn = _EditorialIssueColumn
            End Get
            Set(ByVal value As Short)
                _EditorialIssueColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SectionColumn() As Short
            Get
                SectionColumn = _SectionColumn
            End Get
            Set(ByVal value As Short)
                _SectionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuantityColumn() As Short
            Get
                QuantityColumn = _QuantityColumn
            End Get
            Set(ByVal value As Short)
                _QuantityColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSizeColumn() As Short
            Get
                AdSizeColumn = _AdSizeColumn
            End Get
            Set(ByVal value As Short)
                _AdSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumberColumn() As Short
            Get
                JobComponentNumberColumn = _JobComponentNumberColumn
            End Get
            Set(ByVal value As Short)
                _JobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescriptionColumn() As Short
            Get
                JobDescriptionColumn = _JobDescriptionColumn
            End Get
            Set(ByVal value As Short)
                _JobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentDescriptionColumn() As Short
            Get
                ComponentDescriptionColumn = _ComponentDescriptionColumn
            End Get
            Set(ByVal value As Short)
                _ComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDetailCommentColumn() As Short
            Get
                OrderDetailCommentColumn = _OrderDetailCommentColumn
            End Get
            Set(ByVal value As Short)
                _OrderDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderHouseDetailCommentColumn() As Short
            Get
                OrderHouseDetailCommentColumn = _OrderHouseDetailCommentColumn
            End Get
            Set(ByVal value As Short)
                _OrderHouseDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtraChargesColumn() As Short
            Get
                ExtraChargesColumn = _ExtraChargesColumn
            End Get
            Set(ByVal value As Short)
                _ExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCommissionSeparately() As Boolean
            Get
                ShowCommissionSeparately = _ShowCommissionSeparately
            End Get
            Set(ByVal value As Boolean)
                _ShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowRebateSeparately() As Boolean
            Get
                ShowRebateSeparately = _ShowRebateSeparately
            End Get
            Set(ByVal value As Boolean)
                _ShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowTaxSeparately() As Boolean
            Get
                ShowTaxSeparately = _ShowTaxSeparately
            End Get
            Set(ByVal value As Boolean)
                _ShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowBillingHistory() As Boolean
            Get
                ShowBillingHistory = _ShowBillingHistory
            End Get
            Set(ByVal value As Boolean)
                _ShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String
            Get
                PageHeaderLogoPath = _PageHeaderLogoPath
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String
            Get
                PageFooterLogoPath = _PageFooterLogoPath
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String
            Get
                PageFooterLogoPathLandscape = _PageFooterLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLineVisible() As Boolean
            Get
                PageHeaderLineVisible = _PageHeaderLineVisible
            End Get
            Set(ByVal value As Boolean)
                _PageHeaderLineVisible = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader1() As String
            Get
                ColumnHeader1 = _ColumnHeader1
            End Get
            Set(ByVal value As String)
                _ColumnHeader1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader2() As String
            Get
                ColumnHeader2 = _ColumnHeader2
            End Get
            Set(ByVal value As String)
                _ColumnHeader2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader3() As String
            Get
                ColumnHeader3 = _ColumnHeader3
            End Get
            Set(ByVal value As String)
                _ColumnHeader3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader4() As String
            Get
                ColumnHeader4 = _ColumnHeader4
            End Get
            Set(ByVal value As String)
                _ColumnHeader4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader5() As String
            Get
                ColumnHeader5 = _ColumnHeader5
            End Get
            Set(ByVal value As String)
                _ColumnHeader5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader6() As String
            Get
                ColumnHeader6 = _ColumnHeader6
            End Get
            Set(ByVal value As String)
                _ColumnHeader6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnHeader7() As String
            Get
                ColumnHeader7 = _ColumnHeader7
            End Get
            Set(ByVal value As String)
                _ColumnHeader7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalVerbiage() As String
            Get
                InvoiceTotalVerbiage = _InvoiceTotalVerbiage
            End Get
            Set(ByVal value As String)
                _InvoiceTotalVerbiage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateNote() As String
            Get
                ExchangeRateNote = _ExchangeRateNote
            End Get
            Set(ByVal value As String)
                _ExchangeRateNote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateNoteVisible() As Boolean
            Get
                ExchangeRateNoteVisible = _ExchangeRateNoteVisible
            End Get
            Set(ByVal value As Boolean)
                _ExchangeRateNoteVisible = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment1() As Short
            Get
                ColumnAlignment1 = _ColumnAlignment1
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment2() As Short
            Get
                ColumnAlignment2 = _ColumnAlignment2
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment3() As Short
            Get
                ColumnAlignment3 = _ColumnAlignment3
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment4() As Short
            Get
                ColumnAlignment4 = _ColumnAlignment4
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment5() As Short
            Get
                ColumnAlignment5 = _ColumnAlignment5
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment6() As Short
            Get
                ColumnAlignment6 = _ColumnAlignment6
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnAlignment7() As Short
            Get
                ColumnAlignment7 = _ColumnAlignment7
            End Get
            Set(ByVal value As Short)
                _ColumnAlignment7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalColumnVisible3() As Boolean
            Get
                TotalColumnVisible3 = _TotalColumnVisible3
            End Get
            Set(ByVal value As Boolean)
                _TotalColumnVisible3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalColumnVisible4() As Boolean
            Get
                TotalColumnVisible4 = _TotalColumnVisible4
            End Get
            Set(ByVal value As Boolean)
                _TotalColumnVisible4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalColumnVisible5() As Boolean
            Get
                TotalColumnVisible5 = _TotalColumnVisible5
            End Get
            Set(ByVal value As Boolean)
                _TotalColumnVisible5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalColumnVisible6() As Boolean
            Get
                TotalColumnVisible6 = _TotalColumnVisible6
            End Get
            Set(ByVal value As Boolean)
                _TotalColumnVisible6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalColumnVisible7() As Boolean
            Get
                TotalColumnVisible7 = _TotalColumnVisible7
            End Get
            Set(ByVal value As Boolean)
                _TotalColumnVisible7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionLabel() As String
            Get
                CommissionLabel = _CommissionLabel
            End Get
            Set(ByVal value As String)
                _CommissionLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateLabel() As String
            Get
                RebateLabel = _RebateLabel
            End Get
            Set(ByVal value As String)
                _RebateLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxLabel() As String
            Get
                CityTaxLabel = _CityTaxLabel
            End Get
            Set(ByVal value As String)
                _CityTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxLabel() As String
            Get
                CountyTaxLabel = _CountyTaxLabel
            End Get
            Set(ByVal value As String)
                _CountyTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxLabel() As String
            Get
                StateTaxLabel = _StateTaxLabel
            End Get
            Set(ByVal value As String)
                _StateTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnVisible3() As Boolean
            Get
                GrandTotalColumnVisible3 = _GrandTotalColumnVisible3
            End Get
            Set(ByVal value As Boolean)
                _GrandTotalColumnVisible3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnVisible4() As Boolean
            Get
                GrandTotalColumnVisible4 = _GrandTotalColumnVisible4
            End Get
            Set(ByVal value As Boolean)
                _GrandTotalColumnVisible4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnVisible5() As Boolean
            Get
                GrandTotalColumnVisible5 = _GrandTotalColumnVisible5
            End Get
            Set(ByVal value As Boolean)
                _GrandTotalColumnVisible5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnVisible6() As Boolean
            Get
                GrandTotalColumnVisible6 = _GrandTotalColumnVisible6
            End Get
            Set(ByVal value As Boolean)
                _GrandTotalColumnVisible6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnVisible7() As Boolean
            Get
                GrandTotalColumnVisible7 = _GrandTotalColumnVisible7
            End Get
            Set(ByVal value As Boolean)
                _GrandTotalColumnVisible7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCampaign() As Boolean
            Get
                ShowCampaign = _ShowCampaign
            End Get
            Set(ByVal value As Boolean)
                _ShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCampaignComment() As Boolean
            Get
                ShowCampaignComment = _ShowCampaignComment
            End Get
            Set(ByVal value As Boolean)
                _ShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseLocationPrintOptions() As Boolean
            Get
                UseLocationPrintOptions = _UseLocationPrintOptions
            End Get
            Set(ByVal value As Boolean)
                _UseLocationPrintOptions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowOrderSubtotals() As Boolean
            Get
                ShowOrderSubtotals = _ShowOrderSubtotals
            End Get
            Set(ByVal value As Boolean)
                _ShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowSalesClass() As Boolean
            Get
                ShowSalesClass = _ShowSalesClass
            End Get
            Set(value As Boolean)
                _ShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPOLocation() As Integer
            Get
                ClientPOLocation = _ClientPOLocation
            End Get
            Set(value As Integer)
                _ClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassLocation() As Integer
            Get
                SalesClassLocation = _SalesClassLocation
            End Get
            Set(value As Integer)
                _SalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignLocation() As Integer
            Get
                CampaignLocation = _CampaignLocation
            End Get
            Set(value As Integer)
                _CampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeaderGroupBy() As Integer
            Get
                HeaderGroupBy = _HeaderGroupBy
            End Get
            Set(value As Integer)
                _HeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SortLinesBy() As Integer
            Get
                SortLinesBy = _SortLinesBy
            End Get
            Set(value As Integer)
                _SortLinesBy = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property LineNumberColumn() As Short
			Get
				LineNumberColumn = _LineNumberColumn
			End Get
			Set(value As Short)
				_LineNumberColumn = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowZeroFunctionAmounts() As Boolean
            Get
                ShowZeroFunctionAmounts = _ShowZeroFunctionAmounts
            End Get
            Set(value As Boolean)
                _ShowZeroFunctionAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDateColumn() As Short
            Get
                CloseDateColumn = _CloseDateColumn
            End Get
            Set(value As Short)
                _CloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageHeaderLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageFooterLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GuaranteedImpressionsColumn() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDateColumn() As Short

#End Region

#Region " Methods "

        Public Sub New(InvoicePrintingMediaSetting As InvoicePrintingMediaSetting,
					   AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
					   OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
					   MediaType As String, IsMultiCurrencyEnabled As Boolean,
					   ApplyExchangeRate As Short, ExchangeRateAmount As Decimal, CurrencyCode As String)

			Me.IsOneTime = InvoicePrintingMediaSetting.IsOneTime.GetValueOrDefault(False)
			Me.Type = InvoicePrintingMediaSetting.Type.GetValueOrDefault(0)
			Me.ClientCode = InvoicePrintingMediaSetting.ClientCode

			If (MediaType = "M" AndAlso InvoicePrintingMediaSetting.MagazineUseAgencySetting) OrElse
					(MediaType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperUseAgencySetting) OrElse
					(MediaType = "I" AndAlso InvoicePrintingMediaSetting.InternetUseAgencySetting) OrElse
					(MediaType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorUseAgencySetting) OrElse
					(MediaType = "R" AndAlso InvoicePrintingMediaSetting.RadioUseAgencySetting) OrElse
					(MediaType = "T" AndAlso InvoicePrintingMediaSetting.TVUseAgencySetting) Then

				Me.AddressBlockType = AgencyInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1))

				If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.CustomFormatName) = True Then

					Me.CustomFormatName = OneTimeInvoicePrintingMediaSetting.CustomFormatName

				Else

					Me.CustomFormatName = AgencyInvoicePrintingMediaSetting.CustomFormatName

				End If

				Me.PrintClientName = AgencyInvoicePrintingMediaSetting.PrintClientName
				Me.PrintDivisionName = AgencyInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(False))
				Me.PrintProductDescription = AgencyInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(False))
				Me.PrintContactAfterAddress = AgencyInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(False))
				Me.ShowCodes = AgencyInvoicePrintingMediaSetting.ShowCodes
				Me.ContactType = AgencyInvoicePrintingMediaSetting.ContactType
				Me.IncludeBillingComment = AgencyInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(False))
				Me.InvoiceFooterCommentType = AgencyInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(1))

				If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.InvoiceFooterComment) = True Then

					Me.InvoiceFooterComment = OneTimeInvoicePrintingMediaSetting.InvoiceFooterComment

				Else

					Me.InvoiceFooterComment = AgencyInvoicePrintingMediaSetting.InvoiceFooterComment

				End If

				If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.LocationCode) = True Then

					Me.LocationCode = OneTimeInvoicePrintingMediaSetting.LocationCode

                Else

					Me.LocationCode = AgencyInvoicePrintingMediaSetting.LocationCode

                End If

				Me.UseLocationPrintOptions = AgencyInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False))

            Else

				Me.IsOneTime = InvoicePrintingMediaSetting.IsOneTime.GetValueOrDefault(False)
				Me.Type = InvoicePrintingMediaSetting.Type.GetValueOrDefault(0)
				Me.ClientCode = InvoicePrintingMediaSetting.ClientCode
				Me.AddressBlockType = InvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1)
				Me.CustomFormatName = InvoicePrintingMediaSetting.CustomFormatName
				Me.PrintClientName = InvoicePrintingMediaSetting.PrintClientName
				Me.PrintDivisionName = InvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(False)
				Me.PrintProductDescription = InvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(False)
				Me.PrintContactAfterAddress = InvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(False)
				Me.ShowCodes = InvoicePrintingMediaSetting.ShowCodes
				Me.ContactType = InvoicePrintingMediaSetting.ContactType
				Me.IncludeBillingComment = InvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(False)
				Me.InvoiceFooterCommentType = InvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(1)
				Me.InvoiceFooterComment = InvoicePrintingMediaSetting.InvoiceFooterComment
				Me.LocationCode = InvoicePrintingMediaSetting.LocationCode
				Me.UseLocationPrintOptions = InvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False)

            End If

			If MediaType = "M" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.MagazineInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.MagazineUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.MagazineGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.MagazinePrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.MagazineShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.MagazineShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.MagazineShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.MagazineShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.MagazineShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.MagazineOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.MagazineVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.MagazineShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.MagazineOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.MagazineNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.MagazineCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.MagazineTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.MagazineBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.MagazinePriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.MagazineBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.MagazineShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = 0
				Me.SpotLengthColumn = 0
				Me.TagColumn = 0
				Me.StartEndTimesColumn = 0
				Me.NumberOfSpotsColumn = 0
				Me.RemarksColumn = 0
				Me.HeadlineColumn = InvoicePrintingMediaSetting.MagazineHeadlineColumn.GetValueOrDefault(0)
				Me.StartDatesColumn = 0
				Me.EndDatesColumn = 0
				Me.CreativeSizeColumn = 0
				Me.InsertDatesColumn = InvoicePrintingMediaSetting.MagazineInsertDatesColumn.GetValueOrDefault(0)
				Me.OutdoorEndDateColumn = 0
				Me.CopyAreaColumn = 0
				Me.MaterialColumn = InvoicePrintingMediaSetting.MagazineMaterialColumn.GetValueOrDefault(0)
				Me.AdNumberColumn = InvoicePrintingMediaSetting.MagazineAdNumberColumn.GetValueOrDefault(0)
				Me.LocationColumn = 0
				Me.OutdoorTypeColumn = 0
				Me.SizeColumn = 0
				Me.EditorialIssueColumn = InvoicePrintingMediaSetting.MagazineEditorialIssueColumn.GetValueOrDefault(0)
				Me.SectionColumn = 0
				Me.QuantityColumn = 0
				Me.AdSizeColumn = InvoicePrintingMediaSetting.MagazineAdSizeColumn.GetValueOrDefault(0)
				Me.URLColumn = 0
				Me.InternetTypeColumn = 0
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.MagazineJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.MagazineJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.MagazineComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = InvoicePrintingMediaSetting.MagazineOrderDetailCommentColumn.GetValueOrDefault(0)
				Me.OrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.MagazineOrderHouseDetailCommentColumn.GetValueOrDefault(0)
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.MagazineExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.MagazineShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.MagazineShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.MagazineShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.MagazineShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.MagazineShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.MagazineShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.MagazineShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.MagazineShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.MagazineClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.MagazineSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.MagazineCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.MagazineHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.MagazineSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.MagazineLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts
				Me.CloseDateColumn = InvoicePrintingMediaSetting.MagazineCloseDateColumn
                Me.GuaranteedImpressionsColumn = 0
                Me.StartDateColumn = 0
                'SetColumnHeader(InvoicePrintingMediaSetting.MagazineOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.MagazineLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.MagazineVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.MagazineShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.MagazineOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)

				Else

                    SetColumnHeader(InvoicePrintingMediaSetting.MagazineLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.MagazineVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.MagazineShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.MagazineOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)

				End If

				SetColumnHeader(InvoicePrintingMediaSetting.MagazineNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazinePriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineHeadlineColumn.GetValueOrDefault(0), HeadlineColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineInsertDatesColumn.GetValueOrDefault(0), InsertDatesColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineMaterialColumn.GetValueOrDefault(0), MaterialColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineAdNumberColumn.GetValueOrDefault(0), AdNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineEditorialIssueColumn.GetValueOrDefault(0), EditorialIssueColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineAdSizeColumn.GetValueOrDefault(0), AdSizeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineOrderDetailCommentColumn.GetValueOrDefault(0), OrderDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineOrderHouseDetailCommentColumn.GetValueOrDefault(0), OrderHouseDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.MagazineCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				'SetColumnHeader(InvoicePrintingMediaSetting.MagazineExtraChargesColumn.GetValueOrDefault(0), ExtraChargesColumnHeader, TextAlignment.Center, False, HeaderType.Default)

			ElseIf MediaType = "N" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.NewspaperInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.NewspaperUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.NewspaperGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.NewspaperPrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.NewspaperShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.NewspaperShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.NewspaperShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.NewspaperShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.NewspaperShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.NewspaperOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.NewspaperVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.NewspaperShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.NewspaperOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.NewspaperNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.NewspaperCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.NewspaperTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.NewspaperBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.NewspaperPriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.NewspaperBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.NewspaperShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = 0
				Me.SpotLengthColumn = 0
				Me.TagColumn = 0
				Me.StartEndTimesColumn = 0
				Me.NumberOfSpotsColumn = 0
				Me.RemarksColumn = 0
				Me.HeadlineColumn = InvoicePrintingMediaSetting.NewspaperHeadlineColumn.GetValueOrDefault(0)
				Me.StartDatesColumn = 0
				Me.EndDatesColumn = 0
				Me.CreativeSizeColumn = 0
				Me.InsertDatesColumn = InvoicePrintingMediaSetting.NewspaperInsertDatesColumn.GetValueOrDefault(0)
				Me.OutdoorEndDateColumn = 0
				Me.CopyAreaColumn = 0
				Me.MaterialColumn = InvoicePrintingMediaSetting.NewspaperMaterialColumn.GetValueOrDefault(0)
				Me.AdNumberColumn = InvoicePrintingMediaSetting.NewspaperAdNumberColumn.GetValueOrDefault(0)
				Me.LocationColumn = 0
				Me.OutdoorTypeColumn = 0
				Me.SizeColumn = 0
				Me.EditorialIssueColumn = InvoicePrintingMediaSetting.NewspaperEditorialIssueColumn.GetValueOrDefault(0)
				Me.SectionColumn = InvoicePrintingMediaSetting.NewspaperSectionColumn.GetValueOrDefault(0)
				Me.QuantityColumn = InvoicePrintingMediaSetting.NewspaperQuantityColumn.GetValueOrDefault(0)
				Me.AdSizeColumn = InvoicePrintingMediaSetting.NewspaperAdSizeColumn.GetValueOrDefault(0)
				Me.URLColumn = 0
				Me.InternetTypeColumn = 0
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.NewspaperJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.NewspaperJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.NewspaperComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = InvoicePrintingMediaSetting.NewspaperOrderDetailCommentColumn.GetValueOrDefault(0)
				Me.OrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.NewspaperOrderHouseDetailCommentColumn.GetValueOrDefault(0)
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.NewspaperExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.NewspaperShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.NewspaperShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.NewspaperShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.NewspaperShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.NewspaperShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.NewspaperShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.NewspaperShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.NewspaperShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.NewspaperClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.NewspaperSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.NewspaperCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.NewspaperHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.NewspaperSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.NewspaperLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts
                Me.CloseDateColumn = InvoicePrintingMediaSetting.NewspaperCloseDateColumn
                Me.GuaranteedImpressionsColumn = 0
                Me.StartDateColumn = 0

                'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.NewspaperLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.NewspaperOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)

				Else

                    SetColumnHeader(InvoicePrintingMediaSetting.NewspaperLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.NewspaperOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)

				End If

				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperPriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperHeadlineColumn.GetValueOrDefault(0), HeadlineColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperInsertDatesColumn.GetValueOrDefault(0), InsertDatesColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperMaterialColumn.GetValueOrDefault(0), MaterialColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperAdNumberColumn.GetValueOrDefault(0), AdNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperEditorialIssueColumn.GetValueOrDefault(0), EditorialIssueColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperSectionColumn.GetValueOrDefault(0), SectionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperQuantityColumn.GetValueOrDefault(0), QuantityColumnHeader, TextAlignment.Far, True, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperAdSizeColumn.GetValueOrDefault(0), AdSizeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperOrderDetailCommentColumn.GetValueOrDefault(0), OrderDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperOrderHouseDetailCommentColumn.GetValueOrDefault(0), OrderHouseDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.NewspaperCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				'SetColumnHeader(InvoicePrintingMediaSetting.NewspaperExtraChargesColumn.GetValueOrDefault(0), ExtraChargesColumnHeader, TextAlignment.Center, False, HeaderType.Default)

			ElseIf MediaType = "I" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.InternetInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.InternetUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.InternetGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.InternetPrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.InternetShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.InternetShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.InternetShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.InternetShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.InternetShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.InternetOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.InternetVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.InternetShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.InternetOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.InternetNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.InternetCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.InternetTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.InternetBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.InternetPriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.InternetBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.InternetShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = 0
				Me.SpotLengthColumn = 0
				Me.TagColumn = 0
				Me.StartEndTimesColumn = 0
				Me.NumberOfSpotsColumn = 0
				Me.RemarksColumn = 0
				Me.HeadlineColumn = InvoicePrintingMediaSetting.InternetHeadlineColumn.GetValueOrDefault(0)
				Me.StartDatesColumn = InvoicePrintingMediaSetting.InternetStartDatesColumn.GetValueOrDefault(0)
				Me.EndDatesColumn = InvoicePrintingMediaSetting.InternetEndDatesColumn.GetValueOrDefault(0)
				Me.CreativeSizeColumn = InvoicePrintingMediaSetting.InternetCreativeSizeColumn.GetValueOrDefault(0)
				Me.InsertDatesColumn = 0
				Me.OutdoorEndDateColumn = 0
				Me.CopyAreaColumn = 0
				Me.MaterialColumn = 0
				Me.AdNumberColumn = InvoicePrintingMediaSetting.InternetAdNumberColumn.GetValueOrDefault(0)
				Me.LocationColumn = 0
				Me.OutdoorTypeColumn = 0
				Me.SizeColumn = 0
				Me.EditorialIssueColumn = 0
				Me.SectionColumn = 0
				Me.QuantityColumn = 0
				Me.AdSizeColumn = 0
				Me.URLColumn = InvoicePrintingMediaSetting.InternetURLColumn.GetValueOrDefault(0)
				Me.InternetTypeColumn = InvoicePrintingMediaSetting.InternetInternetTypeColumn.GetValueOrDefault(0)
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.InternetJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.InternetJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.InternetComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = 0
				Me.OrderHouseDetailCommentColumn = 0
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.InternetExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.InternetShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.InternetShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.InternetShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.InternetShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.InternetShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.InternetShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.InternetShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.InternetShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.InternetClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.InternetSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.InternetCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.InternetHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.InternetSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.InternetLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.InternetShowZeroLineAmounts
                Me.CloseDateColumn = InvoicePrintingMediaSetting.InternetCloseDateColumn
                Me.GuaranteedImpressionsColumn = InvoicePrintingMediaSetting.InternetGuaranteedImpressionsColumn.GetValueOrDefault(0)
                Me.StartDateColumn = 0

                ' SetColumnHeader(InvoicePrintingMediaSetting.InternetOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.InternetLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.InternetVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.InternetShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.InternetOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)
					SetColumnHeader(InvoicePrintingMediaSetting.InternetStartDatesColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
					SetColumnHeader(InvoicePrintingMediaSetting.InternetEndDatesColumn.GetValueOrDefault(0), EndDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)

				Else

                    SetColumnHeader(InvoicePrintingMediaSetting.InternetLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.InternetVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.InternetShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.InternetOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)
					SetColumnHeader(InvoicePrintingMediaSetting.InternetStartDatesColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, True, HeaderType.Default)
					SetColumnHeader(InvoicePrintingMediaSetting.InternetEndDatesColumn.GetValueOrDefault(0), EndDateColumnHeader, TextAlignment.Center, True, HeaderType.Default)

				End If
				SetColumnHeader(InvoicePrintingMediaSetting.InternetNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetPriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetHeadlineColumn.GetValueOrDefault(0), HeadlineColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetCreativeSizeColumn.GetValueOrDefault(0), CreativeSizeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetAdNumberColumn.GetValueOrDefault(0), AdNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetURLColumn.GetValueOrDefault(0), URLColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetInternetTypeColumn.GetValueOrDefault(0), InternetTypeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.InternetCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                SetColumnHeader(InvoicePrintingMediaSetting.InternetGuaranteedImpressionsColumn.GetValueOrDefault(0), GuaranteedImpressionsColumnHeader, TextAlignment.Far, False, HeaderType.Default)

            ElseIf MediaType = "O" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.OutdoorInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.OutdoorUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.OutdoorGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.OutdoorPrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.OutdoorShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.OutdoorShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.OutdoorShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.OutdoorShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.OutdoorShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.OutdoorOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.OutdoorVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.OutdoorShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.OutdoorOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.OutdoorNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.OutdoorCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.OutdoorTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.OutdoorBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.OutdoorPriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.OutdoorBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.OutdoorShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = 0
				Me.SpotLengthColumn = 0
				Me.TagColumn = 0
				Me.StartEndTimesColumn = 0
				Me.NumberOfSpotsColumn = 0
				Me.RemarksColumn = 0
				Me.HeadlineColumn = InvoicePrintingMediaSetting.OutdoorHeadlineColumn.GetValueOrDefault(0)
				Me.StartDatesColumn = 0
				Me.EndDatesColumn = 0
				Me.CreativeSizeColumn = 0
				Me.InsertDatesColumn = InvoicePrintingMediaSetting.OutdoorInsertDatesColumn.GetValueOrDefault(0)
				Me.OutdoorEndDateColumn = InvoicePrintingMediaSetting.OutdoorEndDateColumn.GetValueOrDefault(0)
				Me.CopyAreaColumn = InvoicePrintingMediaSetting.OutdoorCopyAreaColumn.GetValueOrDefault(0)
				Me.MaterialColumn = 0
				Me.AdNumberColumn = InvoicePrintingMediaSetting.OutdoorAdNumberColumn.GetValueOrDefault(0)
				Me.LocationColumn = InvoicePrintingMediaSetting.OutdoorLocationColumn.GetValueOrDefault(0)
				Me.OutdoorTypeColumn = InvoicePrintingMediaSetting.OutdoorOutdoorTypeColumn.GetValueOrDefault(0)
				Me.SizeColumn = InvoicePrintingMediaSetting.OutdoorSizeColumn.GetValueOrDefault(0)
				Me.EditorialIssueColumn = 0
				Me.SectionColumn = 0
				Me.QuantityColumn = 0
				Me.AdSizeColumn = 0
				Me.URLColumn = 0
				Me.InternetTypeColumn = 0
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.OutdoorJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.OutdoorJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.OutdoorComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = 0
				Me.OrderHouseDetailCommentColumn = 0
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.OutdoorExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.OutdoorShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.OutdoorShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.OutdoorShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.OutdoorShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.OutdoorShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.OutdoorShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.OutdoorShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.OutdoorShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.OutdoorClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.OutdoorSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.OutdoorCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.OutdoorHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.OutdoorSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.OutdoorLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts
                Me.CloseDateColumn = InvoicePrintingMediaSetting.OutdoorCloseDateColumn
                Me.GuaranteedImpressionsColumn = 0
                Me.StartDateColumn = 0

                'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorInsertDatesColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorEndDateColumn.GetValueOrDefault(0), EndDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)

                Else

                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorInsertDatesColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, True, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.OutdoorEndDateColumn.GetValueOrDefault(0), EndDateColumnHeader, TextAlignment.Center, True, HeaderType.Default)

                End If

				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorPriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
                SetColumnHeader(InvoicePrintingMediaSetting.OutdoorHeadlineColumn.GetValueOrDefault(0), HeadlineColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                SetColumnHeader(InvoicePrintingMediaSetting.OutdoorCopyAreaColumn.GetValueOrDefault(0), CopyAreaColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorAdNumberColumn.GetValueOrDefault(0), AdNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorLocationColumn.GetValueOrDefault(0), LocationColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorOutdoorTypeColumn.GetValueOrDefault(0), OutdoorTypeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorSizeColumn.GetValueOrDefault(0), SizeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.OutdoorCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				'SetColumnHeader(InvoicePrintingMediaSetting.OutdoorExtraChargesColumn.GetValueOrDefault(0), ExtraChargesColumnHeader, TextAlignment.Center, False, HeaderType.Default)

			ElseIf MediaType = "R" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.RadioInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.RadioUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.RadioGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.RadioPrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.RadioShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.RadioShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.RadioShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.RadioShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.RadioShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.RadioOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.RadioVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.RadioShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.RadioOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.RadioNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.RadioCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.RadioTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.RadioBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.RadioPriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.RadioBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.RadioShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = InvoicePrintingMediaSetting.RadioProgramColumn.GetValueOrDefault(0)
				Me.SpotLengthColumn = InvoicePrintingMediaSetting.RadioSpotLengthColumn.GetValueOrDefault(0)
				Me.TagColumn = InvoicePrintingMediaSetting.RadioTagColumn.GetValueOrDefault(0)
				Me.StartEndTimesColumn = InvoicePrintingMediaSetting.RadioStartEndTimesColumn.GetValueOrDefault(0)
				Me.NumberOfSpotsColumn = InvoicePrintingMediaSetting.RadioNumberOfSpotsColumn.GetValueOrDefault(0)
				Me.RemarksColumn = InvoicePrintingMediaSetting.RadioRemarksColumn.GetValueOrDefault(0)
				Me.HeadlineColumn = 0
				Me.StartDatesColumn = 0
				Me.EndDatesColumn = 0
				Me.CreativeSizeColumn = 0
				Me.InsertDatesColumn = 0
				Me.OutdoorEndDateColumn = 0
				Me.CopyAreaColumn = 0
				Me.MaterialColumn = 0
				Me.AdNumberColumn = 0
				Me.LocationColumn = 0
				Me.OutdoorTypeColumn = 0
				Me.SizeColumn = 0
				Me.EditorialIssueColumn = 0
				Me.SectionColumn = 0
				Me.QuantityColumn = 0
				Me.AdSizeColumn = 0
				Me.URLColumn = 0
				Me.InternetTypeColumn = 0
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.RadioJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.RadioJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.RadioComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = InvoicePrintingMediaSetting.RadioOrderDetailCommentColumn.GetValueOrDefault(0)
				Me.OrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.RadioOrderHouseDetailCommentColumn.GetValueOrDefault(0)
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.RadioExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.RadioShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.RadioShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.RadioShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.RadioShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.RadioShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.RadioShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.RadioShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.RadioShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.RadioClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.RadioSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.RadioCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.RadioHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.RadioSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.RadioLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.RadioShowZeroLineAmounts
				Me.CloseDateColumn = InvoicePrintingMediaSetting.RadioCloseDateColumn
                Me.GuaranteedImpressionsColumn = 0
                Me.StartDateColumn = InvoicePrintingMediaSetting.RadioStartDateColumn.GetValueOrDefault(0)

                'SetColumnHeader(InvoicePrintingMediaSetting.RadioOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.RadioLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.RadioVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.RadioShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.RadioOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)

				Else

                    SetColumnHeader(InvoicePrintingMediaSetting.RadioLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.RadioVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.RadioShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.RadioOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)

				End If

				SetColumnHeader(InvoicePrintingMediaSetting.RadioNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioPriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioProgramColumn.GetValueOrDefault(0), ProgramColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioSpotLengthColumn.GetValueOrDefault(0), SpotLengthColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioTagColumn.GetValueOrDefault(0), TagColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioStartEndTimesColumn.GetValueOrDefault(0), StartEndTimesColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioNumberOfSpotsColumn.GetValueOrDefault(0), NumberOfSpotsColumnHeader, TextAlignment.Center, True, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioRemarksColumn.GetValueOrDefault(0), RemarksColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioOrderDetailCommentColumn.GetValueOrDefault(0), OrderDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioOrderHouseDetailCommentColumn.GetValueOrDefault(0), OrderHouseDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.RadioCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                SetColumnHeader(InvoicePrintingMediaSetting.RadioStartDateColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)

            ElseIf MediaType = "T" Then

				Me.InvoiceTitle = InvoicePrintingMediaSetting.TVInvoiceTitle
				Me.UseInvoiceCategoryDescription = InvoicePrintingMediaSetting.TVUseInvoiceCategoryDescription.GetValueOrDefault(False)
				Me.GroupByMarket = InvoicePrintingMediaSetting.TVGroupByMarket.GetValueOrDefault(False)
				Me.PrintInvoiceDueDate = InvoicePrintingMediaSetting.TVPrintInvoiceDueDate.GetValueOrDefault(False)

				Me.ShowOrderDescription = InvoicePrintingMediaSetting.TVShowOrderDescription.GetValueOrDefault(False)
				Me.ShowClientReference = InvoicePrintingMediaSetting.TVShowClientReference.GetValueOrDefault(False)
				Me.ShowClientPO = InvoicePrintingMediaSetting.TVShowClientPO.GetValueOrDefault(False)
				Me.ShowOrderComment = InvoicePrintingMediaSetting.TVShowOrderComment.GetValueOrDefault(False)
				Me.ShowOrderHouseComment = InvoicePrintingMediaSetting.TVShowOrderHouseComment.GetValueOrDefault(False)

				Me.OrderNumberColumn = InvoicePrintingMediaSetting.TVOrderNumberColumn.GetValueOrDefault(1)
				Me.VendorNameColumn = InvoicePrintingMediaSetting.TVVendorNameColumn.GetValueOrDefault(1)
				Me.ShowVendorCode = InvoicePrintingMediaSetting.TVShowVendorCode.GetValueOrDefault(0)
				Me.OrderMonthsColumn = InvoicePrintingMediaSetting.TVOrderMonthsColumn.GetValueOrDefault(0)
				Me.NetAmountColumn = InvoicePrintingMediaSetting.TVNetAmountColumn.GetValueOrDefault(0)
				Me.CommissionAmountColumn = InvoicePrintingMediaSetting.TVCommissionAmountColumn.GetValueOrDefault(0)

				Me.TaxAmountColumn = InvoicePrintingMediaSetting.TVTaxAmountColumn.GetValueOrDefault(0)
				Me.BillAmountColumn = InvoicePrintingMediaSetting.TVBillAmountColumn.GetValueOrDefault(0)
				Me.PriorBillAmountColumn = InvoicePrintingMediaSetting.TVPriorBillAmountColumn.GetValueOrDefault(0)
				Me.BilledToDateAmountColumn = InvoicePrintingMediaSetting.TVBilledToDateAmountColumn.GetValueOrDefault(0)
				Me.ShowLineDetail = If(InvoicePrintingMediaSetting.TVShowLineDetail.GetValueOrDefault(False) = True, 1, 0)
				Me.ProgramColumn = InvoicePrintingMediaSetting.TVProgramColumn.GetValueOrDefault(0)
				Me.SpotLengthColumn = InvoicePrintingMediaSetting.TVSpotLengthColumn.GetValueOrDefault(0)
				Me.TagColumn = InvoicePrintingMediaSetting.TVTagColumn.GetValueOrDefault(0)
				Me.StartEndTimesColumn = InvoicePrintingMediaSetting.TVStartEndTimesColumn.GetValueOrDefault(0)
				Me.NumberOfSpotsColumn = InvoicePrintingMediaSetting.TVNumberOfSpotsColumn.GetValueOrDefault(0)
				Me.RemarksColumn = InvoicePrintingMediaSetting.TVRemarksColumn.GetValueOrDefault(0)
				Me.HeadlineColumn = 0
				Me.StartDatesColumn = 0
				Me.EndDatesColumn = 0
				Me.CreativeSizeColumn = 0
				Me.InsertDatesColumn = 0
				Me.OutdoorEndDateColumn = 0
				Me.CopyAreaColumn = 0
				Me.MaterialColumn = 0
				Me.AdNumberColumn = 0
				Me.LocationColumn = 0
				Me.OutdoorTypeColumn = 0
				Me.SizeColumn = 0
				Me.EditorialIssueColumn = 0
				Me.SectionColumn = 0
				Me.QuantityColumn = 0
				Me.AdSizeColumn = 0
				Me.URLColumn = 0
				Me.InternetTypeColumn = 0
				Me.JobComponentNumberColumn = InvoicePrintingMediaSetting.TVJobComponentNumberColumn.GetValueOrDefault(0)
				Me.JobDescriptionColumn = InvoicePrintingMediaSetting.TVJobDescriptionColumn.GetValueOrDefault(0)
				Me.ComponentDescriptionColumn = InvoicePrintingMediaSetting.TVComponentDescriptionColumn.GetValueOrDefault(0)
				Me.OrderDetailCommentColumn = InvoicePrintingMediaSetting.TVOrderDetailCommentColumn.GetValueOrDefault(0)
				Me.OrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.TVOrderHouseDetailCommentColumn.GetValueOrDefault(0)
				Me.ExtraChargesColumn = InvoicePrintingMediaSetting.TVExtraChargesColumn.GetValueOrDefault(0)
				Me.ShowCommissionSeparately = InvoicePrintingMediaSetting.TVShowCommissionSeparately.GetValueOrDefault(False)
				Me.ShowRebateSeparately = InvoicePrintingMediaSetting.TVShowRebateSeparately.GetValueOrDefault(False)
				Me.ShowTaxSeparately = InvoicePrintingMediaSetting.TVShowTaxSeparately.GetValueOrDefault(False)
				Me.ShowBillingHistory = InvoicePrintingMediaSetting.TVShowBillingHistory.GetValueOrDefault(False)
				Me.ShowCampaign = InvoicePrintingMediaSetting.TVShowCampaign
				Me.ShowCampaignComment = InvoicePrintingMediaSetting.TVShowCampaignComment
				Me.ShowOrderSubtotals = InvoicePrintingMediaSetting.TVShowOrderSubtotals
				Me.ShowSalesClass = InvoicePrintingMediaSetting.TVShowSalesClass
				Me.ClientPOLocation = InvoicePrintingMediaSetting.TVClientPOLocation
				Me.SalesClassLocation = InvoicePrintingMediaSetting.TVSalesClassLocation
				Me.CampaignLocation = InvoicePrintingMediaSetting.TVCampaignLocation
				Me.HeaderGroupBy = InvoicePrintingMediaSetting.TVHeaderGroupBy
				Me.SortLinesBy = InvoicePrintingMediaSetting.TVSortLinesBy
				Me.LineNumberColumn = InvoicePrintingMediaSetting.TVLineNumberColumn
				Me.ShowZeroFunctionAmounts = InvoicePrintingMediaSetting.TVShowZeroLineAmounts
				Me.CloseDateColumn = InvoicePrintingMediaSetting.TVCloseDateColumn
                Me.GuaranteedImpressionsColumn = 0
                Me.StartDateColumn = InvoicePrintingMediaSetting.TVStartDateColumn.GetValueOrDefault(0)

                'SetColumnHeader(InvoicePrintingMediaSetting.TVOrderNumberColumn.GetValueOrDefault(1), OrderNumberColumnHeader, TextAlignment.Near, False, HeaderType.Default)

                If Me.ShowLineDetail = 1 Then

                    SetColumnHeader(InvoicePrintingMediaSetting.TVLineNumberColumn.GetValueOrDefault(1), LineNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.TVVendorNameColumn.GetValueOrDefault(1), VendorNameColumnHeader, TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.TVShowVendorCode.GetValueOrDefault(0), VendorCodeColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.TVOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, False, HeaderType.Default)

				Else

                    SetColumnHeader(InvoicePrintingMediaSetting.TVLineNumberColumn.GetValueOrDefault(1), "", TextAlignment.Center, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.TVVendorNameColumn.GetValueOrDefault(1), "", TextAlignment.Near, False, HeaderType.Default)
                    'SetColumnHeader(InvoicePrintingMediaSetting.TVShowVendorCode.GetValueOrDefault(0), "", TextAlignment.Center, False, HeaderType.Default)
                    SetColumnHeader(InvoicePrintingMediaSetting.TVOrderMonthsColumn.GetValueOrDefault(0), OrderMonthsColumnHeader, TextAlignment.Center, True, HeaderType.Default)

				End If

				SetColumnHeader(InvoicePrintingMediaSetting.TVNetAmountColumn.GetValueOrDefault(0), NetAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVCommissionAmountColumn.GetValueOrDefault(0), CommissionAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVTaxAmountColumn.GetValueOrDefault(0), TaxAmountColumnHeader, TextAlignment.Far, True, HeaderType.OtherTotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVBillAmountColumn.GetValueOrDefault(0), BillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVPriorBillAmountColumn.GetValueOrDefault(0), PriorBillAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVBilledToDateAmountColumn.GetValueOrDefault(0), BilledToDateAmountColumnHeader, TextAlignment.Far, True, HeaderType.TotalAmounts)
				SetColumnHeader(InvoicePrintingMediaSetting.TVProgramColumn.GetValueOrDefault(0), ProgramColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVSpotLengthColumn.GetValueOrDefault(0), SpotLengthColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVTagColumn.GetValueOrDefault(0), TagColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVStartEndTimesColumn.GetValueOrDefault(0), StartEndTimesColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVNumberOfSpotsColumn.GetValueOrDefault(0), NumberOfSpotsColumnHeader, TextAlignment.Center, True, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVRemarksColumn.GetValueOrDefault(0), RemarksColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVJobComponentNumberColumn.GetValueOrDefault(0), JobComponentNumberColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVJobDescriptionColumn.GetValueOrDefault(0), JobDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVComponentDescriptionColumn.GetValueOrDefault(0), ComponentDescriptionColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVOrderDetailCommentColumn.GetValueOrDefault(0), OrderDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVOrderHouseDetailCommentColumn.GetValueOrDefault(0), OrderHouseDetailCommentColumnHeader, TextAlignment.Center, False, HeaderType.Default)
				SetColumnHeader(InvoicePrintingMediaSetting.TVCloseDateColumn.GetValueOrDefault(0), CloseDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)
                SetColumnHeader(InvoicePrintingMediaSetting.TVStartDateColumn.GetValueOrDefault(0), StartDateColumnHeader, TextAlignment.Center, False, HeaderType.Default)

            End If

			Me.PageHeaderComment = InvoicePrintingMediaSetting.PageHeaderComment
			Me.PageFooterComment = InvoicePrintingMediaSetting.PageFooterComment
			Me.PageHeaderLogoPath = InvoicePrintingMediaSetting.PageHeaderLogoPath
			Me.PageHeaderLogoPathLandscape = InvoicePrintingMediaSetting.PageHeaderLogoPathLandscape
			Me.PageFooterLogoPath = InvoicePrintingMediaSetting.PageFooterLogoPath
			Me.PageFooterLogoPathLandscape = InvoicePrintingMediaSetting.PageFooterLogoPathLandscape
			Me.PageHeaderLineVisible = Not String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.PageHeaderComment)
            Me.ShowPageHeaderLogo = InvoicePrintingMediaSetting.ShowPageHeaderLogo
            Me.ShowPageFooterLogo = InvoicePrintingMediaSetting.ShowPageFooterLogo

            If Me.ShowCommissionSeparately = False AndAlso Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False Then

				Me.InvoiceTotalVerbiage = "Total"

			Else

				Me.InvoiceTotalVerbiage = "Invoice Total"

			End If

			If IsMultiCurrencyEnabled AndAlso String.IsNullOrWhiteSpace(CurrencyCode) = False Then

				Me.ApplyExchangeRate = 2
				Me.ExchangeRateAmount = ExchangeRateAmount

				Me.ExchangeRateNote = "Exchange rate of " & FormatNumber(Me.ExchangeRateAmount, 4) & " has been applied."
				Me.ExchangeRateNoteVisible = True

			Else

				If (MediaType = "M" AndAlso InvoicePrintingMediaSetting.MagazineUseAgencySetting) OrElse
						(MediaType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperUseAgencySetting) OrElse
						(MediaType = "I" AndAlso InvoicePrintingMediaSetting.InternetUseAgencySetting) OrElse
						(MediaType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorUseAgencySetting) OrElse
						(MediaType = "R" AndAlso InvoicePrintingMediaSetting.RadioUseAgencySetting) OrElse
						(MediaType = "T" AndAlso InvoicePrintingMediaSetting.TVUseAgencySetting) Then

					Me.ApplyExchangeRate = AgencyInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1))
					Me.ExchangeRateAmount = AgencyInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1))

				Else

					Me.ApplyExchangeRate = InvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1)
					Me.ExchangeRateAmount = InvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1)

				End If

				If Me.ApplyExchangeRate = 2 Then

					Me.ExchangeRateNote = "Note: This invoice has been converted using the exchange rate of " & FormatNumber(Me.ExchangeRateAmount, 4)
					Me.ExchangeRateNoteVisible = True

				Else

					Me.ExchangeRateNote = Nothing
					Me.ExchangeRateNoteVisible = False

				End If

			End If

            Me.ExchangeRateNoteVisible = (InvoicePrintingMediaSetting.HideExchangeRateMessage = False)

            If Me.ExchangeRateNoteVisible = False Then

                Me.ExchangeRateNote = Nothing

            End If

            Me.CommissionLabel = "Commission"
			Me.RebateLabel = "Rebate"
			Me.CityTaxLabel = InvoicePrintingMediaSetting.CityTaxLabel
			Me.CountyTaxLabel = InvoicePrintingMediaSetting.CountyTaxLabel
			Me.StateTaxLabel = InvoicePrintingMediaSetting.StateTaxLabel

			_InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
			_MediaType = MediaType

		End Sub
		Private Sub SetColumnHeader(ByVal ColumnNumber As Integer, ByVal HeaderText As String, ByVal TextAlignment As TextAlignment, ByVal TotalColumnVisible As Boolean, ByVal HeaderType As HeaderType)

            Dim GrandTotalColumnVisible As Boolean = False

            Select Case ColumnNumber

                Case 1

                    Me.ColumnHeader1 = HeaderText
                    Me.ColumnAlignment1 = CShort(TextAlignment)

                Case 2

                    Me.ColumnHeader2 = HeaderText
                    Me.ColumnAlignment2 = CShort(TextAlignment)

                Case 3

                    Me.ColumnHeader3 = HeaderText
                    Me.ColumnAlignment3 = CShort(TextAlignment)
                    Me.TotalColumnVisible3 = TotalColumnVisible

                    If HeaderType = MediaInvoicePrintingSetting.HeaderType.TotalAmounts Then

                        GrandTotalColumnVisible = True

                    ElseIf HeaderType = MediaInvoicePrintingSetting.HeaderType.OtherTotalAmounts Then

                        If TotalColumnVisible AndAlso (Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False AndAlso Me.ShowCommissionSeparately = False) Then

                            GrandTotalColumnVisible = True

                        End If

                    End If

                    Me.GrandTotalColumnVisible3 = GrandTotalColumnVisible

                Case 4

                    Me.ColumnHeader4 = HeaderText
                    Me.ColumnAlignment4 = CShort(TextAlignment)
                    Me.TotalColumnVisible4 = TotalColumnVisible

                    If HeaderType = MediaInvoicePrintingSetting.HeaderType.TotalAmounts Then

                        GrandTotalColumnVisible = True

                    ElseIf HeaderType = MediaInvoicePrintingSetting.HeaderType.OtherTotalAmounts Then

                        If TotalColumnVisible AndAlso (Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False AndAlso Me.ShowCommissionSeparately = False) Then

                            GrandTotalColumnVisible = True

                        End If

                    End If

                    Me.GrandTotalColumnVisible4 = GrandTotalColumnVisible

                Case 5

                    Me.ColumnHeader5 = HeaderText
                    Me.ColumnAlignment5 = CShort(TextAlignment)
                    Me.TotalColumnVisible5 = TotalColumnVisible

                    If HeaderType = MediaInvoicePrintingSetting.HeaderType.TotalAmounts Then

                        GrandTotalColumnVisible = True

                    ElseIf HeaderType = MediaInvoicePrintingSetting.HeaderType.OtherTotalAmounts Then

                        If TotalColumnVisible AndAlso (Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False AndAlso Me.ShowCommissionSeparately = False) Then

                            GrandTotalColumnVisible = True

                        End If

                    End If

                    Me.GrandTotalColumnVisible5 = GrandTotalColumnVisible

                Case 6

                    Me.ColumnHeader6 = HeaderText
                    Me.ColumnAlignment6 = CShort(TextAlignment)
                    Me.TotalColumnVisible6 = TotalColumnVisible

                    If HeaderType = MediaInvoicePrintingSetting.HeaderType.TotalAmounts Then

                        GrandTotalColumnVisible = True

                    ElseIf HeaderType = MediaInvoicePrintingSetting.HeaderType.OtherTotalAmounts Then

                        If TotalColumnVisible AndAlso (Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False AndAlso Me.ShowCommissionSeparately = False) Then

                            GrandTotalColumnVisible = True

                        End If

                    End If

                    Me.GrandTotalColumnVisible6 = GrandTotalColumnVisible

                Case 7

                    Me.ColumnHeader7 = HeaderText
                    Me.ColumnAlignment7 = CShort(TextAlignment)
                    Me.TotalColumnVisible7 = TotalColumnVisible

                    If HeaderType = MediaInvoicePrintingSetting.HeaderType.TotalAmounts Then

                        GrandTotalColumnVisible = True

                    ElseIf HeaderType = MediaInvoicePrintingSetting.HeaderType.OtherTotalAmounts Then

                        If TotalColumnVisible AndAlso (Me.ShowRebateSeparately = False AndAlso Me.ShowTaxSeparately = False AndAlso Me.ShowCommissionSeparately = False) Then

                            GrandTotalColumnVisible = True

                        End If

                    End If

                    Me.GrandTotalColumnVisible7 = GrandTotalColumnVisible

            End Select

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

    End Class

End Namespace
