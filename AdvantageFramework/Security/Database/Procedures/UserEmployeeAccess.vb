Namespace Security.Database.Procedures.UserEmployeeAccess

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

        Public Function LoadByUserCodeAndEmployeeCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String) As Security.Database.Entities.UserEmployeeAccess

            Try

                LoadByUserCodeAndEmployeeCode = (From UserEmployeeAccess In DbContext.GetQuery(Of Database.Entities.UserEmployeeAccess)
                                                 Where UserEmployeeAccess.UserCode = UserCode AndAlso
                                                       UserEmployeeAccess.EmployeeCode = EmployeeCode
                                                 Select UserEmployeeAccess).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserEmployeeAccess)

            LoadByUserCode = From UserEmployeeAccess In DbContext.GetQuery(Of Database.Entities.UserEmployeeAccess)
                             Where UserEmployeeAccess.UserCode = UserCode
                             Select UserEmployeeAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserEmployeeAccess)

            Load = From UserEmployeeAccess In DbContext.GetQuery(Of Database.Entities.UserEmployeeAccess)
                   Select UserEmployeeAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, _
                               ByVal EmployeeCode As String, _
                               ByRef UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserEmployeeAccess = New AdvantageFramework.Security.Database.Entities.UserEmployeeAccess

                UserEmployeeAccess.DbContext = DbContext
                UserEmployeeAccess.UserCode = UserCode
                UserEmployeeAccess.EmployeeCode = EmployeeCode

                Inserted = Insert(DbContext, UserEmployeeAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserEmployeeAccesses.Add(UserEmployeeAccess)

                ErrorText = UserEmployeeAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserEmployeeAccess)

                ErrorText = UserEmployeeAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserEmployeeAccess)

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
        Public Function DeleteByUserCode(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_EMP WHERE [USER_ID] = '" & UserCode & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
