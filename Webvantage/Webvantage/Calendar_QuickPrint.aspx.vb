Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports Webvantage.cGlobals.Globals
Imports System.IO

Partial Public Class Calendar_QuickPrint
    Inherits Webvantage.BaseChildPage
    Public dtThisDate As Date

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim c As New cDayPilot()
        'c.LoadTabs(Me.RadTabStripTaskCalendar, Request.QueryString("FromApp"), Request.QueryString("JobNum"), Request.QueryString("JobCompNum"))

        If Page.IsPostBack = True Then
            'dtThisDate = CDate(ViewState("ThisDate"))
        Else
            If IsDate(Request.QueryString("Date")) = True Then
                dtThisDate = CDate(Request.QueryString("Date"))
            Else
                dtThisDate = Today.Date
            End If
            'LoadLookup()
        End If

    End Sub

    'Private Sub LoadLookup()
    '    Try
    '        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

    '        Me.ddLocation.DataSource = oReports.GetLocationPO
    '        Me.ddLocation.DataTextField = "ID"
    '        Me.ddLocation.DataValueField = "LOGO_PATH"
    '        Me.ddLocation.DataBind()
    '        Me.ddLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "None"))
    '    Catch ex As Exception
    '        Me.ShowMessage("Error ddlocation!<BR />" & ex.Message.ToString())
    '    Finally

    '    End Try
    'End Sub

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Try
            Session("SchedulerTitle") = Me.TBTitle.Text
            Session("SchedulerPlacement") = Me.rbplacement.SelectedValue
            'CreateGanttReport()

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            Dim qs2 As New AdvantageFramework.Web.QueryString()
            qs2.Page = "Calendar_Print.aspx"
            qs2.Add("Date", qs.Get("Date"))
            qs2.Add("FromApp", qs.Get("FromApp"))
            qs2.Add("JobNum", qs.Get("JobNum"))
            qs2.Add("JobCompNum", qs.Get("JobCompNum"))
            qs2.Add("view", qs.Get("view"))
            qs2.Add("nontasktype", qs.Get("nontasktype"))
            qs2.Add("duration", qs.Get("duration"))

            Me.OpenWindow("Calendar Print", qs2.ToString(True), 758, 990)

            ' Me.OpenWindow("Calendar Print", "Calendar_Print.aspx?FromApp=" & Request.QueryString("FromApp") & "&JobNum=" & Request.QueryString("JobNum") & "&JobCompNum=" & Request.QueryString("JobCompNum"), 758, 990)
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub CreateGanttReport()

    '    'objects
    '    Dim CreateReport As Boolean = True
    '    Dim StartMonth As Integer = 1
    '    Dim StartYear As Integer = 2011
    '    Dim EndMonth As Integer = 1
    '    Dim EndYear As Integer = 2011
    '    Dim StartDate As Date = Nothing
    '    Dim EndDate As Date = Nothing
    '    Dim MemoryStream As System.IO.MemoryStream = Nothing
    '    Dim Document As iTextSharp.text.Document = Nothing
    '    Dim PdfWriter As iTextSharp.text.pdf.PdfWriter = Nothing
    '    Dim GanttImage As iTextSharp.text.Image = Nothing
    '    Dim Paragraph As iTextSharp.text.Paragraph = Nothing
    '    Dim File As String = ""
    '    Dim PDFFileStream As System.IO.FileStream = Nothing
    '    Dim outputStream As New System.IO.MemoryStream
    '    Dim PDFBytes() As Byte = Nothing
    '    Dim FileNameWithExtension As String = ""
    '    Dim LocationValueArray() As String = Nothing
    '    Dim LogoImage As iTextSharp.text.Image = Nothing
    '    Dim PdfPTable As iTextSharp.text.pdf.PdfPTable = Nothing
    '    Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = Nothing
    '    Dim impersonateUser As Boolean

    '    Try

    '        StartMonth = dtThisDate.Month

    '    Catch ex As Exception
    '        CreateReport = False
    '    End Try

    '    If CreateReport Then

    '        Try

    '            StartYear = dtThisDate.Year

    '        Catch ex As Exception
    '            CreateReport = False
    '        End Try

    '    End If

    '    If CreateReport Then

    '        Try

    '            EndMonth = dtThisDate.Month

    '        Catch ex As Exception
    '            CreateReport = False
    '        End Try

    '    End If

    '    If CreateReport Then

    '        Try

    '            EndYear = dtThisDate.Year

    '        Catch ex As Exception
    '            CreateReport = False
    '        End Try

    '    End If

    '    If CreateReport Then

    '        Try

    '            StartDate = LoGlo.FirstOfMonth(StartYear, StartMonth) 'Convert.ToDateTime(LoGlo.FormatDate(StartMonth & "/1/" & StartYear))

    '            EndDate = LoGlo.LastOfMonth(LoGlo.FormatDate(EndMonth & "/13/" & EndYear))

    '        Catch ex As Exception
    '            CreateReport = False
    '        End Try

    '    End If

    '    Dim UserDomain As String
    '    Dim UserName As String
    '    Dim UserPassword As String

    '    Try
    '        Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
    '        RepositorySecuritySettings.LoadAll()
    '        UserDomain = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
    '        UserName = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME
    '        UserPassword = AdvantageFramework.Security.Encryption.Decrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    If CreateReport Then

    '        If StartDate < EndDate Then

    '            Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)

    '            'Try

    '            '    LocationValueArray = ddLocation.SelectedItem.Value.ToString.Split("|")

    '            '    If LocationValueArray.Length > 1 Then

    '            '        If My.Computer.FileSystem.FileExists(LocationValueArray(1)) Then

    '            '            LogoImage = iTextSharp.text.Image.GetInstance(LocationValueArray(1))

    '            '        End If

    '            '    End If

    '            'Catch ex As Exception
    '            '    LogoImage = Nothing
    '            'End Try

    '            FileNameWithExtension = TBTitle.Text & "_" & Now.ToFileTime & ".pdf"

    '            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"

    '            File = StrFilePrefix & FileNameWithExtension

    '            PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(Document, New System.IO.FileStream(File, System.IO.FileMode.Create))

    '            Document.Open()

    '            Do While True

    '                Try

    '                    StartDate = LoGlo.FirstOfMonth(StartYear, StartMonth) 'LoGlo.FormatDate(StartMonth & "/1/" & StartYear)

    '                Catch ex As Exception
    '                    StartDate = Nothing
    '                End Try

    '                If StartDate <> Nothing Then

    '                    LoadCalendar(StartDate)

    '                End If

    '                DayPilotMonthReport.Update()

    '                MemoryStream = DayPilotMonthReport.Export(System.Drawing.Imaging.ImageFormat.Bmp)

    '                PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)

    '                PdfPTable.WidthPercentage = 100

    '                If LogoImage IsNot Nothing Then

    '                    PdfPCell = New iTextSharp.text.pdf.PdfPCell(LogoImage, True)
    '                    PdfPCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER
    '                    PdfPTable.AddCell(PdfPCell)

    '                    PdfPTable.CompleteRow()

    '                    PdfPCell = New iTextSharp.text.pdf.PdfPCell()
    '                    PdfPCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER
    '                    PdfPTable.AddCell(PdfPCell)

    '                    PdfPTable.CompleteRow()

    '                End If

    '                Paragraph = New iTextSharp.text.Paragraph(TBTitle.Text & " - " & MonthName(StartMonth, False) & "/" & StartYear)
    '                PdfPCell = New iTextSharp.text.pdf.PdfPCell(Paragraph)

    '                If rbplacement.SelectedValue = "center" Then

    '                    Paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER
    '                    PdfPCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

    '                ElseIf rbplacement.SelectedValue = "left" Then

    '                    Paragraph.Alignment = iTextSharp.text.Element.ALIGN_LEFT
    '                    PdfPCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

    '                ElseIf rbplacement.SelectedValue = "right" Then

    '                    Paragraph.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
    '                    PdfPCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

    '                End If

    '                PdfPCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER

    '                PdfPTable.AddCell(PdfPCell)

    '                PdfPTable.CompleteRow()

    '                PdfPCell = New iTextSharp.text.pdf.PdfPCell()
    '                PdfPCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER
    '                PdfPTable.AddCell(PdfPCell)

    '                PdfPTable.CompleteRow()

    '                GanttImage = iTextSharp.text.Image.GetInstance(MemoryStream.ToArray)

    '                PdfPCell = New iTextSharp.text.pdf.PdfPCell(GanttImage, True)
    '                PdfPCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER
    '                PdfPTable.AddCell(PdfPCell)

    '                PdfPTable.CompleteRow()

    '                Document.Add(PdfPTable)

    '                If StartMonth = 12 Then

    '                    StartMonth = 1
    '                    StartYear += 1

    '                Else

    '                    StartMonth += 1

    '                End If

    '                Try

    '                    StartDate = LoGlo.FirstOfMonth(StartYear, StartMonth) 'CDate(StartMonth & "/1/" & StartYear)

    '                Catch ex As Exception
    '                    StartDate = EndDate.AddMonths(1)
    '                End Try

    '                If StartDate > EndDate Then

    '                    Exit Do

    '                Else

    '                    Document.NewPage()

    '                End If

    '            Loop

    '            Try
    '                Document.Close()
    '                PdfWriter.Close()

    '                Document.Dispose()
    '                PdfWriter.Dispose()

    '            Catch ex As Exception
    '                Document = Nothing
    '                PdfWriter = Nothing
    '            Finally
    '                Document = Nothing
    '                PdfWriter = Nothing
    '            End Try

    '            Try

    '                Dim memStream As New System.IO.MemoryStream()


    '                Dim newFileStream As New FileStream(File, FileMode.OpenOrCreate, FileAccess.Read)
    '                Dim FileBytes(newFileStream.Length - 1) As Byte
    '                newFileStream.Read(FileBytes, 0, newFileStream.Length)
    '                newFileStream.Close()

    '                'Try

    '                '    If My.Computer.FileSystem.FileExists(File) Then

    '                '        My.Computer.FileSystem.DeleteFile(File)

    '                '    End If

    '                'Catch ex As Exception

    '                'End Try


    '                HttpContext.Current.Response.Buffer = True
    '                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & FileNameWithExtension.Replace(" ", "_"))
    '                HttpContext.Current.Response.AddHeader("Content-Length", FileBytes.Length.ToString())

    '                HttpContext.Current.Response.ContentType = AdvantageFramework.FileSystem.GetMIMEType(File)
    '                HttpContext.Current.Response.BinaryWrite(FileBytes)
    '                HttpContext.Current.Response.Flush()
    '                HttpContext.Current.Response.End()
    '                HttpContext.Current.Response.Clear()


    '                'PDFFileStream = New System.IO.FileStream(File, System.IO.FileMode.Open, System.IO.FileAccess.Read)

    '                'Dim PDFByte(PDFFileStream.Length - 1) As Byte
    '                'PDFFileStream.Read(PDFByte, 0, PDFFileStream.Length)
    '                'PDFFileStream.Close()


    '            Catch ex As Exception
    '                HttpContext.Current.Response.End()
    '                HttpContext.Current.Response.Clear()
    '            End Try

    '        End If

    '    End If

    'End Sub

End Class
