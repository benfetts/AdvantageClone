Imports System.Text
Imports System.Collections.Generic
Imports System.IO
Imports Webvantage.wvTimeSheet

Partial Public Class TimelinePage
    Inherits System.Web.UI.Page
    Public JobNum As String
    Public JobComp As String
    Public milestone As Boolean
    Public excludeTC As Boolean
    Public completed As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ByDay As Boolean = False
        Dim Ganttline As Webvantage.Ganttline = Nothing
        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
        Dim Workbook As Aspose.Cells.Workbook = Nothing

        Try
            JobNum = Request.QueryString("j")
            JobComp = Request.QueryString("jc")
            milestone = Request.QueryString("ms")
            excludeTC = Request.QueryString("excludeTC")
            completed = Request.QueryString("completed")
        Catch ex As Exception

        End Try

        If Request.QueryString("rpt") = "day" Then

            ByDay = True

        End If

        Ganttline = New Ganttline()

        If Request.QueryString("From") = "psmv" Then

            Workbook = Ganttline.RenderProjectTimelineReportJobsWorkbook(Session("ConnString"), Session("TrafficScheduleMVJobs"), milestone, excludeTC, ByDay, completed)

        Else

            Workbook = Ganttline.RenderProjectTimelineReportWorkbook(Session("ConnString"), JobNum, JobComp, milestone, excludeTC, ByDay, completed)

        End If

        If Workbook IsNot Nothing Then

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

        End If

        Me.EnableViewState = False

    End Sub

    'Private Function RenderProjectTimelineReport(ByVal JobNum As String, ByVal JobComp As String) As String
    '    Dim tl = Ganttline.GetByJob(CStr(Session("ConnString")), JobNum, JobComp, milestone)
    '    Dim dates As List(Of Date) = GetDates(tl)

    '    Dim sb As System.Text.StringBuilder = New StringBuilder()
    '    sb.Append(Table)
    '    sb.Append(String.Format(Heading1, 4 + dates.Count, tl.CampaignTitle))
    '    sb.Append(String.Format(Heading1, 4 + dates.Count, tl.JobNumber & " - " & tl.JobDescription))
    '    sb.Append(String.Format(Heading2, tl.ClientName & " - " & tl.ProductName, GetMonths(dates)))
    '    sb.Append(String.Format(Heading3, GetWeekString(dates, True, Nothing, Nothing)))
    '    For i As Integer = 0 To tl.Lines.Count - 1
    '        If tl.Lines(i).TaskType = "Phase" Then
    '            sb.Append(String.Format(PhaseRow, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
    '        Else
    '            sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
    '        End If
    '    Next
    '    sb.Append(String.Format(Footer, 4 + dates.Count, tl.TrafficComment))

    '    Return sb.ToString()
    'End Function

    'Public Function RenderTimelineReport(ByVal JobNum As String, ByVal JobComp As String, ByVal milestone As Boolean, ByVal filename As String) As String
    '    Dim tl = Ganttline.GetByJob(CStr(Session("ConnString")), JobNum, JobComp, milestone)
    '    Dim dates As List(Of Date) = GetDates(tl)

    '    Dim sb As System.Text.StringBuilder = New StringBuilder()
    '    sb.Append(Table)
    '    sb.Append(String.Format(Heading1, 4 + dates.Count, tl.CampaignTitle))
    '    sb.Append(String.Format(Heading1, 4 + dates.Count, tl.JobNumber & " - " & tl.JobDescription))
    '    sb.Append(String.Format(Heading2, tl.ClientName & " - " & tl.ProductName, GetMonths(dates)))
    '    sb.Append(String.Format(Heading3, GetWeekString(dates, True, Nothing, Nothing)))
    '    For i As Integer = 0 To tl.Lines.Count - 1
    '        If tl.Lines(i).TaskType = "Phase" Then
    '            sb.Append(String.Format(PhaseRow, tl.Lines(i).LineName, GetWeekString(dates, False, Nothing, Nothing)))
    '        Else
    '            sb.Append(String.Format(TaskRow, tl.Lines(i).LineName, tl.Lines(i).Days, tl.Lines(i).Dates, tl.Lines(i).Responsible, GetWeekString(dates, False, tl.Lines(i).StartDate, tl.Lines(i).FinishDate)))
    '        End If
    '    Next
    '    sb.Append(String.Format(Footer, 4 + dates.Count, tl.TrafficComment))

    '    Dim fs As FileStream = File.OpenWrite(filename)
    '    Dim ms As MemoryStream

    '    Dim enc As New UTF8Encoding
    '    Dim arrBytData() As Byte = enc.GetBytes(sb.ToString())
    '    ms = New MemoryStream(arrBytData)
    '    'ms.Read(arrBytData, 0, arrBytData.Length)
    '    ms.WriteTo(fs)
    '    ms.Flush()
    '    ms.Close()
    '    fs.Close()

    'End Function


End Class