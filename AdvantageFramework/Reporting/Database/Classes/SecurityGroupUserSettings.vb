Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SecurityGroupUserSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            GroupName
            GroupDescription
            UserCode
            Inactive
            EmployeeCode
            EmployeeName
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
            AllowTaskEdit
            AllowMediaPageEdit
            AllowUserToAddHolidays
            AllowUserToViewOtherEmployees
            ShowAllAssignments
            ShowUnassignedAssignments
            CanUploadDocuments
            ViewPrivateDocuments
            CreateWorkspaceTemplate
            LimitTimeEntry
            LimitTimesheetFunctions
            LimitPOsToEmployee
            WebvantageUserOnly
            AllowProfileUpdate
            CheckForUserAccess
            IsCRMUser
            IsMediaToolsUser

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("GroupName")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupName() As String
        <Column("GroupDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDescription() As String
        <Column("UserCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <Column("Inactive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Inactive() As String
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
        <Column("AllowTaskEdit", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowTaskEdit() As String
        <Column("AllowMediaPageEdit", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowMediaPageEdit() As String
        <Column("AllowUserToAddHolidays", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowUserToAddHolidays() As String
        <Column("AllowUserToViewOtherEmployees", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowUserToViewOtherEmployees() As String
        <Column("ShowAllAssignments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAllAssignments() As String
        <Column("ShowUnassignedAssignments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowUnassignedAssignments() As String
        <Column("CanUploadDocuments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanUploadDocuments() As String
        <Column("ViewPrivateDocuments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ViewPrivateDocuments() As String
        <Column("CreateWorkspaceTemplate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateWorkspaceTemplate() As String
        <Column("LimitTimeEntry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LimitTimeEntry() As String
        <Column("LimitTimesheetFunctions", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LimitTimesheetFunctions() As String
        <Column("LimitPOsToEmployee", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LimitPOsToEmployee() As String
        <Column("WebvantageUserOnly", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WebvantageUserOnly() As String
        <Column("AllowProfileUpdate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowProfileUpdate() As String
        <Column("CheckForUserAccess", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckForUserAccess() As String
        <Column("IsCRMUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCRMUser() As String
        <Column("IsMediaToolsUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMediaToolsUser() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GroupName.ToString

        End Function

#End Region

    End Class

End Namespace
