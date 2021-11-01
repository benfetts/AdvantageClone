Namespace Database.Procedures.Resource

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Resource)

            Load = From Resource In DbContext.GetQuery(Of Database.Entities.Resource)
                   Select Resource

        End Function
        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As AdvantageFramework.Database.Entities.Resource

            LoadByCode = (From Resource In DbContext.GetQuery(Of Database.Entities.Resource)
                          Where Resource.Code = Code
                          Select Resource).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Resource As AdvantageFramework.Database.Entities.Resource) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Resources.Add(Resource)

                ErrorText = Resource.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Resource As AdvantageFramework.Database.Entities.Resource) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Resource)

                ErrorText = Resource.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Resource As AdvantageFramework.Database.Entities.Resource) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.ResourceTask.DeleteByResourceCode(DbContext, Resource.Code) = False Then

                    ErrorText = "Failed deleting all resource tasks."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Resource)

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
