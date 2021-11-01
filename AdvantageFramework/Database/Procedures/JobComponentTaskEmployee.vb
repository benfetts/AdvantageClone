Namespace Database.Procedures.JobComponentTaskEmployee

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

        Public Function GetTotalDisbursedHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As Decimal

            GetTotalDisbursedHours = (From JobComponentTaskEmployee In DbContext.JobComponentTaskEmployees
                                      Where JobComponentTaskEmployee.JobNumber = JobNumber AndAlso
                                             JobComponentTaskEmployee.JobComponentNumber = JobComponentNumber AndAlso
                                             JobComponentTaskEmployee.SequenceNumber = SequenceNumber
                                      Select JobComponentTaskEmployee.Hours).Sum

        End Function
        'Public Function LoadByJobCompSeqWithEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTaskEmployee)

        '    LoadByJobCompSeqWithEmployee = From JobComponentTaskEmployee In DbContext.JobComponentTaskEmployees.Include("Employee")
        '                                   Where JobComponentTaskEmployee.JobNumber = JobNumber AndAlso
        '                                   JobComponentTaskEmployee.JobComponentNumber = JobComponentNumber AndAlso
        '                                   JobComponentTaskEmployee.SequenceNumber = SequenceNumber
        '                                   Select JobComponentTaskEmployee

        'End Function


        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As Database.Entities.JobComponentTaskEmployee

            Try

                LoadByID = (From JobComponentTaskEmployee In DbContext.GetQuery(Of Database.Entities.JobComponentTaskEmployee)
                            Where JobComponentTaskEmployee.ID = ID
                            Select JobComponentTaskEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByJobCompSeqEmp(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer, ByVal EmployeeCode As String) As Database.Entities.JobComponentTaskEmployee

            Try

                LoadByJobCompSeqEmp = (From JobComponentTaskEmployee In DbContext.GetQuery(Of Database.Entities.JobComponentTaskEmployee)
                                       Where JobComponentTaskEmployee.JobNumber = JobNumber AndAlso
                                           JobComponentTaskEmployee.JobComponentNumber = JobComponentNumber AndAlso
                                           JobComponentTaskEmployee.SequenceNumber = SequenceNumber AndAlso
                                           JobComponentTaskEmployee.EmployeeCode = EmployeeCode
                                       Select JobComponentTaskEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByJobCompSeqEmp = Nothing
            End Try

        End Function
        Public Function LoadByJobCompSeq(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTaskEmployee)

            LoadByJobCompSeq = From JobComponentTaskEmployee In DbContext.GetQuery(Of Database.Entities.JobComponentTaskEmployee)
                               Where JobComponentTaskEmployee.JobNumber = JobNumber AndAlso
                                     JobComponentTaskEmployee.JobComponentNumber = JobComponentNumber AndAlso
                                     JobComponentTaskEmployee.SequenceNumber = SequenceNumber
                               Select JobComponentTaskEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTaskEmployee)

            Load = From JobComponentTaskEmployee In DbContext.GetQuery(Of Database.Entities.JobComponentTaskEmployee)
                   Select JobComponentTaskEmployee

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobComponentTaskEmployees.Add(JobComponentTaskEmployee)

                ErrorText = JobComponentTaskEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobComponentTaskEmployee)

                ErrorText = JobComponentTaskEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobComponentTaskEmployee)

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
