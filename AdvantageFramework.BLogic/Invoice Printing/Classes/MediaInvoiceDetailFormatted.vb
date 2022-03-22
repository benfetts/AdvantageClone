Namespace InvoicePrinting.Classes

    Public Class MediaInvoiceDetailFormatted

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PageHeaderLogoPath
            PageHeaderComment
            PageHeaderLineVisible
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            Address
            InvoiceCategory
            FullInvoiceNumber
            InvoiceNumber
            InvoiceSequenceNumber
            InvoiceType
            InvoiceDate
            InvoiceDueDate
            BillingComment
            SalesClass
            Campaign
            CampaignComment
            ColumnHeader1
            ColumnHeader2
            ColumnHeader3
            ColumnHeader4
            ColumnHeader5
            ColumnHeader6
            ColumnHeader7
            OrderGroupByLabel
            OrderGroupBy
            OrderGroupByDateValue
            Market
            Vendor
            Order
            OrderNumber
            OrderLineNumber
            ClientReference
            ClientPO
            OrderComment
            OrderHouseComment
            ColumnValue1
            ColumnValue2
            ColumnValue3
            ColumnValue4
            ColumnValue5
            ColumnValue6
            ColumnValue7
            GroupTotalColumnValue3
            GroupTotalColumnValue4
            GroupTotalColumnValue5
            GroupTotalColumnValue6
            GroupTotalColumnValue7
            InvoiceTotalColumnValue3
            InvoiceTotalColumnValue4
            InvoiceTotalColumnValue5
            InvoiceTotalColumnValue6
            InvoiceTotalColumnValue7
            GrandTotalColumnValue3
            GrandTotalColumnValue4
            GrandTotalColumnValue5
            GrandTotalColumnValue6
            GrandTotalColumnValue7
            ProgramHeadline
            EditoralUrlLocationStartEndTimes
            MaterialCreativeSizeCopyAreaSpotLength
            SpotsQuantity
            InsertDateDates
            AdNumberTag
            Remarks
            Section
            SubType
            AdSizeCreativeSizeSize
            JobComponent
            JobDescription
            ComponentDescription
            OrderDetailComment
            OrderDetailHouseComment
            AdditionalCharges
            CommissionColumnValue3
            CommissionColumnValue4
            CommissionColumnValue5
            CommissionColumnValue6
            CommissionColumnValue7
            RebateColumnValue3
            RebateColumnValue4
            RebateColumnValue5
            RebateColumnValue6
            RebateColumnValue7
            CityTaxColumnValue3
            CityTaxColumnValue4
            CityTaxColumnValue5
            CityTaxColumnValue6
            CityTaxColumnValue7
            CountyTaxColumnValue3
            CountyTaxColumnValue4
            CountyTaxColumnValue5
            CountyTaxColumnValue6
            CountyTaxColumnValue7
            StateTaxColumnValue3
            StateTaxColumnValue4
            StateTaxColumnValue5
            StateTaxColumnValue6
            StateTaxColumnValue7
            Hours
            Rate
            RebateAmount
            NetAmount
            CommissionAmount
            NonResaleTax
            CityTax
            CountyTax
            StateTax
            TotalTax
            BillAmount
            TotalAmount
            ExchangeRateNoteVisible
            ExchangeRateNote
            InvoiceFooterComment
            InvoiceFooterCommentFontSize
            PageFooterLogoPath
            PageFooterComment

            AddressBlockType
            CustomFormatName
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            ContactType
            ShowCodes
            IncludeBillingComment
            ApplyExchangeRate
            ExchangeRateAmount
            InvoiceFooterCommentType
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
            PageHeaderLogoPathLandscape
            PageFooterLogoPathLandscape
            InvoiceTotalVerbiage
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
            ShowOrderSubtotals
            ShowSalesClass
            ClientPOLocation
            SalesClassLocation
            CampaignLocation
            HeaderGroupBy
            SortLinesBy
            HeaderStartDate
            HeaderEndDate
            OrderStartDate
            OrderEndDate
            LineNumberColumn
            CloseDateColumn
            OrderMonths
            JobNumber
            ComponentNumber
            CloseDate
        End Enum

        Private Enum ValueType
            Text
            [Date]
            [Integer]
            [Decimal]
            [OrderLineNumber]
            [Amounts]
        End Enum

        Private Enum SubTotalValueType
            [Commission]
            [Rebate]
            [CityTax]
            [CountyTax]
            [StateTax]
        End Enum

#End Region

#Region " Variables "

        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageHeaderLineVisible As Boolean = False
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _Address As String = Nothing
        Private _InvoiceCategory As String = Nothing
        Private _FullInvoiceNumber As String = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _InvoiceSequenceNumber As Short = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _InvoiceDueDate As Date = Nothing
        Private _BillingComment As String = Nothing
        Private _SalesClass As String = Nothing
        Private _Campaign As String = Nothing
        Private _CampaignComment As String = Nothing
        Private _ColumnHeader1 As String = Nothing
        Private _ColumnHeader2 As String = Nothing
        Private _ColumnHeader3 As String = Nothing
        Private _ColumnHeader4 As String = Nothing
        Private _ColumnHeader5 As String = Nothing
        Private _ColumnHeader6 As String = Nothing
        Private _ColumnHeader7 As String = Nothing
        Private _OrderGroupByLabel As String = Nothing
        Private _OrderGroupBy As String = Nothing
        Private _OrderGroupByDateValue As Nullable(Of Date) = Nothing
        Private _Market As String = Nothing
        Private _Vendor As String = Nothing
        Private _Order As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _OrderLineNumber As Short = Nothing
        Private _ClientReference As String = Nothing
        Private _ClientPO As String = Nothing
        Private _OrderComment As String = Nothing
        Private _OrderHouseComment As String = Nothing
        Private _ColumnValue1 As String = Nothing
        Private _ColumnValue2 As String = Nothing
        Private _ColumnValue3 As String = Nothing
        Private _ColumnValue4 As String = Nothing
        Private _ColumnValue5 As String = Nothing
        Private _ColumnValue6 As String = Nothing
        Private _ColumnValue7 As String = Nothing
        Private _GroupTotalColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _GroupTotalColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _GroupTotalColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _GroupTotalColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _GroupTotalColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotalColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotalColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotalColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotalColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotalColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _GrandTotalColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _GrandTotalColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _GrandTotalColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _GrandTotalColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _GrandTotalColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _ProgramHeadline As String = Nothing
        Private _EditoralUrlLocationStartEndTimes As String = Nothing
        Private _MaterialCreativeSizeCopyAreaSpotLength As String = Nothing
        Private _SpotsQuantity As String = Nothing
        Private _InsertDateDates As String = Nothing
        Private _AdNumberTag As String = Nothing
        Private _Remarks As String = Nothing
        Private _Section As String = Nothing
        Private _SubType As String = Nothing
        Private _AdSizeCreativeSizeSize As String = Nothing
        Private _JobComponent As String = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _OrderDetailComment As String = Nothing
        Private _OrderDetailHouseComment As String = Nothing
        Private _AdditionalCharges As String = Nothing
        Private _CommissionColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _CommissionColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _CommissionColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _CommissionColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _CommissionColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _RebateColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _RebateColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _RebateColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _RebateColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _RebateColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _CityTaxColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _CityTaxColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _CityTaxColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _CityTaxColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _CityTaxColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _CountyTaxColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _CountyTaxColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _CountyTaxColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _CountyTaxColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _CountyTaxColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _StateTaxColumnValue3 As Nullable(Of Decimal) = Nothing
        Private _StateTaxColumnValue4 As Nullable(Of Decimal) = Nothing
        Private _StateTaxColumnValue5 As Nullable(Of Decimal) = Nothing
        Private _StateTaxColumnValue6 As Nullable(Of Decimal) = Nothing
        Private _StateTaxColumnValue7 As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _RebateAmount As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTax As Nullable(Of Decimal) = Nothing
        Private _CityTax As Nullable(Of Decimal) = Nothing
        Private _CountyTax As Nullable(Of Decimal) = Nothing
        Private _StateTax As Nullable(Of Decimal) = Nothing
        Private _TotalTax As Nullable(Of Decimal) = Nothing
        Private _BillAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _ExchangeRateNoteVisible As Boolean = False
        Private _ExchangeRateNote As String = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _InvoiceFooterCommentFontSize As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _HeaderStartDate As Nullable(Of Date) = Nothing
        Private _HeaderEndDate As Nullable(Of Date) = Nothing
        Private _OrderStartDate As Nullable(Of Date) = Nothing
        Private _OrderEndDate As Nullable(Of Date) = Nothing
        Private _OrderMonths As String = Nothing

        Private _AddressBlockType As Short = Nothing
        Private _CustomFormatName As String = Nothing
        Private _PrintDivisionName As Boolean = Nothing
        Private _PrintProductDescription As Boolean = Nothing
        Private _PrintContactAfterAddress As Boolean = Nothing
        Private _ContactType As Integer = 0
        Private _ShowCodes As Boolean = Nothing
        Private _IncludeBillingComment As Boolean = Nothing
        Private _ApplyExchangeRate As Short = Nothing
        Private _ExchangeRateAmount As Decimal = Nothing
        Private _InvoiceFooterCommentType As Short = Nothing
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
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing
        Private _InvoiceTotalVerbiage As String = Nothing
        Private _ColumnAlignment1 As Short = 0
        Private _ColumnAlignment2 As Short = 0
        Private _ColumnAlignment3 As Short = 0
        Private _ColumnAlignment4 As Short = 0
        Private _ColumnAlignment5 As Short = 0
        Private _ColumnAlignment6 As Short = 0
        Private _ColumnAlignment7 As Short = 0
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
        Private _ShowOrderSubtotals As Boolean = True
        Private _ShowSalesClass As Boolean = False
        Private _ClientPOLocation As Integer = 1
        Private _SalesClassLocation As Integer = 1
        Private _CampaignLocation As Integer = 1
        Private _HeaderGroupBy As Integer = 0
        Private _SortLinesBy As Integer = 1
        Private _LineNumberColumn As Short = 0
        Private _CloseDateColumn As Short = 0

        Private _UserCode As String = Nothing
        Private _MediaInvoicePrintingSetting As MediaInvoicePrintingSetting = Nothing
        Private _MediaInvoiceDetail As MediaInvoiceDetail = Nothing

#End Region

#Region " Properties "

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
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
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
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Address() As String
            Get
                Address = _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceCategory() As String
            Get
                InvoiceCategory = _InvoiceCategory
            End Get
            Set(ByVal value As String)
                _InvoiceCategory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FullInvoiceNumber() As String
            Get
                FullInvoiceNumber = _FullInvoiceNumber
            End Get
            Set(ByVal value As String)
                _FullInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequenceNumber() As Short
            Get
                InvoiceSequenceNumber = _InvoiceSequenceNumber
            End Get
            Set(ByVal value As Short)
                _InvoiceSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(ByVal value As String)
                _InvoiceType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDueDate() As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingComment() As String
            Get
                BillingComment = _BillingComment
            End Get
            Set(ByVal value As String)
                _BillingComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Campaign() As String
            Get
                Campaign = _Campaign
            End Get
            Set(ByVal value As String)
                _Campaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClass() As String
            Get
                SalesClass = _SalesClass
            End Get
            Set(ByVal value As String)
                _SalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignComment() As String
            Get
                CampaignComment = _CampaignComment
            End Get
            Set(ByVal value As String)
                _CampaignComment = value
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
        Public Property OrderGroupByLabel() As String
            Get
                OrderGroupByLabel = _OrderGroupByLabel
            End Get
            Set(ByVal value As String)
                _OrderGroupByLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderGroupBy() As String
            Get
                OrderGroupBy = _OrderGroupBy
            End Get
            Set(ByVal value As String)
                _OrderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderGroupByDateValue() As Nullable(Of Date)
            Get
                OrderGroupByDateValue = _OrderGroupByDateValue
            End Get
            Set(ByVal value As Nullable(Of Date))
                _OrderGroupByDateValue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Market() As String
            Get
                Market = _Market
            End Get
            Set(ByVal value As String)
                _Market = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Vendor() As String
            Get
                Vendor = _Vendor
            End Get
            Set(ByVal value As String)
                _Vendor = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Order() As String
            Get
                Order = _Order
            End Get
            Set(ByVal value As String)
                _Order = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLineNumber() As Short
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As Short)
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set(ByVal value As String)
                _OrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderHouseComment() As String
            Get
                OrderHouseComment = _OrderHouseComment
            End Get
            Set(ByVal value As String)
                _OrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue1() As String
            Get
                ColumnValue1 = _ColumnValue1
            End Get
            Set(ByVal value As String)
                _ColumnValue1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue2() As String
            Get
                ColumnValue2 = _ColumnValue2
            End Get
            Set(ByVal value As String)
                _ColumnValue2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue3() As String
            Get
                ColumnValue3 = _ColumnValue3
            End Get
            Set(ByVal value As String)
                _ColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue4() As String
            Get
                ColumnValue4 = _ColumnValue4
            End Get
            Set(ByVal value As String)
                _ColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue5() As String
            Get
                ColumnValue5 = _ColumnValue5
            End Get
            Set(ByVal value As String)
                _ColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue6() As String
            Get
                ColumnValue6 = _ColumnValue6
            End Get
            Set(ByVal value As String)
                _ColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ColumnValue7() As String
            Get
                ColumnValue7 = _ColumnValue7
            End Get
            Set(ByVal value As String)
                _ColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupTotalColumnValue3() As Nullable(Of Decimal)
            Get
                GroupTotalColumnValue3 = _GroupTotalColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GroupTotalColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupTotalColumnValue4() As Nullable(Of Decimal)
            Get
                GroupTotalColumnValue4 = _GroupTotalColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GroupTotalColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupTotalColumnValue5() As Nullable(Of Decimal)
            Get
                GroupTotalColumnValue5 = _GroupTotalColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GroupTotalColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupTotalColumnValue6() As Nullable(Of Decimal)
            Get
                GroupTotalColumnValue6 = _GroupTotalColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GroupTotalColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupTotalColumnValue7() As Nullable(Of Decimal)
            Get
                GroupTotalColumnValue7 = _GroupTotalColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GroupTotalColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalColumnValue3() As Nullable(Of Decimal)
            Get
                InvoiceTotalColumnValue3 = _InvoiceTotalColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotalColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalColumnValue4() As Nullable(Of Decimal)
            Get
                InvoiceTotalColumnValue4 = _InvoiceTotalColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotalColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalColumnValue5() As Nullable(Of Decimal)
            Get
                InvoiceTotalColumnValue5 = _InvoiceTotalColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotalColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalColumnValue6() As Nullable(Of Decimal)
            Get
                InvoiceTotalColumnValue6 = _InvoiceTotalColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotalColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTotalColumnValue7() As Nullable(Of Decimal)
            Get
                InvoiceTotalColumnValue7 = _InvoiceTotalColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotalColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnValue3() As Nullable(Of Decimal)
            Get
                GrandTotalColumnValue3 = _GrandTotalColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrandTotalColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnValue4() As Nullable(Of Decimal)
            Get
                GrandTotalColumnValue4 = _GrandTotalColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrandTotalColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnValue5() As Nullable(Of Decimal)
            Get
                GrandTotalColumnValue5 = _GrandTotalColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrandTotalColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnValue6() As Nullable(Of Decimal)
            Get
                GrandTotalColumnValue6 = _GrandTotalColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrandTotalColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrandTotalColumnValue7() As Nullable(Of Decimal)
            Get
                GrandTotalColumnValue7 = _GrandTotalColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrandTotalColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramHeadline() As String
            Get
                ProgramHeadline = _ProgramHeadline
            End Get
            Set(ByVal value As String)
                _ProgramHeadline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditoralUrlLocationStartEndTimes() As String
            Get
                EditoralUrlLocationStartEndTimes = _EditoralUrlLocationStartEndTimes
            End Get
            Set(ByVal value As String)
                _EditoralUrlLocationStartEndTimes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialCreativeSizeCopyAreaSpotLength() As String
            Get
                MaterialCreativeSizeCopyAreaSpotLength = _MaterialCreativeSizeCopyAreaSpotLength
            End Get
            Set(ByVal value As String)
                _MaterialCreativeSizeCopyAreaSpotLength = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsQuantity() As String
            Get
                SpotsQuantity = _SpotsQuantity
            End Get
            Set(ByVal value As String)
                _SpotsQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsertDateDates() As String
            Get
                InsertDateDates = _InsertDateDates
            End Get
            Set(ByVal value As String)
                _InsertDateDates = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberTag() As String
            Get
                AdNumberTag = _AdNumberTag
            End Get
            Set(ByVal value As String)
                _AdNumberTag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remarks() As String
            Get
                Remarks = _Remarks
            End Get
            Set(ByVal value As String)
                _Remarks = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(ByVal value As String)
                _Section = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SubType() As String
            Get
                SubType = _SubType
            End Get
            Set(ByVal value As String)
                _SubType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSizeCreativeSizeSize() As String
            Get
                AdSizeCreativeSizeSize = _AdSizeCreativeSizeSize
            End Get
            Set(ByVal value As String)
                _AdSizeCreativeSizeSize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDetailComment() As String
            Get
                OrderDetailComment = _OrderDetailComment
            End Get
            Set(ByVal value As String)
                _OrderDetailComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDetailHouseComment() As String
            Get
                OrderDetailHouseComment = _OrderDetailHouseComment
            End Get
            Set(ByVal value As String)
                _OrderDetailHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdditionalCharges() As String
            Get
                AdditionalCharges = _AdditionalCharges
            End Get
            Set(ByVal value As String)
                _AdditionalCharges = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionColumnValue3() As Nullable(Of Decimal)
            Get
                CommissionColumnValue3 = _CommissionColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionColumnValue4() As Nullable(Of Decimal)
            Get
                CommissionColumnValue4 = _CommissionColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionColumnValue5() As Nullable(Of Decimal)
            Get
                CommissionColumnValue5 = _CommissionColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionColumnValue6() As Nullable(Of Decimal)
            Get
                CommissionColumnValue6 = _CommissionColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionColumnValue7() As Nullable(Of Decimal)
            Get
                CommissionColumnValue7 = _CommissionColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateColumnValue3() As Nullable(Of Decimal)
            Get
                RebateColumnValue3 = _RebateColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateColumnValue4() As Nullable(Of Decimal)
            Get
                RebateColumnValue4 = _RebateColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateColumnValue5() As Nullable(Of Decimal)
            Get
                RebateColumnValue5 = _RebateColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateColumnValue6() As Nullable(Of Decimal)
            Get
                RebateColumnValue6 = _RebateColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateColumnValue7() As Nullable(Of Decimal)
            Get
                RebateColumnValue7 = _RebateColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxColumnValue3() As Nullable(Of Decimal)
            Get
                CityTaxColumnValue3 = _CityTaxColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxColumnValue4() As Nullable(Of Decimal)
            Get
                CityTaxColumnValue4 = _CityTaxColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxColumnValue5() As Nullable(Of Decimal)
            Get
                CityTaxColumnValue5 = _CityTaxColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxColumnValue6() As Nullable(Of Decimal)
            Get
                CityTaxColumnValue6 = _CityTaxColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxColumnValue7() As Nullable(Of Decimal)
            Get
                CityTaxColumnValue7 = _CityTaxColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxColumnValue3() As Nullable(Of Decimal)
            Get
                CountyTaxColumnValue3 = _CountyTaxColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxColumnValue4() As Nullable(Of Decimal)
            Get
                CountyTaxColumnValue4 = _CountyTaxColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxColumnValue5() As Nullable(Of Decimal)
            Get
                CountyTaxColumnValue5 = _CountyTaxColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxColumnValue6() As Nullable(Of Decimal)
            Get
                CountyTaxColumnValue6 = _CountyTaxColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxColumnValue7() As Nullable(Of Decimal)
            Get
                CountyTaxColumnValue7 = _CountyTaxColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxColumnValue3() As Nullable(Of Decimal)
            Get
                StateTaxColumnValue3 = _StateTaxColumnValue3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxColumnValue3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxColumnValue4() As Nullable(Of Decimal)
            Get
                StateTaxColumnValue4 = _StateTaxColumnValue4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxColumnValue4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxColumnValue5() As Nullable(Of Decimal)
            Get
                StateTaxColumnValue5 = _StateTaxColumnValue5
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxColumnValue5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxColumnValue6() As Nullable(Of Decimal)
            Get
                StateTaxColumnValue6 = _StateTaxColumnValue6
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxColumnValue6 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxColumnValue7() As Nullable(Of Decimal)
            Get
                StateTaxColumnValue7 = _StateTaxColumnValue7
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxColumnValue7 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonResaleTax() As Nullable(Of Decimal)
            Get
                NonResaleTax = _NonResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTax() As Nullable(Of Decimal)
            Get
                CityTax = _CityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTax() As Nullable(Of Decimal)
            Get
                CountyTax = _CountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTax() As Nullable(Of Decimal)
            Get
                StateTax = _StateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalTax() As Nullable(Of Decimal)
            Get
                TotalTax = _TotalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
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
        Public Property ExchangeRateNote() As String
            Get
                ExchangeRateNote = _ExchangeRateNote
            End Get
            Set(ByVal value As String)
                _ExchangeRateNote = value
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
        Public Property InvoiceFooterCommentFontSize() As String
            Get
                InvoiceFooterCommentFontSize = _InvoiceFooterCommentFontSize
            End Get
            Set(ByVal value As String)
                _InvoiceFooterCommentFontSize = value
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
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeaderStartDate() As Nullable(Of Date)
            Get
                HeaderStartDate = _HeaderStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _HeaderStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeaderEndDate() As Nullable(Of Date)
            Get
                HeaderEndDate = _HeaderEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _HeaderEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderStartDate() As Nullable(Of Date)
            Get
                OrderStartDate = _OrderStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _OrderStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEndDate() As Nullable(Of Date)
            Get
                OrderEndDate = _OrderEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _OrderEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderMonths() As String
            Get
                OrderMonths = _OrderMonths
            End Get
            Set(ByVal value As String)
                _OrderMonths = value
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
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
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
        Public Property InvoiceTotalVerbiage() As String
            Get
                InvoiceTotalVerbiage = _InvoiceTotalVerbiage
            End Get
            Set(ByVal value As String)
                _InvoiceTotalVerbiage = value
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
        Public Property CloseDateColumn() As Short
            Get
                CloseDateColumn = _CloseDateColumn
            End Get
            Set(value As Short)
                _CloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentNumber As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GuaranteedImpressionsColumn() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDateColumn() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New(MediaInvoiceDetail As MediaInvoiceDetail, MediaInvoicePrintingSetting As MediaInvoicePrintingSetting, MediaType As String, IsDraft As Boolean)

            'objects
            Dim HasMessageAlready As Boolean = False
            Dim HeaderStartDate As Date = Nothing
            Dim HeaderEndDate As Date = Nothing
            Dim OrderMonths As String = ""

            If MediaInvoiceDetail IsNot Nothing AndAlso MediaInvoicePrintingSetting IsNot Nothing Then

                If MediaInvoicePrintingSetting.UseLocationPrintOptions Then

                    Me.PageHeaderLogoPath = MediaInvoicePrintingSetting.PageHeaderLogoPath
                    Me.PageHeaderComment = MediaInvoicePrintingSetting.PageHeaderComment
                    Me.PageHeaderLineVisible = MediaInvoicePrintingSetting.PageHeaderLineVisible

                Else

                    Me.PageHeaderLogoPath = Nothing
                    Me.PageHeaderComment = Nothing
                    Me.PageHeaderLineVisible = False

                End If

                Me.ClientCode = MediaInvoiceDetail.ClientCode
                Me.ClientName = MediaInvoiceDetail.ClientName
                Me.DivisionCode = MediaInvoiceDetail.DivisionCode
                Me.DivisionName = MediaInvoiceDetail.DivisionName
                Me.ProductCode = MediaInvoiceDetail.ProductCode
                Me.ProductName = MediaInvoiceDetail.ProductName
                Me.Address = MediaInvoiceDetail.Address
                Me.InvoiceCategory = MediaInvoiceDetail.InvoiceCategory
                Me.FullInvoiceNumber = MediaInvoiceDetail.FullInvoiceNumber
                Me.InvoiceNumber = MediaInvoiceDetail.InvoiceNumber.GetValueOrDefault(0)
                Me.InvoiceSequenceNumber = MediaInvoiceDetail.InvoiceSequenceNumber.GetValueOrDefault(0)
                Me.InvoiceType = MediaInvoiceDetail.InvoiceType
                Me.InvoiceDate = MediaInvoiceDetail.InvoiceDate
                Me.InvoiceDueDate = MediaInvoiceDetail.InvoiceDueDate.GetValueOrDefault(Nothing)
                Me.BillingComment = MediaInvoiceDetail.BillingComment
                Me.ClientPO = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.ClientPO) = False, MediaInvoiceDetail.ClientPO, Nothing)
                Me.SalesClass = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.SalesClassDescription) = False, MediaInvoiceDetail.SalesClassDescription, Nothing)
                Me.Campaign = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.CampaignName) = False, MediaInvoiceDetail.CampaignCode & " - " & MediaInvoiceDetail.CampaignName, Nothing)
                Me.CampaignComment = If(MediaInvoicePrintingSetting.ShowCampaignComment, MediaInvoiceDetail.CampaignComment, Nothing)
                Me.ColumnHeader1 = MediaInvoicePrintingSetting.ColumnHeader1
                Me.ColumnHeader2 = MediaInvoicePrintingSetting.ColumnHeader2
                Me.ColumnHeader3 = MediaInvoicePrintingSetting.ColumnHeader3
                Me.ColumnHeader4 = MediaInvoicePrintingSetting.ColumnHeader4
                Me.ColumnHeader5 = MediaInvoicePrintingSetting.ColumnHeader5
                Me.ColumnHeader6 = MediaInvoicePrintingSetting.ColumnHeader6
                Me.ColumnHeader7 = MediaInvoicePrintingSetting.ColumnHeader7

				If MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.None Then

					Me.OrderGroupBy = Nothing
					Me.OrderGroupByLabel = Nothing

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByMarket Then

					Me.OrderGroupBy = "Market: " & MediaInvoiceDetail.MarketDescription
					Me.OrderGroupByLabel = "Market Total:"

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByCampaign Then

					Me.OrderGroupBy = "Campaign: " & MediaInvoiceDetail.CampaignName
					Me.OrderGroupByLabel = "Campaign Total:"

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupBySalesClass Then

					Me.OrderGroupBy = "Sales Class: " & MediaInvoiceDetail.SalesClassDescription
					Me.OrderGroupByLabel = "Sales Class Total:"

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendor Then

					Me.OrderGroupBy = "Vendor: " & MediaInvoiceDetail.VendorName
					Me.OrderGroupByLabel = "Vendor Total:"

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByOrderMonth Then

					Me.OrderGroupBy = "Order Month/Year: "

					If MediaType = "T" OrElse MediaType = "R" Then

						If MediaInvoiceDetail.OrderMonth.HasValue AndAlso MediaInvoiceDetail.OrderYear.HasValue Then

							Me.OrderGroupByDateValue = New Date(MediaInvoiceDetail.OrderYear.Value, MediaInvoiceDetail.OrderMonth.Value, 1)

							Me.OrderGroupBy &= Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")
							MediaInvoiceDetail.OrderMonths = Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")

						End If

					ElseIf MediaType = "I" Then

						If MediaInvoiceDetail.OrderStartDate.HasValue Then

							Me.OrderGroupByDateValue = New Date(MediaInvoiceDetail.OrderStartDate.Value.Year, MediaInvoiceDetail.OrderStartDate.Value.Month, 1)

							Me.OrderGroupBy &= Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")
							MediaInvoiceDetail.OrderMonths = Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")

						End If

					Else

						If MediaInvoiceDetail.InsertDate.HasValue Then

							Me.OrderGroupByDateValue = New Date(MediaInvoiceDetail.InsertDate.Value.Year, MediaInvoiceDetail.InsertDate.Value.Month, 1)

							Me.OrderGroupBy &= Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")
							MediaInvoiceDetail.OrderMonths = Me.OrderGroupByDateValue.Value.ToString("MMM yyyy")

						End If

					End If

					Me.OrderGroupByLabel = "Order Month/Year Total:"

				ElseIf MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory Then

					If String.IsNullOrWhiteSpace(MediaInvoiceDetail.VendorInvoiceCategory) Then

						Me.OrderGroupBy = MediaInvoiceDetail.VendorName

					Else

						Me.OrderGroupBy = MediaInvoiceDetail.VendorInvoiceCategory

					End If

					Me.OrderGroupByLabel = "Total:"

				End If

                Me.Market = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.MarketDescription) = False, "Market: " & MediaInvoiceDetail.MarketDescription, Nothing)

				If MediaInvoicePrintingSetting.HeaderGroupBy <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendor AndAlso
						MediaInvoicePrintingSetting.HeaderGroupBy <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory Then

					If MediaInvoicePrintingSetting.VendorNameColumn <> 0 AndAlso MediaInvoicePrintingSetting.ShowVendorCode <> 0 Then

						If String.IsNullOrWhiteSpace(MediaInvoiceDetail.VendorCode) = False AndAlso String.IsNullOrWhiteSpace(MediaInvoiceDetail.VendorCode) = False Then

							Me.Vendor = "Vendor: " & MediaInvoiceDetail.VendorName & " - " & MediaInvoiceDetail.VendorCode

						Else

							Me.Vendor = Nothing

						End If

					ElseIf MediaInvoicePrintingSetting.VendorNameColumn = 0 AndAlso MediaInvoicePrintingSetting.ShowVendorCode <> 0 Then

						Me.Vendor = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.VendorCode) = False, "Vendor: " & MediaInvoiceDetail.VendorCode, Nothing)

					ElseIf MediaInvoicePrintingSetting.VendorNameColumn <> 0 AndAlso MediaInvoicePrintingSetting.ShowVendorCode = 0 Then

						Me.Vendor = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.VendorName) = False, "Vendor: " & MediaInvoiceDetail.VendorName, Nothing)

					Else

						Me.Vendor = Nothing

					End If

				Else

					Me.Vendor = Nothing

                End If

                If MediaInvoicePrintingSetting.OrderNumberColumn <> 0 Then

                    Me.Order = "Order: " & Format(MediaInvoiceDetail.OrderNumber, "00000#")

                Else

                    Me.Order = Nothing

                End If

                If MediaInvoicePrintingSetting.ShowOrderDescription AndAlso String.IsNullOrWhiteSpace(Me.Order) = False Then

                    Me.Order = Me.Order & " - " & MediaInvoiceDetail.OrderDescription

                End If

                Me.OrderNumber = MediaInvoiceDetail.OrderNumber
                Me.OrderLineNumber = MediaInvoiceDetail.OrderLineNumber
                Me.ClientReference = If(MediaInvoicePrintingSetting.ShowClientReference, If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.ClientReference) = False, "Reference: " & MediaInvoiceDetail.ClientReference, Nothing), Nothing)
                Me.OrderComment = If(MediaInvoicePrintingSetting.ShowOrderComment, MediaInvoiceDetail.OrderComment, Nothing)
                Me.OrderHouseComment = If(MediaInvoicePrintingSetting.ShowOrderHouseComment, MediaInvoiceDetail.OrderHouseComment, Nothing)
                Me.HeaderStartDate = MediaInvoiceDetail.HeaderStartDate
                Me.HeaderEndDate = MediaInvoiceDetail.HeaderEndDate

                'SetColumnValue(MediaInvoicePrintingSetting.OrderNumberColumn, Format(MediaInvoiceDetail.OrderNumber, "00000#"), ValueType.Text, False, MediaInvoicePrintingSetting)

                If MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

                    SetColumnValue(MediaInvoicePrintingSetting.LineNumberColumn, MediaInvoiceDetail.OrderLineNumber, ValueType.OrderLineNumber, False, MediaInvoicePrintingSetting)
                    'SetColumnValue(MediaInvoicePrintingSetting.VendorNameColumn, MediaInvoiceDetail.VendorName, ValueType.Text, False, MediaInvoicePrintingSetting)
                    'SetColumnValue(MediaInvoicePrintingSetting.ShowVendorCode, MediaInvoiceDetail.VendorCode, ValueType.Text, False, MediaInvoicePrintingSetting)

                    Me.OrderMonths = MediaInvoiceDetail.OrderMonths

                    SetColumnValue(MediaInvoicePrintingSetting.OrderMonthsColumn, MediaInvoiceDetail.OrderMonths, ValueType.Text, False, MediaInvoicePrintingSetting)

                Else

                    SetColumnValue(MediaInvoicePrintingSetting.LineNumberColumn, Nothing, ValueType.OrderLineNumber, False, MediaInvoicePrintingSetting)
                    'SetColumnValue(MediaInvoicePrintingSetting.VendorNameColumn, Nothing, ValueType.Text, False, MediaInvoicePrintingSetting)
                    'SetColumnValue(MediaInvoicePrintingSetting.ShowVendorCode, Nothing, ValueType.Text, False, MediaInvoicePrintingSetting)

                    If MediaInvoiceDetail.HeaderStartDate.HasValue Then

                        HeaderStartDate = New Date(MediaInvoiceDetail.HeaderStartDate.Value.Year, MediaInvoiceDetail.HeaderStartDate.Value.Month, 1)

                        OrderMonths = HeaderStartDate.ToString("MMM yy")

                    End If

                    If MediaInvoiceDetail.HeaderEndDate.HasValue Then

                        HeaderEndDate = New Date(MediaInvoiceDetail.HeaderEndDate.Value.Year, MediaInvoiceDetail.HeaderEndDate.Value.Month, 1)

                        If HeaderEndDate <> HeaderStartDate Then

                            OrderMonths &= "-" & HeaderEndDate.ToString("MMM yy")

                        End If

                    End If

                    Me.OrderMonths = OrderMonths

                    SetColumnValue(MediaInvoicePrintingSetting.OrderMonthsColumn, Me.OrderMonths, ValueType.Text, False, MediaInvoicePrintingSetting)

                End If

                SetColumnValue(MediaInvoicePrintingSetting.NetAmountColumn, MediaInvoiceDetail.NetAmount, ValueType.Amounts, True, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.TaxAmountColumn, MediaInvoiceDetail.TotalTax, ValueType.Amounts, True, MediaInvoicePrintingSetting)

                SetColumnValue(MediaInvoicePrintingSetting.CommissionAmountColumn, MediaInvoiceDetail.CommissionAmount, ValueType.Amounts, True, MediaInvoicePrintingSetting)

                SetColumnValue(MediaInvoicePrintingSetting.BillAmountColumn, MediaInvoiceDetail.BillAmount, ValueType.Amounts, True, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, MediaInvoiceDetail.PriorBillAmount, ValueType.Amounts, True, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, MediaInvoiceDetail.BilledToDateAmount, ValueType.Amounts, True, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.ProgramColumn, MediaInvoiceDetail.Programming, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.SpotLengthColumn, MediaInvoiceDetail.Length, ValueType.Integer, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.TagColumn, MediaInvoiceDetail.Tag, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.StartEndTimesColumn, FormatStartAndEndTimes(MediaInvoiceDetail.StartTime, MediaInvoiceDetail.EndTime, MediaInvoiceDetail.Monday.GetValueOrDefault(False), MediaInvoiceDetail.Tuesday.GetValueOrDefault(False), MediaInvoiceDetail.Wednesday.GetValueOrDefault(False), MediaInvoiceDetail.Thursday.GetValueOrDefault(False), MediaInvoiceDetail.Friday.GetValueOrDefault(False), MediaInvoiceDetail.Saturday.GetValueOrDefault(False), MediaInvoiceDetail.Sunday.GetValueOrDefault(False)), ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.NumberOfSpotsColumn, MediaInvoiceDetail.NumberOfSpots, ValueType.Integer, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.RemarksColumn, MediaInvoiceDetail.Remarks, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.HeadlineColumn, MediaInvoiceDetail.Headline, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.StartDatesColumn, MediaInvoiceDetail.StartDates, ValueType.Date, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.EndDatesColumn, MediaInvoiceDetail.EndDates, ValueType.Date, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.CreativeSizeColumn, MediaInvoiceDetail.CreativeSize, ValueType.Text, False, MediaInvoicePrintingSetting)
				SetColumnValue(MediaInvoicePrintingSetting.InsertDatesColumn, MediaInvoiceDetail.InsertDate, ValueType.Date, False, MediaInvoicePrintingSetting)
				SetColumnValue(MediaInvoicePrintingSetting.OutdoorEndDateColumn, MediaInvoiceDetail.EndDates, ValueType.Date, False, MediaInvoicePrintingSetting)
				SetColumnValue(MediaInvoicePrintingSetting.CopyAreaColumn, MediaInvoiceDetail.CopyArea, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.MaterialColumn, MediaInvoiceDetail.Material, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.AdNumberColumn, MediaInvoiceDetail.AdNumber, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.LocationColumn, MediaInvoiceDetail.Location, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.OutdoorTypeColumn, MediaInvoiceDetail.OutdoorType, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.SizeColumn, MediaInvoiceDetail.Size, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.EditorialIssueColumn, MediaInvoiceDetail.EditorialIssue, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.SectionColumn, MediaInvoiceDetail.Section, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.QuantityColumn, MediaInvoiceDetail.Quantity, ValueType.Decimal, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.AdSizeColumn, MediaInvoiceDetail.Size, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.URLColumn, MediaInvoiceDetail.URL, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.InternetTypeColumn, MediaInvoiceDetail.InternetType, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.JobComponentNumberColumn, MediaInvoiceDetail.JobComponent, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.JobDescriptionColumn, MediaInvoiceDetail.JobDescription, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.ComponentDescriptionColumn, MediaInvoiceDetail.ComponentDescription, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.OrderDetailCommentColumn, MediaInvoiceDetail.OrderDetailComment, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.OrderHouseDetailCommentColumn, MediaInvoiceDetail.OrderDetailHouseComment, ValueType.Text, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.CloseDateColumn, MediaInvoiceDetail.CloseDate, ValueType.Date, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.GuaranteedImpressionsColumn, MediaInvoiceDetail.GuaranteedImpressions, ValueType.Integer, False, MediaInvoicePrintingSetting)
                SetColumnValue(MediaInvoicePrintingSetting.StartDateColumn, MediaInvoiceDetail.StartDates, ValueType.Date, False, MediaInvoicePrintingSetting)

                SetSubTotalValue(MediaInvoicePrintingSetting.BillAmountColumn, If(MediaInvoicePrintingSetting.ShowCommissionSeparately, MediaInvoiceDetail.CommissionAmount, Nothing), SubTotalValueType.Commission, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, If(MediaInvoicePrintingSetting.ShowCommissionSeparately, MediaInvoiceDetail.PriorBillAmountCommissionAmount, Nothing), SubTotalValueType.Commission, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, If(MediaInvoicePrintingSetting.ShowCommissionSeparately, MediaInvoiceDetail.BilledToDateCommissionAmount, Nothing), SubTotalValueType.Commission, MediaInvoicePrintingSetting)

                SetSubTotalValue(MediaInvoicePrintingSetting.BillAmountColumn, If(MediaInvoicePrintingSetting.ShowRebateSeparately, MediaInvoiceDetail.RebateAmount, Nothing), SubTotalValueType.Rebate, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, If(MediaInvoicePrintingSetting.ShowRebateSeparately, MediaInvoiceDetail.PriorBillAmountRebateAmount, Nothing), SubTotalValueType.Rebate, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, If(MediaInvoicePrintingSetting.ShowRebateSeparately, MediaInvoiceDetail.BilledToDateRebateAmount, Nothing), SubTotalValueType.Rebate, MediaInvoicePrintingSetting)

                SetSubTotalValue(MediaInvoicePrintingSetting.BillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.CityTax, Nothing), SubTotalValueType.CityTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.PriorBillAmountCityTax, Nothing), SubTotalValueType.CityTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.BilledToDateCityTax, Nothing), SubTotalValueType.CityTax, MediaInvoicePrintingSetting)

                SetSubTotalValue(MediaInvoicePrintingSetting.BillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.CountyTax, Nothing), SubTotalValueType.CountyTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.PriorBillAmountCountyTax, Nothing), SubTotalValueType.CountyTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.BilledToDateCountyTax, Nothing), SubTotalValueType.CountyTax, MediaInvoicePrintingSetting)

                SetSubTotalValue(MediaInvoicePrintingSetting.BillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.StateTax, Nothing), SubTotalValueType.StateTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.PriorBillAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.PriorBillAmountStateTax, Nothing), SubTotalValueType.StateTax, MediaInvoicePrintingSetting)
                SetSubTotalValue(MediaInvoicePrintingSetting.BilledToDateAmountColumn, If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.BilledToDateStateTax, Nothing), SubTotalValueType.StateTax, MediaInvoicePrintingSetting)

                If MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.ProgramColumn = 8 Then

                        Me.ProgramHeadline = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Programming) = False, "Programming: " & MediaInvoiceDetail.Programming, Nothing)

                    Else

                        Me.ProgramHeadline = Nothing

                    End If

                Else

                    If MediaInvoicePrintingSetting.HeadlineColumn = 8 Then

                        Me.ProgramHeadline = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Headline) = False, "Headline: " & MediaInvoiceDetail.Headline, Nothing)

                    Else

                        Me.ProgramHeadline = Nothing

                    End If

                End If

                If MediaType = "M" OrElse MediaType = "N" Then

                    If MediaInvoicePrintingSetting.EditorialIssueColumn = 8 Then

                        Me.EditoralUrlLocationStartEndTimes = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.EditorialIssue) = False, "Editorial Issue: " & MediaInvoiceDetail.EditorialIssue, Nothing)

                    Else

                        Me.EditoralUrlLocationStartEndTimes = Nothing

                    End If

                ElseIf MediaType = "I" Then

                    If MediaInvoicePrintingSetting.URLColumn = 8 Then

                        Me.EditoralUrlLocationStartEndTimes = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.URL) = False, "URL: " & MediaInvoiceDetail.URL, Nothing)

                    Else

                        Me.EditoralUrlLocationStartEndTimes = Nothing

                    End If

                ElseIf MediaType = "O" Then

                    If MediaInvoicePrintingSetting.LocationColumn = 8 Then

                        Me.EditoralUrlLocationStartEndTimes = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Location) = False, "Location: " & MediaInvoiceDetail.Location, Nothing)

                    Else

                        Me.EditoralUrlLocationStartEndTimes = Nothing

                    End If

                ElseIf MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.StartEndTimesColumn = 8 Then

                        Me.EditoralUrlLocationStartEndTimes = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.StartTime) = False, "Start-End Times: " & MediaInvoiceDetail.StartTime & If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.EndTime) = False, " - " & MediaInvoiceDetail.EndTime, ""), Nothing)

                    Else

                        Me.EditoralUrlLocationStartEndTimes = Nothing

                    End If

                End If

                If MediaType = "M" OrElse MediaType = "N" Then

                    If MediaInvoicePrintingSetting.MaterialColumn = 8 Then

                        Me.MaterialCreativeSizeCopyAreaSpotLength = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Material) = False, "Material: " & MediaInvoiceDetail.Material, Nothing)

                    Else

                        Me.MaterialCreativeSizeCopyAreaSpotLength = Nothing

                    End If

                ElseIf MediaType = "I" Then

                    If MediaInvoicePrintingSetting.CreativeSizeColumn = 8 Then

                        Me.MaterialCreativeSizeCopyAreaSpotLength = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.CreativeSize) = False, "Creative Size: " & MediaInvoiceDetail.CreativeSize, Nothing)

                    Else

                        Me.MaterialCreativeSizeCopyAreaSpotLength = Nothing

                    End If

                ElseIf MediaType = "O" Then

                    If MediaInvoicePrintingSetting.CopyAreaColumn = 8 Then

                        Me.MaterialCreativeSizeCopyAreaSpotLength = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.CopyArea) = False, "Copy Area: " & MediaInvoiceDetail.CopyArea, Nothing)

                    Else

                        Me.MaterialCreativeSizeCopyAreaSpotLength = Nothing

                    End If

                ElseIf MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.SpotLengthColumn = 8 Then

                        Me.MaterialCreativeSizeCopyAreaSpotLength = If(MediaInvoiceDetail.Length.GetValueOrDefault(0) > 0, "Spot Length: " & MediaInvoiceDetail.Length.Value, Nothing)

                    Else

                        Me.MaterialCreativeSizeCopyAreaSpotLength = Nothing

                    End If

                End If

                If MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.NumberOfSpotsColumn = 8 Then

                        Me.SpotsQuantity = If(MediaInvoiceDetail.NumberOfSpots.GetValueOrDefault(0) > 0, "Number of Spots: " & MediaInvoiceDetail.NumberOfSpots.Value, Nothing)

                    Else

                        Me.SpotsQuantity = Nothing

                    End If

                ElseIf MediaType = "N" Then

                    If MediaInvoicePrintingSetting.QuantityColumn = 8 Then

                        Me.SpotsQuantity = If(MediaInvoiceDetail.Quantity.GetValueOrDefault(0) > 0, "Quantity: " & FormatNumber(MediaInvoiceDetail.Quantity.GetValueOrDefault(0), 0, GroupDigits:=TriState.True), Nothing)

                    Else

                        Me.SpotsQuantity = Nothing

                    End If

                Else

                    Me.SpotsQuantity = Nothing

                End If

                If MediaType = "I" Then

                    If MediaInvoicePrintingSetting.StartDatesColumn = 8 AndAlso MediaInvoicePrintingSetting.EndDatesColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.StartDates.HasValue, "Date(s): Start " & MediaInvoiceDetail.StartDates.Value.ToShortDateString & If(MediaInvoiceDetail.EndDates.HasValue, " -  End " & MediaInvoiceDetail.EndDates.Value.ToShortDateString, ""), Nothing)

                    ElseIf MediaInvoicePrintingSetting.StartDatesColumn = 8 AndAlso MediaInvoicePrintingSetting.EndDatesColumn <> 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.StartDates.HasValue, "Date(s): Start " & MediaInvoiceDetail.StartDates.Value.ToShortDateString, Nothing)

                    ElseIf MediaInvoicePrintingSetting.StartDatesColumn <> 8 AndAlso MediaInvoicePrintingSetting.EndDatesColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.EndDates.HasValue, "Date(s): End " & MediaInvoiceDetail.EndDates.Value.ToShortDateString, Nothing)

                    Else

                        Me.InsertDateDates = Nothing

                    End If

                ElseIf MediaType = "O" Then

                    If MediaInvoicePrintingSetting.InsertDatesColumn = 8 AndAlso MediaInvoicePrintingSetting.OutdoorEndDateColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.StartDates.HasValue, "Date(s): Start " & MediaInvoiceDetail.StartDates.Value.ToShortDateString & If(MediaInvoiceDetail.EndDates.HasValue, " -  End " & MediaInvoiceDetail.EndDates.Value.ToShortDateString, ""), Nothing)

                    ElseIf MediaInvoicePrintingSetting.InsertDatesColumn = 8 AndAlso MediaInvoicePrintingSetting.OutdoorEndDateColumn <> 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.StartDates.HasValue, "Date(s): Start " & MediaInvoiceDetail.StartDates.Value.ToShortDateString, Nothing)

                    ElseIf MediaInvoicePrintingSetting.InsertDatesColumn <> 8 AndAlso MediaInvoicePrintingSetting.OutdoorEndDateColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.EndDates.HasValue, "Date(s): End " & MediaInvoiceDetail.EndDates.Value.ToShortDateString, Nothing)

                    Else

                        Me.InsertDateDates = Nothing

                    End If

                ElseIf MediaType = "M" OrElse MediaType = "N" Then

                    If MediaInvoicePrintingSetting.InsertDatesColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.InsertDate.HasValue, "Insert Date(s): " & MediaInvoiceDetail.InsertDate.Value.ToShortDateString, Nothing)

                    Else

                        Me.InsertDateDates = Nothing

                    End If

                ElseIf MediaType = "R" OrElse MediaType = "T" Then

                    If MediaInvoicePrintingSetting.StartDateColumn = 8 Then

                        Me.InsertDateDates = If(MediaInvoiceDetail.StartDates.HasValue, "Start Date: " & MediaInvoiceDetail.StartDates.Value.ToShortDateString, Nothing)

                    Else

                        Me.InsertDateDates = Nothing

                    End If

                Else

                    Me.InsertDateDates = Nothing

                End If

                If MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.TagColumn = 8 Then

                        Me.AdNumberTag = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Tag) = False, "Tag: " & MediaInvoiceDetail.Tag, Nothing)

                    Else

                        Me.AdNumberTag = Nothing

                    End If

                Else

                    If MediaInvoicePrintingSetting.AdNumberColumn = 8 Then

                        Me.AdNumberTag = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.AdNumberDescription) = False, "Ad Number: " & MediaInvoiceDetail.AdNumberDescription, Nothing)

                    Else

                        Me.AdNumberTag = Nothing

                    End If

                End If

                If MediaType = "T" OrElse MediaType = "R" Then

                    If MediaInvoicePrintingSetting.RemarksColumn = 8 Then

                        Me.Remarks = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Remarks) = False, "Remarks: " & MediaInvoiceDetail.Remarks, Nothing)

                    Else

                        Me.Remarks = Nothing

                    End If

                ElseIf MediaType = "I" Then

                    If MediaInvoicePrintingSetting.GuaranteedImpressionsColumn = 8 Then

                        Me.Remarks = If(MediaInvoiceDetail.GuaranteedImpressions.GetValueOrDefault(0) > 0, "Guar Imps: " & FormatNumber(MediaInvoiceDetail.GuaranteedImpressions.GetValueOrDefault(0), 0, GroupDigits:=TriState.True), Nothing)

                    Else

                        Me.Remarks = Nothing

                    End If

                Else

                    Me.Remarks = Nothing

                End If

                If MediaType = "N" Then

                    If MediaInvoicePrintingSetting.SectionColumn = 8 Then

                        Me.Section = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Section) = False, "Section: " & MediaInvoiceDetail.Section, Nothing)

                    Else

                        Me.Section = Nothing

                    End If

                Else

                    Me.Section = Nothing

                End If

                If MediaType = "I" Then

                    If MediaInvoicePrintingSetting.InternetTypeColumn = 8 Then

                        Me.SubType = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.InternetType) = False, "Internet Type: " & MediaInvoiceDetail.InternetType, Nothing)

                    Else

                        Me.SubType = Nothing

                    End If

                ElseIf MediaType = "O" Then

                    If MediaInvoicePrintingSetting.OutdoorTypeColumn = 8 Then

                        Me.SubType = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.OutdoorType) = False, "Outdoor Type: " & MediaInvoiceDetail.OutdoorType, Nothing)

                    Else

                        Me.SubType = Nothing

                    End If

                Else

                    Me.SubType = Nothing

                End If

				If MediaType = "M" OrElse MediaType = "N" Then

					If MediaInvoicePrintingSetting.AdSizeColumn = 8 Then

						Me.AdSizeCreativeSizeSize = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Size) = False, "Ad Size: " & MediaInvoiceDetail.Size, Nothing)

					Else

						Me.AdSizeCreativeSizeSize = Nothing

					End If

				ElseIf MediaType = "I" Then

					If MediaInvoicePrintingSetting.CreativeSizeColumn = 8 Then

						Me.AdSizeCreativeSizeSize = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Size) = False, "Creative Size: " & MediaInvoiceDetail.Size, Nothing)

					Else

						Me.AdSizeCreativeSizeSize = Nothing

					End If

				ElseIf MediaType = "O" Then

					If MediaInvoicePrintingSetting.SizeColumn = 8 Then

                        Me.AdSizeCreativeSizeSize = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.Size) = False, "Size: " & MediaInvoiceDetail.Size, Nothing)

                    Else

                        Me.AdSizeCreativeSizeSize = Nothing

                    End If

                Else

                    Me.AdSizeCreativeSizeSize = Nothing

                End If

                If MediaInvoicePrintingSetting.JobComponentNumberColumn = 8 Then

                    Me.JobComponent = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.JobComponent) = False, "Job-Comp.: " & MediaInvoiceDetail.JobComponent, Nothing)

                Else

                    Me.JobComponent = Nothing

                End If

                If MediaInvoicePrintingSetting.JobDescriptionColumn = 8 Then

                    Me.JobDescription = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.JobDescription) = False, "Job Description: " & MediaInvoiceDetail.JobDescription, Nothing)

                Else

                    Me.JobDescription = Nothing

                End If

                If MediaInvoicePrintingSetting.ComponentDescriptionColumn = 8 Then

                    Me.ComponentDescription = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.ComponentDescription) = False, "Component Desc.: " & MediaInvoiceDetail.ComponentDescription, Nothing)

                Else

                    Me.ComponentDescription = Nothing

                End If

                If MediaInvoicePrintingSetting.OrderDetailCommentColumn = 8 Then

                    Me.OrderDetailComment = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.OrderDetailComment) = False, "Order Detail Comment: " & MediaInvoiceDetail.OrderDetailComment, Nothing)

                Else

                    Me.OrderDetailComment = Nothing

                End If

                If MediaInvoicePrintingSetting.OrderHouseDetailCommentColumn = 8 Then

                    Me.OrderDetailHouseComment = If(String.IsNullOrWhiteSpace(MediaInvoiceDetail.OrderDetailHouseComment) = False, "House Detail Comment: " & MediaInvoiceDetail.OrderDetailHouseComment, Nothing)

                Else

                    Me.OrderDetailHouseComment = Nothing

                End If

                If MediaInvoicePrintingSetting.CloseDateColumn = 8 Then

                    Me.CloseDate = If(MediaInvoiceDetail.CloseDate.HasValue, "Close Date: " & MediaInvoiceDetail.CloseDate.Value.ToShortDateString, Nothing)

                Else

                    Me.CloseDate = Nothing

                End If

                If MediaInvoicePrintingSetting.ExtraChargesColumn = 1 Then

                    If (MediaInvoiceDetail.ExtraChargesAdditional.HasValue AndAlso MediaInvoiceDetail.ExtraChargesAdditional.Value <> 0) OrElse
                            (MediaInvoiceDetail.ExtraChargesNet.HasValue AndAlso MediaInvoiceDetail.ExtraChargesNet.Value <> 0) OrElse
                            (MediaInvoiceDetail.Discount.HasValue AndAlso MediaInvoiceDetail.Discount.Value <> 0) Then

                        Me.AdditionalCharges = "Charges & Discounts (included):"

                        If MediaInvoiceDetail.ExtraChargesAdditional.HasValue AndAlso MediaInvoiceDetail.ExtraChargesAdditional.Value <> 0 Then

                            Me.AdditionalCharges &= " Additional Charge = $: " & FormatNumber(MediaInvoiceDetail.ExtraChargesAdditional.Value, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)
                            HasMessageAlready = True

                        End If

                        If MediaInvoiceDetail.ExtraChargesNet.HasValue AndAlso MediaInvoiceDetail.ExtraChargesNet.Value <> 0 Then

                            Me.AdditionalCharges &= If(HasMessageAlready, ", ", " ") & "Net Charges = $" & FormatNumber(MediaInvoiceDetail.ExtraChargesNet.Value, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)
                            HasMessageAlready = True

                        End If

                        If MediaInvoiceDetail.Discount.HasValue AndAlso MediaInvoiceDetail.Discount.Value <> 0 Then

                            Me.AdditionalCharges &= If(HasMessageAlready, ", ", " ") & "Discount = $" & FormatNumber(MediaInvoiceDetail.Discount.Value, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                        End If

                    Else

                        Me.AdditionalCharges = Nothing

                    End If

                End If

                Me.Hours = MediaInvoiceDetail.Hours
                Me.Rate = MediaInvoiceDetail.Rate
                Me.RebateAmount = If(MediaInvoicePrintingSetting.ShowRebateSeparately, MediaInvoiceDetail.RebateAmount, Nothing)
                Me.NetAmount = MediaInvoiceDetail.NetAmount
                Me.CommissionAmount = If(MediaInvoicePrintingSetting.ShowCommissionSeparately, MediaInvoiceDetail.CommissionAmount, Nothing)
                Me.NonResaleTax = MediaInvoiceDetail.NonResaleTax
                Me.CityTax = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.CityTax, Nothing)
                Me.CountyTax = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.CountyTax, Nothing)
                Me.StateTax = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoiceDetail.StateTax, Nothing)
                Me.TotalTax = MediaInvoiceDetail.TotalTax
                Me.BillAmount = MediaInvoiceDetail.BillAmount
                Me.TotalAmount = MediaInvoiceDetail.TotalAmount
                Me.InvoiceFooterComment = MediaInvoiceDetail.InvoiceFooterComment
                Me.InvoiceFooterCommentFontSize = MediaInvoiceDetail.InvoiceFooterCommentFontSize
                Me.ExchangeRateNote = MediaInvoicePrintingSetting.ExchangeRateNote
                Me.ExchangeRateNoteVisible = MediaInvoicePrintingSetting.ExchangeRateNoteVisible

                If MediaInvoicePrintingSetting.UseLocationPrintOptions Then

                    Me.PageFooterLogoPath = MediaInvoicePrintingSetting.PageFooterLogoPath
                    Me.PageFooterComment = MediaInvoicePrintingSetting.PageFooterComment

                Else

                    Me.PageFooterLogoPath = Nothing
                    Me.PageFooterComment = Nothing

                End If

                Me.OrderStartDate = MediaInvoiceDetail.OrderStartDate
                Me.OrderEndDate = MediaInvoiceDetail.OrderEndDate

                Me.AddressBlockType = MediaInvoicePrintingSetting.AddressBlockType
                Me.CustomFormatName = MediaInvoicePrintingSetting.CustomFormatName
                Me.PrintDivisionName = MediaInvoicePrintingSetting.PrintDivisionName
                Me.PrintProductDescription = MediaInvoicePrintingSetting.PrintProductDescription
                Me.PrintContactAfterAddress = MediaInvoicePrintingSetting.PrintContactAfterAddress
                Me.ContactType = MediaInvoicePrintingSetting.ContactType
                Me.ShowCodes = MediaInvoicePrintingSetting.ShowCodes
                Me.IncludeBillingComment = MediaInvoicePrintingSetting.IncludeBillingComment
                Me.ApplyExchangeRate = MediaInvoicePrintingSetting.ApplyExchangeRate
                Me.ExchangeRateAmount = MediaInvoicePrintingSetting.ExchangeRateAmount
                Me.InvoiceFooterCommentType = MediaInvoicePrintingSetting.InvoiceFooterCommentType
                Me.LocationCode = MediaInvoicePrintingSetting.LocationCode
                Me.InvoiceTitle = MediaInvoicePrintingSetting.InvoiceTitle
                Me.UseInvoiceCategoryDescription = MediaInvoicePrintingSetting.UseInvoiceCategoryDescription
                Me.GroupByMarket = MediaInvoicePrintingSetting.GroupByMarket
                Me.ShowOrderDescription = MediaInvoicePrintingSetting.ShowOrderDescription
                Me.ShowClientReference = MediaInvoicePrintingSetting.ShowClientReference
                Me.ShowClientPO = MediaInvoicePrintingSetting.ShowClientPO
                Me.ShowOrderComment = MediaInvoicePrintingSetting.ShowOrderComment
                Me.ShowOrderHouseComment = MediaInvoicePrintingSetting.ShowOrderHouseComment
                Me.PrintInvoiceDueDate = (IsDraft = False AndAlso MediaInvoicePrintingSetting.PrintInvoiceDueDate = True)
                Me.OrderNumberColumn = MediaInvoicePrintingSetting.OrderNumberColumn
                Me.VendorNameColumn = MediaInvoicePrintingSetting.VendorNameColumn
                Me.ShowVendorCode = MediaInvoicePrintingSetting.ShowVendorCode
                Me.OrderMonthsColumn = MediaInvoicePrintingSetting.OrderMonthsColumn
                Me.NetAmountColumn = MediaInvoicePrintingSetting.NetAmountColumn
                Me.CommissionAmountColumn = MediaInvoicePrintingSetting.CommissionAmountColumn
                Me.TaxAmountColumn = MediaInvoicePrintingSetting.TaxAmountColumn
                Me.BillAmountColumn = MediaInvoicePrintingSetting.BillAmountColumn
                Me.PriorBillAmountColumn = MediaInvoicePrintingSetting.PriorBillAmountColumn
                Me.BilledToDateAmountColumn = MediaInvoicePrintingSetting.BilledToDateAmountColumn
                Me.ShowLineDetail = MediaInvoicePrintingSetting.ShowLineDetail
                Me.ProgramColumn = MediaInvoicePrintingSetting.ProgramColumn
                Me.SpotLengthColumn = MediaInvoicePrintingSetting.SpotLengthColumn
                Me.TagColumn = MediaInvoicePrintingSetting.TagColumn
                Me.StartEndTimesColumn = MediaInvoicePrintingSetting.StartEndTimesColumn
                Me.NumberOfSpotsColumn = MediaInvoicePrintingSetting.NumberOfSpotsColumn
                Me.RemarksColumn = MediaInvoicePrintingSetting.RemarksColumn
                Me.HeadlineColumn = MediaInvoicePrintingSetting.HeadlineColumn
                Me.StartDatesColumn = MediaInvoicePrintingSetting.StartDatesColumn
                Me.EndDatesColumn = MediaInvoicePrintingSetting.EndDatesColumn
                Me.CreativeSizeColumn = MediaInvoicePrintingSetting.CreativeSizeColumn
				Me.InsertDatesColumn = MediaInvoicePrintingSetting.InsertDatesColumn
				Me.OutdoorEndDateColumn = MediaInvoicePrintingSetting.OutdoorEndDateColumn
				Me.CopyAreaColumn = MediaInvoicePrintingSetting.CopyAreaColumn
                Me.MaterialColumn = MediaInvoicePrintingSetting.MaterialColumn
                Me.AdNumberColumn = MediaInvoicePrintingSetting.AdNumberColumn
                Me.LocationColumn = MediaInvoicePrintingSetting.LocationColumn
                Me.OutdoorTypeColumn = MediaInvoicePrintingSetting.OutdoorTypeColumn
                Me.SizeColumn = MediaInvoicePrintingSetting.SizeColumn
                Me.EditorialIssueColumn = MediaInvoicePrintingSetting.EditorialIssueColumn
                Me.SectionColumn = MediaInvoicePrintingSetting.SectionColumn
                Me.QuantityColumn = MediaInvoicePrintingSetting.QuantityColumn
                Me.AdSizeColumn = MediaInvoicePrintingSetting.AdSizeColumn
                Me.URLColumn = MediaInvoicePrintingSetting.URLColumn
                Me.InternetTypeColumn = MediaInvoicePrintingSetting.InternetTypeColumn
                Me.JobComponentNumberColumn = MediaInvoicePrintingSetting.JobComponentNumberColumn
                Me.JobDescriptionColumn = MediaInvoicePrintingSetting.JobDescriptionColumn
                Me.ComponentDescriptionColumn = MediaInvoicePrintingSetting.ComponentDescriptionColumn
                Me.OrderDetailCommentColumn = MediaInvoicePrintingSetting.OrderDetailCommentColumn
                Me.OrderHouseDetailCommentColumn = MediaInvoicePrintingSetting.OrderHouseDetailCommentColumn
                Me.ExtraChargesColumn = MediaInvoicePrintingSetting.ExtraChargesColumn
                Me.ShowCommissionSeparately = MediaInvoicePrintingSetting.ShowCommissionSeparately
                Me.ShowRebateSeparately = MediaInvoicePrintingSetting.ShowRebateSeparately
                Me.ShowTaxSeparately = MediaInvoicePrintingSetting.ShowTaxSeparately
                Me.ShowBillingHistory = MediaInvoicePrintingSetting.ShowBillingHistory
                Me.InvoiceTotalVerbiage = MediaInvoicePrintingSetting.InvoiceTotalVerbiage
                Me.ShowCampaign = MediaInvoicePrintingSetting.ShowCampaign
                Me.ShowOrderSubtotals = MediaInvoicePrintingSetting.ShowOrderSubtotals
                Me.ShowSalesClass = MediaInvoicePrintingSetting.ShowSalesClass
                Me.ClientPOLocation = MediaInvoicePrintingSetting.ClientPOLocation
                Me.SalesClassLocation = MediaInvoicePrintingSetting.SalesClassLocation
                Me.CampaignLocation = MediaInvoicePrintingSetting.CampaignLocation
                Me.HeaderGroupBy = MediaInvoicePrintingSetting.HeaderGroupBy
                Me.SortLinesBy = MediaInvoicePrintingSetting.SortLinesBy
                Me.LineNumberColumn = MediaInvoicePrintingSetting.LineNumberColumn
                Me.CloseDateColumn = MediaInvoicePrintingSetting.CloseDateColumn

                Me.ColumnAlignment1 = MediaInvoicePrintingSetting.ColumnAlignment1
                Me.ColumnAlignment2 = MediaInvoicePrintingSetting.ColumnAlignment2
                Me.ColumnAlignment3 = MediaInvoicePrintingSetting.ColumnAlignment3
                Me.ColumnAlignment4 = MediaInvoicePrintingSetting.ColumnAlignment4
                Me.ColumnAlignment5 = MediaInvoicePrintingSetting.ColumnAlignment5
                Me.ColumnAlignment6 = MediaInvoicePrintingSetting.ColumnAlignment6
                Me.ColumnAlignment7 = MediaInvoicePrintingSetting.ColumnAlignment7

                Me.TotalColumnVisible3 = MediaInvoicePrintingSetting.TotalColumnVisible3
                Me.TotalColumnVisible4 = MediaInvoicePrintingSetting.TotalColumnVisible4
                Me.TotalColumnVisible5 = MediaInvoicePrintingSetting.TotalColumnVisible5
                Me.TotalColumnVisible6 = MediaInvoicePrintingSetting.TotalColumnVisible6
                Me.TotalColumnVisible7 = MediaInvoicePrintingSetting.TotalColumnVisible7

                Me.GrandTotalColumnVisible3 = MediaInvoicePrintingSetting.GrandTotalColumnVisible3
                Me.GrandTotalColumnVisible4 = MediaInvoicePrintingSetting.GrandTotalColumnVisible4
                Me.GrandTotalColumnVisible5 = MediaInvoicePrintingSetting.GrandTotalColumnVisible5
                Me.GrandTotalColumnVisible6 = MediaInvoicePrintingSetting.GrandTotalColumnVisible6
                Me.GrandTotalColumnVisible7 = MediaInvoicePrintingSetting.GrandTotalColumnVisible7

                Me.CommissionLabel = If(MediaInvoicePrintingSetting.ShowCommissionSeparately, MediaInvoicePrintingSetting.CommissionLabel, Nothing)
                Me.RebateLabel = If(MediaInvoicePrintingSetting.ShowRebateSeparately, MediaInvoicePrintingSetting.RebateLabel, Nothing)
                Me.CityTaxLabel = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoicePrintingSetting.CityTaxLabel, Nothing)
                Me.CountyTaxLabel = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoicePrintingSetting.CountyTaxLabel, Nothing)
                Me.StateTaxLabel = If(MediaInvoicePrintingSetting.ShowTaxSeparately, MediaInvoicePrintingSetting.StateTaxLabel, Nothing)

                Me.JobNumber = MediaInvoiceDetail.JobNumber
                Me.ComponentNumber = MediaInvoiceDetail.ComponentNumber

            End If

            _MediaInvoiceDetail = MediaInvoiceDetail
            _MediaInvoicePrintingSetting = MediaInvoicePrintingSetting

        End Sub
        Private Function FormatStartAndEndTimes(StartTime As String, EndTime As String, Monday As Boolean, Tuesday As Boolean, Wednesday As Boolean, Thursday As Boolean, Friday As Boolean, Saturday As Boolean, Sunday As Boolean) As String

            'objects
            Dim StartAndEndTimes As String = Nothing

            If String.IsNullOrWhiteSpace(StartTime) = False Then

                If Monday Then

                    StartAndEndTimes &= "M"

                End If

                If Tuesday Then

                    StartAndEndTimes &= "Tu"

                End If

                If Wednesday Then

                    StartAndEndTimes &= "W"

                End If

                If Thursday Then

                    StartAndEndTimes &= "Th"

                End If

                If Friday Then

                    StartAndEndTimes &= "F"

                End If

                If Saturday Then

                    StartAndEndTimes &= "Sa"

                End If

                If Sunday Then

                    StartAndEndTimes &= "Su"

                End If

                StartAndEndTimes &= " " & StartTime

                If String.IsNullOrWhiteSpace(EndTime) = False Then

                    StartAndEndTimes &= " - " & EndTime

                End If

                StartAndEndTimes = StartAndEndTimes.Trim

            End If

            FormatStartAndEndTimes = StartAndEndTimes

        End Function
        Private Sub SetSubTotalValue(ByVal ColumnNumber As Integer, ByVal Value As Nullable(Of Decimal), ByVal SubTotalValueType As SubTotalValueType, ByVal MediaInvoicePrintingSetting As MediaInvoicePrintingSetting)

            Select Case ColumnNumber

                Case 3

                    If SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Commission Then

                        Me.CommissionColumnValue3 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowCommissionSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Rebate Then

                        Me.RebateColumnValue3 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowRebateSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CityTax Then

                        Me.CityTaxColumnValue3 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CountyTax Then

                        Me.CountyTaxColumnValue3 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.StateTax Then

                        Me.StateTaxColumnValue3 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    End If

                    If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible3 = True Then

                        Me.GrandTotalColumnValue3 += Value.GetValueOrDefault(0)

                    End If

                Case 4

                    If SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Commission Then

                        Me.CommissionColumnValue4 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowCommissionSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Rebate Then

                        Me.RebateColumnValue4 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowRebateSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CityTax Then

                        Me.CityTaxColumnValue4 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CountyTax Then

                        Me.CountyTaxColumnValue4 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.StateTax Then

                        Me.StateTaxColumnValue4 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    End If

                    If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible4 = True Then

                        Me.GrandTotalColumnValue4 += Value.GetValueOrDefault(0)

                    End If

                Case 5

                    If SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Commission Then

                        Me.CommissionColumnValue5 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowCommissionSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Rebate Then

                        Me.RebateColumnValue5 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowRebateSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CityTax Then

                        Me.CityTaxColumnValue5 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CountyTax Then

                        Me.CountyTaxColumnValue5 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.StateTax Then

                        Me.StateTaxColumnValue5 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    End If

                    If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible5 = True Then

                        Me.GrandTotalColumnValue5 += Value.GetValueOrDefault(0)

                    End If

                Case 6

                    If SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Commission Then

                        Me.CommissionColumnValue6 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowCommissionSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Rebate Then

                        Me.RebateColumnValue6 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowRebateSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CityTax Then

                        Me.CityTaxColumnValue6 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CountyTax Then

                        Me.CountyTaxColumnValue6 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.StateTax Then

                        Me.StateTaxColumnValue6 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    End If

                    If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible6 = True Then

                        Me.GrandTotalColumnValue6 += Value.GetValueOrDefault(0)

                    End If

                Case 7

                    If SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Commission Then

                        Me.CommissionColumnValue7 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowCommissionSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.Rebate Then

                        Me.RebateColumnValue7 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowRebateSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CityTax Then

                        Me.CityTaxColumnValue7 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.CountyTax Then

                        Me.CountyTaxColumnValue7 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    ElseIf SubTotalValueType = MediaInvoiceDetailFormatted.SubTotalValueType.StateTax Then

                        Me.StateTaxColumnValue7 = If(Value = 0 OrElse MediaInvoicePrintingSetting.ShowTaxSeparately = False, Nothing, Value)

                    End If

                    If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible7 = True Then

                        Me.GrandTotalColumnValue7 += Value.GetValueOrDefault(0)

                    End If

            End Select

        End Sub
        Private Sub SetColumnValue(ByVal ColumnNumber As Integer, ByVal Value As Object, ByVal ValueType As ValueType, ByVal AddToInvoiceTotal As Boolean, ByVal MediaInvoicePrintingSetting As MediaInvoicePrintingSetting)

            'objects
            Dim AddToTotalColumn As Boolean = False

            If ValueType <> MediaInvoiceDetailFormatted.ValueType.Date AndAlso ValueType <> MediaInvoiceDetailFormatted.ValueType.Text AndAlso
                ValueType <> MediaInvoiceDetailFormatted.ValueType.OrderLineNumber Then

                AddToTotalColumn = True

            End If

            Select Case ColumnNumber

                Case 1

                    Me.ColumnValue1 = FormatValue(Value, ValueType)

                Case 2

                    Me.ColumnValue2 = FormatValue(Value, ValueType)

                Case 3

                    Me.ColumnValue3 = FormatValue(Value, ValueType)

                    If AddToTotalColumn Then

                        Me.GroupTotalColumnValue3 = CDec(Value)

                        If AddToInvoiceTotal Then

                            Me.InvoiceTotalColumnValue3 = CDec(Value)

                        End If

                        If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible3 = True AndAlso
                            ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                            Me.GrandTotalColumnValue3 = CDec(Value)

                        End If

                    End If

                Case 4

                    Me.ColumnValue4 = FormatValue(Value, ValueType)

                    If AddToTotalColumn Then

                        Me.GroupTotalColumnValue4 = CDec(Value)

                        If AddToInvoiceTotal Then

                            Me.InvoiceTotalColumnValue4 = CDec(Value)

                        End If

                        If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible4 = True AndAlso
                            ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                            Me.GrandTotalColumnValue4 = CDec(Value)

                        End If

                    End If

                Case 5

                    Me.ColumnValue5 = FormatValue(Value, ValueType)

                    If AddToTotalColumn Then

                        If ValueType = MediaInvoiceDetailFormatted.ValueType.Integer Then

                            Me.GroupTotalColumnValue5 = CInt(Value)

                        Else

                            Me.GroupTotalColumnValue5 = CDec(Value)

                        End If

                        If AddToInvoiceTotal Then

                            Me.InvoiceTotalColumnValue5 = CDec(Value)

                        End If

                        If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible5 = True AndAlso
                            ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                            Me.GrandTotalColumnValue5 = CDec(Value)

                        End If

                    End If

                Case 6

                    Me.ColumnValue6 = FormatValue(Value, ValueType)

                    If AddToTotalColumn Then

                        Me.GroupTotalColumnValue6 = CDec(Value)

                        If AddToInvoiceTotal Then

                            Me.InvoiceTotalColumnValue6 = CDec(Value)

                        End If

                        If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible6 = True AndAlso
                            ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                            Me.GrandTotalColumnValue6 = CDec(Value)

                        End If

                    End If

                Case 7

                    Me.ColumnValue7 = FormatValue(Value, ValueType)

                    If AddToTotalColumn Then

                        Me.GroupTotalColumnValue7 = CDec(Value)

                        If AddToInvoiceTotal Then

                            Me.InvoiceTotalColumnValue7 = CDec(Value)

                        End If

                        If MediaInvoicePrintingSetting IsNot Nothing AndAlso MediaInvoicePrintingSetting.GrandTotalColumnVisible7 = True AndAlso
                            ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                            Me.GrandTotalColumnValue7 = CDec(Value)

                        End If

                    End If

            End Select

        End Sub
        Private Function FormatValue(ByVal Value As Object, ValueType As ValueType) As String

            'objects
            Dim FormattedValue As String = ""

            Try

                If ValueType = MediaInvoiceDetailFormatted.ValueType.Text Then

                    FormattedValue = Value

                ElseIf ValueType = MediaInvoiceDetailFormatted.ValueType.Date Then

                    If Value IsNot Nothing AndAlso Value <> Nothing AndAlso IsDate(Value) Then

                        FormattedValue = FormatDateTime(Value, DateFormat.ShortDate)

                    End If

                ElseIf ValueType = MediaInvoiceDetailFormatted.ValueType.Integer Then

                    If IsNumeric(Value) Then

                        FormattedValue = FormatNumber(Value, 0, TriState.UseDefault, TriState.UseDefault, TriState.True)

                    End If

                ElseIf ValueType = MediaInvoiceDetailFormatted.ValueType.Decimal OrElse ValueType = MediaInvoiceDetailFormatted.ValueType.Amounts Then

                    If IsNumeric(Value) Then

                        FormattedValue = FormatNumber(Value, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                    End If

                    'ElseIf ValueType = MediaInvoiceDetailsFormatted.ValueType.Currency Then

                    '    If Value IsNot Nothing AndAlso Value <> Nothing AndAlso IsNumeric(Value) Then

                    '        FormattedValue = FormatCurrency(Value, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                    '    End If

                ElseIf ValueType = MediaInvoiceDetailFormatted.ValueType.OrderLineNumber Then

                    If IsNumeric(Value) Then

                        FormattedValue = Format(Value, "000#")

                    End If

                End If

            Catch ex As Exception

            End Try

            FormatValue = FormattedValue

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.FullInvoiceNumber

        End Function

#End Region

    End Class

End Namespace
