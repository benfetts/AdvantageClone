Namespace Security.Database.Procedures.User

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

        Public Function LoadEmailAddressByUserCode(ByVal DbContext As Database.DbContext,
                                                   ByVal UserCode As String) As String

            Dim EmailAddress As String = String.Empty

            Try

                Dim SQL As String = String.Empty

                SQL = " SELECT TOP 1 
	                        E.EMP_EMAIL
                        FROM 
	                        EMPLOYEE E WITH(NOLOCK) 
	                        INNER JOIN SEC_USER S WITH(NOLOCK) ON E.EMP_CODE = S.EMP_CODE 
                        WHERE 
	                        UPPER(S.USER_CODE) = UPPER('{0}') 
                        ORDER BY 
	                        S.SEC_USER_ID DESC;"

                EmailAddress = DbContext.Database.SqlQuery(Of String)(String.Format(SQL, UserCode)).SingleOrDefault

            Catch ex As Exception
                EmailAddress = String.Empty
            End Try

            Return EmailAddress

        End Function
        Public Function LoadByUserIDs(ByVal DbContext As Database.DbContext, ByVal UserIDs() As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.User)

            LoadByUserIDs = From User In DbContext.Users.AsQueryable
                            Where UserIDs.Contains(User.ID)
                            Select User

        End Function
        Public Sub ChangeUserAdAssistPassword(ByVal DbContext As Database.DbContext, ByVal IsInserting As Boolean, ByVal UserID As Integer, ByVal Password As String, ByRef ReturnValue As Integer)

            'objects
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPassword As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@sec_user_id", SqlDbType.Int)
            SqlParameterPassword = New System.Data.SqlClient.SqlParameter("@pwd_d", SqlDbType.VarChar)
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterReturnValue.Direction = ParameterDirection.Output

            Try

                SqlParameterUserID.Value = UserID
                SqlParameterPassword.Value = Password
                SqlParameterReturnValue.Value = 0

                If IsInserting Then

                    DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_INSERT_SEC_USER_AUTH @sec_user_id, @pwd_d, @ret_val OUTPUT", SqlParameterUserID, SqlParameterPassword, SqlParameterReturnValue)

                Else

                    DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_UPDATE_SEC_USER_AUTH @sec_user_id, @pwd_d, @ret_val OUTPUT", SqlParameterUserID, SqlParameterPassword, SqlParameterReturnValue)

                End If

                ReturnValue = SqlParameterReturnValue.Value

            Catch ex As Exception
                ReturnValue = -2
            End Try

        End Sub
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As Security.Database.Entities.User

            Try

                LoadByUserID = (From User In DbContext.GetQuery(Of Database.Entities.User)
                                Where User.ID = UserID
                                Select User).SingleOrDefault

            Catch ex As Exception
                LoadByUserID = Nothing
            End Try

        End Function
        Public Function LoadByUserName(ByVal DbContext As Database.DbContext, ByVal UserName As String) As Security.Database.Entities.User

            Try

                LoadByUserName = (From User In DbContext.GetQuery(Of Database.Entities.User)
                                  Where User.UserName = UserName
                                  Select User).SingleOrDefault

            Catch ex As Exception
                LoadByUserName = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Security.Database.Entities.User

            Try

                LoadByUserCode = (From User In DbContext.GetQuery(Of Database.Entities.User)
                                  Where User.UserCode.ToUpper = UserCode.ToUpper
                                  Select User).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.User)

            LoadByEmployeeCode = From User In DbContext.Users.AsQueryable
                                 Where User.EmployeeCode = EmployeeCode
                                 Select User

        End Function
        Public Function LoadFirstUserByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As Security.Database.Entities.User

            Try

                LoadFirstUserByEmployeeCode = (From User In DbContext.GetQuery(Of Database.Entities.User)
                                               Where User.EmployeeCode = EmployeeCode
                                               Select User).FirstOrDefault

            Catch ex As Exception
                LoadFirstUserByEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeWithAllOptions(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Security.Database.Entities.User

            Try

                LoadByUserCodeWithAllOptions = (From User In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.User).Include("GroupUsers").Include("GroupUsers.Group").Include("GroupUsers.Group.GroupApplicationAccesses").Include("UserApplicationAccesses")
                                                Where User.UserCode.ToUpper = UserCode.ToUpper
                                                Select User).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeWithAllOptions = Nothing
            End Try

        End Function
        Public Function LoadWithAllOptions(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.User)

            LoadWithAllOptions = From User In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.User).Include("GroupUsers").Include("GroupUsers.Group").Include("GroupUsers.Group.GroupApplicationAccesses").Include("UserApplicationAccesses")
                                 Select User

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.User)

            Load = From User In DbContext.GetQuery(Of Database.Entities.User)
                   Select User

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String,
                               ByVal EmployeeCode As String, ByVal UserName As String,
                               ByVal CheckForUserAccess As Boolean,
                               SID As String,
                               ByRef User As AdvantageFramework.Security.Database.Entities.User) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                User = New AdvantageFramework.Security.Database.Entities.User

                User.DbContext = DbContext
                User.UserCode = UserCode
                User.EmployeeCode = EmployeeCode
                User.UserName = UserName
                User.CheckForUserAccess = CheckForUserAccess
                User.Password = String.Empty
                User.SID = SID

                Inserted = Insert(DbContext, User)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal User As AdvantageFramework.Security.Database.Entities.User) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Application As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Entities.Module = Nothing
            Dim SecuritySettingAttribute As AdvantageFramework.Security.Attributes.SecuritySettingAttribute = Nothing

            Try

                DbContext.Users.Add(User)

                ErrorText = User.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    'Try

                    '    If DbContext.Database.SqlQuery(Of String)(String.Format("SELECT USER_CODE FROM dbo.U_APP_SECURITY WHERE USER_CODE = '{0}'", User.UserCode)).Any = False Then

                    '        IsValid = DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[U_APP_SECURITY]([USER_CODE], [EMP_CODE], [USER_NAME]) " & _
                    '                                                                  "VALUES ('{0}', '{1}', '{2}')", User.UserCode, User.EmployeeCode, User.Employee.ToString)) > 0

                    '    Else

                    '        IsValid = True

                    '    End If

                    'Catch ex As Exception
                    '    IsValid = False
                    'End Try

                    If IsValid Then

                        Inserted = True

                        For Each Application In AdvantageFramework.Security.Database.Procedures.Application.Load(DbContext).ToList

                            AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.Insert(DbContext, User.ID, Application.ID, False, True, True, True, False, False, Nothing)

                        Next

                        DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_USER_MODACCESS([SEC_MODULE_ID], [SEC_USER_ID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " &
                                                             "SELECT [SEC_MODULE_ID], " & User.ID & ", 0, 1, 1, 1, 0, 0 FROM dbo.SEC_MODULE")

                        For Each Setting In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Security.UserSettings), False)

                            Try

                                SecuritySettingAttribute = System.Attribute.GetCustomAttribute(GetType(AdvantageFramework.Security.UserSettings).GetField(Setting), GetType(AdvantageFramework.Security.Attributes.SecuritySettingAttribute))

                            Catch ex As Exception
                                SecuritySettingAttribute = Nothing
                            End Try

                            If SecuritySettingAttribute IsNot Nothing Then

                                If SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, Nothing, SecuritySettingAttribute.DefaultValue, Nothing, Nothing)

                                ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then


                                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, Nothing, Nothing, SecuritySettingAttribute.DefaultValue, Nothing)

                                Else

                                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, SecuritySettingAttribute.DefaultValue, Nothing, Nothing, Nothing)

                                End If

                            Else

                                AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, Nothing, Nothing, Nothing, Nothing)

                            End If

                        Next

                        'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(DbContext, User.UserName, IsAdvantageAdmin, False)

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_USER_UDRACCESS]([SEC_USER_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " &
                                                                            "SELECT {0}, [USER_DEF_REPORT_ID], 1 FROM [dbo].[USER_DEF_REPORT]", User.ID))

                        Catch ex As Exception

                        End Try

                    Else

                        ErrorText = "Failed to create user in legacy security."

                        Try

                            DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER WHERE SEC_USER_ID = " & User.ID)

                        Catch ex As Exception

                        End Try

                    End If

                End If

                If Inserted = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal User As AdvantageFramework.Security.Database.Entities.User) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(User)

                ErrorText = User.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal User As AdvantageFramework.Security.Database.Entities.User) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Try

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.GroupUser.DeleteByUserID(DbContext, User.ID) Then

                        If AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.DeleteByUserID(DbContext, User.ID) Then

                            If AdvantageFramework.Security.Database.Procedures.UserModuleAccess.DeleteByUserID(DbContext, User.ID) Then

                                If AdvantageFramework.Security.Database.Procedures.UserSetting.DeleteByUserID(DbContext, User.ID) Then

                                    DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_DELETE_SEC_USER_AUTH " & User.ID & ", 0")

                                    If AdvantageFramework.Security.Database.Procedures.UserWorkspace.DeleteByUserCode(DbContext, User.UserCode) Then

                                        If AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.DeleteByUserID(DbContext, User.ID) Then

                                            AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.DeleteByUserCode(DbContext, User.UserCode)

                                            AdvantageFramework.Security.Database.Procedures.UserMenu.DeleteByUserID(DbContext, User.ID)

                                            AdvantageFramework.Security.Database.Procedures.UserMenuTab.DeleteByUserID(DbContext, User.ID)

                                            Try

                                                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_CLIENT WHERE [USER_ID] = '" & User.UserCode & "'")

                                            Catch ex As Exception

                                            End Try

                                            Try

                                                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_REPORTS WHERE [USER_ID] = '" & User.UserCode & "'")

                                            Catch ex As Exception

                                            End Try


                                            Try

                                                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_PWD_LOCK WHERE [USER_CODE] = '" & User.UserCode & "'")

                                            Catch ex As Exception

                                            End Try
                                            'If DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.U_APP_SECURITY WHERE USER_CODE = '" & User.UserCode & "'") > 0 Then

                                            'AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.DeleteDatabaseSQLUser(DbContext, User.UserName)

                                            DbContext.DeleteEntityObject(User)

                                            DbContext.SaveChanges()

                                            Deleted = True

                                            'End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

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
