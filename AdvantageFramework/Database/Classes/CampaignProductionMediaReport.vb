Namespace Database.Classes

    <Serializable()>
    Public Class CampaignProductionMediaReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            ClientCity
            ClientState
            DivisionCode
            DivisionDescription
            DivisionCity
            DivisionState
            ProductCode
            ProductDescription
            ProductCity
            ProductState
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            AccountExecutiveCode
            AccountExecutive
            CampaignID
            CampaignCode
            CampaignName
            BillingBudget
            IncomeBudget
            MarketCode
            MarketDescription
            FiscalPeriodCode
            FiscalPeriodDescription
            SalesClassCode
            SalesClassDescription
            JobNumber
            JobComponentNumber
            JobComponent
            JobDescription
            ComponentDescription
            OrderNumber
            OrderDescription
            ClientPO
            Hours
            NetAmount
            Commission
            BillingAmountLessResale
            BilledAmountLessResale
            BilledAmount
            BilledCost
            BilledIncome
            UnbilledAmountLessResale
            UnbilledAmount
            ResaleTaxAmount
            Total
            TotalLessResale
            ClientBudgetBillingAmount
            ClientBudgetIncomeAmount
            EstimateHours
            EstimateQuantity
            EstimateTotalAmount
            EstimateContTotalAmount
            EstimateNonResaleTaxAmount
            EstimateResaleTaxAmount
            EstimateMarkupAmount
            EstimateCostAmount
            EstimateNetAmount
            CampaignEstimateHours
            CampaignEstimateQuantity
            CampaignEstimateTotalAmount
            CampaignEstimateContTotalAmount
            CampaignEstimateNonResaleTaxAmount
            CampaignEstimateResaleTaxAmount
            CampaignEstimateMarkupAmount
            CampaignEstimateCostAmount
            CampaignEstimateNetAmount
            Type
            AccountsReceivablePostingPeriod
            Year
            Month
            JobCreatedDate
            JobStartDate
            JobDueDate
            CampaignComments

        End Enum

#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _ClientCity As String = Nothing
        Private _ClientState As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _DivisionCity As String = Nothing
        Private _DivisionState As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductCity As String = Nothing
        Private _ProductState As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _BillingBudget As Nullable(Of Decimal) = Nothing
        Private _IncomeBudget As Nullable(Of Decimal) = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _FiscalPeriodCode As String = Nothing
        Private _FiscalPeriodDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponent As String = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _Commission As Nullable(Of Decimal) = Nothing
        Private _BillingAmountLessResale As Nullable(Of Decimal) = Nothing
        Private _BilledAmountLessResale As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _BilledCost As Nullable(Of Decimal) = Nothing
        Private _BilledIncome As Nullable(Of Decimal) = Nothing
        Private _UnbilledAmountLessResale As Nullable(Of Decimal) = Nothing
        Private _UnbilledAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _Total As Nullable(Of Decimal) = Nothing
        Private _TotalLessResale As Nullable(Of Decimal) = Nothing
        Private _ClientBudgetBillingAmount As Nullable(Of Decimal) = Nothing
        Private _ClientBudgetIncomeAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateHours As Nullable(Of Decimal) = Nothing
        Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateContTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCostAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateHours As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateContTotalAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateNonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateCostAmount As Nullable(Of Decimal) = Nothing
        Private _CampaignEstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _Type As String = Nothing
        Private _AccountsReceivablePostingPeriod As String = Nothing
        Private _Year As Nullable(Of Short) = Nothing
        Private _Month As String = Nothing
        Private _JobCreatedDate As Nullable(Of Date) = Nothing
        Private _JobStartDate As Nullable(Of Date) = Nothing
        Private _JobDueDate As Nullable(Of Date) = Nothing
        Private _CampaignComments As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(ByVal value As String)
                _OfficeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
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
        Public Property ClientState() As String
            Get
                ClientState = _ClientState
            End Get
            Set(ByVal value As String)
                _ClientState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCity() As String
            Get
                DivisionCity = _DivisionCity
            End Get
            Set(ByVal value As String)
                _DivisionCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionState() As String
            Get
                DivisionState = _DivisionState
            End Get
            Set(ByVal value As String)
                _DivisionState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCity() As String
            Get
                ProductCity = _ProductCity
            End Get
            Set(ByVal value As String)
                _ProductCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductState() As String
            Get
                ProductState = _ProductState
            End Get
            Set(ByVal value As String)
                _ProductState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(ByVal value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(ByVal value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(ByVal value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(ByVal value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillingBudget() As Nullable(Of Decimal)
            Get
                BillingBudget = _BillingBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillingBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property IncomeBudget() As Nullable(Of Decimal)
            Get
                IncomeBudget = _IncomeBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IncomeBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(ByVal value As String)
                _MarketCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(ByVal value As String)
                _MarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set(ByVal value As String)
                _FiscalPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodDescription() As String
            Get
                FiscalPeriodDescription = _FiscalPeriodDescription
            End Get
            Set(ByVal value As String)
                _FiscalPeriodDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(ByVal value As String)
                _OrderDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Commission() As Nullable(Of Decimal)
            Get
                Commission = _Commission
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Commission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillingAmountLessResale() As Nullable(Of Decimal)
            Get
                BillingAmountLessResale = _BillingAmountLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillingAmountLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAmountLessResale() As Nullable(Of Decimal)
            Get
                BilledAmountLessResale = _BilledAmountLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledAmountLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledCost() As Nullable(Of Decimal)
            Get
                BilledCost = _BilledCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledIncome() As Nullable(Of Decimal)
            Get
                BilledIncome = _BilledIncome
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledAmountLessResale() As Nullable(Of Decimal)
            Get
                UnbilledAmountLessResale = _UnbilledAmountLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnbilledAmountLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledAmount() As Nullable(Of Decimal)
            Get
                UnbilledAmount = _UnbilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnbilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Total() As Nullable(Of Decimal)
            Get
                Total = _Total
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Total = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalLessResale() As Nullable(Of Decimal)
            Get
                TotalLessResale = _TotalLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBudgetBillingAmount() As Nullable(Of Decimal)
            Get
                ClientBudgetBillingAmount = _ClientBudgetBillingAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientBudgetBillingAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBudgetIncomeAmount() As Nullable(Of Decimal)
            Get
                ClientBudgetIncomeAmount = _ClientBudgetIncomeAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientBudgetIncomeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateHours() As Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Nullable(Of Decimal)
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateContTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateContTotalAmount = _EstimateContTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateNonResaleTaxAmount = _EstimateNonResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNonResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateResaleTaxAmount = _EstimateResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCostAmount() As Nullable(Of Decimal)
            Get
                EstimateCostAmount = _EstimateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNetAmount() As Nullable(Of Decimal)
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateHours() As Nullable(Of Decimal)
            Get
                CampaignEstimateHours = _CampaignEstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateQuantity() As Nullable(Of Decimal)
            Get
                CampaignEstimateQuantity = _CampaignEstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateTotalAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateTotalAmount = _CampaignEstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateContTotalAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateContTotalAmount = _CampaignEstimateContTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateContTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateNonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateNonResaleTaxAmount = _CampaignEstimateNonResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateNonResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateResaleTaxAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateResaleTaxAmount = _CampaignEstimateResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateMarkupAmount = _CampaignEstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateCostAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateCostAmount = _CampaignEstimateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CampaignEstimateNetAmount() As Nullable(Of Decimal)
            Get
                CampaignEstimateNetAmount = _CampaignEstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CampaignEstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountsReceivablePostingPeriod() As String
            Get
                AccountsReceivablePostingPeriod = _AccountsReceivablePostingPeriod
            End Get
            Set(ByVal value As String)
                _AccountsReceivablePostingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Year() As Nullable(Of Short)
            Get
                Year = _Year
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Year = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Month() As String
            Get
                Month = _Month
            End Get
            Set(ByVal value As String)
                _Month = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCreatedDate() As Nullable(Of Date)
            Get
                JobCreatedDate = _JobCreatedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobCreatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobStartDate() As Nullable(Of Date)
            Get
                JobStartDate = _JobStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignComments() As String
            Get
                CampaignComments = _CampaignComments
            End Get
            Set(ByVal value As String)
                _CampaignComments = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
