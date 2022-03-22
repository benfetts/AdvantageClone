Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            SalesClassCode
            SalesClassDescription
            MarketCode
            MarketDescription
            CampaignID
            CampaignCode
            CampaignName
            CampaignComment
            OrderNumber
            OrderLineNumber
            MediaType
            OrderDescription
            InvoiceNumber
            InvoiceSequenceNumber
            InvoiceType
            InvoiceDate
            ClientPO
            ClientReference
            InvoiceCategoryCode
            InvoiceCategoryDescription
            OrderComment
            OrderHouseComment
            InvoiceDueDate
            VendorCode
            VendorName
            OrderMonths
            HeaderStartDate
            HeaderEndDate
            OrderStartDate
            OrderEndDate
            Headline
            InsertDate
            Material
            EditorialIssue
            Section
            Quantity
            Size
            StartDates
            EndDates
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            Sunday
            CreativeSize
            URL
            InternetType
            CopyArea
            Location
            OutdoorType
            Programming
            Length
            Tag
            StartTime
            EndTime
            NumberOfSpots
            Remarks
            JobComponent
            JobNumber
            ComponentNumber
            JobDescription
            ComponentDescription
            OrderDetailComment
            OrderDetailHouseComment
            ExtraChargesAdditional
            ExtraChargesNet
            Discount
            AdNumber
            AdNumberDescription
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
            TotalAmount
            Address
            InvoiceCategory
            InvoiceFooterComment
            InvoiceFooterCommentFontSize
            FullInvoiceNumber
            BillingComment
            BillAmount
            BilledToDateRebateAmount
            BilledToDateCommissionAmount
            BilledToDateStateTax
            BilledToDateCountyTax
            BilledToDateCityTax
            BilledToDateTotalTax
            BilledToDateAmount
            PriorBillAmountRebateAmount
            PriorBillAmountCommissionAmount
            PriorBillAmountStateTax
            PriorBillAmountCountyTax
            PriorBillAmountCityTax
            PriorBillAmountTotalTax
            PriorBillAmount
			CloseDate
			VendorInvoiceCategoryID
            VendorInvoiceCategory
            VATNumber
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _CampaignComment As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _MediaType As String = Nothing
        Private _OrderDescription As String = Nothing
        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSequenceNumber As Nullable(Of Short) = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _ClientPO As String = Nothing
        Private _ClientReference As String = Nothing
        Private _InvoiceCategoryCode As String = Nothing
        Private _InvoiceCategoryDescription As String = Nothing
        Private _OrderComment As String = Nothing
        Private _OrderHouseComment As String = Nothing
        Private _InvoiceDueDate As Nullable(Of Date) = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _OrderMonths As String = Nothing
        Private _HeaderStartDate As Nullable(Of Date) = Nothing
        Private _HeaderEndDate As Nullable(Of Date) = Nothing
        Private _OrderStartDate As Nullable(Of Date) = Nothing
        Private _OrderEndDate As Nullable(Of Date) = Nothing
        Private _OrderMonth As Nullable(Of Short) = Nothing
        Private _OrderYear As Nullable(Of Short) = Nothing
        Private _Headline As String = Nothing
        Private _InsertDate As Nullable(Of Date) = Nothing
        Private _Material As String = Nothing
        Private _EditorialIssue As String = Nothing
        Private _Section As String = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Size As String = Nothing
        Private _StartDates As Nullable(Of Date) = Nothing
        Private _EndDates As Nullable(Of Date) = Nothing
        Private _Monday As Nullable(Of Boolean) = Nothing
        Private _Tuesday As Nullable(Of Boolean) = Nothing
        Private _Wednesday As Nullable(Of Boolean) = Nothing
        Private _Thursday As Nullable(Of Boolean) = Nothing
        Private _Friday As Nullable(Of Boolean) = Nothing
        Private _Saturday As Nullable(Of Boolean) = Nothing
        Private _Sunday As Nullable(Of Boolean) = Nothing
        Private _CreativeSize As String = Nothing
        Private _URL As String = Nothing
        Private _InternetType As String = Nothing
        Private _CopyArea As String = Nothing
        Private _Location As String = Nothing
        Private _OutdoorType As String = Nothing
        Private _Programming As String = Nothing
        Private _Length As Nullable(Of Short) = Nothing
        Private _Tag As String = Nothing
        Private _StartTime As String = Nothing
        Private _EndTime As String = Nothing
        Private _NumberOfSpots As Nullable(Of Integer) = Nothing
        Private _Remarks As String = Nothing
        Private _JobComponent As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _OrderDetailComment As String = Nothing
        Private _OrderDetailHouseComment As String = Nothing
        Private _ExtraChargesAdditional As Nullable(Of Decimal) = Nothing
        Private _ExtraChargesNet As Nullable(Of Decimal) = Nothing
        Private _Discount As Nullable(Of Decimal) = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
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
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _Address As String = Nothing
        Private _InvoiceCategory As String = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _InvoiceFooterCommentFontSize As String = Nothing
        Private _FullInvoiceNumber As String = Nothing
        Private _BillingComment As String = Nothing
        Private _BillAmount As Nullable(Of Decimal) = Nothing
        Private _BilledToDateRebateAmount As Nullable(Of Decimal) = Nothing
        Private _BilledToDateCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _BilledToDateStateTax As Nullable(Of Decimal) = Nothing
        Private _BilledToDateCountyTax As Nullable(Of Decimal) = Nothing
        Private _BilledToDateCityTax As Nullable(Of Decimal) = Nothing
        Private _BilledToDateTotalTax As Nullable(Of Decimal) = Nothing
        Private _BilledToDateAmount As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountRebateAmount As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountStateTax As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountCountyTax As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountCityTax As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmountTotalTax As Nullable(Of Decimal) = Nothing
        Private _PriorBillAmount As Nullable(Of Decimal) = Nothing
		Private _CloseDate As Nullable(Of Date) = Nothing
		Private _VendorInvoiceCategoryID As Nullable(Of Integer) = Nothing
		Private _VendorInvoiceCategory As String = Nothing

#End Region

#Region " Properties "

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
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(ByVal value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(ByVal value As String)
                _MarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
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
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(ByVal value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(ByVal value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequenceNumber() As Nullable(Of Short)
            Get
                InvoiceSequenceNumber = _InvoiceSequenceNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
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
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
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
        Public Property InvoiceCategoryCode() As String
            Get
                InvoiceCategoryCode = _InvoiceCategoryCode
            End Get
            Set(ByVal value As String)
                _InvoiceCategoryCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceCategoryDescription() As String
            Get
                InvoiceCategoryDescription = _InvoiceCategoryDescription
            End Get
            Set(ByVal value As String)
                _InvoiceCategoryDescription = value
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
        Public Property InvoiceDueDate() As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
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
        Public Property OrderMonth() As Nullable(Of Short)
            Get
                OrderMonth = _OrderMonth
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OrderMonth = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderYear() As Nullable(Of Short)
            Get
                OrderYear = _OrderYear
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OrderYear = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(ByVal value As String)
                _Headline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsertDate() As Nullable(Of Date)
            Get
                InsertDate = _InsertDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InsertDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(ByVal value As String)
                _Material = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditorialIssue() As String
            Get
                EditorialIssue = _EditorialIssue
            End Get
            Set(ByVal value As String)
                _EditorialIssue = value
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
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Size() As String
            Get
                Size = _Size
            End Get
            Set(ByVal value As String)
                _Size = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDates() As Nullable(Of Date)
            Get
                StartDates = _StartDates
            End Get
            Set(ByVal value As Nullable(Of Date))
                _StartDates = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDates() As Nullable(Of Date)
            Get
                EndDates = _EndDates
            End Get
            Set(ByVal value As Nullable(Of Date))
                _EndDates = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Monday() As Nullable(Of Boolean)
            Get
                Monday = _Monday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Monday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Tuesday() As Nullable(Of Boolean)
            Get
                Tuesday = _Tuesday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Tuesday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Wednesday() As Nullable(Of Boolean)
            Get
                Wednesday = _Wednesday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Wednesday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Thursday() As Nullable(Of Boolean)
            Get
                Thursday = _Thursday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Thursday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Friday() As Nullable(Of Boolean)
            Get
                Friday = _Friday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Friday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Saturday() As Nullable(Of Boolean)
            Get
                Saturday = _Saturday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Saturday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Sunday() As Nullable(Of Boolean)
            Get
                Sunday = _Sunday
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Sunday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreativeSize() As String
            Get
                CreativeSize = _CreativeSize
            End Get
            Set(ByVal value As String)
                _CreativeSize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property URL() As String
            Get
                URL = _URL
            End Get
            Set(ByVal value As String)
                _URL = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetType() As String
            Get
                InternetType = _InternetType
            End Get
            Set(ByVal value As String)
                _InternetType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CopyArea() As String
            Get
                CopyArea = _CopyArea
            End Get
            Set(ByVal value As String)
                _CopyArea = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Location() As String
            Get
                Location = _Location
            End Get
            Set(ByVal value As String)
                _Location = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorType() As String
            Get
                OutdoorType = _OutdoorType
            End Get
            Set(ByVal value As String)
                _OutdoorType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Programming() As String
            Get
                Programming = _Programming
            End Get
            Set(ByVal value As String)
                _Programming = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Length() As Nullable(Of Short)
            Get
                Length = _Length
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Length = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Tag() As String
            Get
                Tag = _Tag
            End Get
            Set(ByVal value As String)
                _Tag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartTime() As String
            Get
                StartTime = _StartTime
            End Get
            Set(ByVal value As String)
                _StartTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndTime() As String
            Get
                EndTime = _EndTime
            End Get
            Set(ByVal value As String)
                _EndTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GuaranteedImpressions() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfSpots() As Nullable(Of Integer)
            Get
                NumberOfSpots = _NumberOfSpots
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _NumberOfSpots = value
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
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ComponentNumber = value
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
        Public Property ExtraChargesAdditional() As Nullable(Of Decimal)
            Get
                ExtraChargesAdditional = _ExtraChargesAdditional
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtraChargesAdditional = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtraChargesNet() As Nullable(Of Decimal)
            Get
                ExtraChargesNet = _ExtraChargesNet
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtraChargesNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Discount() As Nullable(Of Decimal)
            Get
                Discount = _Discount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Discount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(ByVal value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set(ByVal value As String)
                _AdNumberDescription = value
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
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
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
        Public Property FullInvoiceNumber() As String
            Get
                FullInvoiceNumber = _FullInvoiceNumber
            End Get
            Set(ByVal value As String)
                _FullInvoiceNumber = value
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
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateRebateAmount() As Nullable(Of Decimal)
            Get
                BilledToDateRebateAmount = _BilledToDateRebateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateRebateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateCommissionAmount() As Nullable(Of Decimal)
            Get
                BilledToDateCommissionAmount = _BilledToDateCommissionAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateCommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateStateTax() As Nullable(Of Decimal)
            Get
                BilledToDateStateTax = _BilledToDateStateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateStateTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateCountyTax() As Nullable(Of Decimal)
            Get
                BilledToDateCountyTax = _BilledToDateCountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateCountyTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateCityTax() As Nullable(Of Decimal)
            Get
                BilledToDateCityTax = _BilledToDateCityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateCityTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateTotalTax() As Nullable(Of Decimal)
            Get
                BilledToDateTotalTax = _BilledToDateTotalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateTotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateAmount() As Nullable(Of Decimal)
            Get
                BilledToDateAmount = _BilledToDateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountRebateAmount() As Nullable(Of Decimal)
            Get
                PriorBillAmountRebateAmount = _PriorBillAmountRebateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountRebateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountCommissionAmount() As Nullable(Of Decimal)
            Get
                PriorBillAmountCommissionAmount = _PriorBillAmountCommissionAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountCommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountStateTax() As Nullable(Of Decimal)
            Get
                PriorBillAmountStateTax = _PriorBillAmountStateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountStateTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountCountyTax() As Nullable(Of Decimal)
            Get
                PriorBillAmountCountyTax = _PriorBillAmountCountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountCountyTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountCityTax() As Nullable(Of Decimal)
            Get
                PriorBillAmountCityTax = _PriorBillAmountCityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountCityTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmountTotalTax() As Nullable(Of Decimal)
            Get
                PriorBillAmountTotalTax = _PriorBillAmountTotalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmountTotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorBillAmount() As Nullable(Of Decimal)
            Get
                PriorBillAmount = _PriorBillAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorBillAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property VendorInvoiceCategoryID() As Nullable(Of Integer)
			Get
				VendorInvoiceCategoryID = _VendorInvoiceCategoryID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_VendorInvoiceCategoryID = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property VendorInvoiceCategory() As String
			Get
				VendorInvoiceCategory = _VendorInvoiceCategory
			End Get
			Set(ByVal value As String)
				_VendorInvoiceCategory = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VATNumber() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
