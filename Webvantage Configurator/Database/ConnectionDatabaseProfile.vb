Namespace Database

    <Serializable()>
    Public Class ConnectionDatabaseProfile

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



#End Region

#Region " Properties "

        Public Property ServerName() As String
        Public Property DatabaseName() As String
        Public Property UserName() As String
        Public Property Password() As String

#End Region

#Region " Methods "

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
        Public Function GetConnectionString() As String

            Dim ConnectionString As String = String.Empty

            ConnectionString = Database.CreateConnectionString(Me.ServerName, Me.DatabaseName, False, Me.UserName, Me.Password)

            GetConnectionString = ConnectionString

        End Function

#End Region

    End Class

End Namespace

