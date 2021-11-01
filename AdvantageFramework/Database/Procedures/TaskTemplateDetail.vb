Namespace Database.Procedures.TaskTemplateDetail

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

        Private Function UpdateTaskTemplateTotals(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateCode As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

            Try

                TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, TaskTemplateCode)

                If TaskTemplate IsNot Nothing Then

                    TaskTemplate.TotalRushDays = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code)
                    TaskTemplate.TotalStandardDays = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code)

                    Updated = AdvantageFramework.Database.Procedures.TaskTemplate.Update(DbContext, TaskTemplate)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateTaskTemplateTotals = Updated
            End Try

        End Function
        Public Function LoadByTaskTemplateCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.TaskTemplateDetail)

            LoadByTaskTemplateCode = From TaskTemplateDetail In DataContext.TaskTemplateDetails
                                     Where TaskTemplateDetail.TaskTemplateCode = TaskTemplateCode
                                     Select TaskTemplateDetail

        End Function
        Public Function LoadByTaskTemplateDetailID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateDetailID As Long) As AdvantageFramework.Database.Entities.TaskTemplateDetail

            Try

                LoadByTaskTemplateDetailID = (From TaskTemplateDetail In DataContext.TaskTemplateDetails
                                              Where TaskTemplateDetail.ID = TaskTemplateDetailID
                                              Select TaskTemplateDetail).SingleOrDefault

            Catch ex As Exception
                LoadByTaskTemplateDetailID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.TaskTemplateDetail)

            Load = From TaskTemplateDetail In DataContext.TaskTemplateDetails
                   Select TaskTemplateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                TaskTemplateDetail.DataContext = DataContext
                TaskTemplateDetail.DbContext = DbContext

                TaskTemplateDetail.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.TaskTemplateDetails.InsertOnSubmit(TaskTemplateDetail)

                ErrorText = TaskTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

                    Inserted = True

                    UpdateTaskTemplateTotals(DbContext, DataContext, TaskTemplateDetail.TaskTemplateCode)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                TaskTemplateDetail.DataContext = DataContext
                TaskTemplateDetail.DbContext = DbContext

                TaskTemplateDetail.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = TaskTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

                    Updated = True

                    UpdateTaskTemplateTotals(DbContext, DataContext, TaskTemplateDetail.TaskTemplateCode)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.TaskTemplateDetails.DeleteOnSubmit(TaskTemplateDetail)

                    DataContext.SubmitChanges()

                    Deleted = True

                    UpdateTaskTemplateTotals(DbContext, DataContext, TaskTemplateDetail.TaskTemplateCode)

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

