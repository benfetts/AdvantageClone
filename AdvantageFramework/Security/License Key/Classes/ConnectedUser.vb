Namespace Security.LicenseKey.Classes

    <Serializable()>
    Public Class ConnectedUser

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            UserCode
            UserName
            EmployeeCode
            EmployeeName
            Application
            CreatedDate
            ApplicationID
        End Enum

#End Region

#Region " Variables "

        Private _UserID As Integer = Nothing
        Private _UserCode As String = Nothing
        Private _UserName As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _Application As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _ApplicationID As Integer = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property UserID() As Integer
            Get
                UserID = _UserID
            End Get
        End Property
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Public ReadOnly Property UserName() As String
            Get
                UserName = _UserName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
        End Property
        Public ReadOnly Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
        End Property
        Public ReadOnly Property Application() As String
            Get
                Application = _Application
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ApplicationID() As Integer
            Get
                ApplicationID = _ApplicationID
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal User As AdvantageFramework.Security.Database.Entities.User, ByVal Application As AdvantageFramework.Security.Application, ByVal CreatedDate As Date)

            _UserID = User.ID
            _UserCode = User.UserCode
            _UserName = User.UserName
            _EmployeeCode = User.EmployeeCode
            _EmployeeName = User.Employee.ToString
            _Application = Application.ToString
            _CreatedDate = CreatedDate
            _ApplicationID = Application

        End Sub
        Public Sub New(ByVal ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact, ByVal Application As AdvantageFramework.Security.Application, ByVal CreatedDate As Date)

            _UserID = ClientContact.ContactID
            _UserCode = ClientContact.ContactCode
            _UserName = ClientContact.EmailAddress
            _EmployeeCode = ClientContact.ContactCode
            _EmployeeName = ClientContact.FullNameFML
            _Application = Application.ToString
            _CreatedDate = CreatedDate
            _ApplicationID = Application

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserID

        End Function

#End Region

    End Class

End Namespace
