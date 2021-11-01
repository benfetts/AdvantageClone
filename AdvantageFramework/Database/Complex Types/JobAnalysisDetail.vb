Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="JobAnalysisDetail")>
    <Serializable()>
    Public Class JobAnalysisDetail
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobMarkupPercentage
            JobNumberAndComponentNumber
            NonBillable
            HoldType
            IsAdvancedBilling
            ClientCode
            Client
            DivisionCode
            Division
            ProductCode
            Product
            AccountExecutiveEmployeeCode
            AccountExecutiveFirstName
            AccountExecutiveLastName
            JobClientReference
            JobNumber
            JobDescription
            SalesClassCode
            JobComponentNumber
            JobComponentDescription
            JobTypeCode
            FunctionTypeOrder
            FunctionTypeCode
            FunctionTypeDescription
            OrderNumber
            FunctionCode
            FunctionDescription
            DetailDescription
            DetailDate
            DetailCode
            PostPeriodCode
            TotalEstimateAmount
            TotalEstimateNetCost
            TotalEstimateMarkupAmount
            TotalEstimateNonResaleTax
            TotalIncomeOnlyAmount
            TotalBillableEmployeeHours
            TotalBillableAmount
            TotalAPNetCost
            TotalMarkupAmount
            TotalNonResaleTaxAmount
            TotalResaleTaxAmount
            TotalResaleBilledAmount
            TotalOpenPOAmount
            TotalAmount
            TotalNonBillableEmployeeHours
            TotalNonBillableAmount
            TotalAmountBilled
            TotalAdvancedBilledAmount
            TotalAdvancedAmount
            TotalCostBilled
            JobProcessControlDescription
            JobProcessControlNumber
            Code
            ZeroMarkup
            Advanced
            EstimateNumber
            EstimateComponentNumber
        End Enum

#End Region

#Region " Variables "

        Private _JobMarkupPercentage As Nullable(Of Decimal) = Nothing
        Private _JobNumberAndComponentNumber As Nullable(Of Integer) = Nothing
        Private _NonBillable As String = Nothing
        Private _HoldType As String = Nothing
        Private _IsAdvancedBilling As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _Client As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _Division As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Product As String = Nothing
        Private _AccountExecutiveEmployeeCode As String = Nothing
        Private _AccountExecutiveFirstName As String = Nothing
        Private _AccountExecutiveLastName As String = Nothing
        Private _JobClientReference As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _FunctionTypeOrder As Nullable(Of Integer) = Nothing
        Private _FunctionTypeCode As String = Nothing
        Private _FunctionTypeDescription As String = Nothing
        Private _OrderNumber As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _DetailDescription As String = Nothing
        Private _DetailDate As Nullable(Of Date) = Nothing
        Private _DetailCode As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _TotalEstimateAmount As Nullable(Of Decimal) = Nothing
        Private _TotalEstimateNetCost As Nullable(Of Decimal) = Nothing
        Private _TotalEstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TotalEstimateNonResaleTax As Nullable(Of Decimal) = Nothing
        Private _TotalIncomeOnlyAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBillableEmployeeHours As Nullable(Of Decimal) = Nothing
        Private _TotalBillableAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAPNetCost As Nullable(Of Decimal) = Nothing
        Private _TotalMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TotalNonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _TotalResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _TotalResaleBilledAmount As Nullable(Of Decimal) = Nothing
        Private _TotalOpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _TotalNonBillableEmployeeHours As Nullable(Of Decimal) = Nothing
        Private _TotalNonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAmountBilled As Nullable(Of Decimal) = Nothing
        Private _TotalAdvancedBilledAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAdvancedAmount As Nullable(Of Decimal) = Nothing
        Private _TotalCostBilled As Nullable(Of Decimal) = Nothing
        Private _JobProcessControlDescription As String = Nothing
        Private _JobProcessControlNumber As Nullable(Of Short) = Nothing
        Private _Code As String = Nothing
        Private _ZeroMarkup As Nullable(Of Decimal) = Nothing
        Private _Advanced As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobMarkupPercentage() As Nullable(Of Decimal)
            Get
                JobMarkupPercentage = _JobMarkupPercentage
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _JobMarkupPercentage = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumberAndComponentNumber() As Nullable(Of Integer)
            Get
                JobNumberAndComponentNumber = _JobNumberAndComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumberAndComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillable() As String
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As String)
                _NonBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HoldType() As String
            Get
                HoldType = _HoldType
            End Get
            Set(ByVal value As String)
                _HoldType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAdvancedBilling() As Nullable(Of Short)
            Get
                IsAdvancedBilling = _IsAdvancedBilling
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsAdvancedBilling = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Client() As String
            Get
                Client = _Client
            End Get
            Set(ByVal value As String)
                _Client = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Division() As String
            Get
                Division = _Division
            End Get
            Set(ByVal value As String)
                _Division = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Product() As String
            Get
                Product = _Product
            End Get
            Set(ByVal value As String)
                _Product = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveEmployeeCode() As String
            Get
                AccountExecutiveEmployeeCode = _AccountExecutiveEmployeeCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveEmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveFirstName() As String
            Get
                AccountExecutiveFirstName = _AccountExecutiveFirstName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveFirstName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveLastName() As String
            Get
                AccountExecutiveLastName = _AccountExecutiveLastName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveLastName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobClientReference() As String
            Get
                JobClientReference = _JobClientReference
            End Get
            Set(ByVal value As String)
                _JobClientReference = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionTypeOrder() As Nullable(Of Integer)
            Get
                FunctionTypeOrder = _FunctionTypeOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionTypeOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionTypeCode() As String
            Get
                FunctionTypeCode = _FunctionTypeCode
            End Get
            Set(ByVal value As String)
                _FunctionTypeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionTypeDescription() As String
            Get
                FunctionTypeDescription = _FunctionTypeDescription
            End Get
            Set(ByVal value As String)
                _FunctionTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber() As String
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As String)
                _OrderNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DetailDescription() As String
            Get
                DetailDescription = _DetailDescription
            End Get
            Set(ByVal value As String)
                _DetailDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DetailDate() As Nullable(Of Date)
            Get
                DetailDate = _DetailDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DetailDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DetailCode() As String
            Get
                DetailCode = _DetailCode
            End Get
            Set(ByVal value As String)
                _DetailCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalEstimateAmount() As Nullable(Of Decimal)
            Get
                TotalEstimateAmount = _TotalEstimateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalEstimateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalEstimateNetCost() As Nullable(Of Decimal)
            Get
                TotalEstimateNetCost = _TotalEstimateNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalEstimateNetCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalEstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                TotalEstimateMarkupAmount = _TotalEstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalEstimateMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalEstimateNonResaleTax() As Nullable(Of Decimal)
            Get
                TotalEstimateNonResaleTax = _TotalEstimateNonResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalEstimateNonResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalIncomeOnlyAmount() As Nullable(Of Decimal)
            Get
                TotalIncomeOnlyAmount = _TotalIncomeOnlyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalIncomeOnlyAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalBillableEmployeeHours() As Nullable(Of Decimal)
            Get
                TotalBillableEmployeeHours = _TotalBillableEmployeeHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBillableEmployeeHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalBillableAmount() As Nullable(Of Decimal)
            Get
                TotalBillableAmount = _TotalBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBillableAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAPNetCost() As Nullable(Of Decimal)
            Get
                TotalAPNetCost = _TotalAPNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAPNetCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalMarkupAmount() As Nullable(Of Decimal)
            Get
                TotalMarkupAmount = _TotalMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalNonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                TotalNonResaleTaxAmount = _TotalNonResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalNonResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalResaleTaxAmount() As Nullable(Of Decimal)
            Get
                TotalResaleTaxAmount = _TotalResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalResaleBilledAmount() As Nullable(Of Decimal)
            Get
                TotalResaleBilledAmount = _TotalResaleBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalResaleBilledAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalOpenPOAmount() As Nullable(Of Decimal)
            Get
                TotalOpenPOAmount = _TotalOpenPOAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalOpenPOAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalNonBillableEmployeeHours() As Nullable(Of Decimal)
            Get
                TotalNonBillableEmployeeHours = _TotalNonBillableEmployeeHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalNonBillableEmployeeHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalNonBillableAmount() As Nullable(Of Decimal)
            Get
                TotalNonBillableAmount = _TotalNonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalNonBillableAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAmountBilled() As Nullable(Of Decimal)
            Get
                TotalAmountBilled = _TotalAmountBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmountBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAdvancedBilledAmount() As Nullable(Of Decimal)
            Get
                TotalAdvancedBilledAmount = _TotalAdvancedBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAdvancedBilledAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAdvancedAmount() As Nullable(Of Decimal)
            Get
                TotalAdvancedAmount = _TotalAdvancedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAdvancedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalCostBilled() As Nullable(Of Decimal)
            Get
                TotalCostBilled = _TotalCostBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalCostBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControlDescription() As String
            Get
                JobProcessControlDescription = _JobProcessControlDescription
            End Get
            Set(ByVal value As String)
                _JobProcessControlDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControlNumber() As Nullable(Of Short)
            Get
                JobProcessControlNumber = _JobProcessControlNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobProcessControlNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ZeroMarkup() As Nullable(Of Decimal)
            Get
                ZeroMarkup = _ZeroMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ZeroMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Advanced() As String
            Get
                Advanced = _Advanced
            End Get
            Set(ByVal value As String)
                _Advanced = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimateComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobMarkupPercentage

        End Function

#End Region

    End Class

End Namespace
