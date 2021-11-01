Imports System.Threading

Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class WorkItemAsync

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Session

#End Region

#Region " Properties "

        Public Property SprintHeaderID As Integer = 0
        Public Property AlertID As Integer? = 0

        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Public Property TaskSequenceNumber As Short = -1

        Public Property Result As ResultObject = Nothing

#End Region

#Region " Methods "

#Region " Checks entire sprint "

        'Public Sub CleanUpHours()

        '    Dim CleanUpHoursThreadStart As New ParameterizedThreadStart(AddressOf CleanUpHoursAsync)
        '    Dim CleanUpHoursThread As New Thread(CleanUpHoursThreadStart)

        '    CleanUpHoursThread.Start()

        'End Sub
        'Private Sub CleanUpHoursAsync()

        '    If _SecuritySession IsNot Nothing AndAlso AlertID IsNot Nothing AndAlso AlertID > 0 Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

        '            Dim Hours As Generic.List(Of AdvantageFramework.Database.Entities.SprintEmployee) = Nothing

        '            Hours = AdvantageFramework.Database.Procedures.SprintEmployee.LoadByAlertID(DbContext, AlertID).ToList

        '            If Hours IsNot Nothing AndAlso Hours.Count > 0 Then

        '                Try

        '                    Result = DbContext.Database.SqlQuery(Of ResultObject)(String.Format("EXEC [dbo].[advsp_agile_hours_cleanup] {0}, NULL, NULL;", AlertID)).SingleOrDefault

        '                Catch ex As Exception
        '                End Try

        '            End If

        '        End Using

        '    End If

        'End Sub

        Public Sub CheckSprintEmployeeRecordsWithCheck()

            Dim CheckRecordsThreadStart As New ParameterizedThreadStart(AddressOf CheckSprintEmployeeRecordsWithCheckAsync)
            Dim CheckRecordsThread As New Thread(CheckRecordsThreadStart)

            CheckRecordsThread.Start()

        End Sub
        Public Sub CheckSprintEmployeeRecordsWithCheckAsync()

            If _SecuritySession IsNot Nothing AndAlso AlertID IsNot Nothing AndAlso AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                    Dim Hours As Generic.List(Of AdvantageFramework.Database.Entities.SprintEmployee) = Nothing

                    Hours = AdvantageFramework.Database.Procedures.SprintEmployee.LoadByAlertID(DbContext, AlertID).ToList

                    If Hours IsNot Nothing AndAlso Hours.Count > 0 Then

                        Try

                            Result = DbContext.Database.SqlQuery(Of ResultObject)(String.Format("EXEC [dbo].[advsp_agile_sprint_check_employee_records] {0}, NULL, 1;", AlertID)).SingleOrDefault

                        Catch ex As Exception
                        End Try

                    End If

                End Using

            End If

        End Sub
        Public Sub CheckSprintEmployeeRecords()

            Dim CheckRecordsThreadStart As New ParameterizedThreadStart(AddressOf CheckSprintEmployeeRecordsAsync)
            Dim CheckRecordsThread As New Thread(CheckRecordsThreadStart)

            CheckRecordsThread.Start()

        End Sub
        Private Sub CheckSprintEmployeeRecordsAsync()

            If _SecuritySession IsNot Nothing AndAlso AlertID IsNot Nothing AndAlso AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                    Try

                        Result = DbContext.Database.SqlQuery(Of ResultObject)(String.Format("EXEC [dbo].[advsp_agile_sprint_check_employee_records] {0}, NULL, 1;", AlertID)).SingleOrDefault

                    Catch ex As Exception
                    End Try

                End Using

            End If

        End Sub

#End Region
#Region " Check a task "

        Public Sub CheckTaskForSprintEmployees()

            Dim CheckTaskForSprintEmployeesThreadStart As New ParameterizedThreadStart(AddressOf CheckTaskForSprintEmployeesAsync)
            Dim CheckTaskForSprintEmployeesThread As New Thread(CheckTaskForSprintEmployeesThreadStart)

            CheckTaskForSprintEmployeesThread.Start()

        End Sub
        Private Sub CheckTaskForSprintEmployeesAsync()

            If _SecuritySession IsNot Nothing AndAlso
                    JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso TaskSequenceNumber > -1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[advsp_agile_sprint_check_task_employees] {0}, {1}, {2};",
                                                                           JobNumber, JobComponentNumber, TaskSequenceNumber))

                    Catch ex As Exception
                    End Try

                End Using

            End If

        End Sub

#End Region

        Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

            _SecuritySession = SecuritySession
            Result = New ResultObject

        End Sub

#End Region

        <Serializable()>
        Public Class ResultObject
            Public Property Success As Boolean = False
            Public Property Message As String = String.Empty
            Sub New()

            End Sub
        End Class

    End Class

End Namespace
