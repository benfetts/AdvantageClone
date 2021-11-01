Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="BillingStatus")>
    <Serializable()>
    Public Class BillingStatus
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsAssigned
            IsPrinted
            IsProcessed
            IsCoopSaved
            HasCoopJobs
        End Enum

#End Region

#Region " Variables "

        Private _IsAssigned As Nullable(Of Integer) = Nothing
        Private _IsPrinted As Nullable(Of Integer) = Nothing
        Private _IsProcessed As Boolean = Nothing
        Private _IsCoopSaved As Boolean = Nothing
        Private _HasCoopJobs As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAssigned() As Nullable(Of Integer)
            Get
                IsAssigned = _IsAssigned
            End Get
            Set(value As Nullable(Of Integer))
                _IsAssigned = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsPrinted() As Nullable(Of Integer)
            Get
                IsPrinted = _IsPrinted
            End Get
            Set(value As Nullable(Of Integer))
                _IsPrinted = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsProcessed() As Boolean
            Get
                IsProcessed = _IsProcessed
            End Get
            Set(value As Boolean)
                _IsProcessed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsCoopSaved() As Boolean
            Get
                IsCoopSaved = _IsCoopSaved
            End Get
            Set(value As Boolean)
                _IsCoopSaved = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HasCoopJobs() As Nullable(Of Boolean)
            Get
                HasCoopJobs = _HasCoopJobs
            End Get
            Set(value As Nullable(Of Boolean))
                _HasCoopJobs = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.IsAssigned.ToString

        End Function

#End Region

    End Class

End Namespace
