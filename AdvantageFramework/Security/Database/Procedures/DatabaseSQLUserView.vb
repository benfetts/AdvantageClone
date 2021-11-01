Namespace Security.Database.Procedures.DatabaseSQLUserView

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

        'Public Function IsDBDataReader(ByVal DbContext As Database.DbContext) As Boolean

        '    Try

        '        IsDBDataReader = (DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_MEMBER('db_datareader'), 0)").FirstOrDefault <> 0)

        '    Catch ex As Exception
        '        IsDBDataReader = False
        '    End Try

        'End Function
        'Public Function IsDBDataWriter(ByVal DbContext As Database.DbContext) As Boolean

        '    Try

        '        IsDBDataWriter = (DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_MEMBER('db_datawriter'), 0)").FirstOrDefault <> 0)

        '    Catch ex As Exception
        '        IsDBDataWriter = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserLicenseWrite(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserLicenseWrite = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'license_write' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserLicenseWrite = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserLicenseRead(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserLicenseRead = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'license_read' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserLicenseRead = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserAdvantageAdmin(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Boolean

        '    'objects
        '    Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
        '    Dim IsAdvantageAdmin As Boolean = False

        '    Try

        '        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(DbContext, UserCode)

        '    Catch ex As Exception
        '        User = Nothing
        '    End Try

        '    If User IsNot Nothing Then

        '        IsAdvantageAdmin = IsDatabaseSQLUserAdvantageAdmin(DbContext, User)

        '    End If

        '    IsDatabaseSQLUserAdvantageAdmin = IsAdvantageAdmin

        'End Function
        'Public Function IsDatabaseSQLUserAdvantageAdmin(ByVal DbContext As Database.DbContext, ByVal User As AdvantageFramework.Security.Database.Entities.User) As Boolean

        '    'objects
        '    Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
        '    Dim IsAdvantageAdmin As Boolean = False

        '    If User IsNot Nothing Then

        '        Try

        '            DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(DbContext, User.UserName)

        '        Catch ex As Exception
        '            DatabaseSQLUser = Nothing
        '        End Try

        '        If DatabaseSQLUser IsNot Nothing Then

        '            IsAdvantageAdmin = IsDatabaseSQLUserAdvantageAdmin(DbContext, DatabaseSQLUser.ID)

        '        End If

        '    End If

        '    IsDatabaseSQLUserAdvantageAdmin = IsAdvantageAdmin

        'End Function
        'Public Function IsDatabaseSQLUserAdvantageAdmin(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserAdvantageAdmin = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'advan_admin' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserAdvantageAdmin = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserDBOwner(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserDBOwner = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'db_owner' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserDBOwner = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserDBSecurityAdmin(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserDBSecurityAdmin = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'db_securityadmin' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserDBSecurityAdmin = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserDBAccessAdmin(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserDBAccessAdmin = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'db_accessadmin' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserDBAccessAdmin = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserDBDataReader(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserDBDataReader = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'db_datareader' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserDBDataReader = False
        '    End Try

        'End Function
        'Public Function IsDatabaseSQLUserDBDataWriter(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Boolean

        '    Try

        '        IsDatabaseSQLUserDBDataWriter = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[V_DATABASE_SQLUSER] su LEFT OUTER JOIN sys.database_role_members rm ON rm.role_principal_id = su.principal_id WHERE su.[type] = 'R' AND su.name = 'db_datawriter' AND member_principal_id = {0}", ID)).FirstOrDefault > 0

        '    Catch ex As Exception
        '        IsDatabaseSQLUserDBDataWriter = False
        '    End Try

        ''End Function
        'Public Function LoadWithNameThatEndsWith(ByVal DbContext As Database.DbContext, ByVal Name As String) As System.Collections.Generic.List(Of Security.Database.Views.DatabaseSQLUser)

        '    LoadWithNameThatEndsWith = (From DatabaseSQLUser In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.DatabaseSQLUser).ToList
        '                                Where DatabaseSQLUser.Name.EndsWith(Name) = True
        '                                Select DatabaseSQLUser).ToList

        'End Function
        'Public Function LoadByName(ByVal DbContext As Database.DbContext, ByVal Name As String) As Security.Database.Views.DatabaseSQLUser

        '    Try

        '        LoadByName = (From DatabaseSQLUser In DbContext.GetQuery(Of Database.Views.DatabaseSQLUser)
        '                      Where DatabaseSQLUser.Name = Name
        '                      Select DatabaseSQLUser).SingleOrDefault

        '    Catch ex As Exception
        '        LoadByName = Nothing
        '    End Try

        'End Function
        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.DatabaseSQLUser)

        '    Load = From DatabaseSQLUser In DbContext.GetQuery(Of Database.Views.DatabaseSQLUser)
        '           Select DatabaseSQLUser

        'End Function
        'Public Function CreateDatabaseSQLUser(ByVal DbContext As Database.DbContext, ByVal Name As String, ByVal IsAdvantageAdmin As Boolean, ByVal ShowMessageBox As Boolean) As Boolean

        '    'objects
        '    Dim Created As Boolean = False
        '    Dim ErrorMessage As String = ""

        '    Try

        '        If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(DbContext, Name) Is Nothing Then

        '            Created = True

        '            If DbContext.Database.ExecuteSqlCommand(String.Format("CREATE USER [{0}] FOR LOGIN [{0}]", Name)) = 0 Then

        '                Created = False

        '            End If

        '            If Created Then

        '                DbContext.Database.ExecuteSqlCommand(String.Format("ALTER USER [{0}] WITH DEFAULT_SCHEMA=[dbo]", Name))
        '                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datareader', N'{0}'", Name))
        '                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'db_datawriter', N'{0}'", Name))

        '                If IsAdvantageAdmin Then

        '                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'advan_admin', N'{0}'", Name))

        '                End If

        '            Else

        '                ErrorMessage = "Failed to create Database SQL User"

        '            End If

        '        Else

        '            ErrorMessage = "Database SQL User already exits"

        '        End If

        '        If Created = False Then

        '            If ShowMessageBox Then

        '                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

        '            End If

        '        End If

        '    Catch ex As Exception
        '        Created = False
        '    Finally
        '        CreateDatabaseSQLUser = Created
        '    End Try

        'End Function
        'Public Function DeleteDatabaseSQLUser(ByVal DbContext As Database.DbContext, ByVal Name As String) As Boolean

        '    'objects
        '    Dim Deleted As Boolean = False

        '    Try

        '        If DbContext.Database.ExecuteSqlCommand(String.Format("DROP USER [{0}]", Name)) > 0 Then

        '            Deleted = True

        '        End If

        '    Catch ex As Exception
        '        Deleted = False
        '    Finally
        '        DeleteDatabaseSQLUser = Deleted
        '    End Try

        'End Function

#End Region

    End Module

End Namespace
