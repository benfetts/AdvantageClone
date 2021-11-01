Namespace Security

    <Serializable()> Public Class Session

#Region " Constants "

        'Public Const CONST_NIELSENWEBSERVICE_URL As String = "http://localhost/Advantage.Nielsen.WebServices"
        'Public Const CONST_NIELSENWEBSERVICE_URL As String = "https://project.gotoadvantage.com/nielsen"     '"https://api.gotoadvantage.com/NielsenWebService"
        Public Const CONST_NIELSENWEBSERVICE_URL As String = "https://www.advantagehosted.com/nielsenwebservice"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Application As AdvantageFramework.Security.Application = AdvantageFramework.Security.Application.Advantage
        Private _ServerName As String = ""
        Private _DatabaseName As String = ""
        Private _UseWindowsAuthentication As Boolean = False
        Private _UserName As String = ""
        Private _Password As String = ""
        Private _UserCode As String = ""
        Private _User As AdvantageFramework.Security.Classes.User = Nothing
        'Private _IsSecurityAdmin As Boolean = False
        Private _IsTimeEntryOnly As Boolean = False
        'Private _IsAdmin As Boolean = False
        Private _MenuHWND As Integer = 0
        'Private _IsSysAdmin As Boolean = False
        'Private _IsDBOwner As Boolean = False
        'Private _IsDBSecurityAdmin As Boolean = False
        'Private _IsDBAccessAdmin As Boolean = False
        Private _ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser = Nothing
        Private _RegisterSecuritySessionMessage As String = ""
        Private _UnregisterSecuritySessionMessage As String = ""
        Private _AdvantageUserLicenseInUseID As Integer = 0
        Private _EmployeeName As String = ""
		Private _HandlerAttached As Boolean = False
		Private _CheckForNielsenSetup As Boolean = False
		Private _IsNielsenSetup As Boolean = False
        Private _CheckForEastlanSetup As Boolean = False
        Private _IsEastlanSetup As Boolean = False
        Private _CheckForComscoreSetup As Boolean = False
        Private _IsComscoreSetup As Boolean = False
        Private _ConnectionString As String = ""
        Private _CheckForNationalSetup As Boolean = False
        Private _IsNationalSetup As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property AdvantageUserLicenseInUseID As Integer
            Get
                AdvantageUserLicenseInUseID = _AdvantageUserLicenseInUseID
            End Get
        End Property
        Public ReadOnly Property RegisterSecuritySessionMessage As String
            Get
                RegisterSecuritySessionMessage = _RegisterSecuritySessionMessage
            End Get
        End Property
        Public ReadOnly Property UnregisterSecuritySessionMessage As String
            Get
                UnregisterSecuritySessionMessage = _UnregisterSecuritySessionMessage
            End Get
        End Property
        Public ReadOnly Property Application As AdvantageFramework.Security.Application
            Get
                Application = _Application
            End Get
        End Property
        Public ReadOnly Property User As AdvantageFramework.Security.Classes.User
            Get
                User = _User
            End Get
        End Property
        Public ReadOnly Property ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser
            Get
                ClientPortalUser = _ClientPortalUser
            End Get
        End Property
        Public ReadOnly Property ServerName As String
            Get
                ServerName = _ServerName
            End Get
        End Property
        Public ReadOnly Property DatabaseName As String
            Get
                DatabaseName = _DatabaseName
            End Get
        End Property
        Public ReadOnly Property UseWindowsAuthentication As Boolean
            Get
                UseWindowsAuthentication = _UseWindowsAuthentication
            End Get
        End Property
        Public ReadOnly Property UserName As String
            Get
                UserName = _UserName
            End Get
        End Property
        Public ReadOnly Property Password As String
            Get
                Password = _Password
            End Get
        End Property
        Public ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Public ReadOnly Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
        End Property
        Public ReadOnly Property ConnectionString As String
            Get
                ConnectionString = _ConnectionString
            End Get
        End Property
        'Public ReadOnly Property IsAdmin As Boolean
        '    Get
        '        IsAdmin = _IsAdmin
        '    End Get
        'End Property
        'Public ReadOnly Property IsSecurityAdmin As Boolean
        '    Get
        '        IsSecurityAdmin = _IsSecurityAdmin
        '    End Get
        'End Property
        'Public ReadOnly Property IsSysAdmin As Boolean
        '    Get
        '        IsSysAdmin = _IsSysAdmin
        '    End Get
        'End Property
        'Public ReadOnly Property IsDBOwner As Boolean
        '    Get
        '        IsDBOwner = _IsDBOwner
        '    End Get
        'End Property
        'Public ReadOnly Property IsDBSecurityAdmin As Boolean
        '    Get
        '        IsDBSecurityAdmin = _IsDBSecurityAdmin
        '    End Get
        'End Property
        'Public ReadOnly Property IsDBAccessAdmin As Boolean
        '    Get
        '        IsDBAccessAdmin = _IsDBAccessAdmin
        '    End Get
        'End Property
        Public ReadOnly Property IsTimeEntryOnly As Boolean
            Get
                IsTimeEntryOnly = _IsTimeEntryOnly
            End Get
        End Property
        Public Property MenuHWND As Integer
            Get
                MenuHWND = _MenuHWND
            End Get
            Set(ByVal value As Integer)
                _MenuHWND = value
            End Set
        End Property
        Public Property HasLimitedOfficeCodes As Boolean = False
        Public Property AccessibleOfficeCodes As Generic.List(Of String) = Nothing
        Public Property AccessibleGLOfficeCodes As Generic.List(Of String) = Nothing
        Public ReadOnly Property NielsenConnectionString As String
            Get
                NielsenConnectionString = AdvantageFramework.Database.CreateConnectionString(NielsenServerName, NielsenDatabaseName, NielsenUseWindowsAuthentication, NielsenUserName, NielsenPassword, "Nielsen")
            End Get
        End Property
        Public Property NielsenServerName As String = Nothing
        Public Property NielsenDatabaseName As String = Nothing
        Public Property NielsenUserName As String = Nothing
        Public Property NielsenPassword As String = Nothing
        Public Property NielsenUseWindowsAuthentication As Boolean = False
        Public Property NielsenClientCodeForHosted As String = Nothing
        Public Property NationalServerName As String = Nothing
        Public Property NationalDatabaseName As String = Nothing
        Public Property NationalUserName As String = Nothing
        Public Property NationalPassword As String = Nothing
        Public Property NationalUseWindowsAuthentication As Boolean = False
        Public ReadOnly Property NationalConnectionString As String
            Get
                NationalConnectionString = AdvantageFramework.Database.CreateConnectionString(NationalServerName, NationalDatabaseName, NationalUseWindowsAuthentication, NationalUserName, NationalPassword, "National")
            End Get
        End Property
        Public Property UserLoginAuditID As Integer
        Public Property SQLUserName As String = String.Empty
        Public Property SQLPassword As String = String.Empty

#End Region

#Region " Methods "

        Public Sub New(Application As AdvantageFramework.Security.Application, ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean,
                       ByVal UserName As String, ByVal Password As String, ByVal UserCode As String, ByVal AdvantageUserLicenseInUseID As Integer, ConnectionString As String)

            'objects
            Dim ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            _ServerName = ServerName
            _DatabaseName = DatabaseName
            _UseWindowsAuthentication = UseWindowsAuthentication
            _UserName = UserName
            _Password = Password
            _UserCode = UserCode
            _Application = Application
            _AdvantageUserLicenseInUseID = AdvantageUserLicenseInUseID
            _ConnectionString = ConnectionString

            GetSQLUserNameAndPassword()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                SecurityDbContext.Database.Connection.Open()

                If _Application = Methods.Application.Advantage_Nielsen_Database_Update Then



                ElseIf _Application = Methods.Application.Client_Portal Then

                    Try

                        _ClientPortalUser = New Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByUserName(SecurityDbContext, _UserCode))

                    Catch ex As Exception
                        _ClientPortalUser = Nothing
                    End Try

                Else

                    Try

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserCode)
                        _User = New Classes.User(User)

                    Catch ex As Exception
                        _User = Nothing
                    End Try

                    If _Application = Application.Advantage OrElse _Application = Application.Webvantage Then

                        Try

                            NielsenServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_SERVER.ToString)).FirstOrDefault
                            NielsenDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_NAME.ToString)).FirstOrDefault
                            NielsenUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_USER.ToString)).FirstOrDefault
                            NielsenPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_PASSWORD.ToString)).FirstOrDefault
                            NielsenUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_WINDOWS_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NielsenServerName = Nothing
                        End Try

                        Try

                            NationalServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_SERVER.ToString)).FirstOrDefault
                            NationalDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_NAME.ToString)).FirstOrDefault
                            NationalUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_USER.ToString)).FirstOrDefault
                            NationalPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_PASSWORD.ToString)).FirstOrDefault
                            NationalUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_WIN_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NationalServerName = Nothing
                        End Try

                    End If

                    If (Not String.IsNullOrWhiteSpace(NationalServerName) OrElse Not String.IsNullOrWhiteSpace(NielsenServerName)) AndAlso _Application = Application.Advantage Then

                        GetNielsenClientCodeForHosted(SecurityDbContext)

                    End If

                    Try

                        HasLimitedOfficeCodes = SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", _User.EmployeeCode)).FirstOrDefault

                    Catch ex As Exception
                        HasLimitedOfficeCodes = False
                    End Try

                    Try

                        AccessibleOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        AccessibleGLOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_gl_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleGLOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        _EmployeeName = User.Employee.ToString

                    Catch ex As Exception
                        _EmployeeName = Nothing
                    End Try

                    Try

                        'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _User.UserName)

                        'If DatabaseSQLUser IsNot Nothing Then

                        '_IsAdmin = _User.IsAdvanAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBOwner = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBOwner(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBSecurityAdmin = False '_User.IsSecurityAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBSecurityAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBAccessAdmin = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBAccessAdmin(SecurityDbContext, DatabaseSQLUser.ID)

                        'End If

                    Catch ex As Exception
                        '_IsAdmin = False
                        '_IsDBOwner = False
                        '_IsDBSecurityAdmin = False
                        '_IsDBAccessAdmin = False
                    End Try

                    '_IsSecurityAdmin = User.IsSecurityAdmin
                    '_IsSysAdmin = User.IsSysAdmin

                    'ServerSQLUser = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadByName(SecurityDbContext, _UserName)

                    'If ServerSQLUser IsNot Nothing Then

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSecurityAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSecurityAdmin = True

                    '    End If

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSysAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSysAdmin = True

                    '    End If

                    'End If

                    Try

                        If Application = Methods.Application.Advantage Then

                            UserSetting = User.UserSettings.SingleOrDefault(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        Else

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        End If

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        If UserSetting.StringValue = "Y" Then

                            _IsTimeEntryOnly = True

                        End If

                    End If

                End If

                SecurityDbContext.Database.Connection.Close()

            End Using

        End Sub
        Public Sub New(ByVal ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application, ByVal ServerName As String, ByVal DatabaseName As String,
                       ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByVal Password As String, ByVal UserCode As String, ByVal AdvantageUserLicenseInUseID As Integer, ConnectionString As String)

            'objects
            Dim ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            _ServerName = ServerName
            _DatabaseName = DatabaseName
            _UseWindowsAuthentication = UseWindowsAuthentication
            _UserName = UserName
            _Password = Password
            _UserCode = UserCode
            _Application = ApplicationEntity.ID
            _AdvantageUserLicenseInUseID = AdvantageUserLicenseInUseID
            _ConnectionString = ConnectionString

            GetSQLUserNameAndPassword()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                SecurityDbContext.Database.Connection.Open()

                If _Application = Methods.Application.Advantage_Nielsen_Database_Update Then



                ElseIf _Application = Methods.Application.Client_Portal Then

                    Try

                        _ClientPortalUser = New Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByUserName(SecurityDbContext, _UserCode))

                    Catch ex As Exception
                        _ClientPortalUser = Nothing
                    End Try

                    AccessibleOfficeCodes = New Generic.List(Of String)
                    AccessibleGLOfficeCodes = New Generic.List(Of String)

                Else

                    Try

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserCode)
                        _User = New Classes.User(User)

                    Catch ex As Exception
                        _User = Nothing
                    End Try

                    If _Application = Application.Advantage OrElse _Application = Application.Webvantage Then

                        Try

                            NielsenServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_SERVER.ToString)).FirstOrDefault
                            NielsenDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_NAME.ToString)).FirstOrDefault
                            NielsenUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_USER.ToString)).FirstOrDefault
                            NielsenPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_PASSWORD.ToString)).FirstOrDefault
                            NielsenUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_WINDOWS_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NielsenServerName = Nothing
                        End Try

                        Try

                            NationalServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_SERVER.ToString)).FirstOrDefault
                            NationalDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_NAME.ToString)).FirstOrDefault
                            NationalUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_USER.ToString)).FirstOrDefault
                            NationalPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_PASSWORD.ToString)).FirstOrDefault
                            NationalUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_WIN_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NationalServerName = Nothing
                        End Try

                    End If

                    If (Not String.IsNullOrWhiteSpace(NationalServerName) OrElse Not String.IsNullOrWhiteSpace(NielsenServerName)) AndAlso _Application = Application.Advantage Then

                        GetNielsenClientCodeForHosted(SecurityDbContext)

                    End If

                    Try

                        HasLimitedOfficeCodes = SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", _User.EmployeeCode)).FirstOrDefault

                    Catch ex As Exception
                        HasLimitedOfficeCodes = False
                    End Try

                    Try

                        AccessibleOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        AccessibleGLOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_gl_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleGLOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        _EmployeeName = User.Employee.ToString

                    Catch ex As Exception
                        _EmployeeName = Nothing
                    End Try

                    Try

                        'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _User.UserName)

                        'If DatabaseSQLUser IsNot Nothing Then

                        '_IsAdmin = _User.IsAdvanAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBOwner = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBOwner(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBSecurityAdmin = False '_User.IsSecurityAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBSecurityAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBAccessAdmin = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBAccessAdmin(SecurityDbContext, DatabaseSQLUser.ID)

                        'End If

                    Catch ex As Exception
                        '_IsAdmin = False
                        '_IsDBOwner = False
                        '_IsDBSecurityAdmin = False
                        '_IsDBAccessAdmin = False
                    End Try

                    '_IsSecurityAdmin = User.IsSecurityAdmin
                    '_IsSysAdmin = User.IsSysAdmin

                    'ServerSQLUser = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadByName(SecurityDbContext, _UserName)

                    'If ServerSQLUser IsNot Nothing Then

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSecurityAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSecurityAdmin = True

                    '    End If

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSysAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSysAdmin = True

                    '    End If

                    'End If

                    Try

                        If Application = Methods.Application.Advantage Then

                            UserSetting = User.UserSettings.SingleOrDefault(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        Else

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        End If

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        If UserSetting.StringValue = "Y" Then

                            _IsTimeEntryOnly = True

                        End If

                    End If

                End If

                SecurityDbContext.Database.Connection.Close()

            End Using

        End Sub
        Public Sub New(ByVal Application As AdvantageFramework.Security.Application, ByVal ConnectionString As String, ByVal UserCode As String, ByVal AdvantageUserLicenseInUseID As Integer, SSConnectionString As String)

            'objects
            Dim SqlConntection As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            SqlConntection = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

            _Application = Application
            _ServerName = SqlConntection.DataSource
            _DatabaseName = SqlConntection.InitialCatalog
            _UseWindowsAuthentication = SqlConntection.IntegratedSecurity
            _UserName = SqlConntection.UserID
            _Password = SqlConntection.Password
            _UserCode = UserCode
            _AdvantageUserLicenseInUseID = AdvantageUserLicenseInUseID
            _ConnectionString = SSConnectionString

            GetSQLUserNameAndPassword()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                SecurityDbContext.Database.Connection.Open()

                If _Application = Methods.Application.Advantage_Nielsen_Database_Update Then



                ElseIf _Application = Methods.Application.Client_Portal Then

                    Try

                        _ClientPortalUser = New Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByUserName(SecurityDbContext, _UserCode))

                    Catch ex As Exception
                        _ClientPortalUser = Nothing
                    End Try

                Else

                    Try

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserCode)
                        _User = New Classes.User(User)

                    Catch ex As Exception
                        _User = Nothing
                    End Try

                    If _Application = Application.Advantage OrElse _Application = Application.Webvantage Then

                        Try

                            NielsenServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_SERVER.ToString)).FirstOrDefault
                            NielsenDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_NAME.ToString)).FirstOrDefault
                            NielsenUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_USER.ToString)).FirstOrDefault
                            NielsenPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_DB_PASSWORD.ToString)).FirstOrDefault
                            NielsenUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NIELSEN_WINDOWS_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NielsenServerName = Nothing
                        End Try

                        Try

                            NationalServerName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_SERVER.ToString)).FirstOrDefault
                            NationalDatabaseName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_NAME.ToString)).FirstOrDefault
                            NationalUserName = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_USER.ToString)).FirstOrDefault
                            NationalPassword = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_DB_PASSWORD.ToString)).FirstOrDefault
                            NationalUseWindowsAuthentication = CBool(SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}'", AdvantageFramework.Agency.Settings.NATIONAL_WIN_AUTH.ToString)).FirstOrDefault)

                        Catch ex As Exception
                            NationalServerName = Nothing
                        End Try

                    End If

                    If (Not String.IsNullOrWhiteSpace(NationalServerName) OrElse Not String.IsNullOrWhiteSpace(NielsenServerName)) AndAlso _Application = Application.Advantage Then

                        GetNielsenClientCodeForHosted(SecurityDbContext)

                    End If

                    Try

                        HasLimitedOfficeCodes = SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", _User.EmployeeCode)).FirstOrDefault

                    Catch ex As Exception
                        HasLimitedOfficeCodes = False
                    End Try

                    Try

                        AccessibleOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        AccessibleGLOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[advsp_employee_gl_office_limits_load] '{0}'", _User.EmployeeCode)).ToList

                    Catch ex As Exception
                        AccessibleGLOfficeCodes = New Generic.List(Of String)
                    End Try

                    Try

                        _EmployeeName = User.Employee.ToString

                    Catch ex As Exception
                        _EmployeeName = Nothing
                    End Try

                    Try

                        'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _User.UserName)

                        'If DatabaseSQLUser IsNot Nothing Then

                        '_IsAdmin = _User.IsAdvanAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBOwner = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBOwner(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBSecurityAdmin = False '_User.IsSecurityAdmin 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBSecurityAdmin(SecurityDbContext, DatabaseSQLUser.ID)
                        '_IsDBAccessAdmin = False 'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBAccessAdmin(SecurityDbContext, DatabaseSQLUser.ID)

                        'End If

                    Catch ex As Exception
                        '_IsAdmin = False
                        '_IsDBOwner = False
                        '_IsDBSecurityAdmin = False
                        '_IsDBAccessAdmin = False
                    End Try

                    '_IsSecurityAdmin = User.IsSecurityAdmin
                    '_IsSysAdmin = User.IsSysAdmin

                    'ServerSQLUser = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadByName(SecurityDbContext, _UserName)

                    'If ServerSQLUser IsNot Nothing Then

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSecurityAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSecurityAdmin = True

                    '    End If

                    '    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSysAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                    '        _IsSysAdmin = True

                    '    End If

                    'End If

                    Try

                        If Application = Methods.Application.Advantage Then

                            UserSetting = User.UserSettings.SingleOrDefault(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        Else

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        End If

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        If UserSetting.StringValue = "Y" Then

                            _IsTimeEntryOnly = True

                        End If

                    End If

                End If

                SecurityDbContext.Database.Connection.Close()

            End Using

        End Sub
        Public Sub SetPassword(ByVal Password As String)

            _Password = Password

        End Sub
        ''' <summary>
        ''' DO NOT USE FOR WEBVANTAGE --> Advantage Only!!!!
        ''' </summary>
        Public Sub SetRegisterSecuritySessionMessage(ByVal RegisterSecuritySessionMessage As String)

            _RegisterSecuritySessionMessage = RegisterSecuritySessionMessage

        End Sub
        Public Function RegisterSecuritySession(Optional ByVal WebID As String = Nothing) As Boolean

            'objects
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMenuHWND As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWebID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTimeHWND As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterConnect As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
            Dim RegisteredSecuritySession As Boolean = True
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

            If _Application = Methods.Application.Client_Portal Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                    ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUser.ID)

                    ClientPortalUser.WebID = WebID
                    _ClientPortalUser.WebID = WebID

                    RegisteredSecuritySession = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser)

                    If RegisteredSecuritySession = False Then

                        _RegisterSecuritySessionMessage = "Failed to register client portal user."

                    End If

                End Using

            Else

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                        SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@sec_user_id", SqlDbType.Int)
                        SqlParameterUserID.Value = Me.User.ID

                        SqlParameterMenuHWND = New System.Data.SqlClient.SqlParameter("@menu_hwnd_in", SqlDbType.Int)
                        SqlParameterMenuHWND.Value = System.DBNull.Value

                        SqlParameterWebID = New System.Data.SqlClient.SqlParameter("@web_id_in", SqlDbType.VarChar)
                        SqlParameterWebID.Value = System.DBNull.Value

                        SqlParameterTimeHWND = New System.Data.SqlClient.SqlParameter("@time_hwnd_in", SqlDbType.Int)
                        SqlParameterTimeHWND.Value = System.DBNull.Value

                        SqlParameterConnect = New System.Data.SqlClient.SqlParameter("@connect", SqlDbType.Bit)
                        SqlParameterConnect.Value = System.DBNull.Value

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                        SqlParameterReturnValue.Direction = ParameterDirection.Output

                        If _Application = AdvantageFramework.Security.Application.Advantage AndAlso Me.IsTimeEntryOnly = False Then

                            SqlParameterMenuHWND.Value = _MenuHWND

                        ElseIf _Application = AdvantageFramework.Security.Application.Webvantage Then

                            SqlParameterWebID.Value = WebID

                        ElseIf _Application = AdvantageFramework.Security.Application.Advantage AndAlso Me.IsTimeEntryOnly Then

                            SqlParameterTimeHWND.Value = _MenuHWND

                        End If

                        SqlParameterConnect.Value = 1
                        SqlParameterReturnValue.Value = 0

                        SecurityDbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_register_session @sec_user_id, @menu_hwnd_in, @web_id_in, @time_hwnd_in, @connect, @ret_val",
                            SqlParameterUserID, SqlParameterMenuHWND, SqlParameterWebID, SqlParameterTimeHWND, SqlParameterConnect, SqlParameterReturnValue)

                        _RegisterSecuritySessionMessage = TranslateReturnValue(SqlParameterReturnValue.Value)

                    End Using

                Catch ex As Exception
                    _RegisterSecuritySessionMessage = ex.Message
                End Try

                If _RegisterSecuritySessionMessage <> "" Then

                    RegisteredSecuritySession = False

                End If

            End If

            RegisterSecuritySession = RegisteredSecuritySession

        End Function
        Public Function UnregisterSecuritySession(Optional ByVal WebID As String = Nothing) As Boolean

            'objects
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMenuHWND As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWebID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTimeHWND As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterConnect As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
            Dim UnregisteredSecuritySession As Boolean = True
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

            If _Application = Methods.Application.Client_Portal Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                    ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUser.ID)

                    ClientPortalUser.WebID = Nothing
                    _ClientPortalUser.WebID = Nothing

                    UnregisteredSecuritySession = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser)

                End Using

            Else

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                        SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@sec_user_id", SqlDbType.Int)
                        SqlParameterUserID.Value = Me.User.ID

                        SqlParameterMenuHWND = New System.Data.SqlClient.SqlParameter("@menu_hwnd_in", SqlDbType.Int)
                        SqlParameterMenuHWND.Value = System.DBNull.Value

                        SqlParameterWebID = New System.Data.SqlClient.SqlParameter("@web_id_in", SqlDbType.VarChar)
                        SqlParameterWebID.Value = System.DBNull.Value

                        SqlParameterTimeHWND = New System.Data.SqlClient.SqlParameter("@time_hwnd_in", SqlDbType.Int)
                        SqlParameterTimeHWND.Value = System.DBNull.Value

                        SqlParameterConnect = New System.Data.SqlClient.SqlParameter("@connect", SqlDbType.Bit)
                        SqlParameterConnect.Value = System.DBNull.Value

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                        SqlParameterReturnValue.Direction = ParameterDirection.Output

                        If _Application = AdvantageFramework.Security.Application.Advantage Then

                            SqlParameterMenuHWND.Value = _MenuHWND

                        ElseIf _Application = AdvantageFramework.Security.Application.Webvantage Then

                            SqlParameterWebID.Value = WebID

                        End If

                        SqlParameterConnect.Value = 0
                        SqlParameterReturnValue.Value = 0

                        SecurityDbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_register_session @sec_user_id, @menu_hwnd_in, @web_id_in, @time_hwnd_in, @connect, @ret_val",
                            SqlParameterUserID, SqlParameterMenuHWND, SqlParameterWebID, SqlParameterTimeHWND, SqlParameterConnect, SqlParameterReturnValue)

                        _UnregisterSecuritySessionMessage = TranslateReturnValue(SqlParameterReturnValue.Value)

                    End Using

                Catch ex As Exception
                    _UnregisterSecuritySessionMessage = ex.Message
                End Try

                If _UnregisterSecuritySessionMessage <> "" Then

                    UnregisteredSecuritySession = False

                End If

            End If

            UnregisterSecuritySession = UnregisteredSecuritySession

        End Function
        Private Function TranslateReturnValue(ByVal ReturnValue As Integer) As String

            'objects
            Dim Message As String = ""

            Select Case ReturnValue
                Case 3 'User has already been registered with the same session data
                    Message = ""
                Case 2 'Successfully unregistered user
                    Message = ""
                Case 1 'Successfully registered user
                    Message = ""
                Case -1 'Key decryption failed
                    Message = "Key decryption failed"
                Case -2 'No available licenses
                    Message = "No available licenses"
                Case -3 'User already has an active session using different session data
                    Message = "Warning: The system has detected that you may have multiple instances of advantage already connected to the same database. This can be caused by abnormal termination or being logged in at another PC. Please make sure none of these conditions exists then restart advantage."
                Case -4 'No window handle or session ID passed
                    Message = "No window handle or session ID passed"
                Case -5 'Could not update SEC_USER table
                    Message = "Could not update SEC_USER table"
                Case -6 'SEC_USER_ID not found
                    Message = "SEC_USER_ID not found"
                Case -7 'SEC_USER_ID not found
                    Message = "No window handle or session ID passed"
                Case -8 'SEC_USER_ID not found
                    Message = "Could not determine user license type"
            End Select

            TranslateReturnValue = Message

        End Function
        'Private Sub ValidateLicenseKeyCompletedHandler(ByVal sender As Object, ByVal e As AdvantageFramework.LicenseService.ValidateLicenseKeyCompletedEventArgs)

        '    Me.NielsenClientCodeForHosted = e.Result

        'End Sub
        'Private Sub CallValidateLicenseKeyAsync(EncryptedLicenseKey As String, AgencyName As String)

        '    If Not _HandlerAttached Then

        '        'AddHandler My.WebServices.Service.ValidateLicenseKeyCompleted, AddressOf Me.ValidateLicenseKeyCompletedHandler

        '        _HandlerAttached = True

        '    End If

        '    My.WebServices.Service.ValidateLicenseKeyAsync(EncryptedLicenseKey, AgencyName)

        'End Sub
        Private Sub LogError(ErrorText As String)

            Dim SqlParameterComputerName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterErrorText As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterComputerName = New System.Data.SqlClient.SqlParameter("@COMPUTER_NAME", SqlDbType.VarChar)
            SqlParameterComputerName.Value = Environment.MachineName

            SqlParameterErrorText = New System.Data.SqlClient.SqlParameter("@ERROR_TEXT", SqlDbType.VarChar)
            SqlParameterErrorText.Value = ErrorText

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.ConnectionString, Me.UserCode)

                DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.NIELSEN_ERROR_LOG (COMPUTER_NAME, ERROR_TEXT) VALUES (@COMPUTER_NAME, @ERROR_TEXT)", SqlParameterComputerName, SqlParameterErrorText)

            End Using

        End Sub
        'Private Sub GetNielsenClientCodeForHosted(ConnectionString As String, UserCode As String)

        '    'objects
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim EncryptedLicenseKey As String = Nothing
        '    Dim AgencyName As String = Nothing

        '    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

        '        If CBool(SecurityDbContext.Database.SqlQuery(Of Int32)("SELECT COALESCE(ASP_ACTIVE, 0) FROM dbo.AGENCY").FirstOrDefault) = True Then

        '            EncryptedLicenseKey = SecurityDbContext.Database.SqlQuery(Of String)("SELECT LICENSE_KEY FROM dbo.AGENCY").FirstOrDefault
        '            AgencyName = SecurityDbContext.Database.SqlQuery(Of String)("SELECT NAME FROM dbo.AGENCY").FirstOrDefault

        '            Try

        '                RestClient = New RestSharp.RestClient(AdvantageFramework.Security.Session.CONST_NIELSENWEBSERVICE_URL & "/api/")

        '                RestRequest = New RestSharp.RestRequest("LicenseKeyHistory/ValidateLicenseKey")

        '                RestRequest.Method = RestSharp.Method.GET
        '                RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '                RestRequest.AddParameter("EncryptedLicenseKey", EncryptedLicenseKey)
        '                RestRequest.AddParameter("AgencyName", AgencyName)

        '                RestResponse = RestClient.Execute(RestRequest)

        '                If RestResponse.StatusDescription = "OK" Then

        '                    Me.NielsenClientCodeForHosted = Newtonsoft.Json.JsonConvert.DeserializeObject(Of String)(RestResponse.Content)

        '                Else

        '                    LogError("StatusDescription:" & RestResponse.StatusDescription & Space(1) & If(RestResponse.ErrorMessage IsNot Nothing, "ErrorMessage:" & RestResponse.ErrorMessage, ""))

        '                End If

        '            Catch ex As Exception

        '                While ex.InnerException IsNot Nothing

        '                    ex = ex.InnerException

        '                End While

        '                LogError(ex.Message)

        '            End Try

        '            'CallValidateLicenseKeyAsync(EncryptedLicenseKey, AgencyName)

        '        End If

        '    End Using

        'End Sub
        Private Sub GetNielsenClientCodeForHosted(SecurityDbContext As AdvantageFramework.Security.Database.DbContext)

            If CBool(SecurityDbContext.Database.SqlQuery(Of Int32)("SELECT COALESCE(ASP_ACTIVE, 0) FROM dbo.AGENCY").FirstOrDefault) = True Then

                Me.NielsenClientCodeForHosted = SecurityDbContext.Database.SqlQuery(Of String)("SELECT ADVAN_CLIENT_CODE FROM dbo.ADVAN_CLIENT_CODE").FirstOrDefault

            End If

        End Sub
        Public Function GetNielsenClientCodeForNonHosted(DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim EncryptedLicenseKey As String = Nothing
            Dim AgencyName As String = Nothing
            Dim ClientCode As String = Nothing

            EncryptedLicenseKey = DbContext.Database.SqlQuery(Of String)("SELECT LICENSE_KEY FROM dbo.AGENCY").FirstOrDefault
            AgencyName = DbContext.Database.SqlQuery(Of String)("SELECT NAME FROM dbo.AGENCY").FirstOrDefault

            Try

                System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12

                RestClient = New RestSharp.RestClient(AdvantageFramework.Security.Session.CONST_NIELSENWEBSERVICE_URL & "/api/")

                RestRequest = New RestSharp.RestRequest("LicenseKeyHistory/ValidateLicenseKey")

                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("EncryptedLicenseKey", EncryptedLicenseKey)
                RestRequest.AddParameter("AgencyName", AgencyName)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientCode = Newtonsoft.Json.JsonConvert.DeserializeObject(Of String)(RestResponse.Content)

                End If

            Catch ex As Exception

            End Try

            GetNielsenClientCodeForNonHosted = ClientCode

        End Function
		Public Function IsNielsenSetup() As Boolean

			If _CheckForNielsenSetup = False Then

				_CheckForNielsenSetup = True

                If String.IsNullOrWhiteSpace(Me.NielsenServerName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenDatabaseName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenUserName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenPassword) = False AndAlso
                        AdvantageFramework.Database.IsValidConnectionString(Me.NielsenConnectionString) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.ConnectionString, Me.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            If String.IsNullOrWhiteSpace(Me.NielsenClientCodeForHosted) = False Then

                                _IsNielsenSetup = True

                            End If

                        Else

                            _IsNielsenSetup = True

                        End If

                    End Using

                End If

            End If

			IsNielsenSetup = _IsNielsenSetup

		End Function
        Public Function IsEastlanSetup() As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If _CheckForEastlanSetup = False Then

                _CheckForEastlanSetup = True

                If String.IsNullOrWhiteSpace(Me.NielsenServerName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenDatabaseName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenUserName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NielsenPassword) = False AndAlso
                        AdvantageFramework.Database.IsValidConnectionString(Me.NielsenConnectionString) Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.ConnectionString, Me.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.EASTLAN_ENABLED.ToString)

                        If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                            _IsEastlanSetup = True

                        End If

                    End Using

                End If

            End If

            IsEastlanSetup = _IsEastlanSetup

        End Function
        Public Function IsComscoreSetup() As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If _CheckForComscoreSetup = False Then

                _CheckForComscoreSetup = True

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.ConnectionString, Me.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_AS_CLIENT_ID.ToString)

                    If Setting IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Setting.Value) Then

                        _IsComscoreSetup = True

                    End If

                End Using

            End If

            IsComscoreSetup = _IsComscoreSetup

        End Function
        Public Function IsNationalSetup() As Boolean

            'objects
            Dim TableName As String = Nothing

            If _CheckForNationalSetup = False Then

                _CheckForNationalSetup = True

                If String.IsNullOrWhiteSpace(Me.NationalServerName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NationalDatabaseName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NationalUserName) = False AndAlso
                        String.IsNullOrWhiteSpace(Me.NationalPassword) = False AndAlso
                        AdvantageFramework.Database.IsValidConnectionString(Me.NationalConnectionString) Then

                    Using NationalDbContext = New AdvantageFramework.Database.DbContext(Me.NationalConnectionString, Nothing)

                        TableName = NationalDbContext.Database.SqlQuery(Of String)("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NATIONAL_YEAR'").FirstOrDefault

                        If TableName IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.ConnectionString, Me.UserCode)

                                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                    If String.IsNullOrWhiteSpace(Me.NielsenClientCodeForHosted) = False Then

                                        _IsNationalSetup = True

                                    End If

                                    'Else

                                    '    _IsNationalSetup = True

                                End If

                            End Using

                        End If

                    End Using

                End If

            End If

            IsNationalSetup = _IsNationalSetup

        End Function
        Private Sub GetSQLUserNameAndPassword()

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(Me.ConnectionString)
                SqlConnectionStringBuilder.MultipleActiveResultSets = True

                Me.SQLUserName = SqlConnectionStringBuilder.UserID
                Me.SQLPassword = SqlConnectionStringBuilder.Password

            Catch ex As Exception
                Me.SQLUserName = String.Empty
                Me.SQLPassword = String.Empty
            End Try

        End Sub

#End Region

    End Class

End Namespace
