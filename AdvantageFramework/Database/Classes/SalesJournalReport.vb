Namespace Database.Classes

    <Serializable()>
    Public Class SalesJournalReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            ClientAddress
            ClientAddress2
            ClientCity
            ClientCounty
            ClientState
            ClientZip
            ClientCountry
            ClientBillingAddress
            ClientBillingAddress2
            ClientBillingCity
            ClientBillingCounty
            ClientBillingState
            ClientBillingZip
            ClientBillingCountry
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ProductBillingAddress
            ProductBillingAddress2
            ProductBillingCity
            ProductBillingCounty
            ProductBillingState
            ProductBillingZip
            ProductBillingCountry
            DefaultAECode
            DefaultAEName
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            ARPostPeriod
            ARPostPeriodStartDate
            ARPostPeriodEndDate
            ARPostPeriodDescription
            ARPostPeriodGLMonth
            ARPostPeriodGLYear
            SalePostPeriod
            SalePostPeriodStartDate
            SalePostPeriodEndDate
            SalePostPeriodDescription
            SalePostPeriodGLMonth
            SalePostPeriodGLYear
            InvoiceDate
            InvoiceNumber
            InvoiceSEQ
            InvoiceType
            InvoiceDescription
            InvoiceAssignBy
            InvoiceCategory
            InvoiceDueDate
            MediaType
            MediaTypeDescription
            ManualFlag
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignDescription
            ClientPO
            AccountExecutiveCode
            AccountExecutive
            JobNumber
            JobDescription
            JobComponent
            JobComponentDescription
            FunctionType
            FunctionCode
            FunctionDescription
            FunctionHeadingDescription
            OrderNumber
            OrderLine
            MediaMonth
            MediaYear
            MediaStartDate
            MediaEndDate
            MediaMarket
            MediaMarketDescription
            InvoiceTotal
            Sales
            CostOfSales
            GrossIncome
            DeferredSales
            DeferredCostOfSales
            DeferredGrossIncome
            HoursOrQuantity
            Time
            IncomeOnly
            Commission
            Cost
            VendorTax
            MediaNetCharge
            MediaRebate
            MediaAdditionalCharge
            MediaDiscount
            AdvanceIncome
            AdvanceCommission
            AdvanceCost
            AdvanceRetainedSales
            AdvanceNonresaleAmount
            TotalBillLessResaleTax
            CityTax
            CountyTax
            StateTax
            ResaleTax
            TotalBill
            TaxAtBilling
            TaxCode
            CityTaxPct
            CountyTaxPct
            StateTaxPct
            GLXACT
            GLXACTDeferred
            GLAccountAR
            GLAccountARDescription
            GLAccountSales
            GLAccountSalesDescription
            GLAccountDeferredSales
            GLAccountDeferredSalesDescription
            GLAccountCostOfSales
            GLAccountCostOfSalesDescription
            GLAccountAccruedAP
            GLAccountAccruedAPDescription
            GLAccountAccruedCOS
            GLAccountAccruedCOSDescription
            GLAccountWIP
            GLAccountWIPDescription
            GLAccountCityTax
            GLAccountCityTaxDescription
            GLAccountCountyTax
            GLAccountCountyTaxDescription
            GLAccountStateTax
            GLAccountStateTaxDescription
            Converted
            OrderDescription
            VendorCode
            VendorName
            CreateDate
            UserID
            IsVoided
            VoidComment
            FiscalMonth
            'BillingComment
            'BillingJobComment
            'BillingDetailComment
            'BillingApprovalClientComment
            'BillingApprovalFunctionComment
            'CampaignComments
            ClientReference
            'JobComment
            'JobComponentComment
            EstimateNumber
            EstimateComponentNumber
            'EstimateComment
            'EstimateComponentComment
            'EstimateQuoteComment
            'EstimateRevisionComment
            'EstimateFunctionComment
            'InvoiceFooterComment
            BillingAddress
            JobTypeCode
            JobTypeDescription
            JobMediaDateToBill
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _ClientAddress As String = Nothing
        Private _ClientAddress2 As String = Nothing
        Private _ClientCity As String = Nothing
        Private _ClientCounty As String = Nothing
        Private _ClientState As String = Nothing
        Private _ClientZip As String = Nothing
        Private _ClientCountry As String = Nothing
        Private _ClientBillingAddress As String = Nothing
        Private _ClientBillingAddress2 As String = Nothing
        Private _ClientBillingCity As String = Nothing
        Private _ClientBillingCounty As String = Nothing
        Private _ClientBillingState As String = Nothing
        Private _ClientBillingZip As String = Nothing
        Private _ClientBillingCountry As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ProductBillingAddress As String = Nothing
        Private _ProductBillingAddress2 As String = Nothing
        Private _ProductBillingCity As String = Nothing
        Private _ProductBillingCounty As String = Nothing
        Private _ProductBillingState As String = Nothing
        Private _ProductBillingZip As String = Nothing
        Private _ProductBillingCountry As String = Nothing
        Private _DefaultAECode As String = Nothing
        Private _DefaultAEName As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _ARPostPeriod As String = Nothing
        Private _ARPostPeriodStartDate As Nullable(Of Date) = Nothing
        Private _ARPostPeriodEndDate As Nullable(Of Date) = Nothing
        Private _ARPostPeriodDescription As String = Nothing
        Private _ARPostPeriodGLMonth As Nullable(Of Short) = Nothing
        Private _ARPostPeriodGLYear As String = Nothing
        Private _SalePostPeriod As String = Nothing
        Private _SalePostPeriodStartDate As Nullable(Of Date) = Nothing
        Private _SalePostPeriodEndDate As Nullable(Of Date) = Nothing
        Private _SalePostPeriodDescription As String = Nothing
        Private _SalePostPeriodGLMonth As Nullable(Of Short) = Nothing
        Private _SalePostPeriodGLYear As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSEQ As Nullable(Of Short) = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceAssignBy As String = Nothing
        Private _InvoiceCategory As String = Nothing
        Private _InvoiceDueDate As Nullable(Of Date) = Nothing
        Private _MediaType As String = Nothing
        Private _MediaTypeDescription As String = Nothing
        Private _ManualFlag As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _ClientPO As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponent As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLine As Nullable(Of Short) = Nothing
        Private _MediaMonth As Nullable(Of Short) = Nothing
        Private _MediaYear As Nullable(Of Short) = Nothing
        Private _MediaStartDate As Nullable(Of Date) = Nothing
        Private _MediaEndDate As Nullable(Of Date) = Nothing
        Private _MediaMarket As String = Nothing
        Private _MediaMarketDescription As String = Nothing
        Private _InvoiceTotal As Nullable(Of Decimal) = Nothing
        Private _Sales As Nullable(Of Decimal) = Nothing
        Private _CostOfSales As Nullable(Of Decimal) = Nothing
        Private _GrossIncome As Nullable(Of Decimal) = Nothing
        Private _DeferredSales As Nullable(Of Decimal) = Nothing
        Private _DeferredCostOfSales As Nullable(Of Decimal) = Nothing
        Private _DeferredGrossIncome As Nullable(Of Decimal) = Nothing
        Private _HoursOrQuantity As Nullable(Of Decimal) = Nothing
        Private _Time As Nullable(Of Decimal) = Nothing
        Private _IncomeOnly As Nullable(Of Decimal) = Nothing
        Private _Commission As Nullable(Of Decimal) = Nothing
        Private _Cost As Nullable(Of Decimal) = Nothing
        Private _VendorTax As Nullable(Of Decimal) = Nothing
        Private _MediaNetCharge As Nullable(Of Decimal) = Nothing
        Private _MediaRebate As Nullable(Of Decimal) = Nothing
        Private _MediaAdditionalCharge As Nullable(Of Decimal) = Nothing
        Private _MediaDiscount As Nullable(Of Decimal) = Nothing
        Private _AdvanceIncome As Nullable(Of Decimal) = Nothing
        Private _AdvanceCommission As Nullable(Of Decimal) = Nothing
        Private _AdvanceCost As Nullable(Of Decimal) = Nothing
        Private _AdvanceRetainedSales As Nullable(Of Decimal) = Nothing
        Private _AdvanceNonresaleAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBillLessResaleTax As Nullable(Of Decimal) = Nothing
        Private _CityTax As Nullable(Of Decimal) = Nothing
        Private _CountyTax As Nullable(Of Decimal) = Nothing
        Private _StateTax As Nullable(Of Decimal) = Nothing
        Private _ResaleTax As Nullable(Of Decimal) = Nothing
        Private _TotalBill As Nullable(Of Decimal) = Nothing
        Private _TaxAtBilling As String = Nothing
        Private _TaxCode As String = Nothing
        Private _CityTaxPct As Nullable(Of Decimal) = Nothing
        Private _CountyTaxPct As Nullable(Of Decimal) = Nothing
        Private _StateTaxPct As Nullable(Of Decimal) = Nothing
        Private _GLXACT As Nullable(Of Integer) = Nothing
        Private _GLXACTDeferred As Nullable(Of Integer) = Nothing
        Private _GLAccountAR As String = Nothing
        Private _GLAccountARDescription As String = Nothing
        Private _GLAccountSales As String = Nothing
        Private _GLAccountSalesDescription As String = Nothing
        Private _GLAccountDeferredSales As String = Nothing
        Private _GLAccountDeferredSalesDescription As String = Nothing
        Private _GLAccountCostOfSales As String = Nothing
        Private _GLAccountCostOfSalesDescription As String = Nothing
        Private _GLAccountAccruedAP As String = Nothing
        Private _GLAccountAccruedAPDescription As String = Nothing
        Private _GLAccountAccruedCOS As String = Nothing
        Private _GLAccountAccruedCOSDescription As String = Nothing
        Private _GLAccountWIP As String = Nothing
        Private _GLAccountWIPDescription As String = Nothing
        Private _GLAccountCityTax As String = Nothing
        Private _GLAccountCityTaxDescription As String = Nothing
        Private _GLAccountCountyTax As String = Nothing
        Private _GLAccountCountyTaxDescription As String = Nothing
        Private _GLAccountStateTax As String = Nothing
        Private _GLAccountStateTaxDescription As String = Nothing
        Private _Converted As String = Nothing
        Private _OrderDescription As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _CreateDate As Nullable(Of Date) = Nothing
        Private _UserID As String = Nothing
        Private _IsVoided As String = Nothing
        Private _VoidComment As String = Nothing
        Private _FiscalMonth As Nullable(Of Short) = Nothing
        'Private _BillingComment As String = Nothing
        'Private _BillingJobComment As String = Nothing
        'Private _BillingDetailComment As String = Nothing
        'Private _BillingApprovalClientComment As String = Nothing
        'Private _BillingApprovalFunctionComment As String = Nothing
        'Private _CampaignComments As String = Nothing
        Private _ClientReference As String = Nothing
        'Private _JobComment As String = Nothing
        'Private _JobComponentComment As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing
        'Private _EstimateComment As String = Nothing
        'Private _EstimateComponentComment As String = Nothing
        'Private _EstimateQuoteComment As String = Nothing
        'Private _EstimateRevisionComment As String = Nothing
        'Private _EstimateFunctionComment As String = Nothing
        'Private _InvoiceFooterComment As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _JobMediaDateToBill As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(ByVal value As String)
                _OfficeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientAddress() As String
            Get
                ClientAddress = _ClientAddress
            End Get
            Set(ByVal value As String)
                _ClientAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientAddress2() As String
            Get
                ClientAddress2 = _ClientAddress2
            End Get
            Set(ByVal value As String)
                _ClientAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCity() As String
            Get
                ClientCity = _ClientCity
            End Get
            Set(ByVal value As String)
                _ClientCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCounty() As String
            Get
                ClientCounty = _ClientCounty
            End Get
            Set(ByVal value As String)
                _ClientCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientState() As String
            Get
                ClientState = _ClientState
            End Get
            Set(ByVal value As String)
                _ClientState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientZip() As String
            Get
                ClientZip = _ClientZip
            End Get
            Set(ByVal value As String)
                _ClientZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCountry() As String
            Get
                ClientCountry = _ClientCountry
            End Get
            Set(ByVal value As String)
                _ClientCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingAddress() As String
            Get
                ClientBillingAddress = _ClientBillingAddress
            End Get
            Set(ByVal value As String)
                _ClientBillingAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingAddress2() As String
            Get
                ClientBillingAddress2 = _ClientBillingAddress2
            End Get
            Set(ByVal value As String)
                _ClientBillingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCity() As String
            Get
                ClientBillingCity = _ClientBillingCity
            End Get
            Set(ByVal value As String)
                _ClientBillingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCounty() As String
            Get
                ClientBillingCounty = _ClientBillingCounty
            End Get
            Set(ByVal value As String)
                _ClientBillingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingState() As String
            Get
                ClientBillingState = _ClientBillingState
            End Get
            Set(ByVal value As String)
                _ClientBillingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingZip() As String
            Get
                ClientBillingZip = _ClientBillingZip
            End Get
            Set(ByVal value As String)
                _ClientBillingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCountry() As String
            Get
                ClientBillingCountry = _ClientBillingCountry
            End Get
            Set(ByVal value As String)
                _ClientBillingCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingAddress() As String
            Get
                ProductBillingAddress = _ProductBillingAddress
            End Get
            Set(ByVal value As String)
                _ProductBillingAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingAddress2() As String
            Get
                ProductBillingAddress2 = _ProductBillingAddress2
            End Get
            Set(ByVal value As String)
                _ProductBillingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCity() As String
            Get
                ProductBillingCity = _ProductBillingCity
            End Get
            Set(ByVal value As String)
                _ProductBillingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCounty() As String
            Get
                ProductBillingCounty = _ProductBillingCounty
            End Get
            Set(ByVal value As String)
                _ProductBillingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingState() As String
            Get
                ProductBillingState = _ProductBillingState
            End Get
            Set(ByVal value As String)
                _ProductBillingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingZip() As String
            Get
                ProductBillingZip = _ProductBillingZip
            End Get
            Set(ByVal value As String)
                _ProductBillingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCountry() As String
            Get
                ProductBillingCountry = _ProductBillingCountry
            End Get
            Set(ByVal value As String)
                _ProductBillingCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAECode() As String
            Get
                DefaultAECode = _DefaultAECode
            End Get
            Set(value As String)
                _DefaultAECode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAEName() As String
            Get
                DefaultAEName = _DefaultAEName
            End Get
            Set(value As String)
                _DefaultAEName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AR Post Period")>
        Public Property ARPostPeriod As String
            Get
                ARPostPeriod = _ARPostPeriod
            End Get
            Set(ByVal value As String)
                _ARPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriodStartDate As Nullable(Of Date)
            Get
                ARPostPeriodStartDate = _ARPostPeriodStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ARPostPeriodStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriodEndDate As Nullable(Of Date)
            Get
                ARPostPeriodEndDate = _ARPostPeriodEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ARPostPeriodEndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriodDescription As String
            Get
                ARPostPeriodDescription = _ARPostPeriodDescription
            End Get
            Set(ByVal value As String)
                _ARPostPeriodDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriodGLMonth As Nullable(Of Short)
            Get
                ARPostPeriodGLMonth = _ARPostPeriodGLMonth
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ARPostPeriodGLMonth = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriodGLYear As String
            Get
                ARPostPeriodGLYear = _ARPostPeriodGLYear
            End Get
            Set(ByVal value As String)
                _ARPostPeriodGLYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Post Period")>
        Public Property SalePostPeriod As String
            Get
                SalePostPeriod = _SalePostPeriod
            End Get
            Set(ByVal value As String)
                _SalePostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalePostPeriodStartDate As Nullable(Of Date)
            Get
                SalePostPeriodStartDate = _SalePostPeriodStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _SalePostPeriodStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalePostPeriodEndDate As Nullable(Of Date)
            Get
                SalePostPeriodEndDate = _SalePostPeriodEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _SalePostPeriodEndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalePostPeriodDescription As String
            Get
                SalePostPeriodDescription = _SalePostPeriodDescription
            End Get
            Set(ByVal value As String)
                _SalePostPeriodDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalePostPeriodGLMonth As Nullable(Of Short)
            Get
                SalePostPeriodGLMonth = _SalePostPeriodGLMonth
            End Get
            Set(ByVal value As Nullable(Of Short))
                _SalePostPeriodGLMonth = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalePostPeriodGLYear As String
            Get
                SalePostPeriodGLYear = _SalePostPeriodGLYear
            End Get
            Set(ByVal value As String)
                _SalePostPeriodGLYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property InvoiceNumber As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Invoice SEQ")>
        Public Property InvoiceSEQ As Nullable(Of Short)
            Get
                InvoiceSEQ = _InvoiceSEQ
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceSEQ = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceType As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(ByVal value As String)
                _InvoiceType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDescription As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(ByVal value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceAssignBy As String
            Get
                InvoiceAssignBy = _InvoiceAssignBy
            End Get
            Set(ByVal value As String)
                _InvoiceAssignBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceCategory As String
            Get
                InvoiceCategory = _InvoiceCategory
            End Get
            Set(ByVal value As String)
                _InvoiceCategory = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDueDate As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType As String
            Get
                MediaType = _MediaType
            End Get
            Set(ByVal value As String)
                _MediaType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaTypeDescription As String
            Get
                MediaTypeDescription = _MediaTypeDescription
            End Get
            Set(ByVal value As String)
                _MediaTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ManualFlag As String
            Get
                ManualFlag = _ManualFlag
            End Get
            Set(ByVal value As String)
                _ManualFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client PO")>
        Public Property ClientPO As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent As Nullable(Of Short)
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingDescription As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLine As Nullable(Of Short)
            Get
                OrderLine = _OrderLine
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OrderLine = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMonth As Nullable(Of Short)
            Get
                MediaMonth = _MediaMonth
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MediaMonth = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property MediaYear As Nullable(Of Short)
            Get
                MediaYear = _MediaYear
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MediaYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaStartDate As Nullable(Of Date)
            Get
                MediaStartDate = _MediaStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _MediaStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaEndDate As Nullable(Of Date)
            Get
                MediaEndDate = _MediaEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _MediaEndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMarket As String
            Get
                MediaMarket = _MediaMarket
            End Get
            Set(ByVal value As String)
                _MediaMarket = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMarketDescription As String
            Get
                MediaMarketDescription = _MediaMarketDescription
            End Get
            Set(ByVal value As String)
                _MediaMarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property InvoiceTotal As Nullable(Of Decimal)
            Get
                InvoiceTotal = _InvoiceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Sales As Nullable(Of Decimal)
            Get
                Sales = _Sales
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Sales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Cost of Sales")>
        Public Property CostOfSales As Nullable(Of Decimal)
            Get
                CostOfSales = _CostOfSales
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CostOfSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GrossIncome As Nullable(Of Decimal)
            Get
                GrossIncome = _GrossIncome
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrossIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DeferredSales As Nullable(Of Decimal)
            Get
                DeferredSales = _DeferredSales
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DeferredSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Deferred Cost of Sales")>
        Public Property DeferredCostOfSales As Nullable(Of Decimal)
            Get
                DeferredCostOfSales = _DeferredCostOfSales
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DeferredCostOfSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DeferredGrossIncome As Nullable(Of Decimal)
            Get
                DeferredGrossIncome = _DeferredGrossIncome
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DeferredGrossIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Hours or Quantity")>
        Public Property HoursOrQuantity As Nullable(Of Decimal)
            Get
                HoursOrQuantity = _HoursOrQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HoursOrQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Time As Nullable(Of Decimal)
            Get
                Time = _Time
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Time = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property IncomeOnly As Nullable(Of Decimal)
            Get
                IncomeOnly = _IncomeOnly
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IncomeOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Commission As Nullable(Of Decimal)
            Get
                Commission = _Commission
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Commission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Cost As Nullable(Of Decimal)
            Get
                Cost = _Cost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Cost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorTax As Nullable(Of Decimal)
            Get
                VendorTax = _VendorTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaNetCharge As Nullable(Of Decimal)
            Get
                MediaNetCharge = _MediaNetCharge
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MediaNetCharge = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaRebate As Nullable(Of Decimal)
            Get
                MediaRebate = _MediaRebate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MediaRebate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaAdditionalCharge As Nullable(Of Decimal)
            Get
                MediaAdditionalCharge = _MediaAdditionalCharge
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MediaAdditionalCharge = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaDiscount As Nullable(Of Decimal)
            Get
                MediaDiscount = _MediaDiscount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MediaDiscount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceIncome As Nullable(Of Decimal)
            Get
                AdvanceIncome = _AdvanceIncome
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceCommission As Nullable(Of Decimal)
            Get
                AdvanceCommission = _AdvanceCommission
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceCost As Nullable(Of Decimal)
            Get
                AdvanceCost = _AdvanceCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceRetainedSales As Nullable(Of Decimal)
            Get
                AdvanceRetainedSales = _AdvanceRetainedSales
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceRetainedSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceNonresaleAmount As Nullable(Of Decimal)
            Get
                AdvanceNonresaleAmount = _AdvanceNonresaleAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceNonresaleAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalBillLessResaleTax As Nullable(Of Decimal)
            Get
                TotalBillLessResaleTax = _TotalBillLessResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBillLessResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CityTax As Nullable(Of Decimal)
            Get
                CityTax = _CityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CountyTax As Nullable(Of Decimal)
            Get
                CountyTax = _CountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property StateTax As Nullable(Of Decimal)
            Get
                StateTax = _StateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ResaleTax As Nullable(Of Decimal)
            Get
                ResaleTax = _ResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalBill As Nullable(Of Decimal)
            Get
                TotalBill = _TotalBill
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxAtBilling As String
            Get
                TaxAtBilling = _TaxAtBilling
            End Get
            Set(ByVal value As String)
                _TaxAtBilling = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(ByVal value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property CityTaxPct As Nullable(Of Decimal)
            Get
                CityTaxPct = _CityTaxPct
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxPct = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property CountyTaxPct As Nullable(Of Decimal)
            Get
                CountyTaxPct = _CountyTaxPct
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxPct = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property StateTaxPct As Nullable(Of Decimal)
            Get
                StateTaxPct = _StateTaxPct
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxPct = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GL XACT")>
        Public Property GLXACT As Nullable(Of Integer)
            Get
                GLXACT = _GLXACT
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GLXACT = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GL XACT Deferred")>
        Public Property GLXACTDeferred As Nullable(Of Integer)
            Get
                GLXACTDeferred = _GLXACTDeferred
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GLXACTDeferred = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account AR")>
        Public Property GLAccountAR As String
            Get
                GLAccountAR = _GLAccountAR
            End Get
            Set(ByVal value As String)
                _GLAccountAR = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account AR Description")>
        Public Property GLAccountARDescription As String
            Get
                GLAccountARDescription = _GLAccountARDescription
            End Get
            Set(ByVal value As String)
                _GLAccountARDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Sales")>
        Public Property GLAccountSales As String
            Get
                GLAccountSales = _GLAccountSales
            End Get
            Set(ByVal value As String)
                _GLAccountSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Sales Description")>
        Public Property GLAccountSalesDescription As String
            Get
                GLAccountSalesDescription = _GLAccountSalesDescription
            End Get
            Set(ByVal value As String)
                _GLAccountSalesDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Deferred Sales")>
        Public Property GLAccountDeferredSales As String
            Get
                GLAccountDeferredSales = _GLAccountDeferredSales
            End Get
            Set(ByVal value As String)
                _GLAccountDeferredSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Deferred Sales Description")>
        Public Property GLAccountDeferredSalesDescription As String
            Get
                GLAccountDeferredSalesDescription = _GLAccountDeferredSalesDescription
            End Get
            Set(ByVal value As String)
                _GLAccountDeferredSalesDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Cost of Sales")>
        Public Property GLAccountCostOfSales As String
            Get
                GLAccountCostOfSales = _GLAccountCostOfSales
            End Get
            Set(ByVal value As String)
                _GLAccountCostOfSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Cost of Sales Description")>
        Public Property GLAccountCostOfSalesDescription As String
            Get
                GLAccountCostOfSalesDescription = _GLAccountCostOfSalesDescription
            End Get
            Set(ByVal value As String)
                _GLAccountCostOfSalesDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued AP")>
        Public Property GLAccountAccruedAP As String
            Get
                GLAccountAccruedAP = _GLAccountAccruedAP
            End Get
            Set(ByVal value As String)
                _GLAccountAccruedAP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued AP Description")>
        Public Property GLAccountAccruedAPDescription As String
            Get
                GLAccountAccruedAPDescription = _GLAccountAccruedAPDescription
            End Get
            Set(ByVal value As String)
                _GLAccountAccruedAPDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued COS")>
        Public Property GLAccountAccruedCOS As String
            Get
                GLAccountAccruedCOS = _GLAccountAccruedCOS
            End Get
            Set(ByVal value As String)
                _GLAccountAccruedCOS = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued COS Description")>
        Public Property GLAccountAccruedCOSDescription As String
            Get
                GLAccountAccruedCOSDescription = _GLAccountAccruedCOSDescription
            End Get
            Set(ByVal value As String)
                _GLAccountAccruedCOSDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account WIP")>
        Public Property GLAccountWIP As String
            Get
                GLAccountWIP = _GLAccountWIP
            End Get
            Set(ByVal value As String)
                _GLAccountWIP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account WIP Description")>
        Public Property GLAccountWIPDescription As String
            Get
                GLAccountWIPDescription = _GLAccountWIPDescription
            End Get
            Set(ByVal value As String)
                _GLAccountWIPDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account City Tax")>
        Public Property GLAccountCityTax As String
            Get
                GLAccountCityTax = _GLAccountCityTax
            End Get
            Set(ByVal value As String)
                _GLAccountCityTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account City Tax Description")>
        Public Property GLAccountCityTaxDescription As String
            Get
                GLAccountCityTaxDescription = _GLAccountCityTaxDescription
            End Get
            Set(ByVal value As String)
                _GLAccountCityTaxDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account County Tax")>
        Public Property GLAccountCountyTax As String
            Get
                GLAccountCountyTax = _GLAccountCountyTax
            End Get
            Set(ByVal value As String)
                _GLAccountCountyTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account County Tax Description")>
        Public Property GLAccountCountyTaxDescription As String
            Get
                GLAccountCountyTaxDescription = _GLAccountCountyTaxDescription
            End Get
            Set(ByVal value As String)
                _GLAccountCountyTaxDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account State Tax")>
        Public Property GLAccountStateTax As String
            Get
                GLAccountStateTax = _GLAccountStateTax
            End Get
            Set(ByVal value As String)
                _GLAccountStateTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account State Tax Description")>
        Public Property GLAccountStateTaxDescription As String
            Get
                GLAccountStateTaxDescription = _GLAccountStateTaxDescription
            End Get
            Set(ByVal value As String)
                _GLAccountStateTaxDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Converted As String
            Get
                Converted = _Converted
            End Get
            Set(ByVal value As String)
                _Converted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderDescription As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(ByVal value As String)
                _OrderDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate As Nullable(Of Date)
            Get
                CreateDate = _CreateDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CreateDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID As String
            Get
                UserID = _UserID
            End Get
            Set(ByVal value As String)
                _UserID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided As String
            Get
                IsVoided = _IsVoided
            End Get
            Set(ByVal value As String)
                _IsVoided = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidComment As String
            Get
                VoidComment = _VoidComment
            End Get
            Set(ByVal value As String)
                _VoidComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalMonth As Nullable(Of Short)
            Get
                FiscalMonth = _FiscalMonth
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FiscalMonth = value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property BillingComment As String
        '    Get
        '        BillingComment = _BillingComment
        '    End Get
        '    Set(ByVal value As String)
        '        _BillingComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property BillingJobComment As String
        '    Get
        '        BillingJobComment = _BillingJobComment
        '    End Get
        '    Set(ByVal value As String)
        '        _BillingJobComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property BillingDetailComment As String
        '    Get
        '        BillingDetailComment = _BillingDetailComment
        '    End Get
        '    Set(ByVal value As String)
        '        _BillingDetailComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property BillingApprovalClientComment As String
        '    Get
        '        BillingApprovalClientComment = _BillingApprovalClientComment
        '    End Get
        '    Set(ByVal value As String)
        '        _BillingApprovalClientComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property BillingApprovalFunctionComment As String
        '    Get
        '        BillingApprovalFunctionComment = _BillingApprovalFunctionComment
        '    End Get
        '    Set(ByVal value As String)
        '        _BillingApprovalFunctionComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property CampaignComments As String
        '    Get
        '        CampaignComments = _CampaignComments
        '    End Get
        '    Set(ByVal value As String)
        '        _CampaignComments = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property JobComment As String
        '    Get
        '        JobComment = _JobComment
        '    End Get
        '    Set(ByVal value As String)
        '        _JobComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property JobComponentComment As String
        '    Get
        '        JobComponentComment = _JobComponentComment
        '    End Get
        '    Set(ByVal value As String)
        '        _JobComponentComment = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateNumber As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimateComponentNumber = value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EstimateComment As String
        '    Get
        '        EstimateComment = _EstimateComment
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EstimateComponentComment As String
        '    Get
        '        EstimateComponentComment = _EstimateComponentComment
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateComponentComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EstimateQuoteComment As String
        '    Get
        '        EstimateQuoteComment = _EstimateQuoteComment
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateQuoteComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EstimateRevisionComment As String
        '    Get
        '        EstimateRevisionComment = _EstimateRevisionComment
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateRevisionComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EstimateFunctionComment As String
        '    Get
        '        EstimateFunctionComment = _EstimateFunctionComment
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateFunctionComment = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property InvoiceFooterComment As String
        '    Get
        '        InvoiceFooterComment = _InvoiceFooterComment
        '    End Get
        '    Set(ByVal value As String)
        '        _InvoiceFooterComment = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Avatax Address")>
        Public Property BillingAddress As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeCode As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(ByVal value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobMediaDateToBill As Nullable(Of Date)
            Get
                JobMediaDateToBill = _JobMediaDateToBill
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobMediaDateToBill = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
