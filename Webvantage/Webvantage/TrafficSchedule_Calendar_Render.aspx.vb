Imports System.Text
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Drawing

Public Class TrafficSchedule_Calendar_Render
    Inherits System.Web.UI.Page

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property



    Public JobNum As String
    Public JobComp As String
    Private oTasks As New TaskCollection
    Private oTask As Task

    Public Function RenderProjectCalendarReportWorkbook(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal Milestone As Boolean, Optional ByVal completed As Boolean = True) As Aspose.Cells.Workbook

        'Renders calendar report populating task descriptions from start date to revised date. Spans via highlight.
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim DataTable As DataTable = Nothing
        Dim DataRow As DataRow = Nothing
        Dim Task As Task = Nothing
        Dim CurrentRow As Integer = 0
        Dim startReportDate As Date
        Dim startReportDateStr As String
        Dim maxReportDate As Date = "1/1/1900"
        Dim maxReportDateStr As String
        Dim current_month As Integer = 0
        Dim current_day As Integer = 0
        Dim daysInMonth As Integer
        Dim currentCalendarDate As Date
        Dim NumberOfTasksPerWeek As Integer = 0
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim License As Aspose.Cells.License = Nothing
        Dim strColor(10) As String
        Dim ErrorCheckOptionCollection As Aspose.Cells.ErrorCheckOptionCollection = Nothing
        Dim ErrorIndex As Integer = 0
        Dim ReportViewer As New popReportViewer()
        Dim FileName As String = Nothing
        Dim Idx As Integer = Nothing
        Dim AccentIndex As Integer = Nothing
        Dim BuiltinStyleType As Aspose.Cells.BuiltinStyleType = Nothing
        Dim BuiltInStyleTypeName As String = Nothing

        strColor(0) = "EE6363" '"AFD8F8" 'Baby blue
        strColor(1) = "F6BD0F" 'gold
        strColor(2) = "EE82EE" 'violet
        strColor(3) = "8BBA00" 'green
        strColor(4) = "FF8000" 'orange
        strColor(5) = "AFD8F8" 'baby blue
        strColor(6) = "999999" 'gray
        strColor(7) = "BCED91" 'green mist
        strColor(8) = "FFC1C1" 'pink
        strColor(9) = "67C8FF" 'neon blue

        License = New Aspose.Cells.License
        License.SetLicense("Aspose.Total.lic")

        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

        If Workbook.Worksheets.Count = 0 Then

            Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

        End If

        Worksheet = Workbook.Worksheets(0)

        DataTable = oTrafficSchedule.GetScheduleCalendarRpt(JobNumber, JobComponentNumber, Milestone, completed)

        ' Collect all task data into collection and determine start/end dates of report
        If DataTable.Rows.Count > 0 Then

            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)

                Task = New Task

                With Task

                    .Description = DataRow("TASK_DESCRIPTION")

                    If Not IsDBNull(DataRow("TASK_START_DATE")) Then

                        .StartDate = DataRow("TASK_START_DATE")

                    Else

                        If Not IsDBNull(DataRow("JOB_REVISED_DATE")) Then

                            .StartDate = DataRow("JOB_REVISED_DATE")

                        End If

                    End If

                    If Not IsDBNull(DataRow("JOB_REVISED_DATE")) Then

                        .EndDate = DataRow("JOB_REVISED_DATE")

                    Else


                        If Not IsDBNull(DataRow("TASK_START_DATE")) Then

                            .EndDate = DataRow("TASK_START_DATE")

                        End If

                    End If

                    Idx = DataTable.Rows.IndexOf(DataRow)
                    AccentIndex = CInt(Math.Truncate((Idx Mod 24) / 6))

                    BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.Accent1.ToString.Replace("1", (Idx Mod 6) + 1)

                    If AccentIndex = 1 Then

                        BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.SixtyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                    ElseIf AccentIndex = 2 Then

                        BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.FortyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                    ElseIf AccentIndex = 3 Then

                        BuiltInStyleTypeName = Aspose.Cells.BuiltinStyleType.TwentyPercentAccent1.ToString.Replace("Accent1", BuiltInStyleTypeName)

                    End If

                    .Background = BuiltInStyleTypeName 'strColor(DataTable.Rows.IndexOf(DataRow) Mod 10)

                End With

                oTasks.Add(Task)

                If DataTable.Rows.IndexOf(DataRow) = 0 Then

                    startReportDateStr = LoGlo.FirstOfMonth(Task.StartDate.Year, Task.StartDate.Month) 'oTask.StartDate.Month.ToString() & "/1/" & oTask.StartDate.Year.ToString
                    startReportDate = CType(startReportDateStr, Date)

                End If

                If maxReportDate < Task.EndDate Then

                    maxReportDate = Task.EndDate

                End If

            Next

            daysInMonth = maxReportDate.DaysInMonth(maxReportDate.Year, maxReportDate.Month)
            maxReportDateStr = LoGlo.FormatDate(maxReportDate.Month.ToString() & "/" & daysInMonth.ToString() & "/" & maxReportDate.Year.ToString())
            maxReportDate = CType(maxReportDateStr, Date)

        End If

        currentCalendarDate = startReportDate
        current_month = startReportDate.Month

        CurrentRow = 0

        AddJobHeaderToWorksheet(Worksheet, CurrentRow, JobNumber, JobComponentNumber)

        CurrentRow += 1

        AddCalendarHeaderToWorksheet(Worksheet, CurrentRow, startReportDate)

        CurrentRow += 2

        Do While currentCalendarDate <= maxReportDate

            If current_month <> currentCalendarDate.Month Then

                If currentCalendarDate.DayOfWeek <> DayOfWeek.Sunday Then

                    'finish building out row
                    BuildBlankDayCells(Worksheet, currentCalendarDate, CurrentRow, False)

                End If

                CurrentRow += 7

                'then start new month
                AddJobHeaderToWorksheet(Worksheet, CurrentRow, JobNumber, JobComponentNumber)

                CurrentRow += 1

                AddCalendarHeaderToWorksheet(Worksheet, CurrentRow, currentCalendarDate)

                CurrentRow += 2

                If currentCalendarDate.DayOfWeek <> DayOfWeek.Sunday Then

                    'start building out row
                    BuildBlankDayCells(Worksheet, currentCalendarDate.AddDays(-1), CurrentRow, True)

                End If

            End If

            If currentCalendarDate = startReportDate OrElse
                currentCalendarDate.DayOfWeek = DayOfWeek.Sunday OrElse
                current_month <> currentCalendarDate.Month Then

                NumberOfTasksPerWeek = GetNumberOfTasksPerWeek(currentCalendarDate)

            End If

            BuildDayCell(Worksheet, currentCalendarDate, CurrentRow, NumberOfTasksPerWeek)

            If currentCalendarDate.DayOfWeek = System.DayOfWeek.Saturday Then

                CurrentRow += Math.Max(NumberOfTasksPerWeek + 1, 7)

            End If

            current_month = currentCalendarDate.Month
            currentCalendarDate = currentCalendarDate.AddDays(1)

        Loop

        If currentCalendarDate.DayOfWeek <> DayOfWeek.Sunday Then

            'finish building out row
            BuildBlankDayCells(Worksheet, currentCalendarDate, CurrentRow, False)

        End If

        Worksheet.AutoFitColumns()

        For I = 0 To 6

            Worksheet.Cells.SetColumnWidth(I, Worksheet.Cells.Columns.OfType(Of Aspose.Cells.Column).Select(Function(c) c.Width).Max)

        Next

        ErrorCheckOptionCollection = Worksheet.ErrorCheckOptions
        ErrorIndex = ErrorCheckOptionCollection.Add()

        With ErrorCheckOptionCollection(ErrorIndex)

            .SetErrorCheck(Aspose.Cells.ErrorCheckType.TextNumber, False)
            .AddRange(Aspose.Cells.CellArea.CreateCellArea(0, 0, CurrentRow, 6))

        End With

        FileName = ReportViewer.GetClientJobCompStandardString(JobNumber, JobComponentNumber, "Calendar Report")

        Workbook.FileName = FileName & ".xls"

        Return Workbook

    End Function
    Private Sub BuildDayCell(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal CellDate As Date, ByVal RowNumber As Integer, ByVal MaxNumberOfTasks As Integer)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim Tasks As Generic.List(Of Task) = Nothing
        Dim TotalRows As Integer = 0
        Dim Style As Aspose.Cells.Style = Nothing

        Tasks = oTasks.OfType(Of Task).Where(Function(t) t.StartDate <= CellDate AndAlso t.EndDate >= CellDate).ToList

        TotalRows = Math.Max((MaxNumberOfTasks + 1), 6)

        For I = 0 To Math.Max((MaxNumberOfTasks + 1), 6)

            Cell = Worksheet.Cells(RowNumber + I, CellDate.DayOfWeek)

            Worksheet.Cells.SetRowHeight(Cell.Row, 14.25)

            'Style = Cell.GetStyle
            Style = Nothing

            If I = 0 Then

                Cell.Value = CellDate.Day.ToString

                Style = Cell.GetStyle

            Else

                If Tasks.Count >= I Then

                    With Tasks(I - 1)

                        Cell.Value = .Description
                        'Style.ForegroundColor = New System.Drawing.ColorConverter().ConvertFromString("#" & .Background)

                        Dim BuiltinStyleType As Aspose.Cells.BuiltinStyleType = Nothing

                        Try

                            BuiltinStyleType = [Enum].Parse(GetType(Aspose.Cells.BuiltinStyleType), .Background)

                        Catch ex As Exception

                        End Try

                        If BuiltinStyleType = Aspose.Cells.BuiltinStyleType.TwentyPercentAccent3 Then 'something is wrong with that style is Aspose

                            Style = Cell.GetStyle

                            With Style

                                Style.Font.ThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Text1, 0)
                                Style.ForegroundThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Accent3, 0.8)

                            End With

                        Else

                            Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(BuiltinStyleType)

                        End If

                    End With

                Else

                    Cell.Value = ""

                End If

            End If

            If Style Is Nothing Then

                Style = Cell.GetStyle

            End If

            If Style IsNot Nothing Then

                If I = 0 Then

                    Style.SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)

                End If

                Style.Font.Size = 8
                Style.SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)
                Style.Pattern = Aspose.Cells.BackgroundType.Solid

                If I = TotalRows Then

                    Style.SetBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)

                End If

                Cell.SetStyle(Style)

            End If

        Next

    End Sub
    Private Sub BuildBlankDayCells(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal StartDate As Date, ByVal RowNumber As Integer, ByVal Reverse As Boolean)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim FirstBlankDate As Date = Nothing
        Dim LastBlankDate As Date = Nothing

        FirstBlankDate = StartDate
        LastBlankDate = StartDate

        If Reverse Then

            Do Until FirstBlankDate.DayOfWeek = DayOfWeek.Sunday

                FirstBlankDate = FirstBlankDate.AddDays(-1)

            Loop

        Else

            Do Until LastBlankDate.DayOfWeek = DayOfWeek.Saturday

                LastBlankDate = LastBlankDate.AddDays(1)

            Loop

        End If

        Do While FirstBlankDate <= LastBlankDate

            Cell = Worksheet.Cells(RowNumber, FirstBlankDate.DayOfWeek)

            Cell.Value = ""
            Worksheet.Cells.Merge(RowNumber, FirstBlankDate.DayOfWeek, 7, 1)

            Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)
            Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)
            Cell.GetMergedRange.SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Color.Black)

            FirstBlankDate = FirstBlankDate.AddDays(1)

        Loop

    End Sub
    Private Sub AddJobHeaderToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer)

        'objects
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim Style As Aspose.Cells.Style = Nothing

        If Worksheet IsNot Nothing Then

            Cell = Worksheet.Cells(RowNumber, 0)

            Cell.Value = "Job:  " & JobNumber.ToString.PadLeft(6, "0") & " - " & JobComponentNumber.ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNumber), CInt(JobComponentNumber))
            Worksheet.Cells.Merge(RowNumber, 0, 1, 7)

            'Style = Cell.GetStyle
            Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header1)
            Cell.GetMergedRange().SetStyle(Style)
            'With Style

            '    .Font.IsBold = True
            '    .Font.Size = 11
            '    .Pattern = Aspose.Cells.BackgroundType.Solid

            'End With

            Cell.SetStyle(Style)

        End If

    End Sub
    Private Sub AddCalendarHeaderToWorksheet(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer, ByVal CalendarDate As Date)

        'objects
        Dim CultureInfo As Globalization.CultureInfo = LoGlo.GetCultureInfo
        Dim Sunday As String = Nothing
        Dim Monday As String = Nothing
        Dim Tuesday As String = Nothing
        Dim Wednesday As String = Nothing
        Dim Thursday As String = Nothing
        Dim Friday As String = Nothing
        Dim Saturday As String = Nothing

        If Worksheet IsNot Nothing Then

            Worksheet.Cells(RowNumber, 0).Value = String.Format(CultureInfo, "{0:MMM}", CalendarDate)
            Worksheet.Cells.Merge(RowNumber, 0, 1, 7)

            If LoGlo.UserCultureGet() = "fr-FR" Then

                Sunday = "dimanche"
                Monday = "lundi"
                Tuesday = "mardi"
                Wednesday = "mercredi"
                Thursday = "jeudi"
                Friday = "vendredi"
                Saturday = "samedi"

            ElseIf LoGlo.UserCultureGet() = "es-ES" Then

                Sunday = "domingo"
                Monday = "lunes"
                Tuesday = "martes"
                Wednesday = "miércoles"
                Thursday = "jueves"
                Friday = "viernes"
                Saturday = "sábado"

            ElseIf LoGlo.UserCultureGet() = "zh-CN" Then

                Sunday = "星期日"
                Monday = "星期一"
                Tuesday = "星期二"
                Wednesday = "星期三"
                Thursday = "星期四"
                Friday = "星期五"
                Saturday = "星期六"

            ElseIf LoGlo.UserCultureGet() = "de" Then

                Sunday = "sonntag"
                Monday = "montag"
                Tuesday = "dienstag"
                Wednesday = "mittwoch"
                Thursday = "donnerstag"
                Friday = "freitag"
                Saturday = "samstag"

            Else

                Sunday = "Sunday"
                Monday = "Monday"
                Tuesday = "Tuesday"
                Wednesday = "Wednesday"
                Thursday = "Thursday"
                Friday = "Friday"
                Saturday = "Saturday"

            End If

            Worksheet.Cells(RowNumber + 1, 0).Value = Sunday
            Worksheet.Cells(RowNumber + 1, 1).Value = Monday
            Worksheet.Cells(RowNumber + 1, 2).Value = Tuesday
            Worksheet.Cells(RowNumber + 1, 3).Value = Wednesday
            Worksheet.Cells(RowNumber + 1, 4).Value = Thursday
            Worksheet.Cells(RowNumber + 1, 5).Value = Friday
            Worksheet.Cells(RowNumber + 1, 6).Value = Saturday

            FormatCalendarHeader(Worksheet, RowNumber)

        End If

    End Sub
    Private Function GetNumberOfTasksPerWeek(ByVal StartDate As Date) As Integer

        'objects
        Dim WeekStart As Date = Nothing
        Dim WeekEnd As Date = Nothing
        Dim MaxTasks As Integer = Nothing
        Dim DayTasks As Integer = Nothing

        WeekStart = StartDate

        If WeekStart.DayOfWeek <> DayOfWeek.Sunday Then

            Do Until WeekStart.DayOfWeek = DayOfWeek.Sunday OrElse WeekStart.AddDays(-1).Month <> WeekStart.Month

                WeekStart = WeekStart.AddDays(-1)

            Loop

        End If

        WeekEnd = WeekStart

        If WeekEnd.DayOfWeek <> DayOfWeek.Saturday Then

            Do Until WeekEnd.DayOfWeek = DayOfWeek.Saturday OrElse WeekEnd.AddDays(1).Month <> WeekStart.Month

                WeekEnd = WeekEnd.AddDays(1)

            Loop

        End If

        For I = 0 To ((WeekEnd - WeekStart).Days + 1)

            DayTasks = oTasks.OfType(Of Task).Where(Function(t) t.StartDate <= WeekStart.AddDays(I) AndAlso t.EndDate >= WeekStart.AddDays(I)).Count()

            If DayTasks > MaxTasks Then

                MaxTasks = DayTasks

            End If

        Next

        Return MaxTasks

    End Function
    Private Sub FormatCalendarHeader(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal RowNumber As Integer)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing
        Dim Cell As Aspose.Cells.Cell = Nothing

        Cell = Worksheet.Cells(RowNumber, 0)

        'Style = Cell.GetStyle

        Style = Worksheet.Workbook.Styles.CreateBuiltinStyle(Aspose.Cells.BuiltinStyleType.Header3)

        With Style

            '.Font.IsBold = True
            '.Font.Size = 11
            .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom

        End With

        Cell.GetMergedRange().SetStyle(Style)
        Cell.SetStyle(Style)

        For I = 0 To 6

            Cell = Worksheet.Cells(RowNumber + 1, I)

            Style = Cell.GetStyle

            With Style

                .Font.Size = 8
                .Font.IsBold = True
                .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
                .VerticalAlignment = Aspose.Cells.TextAlignmentType.Bottom
                .Pattern = Aspose.Cells.BackgroundType.Solid
                '.ForegroundColor = New System.Drawing.ColorConverter().ConvertFromString("#99CCFF")
                .ForegroundThemeColor = New Aspose.Cells.ThemeColor(Aspose.Cells.ThemeColorType.Background2, 0)

                .SetBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Medium, System.Drawing.Color.Black)

                If I <> 6 Then

                    .SetBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, System.Drawing.Color.Black)

                End If

            End With

            Cell.SetStyle(Style)

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing

        Try

            JobNum = Request.QueryString("job")
            JobComp = Request.QueryString("jobcomp")

        Catch ex As Exception

        End Try

        Try

            Workbook = RenderProjectCalendarReportWorkbook(CInt(JobNum), CInt(JobComp), Request.QueryString("ms"), Request.QueryString("completed"))

            Using MemoryStream = New System.IO.MemoryStream

                XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)

                Workbook.Save(MemoryStream, XlsSaveOptions)

                With HttpContext.Current.Response

                    .Clear()
                    .Buffer = True
                    .ContentType = "application/vnd.ms-excel"
                    .AppendHeader("Content-Disposition", "attachment; filename=" & Workbook.FileName)
                    .Charset = ""
                    .BinaryWrite(MemoryStream.ToArray())

                End With

                HttpContext.Current.ApplicationInstance.CompleteRequest()

                Try

                    HttpContext.Current.Response.End()

                Catch ex As Exception

                End Try

            End Using

        Catch ex As Exception

        End Try

        'Dim report As Literal = New Literal()
        'report.Text = RenderProjectCalendarReport2(JobNum, JobComp)
        'PanelCalendar.Controls.Add(report)

        'Dim Filename As String = ""
        'Dim f As New popReportViewer()
        'Filename = f.GetClientJobCompStandardString(JobNum, JobComp, "Calendar Report")

        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/vnd.ms-excel"
        'Response.AddHeader("content-disposition", "attachment;filename=" & Filename & ".xls")
        'Response.Charset = ""
        Me.EnableViewState = False

    End Sub

    Private Function RenderProjectCalendarReport(ByVal JobNum As String, ByVal JobComp As String) As String
        'Renders calendar report populating task descriptions on job revised date only
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As New DataTable
        Dim idx As Integer
        Dim thisDate As Date
        Dim endDate As Date
        Dim current_month As Integer = 0
        Dim current_day As Integer = 0
        Dim current_year As Integer = 0
        Dim data_month As Integer = 0
        Dim data_day As Integer = 0
        Dim data_year As Integer = 0
        Dim daysInMonth As Integer
        Dim current_daysInMonth As Integer
        Dim MonthDayIdx As Integer = 0
        Dim Sun, Mon, Tue, Wed, Thu, Fri, Sat As String
        Dim SunCt, MonCt, TueCt, WedCt, ThuCt, FriCt, SatCt As Integer
        Dim dayOfWeek As System.DayOfWeek
        Dim firstDayOfMonthStr As String
        Dim firstDayOfMonth As Date
        Dim firstDayOfWeek As System.DayOfWeek
        Dim CurrentWeekday As System.DayOfWeek
        Dim TaskDescription As String
        Dim currentCalendarDate As Date
        Dim currentCalendarDateStr As String
        Dim currentCalendarWeekOfYear As Integer = 0
        Dim currentWeekOfYear As Integer = 0
        Dim dataWeekOfYear As Integer = 0

        Dim sb As System.Text.StringBuilder = New StringBuilder()
        Sun = ""
        Mon = ""
        Tue = ""
        Wed = ""
        Thu = ""
        Fri = ""
        Sat = ""
        SunCt = 0
        MonCt = 0
        TueCt = 0
        WedCt = 0
        ThuCt = 0
        FriCt = 0
        SatCt = 0

        sb.Append(Table)

        dt = oTrafficSchedule.GetScheduleCalendarRpt(JobNum, JobComp, Request.QueryString("ms"), Request.QueryString("completed"))

        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                TaskDescription = dt.Rows(j)("TASK_DESCRIPTION")
                endDate = dt.Rows(j)("JOB_REVISED_DATE")
                thisDate = dt.Rows(j)("TASK_START_DATE")

                data_month = thisDate.Month
                data_year = thisDate.Year
                data_day = thisDate.Day
                dataWeekOfYear = Int(thisDate.DayOfYear / 7) + 1

                daysInMonth = thisDate.DaysInMonth(data_year, data_month)

                If data_month <> current_month Then
                    If j > 0 Then
                        'Finish off current month 
                        Do While MonthDayIdx < daysInMonth
                            MonthDayIdx += 1
                            currentCalendarDateStr = current_month.ToString() & "/" & MonthDayIdx.ToString() & "/" & current_year.ToString
                            currentCalendarDate = CType(currentCalendarDateStr, Date)
                            currentCalendarWeekOfYear = Int(currentCalendarDate.DayOfYear / 7) + 1

                            If currentCalendarWeekOfYear <> currentWeekOfYear Then
                                sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))
                                Sun = ""
                                Mon = ""
                                Tue = ""
                                Wed = ""
                                Thu = ""
                                Fri = ""
                                Sat = ""
                                SunCt = 0
                                MonCt = 0
                                TueCt = 0
                                WedCt = 0
                                ThuCt = 0
                                FriCt = 0
                                SatCt = 0
                                currentWeekOfYear = currentCalendarWeekOfYear
                            End If

                            CurrentWeekday = currentCalendarDate.DayOfWeek
                            Select Case CurrentWeekday
                                Case System.DayOfWeek.Sunday
                                    Sun = MonthDayIdx.ToString
                                    SunCt += 1
                                Case System.DayOfWeek.Monday
                                    Mon = MonthDayIdx.ToString
                                    MonCt += 1
                                Case System.DayOfWeek.Tuesday
                                    Tue = MonthDayIdx.ToString
                                    TueCt += 1
                                Case System.DayOfWeek.Wednesday
                                    Wed = MonthDayIdx.ToString
                                    WedCt += 1
                                Case System.DayOfWeek.Thursday
                                    Thu = MonthDayIdx.ToString
                                    ThuCt += 1
                                Case System.DayOfWeek.Friday
                                    Fri = MonthDayIdx.ToString
                                    FriCt += 1
                                Case System.DayOfWeek.Saturday
                                    Sat = MonthDayIdx.ToString
                                    SatCt += 1
                            End Select

                            If MonthDayIdx = current_daysInMonth And currentCalendarWeekOfYear = currentWeekOfYear Then
                                sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))
                                Sun = ""
                                Mon = ""
                                Tue = ""
                                Wed = ""
                                Thu = ""
                                Fri = ""
                                Sat = ""
                                SunCt = 0
                                MonCt = 0
                                TueCt = 0
                                WedCt = 0
                                ThuCt = 0
                                FriCt = 0
                                SatCt = 0
                                currentWeekOfYear = currentCalendarWeekOfYear
                            End If

                        Loop
                    End If

                    MonthDayIdx = 1
                    current_month = data_month
                    current_year = data_year
                    currentCalendarDateStr = data_month.ToString() & "/" & MonthDayIdx.ToString() & "/" & data_year.ToString
                    currentCalendarDate = CType(currentCalendarDateStr, Date)
                    currentCalendarWeekOfYear = Int(currentCalendarDate.DayOfYear / 7) + 1
                    currentWeekOfYear = currentCalendarWeekOfYear
                    current_daysInMonth = daysInMonth


                    sb.Append(String.Format(headerCalendar1, "7", "Job:  " & CInt(JobNum).ToString.PadLeft(6, "0") & " - " & CInt(JobComp).ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNum), CInt(JobComp))))
                    sb.Append(String.Format(headerCalendar2, "7", GetMonthName(current_month)))

                    sb.Append(String.Format(DayCellsHeader, "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"))
                    Sun = ""
                    Mon = ""
                    Tue = ""
                    Wed = ""
                    Thu = ""
                    Fri = ""
                    Sat = ""
                    SunCt = 0
                    MonCt = 0
                    TueCt = 0
                    WedCt = 0
                    ThuCt = 0
                    FriCt = 0
                    SatCt = 0
                End If
                '***********************End Of New Month logic

                Do While MonthDayIdx < data_day And MonthDayIdx <= daysInMonth
                    CurrentWeekday = currentCalendarDate.DayOfWeek

                    Select Case CurrentWeekday
                        Case System.DayOfWeek.Sunday
                            If Sun = "" Then
                                Sun = MonthDayIdx.ToString
                                SunCt += 1
                            End If
                        Case System.DayOfWeek.Monday
                            If Mon = "" Then
                                Mon = MonthDayIdx.ToString
                                MonCt += 1
                            End If
                        Case System.DayOfWeek.Tuesday
                            If Tue = "" Then
                                Tue = MonthDayIdx.ToString
                                TueCt += 1
                            End If
                        Case System.DayOfWeek.Wednesday
                            If Wed = "" Then
                                Wed = MonthDayIdx.ToString
                                WedCt += 1
                            End If
                        Case System.DayOfWeek.Thursday
                            If Thu = "" Then
                                Thu = MonthDayIdx.ToString
                                ThuCt += 1
                            End If
                        Case System.DayOfWeek.Friday
                            If Fri = "" Then
                                Fri = MonthDayIdx.ToString
                                FriCt += 1
                            End If
                        Case System.DayOfWeek.Saturday
                            If Sat = "" Then
                                Sat = MonthDayIdx.ToString
                                SatCt += 1
                            End If
                    End Select

                    MonthDayIdx += 1
                    current_month = data_month
                    current_year = data_year
                    currentCalendarDateStr = data_month.ToString() & "/" & MonthDayIdx.ToString() & "/" & data_year.ToString
                    currentCalendarDate = CType(currentCalendarDateStr, Date)
                    currentCalendarWeekOfYear = Int(currentCalendarDate.DayOfYear / 7) + 1

                    If currentCalendarWeekOfYear <> currentWeekOfYear Then
                        sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))

                        Sun = ""
                        Mon = ""
                        Tue = ""
                        Wed = ""
                        Thu = ""
                        Fri = ""
                        Sat = ""
                        SunCt = 0
                        MonCt = 0
                        TueCt = 0
                        WedCt = 0
                        ThuCt = 0
                        FriCt = 0
                        SatCt = 0
                        currentWeekOfYear = currentCalendarWeekOfYear
                    End If
                Loop

                If dataWeekOfYear <> currentWeekOfYear Then
                    sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))

                    currentWeekOfYear = dataWeekOfYear
                End If

                dayOfWeek = thisDate.DayOfWeek
                Select Case dayOfWeek
                    Case System.DayOfWeek.Sunday
                        If current_day <> data_day Then
                            Sun = data_day.ToString
                            current_day = data_day
                            SunCt += 1
                        End If
                        Sun &= "<br />" & TaskDescription
                        SunCt += 1

                    Case System.DayOfWeek.Monday
                        If current_day <> data_day Then
                            Mon = data_day.ToString
                            current_day = data_day
                            MonCt += 1
                        End If
                        Mon &= "<br />" & TaskDescription
                        MonCt += 1

                    Case System.DayOfWeek.Tuesday
                        If current_day <> data_day Then
                            Tue = data_day.ToString
                            current_day = data_day
                            TueCt += 1
                        End If
                        Tue &= "<br />" & TaskDescription
                        TueCt += 1

                    Case System.DayOfWeek.Wednesday
                        If current_day <> data_day Then
                            Wed = data_day.ToString
                            current_day = data_day
                            WedCt += 1
                        End If
                        Wed &= "<br />" & TaskDescription
                        WedCt += 1

                    Case System.DayOfWeek.Thursday
                        If current_day <> data_day Then
                            Thu = data_day.ToString
                            current_day = data_day
                            ThuCt += 1
                        End If
                        Thu &= "<br />" & TaskDescription
                        ThuCt += 1

                    Case System.DayOfWeek.Friday
                        If current_day <> data_day Then
                            Fri = data_day.ToString
                            current_day = data_day
                            FriCt += 1
                        End If
                        Fri &= "<br />" & TaskDescription
                        FriCt += 1

                    Case System.DayOfWeek.Saturday
                        If current_day <> data_day Then
                            Sat = data_day.ToString
                            current_day = data_day
                            SatCt += 1
                        End If
                        Sat &= "<br />" & TaskDescription
                        SatCt += 1
                End Select
            Next

            'Finish up last month 
            Do While MonthDayIdx < daysInMonth
                MonthDayIdx += 1
                currentCalendarDateStr = current_month.ToString() & "/" & MonthDayIdx.ToString() & "/" & current_year.ToString
                currentCalendarDate = CType(currentCalendarDateStr, Date)
                currentCalendarWeekOfYear = Int(currentCalendarDate.DayOfYear / 7) + 1

                If currentCalendarWeekOfYear <> currentWeekOfYear Then
                    sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))

                    Sun = ""
                    Mon = ""
                    Tue = ""
                    Wed = ""
                    Thu = ""
                    Fri = ""
                    Sat = ""
                    SunCt = 0
                    MonCt = 0
                    TueCt = 0
                    WedCt = 0
                    ThuCt = 0
                    FriCt = 0
                    SatCt = 0
                    currentWeekOfYear = currentCalendarWeekOfYear
                End If

                CurrentWeekday = currentCalendarDate.DayOfWeek
                Select Case CurrentWeekday
                    Case System.DayOfWeek.Sunday
                        If Sun = "" Then
                            Sun = MonthDayIdx.ToString
                            SunCt += 1
                        End If
                    Case System.DayOfWeek.Monday
                        If Mon = "" Then
                            Mon = MonthDayIdx.ToString
                            MonCt += 1
                        End If
                    Case System.DayOfWeek.Tuesday
                        If Tue = "" Then
                            Tue = MonthDayIdx.ToString
                            TueCt += 1
                        End If
                    Case System.DayOfWeek.Wednesday
                        If Wed = "" Then
                            Wed = MonthDayIdx.ToString
                            WedCt += 1
                        End If
                    Case System.DayOfWeek.Thursday
                        If Thu = "" Then
                            Thu = MonthDayIdx.ToString
                            ThuCt += 1
                        End If
                    Case System.DayOfWeek.Friday
                        If Fri = "" Then
                            Fri = MonthDayIdx.ToString
                            FriCt += 1
                        End If
                    Case System.DayOfWeek.Saturday
                        If Sat = "" Then
                            Sat = MonthDayIdx.ToString
                            SatCt += 1
                        End If
                End Select

                If MonthDayIdx = current_daysInMonth And currentCalendarWeekOfYear = currentWeekOfYear Then
                    sb.Append(String.Format(WeekCells, PadDay(Sun, SunCt), PadDay(Mon, MonCt), PadDay(Tue, TueCt), PadDay(Wed, WedCt), PadDay(Thu, ThuCt), PadDay(Fri, FriCt), PadDay(Sat, SatCt)))

                    Sun = ""
                    Mon = ""
                    Tue = ""
                    Wed = ""
                    Thu = ""
                    Fri = ""
                    Sat = ""
                    SunCt = 0
                    MonCt = 0
                    TueCt = 0
                    WedCt = 0
                    ThuCt = 0
                    FriCt = 0
                    SatCt = 0
                    currentWeekOfYear = currentCalendarWeekOfYear
                End If

            Loop

        End If

        sb.Append("</tr></table>")

        Return sb.ToString

    End Function

    Private m_Rnd As New Random
    Public Function RandomRGBColor() As String
        'Return Color.FromArgb(255, _
        '    m_Rnd.Next(0, 255), _
        '    m_Rnd.Next(0, 255), _
        '    m_Rnd.Next(0, 255))

        Dim RandomClass As New Random()
        Dim intR, intG, intB As Integer
        intR = RandomClass.Next(0, 256)
        intG = RandomClass.Next(0, 256)
        intB = RandomClass.Next(0, 256)

        Dim hexR As String
        Dim hexG As String
        Dim hexB As String
        hexR = intR.ToString("X").PadLeft(2, "0"c)
        hexG = intG.ToString("X").PadLeft(2, "0"c)
        hexB = intB.ToString("X").PadLeft(2, "0"c)

        Dim strColor As String
        strColor = "#" & hexR & hexG & hexB

        Return strColor
    End Function

    Public Function RenderProjectCalendarReport2(ByVal JobNum As String, ByVal JobComp As String) As String
        'Renders calendar report populating task descriptions from start date to revised date. Spans via highlight.
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As New DataTable
        Dim thisDate As Date
        Dim startReportDate As Date
        Dim startReportDateStr As String
        Dim maxReportDate As Date = "1/1/1900"
        Dim maxReportDateStr As String
        Dim current_month As Integer = 0
        Dim current_day As Integer = 0
        Dim data_month As Integer = 0
        Dim data_day As Integer = 0
        Dim daysInMonth As Integer
        Dim Sun, Mon, Tue, Wed, Thu, Fri, Sat As String
        Dim CurrentWeekday As System.DayOfWeek
        Dim currentCalendarDate As Date
        Dim currentCalendarDateStr As String
        Dim currentCalendarWeekOfYear As Integer = 0
        Dim currentWeekOfYear As Integer = 0
        Dim lineCount As Integer
        Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo

        Dim strColor(10) As String
        strColor(0) = "EE6363" '"AFD8F8" 'Baby blue
        strColor(1) = "F6BD0F" 'gold
        strColor(2) = "EE82EE" 'violet
        strColor(3) = "8BBA00" 'green
        strColor(4) = "FF8000" 'orange
        strColor(5) = "AFD8F8" 'baby blue
        strColor(6) = "999999" 'gray
        strColor(7) = "BCED91" 'green mist
        strColor(8) = "FFC1C1" 'pink
        strColor(9) = "67C8FF" 'neon blue

        Dim sb As System.Text.StringBuilder = New StringBuilder()
        sb.Append(Table)

        dt = oTrafficSchedule.GetScheduleCalendarRpt(JobNum, JobComp, Request.QueryString("ms"), Request.QueryString("completed"))

        ' Collect all task data into collection and determine start/end dates of report
        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                oTask = New Task
                oTask.Description = dt.Rows(j)("TASK_DESCRIPTION")
                'oTask.StartDate = dt.Rows(j)("TASK_START_DATE")
                'oTask.EndDate = dt.Rows(j)("JOB_REVISED_DATE")
                If Not IsDBNull(dt.Rows(j)("TASK_START_DATE")) Then
                    oTask.StartDate = dt.Rows(j)("TASK_START_DATE")
                Else
                    If Not IsDBNull(dt.Rows(j)("JOB_REVISED_DATE")) Then
                        oTask.StartDate = dt.Rows(j)("JOB_REVISED_DATE")
                    End If
                End If
                If Not IsDBNull(dt.Rows(j)("JOB_REVISED_DATE")) Then
                    oTask.EndDate = dt.Rows(j)("JOB_REVISED_DATE")
                Else
                    If Not IsDBNull(dt.Rows(j)("TASK_START_DATE")) Then
                        oTask.EndDate = dt.Rows(j)("TASK_START_DATE")
                    End If
                End If
                oTask.Background = strColor(j Mod 10)
                oTasks.Add(oTask)

                If j = 0 Then
                    startReportDateStr = LoGlo.FirstOfMonth(oTask.StartDate.Year, oTask.StartDate.Month) 'oTask.StartDate.Month.ToString() & "/1/" & oTask.StartDate.Year.ToString
                    startReportDate = CType(startReportDateStr, Date)
                End If

                If maxReportDate < oTask.EndDate Then
                    maxReportDate = oTask.EndDate
                End If
            Next

            daysInMonth = maxReportDate.DaysInMonth(maxReportDate.Year, maxReportDate.Month)
            maxReportDateStr = LoGlo.FormatDate(maxReportDate.Month.ToString() & "/" & daysInMonth.ToString() & "/" & maxReportDate.Year.ToString())
            maxReportDate = CType(maxReportDateStr, Date)
        End If

        currentCalendarDate = startReportDate
        current_month = startReportDate.Month

        'Dim headerImg As String = "<tr><td colspan='7'><asp:Image ID='img' ImageUrl='" & CStr(Session("PSLogoLocation")) & "'/></td></tr>"
        'sb.Append(headerImg)
        sb.Append(String.Format(headerCalendar1, "7", "Job:  " & CInt(JobNum).ToString.PadLeft(6, "0") & " - " & CInt(JobComp).ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNum), CInt(JobComp))))
        sb.Append(String.Format(headerCalendar2, "7", String.Format(c, "{0:MMM}", startReportDate)))
        If LoGlo.UserCultureGet() = "fr-FR" Then
            sb.Append(String.Format(DayCellsHeader, "dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi"))
        ElseIf LoGlo.UserCultureGet() = "es-ES" Then
            sb.Append(String.Format(DayCellsHeader, "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"))
        ElseIf LoGlo.UserCultureGet() = "zh-CN" Then
            sb.Append(String.Format(DayCellsHeader, "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"))
        ElseIf LoGlo.UserCultureGet() = "de" Then
            sb.Append(String.Format(DayCellsHeader, "sonntag", "montag", "dienstag", "mittwoch", "donnerstag", "freitag", "samstag"))
        Else
            sb.Append(String.Format(DayCellsHeader, "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"))
        End If

        Do While currentCalendarDate <= maxReportDate

            CurrentWeekday = currentCalendarDate.DayOfWeek
            Select Case CurrentWeekday
                Case System.DayOfWeek.Sunday
                    Sun = ParseDay(currentCalendarDate, lineCount)
                Case System.DayOfWeek.Monday
                    Mon = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Tuesday
                    Tue = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Wednesday
                    Wed = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Thursday
                    Thu = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Friday
                    Fri = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Saturday
                    Sat = ParseDay(currentCalendarDate)
            End Select

            currentCalendarDate = currentCalendarDate.AddDays(1)
            data_month = currentCalendarDate.Month

            If CurrentWeekday = System.DayOfWeek.Saturday Then
                sb.Append(String.Format(WeekCells, PadDay(Sun, lineCount), Mon, Tue, Wed, Thu, Fri, Sat))
                lineCount = 0
            End If

            If data_month <> current_month Then
                If currentCalendarDate.DayOfWeek <> System.DayOfWeek.Sunday Then
                    CleanFirstWeekOfMonth(currentCalendarDate.DayOfWeek, Sun, Mon, Tue, Wed, Thu, Fri, Sat)
                    sb.Append(String.Format(WeekCells, PadDay(Sun, lineCount), Mon, Tue, Wed, Thu, Fri, Sat))
                    'sb.Append("<tr>")
                    'sb.Append(PadDay(Sun, lineCount))
                    'sb.Append(Mon)
                    'sb.Append(Tue)
                    'sb.Append(Wed)
                    'sb.Append(Thu)
                    'sb.Append(Fri)
                    'sb.Append(Sat)
                    'sb.Append("</tr>")
                    lineCount = 0
                End If

                If data_month <> current_month Then
                    current_month = currentCalendarDate.Month

                    If currentCalendarDate <= maxReportDate Then
                        sb.Append(String.Format(headerCalendar1, "7", "Job:  " & CInt(JobNum).ToString.PadLeft(6, "0") & " - " & CInt(JobComp).ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNum), CInt(JobComp))))
                        sb.Append(String.Format(headerCalendar2, "7", String.Format(c, "{0:MMM}", currentCalendarDate)))
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            sb.Append(String.Format(DayCellsHeader, "dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi"))
                        ElseIf LoGlo.UserCultureGet() = "es-ES" Then
                            sb.Append(String.Format(DayCellsHeader, "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"))
                        ElseIf LoGlo.UserCultureGet() = "zh-CN" Then
                            sb.Append(String.Format(DayCellsHeader, "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"))
                        ElseIf LoGlo.UserCultureGet() = "de" Then
                            sb.Append(String.Format(DayCellsHeader, "sonntag", "montag", "dienstag", "mittwoch", "donnerstag", "freitag", "samstag"))
                        Else
                            sb.Append(String.Format(DayCellsHeader, "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"))
                        End If

                        CleanFirstWeekOfMonthAfter(currentCalendarDate.DayOfWeek, Sun, Mon, Tue, Wed, Thu, Fri, Sat)
                    End If
                End If
            End If
        Loop

        sb.Append("</tr></table>")

        Return sb.ToString

    End Function

    Public Function RenderProjectCalendarReport2Excel(ByVal JobNum As String, ByVal JobComp As String, ByVal ms As Boolean, Optional ByVal completed As Boolean = True) As String
        'Renders calendar report populating task descriptions from start date to revised date. Spans via highlight.
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As New DataTable
        Dim thisDate As Date
        Dim startReportDate As Date
        Dim startReportDateStr As String
        Dim maxReportDate As Date = "1/1/1900"
        Dim maxReportDateStr As String
        Dim current_month As Integer = 0
        Dim current_day As Integer = 0
        Dim data_month As Integer = 0
        Dim data_day As Integer = 0
        Dim daysInMonth As Integer
        Dim Sun, Mon, Tue, Wed, Thu, Fri, Sat As String
        Dim CurrentWeekday As System.DayOfWeek
        Dim currentCalendarDate As Date
        Dim currentCalendarDateStr As String
        Dim currentCalendarWeekOfYear As Integer = 0
        Dim currentWeekOfYear As Integer = 0
        Dim lineCount As Integer
        Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo

        Dim strColor(10) As String
        strColor(0) = "EE6363" '"AFD8F8" 'Baby blue
        strColor(1) = "F6BD0F" 'gold
        strColor(2) = "EE82EE" 'violet
        strColor(3) = "8BBA00" 'green
        strColor(4) = "FF8000" 'orange
        strColor(5) = "AFD8F8" 'baby blue
        strColor(6) = "999999" 'gray
        strColor(7) = "BCED91" 'green mist
        strColor(8) = "FFC1C1" 'pink
        strColor(9) = "67C8FF" 'neon blue

        Dim sb As System.Text.StringBuilder = New StringBuilder()
        sb.Append(Table)

        dt = oTrafficSchedule.GetScheduleCalendarRpt(JobNum, JobComp, ms, completed)

        ' Collect all task data into collection and determine start/end dates of report
        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                oTask = New Task
                oTask.Description = dt.Rows(j)("TASK_DESCRIPTION")
                'oTask.StartDate = dt.Rows(j)("TASK_START_DATE")
                'oTask.EndDate = dt.Rows(j)("JOB_REVISED_DATE")
                If Not IsDBNull(dt.Rows(j)("TASK_START_DATE")) Then
                    oTask.StartDate = dt.Rows(j)("TASK_START_DATE")
                Else
                    If Not IsDBNull(dt.Rows(j)("JOB_REVISED_DATE")) Then
                        oTask.StartDate = dt.Rows(j)("JOB_REVISED_DATE")
                    End If
                End If
                If Not IsDBNull(dt.Rows(j)("JOB_REVISED_DATE")) Then
                    oTask.EndDate = dt.Rows(j)("JOB_REVISED_DATE")
                Else
                    If Not IsDBNull(dt.Rows(j)("TASK_START_DATE")) Then
                        oTask.EndDate = dt.Rows(j)("TASK_START_DATE")
                    End If
                End If
                oTask.Background = strColor(j Mod 10)
                oTasks.Add(oTask)

                If j = 0 Then
                    startReportDateStr = LoGlo.FirstOfMonth(oTask.StartDate.Year, oTask.StartDate.Month) 'oTask.StartDate.Month.ToString() & "/1/" & oTask.StartDate.Year.ToString
                    startReportDate = CType(startReportDateStr, Date)
                End If

                If maxReportDate < oTask.EndDate Then
                    maxReportDate = oTask.EndDate
                End If
            Next

            daysInMonth = maxReportDate.DaysInMonth(maxReportDate.Year, maxReportDate.Month)
            maxReportDateStr = LoGlo.FormatDate(maxReportDate.Month.ToString() & "/" & daysInMonth.ToString() & "/" & maxReportDate.Year.ToString())
            maxReportDate = CType(maxReportDateStr, Date)
        End If

        currentCalendarDate = startReportDate
        current_month = startReportDate.Month

        'Dim headerImg As String = "<tr><td colspan='7'><asp:Image ID='img' ImageUrl='" & CStr(Session("PSLogoLocation")) & "'/></td></tr>"
        'sb.Append(headerImg)
        sb.Append(String.Format(headerCalendar1Excel, "7", "Job:  " & CInt(JobNum).ToString.PadLeft(6, "0") & " - " & CInt(JobComp).ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNum), CInt(JobComp))))
        sb.Append(String.Format(headerCalendar2, "7", String.Format(c, "{0:MMM}", startReportDate)))
        If LoGlo.UserCultureGet() = "fr-FR" Then
            sb.Append(String.Format(DayCellsHeader, "dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi"))
        ElseIf LoGlo.UserCultureGet() = "es-ES" Then
            sb.Append(String.Format(DayCellsHeader, "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"))
        ElseIf LoGlo.UserCultureGet() = "zh-CN" Then
            sb.Append(String.Format(DayCellsHeader, "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"))
        ElseIf LoGlo.UserCultureGet() = "de" Then
            sb.Append(String.Format(DayCellsHeader, "sonntag", "montag", "dienstag", "mittwoch", "donnerstag", "freitag", "samstag"))
        Else
            sb.Append(String.Format(DayCellsHeader, "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"))
        End If

        Do While currentCalendarDate <= maxReportDate

            CurrentWeekday = currentCalendarDate.DayOfWeek
            Select Case CurrentWeekday
                Case System.DayOfWeek.Sunday
                    Sun = ParseDay(currentCalendarDate, lineCount)
                Case System.DayOfWeek.Monday
                    Mon = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Tuesday
                    Tue = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Wednesday
                    Wed = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Thursday
                    Thu = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Friday
                    Fri = ParseDay(currentCalendarDate)
                Case System.DayOfWeek.Saturday
                    Sat = ParseDay(currentCalendarDate)
            End Select

            currentCalendarDate = currentCalendarDate.AddDays(1)
            data_month = currentCalendarDate.Month

            If CurrentWeekday = System.DayOfWeek.Saturday Then
                sb.Append(String.Format(WeekCellsExcel, PadDay(Sun, lineCount), Mon, Tue, Wed, Thu, Fri, Sat))
                lineCount = 0
            End If

            If data_month <> current_month Then
                If currentCalendarDate.DayOfWeek <> System.DayOfWeek.Sunday Then
                    CleanFirstWeekOfMonth(currentCalendarDate.DayOfWeek, Sun, Mon, Tue, Wed, Thu, Fri, Sat)
                    sb.Append(String.Format(WeekCellsExcel, PadDay(Sun, lineCount), Mon, Tue, Wed, Thu, Fri, Sat))
                    'sb.Append("<tr>")
                    'sb.Append(PadDay(Sun, lineCount))
                    'sb.Append(Mon)
                    'sb.Append(Tue)
                    'sb.Append(Wed)
                    'sb.Append(Thu)
                    'sb.Append(Fri)
                    'sb.Append(Sat)
                    'sb.Append("</tr>")
                    lineCount = 0
                End If

                If data_month <> current_month Then
                    current_month = currentCalendarDate.Month

                    If currentCalendarDate <= maxReportDate Then
                        sb.Append(String.Format(headerCalendar1Excel, "7", "Job:  " & CInt(JobNum).ToString.PadLeft(6, "0") & " - " & CInt(JobComp).ToString.PadLeft(2, "0") & " " & getJobDesc(CInt(JobNum), CInt(JobComp))))
                        sb.Append(String.Format(headerCalendar2, "7", String.Format(c, "{0:MMM}", currentCalendarDate)))
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            sb.Append(String.Format(DayCellsHeader, "dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi"))
                        ElseIf LoGlo.UserCultureGet() = "es-ES" Then
                            sb.Append(String.Format(DayCellsHeader, "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"))
                        ElseIf LoGlo.UserCultureGet() = "zh-CN" Then
                            sb.Append(String.Format(DayCellsHeader, "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"))
                        ElseIf LoGlo.UserCultureGet() = "de" Then
                            sb.Append(String.Format(DayCellsHeader, "sonntag", "montag", "dienstag", "mittwoch", "donnerstag", "freitag", "samstag"))
                        Else
                            sb.Append(String.Format(DayCellsHeader, "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"))
                        End If

                        CleanFirstWeekOfMonthAfter(currentCalendarDate.DayOfWeek, Sun, Mon, Tue, Wed, Thu, Fri, Sat)
                    End If
                End If
            End If
        Loop

        sb.Append("</tr></table>")

        Return sb.ToString

    End Function

    Private Sub CleanFirstWeekOfMonth(ByVal lastDayOfMonth As System.DayOfWeek, ByRef Sun As String, ByRef Mon As String, ByRef Tue As String, ByRef Wed As String, ByRef Thu As String, ByRef Fri As String, ByRef Sat As String)
        'Last day of month is actually the next day.
        'i.e. If the 31 is on a Saturday, lastDayOfMonth will be the 1st (Sunday), this way whole week can be cleaned
        Select Case lastDayOfMonth
            Case System.DayOfWeek.Sunday
                Sun = ""
                Mon = ""
                Tue = ""
                Wed = ""
                Thu = ""
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Monday
                Mon = ""
                Tue = ""
                Wed = ""
                Thu = ""
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Tuesday
                Tue = ""
                Wed = ""
                Thu = ""
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Wednesday
                Wed = ""
                Thu = ""
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Thursday
                Thu = ""
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Friday
                Fri = ""
                Sat = ""
            Case System.DayOfWeek.Saturday
                Sat = ""
        End Select
    End Sub

    Private Sub CleanFirstWeekOfMonthAfter(ByVal lastDayOfMonth As System.DayOfWeek, ByRef Sun As String, ByRef Mon As String, ByRef Tue As String, ByRef Wed As String, ByRef Thu As String, ByRef Fri As String, ByRef Sat As String)
        'Last day of month is actually the next day.
        'i.e. If the 31 is on a Saturday, lastDayOfMonth will be the 1st (Sunday), this way whole week can be cleaned
        Select Case lastDayOfMonth
            Case System.DayOfWeek.Sunday

            Case System.DayOfWeek.Monday
                Sun = ""

            Case System.DayOfWeek.Tuesday
                Sun = ""
                Mon = ""

            Case System.DayOfWeek.Wednesday
                Sun = ""
                Mon = ""
                Tue = ""

            Case System.DayOfWeek.Thursday
                Sun = ""
                Mon = ""
                Tue = ""
                Wed = ""

            Case System.DayOfWeek.Friday
                Sun = ""
                Mon = ""
                Tue = ""
                Wed = ""
                Thu = ""

            Case System.DayOfWeek.Saturday
                Sun = ""
                Mon = ""
                Tue = ""
                Wed = ""
                Thu = ""
                Fri = ""
        End Select
    End Sub

    Private Function ParseDay(ByVal currentCalendarDate As Date, Optional ByRef lineCount As Integer = 0) As String
        Dim CurrentWeekday As Integer
        Dim weekDayString As String
        Dim weekDayTask As String
        Dim weekday As String = currentCalendarDate.Day.ToString
        Dim count As Integer = 0
        weekDayTask = "<table><tr><td style=""font-size:8pt; text-align: left;"">" & currentCalendarDate.Day.ToString() & "</td></tr>"
        weekDayString = "<table><tr><td style=""font-size:8pt; text-align: left;"">" & currentCalendarDate.Day.ToString
        lineCount = 1

        For taskIdx As Integer = 0 To oTasks.Count - 1
            If oTasks.Item(taskIdx).StartDate <= currentCalendarDate And oTasks.Item(taskIdx).EndDate >= currentCalendarDate Then
                'weekDayString += "<br />" & oTasks.Item(taskIdx).Description
                'If count > 0 Then
                '    weekDayTask += "<tr><td style=""background: #" & oTasks.Item(taskIdx).Background & "; font-size:8pt; text-align: left;"">" & oTasks.Item(taskIdx).Description & "<br /></td></tr>"
                'Else
                weekDayTask += "<tr><td style=""background: #" & oTasks.Item(taskIdx).Background & "; font-size:8pt; text-align: left; "">" & oTasks.Item(taskIdx).Description & "<br /></td></tr>"
                'End If
                'count += 1

                'Start attempt to get tasks on same line (same color)
                'lineCount += 1
                'oTask = oTasks.Item(taskIdx)
                'oTask.DayLineLevel = lineCount
                'oTasks.Item(taskIdx) = oTask
            End If
        Next
        If weekDayTask.Length > 8 Then
            Return weekDayTask & "</table>"
        Else
            Return weekDayString & "</td></tr></table>"
        End If

    End Function

    Private Function PadDay(ByVal dayString As String, ByVal currentLineCount As Integer) As String
        If currentLineCount < 5 Then
            For idx As Integer = currentLineCount To 5
                dayString &= "<br />"
            Next
        End If
        Return dayString
    End Function

    Private Function GetMonthName(ByVal month As Integer) As String
        Select Case month
            Case 1
                Return "January"
            Case 2
                Return "February"
            Case 3
                Return "March"
            Case 4
                Return "April"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "July"
            Case 8
                Return "August"
            Case 9
                Return "September"
            Case 10
                Return "October"
            Case 11
                Return "November"
            Case 12
                Return "December"
        End Select

    End Function

    Private Function getJobDesc(ByVal jobNbr As Integer, ByVal jobcompnbr As Integer) As String
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim jobDesc As String

        SQL_STRING = "SELECT IsNull(JOB_COMP_DESC, '') FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = " & jobNbr.ToString() & " AND JOB_COMPONENT_NBR = " & jobcompnbr.ToString
        dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

        dr.Read()
        jobDesc = dr.GetString(0)

        dr.Close()

        Return jobDesc

    End Function

    Private Table As String = "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;'>"

    Private headerCalendar1 As String = "<tr><td colspan='{0}' class='headerCalendar1'>{1}</td></tr>"
    Private headerCalendar2 As String = "<tr><td colspan='{0}' class='headerCalendar2'>{1}</td></tr>"
    Private DayCellsHeader As String = "<tr><td class='dateCellFill'>{0}</td><td class='dateCellFill'>{1}</td><td class='dateCellFill'>{2}</td><td class='dateCellFill'>{3}</td><td class='dateCellFill'>{4}</td><td class='dateCellFill'>{5}</td><td class='dateCellFill'>{6}</td></tr>"
    Private WeekCells As String = "<tr><td class='dateCell'>{0}</td><td class='dateCell'>{1}</td><td class='dateCell'>{2}</td><td class='dateCell'>{3}</td><td class='dateCell'>{4}</td><td class='dateCell'>{5}</td><td class='dateCellEnd2'>{6}</td></tr>"


    Private TableExcel As String = "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;'>"
    Private headerCalendar1Excel As String = "<tr><td colspan='{0}' style='font-weight:700;	border:none; text-align:left; page-break-before:always;'>{1}</td></tr>"
    Private headerCalendar2Excel As String = "<tr><td colspan='{0}' style='font-weight:700;	border:none; border-bottom:1.5pt solid black; text-align:center;'>{1}</td></tr>"
    Private DayCellsHeaderExcel As String = "<tr><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{0}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{1}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{2}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{3}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{4}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{5}</td><td style='border:0.5pt solid black; border-right:none; font-weight:bold; text-align:center; background:#99CCFF; width:150px; font-size:8pt;'>{6}</td></tr>"
    Private WeekCellsExcel As String = "<tr><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{0}</td><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{1}</td><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{2}</td><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{3}</td><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{4}</td><td style='border:0.5pt solid black; border-right:none; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{5}</td><td style='border:0.5pt solid black; border-right:0.5pt solid black; text-align:left; vertical-align:top; width:150px; font-size:8pt;'>{6}</td></tr>"

    '.dateCellFillTask - highlights task
    '<td style="background-color:Highlight"></td>

    'Private Footer As String = "<tr><td></td><td colspan='{0}' style='' class='footer'>{1}</td></tr>"

    <Serializable()> Public Structure Task
        Private mDescription As String
        Private mStartDate As Date
        Private mEndDate As Date
        Private mBackground As String
        Private mDayLineLevel As Integer

        Public Property Description() As String
            Get
                Return mDescription
            End Get
            Set(ByVal Value As String)
                mDescription = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return mStartDate
            End Get
            Set(ByVal Value As Date)
                mStartDate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return mEndDate
            End Get
            Set(ByVal Value As Date)
                mEndDate = Value
            End Set
        End Property
        Public Property Background() As String
            Get
                Return mBackground
            End Get
            Set(ByVal Value As String)
                mBackground = Value
            End Set
        End Property
        Public Property DayLineLevel() As String
            Get
                Return mDayLineLevel
            End Get
            Set(ByVal Value As String)
                mDayLineLevel = Value
            End Set
        End Property
    End Structure

    <Serializable()> Public Class TaskCollection
        Inherits CollectionBase
        Default Public Property Item(ByVal index As Integer) As Task
            Get
                Return CType(List(index), Task)
            End Get
            Set(ByVal Value As Task)
                List(index) = Value
            End Set
        End Property
        Public Function Add(ByVal value As Task) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As Task) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Task)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Task)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As Task) As Boolean
            Return List.Contains(value)
        End Function
        Public Sub New()
        End Sub
    End Class
End Class