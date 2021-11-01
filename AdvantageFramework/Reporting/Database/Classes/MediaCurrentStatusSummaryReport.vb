Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class MediaCurrentStatusSummaryReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            OrderType
            OrderNumber
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            OrderDescription
            OrderComment
            VendorCode
            VendorName
            VendorRepCode
            VendorRepName
            VendorRepCode2
            VendorRepName2
            VendorPaymentMethod
            CampaignCode
            CampaignID
            CampaignName
            MediaType

            AutoCreateUnitType

            PostBillFlag
            NetGrossFlag
            MarketCode
            MarketDescription
            OrderDate
            OrderFlightFrom
            OrderFlightTo
            OrderProcessControl
            Buyer
            ClientPO
            LinkID
            OrderAccepted
            LineNumber
            OrderDateType
            OrderPeriod
            OrderMonth
            OrderYear
            InsertionDate
            OrderEndDate
            DateToBill
            CloseDate
            MaterialCloseDate
            ExtendedMaterialCloseDate
            ExtendedSpaceCloseDate
            LineDescription
            AdSize
            EditionIssue
            Section
            Material
            Remarks
            URL
            CopyArea
            MaterialNotes
            PositionInfo
            MiscellaneousInfo
            RateInfo
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            CostType
            RateType
            PrintQuantity
            Placement1
            Placement2
            ProjectedImpressions
            ActualImpressions
            GuaranteedImpressions
            LineLinkID
            OrderEntryType
            ExtendedNetAmount
            NetChargeAmount
            DiscountAmount
            AdditionalChargeAmount
            CommissionAmount
            RebateAmount
            VendorTaxAmount
            ResaleTaxAmount
            LineTotalAmount
            NetTotalAmount
            VendorNetAmount
            BillAmount
            ReconcileNoBillBillAmount
            ReconcileNoBillNetAmount
            SpotsQuantity
            LineCancelled
            BilledExtendedNetAmount
            BilledDiscountAmount
            BilledNetChargeAmount
            BilledVendorTaxAmount
            BilledNetAmount
            BilledAdditionalChargeAmount
            BilledCommissionAmount
            BilledRebateAmount
            BilledResaleTaxAmount
            BilledBillAmount
            BilledSpotsQuantity
            BillCoopCode
            BillCoopDescription
            ARLastCheckNumber
            ARLastCheckDate
            ARLastDepositDate
            ARPaymentFlag
            ARPaymentAmount
            APNetAmount
            APNetChargeAmount
            APDiscountAmount
            APCommissionAmount
            APRebateAmount
            APVendorTaxAmount
            APResaleTaxAmount
            APBillAmount
            APLineTotal
            APSpotsQuantity
            APLastCheckNumber
            APLastCheckDate
            APPaymentFlag
            APPaymentAmount
            MediaTypeDescription
            FiscalPeriodCode
            Circulation
            AcctExecCode
            AcctExecName
            CreateDate
            CreateUser
            JobType
            JobTypeDescription
            HouseComments
            InternetTypeCode
            InternetTypeDescription
            OutofHomeTypeCode
            OutofHomeTypeDescription
            AdNumber
            AdNumberDescription
            Rate
            Location
            GRP
            GrossImpressions
            PrimaryDemo
            Bookend
            AddedValue
            'OrderMonthNbr
            'OrderYearNbr
            Headline
            RatingSource

            Week1Amount
            Week2Amount
            Week3Amount
            Week4Amount
            Week5Amount
            Week6Amount
            Week7Amount

            Week1Impressions
            Week2Impressions
            Week3Impressions
            Week4Impressions
            Week15Impressions
            Week16mpressions
            Week17mpressions
            OrderResaleTaxAmount
            OrderVendorTaxAmount
            LineMarketCode
            LineMarketDescription
            BroadcastWorksheetID
            BroadcastWorksheetName

        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _UserCode As String = Nothing
        Private _OrderType As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderComment As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorRepCode As String = Nothing
        Private _VendorRepName As String = Nothing
        Private _VendorRepCode2 As String = Nothing
        Private _VendorRepName2 As String = Nothing
        Private _VendorPaymentMethod As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignID As Nullable(Of Short) = Nothing
        Private _CampaignName As String = Nothing
        Private _MediaType As String = Nothing

        Private _AutoCreateUnitType As String = Nothing

        Private _PostBillFlag As Nullable(Of Byte) = Nothing
        Private _NetGrossFlag As Nullable(Of Byte) = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _OrderDate As Nullable(Of Date) = Nothing
        Private _OrderFlightFrom As Nullable(Of Date) = Nothing
        Private _OrderFlightTo As Nullable(Of Date) = Nothing
        Private _OrderProcessControl As Nullable(Of Byte) = Nothing
        Private _Buyer As String = Nothing
        Private _ClientPO As String = Nothing
        Private _LinkID As Nullable(Of Integer) = Nothing
        Private _OrderAccepted As Nullable(Of Byte) = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _OrderDateType As String = Nothing
        Private _OrderPeriod As Nullable(Of Integer) = Nothing
        Private _OrderMonth As String = Nothing
        Private _OrderYear As Nullable(Of Short) = Nothing
        Private _InsertionDate As Nullable(Of Date) = Nothing
        Private _OrderEndDate As Nullable(Of Date) = Nothing
        Private _DateToBill As Nullable(Of Date) = Nothing
        Private _CloseDate As Nullable(Of Date) = Nothing
        Private _MaterialCloseDate As Nullable(Of Date) = Nothing
        Private _ExtendedMaterialCloseDate As Nullable(Of Date) = Nothing
        Private _ExtendedSpaceCloseDate As Nullable(Of Date) = Nothing
        Private _LineDescription As String = Nothing
        Private _AdSize As String = Nothing
        Private _EditionIssue As String = Nothing
        Private _Section As String = Nothing
        Private _Material As String = Nothing
        Private _Remarks As String = Nothing
        Private _URL As String = Nothing
        Private _CopyArea As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _PositionInfo As String = Nothing
        Private _MiscellaneousInfo As String = Nothing
        Private _RateInfo As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _CostType As String = Nothing
        Private _RateType As String = Nothing
        Private _PrintQuantity As Nullable(Of Decimal) = Nothing
        Private _Placement1 As String = Nothing
        Private _Placement2 As String = Nothing
        Private _ProjectedImpressions As Nullable(Of Integer) = Nothing
        Private _ActualImpressions As Nullable(Of Integer) = Nothing
        Private _GuaranteedImpressions As Nullable(Of Integer) = Nothing
        Private _LineLinkID As Nullable(Of Integer) = Nothing
        Private _OrderEntryType As String = Nothing
        Private _ExtendedNetAmount As Nullable(Of Decimal) = Nothing
        Private _NetChargeAmount As Nullable(Of Decimal) = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing
        Private _AdditionalChargeAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _RebateAmount As Nullable(Of Decimal) = Nothing
        Private _VendorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _LineTotalAmount As Nullable(Of Decimal) = Nothing
        Private _NetTotalAmount As Nullable(Of Decimal) = Nothing
        Private _VendorNetAmount As Nullable(Of Decimal) = Nothing
        Private _BillAmount As Nullable(Of Decimal) = Nothing
        Private _ReconcileNoBillBillAmount As Nullable(Of Decimal) = Nothing
        Private _ReconcileNoBillNetAmount As Nullable(Of Decimal) = Nothing
        Private _LineCancelled As Nullable(Of Byte) = Nothing
        Private _SpotsQuantity As Nullable(Of Integer) = Nothing
        Private _BilledExtendedNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledDiscountAmount As Nullable(Of Decimal) = Nothing
        Private _BilledNetChargeAmount As Nullable(Of Decimal) = Nothing
        Private _BilledVendorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _BilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledAdditionalChargeAmount As Nullable(Of Decimal) = Nothing
        Private _BilledCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _BilledRebateAmount As Nullable(Of Decimal) = Nothing
        Private _BilledResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _BilledBillAmount As Nullable(Of Decimal) = Nothing
        Private _BilledSpotsQuantity As Nullable(Of Integer) = Nothing
        Private _BillCoopCode As String = Nothing
        Private _BillCoopDescription As String = Nothing
        Private _ARLastCheckNumber As String = Nothing
        Private _ARLastCheckDate As Nullable(Of Date) = Nothing
        Private _ARLastDepositDate As Nullable(Of Date) = Nothing
        Private _ARPaymentFlag As String = Nothing
        Private _ARPaymentAmount As Nullable(Of Decimal) = Nothing
        Private _APNetAmount As Nullable(Of Decimal) = Nothing
        Private _APNetChargeAmount As Nullable(Of Decimal) = Nothing
        Private _APDiscountAmount As Nullable(Of Decimal) = Nothing
        Private _APCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _APRebateAmount As Nullable(Of Decimal) = Nothing
        Private _APVendorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _APResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _APBillAmount As Nullable(Of Decimal) = Nothing
        Private _APLineTotal As Nullable(Of Decimal) = Nothing
        Private _APSpotsQuantity As Nullable(Of Integer) = Nothing
        Private _APLastCheckNumber As String = Nothing
        Private _APLastCheckDate As Nullable(Of Date) = Nothing
        Private _APPaymentFlag As String = Nothing
        Private _APPaymentAmount As Nullable(Of Decimal) = Nothing
        Private _MediaTypeDescription As String = Nothing
        Private _FiscalPeriodCode As String = Nothing
        Private _Circulation As Nullable(Of Integer) = Nothing
        Private _AcctExecCode As String = Nothing
        Private _AcctExecName As String = Nothing
        Private _CreateDate As Nullable(Of Date) = Nothing
        Private _CreateUser As String = Nothing
        Private _JobType As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _HouseComments As String = Nothing
        Private _InternetTypeCode As String = Nothing
        Private _InternetTypeDescription As String = Nothing
        Private _OutofHomeTypeCode As String = Nothing
        Private _OutofHomeTypeDescription As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Location As String = Nothing
        Private _GRP As Nullable(Of Decimal) = Nothing
        Private _GrossImpressions As Nullable(Of Decimal) = Nothing
        Private _PrimaryDemo As String = Nothing
        Private _Bookend As Nullable(Of Boolean) = Nothing
        Private _AddedValue As Nullable(Of Boolean) = Nothing
        'Private _OrderMonthNbr As Nullable(Of Short) = Nothing
        'Private _OrderYearNbr As Nullable(Of Short) = Nothing
        Private _Headline As String = Nothing
        Private _RatingSource As String = Nothing

        Private _Week1Amount As Nullable(Of Decimal) = Nothing
        Private _Week2Amount As Nullable(Of Decimal) = Nothing
        Private _Week3Amount As Nullable(Of Decimal) = Nothing
        Private _Week4Amount As Nullable(Of Decimal) = Nothing
        Private _Week5Amount As Nullable(Of Decimal) = Nothing
        Private _Week6Amount As Nullable(Of Decimal) = Nothing
        Private _Week7Amount As Nullable(Of Decimal) = Nothing

        Private _Week1Impressions As Nullable(Of Integer) = Nothing
        Private _Week2Impressions As Nullable(Of Integer) = Nothing
        Private _Week3Impressions As Nullable(Of Integer) = Nothing
        Private _Week4Impressions As Nullable(Of Integer) = Nothing
        Private _Week5Impressions As Nullable(Of Integer) = Nothing
        Private _Week6Impressions As Nullable(Of Integer) = Nothing
        Private _Week7Impressions As Nullable(Of Integer) = Nothing
        Private _LineMarketCode As String = Nothing
        Private _LineMarketDescription As String = Nothing
        Private _BroadcastWorksheetID As Nullable(Of Integer) = Nothing
        Private _BroadcastWorksheetName As String = Nothing


#End Region

#Region " Properties "

        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of System.Guid))
                _ID = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderType() As String
            Get
                OrderType = _OrderType
            End Get
            Set(value As String)
                _OrderType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product Name")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set(value As String)
                _OrderComment = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode() As String
            Get
                VendorRepCode = _VendorRepCode
            End Get
            Set(value As String)
                _VendorRepCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName() As String
            Get
                VendorRepName = _VendorRepName
            End Get
            Set(value As String)
                _VendorRepName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode2() As String
            Get
                VendorRepCode2 = _VendorRepCode2
            End Get
            Set(value As String)
                _VendorRepCode2 = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName2() As String
            Get
                VendorRepName2 = _VendorRepName2
            End Get
            Set(value As String)
                _VendorRepName2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorPaymentMethod() As String
            Get
                VendorPaymentMethod = _VendorPaymentMethod
            End Get
            Set(value As String)
                _VendorPaymentMethod = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Short)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Short))
                _CampaignID = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaTypeDescription() As String
            Get
                MediaTypeDescription = _MediaTypeDescription
            End Get
            Set(value As String)
                _MediaTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AutoCreateUnitType() As String
            Get
                AutoCreateUnitType = _AutoCreateUnitType
            End Get
            Set(value As String)
                _AutoCreateUnitType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostBillFlag() As Nullable(Of Byte)
            Get
                PostBillFlag = _PostBillFlag
            End Get
            Set(value As Nullable(Of Byte))
                _PostBillFlag = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetGrossFlag() As Nullable(Of Byte)
            Get
                NetGrossFlag = _NetGrossFlag
            End Get
            Set(value As Nullable(Of Byte))
                _NetGrossFlag = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set(value As String)
                _FiscalPeriodCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightFrom() As Nullable(Of Date)
            Get
                OrderFlightFrom = _OrderFlightFrom
            End Get
            Set(value As Nullable(Of Date))
                _OrderFlightFrom = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightTo() As Nullable(Of Date)
            Get
                OrderFlightTo = _OrderFlightTo
            End Get
            Set(value As Nullable(Of Date))
                _OrderFlightTo = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderProcessControl() As Nullable(Of Byte)
            Get
                OrderProcessControl = _OrderProcessControl
            End Get
            Set(value As Nullable(Of Byte))
                _OrderProcessControl = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkID = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderAccepted() As Nullable(Of Byte)
            Get
                OrderAccepted = _OrderAccepted
            End Get
            Set(value As Nullable(Of Byte))
                _OrderAccepted = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDateType() As String
            Get
                OrderDateType = _OrderDateType
            End Get
            Set(value As String)
                _OrderDateType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderPeriod() As Nullable(Of Integer)
            Get
                OrderPeriod = _OrderPeriod
            End Get
            Set(value As Nullable(Of Integer))
                _OrderPeriod = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderMonth() As String
            Get
                OrderMonth = _OrderMonth
            End Get
            Set(value As String)
                _OrderMonth = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Order Year")>
        Public Property OrderYear() As Nullable(Of Short)
            Get
                OrderYear = _OrderYear
            End Get
            Set(value As Nullable(Of Short))
                _OrderYear = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set(value As Nullable(Of Date))
                _InsertionDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEndDate() As Nullable(Of Date)
            Get
                OrderEndDate = _OrderEndDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderEndDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DateToBill() As Nullable(Of Date)
            Get
                DateToBill = _DateToBill
            End Get
            Set(value As Nullable(Of Date))
                _DateToBill = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialCloseDate() As Nullable(Of Date)
            Get
                MaterialCloseDate = _MaterialCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _MaterialCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedMaterialCloseDate() As Nullable(Of Date)
            Get
                ExtendedMaterialCloseDate = _ExtendedMaterialCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedMaterialCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedSpaceCloseDate() As Nullable(Of Date)
            Get
                ExtendedSpaceCloseDate = _ExtendedSpaceCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedSpaceCloseDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(value As String)
                _LineDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSize() As String
            Get
                AdSize = _AdSize
            End Get
            Set(value As String)
                _AdSize = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditionIssue() As String
            Get
                EditionIssue = _EditionIssue
            End Get
            Set(value As String)
                _EditionIssue = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(value As String)
                _Section = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(value As String)
                _Material = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remarks() As String
            Get
                Remarks = _Remarks
            End Get
            Set(value As String)
                _Remarks = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property URL() As String
            Get
                URL = _URL
            End Get
            Set(value As String)
                _URL = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CopyArea() As String
            Get
                CopyArea = _CopyArea
            End Get
            Set(value As String)
                _CopyArea = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set(value As String)
                _MaterialNotes = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PositionInfo() As String
            Get
                PositionInfo = _PositionInfo
            End Get
            Set(value As String)
                _PositionInfo = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MiscellaneousInfo() As String
            Get
                MiscellaneousInfo = _MiscellaneousInfo
            End Get
            Set(value As String)
                _MiscellaneousInfo = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RateInfo() As String
            Get
                RateInfo = _RateInfo
            End Get
            Set(value As String)
                _RateInfo = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(value As String)
                _CostType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RateType() As String
            Get
                RateType = _RateType
            End Get
            Set(value As String)
                _RateType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property PrintQuantity() As Nullable(Of Decimal)
            Get
                PrintQuantity = _PrintQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _PrintQuantity = value
            End Set
        End Property
        Public Property Placement1() As String
            Get
                Placement1 = _Placement1
            End Get
            Set(value As String)
                _Placement1 = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Placement2() As String
            Get
                Placement2 = _Placement2
            End Get
            Set(value As String)
                _Placement2 = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProjectedImpressions() As Nullable(Of Integer)
            Get
                ProjectedImpressions = _ProjectedImpressions
            End Get
            Set(value As Nullable(Of Integer))
                _ProjectedImpressions = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualImpressions() As Nullable(Of Integer)
            Get
                ActualImpressions = _ActualImpressions
            End Get
            Set(value As Nullable(Of Integer))
                _ActualImpressions = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GuaranteedImpressions() As Nullable(Of Integer)
            Get
                GuaranteedImpressions = _GuaranteedImpressions
            End Get
            Set(value As Nullable(Of Integer))
                _GuaranteedImpressions = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Circulation() As Nullable(Of Integer)
            Get
                Circulation = _Circulation
            End Get
            Set(value As Nullable(Of Integer))
                _Circulation = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property LineLinkID() As Nullable(Of Integer)
            Get
                LineLinkID = _LineLinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LineLinkID = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEntryType() As String
            Get
                OrderEntryType = _OrderEntryType
            End Get
            Set(value As String)
                _OrderEntryType = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
            Get
                ExtendedNetAmount = _ExtendedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetChargeAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                AdditionalChargeAmount = _AdditionalChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdditionalChargeAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineTotalAmount() As Nullable(Of Decimal)
            Get
                LineTotalAmount = _LineTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotalAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetTotalAmount() As Nullable(Of Decimal)
            Get
                NetTotalAmount = _NetTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetTotalAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorNetAmount() As Nullable(Of Decimal)
            Get
                VendorNetAmount = _VendorNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReconcileNoBillBillAmount() As Nullable(Of Decimal)
            Get
                ReconcileNoBillBillAmount = _ReconcileNoBillBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconcileNoBillBillAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReconcileNoBillNetAmount() As Nullable(Of Decimal)
            Get
                ReconcileNoBillNetAmount = _ReconcileNoBillNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconcileNoBillNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsQuantity() As Nullable(Of Integer)
            Get
                SpotsQuantity = _SpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _SpotsQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled() As Nullable(Of Byte)
            Get
                LineCancelled = _LineCancelled
            End Get
            Set(value As Nullable(Of Byte))
                _LineCancelled = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledExtendedNetAmount() As Nullable(Of Decimal)
            Get
                BilledExtendedNetAmount = _BilledExtendedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledExtendedNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledDiscountAmount() As Nullable(Of Decimal)
            Get
                BilledDiscountAmount = _BilledDiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledDiscountAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledNetChargeAmount() As Nullable(Of Decimal)
            Get
                BilledNetChargeAmount = _BilledNetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNetChargeAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledVendorTaxAmount() As Nullable(Of Decimal)
            Get
                BilledVendorTaxAmount = _BilledVendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledVendorTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledNetAmount() As Nullable(Of Decimal)
            Get
                BilledNetAmount = _BilledNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledAdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                BilledAdditionalChargeAmount = _BilledAdditionalChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAdditionalChargeAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCommissionAmount() As Nullable(Of Decimal)
            Get
                BilledCommissionAmount = _BilledCommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommissionAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledRebateAmount() As Nullable(Of Decimal)
            Get
                BilledRebateAmount = _BilledRebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledRebateAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledResaleTaxAmount() As Nullable(Of Decimal)
            Get
                BilledResaleTaxAmount = _BilledResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledBillAmount() As Nullable(Of Decimal)
            Get
                BilledBillAmount = _BilledBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledBillAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledSpotsQuantity() As Nullable(Of Integer)
            Get
                BilledSpotsQuantity = _BilledSpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _BilledSpotsQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Billing Coop Code")>
        Public Property BillCoopCode() As String
            Get
                BillCoopCode = _BillCoopCode
            End Get
            Set(value As String)
                _BillCoopCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Billing Coop Description")>
        Public Property BillCoopDescription() As String
            Get
                BillCoopDescription = _BillCoopDescription
            End Get
            Set(value As String)
                _BillCoopDescription = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastCheckNumber() As String
            Get
                ARLastCheckNumber = _ARLastCheckNumber
            End Get
            Set(value As String)
                _ARLastCheckNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastCheckDate() As Nullable(Of Date)
            Get
                ARLastCheckDate = _ARLastCheckDate
            End Get
            Set(value As Nullable(Of Date))
                _ARLastCheckDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastDepositDate() As Nullable(Of Date)
            Get
                ARLastDepositDate = _ARLastDepositDate
            End Get
            Set(value As Nullable(Of Date))
                _ARLastDepositDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AR Payment")>
        Public Property ARPaymentFlag() As String
            Get
                ARPaymentFlag = _ARPaymentFlag
            End Get
            Set(value As String)
                _ARPaymentFlag = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARPaymentAmount() As Nullable(Of Decimal)
            Get
                ARPaymentAmount = _ARPaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ARPaymentAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APNetAmount() As Nullable(Of Decimal)
            Get
                APNetAmount = _APNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APNetAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APNetChargeAmount() As Nullable(Of Decimal)
            Get
                APNetChargeAmount = _APNetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APNetChargeAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APDiscountAmount() As Nullable(Of Decimal)
            Get
                APDiscountAmount = _APDiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APDiscountAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APCommissionAmount() As Nullable(Of Decimal)
            Get
                APCommissionAmount = _APCommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APCommissionAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APRebateAmount() As Nullable(Of Decimal)
            Get
                APRebateAmount = _APRebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APRebateAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APVendorTaxAmount() As Nullable(Of Decimal)
            Get
                APVendorTaxAmount = _APVendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APVendorTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APResaleTaxAmount() As Nullable(Of Decimal)
            Get
                APResaleTaxAmount = _APResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APResaleTaxAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APBillAmount() As Nullable(Of Decimal)
            Get
                APBillAmount = _APBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APBillAmount = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLineTotal() As Nullable(Of Decimal)
            Get
                APLineTotal = _APLineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _APLineTotal = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APSpotsQuantity() As Nullable(Of Integer)
            Get
                APSpotsQuantity = _APSpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _APSpotsQuantity = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLastCheckNumber() As String
            Get
                APLastCheckNumber = _APLastCheckNumber
            End Get
            Set(value As String)
                _APLastCheckNumber = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLastCheckDate() As Nullable(Of Date)
            Get
                APLastCheckDate = _APLastCheckDate
            End Get
            Set(value As Nullable(Of Date))
                _APLastCheckDate = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AP Payment")>
        Public Property APPaymentFlag() As String
            Get
                APPaymentFlag = _APPaymentFlag
            End Get
            Set(value As String)
                _APPaymentFlag = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APPaymentAmount() As Nullable(Of Decimal)
            Get
                APPaymentAmount = _APPaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APPaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AcctExecCode() As String
            Get
                AcctExecCode = _AcctExecCode
            End Get
            Set(value As String)
                _AcctExecCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AcctExecName() As String
            Get
                AcctExecName = _AcctExecName
            End Get
            Set(value As String)
                _AcctExecName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreateDate() As Nullable(Of Date)
            Get
                CreateDate = _CreateDate
            End Get
            Set(value As Nullable(Of Date))
                _CreateDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreateUser() As String
            Get
                CreateUser = _CreateUser
            End Get
            Set(value As String)
                _CreateUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobType() As String
            Get
                JobType = _JobType
            End Get
            Set(value As String)
                _JobType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HouseComments() As String
            Get
                HouseComments = _HouseComments
            End Get
            Set(value As String)
                _HouseComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTypeCode() As String
            Get
                InternetTypeCode = _InternetTypeCode
            End Get
            Set(value As String)
                _InternetTypeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTypeDescription() As String
            Get
                InternetTypeDescription = _InternetTypeDescription
            End Get
            Set(value As String)
                _InternetTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Out of Home Type Code")>
        Public Property OutofHomeTypeCode() As String
            Get
                OutofHomeTypeCode = _OutofHomeTypeCode
            End Get
            Set(value As String)
                _OutofHomeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Out of Home Type Description")>
        Public Property OutofHomeTypeDescription() As String
            Get
                OutofHomeTypeDescription = _OutofHomeTypeDescription
            End Get
            Set(value As String)
                _OutofHomeTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set(value As String)
                _AdNumberDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Location() As String
            Get
                Location = _Location
            End Get
            Set(value As String)
                _Location = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
        Public Property GRP() As Nullable(Of Decimal)
            Get
                GRP = _GRP
            End Get
            Set(value As Nullable(Of Decimal))
                _GRP = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property GrossImpressions() As Nullable(Of Decimal)
            Get
                GrossImpressions = _GrossImpressions
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossImpressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrimaryDemo() As String
            Get
                PrimaryDemo = _PrimaryDemo
            End Get
            Set(value As String)
                _PrimaryDemo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Bookend() As Nullable(Of Boolean)
            Get
                Bookend = _Bookend
            End Get
            Set(value As Nullable(Of Boolean))
                _Bookend = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddedValue() As Nullable(Of Boolean)
            Get
                AddedValue = _AddedValue
            End Get
            Set(value As Nullable(Of Boolean))
                _AddedValue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(value As String)
                _Headline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RatingSource() As String
            Get
                RatingSource = _RatingSource
            End Get
            Set(value As String)
                _RatingSource = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week1Amount() As Nullable(Of Decimal)
            Get
                Week1Amount = _Week1Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week1Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week2Amount() As Nullable(Of Decimal)
            Get
                Week2Amount = _Week2Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week2Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week3Amount() As Nullable(Of Decimal)
            Get
                Week3Amount = _Week3Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week3Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week4Amount() As Nullable(Of Decimal)
            Get
                Week4Amount = _Week4Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week4Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week5Amount() As Nullable(Of Decimal)
            Get
                Week5Amount = _Week5Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week5Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week6Amount() As Nullable(Of Decimal)
            Get
                Week6Amount = _Week6Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week6Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week7Amount() As Nullable(Of Decimal)
            Get
                Week7Amount = _Week7Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Week7Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week1Impressions() As Nullable(Of Integer)
            Get
                Week1Impressions = _Week1Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week1Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week2Impressions() As Nullable(Of Integer)
            Get
                Week2Impressions = _Week2Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week2Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week3Impressions() As Nullable(Of Integer)
            Get
                Week3Impressions = _Week3Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week3Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week4Impressions() As Nullable(Of Integer)
            Get
                Week4Impressions = _Week4Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week4Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week5Impressions() As Nullable(Of Integer)
            Get
                Week5Impressions = _Week5Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week5Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week6Impressions() As Nullable(Of Integer)
            Get
                Week6Impressions = _Week6Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week6Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Week7Impressions() As Nullable(Of Integer)
            Get
                Week7Impressions = _Week7Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Week7Impressions = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        'Public Property OrderMonthNbr() As Nullable(Of Short)
        '    Get
        '        OrderMonthNbr = _OrderMonthNbr
        '    End Get
        '    Set(value As Nullable(Of Short))
        '        _OrderMonthNbr = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        'Public Property OrderYearNbr() As Nullable(Of Short)
        '    Get
        '        OrderYearNbr = _OrderYearNbr
        '    End Get
        '    Set(value As Nullable(Of Short))
        '        _OrderYearNbr = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderResaleTaxAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderVendorTaxAmount As Nullable(Of Decimal)
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineMarketCode() As String
            Get
                LineMarketCode = _LineMarketCode
            End Get
            Set(value As String)
                _LineMarketCode = value
            End Set
        End Property
        <
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineMarketDescription() As String
            Get
                LineMarketDescription = _LineMarketDescription
            End Get
            Set(value As String)
                _LineMarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BroadcastWorksheetID() As Nullable(Of Integer)
            Get
                BroadcastWorksheetID = _BroadcastWorksheetID
            End Get
            Set(value As Nullable(Of Integer))
                _BroadcastWorksheetID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastWorksheetName() As String
            Get
                BroadcastWorksheetName = _BroadcastWorksheetName
            End Get
            Set(value As String)
                _BroadcastWorksheetName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
