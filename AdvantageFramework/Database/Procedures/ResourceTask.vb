Namespace Database.Procedures.ResourceTask

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ResourceTask)

            Load = From ResourceTask In DbContext.GetQuery(Of Database.Entities.ResourceTask)
                   Select ResourceTask

        End Function
        Public Function LoadByResourceCode(ByVal DbContext As Database.DbContext, ByVal ResourceCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ResourceTask)

            LoadByResourceCode = From ResourceTask In DbContext.GetQuery(Of Database.Entities.ResourceTask)
                                 Where (ResourceTask.ResourceCode = ResourceCode)
                                 Select ResourceTask

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ResourceTask As AdvantageFramework.Database.Entities.ResourceTask) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ResourceTasks.Add(ResourceTask)

                ErrorText = ResourceTask.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ResourceTask As AdvantageFramework.Database.Entities.ResourceTask) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ResourceTask)

                ErrorText = ResourceTask.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ResourceTask As AdvantageFramework.Database.Entities.ResourceTask) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DeleteEntityObject(ResourceTask)

                DbContext.SaveChanges()

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByResourceCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ResourceCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.RESOURCE_TASKS WHERE [RESOURCE_CODE] = '" & ResourceCode & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByResourceCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
