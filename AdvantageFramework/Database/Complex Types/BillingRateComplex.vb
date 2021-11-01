Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="BillingRateComplex")>
    <Serializable()>
    Public Class BillingRateComplex
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingRate
            RateLevel
            TaxCode
            TaxLevel
            NonBillFlag
            NonBillLevel
            Commission
            CommissionLevel
            TaxCommission
            TaxCommissionOnly
            TaxCommissionFlagLevel
            FeeTimeFlag
            FeeTimeLevel
        End Enum

#End Region

#Region " Variables "

        Private _BillingRate As Nullable(Of Decimal) = Nothing
        Private _RateLevel As Nullable(Of Short) = Nothing
        Private _TaxCode As String = Nothing
        Private _TaxLevel As Nullable(Of Short) = Nothing
        Private _NonBillFlag As Nullable(Of Short) = Nothing
        Private _NonBillLevel As Nullable(Of Short) = Nothing
        Private _Commission As Nullable(Of Decimal) = Nothing
        Private _CommissionLevel As Nullable(Of Short) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _TaxCommissionFlagLevel As Nullable(Of Short) = Nothing
        Private _FeeTimeFlag As Nullable(Of Short) = Nothing
        Private _FeeTimeLevel As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RateLevel() As Nullable(Of Short)
            Get
                RateLevel = _RateLevel
            End Get
            Set(value As Nullable(Of Short))
                _RateLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxLevel() As Nullable(Of Short)
            Get
                TaxLevel = _TaxLevel
            End Get
            Set(value As Nullable(Of Short))
                _TaxLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillFlag() As Nullable(Of Short)
            Get
                NonBillFlag = _NonBillFlag
            End Get
            Set(value As Nullable(Of Short))
                _NonBillFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillLevel() As Nullable(Of Short)
            Get
                NonBillLevel = _NonBillLevel
            End Get
            Set(value As Nullable(Of Short))
                _NonBillLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Commission() As Nullable(Of Decimal)
            Get
                Commission = _Commission
            End Get
            Set(value As Nullable(Of Decimal))
                _Commission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionLevel() As Nullable(Of Short)
            Get
                CommissionLevel = _CommissionLevel
            End Get
            Set(value As Nullable(Of Short))
                _CommissionLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxCommissionFlagLevel() As Nullable(Of Short)
            Get
                TaxCommissionFlagLevel = _TaxCommissionFlagLevel
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionFlagLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FeeTimeFlag() As Nullable(Of Short)
            Get
                FeeTimeFlag = _FeeTimeFlag
            End Get
            Set(value As Nullable(Of Short))
                _FeeTimeFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FeeTimeLevel() As Nullable(Of Short)
            Get
                FeeTimeLevel = _FeeTimeLevel
            End Get
            Set(value As Nullable(Of Short))
                _FeeTimeLevel = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BillingRate.ToString

        End Function

#End Region

    End Class

End Namespace
