'Imports Kendo.Mvc.Extensions
'Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MvcCodeRouting.Web.Mvc
Imports System.Data.SqlClient
Imports Webvantage.cGlobals

Namespace Controllers.Dashboard

    <Serializable()>
    Public Class FinancialController
        Inherits MVCControllerBase

#Region " Constants "


#End Region

#Region " Enum "

#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Initialize "


#End Region

#Region " Razor Views "

        Public Function Index(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As ActionResult

            Dim Employee As cEmployee = Nothing

            Employee = New cEmployee(Me.SecuritySession.ConnectionString)

            If MiscFN.IsClientPortal Then
                ViewBag.IsClientPortal = True
                'EUFilter.IsClientPortal = True
            Else
                ViewBag.IsClientPortal = False
                ViewBag.EmployeeName = Employee.GetName(Me.SecuritySession.User.EmployeeCode)
                ViewBag.DefaultEmpCode = Me.SecuritySession.User.EmployeeCode
            End If

            ViewBag.Year1 = Date.Now.Year - 1
            ViewBag.Year2 = Date.Now.Year

            'ViewBag.BackgroundColor = GetUserBackgroundColor(Me.SecuritySession.UserName)
            ViewBag.HasAccessToTimesheet = Me.HasAccessToTimesheet()
            ViewBag.UserCode = Me.SecuritySession.UserCode

            Return View()

        End Function
        Public Function _FinancialDashboard() As ActionResult

            Return PartialView()

        End Function
        'Public Function _UtilizationFilter() As ActionResult

        '    Return PartialView()

        'End Function

#End Region

#Region " API "

#Region " Get "
        <HttpGet>
        Public Function GetUserViewSettings(ApplicationName As String) As JsonResult

            'objects
            Dim ViewSettings As List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationUserViewSetting) = Nothing
            Dim ErrorMessage As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ViewSettings = AdvantageFramework.Dashboard.GetUserViewSettings(DbContext, Me.SecuritySession.UserCode, ApplicationName)

            End Using

            Return MaxJson(ViewSettings, JsonRequestBehavior.AllowGet)

        End Function

        Public Function GroupSecuritySettings() As JsonResult

            Dim SecuritySettings As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting) = Nothing
            SecuritySettings = New List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting)

            Dim setting As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting
            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "ShowAllAssignments"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments) = 0, False, True)

            SecuritySettings.Add(setting)


            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "ShowUnassignedAssignments"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments) = 0, False, True)

            SecuritySettings.Add(setting)


            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "AllowTaskEdit"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) = 0, False, True)

            SecuritySettings.Add(setting)

            Return MaxJson(SecuritySettings, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function GetChartData(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As JsonResult
            'temporary hard coding for dashboard data
            'once the metrics have been nailed down for the dashboards

            Dim MTDDataDetails As List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData) = Nothing
            Dim MTDDataDetail As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData = Nothing

            Dim PerformanceDataDetails As List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardData) = Nothing
            Dim PerformanceDataDetail As AdvantageFramework.Dashboard.Classes.FinancialDashboardData = Nothing

            Dim FinancialData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardData
            Dim FinancialChartData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartData
            Dim FinancialChartGridData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartGridData
            Dim FinancialChartDataYTD As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataYTD
            Dim FinancialChartGridDataYTD As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartGridDataYTD
            Dim FinancialChartDataClient As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataClient
            Dim FinancialChartGridDataClient As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataGridClient
            Dim FinancialChartDataBillable As New AdvantageFramework.Dashboard.Classes.FinancialDashboardBillableGridData
            Dim FinancialChartDataNewBusiness As New AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessData
            Dim FinancialChartDataGrow As New AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowData
            Dim ErrorMessage As String = ""

            'MTD GRID
            'If ChartId = 1 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If EUFilter.Page = 3 Then
                    FinancialChartData.Items = AdvantageFramework.Dashboard.LoadFinancialChartData(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 4 Then
                    FinancialChartGridData.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridData(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 5 Then
                    FinancialChartDataYTD.Items = AdvantageFramework.Dashboard.LoadFinancialChartDataYTD(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 6 Then
                    FinancialChartGridDataYTD.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridDataYTD(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 7 Then
                    FinancialChartDataClient.Items = AdvantageFramework.Dashboard.LoadFinancialChartDataClientDT(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 8 Then
                    FinancialChartGridDataClient.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridDataClientDT(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 9 Then
                    FinancialChartDataBillable.Items = AdvantageFramework.Dashboard.LoadFinancialBillableData(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 10 Then
                    FinancialChartDataNewBusiness.Items = AdvantageFramework.Dashboard.LoadFinancialNewBusinessData(DbContext, EUFilter, ErrorMessage)
                ElseIf EUFilter.Page = 11 Then
                    FinancialChartDataGrow.Items = AdvantageFramework.Dashboard.LoadFinancialGrowData(DbContext, EUFilter, ErrorMessage)
                Else
                    FinancialData.Items = AdvantageFramework.Dashboard.LoadFinancialData(DbContext, EUFilter, ErrorMessage)
                End If

            End Using

            'MTDDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData()
            'MTDDataDetail.Category = "Revenue"
            'MTDDataDetail.Actual = 2111073
            'MTDDataDetail.Budget = 2451420
            'MTDDataDetail.VariancePercent = 340347
            'MTDDataDetail.MTD = 2147940
            'MTDDataDetail.YOYPercent = -2

            'MTDDataDetails = New List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData)
            'MTDDataDetails.Add(MTDDataDetail)

            'MTDDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData()
            'MTDDataDetail.Category = "Expenses"
            'MTDDataDetail.Actual = 2111073
            'MTDDataDetail.Budget = 2451420
            'MTDDataDetail.VariancePercent = 340347
            'MTDDataDetail.MTD = 2147940
            'MTDDataDetail.YOYPercent = -2

            'MTDDataDetails.Add(MTDDataDetail)

            'MTDDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData()
            'MTDDataDetail.Category = "Net Income"
            'MTDDataDetail.Actual = 2111073
            'MTDDataDetail.Budget = 2451420
            'MTDDataDetail.VariancePercent = 340347
            'MTDDataDetail.MTD = 2147940
            'MTDDataDetail.YOYPercent = -2

            'MTDDataDetails.Add(MTDDataDetail)

            'MTDDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData()
            'MTDDataDetail.Category = "Profit Margin"
            'MTDDataDetail.Actual = 2111073
            'MTDDataDetail.Budget = 2451420
            'MTDDataDetail.VariancePercent = 340347
            'MTDDataDetail.MTD = 2147940
            'MTDDataDetail.YOYPercent = -2

            'MTDDataDetails.Add(MTDDataDetail)
            'End If

            'YTD GRID
            'If ChartId = 1 Then
            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Media"
            '    DataDetail.Count = 15
            '    DataDetail.Amount = 223298

            '    DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Non-Client"
            '    DataDetail.Count = 7
            '    DataDetail.Amount = 82843

            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Production"
            '    DataDetail.Count = 4
            '    DataDetail.Amount = 12256

            '    DataDetails.Add(DataDetail)
            'End If

            'Year Performance
            'If ChartId = 2 Then
            '    PerformanceDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardData()
            '    PerformanceDataDetail.Month = "January"
            '    PerformanceDataDetail.Revenue = 22
            '    PerformanceDataDetail.Expenses = 63330
            '    PerformanceDataDetail.Income = 0
            '    PerformanceDataDetail.ProfitMargin = 0

            '    PerformanceDataDetails = New List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardData)
            '    PerformanceDataDetails.Add(PerformanceDataDetail)

            '    PerformanceDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardData()
            '    PerformanceDataDetail.Month = "Febuurary"
            '    PerformanceDataDetail.Revenue = 22
            '    PerformanceDataDetail.Expenses = 63330
            '    PerformanceDataDetail.Income = 0
            '    PerformanceDataDetail.ProfitMargin = 0

            '    PerformanceDataDetails.Add(PerformanceDataDetail)

            '    PerformanceDataDetail = New AdvantageFramework.Dashboard.Classes.FinancialDashboardData()
            '    PerformanceDataDetail.Month = "March"
            '    PerformanceDataDetail.Revenue = 22
            '    PerformanceDataDetail.Expenses = 63330
            '    PerformanceDataDetail.Income = 0
            '    PerformanceDataDetail.ProfitMargin = 0

            '    PerformanceDataDetails.Add(PerformanceDataDetail)
            'End If

            'Open Payables by Type - Grid Detail
            'If ChartId = 3 Then
            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Centro"
            '    DataDetail.SubCategory = "Media"
            '    DataDetail.Count = 1
            '    DataDetail.Amount = 19164

            '    DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Excellent Printing Company"
            '    DataDetail.SubCategory = "Production"
            '    DataDetail.Count = 3
            '    DataDetail.Amount = 47652

            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Facebook"
            '    DataDetail.SubCategory = "Media"
            '    DataDetail.Count = 2
            '    DataDetail.Amount = 21254

            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Federal Express, Corp"
            '    DataDetail.SubCategory = "Non-Client"
            '    DataDetail.Count = 1
            '    DataDetail.Amount = 25846

            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "KABC Radio"
            '    DataDetail.SubCategory = "Media"
            '    DataDetail.Count = 1
            '    DataDetail.Amount = 8653

            '    DataDetails.Add(DataDetail)

            '    DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
            '    DataDetail.Category = "Simpli.Fi"
            '    DataDetail.SubCategory = "Media"
            '    DataDetail.Count = 1
            '    DataDetail.Amount = 14259

            '    DataDetails.Add(DataDetail)
            'End If

            If EUFilter.Page = 3 Then
                Return MaxJson(FinancialChartData.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 4 Then
                Return MaxJson(FinancialChartGridData.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 5 Then
                Return MaxJson(FinancialChartDataYTD.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 6 Then
                Return MaxJson(FinancialChartGridDataYTD.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 7 Then
                Return MaxJson(FinancialChartDataClient.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 8 Then
                Return MaxJson(FinancialChartGridDataClient.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 9 Then
                Return MaxJson(FinancialChartDataBillable.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 10 Then
                Return MaxJson(FinancialChartDataNewBusiness.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 11 Then
                Return MaxJson(FinancialChartDataGrow.Items, JsonRequestBehavior.AllowGet)
            Else
                Return MaxJson(FinancialData.Items, JsonRequestBehavior.AllowGet)
            End If


        End Function

        <HttpGet>
        Public Function GetChartDataDS(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As JsonResult
            'temporary hard coding for dashboard data
            'once the metrics have been nailed down for the dashboards

            Dim MTDDataDetails As List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData) = Nothing
            Dim MTDDataDetail As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData = Nothing

            Dim PerformanceDataDetails As List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardData) = Nothing
            Dim PerformanceDataDetail As AdvantageFramework.Dashboard.Classes.FinancialDashboardData = Nothing

            Dim FinancialData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardData
            Dim FinancialDataYTD As New AdvantageFramework.Dashboard.Classes.FinancialDashboardDataYTD
            Dim FinancialChartData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartData
            Dim FinancialChartGridData As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartGridData
            Dim FinancialChartDataYTD As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataYTD
            Dim FinancialChartGridDataYTD As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartGridDataYTD
            Dim FinancialChartDataClient As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataClient
            Dim FinancialChartGridDataClient As New AdvantageFramework.Dashboard.Classes.FinancialDashboardChartDataGridClient
            Dim FinancialChartDataBillable As New AdvantageFramework.Dashboard.Classes.FinancialDashboardBillableGridData
            Dim FinancialChartDataNewBusiness As New AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessData
            Dim FinancialChartDataGrow As New AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowData
            Dim ErrorMessage As String = ""

            Dim FinancialDashboardMonthData As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData = Nothing
            Dim FinancialDashboardMonthChartData As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartData = Nothing
            Dim FinancialDashboardMonthChartGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartGridData = Nothing
            Dim FinancialDashboardYTDChartData As AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartData = Nothing
            Dim FinancialDashboardYTDChartGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartGridData = Nothing
            Dim FinancialDashboardClientChartData As AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData = Nothing
            Dim FinancialDashboardClientChartGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData = Nothing
            Dim FinancialDashboardMonthBillableGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData = Nothing
            Dim FinancialDashboardNewBusinessGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessGridData = Nothing
            Dim FinancialDashboardGrowGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData = Nothing

            'MTD GRID
            'If ChartId = 1 Then

            Dim ds As DataSet

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ds = AdvantageFramework.Dashboard.LoadFinancialDataDS(DbContext, EUFilter, ErrorMessage)

                If ds IsNot Nothing And ds.Tables.Count > 0 Then

                    For Each dt As DataTable In ds.Tables

                        If dt IsNot Nothing And dt.Rows.Count > 0 Then

                            For i = 0 To dt.Rows.Count - 1

                                If EUFilter.Page = 1 Then

                                    FinancialDashboardMonthData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData

                                    FinancialDashboardMonthData.Category = dt.Rows(i)("Category")
                                    FinancialDashboardMonthData.Actual = dt.Rows(i)("Actual")
                                    FinancialDashboardMonthData.Budget = dt.Rows(i)("Budget")
                                    FinancialDashboardMonthData.VariancePercent = dt.Rows(i)("VariancePercent")
                                    FinancialDashboardMonthData.MTD = dt.Rows(i)("MTD")
                                    FinancialDashboardMonthData.YOYPercent = dt.Rows(i)("YOYPercent")

                                    FinancialData.Items.Add(FinancialDashboardMonthData)

                                ElseIf EUFilter.Page = 2 Then

                                    FinancialDashboardMonthData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData

                                    FinancialDashboardMonthData.Category = dt.Rows(i)("Category")
                                    FinancialDashboardMonthData.Actual = dt.Rows(i)("Actual")
                                    FinancialDashboardMonthData.Budget = dt.Rows(i)("Budget")
                                    FinancialDashboardMonthData.VariancePercent = dt.Rows(i)("VariancePercent")
                                    FinancialDashboardMonthData.MTD = dt.Rows(i)("MTD")
                                    FinancialDashboardMonthData.YOYPercent = dt.Rows(i)("YOYPercent")

                                    FinancialDataYTD.Items.Add(FinancialDashboardMonthData)

                                ElseIf EUFilter.Page = 3 Then

                                    FinancialDashboardMonthChartData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartData

                                    FinancialDashboardMonthChartData.Month = dt.Rows(i)("Month")
                                    FinancialDashboardMonthChartData.Revenue = dt.Rows(i)("Revenue")
                                    FinancialDashboardMonthChartData.Expenses = dt.Rows(i)("Expenses")
                                    FinancialDashboardMonthChartData.NetIncome = dt.Rows(i)("NetIncome")

                                    FinancialChartData.Items.Add(FinancialDashboardMonthChartData)

                                ElseIf EUFilter.Page = 4 Then

                                    FinancialDashboardMonthChartGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartGridData

                                    FinancialDashboardMonthChartGridData.Category = dt.Rows(i)("Category")
                                    FinancialDashboardMonthChartGridData.January = dt.Rows(i)("January")
                                    FinancialDashboardMonthChartGridData.Feburary = dt.Rows(i)("Feburary")
                                    FinancialDashboardMonthChartGridData.March = dt.Rows(i)("March")
                                    FinancialDashboardMonthChartGridData.April = dt.Rows(i)("April")
                                    FinancialDashboardMonthChartGridData.May = dt.Rows(i)("May")
                                    FinancialDashboardMonthChartGridData.June = dt.Rows(i)("June")
                                    FinancialDashboardMonthChartGridData.July = dt.Rows(i)("July")
                                    FinancialDashboardMonthChartGridData.August = dt.Rows(i)("August")
                                    FinancialDashboardMonthChartGridData.September = dt.Rows(i)("September")
                                    FinancialDashboardMonthChartGridData.October = dt.Rows(i)("October")
                                    FinancialDashboardMonthChartGridData.November = dt.Rows(i)("November")
                                    FinancialDashboardMonthChartGridData.December = dt.Rows(i)("December")

                                    FinancialChartGridData.Items.Add(FinancialDashboardMonthChartGridData)

                                ElseIf EUFilter.Page = 5 Then

                                    FinancialDashboardYTDChartData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartData

                                    FinancialDashboardYTDChartData.Year = dt.Rows(i)("Year")
                                    FinancialDashboardYTDChartData.Revenue = dt.Rows(i)("Revenue")
                                    FinancialDashboardYTDChartData.Expenses = dt.Rows(i)("Expenses")
                                    FinancialDashboardYTDChartData.Income = dt.Rows(i)("Income")
                                    FinancialDashboardYTDChartData.Profit = dt.Rows(i)("Profit")

                                    FinancialChartDataYTD.Items.Add(FinancialDashboardYTDChartData)

                                ElseIf EUFilter.Page = 6 Then

                                    FinancialDashboardYTDChartGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartGridData

                                    FinancialDashboardYTDChartGridData.Category = dt.Rows(i)("Category")
                                    FinancialDashboardYTDChartGridData.Year1 = dt.Rows(i)("Year1")
                                    FinancialDashboardYTDChartGridData.Year2 = dt.Rows(i)("Year2")

                                    FinancialChartGridDataYTD.Items.Add(FinancialDashboardYTDChartGridData)

                                ElseIf EUFilter.Page = 7 Then

                                    FinancialDashboardClientChartData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData

                                    FinancialDashboardClientChartData.Client = dt.Rows(i)("Client")
                                    FinancialDashboardClientChartData.Year1 = dt.Rows(i)("Year1")
                                    FinancialDashboardClientChartData.Year2 = dt.Rows(i)("Year2")

                                    FinancialChartDataClient.Items.Add(FinancialDashboardClientChartData)

                                ElseIf EUFilter.Page = 8 Then

                                    FinancialDashboardClientChartGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData

                                    FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)("Client1")
                                    FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)("Client2")
                                    FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)("Client3")
                                    FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)("Client4")
                                    FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)("Client5")
                                    FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)("Client6")
                                    FinancialDashboardClientChartGridData.Client7 = dt.Rows(i)("Client7")
                                    FinancialDashboardClientChartGridData.Client8 = dt.Rows(i)("Client8")
                                    FinancialDashboardClientChartGridData.Client9 = dt.Rows(i)("Client9")
                                    FinancialDashboardClientChartGridData.Client10 = dt.Rows(i)("Client10")

                                    FinancialChartGridDataClient.Items.Add(FinancialDashboardClientChartGridData)

                                ElseIf EUFilter.Page = 9 Then

                                    FinancialDashboardMonthBillableGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData

                                    FinancialDashboardMonthBillableGridData.January = dt.Rows(i)("January")
                                    FinancialDashboardMonthBillableGridData.Feburary = dt.Rows(i)("Feburary")
                                    FinancialDashboardMonthBillableGridData.March = dt.Rows(i)("March")
                                    FinancialDashboardMonthBillableGridData.April = dt.Rows(i)("April")
                                    FinancialDashboardMonthBillableGridData.May = dt.Rows(i)("May")
                                    FinancialDashboardMonthBillableGridData.June = dt.Rows(i)("June")
                                    FinancialDashboardMonthBillableGridData.July = dt.Rows(i)("July")
                                    FinancialDashboardMonthBillableGridData.August = dt.Rows(i)("August")
                                    FinancialDashboardMonthBillableGridData.September = dt.Rows(i)("September")
                                    FinancialDashboardMonthBillableGridData.October = dt.Rows(i)("October")
                                    FinancialDashboardMonthBillableGridData.November = dt.Rows(i)("November")
                                    FinancialDashboardMonthBillableGridData.December = dt.Rows(i)("December")

                                    FinancialChartDataBillable.Items.Add(FinancialDashboardMonthBillableGridData)

                                ElseIf EUFilter.Page = 10 Then

                                    FinancialDashboardNewBusinessGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessGridData

                                    FinancialDashboardNewBusinessGridData.Client = dt.Rows(i)("Client")
                                    FinancialDashboardNewBusinessGridData.Amount = dt.Rows(i)("Amount")

                                    FinancialChartDataNewBusiness.Items.Add(FinancialDashboardNewBusinessGridData)

                                ElseIf EUFilter.Page = 11 Then

                                    FinancialDashboardGrowGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData

                                    FinancialDashboardGrowGridData.Client = dt.Rows(i)("Client")
                                    FinancialDashboardGrowGridData.YOY = dt.Rows(i)("YOY")
                                    FinancialDashboardGrowGridData.Growth = dt.Rows(i)("Growth")

                                    FinancialChartDataGrow.Items.Add(FinancialDashboardGrowGridData)

                                Else
                                    'FinancialData.Items = AdvantageFramework.Dashboard.LoadFinancialData(DbContext, EUFilter, ErrorMessage)
                                End If



                            Next

                        End If

                    Next

                End If


                'If EUFilter.Page = 3 Then
                '    FinancialChartData.Items = AdvantageFramework.Dashboard.LoadFinancialChartData(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 4 Then
                '    FinancialChartGridData.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridData(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 5 Then
                '    FinancialChartDataYTD.Items = AdvantageFramework.Dashboard.LoadFinancialChartDataYTD(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 6 Then
                '    FinancialChartGridDataYTD.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridDataYTD(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 7 Then
                '    FinancialChartDataClient.Items = AdvantageFramework.Dashboard.LoadFinancialChartDataClientDT(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 8 Then
                '    FinancialChartGridDataClient.Items = AdvantageFramework.Dashboard.LoadFinancialChartGridDataClientDT(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 9 Then
                '    FinancialChartDataBillable.Items = AdvantageFramework.Dashboard.LoadFinancialBillableData(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 10 Then
                '    FinancialChartDataNewBusiness.Items = AdvantageFramework.Dashboard.LoadFinancialNewBusinessData(DbContext, EUFilter, ErrorMessage)
                'ElseIf EUFilter.Page = 11 Then
                '    FinancialChartDataGrow.Items = AdvantageFramework.Dashboard.LoadFinancialGrowData(DbContext, EUFilter, ErrorMessage)
                'Else
                '    FinancialData.Items = AdvantageFramework.Dashboard.LoadFinancialData(DbContext, EUFilter, ErrorMessage)
                'End If

            End Using

            If EUFilter.Page = 3 Then
                Return MaxJson(FinancialChartData.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 4 Then
                Return MaxJson(FinancialChartGridData.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 5 Then
                Return MaxJson(FinancialChartDataYTD.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 6 Then
                Return MaxJson(FinancialChartGridDataYTD.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 7 Then
                Return MaxJson(FinancialChartDataClient.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 8 Then
                Return MaxJson(FinancialChartGridDataClient.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 9 Then
                Return MaxJson(FinancialChartDataBillable.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 10 Then
                Return MaxJson(FinancialChartDataNewBusiness.Items, JsonRequestBehavior.AllowGet)
            ElseIf EUFilter.Page = 11 Then
                Return MaxJson(FinancialChartDataGrow.Items, JsonRequestBehavior.AllowGet)
            Else
                Return MaxJson(FinancialData.Items, JsonRequestBehavior.AllowGet)
            End If


        End Function

        <HttpGet>
        Public Function GetClients(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As JsonResult
            'temporary hard coding for dashboard data
            'once the metrics have been nailed down for the dashboards

            Dim FinancialClients As New Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClients)
            Dim ErrorMessage As String = ""

            'MTD GRID
            'If ChartId = 1 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                FinancialClients = AdvantageFramework.Dashboard.LoadFinancialClients(DbContext, EUFilter, ErrorMessage)

            End Using

            Return MaxJson(FinancialClients, JsonRequestBehavior.AllowGet)


        End Function

#End Region
#Region " Post "
        <HttpPost>
        Public Function BookmarkFinancialDashboard(Month As String, Year As String, GridSize As Integer) As JsonResult

            'objects
            Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
            Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
            Dim Description As String = Nothing
            Dim StartDateLogic As String = Nothing
            Dim EndDateLogic As String = Nothing

            BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
            Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

            QueryString = New AdvantageFramework.Web.QueryString

            QueryString.Page = "Dashboard/Financial"
            QueryString.Add("bm", "1")
            QueryString.Add("year", Year)
            QueryString.Add("month", Month)
            QueryString.Add("aamgs", GridSize)

            Description = "Financial Dashboard" + " (" + Month + "/" + Year + ")"

            Bookmark.Description = Description
            Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_FinancialDashboard
            Bookmark.UserCode = Me.SecuritySession.UserCode

            Bookmark.Name = String.Format("{0}", "Financial Dashboard")
            Bookmark.PageURL = QueryString.ToString(True)

            Saved = BookmarkMethods.SaveBookmark(Bookmark, Message)



            Return MaxJson(New With {.Success = Saved, .Message = Message})

        End Function

#End Region

#End Region

#Region " Private "


#End Region

#Region " Classes "


#End Region

    End Class

End Namespace

