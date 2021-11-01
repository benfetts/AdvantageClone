Namespace Security.Database.Entities

	<Table("CP_USER")>
	Public Class ClientPortalUser
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserName
			LoweredUserName
			FullName
			Password
			LastLoginDate
			CreatedByUserCode
			CreatedDate
			IsLocked
			EmailAddress
			LoginsAttempted
			UnlockedDate
			MustChangePassword
			Theme
			ClientContactID
			DesktopTemplate
			WebID
			IsAdminUser
			ClientCode
			AlertGroupCode
            AgencyContactEmployeeCode
            TimeZoneID
            ConceptShareUserID
			ConceptSharePassword
			ClientPortalUserApplicationAccesses
			ClientPortalUserModuleAccesses
			ClientContact
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("USER_GUID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Guid
		<Required>
		<MaxLength(100)>
		<Column("USER_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property UserName() As String
		<Required>
		<MaxLength(100)>
		<Column("LOWERED_USER_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LoweredUserName() As String
		<MaxLength(100)>
		<Column("FULL_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FullName() As String
		<Required>
		<MaxLength(44)>
		<Column("PASSWORD_HASH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Password() As String
		<Column("LAST_LOGON")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastLoginDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Column("CREATED_TIMESTAMP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<Column("IS_LOCKED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsLocked() As Nullable(Of Boolean)
		<MaxLength(100)>
		<Column("EMAIL_ADDRESS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailAddress() As String
		<Required>
		<Column("LOGIN_TRY_COUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LoginsAttempted() As Short
		<Column("UNLOCK_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UnlockedDate() As Nullable(Of Date)
		<Required>
		<Column("MUST_CHANGE_PASSORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MustChangePassword() As Boolean
		<Required>
		<MaxLength(20)>
		<Column("THEME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Theme() As String
		<Required>
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Integer
		<Column("DESKTOP_TEMPLATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DesktopTemplate() As Nullable(Of Integer)
		<MaxLength(50)>
		<Column("WEB_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebID() As String
		<Required>
		<Column("ADMIN_USER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAdminUser() As Boolean
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(50)>
		<Column("ALERT_GROUP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertGroupCode() As String
		<MaxLength(6)>
		<Column("AGENCY_CONTACT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AgencyContactEmployeeCode() As String
        <Column("TIME_ZONE_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeZoneID() As String
        <Column("CS_USERID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareUserID() As Nullable(Of Integer)
        <Column("CS_PASSWORD", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ConceptSharePassword() As String

		Public Overridable Property ClientPortalUserApplicationAccesses As ICollection(Of Database.Entities.ClientPortalUserApplicationAccess)
        Public Overridable Property ClientPortalUserModuleAccesses As ICollection(Of Database.Entities.ClientPortalUserModuleAccess)
        <ForeignKey("ClientContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserName

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.UserName.ToString

                    If Me.IsEntityBeingAdded() Then

                        If AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByUserName(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "Please enter a unique user name."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
