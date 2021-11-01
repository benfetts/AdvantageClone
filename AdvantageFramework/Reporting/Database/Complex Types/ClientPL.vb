Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="ClientPL")>
    <Serializable()>
    Public Class ClientPL
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            DefaultAECode
            DefaultAEName
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            Industry
            Specialty
            Region
            RegionCode
            Revenue
            NumberOfEmployees
            Source
            Type
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            PostingPeriod
            PostingPeriodYear
            PostingPeriodMonth
            Year
            BilledHours
            BilledQuantity
            BilledFee
            BilledTime
            BilledCommission
            BilledCostOfSales
            BilledIncomeRec
            ManualSale
            ManualCOS
            GLSales
            GLCostOfSales
            BilledTotal
            TotalGrossIncome
            Hours
            DirectServiceCost
            DirectExpense
            GLDirectExpense
            TotalDirectCosts
            TotalIncome
            Overhead
            IncomeLessOverhead
            FTE
            BudgetFee
            BudgetTime
            BudgetCommission
            BudgetCostOfSales
            BudgetDirectServiceCost
            BudgetDirectExpense
            BudgetSummaryBilling
            BudgetSummaryCOS
            BudgetSummaryIncome
            BudgetBillingAmount
            BudgetCOSAmount
            BudgetGrossIncome
            BudgetDirectCost
            BudgetIncome
            BudgetVarianceFee
            BudgetVarianceTime
            BudgetVarianceCommission
            BudgetVarianceCostOfSales
            BudgetVarianceDirectServiceCost
            BudgetVarianceDirectExpense
            BudgetVarianceGrossIncome
            BudgetVarianceIncome
            BudgetVarianceBilling
            ForecastFee
            ForecastTime
            ForecastCommission
            ForecastCostOfSales
            ForecastDirectServiceCost
            ForecastDirectExpense
            ForecastGrossIncome
            ForecastIncome
            BFVarianceFee
            BFVarianceTime
            BFVarianceCommission
            BFVarianceCostOfSales
            BFVarianceDirectServiceCost
            BFVarianceDirectExpense
            BFVarianceGrossIncome
            BFVarianceIncome
            SumofTotalGrossIncomeOffice
            SumofDirectServiceCostOffice
            SumofTotalGrossIncomeOfficeYear
            SumofDirectServiceCostOfficeYear
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _DefaultAECode As String = Nothing
        Private _DefaultAEName As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _Industry As String = Nothing
        Private _Specialty As String = Nothing
        Private _Region As String = Nothing
        Private _RegionCode As String = Nothing
        Private _Revenue As Nullable(Of Decimal) = Nothing
        Private _NumberOfEmployees As Nullable(Of Integer) = Nothing
        Private _Source As String = Nothing
        Private _Type As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _PostingPeriod As String = Nothing
        Private _PostingPeriodYear As Nullable(Of Integer) = Nothing
        Private _PostingPeriodMonth As Nullable(Of Short) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledFee As Nullable(Of Decimal) = Nothing
        Private _BilledTime As Nullable(Of Decimal) = Nothing
        Private _BilledCommission As Nullable(Of Decimal) = Nothing
        Private _BilledCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BilledIncomeRec As Nullable(Of Decimal) = Nothing
        Private _ManualSale As Nullable(Of Decimal) = Nothing
        Private _ManualCOS As Nullable(Of Decimal) = Nothing
        Private _GLSales As Nullable(Of Decimal) = Nothing
        Private _GLCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BilledTotal As Nullable(Of Decimal) = Nothing
        Private _TotalGrossIncome As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _DirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _DirectExpense As Nullable(Of Decimal) = Nothing
        Private _GLDirectExpense As Nullable(Of Decimal) = Nothing
        Private _TotalDirectCosts As Nullable(Of Decimal) = Nothing
        Private _TotalIncome As Nullable(Of Decimal) = Nothing
        Private _Overhead As Nullable(Of Decimal) = Nothing
        Private _IncomeLessOverhead As Nullable(Of Decimal) = Nothing
        Private _FTE As Nullable(Of Decimal) = Nothing
        Private _BudgetFee As Nullable(Of Decimal) = Nothing
        Private _BudgetTime As Nullable(Of Decimal) = Nothing
        Private _BudgetCommission As Nullable(Of Decimal) = Nothing
        Private _BudgetCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryBilling As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryCOS As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetBillingAmount As Nullable(Of Decimal) = Nothing
        Private _BudgetCOSAmount As Nullable(Of Decimal) = Nothing
        Private _BudgetGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectCost As Nullable(Of Decimal) = Nothing
        Private _BudgetIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceFee As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceTime As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceCommission As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceIncome As Nullable(Of Decimal) = Nothing
        Private _ForecastFee As Nullable(Of Decimal) = Nothing
        Private _ForecastTime As Nullable(Of Decimal) = Nothing
        Private _ForecastCommission As Nullable(Of Decimal) = Nothing
        Private _ForecastCostOfSales As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectExpense As Nullable(Of Decimal) = Nothing
        Private _ForecastGrossIncome As Nullable(Of Decimal) = Nothing
        Private _ForecastIncome As Nullable(Of Decimal) = Nothing
        Private _BFVarianceFee As Nullable(Of Decimal) = Nothing
        Private _BFVarianceTime As Nullable(Of Decimal) = Nothing
        Private _BFVarianceCommission As Nullable(Of Decimal) = Nothing
        Private _BFVarianceCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BFVarianceDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BFVarianceDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BFVarianceGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BFVarianceIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceBilling As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeOffice As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOffice As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeOfficeYear As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOfficeYear As Nullable(Of Decimal) = Nothing

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
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
                _ProductDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultAECode() As String
            Get
                DefaultAECode = _DefaultAECode
            End Get
            Set(value As String)
                _DefaultAECode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultAEName() As String
            Get
                DefaultAEName = _DefaultAEName
            End Get
            Set(value As String)
                _DefaultAEName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property Industry() As String
            Get
                Industry = _Industry
            End Get
            Set
                _Industry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Specialty() As String
            Get
                Specialty = _Specialty
            End Get
            Set
                _Specialty = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set
                _Region = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RegionCode() As String
            Get
                RegionCode = _RegionCode
            End Get
            Set
                _RegionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Revenue() As Nullable(Of Decimal)
            Get
                Revenue = _Revenue
            End Get
            Set
                _Revenue = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfEmployees() As Nullable(Of Integer)
            Get
                NumberOfEmployees = _NumberOfEmployees
            End Get
            Set
                _NumberOfEmployees = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
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
        Public Property PostingPeriod() As String
            Get
                PostingPeriod = _PostingPeriod
            End Get
            Set(value As String)
                _PostingPeriod = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property PostingPeriodYear() As Nullable(Of Integer)
            Get
                PostingPeriodYear = _PostingPeriodYear
            End Get
            Set
                _PostingPeriodYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostingPeriodMonth() As Nullable(Of Short)
            Get
                PostingPeriodMonth = _PostingPeriodMonth
            End Get
            Set
                _PostingPeriodMonth = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours
            End Get
            Set
                _BilledHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set
                _BilledQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledFee() As Nullable(Of Decimal)
            Get
                BilledFee = _BilledFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledTime() As Nullable(Of Decimal)
            Get
                BilledTime = _BilledTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCommission() As Nullable(Of Decimal)
            Get
                BilledCommission = _BilledCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCostOfSales() As Nullable(Of Decimal)
            Get
                BilledCostOfSales = _BilledCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledIncomeRec() As Nullable(Of Decimal)
            Get
                BilledIncomeRec = _BilledIncomeRec
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledIncomeRec = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ManualSale() As Nullable(Of Decimal)
            Get
                ManualSale = _ManualSale
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualSale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ManualCOS() As Nullable(Of Decimal)
            Get
                ManualCOS = _ManualCOS
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualCOS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLSales() As Nullable(Of Decimal)
            Get
                GLSales = _GLSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLCostOfSales() As Nullable(Of Decimal)
            Get
                GLCostOfSales = _GLCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalGrossIncome() As Nullable(Of Decimal)
            Get
                TotalGrossIncome = _TotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalGrossIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectServiceCost() As Nullable(Of Decimal)
            Get
                DirectServiceCost = _DirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectServiceCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectExpense() As Nullable(Of Decimal)
            Get
                DirectExpense = _DirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLDirectExpense() As Nullable(Of Decimal)
            Get
                GLDirectExpense = _GLDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _GLDirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalDirectCosts() As Nullable(Of Decimal)
            Get
                TotalDirectCosts = _TotalDirectCosts
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalDirectCosts = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalIncome() As Nullable(Of Decimal)
            Get
                TotalIncome = _TotalIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Overhead() As Nullable(Of Decimal)
            Get
                Overhead = _Overhead
            End Get
            Set(value As Nullable(Of Decimal))
                _Overhead = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncomeLessOverhead() As Nullable(Of Decimal)
            Get
                IncomeLessOverhead = _IncomeLessOverhead
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeLessOverhead = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FTE() As Nullable(Of Decimal)
            Get
                FTE = _FTE
            End Get
            Set(value As Nullable(Of Decimal))
                _FTE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetFee() As Nullable(Of Decimal)
            Get
                BudgetFee = _BudgetFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetTime() As Nullable(Of Decimal)
            Get
                BudgetTime = _BudgetTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetCommission() As Nullable(Of Decimal)
            Get
                BudgetCommission = _BudgetCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetCostOfSales() As Nullable(Of Decimal)
            Get
                BudgetCostOfSales = _BudgetCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetDirectServiceCost() As Nullable(Of Decimal)
            Get
                BudgetDirectServiceCost = _BudgetDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetDirectServiceCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetDirectExpense() As Nullable(Of Decimal)
            Get
                BudgetDirectExpense = _BudgetDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetDirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetSummaryBilling() As Nullable(Of Decimal)
            Get
                BudgetSummaryBilling = _BudgetSummaryBilling
            End Get
            Set
                _BudgetSummaryBilling = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetSummaryCOS() As Nullable(Of Decimal)
            Get
                BudgetSummaryCOS = _BudgetSummaryCOS
            End Get
            Set
                _BudgetSummaryCOS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetSummaryIncome() As Nullable(Of Decimal)
            Get
                BudgetSummaryIncome = _BudgetSummaryIncome
            End Get
            Set
                _BudgetSummaryIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetBillingAmount() As Nullable(Of Decimal)
            Get
                BudgetBillingAmount = _BudgetBillingAmount
            End Get
            Set
                _BudgetBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetCOSAmount() As Nullable(Of Decimal)
            Get
                BudgetCOSAmount = _BudgetCOSAmount
            End Get
            Set
                _BudgetCOSAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetGrossIncome() As Nullable(Of Decimal)
            Get
                BudgetGrossIncome = _BudgetGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetGrossIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetDirectCost() As Nullable(Of Decimal)
            Get
                BudgetDirectCost = _BudgetDirectCost
            End Get
            Set
                _BudgetDirectCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetIncome() As Nullable(Of Decimal)
            Get
                BudgetIncome = _BudgetIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceFee() As Nullable(Of Decimal)
            Get
                BudgetVarianceFee = _BudgetVarianceFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceTime() As Nullable(Of Decimal)
            Get
                BudgetVarianceTime = _BudgetVarianceTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceCommission() As Nullable(Of Decimal)
            Get
                BudgetVarianceCommission = _BudgetVarianceCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceCostOfSales() As Nullable(Of Decimal)
            Get
                BudgetVarianceCostOfSales = _BudgetVarianceCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceDirectServiceCost() As Nullable(Of Decimal)
            Get
                BudgetVarianceDirectServiceCost = _BudgetVarianceDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceDirectServiceCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceDirectExpense() As Nullable(Of Decimal)
            Get
                BudgetVarianceDirectExpense = _BudgetVarianceDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceDirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceGrossIncome() As Nullable(Of Decimal)
            Get
                BudgetVarianceGrossIncome = _BudgetVarianceGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceGrossIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceIncome() As Nullable(Of Decimal)
            Get
                BudgetVarianceIncome = _BudgetVarianceIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BudgetVarianceBilling() As Nullable(Of Decimal)
            Get
                BudgetVarianceBilling = _BudgetVarianceBilling
            End Get
            Set
                _BudgetVarianceBilling = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastFee() As Nullable(Of Decimal)
            Get
                ForecastFee = _ForecastFee
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastTime() As Nullable(Of Decimal)
            Get
                ForecastTime = _ForecastTime
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastCommission() As Nullable(Of Decimal)
            Get
                ForecastCommission = _ForecastCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastCostOfSales() As Nullable(Of Decimal)
            Get
                ForecastCostOfSales = _ForecastCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastDirectServiceCost() As Nullable(Of Decimal)
            Get
                ForecastDirectServiceCost = _ForecastDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectServiceCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastDirectExpense() As Nullable(Of Decimal)
            Get
                ForecastDirectExpense = _ForecastDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastGrossIncome() As Nullable(Of Decimal)
            Get
                ForecastGrossIncome = _ForecastGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastGrossIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastIncome() As Nullable(Of Decimal)
            Get
                ForecastIncome = _ForecastIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceFee() As Nullable(Of Decimal)
            Get
                BFVarianceFee = _BFVarianceFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceTime() As Nullable(Of Decimal)
            Get
                BFVarianceTime = _BFVarianceTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceCommission() As Nullable(Of Decimal)
            Get
                BFVarianceCommission = _BFVarianceCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceCostOfSales() As Nullable(Of Decimal)
            Get
                BFVarianceCostOfSales = _BFVarianceCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceCostOfSales = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceDirectServiceCost() As Nullable(Of Decimal)
            Get
                BFVarianceDirectServiceCost = _BFVarianceDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceDirectServiceCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceDirectExpense() As Nullable(Of Decimal)
            Get
                BFVarianceDirectExpense = _BFVarianceDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceDirectExpense = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceGrossIncome() As Nullable(Of Decimal)
            Get
                BFVarianceGrossIncome = _BFVarianceGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceGrossIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BFVarianceIncome() As Nullable(Of Decimal)
            Get
                BFVarianceIncome = _BFVarianceIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceIncome = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeOffice() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeOffice = _SumofTotalGrossIncomeOffice
            End Get
            Set
                _SumofTotalGrossIncomeOffice = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOffice() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOffice = _SumofDirectServiceCostOffice
            End Get
            Set
                _SumofDirectServiceCostOffice = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeOfficeYear() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeOfficeYear = _SumofTotalGrossIncomeOfficeYear
            End Get
            Set
                _SumofTotalGrossIncomeOfficeYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOfficeYear() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOfficeYear = _SumofDirectServiceCostOfficeYear
            End Get
            Set
                _SumofDirectServiceCostOfficeYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
