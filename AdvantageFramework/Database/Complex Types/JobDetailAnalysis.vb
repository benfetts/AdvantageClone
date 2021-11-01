Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="JobDetailAnalysis")>
    <Serializable()>
    Public Class JobDetailAnalysis
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarkupPercent
            JobComponent
            IsNonBillableJob
            IsNonBillable
            Hold
            AdvanceBillFlag
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            AccountExecutiveCode
            AccountExecutive
            ClientReference
            JobNumber
            JobDescription
            SalesClassCode
            JobComponentNumber
            ComponentDescription
            JobTypeCode
            FunctionTypeOrder
            FunctionType
            FunctionTypeDescription
            Order
            FunctionCode
            FunctionDescription
            ItemDescription
            ItemDate
            ItemCode
            ClientPO
            SumOfEstimate
            SumOfEstimateHours
            SumOfEstimateCont
            SumOfEstimateNetCost
            SumOfEstimateNetAmount
            SumOfEstimateExtMarkup
            SumOfEstimateVenTax
            SumOfEstimateResaleTax
            SumOfIncomeOnly
            SumOfBillEmpHours
            SumOfTotalBill
            SumOfAPNetCost
            SumOfAPQuantity
            SumOfExtMarkupAmount
            SumOfVenTax
            SumOfResaleTax
            SumOfResaleBilled
            SumOfOpenPOAmount
            SumOfLineTotal
            SumOfNonBillableEmpHours
            SumOfNonBillableAmount
            SumOfBilledAmount
            SumOfAdvanceBilled
            SumOfAdvanceResale
            SumOfAdvanceResaleBilled
            SumOfAdvanceFinalBilled
            SumOfAdvanceTotal
            SumOfBilledCost
            SumOfUnbilled
            ProcessDesc
            JobProcessControl
            Code
            ZeroMU
            IsAdvanceBill
            EstimateNumber
            EstimateComponentNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _JobComponent As String = Nothing
        Private _IsNonBillableJob As String = Nothing
        Private _IsNonBillable As String = Nothing
        Private _Hold As String = Nothing
        Private _AdvanceBillFlag As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ClientReference As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _FunctionTypeOrder As Nullable(Of Integer) = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionTypeDescription As String = Nothing
        Private _Order As Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _ItemDescription As String = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _ItemCode As String = Nothing
        Private _ClientPO As String = Nothing
        Private _SumOfEstimate As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateHours As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateCont As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
        Private _SumOfIncomeOnly As Nullable(Of Decimal) = Nothing
        Private _SumOfBillEmpHours As Nullable(Of Decimal) = Nothing
        Private _SumOfTotalBill As Nullable(Of Decimal) = Nothing
        Private _SumOfAPNetCost As Nullable(Of Decimal) = Nothing
        Private _SumOfAPQuantity As Nullable(Of Decimal) = Nothing
        Private _SumOfExtMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfVenTax As Nullable(Of Decimal) = Nothing
        Private _SumOfResaleTax As Nullable(Of Decimal) = Nothing
        Private _SumOfResaleBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfOpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfLineTotal As Nullable(Of Decimal) = Nothing
        Private _SumOfNonBillableEmpHours As Nullable(Of Decimal) = Nothing
        Private _SumOfNonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfBilledAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceResale As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceResaleBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceFinalBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _SumOfBilledCost As Nullable(Of Decimal) = Nothing
        Private _SumOfUnbilled As Nullable(Of Decimal) = Nothing
        Private _ProcessDesc As String = Nothing
        Private _JobProcessControl As Nullable(Of Short) = Nothing
        Private _Code As String = Nothing
        Private _ZeroMU As Nullable(Of Decimal) = Nothing
        Private _IsAdvanceBill As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set(ByVal value As Nullable(Of System.Guid))
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsNonBillableJob() As String
            Get
                IsNonBillableJob = _IsNonBillableJob
            End Get
            Set
                _IsNonBillableJob = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsNonBillable() As String
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(ByVal value As String)
                _IsNonBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hold() As String
            Get
                Hold = _Hold
            End Get
            Set(ByVal value As String)
                _Hold = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvanceBillFlag() As Nullable(Of Short)
            Get
                AdvanceBillFlag = _AdvanceBillFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AdvanceBillFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
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
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
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
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
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
        Public Property Order() As Nullable(Of Integer)
            Get
                Order = _Order
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Order = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(ByVal value As String)
                _ItemDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ItemDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(ByVal value As String)
                _ItemCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimate() As Nullable(Of Decimal)
            Get
                SumOfEstimate = _SumOfEstimate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateHours() As Nullable(Of Decimal)
            Get
                SumOfEstimateHours = _SumOfEstimateHours
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfEstimateHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateCont() As Nullable(Of Decimal)
            Get
                SumOfEstimateCont = _SumOfEstimateCont
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateCont = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateNetCost() As Nullable(Of Decimal)
            Get
                SumOfEstimateNetCost = _SumOfEstimateNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateNetCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateNetAmount() As Nullable(Of Decimal)
            Get
                SumOfEstimateNetAmount = _SumOfEstimateNetAmount
            End Get
            Set
                _SumOfEstimateNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateExtMarkup() As Nullable(Of Decimal)
            Get
                SumOfEstimateExtMarkup = _SumOfEstimateExtMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateExtMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateVenTax() As Nullable(Of Decimal)
            Get
                SumOfEstimateVenTax = _SumOfEstimateVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateVenTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfEstimateResaleTax() As Nullable(Of Decimal)
            Get
                SumOfEstimateResaleTax = _SumOfEstimateResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfIncomeOnly() As Nullable(Of Decimal)
            Get
                SumOfIncomeOnly = _SumOfIncomeOnly
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfIncomeOnly = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfBillEmpHours() As Nullable(Of Decimal)
            Get
                SumOfBillEmpHours = _SumOfBillEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfBillEmpHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfTotalBill() As Nullable(Of Decimal)
            Get
                SumOfTotalBill = _SumOfTotalBill
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfTotalBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAPNetCost() As Nullable(Of Decimal)
            Get
                SumOfAPNetCost = _SumOfAPNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfAPNetCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAPQuantity() As Nullable(Of Decimal)
            Get
                SumOfAPQuantity = _SumOfAPQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAPQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfExtMarkupAmount() As Nullable(Of Decimal)
            Get
                SumOfExtMarkupAmount = _SumOfExtMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfExtMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfVenTax() As Nullable(Of Decimal)
            Get
                SumOfVenTax = _SumOfVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfVenTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfResaleTax() As Nullable(Of Decimal)
            Get
                SumOfResaleTax = _SumOfResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfResaleBilled() As Nullable(Of Decimal)
            Get
                SumOfResaleBilled = _SumOfResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfResaleBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfOpenPOAmount() As Nullable(Of Decimal)
            Get
                SumOfOpenPOAmount = _SumOfOpenPOAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfOpenPOAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfLineTotal() As Nullable(Of Decimal)
            Get
                SumOfLineTotal = _SumOfLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfLineTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfNonBillableEmpHours() As Nullable(Of Decimal)
            Get
                SumOfNonBillableEmpHours = _SumOfNonBillableEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfNonBillableEmpHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfNonBillableAmount() As Nullable(Of Decimal)
            Get
                SumOfNonBillableAmount = _SumOfNonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfNonBillableAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfBilledAmount() As Nullable(Of Decimal)
            Get
                SumOfBilledAmount = _SumOfBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfBilledAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAdvanceBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceBilled = _SumOfAdvanceBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfAdvanceBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAdvanceResale() As Nullable(Of Decimal)
            Get
                SumOfAdvanceResale = _SumOfAdvanceResale
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAdvanceResaleBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceResaleBilled = _SumOfAdvanceResaleBilled
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceResaleBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAdvanceFinalBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceFinalBilled = _SumOfAdvanceFinalBilled
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceFinalBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfAdvanceTotal() As Nullable(Of Decimal)
            Get
                SumOfAdvanceTotal = _SumOfAdvanceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfAdvanceTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfBilledCost() As Nullable(Of Decimal)
            Get
                SumOfBilledCost = _SumOfBilledCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfBilledCost = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SumOfUnbilled() As Nullable(Of Decimal)
            Get
                SumOfUnbilled = _SumOfUnbilled
            End Get
            Set
                _SumOfUnbilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProcessDesc() As String
            Get
                ProcessDesc = _ProcessDesc
            End Get
            Set(ByVal value As String)
                _ProcessDesc = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControl() As Nullable(Of Short)
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobProcessControl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property ZeroMU() As Nullable(Of Decimal)
            Get
                ZeroMU = _ZeroMU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ZeroMU = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAdvanceBill() As String
            Get
                IsAdvanceBill = _IsAdvanceBill
            End Get
            Set(ByVal value As String)
                _IsAdvanceBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
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

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
