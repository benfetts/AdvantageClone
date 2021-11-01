Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SecurityUserModuleAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            UserID
            UserCode
            EmployeeCode
            EmployeeName
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
            ApplicationID
            ApplicationName
            ApplicationIsBlocked
            ModuleID
            ParentModule
            SubParentModule
            SubSubParentModule
            [Module]
            ModuleIsBlocked
            ModuleCanPrint
            ModuleCanUpdate
            ModuleCanAdd
            ModuleCustom1
            ModuleCustom2
            ParentModuleSortOrder
            SubParentModuleSortOrder
            SubSubParentModuleSortOrder
            ModuleSortOrder

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("UserID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As Integer
        <Column("UserCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <Column("EmployeeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
        <Column("EmployeeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeName() As String
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <Column("DepartmentCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentCode() As String
        <Column("DepartmentName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentName() As String
        <Column("ApplicationID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationID() As Integer
        <Column("ApplicationName")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationName() As String
        <Column("ApplicationIsBlocked")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationIsBlocked() As String
        <Column("ModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ModuleID() As Integer
        <Column("ParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModule() As String
        <Column("SubParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModule() As String
        <Column("SubSubParentModule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModule() As String
        <Column("Module", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Module]() As String
        <Column("ModuleIsBlocked")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleIsBlocked() As String
        <Column("ModuleCanPrint")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCanPrint() As String
        <Column("ModuleCanUpdate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCanUpdate() As String
        <Column("ModuleCanAdd")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCanAdd() As String
        <Column("ModuleCustom1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCustom1() As String
        <Column("ModuleCustom2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCustom2() As String
        <Column("ParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentModuleSortOrder() As Nullable(Of Integer)
        <Column("SubParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubParentModuleSortOrder() As Nullable(Of Integer)
        <Column("SubSubParentModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubSubParentModuleSortOrder() As Nullable(Of Integer)
        <Column("ModuleSortOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleSortOrder() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserID.ToString

        End Function

#End Region

    End Class

End Namespace
