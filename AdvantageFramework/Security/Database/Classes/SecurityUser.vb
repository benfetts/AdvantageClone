Namespace Security.Database.Classes

    <Serializable()>
    Public Class SecurityUser

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            UserName
            IsValidNTAuthUser
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _UserCode As String = String.Empty
        Private _UserName As String = String.Empty
        Private _IsValidNTAuthUser As Boolean = False
        Private _SID As String = String.Empty

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserName() As String
            Get
                UserName = _UserName
            End Get
            Set(ByVal value As String)

                Dim UserNameHasChanged As Boolean = False

                If Object.Equals(_UserName, value) = False Then

                    UserNameHasChanged = True

                End If

                _UserName = value

                If UserNameHasChanged = True Then

                    UserNameChanged()

                End If

            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Valid NT Auth User")>
        Public ReadOnly Property IsValidNTAuthUser() As Boolean
            Get
                IsValidNTAuthUser = _IsValidNTAuthUser
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SID() As String
            Get
                SID = _SID
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal User As AdvantageFramework.Security.Database.Entities.User)

            _ID = User.ID
            _UserCode = User.UserCode
            _UserName = User.UserName
            _IsValidNTAuthUser = If(String.IsNullOrWhiteSpace(User.SID), False, True)
            _SID = User.SID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserName

        End Function
        Public Sub UserNameChanged()

            Dim NTAccount As System.Security.Principal.NTAccount = Nothing
            Dim SecurityIdentifier As System.Security.Principal.SecurityIdentifier = Nothing

            If String.IsNullOrWhiteSpace(Me.UserName) = False AndAlso Me.UserName.Contains("\") Then

                Try

                    NTAccount = New System.Security.Principal.NTAccount(Me.UserName)
                    SecurityIdentifier = NTAccount.Translate(GetType(System.Security.Principal.SecurityIdentifier))

                Catch ex As Exception

                End Try

            End If

            If SecurityIdentifier IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SecurityIdentifier.Value) = False Then

                _SID = SecurityIdentifier.Value
                _IsValidNTAuthUser = True

            Else

                _SID = String.Empty
                _IsValidNTAuthUser = False

            End If

            'System.Security.Principal.WindowsIdentity.GetCurr
            '_HasValidSQLUser = HasValidSQLUser

        End Sub
        'Public Sub SetSID(HasValidSQLUser As Boolean)

        '    '_HasValidSQLUser = HasValidSQLUser

        'End Sub

#End Region

    End Class

End Namespace
