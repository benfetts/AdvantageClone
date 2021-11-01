Namespace Database.Procedures.Board

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

        Public Function LoadBySprintID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintID As Integer) As AdvantageFramework.Database.Entities.Board

            Dim BoardID As Integer = 0

            Try

                BoardID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(BOARD_ID, 0) FROM SPRINT_HDR WHERE ID = {0};", SprintID)).SingleOrDefault

                LoadBySprintID = LoadByBoardID(DbContext, BoardID)

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardID As Integer) As AdvantageFramework.Database.Entities.Board

            LoadByBoardID = (From Entity In DbContext.GetQuery(Of Database.Entities.Board)
                             Where Entity.ID = BoardID
                             Select Entity).SingleOrDefault

        End Function
        Public Function LoadAllJobsBoards(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Board)

            LoadAllJobsBoards = (From Entity In DbContext.GetQuery(Of Database.Entities.Board)
                                 Where Entity.IncludeAllJobs IsNot Nothing And Entity.IncludeAllJobs = True
                                 Select Entity)

        End Function
        Public Function LoadByJobAndComponent(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer,
                                              ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Board)

            LoadByJobAndComponent = (From Entity In DbContext.GetQuery(Of Database.Entities.Board)
                                     Join BoardJob In DbContext.GetQuery(Of Database.Entities.BoardJob) On BoardJob.BoardID Equals Entity.ID
                                     Where BoardJob.JobNumber = JobNumber And BoardJob.JobComponentNumber = JobComponentNumber And
                                        (Entity.IsActive Is Nothing Or Entity.IsActive = True)
                                     Select Entity)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Board)

            Load = (From Entity In DbContext.GetQuery(Of Database.Entities.Board)
                    Select Entity)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Board As AdvantageFramework.Database.Entities.Board) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'Board.ID = DbContext.Database.SqlQuery(Of Integer)(String.Format("INSERT INTO BOARD (NAME, DESCRIPTION, BOARD_OWNER_EMP_CODE, BOARD_HDR_ID, OFFICE_CODE, CREATE_USER, CREATE_DATE) VALUES ('{0}','{1}', '{2}', {3}, '{4}', '{5}', GETDATE()); SELECT CAST(@@IDENTITY AS INT);",
                '                                                   Board.Name, Board.Description, Board.BoardOwnerEmployeeCode, Board.BoardHeaderID, Board.OfficeCode, Board.CreatedByUserCode)).SingleOrDefault
                'Inserted = True
                DbContext.Boards.Add(Board)

                ErrorText = Board.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Board As AdvantageFramework.Database.Entities.Board) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Board)

                ErrorText = Board.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Board As AdvantageFramework.Database.Entities.Board) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    AdvantageFramework.Database.Procedures.BoardJob.DeleteAllByBoardID(DbContext, Board.ID)

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Board)
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

