Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Collections.Generic

<DebuggerDisplay("Id = {Id},Name = {Name},Start = {Start},Finish = {Finish}")> _
Public Class PertTask

    Public Id As Integer = 0
    Public Name As String = ""
    Public Start As Date = Nothing
    Public Finish As Date = Nothing

    Shared Function Init(ByVal reader As IDataReader) As PertTask
        Dim task As New PertTask With { _
            .Id = reader("Id") _
            , .Name = reader("Name") _
            , .Start = reader("Start") _
            , .Finish = reader("Finish") _
        }
        Return task
    End Function

    Public Shared Function GetByPertProject(ByRef projects As List(Of PertProject)) As List(Of PertProject)
        projects = GetTasks(projects) ' this should be the db call, rest is processing
        Return projects
    End Function

    Public Shared Function GetTasks(ByRef projects As List(Of PertProject)) As List(Of PertProject)
        Dim conStr As String = HttpContext.Current.Session("ConnString")
        Dim cnt As Integer = 0
        Dim cd As Date = Date.Now
        Dim t As New Webvantage.cSchedule(conStr, HttpContext.Current.Session("UserCode"))

        For Each project As PertProject In projects
            project.tasks = New List(Of PertTask)
            Dim j As Integer = project.JobNumber
            Dim jc As Integer = project.JobComponentNbr
            Dim dt As New DataTable
            dt = t.GetScheduleTasks(j, jc, "is_null", HttpContext.Current.Session("UserCode"))
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim tsk As PertTask = New PertTask()
                        With tsk
                            If Not IsDBNull(dt.Rows(i)("SEQ_NBR")) Then
                                .Id = dt.Rows(i)("SEQ_NBR")
                            End If
                            If Not IsDBNull(dt.Rows(i)("TASK_DESCRIPTION")) Then
                                .Name = dt.Rows(i)("TASK_DESCRIPTION")
                            End If
                            If Not IsDBNull(dt.Rows(i)("TASK_START_DATE")) Then
                                .Start = dt.Rows(i)("TASK_START_DATE")
                            Else
                                If Not IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) Then
                                    .Start = dt.Rows(i)("JOB_REVISED_DATE")
                                End If
                            End If
                            If Not IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) Then
                                .Finish = dt.Rows(i)("JOB_REVISED_DATE")
                            Else
                                If Not IsDBNull(dt.Rows(i)("TASK_START_DATE")) Then
                                    .Finish = dt.Rows(i)("TASK_START_DATE")
                                End If
                            End If
                        End With
                        project.tasks.Add(tsk)
                    Next
                End If
            End If
        Next
        Return projects
    End Function
End Class
