Namespace Database.Procedures.Task

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

        Public Function IsInUse(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskCode As String) As Boolean

            IsInUse = (From TaskTemplateDetail In DataContext.TaskTemplateDetails _
                       Where TaskTemplateDetail.TaskCode = TaskCode _
                       Select TaskTemplateDetail).Any

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Task)

            LoadAllActive = From Task In DbContext.GetQuery(Of Database.Entities.Task)
                            Where Task.IsInactive Is Nothing OrElse
                                  Task.IsInactive = 0
                            Select Task

        End Function
        Public Function LoadByTaskCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskCode As String) As AdvantageFramework.Database.Entities.Task

            Try

                LoadByTaskCode = (From Task In DbContext.GetQuery(Of Database.Entities.Task)
                                  Where Task.Code = TaskCode
                                  Select Task).SingleOrDefault

            Catch ex As Exception
                LoadByTaskCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Task)

            Load = From Task In DbContext.GetQuery(Of Database.Entities.Task)
                   Select Task

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Task As AdvantageFramework.Database.Entities.Task) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Tasks.Add(Task)

                ErrorText = Task.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Task As AdvantageFramework.Database.Entities.Task) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Task)

                ErrorText = Task.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Task As AdvantageFramework.Database.Entities.Task) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.Task.IsInUse(DataContext, Task.Code) = True OrElse
                       AdvantageFramework.Database.Procedures.TaskRole.LoadByTaskCode(DataContext, Task.Code).Count > 0 Then

                    ErrorText = "The task is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Task)

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

