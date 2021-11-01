Namespace Database.Procedures.SprintHeader

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

        Public Function BoardCountByJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Integer

            Dim Count As Integer = 0

            Try

                LoadByJobAndComponentNumber(DbContext, JobNumber, JobComponentNumber).Count

            Catch ex As Exception
                Count = 0
            End Try

            Return Count

        End Function
        Public Function LoadActiveByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintHeader)

            LoadActiveByBoardID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                                   Where SprintHeader.BoardID = BoardID And (SprintHeader.IsActive IsNot Nothing And SprintHeader.IsActive = True)
                                   Select SprintHeader)

        End Function
        Public Function LoadByBoardIDWithActiveCount(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal BoardID As Integer) As Collections.Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader)

            LoadByBoardIDWithActiveCount = Nothing

        End Function
        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintHeader)

            LoadByBoardID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                             Where SprintHeader.BoardID = BoardID
                             Select SprintHeader)

        End Function
        Public Function LoadLastByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal BoardID As Integer) As AdvantageFramework.Database.Entities.SprintHeader

            LoadLastByBoardID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                                 Where SprintHeader.BoardID = BoardID 'And (SprintHeader.IsActive IsNot Nothing And SprintHeader.IsActive = True)
                                 Order By SprintHeader.ID Descending
                                 Select SprintHeader).FirstOrDefault

        End Function

        Public Function LoadBySprintHeaderID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SprintHeaderID As Integer) As AdvantageFramework.Database.Entities.SprintHeader

            LoadBySprintHeaderID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                                    Where SprintHeader.ID = SprintHeaderID
                                    Select SprintHeader).SingleOrDefault

        End Function
        Public Function LoadBySprintDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SprintDetailID As Integer) As AdvantageFramework.Database.Entities.SprintHeader

            LoadBySprintDetailID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                                    Join SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail) On SprintDetail.SprintHeaderID Equals SprintHeader.ID
                                    Where SprintDetail.ID = SprintDetailID
                                    Select SprintHeader).SingleOrDefault

        End Function

        Public Function LoadByJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintHeader)

            ''''LoadByJobAndComponentNumber = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
            ''''                               Where SprintHeader.JobNumber = JobNumber And SprintHeader.JobComponentNumber = JobComponentNumber
            ''''                               Select SprintHeader)
            Return Nothing

        End Function

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintHeader)

            Load = From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                   Select SprintHeader

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintHeader As AdvantageFramework.Database.Entities.SprintHeader) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    If SprintHeader.SequenceNumber Is Nothing AndAlso SprintHeader.BoardID IsNot Nothing Then

                        SprintHeader.SequenceNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(MAX(SEQ_NBR), 0) + 1 AS SMALLINT) FROM SPRINT_HDR WHERE BOARD_ID = {0};",
                                                                                                          SprintHeader.BoardID)).SingleOrDefault

                    End If

                Catch ex As Exception
                    SprintHeader.SequenceNumber = 0
                End Try

                ''''Try

                ''''    'Prevent overlap (not complete)?
                ''''    Dim StartDate As Date
                ''''    Dim EndDate As Date
                ''''    Dim NumWks As Integer
                ''''    Dim Cal As System.Globalization.Calendar = System.Globalization.CultureInfo.InvariantCulture.Calendar
                ''''    Dim RecCount As Integer = 0

                ''''    NumWks = SprintHeader.NumberOfWeeks
                ''''    StartDate = SprintHeader.StartDate
                ''''    EndDate = Cal.AddWeeks(StartDate, NumWks)

                ''''    RecCount = (From Entity In DbContext.GetQuery(Of Database.Entities.SprintHeader)
                ''''                Where Entity.BoardID = SprintHeader.BoardID And
                ''''                        Entity.IsActive IsNot Nothing And Entity.IsActive = True And
                ''''                        (Entity.IsComplete Is Nothing Or Entity.IsComplete = False)).Count

                ''''Catch ex As Exception
                ''''End Try

                DbContext.SprintHeaders.Add(SprintHeader)

                ErrorText = SprintHeader.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintHeader As AdvantageFramework.Database.Entities.SprintHeader) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SprintHeader)

                ErrorText = SprintHeader.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SprintHeader As AdvantageFramework.Database.Entities.SprintHeader) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.SprintHeader.IsInUse(DataContext, SprintHeader.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.SprintHeaderRole.LoadBySprintHeaderCode(DataContext, SprintHeader.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(SprintHeader)

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
