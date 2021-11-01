Namespace Database.Procedures.TaskTemplate

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

        Public Function LoadTotalStandardDaysByTaskTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateCode As String) As Long

            Try

                LoadTotalStandardDaysByTaskTemplateCode = (From TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, TaskTemplateCode) _
                                                           Where TaskTemplateDetail.TaskTemplateCode = TaskTemplateCode _
                                                           Group TaskTemplateDetail By TaskTemplateDetail.ProcessOrderNumber Into TaskTemplateDetails = Group _
                                                           Select TaskTemplateDetails.Max(Function(Entity) Entity.DaysToComplete.GetValueOrDefault(0))).Sum

            Catch ex As Exception
                LoadTotalStandardDaysByTaskTemplateCode = 0
            End Try

        End Function
        Public Function LoadTotalRushDaysByTaskTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateCode As String) As Long

            Try

                LoadTotalRushDaysByTaskTemplateCode = (From TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, TaskTemplateCode) _
                                                       Where TaskTemplateDetail.TaskTemplateCode = TaskTemplateCode _
                                                       Group TaskTemplateDetail By TaskTemplateDetail.ProcessOrderNumber Into TaskTemplateDetails = Group _
                                                       Select TaskTemplateDetails.Max(Function(Entity) Entity.RushDaysToComplete.GetValueOrDefault(0))).Sum

            Catch ex As Exception
                LoadTotalRushDaysByTaskTemplateCode = 0
            End Try

        End Function
        Public Function LoadByTaskTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskTemplateCode As String) As AdvantageFramework.Database.Entities.TaskTemplate

            Try

                LoadByTaskTemplateCode = (From TaskTemplate In DbContext.GetQuery(Of Database.Entities.TaskTemplate)
                                          Where TaskTemplate.Code = TaskTemplateCode
                                          Select TaskTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByTaskTemplateCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TaskTemplate)

            Load = From TaskTemplate In DbContext.GetQuery(Of Database.Entities.TaskTemplate)
                   Select TaskTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                TaskTemplate.DbContext = DbContext

                If TaskTemplate.IsEntityBeingAdded() = True Then

                    DbContext.TaskTemplates.Add(TaskTemplate)

                    ErrorText = TaskTemplate.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                    End If

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(TaskTemplate)

                ErrorText = TaskTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

            Try


                Try

                    For Each TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, TaskTemplate.Code)

                        DataContext.TaskTemplateDetails.DeleteOnSubmit(TaskTemplateDetail)

                    Next

                    DataContext.SubmitChanges()

                Catch ex As Exception
                    IsValid = False
                    ErrorText = "Failed deleting task template details."
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(TaskTemplate)

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

