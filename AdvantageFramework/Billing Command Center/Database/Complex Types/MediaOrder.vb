Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="MediaOrder")>
    <Serializable()>
    Public Class MediaOrder
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            LineNumber
            BroadcastYear
            BroadcastMonth
            MediaFrom
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _BroadcastYear As Nullable(Of Short) = Nothing
        Private _BroadcastMonth As Nullable(Of Short) = Nothing
        Private _MediaFrom As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastYear() As Nullable(Of Short)
            Get
                BroadcastYear = _BroadcastYear
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastMonth() As Nullable(Of Short)
            Get
                BroadcastMonth = _BroadcastMonth
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastMonth = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
