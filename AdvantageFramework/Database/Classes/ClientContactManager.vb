Namespace Database.Classes

    <Serializable()>
    Public Class ClientContactManager

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContactID
            ContactCode
            Name
            Title
            Telephone
            CellPhone
            Fax
            EmailAddress
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _ContactID As Integer = Nothing
        Private _ContactCode As String = Nothing
        Private _Name As String = Nothing
        Private _Title As String = Nothing
        Private _Telephone As String = Nothing
        Private _CellPhone As String = Nothing
        Private _Fax As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _IsInactive As Boolean = Nothing

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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Code")>
        Public Property ContactCode() As String
            Get
                ContactCode = _ContactCode
            End Get
            Set(value As String)
                _ContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
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
        Public Property Telephone() As String
            Get
                Telephone = _Telephone
            End Get
            Set(value As String)
                _Telephone = value
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
        Public Property Fax() As String
            Get
                Fax = _Fax
            End Get
            Set(value As String)
                _Fax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Boolean)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact)

            _ContactID = ClientContact.ContactID
            _ContactCode = ClientContact.ContactCode
            _Name = ClientContact.ToString
            _Title = ClientContact.Title
            _Telephone = ClientContact.Telephone
            _CellPhone = ClientContact.CellPhone
            _Fax = ClientContact.Fax
            _EmailAddress = ClientContact.EmailAddress
            _IsInactive = CBool(ClientContact.IsInactive.GetValueOrDefault(0))

        End Sub

#End Region

    End Class

End Namespace

