Partial Public Class CreateAdvantageUserPage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property AdvantageUserName As String
        Get
            AdvantageUserName = TextEditForm_User.Text
        End Get
        Set(value As String)
            TextEditForm_User.Text = value
        End Set
    End Property
    Public Property AdvantagePassword As String
        Get
            AdvantagePassword = TextEditForm_Password.Text
        End Get
        Set(value As String)
            TextEditForm_Password.Text = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Function CreateServerSQLUser(DbContext As AdvantageFramework.Security.Database.DbContext, Name As String, UseWindowsAuthentication As Boolean,
                                        Password As String, ConfirmPassword As String, IsSecurityAdmin As Boolean, EnforcePasswordPolicy As Boolean,
                                        MustChangePasswordAtNextLogin As Boolean, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim Created As Boolean = False
        Dim PasswordPolicy As String = ""
        Dim UserID As Integer = 0
        Dim FailedGettingUserID As Boolean = False
        Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing

        DbContext.Database.Connection.Open()

        DbContextTransaction = DbContext.Database.BeginTransaction

        Try

            Try

                UserID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL([principal_id], 0) FROM sys.server_principals WHERE [name] = '{0}'", Name)).FirstOrDefault()

            Catch ex As Exception
                FailedGettingUserID = True
            End Try

            If FailedGettingUserID = False Then

                If UserID = 0 Then

                    Created = True

                    If UseWindowsAuthentication Then

                        If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] FROM WINDOWS WITH DEFAULT_DATABASE=[master]", Name)) = 0 Then

                            Created = False
                            ErrorMessage = "Failed to create login."

                        End If

                    Else

                        If Password = ConfirmPassword Then

                            If EnforcePasswordPolicy Then

                                PasswordPolicy = "ON"

                            Else

                                PasswordPolicy = "OFF"

                            End If

                            If MustChangePasswordAtNextLogin Then

                                If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] WITH PASSWORD = '{1}' MUST_CHANGE, DEFAULT_DATABASE=[master], CHECK_POLICY = {2}, CHECK_EXPIRATION = ON", Name, Password, PasswordPolicy)) = 0 Then

                                    Created = False
                                    ErrorMessage = "Failed to create login."

                                End If

                            Else

                                If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] WITH PASSWORD = '{1}', DEFAULT_DATABASE=[master], CHECK_POLICY = {2}", Name, Password, PasswordPolicy)) = 0 Then

                                    Created = False
                                    ErrorMessage = "Failed to create login."

                                End If

                            End If

                        Else

                            Created = False
                            ErrorMessage = "Passwords do not match. Please retype passwords"

                        End If

                    End If

                    If Created Then

                        If IsSecurityAdmin Then

                            'If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'securityadmin'", Name)) = 0 Then

                            '    Created = False
                            '    ErrorMessage = "Failed to add user to security admin role."

                            'End If

                            'If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'serveradmin'", Name)) = 0 Then

                            '    Created = False
                            '    ErrorMessage = "Failed to add user to server admin role."

                            'End If

                            'If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'sysadmin'", Name)) = 0 Then

                            '    Created = False
                            '    ErrorMessage = "Failed to add user to sys admin role."

                            'End If

                        End If

                    End If

                    If Created Then

                        If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE USER [{0}] FOR LOGIN [{0}]", Name)) = 0 Then

                            Created = False
                            ErrorMessage = "Failed to add user to database."

                        End If

                        If Created Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("ALTER USER [{0}] WITH DEFAULT_SCHEMA=[dbo]", Name)) = 0 Then

                                Created = False
                                ErrorMessage = "Failed to alter default schema."

                            End If

                        End If

                        If Created Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datareader', N'{0}'", Name)) = 0 Then

                                Created = False
                                ErrorMessage = "Failed to add database db_datareader role."

                            End If

                        End If

                        If Created Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datawriter', N'{0}'", Name)) = 0 Then

                                Created = False
                                ErrorMessage = "Failed to add database db_datawriter role."

                            End If

                        End If

                        If Created Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_owner', N'{0}'", Name)) = 0 Then

                                Created = False
                                ErrorMessage = "Failed to add database db_owner role."

                            End If

                        End If

                        'If Created Then

                        '    If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'advan_admin', N'{0}'", Name)) = 0 Then

                        '        Created = False
                        '        ErrorMessage = "Failed to add database advan_admin role."

                        '    End If

                        'End If

                    End If

                Else

                    ErrorMessage = "Server SQL User already exits"

                End If

            Else

                ErrorMessage = "Failed trying to determine if SQL user already exists"

            End If

        Catch ex As Exception
            Created = False
            ErrorMessage = ex.Message
        End Try

        If Created Then

            DbContextTransaction.Commit()

        Else

            DbContextTransaction.Rollback()

        End If

        CreateServerSQLUser = Created

    End Function
    Public Function AddServerSQLUser(DbContext As AdvantageFramework.Security.Database.DbContext, Name As String, AddUserToDB As Boolean, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim Created As Boolean = True
        Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing

        DbContext.Database.Connection.Open()

        DbContextTransaction = DbContext.Database.BeginTransaction

        Try

            'If Created Then

            '    Try

            '        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'securityadmin'", Name))

            '    Catch ex As Exception
            '        Created = False
            '    End Try

            'End If

            'If Created Then

            '    Try

            '        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'serveradmin'", Name))

            '    Catch ex As Exception
            '        Created = False
            '    End Try

            'End If

            'If Created Then

            '    Try

            '        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'sysadmin'", Name))

            '    Catch ex As Exception
            '        Created = False
            '    End Try

            'End If

            If Created Then

                If AddUserToDB Then

                    If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE USER [{0}] FOR LOGIN [{0}]", Name)) = 0 Then

                        Created = False
                        ErrorMessage = "Failed to add user to database."

                    End If

                End If

            End If

            If Created Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("ALTER USER [{0}] WITH DEFAULT_SCHEMA=[dbo]", Name))

                Catch ex As Exception
                    Created = False
                End Try

            End If

            If Created Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datareader', N'{0}'", Name))

                Catch ex As Exception
                    Created = False
                End Try

            End If

            If Created Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datawriter', N'{0}'", Name))

                Catch ex As Exception
                    Created = False
                End Try

            End If

            If Created Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_owner', N'{0}'", Name))

                Catch ex As Exception
                    Created = False
                End Try

            End If

            'If Created Then

            '    Try

            '        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'advan_admin', N'{0}'", Name))

            '    Catch ex As Exception
            '        Created = False
            '    End Try

            'End If

        Catch ex As Exception
            Created = False
            ErrorMessage = ex.Message
        End Try

        If Created Then

            DbContextTransaction.Commit()

        Else

            DbContextTransaction.Rollback()

        End If

        AddServerSQLUser = Created

    End Function
    Private Function GetProperAvailableSQLUsers() As Generic.List(Of String)

        Dim SQLUserSelect As String = String.Empty
        Dim ProperAvailableSQLUsers As Generic.List(Of String) = Nothing

        Try

            SQLUserSelect = "SELECT 
	                                    DISTINCT U.name
                                    FROM
	                                    (SELECT
			                                    spU.name
			                                    ,MAX(CASE WHEN srm.role_principal_id = 3 THEN 1 ELSE 0 END) AS sysadmin
			                                    ,MAX(CASE WHEN srm.role_principal_id = 5 THEN 1 ELSE 0 END) AS serveradmin
		                                    FROM
			                                    sys.server_principals AS spR
			                                    JOIN sys.server_role_members AS srm ON spR.principal_id = srm.role_principal_id
			                                    JOIN sys.server_principals AS spU ON srm.member_principal_id = spU.principal_id
		                                    WHERE
			                                    spR.[type] = 'R'
			                                    AND spU.[type] = 'S'
			                                    AND ISNULL(spU.is_disabled,0) = 0
			                                    AND spU.principal_id <> 1
		                                    GROUP BY
			                                    spU.name) AS U
                                    WHERE
	                                    U.sysadmin = 1 OR U.serveradmin = 1"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                ProperAvailableSQLUsers = SecurityDbContext.Database.SqlQuery(Of String)(SQLUserSelect).ToList()

            End Using

        Catch ex As Exception
            ProperAvailableSQLUsers = New Generic.List(Of String)
        End Try

        GetProperAvailableSQLUsers = ProperAvailableSQLUsers

    End Function
    Private Function GetAvailableSQLUsers() As Generic.List(Of String)

        Dim SQLUserSelect As String = String.Empty
        Dim AvailableSQLUsers As Generic.List(Of String) = Nothing

        Try

            SQLUserSelect = "SELECT 
	                                name
                                FROM 
	                                sys.server_principals dbp
                                WHERE 
	                                dbp.[type] = 'S'
	                                AND dbp.[sid] IS NOT NULL
	                                AND ISNULL(dbp.is_disabled,0) = 0
	                                AND dbp.principal_id <> 1
                                    AND (name != 'guest' AND name != 'dbo')"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                AvailableSQLUsers = SecurityDbContext.Database.SqlQuery(Of String)(SQLUserSelect).ToList()

            End Using

        Catch ex As Exception
            AvailableSQLUsers = New Generic.List(Of String)
        End Try

        GetAvailableSQLUsers = AvailableSQLUsers

    End Function
    Private Function IsUserAddedToDB(UserName As String) As Boolean

        Dim UserAddedToDB As Boolean = False
        Dim SQLUserSelect As String = String.Empty
        Dim DBSQLUsers As Generic.List(Of String) = Nothing

        Try

            SQLUserSelect = "SELECT 
	                                name
                                FROM 
	                                sys.database_principals dbp
                                WHERE 
	                                dbp.[type] = 'S'
	                                AND dbp.[sid] IS NOT NULL
                                    AND (name != 'guest' AND name != 'dbo')"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                DBSQLUsers = SecurityDbContext.Database.SqlQuery(Of String)(SQLUserSelect).ToList()

            End Using

        Catch ex As Exception
            DBSQLUsers = New Generic.List(Of String)
        End Try

        UserAddedToDB = DBSQLUsers.Contains(UserName)

        IsUserAddedToDB = UserAddedToDB

    End Function
    Public Sub Create()

        SimpleButtonForm_Create.PerformClick()

    End Sub
    Public Sub SelectUser()

        SimpleButtonForm_Select.PerformClick()

    End Sub
    Public Sub Skip()

        CType(PageViewModel, CreateAdvantageUserPageViewModel).SetIsComplete(True)

        Me.WizardViewModel.PageCompleted()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Create_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Create.Click

        Dim HasRequiredInput As Boolean = True
        Dim CreatedSQLServerUser As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim UserID As Integer = 0
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

        DxErrorProvider1.ClearErrors()

        If String.IsNullOrWhiteSpace(TextEditForm_User.Text) Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "User Name is required.")

            Else

                DxErrorProvider1.SetError(TextEditForm_User, "User Name is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

            End If

            HasRequiredInput = False

        End If

        If String.IsNullOrWhiteSpace(TextEditForm_Password.Text) Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Password is required.")

            Else

                DxErrorProvider1.SetError(TextEditForm_Password, "Password is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

            End If

            HasRequiredInput = False

        Else

            If TextEditForm_Password.Text.Length < 6 Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Password must be greater than 6 characters and have at least one alpha and one numeric character.")

                Else

                    DxErrorProvider1.SetError(TextEditForm_Password, "Password must be greater than 6 characters and have at least one alpha and one numeric character.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

                End If

                HasRequiredInput = False

            ElseIf TextEditForm_Password.Text.Any(Function(PWC) Char.IsDigit(PWC) = True) = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Password must be greater than 6 characters and have at least one alpha and one numeric character.")

                Else

                    DxErrorProvider1.SetError(TextEditForm_Password, "Password must be greater than 6 characters and have at least one alpha and one numeric character.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

                End If

                HasRequiredInput = False

            ElseIf TextEditForm_Password.Text.Any(Function(PWC) Char.IsLetter(PWC) = True) = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Password must be greater than 6 characters and have at least one alpha and one numeric character.")

                Else

                    DxErrorProvider1.SetError(TextEditForm_Password, "Password must be greater than 6 characters and have at least one alpha and one numeric character.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

                End If

                HasRequiredInput = False

            End If

        End If

        If HasRequiredInput Then

            OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                CreatedSQLServerUser = CreateServerSQLUser(SecurityDbContext, TextEditForm_User.Text, False, TextEditForm_Password.Text, TextEditForm_Password.Text, True, False, False, ErrorMessage)

            End Using

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

            If CreatedSQLServerUser = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Failed to create advantage user.")

                    Else

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to create advantage user.")

                    End If

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        DevExpress.XtraEditors.XtraMessageBox.Show("Failed to create advantage user.")

                    Else

                        DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to create advantage user.")

                    End If

                End If

            End If

        End If

        If CreatedSQLServerUser Then

            Me.WizardViewModel.WizardInputs.AdvantageUserSelected = False
            Me.WizardViewModel.WizardInputs.AdvantageUserName = TextEditForm_User.Text
            Me.WizardViewModel.WizardInputs.AdvantagePassword = TextEditForm_Password.Text
            Me.WizardViewModel.WizardInputs.IsAdvantageUserInDB = True

            CType(PageViewModel, CreateAdvantageUserPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            CType(PageViewModel, CreateAdvantageUserPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub
    Private Sub SimpleButtonForm_Select_Click(sender As Object, e As EventArgs) Handles SimpleButtonForm_Select.Click

        Dim HasRequiredInput As Boolean = True
        Dim SelectedSQLServerUser As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim UserID As Integer = 0
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim AvailableSQLUsers As Generic.List(Of String) = Nothing
        Dim ProperAvailableSQLUsers As Generic.List(Of String) = Nothing
        Dim IsAdvantageUserInDB As Boolean = False
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        DxErrorProvider1.ClearErrors()

        If String.IsNullOrWhiteSpace(TextEditForm_User.Text) Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "User Name is required.")

            Else

                DxErrorProvider1.SetError(TextEditForm_User, "User Name is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

            End If

            HasRequiredInput = False

        End If

        If String.IsNullOrWhiteSpace(TextEditForm_Password.Text) Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Password is required.")

            Else

                DxErrorProvider1.SetError(TextEditForm_Password, "Password is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

            End If

            HasRequiredInput = False

        End If

        If HasRequiredInput Then

            OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

            Try

                AvailableSQLUsers = GetAvailableSQLUsers()

                If AvailableSQLUsers.Contains(TextEditForm_User.Text) = False Then

                    Throw New Exception("User is not available in this SQL instance.")

                End If

                'ProperAvailableSQLUsers = GetProperAvailableSQLUsers()

                'If ProperAvailableSQLUsers.Contains(TextEditForm_User.Text) = False Then

                '    Throw New Exception("User must be assigned to one of the following roles --> serveradmin, sysadmin")

                'End If

                IsAdvantageUserInDB = IsUserAddedToDB(TextEditForm_User.Text)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                    If AddServerSQLUser(SecurityDbContext, TextEditForm_User.Text, If(IsAdvantageUserInDB = False, True, False), ErrorMessage) = False Then

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Throw New Exception("Failed trying to add/modify user on database.")

                        Else

                            Throw New Exception(ErrorMessage)

                        End If

                    End If

                End Using

                ConnectionDatabaseProfile = New AdvantageFramework.Database.ConnectionDatabaseProfile

                ConnectionDatabaseProfile.ServerName = Me.WizardViewModel.WizardInputs.ServerName
                ConnectionDatabaseProfile.DatabaseName = Me.WizardViewModel.WizardInputs.Database
                ConnectionDatabaseProfile.UserName = TextEditForm_User.Text
                ConnectionDatabaseProfile.Password = Me.TextEditForm_Password.Text

                If AdvantageFramework.Database.TestConnectionString(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage)) = False Then

                    Throw New Exception("Failed verifying connection with those credentials.")

                End If

                SelectedSQLServerUser = True

            Catch ex As Exception
                SelectedSQLServerUser = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

            End Try

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

            If SelectedSQLServerUser = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", "Failed to verify selected advantage user.")

                    Else

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageUserPage", ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to verify selected advantage user.")

                    End If

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        DevExpress.XtraEditors.XtraMessageBox.Show("Failed to verify selected advantage user.")

                    Else

                        DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to verify selected advantage user.")

                    End If

                End If

            End If

        End If

        If SelectedSQLServerUser Then

            Me.WizardViewModel.WizardInputs.AdvantageUserSelected = True
            Me.WizardViewModel.WizardInputs.AdvantageUserName = TextEditForm_User.Text
            Me.WizardViewModel.WizardInputs.AdvantagePassword = TextEditForm_Password.Text
            Me.WizardViewModel.WizardInputs.IsAdvantageUserInDB = True

            CType(PageViewModel, CreateAdvantageUserPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            CType(PageViewModel, CreateAdvantageUserPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub

#End Region

#End Region

End Class
