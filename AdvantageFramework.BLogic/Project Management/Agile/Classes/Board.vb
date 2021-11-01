Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class Board

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property BoardID As Integer = 0

        Public Property Header As AdvantageFramework.Database.Entities.Board = Nothing

        Public Property Jobs As IEnumerable
        Public Property SelectedJobsKeys As IEnumerable
        Public Property Boards As IEnumerable
        Public Property Employees As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.EmployeeSimple) = Nothing
        Public Property Offices As IEnumerable

#End Region

#Region " Methods "

        Public Sub Load()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Try

                    Offices = (From Entity In Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me._SecuritySession)
                               Select Entity.Code, Entity.Name).ToList

                Catch ex As Exception
                End Try
                Try
                    If BoardID > 0 Then

                        Boards = (From Entity In AdvantageFramework.Database.Procedures.BoardHeader.Load(DbContext)
                                  Select Entity.ID, Entity.Name).ToList

                    Else

                        Boards = (From Entity In AdvantageFramework.Database.Procedures.BoardHeader.LoadActive(DbContext)
                                  Select Entity.ID, Entity.Name).ToList

                    End If

                Catch ex As Exception
                End Try
                Try

                    Employees = AdvantageFramework.ProjectManagement.Agile.LoadEmployeeSimple(DbContext, Me._SecuritySession.UserCode, "", "", "", 0, 0, -1, False, False, False, True)

                Catch ex As Exception
                End Try
                Try

                    If Employees IsNot Nothing Then
                        For Each Employee In Employees
                            Employee.EmployeePictureURL = String.Empty
                            Employee.Picture = Nothing
                        Next
                    End If
                Catch ex As Exception
                End Try
                Try

                    Jobs = AdvantageFramework.ProjectManagement.Agile.LoadJobsForBoard(DbContext, BoardID, Me._SecuritySession.UserCode)

                Catch ex As Exception
                End Try

                Try

                    If BoardID > 0 Then

                        Try

                            Header = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                        Catch ex As Exception
                            Header = Nothing
                        End Try
                        Try

                            SelectedJobsKeys = (From Entity In AdvantageFramework.Database.Procedures.BoardJob.LoadByBoardID(DbContext, BoardID)
                                                Select Entity.JobNumber.ToString & "," & Entity.JobComponentNumber.ToString).ToList

                        Catch ex As Exception

                        End Try


                    End If

                    If Header Is Nothing Then

                        Header = New Database.Entities.Board
                        Header.BoardHeaderID = 0

                    End If

                    If Header IsNot Nothing AndAlso Header.IncludeAllJobs Is Nothing Then

                        Header.IncludeAllJobs = False

                    End If

                Catch ex As Exception
                End Try

            End Using

        End Sub

        Sub New()


        End Sub
        Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

            _SecuritySession = SecuritySession

            Header = New Database.Entities.Board
            Employees = New List(Of EmployeeSimple)

        End Sub

#End Region

    End Class

End Namespace
