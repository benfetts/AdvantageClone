Namespace Database.Procedures.JobForecastRevision

    <HideModuleName()>
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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobForecastRevision)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastRevision)()

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.JobForecastRevision

            LoadByID = (From Item In DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastRevision).Include("JobForecast")
                        Where Item.ID = ID
                        Select Item).SingleOrDefault

        End Function
        Public Function LoadByJobForecastID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobForecastRevision)

            LoadByJobForecastID = From Item In DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastRevision)()
                                  Where Item.JobForecastID = JobForecastID
                                  Select Item

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    JobForecastRevision.RevisionNumber = DbContext.Database.SqlQuery(Of Integer)([String].Format("SELECT [NEXT_REV_NBR] = ISNULL(MAX(REV_NBR), -1) + 1 FROM dbo.JF_REV WHERE JF_ID = {0}", JobForecastRevision.JobForecastID)).SingleOrDefault

                Catch ex As Exception
                    JobForecastRevision.RevisionNumber = 0
                End Try

                DbContext.JobForecastRevisions.Add(JobForecastRevision)

                ErrorText = JobForecastRevision.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(JobForecastRevision).State = Entity.EntityState.Modified

                ErrorText = JobForecastRevision.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(JobForecastRevision).State = Entity.EntityState.Deleted

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
