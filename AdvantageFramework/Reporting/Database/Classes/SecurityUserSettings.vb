Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SecurityUserSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            UserCode
            Inactive
            EmployeeCode
            EmployeeName
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
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

            ToString = Me.UserCode.ToString

        End Function

#End Region

    End Class

End Namespace
