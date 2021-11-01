Namespace Controller.ProjectManagement

    Public Class AgileController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Public Const AppVarApplicationName = "BOARDS"

#End Region

#Region " Enum "

        Public Enum BoardUserOptions

            SwimLaneOption
            SwimLaneCollapseOption
            FilterCardOption
            FilterCardOnlyBacklog
            FilterEmployee
            FilterEmployeeIncludeBacklog
            FilterBacklogSort
            FilterBacklogSortType


        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Shared Function AddSprintEmployeeRecords(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal AlertID As Integer) As Boolean
            Dim Added As Boolean = True

            Try

                Dim Setting As Database.Entities.AppVars = Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                                            DbContext.UserCode.ToUpper,
                                                                                                                            "WEEKLY_HOURS_GRID",
                                                                                                                            "CreatePriorWeeksSetting")

                Dim parameters As List(Of System.Data.SqlClient.SqlParameter)

                parameters = New List(Of SqlClient.SqlParameter)

                parameters.Add(New SqlClient.SqlParameter("@AlertID", AlertID))

                If (Setting IsNot Nothing AndAlso Setting.Value.ToLower = "True".ToLower) Then

                    parameters.Add(New SqlClient.SqlParameter("@CreatePast", 1))

                Else

                    parameters.Add(New SqlClient.SqlParameter("@CreatePast", 0))

                End If

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_agile_sprint_add_employee_records] @AlertID, null, @CreatePast;", parameters.ToArray)

            Catch ex As Exception
                Added = False
            End Try

            Return Added

        End Function
        Public Function AddJobToBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByRef ErrorMessage As String) As Boolean

            Dim BoardJob As AdvantageFramework.Database.Entities.BoardJob = Nothing
            Dim BoardJobObject As AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob = Nothing
            Dim Success As Boolean = False

            Try

                BoardJob = AdvantageFramework.Database.Procedures.BoardJob.LoadByBoardAndJobAndComponentNumber(DbContext, BoardID, JobNumber, JobComponentNumber)

                If BoardJob Is Nothing Then

                    BoardJob = New AdvantageFramework.Database.Entities.BoardJob

                    BoardJob.BoardID = BoardID
                    BoardJob.JobNumber = JobNumber
                    BoardJob.JobComponentNumber = JobComponentNumber

                    Success = AdvantageFramework.Database.Procedures.BoardJob.Insert(DbContext, BoardJob)

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                BoardJobObject = Nothing
            End Try

            Return Success

        End Function
        Public Function RemoveJobFromBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal BoardID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                           ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_remove_job_from_board] {0}, {1}, {2};", BoardID, JobNumber, JobComponentNumber))

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Success

        End Function
        Public Function CheckSprintForRemovedOrClosedJobs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintID As Integer, ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_sprint_check_jobs] {0};", SprintID))

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Success

        End Function
        Public Function SaveSwimLaneCollapseOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Collapse As Boolean) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.SwimLaneCollapseOption.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.SwimLaneCollapseOption.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "Boolean"
            '        AppVar.Value = Collapse.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = Collapse.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadSwimLaneCollapseOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim Collapse As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.SwimLaneCollapseOption.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            Collapse = AppVar.Value.ToString.ToLower = "true"

            '        Catch ex As Exception
            '            Collapse = False
            '        End Try

            '    End If

            'Catch ex As Exception
            '    Collapse = False
            'End Try

            Return Collapse

        End Function
        Public Function SaveSwimLaneOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SwimLaneBy As String) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.SwimLaneOption.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.SwimLaneOption.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "String"
            '        AppVar.Value = SwimLaneBy

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = SwimLaneBy

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadSwimLaneOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim SwimLaneBy As String = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey.None.ToString

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.SwimLaneOption.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            SwimLaneBy = AppVar.Value

            '        Catch ex As Exception
            '            SwimLaneBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey.None.ToString
            '        End Try

            '    End If

            'Catch ex As Exception
            '    SwimLaneBy = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey.None.ToString
            'End Try

            Return SwimLaneBy

        End Function
        Public Function SaveFilterCardOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Filter As String) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterCardOption.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterCardOption.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "String"
            '        AppVar.Value = Filter

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = Filter

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterCardOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim Filter As String = ""

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterCardOption.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            Filter = AppVar.Value

            '        Catch ex As Exception
            '            Filter = ""
            '        End Try

            '    End If

            'Catch ex As Exception
            '    Filter = ""
            'End Try

            Return Filter

        End Function
        Public Function SaveFilterOnlyBacklogOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Backlog As Boolean) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterCardOnlyBacklog.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterCardOnlyBacklog.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "Boolean"
            '        AppVar.Value = Backlog.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = Backlog.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterOnlyBacklogOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim Backlog As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterCardOnlyBacklog.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            Backlog = AppVar.Value.ToString.ToLower = "true"

            '        Catch ex As Exception
            '            Backlog = False
            '        End Try

            '    End If

            'Catch ex As Exception
            '    Backlog = False
            'End Try

            Return Backlog

        End Function
        Public Function SaveFilterEmployeeOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Filter As String) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterEmployee.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterEmployee.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "String"
            '        AppVar.Value = Filter

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = Filter

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterEmployeeOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim Filter As String = ""

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterEmployee.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            Filter = AppVar.Value

            '        Catch ex As Exception
            '            Filter = ""
            '        End Try

            '    End If

            'Catch ex As Exception
            '    Filter = ""
            'End Try

            Return Filter

        End Function
        Public Function SaveFilterEmployeeBacklogOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Backlog As Boolean) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterEmployeeIncludeBacklog.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterEmployeeIncludeBacklog.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "Boolean"
            '        AppVar.Value = Backlog.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = Backlog.ToString

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterEmployeeBacklogOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim Backlog As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterEmployeeIncludeBacklog.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            Backlog = AppVar.Value.ToString.ToLower = "true"

            '        Catch ex As Exception
            '            Backlog = False
            '        End Try

            '    End If

            'Catch ex As Exception
            '    Backlog = False
            'End Try

            Return Backlog

        End Function
        Public Function SaveFilterBacklogSortOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BacklogSort As String) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterBacklogSort.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterBacklogSort.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "String"
            '        AppVar.Value = BacklogSort

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = BacklogSort

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterBacklogSortOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim BacklogSort As String = "0"

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterBacklogSort.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            BacklogSort = AppVar.Value

            '        Catch ex As Exception
            '            BacklogSort = "0"
            '        End Try

            '    End If

            'Catch ex As Exception
            '    BacklogSort = "0"
            'End Try

            Return BacklogSort

        End Function
        Public Function SaveFilterBacklogSortTypeOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BacklogSort As String) As Boolean

            Dim Success As Boolean = False

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterBacklogSortType.ToString)

            '    If AppVar Is Nothing Then

            '        AppVar = New Database.Entities.AppVars

            '        AppVar.Application = AppVarApplicationName
            '        AppVar.Name = BoardUserOptions.FilterBacklogSortType.ToString
            '        AppVar.UserCode = Session.UserCode
            '        AppVar.Type = "String"
            '        AppVar.Value = BacklogSort

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

            '    Else

            '        AppVar.Value = BacklogSort

            '        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

            '    End If

            'Catch ex As Exception
            '    Success = False
            'End Try

            Return Success

        End Function
        Public Function LoadFilterBacklogSortTypeOption(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim BacklogSort As String = "modified"

            'Try

            '    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            '    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, Session.UserCode, AppVarApplicationName, BoardUserOptions.FilterBacklogSortType.ToString)

            '    If AppVar IsNot Nothing Then

            '        Try

            '            BacklogSort = AppVar.Value

            '        Catch ex As Exception
            '            BacklogSort = "modified"
            '        End Try

            '    End If

            'Catch ex As Exception
            '    BacklogSort = "modified"
            'End Try

            Return BacklogSort

        End Function

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

#End Region

    End Class

End Namespace
