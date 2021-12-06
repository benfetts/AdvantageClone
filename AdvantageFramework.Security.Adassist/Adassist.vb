<Microsoft.VisualBasic.ComClass(Adassist.ClassId, Adassist.InterfaceId, Adassist.EventsId)>
Public Class Adassist
    Implements Interfaces.IAdassist

#Region " Constants "

    Public Const ClassId As String = "4a03e9f5-c425-4b44-bf07-35a65839e012"
    Public Const InterfaceId As String = "37d458b6-693f-4275-b971-221052ea8d6d"
    Public Const EventsId As String = "d5193e01-a681-4c4e-a684-cc3e9a058dcc"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        MyBase.New()

    End Sub
    Public Function Encrypt(PlainText As String) As String Implements Interfaces.IAdassist.Encrypt

        Encrypt = AdvantageFramework.Security.Encryption.Encrypt(PlainText)

    End Function
    Public Function Decrypt(EncryptedText As String) As String Implements Interfaces.IAdassist.Decrypt

        Decrypt = AdvantageFramework.Security.Encryption.Decrypt(EncryptedText)

    End Function
    Public Function EncryptPassword(PlainText As String) As String Implements Interfaces.IAdassist.EncryptPassword

        EncryptPassword = AdvantageFramework.Security.Encryption.EncryptPassword(PlainText)

    End Function
    Private Function NewDebugLine(DebugLines As String, Message As String) As String

        Dim DebugLine As String = String.Empty

        If String.IsNullOrWhiteSpace(DebugLines) Then

            DebugLine = Now.ToShortDateString & " " & Now.ToLongTimeString & " --- " & Message

        Else

            DebugLine = Now.ToShortDateString & " " & Now.ToLongTimeString & " --- " & Message & System.Environment.NewLine & DebugLines

        End If

        NewDebugLine = DebugLine

    End Function
    Public Function Login(DNSName As String, UserCode As String, Password As String) As Boolean Implements Interfaces.IAdassist.Login

        Dim SuccessfulLogin As Boolean = False
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0
        Dim EncryptedPassword As String = String.Empty
        'Dim DebugLines As String = String.Empty

        'DebugLines = NewDebugLine(DebugLines, "DNSName = " & DNSName)
        'DebugLines = NewDebugLine(DebugLines, "UserCode = " & UserCode)
        'DebugLines = NewDebugLine(DebugLines, "Password = " & Password)

        Try

            ODBCs = AdvantageFramework.Database.LoadODBCs()

            If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

            End If

        Catch ex As Exception
            ODBC = Nothing
        End Try

        If ODBC IsNot Nothing Then

            'DebugLines = NewDebugLine(DebugLines, "Found ODBC " & DNSName)

            Try

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName.ToUpper = ODBC.ServerName.ToUpper AndAlso Entity.DatabaseName.ToUpper = ODBC.DatabaseName.ToUpper)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    'DebugLines = NewDebugLine(DebugLines, "Found ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

                        Catch ex As Exception
                            UserID = 0
                        End Try

                        If UserID > 0 Then

                            'DebugLines = NewDebugLine(DebugLines, "Found User ID " & UserID)

                            Try

                                EncryptedPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.advfn_SEC_USER_AUTH({0})", UserID)).FirstOrDefault

                            Catch ex As Exception
                                EncryptedPassword = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(EncryptedPassword) = False Then

                                'DebugLines = NewDebugLine(DebugLines, "Found EncryptedPassword - User ID " & UserID)

                                If EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                                    'DebugLines = NewDebugLine(DebugLines, "Valid Password " & Password)

                                    SuccessfulLogin = True

                                Else

                                    'DebugLines = NewDebugLine(DebugLines, "Invalid Password " & Password)

                                End If

                            Else

                                'DebugLines = NewDebugLine(DebugLines, "DID NOT Find EncryptedPassword - User ID " & UserID)

                            End If

                        Else

                            'DebugLines = NewDebugLine(DebugLines, "DID NOT Find User ID " & UserID)

                        End If

                    End Using

                Else

                    'DebugLines = NewDebugLine(DebugLines, "DID NOT Find ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                End If

            Catch ex As Exception

                'DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.Message)

                'If ex.InnerException IsNot Nothing Then

                '    DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.Message)

                '    If ex.InnerException.InnerException IsNot Nothing Then

                '        DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.InnerException.Message)

                '    End If

                'End If

            End Try

        Else

            'DebugLines = NewDebugLine(DebugLines, "DID NOT Find ODBC " & DNSName)

        End If

        'My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AdassistDebug.txt", DebugLines, False)

        Login = SuccessfulLogin

    End Function
    Public Function SetPassword(DNSName As String, UserCode As String, Password As String) As Boolean Implements Interfaces.IAdassist.SetPassword

        Dim PasswordUpdated As Boolean = False
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0
        Dim AlreadyHasPassword As Boolean = False
        Dim EncryptedPassword As String = String.Empty

        Try

            ODBCs = AdvantageFramework.Database.LoadODBCs()

            If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

            End If

        Catch ex As Exception
            ODBC = Nothing
        End Try

        If ODBC IsNot Nothing Then

            Try

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = ODBC.ServerName AndAlso Entity.DatabaseName = ODBC.DatabaseName)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

                        Catch ex As Exception
                            UserID = 0
                        End Try

                        If UserID > 0 Then

                            EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password)

                            AlreadyHasPassword = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.SEC_USER_AUTH WHERE SEC_USER_ID = {0}", UserID)).FirstOrDefault > 0)

                            If AlreadyHasPassword Then

                                PasswordUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_AUTH SET PWD_D = '{0}' WHERE SEC_USER_ID = {1}", EncryptedPassword, UserID))

                            Else

                                PasswordUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SEC_USER_AUTH (SEC_USER_ID, PWD_D) VALUES ({0}, '{1}')", UserID, EncryptedPassword))

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End If

        SetPassword = PasswordUpdated

    End Function
    Public Function DeleteLogin(DNSName As String, UserCode As String) As Boolean Implements Interfaces.IAdassist.DeleteLogin

        Dim LoginDeleted As Boolean = False
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0

        Try

            ODBCs = AdvantageFramework.Database.LoadODBCs()

            If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

            End If

        Catch ex As Exception
            ODBC = Nothing
        End Try

        If ODBC IsNot Nothing Then

            Try

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = ODBC.ServerName AndAlso Entity.DatabaseName = ODBC.DatabaseName)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

                        Catch ex As Exception
                            UserID = 0
                        End Try

                        If UserID > 0 Then

                            LoginDeleted = DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.SEC_USER_AUTH WHERE SEC_USER_ID = {0}", UserID))

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End If

        DeleteLogin = LoginDeleted

    End Function

#End Region

End Class
