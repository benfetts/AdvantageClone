Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="AROpenAged")>
    <Serializable()>
    Public Class AROpenAged
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ARGLAccount
            GLOffice
            AROffice
            ClientCode
            ClientDescription
            ClientStatementAddress1
            ClientStatementAddress2
            ClientStatementCityStateZip
            ClientStatementCountry
            ClientBillingAddress1
            ClientBillingAddress2
            ClientBillingCityStateZip
            ClientBillingCountry
            ClientBillingAttention
            ClientARComment
            ClientDaysToPayProduction
            ClientDaysToPayMedia
            DivisionCode
            DivisionDescription
            DivisionStatementAddress1
            DivisionStatementAddress2
            DivisionStatementCityStateZip
            DivisionStatementCountry
            DivisionBillingAddress1
            DivisionBillingAddress2
            DivisionBillingCityStateZip
            DivisionBillingCountry
            DivisionBillingAttention
            ProductCode
            ProductDescription
            ProductStatementAddress1
            ProductStatementAddress2
            ProductStatementCityStateZip
            ProductStatementCountry
            ProductBillingAddress1
            ProductBillingAddress2
            ProductBillingCityStateZip
            ProductBillingCountry
            ProductBillingAttention
            AccountExecutiveCode
            AccountExecutive
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            InvoiceNumber
            InvoiceSequence
            InvoicePostingPeriod
            InvoiceDate
            InvoiceDueDate
            InvoiceDescription
            InvoiceRecordType
            InvoiceCategory
            InvoiceComments
            ARCollectionNotes
            TotalInvoiceAmount
            CashReceipts
            CRAdjustments
            TotalReceiptsAndAdjustments
            InvoiceBalance
            Days
            Current
            Aging30Days
            Aging60Days
            Aging90Days
            Aging120PlusDays
            OnAccountBalance
            InvoiceBalanceWithOA
            JobOrderNumberListing
            CRCheckNumberListing
            JobNumber
            JobDescription
            ClientReference
            ClientPOProduction
            JobType
            JobContact
            OrderNumber
            OrderDescription
            ClientPOMedia
            MediaDates
            InvoiceTypeDescription
            PartialPaymentIndicator
            VendorCode
            VendorName
            CampaignID
            CampaignCode
            CampaignName
            CampaignComment
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _ARGLAccount As String = Nothing
        Private _GLOffice As String = Nothing
        Private _AROffice As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _ClientStatementAddress1 As String = Nothing
        Private _ClientStatementAddress2 As String = Nothing
        Private _ClientStatementCityStateZip As String = Nothing
        Private _ClientStatementCountry As String = Nothing
        Private _ClientBillingAddress1 As String = Nothing
        Private _ClientBillingAddress2 As String = Nothing
        Private _ClientBillingCityStateZip As String = Nothing
        Private _ClientBillingCountry As String = Nothing
        Private _ClientBillingAttention As String = Nothing
        Private _ClientARComment As String = Nothing
        Private _ClientDaysToPayProduction As Nullable(Of Short) = Nothing
        Private _ClientDaysToPayMedia As Nullable(Of Short) = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _DivisionStatementAddress1 As String = Nothing
        Private _DivisionStatementAddress2 As String = Nothing
        Private _DivisionStatementCityStateZip As String = Nothing
        Private _DivisionStatementCountry As String = Nothing
        Private _DivisionBillingAddress1 As String = Nothing
        Private _DivisionBillingAddress2 As String = Nothing
        Private _DivisionBillingCityStateZip As String = Nothing
        Private _DivisionBillingCountry As String = Nothing
        Private _DivisionBillingAttention As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductStatementAddress1 As String = Nothing
        Private _ProductStatementAddress2 As String = Nothing
        Private _ProductStatementCityStateZip As String = Nothing
        Private _ProductStatementCountry As String = Nothing
        Private _ProductBillingAddress1 As String = Nothing
        Private _ProductBillingAddress2 As String = Nothing
        Private _ProductBillingCityStateZip As String = Nothing
        Private _ProductBillingCountry As String = Nothing
        Private _ProductBillingAttention As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceSequence As String = Nothing
        Private _InvoicePostingPeriod As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _InvoiceDueDate As Nullable(Of Date) = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceRecordType As String = Nothing
        Private _InvoiceCategory As String = Nothing
        Private _InvoiceComments As String = Nothing
        Private _ARCollectionNotes As String = Nothing
        Private _TotalInvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _CashReceipts As Nullable(Of Decimal) = Nothing
        Private _CRAdjustments As Nullable(Of Decimal) = Nothing
        Private _TotalReceiptsAndAdjustments As Nullable(Of Decimal) = Nothing
        Private _InvoiceBalance As Nullable(Of Decimal) = Nothing
        Private _Days As Nullable(Of Integer) = Nothing
        Private _Current As Nullable(Of Decimal) = Nothing
        Private _Aging30Days As Nullable(Of Decimal) = Nothing
        Private _Aging60Days As Nullable(Of Decimal) = Nothing
        Private _Aging90Days As Nullable(Of Decimal) = Nothing
        Private _Aging120PlusDays As Nullable(Of Decimal) = Nothing
        Private _OnAccountBalance As Nullable(Of Decimal) = Nothing
        Private _InvoiceBalanceWithOA As Nullable(Of Decimal) = Nothing
        Private _JobOrderNumberListing As String = Nothing
        Private _CRCheckNumberListing As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _ClientReference As String = Nothing
        Private _ClientPOProduction As String = Nothing
        Private _JobType As String = Nothing
        Private _JobContact As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _ClientPOMedia As String = Nothing
        Private _MediaDates As String = Nothing
        Private _InvoiceTypeDescription As String = Nothing
        Private _PartialPaymentIndicator As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _CampaignComment As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of Integer))
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="AR GL Account")>
        Public Property ARGLAccount() As String
            Get
                ARGLAccount = _ARGLAccount
            End Get
            Set(value As String)
                _ARGLAccount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLOffice() As String
            Get
                GLOffice = _GLOffice
            End Get
            Set(value As String)
                _GLOffice = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AROffice() As String
            Get
                AROffice = _AROffice
            End Get
            Set(value As String)
                _AROffice = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientStatementAddress1() As String
            Get
                ClientStatementAddress1 = _ClientStatementAddress1
            End Get
            Set(value As String)
                _ClientStatementAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientStatementAddress2() As String
            Get
                ClientStatementAddress2 = _ClientStatementAddress2
            End Get
            Set(value As String)
                _ClientStatementAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientStatementCityStateZip() As String
            Get
                ClientStatementCityStateZip = _ClientStatementCityStateZip
            End Get
            Set(value As String)
                _ClientStatementCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientStatementCountry() As String
            Get
                ClientStatementCountry = _ClientStatementCountry
            End Get
            Set(value As String)
                _ClientStatementCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientBillingAddress1() As String
            Get
                ClientBillingAddress1 = _ClientBillingAddress1
            End Get
            Set(value As String)
                _ClientBillingAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientBillingAddress2() As String
            Get
                ClientBillingAddress2 = _ClientBillingAddress2
            End Get
            Set(value As String)
                _ClientBillingAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientBillingCityStateZip() As String
            Get
                ClientBillingCityStateZip = _ClientBillingCityStateZip
            End Get
            Set(value As String)
                _ClientBillingCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientBillingCountry() As String
            Get
                ClientBillingCountry = _ClientBillingCountry
            End Get
            Set(value As String)
                _ClientBillingCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientBillingAttention() As String
            Get
                ClientBillingAttention = _ClientBillingAttention
            End Get
            Set(value As String)
                _ClientBillingAttention = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientARComment() As String
            Get
                ClientARComment = _ClientARComment
            End Get
            Set(value As String)
                _ClientARComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientDaysToPayProduction() As Nullable(Of Short)
            Get
                ClientDaysToPayProduction = _ClientDaysToPayProduction
            End Get
            Set(value As Nullable(Of Short))
                _ClientDaysToPayProduction = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientDaysToPayMedia() As Nullable(Of Short)
            Get
                ClientDaysToPayMedia = _ClientDaysToPayMedia
            End Get
            Set(value As Nullable(Of Short))
                _ClientDaysToPayMedia = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionStatementAddress1() As String
            Get
                DivisionStatementAddress1 = _DivisionStatementAddress1
            End Get
            Set(value As String)
                _DivisionStatementAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionStatementAddress2() As String
            Get
                DivisionStatementAddress2 = _DivisionStatementAddress2
            End Get
            Set(value As String)
                _DivisionStatementAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionStatementCityStateZip() As String
            Get
                DivisionStatementCityStateZip = _DivisionStatementCityStateZip
            End Get
            Set(value As String)
                _DivisionStatementCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionStatementCountry() As String
            Get
                DivisionStatementCountry = _DivisionStatementCountry
            End Get
            Set(value As String)
                _DivisionStatementCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionBillingAddress1() As String
            Get
                DivisionBillingAddress1 = _DivisionBillingAddress1
            End Get
            Set(value As String)
                _DivisionBillingAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionBillingAddress2() As String
            Get
                DivisionBillingAddress2 = _DivisionBillingAddress2
            End Get
            Set(value As String)
                _DivisionBillingAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionBillingCityStateZip() As String
            Get
                DivisionBillingCityStateZip = _DivisionBillingCityStateZip
            End Get
            Set(value As String)
                _DivisionBillingCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionBillingCountry() As String
            Get
                DivisionBillingCountry = _DivisionBillingCountry
            End Get
            Set(value As String)
                _DivisionBillingCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionBillingAttention() As String
            Get
                DivisionBillingAttention = _DivisionBillingAttention
            End Get
            Set(value As String)
                _DivisionBillingAttention = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property ProductStatementAddress1() As String
            Get
                ProductStatementAddress1 = _ProductStatementAddress1
            End Get
            Set(value As String)
                _ProductStatementAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductStatementAddress2() As String
            Get
                ProductStatementAddress2 = _ProductStatementAddress2
            End Get
            Set(value As String)
                _ProductStatementAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductStatementCityStateZip() As String
            Get
                ProductStatementCityStateZip = _ProductStatementCityStateZip
            End Get
            Set(value As String)
                _ProductStatementCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductStatementCountry() As String
            Get
                ProductStatementCountry = _ProductStatementCountry
            End Get
            Set(value As String)
                _ProductStatementCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductBillingAddress1() As String
            Get
                ProductBillingAddress1 = _ProductBillingAddress1
            End Get
            Set(value As String)
                _ProductBillingAddress1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductBillingAddress2() As String
            Get
                ProductBillingAddress2 = _ProductBillingAddress2
            End Get
            Set(value As String)
                _ProductBillingAddress2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductBillingCityStateZip() As String
            Get
                ProductBillingCityStateZip = _ProductBillingCityStateZip
            End Get
            Set(value As String)
                _ProductBillingCityStateZip = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductBillingCountry() As String
            Get
                ProductBillingCountry = _ProductBillingCountry
            End Get
            Set(value As String)
                _ProductBillingCountry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductBillingAttention() As String
            Get
                ProductBillingAttention = _ProductBillingAttention
            End Get
            Set(value As String)
                _ProductBillingAttention = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(value As String)
                _AccountExecutiveCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequence() As String
            Get
                InvoiceSequence = _InvoiceSequence
            End Get
            Set(value As String)
                _InvoiceSequence = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoicePostingPeriod() As String
            Get
                InvoicePostingPeriod = _InvoicePostingPeriod
            End Get
            Set(value As String)
                _InvoicePostingPeriod = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDueDate() As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceRecordType() As String
            Get
                InvoiceRecordType = _InvoiceRecordType
            End Get
            Set(value As String)
                _InvoiceRecordType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceCategory() As String
            Get
                InvoiceCategory = _InvoiceCategory
            End Get
            Set(value As String)
                _InvoiceCategory = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceComments() As String
            Get
                InvoiceComments = _InvoiceComments
            End Get
            Set(value As String)
                _InvoiceComments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARCollectionNotes() As String
            Get
                ARCollectionNotes = _ARCollectionNotes
            End Get
            Set(value As String)
                _ARCollectionNotes = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalInvoiceAmount() As Nullable(Of Decimal)
            Get
                TotalInvoiceAmount = _TotalInvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalInvoiceAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CashReceipts() As Nullable(Of Decimal)
            Get
                CashReceipts = _CashReceipts
            End Get
            Set(value As Nullable(Of Decimal))
                _CashReceipts = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CRAdjustments() As Nullable(Of Decimal)
            Get
                CRAdjustments = _CRAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _CRAdjustments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalReceiptsAndAdjustments() As Nullable(Of Decimal)
            Get
                TotalReceiptsAndAdjustments = _TotalReceiptsAndAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalReceiptsAndAdjustments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceBalance() As Nullable(Of Decimal)
            Get
                InvoiceBalance = _InvoiceBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Days() As Nullable(Of Integer)
            Get
                Days = _Days
            End Get
            Set(value As Nullable(Of Integer))
                _Days = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Current() As Nullable(Of Decimal)
            Get
                Current = _Current
            End Get
            Set(value As Nullable(Of Decimal))
                _Current = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging 30 Days")>
        Public Property Aging30Days() As Nullable(Of Decimal)
            Get
                Aging30Days = _Aging30Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging30Days = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging 60 Days")>
        Public Property Aging60Days() As Nullable(Of Decimal)
            Get
                Aging60Days = _Aging60Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging60Days = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging 90 Days")>
        Public Property Aging90Days() As Nullable(Of Decimal)
            Get
                Aging90Days = _Aging90Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging90Days = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging 120 Plus Days")>
        Public Property Aging120PlusDays() As Nullable(Of Decimal)
            Get
                Aging120PlusDays = _Aging120PlusDays
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging120PlusDays = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OnAccountBalance() As Nullable(Of Decimal)
            Get
                OnAccountBalance = _OnAccountBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _OnAccountBalance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceBalanceWithOA() As Nullable(Of Decimal)
            Get
                InvoiceBalanceWithOA = _InvoiceBalanceWithOA
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalanceWithOA = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobOrderNumberListing() As String
            Get
                JobOrderNumberListing = _JobOrderNumberListing
            End Get
            Set(value As String)
                _JobOrderNumberListing = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CRCheckNumberListing() As String
            Get
                CRCheckNumberListing = _CRCheckNumberListing
            End Get
            Set(value As String)
                _CRCheckNumberListing = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
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
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPOProduction() As String
            Get
                ClientPOProduction = _ClientPOProduction
            End Get
            Set(value As String)
                _ClientPOProduction = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobType() As String
            Get
                JobType = _JobType
            End Get
            Set(value As String)
                _JobType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobContact() As String
            Get
                JobContact = _JobContact
            End Get
            Set(value As String)
                _JobContact = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property ClientPOMedia() As String
            Get
                ClientPOMedia = _ClientPOMedia
            End Get
            Set(value As String)
                _ClientPOMedia = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaDates() As String
            Get
                MediaDates = _MediaDates
            End Get
            Set(value As String)
                _MediaDates = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTypeDescription() As String
            Get
                InvoiceTypeDescription = _InvoiceTypeDescription
            End Get
            Set(value As String)
                _InvoiceTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PartialPaymentIndicator() As String
            Get
                PartialPaymentIndicator = _PartialPaymentIndicator
            End Get
            Set(value As String)
                _PartialPaymentIndicator = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property CampaignComment() As String
            Get
                CampaignComment = _CampaignComment
            End Get
            Set(value As String)
                _CampaignComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ARGLAccount.ToString

        End Function

#End Region

    End Class

End Namespace
