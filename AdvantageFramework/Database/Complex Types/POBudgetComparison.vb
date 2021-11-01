Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="POBudgetComparison")>
    <Serializable()>
    Public Class POBudgetComparison
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAccount
            Budget
            POUsed
            Balance
        End Enum

#End Region

#Region " Variables "

        Private _GLAccount As String = Nothing
        Private _Budget As Nullable(Of Decimal) = Nothing
        Private _POUsed As Nullable(Of Decimal) = Nothing
        Private _Balance As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLAccount() As String
            Get
                GLAccount = _GLAccount
            End Get
            Set(value As String)
                _GLAccount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Budget() As Nullable(Of Decimal)
            Get
                Budget = _Budget
            End Get
            Set(value As Nullable(Of Decimal))
                _Budget = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property POUsed() As Nullable(Of Decimal)
            Get
                POUsed = _POUsed
            End Get
            Set(value As Nullable(Of Decimal))
                _POUsed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLAccount.ToString

        End Function

#End Region

    End Class

End Namespace
