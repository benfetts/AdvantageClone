Namespace Database.Procedures.BoardJob

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

        Public Function LoadByJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As AdvantageFramework.Database.Entities.BoardJob

            LoadByJobAndComponentNumber = (From Entity In DbContext.GetQuery(Of Database.Entities.BoardJob)
                                           Where Entity.JobNumber = JobNumber And Entity.JobComponentNumber = JobComponentNumber
                                           Select Entity).SingleOrDefault

        End Function
        Public Function LoadByBoardAndJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal BoardID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As AdvantageFramework.Database.Entities.BoardJob

            LoadByBoardAndJobAndComponentNumber = (From Entity In DbContext.GetQuery(Of Database.Entities.BoardJob)
                                                   Where Entity.BoardID = BoardID And Entity.JobNumber = JobNumber And Entity.JobComponentNumber = JobComponentNumber
                                                   Select Entity).SingleOrDefault

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardJobID As Integer) As AdvantageFramework.Database.Entities.BoardJob

            LoadByID = (From Entity In DbContext.GetQuery(Of Database.Entities.BoardJob)
                        Where Entity.ID = BoardJobID
                        Select Entity).SingleOrDefault

        End Function

        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardJob)

            LoadByBoardID = (From Entity In DbContext.GetQuery(Of Database.Entities.BoardJob)
                             Where Entity.BoardID = BoardID
                             Select Entity)

        End Function
        Public Function LoadJobsByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobComponent)

            LoadJobsByBoardID = (From Entity In DbContext.GetQuery(Of Database.Entities.BoardJob)
                                 Join JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent).Include("Job") On Entity.JobNumber Equals JobComponent.JobNumber And
                                         Entity.JobComponentNumber Equals JobComponent.Number
                                 Where Entity.BoardID = BoardID
                                 Select JobComponent)

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardJob As AdvantageFramework.Database.Entities.BoardJob) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'DbContext.BoardJobs.Add(BoardJob)

                'ErrorText = BoardJob.ValidateEntity(IsValid)

                'If IsValid Then

                '    DbContext.SaveChanges()

                '    Inserted = True

                'Else

                '    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                'End If

                BoardJob.ID = DbContext.Database.SqlQuery(Of Integer)(String.Format("INSERT INTO BOARD_JOB (BOARD_ID, JOB_NUMBER, JOB_COMPONENT_NBR) VALUES ({0} , {1}, {2}); SELECT CAST(@@IDENTITY AS INT);",
                                                                                    BoardJob.BoardID, BoardJob.JobNumber, BoardJob.JobComponentNumber)).SingleOrDefault
                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardJob As AdvantageFramework.Database.Entities.BoardJob) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BoardJob)

                ErrorText = BoardJob.ValidateEntity(IsValid)

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

        Public Function DeleteAllByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardID As Integer) As Boolean

            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM BOARD_JOB WHERE BOARD_ID = {0};", BoardID))
                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteAllByBoardID = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardJob As AdvantageFramework.Database.Entities.BoardJob) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(BoardJob)

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