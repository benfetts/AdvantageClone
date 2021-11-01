Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="TimesheetEstimate")>
    <Serializable()>
    Public Class TimesheetEstimate
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            EstimateNumber
            EstimateLogDescription
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateQuoteNumber
            EstimateRevisionNumber
            FunctionCode
            EstimateRevisionSuppliedByCode
            TotalEstimateQuantity
            EstimateAmount
            Contingency
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _EstimateNumber As Integer = Nothing
        Private _EstimateLogDescription As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateComponentDescription As String = Nothing
        Private _EstimateQuoteNumber As Short = Nothing
        Private _EstimateRevisionNumber As Short = Nothing
        Private _FunctionCode As String = Nothing
        Private _EstimateRevisionSuppliedByCode As String = Nothing
        Private _TotalEstimateQuantity As Decimal = Nothing
        Private _EstimateAmount As Nullable(Of Decimal) = Nothing
        Private _Contingency As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

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
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateLogDescription() As String
            Get
                EstimateLogDescription = _EstimateLogDescription
            End Get
            Set(value As String)
                _EstimateLogDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentNumber() As Short
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Short)
                _EstimateComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentDescription() As String
            Get
                EstimateComponentDescription = _EstimateComponentDescription
            End Get
            Set(value As String)
                _EstimateComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateQuoteNumber() As Short
            Get
                EstimateQuoteNumber = _EstimateQuoteNumber
            End Get
            Set(value As Short)
                _EstimateQuoteNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionNumber() As Short
            Get
                EstimateRevisionNumber = _EstimateRevisionNumber
            End Get
            Set(value As Short)
                _EstimateRevisionNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionSuppliedByCode() As String
            Get
                EstimateRevisionSuppliedByCode = _EstimateRevisionSuppliedByCode
            End Get
            Set(value As String)
                _EstimateRevisionSuppliedByCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalEstimateQuantity() As Decimal
            Get
                TotalEstimateQuantity = _TotalEstimateQuantity
            End Get
            Set(value As Decimal)
                _TotalEstimateQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateAmount() As Nullable(Of Decimal)
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Contingency() As Nullable(Of Decimal)
            Get
                Contingency = _Contingency
            End Get
            Set(value As Nullable(Of Decimal))
                _Contingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
