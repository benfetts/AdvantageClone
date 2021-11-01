Namespace Reporting.ActiveReports

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "

        Private Const _Delimiter As String = "#"

#End Region

#Region " Enum "

        <Serializable()> _
        Public Enum ExportType
            PDF = 1
            XLS = 2
            HTM = 3
            TXT = 4
            RTF = 5
            TIFF = 6
        End Enum

        <Serializable()> _
        Public Enum ReportFilenameGroup

            BillingApproval = 1
            Calendar = 16
            Campaign = 2
            ClientARStatement = 3
            CreativeBrief = 4
            Estimating = 5
            JobSpec = 6
            JobTemplate = 7
            JobVersion = 8
            Media = 9
            ProductARStatement = 10
            SumRepByClient = 11
            Tasks = 12
            Timesheet = 13
            TrafficDetail = 14
            Vendor = 15

        End Enum

        <Serializable()> _
        Public Enum ReportName

            BillApproval = 31
            BillApproval2 = 32
            BillApproval4 = 38
            BillApprovalJobOnly = 36
            BillApprovalReport = 33

            Campaign = 52

            ClientARStatement = 10
            ClientARStatement001 = 11
            ClientARStatement002 = 12
            ClientARStatement003 = 13
            ClientARStatement004 = 14
            ClientARStatement005 = 62


            CreativeBrief = 39

            EmpNPTime = 28

            Estimating = 37
            Estimating002 = 40
            Estimating003 = 41
            Estimating004 = 42
            Estimating005 = 43
            Estimating006 = 44
            Estimating007 = 45
            Estimating008 = 54
            EstimatingSS1 = 48
            EstimatingSS2 = 49
            Estimating009 = 56
            EstimatingQUR = 57
            EstimatingMars = 61
            Estimating304 = 63
            Estimating305 = 64
            EstimatingBWD = 68
            EstimatingBWD2 = 69
            EstimatingTPN = 71
            EstimatingTAP = 72
            EstimatingTAP2 = 73
            EstimatingInfinity = 66
            EstimatingTPN2 = 74
            Estimating313 = 75
            Estimating314 = 76
            Estimating315 = 77

            JobSpecs = 25
            JobSpecsAllVersions = 35

            JobVersion = 29
            JobVersions = 34

            JobTemplate = 20
            JobTemplate002 = 58
            JobTemplate003 = 59

            MediaReport = 15

            OpenJobs = 1
            OpenJobsFSN = 21
            OpenJobsSC = 16

            ProductARStatement = 5
            ProductARStatement001 = 6
            ProductARStatement002 = 7
            ProductARStatement003 = 8
            ProductARStatement004 = 9

            PurchaseOrder = 17
            PurchaseOrder001 = 19
            PurchaseOrder2 = 46
            PurchaseOrder3 = 67
            PurchaseOrderRR = 65

            SumRepByClient = 26
            SumRepByClientSalesClass = 50

            CompletedTaskReport = 51
            TaskCalendar = 30
            TaskList = 2
            TaskListTask = 3
            TaskListDueDate = 4
            MyTaskList = 22
            MyTaskListDueDate = 24
            MyTaskListSummary = 47
            MyTaskListTask = 23

            TimeSheetPrint = 18

            TrafficDetailByJob = 27
            TrafficDetailByJob2 = 60
            TrafficDetailByJob3 = 70
            TrafficDetailByJobDays = 78 '* This is the newest one (highest num), if you add more reports to this enum, put it in alpha order, then move this comment to the new item so it is easy to find the next number
            TrafficDetailByJobDueDate = 55

            VendorQuoteRequest = 53

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Public Property JobNumber As Integer = 0
        'Public Property JobComponentNbr As Integer = 0

        'Private Property _ConnectionString As String = ""
        'Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function LoadReportGroups() As Dictionary(Of ActiveReports.ReportFilenameGroup, String)

            Dim dict As New Dictionary(Of ActiveReports.ReportFilenameGroup, String)
            With dict

                .Add(ReportFilenameGroup.BillingApproval, "Billing Approval")
                .Add(ReportFilenameGroup.Campaign, "Campaign")
                .Add(ReportFilenameGroup.ClientARStatement, "Client A/R Statement")
                .Add(ReportFilenameGroup.CreativeBrief, "Creative Brief")
                .Add(ReportFilenameGroup.Estimating, "Estimates")
                .Add(ReportFilenameGroup.JobSpec, "Job Specifications")
                .Add(ReportFilenameGroup.JobTemplate, "Job Jacket")
                .Add(ReportFilenameGroup.JobVersion, "Job Version")
                .Add(ReportFilenameGroup.Media, "Media Calendar")
                .Add(ReportFilenameGroup.ProductARStatement, "Product A/R Statement")
                .Add(ReportFilenameGroup.SumRepByClient, "Summary Report by Client")
                .Add(ReportFilenameGroup.Tasks, "Tasks")
                .Add(ReportFilenameGroup.Timesheet, "Timesheet")
                .Add(ReportFilenameGroup.TrafficDetail, "Project Schedule Detail")
                .Add(ReportFilenameGroup.Vendor, "Vendor")

            End With

            Return dict

        End Function
        Public Function GetFilename(ByVal ConnectionString As String, ByVal UserCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByRef OriginalFilename As String, ByVal EmpCode As String, ByVal ReportGroup As AdvantageFramework.Reporting.ActiveReports.ReportFilenameGroup, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim s As String = ""
                Dim ParsingError As Boolean = False

                Select Case ReportGroup

                    Case ReportFilenameGroup.JobTemplate

                        'get db key...per Ellen, not user definable, we will set the default ourselves
                        s = ParseFilenameKey(ConnectionString, UserCode, JobNumber, JobComponentNbr, EmpCode, "Job Jacket Report #ClientCode# - #ClientName# (#DivisionCode#,#ProductCode#) - #JobNumber#-#ComponentNumber#", ReportGroup, ParsingError)

                End Select

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
        Private Function ParseFilenameKey(ByVal ConnectionString As String, ByVal UserCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal EmpCode As String, ByVal KeyToParse As String, ByVal ReportGroup As AdvantageFramework.Reporting.ActiveReports.ReportFilenameGroup, Optional ByRef [Error] As Boolean = False) As String
            Try
                Dim Filename As String = ""

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

                ar = KeyToParse.Split(_Delimiter)

                ''''' Replace with framework code
                ''Dim t As New cTimeSheet(Session("ConnString"))

                ''If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                ''    t.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, JobDesc, JobCompDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, _
                ''                          ScCode, CmpCode, CmpIdentifier, CdpContactId, PrdContCode, ContFML, NextAlertSeqNbr, JobComponentEmpCode)

                ''ElseIf Me.JobNumber > 0 And Me.JobComponentNbr = 0 Then

                ''    t.GetJobInfo(Me.JobNumber, JobDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, ScCode, ScDesc, CmpCode, CmpIdentifier)

                ''End If

                Using oc = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Select Case ReportGroup

                        Case ReportFilenameGroup.JobTemplate, ReportFilenameGroup.JobVersion, ReportFilenameGroup.JobSpec

                            If JobNumber > 0 And JobComponentNbr > 0 Then

                                Dim jc As New AdvantageFramework.Database.Entities.JobComponent
                                jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(oc, JobNumber, JobComponentNbr)

                                OfficeCode = jc.Job.OfficeCode
                                OfficeName = jc.Job.Office.Name
                                ClCode = jc.Job.ClientCode
                                DivCode = jc.Job.DivisionCode
                                PrdCode = jc.Job.ProductCode
                                ClDesc = jc.Job.Client.Name
                                DivDesc = jc.Job.Division.Name
                                PrdDesc = jc.Job.Product.Name
                                JobDesc = jc.Job.Description
                                JobCompDesc = jc.Description

                            ElseIf JobNumber > 0 And JobComponentNbr = 0 Then

                                Dim j As New AdvantageFramework.Database.Entities.Job
                                j = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(oc, JobNumber)

                                OfficeCode = j.OfficeCode
                                OfficeName = j.Office.Name
                                ClCode = j.ClientCode
                                DivCode = j.DivisionCode
                                PrdCode = j.ProductCode
                                ClDesc = j.Client.Name
                                DivDesc = j.Division.Name
                                PrdDesc = j.Product.Name
                                JobDesc = j.Description

                            End If

                    End Select

                End Using

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

                            sb.Append(JobNumber.ToString().PadLeft(6, "0"))

                        Case "ComponentNumber"

                            sb.Append(JobComponentNbr.ToString().PadLeft(2, "0"))

                        Case "JobDescription"

                            sb.Append(JobDesc)

                        Case "ComponentDescription"

                            sb.Append(JobCompDesc)

                        Case "EstimateNumber"



                        Case "PONumber"



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

    End Module

End Namespace

