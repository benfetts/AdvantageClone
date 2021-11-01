Public Module AccessLogin

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function Main(args() As String) As Integer

        Dim ErrorCode As Integer = 0
        Dim SuccessfulLogin As Boolean = False
        Dim DNSName As String = String.Empty
        Dim UserCode As String = String.Empty
        Dim Password As String = String.Empty
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0
        Dim EncryptedPassword As String = String.Empty
        Dim DebugLines As String = String.Empty

        Try

            DNSName = args(0)
            UserCode = args(1)
            Password = args(2)

        Catch ex As Exception

        End Try

        If String.IsNullOrWhiteSpace(DNSName) = False AndAlso
                String.IsNullOrWhiteSpace(UserCode) = False AndAlso
                String.IsNullOrWhiteSpace(Password) = False Then

            Try

                DebugLines = NewDebugLine(DebugLines, "DNSName = " & DNSName)
                DebugLines = NewDebugLine(DebugLines, "UserCode = " & UserCode)
                DebugLines = NewDebugLine(DebugLines, "Password = " & Password)

                Try

                    ODBCs = AdvantageFramework.Database.LoadODBCs()

                    If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                        For Each ODBC In ODBCs

                            DebugLines = NewDebugLine(DebugLines, "ODBC DNSName = " & ODBC.DNSName)

                        Next

                        ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

                    End If

                Catch ex As Exception

                    DebugLines = NewDebugLine(DebugLines, "Error ODBC --> " & ex.Message)

                    If ex.InnerException IsNot Nothing Then

                        DebugLines = NewDebugLine(DebugLines, "Error ODBC --> " & ex.InnerException.Message)

                        If ex.InnerException.InnerException IsNot Nothing Then

                            DebugLines = NewDebugLine(DebugLines, "Error ODBC --> " & ex.InnerException.InnerException.Message)

                        End If

                    End If

                End Try

                If ODBC IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Found ODBC " & DNSName)

                    Try

                        ConnectionDatabaseProfiles = LoadConnectionDatabaseProfileForAdvantage(DebugLines, True)

                        Try

                            ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName.ToUpper = ODBC.ServerName.ToUpper AndAlso Entity.DatabaseName.ToUpper = ODBC.DatabaseName.ToUpper)

                        Catch ex As Exception
                            ConnectionDatabaseProfile = Nothing
                        End Try

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            DebugLines = NewDebugLine(DebugLines, "Found ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                                DbContext.Database.Connection.Open()

                                Try

                                    UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER('{0}')", UserCode)).FirstOrDefault

                                Catch ex As Exception
                                    UserID = 0
                                End Try

                                If UserID > 0 Then

                                    DebugLines = NewDebugLine(DebugLines, "Found User ID " & UserID)

                                    Try

                                        EncryptedPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.advfn_SEC_USER_AUTH({0})", UserID)).FirstOrDefault

                                    Catch ex As Exception
                                        EncryptedPassword = String.Empty
                                    End Try

                                    If String.IsNullOrWhiteSpace(EncryptedPassword) = False Then

                                        DebugLines = NewDebugLine(DebugLines, "Found EncryptedPassword - User ID " & UserID)

                                        If EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                                            DebugLines = NewDebugLine(DebugLines, "Valid Password " & Password)

                                            SuccessfulLogin = True

                                        Else

                                            DebugLines = NewDebugLine(DebugLines, "Invalid Password " & Password)

                                        End If

                                    Else

                                        DebugLines = NewDebugLine(DebugLines, "DID NOT Find EncryptedPassword - User ID " & UserID)

                                    End If

                                Else

                                    DebugLines = NewDebugLine(DebugLines, "DID NOT Find User ID " & UserID)

                                End If

                            End Using

                        Else

                            DebugLines = NewDebugLine(DebugLines, "DID NOT Find ConnectionDatabaseProfile " & ODBC.DatabaseName)

                        End If

                    Catch ex As Exception

                        DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.Message)

                        If ex.InnerException IsNot Nothing Then

                            DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.Message)

                            If ex.InnerException.InnerException IsNot Nothing Then

                                DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.InnerException.Message)

                            End If

                        End If

                    End Try

                Else

                    DebugLines = NewDebugLine(DebugLines, "DID NOT Find ODBC " & DNSName)

                End If

            Catch ex As Exception
                SuccessfulLogin = False
            End Try

        Else

            If String.IsNullOrWhiteSpace(DNSName) Then

                DebugLines = NewDebugLine(DebugLines, "DNSName is blank ")

            End If

            If String.IsNullOrWhiteSpace(UserCode) Then

                DebugLines = NewDebugLine(DebugLines, "UserCode is blank ")

            End If

            If String.IsNullOrWhiteSpace(Password) Then

                DebugLines = NewDebugLine(DebugLines, "Password is blank ")

            End If

        End If

        Try

            My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AccessLoginDebug.txt", DebugLines, False)

        Catch ex As Exception

        End Try

        If SuccessfulLogin Then

            ErrorCode = 0

        Else

            ErrorCode = 1

        End If

        Return ErrorCode

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
    Private Function LoadConnectionDatabaseProfileForAdvantage(ByRef DebugLines As String, Optional DecryptPassword As Boolean = False) As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

        'objects
        Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
        Dim XMLFile As String = ""
        Dim XML As String = ""
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

        Try

            XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.Security.AdvantageConnectionConfigurationFileName

            DebugLines = NewDebugLine(DebugLines, "XML FILE --> " & XMLFile)

            ConnectionDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            If My.Computer.FileSystem.FileExists(XMLFile) Then

                Try

                    XmlTextReader = New System.Xml.XmlTextReader(XMLFile)

                    Do Until XmlTextReader.Read() = False

                        If XmlTextReader.Name = "ConnectionDatabaseProfile" Then

                            XML = XmlTextReader.ReadOuterXml

                            ConnectionDatabaseProfile = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.ConnectionDatabaseProfile))

                            If ConnectionDatabaseProfile IsNot Nothing Then

                                If DecryptPassword Then

                                    ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

                                End If

                                ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                            End If

                        End If

                    Loop

                Catch ex As Exception
                    XML = ""

                    DebugLines = NewDebugLine(DebugLines, "FAILED READING XML FILE --> " & XMLFile)

                Finally

                    If XmlTextReader IsNot Nothing Then

                        XmlTextReader.Close()

                    End If

                    XmlTextReader = Nothing

                End Try

            Else

                DebugLines = NewDebugLine(DebugLines, "NOT FOUND XML FILE --> " & XMLFile)

            End If

        Catch ex As Exception

        End Try

        LoadConnectionDatabaseProfileForAdvantage = ConnectionDatabaseProfileList

    End Function
    Public Function Login(DNSName As String, UserCode As String, Password As String) As Boolean

        Dim SuccessfulLogin As Boolean = False
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ODBCs As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
        Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
        Dim UserID As Integer = 0
        Dim EncryptedPassword As String = String.Empty
        Dim DebugLines As String = String.Empty

        DebugLines = NewDebugLine(DebugLines, "DNSName = " & DNSName)
        DebugLines = NewDebugLine(DebugLines, "UserCode = " & UserCode)
        DebugLines = NewDebugLine(DebugLines, "Password = " & Password)

        Try

            ODBCs = AdvantageFramework.Database.LoadODBCs()

            If ODBCs IsNot Nothing AndAlso ODBCs.Count > 0 Then

                ODBC = ODBCs.SingleOrDefault(Function(Entity) Entity.DNSName = DNSName)

            End If

        Catch ex As Exception
            ODBC = Nothing
        End Try

        If ODBC IsNot Nothing Then

            DebugLines = NewDebugLine(DebugLines, "Found ODBC " & DNSName)

            Try

                ConnectionDatabaseProfiles = LoadConnectionDatabaseProfileForAdvantage(DebugLines, True)

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName.ToUpper = ODBC.ServerName.ToUpper AndAlso Entity.DatabaseName.ToUpper = ODBC.DatabaseName.ToUpper)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Found ConnectionDatabaseProfile " & ConnectionDatabaseProfile.ToString)

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", UserCode)).FirstOrDefault

                        Catch ex As Exception
                            UserID = 0
                        End Try

                        If UserID > 0 Then

                            DebugLines = NewDebugLine(DebugLines, "Found User ID " & UserID)

                            Try

                                EncryptedPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.advfn_SEC_USER_AUTH({0})", UserID)).FirstOrDefault

                            Catch ex As Exception
                                EncryptedPassword = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(EncryptedPassword) = False Then

                                DebugLines = NewDebugLine(DebugLines, "Found EncryptedPassword - User ID " & UserID)

                                If EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                                    DebugLines = NewDebugLine(DebugLines, "Valid Password " & Password)

                                    SuccessfulLogin = True

                                Else

                                    DebugLines = NewDebugLine(DebugLines, "Invalid Password " & Password)

                                End If

                            Else

                                DebugLines = NewDebugLine(DebugLines, "DID NOT Find EncryptedPassword - User ID " & UserID)

                            End If

                        Else

                            DebugLines = NewDebugLine(DebugLines, "DID NOT Find User ID " & UserID)

                        End If

                    End Using

                Else

                    DebugLines = NewDebugLine(DebugLines, "DID NOT Find ConnectionDatabaseProfile " & ODBC.DatabaseName)

                End If

            Catch ex As Exception

                DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.Message)

                If ex.InnerException IsNot Nothing Then

                    DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.Message)

                    If ex.InnerException.InnerException IsNot Nothing Then

                        DebugLines = NewDebugLine(DebugLines, "Error --> " & ex.InnerException.InnerException.Message)

                    End If

                End If

            End Try

        Else

            DebugLines = NewDebugLine(DebugLines, "DID NOT Find ODBC " & DNSName)

        End If

        My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AdassistDebug.txt", DebugLines, False)

        Login = SuccessfulLogin

    End Function

#End Region

End Module
