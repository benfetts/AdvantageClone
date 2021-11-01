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
            National
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Function LoadDatabaseCollation(ByVal ConnectionString As String) As String

			'objects
			Dim DatabaseCollation As String = ""
			Dim DatabaseDetail As AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail = Nothing

			Try

				Using DataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(ConnectionString, "")

					DatabaseDetail = DataContext.DatabaseDetails.Where(Function(DBDetail) DBDetail.Name = DataContext.Connection.Database).SingleOrDefault

					DatabaseCollation = DatabaseDetail.Collation

				End Using

			Catch ex As Exception
				DatabaseCollation = ""
			End Try

			LoadDatabaseCollation = DatabaseCollation

		End Function
		Public Sub CloseDbContext(ByVal DbContext As System.Data.Entity.DbContext)

			If DbContext IsNot Nothing Then

				DbContext.Dispose()

				DbContext = Nothing

			End If

		End Sub
		Public Sub CloseDataContext(ByVal DataContext As System.Data.Linq.DataContext)

			If DataContext IsNot Nothing Then

				DataContext.Dispose()

				DataContext = Nothing

			End If

		End Sub
        Public Function CreateConnectionString(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean,
                                               Optional ByVal UserName As String = "", Optional ByVal Password As String = "", Optional ByVal Application As String = "Advantage") As String

            'objects
            Dim ConnectionString As String = ""
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder

            SqlConnectionStringBuilder.ApplicationName = Application
            SqlConnectionStringBuilder.DataSource = ServerName
            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            If UseWindowsAuthentication Then

                SqlConnectionStringBuilder.IntegratedSecurity = UseWindowsAuthentication
                SqlConnectionStringBuilder.PersistSecurityInfo = False

            Else

                SqlConnectionStringBuilder.PersistSecurityInfo = True
                SqlConnectionStringBuilder.UserID = UserName
                SqlConnectionStringBuilder.Password = Password

            End If

            ConnectionString = SqlConnectionStringBuilder.ConnectionString

            If Application = AdvantageFramework.Security.Application.Webvantage.ToString Then

                ConnectionString &= ";Pooling=False;Connect Timeout=1200;Connection Lifetime=15;Connection Reset=False;Max Pool Size=1;"

            ElseIf Application = AdvantageFramework.Security.Application.Webvantage_Password_Admin.ToString Then

                'Only for validation!
                ConnectionString &= ";Pooling=False;Connect Timeout=1;Connection Lifetime=1;Connection Reset=False;Max Pool Size=1;"

            ElseIf Application = "Nielsen" Then

                ConnectionString &= ";Max Pool Size=32767;"

            ElseIf Application = AdvantageFramework.Security.Application.ProofingAPI.ToString Then

                ConnectionString &= ";"

            End If

            CreateConnectionString = ConnectionString

        End Function
        Public Function IsValidConnectionString(ConnectionString As String) As Boolean


			'objects
			Dim IsValid As Boolean = True
			Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

			Try

				SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

				If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) OrElse String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) Then

					IsValid = False

				End If

			Catch ex As Exception
				IsValid = False
			End Try

			If IsValid Then

				IsValid = TestConnectionString(ConnectionString)

			End If

			IsValidConnectionString = IsValid

		End Function
		Public Function IsValidConnectionStringWithTimeoutSet(ConnectionString As String) As Boolean


			'objects
			Dim IsValid As Boolean = True
			Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

			Try

				SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

				SqlConnectionStringBuilder.ConnectTimeout = 1

				If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) OrElse String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) Then

					IsValid = False

				End If

			Catch ex As Exception
				IsValid = False
			End Try

			If IsValid Then

				IsValid = TestConnectionString(SqlConnectionStringBuilder.ToString)

			End If

			IsValidConnectionStringWithTimeoutSet = IsValid

		End Function
		Public Function TestConnectionString(ByVal ConnectionString As String) As Boolean

			TestConnectionString = TestConnectionString(ConnectionString, "")

		End Function
        Public Function TestConnectionString(ByVal ConnectionString As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim CanConnect As Boolean = True

            Try

                Using DataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                    If DataContext.Databases.Any Then

                        CanConnect = True

                    Else

                        CanConnect = False

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
                CanConnect = False
            Finally
                TestConnectionString = CanConnect
            End Try

        End Function
        Public Function LoadSQLUser(ConnectionString As String) As String


            'objects
            Dim SQLUser As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

                SQLUser = SqlConnectionStringBuilder.UserID

            Catch ex As Exception
                SQLUser = String.Empty
            End Try

            LoadSQLUser = SQLUser

        End Function
        Public Function LoadDatabaseProfile(ByVal DatabaseName As String) As AdvantageFramework.Database.DatabaseProfile

			'objects
			Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
			Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

			For Each Profile In LoadDatabaseProfiles()

				If Profile.DatabaseName.ToUpper = DatabaseName.ToUpper Then

					DatabaseProfile = Profile
					Exit For

				End If

			Next

			LoadDatabaseProfile = DatabaseProfile

		End Function
        Public Function LoadDatabaseProfiles() As Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

            RegistryKey = AdvantageFramework.Registry.LoadDatabaseProfilesRegistryKey()

            If RegistryKey IsNot Nothing Then

                DatabaseProfiles = LoadDatabaseProfiles(RegistryKey)

                RegistryKey.Close()

                RegistryKey.Dispose()

                RegistryKey = Nothing

            End If

            If DatabaseProfiles Is Nothing Then

                DatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            End If

            LoadDatabaseProfiles = DatabaseProfiles

        End Function
        Public Function LoadDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal ServerName As String, ByVal DatabaseName As String) As AdvantageFramework.Database.DatabaseProfile

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

            If RegistryKey IsNot Nothing Then

                DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile

                RegistrySubKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistryKey, DatabaseName)

                If RegistrySubKey IsNot Nothing Then

                    DatabaseProfile.DatabaseServer = ServerName.Replace("#", "\")
                    DatabaseProfile.DatabaseName = DatabaseName
                    DatabaseProfile.DatabaseUserName = RegistrySubKey.GetValue("Username").ToString
                    DatabaseProfile.DatabasePassword = AdvantageFramework.Security.Encryption.Decrypt(RegistrySubKey.GetValue("Password").ToString)
                    DatabaseProfile.CPDatabaseUserName = RegistrySubKey.GetValue("CPUsername").ToString
                    DatabaseProfile.CPDatabasePassword = AdvantageFramework.Security.Encryption.Decrypt(RegistrySubKey.GetValue("CPPassword").ToString)

                    If RegistrySubKey.GetValue("EnableServices") IsNot Nothing Then

                        DatabaseProfile.EnableServices = RegistrySubKey.GetValue("EnableServices").ToString

                    Else

                        DatabaseProfile.EnableServices = True

                    End If

                End If

                If RegistrySubKey IsNot Nothing Then

                    RegistrySubKey.Close()

                    RegistrySubKey.Dispose()

                    RegistrySubKey = Nothing

                End If

            End If

            LoadDatabaseProfile = DatabaseProfile

        End Function
        Public Function LoadDatabaseProfiles(ByRef RegistryKey As Microsoft.Win32.RegistryKey) As Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                DatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

                For Each SubKeyName In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName)

                    For Each DatabaseSubKeyName In DatabaseRegistryKey.GetSubKeyNames

                        DatabaseProfile = AdvantageFramework.Database.LoadDatabaseProfile(DatabaseRegistryKey, SubKeyName, DatabaseSubKeyName)

                        If DatabaseProfile IsNot Nothing Then

                            DatabaseProfiles.Add(DatabaseProfile)

                        End If

                    Next

                Next

            End If

            LoadDatabaseProfiles = DatabaseProfiles

        End Function
        Public Function SaveDatabaseProfile(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal IsUpdating As Boolean) As Boolean

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseProfileSaved As Boolean = False

            If DatabaseProfile IsNot Nothing AndAlso DatabaseProfile.DatabaseName <> "" Then

                RegistryKey = AdvantageFramework.Registry.LoadDatabaseProfilesRegistryKey()

                If RegistryKey IsNot Nothing Then

                    DatabaseProfileSaved = SaveDatabaseProfile(RegistryKey, DatabaseProfile, IsUpdating)

                    RegistryKey.Close()

                    RegistryKey.Dispose()

                    RegistryKey = Nothing

                End If

            End If

            SaveDatabaseProfile = DatabaseProfileSaved

        End Function
        Public Function SaveDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal Updating As Boolean) As Boolean

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseProfileSaved As Boolean = False

            If Updating Then

                RegistrySubKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistryKey, DatabaseProfile.DatabaseServer)

            Else

                RegistrySubKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, DatabaseProfile.DatabaseServer)

            End If

            If RegistrySubKey IsNot Nothing Then

                If Updating Then

                    DatabaseRegistryKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistrySubKey, DatabaseProfile.DatabaseName)

                Else

                    DatabaseRegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistrySubKey, DatabaseProfile.DatabaseName)

                End If

                If DatabaseRegistryKey IsNot Nothing Then

                    DatabaseRegistryKey.SetValue("Username", DatabaseProfile.DatabaseUserName)
                    DatabaseRegistryKey.SetValue("Password", AdvantageFramework.Security.Encryption.Encrypt(DatabaseProfile.DatabasePassword))
                    DatabaseRegistryKey.SetValue("CPUsername", DatabaseProfile.CPDatabaseUserName)
                    DatabaseRegistryKey.SetValue("CPPassword", AdvantageFramework.Security.Encryption.Encrypt(DatabaseProfile.CPDatabasePassword))
                    DatabaseRegistryKey.SetValue("EnableServices", DatabaseProfile.EnableServices)

                    DatabaseProfileSaved = True

                    DatabaseRegistryKey.Close()

                    DatabaseRegistryKey.Dispose()

                    DatabaseRegistryKey = Nothing

                    RegistrySubKey.Close()

                    RegistrySubKey.Dispose()

                    RegistrySubKey = Nothing

                End If

            End If

            SaveDatabaseProfile = DatabaseProfileSaved

        End Function
        Public Function DeleteDatabaseProfile(ByVal DatabaseName As String) As Boolean

            'objects
            Dim DatabaseProfiesRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DatabaseProfileDeleted As Boolean = False

            DatabaseProfiesRegistryKey = AdvantageFramework.Registry.LoadDatabaseProfilesRegistryKey()

            If DatabaseProfiesRegistryKey IsNot Nothing Then

                DatabaseProfileDeleted = DeleteDatabaseProfile(DatabaseProfiesRegistryKey, DatabaseName)

                DatabaseProfiesRegistryKey.Close()

                DatabaseProfiesRegistryKey.Dispose()

                DatabaseProfiesRegistryKey = Nothing

            End If

            DeleteDatabaseProfile = DatabaseProfileDeleted

        End Function
        Public Function DeleteDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal DatabaseName As String) As Boolean

            'objects
            Dim DatabaseProfileDeleted As Boolean = False
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                For Each SubKeyName In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName, True)

                    If DatabaseRegistryKey.GetSubKeyNames.Contains(DatabaseName) Then

                        DatabaseRegistryKey.DeleteSubKeyTree(DatabaseName)

                        DatabaseProfileDeleted = True

                    End If

                Next

            End If

            DeleteDatabaseProfile = DatabaseProfileDeleted

        End Function
        Public Function LoadConnectionDatabaseProfile(DatabaseName As String) As AdvantageFramework.Database.ConnectionDatabaseProfile

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

            For Each Profile In LoadConnectionDatabaseProfiles()

                If Profile.DatabaseName.ToUpper = DatabaseName.ToUpper Then

                    ConnectionDatabaseProfile = Profile
                    Exit For

                End If

            Next

            LoadConnectionDatabaseProfile = ConnectionDatabaseProfile

        End Function
        Public Function LoadConnectionDatabaseProfiles() As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            RegistryKey = AdvantageFramework.Registry.LoadConnectionDatabaseProfilesRegistryKeyReadOnly()

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfiles = LoadConnectionDatabaseProfiles(RegistryKey)

                RegistryKey.Close()

                RegistryKey.Dispose()

                RegistryKey = Nothing

            End If

            If ConnectionDatabaseProfiles Is Nothing Then

                ConnectionDatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            End If

            LoadConnectionDatabaseProfiles = ConnectionDatabaseProfiles

        End Function
        Public Function LoadConnectionDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ServerName As String, DatabaseName As String) As AdvantageFramework.Database.ConnectionDatabaseProfile

            'objects
            Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfile = New AdvantageFramework.Database.ConnectionDatabaseProfile

                RegistrySubKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32ReadOnly(RegistryKey, DatabaseName)

                If RegistrySubKey IsNot Nothing Then

                    ConnectionDatabaseProfile.ServerName = ServerName.Replace("#", "\")
                    ConnectionDatabaseProfile.DatabaseName = DatabaseName
                    ConnectionDatabaseProfile.UserName = RegistrySubKey.GetValue("UserName").ToString
                    ConnectionDatabaseProfile.Password = RegistrySubKey.GetValue("Password").ToString

                End If

                If RegistrySubKey IsNot Nothing Then

                    RegistrySubKey.Close()

                    RegistrySubKey.Dispose()

                    RegistrySubKey = Nothing

                End If

            End If

            LoadConnectionDatabaseProfile = ConnectionDatabaseProfile

        End Function
        Public Function LoadConnectionDatabaseProfiles(ByRef RegistryKey As Microsoft.Win32.RegistryKey) As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            'objects
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                ConnectionDatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

                For Each SubKeyName In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName)

                    For Each DatabaseSubKeyName In DatabaseRegistryKey.GetSubKeyNames

                        ConnectionDatabaseProfile = AdvantageFramework.Database.LoadConnectionDatabaseProfile(DatabaseRegistryKey, SubKeyName, DatabaseSubKeyName)

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            ConnectionDatabaseProfiles.Add(ConnectionDatabaseProfile)

                        End If

                    Next

                Next

            End If

            LoadConnectionDatabaseProfiles = ConnectionDatabaseProfiles

        End Function
        Public Function SaveConnectionDatabaseProfile(ByRef ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile, IsUpdating As Boolean) As Boolean

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim ConnectionDatabaseProfileSaved As Boolean = False

            If ConnectionDatabaseProfile IsNot Nothing AndAlso ConnectionDatabaseProfile.DatabaseName <> "" Then

                RegistryKey = AdvantageFramework.Registry.LoadConnectionDatabaseProfilesRegistryKey()

                If RegistryKey IsNot Nothing Then

                    ConnectionDatabaseProfileSaved = SaveConnectionDatabaseProfile(RegistryKey, ConnectionDatabaseProfile, IsUpdating)

                    RegistryKey.Close()

                    RegistryKey.Dispose()

                    RegistryKey = Nothing

                End If

                If IntPtr.Size <> 4 Then

                    RegistryKey = AdvantageFramework.Registry.LoadConnectionDatabaseProfilesRegistryKeyWin64()

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
        Private Function SaveConnectionDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByRef ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile, Updating As Boolean) As Boolean

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

                RegistrySubKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

                If RegistrySubKey Is Nothing Then

                    RegistrySubKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

                End If

            Else

                RegistrySubKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, ConnectionDatabaseProfile.ServerName)

            End If

            If RegistrySubKey IsNot Nothing Then

                If Updating Then

                    DatabaseRegistryKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                    If DatabaseRegistryKey Is Nothing Then

                        DatabaseRegistryKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                    End If

                Else

                    DatabaseRegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistrySubKey, ConnectionDatabaseProfile.DatabaseName)

                End If

                If DatabaseRegistryKey IsNot Nothing Then

                    DatabaseRegistryKey.SetValue("UserName", ConnectionDatabaseProfile.UserName)
                    DatabaseRegistryKey.SetValue("Password", AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.Password))

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

            DatabaseProfiesRegistryKey = AdvantageFramework.Registry.LoadConnectionDatabaseProfilesRegistryKey()

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

                For Each SubKeyName In RegistryKey.GetSubKeyNames

                    DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName, True)

                    If DatabaseRegistryKey.GetSubKeyNames.Contains(DatabaseName) Then

                        DatabaseRegistryKey.DeleteSubKeyTree(DatabaseName)

                        ConnectionDatabaseProfileDeleted = True

                    End If

                Next

            End If

            DeleteConnectionDatabaseProfile = ConnectionDatabaseProfileDeleted

        End Function
        Public Function LoadConnectionDatabaseProfileForAdvantage() As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            'objects
            Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
            Dim XMLFile As String = ""
            Dim XML As String = ""
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.Security.AdvantageConnectionConfigurationFileName

            ConnectionDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

            If My.Computer.FileSystem.FileExists(XMLFile) Then

                Try

                    XmlTextReader = New System.Xml.XmlTextReader(XMLFile)

                    Do Until XmlTextReader.Read() = False

                        If XmlTextReader.Name = "ConnectionDatabaseProfile" Then

                            XML = XmlTextReader.ReadOuterXml

                            ConnectionDatabaseProfile = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.ConnectionDatabaseProfile))

                            If ConnectionDatabaseProfile IsNot Nothing Then

                                'If DecryptPassword Then

                                '    ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

                                'End If

                                ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                            End If

                        End If

                    Loop

                Catch ex As Exception
                    XML = ""
                Finally

                    If XmlTextReader IsNot Nothing Then

                        XmlTextReader.Close()

                    End If

                    XmlTextReader = Nothing

                End Try

            End If

            LoadConnectionDatabaseProfileForAdvantage = ConnectionDatabaseProfileList

        End Function
        Public Function LoadODBCs() As Generic.List(Of AdvantageFramework.Database.ODBC)

            'objects
            Dim RegistryKeys As Generic.List(Of Microsoft.Win32.RegistryKey) = Nothing
            Dim ODBC As AdvantageFramework.Database.ODBC = Nothing
            Dim ODBCList As Generic.List(Of AdvantageFramework.Database.ODBC) = Nothing
            Dim ODBCRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DNSEntryRegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim DNSDirectory As String = String.Empty

            ODBCList = New Generic.List(Of AdvantageFramework.Database.ODBC)

            RegistryKeys = New Generic.List(Of Microsoft.Win32.RegistryKey)

            ODBCRegistryKey = Nothing

            Try

                ODBCRegistryKey = AdvantageFramework.Registry.LoadODBCLocalMachineRegistryKeyReadOnly32Bit()

            Catch ex As Exception
                ODBCRegistryKey = Nothing
            End Try

            If ODBCRegistryKey IsNot Nothing Then

                RegistryKeys.Add(ODBCRegistryKey)

            End If

            ODBCRegistryKey = Nothing

            Try

                ODBCRegistryKey = AdvantageFramework.Registry.LoadODBCCurrentUserRegistryKeyReadOnly32Bit()

            Catch ex As Exception
                ODBCRegistryKey = Nothing
            End Try

            If ODBCRegistryKey IsNot Nothing Then

                RegistryKeys.Add(ODBCRegistryKey)

            End If

            ODBCRegistryKey = Nothing

            Try

                ODBCRegistryKey = AdvantageFramework.Registry.LoadODBCLocalMachineRegistryKeyReadOnly()

            Catch ex As Exception
                ODBCRegistryKey = Nothing
            End Try

            If ODBCRegistryKey IsNot Nothing Then

                RegistryKeys.Add(ODBCRegistryKey)

            End If

            ODBCRegistryKey = Nothing

            Try

                ODBCRegistryKey = AdvantageFramework.Registry.LoadODBCCurrentUserRegistryKeyReadOnly()

            Catch ex As Exception
                ODBCRegistryKey = Nothing
            End Try

            If ODBCRegistryKey IsNot Nothing Then

                RegistryKeys.Add(ODBCRegistryKey)

            End If

            For Each RegistryKey In RegistryKeys.ToList

                DNSDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(RegistryKey.Name, "\")

                For Each SubKeyName In RegistryKey.GetSubKeyNames

                    DNSEntryRegistryKey = RegistryKey.OpenSubKey(SubKeyName)

                    If DNSEntryRegistryKey IsNot Nothing Then

                        ODBC = New AdvantageFramework.Database.ODBC

                        ODBC.DNSName = DNSEntryRegistryKey.Name.Replace(DNSDirectory, "")
                        ODBC.ServerName = DNSEntryRegistryKey.GetValue("Server")
                        ODBC.DatabaseName = DNSEntryRegistryKey.GetValue("Database")

                        If String.IsNullOrWhiteSpace(ODBC.ServerName) = False Then

                            ODBC.ServerName = ODBC.ServerName.Replace("#", "\")

                        End If

                        If ODBCList.Any(Function(Entity) Entity.DNSName.ToUpper = ODBC.DNSName.ToUpper) = False Then

                            ODBCList.Add(ODBC)

                        End If

                        DNSEntryRegistryKey.Close()

                        DNSEntryRegistryKey.Dispose()

                        DNSEntryRegistryKey = Nothing

                    End If

                Next

                RegistryKeys.Remove(RegistryKey)

                If RegistryKey IsNot Nothing Then

                    RegistryKey.Close()

                    RegistryKey.Dispose()

                    RegistryKey = Nothing

                End If

            Next

            LoadODBCs = ODBCList

        End Function
        Public Function LoadSimpleDatabaseProfileList() As Generic.List(Of AdvantageFramework.Database.SimpleDatabaseProfile)

			'objects
			Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
			Dim XMLFile As String = ""
			Dim XML As String = ""
			Dim SimpleDatabaseProfile As AdvantageFramework.Database.SimpleDatabaseProfile = Nothing
			Dim SimpleDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.SimpleDatabaseProfile) = Nothing

			XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AdvantageConfiguration.xml"

			SimpleDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.SimpleDatabaseProfile)

			If My.Computer.FileSystem.FileExists(XMLFile) Then

				Try

					XmlTextReader = New System.Xml.XmlTextReader(XMLFile)

					Do Until XmlTextReader.Read() = False

						If XmlTextReader.Name = "SimpleDatabaseProfile" Then

							XML = XmlTextReader.ReadOuterXml

							SimpleDatabaseProfile = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.SimpleDatabaseProfile))

							If SimpleDatabaseProfile IsNot Nothing Then

								SimpleDatabaseProfileList.Add(SimpleDatabaseProfile)

							End If

						End If

					Loop

				Catch ex As Exception
					XML = ""
				Finally

					If XmlTextReader IsNot Nothing Then

						XmlTextReader.Close()

					End If

					XmlTextReader = Nothing

				End Try

			End If

			LoadSimpleDatabaseProfileList = SimpleDatabaseProfileList

		End Function
        Public Function ValidateServerAndDatabase(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByRef Password As String, ByVal Application As String, ByVal CheckPasswordPolicyMessages As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ConnectionString As String = ""
            Dim IsValid As Boolean = False

            Try

                ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, "master", UseWindowsAuthentication, UserName, Password, Application)

                Using DataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                    If DataContext.Databases.Any(Function(Database) Database.Name = DatabaseName) Then

                        IsValid = True

                    Else

                        ErrorMessage = "Invalid database (" & DatabaseName & ")"
                        IsValid = False

                    End If

                End Using

                'Using Conn = New SqlClient.SqlConnection(ConnectionString)

                '    Conn.Open()

                '    If Conn.State = ConnectionState.Open Then

                '        IsValid = True
                '        Conn.Close()

                '    End If

                'End Using

            Catch ex As Exception

                If TypeOf ex Is System.Data.SqlClient.SqlException Then

                    If DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18487 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = AdvantageFramework.Security.Application.Advantage.ToString Then

                        '    AdvantageFramework.Navigation.ShowMessageBox("Your password has expired.")

                        '    If AdvantageFramework.Navigation.ShowChangePassword(SSConnectionString, UserName, Password) = AdvantageFramework.WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "Your password has expired."

                        '    AdvantageFramework.Navigation.ShowChangePasswordWithMessage(SSConnectionString, UserName, Password, ErrorMessage)

                        'End If

                    ElseIf DirectCast(ex, System.Data.SqlClient.SqlException).Number = 18488 AndAlso CheckPasswordPolicyMessages AndAlso UseWindowsAuthentication = False Then

                        'If Application = AdvantageFramework.Security.Application.Advantage.ToString Then

                        '    AdvantageFramework.Navigation.ShowMessageBox("You must change password on first login.")

                        '    If AdvantageFramework.Navigation.ShowChangePassword(ServerName, DatabaseName, UserName, Password) = AdvantageFramework.WinForm.MessageBox.DialogResults.Cancel Then

                        '        ErrorMessage = "Your password has expired."
                        '        IsValid = False

                        '    Else

                        '        IsValid = True

                        '    End If

                        'Else

                        '    ErrorMessage = "You must change password on first login."

                        '    AdvantageFramework.Navigation.ShowChangePasswordWithMessage(ServerName, DatabaseName, UserName, Password, ErrorMessage)

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
        <System.Runtime.CompilerServices.Extension>
        Public Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function

#End Region

    End Module

End Namespace

