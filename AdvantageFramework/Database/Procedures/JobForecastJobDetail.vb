Namespace Database.Procedures.JobForecastJobDetail

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)()

        End Function
        Public Function LoadByJobForecastJobID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)

            LoadByJobForecastJobID = From Item In DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)()
                                     Where Item.JobForecastJobID = JobForecastJobID
                                     Select Item

        End Function
        Public Function LoadByJobForecastRevisionID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevisionID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)

            LoadByJobForecastRevisionID = From Item In DbContext.Set(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)()
                                          Where Item.JobForecastRevisionID = JobForecastRevisionID
                                          Select Item

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobForecastJobDetails.Add(JobForecastJobDetail)

                ErrorText = JobForecastJobDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(JobForecastJobDetail).State = Entity.EntityState.Modified

                ErrorText = JobForecastJobDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(JobForecastJobDetail).State = Entity.EntityState.Deleted

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
