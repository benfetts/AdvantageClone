Namespace Database

    <Serializable()>
    Public Class ConnectionDatabaseProfile
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ServerName
            DatabaseName
            UserName
            Password
        End Enum

#End Region

#Region " Variables "

        Private _DecryptedPassword As String = String.Empty

#End Region

#Region " Properties "

        <Xml.Serialization.XmlIgnore()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GUID As System.Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ServerName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DatabaseName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Password() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.GUID = System.Guid.NewGuid

        End Sub
        Public Function Copy() As ConnectionDatabaseProfile

            'objects
            Dim ConnectionDatabaseProfile As ConnectionDatabaseProfile = Nothing

            ConnectionDatabaseProfile = New ConnectionDatabaseProfile

            ConnectionDatabaseProfile.ServerName = Me.ServerName
            ConnectionDatabaseProfile.DatabaseName = Me.DatabaseName
            ConnectionDatabaseProfile.UserName = Me.UserName
            ConnectionDatabaseProfile.Password = Me.Password

            Copy = ConnectionDatabaseProfile

        End Function
        Public Function GetDecryptPassword() As String

            Dim DecryptedPassword As String = String.Empty

            Try

                DecryptedPassword = AdvantageFramework.Security.Encryption.Decrypt(Me.Password)

            Catch ex As Exception
                DecryptedPassword = String.Empty
            End Try

            GetDecryptPassword = DecryptedPassword

        End Function
        Public Function GetConnectionString(Application As AdvantageFramework.Security.Application) As String

            Dim ConnectionString As String = String.Empty

            ConnectionString = AdvantageFramework.Database.CreateConnectionString(Me.ServerName, Me.DatabaseName, False, Me.UserName, Me.GetDecryptPassword(), Application.ToString)

            GetConnectionString = ConnectionString

        End Function
        Public Overrides Function ToString() As String

            ToString = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Me.ServerName, "\") & Me.DatabaseName

        End Function
        Public Sub SetError(ErrorText As String)

            Dim FullErrorText As String = String.Empty

            FullErrorText = _EntityError

            If String.IsNullOrWhiteSpace(ErrorText) Then

                '_ErrorHashtable("ServerName") = String.Empty
                _ErrorHashtable("DatabaseName") = String.Empty

            Else

                '_ErrorHashtable("ServerName") = ErrorText
                _ErrorHashtable("DatabaseName") = ErrorText

            End If

            _EntityError = IIf(FullErrorText = "", ErrorText, FullErrorText & Environment.NewLine & ErrorText)

        End Sub

#End Region

    End Class

End Namespace

