Namespace Security.Database.Views

    <System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="SecurityObjectContext", Name:="UserPerimissionsReport")>
    <Serializable()>
    Public Class UserPerimissionsReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ApplicationID
            ParentModuleID
            ParentModule
            ParentModuleSortOrder
            SubParentModuleID
            SubParentModule
            SubParentModuleSortOrder
            SubSubParentModuleID
            SubSubParentModule
            SubSubParentModuleSortOrder
            ModuleID
            ModuleCode
            [Module]
            ModuleIsCategory
            ModuleInfoID
            ModuleSortOrder
            ModuleHasCustomPermission
            UserID
            UserCode
            EmployeeCode
            Employee
            IsBlocked
            CanPrint
            CanUpdate
            CanAdd
            Custom1
            Custom2
            ApplicationIsBlocked
            ApplicationCanPrint
            ApplicationCanUpdate
            ApplicationCanAdd
            ApplicationCustom1
            ApplicationCustom2
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ApplicationID As Integer = Nothing
        Private _ParentModuleID As Nullable(Of Integer) = Nothing
        Private _ParentModule As String = Nothing
        Private _ParentModuleSortOrder As Nullable(Of Integer) = Nothing
        Private _SubParentModuleID As Nullable(Of Integer) = Nothing
        Private _SubParentModule As String = Nothing
        Private _SubParentModuleSortOrder As Nullable(Of Integer) = Nothing
        Private _SubSubParentModuleID As Nullable(Of Integer) = Nothing
        Private _SubSubParentModule As String = Nothing
        Private _SubSubParentModuleSortOrder As Nullable(Of Integer) = Nothing
        Private _ModuleID As Integer = Nothing
        Private _ModuleCode As String = Nothing
        Private _Module As String = Nothing
        Private _ModuleIsCategory As Boolean = Nothing
        Private _ModuleInfoID As Integer = Nothing
        Private _ModuleSortOrder As Nullable(Of Integer) = Nothing
        Private _ModuleHasCustomPermission As Nullable(Of Boolean) = Nothing
        Private _UserID As Integer = Nothing
        Private _UserCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _IsBlocked As Boolean = Nothing
        Private _CanPrint As Boolean = Nothing
        Private _CanUpdate As Boolean = Nothing
        Private _CanAdd As Boolean = Nothing
        Private _Custom1 As Boolean = Nothing
        Private _Custom2 As Boolean = Nothing
        Private _ApplicationIsBlocked As Boolean = Nothing
        Private _ApplicationCanPrint As Boolean = Nothing
        Private _ApplicationCanUpdate As Boolean = Nothing
        Private _ApplicationCanAdd As Boolean = Nothing
        Private _ApplicationCustom1 As Boolean = Nothing
        Private _ApplicationCustom2 As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationID() As Integer
            Get
                ApplicationID = _ApplicationID
            End Get
            Set(ByVal value As Integer)
                _ApplicationID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModuleID() As Nullable(Of Integer)
            Get
                ParentModuleID = _ParentModuleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ParentModuleID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModule() As String
            Get
                ParentModule = _ParentModule
            End Get
            Set(ByVal value As String)
                _ParentModule = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModuleSortOrder() As Nullable(Of Integer)
            Get
                ParentModuleSortOrder = _ParentModuleSortOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ParentModuleSortOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModuleID() As Nullable(Of Integer)
            Get
                SubParentModuleID = _SubParentModuleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SubParentModuleID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModule() As String
            Get
                SubParentModule = _SubParentModule
            End Get
            Set(ByVal value As String)
                _SubParentModule = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModuleSortOrder() As Nullable(Of Integer)
            Get
                SubParentModuleSortOrder = _SubParentModuleSortOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SubParentModuleSortOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModuleID() As Nullable(Of Integer)
            Get
                SubSubParentModuleID = _SubSubParentModuleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SubSubParentModuleID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModule() As String
            Get
                SubSubParentModule = _SubSubParentModule
            End Get
            Set(ByVal value As String)
                _SubSubParentModule = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModuleSortOrder() As Nullable(Of Integer)
            Get
                SubSubParentModuleSortOrder = _SubSubParentModuleSortOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SubSubParentModuleSortOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleID() As Integer
            Get
                ModuleID = _ModuleID
            End Get
            Set(ByVal value As Integer)
                _ModuleID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCode() As String
            Get
                ModuleCode = _ModuleCode
            End Get
            Set(ByVal value As String)
                _ModuleCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Module]() As String
            Get
                [Module] = _Module
            End Get
            Set(ByVal value As String)
                _Module = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleIsCategory() As Boolean
            Get
                ModuleIsCategory = _ModuleIsCategory
            End Get
            Set(ByVal value As Boolean)
                _ModuleIsCategory = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleInfoID() As Integer
            Get
                ModuleInfoID = _ModuleInfoID
            End Get
            Set(ByVal value As Integer)
                _ModuleInfoID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleSortOrder() As Nullable(Of Integer)
            Get
                ModuleSortOrder = _ModuleSortOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ModuleSortOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleHasCustomPermission() As Nullable(Of Boolean)
            Get
                ModuleHasCustomPermission = _ModuleHasCustomPermission
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ModuleHasCustomPermission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As Integer
            Get
                UserID = _UserID
            End Get
            Set(ByVal value As Integer)
                _UserID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(ByVal value As String)
                _Employee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
            System.Runtime.Serialization.DataMemberAttribute(),
            AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsBlocked() As Boolean
            Get
                IsBlocked = _IsBlocked
            End Get
            Set(ByVal value As Boolean)
                _IsBlocked = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanPrint() As Boolean
            Get
                CanPrint = _CanPrint
            End Get
            Set(ByVal value As Boolean)
                _CanPrint = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanUpdate() As Boolean
            Get
                CanUpdate = _CanUpdate
            End Get
            Set(ByVal value As Boolean)
                _CanUpdate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanAdd() As Boolean
            Get
                CanAdd = _CanAdd
            End Get
            Set(ByVal value As Boolean)
                _CanAdd = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom1() As Boolean
            Get
                Custom1 = _Custom1
            End Get
            Set(ByVal value As Boolean)
                _Custom1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom2() As Boolean
            Get
                Custom2 = _Custom2
            End Get
            Set(ByVal value As Boolean)
                _Custom2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationIsBlocked() As Boolean
            Get
                ApplicationIsBlocked = _ApplicationIsBlocked
            End Get
            Set(ByVal value As Boolean)
                _ApplicationIsBlocked = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanPrint() As Boolean
            Get
                ApplicationCanPrint = _ApplicationCanPrint
            End Get
            Set(ByVal value As Boolean)
                _ApplicationCanPrint = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanUpdate() As Boolean
            Get
                ApplicationCanUpdate = _ApplicationCanUpdate
            End Get
            Set(ByVal value As Boolean)
                _ApplicationCanUpdate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanAdd() As Boolean
            Get
                ApplicationCanAdd = _ApplicationCanAdd
            End Get
            Set(ByVal value As Boolean)
                _ApplicationCanAdd = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCustom1() As Boolean
            Get
                ApplicationCustom1 = _ApplicationCustom1
            End Get
            Set(ByVal value As Boolean)
                _ApplicationCustom1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCustom2() As Boolean
            Get
                ApplicationCustom2 = _ApplicationCustom2
            End Get
            Set(ByVal value As Boolean)
                _ApplicationCustom2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
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
