Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="MyObjectDefinition")>
    <Serializable()>
    Public Class MyObjectDefinition
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ObjectDefinitionID
            ObjectID
            ObjectDescription
            ObjectType
            DefinitionID
            DefinitionDescription
            IsStatic
            Checked
        End Enum

#End Region

#Region " Variables "

        Private _ObjectDefinitionID As Nullable(Of Integer) = Nothing
        Private _ObjectID As Nullable(Of Integer) = Nothing
        Private _ObjectDescription As String = Nothing
        Private _ObjectType As Nullable(Of Integer) = Nothing
        Private _DefinitionID As Nullable(Of Integer) = Nothing
        Private _DefinitionDescription As String = Nothing
        Private _IsStatic As Nullable(Of Boolean) = Nothing
        Private _Checked As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectDefinitionID() As Nullable(Of Integer)
            Get
                ObjectDefinitionID = _ObjectDefinitionID
            End Get
            Set(value As Nullable(Of Integer))
                _ObjectDefinitionID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectID() As Nullable(Of Integer)
            Get
                ObjectID = _ObjectID
            End Get
            Set(value As Nullable(Of Integer))
                _ObjectID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectDescription() As String
            Get
                ObjectDescription = _ObjectDescription
            End Get
            Set(value As String)
                _ObjectDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectType() As Nullable(Of Integer)
            Get
                ObjectType = _ObjectType
            End Get
            Set(value As Nullable(Of Integer))
                _ObjectType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefinitionID() As Nullable(Of Integer)
            Get
                DefinitionID = _DefinitionID
            End Get
            Set(value As Nullable(Of Integer))
                _DefinitionID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DefinitionDescription() As String
            Get
                DefinitionDescription = _DefinitionDescription
            End Get
            Set(value As String)
                _DefinitionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsStatic() As Nullable(Of Boolean)
            Get
                IsStatic = _IsStatic
            End Get
            Set(value As Nullable(Of Boolean))
                _IsStatic = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Checked() As Nullable(Of Boolean)
            Get
                Checked = _Checked
            End Get
            Set(value As Nullable(Of Boolean))
                _Checked = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ObjectDefinitionID.ToString

        End Function

#End Region

    End Class

End Namespace
