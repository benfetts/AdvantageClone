Namespace Security.Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdassistUsers
            AdvantageUserLicenseInUses
            ApplicationModules
            Applications
            ApplicationSettings
            ClientPortalUserApplicationAccesses
            ClientPortalUserModuleAccesses
            ClientPortalUsers
            ClientPortalUserWorkspaces
            ClientPortalWorkspaceObjects
            CPUserFavoriteModules
            DatabaseSQLUsers
            EmployeeSummaries
            GroupApplicationAccesses
            GroupModuleAccesses
            GroupPermissions
            GroupPermissionsReports
            Groups
            GroupSettings
            GroupUserDefinedReportAccesses
            GroupUsers
            ModuleInformations
            Modules
            ModuleStructures
            ModuleSubs
            ModuleViews
            ReportAccesses
            Reports
            SecurityClientContactDetails
            SecurityClientContacts
            SecurityClients
            SecurityDepartments
            SecurityDivisions
            SecurityEmployees
            SecurityOffices
            SecurityProducts
            ServerSQLUsers
            ServiceFeeReconciliationReportColumns
            ServiceFeeReconciliationReports
            ServiceFeeReconciliationReportSummaryItems
            ServiceFeeReconciliationSettingCDPs
            ServiceFeeReconciliationSettingDetails
            ServiceFeeReconciliationSettings
            UserApplicationAccesses
            UserClientDivisionProductAccesses
            UserEmployeeAccesses
            UserFavoriteModules
            UserLoginAudits
            UserMenus
            UserMenuTabs
            UserModuleAccesses
            UserPermissionsReports
            UserPermissions
            Users
            UserSettings
            UserUserDefinedReportAccesses
            UserUserDefinedReportPermissions
            UserWorkspaces
            WorkspaceObjects
            WorkspaceTemplateDetails
            WorkspaceTemplateItems
            WorkspaceTemplates
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property AdassistUsers As System.Data.Entity.DbSet(Of Security.Database.Entities.AdassistUser)
        Public Overridable Property AdvantageUserLicenseInUses As System.Data.Entity.DbSet(Of Security.Database.Entities.AdvantageUserLicenseInUse)
        Public Overridable Property ApplicationModules As System.Data.Entity.DbSet(Of Security.Database.Entities.ApplicationModule)
        Public Overridable Property Applications As System.Data.Entity.DbSet(Of Security.Database.Entities.Application)
        Public Overridable Property ApplicationSettings As System.Data.Entity.DbSet(Of Security.Database.Entities.ApplicationSetting)
        Public Overridable Property CDPSecurityGroups As System.Data.Entity.DbSet(Of Security.Database.Entities.CDPSecurityGroup)
        Public Overridable Property CDPSecurityGroupEmployees As System.Data.Entity.DbSet(Of Security.Database.Entities.CDPSecurityGroupEmployee)
        Public Overridable Property ClientPortalUserApplicationAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientPortalUserApplicationAccess)
        Public Overridable Property ClientPortalUserModuleAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientPortalUserModuleAccess)
        Public Overridable Property ClientPortalUsers As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientPortalUser)
        Public Overridable Property ClientPortalUserWorkspaces As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientPortalUserWorkspace)
        Public Overridable Property ClientPortalWorkspaceObjects As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientPortalWorkspaceObject)
        Public Overridable Property CPUserFavoriteModules As System.Data.Entity.DbSet(Of Security.Database.Entities.CPUserFavoriteModule)
        Public Overridable Property DatabaseSQLUsers As System.Data.Entity.DbSet(Of Security.Database.Views.DatabaseSQLUser)
        Public Overridable Property EmployeeSummaries As System.Data.Entity.DbSet(Of Security.Database.Views.EmployeeSummary)
        Public Overridable Property GroupApplicationAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.GroupApplicationAccess)
        Public Overridable Property GroupModuleAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.GroupModuleAccess)
        Public Overridable Property GroupPermissions As System.Data.Entity.DbSet(Of Security.Database.Views.GroupPermission)
        Public Overridable Property GroupPermissionsReports As System.Data.Entity.DbSet(Of Security.Database.Views.GroupPermissionsReport)
        Public Overridable Property Groups As System.Data.Entity.DbSet(Of Security.Database.Entities.Group)
        Public Overridable Property GroupSettings As System.Data.Entity.DbSet(Of Security.Database.Entities.GroupSetting)
        Public Overridable Property GroupUserDefinedReportAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.GroupUserDefinedReportAccess)
        Public Overridable Property GroupUsers As System.Data.Entity.DbSet(Of Security.Database.Entities.GroupUser)
        Public Overridable Property ModuleInformations As System.Data.Entity.DbSet(Of Security.Database.Entities.ModuleInformation)
        Public Overridable Property Modules As System.Data.Entity.DbSet(Of Security.Database.Entities.[Module])
        Public Overridable Property ModuleStructures As System.Data.Entity.DbSet(Of Security.Database.Views.ModuleStructure)
        Public Overridable Property ModuleSubs As System.Data.Entity.DbSet(Of Security.Database.Entities.ModuleSub)
        Public Overridable Property ModuleViews As System.Data.Entity.DbSet(Of Security.Database.Views.ModuleView)
        Public Overridable Property PasswordHistories As System.Data.Entity.DbSet(Of Security.Database.Entities.PasswordHistory)
        Public Overridable Property PasswordLockouts As System.Data.Entity.DbSet(Of Security.Database.Entities.PasswordLockout)
        Public Overridable Property ReportAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.ReportAccess)
        Public Overridable Property Reports As System.Data.Entity.DbSet(Of Security.Database.Entities.Report)
        Public Overridable Property SecurityClientContactDetails As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientContactDetail)
        Public Overridable Property SecurityClientContacts As System.Data.Entity.DbSet(Of Security.Database.Entities.ClientContact)
        Public Overridable Property SecurityClients As System.Data.Entity.DbSet(Of Security.Database.Entities.Client)
        Public Overridable Property SecurityDepartments As System.Data.Entity.DbSet(Of Security.Database.Entities.Department)
        Public Overridable Property SecurityDivisions As System.Data.Entity.DbSet(Of Security.Database.Entities.Division)
        Public Overridable Property SecurityEmployees As System.Data.Entity.DbSet(Of Security.Database.Views.Employee)
        Public Overridable Property SecurityOffices As System.Data.Entity.DbSet(Of Security.Database.Entities.Office)
        Public Overridable Property SecurityProducts As System.Data.Entity.DbSet(Of Security.Database.Entities.Product)
        Public Overridable Property ServerSQLUsers As System.Data.Entity.DbSet(Of Security.Database.Views.ServerSQLUser)
        Public Overridable Property ServiceFeeReconciliationReportColumns As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationReportColumn)
        Public Overridable Property ServiceFeeReconciliationReports As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationReport)
        Public Overridable Property ServiceFeeReconciliationReportSummaryItems As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem)
        Public Overridable Property ServiceFeeReconciliationSettingCDPs As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationSettingCDP)
        Public Overridable Property ServiceFeeReconciliationSettingDetails As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationSettingDetail)
        Public Overridable Property ServiceFeeReconciliationSettings As System.Data.Entity.DbSet(Of Security.Database.Entities.ServiceFeeReconciliationSetting)
        Public Overridable Property UserApplicationAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.UserApplicationAccess)
        Public Overridable Property UserClientDivisionProductAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.UserClientDivisionProductAccess)
        Public Overridable Property UserEmployeeAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.UserEmployeeAccess)
        Public Overridable Property UserFavoriteModules As System.Data.Entity.DbSet(Of Security.Database.Entities.UserFavoriteModule)
        Public Overridable Property UserLoginAudits As System.Data.Entity.DbSet(Of Security.Database.Entities.UserLoginAudit)
        Public Overridable Property UserMenus As System.Data.Entity.DbSet(Of Security.Database.Entities.UserMenu)
        Public Overridable Property UserMenuTabs As System.Data.Entity.DbSet(Of Security.Database.Entities.UserMenuTab)
        Public Overridable Property UserModuleAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.UserModuleAccess)
        Public Overridable Property UserPermissionsReports As System.Data.Entity.DbSet(Of Security.Database.Views.UserPermissionsReport)
        Public Overridable Property UserPermissions As System.Data.Entity.DbSet(Of Security.Database.Views.UserPermission)
        Public Overridable Property Users As System.Data.Entity.DbSet(Of Security.Database.Entities.User)
        Public Overridable Property UserSettings As System.Data.Entity.DbSet(Of Security.Database.Entities.UserSetting)
        Public Overridable Property UserUserDefinedReportAccesses As System.Data.Entity.DbSet(Of Security.Database.Entities.UserUserDefinedReportAccess)
        Public Overridable Property UserUserDefinedReportPermissions As System.Data.Entity.DbSet(Of Security.Database.Views.UserUserDefinedReportPermission)
        Public Overridable Property UserWorkspaces As System.Data.Entity.DbSet(Of Security.Database.Entities.UserWorkspace)
        Public Overridable Property WorkspaceObjects As System.Data.Entity.DbSet(Of Security.Database.Entities.WorkspaceObject)
        Public Overridable Property WorkspaceTemplateDetails As System.Data.Entity.DbSet(Of Security.Database.Entities.WorkspaceTemplateDetail)
        Public Overridable Property WorkspaceTemplateItems As System.Data.Entity.DbSet(Of Security.Database.Entities.WorkspaceTemplateItem)
        Public Overridable Property WorkspaceTemplates As System.Data.Entity.DbSet(Of Security.Database.Entities.WorkspaceTemplate)

#End Region

#Region " Methods "

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.Security)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Security.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            'modelBuilder.Properties.Having(Function(Prop) Prop.GetCustomAttributes(False).OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault).
            '                        Configure(Function(Prop, Attribute) Prop.HasPrecision(Attribute.Precision, Attribute.Scale))

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace
