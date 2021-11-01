Namespace Database.Classes

    <Serializable()>
    Public Class ClientContact
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContactID
            ContactCode
            ClientCode
            ClientName
            ContactType
            IsClientInactive
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
        End Enum

#End Region

#Region " Variables "

        Private _ContactID As Integer = Nothing
        Private _ContactCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _ContactType As String = Nothing
        Private _IsClientInactive As Boolean = Nothing
        Private _EmailAddress As String = Nothing
        Private _FirstName As String = Nothing
        Private _LastName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _Title As String = Nothing
        Private _Address As String = Nothing
        Private _Address2 As String = Nothing
        Private _City As String = Nothing
        Private _County As String = Nothing
        Private _State As String = Nothing
        Private _Country As String = Nothing
        Private _Zip As String = Nothing
        Private _Telephone As String = Nothing
        Private _TelephoneExtension As String = Nothing
        Private _Fax As String = Nothing
        Private _FaxExtension As String = Nothing
        Private _ScheduleUser As Boolean = Nothing
        Private _DefaultTaskCode As String = Nothing
        Private _GetAlerts As Boolean = Nothing
        Private _GetEmails As Boolean = Nothing
        Private _IsPrimaryTask As Boolean = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _CellPhone As String = Nothing
        Private _Comments As String = Nothing
        Private _IsClientPortalUser As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ContactID() As Integer
            Get
                ContactID = _ContactID
            End Get
            Set(value As Integer)
                _ContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property ContactCode() As String
            Get
                ContactCode = _ContactCode
            End Get
            Set(value As String)
                _ContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContactType() As String
            Get
                ContactType = _ContactType
            End Get
            Set(value As String)
                _ContactType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Email)>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(value As String)
                _LastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(value As String)
                _MiddleInitial = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Title() As String
            Get
                Title = _Title
            End Get
            Set(value As String)
                _Title = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address() As String
            Get
                Address = _Address
            End Get
            Set(value As String)
                _Address = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address2() As String
            Get
                Address2 = _Address2
            End Get
            Set(value As String)
                _Address2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
            Get
                City = _City
            End Get
            Set(value As String)
                _City = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
            Get
                County = _County
            End Get
            Set(value As String)
                _County = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
            Get
                State = _State
            End Get
            Set(value As String)
                _State = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
            Get
                Country = _Country
            End Get
            Set(value As String)
                _Country = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Zip() As String
            Get
                Zip = _Zip
            End Get
            Set(value As String)
                _Zip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Telephone() As String
            Get
                Telephone = _Telephone
            End Get
            Set(value As String)
                _Telephone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelephoneExtension() As String
            Get
                TelephoneExtension = _TelephoneExtension
            End Get
            Set(value As String)
                _TelephoneExtension = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fax() As String
            Get
                Fax = _Fax
            End Get
            Set(value As String)
                _Fax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxExtension() As String
            Get
                FaxExtension = _FaxExtension
            End Get
            Set(value As String)
                _FaxExtension = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ScheduleUser() As Boolean
            Get
                ScheduleUser = _ScheduleUser
            End Get
            Set(value As Boolean)
                _ScheduleUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DefaultTaskCode() As String
            Get
                DefaultTaskCode = _DefaultTaskCode
            End Get
            Set(value As String)
                _DefaultTaskCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property GetAlerts() As Boolean
            Get
                GetAlerts = _GetAlerts
            End Get
            Set(value As Boolean)
                _GetAlerts = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property GetEmails() As Boolean
            Get
                GetEmails = _GetEmails
            End Get
            Set(value As Boolean)
                _GetEmails = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsPrimaryTask() As Boolean
            Get
                IsPrimaryTask = _IsPrimaryTask
            End Get
            Set(value As Boolean)
                _IsPrimaryTask = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Boolean)
                _IsInactive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CellPhone() As String
            Get
                CellPhone = _CellPhone
            End Get
            Set(value As String)
                _CellPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(value As String)
                _Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsClientPortalUser() As Boolean
            Get
                IsClientPortalUser = _IsClientPortalUser
            End Get
            Set(value As Boolean)
                _IsClientPortalUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsClientInactive() As Boolean
            Get
                IsClientInactive = _IsClientInactive
            End Get
            Set(value As Boolean)
                _IsClientInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContactEntity As AdvantageFramework.Database.Entities.ClientContact)

            'objects
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing

            _ContactID = ClientContactEntity.ContactID
            _ContactCode = ClientContactEntity.ContactCode
            _ClientCode = ClientContactEntity.ClientCode
            _ClientName = ClientContactEntity.Client.Name
            _IsClientInactive = Not CBool(ClientContactEntity.Client.IsActive.GetValueOrDefault(0))
            _EmailAddress = ClientContactEntity.EmailAddress
            _FirstName = ClientContactEntity.FirstName
            _LastName = ClientContactEntity.LastName
            _MiddleInitial = ClientContactEntity.MiddleInitial
            _Title = ClientContactEntity.Title
            _Address = ClientContactEntity.Address
            _Address2 = ClientContactEntity.Address2
            _City = ClientContactEntity.City
            _County = ClientContactEntity.County
            _State = ClientContactEntity.State
            _Country = ClientContactEntity.Country
            _Zip = ClientContactEntity.Zip
            _Telephone = ClientContactEntity.Telephone
            _TelephoneExtension = ClientContactEntity.TelephoneExtension
            _Fax = ClientContactEntity.Fax
            _FaxExtension = ClientContactEntity.FaxExtension
            _ScheduleUser = CBool(ClientContactEntity.ScheduleUser.GetValueOrDefault(0))
            _DefaultTaskCode = ClientContactEntity.DefaultTaskCode
            _GetAlerts = CBool(ClientContactEntity.GetAlerts.GetValueOrDefault(0))
            _GetEmails = CBool(ClientContactEntity.GetEmails.GetValueOrDefault(0))
            _IsPrimaryTask = CBool(ClientContactEntity.IsPrimaryTask.GetValueOrDefault(0))
            _IsInactive = CBool(ClientContactEntity.IsInactive.GetValueOrDefault(0))
            _CellPhone = ClientContactEntity.CellPhone
            _Comments = ClientContactEntity.Comments
            _IsClientPortalUser = CBool(ClientContactEntity.IsClientPortalUser.GetValueOrDefault(0))

            If ClientContactEntity.ContactTypeID.GetValueOrDefault(0) > 0 Then

                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, ClientContactEntity.ContactTypeID.GetValueOrDefault(0))

                If ContactType IsNot Nothing Then

                    _ContactType = ContactType.Description

                End If

            End If

        End Sub
        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function

#End Region

    End Class

End Namespace
