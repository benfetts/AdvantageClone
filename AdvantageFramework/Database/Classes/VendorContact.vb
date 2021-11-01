Namespace Database.Classes

    <Serializable()>
    Public Class VendorContact

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContactCode
            Name
            EmailAddress
            IsInactive
            IsDefault
        End Enum

#End Region

#Region " Variables "

        Private _VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
        Private _ContactCode As String = Nothing
        Private _Name As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _IsDefault As Boolean = Nothing

#End Region

#Region " Properties "

        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public ReadOnly Property VendorContact As AdvantageFramework.Database.Entities.VendorContact
        '    Get
        '        VendorContact = _VendorContact
        '    End Get
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ContactCode() As String
            Get
                ContactCode = _ContactCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Name() As String
            Get
                Name = _Name
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Default", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsDefault() As Boolean
            Get
                IsDefault = _IsDefault
            End Get
            Set(ByVal value As Boolean)
                _IsDefault = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact, ByVal IsDefault As Boolean)

            _VendorContact = VendorContact
            _ContactCode = VendorContact.Code
            _Name = VendorContact.FirstName & " " & VendorContact.MiddleInitial & " " & VendorContact.LastName
            _EmailAddress = VendorContact.Email
            _IsInactive = Convert.ToBoolean(VendorContact.IsInactive.GetValueOrDefault(0))
            _IsDefault = IsDefault

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ContactCode

        End Function

#End Region

    End Class

End Namespace

