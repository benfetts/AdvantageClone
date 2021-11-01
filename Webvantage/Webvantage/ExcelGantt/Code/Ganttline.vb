Imports System.Collections.Generic
Imports System.Data.SqlClient

<Serializable()> Public Class Ganttline

    Public Enum TaskTypeEnum
        Task = 1
        Phase = 2
    End Enum

    Public Id As Integer
    Public CampaignTitle As String
    Public JobNumber As Integer
    Public JobDescription As String
    Public JobCompNumber As Integer
    Public JobCompDescription As String
    Public ClientName As String
    Public ProductName As String
    Public TrafficComment As String
    Public PhaseName As String
    Public TaskName As String
    Public Sequence As Integer
    Public Days As Integer
    Public StartDate As DateTime
    Public FinishDate As DateTime
    Public EmployeesResponsible As String
    Public ClientsResponsible As String
    Public FunctionComment As String
    Public TrafficStatus As String

    Public LineName As String
    Public TaskType As String
    Public Dates As String
    Public Responsible As String
    Public CompletedDate As String

    Public Lines As List(Of Ganttline)

    Private mConnString As String
    Private mUserID As String
    Private oSQL As SqlHelper

  

    Shared Function Init(ByVal reader As IDataReader) As Ganttline
        Dim timeline As New Ganttline() With {
            .Id = reader("ROWID") _
            , .CampaignTitle = IIf(reader("CMP_NAME") Is DBNull.Value, "", reader("CMP_NAME")) _
            , .JobNumber = IIf(reader("JOB_NUMBER") Is DBNull.Value, 0, reader("JOB_NUMBER")) _
            , .JobDescription = IIf(reader("JOB_DESC") Is DBNull.Value, "", reader("JOB_DESC")) _
            , .JobCompNumber = IIf(reader("JOB_COMPONENT_NBR") Is DBNull.Value, 0, reader("JOB_COMPONENT_NBR")) _
            , .JobCompDescription = IIf(reader("JOB_COMP_DESC") Is DBNull.Value, "", reader("JOB_COMP_DESC")) _
            , .ClientName = IIf(reader("CL_Name") Is DBNull.Value, "", reader("CL_Name")) _
            , .ProductName = IIf(reader("PRD_DESCRIPTION") Is DBNull.Value, "", reader("PRD_DESCRIPTION")) _
            , .TrafficComment = IIf(reader("TRF_COMMENTS") Is DBNull.Value, "", reader("TRF_COMMENTS")) _
            , .PhaseName = IIf(reader("PHASE_DESC") Is DBNull.Value, "", reader("PHASE_DESC")) _
            , .TaskName = IIf(reader("TASK_DESCRIPTION") Is DBNull.Value, "", reader("TASK_DESCRIPTION")) _
            , .Sequence = IIf(reader("SEQ_NBR") Is DBNull.Value, 0, reader("SEQ_NBR")) _
            , .Days = IIf(reader("PARENT_DAYS") Is DBNull.Value, IIf(reader("JOB_DAYS") Is DBNull.Value, 0, reader("JOB_DAYS")), reader("PARENT_DAYS")) _
            , .StartDate = IIf(reader("TASK_START_DATE") Is DBNull.Value, Date.Now, reader("TASK_START_DATE")) _
            , .FinishDate = IIf(reader("JOB_REVISED_DATE") Is DBNull.Value, Date.Now, reader("JOB_REVISED_DATE")) _
            , .EmployeesResponsible = IIf(reader("EMP_CODE_LIST") Is DBNull.Value, "", reader("EMP_CODE_LIST")) _
            , .ClientsResponsible = IIf(reader("CLIENT_LNAME_LIST") Is DBNull.Value, "", reader("CLIENT_LNAME_LIST")) _
            , .FunctionComment = IIf(reader("FNC_COMMENTS") Is DBNull.Value, "", reader("FNC_COMMENTS")) _
            , .TrafficStatus = IIf(reader("TRF_DESC") Is DBNull.Value, "", reader("TRF_DESC")) _
            , .CompletedDate = IIf(reader("JOB_COMPLETED_DATE") Is DBNull.Value, "", reader("JOB_COMPLETED_DATE"))
        }
        timeline.StartDate = New Date(timeline.StartDate.Year, timeline.StartDate.Month, timeline.StartDate.Day, 0, 0, 1)
        timeline.FinishDate = New Date(timeline.FinishDate.Year, timeline.FinishDate.Month, timeline.FinishDate.Day, 23, 59, 59)
        Return timeline
    End Function

    Public Shared Function GetByJob(ByVal conStr As String, ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, Optional ByVal completed As Boolean = True) As Ganttline

        Dim lines As List(Of Ganttline) = New List(Of Ganttline)
        Dim oSQL As SqlHelper
        Dim parms(5) As SqlParameter

        Dim paramCliCode As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramCliCode.Value = JobNum
        parms(0) = paramCliCode

        Dim paramDivCode As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramDivCode.Value = JobComp
        parms(1) = paramDivCode

        Dim paramCliCode2 As New SqlParameter("@ORDERBY", SqlDbType.VarChar, 10)
        paramCliCode2.Value = "phase"
        parms(2) = paramCliCode2

        Dim paramMS As New SqlParameter("@MS", SqlDbType.Int)
        If milestone = True Then
            paramMS.Value = 1
        Else
            paramMS.Value = 0
        End If
        parms(3) = paramMS

        Dim paramCompleted As New SqlParameter("@Completed", SqlDbType.Int)
        If completed = True Then
            paramCompleted.Value = 1
        Else
            paramCompleted.Value = 0
        End If
        parms(4) = paramCompleted


        Dim reader As SqlDataReader = oSQL.ExecuteReader(conStr, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Gantt_ToExcel", parms)

        While reader.Read()
            lines.Add(Init(reader))
        End While

        If lines.Count > 0 Then
            Dim timeline As New Ganttline With {
           .CampaignTitle = lines(0).CampaignTitle _
           , .JobNumber = lines(0).JobNumber _
           , .JobDescription = lines(0).JobDescription _
           , .JobCompNumber = lines(0).JobCompNumber _
           , .JobCompDescription = lines(0).JobCompDescription _
           , .ClientName = lines(0).ClientName _
           , .ProductName = lines(0).ProductName _
           , .TrafficComment = lines(0).TrafficComment _
           , .FunctionComment = lines(0).FunctionComment _
           , .TrafficStatus = lines(0).TrafficStatus _
           , .Lines = ParseLines(lines)
       }
            Return timeline
        End If

    End Function

    Public Shared Function ParseLines(ByVal tasks As List(Of Ganttline)) As List(Of Ganttline)

        Dim parsedLines As List(Of Ganttline) = New List(Of Ganttline)

        Dim phase As String = ""
        For i As Integer = 0 To tasks.Count - 1
            If Trim(tasks(i).PhaseName) <> Trim(phase) Then
                phase = tasks(i).PhaseName
                Dim phaseLine As New Ganttline() With {.LineName = phase, .TaskType = TaskTypeEnum.Phase.ToString()}
                parsedLines.Add(phaseLine)
            End If

            Dim taskLine = tasks(i)
            taskLine.LineName = taskLine.TaskName
            taskLine.TaskType = TaskTypeEnum.Task.ToString()
            taskLine.CompletedDate = taskLine.CompletedDate

            If taskLine.EmployeesResponsible.Length > 0 And taskLine.ClientsResponsible.Length > 0 Then
                taskLine.Responsible = "Emp: " & taskLine.EmployeesResponsible
                taskLine.Responsible += " - Client: " & taskLine.ClientsResponsible
            ElseIf taskLine.EmployeesResponsible.Length > 0 Then
                taskLine.Responsible = taskLine.EmployeesResponsible
            ElseIf taskLine.ClientsResponsible.Length > 0 Then
                taskLine.Responsible = taskLine.ClientsResponsible
            End If

            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                taskLine.Dates = " " + MonthName(taskLine.StartDate.Month, False) & " " & taskLine.StartDate.Day
                If taskLine.StartDate <> taskLine.FinishDate Then
                    taskLine.Dates += " - "
                    If taskLine.StartDate.Month <> taskLine.FinishDate.Month Then taskLine.Dates += MonthName(taskLine.FinishDate.Month, False) & " "
                    taskLine.Dates += taskLine.FinishDate.Day.ToString()
                End If
                parsedLines.Add(taskLine)
            Else
                taskLine.Dates = " " & taskLine.StartDate.Day & " " + MonthName(taskLine.StartDate.Month, False)
                If taskLine.StartDate <> taskLine.FinishDate Then
                    taskLine.Dates += " - "
                    taskLine.Dates += taskLine.FinishDate.Day.ToString() & " "
                    If taskLine.StartDate.Month <> taskLine.FinishDate.Month Then taskLine.Dates += MonthName(taskLine.FinishDate.Month, False) & " "
                End If
                parsedLines.Add(taskLine)
            End If
        Next
        Return parsedLines
    End Function

    Public Function GetDates(ByVal tasks As Ganttline) As List(Of Date)
        Dim s As Date = Date.MaxValue
        For i As Integer = 0 To tasks.Lines.Count - 1
            If tasks.Lines(i).TaskType = "Phase" Then Continue For
            If tasks.Lines(i).StartDate < s And Not IsNothing(tasks.Lines(i).StartDate) Then
                s = tasks.Lines(i).StartDate
            End If
        Next

        Dim f As Date = Date.MinValue
        For i As Integer = 0 To tasks.Lines.Count - 1
            If tasks.Lines(i).TaskType = "Phase" Then Continue For
            If tasks.Lines(i).FinishDate > f And Not IsNothing(tasks.Lines(i).FinishDate) Then
                f = tasks.Lines(i).FinishDate
            End If
        Next
        s = PrevMonday(s)
        If s.Day > 7 Then s = s.AddDays(-7)
        If s.Day > 7 Then s = s.AddDays(-7)
        If s.Day > 7 Then s = s.AddDays(-7)
        If s.Day > 7 Then s = s.AddDays(-7)
        f = PrevMonday(f)
        f = New DateTime(f.Year, f.Month, Date.DaysInMonth(f.Year, f.Month), 23, 59, 59)
        Dim dates As List(Of Date) = New List(Of Date)
        While (s <= f)
            dates.Add(s)
            s = s.AddDays(7)
        End While
        Return dates
    End Function

    Public Function GetDatesByDay(ByVal tasks As Ganttline) As List(Of Date)
        Dim s As Date = Date.MaxValue
        For i As Integer = 0 To tasks.Lines.Count - 1
            If tasks.Lines(i).TaskType = "Phase" Then Continue For
            If tasks.Lines(i).StartDate < s And Not IsNothing(tasks.Lines(i).StartDate) Then
                s = tasks.Lines(i).StartDate
            End If
        Next

        Dim f As Date = Date.MinValue
        For i As Integer = 0 To tasks.Lines.Count - 1
            If tasks.Lines(i).TaskType = "Phase" Then Continue For
            If tasks.Lines(i).FinishDate > f And Not IsNothing(tasks.Lines(i).FinishDate) Then
                f = tasks.Lines(i).FinishDate
            End If
        Next
        s = PrevMonday(s)
        'If s.Day > 7 Then s = s.AddDays(-7)
        'If s.Day > 7 Then s = s.AddDays(-7)
        'If s.Day > 7 Then s = s.AddDays(-7)
        'If s.Day > 7 Then s = s.AddDays(-7)
        'f = PrevMonday(f)
        f = New Date(f.Year, f.Month, Date.DaysInMonth(f.Year, f.Month))
        Dim dates As List(Of Date) = New List(Of Date)
        While (s <= f)
            dates.Add(s)
            s = s.AddDays(1)
        End While
        Return dates
    End Function

    Public Function GetMonths(ByVal dates As List(Of Date)) As String
        Dim monthNames As List(Of String) = New List(Of String)
        Dim monthWeeks As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To dates.Count - 1
            Dim key As String = MonthName(dates(i).Month, False)
            If monthNames.Count = 0 Then
                monthNames.Add(key)
                monthWeeks.Add(1)
            ElseIf monthNames(monthNames.Count - 1) = key Then
                monthWeeks(monthNames.Count - 1) = monthWeeks(monthNames.Count - 1) + 1
            Else
                monthNames.Add(key)
                monthWeeks.Add(1)
            End If
        Next
        Dim monthString As String = ""
        For i As Integer = 0 To monthNames.Count - 1
            monthString += String.Format("<td colspan='{0}' class='monthCell'>{1}</td>", monthWeeks(i), monthNames(i))
        Next
        Return monthString
    End Function

    Public Function GetMonthsDay(ByVal dates As List(Of Date)) As String
        Dim monthNames As List(Of String) = New List(Of String)
        Dim monthWeeks As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To dates.Count - 1
            Dim key As String = MonthName(dates(i).Month, False)
            If monthNames.Count = 0 Then
                monthNames.Add(key)
                If dates(i).DayOfWeek = DayOfWeek.Sunday Or dates(i).DayOfWeek = DayOfWeek.Saturday Then
                    monthWeeks.Add(0)
                Else
                    monthWeeks.Add(1)
                End If
            ElseIf monthNames(monthNames.Count - 1) = key Then
                If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                    monthWeeks(monthNames.Count - 1) = monthWeeks(monthNames.Count - 1) + 1
                End If
            Else
                monthNames.Add(key)
                If dates(i).DayOfWeek = DayOfWeek.Sunday Or dates(i).DayOfWeek = DayOfWeek.Saturday Then
                    monthWeeks.Add(0)
                Else
                    monthWeeks.Add(1)
                End If
            End If
        Next
        Dim monthString As String = ""
        For i As Integer = 0 To monthNames.Count - 1
            monthString += String.Format("<td colspan='{0}' class='monthCell'>{1}</td>", monthWeeks(i), monthNames(i))
        Next
        Return monthString
    End Function

    Public Function GetWeekString(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "DateCell"
            Dim day As String = dates(i).Day
            If showDates = False Then day = ""

            Dim filled As Boolean = False


            If (start.ToShortDateString >= dates(i) And start <= AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (finish.ToShortDateString >= dates(i) And finish <= AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (start.ToShortDateString < dates(i) And finish > AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (finish.ToShortDateString = dates(i).ToShortDateString) Then filled = True

            If filled = True Then c = "DateCellFill"

            Dim pm As Date = PrevMonday(finish)
            If pm = dates(i) Then day = finish.Day

            If i = dates.Count - 1 Then
                c = "DateCellEnd"
                If filled = True Then c = "DateCellEndFill"
            ElseIf dates(i).Month <> dates(i + 1).Month Then
                c = "DateCellEnd"
                If filled = True Then c = "DateCellEndFill"
            End If

            weekString += String.Format("<td class='{0}'>{1}</td>", c, day)
        Next
        Return weekString
    End Function

    Public Function GetWeekStringDayofWeek(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "DateCell"
            If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                Dim day As String = LoGlo.GetCultureInfo.CurrentCulture.DateTimeFormat.DayNames(dates(i).DayOfWeek).First
                If showDates = False Then day = ""

                If i = dates.Count - 1 Then
                    c = "DateCellEnd"
                    'ElseIf dates(i).Month <> dates(i + 1).Month Then
                    '    c = "DateCellEnd"
                ElseIf dates(i).DayOfWeek = DayOfWeek.Friday Then
                    c = "DateCellEnd"
                End If

                weekString += String.Format("<td class='{0}'>{1}</td>", c, day)
            End If
        Next
        Return weekString
    End Function

    Public Function GetWeekStringbyDay(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "DateCell"
            Dim day As String = dates(i).Day
            If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                If showDates = False Then day = ""

                Dim filled As Boolean = False


                If (start.ToShortDateString >= dates(i) And start <= AddDays(dates(i).ToShortDateString)) Then filled = True
                If (finish.ToShortDateString >= dates(i) And finish <= AddDays(dates(i).ToShortDateString)) Then filled = True
                If (start.ToShortDateString < dates(i) And finish > AddDays(dates(i).ToShortDateString)) Then filled = True
                If (finish.ToShortDateString = dates(i).ToShortDateString) Then filled = True

                If filled = True Then c = "DateCellFill"

                'Dim pm As Date = PrevMonday(finish)
                'If pm = dates(i) Then day = finish.Day

                If i = dates.Count - 1 Then
                    c = "DateCellEnd"
                    If filled = True Then c = "DateCellEndFill"
                    'ElseIf dates(i).Month <> dates(i + 1).Month Then
                    '    c = "DateCellEnd"
                    '    If filled = True Then c = "DateCellEndFill"
                ElseIf dates(i).DayOfWeek = DayOfWeek.Friday Then
                    c = "DateCellEnd"
                    If filled = True Then c = "DateCellEndFill"
                End If

                weekString += String.Format("<td class='{0}'>{1}</td>", c, day)
            End If
        Next
        Return weekString
    End Function

    Public Function PrevMonday(ByVal val As Date) As Date
        Dim days As Integer = val.DayOfWeek
        If days = 0 Then
            days = -6
        Else
            days = days - 1
            days = days * -1
        End If
        Dim dDate As DateTime = val.AddDays(days)
        dDate = New Date(dDate.Year, dDate.Month, dDate.Day, 12, 0, 1)
        Return dDate
    End Function

    Public Function AddWeeks(ByVal val As Date, ByVal weeks As Integer) As Date
        Dim dDate As DateTime = val.AddDays(7 * weeks).AddMilliseconds(-1)
        Return dDate

    End Function

    Public Function AddWeeks(ByVal val As Date) As Date
        Return val.AddDays(7).AddMilliseconds(-1)
    End Function

    Public Function AddDays(ByVal val As Date) As Date
        Return val.AddDays(1).AddMilliseconds(-1)
    End Function

    Private Table As String = "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;'>"
    Private Heading1 As String = "<tr><td></td><td colspan='{0}' class='header1'>{1}</td></tr>"
    Private HeadingClient As String = "<tr><td></td><td colspan='{0}' class='header2'>{1}</td></tr>"
    Private Heading2 As String = "<tr><td></td><td colspan='{0}' class='header2'>{1}</td>{2}</tr>"
    Private Heading3 As String = "<tr><td></td><td class='headerCellStart'></td><td class='headerCell'>Days</td><td class='headerCell'>Dates</td><td class='headerCell'>Resource</td><td class='headerCellEnd'>Completed Date</td>{0}</tr>"
    Private Heading3TC As String = "<tr><td></td><td class='headerCellStart'></td><td class='headerCell'>Comments</td><td class='headerCell'>Days</td><td class='headerCell'>Dates</td><td class='headerCell'>Resource</td><td class='headerCellEnd'>Completed Date</td>{0}</tr>"
    Private Heading4 As String = "<tr><td></td><td class='headerCellStart'></td><td class='headerCell'></td><td class='headerCell'></td><td class='headerCell'></td><td class='headerCellEnd'></td>{0}</tr>"
    Private Heading4TC As String = "<tr><td></td><td class='headerCellStart'></td><td class='headerCell'></td><td class='headerCell'></td><td class='headerCell'></td><td class='headerCell'></td><td class='headerCellEnd'></td>{0}</tr>"
    Private PhaseRow As String = "<tr><td></td><td class='phaseCell' colspan='{0}'>{1}</td>{2}</tr>"
    Private TaskRow As String = "<tr><td></td><td class='taskCell'>{0}</td><td class='taskCell'>{1}</td><td class='taskCell' style='mso-number-format:""\@"";'>{2}</td><td class='taskCell'>{3}</td><td class='taskCellEnd'>{4}</td>{5}</tr>"
    Private TaskRowTC As String = "<tr><td></td><td class='taskCell'>{0}</td><td class='taskCell'>{1}</td><td class='taskCell'>{2}</td><td class='taskCell' style='mso-number-format:""\@"";'>{3}</td><td class='taskCell'>{4}</td><td class='taskCellEnd'>{5}</td>{6}</tr>"
    Private Footer As String = "<tr><td></td><td colspan='{0}' style='' class='footer'>{1}</td></tr>"
    Private EmptyRow As String = "<tr><td></td><td colspan='{0}'></td></tr>"

    Private TableExcel As String = "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;'>"
    Private Heading1Excel As String = "<tr><td></td><td colspan='{0}' style='font-size:16pt; font-weight:700; border:none; border-bottom:1.5pt solid black;'>{1}</td></tr>"
    Private Heading2Excel As String = "<tr><td></td><td colspan='{0}' style='font-weight:700; border-right:none; border-bottom:0.5pt solid black; border-right:1pt solid black; border-left:none;'>{1}</td>{2}</tr>"
    Private Heading3Excel As String = "<tr><td></td><td style='font-weight:700; border:0.5pt solid black; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'>Days</td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'>Dates</td><td style='font-weight:700; border:0.5pt solid black; border-right:1pt solid black; font-style:italic; text-align:center;'>Resource</td>{0}</tr>"
    Private Heading3ExcelTC As String = "<tr><td></td><td style='font-weight:700; border:0.5pt solid black; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'>Comments</td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'>Days</td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'>Dates</td><td style='font-weight:700; border:0.5pt solid black; border-right:1pt solid black; font-style:italic; text-align:center;'>Resource</td>{0}</tr>"
    Private Heading4Excel As String = "<tr><td></td><td style='font-weight:700; border:0.5pt solid black; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:1pt solid black; font-style:italic; text-align:center;'></td>{0}</tr>"
    Private Heading4ExcelTC As String = "<tr><td></td><td style='font-weight:700; border:0.5pt solid black; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:none; font-style:italic; text-align:center;'></td><td style='font-weight:700; border:0.5pt solid black; border-right:1pt solid black; font-style:italic; text-align:center;'></td>{0}</tr>"
    Private PhaseRowExcel As String = "<tr><td></td><td style='font-size:10pt; font-weight:700;	border:.5pt solid black; border-right:1pt solid black; border-top:none;	background:silver;' colspan='{0}'>{1}</td>{2}</tr>"
    Private TaskRowExcel As String = "<tr><td></td><td style='font-size:10pt; border:none; border-bottom:.5pt solid windowtext;	border-left:.5pt solid windowtext;'>{0}</td><td style='font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{1}</td><td style='mso-number-format:""\@""; font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{2}</td><td style='font-size:10pt; border:none;	border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;	border-right:1pt solid black;'>{3}</td>{4}</tr>"
    Private TaskRowExcelTC As String = "<tr><td></td><td style='font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{0}</td><td style='font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{1}</td><td style='font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{2}</td><td style='mso-number-format:""\@""; font-size:10pt; border:none; border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;'>{3}</td><td style='font-size:10pt; border:none;	border-bottom:.5pt solid windowtext; border-left:.5pt solid windowtext;	border-right:1pt solid black;'>{4}</td>{5}</tr>"
    Private FooterExcel As String = "<tr><td></td><td colspan='{0}' style='font-size:10pt; border:none;	border-top:1pt solid windowtext; height:200px; vertical-align:top; white-space:normal;' >{1}</td></tr>"

#Region " Aspose Excel "

    Private Function GenerateWorkbook(ByVal FileName As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Aspose.Cells.Workbook

        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim FullFileName As String = ""
        Dim ReportViewer As Webvantage.popReportViewer = Nothing
        Dim License As Aspose.Cells.License = Nothing

        Try

            License = New Aspose.Cells.License
            License.SetLicense("Aspose.Total.lic")

            Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

            If Workbook.Worksheets.Count = 0 Then

                Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

            End If

            If Not String.IsNullOrWhiteSpace(FileName) Then

                FileName = FileName.Trim()

            End If

            If FileName.ToUpper().EndsWith(".XLS") = False Then

                If Not FileName.Contains("Gantt Report - Multiple Jobs") Then

                    ReportViewer = New popReportViewer
                    FullFileName = ReportViewer.GetClientJobCompStandardString(JobNumber, JobComponentNumber, FileName)

                Else

                    FullFileName = FileName

                End If

                If Not String.IsNullOrWhiteSpace(FullFileName) Then

                    FullFileName = FullFileName & ".xls"

                End If

            Else

                FullFileName = FileName

            End If

            If Not String.IsNullOrWhiteSpace(FullFileName) Then

                Workbook.FileName = FullFileName

            End If

        Catch ex As Exception
            Workbook = Nothing
        Finally
            GenerateWorkbook = Workbook
        End Try

    End Function
    Public Function RenderProjectTimelineReportJobsWorkbook(ByVal ConnectionString As String, ByVal Jobs As String, ByVal Milestone As Boolean, ByVal ExcludeTaskComments As Boolean, ByVal ByDay As Boolean, Optional ByVal completed As Boolean = True) As Aspose.Cells.Workbook

        'objects
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim CurrentRow As Short = 0
        Dim JobComponents As String() = Nothing
        Dim JobNumber As String = Nothing
        Dim JobComponentNumber As String = Nothing
        Dim FileName As String = ""

        Try

            If Not String.IsNullOrWhiteSpace(Jobs) Then

                FileName = "Gantt Report - Multiple Jobs"

                If ByDay Then

                    FileName &= " By Day"

                End If

                Workbook = GenerateWorkbook(FileName, 0, 0)

                If Workbook IsNot Nothing Then

                    Worksheet = Workbook.Worksheets(0)

                    JobComponents = Jobs.Split("|").Where(Function(jc) Not String.IsNullOrWhiteSpace(jc)).ToArray

                    CurrentRow = 1

                    For Each JobComponent In JobComponents

                        Try

                            JobNumber = JobComponent.Split(",")(0)
                            JobComponentNumber = JobComponent.Split(",")(1)

                        Catch ex As Exception
                            JobNumber = Nothing
                            JobComponentNumber = Nothing
                        End Try

                        If Not String.IsNullOrWhiteSpace(JobNumber) Then

                            AddJobToWorksheet(Worksheet, ConnectionString, CurrentRow, JobNumber, JobComponentNumber, Milestone, ExcludeTaskComments, ByDay, completed)

                            CurrentRow += 1

                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            Workbook = Nothing
        Finally
            RenderProjectTimelineReportJobsWorkbook = Workbook
        End Try

    End Function
    Public Function RenderProjectTimelineReportWorkbook(ByVal ConnectionString As String, ByVal JobNumber As String, ByVal JobComponentNumber As String, ByVal Milestone As Boolean, ByVal ExcludeTaskComments As Boolean, ByVal ByDay As Boolean, Optional ByVal completed As Boolean = True) As Aspose.Cells.Workbook

        'objects
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim FileName As String = ""

        Try

            If Not String.IsNullOrWhiteSpace(JobNumber) AndAlso Not String.IsNullOrWhiteSpace(JobComponentNumber) Then

                FileName = "Gantt Report - Single Job"

                If ByDay Then

                    FileName &= " By Day"

                End If

                Workbook = GenerateWorkbook(FileName, JobNumber, JobComponentNumber)

                If Workbook IsNot Nothing Then

                    Worksheet = Workbook.Worksheets(0)

                    AddJobToWorksheet(Worksheet, ConnectionString, 1, JobNumber, JobComponentNumber, Milestone, ExcludeTaskComments, ByDay, completed)

                End If

            End If

        Catch ex As Exception
            Workbook = Nothing
        Finally
            RenderProjectTimelineReportWorkbook = Workbook
        End Try

    End Function
    Private Sub AddJobHeaderDataToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByRef CurrentRow As Integer, ByVal DataColumnsCount As Integer, ByVal DateColumnsCount As Integer, ByVal CampaignDescription As String,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal JobComponentDescription As String, ByVal ClientDescription As String, ByVal ProductDescription As String,
                                            Optional ByVal TrafficStatus As String = "", Optional ByVal StartDate As String = "", Optional ByVal EndDate As String = "")

        'objects
        Dim TotalColumns As Integer = DataColumnsCount + DateColumnsCount

        Worksheet.Cells(CurrentRow, 1).Value = CampaignDescription
        Worksheet.Cells.Merge(CurrentRow, 1, 1, TotalColumns)
        FormatHeading1(Worksheet.Cells(CurrentRow, 1))

        CurrentRow += 1

        Worksheet.Cells(CurrentRow, 1).Value = "Job: " & JobNumber.ToString.PadLeft(6, "0") & " - " & JobComponentNumber.ToString.PadLeft(2, "0") & " " & JobComponentDescription
        Worksheet.Cells.Merge(CurrentRow, 1, 1, TotalColumns)
        FormatHeading1(Worksheet.Cells(CurrentRow, 1))

        CurrentRow += 1

        Worksheet.Cells(CurrentRow, 1).Value = ClientDescription & " - " & ProductDescription
        Worksheet.Cells.Merge(CurrentRow, 1, 1, TotalColumns)
        FormatHeading2(Worksheet.Cells(CurrentRow, 1), False)

        CurrentRow += 1

        If Not String.IsNullOrWhiteSpace(TrafficStatus) Then

            Worksheet.Cells(CurrentRow, 1).Value = TrafficStatus
            Worksheet.Cells.Merge(CurrentRow, 1, 1, DataColumnsCount)
            FormatHeading2(Worksheet.Cells(CurrentRow, 1), False)

            ' Do not increment row here, next step add months to end of this row

        ElseIf Not String.IsNullOrWhiteSpace(StartDate) Then

            Worksheet.Cells(CurrentRow, 1).Value = StartDate & " - " & EndDate
            Worksheet.Cells.Merge(CurrentRow, 1, 1, DataColumnsCount)
            FormatHeading2(Worksheet.Cells(CurrentRow, 1), False)

            ' Do not increment row here, next step add months to end of this row

        End If

    End Sub
    Private Sub AddJobToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal ConnectionString As String, ByRef CurrentRow As Integer,
                                  ByVal JobNumber As String, ByVal JobComponentNumber As String, ByVal Milestone As Boolean, ByVal ExcludeTaskComments As Boolean, ByVal ByDay As Boolean, Optional ByVal completed As Boolean = True)

        Dim GanttLine As Ganttline = Nothing
        Dim Dates As Generic.List(Of Date) = Nothing
        Dim DataColumns As Short = 6
        Dim Offset As Short = 0
        Dim Job As Webvantage.Job = Nothing
        Dim TotalDates As Integer = 0

        Try

            GanttLine = GetByJob(ConnectionString, JobNumber, JobComponentNumber, Milestone, completed)

            If ExcludeTaskComments Then

                DataColumns = 5

            Else

                Offset = 1

            End If

            If GanttLine IsNot Nothing Then

                If ByDay Then

                    Dates = GetDatesByDay(GanttLine)
                    TotalDates = Dates.Where(Function(d) d.DayOfWeek <> DayOfWeek.Saturday AndAlso d.DayOfWeek <> DayOfWeek.Sunday).Count

                Else

                    Dates = GetDates(GanttLine)
                    TotalDates = Dates.Count()

                End If

                AddJobHeaderDataToWorksheet(Worksheet, CurrentRow, DataColumns, TotalDates, GanttLine.CampaignTitle, GanttLine.JobNumber, GanttLine.JobCompNumber, GanttLine.JobCompDescription,
                                            GanttLine.ClientName, GanttLine.ProductName, GanttLine.TrafficStatus, "", "")

                SetupMonths(Worksheet, Dates, ByDay, CurrentRow, DataColumns + 1)

                CurrentRow += 1

                If ByDay Then

                    FormatCells(Worksheet, CurrentRow, 1, 5 + Offset, True) 'blank

                    SetupWeeks(Worksheet, Dates, True, True, True, Nothing, Nothing, CurrentRow, DataColumns + 1)

                    CurrentRow += 1

                End If

                Worksheet.Cells(CurrentRow, 1).Value = ""

                If Not ExcludeTaskComments Then

                    Worksheet.Cells(CurrentRow, 2).Value = "Comments"

                End If

                Worksheet.Cells(CurrentRow, 2 + Offset).Value = "Days"
                Worksheet.Cells(CurrentRow, 3 + Offset).Value = "Dates"
                Worksheet.Cells(CurrentRow, 4 + Offset).Value = "Resource"
                Worksheet.Cells(CurrentRow, 5 + Offset).Value = "Completed Date"

                FormatCells(Worksheet, CurrentRow, 1, 5 + Offset, True)

                SetupWeeks(Worksheet, Dates, ByDay, False, True, Nothing, Nothing, CurrentRow, DataColumns + 1)

                CurrentRow += 1

                For Each Line In GanttLine.Lines

                    If Line.TaskType = "Phase" Then

                        Worksheet.Cells(CurrentRow, 1).Value = Line.LineName
                        Worksheet.Cells.Merge(CurrentRow, 1, 1, DataColumns)

                        FormatPhaseCell(Worksheet.Cells(CurrentRow, 1))

                        SetupWeeks(Worksheet, Dates, ByDay, False, False, Nothing, Nothing, CurrentRow, DataColumns + 1)

                    Else

                        Worksheet.Cells(CurrentRow, 1).Value = Line.LineName

                        If Not ExcludeTaskComments Then

                            Worksheet.Cells(CurrentRow, 2).Value = Line.FunctionComment

                        End If

                        Worksheet.Cells(CurrentRow, 2 + Offset).Value = Line.Days
                        Worksheet.Cells(CurrentRow, 3 + Offset).Value = Line.Dates
                        Worksheet.Cells(CurrentRow, 4 + Offset).Value = Line.Responsible
                        Worksheet.Cells(CurrentRow, 5 + Offset).Value = Line.CompletedDate

                        FormatCells(Worksheet, CurrentRow, 1, 5 + Offset, False)

                        SetupWeeks(Worksheet, Dates, ByDay, False, False, Line.StartDate, Line.FinishDate, CurrentRow, DataColumns + 1)

                    End If

                    CurrentRow += 1

                Next

                Worksheet.Cells(CurrentRow, 1).Value = GanttLine.TrafficComment
                Worksheet.Cells.Merge(CurrentRow, 1, 1, DataColumns + TotalDates)
                FormatFooterCell(Worksheet.Cells(CurrentRow, 1))

                Worksheet.AutoFitColumns(1, DataColumns)

            Else

                Job = New Webvantage.Job(ConnectionString)
                Job.GetJob(JobNumber, JobComponentNumber)

                If Job.JobComponent.START_DATE.ToString <> "1/1/0001 12:00:00 AM" AndAlso Job.JobComponent.JOB_FIRST_USE_DATE.ToString <> "1/1/0001 12:00:00 AM" Then

                    AddJobHeaderDataToWorksheet(Worksheet, CurrentRow, DataColumns, 0, Job.CampaignDesc, Job.JOB_NUMBER, Job.JobComponent.JOB_COMPONENT_NBR, Job.JobComponent.JOB_COMP_DESC, Job.ClientDesc, Job.ProductDesc, "", Job.JobComponent.START_DATE, Job.JobComponent.JOB_FIRST_USE_DATE)

                End If

                CurrentRow += 4

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub SetupMonths(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal Dates As List(Of Date), ByVal ByDay As Boolean, ByVal StartRow As Short, ByVal StartCell As Short)

        Dim MonthNames As List(Of String) = New List(Of String)
        Dim MonthWeeks As List(Of Integer) = New List(Of Integer)
        Dim Key As String = Nothing
        Dim Name As String = Nothing

        For Each [Date] In Dates

            Key = MonthName([Date].Month, False)

            If MonthNames.Count = 0 Then

                MonthNames.Add(Key)

                If ByDay Then

                    If [Date].DayOfWeek = DayOfWeek.Sunday OrElse [Date].DayOfWeek = DayOfWeek.Saturday Then

                        MonthWeeks.Add(0)

                    Else

                        MonthWeeks.Add(1)

                    End If

                Else

                    MonthWeeks.Add(1)

                End If

            ElseIf MonthNames.Last = Key Then

                If ByDay Then

                    If [Date].DayOfWeek <> DayOfWeek.Sunday AndAlso [Date].DayOfWeek <> DayOfWeek.Saturday Then

                        MonthWeeks(MonthNames.Count - 1) = MonthWeeks(MonthNames.Count - 1) + 1

                    End If

                Else

                    MonthWeeks(MonthWeeks.Count - 1) = MonthWeeks(MonthWeeks.Count - 1) + 1

                End If

            Else

                MonthNames.Add(Key)

                If ByDay Then

                    If [Date].DayOfWeek = DayOfWeek.Sunday OrElse [Date].DayOfWeek = DayOfWeek.Saturday Then

                        MonthWeeks.Add(0)

                    Else

                        MonthWeeks.Add(1)

                    End If

                Else

                    MonthWeeks.Add(1)

                End If

            End If

        Next

        For I = 0 To (MonthNames.Count - 1)

            Name = MonthNames(I)

            Worksheet.Cells(StartRow, StartCell).Value = Name
            Worksheet.Cells.Merge(StartRow, StartCell, 1, MonthWeeks(I))
            FormatHeading2(Worksheet.Cells(StartRow, StartCell), True)

            StartCell += MonthWeeks(I)

        Next

    End Sub
    Private Sub SetupWeeks(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal Dates As List(Of Date), ByVal ByDay As Boolean, ByVal ShowDayAbbreviation As Boolean, ByVal ShowDates As Boolean, ByVal Start As Date, ByVal Finish As Date, ByVal StartRow As Short, ByVal StartCell As Short)

        Dim Day As String = ""
        Dim Filled As Boolean = False
        Dim PreviousMonday As Date = Nothing
        Dim IsLast As Boolean = False
        Dim IsLastDateOfMonthOrWeek As Boolean = False
        Dim ErrorCheckOptionCollection As Aspose.Cells.ErrorCheckOptionCollection = Nothing
        Dim NewErrorIndex As Integer = 0
        Dim CurrentCell As Short = StartCell
        Dim Allowed As Boolean = True

        For Each [Date] In Dates

            Allowed = True

            If ByDay Then

                If [Date].DayOfWeek = DayOfWeek.Saturday OrElse [Date].DayOfWeek = DayOfWeek.Sunday Then

                    Allowed = False

                End If

            End If

            If Allowed Then

                Filled = False
                Day = [Date].Day

                If Not ShowDates Then

                    Day = ""

                End If

                If ([Date].Date >= Start.Date AndAlso [Date].Date <= Finish.Date) Then

                    Filled = True

                ElseIf Not ByDay Then

                    If [Date].Date <= Start.Date AndAlso AddWeeks([Date].Date) >= Start.Date Then

                        Filled = True

                    End If

                    If [Date].Date <= Finish.Date AndAlso AddWeeks([Date].Date) >= Finish.Date Then

                        Filled = True

                    End If

                End If

                If ByDay Then

                    If ShowDayAbbreviation Then

                        Day = [Date].DayOfWeek.ToString.Substring(0, 1)
                        Filled = False

                    End If

                Else

                    PreviousMonday = PrevMonday(Finish)

                    If PreviousMonday = [Date] Then

                        Day = Finish.Day

                    End If

                End If

                IsLast = False
                IsLastDateOfMonthOrWeek = False

                If Dates.IndexOf([Date]) = (Dates.Count - 1) Then

                    IsLast = True

                Else

                    If ByDay Then

                        If [Date].DayOfWeek = DayOfWeek.Friday Then

                            IsLastDateOfMonthOrWeek = True

                        End If

                    ElseIf [Date].Month <> Dates(Dates.IndexOf([Date]) + 1).Month Then

                        IsLastDateOfMonthOrWeek = True

                    End If

                End If

                Worksheet.Cells(StartRow, CurrentCell).Value = Day

                FormatWeekCell(Worksheet.Cells(StartRow, CurrentCell), IsLastDateOfMonthOrWeek, IsLast, Filled)

                CurrentCell += 1

            End If

        Next

        ErrorCheckOptionCollection = Worksheet.ErrorCheckOptions
        NewErrorIndex = ErrorCheckOptionCollection.Add()

        With ErrorCheckOptionCollection(NewErrorIndex)

            .SetErrorCheck(Aspose.Cells.ErrorCheckType.TextNumber, False)
            .AddRange(Aspose.Cells.CellArea.CreateCellArea(StartRow, StartCell, StartRow, CurrentCell - 1))

        End With

    End Sub
    Private Sub FormatHeading1(ByVal Cell As Aspose.Cells.Cell)

        Dim Style As Aspose.Cells.Style = Nothing

        'Style = Cell.GetStyle

        Style = Cell.Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header1)

        With Style

            '.Font.IsBold = True
            '.Pattern = Aspose.Cells.BackgroundType.Solid
            '.Font.Size = 16
            .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thick, Drawing.Color.Black)

            If Cell.IsMerged Then

                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thick, Drawing.Color.Black)

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatHeading2(ByVal Cell As Aspose.Cells.Cell, ByVal IsMonth As Boolean)

        Dim Style As Aspose.Cells.Style = Nothing

        'Style = Cell.GetStyle

        Style = Cell.Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header2)

        With Style

            '.Font.IsBold = True
            '.Pattern = Aspose.Cells.BackgroundType.Solid
            '.Font.Size = 11

            .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            If IsMonth Then

                .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
                .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)
                .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            Else

                .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            End If

            If Cell.IsMerged Then

                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

                If IsMonth Then

                    Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)
                    Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

                Else

                    Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

                End If

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatHeaderCell(ByVal Cell As Aspose.Cells.Cell, ByVal IsLast As Boolean)

        Dim Style As Aspose.Cells.Style = Nothing

        'Style = Cell.GetStyle

        Style = Cell.Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header2)

        With Style

            '.Font.IsBold = True
            '.Font.IsItalic = True
            .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            '.Pattern = Aspose.Cells.BackgroundType.Solid
            '.Font.Size = 11
            .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            If IsLast Then

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            Else

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatWeekCell(ByVal Cell As Aspose.Cells.Cell, ByVal IsLastDateOfMonth As Boolean, ByVal IsLast As Boolean, ByVal IsFilled As Boolean)

        Dim Style As Aspose.Cells.Style = Nothing

        If IsFilled Then

            Style = Cell.Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Accent1)

        Else

            Style = Cell.GetStyle

        End If

        Cell.Worksheet.Cells.SetColumnWidthPixel(Cell.Column, 20)

        With Style

            .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            .Pattern = Aspose.Cells.BackgroundType.Solid
            .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom
            .Font.Size = 8

            .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            If IsLastDateOfMonth OrElse IsLast Then

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            Else

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatPhaseCell(ByVal Cell As Aspose.Cells.Cell)

        Dim Style As Aspose.Cells.Style = Nothing

        Style = Cell.GetStyle

        Cell.Worksheet.Cells.Columns(Cell.Column).Width = 20

        With Style

            .Font.IsBold = True
            .Font.Size = 10
            .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom
            .Pattern = Aspose.Cells.BackgroundType.Solid

            .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            If Cell.IsMerged Then

                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            End If

            .ForegroundThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Background2, 0)
            .Font.ThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Text1, 0)

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatDataCell(ByVal Cell As Aspose.Cells.Cell, ByVal IsLast As Boolean)

        Dim Style As Aspose.Cells.Style = Nothing

        Style = Cell.GetStyle

        Cell.Worksheet.Cells.Columns(Cell.Column).Width = 20

        With Style

            .Font.Size = 10
            .Pattern = Aspose.Cells.BackgroundType.Solid
            .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom
            .Font.ThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Text1, 0)

            .SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)
            .SetBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            If IsLast Then

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            Else

                .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.Black)

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub FormatCells(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal Row As Short, ByVal CellStart As Short, ByVal CellEnd As Short, ByVal IsHeaderRow As Boolean)

        'objects
        Dim IsLast As Boolean = False

        For I = CellStart To CellEnd

            IsLast = If(I = CellEnd, True, False)

            If IsHeaderRow Then

                FormatHeaderCell(Worksheet.Cells(Row, I), IsLast)

            Else

                FormatDataCell(Worksheet.Cells(Row, I), IsLast)

            End If

        Next

    End Sub
    Private Sub FormatFooterCell(ByVal Cell As Aspose.Cells.Cell)

        Dim Style As Aspose.Cells.Style = Nothing

        Style = Cell.GetStyle

        With Style

            .Font.Size = 10
            .Pattern = Aspose.Cells.BackgroundType.Solid
            .Font.ThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Text1, 0)

            .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            If Cell.IsMerged Then

                Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, Drawing.Color.Black)

            End If

        End With

        Cell.SetStyle(Style)

    End Sub
    ''' <summary>
    ''' Prints theme colors for reference 
    ''' </summary>
    ''' <param name="Worksheet"></param>
    ''' <param name="Row"></param>
    Private Sub PrintThemeColors(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal Row As Short)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing

        For Each ThemeColorType In [Enum].GetValues(GetType(Aspose.Cells.ThemeColorType))

            Style = Worksheet.Cells(Row, 2).GetStyle

            With Style

                .Pattern = Aspose.Cells.BackgroundType.Solid
                .ForegroundThemeColor = New Aspose.Cells.ThemeColor(ThemeColorType, 0)

            End With

            Worksheet.Cells(Row, 2).SetStyle(Style)

            Worksheet.Cells(Row, 1).PutValue([Enum].GetName(GetType(Aspose.Cells.ThemeColorType), ThemeColorType))

            Row += 1

        Next

    End Sub

#End Region

    Public Function RenderProjectTimelineReport(ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String

        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()
        Dim tl = GetByJob(constr, JobNum, JobComp, milestone)
        If Not tl Is Nothing Then
            Dim dates As List(Of Date) = GetDates(tl)
            sb.Append(Table)
            If excludeTC = True Then
                sb.Append(String.Format(Heading1, 5 + dates.Count, tl.CampaignTitle))
                sb.Append(String.Format(Heading1, 5 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                sb.Append(String.Format(HeadingClient, 5 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                sb.Append(String.Format(Heading2, 5, tl.TrafficStatus, GetMonths(dates)))
                sb.Append(String.Format(Heading3, GetWeekString(dates, True, Nothing, Nothing)))
                For i As Integer = 0 To tl.Lines.Count - 1
                    If tl.Lines(i).TaskType = "Phase" Then
                        sb.Append(String.Format(PhaseRow, 5, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
                    Else
                        sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                    End If
                Next
                sb.Append(String.Format(Footer, 5 + dates.Count, tl.TrafficComment))
            Else
                sb.Append(String.Format(Heading1, 6 + dates.Count, tl.CampaignTitle))
                sb.Append(String.Format(Heading1, 6 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                sb.Append(String.Format(HeadingClient, 6 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                sb.Append(String.Format(Heading2, 6, tl.TrafficStatus, GetMonths(dates)))
                sb.Append(String.Format(Heading3TC, GetWeekString(dates, True, Nothing, Nothing)))
                For i As Integer = 0 To tl.Lines.Count - 1
                    If tl.Lines(i).TaskType = "Phase" Then
                        sb.Append(String.Format(PhaseRow, 6, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
                    Else
                        sb.Append(String.Format(TaskRowTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                    End If
                Next
                sb.Append(String.Format(Footer, 6 + dates.Count, tl.TrafficComment))
            End If
        End If
        Return sb.ToString()
    End Function

    Public Function RenderProjectTimelineReportByDay(ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String
        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()
        Dim tl = GetByJob(constr, JobNum, JobComp, milestone)
        If Not tl Is Nothing Then
            Dim dates As List(Of Date) = GetDatesByDay(tl)
            Dim count As Integer = 0
            For x As Integer = 0 To dates.Count - 1
                If dates(x).DayOfWeek <> DayOfWeek.Saturday And dates(x).DayOfWeek <> DayOfWeek.Sunday Then
                    count += 1
                End If
            Next

            sb.Append(Table)
            If excludeTC = True Then
                sb.Append(String.Format(Heading1, 5 + count, tl.CampaignTitle))
                sb.Append(String.Format(Heading1, 5 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                sb.Append(String.Format(HeadingClient, 5 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                sb.Append(String.Format(Heading2, 5, tl.TrafficStatus, GetMonthsDay(dates)))
                sb.Append(String.Format(Heading4, GetWeekStringDayofWeek(dates, True, Nothing, Nothing)))
                sb.Append(String.Format(Heading3, GetWeekStringbyDay(dates, True, Nothing, Nothing)))
                For i As Integer = 0 To tl.Lines.Count - 1
                    If tl.Lines(i).TaskType = "Phase" Then
                        sb.Append(String.Format(PhaseRow, 5, tl.Lines(i).LineName, GetWeekStringbyDay(dates, False, Nothing, Nothing)))
                    Else
                        sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekStringbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                    End If
                Next
                sb.Append(String.Format(Footer, 5 + count, tl.TrafficComment))
            Else
                sb.Append(String.Format(Heading1, 6 + count, tl.CampaignTitle))
                sb.Append(String.Format(Heading1, 6 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                sb.Append(String.Format(HeadingClient, 6 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                sb.Append(String.Format(Heading2, 6, tl.TrafficStatus, GetMonthsDay(dates)))
                sb.Append(String.Format(Heading4TC, GetWeekStringDayofWeek(dates, True, Nothing, Nothing)))
                sb.Append(String.Format(Heading3TC, GetWeekStringbyDay(dates, True, Nothing, Nothing)))
                For i As Integer = 0 To tl.Lines.Count - 1
                    If tl.Lines(i).TaskType = "Phase" Then
                        sb.Append(String.Format(PhaseRow, 6, tl.Lines(i).LineName, GetWeekStringbyDay(dates, False, Nothing, Nothing)))
                    Else
                        sb.Append(String.Format(TaskRowTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekStringbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                    End If
                Next
                sb.Append(String.Format(Footer, 6 + count, tl.TrafficComment))
            End If
        End If
        Return sb.ToString()
    End Function

    Public Function RenderProjectTimelineReportExcel(ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String
        Dim tl = GetByJob(constr, JobNum, JobComp, milestone)
        Dim dates As List(Of Date) = GetDates(tl)

        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()
        sb.Append(TableExcel)

        If excludeTC = True Then

            sb.Append(String.Format(Heading1Excel, 4 + dates.Count, tl.CampaignTitle))
            sb.Append(String.Format(Heading1Excel, 4 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
            sb.Append(String.Format(Heading2Excel, 4, tl.ClientName & " - " & tl.ProductName, GetMonthsExcel(dates)))
            sb.Append(String.Format(Heading3Excel, GetWeekStringExcel(dates, True, Nothing, Nothing)))
            For i As Integer = 0 To tl.Lines.Count - 1
                If tl.Lines(i).TaskType = "Phase" Then
                    sb.Append(String.Format(PhaseRowExcel, 4, tl.Lines(i).LineName, GetWeekStringExcel(dates, False, Nothing, Nothing)))
                Else
                    sb.Append(String.Format(TaskRowExcel, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekStringExcel(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                End If
            Next
            sb.Append(String.Format(FooterExcel, 4 + dates.Count, tl.TrafficComment))

        Else

            sb.Append(String.Format(Heading1Excel, 5 + dates.Count, tl.CampaignTitle))
            sb.Append(String.Format(Heading1Excel, 5 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
            sb.Append(String.Format(Heading2Excel, 5, tl.ClientName & " - " & tl.ProductName, GetMonthsExcel(dates)))
            sb.Append(String.Format(Heading3ExcelTC, GetWeekStringExcel(dates, True, Nothing, Nothing)))
            For i As Integer = 0 To tl.Lines.Count - 1
                If tl.Lines(i).TaskType = "Phase" Then
                    sb.Append(String.Format(PhaseRowExcel, 5, tl.Lines(i).LineName, GetWeekStringExcel(dates, False, Nothing, Nothing)))
                Else
                    sb.Append(String.Format(TaskRowExcelTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekStringExcel(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                End If
            Next
            sb.Append(String.Format(FooterExcel, 5 + dates.Count, tl.TrafficComment))

        End If

        Return sb.ToString()
    End Function

    Public Function RenderProjectTimelineReportExcelByDay(ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String
        Dim tl = GetByJob(constr, JobNum, JobComp, milestone)
        Dim dates As List(Of Date) = GetDatesByDay(tl)
        Dim count As Integer = 0
        For x As Integer = 0 To dates.Count - 1
            If dates(x).DayOfWeek <> DayOfWeek.Saturday And dates(x).DayOfWeek <> DayOfWeek.Sunday Then
                count += 1
            End If
        Next
        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()

        sb.Append(TableExcel)

        If excludeTC = True Then

            sb.Append(String.Format(Heading1Excel, 4 + count, tl.CampaignTitle))
            sb.Append(String.Format(Heading1Excel, 4 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
            sb.Append(String.Format(Heading2Excel, 4, tl.ClientName & " - " & tl.ProductName, GetMonthsExcelDay(dates)))
            sb.Append(String.Format(Heading4Excel, GetWeekStringExcelDayofWeek(dates, True, Nothing, Nothing)))
            sb.Append(String.Format(Heading3Excel, GetWeekStringExcelbyDay(dates, True, Nothing, Nothing)))
            For i As Integer = 0 To tl.Lines.Count - 1
                If tl.Lines(i).TaskType = "Phase" Then
                    sb.Append(String.Format(PhaseRowExcel, 4, tl.Lines(i).LineName, GetWeekStringExcelbyDay(dates, False, Nothing, Nothing)))
                Else
                    sb.Append(String.Format(TaskRowExcel, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekStringExcelbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                End If
            Next
            sb.Append(String.Format(FooterExcel, 4 + count, tl.TrafficComment))

        Else

            sb.Append(String.Format(Heading1Excel, 5 + count, tl.CampaignTitle))
            sb.Append(String.Format(Heading1Excel, 5 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
            sb.Append(String.Format(Heading2Excel, 5, tl.ClientName & " - " & tl.ProductName, GetMonthsExcelDay(dates)))
            sb.Append(String.Format(Heading4ExcelTC, GetWeekStringExcelDayofWeek(dates, True, Nothing, Nothing)))
            sb.Append(String.Format(Heading3ExcelTC, GetWeekStringExcelbyDay(dates, True, Nothing, Nothing)))
            For i As Integer = 0 To tl.Lines.Count - 1
                If tl.Lines(i).TaskType = "Phase" Then
                    sb.Append(String.Format(PhaseRowExcel, 5, tl.Lines(i).LineName, GetWeekStringExcelbyDay(dates, False, Nothing, Nothing)))
                Else
                    sb.Append(String.Format(TaskRowExcelTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekStringExcelbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                End If
            Next
            sb.Append(String.Format(FooterExcel, 5 + count, tl.TrafficComment))

        End If

        Return sb.ToString()
    End Function

    Public Function RenderProjectTimelineReportJobs(ByVal Jobs As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String
        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()

        sb.Append(Table)

        Dim jobcomp As New Job(HttpContext.Current.Session("ConnString"))
        Dim JC() As String = Jobs.Split("|")
        For j As Integer = 0 To JC.Length - 1
            Dim strJC() As String = JC(j).Split(",")
            If strJC(0) <> "" Then
                Dim tl = GetByJob(constr, strJC(0), strJC(1), milestone)
                If Not tl Is Nothing Then
                    Dim dates As List(Of Date) = GetDates(tl)
                    If excludeTC = True Then
                        sb.Append(String.Format(Heading1, 5 + dates.Count, tl.CampaignTitle))
                        sb.Append(String.Format(Heading1, 5 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                        sb.Append(String.Format(HeadingClient, 5 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                        sb.Append(String.Format(Heading2, 5, tl.TrafficStatus, GetMonths(dates)))
                        sb.Append(String.Format(Heading3, GetWeekString(dates, True, Nothing, Nothing)))
                        For i As Integer = 0 To tl.Lines.Count - 1
                            If tl.Lines(i).TaskType = "Phase" Then
                                sb.Append(String.Format(PhaseRow, 5, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
                            Else
                                sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                            End If
                        Next
                        sb.Append(String.Format(Footer, 5 + dates.Count, tl.TrafficComment))
                    Else
                        sb.Append(String.Format(Heading1, 6 + dates.Count, tl.CampaignTitle))
                        sb.Append(String.Format(Heading1, 6 + dates.Count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                        sb.Append(String.Format(HeadingClient, 6 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                        sb.Append(String.Format(Heading2, 6, tl.TrafficStatus, GetMonths(dates)))
                        sb.Append(String.Format(Heading3TC, GetWeekString(dates, True, Nothing, Nothing)))
                        For i As Integer = 0 To tl.Lines.Count - 1
                            If tl.Lines(i).TaskType = "Phase" Then
                                sb.Append(String.Format(PhaseRow, 6, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
                            Else
                                sb.Append(String.Format(TaskRowTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                            End If
                        Next
                        sb.Append(String.Format(Footer, 6 + dates.Count, tl.TrafficComment))
                    End If
                Else
                    jobcomp = New Job(HttpContext.Current.Session("ConnString"))
                    jobcomp.GetJob(strJC(0), strJC(1))
                    Dim str As String = jobcomp.JobComponent.START_DATE.ToString
                    If jobcomp.JobComponent.START_DATE.ToString <> "1/1/0001 12:00:00 AM" And jobcomp.JobComponent.JOB_FIRST_USE_DATE.ToString <> "1/1/0001 12:00:00 AM" Then
                        sb.Append(String.Format(Heading1, 6, jobcomp.CampaignDesc))
                        sb.Append(String.Format(Heading1, 6, "Job: " & jobcomp.JOB_NUMBER.ToString.PadLeft(6, "0") & " - " & jobcomp.JobComponent.JOB_COMPONENT_NBR.ToString.PadLeft(2, "0") & " " & jobcomp.JobComponent.JOB_COMP_DESC))
                        sb.Append(String.Format(Heading2, 6, jobcomp.ClientDesc & " - " & jobcomp.ProductDesc, ""))
                        sb.Append(String.Format(Heading2, 6, jobcomp.JobComponent.START_DATE & " - " & jobcomp.JobComponent.JOB_FIRST_USE_DATE, ""))
                        sb.Append(String.Format(Heading2, 6, "", ""))
                    End If
                End If
                
            End If
        Next

        Dim teststring As String = sb.ToString

        Return sb.ToString()
    End Function

    Public Function RenderProjectTimelineReportByDayJobs(ByVal Jobs As String, ByVal milestone As Boolean, ByVal constr As String, ByVal excludeTC As Boolean) As String

        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()

        sb.Append(Table)

        Dim jobcomp As New Job(HttpContext.Current.Session("ConnString"))
        Dim JC() As String = Jobs.Split("|")
        For j As Integer = 0 To JC.Length - 1
            Dim strJC() As String = JC(j).Split(",")
            If strJC(0) <> "" Then
                Dim tl = GetByJob(constr, strJC(0), strJC(1), milestone)
                If Not tl Is Nothing Then
                    Dim dates As List(Of Date) = GetDatesByDay(tl)
                    Dim count As Integer = 0
                    For x As Integer = 0 To dates.Count - 1
                        If dates(x).DayOfWeek <> DayOfWeek.Saturday And dates(x).DayOfWeek <> DayOfWeek.Sunday Then
                            count += 1
                        End If
                    Next

                    If excludeTC = True Then
                        sb.Append(String.Format(Heading1, 5 + count, tl.CampaignTitle))
                        sb.Append(String.Format(Heading1, 5 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                        sb.Append(String.Format(HeadingClient, 5 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                        sb.Append(String.Format(Heading2, 5, tl.TrafficStatus, GetMonthsDay(dates)))
                        sb.Append(String.Format(Heading4, GetWeekStringDayofWeek(dates, True, Nothing, Nothing)))
                        sb.Append(String.Format(Heading3, GetWeekStringbyDay(dates, True, Nothing, Nothing)))
                        For i As Integer = 0 To tl.Lines.Count - 1
                            If tl.Lines(i).TaskType = "Phase" Then
                                sb.Append(String.Format(PhaseRow, 5, tl.Lines(i).LineName, GetWeekStringbyDay(dates, False, Nothing, Nothing)))
                            Else
                                sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekStringbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                            End If
                        Next
                        sb.Append(String.Format(Footer, 5 + count, tl.TrafficComment))
                    Else
                        sb.Append(String.Format(Heading1, 6 + count, tl.CampaignTitle))
                        sb.Append(String.Format(Heading1, 6 + count, "Job: " & tl.JobNumber.ToString.PadLeft(6, "0") & " - " & tl.JobCompNumber.ToString.PadLeft(2, "0") & " " & tl.JobCompDescription))
                        sb.Append(String.Format(HeadingClient, 6 + dates.Count, tl.ClientName & " - " & tl.ProductName))
                        sb.Append(String.Format(Heading2, 6, tl.TrafficStatus, GetMonthsDay(dates)))
                        sb.Append(String.Format(Heading4TC, GetWeekStringDayofWeek(dates, True, Nothing, Nothing)))
                        sb.Append(String.Format(Heading3TC, GetWeekStringbyDay(dates, True, Nothing, Nothing)))
                        For i As Integer = 0 To tl.Lines.Count - 1
                            If tl.Lines(i).TaskType = "Phase" Then
                                sb.Append(String.Format(PhaseRow, 6, tl.Lines(i).LineName, GetWeekStringbyDay(dates, False, Nothing, Nothing)))
                            Else
                                sb.Append(String.Format(TaskRowTC, tl.Lines(i).LineName, tl.Lines(i).FunctionComment, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, tl.Lines(i).CompletedDate, GetWeekStringbyDay(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
                            End If
                        Next
                        sb.Append(String.Format(Footer, 6 + count, tl.TrafficComment))
                    End If
                Else
                    jobcomp = New Job(HttpContext.Current.Session("ConnString"))
                    jobcomp.GetJob(strJC(0), strJC(1))
                    Dim str As String = jobcomp.JobComponent.START_DATE.ToString
                    If jobcomp.JobComponent.START_DATE.ToString <> "1/1/0001 12:00:00 AM" And jobcomp.JobComponent.JOB_FIRST_USE_DATE.ToString <> "1/1/0001 12:00:00 AM" Then
                        sb.Append(String.Format(Heading1, 6, jobcomp.CampaignDesc))
                        sb.Append(String.Format(Heading1, 6, "Job: " & jobcomp.JOB_NUMBER.ToString.PadLeft(6, "0") & " - " & jobcomp.JobComponent.JOB_COMPONENT_NBR.ToString.PadLeft(2, "0") & " " & jobcomp.JobComponent.JOB_COMP_DESC))
                        sb.Append(String.Format(Heading2, 6, jobcomp.ClientDesc & " - " & jobcomp.ProductDesc, ""))
                        sb.Append(String.Format(Heading2, 6, jobcomp.JobComponent.START_DATE & " - " & jobcomp.JobComponent.JOB_FIRST_USE_DATE, ""))
                        sb.Append(String.Format(Heading2, 6, "", ""))
                    End If
                End If
            End If
        Next


        Return sb.ToString()
    End Function

    Public Function GetWeekStringExcel(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "border:0.5pt solid black; border-right:none;	text-align:center; width:20px; font-size:8pt;"
            Dim day As String = dates(i).Day
            If showDates = False Then day = ""

            Dim filled As Boolean = False


            If (start.ToShortDateString >= dates(i) And start <= AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (finish.ToShortDateString >= dates(i) And finish <= AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (start.ToShortDateString < dates(i) And finish > AddWeeks(dates(i).ToShortDateString)) Then filled = True
            If (finish.ToShortDateString = dates(i).ToShortDateString) Then filled = True

            If filled = True Then c = "border:0.5pt solid black; border-right:none; text-align:center; background:#99CCFF; width:25px; font-size:8pt;"

            Dim pm As Date = PrevMonday(finish)
            If pm = dates(i) Then day = finish.Day

            If i = dates.Count - 1 Then
                c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                If filled = True Then c = "background:#99CCFF; border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px; font-size:8pt;"
            ElseIf dates(i).Month <> dates(i + 1).Month Then
                c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                If filled = True Then c = "background:#99CCFF; border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px; font-size:8pt;"
            End If

            weekString += String.Format("<td style='{0}'>{1}</td>", c, day)
        Next
        Return weekString
    End Function

    Public Function GetMonthsExcel(ByVal dates As List(Of Date)) As String
        Dim monthNames As List(Of String) = New List(Of String)
        Dim monthWeeks As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To dates.Count - 1
            Dim key As String = MonthName(dates(i).Month, False)
            If monthNames.Count = 0 Then
                monthNames.Add(key)
                monthWeeks.Add(1)
            ElseIf monthNames(monthNames.Count - 1) = key Then
                monthWeeks(monthNames.Count - 1) = monthWeeks(monthNames.Count - 1) + 1
            Else
                monthNames.Add(key)
                monthWeeks.Add(1)
            End If
        Next
        Dim monthString As String = ""
        For i As Integer = 0 To monthNames.Count - 1
            monthString += String.Format("<td colspan='{0}' style='font-weight:700; text-align:center; border:1pt solid black; border-top:1.5pt solid black; border-left:none; width:80px;'>{1}</td>", monthWeeks(i), monthNames(i))
        Next
        Return monthString
    End Function

    Public Function GetWeekStringExcelbyDay(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "border:0.5pt solid black; border-right:none;	text-align:center; width:20px; font-size:8pt;"
            Dim day As String = dates(i).Day
            If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                If showDates = False Then day = ""

                Dim filled As Boolean = False


                If (start.ToShortDateString >= dates(i) And start <= AddDays(dates(i).ToShortDateString)) Then filled = True
                If (finish.ToShortDateString >= dates(i) And finish <= AddDays(dates(i).ToShortDateString)) Then filled = True
                If (start.ToShortDateString < dates(i) And finish > AddDays(dates(i).ToShortDateString)) Then filled = True
                If (finish.ToShortDateString = dates(i).ToShortDateString) Then filled = True

                If filled = True Then c = "border:0.5pt solid black; border-right:none; text-align:center; background:#99CCFF; width:25px; font-size:8pt;"

                'Dim pm As Date = PrevMonday(finish)
                'If pm = dates(i) Then day = finish.Day

                If i = dates.Count - 1 Then
                    c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                    If filled = True Then c = "background:#99CCFF; border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px; font-size:8pt;"
                    'ElseIf dates(i).Month <> dates(i + 1).Month Then
                    '    c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                    '    If filled = True Then c = "background:#99CCFF; border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px; font-size:8pt;"
                ElseIf dates(i).DayOfWeek = DayOfWeek.Friday Then
                    c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                    If filled = True Then c = "background:#99CCFF; border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px; font-size:8pt;"
                End If

                weekString += String.Format("<td style='{0}'>{1}</td>", c, day)
            End If
            
        Next
        Return weekString
    End Function

    Public Function GetMonthsExcelDay(ByVal dates As List(Of Date)) As String
        Dim monthNames As List(Of String) = New List(Of String)
        Dim monthWeeks As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To dates.Count - 1
            Dim key As String = MonthName(dates(i).Month, False)
            If monthNames.Count = 0 Then
                monthNames.Add(key)
                If dates(i).DayOfWeek = DayOfWeek.Sunday Or dates(i).DayOfWeek = DayOfWeek.Saturday Then
                    monthWeeks.Add(0)
                Else
                    monthWeeks.Add(1)
                End If
            ElseIf monthNames(monthNames.Count - 1) = key Then
                If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                    monthWeeks(monthNames.Count - 1) = monthWeeks(monthNames.Count - 1) + 1
                End If
            Else
                monthNames.Add(key)
                If dates(i).DayOfWeek = DayOfWeek.Sunday Or dates(i).DayOfWeek = DayOfWeek.Saturday Then
                    monthWeeks.Add(0)
                Else
                    monthWeeks.Add(1)
                End If
            End If
        Next
        Dim monthString As String = ""
        For i As Integer = 0 To monthNames.Count - 1
            monthString += String.Format("<td colspan='{0}' style='font-weight:700; text-align:center; border:1pt solid black; border-top:1.5pt solid black; border-left:none; width:80px;'>{1}</td>", monthWeeks(i), monthNames(i))
        Next
        Return monthString
    End Function

    Public Function GetWeekStringExcelDayofWeek(ByVal dates As List(Of Date), ByVal showDates As Boolean, ByVal start As Date, ByVal finish As Date) As String
        Dim weekString As String = ""
        For i As Integer = 0 To dates.Count - 1

            Dim c As String = "border:0.5pt solid black; border-right:none;	text-align:center; width:20px; font-size:8pt;"
            If dates(i).DayOfWeek <> DayOfWeek.Sunday And dates(i).DayOfWeek <> DayOfWeek.Saturday Then
                Dim day As String = LoGlo.GetCultureInfo.CurrentCulture.DateTimeFormat.DayNames(dates(i).DayOfWeek).First
                If showDates = False Then day = ""

                If i = dates.Count - 1 Then
                    c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                    'ElseIf dates(i).Month <> dates(i + 1).Month Then
                    '    c = "DateCellEnd"
                ElseIf dates(i).DayOfWeek = DayOfWeek.Friday Then
                    c = "border:0.5pt solid black; border-right:1pt solid black; text-align:center; width:20px;	font-size:8pt;"
                End If

                weekString += String.Format("<td style='{0}'>{1}</td>", c, day)
            End If
        Next
        Return weekString
    End Function

End Class

