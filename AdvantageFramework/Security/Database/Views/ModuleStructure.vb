Namespace Security.Database.Views

    <Table("V_SEC_MODULES_STRUCT")>
    Public Class ModuleStructure
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
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
            ModuleSortOrder
            ModuleHasCustomPermission

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Long
        <Column("ParentModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModuleID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("ParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModule() As String
        <Column("ParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModuleSortOrder() As Nullable(Of Integer)
        <Column("SubParentModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModuleID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("SubParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModule() As String
        <Column("SubParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModuleSortOrder() As Nullable(Of Integer)
        <Column("SubSubParentModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModuleID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("SubSubParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModule() As String
        <Column("SubSubParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModuleSortOrder() As Nullable(Of Integer)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("ModuleCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCode() As String
        <Required>
        <MaxLength(100)>
        <Column("Module", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Module]() As String
        <Column("ModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleSortOrder() As Nullable(Of Integer)
        <Column("ModuleHasCustomPermission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleHasCustomPermission() As Nullable(Of Boolean)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
