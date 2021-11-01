Namespace Reporting.Database.Classes

    <Serializable>
    Public Class AROpenAgedMonthEnd

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ARGLAccount
            MappedAccount
            TargetAccount
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
            DaysToPayActual
            DaysToPayActualProd
            DaysToPayActualMedia
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
            ARGLXact
            ARGLSequenceNumber
            InvoiceNumber
            InvoiceSequence
            InvoicePostingPeriod
            InvoiceDate
            InvoiceDueDate
            PostedToSummary
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
            AbsoluteAmount
            DebitOrCredit
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
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing
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
        Private _DaysToPayActual As Nullable(Of Integer) = Nothing
        Private _DaysToPayActualProd As Nullable(Of Integer) = Nothing
        Private _DaysToPayActualMedia As Nullable(Of Integer) = Nothing
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
        Private _ARGLXact As Integer? = Nothing
        Private _ARGLSequenceNumber As Short? = Nothing
        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSequence As String = Nothing
        Private _InvoicePostingPeriod As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _InvoiceDueDate As Nullable(Of Date) = Nothing
        Private _PostedToSummary As Nullable(Of Date) = Nothing
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
        Private _AbsoluteAmount As Nullable(Of Decimal) = Nothing
        Private _DebitOrCredit As String = Nothing
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

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of Integer))
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="AR GL Account")>
        Public Property ARGLAccount() As String
            Get
                ARGLAccount = _ARGLAccount
            End Get
            Set(value As String)
                _ARGLAccount = value
            End Set
        End Property
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set(value As String)
                _MappedAccount = value
            End Set
        End Property
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set(value As String)
                _TargetAccount = value
            End Set
        End Property
        Public Property GLOffice() As String
            Get
                GLOffice = _GLOffice
            End Get
            Set(value As String)
                _GLOffice = value
            End Set
        End Property
        Public Property AROffice() As String
            Get
                AROffice = _AROffice
            End Get
            Set(value As String)
                _AROffice = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        Public Property ClientStatementAddress1() As String
            Get
                ClientStatementAddress1 = _ClientStatementAddress1
            End Get
            Set(value As String)
                _ClientStatementAddress1 = value
            End Set
        End Property
        Public Property ClientStatementAddress2() As String
            Get
                ClientStatementAddress2 = _ClientStatementAddress2
            End Get
            Set(value As String)
                _ClientStatementAddress2 = value
            End Set
        End Property
        Public Property ClientStatementCityStateZip() As String
            Get
                ClientStatementCityStateZip = _ClientStatementCityStateZip
            End Get
            Set(value As String)
                _ClientStatementCityStateZip = value
            End Set
        End Property
        Public Property ClientStatementCountry() As String
            Get
                ClientStatementCountry = _ClientStatementCountry
            End Get
            Set(value As String)
                _ClientStatementCountry = value
            End Set
        End Property
        Public Property ClientBillingAddress1() As String
            Get
                ClientBillingAddress1 = _ClientBillingAddress1
            End Get
            Set(value As String)
                _ClientBillingAddress1 = value
            End Set
        End Property
        Public Property ClientBillingAddress2() As String
            Get
                ClientBillingAddress2 = _ClientBillingAddress2
            End Get
            Set(value As String)
                _ClientBillingAddress2 = value
            End Set
        End Property
        Public Property ClientBillingCityStateZip() As String
            Get
                ClientBillingCityStateZip = _ClientBillingCityStateZip
            End Get
            Set(value As String)
                _ClientBillingCityStateZip = value
            End Set
        End Property
        Public Property ClientBillingCountry() As String
            Get
                ClientBillingCountry = _ClientBillingCountry
            End Get
            Set(value As String)
                _ClientBillingCountry = value
            End Set
        End Property
        Public Property ClientBillingAttention() As String
            Get
                ClientBillingAttention = _ClientBillingAttention
            End Get
            Set(value As String)
                _ClientBillingAttention = value
            End Set
        End Property
        Public Property ClientARComment() As String
            Get
                ClientARComment = _ClientARComment
            End Get
            Set(value As String)
                _ClientARComment = value
            End Set
        End Property
        Public Property ClientDaysToPayProduction() As Nullable(Of Short)
            Get
                ClientDaysToPayProduction = _ClientDaysToPayProduction
            End Get
            Set(value As Nullable(Of Short))
                _ClientDaysToPayProduction = value
            End Set
        End Property
        Public Property ClientDaysToPayMedia() As Nullable(Of Short)
            Get
                ClientDaysToPayMedia = _ClientDaysToPayMedia
            End Get
            Set(value As Nullable(Of Short))
                _ClientDaysToPayMedia = value
            End Set
        End Property
        Public Property DaysToPayActual() As Nullable(Of Integer)
            Get
                DaysToPayActual = _DaysToPayActual
            End Get
            Set(value As Nullable(Of Integer))
                _DaysToPayActual = value
            End Set
        End Property
        Public Property DaysToPayActualProd() As Nullable(Of Integer)
            Get
                DaysToPayActualProd = _DaysToPayActualProd
            End Get
            Set(value As Nullable(Of Integer))
                _DaysToPayActualProd = value
            End Set
        End Property
        Public Property DaysToPayActualMedia() As Nullable(Of Integer)
            Get
                DaysToPayActualMedia = _DaysToPayActualMedia
            End Get
            Set(value As Nullable(Of Integer))
                _DaysToPayActualMedia = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = value
            End Set
        End Property
        Public Property DivisionStatementAddress1() As String
            Get
                DivisionStatementAddress1 = _DivisionStatementAddress1
            End Get
            Set(value As String)
                _DivisionStatementAddress1 = value
            End Set
        End Property
        Public Property DivisionStatementAddress2() As String
            Get
                DivisionStatementAddress2 = _DivisionStatementAddress2
            End Get
            Set(value As String)
                _DivisionStatementAddress2 = value
            End Set
        End Property
        Public Property DivisionStatementCityStateZip() As String
            Get
                DivisionStatementCityStateZip = _DivisionStatementCityStateZip
            End Get
            Set(value As String)
                _DivisionStatementCityStateZip = value
            End Set
        End Property
        Public Property DivisionStatementCountry() As String
            Get
                DivisionStatementCountry = _DivisionStatementCountry
            End Get
            Set(value As String)
                _DivisionStatementCountry = value
            End Set
        End Property
        Public Property DivisionBillingAddress1() As String
            Get
                DivisionBillingAddress1 = _DivisionBillingAddress1
            End Get
            Set(value As String)
                _DivisionBillingAddress1 = value
            End Set
        End Property
        Public Property DivisionBillingAddress2() As String
            Get
                DivisionBillingAddress2 = _DivisionBillingAddress2
            End Get
            Set(value As String)
                _DivisionBillingAddress2 = value
            End Set
        End Property
        Public Property DivisionBillingCityStateZip() As String
            Get
                DivisionBillingCityStateZip = _DivisionBillingCityStateZip
            End Get
            Set(value As String)
                _DivisionBillingCityStateZip = value
            End Set
        End Property
        Public Property DivisionBillingCountry() As String
            Get
                DivisionBillingCountry = _DivisionBillingCountry
            End Get
            Set(value As String)
                _DivisionBillingCountry = value
            End Set
        End Property
        Public Property DivisionBillingAttention() As String
            Get
                DivisionBillingAttention = _DivisionBillingAttention
            End Get
            Set(value As String)
                _DivisionBillingAttention = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        Public Property ProductStatementAddress1() As String
            Get
                ProductStatementAddress1 = _ProductStatementAddress1
            End Get
            Set(value As String)
                _ProductStatementAddress1 = value
            End Set
        End Property
        Public Property ProductStatementAddress2() As String
            Get
                ProductStatementAddress2 = _ProductStatementAddress2
            End Get
            Set(value As String)
                _ProductStatementAddress2 = value
            End Set
        End Property
        Public Property ProductStatementCityStateZip() As String
            Get
                ProductStatementCityStateZip = _ProductStatementCityStateZip
            End Get
            Set(value As String)
                _ProductStatementCityStateZip = value
            End Set
        End Property
        Public Property ProductStatementCountry() As String
            Get
                ProductStatementCountry = _ProductStatementCountry
            End Get
            Set(value As String)
                _ProductStatementCountry = value
            End Set
        End Property
        Public Property ProductBillingAddress1() As String
            Get
                ProductBillingAddress1 = _ProductBillingAddress1
            End Get
            Set(value As String)
                _ProductBillingAddress1 = value
            End Set
        End Property
        Public Property ProductBillingAddress2() As String
            Get
                ProductBillingAddress2 = _ProductBillingAddress2
            End Get
            Set(value As String)
                _ProductBillingAddress2 = value
            End Set
        End Property
        Public Property ProductBillingCityStateZip() As String
            Get
                ProductBillingCityStateZip = _ProductBillingCityStateZip
            End Get
            Set(value As String)
                _ProductBillingCityStateZip = value
            End Set
        End Property
        Public Property ProductBillingCountry() As String
            Get
                ProductBillingCountry = _ProductBillingCountry
            End Get
            Set(value As String)
                _ProductBillingCountry = value
            End Set
        End Property
        Public Property ProductBillingAttention() As String
            Get
                ProductBillingAttention = _ProductBillingAttention
            End Get
            Set(value As String)
                _ProductBillingAttention = value
            End Set
        End Property
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = value
            End Set
        End Property
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = value
            End Set
        End Property
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = value
            End Set
        End Property
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = value
            End Set
        End Property
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ARGLXact() As Integer?
            Get
                ARGLXact = _ARGLXact
            End Get
            Set(value As Integer?)
                _ARGLXact = value
            End Set
        End Property
        Public Property ARGLSequenceNumber() As Short?
            Get
                ARGLSequenceNumber = _ARGLSequenceNumber
            End Get
            Set(value As Short?)
                _ARGLSequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        Public Property InvoiceSequence() As String
            Get
                InvoiceSequence = _InvoiceSequence
            End Get
            Set(value As String)
                _InvoiceSequence = value
            End Set
        End Property
        Public Property InvoicePostingPeriod() As String
            Get
                InvoicePostingPeriod = _InvoicePostingPeriod
            End Get
            Set(value As String)
                _InvoicePostingPeriod = value
            End Set
        End Property
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        Public Property InvoiceDueDate() As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="d")>
        Public Property PostedToSummary() As Nullable(Of Date)
            Get
                PostedToSummary = _PostedToSummary
            End Get
            Set(value As Nullable(Of Date))
                _PostedToSummary = value
            End Set
        End Property
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = value
            End Set
        End Property
        Public Property InvoiceRecordType() As String
            Get
                InvoiceRecordType = _InvoiceRecordType
            End Get
            Set(value As String)
                _InvoiceRecordType = value
            End Set
        End Property
        Public Property InvoiceCategory() As String
            Get
                InvoiceCategory = _InvoiceCategory
            End Get
            Set(value As String)
                _InvoiceCategory = value
            End Set
        End Property
        Public Property InvoiceComments() As String
            Get
                InvoiceComments = _InvoiceComments
            End Get
            Set(value As String)
                _InvoiceComments = value
            End Set
        End Property
        Public Property ARCollectionNotes() As String
            Get
                ARCollectionNotes = _ARCollectionNotes
            End Get
            Set(value As String)
                _ARCollectionNotes = value
            End Set
        End Property
        Public Property TotalInvoiceAmount() As Nullable(Of Decimal)
            Get
                TotalInvoiceAmount = _TotalInvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalInvoiceAmount = value
            End Set
        End Property
        Public Property CashReceipts() As Nullable(Of Decimal)
            Get
                CashReceipts = _CashReceipts
            End Get
            Set(value As Nullable(Of Decimal))
                _CashReceipts = value
            End Set
        End Property
        Public Property CRAdjustments() As Nullable(Of Decimal)
            Get
                CRAdjustments = _CRAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _CRAdjustments = value
            End Set
        End Property
        Public Property TotalReceiptsAndAdjustments() As Nullable(Of Decimal)
            Get
                TotalReceiptsAndAdjustments = _TotalReceiptsAndAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalReceiptsAndAdjustments = value
            End Set
        End Property
        Public Property InvoiceBalance() As Nullable(Of Decimal)
            Get
                InvoiceBalance = _InvoiceBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalance = value
            End Set
        End Property
        Public Property Days() As Nullable(Of Integer)
            Get
                Days = _Days
            End Get
            Set(value As Nullable(Of Integer))
                _Days = value
            End Set
        End Property
        Public Property Current() As Nullable(Of Decimal)
            Get
                Current = _Current
            End Get
            Set(value As Nullable(Of Decimal))
                _Current = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging Over 30 Days")>
        Public Property Aging30Days() As Nullable(Of Decimal)
            Get
                Aging30Days = _Aging30Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging30Days = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging Over 60 Days")>
        Public Property Aging60Days() As Nullable(Of Decimal)
            Get
                Aging60Days = _Aging60Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging60Days = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging Over 90 Days")>
        Public Property Aging90Days() As Nullable(Of Decimal)
            Get
                Aging90Days = _Aging90Days
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging90Days = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Aging Over 120 Plus Days")>
        Public Property Aging120PlusDays() As Nullable(Of Decimal)
            Get
                Aging120PlusDays = _Aging120PlusDays
            End Get
            Set(value As Nullable(Of Decimal))
                _Aging120PlusDays = value
            End Set
        End Property
        Public Property OnAccountBalance() As Nullable(Of Decimal)
            Get
                OnAccountBalance = _OnAccountBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _OnAccountBalance = value
            End Set
        End Property
        Public Property InvoiceBalanceWithOA() As Nullable(Of Decimal)
            Get
                InvoiceBalanceWithOA = _InvoiceBalanceWithOA
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalanceWithOA = value
            End Set
        End Property
        Public Property AbsoluteAmount() As Nullable(Of Decimal)
            Get
                AbsoluteAmount = _AbsoluteAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AbsoluteAmount = value
            End Set
        End Property
        Public Property DebitOrCredit() As String
            Get
                DebitOrCredit = _DebitOrCredit
            End Get
            Set(value As String)
                _DebitOrCredit = value
            End Set
        End Property
        Public Property JobOrderNumberListing() As String
            Get
                JobOrderNumberListing = _JobOrderNumberListing
            End Get
            Set(value As String)
                _JobOrderNumberListing = value
            End Set
        End Property
        Public Property CRCheckNumberListing() As String
            Get
                CRCheckNumberListing = _CRCheckNumberListing
            End Get
            Set(value As String)
                _CRCheckNumberListing = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = value
            End Set
        End Property
        Public Property ClientPOProduction() As String
            Get
                ClientPOProduction = _ClientPOProduction
            End Get
            Set(value As String)
                _ClientPOProduction = value
            End Set
        End Property
        Public Property JobType() As String
            Get
                JobType = _JobType
            End Get
            Set(value As String)
                _JobType = value
            End Set
        End Property
        Public Property JobContact() As String
            Get
                JobContact = _JobContact
            End Get
            Set(value As String)
                _JobContact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        Public Property ClientPOMedia() As String
            Get
                ClientPOMedia = _ClientPOMedia
            End Get
            Set(value As String)
                _ClientPOMedia = value
            End Set
        End Property
        Public Property MediaDates() As String
            Get
                MediaDates = _MediaDates
            End Get
            Set(value As String)
                _MediaDates = value
            End Set
        End Property
        Public Property InvoiceTypeDescription() As String
            Get
                InvoiceTypeDescription = _InvoiceTypeDescription
            End Get
            Set(value As String)
                _InvoiceTypeDescription = value
            End Set
        End Property
        Public Property PartialPaymentIndicator() As String
            Get
                PartialPaymentIndicator = _PartialPaymentIndicator
            End Get
            Set(value As String)
                _PartialPaymentIndicator = value
            End Set
        End Property
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        Public Property CampaignComment() As String
            Get
                CampaignComment = _CampaignComment
            End Get
            Set(value As String)
                _CampaignComment = value
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
