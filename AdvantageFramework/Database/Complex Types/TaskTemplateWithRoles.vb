Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="TaskTemplateWithRoles")>
    <Serializable()>
    Public Class TaskTemplateWithRoles
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PhaseID
            PhaseDescription
            TaskCode
            TaskDescription
            Roles
        End Enum

#End Region

#Region " Variables "

        Private _PhaseID As Nullable(Of Integer) = Nothing
        Private _PhaseDescription As String = Nothing
        Private _TaskCode As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _Roles As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PhaseID() As Nullable(Of Integer)
            Get
                PhaseID = _PhaseID
            End Get
            Set(value As Nullable(Of Integer))
                _PhaseID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PhaseDescription() As String
            Get
                PhaseDescription = _PhaseDescription
            End Get
            Set(value As String)
                _PhaseDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(value As String)
                _TaskCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Roles() As String
            Get
                Roles = _Roles
            End Get
            Set(value As String)
                _Roles = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.PhaseID.ToString

        End Function

#End Region

    End Class

End Namespace
