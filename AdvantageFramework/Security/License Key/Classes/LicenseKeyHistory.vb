Namespace Security.LicenseKey.Classes
    ''' <summary>
    ''' FOR INTERNAL ADVANTAGE USE ONLY!!!!
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()>
    Public Class LicenseKeyHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            AgencyName
            UserCode
            EmployeeCode
            EmployeeName
            CreatedDate
            DaysUntilFileExpires
            DaysUntilKeyExpires
            PowerLicenseQuantity
            WebvantageOnlyLicenseQuantity
            ClientPortalLicenseQuantity
            MediaToolsUsersQuantity
            APIUsersQuantity
            IsActive
            DeactivatedDate
            Comment
            EncrpytedLicenseKey
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _AgencyName As String = Nothing
        Private _UserCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _DaysUntilFileExpires As Integer = Nothing
        Private _DaysUntilKeyExpires As Integer = Nothing
        Private _PowerLicenseQuantity As Integer = Nothing
        Private _WebvantageOnlyLicenseQuantity As Integer = Nothing
        Private _ClientPortalLicenseQuantity As Integer = Nothing
        Private _MediaToolsUsersQuantity As Integer = Nothing
        Private _APIUsersQuantity As Integer = Nothing
        Private _IsActive As Boolean = Nothing
        Private _DeactivatedDate As Date = Nothing
        Private _Comment As String = Nothing
        Private _EncrpytedLicenseKey As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property AgencyName() As String
            Get
                AgencyName = _AgencyName
            End Get
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(value As Date)
                _CreatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DaysUntilFileExpires() As Integer
            Get
                DaysUntilFileExpires = _DaysUntilFileExpires
            End Get
            Set(value As Integer)
                _DaysUntilFileExpires = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DaysUntilKeyExpires() As Integer
            Get
                DaysUntilKeyExpires = _DaysUntilKeyExpires
            End Get
            Set(value As Integer)
                _DaysUntilKeyExpires = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property PowerLicenseQuantity() As Integer
            Get
                PowerLicenseQuantity = _PowerLicenseQuantity
            End Get
            Set(value As Integer)
                _PowerLicenseQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property WebvantageOnlyLicenseQuantity() As Integer
            Get
                WebvantageOnlyLicenseQuantity = _WebvantageOnlyLicenseQuantity
            End Get
            Set(value As Integer)
                _WebvantageOnlyLicenseQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ClientPortalLicenseQuantity() As Integer
            Get
                ClientPortalLicenseQuantity = _ClientPortalLicenseQuantity
            End Get
            Set(value As Integer)
                _ClientPortalLicenseQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property MediaToolsUsersQuantity() As Integer
            Get
                MediaToolsUsersQuantity = _MediaToolsUsersQuantity
            End Get
            Set(value As Integer)
                _MediaToolsUsersQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property APIUsersQuantity() As Integer
            Get
                APIUsersQuantity = _APIUsersQuantity
            End Get
            Set(value As Integer)
                _APIUsersQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property IsActive() As Boolean
            Get
                IsActive = _IsActive
            End Get
            Set(value As Boolean)
                _IsActive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DeactivatedDate() As Date
            Get
                DeactivatedDate = _DeactivatedDate
            End Get
            Set(value As Date)
                _DeactivatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EncrpytedLicenseKey() As String
            Get
                EncrpytedLicenseKey = _EncrpytedLicenseKey
            End Get
            Set(value As String)
                _EncrpytedLicenseKey = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
