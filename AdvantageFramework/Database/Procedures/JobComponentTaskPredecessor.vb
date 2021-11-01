Namespace Database.Procedures.JobComponentTaskPredecessor

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

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.JobComponentTaskPredecessor

            LoadByID = (From JobComponentTaskPredecessor In DbContext.JobComponentTaskPredecessors
                        Where JobComponentTaskPredecessor.ID = ID
                        Select JobComponentTaskPredecessor).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor)

            Load = From JobComponentTaskPredecessor In DbContext.JobComponentTaskPredecessors
                   Select JobComponentTaskPredecessor

        End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor)

            LoadByJobNumberAndJobComponentNumber = From JobComponentTaskPredecessor In DbContext.JobComponentTaskPredecessors
                                                   Where JobComponentTaskPredecessor.JobNumber = JobNumber AndAlso
                                                         JobComponentTaskPredecessor.JobComponentNumber = JobComponentNumber
                                                   Select JobComponentTaskPredecessor

        End Function
        Public Function LoadByJobNumberAndJobComponentNumberAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobComponentTaskPredecessor)

            LoadByJobNumberAndJobComponentNumberAndSequenceNumber = From JobComponentTaskPredecessor In DbContext.JobComponentTaskPredecessors
                                                                    Where JobComponentTaskPredecessor.JobNumber = JobNumber AndAlso
                                                                          JobComponentTaskPredecessor.JobComponentNumber = JobComponentNumber AndAlso
                                                                          JobComponentTaskPredecessor.SequenceNumber = SequenceNumber
                                                                    Select JobComponentTaskPredecessor

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskPredecessor As AdvantageFramework.Database.Entities.JobComponentTaskPredecessor) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobComponentTaskPredecessors.Add(JobComponentTaskPredecessor)

                ErrorText = JobComponentTaskPredecessor.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskPredecessor As AdvantageFramework.Database.Entities.JobComponentTaskPredecessor) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobComponentTaskPredecessor)

                ErrorText = JobComponentTaskPredecessor.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskPredecessor As AdvantageFramework.Database.Entities.JobComponentTaskPredecessor) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobComponentTaskPredecessor)

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