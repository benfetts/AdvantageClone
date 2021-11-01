Namespace Security.Database.Entities

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
            PhoneNumber
            PhoneNumberExtention
            FaxNumber
            FaxNumberExtention
            ScheduleUser
            DefaultTaskCode
            RecievesAlerts
            IsEmailRecipient
            IsPrimaryTask
            IsInactive
            CellPhoneNumber
            Comments
            IsClientPortalUser
            ContactTypeID
            ClientContactDetails
            Client
            ClientPortalUsers
            ClientPortalUserWorkspaces
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
		Public Property PhoneNumber() As String
		<MaxLength(5)>
		<Column("CONT_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PhoneNumberExtention() As String
		<MaxLength(13)>
		<Column("CONT_FAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxNumber() As String
		<MaxLength(5)>
		<Column("CONT_FAX_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxNumberExtention() As String
		<Column("SCHEDULE_USER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ScheduleUser() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("DEFAULT_TASK", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DefaultTaskCode() As String
		<Column("CP_ALERTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property RecievesAlerts() As Nullable(Of Short)
		<Column("EMAIL_RCPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsEmailRecipient() As Nullable(Of Short)
		<Column("TASK_PRIMARY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property IsPrimaryTask() As Nullable(Of Short)
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(13)>
		<Column("CELL_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CellPhoneNumber() As String
		<Column("CONT_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<Column("CP_USER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsClientPortalUser() As Nullable(Of Short)
		<Column("CONTACT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ContactTypeID)>
		Public Property ContactTypeID() As Nullable(Of Integer)
		<Column("CONT_LF", TypeName:="varchar")>
		Public Property FullNameLF() As String
		<Column("CONT_FML", TypeName:="varchar")>
		Public Property FullNameFML() As String

        Public Overridable Property ClientContactDetails() As ICollection(Of Database.Entities.ClientContactDetail)
        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property ClientPortalUsers() As ICollection(Of Database.Entities.ClientPortalUser)
        Public Overridable Property ClientPortalUserWorkspaces() As ICollection(Of Database.Entities.ClientPortalUserWorkspace)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ContactID

        End Function

#End Region

    End Class

End Namespace
