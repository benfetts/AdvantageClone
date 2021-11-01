Namespace Database.Entities

	<Table("CDP_CONTACT_HDR")>
	Public Class ClientContact
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ContactID
			ContactCode
			ClientCode
			EmailAddress
			FirstName
			LastName
			MiddleInitial
			Title
			Address
			Address2
			City
			County
			State
			Country
			Zip
			Telephone
			TelephoneExtension
			Fax
			FaxExtension
			ScheduleUser
			DefaultTaskCode
			GetAlerts
			GetEmails
			IsPrimaryTask
			IsInactive
			CellPhone
			Comments
			IsClientPortalUser
			ContactTypeID
			Client
			Task
			JobComponents
			ClientContactDetail
			ClientAccountsReceivableStatements
			ProductAccountsReceivableStatements
			JobComponentTaskClientContacts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ContactID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("CONT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property ContactCode() As String
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(50)>
		<Column("EMAIL_ADDRESS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
		Public Property EmailAddress() As String
		<MaxLength(30)>
		<Column("CONT_FNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FirstName() As String
		<MaxLength(30)>
		<Column("CONT_LNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastName() As String
		<MaxLength(1)>
		<Column("CONT_MI", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiddleInitial() As String
		<MaxLength(40)>
		<Column("CONT_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Title() As String
		<MaxLength(40)>
		<Column("CONT_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("CONT_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("CONT_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("CONT_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("CONT_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("CONT_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("CONT_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(13)>
		<Column("CONT_TELEPHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Telephone() As String
		<MaxLength(5)>
		<Column("CONT_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelephoneExtension() As String
		<MaxLength(13)>
		<Column("CONT_FAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax() As String
		<MaxLength(5)>
		<Column("CONT_FAX_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxExtension() As String
		<Column("SCHEDULE_USER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ScheduleUser() As Nullable(Of Short)
        <MaxLength(10)>
        <Column("DEFAULT_TASK", TypeName:="varchar")>
        <ForeignKey("Task")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DefaultTaskCode() As String
		<Column("CP_ALERTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property GetAlerts() As Nullable(Of Short)
		<Column("EMAIL_RCPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property GetEmails() As Nullable(Of Short)
		<Column("TASK_PRIMARY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property IsPrimaryTask() As Nullable(Of Short)
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(13)>
		<Column("CELL_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CellPhone() As String
		<Column("CONT_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<Column("CP_USER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsClientPortalUser() As Nullable(Of Short)
		<Column("CONTACT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ContactTypeID)>
		Public Property ContactTypeID() As Nullable(Of Integer)

        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property Task As Database.Entities.Task
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
        Public Overridable Property ClientContactDetail As ICollection(Of Database.Entities.ClientContactDetail)
        Public Overridable Property ClientAccountsReceivableStatements As ICollection(Of Database.Entities.ClientAccountsReceivableStatement)
        Public Overridable Property ProductAccountsReceivableStatements As ICollection(Of Database.Entities.ProductAccountsReceivableStatement)
        Public Overridable Property JobComponentTaskClientContacts As ICollection(Of Database.Entities.JobComponentTaskClientContact)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ClientContact.Properties.ContactCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientContact
                            Where Entity.ContactCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                        Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique contact code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
