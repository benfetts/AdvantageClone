Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="InvoiceAssignedCoop")>
    <Serializable()>
    Public Class InvoiceAssignedCoop
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorkARFunctionID
            JobNumber
            JobComponentNumber
            JobComponentDescription
            ClientCode
            DivisionCode
            ProductCode
            FunctionCode
            FunctionDescription
            FunctionType
            CoopPercent
            CostAmount
            CCCostAmount
            IncomeAmount
            CCIncomeAmount
            SalesTaxCode
            DetailTaxFlag
            InvoiceTaxFlag
            CoopCode
            CostPercent
            IncomePercent
            JobDescription
            JobAdvanceBillingFlag
            IsSummaryFlag
            FromAdv
            EmployeeTimeAmount
            IncomeOnlyAmount
            AdvanceBillIncomeAmount
            AdvanceBillCostAmount
            MarkupAmount
            AdvanceBillMarkupAmount
            AdvanceBillSaleAmount
            AdvanceBillNonResaleTaxAmount
            StateTaxAmount
            CountyTaxAmount
            CityTaxAmount
            NonResaleTaxAmount
            TotalBill
            IsModified
            CCBalancedFlag
            CCAmountModified
            CCVariance
            CCInterimReconcile
            FunctionRowCount
            NewspaperCoopSplit
            CampaignID
            SummaryRowId
            ClientName
            DivisionName
            ProductName
            CampaignCode
            CampaignName
        End Enum

#End Region

#Region " Variables "

        Private _WorkARFunctionID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _CoopPercent As Nullable(Of Decimal) = Nothing
        Private _CostAmount As Nullable(Of Decimal) = Nothing
        Private _CCCostAmount As Nullable(Of Decimal) = Nothing
        Private _IncomeAmount As Nullable(Of Decimal) = Nothing
        Private _CCIncomeAmount As Nullable(Of Decimal) = Nothing
        Private _SalesTaxCode As String = Nothing
        Private _DetailTaxFlag As Nullable(Of Boolean) = Nothing
        Private _InvoiceTaxFlag As Nullable(Of Boolean) = Nothing
        Private _CoopCode As String = Nothing
        Private _CostPercent As Nullable(Of Decimal) = Nothing
        Private _IncomePercent As Nullable(Of Decimal) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobAdvanceBillingFlag As Nullable(Of Byte) = Nothing
        Private _IsSummaryFlag As Nullable(Of Boolean) = Nothing
        Private _FromAdv As Nullable(Of Boolean) = Nothing
        Private _EmployeeTimeAmount As Nullable(Of Decimal) = Nothing
        Private _IncomeOnlyAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillIncomeAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillCostAmount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillSaleAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillNonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _StateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CountyTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CityTaxAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBill As Nullable(Of Decimal) = Nothing
        Private _IsModified As Nullable(Of Boolean) = Nothing
        Private _CCBalancedFlag As Nullable(Of Boolean) = Nothing
        Private _CCAmountModified As Nullable(Of Boolean) = Nothing
        Private _CCVariance As Nullable(Of Decimal) = Nothing
        Private _CCInterimReconcile As Nullable(Of Boolean) = Nothing
        Private _FunctionRowCount As Nullable(Of Integer) = Nothing
        Private _NewspaperCoopSplit As Nullable(Of Short) = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _SummaryRowId As Nullable(Of Integer) = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductName As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkARFunctionID() As Integer
            Get
                WorkARFunctionID = _WorkARFunctionID
            End Get
            Set(value As Integer)
                _WorkARFunctionID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CoopPercent() As Nullable(Of Decimal)
            Get
                CoopPercent = _CoopPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CoopPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostAmount() As Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCCostAmount() As Nullable(Of Decimal)
            Get
                CCCostAmount = _CCCostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CCCostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncomeAmount() As Nullable(Of Decimal)
            Get
                IncomeAmount = _IncomeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCIncomeAmount() As Nullable(Of Decimal)
            Get
                CCIncomeAmount = _CCIncomeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CCIncomeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _SalesTaxCode
            End Get
            Set(value As String)
                _SalesTaxCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DetailTaxFlag() As Nullable(Of Boolean)
            Get
                DetailTaxFlag = _DetailTaxFlag
            End Get
            Set(value As Nullable(Of Boolean))
                _DetailTaxFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTaxFlag() As Nullable(Of Boolean)
            Get
                InvoiceTaxFlag = _InvoiceTaxFlag
            End Get
            Set(value As Nullable(Of Boolean))
                _InvoiceTaxFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CoopCode() As String
            Get
                CoopCode = _CoopCode
            End Get
            Set(value As String)
                _CoopCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostPercent() As Nullable(Of Decimal)
            Get
                CostPercent = _CostPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CostPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncomePercent() As Nullable(Of Decimal)
            Get
                IncomePercent = _IncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomePercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property JobAdvanceBillingFlag() As Nullable(Of Byte)
            Get
                JobAdvanceBillingFlag = _JobAdvanceBillingFlag
            End Get
            Set(value As Nullable(Of Byte))
                _JobAdvanceBillingFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsSummaryFlag() As Nullable(Of Boolean)
            Get
                IsSummaryFlag = _IsSummaryFlag
            End Get
            Set(value As Nullable(Of Boolean))
                _IsSummaryFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FromAdv() As Nullable(Of Boolean)
            Get
                FromAdv = _FromAdv
            End Get
            Set(value As Nullable(Of Boolean))
                _FromAdv = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTimeAmount() As Nullable(Of Decimal)
            Get
                EmployeeTimeAmount = _EmployeeTimeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeTimeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncomeOnlyAmount() As Nullable(Of Decimal)
            Get
                IncomeOnlyAmount = _IncomeOnlyAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeOnlyAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillIncomeAmount() As Nullable(Of Decimal)
            Get
                AdvanceBillIncomeAmount = _AdvanceBillIncomeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillIncomeAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillCostAmount() As Nullable(Of Decimal)
            Get
                AdvanceBillCostAmount = _AdvanceBillCostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillCostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillMarkupAmount() As Nullable(Of Decimal)
            Get
                AdvanceBillMarkupAmount = _AdvanceBillMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillSaleAmount() As Nullable(Of Decimal)
            Get
                AdvanceBillSaleAmount = _AdvanceBillSaleAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillSaleAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillNonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                AdvanceBillNonResaleTaxAmount = _AdvanceBillNonResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillNonResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
            Get
                StateTaxAmount = _StateTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _StateTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
            Get
                CountyTaxAmount = _CountyTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CountyTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
            Get
                CityTaxAmount = _CityTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CityTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                NonResaleTaxAmount = _NonResaleTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NonResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalBill() As Nullable(Of Decimal)
            Get
                TotalBill = _TotalBill
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsModified() As Nullable(Of Boolean)
            Get
                IsModified = _IsModified
            End Get
            Set(value As Nullable(Of Boolean))
                _IsModified = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCBalancedFlag() As Nullable(Of Boolean)
            Get
                CCBalancedFlag = _CCBalancedFlag
            End Get
            Set(value As Nullable(Of Boolean))
                _CCBalancedFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCAmountModified() As Nullable(Of Boolean)
            Get
                CCAmountModified = _CCAmountModified
            End Get
            Set(value As Nullable(Of Boolean))
                _CCAmountModified = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCVariance() As Nullable(Of Decimal)
            Get
                CCVariance = _CCVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _CCVariance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCInterimReconcile() As Nullable(Of Boolean)
            Get
                CCInterimReconcile = _CCInterimReconcile
            End Get
            Set(value As Nullable(Of Boolean))
                _CCInterimReconcile = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionRowCount() As Nullable(Of Integer)
            Get
                FunctionRowCount = _FunctionRowCount
            End Get
            Set(value As Nullable(Of Integer))
                _FunctionRowCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCoopSplit() As Nullable(Of Short)
            Get
                NewspaperCoopSplit = _NewspaperCoopSplit
            End Get
            Set(value As Nullable(Of Short))
                _NewspaperCoopSplit = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
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
        Public Property SummaryRowId() As Nullable(Of Integer)
            Get
                SummaryRowId = _SummaryRowId
            End Get
            Set(value As Nullable(Of Integer))
                _SummaryRowId = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.WorkARFunctionID.ToString

        End Function

#End Region

    End Class

End Namespace
