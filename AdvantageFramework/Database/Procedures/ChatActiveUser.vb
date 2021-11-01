Namespace Database.Procedures.ChatActiveUser

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

        Public Function LoadActiveContextUserIdentityNameDoNotDisturb(ByVal DbContext As AdvantageFramework.Database.DbContext) As List(Of String)

            LoadActiveContextUserIdentityNameDoNotDisturb = (From ChatActiveUser In DbContext.ChatActiveUsers
                                                             Where ChatActiveUser.DoNotDisturb = False
                                                             Select ChatActiveUser.ContextUserIdentityName).ToList

        End Function
        Public Function LoadActiveByChatRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            LoadActiveByChatRoomID = (From ChatActiveUser In DbContext.ChatActiveUsers
                                      Join ChatUser In DbContext.ChatUsers On ChatUser.UserCode Equals ChatActiveUser.UserCode
                                      Where ChatUser.ChatRoomID = ChatRoomID AndAlso ChatActiveUser.DoNotDisturb = False
                                      Select ChatActiveUser)

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As AdvantageFramework.Database.Entities.ChatActiveUser

            LoadByUserCode = (From ChatActiveUser In DbContext.ChatActiveUsers
                              Where ChatActiveUser.UserCode.ToUpper = UserCode.ToUpper
                              Order By ChatActiveUser.ID Descending
                              Select ChatActiveUser).FirstOrDefault

        End Function
        Public Function LoadDoNotDisturb(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            LoadDoNotDisturb = (From ChatActiveUser In DbContext.ChatActiveUsers
                                Where ChatActiveUser.DoNotDisturb = False
                                Select ChatActiveUser)

        End Function
        Public Function LoadByDepartmentTeamCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ThisUserCode As String, ByVal ThisEmployeeCode As String,
                                                 ByVal DepartmentTeamCode As String,
                                                 ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            Dim DepartmentTeamEmployeeCodes As List(Of String)

            DepartmentTeamEmployeeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DISTINCT A.EMP_CODE FROM (SELECT EMP_CODE FROM EMP_DP_TM WITH(NOLOCK) WHERE DP_TM_CODE = '{0}' UNION SELECT EMP_CODE FROM EMPLOYEE WITH(NOLOCK) WHERE DP_TM_CODE = '{0}') AS A;", DepartmentTeamCode)).ToList

            'If DepartmentTeamEmployeeCodes Is Nothing OrElse DepartmentTeamEmployeeCodes.Count = 0 Then

            '    LoadByDepartmentTeamCode = Load(DbContext, ThisUserCode, ThisEmployeeCode, DbContext, SecurityDbContext)

            'Else

            LoadByDepartmentTeamCode = (From ChatActiveUser In Load(DbContext, ThisUserCode, ThisEmployeeCode, SecurityDbContext)
                                        Where DepartmentTeamEmployeeCodes.Contains(ChatActiveUser.EmployeeCode))

            'End If

        End Function

        Private _ActiveEmployeeCodesByUserOffice As System.Collections.Generic.List(Of String) = Nothing
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ThisUserCode As String, ByVal ThisEmployeeCode As String,
                             ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            Try

                If _ActiveEmployeeCodesByUserOffice Is Nothing Then

                    _ActiveEmployeeCodesByUserOffice = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeeCodesByUserOffice(DbContext, ThisEmployeeCode)

                End If

            Catch ex As Exception
                _ActiveEmployeeCodesByUserOffice = Nothing
            End Try

            If _ActiveEmployeeCodesByUserOffice IsNot Nothing AndAlso _ActiveEmployeeCodesByUserOffice.Count > 0 Then

                Dim UserEmployeeAccesses As String() = Nothing
                UserEmployeeAccesses = (From EmployeeCode In _ActiveEmployeeCodesByUserOffice
                                        Select EmployeeCode).ToArray

                Load = (From ChatActiveUser In DbContext.ChatActiveUsers
                        Where ChatActiveUser.DoNotDisturb = False AndAlso UserEmployeeAccesses.Contains(ChatActiveUser.EmployeeCode)
                        Select ChatActiveUser)

            Else

                Load = (From ChatActiveUser In DbContext.ChatActiveUsers
                        Where ChatActiveUser.DoNotDisturb = False
                        Select ChatActiveUser)

            End If

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            Load = (From ChatActiveUser In DbContext.ChatActiveUsers
                    Select ChatActiveUser)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ChatActiveUsers.Add(ChatActiveUser)

                ErrorMessage = ChatActiveUser.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CHAT_ACTIVE_USER WITH(ROWLOCK) WHERE UPPER(USER_CODE) = '{0}';", ChatActiveUser.UserCode.ToUpper))

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message.ToString()

                End If

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(ChatActiveUser).State = Entity.EntityState.Modified

                ErrorMessage = ChatActiveUser.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CHAT_ACTIVE_USER WITH(ROWLOCK) WHERE UPPER(USER_CODE) = '{0}';", ChatActiveUser.UserCode.ToUpper))

                'If IsValid Then

                '    DbContext.Entry(ChatActiveUser).State = Entity.EntityState.Deleted

                '    DbContext.SaveChanges()

                '    Deleted = True

                'Else

                '    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                'End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace