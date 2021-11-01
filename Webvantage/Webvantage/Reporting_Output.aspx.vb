Public Class Reporting_Output
    Inherits Webvantage.BasePrintSendPage
    Private ConnectionString As String = ""
    Private DocumentId As Integer = 0
    Private AccessPrivate As Boolean = False


#Region " Private vars: "

    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Private ShowMessage As Boolean = False
    Private MessageID As Integer = 0
    Private Quotes As String = ""
    Private Comps As String = ""
    Private Type As String = ""
    Private Estdate As DateTime = Nothing
    Private Combine As Integer = 0

    Private _From As String = ""
    Private _SelectedQuoteNumbers As String = ""
    Private _PrintSendAll As Boolean = False
    Private Const Delimiter As String = "#"
    Private ReportFormat As AdvantageFramework.Estimate.Printing.ReportFormats = Nothing
    Private CustomFormat As String = ""

    Private Report As DevExpress.XtraReports.UI.XtraReport = Nothing
    Private EstimateFormatType As String = ""


#End Region

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
            If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber
            If qs.EstimateNumber > 0 Then Me.EstNum = qs.EstimateNumber
            If qs.EstimateComponentNumber > 0 Then Me.EstCompNum = qs.EstimateComponentNumber
            'If qs.EstQuoteNbr > 0 Then Me.QuoteNum = qs.EstQuoteNbr
            'If qs.EstRevNbr > 0 Then Me.RevNum = qs.EstRevNbr

            Me.Quotes = qs.GetValue("quotes")
            Me.Comps = qs.GetValue("comps")
            Me._From = qs.GetValue("from")
            Me.Type = qs.GetValue("Type")
            Me.Estdate = qs.GetValue("estdate")
            Me.CustomFormat = qs.GetValue("Report")
            Me.Combine = qs.GetValue("combine")
            Me.EstimateFormatType = qs.GetValue("settingType")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim SecuritySession 'As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")))
        SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")), HttpContext.Current.Session("ConnString"))

        Me.ConnectionString = Session("ConnString")
        Dim RealFilename As String = ""  ' Filename
        Dim stream As New System.IO.MemoryStream

        RealFilename = Me.GetEstimateReport(SecuritySession)

        With HttpContext.Current.Response
            Try
                If Type = "1" Then
                    Report.ExportToPdf(stream)
                    RealFilename &= ".pdf"
                ElseIf Type = "5" Then
                    Report.ExportToRtf(stream)
                    RealFilename &= ".rtf"
                Else
                    Report.ExportToPdf(stream)
                    RealFilename &= ".pdf"
                End If
                .Buffer = True
                .AddHeader("Content-Transfer-Encoding", "binary")
                If Type = "1" Then
                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                    .ContentType = "application/pdf"
                ElseIf Type = "5" Then
                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                    .ContentType = "application/rtf"
                Else
                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                    .ContentType = "application/pdf"
                End If
                .BinaryWrite(stream.ToArray)
                .Flush()
                .End()
                .Clear()
            Catch ex As Exception
                .End()
                .Clear()
            End Try
        End With

    End Sub

#Region "Estimating"

    Private Function GetEstimateReport(ByVal SecuritySession As AdvantageFramework.Security.Session)
        'Try
        Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
        Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
        Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
        Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
        Dim CurrentCultureCode As String = LoGlo.UserCultureGet()
        Dim filename As String = ""



        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If Me._From = "Est" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, EstCompNum)).ToList

                ElseIf Me._From = "EstQuote" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, EstCompNum)).ToList

                End If

                EstimateQuote = EstimateQuotes(0)

                If CustomFormat = "EstimatingSS2" Then
                    EstimatePrintSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWV(DbContext, False, Session("UserCode")).FirstOrDefault
                Else
                    EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, EstimateFormatType, EstimateQuote.ClientCode, EstimateQuote.CDP, _Session.UserCode).FirstOrDefault()
                End If

            End Using
        End Using

        If Combine = 1 Then
            If CustomFormat = "EstimatingSS2" Then
                Report = AdvantageFramework.Reporting.Reports.CreateEstimateWV(SecuritySession, EstimateQuote, Nothing, EstNum, EstCompNum, Comps, Quotes, EstimatePrintSetting, Estdate, CurrentCultureCode, CustomFormat, Session("EstimatingQteDescs"), Combine)
            Else
                Report = AdvantageFramework.Reporting.Reports.CreateEstimate(SecuritySession, EstimateQuote, EstimatePrintingSetting, ReportFormat, Comps, Quotes, Session("EstimatingQteDescs"), EstimatePrintingSetting.SummaryLevel, Nothing, CurrentCultureCode)
            End If


        Else
            If CustomFormat = "EstimatingSS2" Then
                Report = AdvantageFramework.Reporting.Reports.CreateEstimateWV(SecuritySession, EstimateQuote, Nothing, EstNum, EstCompNum, Comps, Quotes, EstimatePrintSetting, Estdate, CurrentCultureCode, CustomFormat, Session("EstimatingQteDescs" & EstCompNum.ToString()), Combine)
            Else
                Report = AdvantageFramework.Reporting.Reports.CreateEstimate(SecuritySession, EstimateQuote, EstimatePrintingSetting, ReportFormat, Comps, Quotes, Session("EstimatingQteDescs" & EstCompNum.ToString()), EstimatePrintingSetting.SummaryLevel, Nothing, CurrentCultureCode)
            End If

        End If



        If Report IsNot Nothing Then
            Me.GetFilename(filename, Session("EmpCode"), AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating)
        End If

        Return filename

        'Catch ex As Exception

        'End Try
    End Function

#End Region

#Region " New Filename "

    Private Function GetFilename(ByRef OriginalFilename As String, ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim s As String = ""
            Dim ParsingError As Boolean = False

            s = Me.ParseEstimatingFilenameKey(EmpCode, ReportType, ParsingError)

            s = s.Replace(",", "").Replace("/", "").Replace("\", "").Replace(" ", "_")

            s = s.ToUpper()

            If ParsingError = False Then

                If s.Trim() <> "" Then OriginalFilename = s 'Change original to new
                ErrorMessage = ""
                Return True

            Else

                ErrorMessage = s
                Return False

            End If


        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return False

        End Try
    End Function

    Private Function ParseEstimatingFilenameKey(ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        'get est
        'if est has j/jc include, if not, use just client
        Dim s As String

        Dim EstString As String = ""
        Dim EstCompString As String = ""

        If Me.EstNum > 0 Then

            EstString = Me.EstNum.ToString().PadLeft(6, "0")

        End If


        If Me.EstCompNum > 0 Then

            EstCompString = "_" & Me.EstCompNum.ToString().PadLeft(2, "0")

        End If

        If Me.JobNum = 0 Or Me.JobCompNum = 0 Then

            Dim ClCode As String = ""
            Dim ClCodeString As String = ""

            If Me.EstNum > 0 Then

                Try

                    ClCode = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT ISNULL(CL_CODE,'') FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER" & Me.EstNum.ToString() & ";").ToString()

                Catch ex As Exception

                    ClCode = ""

                End Try

            End If

            If ClCode <> "" Then

                ClCodeString = "_" & ClCode

            End If

            s = Me.ParseFilenameKey(EmpCode, "ESTIMATE" & ClCodeString & "_EST_" & EstString & EstCompString, ReportType, [Error])

        Else

            s = Me.ParseFilenameKey(EmpCode, "ESTIMATE_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#" & "_EST_" & EstString & EstCompString, ReportType, [Error])

        End If

        Return s

    End Function

    Private Function ParseFilenameKey(ByVal EmpCode As String, ByVal KeyToParse As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        Try
            Dim Filename As String = ""

            Dim ObjectEmpCode As String = ""

            Dim JobDesc As String = ""
            Dim OfficeCode As String = ""
            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""
            Dim OfficeName As String = ""
            Dim ClDesc As String = ""
            Dim DivDesc As String = ""
            Dim PrdDesc As String = ""
            Dim ScCode As String = ""
            Dim ScDesc As String = ""
            Dim CmpCode As String = ""
            Dim CmpIdentifier As String = ""

            Dim JobCompDesc As String = ""
            Dim CdpContactId As String = ""
            Dim PrdContCode As String = ""
            Dim ContFML As String = ""
            Dim NextAlertSeqNbr As String = ""
            Dim JobComponentEmpCode As String = ""

            Dim sb As New System.Text.StringBuilder
            Dim ar() As String

            ar = KeyToParse.Split(Delimiter)

            Dim t As New wvTimeSheet.cTimeSheet(Session("ConnString"))

            If Me.JobNum > 0 And Me.JobCompNum > 0 Then

                t.GetJobComponentInfo(Me.JobNum, Me.JobCompNum, JobDesc, JobCompDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, _
                                      ScCode, CmpCode, CmpIdentifier, CdpContactId, PrdContCode, ContFML, NextAlertSeqNbr, JobComponentEmpCode)

            ElseIf Me.JobNum > 0 And Me.JobCompNum = 0 Then

                t.GetJobInfo(Me.JobNum, JobDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, ScCode, ScDesc, CmpCode, CmpIdentifier)

            End If

            For Each s As String In ar

                Select Case s

                    Case "OfficeCode"

                        sb.Append(OfficeCode)

                    Case "OfficeName"

                        sb.Append(OfficeName)

                    Case "ClientCode"

                        sb.Append(ClCode)

                    Case "DivisionCode"

                        sb.Append(DivCode)

                    Case "ProductCode"

                        sb.Append(PrdCode)

                    Case "ClientName"

                        sb.Append(ClDesc)

                    Case "DivisionName"

                        sb.Append(DivDesc)

                    Case "ProductName"

                        sb.Append(PrdDesc)

                    Case "JobNumber"

                        sb.Append(JobNum.ToString().PadLeft(6, "0"))

                    Case "ComponentNumber"

                        sb.Append(JobCompNum.ToString().PadLeft(2, "0"))

                    Case "JobDescription"

                        sb.Append(JobDesc)

                    Case "ComponentDescription"

                        sb.Append(JobCompDesc)

                    Case "CurrentDate"

                        sb.Append(Now.Year.ToString())
                        sb.Append(Now.Month.ToString())
                        sb.Append(Now.Day.ToString())

                    Case "CurrentTime"

                        sb.Append(Now.Hour.ToString())
                        sb.Append(Now.Minute.ToString())
                        sb.Append(Now.Minute.ToString())

                    Case "EmployeeCode"


                    Case Else 'Treat it as a literal

                        sb.Append(s)

                End Select

            Next

            [Error] = False
            Return sb.ToString()

        Catch ex As Exception

            [Error] = True
            Return ex.Message.ToString()

        End Try
    End Function

#End Region

End Class
