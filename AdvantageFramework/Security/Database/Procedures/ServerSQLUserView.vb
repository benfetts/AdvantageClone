Namespace Security.Database.Procedures.ServerSQLUserView

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Public Function IsSysAdmin(ByVal DbContext As Database.DbContext) As Boolean

        '    Try

        '        IsSysAdmin = (DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0)

        '    Catch ex As Exception
        '        IsSysAdmin = False
        '    End Try

        'End Function
        'Public Function IsSecurityAdmin(ByVal DbContext As Database.DbContext) As Boolean

        '    Try

        '        IsSecurityAdmin = (DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('securityadmin'), 0)").FirstOrDefault <> 0)

        '    Catch ex As Exception
        '        IsSecurityAdmin = False
        '    End Try

        'End Function
        'Public Function IsServerSQLUserSecurityAdmin(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsServerSQLUserSecurityAdmin = DbContext.Database.SqlQuery(Of String)("SELECT su.name FROM [dbo].[V_SERVER_SQLUSER] su LEFT OUTER JOIN sys.server_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'securityadmin' AND member_principal_id = {0}", ID).Any

        '    Catch ex As Exception
        '        IsServerSQLUserSecurityAdmin = False
        '    End Try

        'End Function
        'Public Function IsServerSQLUserSysAdmin(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsServerSQLUserSysAdmin = DbContext.Database.SqlQuery(Of String)("SELECT su.name FROM [dbo].[V_SERVER_SQLUSER] su LEFT OUTER JOIN sys.server_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'sysadmin' AND member_principal_id = {0}", ID).Any

        '    Catch ex As Exception
        '        IsServerSQLUserSysAdmin = False
        '    End Try

        'End Function
        'Public Function LoadByName(ByVal DbContext As Database.DbContext, ByVal Name As String) As Security.Database.Views.ServerSQLUser

        '    Try

        '        LoadByName = (From ServerSQLUser In DbContext.GetQuery(Of Database.Views.ServerSQLUser)
        '                      Where ServerSQLUser.Name = Name
        '                      Select ServerSQLUser).SingleOrDefault

        '    Catch ex As Exception
        '        LoadByName = Nothing
        '    End Try

        'End Function
        'Public Function LoadAvailableSQLUsers(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ServerSQLUser)

        '    LoadAvailableSQLUsers = From ServerSQLUser In DbContext.GetQuery(Of Database.Views.ServerSQLUser)
        '                            Where (ServerSQLUser.Type = "S" OrElse ServerSQLUser.Type = "U") AndAlso
        '                                  (ServerSQLUser.ID < 101 OrElse
        '                                   ServerSQLUser.ID > 255) AndAlso
        '                                  ServerSQLUser.Name <> "MS_AgentSigningCertificate" AndAlso
        '                                  ServerSQLUser.Name <> "sa" AndAlso
        '                                  ServerSQLUser.IsDisabled = False AndAlso
        '                                  DbContext.DatabaseSQLUsers.Any(Function(DatabaseSQLUser) DatabaseSQLUser.Name = ServerSQLUser.Name AndAlso
        '                                                                                               (DatabaseSQLUser.Type = "S" OrElse DatabaseSQLUser.Type = "U") AndAlso
        '                                                                                               DatabaseSQLUser.Name <> "dbo" AndAlso
        '                                                                                               DatabaseSQLUser.DefaultSchemaName = "dbo") = False
        '                            Select ServerSQLUser

        'End Function
        'Public Function LoadAllValidSQLUsers(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ServerSQLUser)

        '    LoadAllValidSQLUsers = From ServerSQLUser In DbContext.GetQuery(Of Database.Views.ServerSQLUser)
        '                           Where (ServerSQLUser.Type = "S" OrElse ServerSQLUser.Type = "U") AndAlso
        '                                 (ServerSQLUser.ID < 101 OrElse
        '                                  ServerSQLUser.ID > 255) AndAlso
        '                                 ServerSQLUser.Name <> "MS_AgentSigningCertificate" AndAlso
        '                                 ServerSQLUser.Name <> "sa" AndAlso
        '                                 ServerSQLUser.IsDisabled = False
        '                           Select ServerSQLUser

        'End Function
        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ServerSQLUser)

        '    Load = From ServerSQLUser In DbContext.GetQuery(Of Database.Views.ServerSQLUser)
        '           Select ServerSQLUser

        'End Function
        'Public Function CreateServerSQLUser(ByVal DbContext As Database.DbContext, ByVal Name As String, ByVal UseWindowsAuthentication As Boolean, _
        '                                    ByVal Password As String, ByVal ConfirmPassword As String, ByVal IsSecurityAdmin As Boolean, ByVal EnforcePasswordPolicy As Boolean, _
        '                                    ByVal MustChangePasswordAtNextLogin As Boolean, ByRef ErrorMessage As String) As Boolean

        '    'objects
        '    Dim Created As Boolean = False
        '    Dim PasswordPolicy As String = ""

        '    Try

        '        If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadByName(DbContext, Name) Is Nothing Then

        '            Created = True

        '            If UseWindowsAuthentication Then

        '                If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] FROM WINDOWS WITH DEFAULT_DATABASE=[master]", Name)) = 0 Then

        '                    Created = False
        '                    ErrorMessage = "Failed to create login."

        '                End If

        '            Else

        '                If Password = ConfirmPassword Then

        '                    If EnforcePasswordPolicy Then

        '                        PasswordPolicy = "ON"

        '                    Else

        '                        PasswordPolicy = "OFF"

        '                    End If

        '                    If MustChangePasswordAtNextLogin Then

        '                        If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] WITH PASSWORD = '{1}' MUST_CHANGE, DEFAULT_DATABASE=[master], CHECK_POLICY = {2}, CHECK_EXPIRATION = ON", Name, Password, PasswordPolicy)) = 0 Then

        '                            Created = False
        '                            ErrorMessage = "Failed to create login."

        '                        End If

        '                    Else

        '                        If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE LOGIN [{0}] WITH PASSWORD = '{1}', DEFAULT_DATABASE=[master], CHECK_POLICY = {2}", Name, Password, PasswordPolicy)) = 0 Then

        '                            Created = False
        '                            ErrorMessage = "Failed to create login."

        '                        End If

        '                    End If

        '                Else

        '                    Created = False
        '                    ErrorMessage = "Passwords do not match. Please retype passwords"

        '                End If

        '            End If

        '            If Created Then

        '                If IsSecurityAdmin Then

        '                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC master..sp_addsrvrolemember @loginame = N'{0}', @rolename = N'securityadmin'", Name))

        '                End If

        '            End If

        '        Else

        '            ErrorMessage = "Server SQL User already exits"

        '        End If

        '    Catch ex As Exception
        '        Created = False
        '        ErrorMessage = ex.Message
        '    Finally
        '        CreateServerSQLUser = Created
        '    End Try

        'End Function

#End Region

    End Module

End Namespace
