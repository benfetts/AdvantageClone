Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="PurchaseOrderEstimate")>
    <Serializable()>
    Public Class PurchaseOrderEstimate
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            JobNumber
            JobComponentNumber
            FunctionType
            FunctionDescription
            FunctionCode
            EstimateApprovalQuoteNumber
            EstimateRevisionQuantity
            EstimateRevisionRate
            EstimateRevisionExtendedAmount
            EstimateRevisionCommissionPercent
            VendorName
            VendorCode
            ClientCode
            DivisionCode
            ProductCode
            ExtendedMarkupAmount
            LineTotal
            PurchaseOrderExistingAmount
            Balance
            UseCPM
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumber As Integer = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateQuoteNumber As Short = Nothing
        Private _EstimateRevisionNumber As Short = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _EstimateApprovalQuoteNumber As Short = Nothing
        Private _EstimateRevisionQuantity As Decimal = Nothing
        Private _EstimateRevisionRate As Decimal = Nothing
        Private _EstimateRevisionExtendedAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateRevisionCommissionPercent As Decimal = Nothing
        Private _VendorName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _PurchaseOrderExistingAmount As Decimal = Nothing
        Private _Balance As Nullable(Of Decimal) = Nothing
        Private _UseCPM As Integer = Nothing

#End Region

#Region " Properties "

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
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateApprovalQuoteNumber() As Short
            Get
                EstimateApprovalQuoteNumber = _EstimateApprovalQuoteNumber
            End Get
            Set(value As Short)
                _EstimateApprovalQuoteNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionQuantity() As Decimal
            Get
                EstimateRevisionQuantity = _EstimateRevisionQuantity
            End Get
            Set(value As Decimal)
                _EstimateRevisionQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionRate() As Decimal
            Get
                EstimateRevisionRate = _EstimateRevisionRate
            End Get
            Set(value As Decimal)
                _EstimateRevisionRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionExtendedAmount() As Nullable(Of Decimal)
            Get
                EstimateRevisionExtendedAmount = _EstimateRevisionExtendedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionExtendedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionCommissionPercent() As Decimal
            Get
                EstimateRevisionCommissionPercent = _EstimateRevisionCommissionPercent
            End Get
            Set(value As Decimal)
                _EstimateRevisionCommissionPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineTotal() As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PurchaseOrderExistingAmount() As Decimal
            Get
                PurchaseOrderExistingAmount = _PurchaseOrderExistingAmount
            End Get
            Set(value As Decimal)
                _PurchaseOrderExistingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Balance() As Nullable(Of Decimal)
            Get
                Balance = _Balance
            End Get
            Set(value As Nullable(Of Decimal))
                _Balance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseCPM() As Integer
            Get
                UseCPM = _UseCPM
            End Get
            Set(value As Integer)
                _UseCPM = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace
