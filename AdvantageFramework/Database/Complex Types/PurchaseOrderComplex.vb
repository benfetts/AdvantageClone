Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="PurchaseOrderComplex")>
    <Serializable()>
    Public Class PurchaseOrderComplex
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            DisplayPONumber
            Description
            IsVoid
            IsComplete
            EmployeeCode
            EmployeeName
            VendorCode
            VendorName
            PODate
            PODueDate
            ModifiedByUserCode
            ModifiedDate
            SortOrder
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _DisplayPONumber As String = Nothing
        Private _Description As String = Nothing
        Private _IsVoid As Nullable(Of Short) = Nothing
        Private _IsComplete As Nullable(Of Short) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _PODate As Nullable(Of Date) = Nothing
        Private _PODueDate As Nullable(Of Date) = Nothing
        Private _ModifiedByUserCode As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _SortOrder As Integer = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(value As Integer)
                _Number = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Number")>
        Public Property DisplayPONumber() As String
            Get
                DisplayPONumber = _DisplayPONumber
            End Get
            Set(value As String)
                _DisplayPONumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Issued By")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="")>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Issued To")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property PODate() As Nullable(Of Date)
            Get
                PODate = _PODate
            End Get
            Set(value As Nullable(Of Date))
                _PODate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Due Date")>
        Public Property PODueDate() As Nullable(Of Date)
            Get
                PODueDate = _PODueDate
            End Get
            Set(value As Nullable(Of Date))
                _PODueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsVoid() As Nullable(Of Short)
            Get
                IsVoid = _IsVoid
            End Get
            Set(value As Nullable(Of Short))
                _IsVoid = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsComplete() As Nullable(Of Short)
            Get
                IsComplete = _IsComplete
            End Get
            Set(value As Nullable(Of Short))
                _IsComplete = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(value As String)
                _ModifiedByUserCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SortOrder() As Integer
            Get
                SortOrder = _SortOrder
            End Get
            Set
                _SortOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number.ToString

        End Function

#End Region

    End Class

End Namespace
