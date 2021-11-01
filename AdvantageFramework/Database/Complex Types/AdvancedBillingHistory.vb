Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="AdvancedBillingHistory")>
    <Serializable()>
    Public Class AdvancedBillingHistory
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            ARInvoiceNumber
            ARType
            TotalAmount
            TotalBilledAmount
            InterimRec
            InterimFlag
            AdvancedType
            BillTypeCode
            BillTypeDescription
            BillTypeSort
            DatePaid
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _ARType As String = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBilledAmount As Nullable(Of Decimal) = Nothing
        Private _InterimRec As Nullable(Of Byte) = Nothing
        Private _InterimFlag As String = Nothing
        Private _AdvancedType As Nullable(Of Byte) = Nothing
        Private _BillTypeCode As String = Nothing
        Private _BillTypeDescription As String = Nothing
        Private _BillTypeSort As Nullable(Of Byte) = Nothing
        Private _DatePaid As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ARInvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARType() As String
            Get
                ARType = _ARType
            End Get
            Set(ByVal value As String)
                _ARType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property TotalBilledAmount() As Nullable(Of Decimal)
            Get
                TotalBilledAmount = _TotalBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBilledAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InterimRec() As Nullable(Of Byte)
            Get
                InterimRec = _InterimRec
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _InterimRec = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InterimFlag() As String
            Get
                InterimFlag = _InterimFlag
            End Get
            Set(ByVal value As String)
                _InterimFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvancedType() As Nullable(Of Byte)
            Get
                AdvancedType = _AdvancedType
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _AdvancedType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillTypeCode() As String
            Get
                BillTypeCode = _BillTypeCode
            End Get
            Set(ByVal value As String)
                _BillTypeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillTypeDescription() As String
            Get
                BillTypeDescription = _BillTypeDescription
            End Get
            Set(ByVal value As String)
                _BillTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillTypeSort() As Nullable(Of Byte)
            Get
                BillTypeSort = _BillTypeSort
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _BillTypeSort = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DatePaid() As Nullable(Of Date)
            Get
                DatePaid = _DatePaid
            End Get
            Set(value As Nullable(Of Date))
                _DatePaid = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber

        End Function

#End Region

    End Class

End Namespace
