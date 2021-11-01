Namespace Database.Procedures.Role

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

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Role)

            LoadAllActive = From Role In DbContext.GetQuery(Of Database.Entities.Role)
                            Where Role.IsInactive = 0
                            Select Role

        End Function
        Public Function LoadByRoleCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoleCode As String) As AdvantageFramework.Database.Entities.Role

            Try

                LoadByRoleCode = (From Role In DbContext.GetQuery(Of Database.Entities.Role)
                                  Where Role.Code = RoleCode
                                  Select Role).SingleOrDefault

            Catch ex As Exception
                LoadByRoleCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Role)

            Load = From Role In DbContext.GetQuery(Of Database.Entities.Role)
                   Select Role

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Role As AdvantageFramework.Database.Entities.Role) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Roles.Add(Role)

                ErrorText = Role.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Role As AdvantageFramework.Database.Entities.Role) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Role)

                ErrorText = Role.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Role As AdvantageFramework.Database.Entities.Role) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing
            Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

            Try

                If DbContext.Employees.Any(Function(Emp) Emp.RoleCode = Role.Code) Then

                    ErrorText = "The role is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    If DbContext.JobComponentTasks.Any(Function(CompTask) CompTask.RoleCode = Role.Code) Then

                        ErrorText = "The role is in use and cannot be deleted."
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.Task)
                        Where Entity.RoleCode = Role.Code
                        Select Entity).Any Then

                        ErrorText = "The role is in use and cannot be deleted."
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If (From Entity In DataContext.TaskTemplateDetails _
                           Where Entity.RoleCode = Role.Code _
                           Select Entity).Any Then

                        ErrorText = "The role is in use and cannot be deleted."
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    For Each EmployeeRole In AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, Role.Code)

                        AdvantageFramework.Database.Procedures.EmployeeRole.Delete(DbContext, EmployeeRole)

                    Next

                    For Each TaskRole In AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, Role.Code)

                        AdvantageFramework.Database.Procedures.TaskRole.Delete(DataContext, TaskRole)

                    Next

                    DbContext.DeleteEntityObject(Role)

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

