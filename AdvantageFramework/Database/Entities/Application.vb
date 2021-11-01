Namespace Database.Entities

    <System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="ObjectContext", Name:="Application")>
    <Serializable()>
    Public Class Application
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            SecurityCode
            ModuleCode
            Subgroup
            IconNumber
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Description As String = Nothing
        Private _SecurityCode As String = Nothing
        Private _ModuleCode As String = Nothing
        Private _Subgroup As String = Nothing
        Private _IconNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SecurityCode() As String
            Get
                SecurityCode = _SecurityCode
            End Get
            Set(ByVal value As String)
                _SecurityCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ModuleCode() As String
            Get
                ModuleCode = _ModuleCode
            End Get
            Set(ByVal value As String)
                _ModuleCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Subgroup() As String
            Get
                Subgroup = _Subgroup
            End Get
            Set(ByVal value As String)
                _Subgroup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IconNumber() As Nullable(Of Short)
            Get
                IconNumber = _IconNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IconNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function

#End Region

    End Class

End Namespace
