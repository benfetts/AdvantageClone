Namespace Database.Procedures.JobType

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

        Public Function LoadByJobTypeCode(ByVal DbContext As Database.DbContext, ByVal JobTypeCode As String) As Database.Entities.JobType

            Try

                LoadByJobTypeCode = (From JobType In DbContext.GetQuery(Of Database.Entities.JobType)
                                     Where JobType.Code = JobTypeCode
                                     Select JobType).SingleOrDefault

            Catch ex As Exception
                LoadByJobTypeCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobType)

            LoadAllActive = From JobType In DbContext.GetQuery(Of Database.Entities.JobType)
                            Where JobType.IsInactive Is Nothing OrElse
                                  JobType.IsInactive = 0
                            Select JobType

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobType)

            Load = From JobType In DbContext.GetQuery(Of Database.Entities.JobType)
                   Select JobType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobType As AdvantageFramework.Database.Entities.JobType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTypes.Add(JobType)

                ErrorText = JobType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobType As AdvantageFramework.Database.Entities.JobType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobType)

                ErrorText = JobType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobType As AdvantageFramework.Database.Entities.JobType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.JobComponent.LoadByJobTypeCode(DbContext, JobType.Code).Any Then

                    IsValid = False
                    ErrorText = "Job Type Code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(JobType)

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
