Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="MediaCurrentStatusReport")>
    <Serializable()>
    Public Class MediaCurrentStatusReport
        Inherits BaseClasses.ComplexType

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
            CampaignCode
            CampaignID
            CampaignName
            MediaType
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
            GuaranteedImpressions
            LineLinkID
            OrderEntryType
            RecordType
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
            NonBillableFlag
            LineCancelled
            BillTypeFlag
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
            InvoiceNumber
            InvoiceSequenceNumber
            InvoiceType
            ARInvoiceDate
            GLBillingTransNumber
            BillCoopCode
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
            APID
            APInvoiceNumber
            APInvoiceDate
            APGLTransNumber
            APLastCheckNumber
            APLastCheckDate
            APPaymentFlag
            APPaymentAmount
            MediaTypeDescription
            FiscalPeriodCode
            Circulation
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
        Private _CampaignCode As String = Nothing
        Private _CampaignID As Nullable(Of Short) = Nothing
        Private _CampaignName As String = Nothing
        Private _MediaType As String = Nothing
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
        Private _PrintQuantity As String = Nothing
        Private _GuaranteedImpressions As Nullable(Of Integer) = Nothing
        Private _LineLinkID As Nullable(Of Integer) = Nothing
        Private _OrderEntryType As String = Nothing
        Private _RecordType As String = Nothing
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
        Private _SpotsQuantity As Nullable(Of Integer) = Nothing
        Private _NonBillableFlag As Nullable(Of Byte) = Nothing
        Private _LineCancelled As Nullable(Of Byte) = Nothing
        Private _BillTypeFlag As Nullable(Of Byte) = Nothing
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
        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSequenceNumber As Nullable(Of Short) = Nothing
        Private _InvoiceType As String = Nothing
        Private _ARInvoiceDate As Nullable(Of Date) = Nothing
        Private _GLBillingTransNumber As Nullable(Of Integer) = Nothing
        Private _BillCoopCode As String = Nothing
        Private _ARLastCheckNumber As String = Nothing
        Private _ARLastCheckDate As Nullable(Of Date) = Nothing
        Private _ARLastDepositDate As Nullable(Of Date) = Nothing
        Private _ARPaymentFlag As Nullable(Of Byte) = Nothing
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
        Private _AP_ID As Nullable(Of Integer) = Nothing
        Private _APInvoiceNumber As String = Nothing
        Private _APInvoiceDate As Nullable(Of Date) = Nothing
        Private _APGLTransNumber As Nullable(Of Integer) = Nothing
        Private _APLastCheckNumber As String = Nothing
        Private _APLastCheckDate As Nullable(Of Date) = Nothing
        Private _APPaymentFlag As Nullable(Of Byte) = Nothing
        Private _APPaymentAmount As Nullable(Of Decimal) = Nothing
        Private _MediaTypeDescription As String = Nothing
        Private _FiscalPeriodCode As String = Nothing
        Private _Circulation As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(value As System.Guid)
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderType() As String
            Get
                OrderType = _OrderType
            End Get
            Set(value As String)
                _OrderType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set(value As String)
                _OrderComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode() As String
            Get
                VendorRepCode = _VendorRepCode
            End Get
            Set(value As String)
                _VendorRepCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName() As String
            Get
                VendorRepName = _VendorRepName
            End Get
            Set(value As String)
                _VendorRepName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode2() As String
            Get
                VendorRepCode2 = _VendorRepCode2
            End Get
            Set(value As String)
                _VendorRepCode2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName2() As String
            Get
                VendorRepName2 = _VendorRepName2
            End Get
            Set(value As String)
                _VendorRepName2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Short)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Short))
                _CampaignID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaTypeDescription() As String
            Get
                MediaTypeDescription = _MediaTypeDescription
            End Get
            Set(value As String)
                _MediaTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostBillFlag() As Nullable(Of Byte)
            Get
                PostBillFlag = _PostBillFlag
            End Get
            Set(value As Nullable(Of Byte))
                _PostBillFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetGrossFlag() As Nullable(Of Byte)
            Get
                NetGrossFlag = _NetGrossFlag
            End Get
            Set(value As Nullable(Of Byte))
                _NetGrossFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set(value As String)
                _FiscalPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightFrom() As Nullable(Of Date)
            Get
                OrderFlightFrom = _OrderFlightFrom
            End Get
            Set(value As Nullable(Of Date))
                _OrderFlightFrom = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightTo() As Nullable(Of Date)
            Get
                OrderFlightTo = _OrderFlightTo
            End Get
            Set(value As Nullable(Of Date))
                _OrderFlightTo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderProcessControl() As Nullable(Of Byte)
            Get
                OrderProcessControl = _OrderProcessControl
            End Get
            Set(value As Nullable(Of Byte))
                _OrderProcessControl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderAccepted() As Nullable(Of Byte)
            Get
                OrderAccepted = _OrderAccepted
            End Get
            Set(value As Nullable(Of Byte))
                _OrderAccepted = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDateType() As String
            Get
                OrderDateType = _OrderDateType
            End Get
            Set(value As String)
                _OrderDateType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderPeriod() As Nullable(Of Integer)
            Get
                OrderPeriod = _OrderPeriod
            End Get
            Set(value As Nullable(Of Integer))
                _OrderPeriod = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderMonth() As String
            Get
                OrderMonth = _OrderMonth
            End Get
            Set(value As String)
                _OrderMonth = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Order Year")>
        Public Property OrderYear() As Nullable(Of Short)
            Get
                OrderYear = _OrderYear
            End Get
            Set(value As Nullable(Of Short))
                _OrderYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set(value As Nullable(Of Date))
                _InsertionDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEndDate() As Nullable(Of Date)
            Get
                OrderEndDate = _OrderEndDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderEndDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DateToBill() As Nullable(Of Date)
            Get
                DateToBill = _DateToBill
            End Get
            Set(value As Nullable(Of Date))
                _DateToBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialCloseDate() As Nullable(Of Date)
            Get
                MaterialCloseDate = _MaterialCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _MaterialCloseDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(value As String)
                _LineDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSize() As String
            Get
                AdSize = _AdSize
            End Get
            Set(value As String)
                _AdSize = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditionIssue() As String
            Get
                EditionIssue = _EditionIssue
            End Get
            Set(value As String)
                _EditionIssue = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(value As String)
                _Section = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(value As String)
                _Material = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remarks() As String
            Get
                Remarks = _Remarks
            End Get
            Set(value As String)
                _Remarks = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property URL() As String
            Get
                URL = _URL
            End Get
            Set(value As String)
                _URL = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CopyArea() As String
            Get
                CopyArea = _CopyArea
            End Get
            Set(value As String)
                _CopyArea = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set(value As String)
                _MaterialNotes = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PositionInfo() As String
            Get
                PositionInfo = _PositionInfo
            End Get
            Set(value As String)
                _PositionInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MiscellaneousInfo() As String
            Get
                MiscellaneousInfo = _MiscellaneousInfo
            End Get
            Set(value As String)
                _MiscellaneousInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RateInfo() As String
            Get
                RateInfo = _RateInfo
            End Get
            Set(value As String)
                _RateInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(value As String)
                _CostType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RateType() As String
            Get
                RateType = _RateType
            End Get
            Set(value As String)
                _RateType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintQuantity() As String
            Get
                PrintQuantity = _PrintQuantity
            End Get
            Set(value As String)
                _PrintQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GuaranteedImpressions() As Nullable(Of Integer)
            Get
                GuaranteedImpressions = _GuaranteedImpressions
            End Get
            Set(value As Nullable(Of Integer))
                _GuaranteedImpressions = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Circulation() As Nullable(Of Integer)
            Get
                Circulation = _Circulation
            End Get
            Set(value As Nullable(Of Integer))
                _Circulation = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineLinkID() As Nullable(Of Integer)
            Get
                LineLinkID = _LineLinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LineLinkID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEntryType() As String
            Get
                OrderEntryType = _OrderEntryType
            End Get
            Set(value As String)
                _OrderEntryType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecordType() As String
            Get
                RecordType = _RecordType
            End Get
            Set(value As String)
                _RecordType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
            Get
                ExtendedNetAmount = _ExtendedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetChargeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                AdditionalChargeAmount = _AdditionalChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdditionalChargeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _RebateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineTotalAmount() As Nullable(Of Decimal)
            Get
                LineTotalAmount = _LineTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetTotalAmount() As Nullable(Of Decimal)
            Get
                NetTotalAmount = _NetTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorNetAmount() As Nullable(Of Decimal)
            Get
                VendorNetAmount = _VendorNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReconcileNoBillBillAmount() As Nullable(Of Decimal)
            Get
                ReconcileNoBillBillAmount = _ReconcileNoBillBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconcileNoBillBillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReconcileNoBillNetAmount() As Nullable(Of Decimal)
            Get
                ReconcileNoBillNetAmount = _ReconcileNoBillNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconcileNoBillNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsQuantity() As Nullable(Of Integer)
            Get
                SpotsQuantity = _SpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _SpotsQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableFlag() As Nullable(Of Byte)
            Get
                NonBillableFlag = _NonBillableFlag
            End Get
            Set(value As Nullable(Of Byte))
                _NonBillableFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled() As Nullable(Of Byte)
            Get
                LineCancelled = _LineCancelled
            End Get
            Set(value As Nullable(Of Byte))
                _LineCancelled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillTypeFlag() As Nullable(Of Byte)
            Get
                BillTypeFlag = _BillTypeFlag
            End Get
            Set(value As Nullable(Of Byte))
                _BillTypeFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledExtendedNetAmount() As Nullable(Of Decimal)
            Get
                BilledExtendedNetAmount = _BilledExtendedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledExtendedNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledDiscountAmount() As Nullable(Of Decimal)
            Get
                BilledDiscountAmount = _BilledDiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledDiscountAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledNetChargeAmount() As Nullable(Of Decimal)
            Get
                BilledNetChargeAmount = _BilledNetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNetChargeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledVendorTaxAmount() As Nullable(Of Decimal)
            Get
                BilledVendorTaxAmount = _BilledVendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledVendorTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledNetAmount() As Nullable(Of Decimal)
            Get
                BilledNetAmount = _BilledNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledAdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                BilledAdditionalChargeAmount = _BilledAdditionalChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAdditionalChargeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCommissionAmount() As Nullable(Of Decimal)
            Get
                BilledCommissionAmount = _BilledCommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommissionAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledRebateAmount() As Nullable(Of Decimal)
            Get
                BilledRebateAmount = _BilledRebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledRebateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledResaleTaxAmount() As Nullable(Of Decimal)
            Get
                BilledResaleTaxAmount = _BilledResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledBillAmount() As Nullable(Of Decimal)
            Get
                BilledBillAmount = _BilledBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledBillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledSpotsQuantity() As Nullable(Of Integer)
            Get
                BilledSpotsQuantity = _BilledSpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _BilledSpotsQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _InvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequenceNumber() As Nullable(Of Short)
            Get
                InvoiceSequenceNumber = _InvoiceSequenceNumber
            End Get
            Set(value As Nullable(Of Short))
                _InvoiceSequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(value As String)
                _InvoiceType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARInvoiceDate() As Nullable(Of Date)
            Get
                ARInvoiceDate = _ARInvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _ARInvoiceDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property GLBillingTransNumber() As Nullable(Of Integer)
            Get
                GLBillingTransNumber = _GLBillingTransNumber
            End Get
            Set(value As Nullable(Of Integer))
                _GLBillingTransNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillCoopCode() As String
            Get
                BillCoopCode = _BillCoopCode
            End Get
            Set(value As String)
                _BillCoopCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastCheckNumber() As String
            Get
                ARLastCheckNumber = _ARLastCheckNumber
            End Get
            Set(value As String)
                _ARLastCheckNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastCheckDate() As Nullable(Of Date)
            Get
                ARLastCheckDate = _ARLastCheckDate
            End Get
            Set(value As Nullable(Of Date))
                _ARLastCheckDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARLastDepositDate() As Nullable(Of Date)
            Get
                ARLastDepositDate = _ARLastDepositDate
            End Get
            Set(value As Nullable(Of Date))
                _ARLastDepositDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AR Payment")>
        Public Property ARPaymentFlag() As Nullable(Of Byte)
            Get
                ARPaymentFlag = _ARPaymentFlag
            End Get
            Set(value As Nullable(Of Byte))
                _ARPaymentFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARPaymentAmount() As Nullable(Of Decimal)
            Get
                ARPaymentAmount = _ARPaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ARPaymentAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APNetAmount() As Nullable(Of Decimal)
            Get
                APNetAmount = _APNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APNetChargeAmount() As Nullable(Of Decimal)
            Get
                APNetChargeAmount = _APNetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APNetChargeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APDiscountAmount() As Nullable(Of Decimal)
            Get
                APDiscountAmount = _APDiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APDiscountAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APCommissionAmount() As Nullable(Of Decimal)
            Get
                APCommissionAmount = _APCommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APCommissionAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APRebateAmount() As Nullable(Of Decimal)
            Get
                APRebateAmount = _APRebateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APRebateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APVendorTaxAmount() As Nullable(Of Decimal)
            Get
                APVendorTaxAmount = _APVendorTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APVendorTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APResaleTaxAmount() As Nullable(Of Decimal)
            Get
                APResaleTaxAmount = _APResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APBillAmount() As Nullable(Of Decimal)
            Get
                APBillAmount = _APBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APBillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLineTotal() As Nullable(Of Decimal)
            Get
                APLineTotal = _APLineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _APLineTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APSpotsQuantity() As Nullable(Of Integer)
            Get
                APSpotsQuantity = _APSpotsQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _APSpotsQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AP_ID() As Nullable(Of Integer)
            Get
                AP_ID = _AP_ID
            End Get
            Set(value As Nullable(Of Integer))
                _AP_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APInvoiceNumber() As String
            Get
                APInvoiceNumber = _APInvoiceNumber
            End Get
            Set(value As String)
                _APInvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APInvoiceDate() As Nullable(Of Date)
            Get
                APInvoiceDate = _APInvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _APInvoiceDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APGLTransNumber() As Nullable(Of Integer)
            Get
                APGLTransNumber = _APGLTransNumber
            End Get
            Set(value As Nullable(Of Integer))
                _APGLTransNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLastCheckNumber() As String
            Get
                APLastCheckNumber = _APLastCheckNumber
            End Get
            Set(value As String)
                _APLastCheckNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APLastCheckDate() As Nullable(Of Date)
            Get
                APLastCheckDate = _APLastCheckDate
            End Get
            Set(value As Nullable(Of Date))
                _APLastCheckDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AP Payment")>
        Public Property APPaymentFlag() As Nullable(Of Byte)
            Get
                APPaymentFlag = _APPaymentFlag
            End Get
            Set(value As Nullable(Of Byte))
                _APPaymentFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property APPaymentAmount() As Nullable(Of Decimal)
            Get
                APPaymentAmount = _APPaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APPaymentAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
