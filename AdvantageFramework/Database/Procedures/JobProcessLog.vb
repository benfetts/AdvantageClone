Namespace Database.Procedures.JobProcessLog

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobProcessLog)

            Load = From JobProcessLog In DbContext.GetQuery(Of Database.Entities.JobProcessLog)
                   Select JobProcessLog

        End Function
        Public Function LoadByJobComponent(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobProcessLog)

            LoadByJobComponent = From JobProcessLog In DbContext.GetQuery(Of Database.Entities.JobProcessLog)
                                 Where JobProcessLog.JobNumber = JobNumber AndAlso
                                        JobProcessLog.JobComponentNumber = JobComponentNumber
                                 Select JobProcessLog

        End Function
        Public Function LoadLatestByJobComponent(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Database.Entities.JobProcessLog

            LoadLatestByJobComponent = (From JobProcessLog In LoadByJobComponent(DbContext, JobNumber, JobComponentNumber)
                                        Order By JobProcessLog.ProcessedDate Descending, JobProcessLog.ID Descending
                                        Select JobProcessLog).FirstOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobProcessLog As AdvantageFramework.Database.Entities.JobProcessLog) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobProcessLogs.Add(JobProcessLog)

                ErrorText = JobProcessLog.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
