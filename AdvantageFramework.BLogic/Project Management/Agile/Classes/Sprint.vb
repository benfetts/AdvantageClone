Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class Sprint

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property BoardID As Integer = 0
        Public Property SprintID As Integer = 0

        Public Property Header As AdvantageFramework.Database.Entities.SprintHeader = Nothing
        Public Property Employees As Generic.List(Of AdvantageFramework.Database.Entities.SprintEmployee) = Nothing
        Public Property Details As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.SprintDetail) = Nothing
        Public Property Boards As IEnumerable

#End Region

#Region " Methods "

        Public Sub LoadForAdd()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Header = New Database.Entities.SprintHeader

                Employees = New List(Of Database.Entities.SprintEmployee)
                Details = New List(Of SprintDetail)

                Try

                    Dim LastActiveSprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing
                    LastActiveSprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadLastByBoardID(DbContext, BoardID)

                    If LastActiveSprint IsNot Nothing Then

                        Header.StartDate = AdvantageFramework.DateUtilities.FirstDayOfWeek(DateAdd(DateInterval.Day, CType(LastActiveSprint.NumberOfWeeks * 7, Double), CType(LastActiveSprint.StartDate, Date)))

                    End If

                Catch ex As Exception
                End Try

                If Header.StartDate Is Nothing Then

                    Header.StartDate = AdvantageFramework.DateUtilities.FirstDayOfWeek(Now.Date)

                End If

                Try
                    Dim SprintCount As Integer = 0

                    SprintCount = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.SprintHeader)
                                   Where Entity.BoardID = BoardID
                                   Select Entity).Count

                    Header.Description = "Sprint " & SprintCount + 1

                Catch ex As Exception
                End Try

                Header.NumberOfWeeks = 1
                Header.TrackChanges = False
                Header.EmailOnChange = False

                Try

                    Boards = (From Entity In AdvantageFramework.Database.Procedures.Board.Load(DbContext)
                              Select Entity.ID, Entity.Name).ToList

                Catch ex As Exception
                End Try

            End Using

        End Sub

        Public Sub Load()

            Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                If SprintID > 0 Then

                    Header = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)
                    Employees = New List(Of Database.Entities.SprintEmployee)
                    Details = New List(Of SprintDetail)

                    Try

                        Boards = (From Entity In AdvantageFramework.Database.Procedures.Board.Load(DbContext)
                                  Select Entity.ID, Entity.Name).ToList

                    Catch ex As Exception
                    End Try


                Else

                    LoadForAdd()

                End If
                'Details = AdvantageFramework.Database.Procedures.SprintDetail.LoadByJobAndComponentNumber(DbContext,)

            End Using

        End Sub
        Public Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession

        End Sub

#End Region

    End Class

    Public Class SprintDetail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
