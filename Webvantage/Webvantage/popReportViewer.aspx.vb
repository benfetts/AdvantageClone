Imports ActiveReportsAssembly
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.HtmlExport
Imports DataDynamics.ActiveReports.Export.Pdf
Imports DataDynamics.ActiveReports.Export.Xls
Imports DataDynamics.ActiveReports.Export.Html
Imports DataDynamics.ActiveReports.Export.Text
Imports DataDynamics.ActiveReports.Export.Rtf
Imports DataDynamics.ActiveReports.Export.Tiff
Imports DataDynamics.ActiveReports.Web
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Partial Public Class popReportViewer
    Inherits System.Web.UI.Page

#Region " Constants "

    Private Const Delimiter As String = "#"

#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private CurrReport As AdvantageFramework.Reporting.ActiveReports.ReportName
    Private stdate As DateTime
    Private eddate As DateTime

    Private _JobNumber As Integer = 0
    Private _JobComponentNbr As Integer = 0

    Private EstimateNumber As Integer = 0
    Private EstimateComponentNbr As Integer = 0
    Private ClientCode As String = ""
    Private StartDate As DateTime
    Private EndDate As DateTime

    Private ShowHours As Boolean = False

    Private VendorCode As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        LoGlo.PageCultureSet(Me.Page)

    End Sub

    Private _QueryString As AdvantageFramework.Web.QueryString
    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me._QueryString = New AdvantageFramework.Web.QueryString
        Me._QueryString = Me._QueryString.FromCurrent()

        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Not Request.QueryString("JobNum") Is Nothing Then
            If IsNumeric(Request.QueryString("JobNum")) = True Then
                Me._JobNumber = CType(Request.QueryString("JobNum"), Integer)
            End If
        End If
        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Me._JobNumber = 0 Then
            If Not Request.QueryString("job") Is Nothing Then
                If IsNumeric(Request.QueryString("job")) = True Then
                    Me._JobNumber = CType(Request.QueryString("job"), Integer)
                End If
            End If
        End If
        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Me._JobNumber = 0 Then
            If Not Request.QueryString("j") Is Nothing Then
                If IsNumeric(Request.QueryString("j")) = True Then
                    Me._JobNumber = CType(Request.QueryString("j"), Integer)
                End If
            End If
        End If

        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Not Request.QueryString("JobCompNum") Is Nothing Then
            If IsNumeric(Request.QueryString("JobCompNum")) = True Then
                Me._JobComponentNbr = CType(Request.QueryString("JobCompNum"), Integer)
            End If
        End If
        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Me._JobComponentNbr = 0 Then
            If Not Request.QueryString("jobcomp") Is Nothing Then
                If IsNumeric(Request.QueryString("jobcomp")) = True Then
                    Me._JobComponentNbr = CType(Request.QueryString("jobcomp"), Integer)
                End If
            End If
        End If
        'handle all the f'ed up different ways the querystring is being set because no one is using the QueryString class
        If Me._JobComponentNbr = 0 Then
            If Not Request.QueryString("jc") Is Nothing Then
                If IsNumeric(Request.QueryString("jc")) = True Then
                    Me._JobComponentNbr = CType(Request.QueryString("jc"), Integer)
                End If
            End If
        End If


        'maybe this is cleaner...
        If Not Request.QueryString("EstNum") Is Nothing Then
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                Me.EstimateNumber = CType(Request.QueryString("EstNum"), Integer)
            End If
        End If
        If Not Request.QueryString("EstCompNum") Is Nothing Then
            If IsNumeric(Request.QueryString("EstCompNum")) = True Then
                Me.EstimateComponentNbr = CType(Request.QueryString("EstCompNum"), Integer)
            End If
        End If

        If Not Request.QueryString("cl") Is Nothing Then

            Me.ClientCode = Request.QueryString("cl")

        End If

        If Not Request.QueryString("startDate") Is Nothing Then

            If IsDate(Request.QueryString("startDate")) = True Then

                Me.StartDate = CType(Request.QueryString("startDate"), DateTime)

            End If

        End If
        If Not Request.QueryString("endDate") Is Nothing Then

            If IsDate(Request.QueryString("endDate")) = True Then

                Me.EndDate = CType(Request.QueryString("endDate"), DateTime)

            End If

        End If
        If Not Request.QueryString("hours") Is Nothing Then
            If IsNumeric(Request.QueryString("hours")) = True Then
                Me.ShowHours = CType(Request.QueryString("hours"), Integer) = 1
            End If
        End If
        If Not Request.QueryString("VendorCode") Is Nothing Then

            Me.VendorCode = Request.QueryString("VendorCode")

        End If

        'Let querystring class have final say:
        If Me._QueryString.JobNumber > 0 Then Me._JobNumber = Me._QueryString.JobNumber
        If Me._QueryString.JobComponentNumber > 0 Then Me._JobComponentNbr = Me._QueryString.JobComponentNumber
        If Me._QueryString.EstimateNumber > 0 Then Me.EstimateNumber = Me._QueryString.EstimateNumber
        If Me._QueryString.EstimateComponentNumber > 0 Then Me.EstimateComponentNbr = Me._QueryString.EstimateComponentNumber
        If Me._QueryString.ClientCode <> "" Then Me.ClientCode = _QueryString.ClientCode
        If Me._QueryString.StartDate <> "" AndAlso IsDate(Me._QueryString.StartDate) Then Me.StartDate = CType(Me._QueryString.StartDate, DateTime)
        If Me._QueryString.EndDate <> "" AndAlso IsDate(Me._QueryString.EndDate) Then Me.EndDate = CType(Me._QueryString.EndDate, DateTime)
        If Me._QueryString.GetValue("hours") <> "" Then Me.ShowHours = Me._QueryString.GetValue("hours") = "1"
        If Me._QueryString.VendorCode <> "" Then Me.VendorCode = Me._QueryString.VendorCode

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Try
                        With HttpContext.Current.Response
                            .Clear()
                            .ClearHeaders()
                            .ClearContent()
                        End With

                        Dim type As String = Request.QueryString("Type")
                        Dim CurrType As AdvantageFramework.Reporting.ActiveReports.ExportType = CType(type, AdvantageFramework.Reporting.ActiveReports.ExportType)

                        Dim report As String = Request.QueryString("Report")

                        Select Case report
                            Case "OpenJobs"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobs)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobs
                            Case "OpenJobsSC"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsSC)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsSC
                            Case "clientarstatement001"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement001)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement001
                            Case "clientarstatement002"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement002)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement002
                            Case "clientarstatement003"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement003)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement003
                            Case "clientarstatement004"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement004)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement004
                            Case "clientarstatement005"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement005)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement005
                            Case "productarstatement001"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement001)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement001
                            Case "productarstatement002"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement002)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement002
                            Case "productarstatement003"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement003)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement003
                            Case "productarstatement004"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement004)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement004
                            Case "tasklist"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TaskList)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TaskList
                            Case "tasklistduedate"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListDueDate)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListDueDate
                            Case "tasklisttask"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListTask)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListTask
                            Case "mytasklist"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskList)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskList
                            Case "mytasklistduedate"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListDueDate)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListDueDate
                            Case "mytasklisttask"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListTask)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListTask
                            Case "mediareport"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.MediaReport)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.MediaReport
                            Case "purchaseorder"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder
                            Case "timesheetprint"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TimeSheetPrint)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TimeSheetPrint
                            Case "purchaseorder001"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder001)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder001
                            Case "JobTemplate"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate
                            Case "OpenJobsFSN"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsFSN)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsFSN
                            Case "JobSpecs"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecs)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecs
                            Case "SumRepByClient"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClient)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClient
                            Case "TrafficDetailByJob"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob
                            Case "EmpNPTime"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EmpNPTime)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EmpNPTime
                            Case "JobVersion"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersion)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersion
                            Case "TaskCalendar"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TaskCalendar)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TaskCalendar
                            Case "BillingApproval"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval
                            Case "BillingApproval2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval2
                            Case "BillingApprovalReport"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalReport)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalReport
                            Case "JobVersions"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersions)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersions
                            Case "JobSpecsAllVersions"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecsAllVersions)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecsAllVersions
                            Case "BillingApprovalJobOnly"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalJobOnly)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalJobOnly
                            Case "Estimating"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating
                            Case "BillingApproval4"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval4)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval4
                            Case "CreativeBrief"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.CreativeBrief)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.CreativeBrief
                            Case "Estimating002"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating002)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating002
                            Case "Estimating003"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating003)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating003
                            Case "Estimating004"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating004)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating004
                            Case "Estimating005"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating005)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating005
                            Case "Estimating006"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating006)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating006
                            Case "Estimating007"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating007)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating007
                            Case "purchaseorder2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder2
                            Case "mytasklistsummary"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListSummary)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListSummary
                            Case "EstimatingSS1"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS1)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS1
                            Case "EstimatingSS2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS2
                            Case "SumRepByClientSalesClass"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClientSalesClass)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClientSalesClass
                            Case "CompletedTaskReport"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.CompletedTaskReport)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.CompletedTaskReport
                            Case "Campaign"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Campaign)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Campaign
                            Case "VendorQuoteRequest"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.VendorQuoteRequest)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.VendorQuoteRequest
                            Case "Estimating008"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008
                            Case "TrafficDetailByJobDueDate"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate
                            Case "Estimating009"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008
                            Case "EstimatingQUR"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingQUR)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingQUR
                            Case "JobTemplate002"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate002)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate002
                            Case "JobTemplate003"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate003)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate003
                            Case "TrafficDetailByJob2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob2
                            Case "EstimatingMars"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars
                            Case "Estimating304"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304
                            Case "Estimating305"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305
                            Case "purchaseorderRR"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrderRR)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrderRR
                            Case "EstimatingInfinity"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingInfinity)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingInfinity
                            Case "purchaseorder3"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder3)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder3
                            Case "EstimatingBWD"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD
                            Case "EstimatingBWD2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2
                            Case "TrafficDetailByJob3"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3
                            Case "EstimatingTPN"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN
                            Case "EstimatingTPN2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2
                            Case "EstimatingTAP"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP
                            Case "EstimatingTAP2"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP2)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP2
                            Case "Estimating313"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating313)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating313
                            Case "Estimating314"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314
                            Case "Estimating315"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315
                            Case "TrafficDetailByJobDays"
                                GetReport(CurrType, AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDays)
                                Me.CurrReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDays
                        End Select
                    Catch exThread As System.Threading.ThreadAbortException

                    Catch ex As Exception
                        Response.Write("popPageload: " & ex.Message.ToString())
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        Session("ARPrintIDs") = Nothing
        Session("ARPrintOfficeCodes") = Nothing

        Try
            Select Case Me.CurrReport
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobs
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskList
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListTask
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListDueDate
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement001
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement002
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement003
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement004
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement001
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement002
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement003
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement004
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement005
                    Session("ARPrintOfficeCodes") = Nothing
                    Session("ARPrintIDs") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MediaReport
                    Session("mtfSClientText") = Nothing
                    Session("mtfSDivisionText") = Nothing
                    Session("mtfSProductText") = Nothing
                    Session("MediaCalType") = Nothing
                    Session("LogoPath") = Nothing
                    Session("MediaSchPrintText") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsSC
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder
                    Session("POPrintLocationPath") = Nothing
                    Session("POPrintLocationID") = Nothing
                    Session("POPrintDate") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TimeSheetPrint
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder001
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate
                    Session("IncludeJOFReport") = Nothing
                    Session("OmitEFReport") = Nothing
                    Session("IncludeTAReport") = Nothing
                    Session("TASectionTitle") = Nothing
                    Session("IncludeTSReport") = Nothing
                    Session("TSScheduleComments") = Nothing
                    Session("TSSectionTitle") = Nothing
                    Session("TSDueDatesOnly") = Nothing
                    Session("TSMilestonesOnly") = Nothing
                    Session("TSMilestoneTitle") = Nothing
                    Session("TSEmpAssignments") = Nothing
                    Session("JobOrderFormLogoLocation") = Nothing
                    Session("JobOrderFormLogoPlacement") = Nothing
                    Session("JobOrderFormLogoLocationID") = Nothing
                    Session("JobOrderFormLogoLocationID") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsFSN
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskList
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListTask
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListDueDate
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecs
                    Session("JSIncludeVS") = Nothing
                    Session("JSIncludeMS") = Nothing
                    Session("JSLogoLocation") = Nothing
                    Session("JSLogoPlacement") = Nothing
                    Session("JSLogoLocationID") = Nothing
                    Session("JSOmitEmptyFields") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClient
                    Session("ProjectSummaryRPT") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob
                    Session("PSLogoLocation") = Nothing
                    Session("PSLogoPlacement") = Nothing
                    Session("PSLogoLocationID") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate
                    Session("PSLogoLocation") = Nothing
                    Session("PSLogoPlacement") = Nothing
                    Session("PSLogoLocationID") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.EmpNPTime
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersion
                    Session("versionNbr") = Nothing
                    Session("JVDescription") = Nothing
                    Session("JVReportTitle") = Nothing
                    Session("JVLogoLocation") = Nothing
                    Session("JVLogoPlacement") = Nothing
                    Session("JVLogoLocationID") = Nothing
                    Session("JVLogoLocationID") = Nothing
                    Session("JVOmitEmptyFields") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskCalendar
                    Session("LogoPath") = Nothing
                    Session("TBTitle") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval '- Billing Approval Function Heading/Comp
                    Session("BAPrintLocationPath") = Nothing
                    Session("BAPrintLocationID") = Nothing
                    Session("BAClientNamePrint") = Nothing
                    Session("BAClientPrint") = Nothing
                    Session("BADivisionPrint") = Nothing
                    Session("BAProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval2
                    Session("BAPrintLocationPath") = Nothing
                    Session("BAPrintLocationID") = Nothing
                    Session("BAClientNamePrint") = Nothing
                    Session("BAClientPrint") = Nothing
                    Session("BADivisionPrint") = Nothing
                    Session("BAProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalReport
                    Session("BAPrintLocationPath") = Nothing
                    Session("BAPrintLocationID") = Nothing
                    Session("BAClientNamePrint") = Nothing
                    Session("BAClientPrint") = Nothing
                    Session("BADivisionPrint") = Nothing
                    Session("BAProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersions 'Job Versions
                    Session("JVReportTitle") = Nothing
                    Session("JobOrderFormLogoLocation") = Nothing
                    Session("JobOrderFormLogoPlacement") = Nothing
                    Session("JobOrderFormLogoLocationID") = Nothing
                    Session("OmitEmptyFieldsJV") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecsAllVersions
                    Session("UserCode") = Nothing
                    Session("JSReportTitle") = Nothing
                    Session("JSApproveOnly") = Nothing
                    Session("OmitEmptyFieldsJS") = Nothing
                    Session("JSIncludeVS") = Nothing
                    Session("JSIncludeMS") = Nothing
                    Session("JobOrderFormLogoLocation") = Nothing
                    Session("JobOrderFormLogoPlacement") = Nothing
                    Session("JobOrderFormLogoLocationID") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalJobOnly
                    Session("BAPrintLocationPath") = Nothing
                    Session("BAPrintLocationID") = Nothing
                    Session("BAClientNamePrint") = Nothing
                    Session("BAClientPrint") = Nothing
                    Session("BADivisionPrint") = Nothing
                    Session("BAProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315
                    Session("EstimatingLogoLocation") = Nothing
                    Session("EstimatingLogoLocationID") = Nothing
                    Session("EstimatingPrintedDate") = Nothing
                    Session("EstimatingDefFooter") = Nothing
                    Session("EstimatingDefaultFooterFontSize") = Nothing
                    Session("EstimatingClientPrint") = Nothing
                    Session("EstimatingDivisionPrint") = Nothing
                    Session("EstimatingProductPrint") = Nothing
                    Session("EstimatingSignature") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval4
                    Session("BAPrintLocationPath") = Nothing
                    Session("BAPrintLocationID") = Nothing
                    Session("BAClientNamePrint") = Nothing
                    Session("BAClientPrint") = Nothing
                    Session("BADivisionPrint") = Nothing
                    Session("BAProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.CreativeBrief
                    Session("CBReportTitle") = Nothing
                    Session("CBLogoLocation") = Nothing
                    Session("CBLogoPlacement") = Nothing
                    Session("CBLogoLocationID") = Nothing
                    Session("OmitEmptyFieldsCB") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating002
                    Session("EstimatingLogoLocation") = Nothing
                    Session("EstimatingLogoLocationID") = Nothing
                    Session("EstimatingPrintedDate") = Nothing
                    Session("EstimatingDefFooter") = Nothing
                    Session("EstimatingDefaultFooterFontSize") = Nothing
                    Session("EstimatingClientPrint") = Nothing
                    Session("EstimatingDivisionPrint") = Nothing
                    Session("EstimatingProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating003, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating004, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating005, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating006, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating007, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305
                    Session("EstimatingLogoLocation") = Nothing
                    Session("EstimatingLogoLocationID") = Nothing
                    Session("EstimatingPrintedDate") = Nothing
                    Session("EstimatingDefFooter") = Nothing
                    Session("EstimatingDefaultFooterFontSize") = Nothing
                    Session("EstimatingClientPrint") = Nothing
                    Session("EstimatingDivisionPrint") = Nothing
                    Session("EstimatingProductPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder2
                    Session("POPrintLocationPath") = Nothing
                    Session("POPrintLocationID") = Nothing
                    Session("POPrintDate") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListSummary
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS1, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS2, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008, AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating009, AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingQUR
                    Session("EstimatingClientPrint") = Nothing
                    Session("EstimatingDivisionPrint") = Nothing
                    Session("EstimatingProductPrint") = Nothing
                    Session("EstimatingLogoLocation") = Nothing
                    Session("EstimatingLogoLocationID") = Nothing
                    Session("EstimatingPrintedDate") = Nothing
                    Session("EstimatingDefFooter") = Nothing
                    Session("EstimatingDefaultFooterFontSize") = Nothing
                    Session("EstimatingSignature") = Nothing
                    Session("EstimatingJobPrint") = Nothing
                    Session("EstimatingCompPrint") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClientSalesClass
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.CompletedTaskReport
                    Session("CompletedTaskReportData") = Nothing
                    Session("TrafficByTaskReportTitle") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Campaign
                    Session("CampaignLogoLocation") = Nothing
                    Session("CampaignLogoLocationID") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.VendorQuoteRequest
                    Session("VendorsRFQVendors") = Nothing
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate002, AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate003
                    Session("IncludeJOFReport") = Nothing
                    Session("OmitEFReport") = Nothing
                    Session("IncludeTAReport") = Nothing
                    Session("TASectionTitle") = Nothing
                    Session("IncludeTSReport") = Nothing
                    Session("TSScheduleComments") = Nothing
                    Session("TSSectionTitle") = Nothing
                    Session("TSDueDatesOnly") = Nothing
                    Session("TSMilestonesOnly") = Nothing
                    Session("TSMilestoneTitle") = Nothing
                    Session("TSEmpAssignments") = Nothing
                    Session("JobOrderFormReportTitle") = Nothing
                    Session("JobOrderFormLogoLocation") = Nothing
                    Session("JobOrderFormLogoPlacement") = Nothing
                    Session("JobOrderFormLogoLocationID") = Nothing
                    Session("JobOrderPrintDate") = Nothing
                    Session("JobOrderFormSignatureFormat") = Nothing
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType(), "CloseWindow", "window.close();", True)

    End Sub

#End Region

#Region " Controls Events "



#End Region

#Region " Methods "

    Protected Sub GetReport(ByVal TypeOfExport As AdvantageFramework.Reporting.ActiveReports.ExportType, ByVal TypeOfReport As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByVal strFileName As String = "")

        Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
        Dim rpt
        Dim rpt2
        Dim oReports As New cReports(Session("ConnString"))

        Dim strReportName As String
        Dim sdate As String = ""
        Dim edate As String = ""
        Dim flgNoData As Boolean = False
        Dim strURL As String = ""
        Dim dt As DataTable
        Dim EmpRole As Integer

        Dim CurrentCultureCode As String = LoGlo.UserCultureGet()

        Try
            Select Case TypeOfReport
                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval '- Billing Approval Function Heading/Comp

                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptBillingApproval
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("BAPrintLocationPath")
                    rpt.LogoID = Session("BAPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.clname = Session("BAClientNamePrint")
                    rpt.printDivName = Request.QueryString("PrintDivName")
                    rpt.printPrdDesc = Request.QueryString("PrintPrdDesc")
                    rpt.title = Request.QueryString("Title")
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfo(Request.QueryString("option"), Session("BAClientPrint"), Session("BADivisionPrint"), Session("BAProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("BAPrintLocationID"))
                    rpt.estComment = cr.GetAgencyEstComment()
                    rpt.dt = ba.GetBAData(CInt(Request.QueryString("AID")), 1, Request.QueryString("PrintZero"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval2

                    '- Billing Approval Comp/Function Heading
                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptBillingApproval2
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("BAPrintLocationPath")
                    rpt.LogoID = Session("BAPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.clname = Session("BAClientNamePrint")
                    rpt.printDivName = Request.QueryString("PrintDivName")
                    rpt.printPrdDesc = Request.QueryString("PrintPrdDesc")
                    rpt.title = Request.QueryString("Title")
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfo(Request.QueryString("option"), Session("BAClientPrint"), Session("BADivisionPrint"), Session("BAProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("BAPrintLocationID"))
                    rpt.estComment = cr.GetAgencyEstComment()
                    rpt.dt = ba.GetBAData(CInt(Request.QueryString("AID")), 2, Request.QueryString("PrintZero"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApproval4

                    '- Billing Approval Campaign Component
                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptBillingApproval4
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("BAPrintLocationPath")
                    rpt.LogoID = Session("BAPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.clname = Session("BAClientNamePrint")
                    rpt.printDivName = Request.QueryString("PrintDivName")
                    rpt.printPrdDesc = Request.QueryString("PrintPrdDesc")
                    rpt.title = Request.QueryString("Title")
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfo(Request.QueryString("option"), Session("BAClientPrint"), Session("BADivisionPrint"), Session("BAProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("BAPrintLocationID"))
                    rpt.estComment = cr.GetAgencyEstComment()
                    rpt.dt = ba.GetBAData(CInt(Request.QueryString("AID")), 3, Request.QueryString("PrintZero"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalJobOnly

                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptBillingApprovalJobOnly
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("BAPrintLocationPath")
                    rpt.LogoID = Session("BAPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.clname = Session("BAClientNamePrint")
                    rpt.printDivName = Request.QueryString("PrintDivName")
                    rpt.printPrdDesc = Request.QueryString("PrintPrdDesc")
                    rpt.title = Request.QueryString("Title")
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfo(Request.QueryString("option"), Session("BAClientPrint"), Session("BADivisionPrint"), Session("BAProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("BAPrintLocationID"))
                    rpt.estComment = cr.GetAgencyEstComment()
                    rpt.dt = ba.GetBAData(CInt(Request.QueryString("AID")), 1, Request.QueryString("PrintZero"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.BillApprovalReport

                    '- Default Billing Approval
                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptBillingApprovalReport
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("BAPrintLocationPath")
                    rpt.LogoID = Session("BAPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.clname = Session("BAClientNamePrint")
                    rpt.printDivName = Request.QueryString("PrintDivName")
                    rpt.printPrdDesc = Request.QueryString("PrintPrdDesc")
                    rpt.title = Request.QueryString("Title")
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfo(Request.QueryString("option"), Session("BAClientPrint"), Session("BADivisionPrint"), Session("BAProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("BAPrintLocationID"))
                    rpt.estComment = cr.GetAgencyEstComment()
                    rpt.dt = ba.GetBADataDefault(CInt(Request.QueryString("AID")), 1, Request.QueryString("PrintZero"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Campaign

                    rpt = New ActiveReportsAssembly.arptCampaign001
                    rpt.CultureCode = CurrentCultureCode

                    strReportName = "campaignReport0001"
                    rpt.LogoPath = Session("CampaignLogoLocation")
                    rpt.LogoID = Session("CampaignLogoLocationID")
                    rpt.imgPath = imgPath
                    rpt.dtData = oReports.GetCampaignSummarybyJobBudgetVariance(Request.QueryString("cmp"), Request.QueryString("StartPeriod"), Request.QueryString("EndPeriod"), Request.QueryString("StartDate"), Request.QueryString("EndDate"))
                    rpt.dtLocation = oReports.GetAgencyInfoJobTemplate(Session("CampaignLogoLocationID"))

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement

                    rpt = New ActiveReportsAssembly.arptClientARStatement
                    strReportName = "Client_AR_Statement"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement001

                    rpt = New ActiveReportsAssembly.arptClientARStatement001
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", StrOffices, Request.QueryString("aging"))
                    strReportName = "Client_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If


                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement002

                    rpt = New ActiveReportsAssembly.arptClientARStatement002
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    'rpt.strFooter = Request.QueryString("Footer")
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "2", StrOffices, Request.QueryString("aging"))
                    strReportName = "Client_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement003

                    rpt = New ActiveReportsAssembly.arptClientARStatement003
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    'rpt.strFooter = Request.QueryString("Footer")
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "3", StrOffices, Request.QueryString("aging"))
                    strReportName = "Client_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement004

                    rpt = New ActiveReportsAssembly.arptClientARStatement004
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    'rpt.strFooter = Request.QueryString("Footer")
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "4", StrOffices, Request.QueryString("aging"))
                    strReportName = "Client_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ClientARStatement005

                    rpt = New ActiveReportsAssembly.arptClientARStatement005
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    'rpt.strFooter = Request.QueryString("Footer")
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", StrOffices, Request.QueryString("aging"))
                    strReportName = "Client_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.CompletedTaskReport

                    rpt = New ActiveReportsAssembly.arptCompletedTask
                    rpt.CultureCode = CurrentCultureCode
                    rpt.dtData = Session("CompletedTaskReportData")
                    rpt.title = Session("TrafficByTaskReportTitle")
                    rpt.dateoption = Request.QueryString("dateoption")
                    rpt.strUserID = Session("UserCode")

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.CreativeBrief

                    'Creative Brief
                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
                    Dim dr As SqlClient.SqlDataReader
                    Dim jl As New JOB_LOG(Session("ConnString"))
                    Dim jc As New JOB_COMPONENT(Session("ConnString"))
                    Dim job_nbr As Integer
                    Dim job_comp As Int16
                    Dim job_str As String

                    jl.LoadByPrimaryKey(CInt(Me._JobNumber))
                    jc.LoadByPrimaryKey(CInt(Me._JobComponentNbr), CInt(Me._JobNumber))

                    rpt = New ActiveReportsAssembly.arptCreativeBrief
                    rpt.CultureCode = CurrentCultureCode
                    rpt.mConnectionString = Session("ConnString")
                    rpt.UserCode = Session("UserCode")
                    rpt.Description = "Creative Brief"

                    job_nbr = Me._JobNumber
                    job_str = job_nbr.ToString.PadLeft(6, "0")
                    rpt.job = job_str
                    rpt.jobDesc = jl.JOB_DESC
                    rpt.jobNbr = job_nbr

                    job_comp = Me._JobComponentNbr
                    job_str = job_comp.ToString.PadLeft(2, "0")
                    rpt.jobcomp = job_str
                    rpt.compDesc = jc.JOB_COMP_DESC
                    rpt.jobCompNbr = job_comp

                    dr = js.GetJobSpecCDP(CInt(Me._JobNumber))
                    dr.Read()
                    rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                    rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                    rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                    rpt.cl_code = dr.GetString(1)
                    rpt.div_code = dr.GetString(3)
                    rpt.prd_code = dr.GetString(5)
                    dr.Close()

                    rpt.Reporter = Session("UserCode")
                    rpt.ReportTitle = Session("CBReportTitle")

                    strReportName = "CreativeBrief"
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("CBLogoLocation")
                    rpt.LogoPlacement = Session("CBLogoPlacement")
                    rpt.LogoID = Session("CBLogoLocationID")
                    rpt.omitEmptyFields = Session("OmitEmptyFieldsCB")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("CBLogoLocationID"))

                    If Session("CBLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("CBLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.EmpNPTime

                    rpt = New ActiveReportsAssembly.arptEmpNPTime
                    rpt.CultureCode = CurrentCultureCode

                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.sort = Request.QueryString("SortOrder")
                    rpt.office = Request.QueryString("Office")
                    rpt.super = Request.QueryString("super")
                    rpt.emp = Request.QueryString("emp")
                    rpt.dept = Request.QueryString("dept")
                    rpt.StartDate = Request.QueryString("StartDate")
                    rpt.EndDate = Request.QueryString("EndDate")
                    rpt.inclTermEmp = Request.QueryString("inclTermEmp")

                    rpt.dt = oReports.GetEmpNPTimeData(rpt.strUserID, rpt.sort, rpt.office, rpt.super, rpt.emp, rpt.dept, rpt.StartDate, rpt.EndDate, rpt.inclTermEmp, Request.QueryString("bytype"), Request.QueryString("excludeFree"))

                    strReportName = "EmpIndirectTime"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingInfinity,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN,
                 AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315

                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim dtEst As DataTable
                    Dim dtComments As DataTable
                    Dim dtCompComments As DataTable
                    Dim dtPD As DataTable
                    Dim foption As String
                    Dim goption As String
                    Dim fnccmt As String
                    Dim ds As DataSet
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating Then
                        rpt = New ActiveReportsAssembly.arptEstimating
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars Then
                        rpt = New ActiveReportsAssembly.arptEstimatingMars
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingInfinity Then
                        rpt = New ActiveReportsAssembly.arptEstimatingInfinity
                        Dim job As New Job(Session("ConnString"))
                        job.GetJob(Session("EstimatingJobPrint"), Session("EstimatingCompPrint"))
                        rpt.JobComments = job.JOB_COMMENTS
                        rpt.JobCompComments = job.JobComponent.JOB_COMP_COMMENTS
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD Then
                        rpt = New ActiveReportsAssembly.arptEstimatingBWD1
                        rpt.LocationCode = Session("EstimatingLogoLocationID")
                        rpt.LocationName = Session("EstimatingLogoLocationName")
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2 Then
                        rpt = New ActiveReportsAssembly.arptEstimatingBWD2
                        rpt.LocationCode = Session("EstimatingLogoLocationID")
                        rpt.LocationName = Session("EstimatingLogoLocationName")
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN Then
                        rpt = New ActiveReportsAssembly.arptEstimatingTPN
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315 Then
                        rpt = New ActiveReportsAssembly.arptEstimating315
                    End If
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("EstimatingLogoLocation")
                    rpt.LogoID = Session("EstimatingLogoLocationID")
                    rpt.imgPath = imgPath
                    rpt.printedDate = Session("EstimatingPrintedDate")
                    rpt.defFooter = Session("EstimatingDefFooter")
                    rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                    rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Request.QueryString("option"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                    rpt.signature = Session("EstimatingSignature")
                    rpt.agencyname = cr.GetAgencyName()
                    If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                        rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating Then
                        rpt.IncludeRate = Request.QueryString("IncludeRate")
                    End If

                    Dim cEmp As New cEmployee(Session("ConnString"))

                    Try
                        Dim sig As String = Request.QueryString("UseEmpSig")
                        If sig = "0" Then
                            rpt.UseEmpSig = True
                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        Else
                            rpt.UseEmpSig = False
                        End If

                    Catch ex As Exception
                    End Try

                    If Session("EstimatingLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If Request.QueryString("combine") = "1" Then
                        rpt.combined = True
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2 Then
                            dtEst = est.getPrintDetailsCombinedBWD(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), 1)
                        Else
                            dtEst = est.getPrintDetailsCombined(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), "cb")
                            If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN Then
                                ds = est.getPrintDetailsDS(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                                If ds.Tables.Count > 1 Then
                                    rpt.dtlabels = ds.Tables(1)
                                End If
                            End If
                        End If
                        If dtEst.Rows.Count > 0 Then
                            For x As Integer = 0 To dtEst.Rows.Count - 1
                                dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                dtCompComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), "", Session("UserCode"))
                                If dtCompComments.Rows.Count > 0 Then
                                    Dim compcomments As String = ""
                                    Dim cc As String = ""
                                    For y As Integer = 0 To dtCompComments.Rows.Count - 1
                                        'If dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML") <> "" And dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML").ToString.Trim <> cc.Trim Then
                                        '    compcomments &= dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML") & vbCrLf
                                        '    cc = dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML")
                                        'Else
                                        If dtCompComments.Rows(y)("EST_COMP_COMMENT") <> "" And dtCompComments.Rows(y)("EST_COMP_COMMENT").ToString.Trim <> cc.Trim Then
                                            compcomments &= dtCompComments.Rows(y)("EST_COMP_COMMENT") & vbCrLf
                                            cc = dtCompComments.Rows(y)("EST_COMP_COMMENT")
                                        End If
                                    Next
                                    dtEst.Rows(x)("EST_COMP_COMMENT") = compcomments
                                End If
                                If dtComments.Rows.Count > 0 Then
                                    Dim qtecomments As String = ""
                                    Dim comments As String = ""
                                    Dim supcomments As String = ""
                                    For y As Integer = 0 To dtComments.Rows.Count - 1
                                        If dtComments.Rows(y)("EST_QTE_COMMENT") <> "" Then
                                            qtecomments = dtComments.Rows(y)("EST_QTE_COMMENT") & vbCrLf
                                        End If
                                        If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                            comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                        End If
                                        If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                            supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                        End If
                                    Next
                                    dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                    dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                    'dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                    dtEst.Rows(x)("EST_QTE_COMMENT") = qtecomments
                                    'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                End If
                            Next
                        End If
                        rpt.dt = dtEst
                    Else
                        dtPD = est.GetPrintDefDT(Session("UserCode"))
                        If dtPD.Rows.Count > 0 Then
                            goption = dtPD.Rows(0)("GROUP_OPTION")
                        End If
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating315 Then
                            If goption = "HT" Then
                                dtEst = est.getPrintDetailsFH(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                            Else
                                dtEst = est.getPrintDetails(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                            End If
                        End If
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN Then
                            If goption = "HT" Then
                                dtEst = est.getPrintDetailsFH(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                            Else
                                dtEst = est.getPrintDetails(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                                ds = est.getPrintDetailsDS(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                                If ds.Tables.Count > 1 Then
                                    rpt.dtlabels = ds.Tables(1)
                                End If
                            End If
                        End If
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingMars Then
                            dtEst = est.getPrintDetailsCombined(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), "jc")
                        End If
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingInfinity Then
                            dtEst = est.getPrintDetails(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                        End If
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingBWD2 Then
                            dtEst = est.getPrintDetailsBWD(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), 0)
                        End If
                        If dtPD.Rows.Count > 0 Then
                            foption = dtPD.Rows(0)("FUNCTION_OPTION")
                            fnccmt = dtPD.Rows(0)("FUNC_COMMENT")
                        End If
                        If foption <> "N" Then
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    If goption = "HT" Then
                                        dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                        If dtComments.Rows.Count > 0 Then
                                            Dim commentsfnc As String = ""
                                            For y As Integer = 0 To dtComments.Rows.Count - 1
                                                If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                    commentsfnc &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                End If
                                            Next
                                            dtEst.Rows(x)("EST_FNC_COMMENT") = commentsfnc
                                            dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                            dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                            dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                            dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                        End If
                                    Else
                                        dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), IIf(IsDBNull(dtEst.Rows(x)("EST_REV_RATE")), 0, dtEst.Rows(x)("EST_REV_RATE")), Session("UserCode"))
                                        If dtComments.Rows.Count > 0 Then
                                            Dim comments As String = ""
                                            Dim supcomments As String = ""
                                            For y As Integer = 0 To dtComments.Rows.Count - 1
                                                If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                    comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                End If
                                                If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                    supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                                End If
                                            Next
                                            dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                            dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                            dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                            dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                            dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                            dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        rpt.dt = dtEst
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating002,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314

                    '- Estimating002 - Quote Side By Side
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim dtEst As DataTable
                    Dim dtComments As DataTable
                    Dim dtCompComments As DataTable
                    Dim dtPD As DataTable
                    Dim foption As String
                    Dim max As Integer
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating002 Then
                        rpt = New ActiveReportsAssembly.arptEstimating002
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314 Then
                        rpt = New ActiveReportsAssembly.arptEstimating314
                    End If
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("EstimatingLogoLocation")
                    rpt.LogoID = Session("EstimatingLogoLocationID")
                    rpt.imgPath = imgPath
                    rpt.printedDate = Session("EstimatingPrintedDate")
                    rpt.defFooter = Session("EstimatingDefFooter")
                    rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                    rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Request.QueryString("option"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                    rpt.quotes = Request.QueryString("quotes")
                    rpt.agencyname = cr.GetAgencyName()
                    If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                        rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                    End If


                    Dim cEmp As New cEmployee(Session("ConnString"))

                    Try
                        Dim sig As String = Request.QueryString("UseEmpSig")
                        If sig = "0" Then
                            rpt.UseEmpSig = True
                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        Else
                            rpt.UseEmpSig = False
                        End If

                    Catch ex As Exception
                    End Try

                    If Session("EstimatingLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If Request.QueryString("combine") = "1" Then
                        rpt.quotedescs = Session("EstimatingQteDescs")
                        rpt.combined = True
                        rpt.comps = Request.QueryString("comps")
                        dtEst = est.getPrintDetails002Combined(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), 0)
                        If dtEst.Rows.Count > 0 Then
                            For x As Integer = 0 To dtEst.Rows.Count - 1
                                If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314 Then
                                    dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), 1, dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                Else
                                    dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), 0, dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                End If
                                dtCompComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), 0, "", Session("UserCode"))
                                If dtCompComments.Rows.Count > 0 Then
                                    Dim compcomments As String = ""
                                    Dim cc As String = ""
                                    Dim cps As String = Request.QueryString("comps")
                                    For y As Integer = 0 To dtCompComments.Rows.Count - 1
                                        'If dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML") <> "" And cps.Contains(dtCompComments.Rows(y)("EST_COMPONENT_NBR").ToString()) = True And dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML").ToString.Trim <> cc.Trim Then
                                        '    compcomments &= dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML") & vbCrLf
                                        '    cc = dtCompComments.Rows(y)("EST_COMP_COMMENT_HTML")
                                        'Else
                                        If dtCompComments.Rows(y)("EST_COMP_COMMENT") <> "" And cps.Contains(dtCompComments.Rows(y)("EST_COMPONENT_NBR").ToString()) = True And dtCompComments.Rows(y)("EST_COMP_COMMENT").ToString.Trim <> cc.Trim Then
                                            compcomments &= dtCompComments.Rows(y)("EST_COMP_COMMENT") & vbCrLf
                                            cc = dtCompComments.Rows(y)("EST_COMP_COMMENT")
                                        End If
                                    Next
                                    dtEst.Rows(x)("EST_COMP_COMMENT") = compcomments
                                End If
                                If dtComments.Rows.Count > 0 Then
                                    'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                    'Else
                                    '    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                    'End If
                                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314 Then
                                        Dim comments As String = ""
                                        For y As Integer = 0 To dtComments.Rows.Count - 1
                                            'If dtComments.Rows(y)("EST_FNC_COMMENT_HTML") <> "" Then
                                            '    comments = dtComments.Rows(y)("EST_FNC_COMMENT_HTML") & vbCrLf
                                            'Else
                                            If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                            End If
                                        Next
                                        dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                    End If
                                End If
                            Next
                        End If
                        rpt.dt = dtEst
                    Else
                        rpt.quotedescs = Session("EstimatingQteDescs" & Request.QueryString("EstCompNum"))
                        dtPD = est.GetPrintDefDT(Session("UserCode"))
                        dtEst = est.getPrintDetails002(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), 0)
                        If dtPD.Rows.Count > 0 Then
                            foption = dtPD.Rows(0)("FUNCTION_OPTION")
                        End If
                        If foption <> "N" Then
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    Dim comments As String = ""
                                    dtComments = est.GetEstimateData(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 0, 0, Session("UserCode"))
                                    If dtComments.Rows.Count > 0 Then
                                        'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                        'Else
                                        'dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                        'End If
                                        'If dtComments.Rows(0)("EST_COMP_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                        ' Else
                                        '    dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT_HTML")
                                        'End If
                                    End If
                                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating314 Then
                                        max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 1)
                                        dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 1, max, dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                        If dtComments.Rows.Count > 0 Then
                                            For y As Integer = 0 To dtComments.Rows.Count - 1
                                                If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                    comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                End If
                                            Next
                                            dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                        End If
                                    End If
                                Next
                            End If
                        End If

                        rpt.dt = dtEst
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating003,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating004,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating005,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating006,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating007,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2,
                          AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating313

                    '41, 42, 43, 44, 45 '- Estimating003 - Revision Comparison, Estimating004 - Revision Comparison w/Variance, Estimating005 - Revision Comparison w/Variance, Estimating006 - Revision Comparison No Actual, Estimating007 - Revision Comparison Prev/Last Rev
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim dtEst As DataTable
                    Dim dtComments As DataTable
                    Dim dtPD As DataTable
                    Dim ds As DataSet
                    Dim foption As String
                    Dim max As Integer
                    Dim type As Integer = 0
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating003 Then
                        rpt = New ActiveReportsAssembly.arptEstimating003
                        type = 3
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating004 Then
                        rpt = New ActiveReportsAssembly.arptEstimating004
                        type = 4
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating005 Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304 Then
                        rpt = New ActiveReportsAssembly.arptEstimating005
                        type = 5
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating006 Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305 Then
                        rpt = New ActiveReportsAssembly.arptEstimating006
                        type = 6
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating007 Then
                        rpt = New ActiveReportsAssembly.arptEstimating007
                        type = 7
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2 Then
                        rpt = New ActiveReportsAssembly.arptEstimatingTPN2
                        type = 6
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating313 Then
                        rpt = New ActiveReportsAssembly.arptEstimating313
                        type = 7
                    End If
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("EstimatingLogoLocation")
                    rpt.LogoID = Session("EstimatingLogoLocationID")
                    rpt.imgPath = imgPath
                    rpt.printedDate = Session("EstimatingPrintedDate")
                    rpt.defFooter = Session("EstimatingDefFooter")
                    rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                    rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                    rpt.addressOption = Request.QueryString("option")
                    rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Request.QueryString("option"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                    rpt.agencyname = cr.GetAgencyName()
                    If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                        rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating304 Then
                        rpt.rptFormat = "304"
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating305 Then
                        rpt.rptFormat = "305"
                    End If

                    Dim cEmp As New cEmployee(Session("ConnString"))

                    Try
                        Dim sig As String = Request.QueryString("UseEmpSig")
                        If sig = "0" Then
                            rpt.UseEmpSig = True
                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        Else
                            rpt.UseEmpSig = False
                        End If

                    Catch ex As Exception
                    End Try

                    If Session("EstimatingLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If Request.QueryString("combine") = "1" Then
                        rpt.combined = True
                        dtEst = est.getPrintDetails003Combined(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), type)
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2 Then
                            ds = est.getPrintDetails003DS(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), type)
                            If ds.Tables.Count > 1 Then
                                rpt.dtlabels = ds.Tables(1)
                            End If
                        End If
                        If dtEst.Rows.Count > 0 Then
                            For x As Integer = 0 To dtEst.Rows.Count - 1
                                'max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"))
                                dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                'dtEst.Rows(x)("MAX_REVISION") = max
                                If dtComments.Rows.Count > 0 Then
                                    Dim comments As String = ""
                                    Dim supcomments As String = ""
                                    Dim jq As Integer = 0
                                    For y As Integer = 0 To dtComments.Rows.Count - 1
                                        If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                            comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                        End If
                                        If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                            supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                        End If
                                        If IsNumeric(dtComments.Rows(y)("JOB_QTY")) = True Then
                                            jq += CInt(dtComments.Rows(y)("JOB_QTY"))
                                        End If
                                    Next
                                    dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                    dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                    If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                    Else
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                    End If
                                    dtEst.Rows(x)("JOB_QTY") = jq
                                    'dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                    'dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                    'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                End If
                            Next
                        End If
                        rpt.dt = dtEst
                    Else
                        dtPD = est.GetPrintDefDT(Session("UserCode"))
                        dtEst = est.getPrintDetails003(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), type)
                        If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTPN2 Then
                            ds = est.getPrintDetails003DS(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), type)
                            If ds.Tables.Count > 1 Then
                                rpt.dtlabels = ds.Tables(1)
                            End If
                        End If
                        If dtPD.Rows.Count > 0 Then
                            foption = dtPD.Rows(0)("FUNCTION_OPTION")
                        End If
                        If foption <> "N" Then
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"))
                                    dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), max, dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                    dtEst.Rows(x)("MAX_REVISION") = max
                                    If dtComments.Rows.Count > 0 Then
                                        Dim comments As String = ""
                                        Dim supcomments As String = ""
                                        For y As Integer = 0 To dtComments.Rows.Count - 1
                                            'If dtComments.Rows(y)("EST_FNC_COMMENT_HTML") <> "" Then
                                            '    comments = dtComments.Rows(y)("EST_FNC_COMMENT_HTML") & vbCrLf
                                            'ElseIf dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                            comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                            'End If
                                            'If dtComments.Rows(y)("EST_REV_SUP_BY_HTML") <> "" Then
                                            '    supcomments = dtComments.Rows(y)("EST_REV_SUP_BY_HTML") & vbCrLf
                                            'ElseIf dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                            supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                            'End If
                                        Next
                                        dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                        dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                        'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                        'Else
                                        '    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                        'End If
                                        'If dtComments.Rows(0)("EST_COMP_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                        'Else
                                        '    dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT_HTML")
                                        'End If
                                        'If dtComments.Rows(0)("EST_QTE_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                        'Else
                                        '    dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT_HTML")
                                        'End If
                                        'If dtComments.Rows(0)("EST_REV_COMMENT_HTML") = "" Then
                                        dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                        'Else
                                        '    dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT_HTML")
                                        'End If
                                        dtEst.Rows(x)("JOB_QTY") = dtComments.Rows(0)("JOB_QTY")
                                    End If
                                Next
                            End If
                        End If
                        rpt.dt = dtEst
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS1,
                AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingSS2,
                AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating008,
                AdvantageFramework.Reporting.ActiveReports.ReportName.Estimating009,
                AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingQUR,
                AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP,
                AdvantageFramework.Reporting.ActiveReports.ReportName.EstimatingTAP2

                    '48, 49, 54 '- Estimating Custom Saatchi and Quarry
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    Dim cc As New cCampaign(Session("ConnString"))
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim dtEst As DataTable
                    Dim dtComments As DataTable
                    Dim dsEst As DataSet
                    Dim dtCompComments As DataTable
                    Dim drCmp As SqlDataReader
                    Dim dtPD As DataTable
                    Dim foption As String
                    Dim goption As String
                    If TypeOfReport = 48 Then
                        rpt = New ActiveReportsAssembly.arptEstimatingSS1
                    End If
                    If TypeOfReport = 49 Then
                        rpt = New ActiveReportsAssembly.arptEstimatingSS2
                    End If
                    If TypeOfReport = 57 Then
                        rpt = New ActiveReportsAssembly.arptEstimatingQuarry
                    End If
                    If TypeOfReport = 54 Or TypeOfReport = 56 Or TypeOfReport = 72 Or TypeOfReport = 73 Then
                        If TypeOfReport = 72 Or TypeOfReport = 73 Then
                            rpt = New ActiveReportsAssembly.arptEstimatingTap
                            rpt.FunctionComment = Session("EstimatingFncComment")
                        Else
                            rpt = New ActiveReportsAssembly.arptEstimating008
                        End If
                        rpt.rpttype = Request.QueryString("Report")
                        rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Request.QueryString("option"), "", "", "")
                    Else
                        rpt.addressInfo = cr.GetCDPAddressInfoEstimate("Client", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    End If

                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("EstimatingLogoLocation")
                    rpt.LogoID = Session("EstimatingLogoLocationID")
                    rpt.imgPath = imgPath
                    rpt.printedDate = Session("EstimatingPrintedDate")
                    rpt.defFooter = Session("EstimatingDefFooter")
                    rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                    rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                    rpt.addressOption = Request.QueryString("option")
                    'rpt.addressInfo = cr.GetCDPAddressInfo("Client", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    rpt.addressInfoProd = cr.GetCDPAddressInfoEstimate("Product", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                    rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                    rpt.signature = Session("EstimatingSignature")
                    rpt.connstring = Session("ConnString")
                    rpt.dtJobVersion = est.getPrintDetailsJVS(Session("EstimatingJobPrint"), Session("EstimatingCompPrint"))
                    'rpt.dtTotals = est.getPrintDetailsTotals(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"))
                    rpt.agencyname = cr.GetAgencyName()
                    Dim cEmp As New cEmployee(Session("ConnString"))

                    Try
                        Dim sig As String = Request.QueryString("UseEmpSig")
                        If sig = "0" Then
                            rpt.UseEmpSig = True
                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        Else
                            rpt.UseEmpSig = False
                        End If

                    Catch ex As Exception
                    End Try

                    If Session("EstimatingLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If Request.QueryString("combine") = "1" Then

                    Else
                        dtPD = est.GetPrintDefDT(Session("UserCode"))
                        If dtPD.Rows.Count > 0 Then
                            goption = dtPD.Rows(0)("GROUP_OPTION")
                        End If
                        If TypeOfReport = 48 Then
                            dtEst = est.getPrintDetailsSS1(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"))
                            rpt.dtTotals = est.getPrintDetailsTotals(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"))
                        End If
                        If TypeOfReport = 49 Then
                            dtEst = est.getPrintDetailsSS2(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"))
                        End If
                        If TypeOfReport = 54 Or TypeOfReport = 56 Or TypeOfReport = 57 Or TypeOfReport = 72 Or TypeOfReport = 73 Then
                            If TypeOfReport = 72 Or TypeOfReport = 73 Then
                                dsEst = est.getPrintDetailsTap(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), Request.QueryString("Report"))
                                dtEst = dsEst.Tables(0)
                            Else
                                dtEst = est.getPrintDetailsQuarry(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"))
                            End If
                            rpt.dtTotals = est.getPrintDetailsTotalsQuarry(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Session("UserCode"), Request.QueryString("quotes"), Request.QueryString("comps"), Request.QueryString("Report"))
                        End If
                        If dtPD.Rows.Count > 0 Then
                            foption = dtPD.Rows(0)("FUNCTION_OPTION")
                        End If
                        If foption <> "N" Then
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    If TypeOfReport = 54 Or TypeOfReport = 56 Or TypeOfReport = 57 Then
                                        dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                        If dtComments.Rows.Count > 0 Then
                                            'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                            dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                            'Else
                                            'dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                            'End If
                                            'If dtComments.Rows(0)("EST_COMP_COMMENT_HTML") = "" Then
                                            dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                            'Else
                                            'dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT_HTML")
                                            'End If
                                            'If dtComments.Rows(0)("EST_QTE_COMMENT_HTML") = "" Then
                                            dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                            'Else
                                            'dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT_HTML")
                                            'End If
                                            'If dtComments.Rows(0)("EST_REV_COMMENT_HTML") = "" Then
                                            dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                            'Else
                                            'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT_HTML")
                                            'End If
                                        End If
                                        If TypeOfReport = 54 Or TypeOfReport = 56 Then
                                            drCmp = cc.GetCampaignByCmpIdentifier(dtEst.Rows(x)("CMP_ID"))
                                            If drCmp.HasRows = True Then
                                                drCmp.Read()
                                                dtEst.Rows(x)("CMP_COMMENTS") = drCmp("CMP_COMMENTS")
                                                drCmp.Close()
                                            End If
                                        End If
                                    ElseIf TypeOfReport = 72 Or TypeOfReport = 73 Then
                                        drCmp = cc.GetCampaignByCmpIdentifier(dtEst.Rows(x)("CMP_ID"))
                                        If drCmp.HasRows = True Then
                                            drCmp.Read()
                                            dtEst.Rows(x)("CMP_COMMENTS") = drCmp("CMP_COMMENTS")
                                            drCmp.Close()
                                        End If
                                        If dtEst.Rows(x)("ESTIMATE_NUMBER") <> 0 Then
                                            dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                            If dtComments.Rows.Count > 0 Then
                                                Dim comments As String = ""
                                                Dim supcomments As String = ""
                                                For y As Integer = 0 To dtComments.Rows.Count - 1
                                                    If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                        comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                    End If
                                                Next
                                                dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                            End If
                                        End If
                                    Else
                                        If goption = "HT" Then
                                            dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                            If dtComments.Rows.Count > 0 Then
                                                'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                'Else
                                                '    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_COMP_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                'Else
                                                '    dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_QTE_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                'Else
                                                '    dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_REV_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                                'Else
                                                '    dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT_HTML")
                                                'End If
                                            End If
                                        Else
                                            dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), dtEst.Rows(x)("EST_REV_RATE"), Session("UserCode"))
                                            If dtComments.Rows.Count > 0 Then

                                                Dim comments As String = ""
                                                Dim supcomments As String = ""

                                                For y As Integer = 0 To dtComments.Rows.Count - 1
                                                    'If dtComments.Rows(y)("EST_FNC_COMMENT_HTML") <> "" Then
                                                    '    comments = dtComments.Rows(y)("EST_FNC_COMMENT_HTML") & vbCrLf
                                                    If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                        comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                    End If
                                                    'If dtComments.Rows(y)("EST_REV_SUP_BY_HTML") <> "" Then
                                                    '    supcomments = dtComments.Rows(y)("EST_REV_SUP_BY_HTML") & vbCrLf
                                                    If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                        supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                                    End If
                                                Next

                                                dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                                dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                                'If dtComments.Rows(0)("EST_LOG_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                'Else
                                                'dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_COMP_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                'Else
                                                'dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_QTE_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                'Else
                                                'dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT_HTML")
                                                'End If
                                                'If dtComments.Rows(0)("EST_REV_COMMENT_HTML") = "" Then
                                                dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                                'Else
                                                'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT_HTML")
                                                'End If

                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        rpt.dt = dtEst
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecs

                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                    Dim ds As DataSet
                    Dim dr As SqlClient.SqlDataReader
                    Dim jl As New JOB_LOG(Session("ConnString"))
                    Dim jc As New JOB_COMPONENT(Session("ConnString"))

                    jl.LoadByPrimaryKey(CInt(Me._JobNumber))
                    jc.LoadByPrimaryKey(CInt(Me._JobComponentNbr), CInt(Me._JobNumber))
                    rpt = New ActiveReportsAssembly.arptJobSpecs
                    rpt.CultureCode = CurrentCultureCode
                    ds = js.GetJobSpecsDataSet(Me._JobNumber, Me._JobComponentNbr, Request.QueryString("version"), Request.QueryString("revision"))
                    rpt.dtData = ds.Tables(0)
                    ds = js.GetJobSpecCategories(Session("JSType"))
                    rpt.dtCategory = ds.Tables(0)
                    rpt.dtQuantity = js.GetJobSpecsQtyData(Me._JobNumber, Me._JobComponentNbr, Request.QueryString("version"), Request.QueryString("revision"))
                    ds = js.GetJobSpecsDataSetTextFields(Me._JobNumber, Me._JobComponentNbr, Request.QueryString("version"), Request.QueryString("revision"))
                    rpt.dtText = ds.Tables(0)
                    rpt.Description = Session("JSDescription")
                    rpt.reason = Session("JSReason")
                    rpt.version = Request.QueryString("version")
                    rpt.revision = Request.QueryString("revision")
                    rpt.job = Me._JobNumber & " - " & jl.JOB_DESC
                    rpt.jobcomp = Me._JobComponentNbr & " - " & jc.JOB_COMP_DESC
                    dr = js.GetJobSpecCDP(CInt(Me._JobNumber))

                    Do While dr.Read

                        If IsDBNull(dr("CL_CODE")) = False Then
                            rpt.client = dr("CL_CODE")
                        End If
                        If IsDBNull(dr("CL_NAME")) = False Then
                            rpt.client &= " - " & dr("CL_NAME")
                        End If
                        If IsDBNull(dr("DIV_CODE")) = False Then
                            rpt.division = dr("DIV_CODE")
                        End If
                        If IsDBNull(dr("DIV_NAME")) = False Then
                            rpt.division &= " - " & dr("DIV_NAME")
                        End If
                        If IsDBNull(dr("PRD_CODE")) = False Then
                            rpt.product = dr("PRD_CODE")
                        End If
                        If IsDBNull(dr("PRD_DESCRIPTION")) = False Then
                            rpt.product &= " - " & dr("PRD_DESCRIPTION")
                        End If

                    Loop

                    dr.Close()

                    rpt.Reporter = Session("UserCode")
                    rpt.title = Session("JSReportTitle")
                    dr = js.GetJobSpecApprovalData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr))

                    Do While dr.Read

                        If dr.GetInt32(0) = CInt(Request.QueryString("version")) Then

                            rpt.Approved = True

                        Else

                            rpt.Approved = False

                        End If

                    Loop
                    dr.Close()
                    dr = js.GetJobSpecQtyVendorTabs(Session("JSType"))
                    If dr.HasRows = True Then

                        Do While dr.Read

                            If dr.GetInt16(2) = 1 Then

                                rpt.vendortab = 1
                                rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr), 1)

                            End If
                            If dr.GetInt16(2) = 2 Then

                                rpt.vendortab = 2
                                rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr), 2)

                            End If
                        Loop

                    End If
                    dr.Close()
                    If Request.QueryString("page") = "jobjacket" Then

                        rpt.includeVS = Session("JSIncludeVS")
                        rpt.includeMS = Session("JSIncludeMS")
                        rpt.page = "jobjacket"

                    Else

                        rpt.includeVS = False
                        rpt.includeMS = False
                        rpt.page = "jobspecs"

                    End If
                    strReportName = "Specification"
                    rpt.dtMediaSpecs = js.GetJobSpecsMediaSpecsData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr))

                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JSLogoLocation")
                    rpt.LogoPlacement = Session("JSLogoPlacement")
                    rpt.LogoID = Session("JSLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JSLogoLocationID"))
                    rpt.omitEmptyFields = Session("JSOmitEmptyFields")

                    If Session("JSLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecsAllVersions

                    'Job Specs All Versions
                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                    Dim ds As DataSet
                    Dim dr As SqlClient.SqlDataReader
                    Dim jl As New JOB_LOG(Session("ConnString"))
                    Dim jc As New JOB_COMPONENT(Session("ConnString"))

                    jl.LoadByPrimaryKey(CInt(Me._JobNumber))
                    jc.LoadByPrimaryKey(CInt(Me._JobComponentNbr), CInt(Me._JobNumber))

                    rpt = New ActiveReportsAssembly.arptJobSpecAllVersions
                    rpt.CultureCode = CurrentCultureCode

                    ds = js.GetJobSpecsDSbyJobComp(Me._JobNumber, Me._JobComponentNbr)
                    rpt.dtData = ds.Tables(0)

                    rpt.job = Me._JobNumber & " - " & jl.JOB_DESC
                    rpt.jobcomp = Me._JobComponentNbr & " - " & jc.JOB_COMP_DESC

                    dr = js.GetJobSpecCDP(CInt(Me._JobNumber))

                    Do While dr.Read

                        rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                        rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                        rpt.product = dr.GetString(5) & " - " & dr.GetString(6)

                    Loop

                    dr.Close()

                    rpt.Reporter = Session("UserCode")
                    rpt.title = Session("JSReportTitle")
                    rpt.Approved = Session("JSApproveOnly")
                    rpt.omitEmptyFields = Session("OmitEmptyFieldsJS")

                    dr = js.GetJobSpecQtyVendorTabs(Session("JSType"))

                    If dr.HasRows = True Then

                        Do While dr.Read

                            If dr.GetInt16(2) = 1 Then
                                rpt.vendortab = 1
                                rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr), 1)
                            End If
                            If dr.GetInt16(2) = 2 Then

                                rpt.vendortab = 2
                                rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr), 2)

                            End If

                        Loop

                    End If
                    dr.Close()

                    If Request.QueryString("page") = "jobjacket" Then

                        rpt.includeVS = Session("JSIncludeVS")
                        rpt.includeMS = Session("JSIncludeMS")
                        rpt.page = "jobjacket"

                    Else

                        rpt.includeVS = False
                        rpt.includeMS = False
                        rpt.page = "jobspecs"

                    End If

                    strReportName = "Specification"

                    rpt.dtMediaSpecs = js.GetJobSpecsMediaSpecsData(CInt(Me._JobNumber), CInt(Me._JobComponentNbr))

                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JobOrderFormLogoLocation")
                    rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                    rpt.LogoID = Session("JobOrderFormLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))

                    If Session("JobOrderFormLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate

                    Dim ds As DataSet
                    Dim ds2 As DataSet
                    Dim ds3 As DataSet
                    Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim rush As Short
                    Dim oJob As Job = New Job(Session("ConnString"))

                    oJob.GetJob(Me._JobNumber, Me._JobComponentNbr)
                    rush = oJob.JOB_RUSH_CHARGES
                    If rush <> 1 Then rush = 0

                    strReportName = MyJobTemplate.GetTemplateDesc(MyJobTemplate.GetTemplateCode(Me._JobNumber, Me._JobComponentNbr))

                    rpt = New ActiveReportsAssembly.arptJobTemplate
                    rpt.CultureCode = CurrentCultureCode
                    rpt.JobNum = Me._JobNumber
                    rpt.JobCompNum = Me._JobComponentNbr
                    rpt.printJobOrderForm = Session("IncludeJOFReport")
                    rpt.omitEmptyFields = Session("OmitEFReport")
                    rpt.includeTA = Session("IncludeTAReport")
                    rpt.sectionTitleTA = Session("TASectionTitle")
                    rpt.includeTS = Session("IncludeTSReport")
                    rpt.scheduleCommentTS = Session("TSScheduleComments")
                    rpt.sectionTitleTS = Session("TSSectionTitle")
                    rpt.dueDatesOnlyTS = Session("TSDueDatesOnly")
                    rpt.milestonesOnlyTS = Session("TSMilestonesOnly")
                    rpt.milestoneTitle = Session("TSMilestoneTitle")
                    rpt.employeeAssignmentsTS = Session("TSEmpAssignments")
                    rpt.ReportTitle = strReportName
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JobOrderFormLogoLocation")
                    rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                    rpt.LogoID = Session("JobOrderFormLogoLocationID")
                    rpt.Reporter = Session("UserCode")
                    rpt.dtTraffic = oReports.GetJobTrafficAssignments(Me._JobNumber, Me._JobComponentNbr)
                    ds3 = oTrafficSchedule.GetScheduleAssignmentLabels
                    rpt.dtTrafficLabels = ds3.Tables(0)
                    rpt.dtSchedule = oReports.GetJobTrafficSchedule(Me._JobNumber, Me._JobComponentNbr, "ama")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                    ds2 = MyJobTemplate.GetJobTemplateComments(Me._JobNumber, Me._JobComponentNbr)
                    rpt.dtComments = ds2.Tables(0)
                    ds = MyJobTemplate.GetJobTemplateDetails(Me._JobNumber, Me._JobComponentNbr)
                    rpt.MyDT = ds.Tables(0)
                    rpt.dtData = ds.Tables(2)
                    rpt.rushJob = rush

                    If Session("JobOrderFormLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If


                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate002,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate003

                    Dim ds As DataSet
                    Dim ds2 As DataSet
                    Dim ds3 As DataSet
                    Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim rush As Short
                    Dim oJob As Job = New Job(Session("ConnString"))

                    oJob.GetJob(Me._JobNumber, Me._JobComponentNbr)
                    rush = oJob.JOB_RUSH_CHARGES
                    If rush <> 1 Then rush = 0

                    rpt = New ActiveReportsAssembly.arptJobTemplate002
                    rpt.CultureCode = CurrentCultureCode
                    If TypeOfReport = 58 Then
                        rpt.rptType = "002"
                    End If
                    If TypeOfReport = 59 Then
                        rpt.rptType = "003"
                    End If

                    strReportName = MyJobTemplate.GetTemplateDesc(MyJobTemplate.GetTemplateCode(Me._JobNumber, Me._JobComponentNbr))
                    rpt.mConnectionString = Session("ConnString")

                    rpt.UserCode = Session("UserCode")
                    rpt.JobNum = Me._JobNumber
                    rpt.JobCompNum = Me._JobComponentNbr
                    rpt.printJobOrderForm = Session("IncludeJOFReport")
                    rpt.omitEmptyFields = Session("OmitEFReport")
                    rpt.includeTA = Session("IncludeTAReport")
                    rpt.sectionTitleTA = Session("TASectionTitle")
                    rpt.includeTS = Session("IncludeTSReport")
                    rpt.scheduleCommentTS = Session("TSScheduleComments")
                    rpt.sectionTitleTS = Session("TSSectionTitle")
                    rpt.dueDatesOnlyTS = Session("TSDueDatesOnly")
                    rpt.milestonesOnlyTS = Session("TSMilestonesOnly")
                    rpt.milestoneTitle = Session("TSMilestoneTitle")
                    rpt.employeeAssignmentsTS = Session("TSEmpAssignments")
                    rpt.ReportTitle = Session("JobOrderFormReportTitle")
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JobOrderFormLogoLocation")
                    rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                    rpt.LogoID = Session("JobOrderFormLogoLocationID")
                    rpt.Reporter = Session("UserCode")
                    rpt.dtSchedule = oReports.GetJobTrafficSchedule(Me._JobNumber, Me._JobComponentNbr, "ama")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                    ds2 = MyJobTemplate.GetJobTemplateComments(Me._JobNumber, Me._JobComponentNbr)
                    rpt.dtComments = ds2.Tables(0)
                    ds = MyJobTemplate.GetJobTemplateDetails(Me._JobNumber, Me._JobComponentNbr)
                    rpt.MyDT = ds.Tables(0)
                    rpt.rushJob = rush
                    If Session("JobOrderPrintDate") <> "" Then
                        rpt.JobDate = Session("JobOrderPrintDate")
                    Else
                        rpt.JobDate = oJob.JOB_DATE_OPENED.ToShortDateString
                    End If
                    rpt.Client = oJob.ClientDesc
                    rpt.AE = oJob.JobComponent.AccountExecutiveDesc
                    rpt.desc = oJob.JobComponent.JOB_COMP_DESC
                    rpt.dsBudget = MyJobTemplate.GetBudget(Me._JobNumber, Me._JobComponentNbr)
                    rpt.signature = Session("JobOrderFormSignatureFormat")

                    If Session("JobOrderFormLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersion

                    Dim jv As New JobVersion(Session("ConnString"))
                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim ds As DataSet
                    Dim dr As SqlClient.SqlDataReader
                    Dim jl As New JOB_LOG(Session("ConnString"))
                    Dim jc As New JOB_COMPONENT(Session("ConnString"))
                    Dim job_nbr As Integer
                    Dim version_nbr, job_comp As Int16
                    Dim version_str, job_str As String
                    Dim job_version_desc As String
                    If Me._JobNumber = 0 Then

                    Else
                        jl.LoadByPrimaryKey(CInt(Me._JobNumber))
                        jc.LoadByPrimaryKey(CInt(Me._JobComponentNbr), CInt(Me._JobNumber))
                    End If

                    rpt = New ActiveReportsAssembly.arptJobVersion
                    rpt.CultureCode = CurrentCultureCode
                    ds = jv.getArptJobVersion(Request.QueryString("JobVerHdrID"))
                    rpt.dtData = ds.Tables(0)

                    version_nbr = Session("versionNbr")
                    version_str = version_nbr.ToString.PadLeft(3, "0")

                    job_version_desc = jv.GetAgencyDesc()
                    rpt.Description = version_str & " - " & Session("JVDescription")

                    If Me._JobNumber <> 0 Then
                        job_nbr = Me._JobNumber
                        job_str = job_nbr.ToString.PadLeft(6, "0")
                        rpt.job = job_str & " - " & jl.JOB_DESC

                        job_comp = Me._JobComponentNbr
                        job_str = job_comp.ToString.PadLeft(3, "0")
                        rpt.jobcomp = job_str & " - " & jc.JOB_COMP_DESC

                        dr = js.GetJobSpecCDP(CInt(Me._JobNumber))
                        dr.Read()
                        rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                        rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                        rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                        dr.Close()
                    Else
                        dr = jv.GetJVRequestDescriptions(Request.QueryString("JobVerHdrID"))
                        dr.Read()
                        rpt.client = dr.GetString(0) & " - " & dr.GetString(1)
                        rpt.division = dr.GetString(2) & " - " & dr.GetString(3)
                        rpt.product = dr.GetString(4) & " - " & dr.GetString(5)
                        dr.Close()
                    End If

                    rpt.Reporter = Session("UserCode")
                    rpt.ReportTitle = Session("JVReportTitle")

                    strReportName = "JobVersion"
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JVLogoLocation")
                    rpt.LogoPlacement = Session("JVLogoPlacement")
                    rpt.LogoID = Session("JVLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JVLogoLocationID"))
                    rpt.omitEmptyFields = (Session("JVOmitEmptyFields"))

                    If Session("JVLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JVLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersions 'Job Versions

                    Dim jv As New JobVersion(Session("ConnString"))
                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim ds As DataSet
                    Dim dr As SqlClient.SqlDataReader
                    Dim jl As New JOB_LOG(Session("ConnString"))
                    Dim jc As New JOB_COMPONENT(Session("ConnString"))
                    Dim job_nbr As Integer
                    Dim version_nbr, job_comp As Int16
                    Dim version_str, job_str As String
                    Dim job_version_desc As String
                    jl.LoadByPrimaryKey(CInt(Me._JobNumber))
                    jc.LoadByPrimaryKey(CInt(Me._JobComponentNbr), CInt(Me._JobNumber))

                    rpt = New ActiveReportsAssembly.arptJobVersions
                    rpt.CultureCode = CurrentCultureCode
                    ds = jv.getArptJobVersions(CInt(Me._JobNumber), CInt(Me._JobComponentNbr))
                    rpt.dtData = ds.Tables(0)

                    rpt.AgencyDesc = jv.GetAgencyDesc()

                    job_nbr = Me._JobNumber
                    job_str = job_nbr.ToString.PadLeft(6, "0")
                    rpt.job = job_str & " - " & jl.JOB_DESC

                    job_comp = Me._JobComponentNbr
                    job_str = job_comp.ToString.PadLeft(3, "0")
                    rpt.jobcomp = job_str & " - " & jc.JOB_COMP_DESC

                    dr = js.GetJobSpecCDP(CInt(Me._JobNumber))
                    dr.Read()
                    rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                    rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                    rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                    dr.Close()

                    rpt.Reporter = Session("UserCode")
                    rpt.ReportTitle = Session("JVReportTitle")

                    strReportName = "JobVersions"
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("JobOrderFormLogoLocation")
                    rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                    rpt.LogoID = Session("JobOrderFormLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                    rpt.omitEmptyFields = Session("OmitEmptyFieldsJV")

                    If Session("JobOrderFormLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MediaReport

                    rpt = New ActiveReportsAssembly.mediaCalReport
                    rpt.CultureCode = CurrentCultureCode
                    If Not Session("MediaCalType") Is Nothing Then
                        If Session("MediaCalType") = "Schedule" Then
                            If Not Session("msfSClientText") Is Nothing Then
                                rpt.client = Session("msfSClientText")
                                rpt.division = Session("msfSDivisionText")
                                rpt.product = Session("msfSProductText")
                            Else
                                rpt.client = "All Clients"
                                rpt.division = "All Divisions"
                                rpt.product = "All Products"
                            End If
                        ElseIf Session("MediaCalType") = "Traffic" Then
                            If Not Session("mtfSClientText") Is Nothing Then
                                rpt.client = Session("mtfSClientText")
                                rpt.division = Session("mtfSDivisionText")
                                rpt.product = Session("mtfSProductText")
                            Else
                                rpt.client = "All Clients"
                                rpt.division = "All Divisions"
                                rpt.product = "All Products"
                            End If
                        End If
                        rpt.type = Session("MediaCalType")
                    Else
                        rpt.client = "All Clients"
                        rpt.division = "All Divisions"
                        rpt.product = "All Products"
                        rpt.type = "Traffic"
                    End If
                    rpt.year = Convert.ToDateTime(Request.QueryString("thisdate")).Year
                    rpt.month = getMonthName()
                    rpt.logopath = Session("LogoPath")
                    rpt.printtext = Session("MediaSchPrintText")
                    rpt.imgPath = imgPath
                    rpt.dt = getMonthData(Request.QueryString("thisdate"))


                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskList

                    rpt = New ActiveReportsAssembly.arptMyTaskList
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    If Not Request.QueryString("EmpCodes") Is Nothing Then
                        rpt.strEmpCodes = Request.QueryString("EmpCodes")
                        EmpRole = 1
                    Else
                        rpt.strEmpCodes = Request.QueryString("RoleCodes")
                        EmpRole = 0
                    End If

                    rpt.strClientCodes = Request.QueryString("ClientCodes")
                    rpt.strOfficeCodes = Request.QueryString("OfficeCodes")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkRevDueDate = Request.QueryString("chkRevDueDate")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkEmp = Request.QueryString("chkEmp")
                    rpt.chkJTComments = Request.QueryString("chkJobTrafficComments")
                    rpt.strAECodes = Request.QueryString("AECodes")

                    dt = oReports.GetMyTaskData(rpt.strUserID, rpt.strEmpCodes, rpt.strClientCodes, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strOfficeCodes, rpt.strCompleted, EmpRole, Request.QueryString("ddManager"), rpt.strAECodes)
                    'If dt.Rows.Count > 0 Then
                    '    For i As Integer = 0 To dt.Rows.Count - 1
                    '        If dt.Rows(i)("Emp").ToString() = "" Then
                    '            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    '            Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(CInt(dt.Rows(i)("JobNum")), CInt(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("SEQ_NBR")))
                    '            If strEmps <> "" Then
                    '                dt.Rows(i)("Emp") = strEmps
                    '            End If
                    '        End If
                    '        'If dt.Rows(i)("Comments").ToString() = "" Then
                    '        '    Dim jtd As New JOB_TRAFFIC_DET(Session("ConnString"))
                    '        '    Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '        '    If jtd.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum")), CShort(dt.Rows(i)("SEQ_NBR"))) = True Then
                    '        '        dt.Rows(i)("Comments") = jtd.FNC_COMMENTS
                    '        '    End If
                    '        'End If
                    '        'If dt.Rows(i)("JTComments").ToString() = "" Then
                    '        '    Dim jt As New JOB_TRAFFIC(Session("ConnString"))
                    '        '    Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '        '    If jt.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum"))) = True Then
                    '        '        dt.Rows(i)("JTComments") = jt.TRF_COMMENTS
                    '        '    End If
                    '        'End If
                    '    Next
                    'End If
                    Dim filter As String
                    Dim dv As New DataView(dt)
                    If Request.QueryString("Only") = "True" Then
                        If filter = "" Then
                            filter = "(Emp = '')"
                        End If
                    End If
                    If Request.QueryString("Exclude") = "True" Then
                        If filter = "" Then
                            filter = "(Emp <> '')"
                        Else
                            filter &= " AND (Emp <> '')"
                        End If
                    End If
                    dv.RowFilter = filter
                    rpt.dt = dv.ToTable
                    dt = rpt.dt
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    strURL = "TaskList_Settings.aspx?nodata=1"
                    strReportName = "Task_List"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListSummary

                    rpt = New ActiveReportsAssembly.arptMyTaskListSummary
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    If Not Request.QueryString("EmpCodes") Is Nothing Then
                        rpt.strEmpCodes = Request.QueryString("EmpCodes")
                        EmpRole = 1
                    Else
                        rpt.strEmpCodes = Request.QueryString("RoleCodes")
                        EmpRole = 0
                    End If

                    rpt.strClientCodes = Request.QueryString("ClientCodes")
                    rpt.strOfficeCodes = Request.QueryString("OfficeCodes")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkRevDueDate = Request.QueryString("chkRevDueDate")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkEmp = Request.QueryString("chkEmp")
                    rpt.chkJTComments = Request.QueryString("chkJobTrafficComments")
                    rpt.strAECodes = Request.QueryString("AECodes")

                    dt = oReports.GetMyTaskData(rpt.strUserID, rpt.strEmpCodes, rpt.strClientCodes, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strOfficeCodes, rpt.strCompleted, EmpRole, Request.QueryString("ddManager"), rpt.strAECodes)
                    'If dt.Rows.Count > 0 Then
                    '    For i As Integer = 0 To dt.Rows.Count - 1
                    '        If dt.Rows(i)("Emp").ToString() = "" Then
                    '            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    '            Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(CInt(dt.Rows(i)("JobNum")), CInt(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("SEQ_NBR")))
                    '            If strEmps <> "" Then
                    '                dt.Rows(i)("Emp") = strEmps
                    '            End If
                    '        End If
                    '        If dt.Rows(i)("Comments").ToString() = "" Then
                    '            Dim jtd As New JOB_TRAFFIC_DET(Session("ConnString"))
                    '            Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '            If jtd.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum")), CShort(dt.Rows(i)("SEQ_NBR"))) = True Then
                    '                dt.Rows(i)("Comments") = jtd.FNC_COMMENTS
                    '            End If
                    '        End If
                    '        If dt.Rows(i)("JTComments").ToString() = "" Then
                    '            Dim jt As New JOB_TRAFFIC(Session("ConnString"))
                    '            Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '            If jt.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum"))) = True Then
                    '                dt.Rows(i)("JTComments") = jt.TRF_COMMENTS
                    '            End If
                    '        End If
                    '    Next
                    'End If
                    Dim filter As String
                    Dim dv As New DataView(dt)
                    If Request.QueryString("Only") = "True" Then
                        If filter = "" Then
                            filter = "(Emp = '')"
                        End If
                    End If
                    If Request.QueryString("Exclude") = "True" Then
                        If filter = "" Then
                            filter = "(Emp <> '')"
                        Else
                            filter &= " AND (Emp <> '')"
                        End If
                    End If
                    dv.RowFilter = filter
                    rpt.dt = dv.ToTable
                    dt = rpt.dt
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    strURL = "TaskList_Settings.aspx?nodata=1"
                    strReportName = "Task_List"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListTask

                    rpt = New ActiveReportsAssembly.arptMyTaskListByTask
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    If Not Request.QueryString("EmpCodes") Is Nothing Then
                        rpt.strEmpCodes = Request.QueryString("EmpCodes")
                        EmpRole = 1
                    Else
                        rpt.strEmpCodes = Request.QueryString("RoleCodes")
                        EmpRole = 0
                    End If
                    rpt.strClientCodes = Request.QueryString("ClientCodes")
                    rpt.strOfficeCodes = Request.QueryString("OfficeCodes")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkClient = Request.QueryString("chkClient")
                    rpt.chkDivision = Request.QueryString("chkDivision")
                    rpt.chkProduct = Request.QueryString("chkProduct")
                    rpt.chkJob = Request.QueryString("chkJob")
                    rpt.chkRevDueDate = Request.QueryString("chkRevDueDate")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkEmp = Request.QueryString("chkEmp")
                    rpt.strAECodes = Request.QueryString("AECodes")

                    dt = oReports.GetMyTaskData(rpt.strUserID, rpt.strEmpCodes, rpt.strClientCodes, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strOfficeCodes, rpt.strCompleted, EmpRole, Request.QueryString("ddManager"), rpt.strAECodes)
                    'If dt.Rows.Count > 0 Then
                    '    For i As Integer = 0 To dt.Rows.Count - 1
                    '        If dt.Rows(i)("Emp").ToString() = "" Then
                    '            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    '            Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(CInt(dt.Rows(i)("JobNum")), CInt(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("SEQ_NBR")))
                    '            If strEmps <> "" Then
                    '                dt.Rows(i)("Emp") = strEmps
                    '            End If
                    '        End If
                    '        If dt.Rows(i)("Comments").ToString() = "" Then
                    '            Dim jtd As New JOB_TRAFFIC_DET(Session("ConnString"))
                    '            Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '            If jtd.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum")), CShort(dt.Rows(i)("SEQ_NBR"))) = True Then
                    '                dt.Rows(i)("Comments") = jtd.FNC_COMMENTS
                    '            End If
                    '        End If
                    '    Next
                    'End If
                    Dim filter As String
                    Dim dv As New DataView(dt)
                    If Request.QueryString("Only") = "True" Then
                        If filter = "" Then
                            filter = "(Emp = '')"
                        End If
                    End If
                    If Request.QueryString("Exclude") = "True" Then
                        If filter = "" Then
                            filter = "(Emp <> '')"
                        Else
                            filter &= " AND (Emp <> '')"
                        End If
                    End If
                    dv.RowFilter = filter
                    rpt.dt = dv.ToTable
                    dt = rpt.dt
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    strURL = "TaskList_Settings.aspx?nodata=1"
                    strReportName = "Task_List_By_Task"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListDueDate

                    rpt = New ActiveReportsAssembly.arptMyTaskListByDueDate
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    If Not Request.QueryString("EmpCodes") Is Nothing Then
                        rpt.strEmpCodes = Request.QueryString("EmpCodes")
                        EmpRole = 1
                    Else
                        rpt.strEmpCodes = Request.QueryString("RoleCodes")
                        EmpRole = 0
                    End If
                    rpt.strClientCodes = Request.QueryString("ClientCodes")
                    rpt.strOfficeCodes = Request.QueryString("OfficeCodes")

                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkClient = Request.QueryString("chkClient")
                    rpt.chkDivision = Request.QueryString("chkDivision")
                    rpt.chkProduct = Request.QueryString("chkProduct")
                    rpt.chkJob = Request.QueryString("chkJob")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkEmp = Request.QueryString("chkEmp")
                    rpt.strAECodes = Request.QueryString("AECodes")

                    dt = oReports.GetMyTaskData(rpt.strUserID, rpt.strEmpCodes, rpt.strClientCodes, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strOfficeCodes, rpt.strCompleted, EmpRole, Request.QueryString("ddManager"), rpt.strAECodes)
                    'If dt.Rows.Count > 0 Then
                    '    For i As Integer = 0 To dt.Rows.Count - 1
                    '        If dt.Rows(i)("Emp").ToString() = "" Then
                    '            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    '            Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(CInt(dt.Rows(i)("JobNum")), CInt(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("SEQ_NBR")))
                    '            If strEmps <> "" Then
                    '                dt.Rows(i)("Emp") = strEmps
                    '            End If
                    '        End If
                    '        If dt.Rows(i)("Comments").ToString() = "" Then
                    '            Dim jtd As New JOB_TRAFFIC_DET(Session("ConnString"))
                    '            Dim ij As Integer = CInt(dt.Rows(i)("JobNum"))
                    '            If jtd.LoadByPrimaryKey(CShort(dt.Rows(i)("CompNum")), CInt(dt.Rows(i)("JobNum")), CShort(dt.Rows(i)("SEQ_NBR"))) = True Then
                    '                dt.Rows(i)("Comments") = jtd.FNC_COMMENTS
                    '            End If
                    '        End If
                    '    Next
                    'End If
                    Dim filter As String
                    Dim dv As New DataView(dt)
                    If Request.QueryString("Only") = "True" Then
                        If filter = "" Then
                            filter = "(Emp = '')"
                        End If
                    End If
                    If Request.QueryString("Exclude") = "True" Then
                        If filter = "" Then
                            filter = "(Emp <> '')"
                        Else
                            filter &= " AND (Emp <> '')"
                        End If
                    End If
                    dv.RowFilter = filter
                    rpt.dt = dv.ToTable
                    dt = rpt.dt
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    strURL = "TaskList_Settings.aspx?nodata=1"
                    strReportName = "Task_List_By_Due_Date"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobs

                    rpt = New ActiveReportsAssembly.arptOpenJobs
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strClientID = Request.QueryString("ClientCode")
                    stdate = cGlobals.wvCDate(Request.QueryString("sdate"))
                    eddate = cGlobals.wvCDate(Request.QueryString("edate"))
                    rpt.dttest = oReports.GetOpenJobsDS(rpt.strUserID, rpt.strClientID, Request.QueryString("Office"), stdate, eddate, Request.QueryString("schedincld"), Request.QueryString("cp"), Session("UserID"))

                    dt = rpt.dttest
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    If TypeOfExport = 4 Then
                        rpt.TextDoc = True
                    End If
                    strURL = "OpenJobs_Settings.aspx?nodata=1"
                    strReportName = "Open_Jobs"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsFSN

                    rpt = New ActiveReportsAssembly.arptOpenJobsSch
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strClientID = Request.QueryString("ClientCode")
                    sdate = Request.QueryString("sdate")
                    edate = Request.QueryString("edate")
                    If sdate <> "01/01/1950" And edate <> "01/01/2050" Then
                        rpt.strDateRange = sdate & " - " & edate
                    End If
                    rpt.dttest = oReports.GetOpenJobsDS(rpt.strUserID, rpt.strClientID, Request.QueryString("Office"), Request.QueryString("sdate"), Request.QueryString("edate"), Request.QueryString("schedincld"), Request.QueryString("cp"), Session("UserID"))

                    dt = rpt.dttest
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                    End If
                    Dim tempDView As DataView = New DataView(dt)
                    tempDView.RowFilter = "TRF_SCHEDULE_REQ=1"
                    tempDView.Sort = "JOB_COMP_DATE"
                    If tempDView.Count <= 0 Then
                        flgNoData = True
                    End If
                    If TypeOfExport = 4 Then
                        rpt.TextDoc = True
                    End If
                    strURL = "OpenJobs_Settings.aspx?nodata=1"
                    strReportName = "Open_JobsFSN"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.OpenJobsSC

                    rpt = New ActiveReportsAssembly.arptOpenJobsSC
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strClientID = Request.QueryString("ClientCode")
                    rpt.dttest = oReports.GetOpenJobsDS(rpt.strUserID, rpt.strClientID, Request.QueryString("Office"), Request.QueryString("sdate"), Request.QueryString("edate"), Request.QueryString("schedincld"), Request.QueryString("cp"), Session("UserID"))
                    dt = rpt.dttest
                    If dt.Rows.Count <= 0 Then
                        flgNoData = True
                        'JSError = "<script language='javascript'>window.alert('Data Not Found');window.close();</script>"
                    End If
                    If TypeOfExport = 4 Then
                        rpt.TextDoc = True
                    End If
                    strURL = "OpenJobs_Settings.aspx?nodata=1"
                    strReportName = "Open_JobsSC"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement

                    rpt = New ActiveReportsAssembly.arptProductARStatement
                    strReportName = "Product_AR_Statement"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement001

                    rpt = New ActiveReportsAssembly.arptProductARStatement001
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    'rpt.strFooter = Request.QueryString("Footer")
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", StrOffices, Request.QueryString("aging"))
                    strReportName = "Product_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement002

                    rpt = New ActiveReportsAssembly.arptProductARStatement002
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "2", StrOffices, Request.QueryString("aging"))
                    strReportName = "Product_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement003
                    rpt = New ActiveReportsAssembly.arptProductARStatement003
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "3", StrOffices, Request.QueryString("aging"))
                    strReportName = "Product_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.ProductARStatement004
                    rpt = New ActiveReportsAssembly.arptProductARStatement004
                    rpt.CultureCode = CurrentCultureCode
                    If Request.QueryString("ID") = "ARPrint" Then
                        rpt.strID = Session("ARPrintIDs")
                    Else
                        rpt.strID = Request.QueryString("ID")
                    End If
                    Try
                        If Not Request.QueryString("c") Is Nothing Then
                            If Request.QueryString("c") = "f" Then 'comment in footer
                                rpt.PutCommentInFooter = True
                            Else
                                rpt.PutCommentInFooter = False
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Dim StrOffices As String = ""
                    Try
                        If Not Session("ARPrintOfficeCodes") Is Nothing Then
                            StrOffices = Session("ARPrintOfficeCodes").ToString()
                        End If
                    Catch ex As Exception
                        StrOffices = ""
                    End Try
                    rpt.strPostPeriod = Request.QueryString("PP")
                    rpt.strLocation = Request.QueryString("Loc")
                    rpt.strAgedDate = Request.QueryString("AD")
                    rpt.strFooter = oReports.GetAgencyFooter(Request.QueryString("Loc"))
                    rpt.imgPath = imgPath
                    rpt.strExclude = Request.QueryString("exclude")
                    rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "4", StrOffices, Request.QueryString("aging"))
                    strReportName = "Product_AR_Statement"
                    Session("ARPrintIDs") = ""

                    If Request.QueryString("Loc") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Me.NoData()
                        Exit Sub

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrderRR,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder3

                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder Then
                        rpt = New ActiveReportsAssembly.arptPurchaseOrder
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrderRR Then
                        rpt = New ActiveReportsAssembly.arptPurchaseOrderRR
                        rpt.LogoName = Session("POPrintLocationName")
                    End If
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder3 Then
                        rpt = New ActiveReportsAssembly.arptPurchaseOrder3
                        rpt.LogoName = Session("POPrintLocationName")
                    End If
                    rpt.CultureCode = CurrentCultureCode
                    Dim dsPO As New DataSet
                    Dim dtPrintDef As DataTable
                    Dim rep As New cReports(Session("ConnString"))
                    Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                    Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                    Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                    POHeader.Select_POHeader(Int32.Parse(Request.QueryString("ponumber").Trim), "")
                    POHeader.Select_PO_Memo("po_footer", Request.QueryString("ponumber").Trim)
                    POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)
                    Dim session_user As String = ""
                    Dim header As String
                    Dim cEmp As New cEmployee(Session("ConnString"))
                    Dim StandardComments As AdvantageFramework.Database.Entities.StandardComment = Nothing
                    Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

                    If Not String.IsNullOrEmpty(Session("UserCode")) Then

                        session_user = Session("UserCode")

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Dim POs As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing

                        POs = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, Int32.Parse(Request.QueryString("ponumber").Trim)).ToList

                        For Each p In POs
                            If p.Job IsNot Nothing Then
                                If p.Job.Client.Name <> "" Then
                                    rpt._ClientName = p.Job.Client.Name
                                    Exit For
                                End If
                            End If
                        Next


                    End Using

                    dtPrintDef = PO.GetPO_PrintDef_By_User_DTable(session_user) 'user print def.
                    rpt.logopath = Session("POPrintLocationPath")
                    rpt.LogoID = Session("POPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.PODate = Session("POPrintDate")
                    rpt.Void = POHeader.PO_Voided
                    rpt.Connstring = Session("ConnString")
                    rpt.UserCode = Session("UserCode")

                    If dtPrintDef.Rows.Count > 0 Then
                        If IsDBNull(dtPrintDef.Rows(0)(18)) = False Then
                            If dtPrintDef.Rows(0)(18).ToString() = "1" Then
                                rpt.UseLocationName = True
                            End If
                        End If
                        If IsDBNull(dtPrintDef.Rows(0)(19)) = False Then
                            If dtPrintDef.Rows(0)(19).ToString() = "1" Then
                                rpt.UseClientName = True
                            End If
                        End If
                    End If

                    If dtPrintDef.Rows.Count > 0 Then
                        If IsDBNull(dtPrintDef.Rows(0)(18)) = False Then
                            If dtPrintDef.Rows(0)(18).ToString() = "1" Then
                                rpt.UseLocationName = True
                            End If
                        End If
                        If IsDBNull(dtPrintDef.Rows(0)(19)) = False Then
                            If dtPrintDef.Rows(0)(19).ToString() = "1" Then
                                rpt.UseClientName = True
                            End If
                        End If
                    End If

                    Try
                        'State server fix
                        If Session("LocationOverride") IsNot Nothing Then

                            rpt.DefaultLocation = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Database.Entities.Location)(Session("LocationOverride"))

                        End If

                    Catch ex As Exception
                    End Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

                    End Using

                    Dim ClientCode As String = ""
                    Dim DivisionCode As String = ""
                    Dim ProductCode As String = ""
                    Dim StandComment As String = ""
                    Dim JobNumber As Integer = 0
                    Dim OfficeCode As String = ""
                    Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                    dsPO = PODtl.Select_PODetailsDS(Int32.Parse(Request.QueryString("ponumber").Trim), session_user.Trim, Request.QueryString("options").Trim, Session("POPrintLocationID"))

                    If POHeader.PO_Footer = Nothing Then
                        For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                            If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                JobNumber = dsPO.Tables(0).Rows(x)("JOB_NUMBER")
                            End If

                            If JobNumber > 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                                    If Job IsNot Nothing Then
                                        OfficeCode = Job.OfficeCode
                                    End If
                                End Using
                            End If

                            StandardComments = Nothing

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            'CDPV
                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                        Next

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments IsNot Nothing Then
                            rpt.FooterComment = StandComment 'StandardComments.Comment
                            rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                        Else
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        End If
                    ElseIf POHeader.PO_Footer = "Agency Defined" Then
                        rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                    ElseIf POHeader.PO_Footer = "Standard Comment" Then
                        For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                            If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                JobNumber = dsPO.Tables(0).Rows(x)("JOB_NUMBER")
                            End If

                            If JobNumber > 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                                    If Job IsNot Nothing Then
                                        OfficeCode = Job.OfficeCode
                                    End If
                                End Using
                            End If

                            StandardComments = Nothing

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            'CDPV
                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If
                        Next

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments IsNot Nothing Then
                            rpt.FooterComment = StandComment 'StandardComments.Comment
                            rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                        Else
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        End If

                    Else
                        rpt.FooterComment = POHeader.PO_Footer
                    End If
                    If dtPrintDef.Rows.Count > 0 Then
                        If IsDBNull(dtPrintDef.Rows(0)(3)) = False Then
                            If dtPrintDef.Rows(0)(3).ToString() = "0" Then
                                rpt.FooterComment = ""
                            End If
                        End If
                    End If

                    strFileName = "Purchase_Order_" + Request.QueryString("ponumber").ToString.PadLeft(8, "0") + "_" + Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")

                    Try
                        Dim sig, str, userSig, opts() As String
                        str = Request.QueryString("options").Trim
                        opts = str.Split(";")
                        sig = opts(11) 'Exclude Emp Sig (0 use, 1 exclude)

                        If sig = "0" Then
                            rpt.UseEmpSig = True

                            If opts.Length >= 14 Then

                                userSig = opts(13) 'use logged in employee 

                            End If

                        Else
                            rpt.UseEmpSig = False
                        End If

                        If userSig = "1" Then

                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))

                        Else

                            rpt.SigImage = cEmp.getEmpSignatureImage(POHeader.Issue_By_Emp_Code)

                        End If

                    Catch ex As Exception
                    End Try


                    If dsPO.Tables(0).Rows.Count > 0 Then
                        If dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "" Then
                            dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "-"
                        End If
                        If dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "" Then
                            dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "-"
                        End If
                        If IsDBNull(dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")) = True Then
                            rpt.header = ""
                        Else
                            If dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER") = "" Then
                                rpt.header = ""
                            Else
                                header = dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")
                                rpt.header = RTrim(LTrim(header.Replace("|", "•")))
                            End If
                        End If

                    End If
                    rpt.ds1 = dsPO

                    strReportName = "Purchase_Order"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.PurchaseOrder2

                    rpt = New ActiveReportsAssembly.arptPurchaseOrder2
                    rpt.CultureCode = CurrentCultureCode
                    Dim dsPO As New DataSet
                    Dim dtPrintDef As DataTable
                    Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                    Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                    Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                    POHeader.Select_POHeader(Int32.Parse(Request.QueryString("ponumber").Trim), "")
                    POHeader.Select_PO_Memo("po_footer", Request.QueryString("ponumber").Trim)
                    POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)
                    Dim session_user As String = ""
                    Dim header As String
                    Dim StandardComments As AdvantageFramework.Database.Entities.StandardComment = Nothing
                    Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

                    If Not String.IsNullOrEmpty(Session("UserCode")) Then
                        session_user = Session("UserCode")
                    End If

                    dtPrintDef = PO.GetPO_PrintDef_By_User_DTable(session_user) 'user print def.

                    rpt.logopath = Session("POPrintLocationPath")
                    rpt.LogoID = Session("POPrintLocationID")
                    rpt.imgPath = imgPath
                    rpt.PODate = Session("POPrintDate")
                    rpt.Void = POHeader.PO_Voided

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

                    End Using

                    Dim ClientCode As String = ""
                    Dim DivisionCode As String = ""
                    Dim ProductCode As String = ""
                    Dim StandComment As String = ""
                    Dim JobNumber As Integer = 0
                    Dim OfficeCode As String = ""
                    Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                    dsPO = PODtl.Select_PODetailsDS(Int32.Parse(Request.QueryString("ponumber").Trim), session_user.Trim, Request.QueryString("options").Trim, Session("POPrintLocationID"))

                    If POHeader.PO_Footer = Nothing Then
                        For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                            If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                JobNumber = dsPO.Tables(0).Rows(x)("JOB_NUMBER")
                            End If

                            If JobNumber > 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                                    If Job IsNot Nothing Then
                                        OfficeCode = Job.OfficeCode
                                    End If
                                End Using
                            End If

                            StandardComments = Nothing

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                        Next

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments IsNot Nothing Then
                            rpt.FooterComment = StandComment 'StandardComments.Comment
                            rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                        Else
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        End If
                    ElseIf POHeader.PO_Footer = "Agency Defined" Then
                        rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                    ElseIf POHeader.PO_Footer = "Standard Comment" Then
                        For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                            If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                JobNumber = dsPO.Tables(0).Rows(x)("JOB_NUMBER")
                            End If

                            If JobNumber > 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                                    If Job IsNot Nothing Then
                                        OfficeCode = Job.OfficeCode
                                    End If
                                End Using
                            End If

                            StandardComments = Nothing

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.OfficeCode Is Nothing And ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        If StandComment = "" Then
                                            StandComment &= ClientComment.Comment
                                        Else
                                            StandComment &= vbCrLf & ClientComment.Comment
                                        End If
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If
                        Next

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments Is Nothing Then
                            For Each ClientComment In StandardCommentsList
                                If ClientComment.OfficeCode Is Nothing And ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                    StandComment &= ClientComment.Comment
                                    StandardComments = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComments IsNot Nothing Then
                            rpt.FooterComment = StandComment 'StandardComments.Comment
                            rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                        Else
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        End If

                    Else
                        rpt.FooterComment = POHeader.PO_Footer
                    End If
                    If dtPrintDef.Rows.Count > 0 Then
                        If IsDBNull(dtPrintDef.Rows(0)(3)) = False Then
                            If dtPrintDef.Rows(0)(3).ToString() = "0" Then
                                rpt.FooterComment = ""
                            End If
                        End If
                    End If

                    Dim cEmp As New cEmployee(Session("ConnString"))
                    Try
                        Dim sig, str, opts() As String
                        str = Request.QueryString("options").Trim
                        opts = str.Split(";")
                        sig = opts(11) 'Exclude Emp Sig (0 use, 1 exclude)
                        If sig = "0" Then
                            rpt.UseEmpSig = True
                        Else
                            rpt.UseEmpSig = False
                        End If

                        rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                    Catch ex As Exception
                    End Try

                    If dsPO.Tables(0).Rows.Count > 0 Then
                        If dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "" Then
                            dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "-"
                        End If
                        If dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "" Then
                            dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "-"
                        End If
                        If IsDBNull(dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")) = True Then
                            rpt.header = ""
                        Else
                            If dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER") = "" Then
                                rpt.header = ""
                            Else
                                header = dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")
                                rpt.header = RTrim(LTrim(header.Replace("|", "•")))
                            End If
                        End If

                    End If
                    rpt.ds1 = dsPO

                    strReportName = "Purchase_Order"
                    strFileName = "Purchase_Order_" + Request.QueryString("ponumber").ToString.PadLeft(8, "0") + "_" + Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0")

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClient

                    rpt = New ActiveReportsAssembly.sum_rep_by_client
                    rpt.CultureCode = CurrentCultureCode
                    sdate = Request.QueryString("StartDate")
                    edate = Request.QueryString("EndDate")
                    rpt.Filter = Session("ProjectSummaryRPT")
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.division = Request.QueryString("division")
                    rpt.product = Request.QueryString("product")
                    rpt.AE = Request.QueryString("AE")
                    rpt.JobDesc = Request.QueryString("jobdesc")
                    rpt.Job = True
                    rpt.Component = Request.QueryString("component")
                    rpt.CompDesc = Request.QueryString("jobcompdesc")
                    rpt.type = Request.QueryString("jtype")
                    rpt.typeDesc = Request.QueryString("typedesc")
                    rpt.status = Request.QueryString("status")
                    rpt.ref = Request.QueryString("ref")
                    rpt.sdate = Request.QueryString("sdate")
                    rpt.duedate = Request.QueryString("duedate")
                    rpt.comm = Request.QueryString("comments")
                    rpt.ndue = Request.QueryString("ndue")
                    rpt.nduedate = Request.QueryString("nduedate")
                    rpt.nduecomm = Request.QueryString("nduecom")
                    rpt.estimate = Request.QueryString("estimate")
                    rpt.estaprv = Request.QueryString("estaprv")
                    rpt.title = Request.QueryString("title")
                    rpt.jobqty = Request.QueryString("jobqty")

                    Dim AEs As String
                    AEs = CStr(Request.QueryString("AECodes"))

                    If sdate <> "01/01/1950" And edate <> "01/01/2050" Then
                        rpt.strDateRange = sdate & " - " & edate
                    End If
                    rpt.dtMain = oReports.GetSumRepByClient(Request.QueryString("UserID").ToString(), sdate, edate, Request.QueryString("includeCS"), AEs, MiscFN.IsClientPortal, Session("UserID"))
                    rpt.dtNextDue = oReports.GetNextDue()
                    strReportName = "Summary_Rep_By_Clients"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.SumRepByClientSalesClass
                    rpt = New ActiveReportsAssembly.sum_rep_by_client_sc_jdd
                    rpt.CultureCode = CurrentCultureCode
                    sdate = Request.QueryString("StartDate")
                    edate = Request.QueryString("EndDate")
                    rpt.Filter = Session("ProjectSummaryRPT")
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.division = Request.QueryString("division")
                    rpt.product = Request.QueryString("product")
                    rpt.AE = Request.QueryString("AE")
                    rpt.JobDesc = Request.QueryString("jobdesc")
                    rpt.Job = True
                    rpt.Component = Request.QueryString("component")
                    rpt.CompDesc = Request.QueryString("jobcompdesc")
                    rpt.type = Request.QueryString("jtype")
                    rpt.typeDesc = Request.QueryString("typedesc")
                    rpt.status = Request.QueryString("status")
                    rpt.ref = Request.QueryString("ref")
                    rpt.sdate = Request.QueryString("sdate")
                    rpt.duedate = Request.QueryString("duedate")
                    rpt.comm = Request.QueryString("comments")
                    rpt.ndue = Request.QueryString("ndue")
                    rpt.nduedate = Request.QueryString("nduedate")
                    rpt.nduecomm = Request.QueryString("nduecom")
                    rpt.estimate = Request.QueryString("estimate")
                    rpt.estaprv = Request.QueryString("estaprv")
                    rpt.title = Request.QueryString("title")
                    rpt.jobqty = Request.QueryString("jobqty")

                    Dim AEs As String
                    AEs = CStr(Request.QueryString("AECodes"))

                    If sdate <> "01/01/1950" And edate <> "01/01/2050" Then
                        rpt.strDateRange = sdate & " - " & edate
                    End If
                    rpt.dtMain = oReports.GetSumRepByClientSalesClass(Request.QueryString("UserID").ToString(), sdate, edate, Request.QueryString("includeCS"), AEs, MiscFN.IsClientPortal, Session("UserID"))
                    rpt.dtNextDue = oReports.GetNextDue()
                    strReportName = "Summary_Rep_By_Clients_SalesClass"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskCalendar
                    Dim taskincl, holincl, apptincl As Boolean
                    Dim eventincl, eventTaskincl As Boolean
                    Dim staskincl, sholincl, sapptincl As String
                    Dim seventincl, seventTaskincl As String

                    rpt = New ActiveReportsAssembly.arptTaskCalendar
                    rpt.CultureCode = CurrentCultureCode
                    rpt.logopath = Session("LogoPath")
                    rpt.reportTitle = Session("TBTitle")
                    rpt.placement = Request.QueryString("placement")
                    rpt.groupLevel = Request.QueryString("groupLevel")
                    rpt.SchCommentIncl = Request.QueryString("SchCommentIncl")
                    rpt.StatusIncl = Request.QueryString("StatusIncl")
                    rpt.TaskIncl = Request.QueryString("incltask")
                    strReportName = "Task_Calendar"

                    staskincl = Request.QueryString("incltask")
                    sholincl = Request.QueryString("inclhol")
                    sapptincl = Request.QueryString("inclappt")
                    eventincl = Request.QueryString("inclEvent")
                    eventTaskincl = Request.QueryString("inclEventTask")

                    If staskincl = "0" Then
                        taskincl = False
                    Else
                        taskincl = True
                    End If
                    If sholincl = "0" Then
                        holincl = False
                    Else
                        holincl = True
                    End If
                    If sapptincl = "0" Then
                        apptincl = False
                    Else
                        apptincl = True
                    End If

                    If taskincl = False And holincl = False And apptincl = False And eventincl = False And eventTaskincl = False Then

                        Session("Calresponse") = True
                        Session("Calresponse_string") = "Please select to include at least one display item: tasks/holidays/appts/Events/EventTasks."
                        MiscFN.ResponseRedirect("Calendar_Report.aspx")

                    End If

                    rpt.imgPath = imgPath
                    rpt.mConnPath = Session("ConnString")
                    If Request.QueryString("FromApp") = "" Then
                        rpt.dt = getTaskReport(taskincl, holincl, apptincl, eventincl, eventTaskincl)
                    ElseIf Request.QueryString("FromApp") = "PSMV" Then
                        rpt.dt = getTaskReport(taskincl, holincl, apptincl, eventincl, eventTaskincl, Request.QueryString("FromApp"))
                    Else
                        rpt.dt = getTaskReport(taskincl, holincl, apptincl, eventincl, eventTaskincl, Request.QueryString("FromApp"), Me._JobNumber, Me._JobComponentNbr)
                    End If

                    If rpt.dt.rows.count = 0 Then

                        Session("Calresponse") = True
                        Session("Calresponse_string") = "No Data for Selected Inputs."

                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskList

                    rpt = New ActiveReportsAssembly.arptTaskList
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strEmpName = Request.QueryString("EmpName")
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strEmpCode = Request.QueryString("EmpCode")
                    rpt.strClientCode = Request.QueryString("ClientCode")
                    rpt.strDivCode = Request.QueryString("DivCode")
                    rpt.strProdCode = Request.QueryString("ProdCode")
                    rpt.strJobNumber = Request.QueryString("JobNumber")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkRevDueDate = Request.QueryString("chkRevDueDate")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkDueDate = Request.QueryString("chkDueDate")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.dt = oReports.GetTaskData(rpt.strUserID, rpt.strEmpCode, rpt.strClientCode, rpt.strDivCode, rpt.strProdCode, rpt.strJobNumber, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strCompleted, Request.QueryString("CP"), Request.QueryString("CPID"))

                    strReportName = "Task_List"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListDueDate

                    rpt = New ActiveReportsAssembly.arptTaskListByDueDate
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strEmpName = Request.QueryString("EmpName")
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strEmpCode = Request.QueryString("EmpCode")
                    rpt.strClientCode = Request.QueryString("ClientCode")
                    rpt.strDivCode = Request.QueryString("DivCode")
                    rpt.strProdCode = Request.QueryString("ProdCode")
                    rpt.strJobNumber = Request.QueryString("JobNumber")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkClient = Request.QueryString("chkClient")
                    rpt.chkDivision = Request.QueryString("chkDivision")
                    rpt.chkProduct = Request.QueryString("chkProduct")
                    rpt.chkJob = Request.QueryString("chkJob")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkDueDate = Request.QueryString("chkDueDate")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.dt = oReports.GetTaskData(rpt.strUserID, rpt.strEmpCode, rpt.strClientCode, rpt.strDivCode, rpt.strProdCode, rpt.strJobNumber, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strCompleted, Request.QueryString("CP"), Request.QueryString("CPID"))
                    strReportName = "Task_List_By_Due_Date"


                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListTask

                    rpt = New ActiveReportsAssembly.arptTaskListByTask
                    rpt.CultureCode = CurrentCultureCode
                    rpt.strEmpName = Request.QueryString("EmpName")
                    rpt.strUserID = Request.QueryString("UserID")
                    rpt.strEmpCode = Request.QueryString("EmpCode")
                    rpt.strClientCode = Request.QueryString("ClientCode")
                    rpt.strDivCode = Request.QueryString("DivCode")
                    rpt.strProdCode = Request.QueryString("ProdCode")
                    rpt.strJobNumber = Request.QueryString("JobNumber")
                    rpt.strSortOrder = Request.QueryString("SortOrder")
                    rpt.strStartDate = Request.QueryString("StartDate")
                    rpt.strEndDate = Request.QueryString("EndDate")
                    rpt.strCompleted = Request.QueryString("Completed")
                    rpt.chkClient = Request.QueryString("chkClient")
                    rpt.chkDivision = Request.QueryString("chkDivision")
                    rpt.chkProduct = Request.QueryString("chkProduct")
                    rpt.chkJob = Request.QueryString("chkJob")
                    rpt.chkRevDueDate = Request.QueryString("chkRevDueDate")
                    rpt.chkCompleted = Request.QueryString("chkCompleted")
                    rpt.chkComponent = Request.QueryString("chkComponent")
                    rpt.chkHrsAllowed = Request.QueryString("chkHrsAllowed")
                    rpt.chkDueDate = Request.QueryString("chkDueDate")
                    rpt.chkComments = Request.QueryString("chkComments")
                    rpt.chkTimeDue = Request.QueryString("chkTimeDue")
                    rpt.dt = oReports.GetTaskData(rpt.strUserID, rpt.strEmpCode, rpt.strClientCode, rpt.strDivCode, rpt.strProdCode, rpt.strJobNumber, rpt.strSortOrder, rpt.strStartDate, rpt.strEndDate, rpt.strCompleted, Request.QueryString("CP"), Request.QueryString("CPID"))
                    strReportName = "Task_List_By_Task"

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TimeSheetPrint

                    Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
                    If oSec.CheckEmployees(Session("UserCode"), Request.QueryString("empcode")) = False Then
                        Server.Transfer("NoAccess.aspx")
                    End If
                    Dim EmpName As String
                    Dim TotalHours As Double
                    rpt = New ActiveReportsAssembly.arptTimeSheetPrint
                    rpt.CultureCode = CurrentCultureCode
                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    Dim oEmp As cEmployee = New cEmployee(CStr(Session("ConnString")))
                    Dim ThisTimeSheet As DataTable
                    Dim SortBy As String = "EMP_DATE"

                    EmpName = oEmp.GetName(Request.QueryString("empcode"))


                    ThisTimeSheet = oTS.GetThisTimeSheetPrint(Request.QueryString("empcode"),
                                                              CDate(Request.QueryString("startdate")),
                                                              CDate(Request.QueryString("enddate")), SortBy)

                    Try

                        If ThisTimeSheet IsNot Nothing AndAlso ThisTimeSheet.Rows.Count > 0 AndAlso
                        Request.QueryString("sortkey") IsNot Nothing AndAlso IsNumeric(Request.QueryString("sortkey")) = True Then

                            Select Case CType(CType(Request.QueryString("sortkey"), Integer), AdvantageFramework.Timesheet.TimesheetSort)

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.NewestFirst

                                    'ThisTimeSheet.DefaultView.Sort = "EMP_DATE DESC"                                    
                                    ThisTimeSheet.DefaultView.Sort = "EMP_DATE ASC" '(NEWEST LAST AS REPORT DEFAULT)
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.JobComponent

                                    ThisTimeSheet.DefaultView.Sort = "JOB_NUMBER ASC, JOB_COMPONENT_NBR ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.Client

                                    ThisTimeSheet.DefaultView.Sort = "CL_CODE ASC, DIV_CODE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.Division

                                    ThisTimeSheet.DefaultView.Sort = "DIV_CODE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.Product

                                    ThisTimeSheet.DefaultView.Sort = "PRD_CODE ASC, CL_CODE ASC, DIV_CODE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.FunctionCategory

                                    ThisTimeSheet.DefaultView.Sort = "FNC_CAT ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.DepartmentTeam

                                    ThisTimeSheet.DefaultView.Sort = "DP_TM_CODE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.Date

                                    ThisTimeSheet.DefaultView.Sort = "EMP_DATE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.ClientAsc

                                    ThisTimeSheet.DefaultView.Sort = "CL_CODE ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.ClientDesc

                                    ThisTimeSheet.DefaultView.Sort = "CL_CODE DESC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.JobAsc

                                    ThisTimeSheet.DefaultView.Sort = "JOB_NUMBER ASC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                                Case AdvantageFramework.Timesheet.Methods.TimesheetSort.JobDesc

                                    ThisTimeSheet.DefaultView.Sort = "JOB_NUMBER DESC"
                                    ThisTimeSheet = ThisTimeSheet.DefaultView.ToTable()

                            End Select

                        End If

                    Catch ex As Exception
                    End Try

                    If CheckProductCategory() = True Then

                        rpt.prodCat = True

                    Else

                        rpt.prodCat = False

                    End If

                    rpt.dt = ThisTimeSheet
                    rpt.totalHours = TotalHours
                    rpt.EmpName = EmpName
                    rpt.EmpCode = Request.QueryString("empcode")
                    rpt.StartDate = Request.QueryString("startdate")
                    rpt.EndDate = Request.QueryString("enddate")
                    rpt.UserCode = Session("UserCode")
                    rpt.ConnectionString = Session("ConnString")

                    Try

                        If Request.QueryString("ExcludeEmployeeSignature") IsNot Nothing AndAlso Request.QueryString("ExcludeEmployeeSignature") = "0" Then

                            rpt.UseEmpSig = True
                            rpt.SigImage = oEmp.getEmpSignatureImage(Request.QueryString("UserCode"))

                        Else

                            rpt.UseEmpSig = False

                        End If

                    Catch ex As Exception
                    End Try

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob2,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3,
                     AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDays

                    Dim ds As DataSet
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim oTS As cReports = New cReports(Session("ConnString"))
                    ds = oTS.GetReportScheduleTasks(Request.QueryString("job"), Request.QueryString("jobcomp"), Request.QueryString("sort"), Request.QueryString("ms"), Request.QueryString("completed"))
                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob2 Then
                        rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob2
                    ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3 Then
                        rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob3
                        rpt.dtAssignments = ds.Tables(1)
                    ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDays Then
                        rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJobDays
                    Else
                        rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob
                    End If
                    rpt.CultureCode = CurrentCultureCode
                    rpt.dtJob = oTrafficSchedule.GetScheduleWSTaskData(Request.QueryString("job"), Request.QueryString("jobcomp"), CStr(Session("UserCode")), , , , , , , , , , , False, True, False, False,)
                    rpt.dtTS = ds.Tables(0)
                    rpt.Agency = oReports.GetAgencyName
                    rpt.connstring = Session("ConnString")
                    rpt.usercode = Session("UserCode")
                    rpt.hours = Request.QueryString("hours")
                    rpt.due = Request.QueryString("due")
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("PSLogoLocation")
                    rpt.LogoPlacement = Session("PSLogoPlacement")
                    rpt.LogoID = Session("PSLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("PSLogoLocationID"))
                    rpt.excludeTC = Request.QueryString("excludeTC")
                    rpt.excludephase = Request.QueryString("phase")
                    rpt.excluderesource = Request.QueryString("reso")

                    If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob OrElse
                        TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3 OrElse
                        TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDays Then

                        rpt.excludemilestone = Request.QueryString("exms") 'milestone column, not milestone tasks
                        rpt.excludetimedue = Request.QueryString("timedue")

                    End If

                    If Session("PSLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("PSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate

                    Dim ds As DataSet
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim oTS As cReports = New cReports(Session("ConnString"))

                    rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJobDueDate
                    rpt.CultureCode = CurrentCultureCode
                    rpt.dtJob = oTrafficSchedule.GetScheduleWSTaskData(Request.QueryString("job"), Request.QueryString("jobcomp"), CStr(Session("UserCode")), , , , , , , , , , , False, True, False, False)
                    ds = oTS.GetReportScheduleTasks(Request.QueryString("job"), Request.QueryString("jobcomp"), Request.QueryString("sort"), Request.QueryString("ms"), Request.QueryString("completed"))
                    rpt.dtTS = ds.Tables(0)
                    rpt.Agency = oReports.GetAgencyName
                    rpt.connstring = Session("ConnString")
                    rpt.usercode = Session("UserCode")
                    rpt.hours = Request.QueryString("hours")
                    rpt.due = Request.QueryString("due")
                    rpt.imgPath = imgPath
                    rpt.LogoPath = Session("PSLogoLocation")
                    rpt.LogoPlacement = Session("PSLogoPlacement")
                    rpt.LogoID = Session("PSLogoLocationID")
                    rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("PSLogoLocationID"))
                    rpt.excludeTC = Request.QueryString("excludeTC")
                    rpt.ms = Request.QueryString("ms")
                    rpt.excludephase = Request.QueryString("phase")
                    rpt.excluderesource = Request.QueryString("reso")

                    If Session("PSLogoLocationID") <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                            rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("PSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        End Using
                    End If

                Case AdvantageFramework.Reporting.ActiveReports.ReportName.VendorQuoteRequest

                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim cr As New cReports(Session("ConnString"))
                    rpt = New ActiveReportsAssembly.arptVendorQuoteRequest
                    rpt.CultureCode = CurrentCultureCode
                    strReportName = "VendorQuoteRequest"
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim taskVar As String
                    Dim ar() As String
                    taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "Location")
                    If taskVar <> "" Then
                        ar = taskVar.Split("|")
                        rpt.logopath = ar(1)
                        rpt.LogoID = ar(0)
                        rpt.dtLocation = cr.GetAgencyInfoJobTemplate(ar(0))
                    End If

                    taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "PrintDate")
                    If taskVar <> "" Then
                        rpt.printDate = taskVar
                    End If
                    rpt.imgPath = imgPath
                    rpt.dt = est.GetRequestPrint(Request.QueryString("EstNum"), Request.QueryString("EstCompNum"), Request.QueryString("VendorQteNbr"), Session("UserCode"), Request.QueryString("VendorCode"), Session("VendorsRFQVendors"))
                    Session("VendorsRFQVendors") = ""

            End Select

        Catch ex As Exception

            HttpContext.Current.Response.Write("popgetreport: " & ex.Message.ToString())

        End Try

        If flgNoData = True Then

            Response.Redirect(strURL)

        End If

        Dim strFileExtension As String = String.Empty

        If strFileName = String.Empty Or strFileName = "" Then

            If TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersion Then
                If Me._JobNumber <> 0 Then
                    strFileName = Session("JVTemplateName").ToString.Replace(" ", "") & "_" & Session("versionNbr") & "_" & CInt(Me._JobNumber).ToString() & "_" & CInt(Me._JobComponentNbr).ToString() & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
                Else
                    strFileName = Session("JVTemplateName").ToString.Replace(" ", "") & "_" & Session("versionNbr") & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
                End If
            ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobVersions Then
                strFileName = Session("JVReportTitle").ToString.Replace("Report", "").Replace(" ", "") & "_" & CInt(Me._JobNumber).ToString() & "_" & CInt(Me._JobComponentNbr).ToString() & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
            ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate Then
                strFileName = "Project_Schedule_" & Request.QueryString("job") & "_" & Request.QueryString("jobcomp") & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
            ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobTemplate Then
                strFileName = "Job_Jacket_" & Me._JobNumber & "_" & Me._JobComponentNbr & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
            ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecs Or TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.JobSpecsAllVersions Then
                strFileName = "Specification_" & Me._JobNumber & "_" & Me._JobComponentNbr & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
            ElseIf TypeOfReport = AdvantageFramework.Reporting.ActiveReports.ReportName.CreativeBrief Then
                strFileName = "Creative_Brief_" & Me._JobNumber & "_" & Me._JobComponentNbr & "_" & Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0")
            Else
                strFileName = Now.Year.ToString() & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") & "_" & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") & Now.Second.ToString.PadLeft(2, "0") & "_" & strReportName
            End If
        End If


        Try

            Dim ci As New System.Globalization.CultureInfo(ReportFunctions.UserCultureGet())
            rpt.Culture = ci
            rpt.Run(False)

        Catch eRunReport As DataDynamics.ActiveReports.ReportException

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Write("<h1>Error running report:</h1>")
            HttpContext.Current.Response.Write(eRunReport.ToString())
            Return

        End Try

        Select Case TypeOfExport

            Case 1 'ExportType.PDF

                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.ClearHeaders()
                HttpContext.Current.Response.ClearContent()
                HttpContext.Current.Response.ContentType = "application/pdf"
                strFileExtension = ".pdf"

            Case 2 'ExportType.XLS

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
                strFileExtension = ".xls"

            Case 3 'ExportType.HTM

                HttpContext.Current.Response.ContentType = "message/rfc822"
                strFileExtension = ".htm"

            Case 4 'ExportType.TXT

                HttpContext.Current.Response.ContentType = "text/plain"
                strFileExtension = ".txt"

            Case 5 'ExportType.RTF

                HttpContext.Current.Response.ContentType = "application/rtf"
                strFileExtension = ".rtf"

            Case 6 'ExportType.TIFF

                HttpContext.Current.Response.ContentType = "image/tiff"
                strFileExtension = ".tiff"

            Case Else

                HttpContext.Current.Response.ContentType = "application/pdf"
                strFileExtension = ".pdf"

        End Select

        Me.GetFilename(strFileName, Session("EmpCode"), TypeOfReport)

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & strFileName & strFileExtension)

        ' Create a new memory stream that will hold the pdf output
        Dim memStream As New System.IO.MemoryStream()

        ' Create the PDF export object
        Select Case TypeOfExport
            Case 1 'ExportType.PDF

                Dim pdf As New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                pdf.Export(rpt.Document, memStream)

            Case 2 'ExportType.XLS

                Dim xls As New DataDynamics.ActiveReports.Export.Xls.XlsExport
                xls.RemoveVerticalSpace = True
                'xls.UseCellMerging = True
                'xls.MinColumnWidth = 1
                xls.FileFormat = FileFormat.Xls95
                xls.Export(rpt.Document, memStream)

            Case 3 'ExportType.HTM

                'Dim htm As New DataDynamics.ActiveReports.Export.Html.HtmlExport
                'htm.Export(rpt.Document, memStream)

            Case 4 'ExportType.TXT

                Dim txt As New DataDynamics.ActiveReports.Export.Text.TextExport
                txt.Export(rpt.Document, memStream)

            Case 5 'ExportType.RTF

                Dim rtf As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                rtf.Export(rpt.Document, memStream)

            Case 6 'ExportType.TIFF

                Dim tiff As New DataDynamics.ActiveReports.Export.Tiff.TiffExport
                tiff.Export(rpt.Document, memStream)

            Case Else

                Dim pdf As New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                pdf.Export(rpt.Document, memStream)

        End Select

        HttpContext.Current.Response.BinaryWrite(memStream.ToArray())
        ' Send all buffered content to the client
        memStream.Close()
        HttpContext.Current.Response.End()

    End Sub
    Public Function renderDoc(ByVal strFileName As String, ByVal strReport As String, ByVal ID As String, ByVal PP As String, ByVal Loc As String, ByVal AD As String,
                         ByVal Footer As String, ByVal exportType As Integer, ByVal imgPath As String, Optional ByVal options As String = "", Optional ByVal OfficeCodes As String = "",
                         Optional ByRef ErrorMessage As String = "", Optional ByVal AgingDateType As Integer = 1, Optional ByVal ExcludeDescription As String = "0") As Boolean
        Try
            Dim rpt As Object = Nothing
            Dim CurrentCultureCode As String = LoGlo.UserCultureGet()
            Dim oReports As New cReports(Session("ConnString"))

            Try
                Select Case strReport
                    Case "clientarstatement001"
                        rpt = New ActiveReportsAssembly.arptClientARStatement001
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "clientarstatement002"
                        rpt = New ActiveReportsAssembly.arptClientARStatement002
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "2", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "clientarstatement003"
                        rpt = New ActiveReportsAssembly.arptClientARStatement003
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "3", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "clientarstatement004"
                        rpt = New ActiveReportsAssembly.arptClientARStatement004
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "4", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "clientarstatement005"
                        rpt = New ActiveReportsAssembly.arptClientARStatement005
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARClientStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "productarstatement001"
                        rpt = New ActiveReportsAssembly.arptProductARStatement001
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "1", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "productarstatement002"
                        rpt = New ActiveReportsAssembly.arptProductARStatement002
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "2", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "productarstatement003"
                        rpt = New ActiveReportsAssembly.arptProductARStatement003
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "3", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "productarstatement004"
                        rpt = New ActiveReportsAssembly.arptProductARStatement004
                        rpt.CultureCode = CurrentCultureCode
                        rpt.strID = ID
                        rpt.strPostPeriod = PP
                        rpt.strLocation = Loc
                        rpt.strAgedDate = AD
                        rpt.strFooter = Footer
                        If options.Trim() = "f" Then
                            rpt.PutCommentInFooter = True
                        Else
                            rpt.PutCommentInFooter = False
                        End If
                        rpt.strExclude = ExcludeDescription
                        rpt.dt = oReports.GetARProductStatement(rpt.strID, rpt.strPostPeriod, rpt.strLocation, rpt.strAgedDate, rpt.strFooter, "4", OfficeCodes, AgingDateType)

                        If Loc <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Loc, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                    Case "purchaseorder", "purchaseorderRR", "purchaseorder3"
                        If strReport = "purchaseorder" Then
                            rpt = New ActiveReportsAssembly.arptPurchaseOrder
                        End If
                        If strReport = "purchaseorderRR" Then
                            rpt = New ActiveReportsAssembly.arptPurchaseOrderRR
                            rpt.LogoName = Session("POPrintLocationName")
                        End If
                        If strReport = "purchaseorder3" Then
                            rpt = New ActiveReportsAssembly.arptPurchaseOrder3
                            rpt.LogoName = Session("POPrintLocationName")
                        End If
                        rpt.CultureCode = CurrentCultureCode
                        Dim dsPO As New DataSet
                        Dim dtPrintDef As DataTable
                        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                        Dim session_user As String = ""
                        Dim cEmp As New cEmployee(Session("ConnString"))
                        POHeader.Select_POHeader(Int32.Parse(ID.Trim), "")
                        POHeader.Select_PO_Memo("po_footer", Int32.Parse(ID.Trim))
                        POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)

                        Dim header As String
                        Dim StandardComments As AdvantageFramework.Database.Entities.StandardComment = Nothing
                        Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing
                        If Not String.IsNullOrEmpty(Session("UserCode")) Then
                            session_user = Session("UserCode")
                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                            Dim POs As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing

                            POs = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, Int32.Parse(ID.Trim)).ToList

                            For Each p In POs
                                If p.Job IsNot Nothing Then
                                    If p.Job.Client.Name <> "" Then
                                        rpt._ClientName = p.Job.Client.Name
                                        Exit For
                                    End If
                                End If
                            Next

                        End Using

                        dtPrintDef = PO.GetPO_PrintDef_By_User_DTable(session_user) 'user print def.
                        'If dtPrintDef.Rows.Count > 0 Then
                        '    If Not String.IsNullOrEmpty(dtPrintDef.Rows(0).Item(10)) Then
                        '        rpt.logopath = dtPrintDef.Rows(0).Item(10)
                        '    End If
                        'End If
                        dsPO = PODtl.Select_PODetailsDS(Int32.Parse(ID.Trim), session_user.Trim, options, Session("POPrintLocationID"))
                        rpt.logopath = Session("POPrintLocationPath")
                        rpt.LogoID = Session("POPrintLocationID")
                        rpt.imgPath = imgPath
                        rpt.PODate = Session("POPrintDate")

                        If dtPrintDef.Rows.Count > 0 Then
                            If IsDBNull(dtPrintDef.Rows(0)(18)) = False Then
                                If dtPrintDef.Rows(0)(18).ToString() = "1" Then
                                    rpt.UseLocationName = True
                                End If
                            End If
                            If IsDBNull(dtPrintDef.Rows(0)(19)) = False Then
                                If dtPrintDef.Rows(0)(19).ToString() = "1" Then
                                    rpt.UseClientName = True
                                End If
                            End If
                        End If

                        If dsPO.Tables(0).Rows.Count > 0 Then
                            If dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "" Then
                                dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "-"
                            End If
                            If dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "" Then
                                dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "-"
                            End If
                            If IsDBNull(dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")) = True Then
                                rpt.header = ""
                            Else
                                If dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER") = "" Then
                                    rpt.header = ""
                                Else
                                    header = dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")
                                    rpt.header = RTrim(LTrim(header.Replace("|", "•")))
                                End If
                            End If
                        End If
                        If dsPO.Tables(0).Rows.Count > 0 Then
                            rpt.ds1 = dsPO
                        Else
                            dsPO = New DataSet
                            dsPO.Tables.Add("Temp")
                        End If

                        Try

                            rpt.DefaultLocation = Session("LocationOverride")

                        Catch ex As Exception

                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

                        End Using

                        Dim ClientCode As String = ""
                        Dim DivisionCode As String = ""
                        Dim ProductCode As String = ""
                        Dim StandComment As String = ""

                        If POHeader.PO_Footer = Nothing Then
                            For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                                If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                    ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                    DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                    ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                End If

                                StandardComments = Nothing

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                            Next

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments IsNot Nothing Then
                                rpt.FooterComment = StandComment 'StandardComments.Comment
                                rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                            Else
                                rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                            End If
                        ElseIf POHeader.PO_Footer = "Agency Defined" Then
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        ElseIf POHeader.PO_Footer = "Standard Comment" Then
                            For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                                If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                    ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                    DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                    ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                End If

                                StandardComments = Nothing

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If
                            Next

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments IsNot Nothing Then
                                rpt.FooterComment = StandComment 'StandardComments.Comment
                                rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                            Else
                                rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                            End If

                        Else
                            rpt.FooterComment = POHeader.PO_Footer
                        End If
                        If dtPrintDef.Rows.Count > 0 Then
                            If IsDBNull(dtPrintDef.Rows(0)(3)) = False Then
                                If dtPrintDef.Rows(0)(3).ToString() = "0" Then
                                    rpt.FooterComment = ""
                                End If
                            End If
                        End If

                        Try
                            Dim sig, str, userSig, opts() As String
                            str = options.Trim
                            opts = str.Split(";")
                            sig = opts(11) 'Exclude Emp Sig (0 use, 1 exclude)

                            If sig = "0" Then
                                rpt.UseEmpSig = True

                                If opts.Length >= 14 Then

                                    userSig = opts(13) 'use logged in employee 

                                End If

                            Else
                                rpt.UseEmpSig = False
                            End If

                            If userSig = "1" Then

                                rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))

                            Else

                                rpt.SigImage = cEmp.getEmpSignatureImage(POHeader.Issue_By_Emp_Code)

                            End If
                        Catch ex As Exception
                        End Try

                    Case "purchaseorder2"
                        rpt = New ActiveReportsAssembly.arptPurchaseOrder2
                        rpt.CultureCode = CurrentCultureCode
                        Dim dsPO As New DataSet
                        Dim dtPrintDef As DataTable
                        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                        Dim session_user As String = ""
                        Dim cEmp As New cEmployee(Session("ConnString"))
                        POHeader.Select_POHeader(Int32.Parse(ID.Trim), "")
                        POHeader.Select_PO_Memo("po_footer", Int32.Parse(ID.Trim))
                        POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)

                        Dim header As String
                        Dim StandardComments As AdvantageFramework.Database.Entities.StandardComment = Nothing
                        Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing
                        If Not String.IsNullOrEmpty(Session("UserCode")) Then
                            session_user = Session("UserCode")
                        End If

                        dtPrintDef = PO.GetPO_PrintDef_By_User_DTable(session_user) 'user print def.

                        dsPO = PODtl.Select_PODetailsDS(Int32.Parse(ID.Trim), session_user.Trim, options, Session("POPrintLocationID"))
                        rpt.logopath = Session("POPrintLocationPath")
                        rpt.LogoID = Session("POPrintLocationID")
                        rpt.imgPath = imgPath
                        rpt.PODate = Session("POPrintDate")
                        If dsPO.Tables(0).Rows.Count > 0 Then
                            If dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "" Then
                                dsPO.Tables(0).Rows(0)("DEL_INSTRUCT") = "-"
                            End If
                            If dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "" Then
                                dsPO.Tables(0).Rows(0)("PO_MAIN_INSTRUCT") = "-"
                            End If
                            If IsDBNull(dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")) = True Then
                                rpt.header = ""
                            Else
                                If dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER") = "" Then
                                    rpt.header = ""
                                Else
                                    header = dsPO.Tables(0).Rows(0)("AGENCY_FULL_HEADER")
                                    rpt.header = RTrim(LTrim(header.Replace("|", "•")))
                                End If
                            End If
                        End If
                        If dsPO.Tables(0).Rows.Count > 0 Then
                            rpt.ds1 = dsPO
                        Else
                            dsPO = New DataSet
                            dsPO.Tables.Add("Temp")
                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

                        End Using

                        Dim ClientCode As String = ""
                        Dim DivisionCode As String = ""
                        Dim ProductCode As String = ""
                        Dim StandComment As String = ""

                        If POHeader.PO_Footer = Nothing Then
                            For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                                If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                    ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                    DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                    ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                End If

                                StandardComments = Nothing

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                            Next

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments IsNot Nothing Then
                                rpt.FooterComment = StandComment 'StandardComments.Comment
                                rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                            Else
                                rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                            End If
                        ElseIf POHeader.PO_Footer = "Agency Defined" Then
                            rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                        ElseIf POHeader.PO_Footer = "Standard Comment" Then
                            For x As Integer = 0 To dsPO.Tables(0).Rows.Count - 1
                                If IsDBNull(dsPO.Tables(0).Rows(x)("CL_CODE")) = False Then
                                    ClientCode = dsPO.Tables(0).Rows(x)("CL_CODE").ToString
                                    DivisionCode = dsPO.Tables(0).Rows(x)("DIV_CODE").ToString
                                    ProductCode = dsPO.Tables(0).Rows(x)("PRD_CODE").ToString
                                End If

                                StandardComments = Nothing

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ProductCode = ClientComment.ProductCode And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And DivisionCode = ClientComment.DivisionCode And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComments Is Nothing Then
                                    For Each ClientComment In StandardCommentsList
                                        If ClientCode = ClientComment.ClientCode And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                            If StandComment = "" Then
                                                StandComment &= ClientComment.Comment
                                            Else
                                                StandComment &= vbCrLf & ClientComment.Comment
                                            End If
                                            StandardComments = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If
                            Next

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And POHeader.Vendor_Code = ClientComment.VendorCode Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments Is Nothing Then
                                For Each ClientComment In StandardCommentsList
                                    If ClientComment.ClientCode Is Nothing And ClientComment.DivisionCode Is Nothing And ClientComment.ProductCode Is Nothing And ClientComment.VendorCode Is Nothing Then
                                        StandComment &= ClientComment.Comment
                                        StandardComments = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                            If StandardComments IsNot Nothing Then
                                rpt.FooterComment = StandComment 'StandardComments.Comment
                                rpt.DefaultFooterFontSize = StandardComments.FontSize.GetValueOrDefault(0)
                            Else
                                rpt.FooterComment = POHeader.Default_Memo_Text.Trim
                            End If

                        Else
                            rpt.FooterComment = POHeader.PO_Footer
                        End If
                        If dtPrintDef.Rows.Count > 0 Then
                            If IsDBNull(dtPrintDef.Rows(0)(3)) = False Then
                                If dtPrintDef.Rows(0)(3).ToString() = "0" Then
                                    rpt.FooterComment = ""
                                End If
                            End If
                        End If

                        Try
                            Dim sig, str, opts() As String
                            str = options.Trim
                            opts = str.Split(";")
                            sig = opts(11) 'Exclude Emp Sig (0 use, 1 exclude)
                            If sig = 0 Then
                                rpt.UseEmpSig = True
                            Else
                                rpt.UseEmpSig = False
                            End If

                            rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        Catch ex As Exception
                        End Try

                    Case "joborder"
                        Dim ds As DataSet
                        Dim ds2 As DataSet
                        Dim ds3 As DataSet
                        Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
                        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        rpt = New ActiveReportsAssembly.arptJobTemplate
                        rpt.CultureCode = CurrentCultureCode
                        rpt.JobNum = Session("JobOrderFormJobNum")
                        rpt.JobCompNum = Session("JobOrderFormJobCompNum")
                        rpt.printJobOrderForm = Session("IncludeJOFReport")
                        rpt.omitEmptyFields = Session("OmitEFReport")
                        rpt.includeTA = Session("IncludeTAReport")
                        rpt.sectionTitleTA = Session("TASectionTitle")
                        rpt.includeTS = Session("IncludeTSReport")
                        rpt.scheduleCommentTS = Session("TSScheduleComments")
                        rpt.sectionTitleTS = Session("TSSectionTitle")
                        rpt.dueDatesOnlyTS = Session("TSDueDatesOnly")
                        rpt.milestonesOnlyTS = Session("TSMilestonesOnly")
                        rpt.milestoneTitle = Session("TSMilestoneTitle")
                        rpt.employeeAssignmentsTS = Session("TSEmpAssignments")
                        rpt.ReportTitle = MyJobTemplate.GetTemplateDesc(MyJobTemplate.GetTemplateCode(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum")))
                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JobOrderFormLogoLocation")
                        rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                        rpt.LogoID = Session("JobOrderFormLogoLocationID")
                        rpt.Reporter = Session("UserCode")
                        rpt.dtTraffic = oReports.GetJobTrafficAssignments(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        ds3 = oTrafficSchedule.GetScheduleAssignmentLabels
                        rpt.dtTrafficLabels = ds3.Tables(0)
                        rpt.dtSchedule = oReports.GetJobTrafficSchedule(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"), "ama")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                        ds2 = MyJobTemplate.GetJobTemplateComments(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt.dtComments = ds2.Tables(0)
                        ds = MyJobTemplate.GetJobTemplateDetails(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt.MyDT = ds.Tables(0)

                        If Session("JobOrderFormLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "jobspec"
                        Dim js As New Job_Specs(Session("ConnString"))
                        Dim ds As DataSet
                        Dim dr As SqlClient.SqlDataReader
                        Dim jl As New JOB_LOG(Session("ConnString"))
                        Dim jc As New JOB_COMPONENT(Session("ConnString"))
                        jl.LoadByPrimaryKey(CInt(Session("JSReportJobNum")))
                        jc.LoadByPrimaryKey(CInt(Session("JSReportJobCompNum")), CInt(Session("JSReportJobNum")))
                        rpt = New ActiveReportsAssembly.arptJobSpecs
                        rpt.CultureCode = CurrentCultureCode
                        ds = js.GetJobSpecsDataSet(Session("JSReportJobNum"), Session("JSReportJobCompNum"), Session("JSReportVersion"), Session("JSReportRevision"))
                        rpt.dtData = ds.Tables(0)
                        ds = js.GetJobSpecCategories(Session("JSType"))
                        rpt.dtCategory = ds.Tables(0)
                        rpt.dtQuantity = js.GetJobSpecsQtyData(Session("JSReportJobNum"), Session("JSReportJobCompNum"), Session("JSReportVersion"), Session("JSReportRevision"))
                        ds = js.GetJobSpecsDataSetTextFields(Session("JSReportJobNum"), Session("JSReportJobCompNum"), Session("JSReportVersion"), Session("JSReportRevision"))
                        rpt.dtText = ds.Tables(0)
                        rpt.Description = Session("JSDescription")
                        rpt.reason = Session("JSReason")
                        rpt.version = Session("JSReportVersion")
                        rpt.revision = Session("JSReportRevision")
                        rpt.job = Session("JSReportJobNum") & " - " & jl.JOB_DESC
                        rpt.jobcomp = Session("JSReportJobCompNum") & " - " & jc.JOB_COMP_DESC
                        dr = js.GetJobSpecCDP(CInt(Session("JSReportJobNum")))
                        Do While dr.Read
                            rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                            rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                            rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                        Loop
                        dr.Close()
                        rpt.Reporter = Session("UserCode")
                        rpt.title = Session("JSReportTitle")
                        dr = js.GetJobSpecApprovalData(CInt(Session("JSReportJobNum")), CInt(Session("JSReportJobCompNum")))
                        If dr.HasRows = True Then
                            Do While dr.Read
                                If dr.GetInt32(0) = CInt(Session("JSReportVersion")) Then
                                    rpt.Approved = True
                                Else
                                    rpt.Approved = False
                                End If
                            Loop
                        Else
                            rpt.Approved = False
                        End If
                        dr.Close()
                        dr = js.GetJobSpecQtyVendorTabs(Session("JSType"))
                        If dr.HasRows = True Then
                            Do While dr.Read
                                If dr.GetInt16(2) = 1 Then
                                    rpt.vendortab = 1
                                    rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Session("JSReportJobNum")), CInt(Session("JSReportJobCompNum")), 1)
                                End If
                                If dr.GetInt16(2) = 2 Then
                                    rpt.vendortab = 2
                                    rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Session("JSReportJobNum")), CInt(Session("JSReportJobCompNum")), 2)
                                End If
                            Loop
                        End If
                        dr.Close()
                        If Session("JSPage") = "jobjacket" Then
                            rpt.includeVS = Session("JSIncludeVS")
                            rpt.includeMS = Session("JSIncludeMS")
                            rpt.page = "jobjacket"
                        Else
                            rpt.includeVS = False
                            rpt.includeMS = False
                            rpt.page = "jobspecs"
                        End If
                        'strReportName = "Specification"
                        rpt.dtMediaSpecs = js.GetJobSpecsMediaSpecsData(CInt(Session("JSReportJobNum")), CInt(Session("JSReportJobCompNum")))

                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JSLogoLocation")
                        rpt.LogoPlacement = Session("JSLogoPlacement")
                        rpt.LogoID = Session("JSLogoLocationID")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JSLogoLocationID"))
                        rpt.omitEmptyFields = Session("JSOmitEmptyFields")

                        If Session("JSLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "TrafficDetailByJob", "TrafficDetailByJob2", "TrafficDetailByJob3", "TrafficDetailByJobDays"
                        Dim ThisJob As Integer = 0
                        Dim ThisJobComp As Integer = 0
                        Dim MilestoneSetting As Integer = 0
                        Dim completed As Integer = 0
                        Dim excludeTC As Integer = 0
                        Dim excludephase As Integer = 0
                        Dim excluderesource As Integer = 0
                        Dim sort As String = ""
                        Dim ar() As String
                        Dim ds As DataSet
                        If options.Length > 0 Then
                            ar = options.Split("|")
                            Try
                                ThisJob = ar(0)
                            Catch ex As Exception
                                ThisJob = 0
                            End Try
                            Try
                                ThisJobComp = ar(1)
                            Catch ex As Exception
                                ThisJobComp = 0
                            End Try
                        End If
                        Try
                            If ar.Length > 3 Then
                                If IsNumeric(ar(3)) = True Then
                                    MilestoneSetting = ar(3)
                                Else
                                    If ar(3) = "True" Then
                                        MilestoneSetting = 1
                                    Else
                                        MilestoneSetting = 0
                                    End If
                                End If
                                If IsNumeric(ar(5)) = True Then
                                    excludeTC = ar(5)
                                Else
                                    If ar(5) = "True" Then
                                        excludeTC = 1
                                    Else
                                        excludeTC = 0
                                    End If
                                End If
                                If ar(6) <> "" Then
                                    sort = ar(6)
                                End If
                                If IsNumeric(ar(7)) = True Then
                                    excludephase = ar(7)
                                Else
                                    If ar(7) = "True" Then
                                        excludephase = 1
                                    Else
                                        excludephase = 0
                                    End If
                                End If
                                If IsNumeric(ar(8)) = True Then
                                    excluderesource = ar(8)
                                Else
                                    If ar(8) = "True" Then
                                        excluderesource = 1
                                    Else
                                        excluderesource = 0
                                    End If
                                End If
                                If IsNumeric(ar(9)) = True Then
                                    completed = ar(9)
                                Else
                                    If ar(9) = "True" Then
                                        completed = 1
                                    Else
                                        completed = 0
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            excludeTC = 0
                            excludephase = 0
                            excluderesource = 0
                        End Try
                        If ThisJob > 0 And ThisJobComp > 0 Then
                            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                            Dim oTS As cReports = New cReports(Session("ConnString"))
                            ds = oTS.GetReportScheduleTasks(ThisJob, ThisJobComp, sort, MilestoneSetting, completed)
                            If strReport = "TrafficDetailByJob2" Then
                                rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob2
                            ElseIf strReport = "TrafficDetailByJob3" Then
                                rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob3
                                rpt.dtAssignments = ds.Tables(1)
                            ElseIf strReport = "TrafficDetailByJobDays" Then
                                rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJobDays
                            Else
                                rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJob
                            End If
                            rpt.CultureCode = CurrentCultureCode
                            rpt.dtJob = oTrafficSchedule.GetScheduleWSTaskData(ThisJob, ThisJobComp, CStr(Session("UserCode")), , , , , , , , , , , False, True)
                            'rpt.dtTS = oTrafficSchedule.GetScheduleTasks(ThisJob, ThisJobComp, "", CStr(Session("UserCode")))
                            rpt.dtTS = ds.Tables(0)
                            rpt.Agency = oReports.GetAgencyName
                            rpt.connstring = Session("ConnString")
                            rpt.usercode = Session("UserCode")
                            Dim h As Integer = 0
                            Try
                                h = ar(2)
                            Catch ex As Exception
                                h = 0
                            End Try
                            rpt.hours = h
                            Dim d As Integer = 0
                            Try
                                d = ar(4)
                            Catch ex As Exception
                                d = 0
                            End Try
                            rpt.due = d
                            rpt.imgPath = imgPath
                            rpt.LogoPath = Session("PSLogoLocation")
                            rpt.LogoPlacement = Session("PSLogoPlacement")
                            rpt.LogoID = Session("PSLogoLocationID")
                            rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("PSLogoLocationID"))
                            rpt.excludeTC = excludeTC
                            rpt.excludephase = excludephase
                            rpt.excluderesource = excluderesource

                            If Session("PSLogoLocationID") <> "" Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("PSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                                End Using
                            End If
                        End If
                    Case "TrafficDetailByJobDueDate"
                        Dim ThisJob As Integer = 0
                        Dim ThisJobComp As Integer = 0
                        Dim ar() As String
                        Dim ds As DataSet
                        If options.Length > 0 Then
                            ar = options.Split("|")
                            Try
                                ThisJob = ar(0)
                            Catch ex As Exception
                                ThisJob = 0
                            End Try
                            Try
                                ThisJobComp = ar(1)
                            Catch ex As Exception
                                ThisJobComp = 0
                            End Try
                        End If
                        If ThisJob > 0 And ThisJobComp > 0 Then
                            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                            Dim oTS As cReports = New cReports(Session("ConnString"))
                            ds = oTS.GetReportScheduleTasks(ThisJob, ThisJobComp, ar(6), ar(3), ar(9))
                            rpt = New ActiveReportsAssembly.arptJobTrafficSchedulebyJobDueDate
                            rpt.CultureCode = CurrentCultureCode
                            rpt.dtJob = oTrafficSchedule.GetScheduleWSTaskData(ThisJob, ThisJobComp, CStr(Session("UserCode")), , , , , , , , , , , False, True)
                            'rpt.dtTS = oTrafficSchedule.GetScheduleTasks(ThisJob, ThisJobComp, "", CStr(Session("UserCode")))
                            rpt.dtTS = ds.Tables(0)
                            rpt.Agency = oReports.GetAgencyName
                            rpt.connstring = Session("ConnString")
                            rpt.usercode = Session("UserCode")
                            rpt.hours = ar(2)
                            rpt.due = ar(4)
                            rpt.imgPath = imgPath
                            rpt.LogoPath = Session("PSLogoLocation")
                            rpt.LogoPlacement = Session("PSLogoPlacement")
                            rpt.LogoID = Session("PSLogoLocationID")
                            rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("PSLogoLocationID"))
                            rpt.excludeTC = ar(5)
                            rpt.excludephase = ar(7)
                            rpt.excluderesource = ar(8)

                            If Session("PSLogoLocationID") <> "" Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("PSLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                                End Using
                            End If
                        End If
                    Case "jobver"
                        Dim jv As New JobVersion(Session("ConnString"))
                        Dim js As New Job_Specs(Session("ConnString"))
                        Dim ds As DataSet
                        Dim dr As SqlClient.SqlDataReader
                        Dim jl As New JOB_LOG(Session("ConnString"))
                        Dim jc As New JOB_COMPONENT(Session("ConnString"))
                        Dim job_nbr As Integer
                        Dim version_nbr, job_comp As Int16
                        Dim version_str, job_str As String
                        Dim job_version_desc As String
                        If Session("JVReportJobNum") = 0 Then

                        Else
                            jl.LoadByPrimaryKey(CInt(Session("JVReportJobNum")))
                            jc.LoadByPrimaryKey(CInt(Session("JVReportJobCompNum")), CInt(Session("JVReportJobNum")))
                        End If

                        rpt = New ActiveReportsAssembly.arptJobVersion
                        rpt.CultureCode = CurrentCultureCode
                        ds = jv.getArptJobVersion(Session("JobVerHdrID"))
                        rpt.dtData = ds.Tables(0)
                        rpt.exportformat = exportType

                        version_nbr = Session("versionNbr")
                        version_str = version_nbr.ToString.PadLeft(3, "0")

                        job_version_desc = jv.GetAgencyDesc()
                        rpt.Description = version_str & " - " & Session("JVDescription")

                        'rpt.Description = Session("JVDescription")
                        rpt.version = Session("versionNbr")
                        If Session("JVReportJobNum") <> 0 Then
                            job_nbr = Session("JVReportJobNum")
                            job_str = job_nbr.ToString.PadLeft(6, "0")
                            rpt.job = job_str & " - " & jl.JOB_DESC

                            job_comp = Session("JVReportJobCompNum")
                            job_str = job_comp.ToString.PadLeft(3, "0")
                            rpt.jobcomp = job_str & " - " & jc.JOB_COMP_DESC

                            dr = js.GetJobSpecCDP(CInt(Session("JVReportJobNum")))
                            Do While dr.Read
                                rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                                rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                                rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                            Loop
                            dr.Close()
                        Else
                            dr = jv.GetJVRequestDescriptions(Session("JobVerHdrID"))
                            Do While dr.Read
                                rpt.client = dr.GetString(0) & " - " & dr.GetString(1)
                                rpt.division = dr.GetString(2) & " - " & dr.GetString(3)
                                rpt.product = dr.GetString(4) & " - " & dr.GetString(5)
                            Loop
                            dr.Close()
                        End If

                        rpt.Reporter = Session("UserCode")
                        rpt.ReportTitle = Session("JVReportTitle")

                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JVLogoLocation")
                        rpt.LogoPlacement = Session("JVLogoPlacement")
                        rpt.LogoID = Session("JVLogoLocationID")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JVLogoLocationID"))
                        rpt.omitEmptyFields = Session("JVOmitEmptyFields")

                        If Session("JVLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JVLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "jobversions"
                        Dim jv As New JobVersion(Session("ConnString"))
                        Dim js As New Job_Specs(Session("ConnString"))
                        Dim ds As DataSet
                        Dim dr As SqlClient.SqlDataReader
                        Dim jl As New JOB_LOG(Session("ConnString"))
                        Dim jc As New JOB_COMPONENT(Session("ConnString"))
                        Dim job_nbr As Integer
                        Dim version_nbr, job_comp As Int16
                        Dim version_str, job_str As String
                        Dim job_version_desc As String
                        jl.LoadByPrimaryKey(CInt(Session("JobOrderFormJobNum")))
                        jc.LoadByPrimaryKey(CInt(Session("JobOrderFormJobCompNum")), CInt(Session("JobOrderFormJobNum")))

                        rpt = New ActiveReportsAssembly.arptJobVersions
                        rpt.CultureCode = CurrentCultureCode
                        ds = jv.getArptJobVersions(CInt(Session("JobOrderFormJobNum")), CInt(Session("JobOrderFormJobCompNum")))
                        rpt.dtData = ds.Tables(0)

                        rpt.AgencyDesc = jv.GetAgencyDesc()

                        job_nbr = CInt(Session("JobOrderFormJobNum"))
                        job_str = job_nbr.ToString.PadLeft(6, "0")
                        rpt.job = job_str & " - " & jl.JOB_DESC

                        job_comp = Session("JobOrderFormJobCompNum")
                        job_str = job_comp.ToString.PadLeft(3, "0")
                        rpt.jobcomp = job_str & " - " & jc.JOB_COMP_DESC

                        dr = js.GetJobSpecCDP(CInt(Session("JobOrderFormJobNum")))
                        dr.Read()
                        rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                        rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                        rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                        dr.Close()

                        rpt.Reporter = Session("UserCode")
                        rpt.ReportTitle = Session("JVReportTitle")

                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JobOrderFormLogoLocation")
                        rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                        rpt.LogoID = Session("JobOrderFormLogoLocationID")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                        rpt.omitEmptyFields = Session("OmitEmptyFieldsJV")

                        If Session("JobOrderFormLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "jobspecs"
                        Dim js As New Job_Specs(Session("ConnString"))
                        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                        Dim ds As DataSet
                        Dim dr As SqlClient.SqlDataReader
                        Dim jl As New JOB_LOG(Session("ConnString"))
                        Dim jc As New JOB_COMPONENT(Session("ConnString"))

                        jl.LoadByPrimaryKey(CInt(Session("JobOrderFormJobNum")))
                        jc.LoadByPrimaryKey(CInt(Session("JobOrderFormJobCompNum")), CInt(Session("JobOrderFormJobNum")))

                        rpt = New ActiveReportsAssembly.arptJobSpecAllVersions
                        rpt.CultureCode = CurrentCultureCode

                        ds = js.GetJobSpecsDSbyJobComp(CInt(Session("JobOrderFormJobNum")), CInt(Session("JobOrderFormJobCompNum")))
                        rpt.dtData = ds.Tables(0)

                        rpt.job = Session("JobOrderFormJobNum") & " - " & jl.JOB_DESC
                        rpt.jobcomp = Session("JobOrderFormJobCompNum") & " - " & jc.JOB_COMP_DESC

                        dr = js.GetJobSpecCDP(CInt(Session("JobOrderFormJobNum")))
                        Do While dr.Read
                            rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                            rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                            rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                        Loop
                        dr.Close()

                        rpt.Reporter = Session("UserCode")
                        rpt.title = Session("JSReportTitle")
                        rpt.Approved = Session("JSApproveOnly")

                        dr = js.GetJobSpecQtyVendorTabs(Session("JSType"))
                        If dr.HasRows = True Then
                            Do While dr.Read
                                If dr.GetInt16(2) = 1 Then
                                    rpt.vendortab = 1
                                    rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Session("JobOrderFormJobNum")), CInt(Session("JobOrderFormJobCompNum")), 1)
                                End If
                                If dr.GetInt16(2) = 2 Then
                                    rpt.vendortab = 2
                                    rpt.dtVendor = js.GetJobSpecsVendorData(CInt(Session("JobOrderFormJobNum")), CInt(Session("JobOrderFormJobCompNum")), 2)
                                End If
                            Loop
                        End If
                        dr.Close()

                        If Session("Page") = "jobjacket" Then
                            rpt.includeVS = Session("JSIncludeVS")
                            rpt.includeMS = Session("JSIncludeMS")
                            rpt.page = "jobjacket"
                        Else
                            rpt.includeVS = False
                            rpt.includeMS = False
                            rpt.page = "jobspecs"
                        End If

                        'strReportName = "Specification"
                        rpt.dtMediaSpecs = js.GetJobSpecsMediaSpecsData(CInt(Session("JobOrderFormJobNum")), CInt(Session("JobOrderFormJobCompNum")))

                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JobOrderFormLogoLocation")
                        rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                        rpt.LogoID = Session("JobOrderFormLogoLocationID")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                        rpt.omitEmptyFields = Session("OmitEmptyFieldsJS")

                        If Session("JobOrderFormLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "CreativeBrief"
                        Dim jv As New JobVersion(Session("ConnString"))
                        Dim js As New Job_Specs(Session("ConnString"))
                        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
                        Dim ds As DataSet
                        Dim dr As SqlClient.SqlDataReader
                        Dim jl As New JOB_LOG(Session("ConnString"))
                        Dim jc As New JOB_COMPONENT(Session("ConnString"))
                        Dim job_nbr As Integer
                        Dim job_comp As Int16
                        Dim job_str As String

                        If Session("pagetype") = "cb" Then
                            job_nbr = Session("CBReportJobNum")
                            job_comp = Session("CBReportJobCompNum")
                        Else
                            job_nbr = Session("JobOrderFormJobNum")
                            job_comp = Session("JobOrderFormJobCompNum")
                        End If

                        jl.LoadByPrimaryKey(job_nbr)
                        jc.LoadByPrimaryKey(CInt(job_comp), job_nbr)

                        rpt = New ActiveReportsAssembly.arptCreativeBrief
                        rpt.CultureCode = CurrentCultureCode

                        rpt.mConnectionString = Session("ConnString")
                        rpt.UserCode = Session("UserCode")
                        rpt.Description = "Creative Brief"

                        job_str = job_nbr.ToString.PadLeft(6, "0")
                        rpt.job = job_str
                        rpt.jobDesc = jl.JOB_DESC
                        rpt.jobNbr = job_nbr

                        job_str = job_comp.ToString.PadLeft(3, "0")
                        'rpt.jobcomp = job_str & " - " & jc.JOB_COMP_DESC
                        rpt.jobcomp = job_str
                        rpt.jobCompNbr = job_comp
                        rpt.compDesc = jc.JOB_COMP_DESC

                        dr = js.GetJobSpecCDP(job_nbr)
                        dr.Read()
                        rpt.client = dr.GetString(1) & " - " & dr.GetString(2)
                        rpt.division = dr.GetString(3) & " - " & dr.GetString(4)
                        rpt.product = dr.GetString(5) & " - " & dr.GetString(6)
                        rpt.cl_code = dr.GetString(1)
                        rpt.div_code = dr.GetString(3)
                        rpt.prd_code = dr.GetString(5)
                        dr.Close()

                        rpt.Reporter = Session("UserCode")
                        rpt.ReportTitle = Session("CBReportTitle")

                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("CBLogoLocation")
                        rpt.LogoPlacement = Session("CBLogoPlacement")
                        rpt.LogoID = Session("CBLogoLocationID")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("CBLogoLocationID"))
                        rpt.omitEmptyFields = Session("OmitEmptyFieldsCB")

                        If Session("CBLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("CBLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                    Case "Campaign"
                        rpt = New ActiveReportsAssembly.arptCampaign001
                        rpt.CultureCode = CurrentCultureCode

                        rpt.LogoPath = Session("CampaignLogoLocation")
                        rpt.LogoID = Session("CampaignLogoLocationID")
                        'rpt.LogoPlacement = Session("CBLogoPlacement")
                        rpt.imgPath = imgPath
                        rpt.dtData = oReports.GetCampaignSummarybyJobBudgetVariance(CType(ID, Integer), "", "", "", "")
                        rpt.dtLocation = oReports.GetAgencyInfoJobTemplate(Session("CampaignLogoLocationID"))

                    Case "Estimating", "EstimatingMars", "EstimatingInfinity", "EstimatingBWD", "EstimatingBWD2", "EstimatingTPN", "Estimating315"
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim cr As New cReports(Session("ConnString"))
                        Dim otask As cTasks = New cTasks(Session("ConnString"))
                        Dim dtEst As DataTable
                        Dim dtComments As DataTable
                        Dim dtCompComments As DataTable
                        Dim dtPD As DataTable
                        Dim foption As String
                        Dim goption As String
                        Dim cEmp As New cEmployee(Session("ConnString"))
                        Dim ds As DataSet

                        If strReport = "Estimating" Then
                            rpt = New ActiveReportsAssembly.arptEstimating
                        End If
                        If strReport = "EstimatingMars" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingMars
                        End If
                        If strReport = "EstimatingInfinity" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingInfinity
                        End If
                        If strReport = "EstimatingBWD" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingBWD1
                            rpt.LocationCode = Session("EstimatingLogoLocationID")
                            rpt.LocationName = Session("EstimatingLogoLocationName")
                        End If
                        If strReport = "EstimatingBWD2" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingBWD2
                            rpt.LocationCode = Session("EstimatingLogoLocationID")
                            rpt.LocationName = Session("EstimatingLogoLocationName")
                        End If
                        If strReport = "EstimatingTPN" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingTPN
                        End If
                        If strReport = "Estimating315" Then
                            rpt = New ActiveReportsAssembly.arptEstimating315
                        End If
                        rpt.CultureCode = CurrentCultureCode
                        rpt.logopath = Session("EstimatingLogoLocation")
                        rpt.LogoID = Session("EstimatingLogoLocationID")
                        rpt.imgPath = imgPath
                        rpt.printedDate = Session("EstimatingPrintedDate")
                        rpt.defFooter = Session("EstimatingDefFooter")
                        rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                        rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                        rpt.addressOption = Session("EstimatingAddressOption")
                        rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Session("EstimatingAddressOption"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                        rpt.agencyname = cr.GetAgencyName()
                        If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                            rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                        End If
                        'Try
                        '    rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        'Catch ex As Exception
                        'End Try
                        rpt.signature = Session("EstimatingSignature")
                        rpt.agencyname = cr.GetAgencyName()


                        Try
                            Dim sig As String = Session("EstimatingUseEmpSig")
                            If sig = "0" Then
                                rpt.UseEmpSig = True
                                rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                            Else
                                rpt.UseEmpSig = False
                            End If

                        Catch ex As Exception
                        End Try

                        If Session("EstimatingLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                        'If Session("EstimatingCombine") = "1" Then
                        '    rpt.combined = True
                        '    rpt.dt = est.getPrintDetailsCombined(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"))
                        'Else
                        '    rpt.dt = est.getPrintDetails(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                        'End If
                        If Session("EstimatingCombine") = "1" Then
                            rpt.combined = True
                            If strReport = "EstimatingBWD" Or strReport = "EstimatingBWD2" Then
                                dtEst = est.getPrintDetailsCombinedBWD(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), 1)
                            Else
                                dtEst = est.getPrintDetailsCombined(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), "cb")
                                If strReport = "EstimatingTPN" Then
                                    ds = est.getPrintDetailsDS(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                    If ds.Tables.Count > 0 Then
                                        rpt.dtlabels = ds.Tables(1)
                                    End If
                                End If
                            End If
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                    dtCompComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), "", Session("UserCode"))
                                    If dtCompComments.Rows.Count > 0 Then
                                        Dim compcomments As String = ""
                                        Dim cc As String = ""
                                        For y As Integer = 0 To dtCompComments.Rows.Count - 1
                                            If dtCompComments.Rows(y)("EST_COMP_COMMENT") <> "" And dtCompComments.Rows(y)("EST_COMP_COMMENT").ToString.Trim <> cc.Trim Then
                                                compcomments &= dtCompComments.Rows(y)("EST_COMP_COMMENT") & vbCrLf
                                                cc = dtCompComments.Rows(y)("EST_COMP_COMMENT")
                                            End If
                                        Next
                                        dtEst.Rows(x)("EST_COMP_COMMENT") = compcomments
                                    End If
                                    If dtComments.Rows.Count > 0 Then
                                        Dim compcomments As String = ""
                                        Dim qtecomments As String = ""
                                        Dim comments As String = ""
                                        Dim supcomments As String = ""
                                        For y As Integer = 0 To dtComments.Rows.Count - 1
                                            If dtComments.Rows(y)("EST_COMP_COMMENT") <> "" Then
                                                compcomments &= dtComments.Rows(y)("EST_COMP_COMMENT") & vbCrLf
                                            End If
                                            If dtComments.Rows(y)("EST_QTE_COMMENT") <> "" Then
                                                qtecomments &= dtComments.Rows(y)("EST_QTE_COMMENT") & vbCrLf
                                            End If
                                            If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                            End If
                                            If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                            End If
                                        Next
                                        dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                        dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                        dtEst.Rows(x)("EST_COMP_COMMENT") = compcomments
                                        dtEst.Rows(x)("EST_QTE_COMMENT") = qtecomments
                                        'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                    End If
                                Next
                            End If
                            rpt.dt = dtEst
                        Else
                            dtPD = est.GetPrintDefDT(Session("UserCode"))
                            If dtPD.Rows.Count > 0 Then
                                goption = dtPD.Rows(0)("GROUP_OPTION")
                            End If
                            If strReport = "Estimating" Or strReport = "Estimating315" Then
                                If goption = "HT" Then
                                    dtEst = est.getPrintDetailsFH(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                Else
                                    dtEst = est.getPrintDetails(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                End If
                            End If
                            If strReport = "EstimatingTPN" Then
                                If goption = "HT" Then
                                    dtEst = est.getPrintDetailsFH(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                Else
                                    dtEst = est.getPrintDetails(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                    ds = est.getPrintDetailsDS(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                                    If ds.Tables.Count > 0 Then
                                        rpt.dtlabels = ds.Tables(1)
                                    End If
                                End If
                            End If
                            If strReport = "EstimatingMars" Then
                                dtEst = est.getPrintDetailsCombined(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), "jc")
                            End If
                            If strReport = "EstimatingInfinity" Then
                                dtEst = est.getPrintDetails(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                            End If
                            If strReport = "EstimatingBWD" Or strReport = "EstimatingBWD2" Then
                                dtEst = est.getPrintDetailsBWD(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), 0)
                            End If
                            If dtPD.Rows.Count > 0 Then
                                foption = dtPD.Rows(0)("FUNCTION_OPTION")
                            End If
                            If foption <> "N" Then
                                If dtEst.Rows.Count > 0 Then
                                    For x As Integer = 0 To dtEst.Rows.Count - 1
                                        If goption = "HT" Then
                                            Dim commentsfnc As String = ""
                                            dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                            If dtComments.Rows.Count > 0 Then
                                                For y As Integer = 0 To dtComments.Rows.Count - 1
                                                    If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                        commentsfnc &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                    End If
                                                Next
                                                dtEst.Rows(x)("EST_FNC_COMMENT") = commentsfnc
                                                dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                            End If
                                        Else
                                            dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), IIf(IsDBNull(dtEst.Rows(x)("EST_REV_RATE")), 0, dtEst.Rows(x)("EST_REV_RATE")), Session("UserCode"))
                                            If dtComments.Rows.Count > 0 Then
                                                Dim comments As String = ""
                                                Dim supcomments As String = ""
                                                For y As Integer = 0 To dtComments.Rows.Count - 1
                                                    If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                        comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                    End If
                                                    If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                        supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                                    End If
                                                Next
                                                dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                                dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                                dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")


                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            rpt.dt = dtEst
                        End If
                    Case "Estimating002", "Estimating314" '- Quote Side By Side
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim cr As New cReports(Session("ConnString"))
                        Dim dtEst As DataTable
                        Dim dtComments As DataTable
                        Dim dtPD As DataTable
                        Dim foption As String
                        Dim max As Integer
                        Dim cEmp As New cEmployee(Session("ConnString"))
                        Dim otask As cTasks = New cTasks(Session("ConnString"))
                        If strReport = "Estimating002" Then
                            rpt = New ActiveReportsAssembly.arptEstimating002
                        End If
                        If strReport = "Estimating314" Then
                            rpt = New ActiveReportsAssembly.arptEstimating314
                        End If
                        rpt.CultureCode = CurrentCultureCode
                        rpt.logopath = Session("EstimatingLogoLocation")
                        rpt.LogoID = Session("EstimatingLogoLocationID")
                        rpt.imgPath = imgPath
                        rpt.printedDate = Session("EstimatingPrintedDate")
                        rpt.defFooter = Session("EstimatingDefFooter")
                        rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                        rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                        rpt.addressOption = Session("EstimatingAddressOption")
                        rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Session("EstimatingAddressOption"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                        rpt.quotes = Session("EstimatingQuotes")
                        rpt.agencyname = cr.GetAgencyName()
                        If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                            rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                        End If

                        Try
                            Dim sig As String = Session("EstimatingUseEmpSig")
                            If sig = "0" Then
                                rpt.UseEmpSig = True
                                rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                            Else
                                rpt.UseEmpSig = False
                            End If

                        Catch ex As Exception
                        End Try

                        If Session("EstimatingLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                        If Session("EstimatingCombine") = "1" Then
                            rpt.quotedescs = Session("EstimatingQteDescs")
                            rpt.combined = True
                            rpt.comps = Session("EstimatingComps")
                            dtEst = est.getPrintDetails002Combined(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), 0)
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), 0, dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                    If dtComments.Rows.Count > 0 Then
                                        Dim compcomments As String = ""
                                        Dim cps As String = Session("EstimatingComps")
                                        For y As Integer = 0 To dtComments.Rows.Count - 1
                                            If dtComments.Rows(y)("EST_COMP_COMMENT") <> "" And cps.Contains(dtComments.Rows(y)("EST_COMPONENT_NBR").ToString()) = True Then
                                                compcomments &= dtComments.Rows(y)("EST_COMP_COMMENT") & vbCrLf
                                            End If
                                        Next
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                        dtEst.Rows(x)("EST_COMP_COMMENT") = compcomments
                                    End If
                                Next
                            End If
                            rpt.dt = dtEst
                        Else
                            rpt.quotedescs = Session("EstimatingQteDescs" & Session("EstimatingEstComp"))
                            dtPD = est.GetPrintDefDT(Session("UserCode"))
                            dtEst = est.getPrintDetails002(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), 0)
                            If dtPD.Rows.Count > 0 Then
                                foption = dtPD.Rows(0)("FUNCTION_OPTION")
                            End If
                            If foption <> "N" Then
                                If dtEst.Rows.Count > 0 Then
                                    For x As Integer = 0 To dtEst.Rows.Count - 1
                                        Dim comments As String = ""
                                        dtComments = est.GetEstimateData(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 0, 0, Session("UserCode"))
                                        If dtComments.Rows.Count > 0 Then
                                            dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                            dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                        End If
                                        If strReport = "Estimating314" Then
                                            max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 1)
                                            dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), 1, max, dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                            If dtComments.Rows.Count > 0 Then
                                                For y As Integer = 0 To dtComments.Rows.Count - 1
                                                    If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                        comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                    End If
                                                Next
                                                dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            rpt.dt = dtEst
                        End If

                    Case "Estimating003", "Estimating004", "Estimating005", "Estimating006", "Estimating007", "Estimating304", "Estimating305", "EstimatingTPN2", "Estimating313" '- Revision Comparison, Estimating004 - Revision Comparison w/Variance, Estimating005 - Revision Comparison w/Variance, Estimating006 - Revision Comparison No Actual, Estimating007 - Revision Comparison Prev/Last Rev
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim cr As New cReports(Session("ConnString"))
                        Dim otask As cTasks = New cTasks(Session("ConnString"))
                        Dim dtEst As DataTable
                        Dim dtComments As DataTable
                        Dim dtPD As DataTable
                        Dim ds As DataSet
                        Dim foption As String
                        Dim max As Integer
                        Dim type As Integer = 0
                        Dim cEmp As New cEmployee(Session("ConnString"))

                        If strReport = "Estimating003" Then
                            rpt = New ActiveReportsAssembly.arptEstimating003
                        End If
                        If strReport = "Estimating004" Then
                            rpt = New ActiveReportsAssembly.arptEstimating004
                        End If
                        If strReport = "Estimating005" Or strReport = "Estimating304" Then
                            rpt = New ActiveReportsAssembly.arptEstimating005
                        End If
                        If strReport = "Estimating006" Or strReport = "Estimating305" Then
                            rpt = New ActiveReportsAssembly.arptEstimating006
                        End If
                        If strReport = "Estimating007" Then
                            rpt = New ActiveReportsAssembly.arptEstimating007
                            type = 7
                        End If
                        If strReport = "EstimatingTPN2" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingTPN2
                            type = 6
                        End If
                        If strReport = "Estimating313" Then
                            rpt = New ActiveReportsAssembly.arptEstimating313
                            type = 7
                        End If
                        rpt.CultureCode = CurrentCultureCode
                        rpt.logopath = Session("EstimatingLogoLocation")
                        rpt.LogoID = Session("EstimatingLogoLocationID")
                        rpt.imgPath = imgPath
                        rpt.printedDate = Session("EstimatingPrintedDate")
                        rpt.defFooter = Session("EstimatingDefFooter")
                        rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                        rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                        rpt.addressOption = Session("EstimatingAddressOption")
                        rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Session("EstimatingAddressOption"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                        rpt.agencyname = cr.GetAgencyName()
                        If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                            rpt.PrintClientName = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
                        End If
                        'Try
                        '    rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        'Catch ex As Exception
                        'End Try

                        Try
                            Dim sig As String = Session("EstimatingUseEmpSig")
                            If sig = "0" Then
                                rpt.UseEmpSig = True
                                rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                            Else
                                rpt.UseEmpSig = False
                            End If

                            If Session("EstimatingLogoLocationID") <> "" Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                    rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                                End Using
                            End If

                        Catch ex As Exception
                        End Try
                        If Session("EstimatingCombine") = "1" Then
                            rpt.combined = True
                            dtEst = est.getPrintDetails003Combined(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), type)
                            If strReport = "EstimatingTPN2" Then
                                ds = est.getPrintDetails003DS(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), type)
                                If ds.Tables.Count > 0 Then
                                    rpt.dtlabels = ds.Tables(1)
                                End If
                            End If
                            If dtEst.Rows.Count > 0 Then
                                For x As Integer = 0 To dtEst.Rows.Count - 1
                                    'max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"))
                                    dtComments = est.getCommentsCombined(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("FNC_CODE"), Session("UserCode"))
                                    'dtEst.Rows(x)("MAX_REVISION") = max
                                    If dtComments.Rows.Count > 0 Then
                                        Dim comments As String = ""
                                        Dim supcomments As String = ""
                                        For y As Integer = 0 To dtComments.Rows.Count - 1
                                            If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                            End If
                                            If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                            End If
                                        Next
                                        dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                        dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                        dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                        'dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                        'dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                        'dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                    End If
                                Next
                            End If
                            rpt.dt = dtEst
                        Else
                            dtPD = est.GetPrintDefDT(Session("UserCode"))
                            dtEst = est.getPrintDetails003(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), type)
                            If strReport = "EstimatingTPN2" Then
                                ds = est.getPrintDetails003DS(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), type)
                                If ds.Tables.Count > 0 Then
                                    rpt.dtlabels = ds.Tables(1)
                                End If
                            End If
                            If dtPD.Rows.Count > 0 Then
                                foption = dtPD.Rows(0)("FUNCTION_OPTION")
                            End If
                            If foption <> "N" Then
                                If dtEst.Rows.Count > 0 Then
                                    For x As Integer = 0 To dtEst.Rows.Count - 1
                                        max = est.GetEstimateQuoteMaxRevision(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"))
                                        dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), max, dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                        dtEst.Rows(x)("MAX_REVISION") = max
                                        If dtComments.Rows.Count > 0 Then
                                            Dim comments As String = ""
                                            Dim supcomments As String = ""
                                            For y As Integer = 0 To dtComments.Rows.Count - 1
                                                If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                    comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                End If
                                                If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                    supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                                End If
                                            Next
                                            dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                            dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                            dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                            dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                            dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                            dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                        End If
                                    Next
                                End If
                            End If
                            rpt.dt = dtEst
                        End If
                    Case "EstimatingSS1", "EstimatingSS2", "Estimating008", "Estimating009", "EstimatingQUR", "EstimatingTAP", "EstimatingTAP2" '- Estimating Custom Saatchi
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim cr As New cReports(Session("ConnString"))
                        Dim cc As New cCampaign(Session("ConnString"))
                        Dim dtEst As DataTable
                        Dim dsEst As DataSet
                        Dim dtComments As DataTable
                        Dim dtCompComments As DataTable
                        Dim dtPD As DataTable
                        Dim drCmp As SqlDataReader
                        Dim foption As String
                        Dim goption As String
                        Dim cEmp As New cEmployee(Session("ConnString"))
                        If strReport = "EstimatingSS1" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingSS1
                        End If
                        If strReport = "EstimatingSS2" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingSS2
                        End If
                        If strReport = "EstimatingQUR" Then
                            rpt = New ActiveReportsAssembly.arptEstimatingQuarry
                        End If
                        If strReport = "Estimating008" Or strReport = "Estimating009" Or strReport = "EstimatingTAP" Or strReport = "EstimatingTAP2" Then
                            If strReport = "EstimatingTAP" Or strReport = "EstimatingTAP2" Then
                                rpt = New ActiveReportsAssembly.arptEstimatingTap
                                rpt.FunctionComment = Session("EstimatingFncComment")
                            Else
                                rpt = New ActiveReportsAssembly.arptEstimating008
                            End If
                            rpt.rpttype = strReport
                            rpt.addressInfo = cr.GetCDPAddressInfoEstimate(Session("EstimatingAddressOption"), "", "", "")
                            'rpt.addressInfo = cr.GetCDPAddressInfo(Session("EstimatingAddressOption"), Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        Else
                            rpt.addressInfo = cr.GetCDPAddressInfoEstimate("Client", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        End If
                        rpt.CultureCode = CurrentCultureCode
                        rpt.logopath = Session("EstimatingLogoLocation")
                        rpt.LogoID = Session("EstimatingLogoLocationID")
                        rpt.imgPath = imgPath
                        rpt.printedDate = Session("EstimatingPrintedDate")
                        rpt.defFooter = Session("EstimatingDefFooter")
                        rpt.DefaultFooterFontSize = Session("EstimatingDefaultFooterFontSize")
                        rpt.dtPrintDef = est.GetPrintDefDT(Session("UserCode"))
                        rpt.addressOption = Session("EstimatingAddressOption")
                        'rpt.addressInfo = cr.GetCDPAddressInfo("Client", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        rpt.addressInfoProd = cr.GetCDPAddressInfoEstimate("Product", Session("EstimatingClientPrint"), Session("EstimatingDivisionPrint"), Session("EstimatingProductPrint"))
                        rpt.dtLocation = cr.GetAgencyInfoJobTemplate(Session("EstimatingLogoLocationID"))
                        rpt.signature = Session("EstimatingSignature")
                        rpt.connstring = Session("ConnString")
                        rpt.dtJobVersion = est.getPrintDetailsJVS(Session("EstimatingJobPrint"), Session("EstimatingCompPrint"))
                        rpt.agencyname = cr.GetAgencyName()
                        'Try
                        '    rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                        'Catch ex As Exception
                        'End Try
                        Try
                            Dim sig As String = Session("EstimatingUseEmpSig")
                            If sig = "0" Then
                                rpt.UseEmpSig = True
                                rpt.SigImage = cEmp.getEmpSignatureImage(Session("EmpCode"))
                            Else
                                rpt.UseEmpSig = False
                            End If

                        Catch ex As Exception
                        End Try

                        If Session("EstimatingLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("EstimatingLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If

                        If Session("EstimatingCombine") = "1" Then

                        Else
                            dtPD = est.GetPrintDefDT(Session("UserCode"))
                            If dtPD.Rows.Count > 0 Then
                                goption = dtPD.Rows(0)("GROUP_OPTION")
                            End If
                            If strReport = "EstimatingSS1" Then
                                dtEst = est.getPrintDetailsSS1(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"))
                                rpt.dtTotals = est.getPrintDetailsTotals(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"))
                            End If
                            If strReport = "EstimatingSS2" Then
                                dtEst = est.getPrintDetailsSS2(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"))
                            End If
                            If strReport = "Estimating008" Or strReport = "Estimating009" Or strReport = "EstimatingQUR" Or strReport = "EstimatingTAP" Or strReport = "EstimatingTAP2" Then
                                If strReport = "EstimatingTAP" Or strReport = "EstimatingTAP2" Then
                                    dsEst = est.getPrintDetailsTap(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), Session("EstimatingReport"))
                                    dtEst = dsEst.Tables(0)
                                Else
                                    dtEst = est.getPrintDetailsQuarry(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"))
                                End If
                                rpt.dtTotals = est.getPrintDetailsTotalsQuarry(Session("EstimatingEstNum"), Session("EstimatingEstComp"), Session("UserCode"), Session("EstimatingQuotes"), Session("EstimatingComps"), Session("EstimatingReport"))
                            End If
                            If dtPD.Rows.Count > 0 Then
                                foption = dtPD.Rows(0)("FUNCTION_OPTION")
                            End If
                            If foption <> "N" Then
                                If dtEst.Rows.Count > 0 Then
                                    For x As Integer = 0 To dtEst.Rows.Count - 1
                                        If strReport = "Estimating008" Or strReport = "Estimating009" Or strReport = "EstimatingQUR" Then
                                            drCmp = cc.GetCampaignByCmpIdentifier(dtEst.Rows(x)("CMP_ID"))
                                            dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                            If dtComments.Rows.Count > 0 Then
                                                dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                            End If
                                            If drCmp.HasRows = True Then
                                                drCmp.Read()
                                                dtEst.Rows(x)("CMP_COMMENTS") = drCmp("CMP_COMMENTS")
                                                drCmp.Close()
                                            End If
                                        ElseIf strReport = "EstimatingTAP" Or strReport = "EstimatingTAP2" Then
                                            drCmp = cc.GetCampaignByCmpIdentifier(dtEst.Rows(x)("CMP_ID"))
                                            If drCmp.HasRows = True Then
                                                drCmp.Read()
                                                dtEst.Rows(x)("CMP_COMMENTS") = drCmp("CMP_COMMENTS")
                                                drCmp.Close()
                                            End If
                                            If dtEst.Rows(x)("ESTIMATE_NUMBER") <> 0 Then
                                                dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), 0, Session("UserCode"))
                                                If dtComments.Rows.Count > 0 Then
                                                    Dim comments As String = ""
                                                    Dim supcomments As String = ""
                                                    For y As Integer = 0 To dtComments.Rows.Count - 1
                                                        If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                            comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                        End If
                                                    Next
                                                    dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                                End If
                                            End If
                                        Else
                                            If goption = "HT" Then
                                                dtComments = est.getCommentsFH(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_HEADING_ID"))
                                                If dtComments.Rows.Count > 0 Then
                                                    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                    dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                    dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                    dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                                End If
                                            Else
                                                dtComments = est.getComments(dtEst.Rows(x)("ESTIMATE_NUMBER"), dtEst.Rows(x)("EST_COMPONENT_NBR"), dtEst.Rows(x)("EST_QUOTE_NBR"), dtEst.Rows(x)("EST_REV_NBR"), dtEst.Rows(x)("FNC_CODE"), dtEst.Rows(x)("EST_REV_RATE"), Session("UserCode"))
                                                If dtComments.Rows.Count > 0 Then
                                                    Dim comments As String = ""
                                                    Dim supcomments As String = ""
                                                    For y As Integer = 0 To dtComments.Rows.Count - 1
                                                        If dtComments.Rows(y)("EST_FNC_COMMENT") <> "" Then
                                                            comments &= dtComments.Rows(y)("EST_FNC_COMMENT") & vbCrLf
                                                        End If
                                                        If dtComments.Rows(y)("EST_REV_SUP_BY_NTE") <> "" Then
                                                            supcomments &= dtComments.Rows(y)("EST_REV_SUP_BY_NTE") & vbCrLf
                                                        End If
                                                    Next
                                                    dtEst.Rows(x)("EST_FNC_COMMENT") = comments
                                                    dtEst.Rows(x)("EST_REV_SUP_BY_NTE") = supcomments
                                                    dtEst.Rows(x)("EST_LOG_COMMENT") = dtComments.Rows(0)("EST_LOG_COMMENT")
                                                    dtEst.Rows(x)("EST_COMP_COMMENT") = dtComments.Rows(0)("EST_COMP_COMMENT")
                                                    dtEst.Rows(x)("EST_QTE_COMMENT") = dtComments.Rows(0)("EST_QTE_COMMENT")
                                                    dtEst.Rows(x)("EST_REV_COMMENT") = dtComments.Rows(0)("EST_REV_COMMENT")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            rpt.dt = dtEst
                        End If
                    Case "VendorQteRequest"
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim cr As New cReports(Session("ConnString"))
                        rpt = New ActiveReportsAssembly.arptVendorQuoteRequest
                        rpt.CultureCode = CurrentCultureCode
                        Dim otask As cTasks = New cTasks(Session("ConnString"))
                        Dim taskVar As String
                        Dim ar() As String
                        taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "Location")
                        If taskVar <> "" Then
                            ar = taskVar.Split("|")
                            rpt.logopath = ar(1)
                            rpt.LogoID = ar(0)
                            rpt.dtLocation = cr.GetAgencyInfoJobTemplate(ar(0))
                        End If

                        taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "PrintDate")
                        If taskVar <> "" Then
                            rpt.printDate = taskVar
                        End If

                        rpt.imgPath = imgPath
                        rpt.dt = est.GetRequestPrint(Session("VendorReqEstNum"), Session("VendorReqEstComp"), Session("VendorReqVenQte"), Session("UserCode"), Session("VendorReqVenCode"), Session("VendorsRFQVendors"))
                        Session("VendorsRFQVendors") = ""
                    Case "joborder2", "joborder3"
                        Dim ds As DataSet
                        Dim ds2 As DataSet
                        Dim ds3 As DataSet
                        Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
                        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        Dim oJob As Job = New Job(Session("ConnString"))

                        oJob.GetJob(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt = New ActiveReportsAssembly.arptJobTemplate002
                        rpt.CultureCode = CurrentCultureCode
                        If strReport = "joborder2" Then
                            rpt.rptType = "002"
                        End If
                        If strReport = "joborder3" Then
                            rpt.rptType = "003"
                        End If
                        rpt.mConnectionString = Session("ConnString")
                        rpt.UserCode = Session("UserCode")
                        rpt.JobNum = Session("JobOrderFormJobNum")
                        rpt.JobCompNum = Session("JobOrderFormJobCompNum")
                        rpt.printJobOrderForm = Session("IncludeJOFReport")
                        rpt.omitEmptyFields = Session("OmitEFReport")
                        rpt.includeTA = Session("IncludeTAReport")
                        rpt.sectionTitleTA = Session("TASectionTitle")
                        rpt.includeTS = Session("IncludeTSReport")
                        rpt.scheduleCommentTS = Session("TSScheduleComments")
                        rpt.sectionTitleTS = Session("TSSectionTitle")
                        rpt.dueDatesOnlyTS = Session("TSDueDatesOnly")
                        rpt.milestonesOnlyTS = Session("TSMilestonesOnly")
                        rpt.milestoneTitle = Session("TSMilestoneTitle")
                        rpt.employeeAssignmentsTS = Session("TSEmpAssignments")
                        rpt.ReportTitle = Session("JobOrderFormReportTitle")
                        rpt.imgPath = imgPath
                        rpt.LogoPath = Session("JobOrderFormLogoLocation")
                        rpt.LogoPlacement = Session("JobOrderFormLogoPlacement")
                        rpt.LogoID = Session("JobOrderFormLogoLocationID")
                        rpt.Reporter = Session("UserCode")
                        rpt.dtSchedule = oReports.GetJobTrafficSchedule(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"), "ama")
                        rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(Session("JobOrderFormLogoLocationID"))
                        ds2 = MyJobTemplate.GetJobTemplateComments(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt.dtComments = ds2.Tables(0)
                        ds = MyJobTemplate.GetJobTemplateDetails(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt.MyDT = ds.Tables(0)
                        If Session("JobOrderPrintDate") <> "" Then
                            rpt.JobDate = Session("JobOrderPrintDate")
                        Else
                            rpt.JobDate = oJob.JOB_DATE_OPENED.ToShortDateString
                        End If
                        rpt.Client = oJob.ClientDesc
                        rpt.AE = oJob.JobComponent.AccountExecutiveDesc
                        rpt.desc = oJob.JobComponent.JOB_COMP_DESC
                        rpt.dsBudget = MyJobTemplate.GetBudget(Session("JobOrderFormJobNum"), Session("JobOrderFormJobCompNum"))
                        rpt.signature = Session("JobOrderFormSignatureFormat")

                        If Session("JobOrderFormLogoLocationID") <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Session("JobOrderFormLogoLocationID"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                            End Using
                        End If
                End Select
            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try

            Try
                rpt.imgPath = imgPath
            Catch ex As Exception
            End Try

            Try
                rpt.Run(False)
            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try

            Try
                Select Case exportType
                    Case 1
                        Dim pdf As New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                        If strFileName.ToLower().IndexOf(".pdf") = -1 Then
                            strFileName = strFileName & ".pdf"
                        End If
                        pdf.Export(rpt.Document, strFileName)
                    Case 2
                        Dim xls As New DataDynamics.ActiveReports.Export.Xls.XlsExport
                        If strFileName.ToLower().IndexOf(".xls") = -1 Then
                            strFileName = strFileName & ".xls"
                        End If
                        xls.Export(rpt.Document, strFileName)
                    Case 4
                        Dim txt As New DataDynamics.ActiveReports.Export.Text.TextExport
                        If strFileName.ToLower().IndexOf(".txt") = -1 Then
                            strFileName = strFileName & ".txt"
                        End If
                        txt.Export(rpt.Document, strFileName)
                    Case 5
                        Dim rtf As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                        If strFileName.ToLower().IndexOf(".rtf") = -1 Then
                            strFileName = strFileName & ".rtf"
                        End If
                        rtf.Export(rpt.Document, strFileName)
                    Case 6
                        Dim tiff As New DataDynamics.ActiveReports.Export.Tiff.TiffExport
                        If strFileName.ToLower().IndexOf(".tiff") = -1 Then
                            strFileName = strFileName & ".tiff"
                        End If
                        tiff.Export(rpt.Document, strFileName)
                    Case Else
                        Dim pdf As New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                        If strFileName.ToLower().IndexOf(".pdf") = -1 Then
                            strFileName = strFileName & ".pdf"
                        End If
                        pdf.Export(rpt.Document, strFileName)
                End Select
            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try

            Try
                rpt = Nothing
                oReports = Nothing
            Catch ex As Exception
            End Try

            ErrorMessage = ""
            Return True

        Catch ex As Exception
            'HttpContext.Current.Response.Write("renderpdf: " & ex.Message.ToString())
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try

    End Function
    Public Function AddToDocumentRepository(ByVal FileName As String, ByVal ReportFormat As String, ByVal ID As String, ByVal PP As String, ByVal Loc As String, ByVal AD As String, ByVal Footer As String, ByVal ExportType As Integer, ByVal ImagePath As String, Optional ByVal Options As String = "", Optional ByVal OfficeCodes As String = "", Optional ByRef ErrorMessage As String = "", Optional ByVal AgingDateType As Integer = 1) As Integer

        'objects
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocumentID As Integer

        Try

            If renderDoc(FileName, ReportFormat, ID, PP, Loc, AD, Footer, 1, ImagePath, Options, OfficeCodes, ErrorMessage, AgingDateType) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    MemoryStream = New System.IO.MemoryStream(System.IO.File.ReadAllBytes(FileName))

                    If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                        If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, System.IO.Path.GetFileName(FileName), Nothing, Nothing, Session("UserCode"), Nothing, Nothing,
                                                             AdvantageFramework.FileSystem.Methods.DocumentSource.Alert, Nothing, Nothing, True, DocumentID) = False Then

                            DocumentID = Nothing

                        End If

                    End If

                    MemoryStream.Dispose()
                    MemoryStream.Close()

                End Using

            End If

        Catch ex As Exception
            DocumentID = Nothing
        Finally
            AddToDocumentRepository = DocumentID
        End Try

    End Function

    Private Sub SetSessionDefaults()
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

        oAppVars.getAllAppVars()

        'If Session("tcal_len") Is Nothing Then
        '    Session("tcal_len") = "50"
        'End If
        If oAppVars.HasAppVar("tcal_len") = False Then
            oAppVars.setAppVar("tcal_len", "50", "Number")
        End If

        'If Session("tcal_tclientcode") Is Nothing Then
        '    Session("tcal_tclientcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tclientcode") = False Then
            oAppVars.setAppVar("tcal_tclientcode", "True", "Boolean")
        End If
        'If Session("tcal_tclientdesc") Is Nothing Then
        '    Session("tcal_tclientdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tclientdesc") = False Then
            oAppVars.setAppVar("tcal_tclientdesc", "False", "Boolean")
        End If
        'If Session("tcal_tdivcode") Is Nothing Then
        '    Session("tcal_tdivcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tdivcode") = False Then
            oAppVars.setAppVar("tcal_tdivcode", "True", "Boolean")
        End If
        'If Session("tcal_tdivdesc") Is Nothing Then
        '    Session("tcal_tdivdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tdivdesc") = False Then
            oAppVars.setAppVar("tcal_tdivdesc", "False", "Boolean")
        End If
        'If Session("tcal_tprodcode") Is Nothing Then
        '    Session("tcal_tprodcode") = True
        'End If
        If oAppVars.HasAppVar("tcal_tprodcode") = False Then
            oAppVars.setAppVar("tcal_tprodcode", "True", "Boolean")
        End If
        'If Session("tcal_tproddesc") Is Nothing Then
        '    Session("tcal_tproddesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tproddesc") = False Then
            oAppVars.setAppVar("tcal_tproddesc", "False", "Boolean")
        End If

        'If Session("tcal_tjobnum") Is Nothing Then
        '    Session("tcal_tjobnum") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobnum") = False Then
            oAppVars.setAppVar("tcal_tjobnum", "False", "Boolean")
        End If
        'If Session("tcal_tjobdesc") Is Nothing Then
        '    Session("tcal_tjobdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobdesc") = False Then
            oAppVars.setAppVar("tcal_tjobdesc", "False", "Boolean")
        End If
        'If Session("tcal_tjobcompnum") Is Nothing Then
        '    Session("tcal_tjobcompnum") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobcompnum") = False Then
            oAppVars.setAppVar("tcal_tjobcompnum", "False", "Boolean")
        End If
        'If Session("tcal_tjobcompdesc") Is Nothing Then
        '    Session("tcal_tjobcompdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_tjobcompdesc") = False Then
            oAppVars.setAppVar("tcal_tjobcompdesc", "False", "Boolean")
        End If
        'If Session("tcal_ttaskcode") Is Nothing Then
        '    Session("tcal_ttaskcode") = False
        'End If
        If oAppVars.HasAppVar("tcal_ttaskcode") = False Then
            oAppVars.setAppVar("tcal_ttaskcode", "False", "Boolean")
        End If
        'If Session("tcal_ttaskdesc") Is Nothing Then
        '    Session("tcal_ttaskdesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_ttaskdesc") = False Then
            oAppVars.setAppVar("tcal_ttaskdesc", "False", "Boolean")
        End If
        'If Session("tcal_haemployeecode") Is Nothing Then
        '    Session("tcal_haemployeecode") = False
        'End If
        If oAppVars.HasAppVar("tcal_haemployeecode") = False Then
            oAppVars.setAppVar("tcal_haemployeecode", "False", "Boolean")
        End If
        'If Session("tcal_haemployeedesc") Is Nothing Then
        '    Session("tcal_haemployeedesc") = False
        'End If
        If oAppVars.HasAppVar("tcal_haemployeedesc") = False Then
            oAppVars.setAppVar("tcal_haemployeedesc", "False", "Boolean")
        End If
        'If Session("tcal_hasubject") Is Nothing Then
        '    Session("tcal_hasubject") = False
        'End If
        If oAppVars.HasAppVar("tcal_hasubject") = False Then
            oAppVars.setAppVar("tcal_hasubject", "False", "Boolean")
        End If
        'If Session("tcal_hatimes") Is Nothing Then
        '    Session("tcal_hatimes") = False
        'End If
        If oAppVars.HasAppVar("tcal_hatimes") = False Then
            oAppVars.setAppVar("tcal_hatimes", "False", "Boolean")
        End If
        'If Session("tcal_hahours") Is Nothing Then
        '    Session("tcal_hahours") = False
        'End If
        If oAppVars.HasAppVar("tcal_hahours") = False Then
            oAppVars.setAppVar("tcal_hahours", "False", "Boolean")
        End If
        'If Session("tcal_hatimecat") Is Nothing Then
        '    Session("tcal_hatimecat") = False
        'End If
        If oAppVars.HasAppVar("tcal_hatimecat") = False Then
            oAppVars.setAppVar("tcal_hatimecat", "False", "Boolean")
        End If
        'If Session("tcal_milestone") Is Nothing Then
        '    Session("tcal_milestone") = False
        'End If
        If oAppVars.HasAppVar("tcal_milestone") = False Then
            oAppVars.setAppVar("tcal_milestone", "False", "Boolean")
        End If
        'If Session("tcal_empcodedispl") Is Nothing Then
        '    Session("tcal_empcodedispl") = False
        'End If
        If oAppVars.HasAppVar("tcal_empcodedispl") = False Then
            oAppVars.setAppVar("tcal_empcodedispl", "False", "Boolean")
        End If
        'If Session("tcal_empdescdispl") Is Nothing Then
        '    Session("tcal_empdescdispl") = False
        'End If
        If oAppVars.HasAppVar("tcal_empdescdispl") = False Then
            oAppVars.setAppVar("tcal_empdescdispl", "False", "Boolean")
        End If
        'If Session("show_client") Is Nothing Then
        '    Session("show_client") = True
        'End If
        If oAppVars.HasAppVar("show_client") = False Then
            oAppVars.setAppVar("show_client", "True", "Boolean")
        End If


        'If Session("tcal_office") Is Nothing Then
        '    Session("tcal_office") = ""
        'End If
        If oAppVars.HasAppVar("tcal_office") = False Then
            oAppVars.setAppVar("tcal_office", "")
        End If

        'If Session("tcal_client") Is Nothing Then
        '    Session("tcal_client") = ""
        'End If
        If oAppVars.HasAppVar("tcal_client") = False Then
            oAppVars.setAppVar("tcal_client", "")
        End If

        'If Session("tcal_div") Is Nothing Then
        '    Session("tcal_div") = ""
        'End If
        If oAppVars.HasAppVar("tcal_div") = False Then
            oAppVars.setAppVar("tcal_div", "")
        End If

        'If Session("tcal_prod") Is Nothing Then
        '    Session("tcal_prod") = ""
        'End If
        If oAppVars.HasAppVar("tcal_prod") = False Then
            oAppVars.setAppVar("tcal_prod", "")
        End If

        'If Session("tcal_jobno") Is Nothing Then
        '    Session("tcal_jobno") = ""
        'End If
        If oAppVars.HasAppVar("tcal_jobno") = False Then
            oAppVars.setAppVar("tcal_jobno", "")
        End If

        'If Session("tcal_jobcomp") Is Nothing Then
        '    Session("tcal_jobcomp") = ""
        'End If
        If oAppVars.HasAppVar("tcal_jobcomp") = False Then
            oAppVars.setAppVar("tcal_jobcomp", "")
        End If

        'If Session("tcal_role") Is Nothing Then
        '    Session("tcal_role") = ""
        'End If
        If oAppVars.HasAppVar("tcal_roles") = False Then
            oAppVars.setAppVar("tcal_roles", "")
        End If

        'If Session("tcal_taskstatus") Is Nothing Then
        '    Session("tcal_taskstatus") = ""
        'End If
        If oAppVars.HasAppVar("tcal_taskstatus") = False Then
            oAppVars.setAppVar("tcal_taskstatus", "")
        End If

        If oAppVars.HasAppVar("tcal_manager") = False Then
            oAppVars.setAppVar("tcal_manager", "")
        End If

        If oAppVars.HasAppVar("tcal_excludetempcomplete") = False Then
            oAppVars.setAppVar("tcal_excludetempcomplete", "False", "Boolean")
        End If

        If oAppVars.HasAppVar("tcal_duration") = False Then
            oAppVars.setAppVar("tcal_duration", "False", "Boolean")
        End If

        oAppVars.SaveAllAppVars()


    End Sub

    Private Function getTaskReport(ByVal showtasks As Boolean, ByVal showholidays As Boolean, ByVal showappts As Boolean, ByVal showEvents As Boolean, ByVal showEventTasks As Boolean,
                                   Optional ByVal fromapp As String = "", Optional ByVal job As Integer = 0, Optional ByVal comp As Integer = 0)
        Dim groupLevel As String
        Dim startDate, endDate As DateTime
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

        groupLevel = Request.QueryString("groupLevel")
        startDate = cGlobals.wvCDate(Request.QueryString("startDate"))
        endDate = cGlobals.wvCDate(Request.QueryString("endDate"))

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim dt As DataTable
        SetSessionDefaults()
        oAppVars.getAllAppVars()


        If fromapp = "PS" Then
            If groupLevel = 0 Or showtasks = False And (showholidays = True Or showappts = True) Then
                dt = oCalendar.GetTaskCalendarReport(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 groupLevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                             oAppVars.getAppVar("tcal_client"),
                                             oAppVars.getAppVar("tcal_div"),
                                             oAppVars.getAppVar("tcal_prod"),
                                             job,
                                             comp,
                                             oAppVars.getAppVar("tcal_roles"),
                                             CInt(oAppVars.getAppVar("tcal_len", "Number", "50")),
                                             oAppVars.getAppVar("tcal_taskstatus"),
                                             CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                            showtasks,
                                            showholidays,
                                            showappts,
                                            CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                            oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), fromapp)

            Else
                dt = oCalendar.GetTaskCalendarReportCDPJCGroup3(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 groupLevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                                oAppVars.getAppVar("tcal_client"),
                                                 oAppVars.getAppVar("tcal_div"),
                                                 oAppVars.getAppVar("tcal_prod"),
                                                 job,
                                                 comp,
                                                 oAppVars.getAppVar("tcal_roles"),
                                                 CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                                 oAppVars.getAppVar("tcal_taskstatus"),
                                                 CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                                    showtasks,
                                                    showholidays,
                                                    showappts,
                                                 CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                                 oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), fromapp)
            End If
        Else
            If groupLevel = 0 Or showtasks = False And (showholidays = True Or showappts = True) Then
                dt = oCalendar.GetTaskCalendarReport(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 groupLevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                             oAppVars.getAppVar("tcal_client"),
                                             oAppVars.getAppVar("tcal_div"),
                                             oAppVars.getAppVar("tcal_prod"),
                                             oAppVars.getAppVar("tcal_jobno"),
                                             oAppVars.getAppVar("tcal_jobcomp"),
                                             oAppVars.getAppVar("tcal_roles"),
                                             CInt(oAppVars.getAppVar("tcal_len", "Number", "50")),
                                             oAppVars.getAppVar("tcal_taskstatus"),
                                             CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                             CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                            showtasks,
                                            showholidays,
                                            showappts,
                                            CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                            CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                            oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"), Request.QueryString("FromApp"), Session("TrafficScheduleMVJobs"))

            Else
                dt = oCalendar.GetTaskCalendarReportCDPJCGroup3(startDate,
                                                 endDate,
                                                 CStr(Session("UserCode")),
                                                 groupLevel,
                                                 oAppVars.getAppVar("tcal_emp"),
                                                 oAppVars.getAppVar("tcal_office"),
                                                oAppVars.getAppVar("tcal_client"),
                                                 oAppVars.getAppVar("tcal_div"),
                                                 oAppVars.getAppVar("tcal_prod"),
                                                 oAppVars.getAppVar("tcal_jobno"),
                                                 oAppVars.getAppVar("tcal_jobcomp"),
                                                 oAppVars.getAppVar("tcal_roles"),
                                                 CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                                 oAppVars.getAppVar("tcal_taskstatus"),
                                                 CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                                    showtasks,
                                                    showholidays,
                                                    showappts,
                                                 CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                                 CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                                 oAppVars.getAppVar("tcal_manager"), showEvents, showEventTasks, oAppVars.getAppVar("tcal_departs"))
            End If
        End If

        Return dt

    End Function
    Private Function getMonthData(ByVal dtThisDate As Date)
        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim dt As DataTable
        If Not Session("MediaCalType") Is Nothing Then
            If Session("MediaCalType") = "Traffic" Then
                dt = oCalendar.GetMediaMonthPrint(dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                  Session("mtfSClient"),
                                                                  Session("mtfSDivision"),
                                                                  Session("mtfSProduct"),
                                                                  Session("mtfSMediaType"),
                                                                  Session("mtfSCampaign"),
                                                                  Session("mtfSClientPO"),
                                                                  Session("mtfSVendor"),
                                                                  Session("mtfSBuyer"),
                                                                  Session("mtfIMagazine"),
                                                                  Session("mtfINewspaper"),
                                                                  Session("mtfIInternet"),
                                                                  Session("mtfIOutOfHome"),
                                                                  Session("mtfITelevision"),
                                                                  Session("mtfIRadio"),
                                                                  Session("mtfIAcceptedOrders"),
                                                                  Session("mtfICancelledOrders"),
                                                                  Session("mtfDClient"),
                                                                  Session("mtfDDivision"),
                                                                  Session("mtfDProduct"),
                                                                  Session("mtfDType"),
                                                                  Session("mtfDMediaType"),
                                                                  Session("mtfDInsertionLine"),
                                                                  Session("mtfDVendorCode"),
                                                                  Session("mtfDVendorName"),
                                                                  Session("mtfDJobComp"),
                                                                  Session("mtfDCampaignCode"),
                                                                  Session("mtfDCampaignName"),
                                                                  Session("mtfDMarketCode"),
                                                                  Session("mtfDMarketName"),
                                                                  Session("mtfDAdSizeLength"),
                                                                  Session("mtfDHeadlineProg"),
                                                                  Session("mtfDExtMatDate"),
                                                                  Session("mtfDCloseDate"),
                                                                  Session("mtfDExtCloseDate"),
                                                                  Session("mtfDRunDate"),
                                                                  Session("mtfDBillingAmount"),
                                                                  Session("mtfDSpots"),
                                                                  Session("mtfDBMatDueDate"),
                                                                  Session("mtfDBExtMatDueDate"),
                                                                  Session("mtfDBCloseDate"),
                                                                  Session("mtfDBExtCloseDate"),
                                                                  Session("mtfDBRunInsertionDate"), False,
                                                                  Session("MediaCalPrint"),
                                                                  Session("mtfSOffice"))
            ElseIf Session("MediaCalType") = "Schedule" Then
                dt = oCalendar.GetMediaMonthPrint(dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                  Session("msfSClient"),
                                                                  Session("msfSDivision"),
                                                                  Session("msfSProduct"),
                                                                  Session("msfSMediaType"),
                                                                  Session("msfSCampaign"),
                                                                  Session("msfSClientPO"),
                                                                  Session("msfSVendor"),
                                                                  Session("msfSBuyer"),
                                                                  Session("msfIMagazine"),
                                                                  Session("msfINewspaper"),
                                                                  Session("msfIInternet"),
                                                                  Session("msfIOutOfHome"),
                                                                  Session("msfITelevision"),
                                                                  Session("msfIRadio"),
                                                                  Session("msfIAcceptedOrders"),
                                                                  Session("msfICancelledOrders"),
                                                                  Session("msfDClient"),
                                                                  Session("msfDDivision"),
                                                                  Session("msfDProduct"),
                                                                  Session("msfDType"),
                                                                  Session("msfDMediaType"),
                                                                  Session("msfDInsertionLine"),
                                                                  Session("msfDVendorCode"),
                                                                  Session("msfDVendorName"),
                                                                  Session("msfDJobComp"),
                                                                  Session("msfDCampaignCode"),
                                                                  Session("msfDCampaignName"),
                                                                  Session("msfDMarketCode"),
                                                                  Session("msfDMarketName"),
                                                                  Session("msfDAdSizeLength"),
                                                                  Session("msfDHeadlineProg"),
                                                                  Session("msfDExtMatDate"),
                                                                  Session("msfDCloseDate"),
                                                                  Session("msfDExtCloseDate"),
                                                                  Session("msfDRunDate"),
                                                                  Session("msfDBillingAmount"),
                                                                  Session("msfDSpots"),
                                                                  Session("msfDBMatDueDate"),
                                                                  Session("msfDBExtMatDueDate"),
                                                                  Session("msfDBCloseDate"),
                                                                  Session("msfDBExtCloseDate"),
                                                                  Session("msfDBRunInsertionDate"),
                                                                  Session("msfDBDisplayFlight"),
                                                                  Session("MediaCalPrint"),
                                                                  Session("msfSOffice"))
            Else
                dt = oCalendar.GetMediaMonthPrint(dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  True,
                                                                  False,
                                                                  True,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  "")
            End If
        Else
            dt = oCalendar.GetMediaMonthPrint(dtThisDate.Month, dtThisDate.Year, CStr(Session("UserCode")), "", "", "", "", "", "", "", "", True, True, True, True, True, True, False, False, True, False, False, True, False, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, True, False, False, False, False)
        End If

        Return dt

    End Function
    Private Function getMonthName()
        Dim month As Integer = Convert.ToDateTime(Request.QueryString("thisdate")).Month
        If month = 1 Then
            Return "January"
        End If
        If month = 2 Then
            Return "February"
        End If
        If month = 3 Then
            Return "March"
        End If
        If month = 4 Then
            Return "April"
        End If
        If month = 5 Then
            Return "May"
        End If
        If month = 6 Then
            Return "June"
        End If
        If month = 7 Then
            Return "July"
        End If
        If month = 8 Then
            Return "August"
        End If
        If month = 9 Then
            Return "September"
        End If
        If month = 10 Then
            Return "October"
        End If
        If month = 11 Then
            Return "November"
        End If
        If month = 12 Then
            Return "December"
        End If

    End Function
    Private Function GetHeader(ByVal Location As String) As String
        Dim header As String = ""
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim arParams(0) As SqlParameter

        Dim parameterLocation As New SqlParameter("@Location", SqlDbType.VarChar)
        parameterLocation.Value = Location
        arParams(0) = parameterLocation

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_get_header", arParams)

            If dr.HasRows Then
                dr.Read()
                header = dr.GetString(0)
            End If
        Catch
            Err.Raise(Err.Number, "Class:popReportViewer Routine:GetHeader", Err.Description)
        End Try

        Return header
    End Function
    Private Function GetFooter(ByVal Location As String) As String
        Dim footer As String = ""
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim arParams(0) As SqlParameter

        Dim parameterLocation As New SqlParameter("@Location", SqlDbType.VarChar)
        parameterLocation.Value = Location
        arParams(0) = parameterLocation

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_get_footer", arParams)

            If dr.HasRows Then
                dr.Read()
                footer = dr.GetString(0)
            End If
        Catch
            Err.Raise(Err.Number, "Class:popReportViewer Routine:GetFooter", Err.Description)
        End Try

        Return footer
    End Function

    Private Function CheckProductCategory() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))

        Return ovisible.ProductCategoryVisible()
    End Function

    'this won't fire for some reason ...
    Private Sub CloseThisWindow()

        Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType, "CloseThisWindow", "window.close;", True)

    End Sub

    Private Sub ShowMessageAndClose(ByVal s As String)
        'this won't fire for some reason
        If s.Trim() = "" Then

            Me.CloseThisWindow()
            Exit Sub

        Else

            s = AdvantageFramework.StringUtilities.JavascriptSafe(s)
            Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType, "CloseThisWindow", "alert('" & s & "');window.close;", True)

        End If

        ' '' ''Response.Write(s)
        ' '' ''Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType, "CloseThisWindow", "window.close;", True)

    End Sub
    Private Sub NoData()

        Me.ShowMessageAndClose("No Data for Selected Inputs.")

    End Sub

#Region " New Filename "

    Private Function GetFilename(ByRef OriginalFilename As String, ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim s As String = ""
            Dim ParsingError As Boolean = False

            If ReportType.ToString().Contains("BillApproval") Then

                s = "BA_" & Me.ClientCode

            ElseIf ReportType.ToString().Contains("Calendar") Then

                If Me.StartDate.Month = Me.EndDate.Month And Me.StartDate.Year = Me.EndDate.Year Then

                    s = "CALENDAR_REPORT_" & Me.StartDate.ToString("MMMM").Substring(0, 3) & Me.StartDate.Year.ToString()

                Else

                    s = "CALENDAR_REPORT_" & Me.StartDate.ToString("MMMM").Substring(0, 3) & Me.StartDate.Year.ToString() & "-" & Me.EndDate.ToString("MMMM").Substring(0, 3) & Me.EndDate.Year.ToString()

                End If


            ElseIf ReportType.ToString().Contains("ClientARStatement") Then

                s = "CLIENT_AR_STATEMENT_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)

            ElseIf ReportType.ToString().Contains("CreativeBrief") Then

                s = Me.ParseFilenameKey(EmpCode, "CREATIVE_BRIEF_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("EmpNPTime") Then

                s = "INDIRECT_TIME_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)

            ElseIf ReportType.ToString().Contains("Estimating") Then

                s = Me.ParseEstimatingFilenameKey(EmpCode, ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("JobSpecs") Then

                s = Me.ParseFilenameKey(EmpCode, "SPECIFICATIONS_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("JobTemplate") Then

                s = Me.ParseFilenameKey(EmpCode, "JOB_JACKET_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("JobVersion") Then

                'Dim jv As JobVersion = New JobVersion(Session("ConnString"))
                Dim TemplateName As String = "" 'jv.GetAgencyDesc().ToUpper()

                If Not Session("JVTemplateName") Is Nothing Then

                    TemplateName = Session("JVTemplateName").ToString().ToUpper()

                End If

                If TemplateName = "" Then TemplateName = "JOB_VERSION"

                s = Me.ParseFilenameKey(EmpCode, TemplateName & "_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("ProductARStatement") Then

                ' s = Me.ParseFilenameKey(EmpCode, "AR_STATEMENT_#ProductCode#", ReportType, ParsingError)
                s = "PRODUCT_AR_STATEMENT_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)

            ElseIf ReportType.ToString().Contains("SumRepByClient") Then

                s = "PROJECT_SUMMARY_REPORT_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)

            ElseIf ReportType.ToString().Contains("TaskList") Then

                Dim FriendlyName As String = Me.GetTaskReportFriendlyName(ReportType)

                's = Me.ParseFilenameKey(EmpCode, FriendlyName & "_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)
                s = FriendlyName & "_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)


            ElseIf ReportType.ToString().Contains("TimeSheetPrint") Then

                s = "TIMESHEET_" & EmpCode & "_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)

            ElseIf ReportType.ToString().Contains("Traffic") Then

                s = Me.ParseFilenameKey(EmpCode, Me.GetProjectScheduleFriendlyName(ReportType) & "_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#", ReportType, ParsingError)

            ElseIf ReportType.ToString().Contains("Vendor") Then

                s = "VENDOR_QUOTE_REQUEST"

                If Me.VendorCode <> "" Then

                    s = s & "_" & Me.VendorCode

                End If

            Else

                s = OriginalFilename

            End If

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

    Private Function GetProjectScheduleFriendlyName(ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        Dim FriendlyName As String = "SCHEDULE"

        Select Case ReportType
            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob

                If ShowHours = False Then

                    FriendlyName = "Schedule Detail by Job with Start Date and Due Date"

                Else

                    FriendlyName = "Schedule Detail by Job with Hours Allowed"

                End If

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob2

                FriendlyName = "Schedule Detail by Job with Dates and Resources"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJob3

                FriendlyName = "Schedule Detail by Job with Assignments"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TrafficDetailByJobDueDate

                FriendlyName = "Schedule Detail by Job with Due Date Only"

        End Select

        Return FriendlyName '.ToUpper().Replace(" ", "_")

        '**shared
        'Schedule Detail by Job with Start Date and Due Date
        'Schedule Detail by Job with Hours Allowed
        'Schedule Detail by Job with Due Date Only
        'Gantt Report - Single Job
        'Calendar Report
        'Schedule Detail by Job with Dates and Resources

        '**multi-view
        'Multi Job Gantt Report
        'Gantt Report - Single Job By Day
        'Schedule Detail by Job with Assignments

        '**single-view
        'Gantt Report - Single Job By Day
        'Schedule Detail by Job with Assignment

    End Function
    Private Function GetTaskReportFriendlyName(ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String

        Dim FriendlyName As String = "TASK"

        Select Case ReportType

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskList

                FriendlyName = "TASK_LIST"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListDueDate

                FriendlyName = "TASK_LIST_BY_DUE_DATE"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListSummary

                FriendlyName = "TASK_LIST_SUMMARY"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.MyTaskListTask

                FriendlyName = "TASK_LIST_BY_TASK"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskList

                FriendlyName = "MY_TASK_LIST"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListDueDate

                FriendlyName = "MY_TASK_LIST_BY_DUE_DATE"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.TaskListTask

                FriendlyName = "MY_TASK_LIST_BY_TASK"

            Case AdvantageFramework.Reporting.ActiveReports.ReportName.CompletedTaskReport

                FriendlyName = "COMPLETED_TASKS"

        End Select

        Return FriendlyName.ToUpper()

    End Function
    Public Function GetClientJobCompStandardString(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal Filename As String, Optional ByVal ClientCode As String = "") As String

        Dim t As New cTimeSheet(HttpContext.Current.Session("ConnString"))

        If ClientCode = "" Then

            If JobNumber > 0 And JobComponentNbr = 0 Then

                t.GetJobInfo(JobNumber, , , ClientCode)

            ElseIf JobNumber > 0 And JobComponentNbr > 0 Then

                t.GetJobComponentInfo(JobNumber, JobComponentNbr, , , , ClientCode)

            End If

        End If

        Dim sb As New System.Text.StringBuilder
        With sb

            If Filename <> "" Then

                .Append(Filename)
                .Append("_")

            End If
            If ClientCode <> "" Then

                .Append(ClientCode)
                .Append("_")

            End If
            If JobNumber > 0 Then

                .Append("JOB_")
                .Append(JobNumber.ToString().PadLeft(6, "0"))

            End If
            If JobComponentNbr > 0 Then

                .Append("_")
                .Append(JobComponentNbr.ToString().PadLeft(3, "0"))

            End If

        End With

        Return sb.ToString().ToUpper().Replace(" ", "_")

    End Function


    Private Function ParseEstimatingFilenameKey(ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        'get est
        'if est has j/jc include, if not, use just client
        Dim s As String

        Dim EstString As String = ""
        Dim EstCompString As String = ""

        If Me.EstimateNumber > 0 Then

            EstString = Me.EstimateNumber.ToString().PadLeft(6, "0")

        End If


        If Me.EstimateComponentNbr > 0 Then

            EstCompString = "_" & Me.EstimateComponentNbr.ToString().PadLeft(2, "0")

        End If

        If Me._JobNumber = 0 Or Me._JobComponentNbr = 0 Then

            Dim ClCode As String = ""
            Dim ClCodeString As String = ""

            If Me.EstimateNumber > 0 Then

                Try

                    ClCode = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT ISNULL(CL_CODE,'') FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER" & Me.EstimateNumber.ToString() & ";").ToString()

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

            Dim t As New cTimeSheet(Session("ConnString"))

            If Me._JobNumber > 0 And Me._JobComponentNbr > 0 Then

                t.GetJobComponentInfo(Me._JobNumber, Me._JobComponentNbr, JobDesc, JobCompDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc,
                                      ScCode, CmpCode, CmpIdentifier, CdpContactId, PrdContCode, ContFML, NextAlertSeqNbr, JobComponentEmpCode)

            ElseIf Me._JobNumber > 0 And Me._JobComponentNbr = 0 Then

                t.GetJobInfo(Me._JobNumber, JobDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, ScCode, ScDesc, CmpCode, CmpIdentifier)

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

                        sb.Append(_JobNumber.ToString().PadLeft(6, "0"))

                    Case "ComponentNumber"

                        sb.Append(_JobComponentNbr.ToString().PadLeft(2, "0"))

                    Case "JobDescription"

                        sb.Append(JobDesc)

                    Case "ComponentDescription"

                        sb.Append(JobCompDesc)

                    Case "EstimateNumber"



                    Case "PONumber"


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

#End Region

End Class

'test
<Serializable()>
Public Class ActiveReportOptions

    Public Property [Values] As System.Collections.Generic.Dictionary(Of String, String)
    Public Property ErrorMessage As String = ""

    Private Property _Key As String = ""

    Public Function Save() As String

        Dim g As Guid
        g = Guid.NewGuid()

        Dim SafeGuid As String = "ARO_" & g.ToString().Substring(0, 15).Replace("'", "").Replace("&", "").Replace("?", "")

        HttpContext.Current.Session(SafeGuid) = Me.Values

    End Function

    Public Sub Load()

        If Me._Key <> "" Then

            If Not HttpContext.Current.Session(Me._Key) Is Nothing Then

                Me.Values = CType(HttpContext.Current.Session(Me._Key), System.Collections.Generic.Dictionary(Of String, String))

            End If

        End If

    End Sub

    Public Sub Dispose()

        HttpContext.Current.Session(Me._Key) = Nothing

    End Sub

    Sub New(Optional ByVal ExistingKey As String = "")

        [Values] = New System.Collections.Generic.Dictionary(Of String, String)

        If ExistingKey <> "" Then

            Me._Key = ExistingKey

        End If

    End Sub

End Class
