Namespace Database.Procedures.JobTrafficPredecessors

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficPredecessors)

            Load = From JobTrafficPredecessors In DbContext.JobTrafficPredecessor
                   Select JobTrafficPredecessors

        End Function

        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficPredecessors)

            Try

                LoadByJobNumberAndJobComponentNumber = From JobTrafficPredecessors In DbContext.JobTrafficPredecessor
                                                       Where JobTrafficPredecessors.JobNumber = JobNumber AndAlso
                                                              JobTrafficPredecessors.JobComponentNumber = JobComponentNumber
                                                       Select JobTrafficPredecessors

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function

        Public Function LoadByJobNumberAndJobComponentNumberPredecessors(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficPredecessors)

            Try

                LoadByJobNumberAndJobComponentNumberPredecessors = From JobTrafficPredecessors In DbContext.JobTrafficPredecessor
                                                                   Where JobTrafficPredecessors.JobPredecessor = JobNumber AndAlso
                                                              JobTrafficPredecessors.JobComponentPredecessor = JobComponentNumber
                                                                   Select JobTrafficPredecessors Distinct

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumberPredecessors = Nothing
            End Try

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, _
                               ByVal JobComponentNbr As Integer, ByVal JobPredecessor As Integer, ByVal JobCompPredecessor As Integer, _
                               ByRef JobTrafficPredecessor As AdvantageFramework.Database.Entities.JobTrafficPredecessors) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                JobTrafficPredecessor = New AdvantageFramework.Database.Entities.JobTrafficPredecessors

                JobTrafficPredecessor.DbContext = DbContext
                JobTrafficPredecessor.JobNumber = JobNumber
                JobTrafficPredecessor.JobComponentNumber = JobComponentNbr
                JobTrafficPredecessor.JobPredecessor = JobPredecessor
                JobTrafficPredecessor.JobComponentPredecessor = JobCompPredecessor

                Inserted = Insert(DbContext, JobTrafficPredecessor)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficPredecessor As AdvantageFramework.Database.Entities.JobTrafficPredecessors) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTrafficPredecessor.Add(JobTrafficPredecessor)

                ErrorText = JobTrafficPredecessor.ValidateEntity(IsValid)

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

        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficPredecessor As AdvantageFramework.Database.Entities.JobTrafficPredecessors) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTrafficPredecessor)

                ErrorText = JobTrafficPredecessor.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficPredecessor As AdvantageFramework.Database.Entities.JobTrafficPredecessors) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobTrafficPredecessor)

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
