Imports AdvantageFramework.Database.Views

Namespace Security.Database.Procedures.PasswordLockout

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LockAction

            Lock = 0
            Unlock = 1

        End Enum
        Public Enum BatchAction

            LockAll = 2
            UnLockAll = 3
            ClearAllPasswords = 4

        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "
        Public Function BatchActions(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                     ByVal Action As BatchAction) As Boolean

            Dim IsLockedOut As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterAction = New System.Data.SqlClient.SqlParameter("@ACTION_ID", SqlDbType.SmallInt)

            SqlParameterUserCode.Value = System.DBNull.Value
            SqlParameterAction.Value = CType(Action, Short)

            IsLockedOut = SecurityDbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_sec_pwd_lock_unlock] @USER_CODE, @ACTION_ID;",
                                                                           SqlParameterUserCode,
                                                                           SqlParameterAction).SingleOrDefault

            Return IsLockedOut

        End Function
        Public Function LockUnlock(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                   ByVal UserCode As String,
                                   ByVal Action As LockAction) As Boolean

            Dim IsLockedOut As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterAction = New System.Data.SqlClient.SqlParameter("@ACTION_ID", SqlDbType.SmallInt)

            SqlParameterUserCode.Value = UserCode
            SqlParameterAction.Value = CType(Action, Short)

            IsLockedOut = SecurityDbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_sec_pwd_lock_unlock] @USER_CODE, @ACTION_ID;",
                                                                           SqlParameterUserCode,
                                                                           SqlParameterAction).SingleOrDefault

            Return IsLockedOut

        End Function
        Public Function IsUserLockedOut(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal UserCode As String,
                                        ByRef ErrorMessage As String) As Boolean

            Dim IsLockedOut As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterUserCode.Value = UserCode

            Try

                IsLockedOut = SecurityDbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_sec_pwd_is_locked_out] @USER_CODE;",
                                                                              SqlParameterUserCode).SingleOrDefault

            Catch ex As Exception

            End Try

            Return IsLockedOut

        End Function
        Public Function ClearByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                        ByVal UserCode As String) As Boolean

            Dim Cleared As Boolean = True
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterUserCode.Value = UserCode

            Try

                SecurityDbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_sec_pwd_lock_clear] @USER_CODE;", SqlParameterUserCode)

            Catch ex As Exception
                Cleared = False
            End Try

            Return Cleared

        End Function
        Public Function LoadByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                       ByVal UserCode As String) As Security.Database.Entities.PasswordLockout

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterUserCode.Value = UserCode

            LoadByUserCode = SecurityDbContext.Database.SqlQuery(Of Security.Database.Entities.PasswordLockout)("EXEC [dbo].[advsp_sec_pwd_lock_load] @USER_CODE;",
                                                                                                                 SqlParameterUserCode).SingleOrDefault

        End Function
        Public Function LogFailureByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                             ByVal UserCode As String) As Integer

            Dim FailedAttempts As Integer = 0
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                SqlParameterUserCode.Value = UserCode

                FailedAttempts = SecurityDbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_sec_pwd_log_failure] @USER_CODE;",
                                                                              SqlParameterUserCode).SingleOrDefault

            Catch ex As Exception
                FailedAttempts = 0
            End Try

            Return FailedAttempts

        End Function
        Public Function LoadResetMinutes(ByVal SecurityDbContext As Database.DbContext) As Integer

            Dim ResetMinutes As Integer = 0

            Try

                ResetMinutes = SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT CAST(COALESCE(A.AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS INT) FROM AGY_SETTINGS A WHERE A.AGY_SETTINGS_CODE = 'PWD_LO_TO';").SingleOrDefault

            Catch ex As Exception
                ResetMinutes = 0
            End Try

            Return ResetMinutes

        End Function

        Public Function AttemptsBeforeLockout(ByVal SecurityDbContext As Database.DbContext) As Integer

            Dim Attempts As Integer = 0

            Try

                Attempts = SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT CAST(COALESCE(A.AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS INT) FROM AGY_SETTINGS A WHERE A.AGY_SETTINGS_CODE = 'PWD_MAX_FAIL';").SingleOrDefault

            Catch ex As Exception
                Attempts = 0
            End Try

            Return Attempts

        End Function
        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.PasswordLockout)

        '    Load = From PasswordLockout In DbContext.GetQuery(Of Database.Entities.PasswordLockout)
        '           Select PasswordLockout

        'End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordLockout As AdvantageFramework.Security.Database.Entities.PasswordLockout) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PasswordLockouts.Add(PasswordLockout)

                ErrorText = PasswordLockout.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordLockout As AdvantageFramework.Security.Database.Entities.PasswordLockout) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PasswordLockout)

                ErrorText = PasswordLockout.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordLockout As AdvantageFramework.Security.Database.Entities.PasswordLockout) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PasswordLockout)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
