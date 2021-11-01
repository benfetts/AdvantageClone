Namespace Database.Procedures.TaskRole

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

        Public Function LoadByTaskCodeAndRoleCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskCode As String, ByVal RoleCode As String) As AdvantageFramework.Database.Entities.TaskRole

            Try

                LoadByTaskCodeAndRoleCode = (From TaskRole In DataContext.TaskRoles _
                                             Where TaskRole.TaskCode = TaskCode AndAlso _
                                                    TaskRole.RoleCode = RoleCode _
                                             Select TaskRole).SingleOrDefault

            Catch ex As Exception
                LoadByTaskCodeAndRoleCode = Nothing
            End Try

        End Function
        Public Function LoadByRoleCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RoleCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.TaskRole)

            LoadByRoleCode = From TaskRole In DataContext.TaskRoles
                             Where TaskRole.RoleCode = RoleCode
                             Select TaskRole

        End Function
        Public Function LoadByTaskCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.TaskRole)

            LoadByTaskCode = From TaskRole In DataContext.TaskRoles
                             Where TaskRole.TaskCode = TaskCode
                             Select TaskRole

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.TaskRole)

            Load = From TaskRole In DataContext.TaskRoles
                   Select TaskRole

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal DbContext As Database.DbContext, ByVal TaskCode As String, _
                               ByVal RoleCode As String, _
                               ByRef TaskRole As AdvantageFramework.Database.Entities.TaskRole) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                TaskRole = New AdvantageFramework.Database.Entities.TaskRole

                TaskRole.TaskCode = TaskCode
                TaskRole.RoleCode = RoleCode

                Inserted = Insert(DataContext, DbContext, TaskRole)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskRole As AdvantageFramework.Database.Entities.TaskRole) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                TaskRole.DataContext = DataContext
                TaskRole.DbContext = DbContext

                TaskRole.DatabaseAction = AdvantageFramework.Database.Action.Inserting
                
                DataContext.TaskRoles.InsertOnSubmit(TaskRole)

                ErrorText = TaskRole.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskRole As AdvantageFramework.Database.Entities.TaskRole) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                TaskRole.DataContext = DataContext
                TaskRole.DbContext = DbContext

                TaskRole.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = TaskRole.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskRole As AdvantageFramework.Database.Entities.TaskRole) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then
                    
                    DataContext.TaskRoles.DeleteOnSubmit(TaskRole)

                    DataContext.SubmitChanges()

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

