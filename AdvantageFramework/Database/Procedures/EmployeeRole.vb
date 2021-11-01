Namespace Database.Procedures.EmployeeRole

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

        Public Function LoadByEmployeeCodeAndRoleCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal RoleCode As String) As AdvantageFramework.Database.Entities.EmployeeRole

            Try

                LoadByEmployeeCodeAndRoleCode = (From EmployeeRole In DbContext.GetQuery(Of Database.Entities.EmployeeRole)
                                                 Where EmployeeRole.EmployeeCode = EmployeeCode AndAlso
                                                        EmployeeRole.RoleCode = RoleCode
                                                 Select EmployeeRole).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCodeAndRoleCode = Nothing
            End Try

        End Function
        Public Function LoadByRoleCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoleCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeRole)

            LoadByRoleCode = From EmployeeRole In DbContext.GetQuery(Of Database.Entities.EmployeeRole)
                             Where EmployeeRole.RoleCode = RoleCode
                             Select EmployeeRole

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeRole)

            LoadByEmployeeCode = From EmployeeRole In DbContext.GetQuery(Of Database.Entities.EmployeeRole)
                                 Where EmployeeRole.EmployeeCode = EmployeeCode
                                 Select EmployeeRole

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeRole)

            Load = From EmployeeRole In DbContext.GetQuery(Of Database.Entities.EmployeeRole)
                   Select EmployeeRole

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, _
                               ByVal RoleCode As String, _
                               ByRef EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeRole = New AdvantageFramework.Database.Entities.EmployeeRole

                EmployeeRole.DbContext = DbContext
                EmployeeRole.EmployeeCode = EmployeeCode
                EmployeeRole.RoleCode = RoleCode

                Inserted = Insert(DbContext, EmployeeRole)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeRoles.Add(EmployeeRole)

                ErrorText = EmployeeRole.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeRole)

                ErrorText = EmployeeRole.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeRole)

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

