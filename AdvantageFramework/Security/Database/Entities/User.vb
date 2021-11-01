Namespace Security.Database.Entities

	<Table("SEC_USER")>
	Public Class User
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserCode
			EmployeeCode
            UserName
            CheckForUserAccess
			TimeHWND
			MenuHWND
            WebID
            IsInactive
            Password
            SID
            'IsAdvanAdmin
            IsSecurityAdmin
            IsSysAdmin
            IsServerAdmin
            UserApplicationAccesses
			UserModuleAccesses
			GroupUsers
			UserSettings
			UserMenus
			UserMenuTabs
			Employee
			UserUserDefinedReportAccesses
            WorkspaceTemplates
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_USER_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property UserCode() As String
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Required>
		<MaxLength(128)>
		<Column("USER_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserName() As String
        <Required>
		<Column("CHECK_USER_ACCESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckForUserAccess() As Boolean
		<Column("TIME_HWND")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TimeHWND() As Nullable(Of Integer)
		<Column("MENU_HWND")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MenuHWND() As Nullable(Of Integer)
		<MaxLength(255)>
		<Column("WEB_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WebID() As String
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
        <Required(AllowEmptyStrings:=True)>
        <Column("PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Password() As String
        <Required(AllowEmptyStrings:=True)>
        <Column("SID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SID() As String
        '<Required>
        '<Column("IS_ADVAN_ADMIN")>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        'Public Property IsAdvanAdmin() As Boolean
        '<Required>
        '<Column("IS_SECURITY_ADMIN")>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        'Public Property IsSecurityAdmin() As Boolean
        '<Required>
        '<Column("IS_SYS_ADMIN")>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        'Public Property IsSysAdmin() As Boolean
        '<Required>
        '<Column("IS_SERVER_ADMIN")>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        'Public Property IsServerAdmin() As Boolean

        Public Overridable Property UserApplicationAccesses As ICollection(Of Database.Entities.UserApplicationAccess)
        Public Overridable Property UserModuleAccesses As ICollection(Of Database.Entities.UserModuleAccess)
        <ForeignKey("ID")>
        Public Overridable Property GroupUsers As ICollection(Of Database.Entities.GroupUser)
        Public Overridable Property UserSettings As ICollection(Of Database.Entities.UserSetting)
        Public Overridable Property UserMenus As ICollection(Of Database.Entities.UserMenu)
        Public Overridable Property UserMenuTabs As ICollection(Of Database.Entities.UserMenuTab)
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property UserUserDefinedReportAccesses As ICollection(Of Database.Entities.UserUserDefinedReportAccess)
        Public Overridable Property WorkspaceTemplates As ICollection(Of Database.Entities.WorkspaceTemplate)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Security.Database.Entities.User.Properties.UserCode

                    If Me.IsEntityBeingAdded() Then

                        If AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "User Code already exists in the system"

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
