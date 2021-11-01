Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("IMP_CLIENT_CONTACT_STAGING")>
    <Serializable()>
    Public Class ImportClientContactStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsNew
            IsOnHold
            ContactID
            ContactCode
            ClientCode
            EmailAddress
            FirstName
            LastName
            MiddleInitial
            Title
            ContactTypeID
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
            ClientPortalUser
            GetAlerts
            GetEmails
            IsInactive
            CellPhone
            Comments
        End Enum

#End Region

#Region " Variables "

        <System.ComponentModel.DataAnnotations.Schema.Column("IMPORT_ID"),
        System.ComponentModel.DataAnnotations.RequiredAttribute,
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID As Integer
		<System.ComponentModel.DataAnnotations.Schema.Column("BATCH_NAME"),
		System.ComponentModel.DataAnnotations.RequiredAttribute,
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName As String
		<System.ComponentModel.DataAnnotations.Schema.Column("IS_NEW"),
		System.ComponentModel.DataAnnotations.RequiredAttribute,
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew As Boolean
		<System.ComponentModel.DataAnnotations.Schema.Column("ON_HOLD"),
		System.ComponentModel.DataAnnotations.RequiredAttribute,
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsOnHold As Boolean
		<System.ComponentModel.DataAnnotations.Schema.Column("CDP_CONTACT_ID"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientContactID)>
		Public Property ContactID As Nullable(Of Integer)
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_CODE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContactCode As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CL_CODE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode As String
		<System.ComponentModel.DataAnnotations.Schema.Column("EMAIL_ADDRESS"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
		Public Property EmailAddress As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_FNAME"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FirstName As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_LNAME"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastName As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_MI"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(1),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiddleInitial As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_TITLE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Title As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONTACT_TYPE_ID"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ContactTypeID, CustomColumnCaption:="Contact Type")>
		Public Property ContactTypeID As Nullable(Of Integer)
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_ADDRESS1"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_ADDRESS2"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2 As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_CITY"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_COUNTY"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(20),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_STATE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(10),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_COUNTRY"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(20),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_ZIP"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(10),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_TELEPHONE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Telephone As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_EXTENTION"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(5),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelephoneExtension As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_FAX"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CONT_FAX_EXTENTION"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(5),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxExtension As String
		<System.ComponentModel.DataAnnotations.Schema.Column("CELL_PHONE"),
		System.ComponentModel.DataAnnotations.MaxLengthAttribute(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CellPhone As String
        <System.ComponentModel.DataAnnotations.Schema.Column("SCHEDULE_USER"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ScheduleUser As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.Column("CP_USER"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ClientPortalUser As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.Column("CP_ALERTS"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property GetAlerts As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.Column("EMAIL_RCPT"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property GetEmails As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.Column("CONT_COMMENT"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments As String
        <System.ComponentModel.DataAnnotations.Schema.Column("INACTIVE_FLAG"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive As Nullable(Of Short)

#End Region

#Region " Properties "

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties.ContactCode.ToString

                    If Me.IsNew Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientContact
                            Where Entity.ContactCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Client contact code already exists in the system."

                        Else

                            If _DbContext IsNot Nothing Then

                                Try

                                    If _DataContext Is Nothing Then

                                        _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                    End If

                                Catch ex As Exception
                                    _DbContext = Nothing
                                End Try

                            End If

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, AdvantageFramework.BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.ClientContact.LoadByClientAndContactCode(_DbContext, Me.ClientCode, PropertyValue) Is Nothing Then

                            IsValid = False
                            ErrorText = "Client contact code does not exist in the system."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
