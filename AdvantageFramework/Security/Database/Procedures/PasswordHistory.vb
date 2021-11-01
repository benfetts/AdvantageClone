Imports AdvantageFramework.Database.Views

Namespace Security.Database.Procedures.PasswordHistory

    <HideModuleName()>
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
        Public Function ValidatePasswordHistory(ByVal SecurityDbContext As Database.DbContext,
                                                ByVal UserCode As String,
                                                ByVal EncryptedPassword As String) As Boolean

            Dim PasswordHistoryIsValid As Boolean = True
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEncryptedPassword As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterEncryptedPassword = New System.Data.SqlClient.SqlParameter("@ENCRYPTED_PWD", SqlDbType.VarChar)

            SqlParameterUserCode.Value = UserCode
            SqlParameterEncryptedPassword.Value = EncryptedPassword

            Try

                PasswordHistoryIsValid = SecurityDbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_sec_pwd_validate_history] @USER_CODE, @ENCRYPTED_PWD;",
                                                                                          SqlParameterUserCode,
                                                                                          SqlParameterEncryptedPassword).SingleOrDefault

            Catch ex As Exception
                PasswordHistoryIsValid = True
            End Try

            Return PasswordHistoryIsValid

        End Function

        Public Function LoadLatestByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                             ByVal UserCode As String) As AdvantageFramework.Security.Database.Entities.PasswordHistory

            Dim PasswordHistoryID As Integer = 0
            Dim PasswordHistoryEntity As AdvantageFramework.Security.Database.Entities.PasswordHistory = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterUserCode.Value = UserCode

            Try

                PasswordHistoryID = SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT MAX(ID) FROM SEC_PWD_HIST S WITH(NOLOCK) WHERE USER_CODE = @USER_CODE;",
                                                                                     SqlParameterUserCode).SingleOrDefault

            Catch ex As Exception
                PasswordHistoryID = 0
            End Try
            If PasswordHistoryID > 0 Then

                PasswordHistoryEntity = (From PasswordHistory In SecurityDbContext.GetQuery(Of Database.Entities.PasswordHistory)
                                         Where PasswordHistory.ID = PasswordHistoryID
                                         Select PasswordHistory).SingleOrDefault

            End If

            Return PasswordHistoryEntity

        End Function
        Public Function LoadCountByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                            ByVal UserCode As String) As Integer

            Dim i As Integer = 0
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            SqlParameterUserCode.Value = UserCode

            i = SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(1) FROM SEC_PWD_HIST WITH(NOLOCK) WHERE USER_CODE = @USER_CODE;",
                                                                 SqlParameterUserCode).SingleOrDefault

            Return i

        End Function
        Public Function LoadByUserCode(ByVal SecurityDbContext As Database.DbContext,
                                       ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.PasswordHistory)

            LoadByUserCode = From PasswordHistory In SecurityDbContext.GetQuery(Of Database.Entities.PasswordHistory)
                             Where PasswordHistory.UserCode = UserCode
                             Order By PasswordHistory.UserCode Descending
                             Select PasswordHistory

        End Function

        Public Function Load(ByVal SecurityDbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.PasswordHistory)

            Load = From PasswordHistory In SecurityDbContext.GetQuery(Of Database.Entities.PasswordHistory)
                   Select PasswordHistory

        End Function
        Public Function Insert(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordHistory As AdvantageFramework.Security.Database.Entities.PasswordHistory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                SecurityDbContext.PasswordHistories.Add(PasswordHistory)

                ErrorText = PasswordHistory.ValidateEntity(IsValid)

                If IsValid Then

                    SecurityDbContext.SaveChanges()

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
        Public Function Update(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordHistory As AdvantageFramework.Security.Database.Entities.PasswordHistory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                SecurityDbContext.UpdateObject(PasswordHistory)

                ErrorText = PasswordHistory.ValidateEntity(IsValid)

                If IsValid Then

                    SecurityDbContext.SaveChanges()

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
        Public Function Delete(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                               ByVal PasswordHistory As AdvantageFramework.Security.Database.Entities.PasswordHistory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    SecurityDbContext.DeleteEntityObject(PasswordHistory)

                    SecurityDbContext.SaveChanges()

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
