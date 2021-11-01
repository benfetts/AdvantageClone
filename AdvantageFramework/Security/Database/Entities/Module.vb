Namespace Security.Database.Entities

    <Table("SEC_MODULE")>
    Public Class [Module]
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            IsInactive
            IsMenuItem
            IsCategory
            IsApplication
            IsReport
            IsDesktopObject
            IsDashQuery
            ModuleInformationID
            Code
            ApplicationModules
            GroupModuleAccesses
            UserModuleAccesses
            SubModules
            ParentSubModules
            ModuleInformation
            UserMenus
            WorkspaceTemplateItems
            ClientPortalUserModuleAccesses

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("SEC_MODULE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
        <Required>
        <Column("IS_MENU_ITEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMenuItem() As Boolean
        <Required>
        <Column("IS_CATEGORY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCategory() As Boolean
        <Required>
        <Column("IS_APPLICATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsApplication() As Boolean
        <Required>
        <Column("IS_REPORT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsReport() As Boolean
        <Required>
        <Column("IS_DESKTOP_OBJECT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDesktopObject() As Boolean
        <Required>
        <Column("IS_DASH_QUERY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDashQuery() As Boolean
        <Required>
        <Column("SEC_MODULE_INFO_ID")>
        <ForeignKey("ModuleInformation")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleInformationID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("SEC_MODULE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String

        Public Overridable Property ApplicationModules As ICollection(Of Database.Entities.ApplicationModule)
        Public Overridable Property GroupModuleAccesses As ICollection(Of Database.Entities.GroupModuleAccess)
        Public Overridable Property UserModuleAccesses As ICollection(Of Database.Entities.UserModuleAccess)
        Public Overridable Property SubModules As ICollection(Of Database.Entities.ModuleSub)
        Public Overridable Property ParentSubModules As ICollection(Of Database.Entities.ModuleSub)
        Public Overridable Property ModuleInformation As Database.Entities.ModuleInformation
        Public Overridable Property UserMenus As ICollection(Of Database.Entities.UserMenu)
        Public Overridable Property WorkspaceTemplateItems As ICollection(Of Database.Entities.WorkspaceTemplateItem)
        Public Overridable Property ClientPortalUserModuleAccesses As ICollection(Of Database.Entities.ClientPortalUserModuleAccess)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
