Namespace Database

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const _ConstConnectionStringBaseWindowsAuthentication As String = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;Persist Security Info=False;APP={2}"
        Private Const _ConstConnectionStringBaseSQLAuthentication As String = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};APP={4}"

#End Region

#Region " Enum "

        Public Enum Action
            Inserting
            Updating
            Deleting
        End Enum
        Public Enum DatabaseTypes
            [Default]
            Reporting
            Security
            BillingCommandCenter
            Nielsen
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateConnectionString(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Boolean,
                                               Optional UserName As String = "", Optional Password As String = "", Optional Application As String = "Advantage") As String

            'objects
            Dim ConnectionString As String = ""

            If UseWindowsAuthentication Then

                ConnectionString = String.Format(_ConstConnectionStringBaseWindowsAuthentication, ServerName, DatabaseName, Application)

            Else

                ConnectionString = String.Format(_ConstConnectionStringBaseSQLAuthentication, ServerName, DatabaseName, UserName, Password, Application)

            End If

            If Application = "Webvantage" Then

                ConnectionString &= ";Pooling=False;Connect Timeout=1200;Connection Lifetime=15;Connection Reset=False;Max Pool Size=1;"

            ElseIf Application = "Nielsen" Then

                ConnectionString &= ";Max Pool Size=32767;"

            End If

            CreateConnectionString = ConnectionString

        End Function
        Public Function TestConnectionString(ConnectionString As String) As Boolean

            Dim CanConnect As Boolean = False
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing

            Try

                SqlConnection = New System.Data.SqlClient.SqlConnection(ConnectionString)
                SqlConnection.Open()

                CanConnect = True

            Catch ex As Exception

            Finally

                If SqlConnection IsNot Nothing Then

                    SqlConnection.Dispose()

                End If

            End Try

            TestConnectionString = CanConnect

        End Function
        Public Function LoadConnectionDatabaseProfile(DatabaseName As String) As Database.ConnectionDatabaseProfile

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

            For Each Profile As Database.ConnectionDatabaseProfile In LoadConnectionDatabaseProfiles()

                If Profile.DatabaseName.ToUpper = DatabaseName.ToUpper Then

                    ConnectionDatabaseProfile = Profile
                    Exit For

                End If

            Next

            LoadConnectionDatabaseProfile = ConnectionDatabaseProfile

        End Function
        Public Function LoadConnectionDatabaseProfiles() As Generic.List(Of Database.ConnectionDatabaseProfile)

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of Database.ConnectionDatabaseProfile) = Nothing

            RegistryKey = Registry.LoadConnectionDatabaseProfilesRegistryKeyReadOnly()

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfiles = LoadConnectionDatabaseProfiles(RegistryKey)

                RegistryKey.Close()

                RegistryKey.Dispose()

                RegistryKey = Nothing

            End If

            If ConnectionDatabaseProfiles Is Nothing Then

                ConnectionDatabaseProfiles = New Generic.List(Of Database.ConnectionDatabaseProfile)

            End If

            LoadConnectionDatabaseProfiles = ConnectionDatabaseProfiles

        End Function
        Public Function LoadConnectionDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ServerName As String, DatabaseName As String) As Database.ConnectionDatabaseProfile

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfile = New Database.ConnectionDatabaseProfile

                RegistrySubKey = Registry.OpenRegistryKeyByWin32ReadOnly(RegistryKey, DatabaseName)

                If RegistrySubKey IsNot Nothing Then

                    ConnectionDatabaseProfile.ServerName = ServerName.Replace("#", "\")
                    ConnectionDatabaseProfile.DatabaseName = DatabaseName
                    ConnectionDatabaseProfile.UserName = RegistrySubKey.GetValue("UserName").ToString
                    ConnectionDatabaseProfile.Password = Decrypt(RegistrySubKey.GetValue("Password").ToString)

                End If

                If RegistrySubKey IsNot Nothing Then

                    RegistrySubKey.Close()

                    RegistrySubKey.Dispose()

                    RegistrySubKey = Nothing

                End If

            End If

            LoadConnectionDatabaseProfile = ConnectionDatabaseProfile

        End Function
        Public Function LoadConnectionDatabaseProfiles(ByRef RegistryKey As Microsoft.Win32.RegistryKey) As Generic.List(Of Database.ConnectionDatabaseProfile)

            'objects
            Dim ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of Database.ConnectionDatabaseProfile) = Nothing
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfiles = New Generic.List(Of Database.ConnectionDatabaseProfile)

                For Each SubKeyName As String In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName)

                    For Each DatabaseSubKeyName As String In DatabaseRegistryKey.GetSubKeyNames

                        ConnectionDatabaseProfile = Database.LoadConnectionDatabaseProfile(DatabaseRegistryKey, SubKeyName, DatabaseSubKeyName)

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            ConnectionDatabaseProfiles.Add(ConnectionDatabaseProfile)

                        End If

                    Next

                Next

            End If

            LoadConnectionDatabaseProfiles = ConnectionDatabaseProfiles

        End Function
        Public Function SaveConnectionDatabaseProfile(ByRef ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile, IsUpdating As Boolean) As Boolean

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfileSaved As Boolean = False

            If ConnectionDatabaseProfile IsNot Nothing AndAlso ConnectionDatabaseProfile.DatabaseName <> "" Then

                RegistryKey = Registry.LoadConnectionDatabaseProfilesRegistryKey()

                If RegistryKey IsNot Nothing Then

                    ConnectionDatabaseProfileSaved = SaveConnectionDatabaseProfile(RegistryKey, ConnectionDatabaseProfile, IsUpdating)

                    RegistryKey.Close()

                    RegistryKey.Dispose()

                    RegistryKey = Nothing

                End If

                If IntPtr.Size <> 4 Then

                    RegistryKey = Registry.LoadConnectionDatabaseProfilesRegistryKeyWin64()

                    If RegistryKey IsNot Nothing Then

                        ConnectionDatabaseProfileSaved = SaveConnectionDatabaseProfile(RegistryKey, ConnectionDatabaseProfile, IsUpdating)

                        RegistryKey.Close()

                        RegistryKey.Dispose()

                        RegistryKey = Nothing

                    End If

                End If

            End If

            SaveConnectionDatabaseProfile = ConnectionDatabaseProfileSaved

        End Function
        Public Function ContainsIllegalCharacters(ByVal StringToCheck As String) As Boolean

            If StringToCheck.Contains("?") = True OrElse
               StringToCheck.Contains("#") = True OrElse
               StringToCheck.Contains("/") = True OrElse
               StringToCheck.Contains("&") = True Then

                Return True

            Else

                Return False

            End If

        End Function
        Private Function SaveConnectionDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey,
                                                       ByRef ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile,
                                                       Updating As Boolean) As Boolean

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfileSaved As Boolean = False

            If ConnectionDatabaseProfile IsNot Nothing Then

                If String.IsNullOrWhiteSpace(ConnectionDatabaseProfile.ServerName) = False Then

                    ConnectionDatabaseProfile.ServerName = ConnectionDatabaseProfile.ServerName.Replace("\", "#")

                End If

            End If

            If Updating Then

                RegistrySubKey = Registry.OpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

                If RegistrySubKey Is Nothing Then

                    RegistrySubKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

                End If

            Else

                RegistrySubKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

            End If

            If RegistrySubKey IsNot Nothing Then

                If Updating Then

                    DatabaseRegistryKey = Registry.OpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                    If DatabaseRegistryKey Is Nothing Then

                        DatabaseRegistryKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                    End If

                Else

                    DatabaseRegistryKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                End If

                If DatabaseRegistryKey IsNot Nothing Then

                    DatabaseRegistryKey.SetValue("UserName", ConnectionDatabaseProfile.UserName)
                    DatabaseRegistryKey.SetValue("Password", Encrypt(ConnectionDatabaseProfile.Password))

                    ConnectionDatabaseProfileSaved = True

                    DatabaseRegistryKey.Close()

                    DatabaseRegistryKey.Dispose()

                    DatabaseRegistryKey = Nothing

                    RegistrySubKey.Close()

                    RegistrySubKey.Dispose()

                    RegistrySubKey = Nothing

                End If

            End If

            SaveConnectionDatabaseProfile = ConnectionDatabaseProfileSaved

        End Function
        Public Function DeleteConnectionDatabaseProfile(DatabaseName As String) As Boolean

            'objects
            Dim DatabaseProfiesRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfileDeleted As Boolean = False

            DatabaseProfiesRegistryKey = Registry.LoadConnectionDatabaseProfilesRegistryKey()

            If DatabaseProfiesRegistryKey IsNot Nothing Then

                ConnectionDatabaseProfileDeleted = DeleteConnectionDatabaseProfile(DatabaseProfiesRegistryKey, DatabaseName)

                DatabaseProfiesRegistryKey.Close()

                DatabaseProfiesRegistryKey.Dispose()

                DatabaseProfiesRegistryKey = Nothing

            End If

            DatabaseProfiesRegistryKey = Nothing

            DatabaseProfiesRegistryKey = Registry.LoadConnectionDatabaseProfilesRegistryKeyWin64

            If DatabaseProfiesRegistryKey IsNot Nothing Then

                ConnectionDatabaseProfileDeleted = DeleteConnectionDatabaseProfile(DatabaseProfiesRegistryKey, DatabaseName)

                DatabaseProfiesRegistryKey.Close()

                DatabaseProfiesRegistryKey.Dispose()

                DatabaseProfiesRegistryKey = Nothing

            End If

            DeleteConnectionDatabaseProfile = ConnectionDatabaseProfileDeleted

        End Function
        Private Function DeleteConnectionDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, DatabaseName As String) As Boolean

            'objects
            Dim ConnectionDatabaseProfileDeleted As Boolean = False
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                For Each SubKeyName As String In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName, True)

                    If DatabaseRegistryKey.GetSubKeyNames.Contains(DatabaseName) Then

                        DatabaseRegistryKey.DeleteSubKeyTree(DatabaseName)

                        ConnectionDatabaseProfileDeleted = True

                    End If

                Next

            End If

            DeleteConnectionDatabaseProfile = ConnectionDatabaseProfileDeleted

        End Function
        Public Function ValidateServerAndDatabase(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Boolean, UserName As String, ByRef Password As String, Application As String, CheckPasswordPolicyMessages As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ConnectionString As String = ""
            Dim IsValid As Boolean = False

            Try

                ConnectionString = Database.CreateConnectionString(ServerName, "master", UseWindowsAuthentication, UserName, Password, Application)

                'Using DataContext = New Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                '    If DataContext.Databases.Any(Function(Database) Database.Name = DatabaseName) Then

                '        IsValid = True

                '    Else

                '        ErrorMessage = "Invalid database (" & DatabaseName & ")"
                '        IsValid = False

                '    End If

                'End Using

            Catch ex As Exception

                If TypeOf ex Is System.Data.SqlClient.SqlException Then

                    If DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18487 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = Security.Application.Advantage.ToString Then

                        '    Navigation.ShowMessageBox("Your password has expired.")

                        '    If Navigation.ShowChangePassword(SSConnectionString, UserName, Password) = WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "Your password has expired."

                        '    Navigation.ShowChangePasswordWithMessage(SSConnectionString, UserName, Password, ErrorMessage)

                        'End If

                    ElseIf DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18488 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = Security.Application.Advantage.ToString Then

                        '    Navigation.ShowMessageBox("You must change password on first login.")

                        '    If Navigation.ShowChangePassword(ServerName, DatabaseName, UserName, Password) = WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "You must change password on first login."

                        '    Navigation.ShowChangePasswordWithMessage(ServerName, DatabaseName, UserName, Password, ErrorMessage)

                        'End If

                    ElseIf DirectCast(ex, System.Data.SqlClient.SqlException).Number = -1 Then

                        ErrorMessage = "Invalid server (" & ServerName & ")"
                        IsValid = False

                    Else

                        ErrorMessage = DirectCast(ex, System.Data.SqlClient.SqlException).Message
                        IsValid = False

                    End If

                End If

            Finally
                ValidateServerAndDatabase = IsValid
            End Try

        End Function

#End Region

    End Module

End Namespace

