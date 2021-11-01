Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Imports System.Web.UI
Imports System
Imports System.Drawing

Namespace Web.Presentation

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const ContentButtonClass As String = "waves-effect waves-light btn"
        Public Const ContentButtonClassDisabled As String = "waves-effect waves-light btn disabled"


#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub SetRadDateInputRequired(ByVal RadDateInput As Telerik.Web.UI.RadDateInput)

            RadDateInput.CssClass = "RequiredInput"

        End Sub
        Public Sub SetRadComboBoxRequired(ByVal RadComboBox As Telerik.Web.UI.RadComboBox)

            RadComboBox.BackColor = ColorTranslator.FromHtml("#FFFFCC")
            RadComboBox.ForeColor = Color.Black

        End Sub
        Public Sub EnableContentButton(ByRef Anchor As System.Web.UI.HtmlControls.HtmlAnchor)

            Anchor.Attributes.Remove("class")
            Anchor.Attributes.Add("class", ContentButtonClass)

        End Sub
        Public Sub DisableContentButton(ByRef Anchor As System.Web.UI.HtmlControls.HtmlAnchor)

            Anchor.Attributes.Remove("class")
            Anchor.Attributes.Add("class", ContentButtonClassDisabled)

        End Sub

        Public Function DoesComboBoxHaveASelectedValue(ByVal RadComboBox As Telerik.Web.UI.RadComboBox) As Boolean

            'objects
            Dim HasASelectedValue As Boolean = False

            If RadComboBox IsNot Nothing Then

                If String.IsNullOrWhiteSpace(RadComboBox.SelectedValue) = False Then

                    HasASelectedValue = True

                End If

            End If

            DoesComboBoxHaveASelectedValue = HasASelectedValue

        End Function
        Public Function GetWeatherString(ByVal ZipCode As Integer) As String

            Dim dt As New DataTable
            Dim sb As New System.Text.StringBuilder
            Dim Break As String = "<br />"
            Dim WeatherString As String = ""

            Try

                Dim ThisFeedURL As String = "http://rss.weather.com/weather/rss/local/" & ZipCode & "?cm_ven=LWO&cm_cat=rss&par=LWO_rss"
                Dim BaseDescription As String = ""

                If IsValidRequest(ThisFeedURL) = True Then

                    Dim rssDS As New RssToolkit.Web.WebControls.RssDataSource()

                    With rssDS

                        .Url = ThisFeedURL

                    End With

                    If Not rssDS Is Nothing Then

                        Dim ds As New DataSet
                        ds = rssDS.Rss.ToDataSet()

                        dt = rssDS.Rss.ToDataSet.Tables(2)

                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                            If Not dt.Rows(0) Is Nothing Then

                                sb.Append("<b>")
                                sb.Append(dt.Rows(0)("title").ToString().Replace("Current ", ""))
                                sb.Append("</b>")
                                sb.Append(Break)
                                'sb.Append("Currently: ")
                                sb.Append(dt.Rows(0)("description").ToString().Replace("For more details?", ""))
                                sb.Append(Break)
                                sb.Append(Break)

                            End If
                            If Not dt.Rows(6) Is Nothing Then

                                sb.Append(Break)
                                sb.Append(Break)

                                Dim ar() As String
                                ar = dt.Rows(6)("description").ToString().Split("----")

                                For i As Integer = 0 To ar.Length - 2

                                    sb.Append(ar(i))
                                    sb.Append(Break)

                                Next

                            End If

                        End If

                        WeatherString = sb.ToString().Replace("<br /><br /><br /><br />", Break)
                        WeatherString = WeatherString.Replace("<br /><br /><br />", Break)
                        WeatherString = WeatherString.Replace("& High", "High")
                        WeatherString = WeatherString.Replace("null", "? ")
                        WeatherString = WeatherString.Replace("T<br />Storms", "T-Storms")
                        WeatherString = WeatherString.Replace("Weather Conditions In ", "")
                        WeatherString = WeatherString.Replace("Today:", Break & "Today:")

                    End If

                End If

            Catch ex As Exception

                WeatherString = ex.Message.ToString()

            End Try

            Return WeatherString

        End Function
        Public Function IsValidRequest(ByVal TheURL As String) As Boolean
            Dim req As HttpWebRequest = WebRequest.Create(TheURL)
            Try
                Dim resp As HttpWebResponse = req.GetResponse()
                Return True
            Catch WebEx As WebException
                Return False
            Catch Ex As Exception
                Return False
            End Try
        End Function

#End Region

    End Module

End Namespace

Namespace Web.Presentation.Bookmarks

#Region " Enum "

    Public Enum BookmarkType

        [None] = 0
        Custom = 1
        Billing_BillingApprovalBatch = 2
        Desktop_Alerts = 3
        Employee_ExpenseReports = 4
        ProjectManagement_Estimating = 5
        ProjectManagement_JobJacket = 6
        ProjectManagement_ProjectSchedule = 7
        ProjectManagement_PurchaseOrders = 8
        ProjectManagement_ProjectSchedule_Task = 9
        Desktop_AlertInbox = 10
        ProjectManagement_Campaign = 11
        ProjectManagement_ProjectSchedule_Search = 12
        ProjectManagement_ProjectSchedule_RiskAnalysis = 13
        ProjectManagement_ProjectSchedule_RiskAnalysisGraph = 14
        Desktop_Documents_Invoice = 15
        Maintenance_ProductEdit = 16
        Maintenance_ClientEdit = 17
        Custom_Search = 18
        Billing_BillingApprovalApprovalRollup = 19
        Desktop_AlertList = 20
        Media_MediaATB = 21
        ProjectManagement_JobStatus = 22
        Desktop_DocumentLabel = 23
        Desktop_Documents = 24
        ProjectManagement_Media = 25
        Content = 26
        DocumentDirectDownload = 27
        DocumentEdit = 28
        DocumentAdvancedSearch = 29
        Billing_BillingApprovalBatchSelection = 30
        JobVersionTemplate_Detail = 31
        ProjectManagement_ConceptShare_Review = 32
        BillingApproval_Approval = 33
        ProjectManagement_Agile_Board = 34
        ProjectManagement_Agile_Sprint = 35
        Employee_DirectTime = 36
        Employee_MyDirectTime = 37
        Employee_IndirectTime = 38
        Employee_MyIndirectTime = 39
        Employee_Time = 40
        Employee_MyTime = 41
        Employee_InOutBoard = 42
        Employee_MyInOutBoard = 43
        Employee_AssignmentsAlerts = 44
        ProjectManagement_JobRequests = 45
        ProjectManagement_MyJobRequests = 46
        ProjectManagement_Projects = 47
        ProjectManagement_MyProjects = 48
        ProjectManagement_ProjectStatistics = 49
        ProjectManagement_ProjectViewpoint = 50
        ProjectManagement_QVA = 51
        ProjectManagement_MyQVA = 52
        ProjectManagement_TaskList = 53
        ProjectManagement_MyTaskList = 54
        FinanceAccounting_ClientAging = 55
        FinanceAccounting_MyClientAging = 56
        FinanceAccounting_GrossIncome = 57
        FinanceAccounting_MyGrossIncome = 58
        FinanceAccounting_ServiceFees = 59
        FinanceAccounting_MyServiceFees = 60
        FinanceAccounting_AgencyGoalsGraph = 61
        FinanceAccounting_ARCashForecastProduct = 62
        FinanceAccounting_ARCashForecast = 63
        FinanceAccounting_MyARCashForecast = 64
        FinanceAccounting_DirectExpenseAlert = 65
        FinanceAccounting_MyDirectExpenseAlert = 66
        FinanceAccounting_AccountingDashboard = 67
        FinanceAccounting_AccountingCashDashboard = 68
        FinanceAccounting_ExecutiveDashboard = 69
        Desktop_Calendar = 70
        ProjectManagement_Agile = 71
        FinanceAccounting_EmployeeTimeForecast = 72
        FinanceAccounting_JobForecast = 73
        Calendar_Availability = 74
        FinanceAccounting_EmployeeUtilization = 75
        FinanceAccounting_ClientTimeAnalysis = 76
        Employee_TimesheetApproval = 77
        Desktop_CRMCentral = 78
        Employee_ExpenseApproval = 79
        ProjectManagement_EstimateSearch = 80
        ProjectManagement_QuotevsActuals = 81
        Media_MediaCalendar = 82
        Employee_TimeSheet = 83
        Content_CreativeBrief = 84
        Content_Specifications = 85
        Content_Forms = 86
        Content_Gantt = 87
        Content_Workload = 88
        Content_FinancialStatus = 89
        Content_Media = 90
        Content_Team = 91
        Content_AccountSetup = 92
        Desktop_DynamicReports = 93
        Desktop_UserDefinedReports = 94
        Maintenance_ProfileAdministration = 95

    End Enum

#End Region

#Region " Objects "

    Public Class Bookmark

        Public Property FolderName As String = ""
        Public Property Id As Integer = 0
        Public Property [BookmarkType] As AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType
        Public Property UserCode As String = ""
        Public Property Name As String = ""
        Public Property PageURL As String = ""
        Public Property Description As String = ""
        Public Property SequenceNumber As Integer = 0
        Public Property OpenByDefault As Boolean = False

        Public ReadOnly Property GroupingText As String
            Get

                Select Case Me.[BookmarkType]
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Billing_BillingApprovalBatch
                        Return "Billing Approval Batch"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Alerts
                        Return "Alert"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports
                        Return "Expense Report"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Estimating
                        Return "Estimate"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                        Return "Job Jacket"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                        Return "Project Schedule"
                    Case AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                        Return "Purchase Order"
                    Case Else
                        Return ""
                End Select

            End Get
        End Property

        Public ReadOnly Property ColorIndicatorCSSClass As String
            Get

                If Me.BookmarkType.ToString().Contains("Desktop") Then

                    Return "application-type-desktop"

                ElseIf Me.BookmarkType.ToString().Contains("Employee") Then

                    Return "application-type-employee"

                ElseIf Me.BookmarkType.ToString().Contains("ProjectManagement") Then

                    Return "application-type-project-management"

                ElseIf Me.BookmarkType.ToString().Contains("Media") Then

                    Return "application-type-media"

                ElseIf Me.BookmarkType.ToString().Contains("Billing") Then

                    Return "application-type-billing"

                ElseIf Me.BookmarkType.ToString().Contains("FinanceAndAccounting") Then

                    Return "application-type-finance-and-accounting"

                ElseIf Me.BookmarkType.ToString().Contains("Maintenance") Then

                    Return "application-type-maintenance"

                ElseIf Me.BookmarkType.ToString().Contains("Security") Then

                    Return "application-type-security"

                ElseIf Me.BookmarkType.ToString().Contains("Security") Then

                    Return "application-type-custom"

                Else

                    Return "application-type-none"

                End If

            End Get
        End Property

        Public ReadOnly Property IndicatorAbbreviation As String
            Get
                Select Case Me.BookmarkType
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalApprovalRollup
                        Return "BaR"
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalBatch
                        Return "BaB"
                    Case Bookmarks.BookmarkType.Custom
                        Return ""
                    Case Bookmarks.BookmarkType.Custom_Search
                        Return "S"
                    Case Bookmarks.BookmarkType.Desktop_AlertInbox
                        Return "AA"
                    Case Bookmarks.BookmarkType.Desktop_AlertList
                        Return "Al"
                    Case Bookmarks.BookmarkType.Desktop_Alerts
                        Return "A"
                    Case Bookmarks.BookmarkType.Desktop_Documents_Invoice
                        Return "Doc"
                    Case Bookmarks.BookmarkType.Employee_ExpenseReports
                        Return "Ex"
                    Case Bookmarks.BookmarkType.Maintenance_ClientEdit
                        Return "Cl"
                    Case Bookmarks.BookmarkType.Maintenance_ProductEdit
                        Return "Prd"
                    Case Bookmarks.BookmarkType.Media_MediaATB
                        Return "Atb"
                    Case Bookmarks.BookmarkType.ProjectManagement_Campaign
                        Return "Cmp"
                    Case Bookmarks.BookmarkType.ProjectManagement_Estimating
                        Return "Est"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobJacket
                        Return "J"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                        Return "Ps"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysis
                        Return "PsR"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysisGraph
                        Return "PsR"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Search
                        Return "PsS"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Task
                        Return "PsT"
                    Case Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                        Return "Po"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobStatus
                        Return "Js"
                    Case Bookmarks.BookmarkType.ProjectManagement_Media
                        Return "M"
                    Case Bookmarks.BookmarkType.ProjectManagement_ConceptShare_Review
                        Return "Cr"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile_Board
                        Return "Ab"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile_Sprint
                        Return "As"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobRequests
                        Return "Jr"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyJobRequests
                        Return "MJr"
                    Case Bookmarks.BookmarkType.ProjectManagement_Projects
                        Return "Pr"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyProjects
                        Return "MPr"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectStatistics
                        Return "PSt"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectViewpoint
                        Return "Pv"
                    Case Bookmarks.BookmarkType.ProjectManagement_QVA
                        Return "QA"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyQVA
                        Return "MQa"
                    Case Bookmarks.BookmarkType.ProjectManagement_TaskList
                        Return "Tl"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyTaskList
                        Return "MTl"
                    Case Bookmarks.BookmarkType.Desktop_DocumentLabel
                        Return "Dl"
                    Case Bookmarks.BookmarkType.Desktop_Documents
                        Return "D"
                    Case Bookmarks.BookmarkType.Content
                        Return "C"
                    Case Bookmarks.BookmarkType.DocumentDirectDownload
                        Return "Ddd"
                    Case Bookmarks.BookmarkType.DocumentEdit
                        Return "De"
                    Case Bookmarks.BookmarkType.DocumentAdvancedSearch
                        Return "Das"
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalBatchSelection
                        Return "BaB"
                    Case Bookmarks.BookmarkType.JobVersionTemplate_Detail
                        Return "Jv"
                    Case Bookmarks.BookmarkType.BillingApproval_Approval
                        Return "BaA"
                    Case Bookmarks.BookmarkType.Employee_DirectTime
                        Return "Dt"
                    Case Bookmarks.BookmarkType.Employee_MyDirectTime
                        Return "MDt"
                    Case Bookmarks.BookmarkType.Employee_IndirectTime
                        Return "Idt"
                    Case Bookmarks.BookmarkType.Employee_MyIndirectTime
                        Return "MId"
                    Case Bookmarks.BookmarkType.Employee_Time
                        Return "T"
                    Case Bookmarks.BookmarkType.Employee_MyTime
                        Return "Mt"
                    Case Bookmarks.BookmarkType.Employee_InOutBoard
                        Return "IB"
                    Case Bookmarks.BookmarkType.Employee_MyInOutBoard
                        Return "MIB"
                    Case Bookmarks.BookmarkType.Employee_AssignmentsAlerts
                        Return "Ea"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ClientAging
                        Return "Ca"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyClientAging
                        Return "MCa"
                    Case Bookmarks.BookmarkType.FinanceAccounting_GrossIncome
                        Return "Gi"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyGrossIncome
                        Return "MGi"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ServiceFees
                        Return "Sf"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyServiceFees
                        Return "MSf"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AgencyGoalsGraph
                        Return "AGg"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ARCashForecastProduct
                        Return "ARP"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ARCashForecast
                        Return "AR"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyARCashForecast
                        Return "MaR"
                    Case Bookmarks.BookmarkType.FinanceAccounting_DirectExpenseAlert
                        Return "De"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyDirectExpenseAlert
                        Return "MDe"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AccountingDashboard
                        Return "Ad"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AccountingCashDashboard
                        Return "AcD"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ExecutiveDashboard
                        Return "Ed"
                    Case Bookmarks.BookmarkType.Desktop_Calendar
                        Return "Cal"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile
                        Return "B"
                    Case Bookmarks.BookmarkType.FinanceAccounting_EmployeeTimeForecast
                        Return "ETF"
                    Case Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                        Return "JF"
                    Case Bookmarks.BookmarkType.Calendar_Availability
                        Return "CA"
                    Case Bookmarks.BookmarkType.FinanceAccounting_EmployeeUtilization
                        Return "EU"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ClientTimeAnalysis
                        Return "CT"
                    Case Bookmarks.BookmarkType.Employee_TimesheetApproval
                        Return "TA"
                    Case Bookmarks.BookmarkType.Desktop_CRMCentral
                        Return "CR"
                    Case Bookmarks.BookmarkType.Employee_ExpenseApproval
                        Return "EA"
                    Case Bookmarks.BookmarkType.ProjectManagement_EstimateSearch
                        Return "ES"
                    Case Bookmarks.BookmarkType.ProjectManagement_QuotevsActuals
                        Return "QA"
                    Case Bookmarks.BookmarkType.Media_MediaCalendar
                        Return "MC"
                    Case Bookmarks.BookmarkType.Employee_TimeSheet
                        Return "T"
                    Case Bookmarks.BookmarkType.Content_CreativeBrief
                        Return "CB"
                    Case Bookmarks.BookmarkType.Content_Specifications
                        Return "S"
                    Case Bookmarks.BookmarkType.Content_Forms
                        Return "F"
                    Case Bookmarks.BookmarkType.Content_Gantt
                        Return "G"
                    Case Bookmarks.BookmarkType.Content_Workload
                        Return "W"
                    Case Bookmarks.BookmarkType.Content_FinancialStatus
                        Return "FS"
                    Case Bookmarks.BookmarkType.Content_Media
                        Return "M"
                    Case Bookmarks.BookmarkType.Content_Team
                        Return "T"
                    Case Bookmarks.BookmarkType.Content_AccountSetup
                        Return "AS"
                    Case Bookmarks.BookmarkType.Desktop_DynamicReports
                        Return "DR"
                    Case Bookmarks.BookmarkType.Desktop_UserDefinedReports
                        Return "UR"
                    Case Bookmarks.BookmarkType.Maintenance_ProfileAdministration
                        Return "PA"
                    Case Else
                        Return ""
                End Select
            End Get
        End Property

        Public ReadOnly Property IndicatorText As String
            Get
                Select Case Me.BookmarkType
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalApprovalRollup
                        Return "Billing Approval Approval Rollup"
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalBatch
                        Return "Billing Approval Batch"
                    Case Bookmarks.BookmarkType.Custom
                        Return "Custom"
                    Case Bookmarks.BookmarkType.Custom_Search
                        Return "Search"
                    Case Bookmarks.BookmarkType.Desktop_AlertInbox
                        Return "Assignments & Alerts"
                    Case Bookmarks.BookmarkType.Desktop_AlertList
                        Return "Alert List"
                    Case Bookmarks.BookmarkType.Desktop_Alerts
                        Return "Alerts"
                    Case Bookmarks.BookmarkType.Desktop_Documents_Invoice
                        Return "Documents Invoice"
                    Case Bookmarks.BookmarkType.Employee_ExpenseReports
                        Return "Expense Reports"
                    Case Bookmarks.BookmarkType.Maintenance_ClientEdit
                        Return "Client Edit"
                    Case Bookmarks.BookmarkType.Maintenance_ProductEdit
                        Return "Product Edit"
                    Case Bookmarks.BookmarkType.Media_MediaATB
                        Return "Media ATB"
                    Case Bookmarks.BookmarkType.ProjectManagement_Campaign
                        Return "Campaign"
                    Case Bookmarks.BookmarkType.ProjectManagement_Estimating
                        Return "Estimating"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobJacket
                        Return "Job Jacket"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                        Return "Project Schedule"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysis
                        Return "Project Schedule Risk Analysis"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysisGraph
                        Return "Project Schedule Risk Analysis"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Search
                        Return "Project Schedule Search"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Task
                        Return "Project Schedule Task"
                    Case Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                        Return "Purchase Orders"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobStatus
                        Return "Job Status"
                    Case Bookmarks.BookmarkType.ProjectManagement_Media
                        Return "Media"
                    Case Bookmarks.BookmarkType.ProjectManagement_ConceptShare_Review
                        Return "Concept Share Review"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile_Board
                        Return "Agile Board"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile
                        Return "Boards"
                    Case Bookmarks.BookmarkType.ProjectManagement_Agile_Sprint
                        Return "Agile Sprint"
                    Case Bookmarks.BookmarkType.ProjectManagement_JobRequests
                        Return "Job Requests"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyJobRequests
                        Return "My Job Requests"
                    Case Bookmarks.BookmarkType.ProjectManagement_Projects
                        Return "Projects"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyProjects
                        Return "My Projects"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectStatistics
                        Return "Project Statistics"
                    Case Bookmarks.BookmarkType.ProjectManagement_ProjectViewpoint
                        Return "Project Viewpoint"
                    Case Bookmarks.BookmarkType.ProjectManagement_QVA
                        Return "QVA"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyQVA
                        Return "My QVA"
                    Case Bookmarks.BookmarkType.ProjectManagement_TaskList
                        Return "Task List"
                    Case Bookmarks.BookmarkType.ProjectManagement_MyTaskList
                        Return "My Task List"
                    Case Bookmarks.BookmarkType.Desktop_DocumentLabel
                        Return "Document Label"
                    Case Bookmarks.BookmarkType.Desktop_Documents
                        Return "Document Manager"
                    Case Bookmarks.BookmarkType.Content
                        Return "Content"
                    Case Bookmarks.BookmarkType.DocumentDirectDownload
                        Return "Document Direct Download"
                    Case Bookmarks.BookmarkType.DocumentEdit
                        Return "Document Edit"
                    Case Bookmarks.BookmarkType.DocumentAdvancedSearch
                        Return "Document Advanced Search"
                    Case Bookmarks.BookmarkType.Billing_BillingApprovalBatchSelection
                        Return "Billing Approval Batch Selection"
                    Case Bookmarks.BookmarkType.JobVersionTemplate_Detail
                        Return "Job Version Detail"
                    Case Bookmarks.BookmarkType.BillingApproval_Approval
                        Return "Billing Approval"
                    Case Bookmarks.BookmarkType.Employee_DirectTime
                        Return "Direct Time"
                    Case Bookmarks.BookmarkType.Employee_MyDirectTime
                        Return "My Direct Time"
                    Case Bookmarks.BookmarkType.Employee_IndirectTime
                        Return "Indirect Time"
                    Case Bookmarks.BookmarkType.Employee_MyIndirectTime
                        Return "My Indirect Time"
                    Case Bookmarks.BookmarkType.Employee_Time
                        Return "Employee Time"
                    Case Bookmarks.BookmarkType.Employee_MyTime
                        Return "My Employee Time"
                    Case Bookmarks.BookmarkType.Employee_InOutBoard
                        Return "InOut Board"
                    Case Bookmarks.BookmarkType.Employee_MyInOutBoard
                        Return "My InOut Board"
                    Case Bookmarks.BookmarkType.Employee_AssignmentsAlerts
                        Return "Assignments & Alerts"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ClientAging
                        Return "Client Aging"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyClientAging
                        Return "My Client Aging"
                    Case Bookmarks.BookmarkType.FinanceAccounting_GrossIncome
                        Return "Gross Income"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyGrossIncome
                        Return "My Gross Income"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ServiceFees
                        Return "Service Fees"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyServiceFees
                        Return "My Service Fees"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AgencyGoalsGraph
                        Return "Agency Goals Graph"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ARCashForecastProduct
                        Return "AR Cash Forecast Product"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ARCashForecast
                        Return "AR Cash Forecast"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyARCashForecast
                        Return "My AR Cash Forecast"
                    Case Bookmarks.BookmarkType.FinanceAccounting_DirectExpenseAlert
                        Return "Direct Expense Alert"
                    Case Bookmarks.BookmarkType.FinanceAccounting_MyDirectExpenseAlert
                        Return "My Direct Expense Alert"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AccountingDashboard
                        Return "Accounting Dashboard"
                    Case Bookmarks.BookmarkType.FinanceAccounting_AccountingCashDashboard
                        Return "Accounting Cash Dashboard"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ExecutiveDashboard
                        Return "Executive Dashboard"
                    Case Bookmarks.BookmarkType.Desktop_Calendar
                        Return "Calendar"
                    Case Bookmarks.BookmarkType.FinanceAccounting_EmployeeTimeForecast
                        Return "Employee Time Forecast"
                    Case Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                        Return "Job Forecast"
                    Case Bookmarks.BookmarkType.Calendar_Availability
                        Return "Calendar Availability"
                    Case Bookmarks.BookmarkType.FinanceAccounting_EmployeeUtilization
                        Return "Employee Utilization"
                    Case Bookmarks.BookmarkType.FinanceAccounting_ClientTimeAnalysis
                        Return "Client Time Analysis"
                    Case Bookmarks.BookmarkType.Employee_TimesheetApproval
                        Return "Timesheet Approval"
                    Case Bookmarks.BookmarkType.Desktop_CRMCentral
                        Return "CRM Central"
                    Case Bookmarks.BookmarkType.Employee_ExpenseApproval
                        Return "Expense Approval"
                    Case Bookmarks.BookmarkType.ProjectManagement_EstimateSearch
                        Return "Estimate Search"
                    Case Bookmarks.BookmarkType.ProjectManagement_QuotevsActuals
                        Return "Quote vs Actuals"
                    Case Bookmarks.BookmarkType.Media_MediaCalendar
                        Return "Media Calendar"
                    Case Bookmarks.BookmarkType.Employee_TimeSheet
                        Return "Timesheet"
                    Case Bookmarks.BookmarkType.Content_CreativeBrief
                        Return "Creative Brief"
                    Case Bookmarks.BookmarkType.Content_Specifications
                        Return "Specifications"
                    Case Bookmarks.BookmarkType.Content_Forms
                        Return "Forms"
                    Case Bookmarks.BookmarkType.Content_Gantt
                        Return "Gantt"
                    Case Bookmarks.BookmarkType.Content_Workload
                        Return "Workload"
                    Case Bookmarks.BookmarkType.Content_FinancialStatus
                        Return "Financial Status"
                    Case Bookmarks.BookmarkType.Content_Media
                        Return "Media"
                    Case Bookmarks.BookmarkType.Content_Team
                        Return "Team"
                    Case Bookmarks.BookmarkType.Content_AccountSetup
                        Return "Account Setup"
                    Case Bookmarks.BookmarkType.Desktop_DynamicReports
                        Return "Dynamic Reports"
                    Case Bookmarks.BookmarkType.Desktop_UserDefinedReports
                        Return "User Defined Reports"
                    Case Bookmarks.BookmarkType.Maintenance_ProfileAdministration
                        Return "Profile Administration"
                    Case Else
                        Return ""
                End Select
            End Get
        End Property

        Public Sub New()

        End Sub

    End Class

    Public Class BookmarkFolder

        Public Property Id As Integer = 0
        Public Property UserCode As String = ""
        Public Property Name As String = ""
        Public Property Description As String = ""
        Public Property ParentId As Integer = 0
        Public Property SequenceNumber As Integer = 0
        Public Property ErrorMessage As String = ""

        Public Property [Bookmarks] As Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.Bookmark)

        Public Function AddBookmark(ByVal [Bookmark] As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark) As Boolean
            Try

                Me.Bookmarks.Add([Bookmark])

                Me.ErrorMessage = ""
                Return True

            Catch ex As Exception

                Me.ErrorMessage = ex.Message.ToString()
                Return False

            End Try

        End Function

        Public Function RemoveBookmark(ByVal [Bookmark] As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark) As Boolean
            Try

                Me.Bookmarks.Remove([Bookmark])

                Me.ErrorMessage = ""
                Return True

            Catch ex As Exception

                Me.ErrorMessage = ex.Message.ToString()
                Return False

            End Try

        End Function

        Public Sub New()

            [Bookmarks] = New Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.Bookmark)

        End Sub

    End Class

    Public Class UserBookmarks

        Public Property [BookmarkFolders] As Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder)

        Private Property _ConnString As String = ""
        Private Property _UserCode As String = ""

        Public Sub GetAll()

            Dim UncategorizedBookmarks As New AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder
            With UncategorizedBookmarks

                .Id = -1
                .Name = "Uncategorized"
                .Description = "Bookmarks not in a folder will appear in this folder"
                .SequenceNumber = -1

            End With
            Me.BookmarkFolders.Add(UncategorizedBookmarks)

            Using MyConn As New SqlConnection(Me._ConnString)

                Dim MyCommand As New SqlCommand()

                With MyCommand

                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_Bookmarks_GetAll"
                    .Connection = MyConn

                End With

                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = Me._UserCode

                MyCommand.Parameters.Add(pUserCode)

                Dim MyAdapter As New SqlDataAdapter(MyCommand)

                Dim DatasetBookmarks As New DataSet
                Dim DatatableBookmarkFolders As New DataTable
                Dim DatatableBookmarks As New DataTable

                MyConn.Open()
                MyAdapter.Fill(DatasetBookmarks)

                If Not DatasetBookmarks Is Nothing Then

                    DatatableBookmarkFolders = DatasetBookmarks.Tables(0)
                    DatatableBookmarks = DatasetBookmarks.Tables(1)

                    'Get uncategorized
                    If Not DatatableBookmarks Is Nothing Then

                        Dim DataviewUncategorizedBookmarks As New DataView(DatatableBookmarks)
                        DataviewUncategorizedBookmarks.RowFilter = "BOOKMARK_FOLDER_ID IS NULL OR BOOKMARK_FOLDER_ID = 0 "
                        Dim HasData As Boolean = False

                        For Each RowView As DataRowView In DataviewUncategorizedBookmarks

                            Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                            Dim row As DataRow = RowView.Row

                            If IsDBNull(row("ID")) = False Then
                                bm.Id = CType(row("ID"), Integer)
                            End If
                            If IsDBNull(row("BOOKMARK_TYPE_ID")) = False Then
                                bm.BookmarkType = CType(row("BOOKMARK_TYPE_ID"), AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType)
                            End If
                            If IsDBNull(row("USER_CODE")) = False Then
                                bm.UserCode = row("USER_CODE")
                            End If
                            If IsDBNull(row("NAME")) = False Then
                                bm.Name = row("NAME")
                            End If
                            If IsDBNull(row("PAGE_URL")) = False Then
                                bm.PageURL = row("PAGE_URL")
                                If bm.PageURL.Contains(".aspx?") = True And bm.PageURL.Contains("&bm=1") = False Then
                                    bm.PageURL = bm.PageURL & "&bm=1"
                                End If
                            End If
                            If IsDBNull(row("DESCRIPTION")) = False Then
                                bm.Description = row("DESCRIPTION")
                            End If
                            If IsDBNull(row("SEQ_NBR")) = False Then
                                bm.SequenceNumber = CType(row("SEQ_NBR"), Integer)
                            End If

                            UncategorizedBookmarks.Bookmarks.Add(bm)
                            HasData = True
                            bm = Nothing

                        Next

                    End If

                    'Get categorized
                    If Not DatatableBookmarkFolders Is Nothing Then

                        For i As Integer = 0 To DatatableBookmarkFolders.Rows.Count - 1

                            Dim folder As New AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder()
                            With folder

                                If Not IsDBNull(DatatableBookmarkFolders.Rows(i)("ID")) Then
                                    .Id = CType(DatatableBookmarkFolders.Rows(i)("ID"), Integer)
                                End If
                                If Not IsDBNull(DatatableBookmarkFolders.Rows(i)("NAME")) Then
                                    .Name = DatatableBookmarkFolders.Rows(i)("NAME")
                                End If
                                If Not IsDBNull(DatatableBookmarkFolders.Rows(i)("DESCRIPTION")) Then
                                    .Description = DatatableBookmarkFolders.Rows(i)("DESCRIPTION")
                                End If
                                If Not IsDBNull(DatatableBookmarkFolders.Rows(i)("SEQ_NBR")) Then
                                    .SequenceNumber = CType(DatatableBookmarkFolders.Rows(i)("SEQ_NBR"), Integer)
                                End If

                            End With

                            Dim DataviewFolderBookmarks As New DataView(DatatableBookmarks)
                            DataviewFolderBookmarks.RowFilter = "BOOKMARK_FOLDER_ID = " & folder.Id

                            For Each RowView As DataRowView In DataviewFolderBookmarks

                                Dim bm As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                                Dim row As DataRow = RowView.Row

                                If IsDBNull(row("ID")) = False Then
                                    bm.Id = CType(row("ID"), Integer)
                                End If
                                If IsDBNull(row("BOOKMARK_TYPE_ID")) = False Then
                                    bm.BookmarkType = CType(row("BOOKMARK_TYPE_ID"), AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType)
                                End If
                                If IsDBNull(row("USER_CODE")) = False Then
                                    bm.UserCode = row("USER_CODE")
                                End If
                                If IsDBNull(row("NAME")) = False Then
                                    bm.Name = row("NAME")
                                End If
                                If IsDBNull(row("PAGE_URL")) = False Then
                                    bm.PageURL = row("PAGE_URL")
                                End If
                                If IsDBNull(row("DESCRIPTION")) = False Then
                                    bm.Description = row("DESCRIPTION")
                                End If
                                If IsDBNull(row("SEQ_NBR")) = False Then
                                    bm.SequenceNumber = CType(row("SEQ_NBR"), Integer)
                                End If

                                folder.Bookmarks.Add(bm)

                                bm = Nothing

                            Next

                            Me.[BookmarkFolders].Add(folder)

                        Next

                    End If

                End If

            End Using

        End Sub

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            _ConnString = ConnectionString
            _UserCode = UserCode
            Me.[BookmarkFolders] = New Generic.List(Of AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder)

        End Sub

    End Class

#End Region

    Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _ConnString As String = ""
        Private Property _UserCode As String = ""
        Private Property _Bookmarks As List(Of Web.Presentation.Bookmarks.Bookmark)

#End Region

#Region " Methods "

#Region " Bookmarks "

        Public Function GetAllUserBookmarks(ByVal UserCode As String, Optional ByRef ErrorMessage As String = "") As UserBookmarks

            Dim ub As New UserBookmarks(Me._ConnString, Me._UserCode)
            Return ub

        End Function
        Public Function GetBookmarks(ByVal UserCode As String, Optional ByRef ErrorMessage As String = "", Optional ByVal Search As String = "") As List(Of Web.Presentation.Bookmarks.Bookmark)

            Try

                Dim list As New List(Of Web.Presentation.Bookmarks.Bookmark)

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    Dim SQL As New System.Text.StringBuilder

                    SQL.Append("SELECT F.NAME AS FOLDER_NAME, B.*")
                    SQL.Append(" FROM            dbo.WV_BOOKMARK_FOLDERS AS F WITH (NOLOCK) INNER JOIN")
                    SQL.Append(" dbo.WV_BOOKMARKS_BOOKMARK_FOLDERS AS BF WITH (NOLOCK) ON F.ID = BF.BOOKMARK_FOLDER_ID RIGHT OUTER JOIN")
                    SQL.Append(" dbo.WV_BOOKMARKS AS B WITH (NOLOCK) ON BF.BOOKMARK_ID = B.ID")
                    SQL.Append(" WHERE        (B.USER_CODE = @USER_CODE)")
                    If Search <> "" Then
                        SQL.Append(" AND ((UPPER(B.NAME) LIKE UPPER('%" & Search & "%')) OR (UPPER(B.DESCRIPTION) LIKE UPPER('%" & Search & "%')))")
                    End If
                    SQL.Append(" ORDER BY F.NAME, B.SEQ_NBR, B.NAME;")

                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn

                    End With

                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = UserCode

                    MyCommand.Parameters.Add(pUserCode)

                    'Dim pSearch As New SqlParameter("@SEARCH", SqlDbType.VarChar, 500)
                    'pSearch.Value = Search

                    'MyCommand.Parameters.Add(pSearch)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Dim bm As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                        Do While Reader.Read()

                            bm = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                            If Reader.IsDBNull(Reader.GetOrdinal("FOLDER_NAME")) = False Then

                                bm.FolderName = Reader.GetValue(Reader.GetOrdinal("FOLDER_NAME"))

                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("ID")) = False Then

                                bm.Id = Reader.GetValue(Reader.GetOrdinal("ID"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("BOOKMARK_TYPE_ID")) = False Then

                                bm.BookmarkType = CType(Reader.GetValue(Reader.GetOrdinal("BOOKMARK_TYPE_ID")), AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType)

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("USER_CODE")) = False Then

                                bm.UserCode = Reader.GetValue(Reader.GetOrdinal("USER_CODE"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("NAME")) = False Then

                                bm.Name = Reader.GetValue(Reader.GetOrdinal("NAME"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("PAGE_URL")) = False Then

                                bm.PageURL = Reader.GetValue(Reader.GetOrdinal("PAGE_URL"))

                                If bm.PageURL.Contains(".aspx?") = True And bm.PageURL.Contains("&bm=1") = False And bm.PageURL.Contains("?bm=1") = False Then

                                    bm.PageURL = bm.PageURL & "&bm=1"

                                End If

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then

                                bm.Description = Reader.GetValue(Reader.GetOrdinal("DESCRIPTION"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("SEQ_NBR")) = False Then

                                bm.SequenceNumber = Reader.GetValue(Reader.GetOrdinal("SEQ_NBR"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("OPEN_BY_DEFAULT")) = False Then

                                bm.OpenByDefault = Reader.GetValue(Reader.GetOrdinal("OPEN_BY_DEFAULT"))

                            End If

                            list.Add(bm)
                            bm = Nothing

                        Loop

                    End If

                End Using

                ErrorMessage = ""
                Return list

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return Nothing

            End Try
        End Function

        Public Function GetBookmarkByID(ByVal BookmarkID As Integer, Optional ByRef ErrorMessage As String = "") As Web.Presentation.Bookmarks.Bookmark

            Try

                Dim list As New List(Of Web.Presentation.Bookmarks.Bookmark)

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    Dim SQL As New System.Text.StringBuilder

                    SQL.Append("SELECT F.NAME AS FOLDER_NAME, B.*")
                    SQL.Append(" FROM            dbo.WV_BOOKMARK_FOLDERS AS F WITH (NOLOCK) INNER JOIN")
                    SQL.Append(" dbo.WV_BOOKMARKS_BOOKMARK_FOLDERS AS BF WITH (NOLOCK) ON F.ID = BF.BOOKMARK_FOLDER_ID RIGHT OUTER JOIN")
                    SQL.Append(" dbo.WV_BOOKMARKS AS B WITH (NOLOCK) ON BF.BOOKMARK_ID = B.ID")
                    SQL.Append(" WHERE        (B.ID = @USER_CODE)")
                    SQL.Append(" ORDER BY F.NAME, B.SEQ_NBR, B.NAME;")

                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn

                    End With

                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.Int)
                    pUserCode.Value = BookmarkID

                    MyCommand.Parameters.Add(pUserCode)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Dim bm As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                        Do While Reader.Read()

                            bm = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                            If Reader.IsDBNull(Reader.GetOrdinal("FOLDER_NAME")) = False Then

                                bm.FolderName = Reader.GetValue(Reader.GetOrdinal("FOLDER_NAME"))

                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("ID")) = False Then

                                bm.Id = Reader.GetValue(Reader.GetOrdinal("ID"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("BOOKMARK_TYPE_ID")) = False Then

                                bm.BookmarkType = CType(Reader.GetValue(Reader.GetOrdinal("BOOKMARK_TYPE_ID")), AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType)

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("USER_CODE")) = False Then

                                bm.UserCode = Reader.GetValue(Reader.GetOrdinal("USER_CODE"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("NAME")) = False Then

                                bm.Name = Reader.GetValue(Reader.GetOrdinal("NAME"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("PAGE_URL")) = False Then

                                bm.PageURL = Reader.GetValue(Reader.GetOrdinal("PAGE_URL"))

                                If bm.PageURL.Contains(".aspx?") = True And bm.PageURL.Contains("&bm=1") = False Then

                                    bm.PageURL = bm.PageURL & "&bm=1"

                                End If

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then

                                bm.Description = Reader.GetValue(Reader.GetOrdinal("DESCRIPTION"))

                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("SEQ_NBR")) = False Then

                                bm.SequenceNumber = Reader.GetValue(Reader.GetOrdinal("SEQ_NBR"))

                            End If

                            list.Add(bm)
                            bm = Nothing

                        Loop

                    End If

                End Using

                ErrorMessage = ""
                Return list(0)

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return Nothing

            End Try
        End Function

        Public Function SaveBookmark(ByVal bm As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_BOOKMARKS_ADD"
                        .Connection = MyConn
                    End With

                    Dim pBookmarkTypeId As New SqlParameter("@BOOKMARK_TYPE_ID", SqlDbType.Int)
                    pBookmarkTypeId.Value = CType(bm.BookmarkType, Integer)
                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = bm.UserCode
                    Dim pName As New SqlParameter("@NAME", SqlDbType.VarChar, 100)
                    pName.Value = bm.Name
                    Dim pDesc As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 500)
                    If bm.Description.Trim() = "" Then
                        pDesc.Value = System.DBNull.Value
                    Else
                        pDesc.Value = bm.Description
                    End If
                    Dim pPageUrl As New SqlParameter("@PAGE_URL", SqlDbType.VarChar, 2000)
                    pPageUrl.Value = bm.PageURL

                    MyCommand.Parameters.Add(pBookmarkTypeId)
                    MyCommand.Parameters.Add(pUserCode)
                    MyCommand.Parameters.Add(pName)
                    MyCommand.Parameters.Add(pDesc)
                    MyCommand.Parameters.Add(pPageUrl)

                    MyConn.Open()

                    Dim i As Integer = 0
                    i = CType(MyCommand.ExecuteScalar(), Integer)

                    Select Case i
                        'Case -2

                        'ErrorMessage = "You do not have a Bookmarks object on any workspace.\nPlease use Workspace Manager to add one."
                        'Return False

                        Case -1

                            ErrorMessage = "Bookmark already exists"
                            Return False

                        Case 0

                        Case Is > 1
                            ErrorMessage = "Bookmark added"
                            Return True
                    End Select
                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

        Public Function UpdateBookmarkNameAndDescription(ByVal BookmarkId As Integer, ByVal NewName As String, ByVal NewDescription As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                NewName = NewName.Trim()
                NewDescription = NewDescription.Trim()

                If NewName = "" Then

                    ErrorMessage = "Bookmark name required"
                    Return False

                End If

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE WV_BOOKMARKS WITH(ROWLOCK) SET [NAME] = @NAME, [DESCRIPTION] = @DESCRIPTION WHERE ID = @ID"
                        .Connection = MyConn
                    End With

                    Dim pId As New SqlParameter("@ID", SqlDbType.Int)
                    pId.Value = BookmarkId

                    Dim pName As New SqlParameter("@NAME", SqlDbType.VarChar, 100)
                    pName.Value = NewName

                    Dim pDescription As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 500)
                    If NewDescription.Trim() = "" Then
                        pDescription.Value = System.DBNull.Value
                    Else
                        pDescription.Value = NewDescription
                    End If

                    MyCommand.Parameters.Add(pId)
                    MyCommand.Parameters.Add(pName)
                    MyCommand.Parameters.Add(pDescription)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

        Public Function UpdateBookmarkOpenByDefault(ByVal BookmarkId As Integer, ByVal OpenByDefault As Boolean) As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE WV_BOOKMARKS WITH(ROWLOCK) SET [OPEN_BY_DEFAULT] = @OpenByDefault WHERE ID = @ID"
                        .Connection = MyConn
                    End With

                    Dim pId As New SqlParameter("@ID", SqlDbType.Int)
                    pId.Value = BookmarkId

                    Dim pName As New SqlParameter("@OpenByDefault", SqlDbType.Bit, 100)
                    pName.Value = OpenByDefault

                    MyCommand.Parameters.Add(pId)
                    MyCommand.Parameters.Add(pName)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                Return True

            Catch ex As Exception

                'ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

        Public Function GetOpenByDefaultCount(ByVal UserCode As String) As Integer

            Try

                Dim list As New List(Of Web.Presentation.Bookmarks.Bookmark)
                Dim Count As Integer = 0

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    Dim SQL As New System.Text.StringBuilder

                    SQL.Append("SELECT COUNT(B.OPEN_BY_DEFAULT) AS OPEN_COUNT")
                    SQL.Append(" FROM dbo.WV_BOOKMARKS AS B WITH (NOLOCK)")
                    SQL.Append(" WHERE (B.USER_CODE = @USER_CODE) AND B.OPEN_BY_DEFAULT = 1")

                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn

                    End With

                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = UserCode

                    MyCommand.Parameters.Add(pUserCode)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            If Reader.IsDBNull(Reader.GetOrdinal("OPEN_COUNT")) = False Then

                                Count = Reader.GetValue(Reader.GetOrdinal("OPEN_COUNT"))

                            End If

                        Loop

                    End If

                End Using

                'ErrorMessage = ""
                Return Count

            Catch ex As Exception

                'ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return 0

            End Try
        End Function



        Public Function MoveBookmarkToFolder(ByVal BookmarkId As Integer, ByVal FolderId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM WV_BOOKMARKS_BOOKMARK_FOLDERS WITH(ROWLOCK) WHERE BOOKMARK_ID = @BOOKMARK_ID;" &
                                       "INSERT INTO WV_BOOKMARKS_BOOKMARK_FOLDERS WITH(ROWLOCK) (BOOKMARK_FOLDER_ID, BOOKMARK_ID) VALUES (@BOOKMARK_FOLDER_ID, @BOOKMARK_ID);"
                        .Connection = MyConn
                    End With

                    Dim pBookmarkFolderId As New SqlParameter("@BOOKMARK_FOLDER_ID", SqlDbType.Int)
                    pBookmarkFolderId.Value = FolderId
                    Dim pBookmarkId As New SqlParameter("@BOOKMARK_ID", SqlDbType.Int)
                    pBookmarkId.Value = BookmarkId

                    MyCommand.Parameters.Add(pBookmarkFolderId)
                    MyCommand.Parameters.Add(pBookmarkId)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function

        Public Function RemoveBookmarkFromFolder(ByVal BookmarkId As Integer, ByVal FolderId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM WV_BOOKMARKS_BOOKMARK_FOLDERS WITH(ROWLOCK) WHERE BOOKMARK_ID = @BOOKMARK_ID AND BOOKMARK_FOLDER_ID = @BOOKMARK_FOLDER_ID;"
                        .Connection = MyConn
                    End With

                    Dim pBookmarkFolderId As New SqlParameter("@BOOKMARK_FOLDER_ID", SqlDbType.Int)
                    pBookmarkFolderId.Value = FolderId
                    Dim pBookmarkId As New SqlParameter("@BOOKMARK_ID", SqlDbType.Int)
                    pBookmarkId.Value = BookmarkId

                    MyCommand.Parameters.Add(pBookmarkFolderId)
                    MyCommand.Parameters.Add(pBookmarkId)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function

        Public Overloads Function DeleteBookmark(ByVal bm As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                If Not bm Is Nothing AndAlso bm.Id > 0 Then

                    If Me.DeleteBookmark(bm.Id, ErrorMessage) = False Then

                        Return False

                    End If

                End If

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function
        Public Overloads Function DeleteBookmark(ByVal BookmarkId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM WV_BOOKMARKS_BOOKMARK_FOLDERS WITH(ROWLOCK) WHERE BOOKMARK_ID = @ID;DELETE FROM WV_BOOKMARKS WITH(ROWLOCK) WHERE ID = @ID;"
                        .Connection = MyConn
                    End With

                    Dim pId As New SqlParameter("@ID", SqlDbType.Int)
                    pId.Value = BookmarkId

                    MyCommand.Parameters.Add(pId)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

#End Region

#Region " Bookmark Folders "

        Public Function CreateFolder(ByRef NewFolder As AdvantageFramework.Web.Presentation.Bookmarks.BookmarkFolder, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim NewFolderId As Integer = 0

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_BOOKMARKS_FOLDER_ADD"
                        .Connection = MyConn
                    End With

                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = NewFolder.UserCode
                    Dim pName As New SqlParameter("@NAME", SqlDbType.VarChar, 50)
                    pName.Value = NewFolder.Name
                    Dim pDescription As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 100)
                    If NewFolder.Description = "" Then
                        pDescription.Value = System.DBNull.Value
                    Else
                        pDescription.Value = NewFolder.Description
                    End If
                    Dim pParentId As New SqlParameter("@PARENT_ID", SqlDbType.Int)
                    pParentId.Value = System.DBNull.Value
                    Dim pSeqNbr As New SqlParameter("@SEQ_NBR", SqlDbType.Int)
                    pSeqNbr.Value = System.DBNull.Value

                    MyCommand.Parameters.Add(pUserCode)
                    MyCommand.Parameters.Add(pName)
                    MyCommand.Parameters.Add(pDescription)
                    MyCommand.Parameters.Add(pParentId)
                    MyCommand.Parameters.Add(pSeqNbr)

                    MyConn.Open()

                    NewFolderId = CType(MyCommand.ExecuteScalar(), Integer)

                    If NewFolderId = -1 Then

                        NewFolder.ErrorMessage = "Folder Exists"
                        ErrorMessage = "Folder Exists"
                        Return False

                    Else

                        NewFolder.Id = NewFolderId

                    End If

                End Using

                NewFolder.ErrorMessage = ""
                ErrorMessage = ""
                Return True

            Catch ex As Exception

                NewFolder.ErrorMessage = ex.Message.ToString()
                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function

        Public Function DeleteFolder(ByVal FolderId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM WV_BOOKMARKS_BOOKMARK_FOLDERS WITH(ROWLOCK) WHERE BOOKMARK_FOLDER_ID = @ID; DELETE FROM WV_BOOKMARK_FOLDERS WITH(ROWLOCK) WHERE ID = @ID;"
                        .Connection = MyConn
                    End With

                    Dim pId As New SqlParameter("@ID", SqlDbType.Int)
                    pId.Value = FolderId

                    MyCommand.Parameters.Add(pId)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

        Public Function UpdateFolderNameAndDescription(ByVal BookmarkFolderId As Integer, ByVal NewName As String, ByVal NewDescription As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                NewName = NewName.Trim()
                NewDescription = NewDescription.Trim()

                If NewName = "" Then

                    ErrorMessage = "Folder name required"
                    Return False

                End If

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE WV_BOOKMARK_FOLDERS WITH(ROWLOCK) SET [NAME] = @NAME, [DESCRIPTION] = @DESCRIPTION WHERE ID = @ID"
                        .Connection = MyConn
                    End With

                    Dim pId As New SqlParameter("@ID", SqlDbType.Int)
                    pId.Value = BookmarkFolderId

                    Dim pName As New SqlParameter("@NAME", SqlDbType.VarChar, 100)
                    pName.Value = NewName

                    Dim pDescription As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 500)
                    If NewDescription.Trim() = "" Then
                        pDescription.Value = System.DBNull.Value
                    Else
                        pDescription.Value = NewDescription
                    End If

                    MyCommand.Parameters.Add(pId)
                    MyCommand.Parameters.Add(pName)
                    MyCommand.Parameters.Add(pDescription)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

#End Region

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            _ConnString = ConnectionString
            _UserCode = UserCode
            _Bookmarks = New List(Of Web.Presentation.Bookmarks.Bookmark)

        End Sub

#End Region

    End Class

End Namespace