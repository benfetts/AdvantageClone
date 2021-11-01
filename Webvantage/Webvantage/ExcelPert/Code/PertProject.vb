Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class PertProject

    Public Id As Integer = 0
    Public IsActive As Boolean = True

    Public ClientName As String = ""
    Public AEName As String = ""

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public JobComponentDesc As String = ""
    Public JobStartDate As String = ""
    Public JobDueDate As String = ""

    Public ClCode As String = ""
    Public DivCode As String = ""
    Public PrdCode As String = ""
    Public EmpCode As String = ""
    Public ManagerCode As String = ""
    Public TaskCode As String = ""
    Public AccountExecCode As String = ""
    Public RoleCode As String = ""
    Public CutOffDate As String = ""
    Public IncludeCompletedTasks As Boolean = True
    Public IncludeOnlyPendingTasks As Boolean = False
    Public ExcludeProjectedTasks As Boolean = False
    Public IncludeCompletedSchedules As Boolean = True
    Public MilestonesOnly As Boolean = False
    Public EditHeaders As Boolean = False
    Public EditGrids As Boolean = False
    Public UsingATaskLevelFilter As Boolean = False
    Public CampaignCode As String = ""
    Public TaskPhaseFilter As String = ""
    Public TrafficStatusCode As String = ""

    Private mConnString As String
    Private mUserCode As String
    Private mEmpCode As String


    Public Grid(1, 1) As Integer
    Public tasks As List(Of PertTask)

    Public Function GetAll(Optional ByVal excel As Integer = 0) As String
        Dim projects As List(Of PertProject) = GetSchedules()
        If projects.Count > 0 Then
            projects = PertTask.GetByPertProject(projects)
            If excel = 1 Then
                Return ToHTMLExcel(projects)
            Else
                Return ToHTML(projects)
            End If
        End If
    End Function

    Public Function ToHTML(ByRef projects As List(Of PertProject)) As String

        ' find high low dates
        Dim start As Date = projects(0).tasks(0).Start
        Dim finish As Date = projects(0).tasks(0).Finish
        For u As Integer = 0 To projects.Count - 1
            For Each task As PertTask In projects(u).tasks
                If task.Start < start Then start = task.Start
                If task.Finish > finish Then finish = task.Finish
            Next
        Next
        Dim days As Integer = finish.Subtract(start).Days
        Dim strColor(10) As String
        strColor(0) = "D00000" '"AFD8F8" 'Baby blue
        strColor(1) = "F6BD0F" 'gold
        strColor(2) = "A66EDD" 'purple
        strColor(3) = "8BBA00" 'green
        strColor(4) = "FF8000" 'orange
        strColor(5) = "AFD8F8" 'baby blue
        strColor(6) = "FFC1C1" 'pink
        strColor(7) = "005500" 'dark green
        strColor(8) = "AA0000" 'dark red
        strColor(9) = "0372AB" 'darker blue

        '  set tasks in grid
        For u As Integer = 0 To projects.Count - 1
            ReDim projects(u).Grid(days, 5)
            Dim maxStack As Integer = 0
            For Each task As PertTask In projects(u).tasks
                Dim sd As Integer = days - finish.Subtract(task.Start).Days
                Dim fd As Integer = days - finish.Subtract(task.Finish).Days - 1
                Dim stack As Integer = 0
                Dim clean As Boolean = False
                While (clean = False)
                    clean = True
                    For c As Integer = sd To fd
                        If projects(u).Grid(c, stack) <> 0 Then
                            clean = False
                            stack = stack + 1
                            Exit For
                        End If
                    Next
                End While
                If maxStack < stack Then maxStack = stack
                For c As Integer = sd To fd
                    projects(u).Grid(c, stack) = task.Id
                Next
            Next
            ReDim Preserve projects(u).Grid(days, maxStack)
        Next

        ' start html===============
        Dim sb As System.Text.StringBuilder = New StringBuilder()
        Dim wid As Integer = days * 20 + 400
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='" & wid & "' style='border-collapse:collapse;border=1px solid black'>" & Chr(13))

        ' month row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td class='rtitle' colspan='7' style='border-bottom:0px solid black' ></td>" & Chr(13))
        sb.Append("<td class='rdel' ></td>" & Chr(13))
        For x As Integer = 0 To days
            Dim d As String = start.AddDays(x).ToString("MM-yyyy")
            Dim w As Integer = 0
            For z As Integer = x To days
                If start.AddDays(z).ToString("MM-yyyy") <> d Then Exit For
                w += 1
            Next
            Dim m = start.AddDays(x).ToString("MMMM") & "&nbsp;" + start.AddDays(x).ToString("yyyy")
            sb.Append("<td class='rmonth' colspan='" & w & "'>" & m & "</td>" + Chr(13))
            x += w - 1
        Next
        sb.Append("</tr>" & Chr(13))

        ' date row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td class='rtitle' colspan='7' style='border-top:0px solid black' ></td>" + Chr(13))
        sb.Append("<td class='rdel' ></td>" + Chr(13))
        For x As Integer = 0 To days
            Dim d As Integer = start.AddDays(x).Day
            Dim wd As Integer = start.AddDays(x).DayOfWeek
            If wd = 0 Or wd = 6 Then
                sb.Append("<td class='rweekday' >" & d & "</td>" + Chr(13))
            Else
                sb.Append("<td class='rday' >" & d & "</td>" + Chr(13))
            End If
        Next
        sb.Append("</tr>" & Chr(13))

        ' header row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td class='rhead' >Client</td>" & Chr(13))
        sb.Append("<td class='rhead' >AE</td>" & Chr(13))
        sb.Append("<td class='rhead' >Job</td>" & Chr(13))
        sb.Append("<td class='rhead' >Component</td>" & Chr(13))
        sb.Append("<td class='rhead' >Description</td>" & Chr(13))
        sb.Append("<td class='rhead' >Job Start</td>" & Chr(13))
        sb.Append("<td class='rhead' >Job Due</td>" & Chr(13))
        sb.Append("<td class='rdel' >&nbsp;</td>" + Chr(13))
        sb.Append("<td class='rhead' colspan='" & (days + 1) & "' >&nbsp;</td>" & Chr(13))

        ' active row
        sb.Append("<tr><td class='rstatus' colspan=" & (days + 9) & ">Active&nbsp;Jobs</td></tr>" + Chr(13))

        ' add active
        For Each p As PertProject In projects
            If p.IsActive <> True Then Continue For
            Dim rows As Integer = p.Grid.GetLength(1)
            sb.Append("<tr>" + Chr(13))
            sb.Append(String.Format("<td class='r' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.ClientName))
            sb.Append(String.Format("<td class='rred' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.AEName))
            sb.Append(String.Format("<td class='r' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobNumber))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobComponentNbr))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobComponentDesc))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobStartDate))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobDueDate))
            sb.Append(String.Format("<td class='rdel' rowspan='{0}'></td>" + Chr(13), rows, "&nbsp;"))
            For x As Integer = 0 To p.Grid.GetLength(1) - 1
                For y As Integer = 0 To p.Grid.GetLength(0) - 1
                    If p.Grid(y, x) <> 0 Then
                        Dim n As Integer = p.Grid(y, x)
                        Dim ct As PertTask
                        For Each t As PertTask In p.tasks
                            If t.Id = n + 1 Then
                                ct = t
                                Exit For
                            End If
                        Next
                        Dim w As Integer = 0
                        For z As Integer = y To p.Grid.GetLength(0) - 1
                            If p.Grid(z, x) = n Then w += 1 Else Exit For
                        Next
                        Dim name As String = ""
                        Try
                            name = Regex.Replace(ct.Name, " ", "&nbsp;")
                        Catch ex As Exception
                            name = "&nbsp;"
                        End Try
                        sb.Append("<td style=""background-color: #" & strColor(y Mod 10) & "; font-size:7pt; text-align: center;"" colspan='" & w & "'>" & name & "</td>" + Chr(13))
                        y += w - 1
                    Else
                        Dim wd As Integer = start.AddDays(y).DayOfWeek
                        If wd = 0 Or wd = 6 Then
                            sb.Append("<td class='rweekblank' >&nbsp;</td>" & Chr(13))
                        Else
                            sb.Append("<td class='rblank' >&nbsp;</td>" & Chr(13))
                        End If
                    End If
                Next
                sb.Append("</tr>" + Chr(13))
            Next
        Next

        ' inactive row
        sb.Append("<tr><td class='rstatus' colspan=" & (days + 9) & ">Upcoming</td></tr>" + Chr(13))

        ' inactives 
        For Each p As PertProject In projects
            If p.IsActive = True Then Continue For
            Dim rows As Integer = p.Grid.GetLength(1)
            sb.Append("<tr>" + Chr(13))
            sb.Append(String.Format("<td class='r' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.ClientName))
            sb.Append(String.Format("<td class='rred' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.AEName))
            sb.Append(String.Format("<td class='r' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobNumber))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobComponentNbr))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobComponentDesc))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobStartDate))
            sb.Append(String.Format("<td class='rbold' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobDueDate))
            sb.Append(String.Format("<td class='rdel' rowspan='{0}'></td>" & Chr(13), rows, "&nbsp;"))
            For x As Integer = 0 To p.Grid.GetLength(1) - 1
                For y As Integer = 0 To p.Grid.GetLength(0) - 1
                    If p.Grid(y, x) <> 0 Then
                        Dim n As Integer = p.Grid(y, x)
                        Dim ct As PertTask
                        For Each t As PertTask In p.tasks
                            If t.Id = n + 1 Then
                                ct = t
                                Exit For
                            End If
                        Next
                        Dim w As Integer = 0
                        For z As Integer = y To p.Grid.GetLength(0) - 1
                            If p.Grid(z, x) = n Then w += 1 Else Exit For
                        Next
                        Dim name As String = Regex.Replace(ct.Name, " ", "&nbsp;")
                        sb.Append("<td class='rtask' colspan='" & w & "'>" & name & "</td>" + Chr(13))
                        y += w - 1
                    Else
                        Dim wd As Integer = start.AddDays(y).DayOfWeek
                        If wd = 0 Or wd = 6 Then
                            sb.Append("<td class='rweekblank' >&nbsp;</td>" & Chr(13))
                        Else
                            sb.Append("<td class='rblank' >&nbsp;</td>" & Chr(13))
                        End If
                    End If
                Next
                sb.Append("</tr>" + Chr(13))
            Next
        Next

        'end html
        sb.Append("</table>" + Chr(13))

        Return sb.ToString()

    End Function

    Public Function ToHTMLExcel(ByRef projects As List(Of PertProject)) As String

        ' find high low dates
        Dim start As Date = projects(0).tasks(0).Start
        Dim finish As Date = projects(0).tasks(0).Finish
        For u As Integer = 0 To projects.Count - 1
            For Each task As PertTask In projects(u).tasks
                If task.Start < start Then start = task.Start
                If task.Finish > finish Then finish = task.Finish
            Next
        Next
        Dim days As Integer = finish.Subtract(start).Days
        Dim strColor(10) As String
        strColor(0) = "D00000" '"AFD8F8" 'Baby blue
        strColor(1) = "F6BD0F" 'gold
        strColor(2) = "A66EDD" 'purple
        strColor(3) = "8BBA00" 'green
        strColor(4) = "FF8000" 'orange
        strColor(5) = "AFD8F8" 'baby blue
        strColor(6) = "999999" 'gray
        strColor(7) = "005500" 'dark green
        strColor(8) = "AA0000" 'dark red
        strColor(9) = "0372AB" 'darker blue

        '  set tasks in grid
        For u As Integer = 0 To projects.Count - 1
            ReDim projects(u).Grid(days, 5)
            Dim maxStack As Integer = 0
            For Each task As PertTask In projects(u).tasks
                Dim sd As Integer = days - finish.Subtract(task.Start).Days
                Dim fd As Integer = days - finish.Subtract(task.Finish).Days - 1
                Dim stack As Integer = 0
                Dim clean As Boolean = False
                While (clean = False)
                    clean = True
                    For c As Integer = sd To fd
                        If projects(u).Grid(c, stack) <> 0 Then
                            clean = False
                            stack = stack + 1
                            Exit For
                        End If
                    Next
                End While
                If maxStack < stack Then maxStack = stack
                For c As Integer = sd To fd
                    projects(u).Grid(c, stack) = task.Id
                Next
            Next
            ReDim Preserve projects(u).Grid(days, maxStack)
        Next

        ' start html===============
        Dim sb As System.Text.StringBuilder = New StringBuilder()
        Dim wid As Integer = days * 20 + 400
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='" & wid & "' style='border-collapse:collapse;border=1px solid black '>" & Chr(13))

        ' month row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td class='rtitle' colspan='7' style='border-bottom:0px solid black; white-space:nowrap;' ></td>" & Chr(13))
        sb.Append("<td style='width: 2px; background-color:Black; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' ></td>" & Chr(13))
        For x As Integer = 0 To days
            Dim d As String = start.AddDays(x).ToString("MM-yyyy")
            Dim w As Integer = 0
            For z As Integer = x To days
                If start.AddDays(z).ToString("MM-yyyy") <> d Then Exit For
                w += 1
            Next
            Dim m = start.AddDays(x).ToString("MMMM") & "&nbsp;" + start.AddDays(x).ToString("yyyy")
            sb.Append("<td style='text-align:center; font-size: 10pt; white-space:nowrap; font-weight:bold;	padding-left:10px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' colspan='" & w & "'>" & m & "</td>" + Chr(13))
            x += w - 1
        Next
        sb.Append("</tr>" & Chr(13))

        ' date row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td class='rtitle' colspan='7' style='border-top:0px solid; white-space:nowrap;' ></td>" + Chr(13))
        sb.Append("<td style='width: 2px; background-color:Black; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' ></td>" + Chr(13))
        For x As Integer = 0 To days
            Dim d As Integer = start.AddDays(x).Day
            Dim wd As Integer = start.AddDays(x).DayOfWeek
            If wd = 0 Or wd = 6 Then
                sb.Append("<td style='width:20px; text-align:center; font-size: 6pt; background-color: #AAA; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >" & d & "</td>" + Chr(13))
            Else
                sb.Append("<td style='width:20px; text-align:center; font-size: 6pt; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >" & d & "</td>" + Chr(13))
            End If
        Next
        sb.Append("</tr>" & Chr(13))

        ' header row
        sb.Append("<tr>" + Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Client</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >AE</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Job</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Component</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Description</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Job Start</td>" & Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-bottom:1pt solid black; border-top:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' >Job Due</td>" & Chr(13))
        sb.Append("<td style='width: 2px; background-color:Black; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >&nbsp;</td>" + Chr(13))
        sb.Append("<td style='color: black; border: 0px solid black; font-size: 10pt; font-weight:bold; padding:0px 2px 0px 2px;	text-align:center; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' colspan='" & (days + 1) & "' >&nbsp;</td>" & Chr(13))

        ' active row
        sb.Append("<tr><td style='color: white; background-color: black; font-size: 10pt; font-weight:bold; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' colspan=" & (days + 9) & ">Active&nbsp;Jobs</td></tr>" + Chr(13))

        ' add active
        For Each p As PertProject In projects
            If p.IsActive <> True Then Continue For
            Dim rows As Integer = p.Grid.GetLength(1)
            sb.Append("<tr>" + Chr(13))
            sb.Append(String.Format("<td style='font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.ClientName))
            sb.Append(String.Format("<td style='font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.AEName))
            sb.Append(String.Format("<td style='font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobNumber))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobComponentNbr))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobComponentDesc))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobStartDate))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" + Chr(13), rows, p.JobDueDate))
            sb.Append(String.Format("<td style='width: 2px; background-color:Black; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'></td>" + Chr(13), rows, "&nbsp;"))
            For x As Integer = 0 To p.Grid.GetLength(1) - 1
                For y As Integer = 0 To p.Grid.GetLength(0) - 1
                    If p.Grid(y, x) <> 0 Then
                        Dim n As Integer = p.Grid(y, x)
                        Dim ct As PertTask
                        For Each t As PertTask In p.tasks
                            If t.Id = n + 1 Then
                                ct = t
                                Exit For
                            End If
                        Next
                        Dim w As Integer = 0
                        For z As Integer = y To p.Grid.GetLength(0) - 1
                            If p.Grid(z, x) = n Then w += 1 Else Exit For
                        Next
                        Dim name As String = ""
                        Try
                            name = Regex.Replace(ct.Name, " ", "&nbsp;")
                        Catch ex As Exception
                            name = "&nbsp;"
                        End Try
                        sb.Append("<td style='background-color: #" & strColor(y Mod 10) & "; font-size:7pt; text-align: center; white-space:nowrap; border-right:1pt solid black; border-bottom:1pt solid black; vertical-align:middle;' colspan='" & w & "'>" & name & "</td>" + Chr(13))
                        y += w - 1
                    Else
                        Dim wd As Integer = start.AddDays(y).DayOfWeek
                        If wd = 0 Or wd = 6 Then
                            sb.Append("<td style='background-color: #AAA; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >&nbsp;</td>" & Chr(13))
                        Else
                            sb.Append("<td style='background-color:#EEEEEE; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >&nbsp;</td>" & Chr(13))
                        End If
                    End If
                Next
                sb.Append("</tr>" + Chr(13))
            Next
        Next

        ' inactive row
        sb.Append("<tr><td style='color: white; background-color: black; font-size: 10pt; font-weight:bold; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' colspan=" & (days + 9) & ">Upcoming</td></tr>" + Chr(13))

        ' inactives 
        For Each p As PertProject In projects
            If p.IsActive = True Then Continue For
            Dim rows As Integer = p.Grid.GetLength(1)
            sb.Append("<tr>" + Chr(13))
            sb.Append(String.Format("<td style='font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.ClientName))
            sb.Append(String.Format("<td style='color: Red; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.AEName))
            sb.Append(String.Format("<td style='font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobNumber))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobComponentNbr))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobComponentDesc))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobStartDate))
            sb.Append(String.Format("<td style='font-weight: bold; font-size: 10pt; font-weight:bold; white-space:nowrap; padding 2px 2px 2px 2px; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'>{1}</td>" & Chr(13), rows, p.JobDueDate))
            sb.Append(String.Format("<td style='width: 2px; background-color:Black; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' rowspan='{0}'></td>" & Chr(13), rows, "&nbsp;"))
            For x As Integer = 0 To p.Grid.GetLength(1) - 1
                For y As Integer = 0 To p.Grid.GetLength(0) - 1
                    If p.Grid(y, x) <> 0 Then
                        Dim n As Integer = p.Grid(y, x)
                        Dim ct As PertTask
                        For Each t As PertTask In p.tasks
                            If t.Id = n + 1 Then
                                ct = t
                                Exit For
                            End If
                        Next
                        Dim w As Integer = 0
                        For z As Integer = y To p.Grid.GetLength(0) - 1
                            If p.Grid(z, x) = n Then w += 1 Else Exit For
                        Next
                        Dim name As String = Regex.Replace(ct.Name, " ", "&nbsp;")
                        sb.Append("<td style='background-color: #DDDDFF; text-align: center; font-size: 7pt; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' colspan='" & w & "'>" & name & "</td>" + Chr(13))
                        y += w - 1
                    Else
                        Dim wd As Integer = start.AddDays(y).DayOfWeek
                        If wd = 0 Or wd = 6 Then
                            sb.Append("<td style='background-color: #AAA; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >&nbsp;</td>" & Chr(13))
                        Else
                            sb.Append("<td style='background-color:#EEEEEE; border-right:1pt solid black; border-bottom:1pt solid black; white-space:nowrap; font-weight:400; font-family:Arial, sans-serif; vertical-align:middle;' >&nbsp;</td>" & Chr(13))
                        End If
                    End If
                Next
                sb.Append("</tr>" + Chr(13))
            Next
        Next

        'end html
        sb.Append("</table>" + Chr(13))

        Return sb.ToString()

    End Function

    Private Function GetSchedules() As List(Of PertProject)
        Dim conStr As String = mConnString
        Dim pps As List(Of PertProject) = New List(Of PertProject)
        Dim dt As New DataTable
        Dim t As New Webvantage.cSchedule(mConnString, mUserCode)

        dt = t.GetScheduleHeader(JobNumber, JobComponentNbr, mUserCode, IncludeCompletedSchedules, _
                                ClCode, DivCode, PrdCode, EmpCode, AccountExecCode, TaskCode, RoleCode, CutOffDate, ManagerCode, _
                                IncludeCompletedTasks, IncludeOnlyPendingTasks, ExcludeProjectedTasks, CampaignCode, True, MilestonesOnly, Me.TrafficStatusCode, True).Tables(0)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim pp As New PertProject
                    With pp
                        .Id = i
                        If Not IsDBNull(dt.Rows(i)("CL_CODE")) Then
                            .ClientName = dt.Rows(i)("CL_CODE").ToString()
                        End If
                        If Not IsDBNull(dt.Rows(i)("AE_NAME")) Then
                            .AEName = dt.Rows(i)("AE_NAME").ToString()
                        End If
                        If Not IsDBNull(dt.Rows(i)("JOB_NUMBER")) Then
                            .JobNumber = CType(dt.Rows(i)("JOB_NUMBER"), Integer).ToString()
                        End If
                        If Not IsDBNull(dt.Rows(i)("JOB_COMPONENT_NBR")) Then
                            .JobComponentNbr = CType(dt.Rows(i)("JOB_COMPONENT_NBR"), Integer).ToString()
                        End If
                        If Not IsDBNull(dt.Rows(i)("JOB_COMP_DESC")) Then
                            .JobComponentDesc = dt.Rows(i)("JOB_COMP_DESC").ToString()
                        End If
                        If Not IsDBNull(dt.Rows(i)("START_DATE")) Then
                            .JobStartDate = CType(dt.Rows(i)("START_DATE"), DateTime).ToShortDateString()
                        Else
                            If Not IsDBNull(dt.Rows(i)("JOB_FIRST_USE_DATE")) Then
                                .JobStartDate = CType(dt.Rows(i)("JOB_FIRST_USE_DATE"), DateTime).ToShortDateString()
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(i)("JOB_FIRST_USE_DATE")) Then
                            .JobDueDate = CType(dt.Rows(i)("JOB_FIRST_USE_DATE"), DateTime).ToShortDateString()
                        Else
                            If Not IsDBNull(dt.Rows(i)("START_DATE")) Then
                                .JobDueDate = CType(dt.Rows(i)("START_DATE"), DateTime).ToShortDateString()
                            End If
                        End If
                    End With
                    pps.Add(pp)
                Next
            End If
        End If
        pps = PertTask.GetByPertProject(pps)
        Return pps
    End Function

    Public Sub New(Optional ByVal UserCode As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        Try
            If UserCode <> "" Then
                mUserCode = UserCode
            Else
                mUserCode = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserCode = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
    End Sub

End Class

