Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="Search")>
    <Serializable()>
    Public Class Search
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            ProductCode
            GroupID
            Group
            MatchingText
            Link
            ID1
            ID2
            ID3
            ID4
            ID5
            ID6
            ID7
            ID8
            ID9
            ID10
            GroupCount
            DateForSort
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _GroupID As Nullable(Of Byte) = Nothing
        Private _Group As String = Nothing
        Private _MatchingText As String = Nothing
        Private _Link As String = Nothing
        Private _ID1 As Nullable(Of Integer) = Nothing
        Private _ID2 As Nullable(Of Integer) = Nothing
        Private _ID3 As Nullable(Of Integer) = Nothing
        Private _ID4 As Nullable(Of Integer) = Nothing
        Private _ID5 As Nullable(Of Integer) = Nothing
        Private _ID6 As String = Nothing
        Private _ID7 As String = Nothing
        Private _ID8 As String = Nothing
        Private _ID9 As String = Nothing
        Private _ID10 As String = Nothing
        Private _GroupCount As Nullable(Of Integer) = Nothing
        Private _DateForSort As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
  Public Property GroupID() As Nullable(Of Byte)
            Get
                GroupID = _GroupID
            End Get
            Set(value As Nullable(Of Byte))
                _GroupID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property Group() As String
            Get
                Group = _Group
            End Get
            Set(value As String)
                _Group = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property MatchingText() As String
            Get
                MatchingText = _MatchingText
            End Get
            Set(value As String)
                _MatchingText = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property Link() As String
            Get
                Link = _Link
            End Get
            Set(value As String)
                _Link = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID1() As Nullable(Of Integer)
            Get
                ID1 = _ID1
            End Get
            Set(value As Nullable(Of Integer))
                _ID1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID2() As Nullable(Of Integer)
            Get
                ID2 = _ID2
            End Get
            Set(value As Nullable(Of Integer))
                _ID2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID3() As Nullable(Of Integer)
            Get
                ID3 = _ID3
            End Get
            Set(value As Nullable(Of Integer))
                _ID3 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID4() As Nullable(Of Integer)
            Get
                ID4 = _ID4
            End Get
            Set(value As Nullable(Of Integer))
                _ID4 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID5() As Nullable(Of Integer)
            Get
                ID5 = _ID5
            End Get
            Set(value As Nullable(Of Integer))
                _ID5 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID6() As String
            Get
                ID6 = _ID6
            End Get
            Set(value As String)
                _ID6 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID7() As String
            Get
                ID7 = _ID7
            End Get
            Set(value As String)
                _ID7 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID8() As String
            Get
                ID8 = _ID8
            End Get
            Set(value As String)
                _ID8 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID9() As String
            Get
                ID9 = _ID9
            End Get
            Set(value As String)
                _ID9 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property ID10() As String
            Get
                ID10 = _ID10
            End Get
            Set(value As String)
                _ID10 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property GroupCount() As Nullable(Of Integer)
            Get
                GroupCount = _GroupCount
            End Get
            Set(value As Nullable(Of Integer))
                _GroupCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property DateForSort() As Nullable(Of Date)
            Get
                DateForSort = _DateForSort
            End Get
            Set(value As Nullable(Of Date))
                _DateForSort = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
