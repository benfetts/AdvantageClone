Namespace Database.Procedures.JobComponentTask

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

        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTask)

            LoadByEmployeeCode = From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask)
                                 Where JobComponentTask.EmployeeCode = EmployeeCode
                                 Select JobComponentTask

        End Function
        Public Function LoadByJobNumberAndJobComponentNumberComplete(ByVal DbContext As Database.DbContext,
                                                                     ByVal JobNumber As Integer,
                                                                     ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTask)

            Try

                LoadByJobNumberAndJobComponentNumberComplete = (From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask).Include("Phase")
                                                                Where JobComponentTask.JobNumber = JobNumber AndAlso
                                                                      JobComponentTask.JobComponentNumber = JobComponentNumber
                                                                Select JobComponentTask)

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumberComplete = Nothing
            End Try

        End Function

        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTask)

            Try

                LoadByJobNumberAndJobComponentNumber = (From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask)
                                                        Where JobComponentTask.JobNumber = JobNumber AndAlso
                                                                               JobComponentTask.JobComponentNumber = JobComponentNumber
                                                        Select JobComponentTask)

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function
        Public Function LoadByJobNumberAndJobComponentNumberAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.JobComponentTask

            Try

                LoadByJobNumberAndJobComponentNumberAndSequenceNumber = (From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask)
                                                                         Where JobComponentTask.JobNumber = JobNumber AndAlso
                                                                               JobComponentTask.JobComponentNumber = JobComponentNumber AndAlso
                                                                               JobComponentTask.SequenceNumber = SequenceNumber
                                                                         Select JobComponentTask).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumberAndSequenceNumber = Nothing
            End Try

        End Function
        Public Function LoadByJobComponentTaskID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskID As Long) As AdvantageFramework.Database.Entities.JobComponentTask

            Try

                LoadByJobComponentTaskID = (From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask)
                                            Where JobComponentTask.ID = JobComponentTaskID
                                            Select JobComponentTask).SingleOrDefault

            Catch ex As Exception
                LoadByJobComponentTaskID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTask)

            Load = From JobComponentTask In DbContext.GetQuery(Of Database.Entities.JobComponentTask)
                   Select JobComponentTask

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SequenceNumber As Integer = Nothing

            Try

                Try

                    SequenceNumber = (From Entity In Load(DbContext)
                                      Where Entity.JobNumber = JobComponentTask.JobNumber AndAlso
                                            Entity.JobComponentNumber = JobComponentTask.JobComponentNumber
                                      Select [SN] = Entity.SequenceNumber).Max + 1

                Catch ex As Exception
                    SequenceNumber = 0
                End Try

                Try

                    If String.IsNullOrWhiteSpace(JobComponentTask.OriginalDueTime) = True AndAlso String.IsNullOrWhiteSpace(JobComponentTask.DueTime = False) Then

                        JobComponentTask.OriginalDueTime = JobComponentTask.DueTime

                    End If

                Catch ex As Exception
                End Try

                JobComponentTask.SequenceNumber = SequenceNumber

                DbContext.JobComponentTasks.Add(JobComponentTask)

                ErrorText = JobComponentTask.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    CreateWorkItemAlert(DbContext, JobComponentTask)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'Employee Code is a Calculated Field. If more than one employee is assigned to a task, the calculated field returns "..." 
                'and causes an error when updating because of the association between JobComponentTask & Employee. 
                'Setting EmployeeCode to nothing does not delete the employees.

                JobComponentTask.EmployeeCode = Nothing

                DbContext.UpdateObject(JobComponentTask)

                ErrorText = JobComponentTask.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask) As Boolean

            Delete = Delete(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber)

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_project_schedule_delete_task] {0}, {1}, {2};",
                                                                           JobNumber, JobComponentNumber, SequenceNumber))

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function CreateWorkItemAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SequenceNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Created As Boolean = False

            Try

                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("JobNumber", JobNumber)
                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("JobComponentNumber", JobComponentNumber)
                SequenceNumberSqlParameter = New System.Data.SqlClient.SqlParameter("SequenceNumber", SequenceNumber)
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("UserCode", DbContext.UserCode)

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.[advsp_agile_add_assignment_from_task] @JobNumber, @JobComponentNumber, @SequenceNumber, @UserCode", JobNumberSqlParameter, JobComponentNumberSqlParameter, SequenceNumberSqlParameter, UserCodeSqlParameter)

                Created = True

            Catch ex As Exception
                Created = False
            End Try

            CreateWorkItemAlert = Created

        End Function
        Public Function CreateWorkItemAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask) As Boolean

            CreateWorkItemAlert = CreateWorkItemAlert(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber)

        End Function



#End Region

    End Module

End Namespace
