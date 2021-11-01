Public Class DesktopObjectLoadWindow
    Inherits Webvantage.BaseChildPage

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

    Public Shared JavascriptAlertTimer As String = ""
    Private ObjectName As String = ""
    Private _DesktopAlertAssignmentLoadType As Webvantage.DesktopCardsMyAssignments.LoadType = DesktopCardsMyAssignments.LoadType.AlertsAndAssignments

    Private Sub DesktopObjectWindow_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        Try
            ObjectName = qs.GetValue("dtoname").Trim()
        Catch ex As Exception
            Me.ShowMessage("Could not break out desktop object")
            Me.CloseThisWindow()
        End Try
        Try
            If qs.GetValue("title") IsNot Nothing AndAlso qs.GetValue("title").Trim() <> "" Then
                Me.PageTitle = qs.GetValue("title").Trim()
            End If
        Catch ex As Exception
            Me.PageTitle = ""
        End Try
        Try
            If qs.GetValue("card_type") IsNot Nothing AndAlso IsNumeric(qs.GetValue("card_type")) = True Then
                Me._DesktopAlertAssignmentLoadType = CType(CType(qs.GetValue("card_type"), Integer), Webvantage.DesktopCardsMyAssignments.LoadType)
            End If
        Catch ex As Exception
            Me._DesktopAlertAssignmentLoadType = DesktopCardsMyAssignments.LoadType.AlertsAndAssignments
        End Try

        Select Case ObjectName
            Case "DesktopAgencyGoals.ascx"

                Dim ctrl As Webvantage.DesktopAgencyGoals
                ctrl = CType(LoadControl("~\DOS\DesktopAgencyGoals.ascx"), Webvantage.DesktopAgencyGoals)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopAgencyGoalsGraph.ascx"

                Dim ctrl As Webvantage.DesktopAgencyGoalsGraph
                ctrl = CType(LoadControl("~\DOS\DesktopAgencyGoalsGraph.ascx"), Webvantage.DesktopAgencyGoalsGraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopAgencyLinks.ascx"

                Dim ctrl As Webvantage.DesktopAgencyLinks
                ctrl = CType(LoadControl("~\DOS\DesktopAgencyLinks.ascx"), Webvantage.DesktopAgencyLinks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopAlerts.ascx"

                Dim ctrl As Webvantage.DesktopAlerts
                ctrl = CType(LoadControl("~\DOS\DesktopAlerts.ascx"), Webvantage.DesktopAlerts)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.JavascriptAlertTimer = MiscFN.SetJavascriptAlertTimer()

            Case "DesktopAlertSummary.ascx"

                Dim ctrl As Webvantage.DesktopAlertSummary
                ctrl = CType(LoadControl("~\DOS\DesktopAlertSummary.ascx"), Webvantage.DesktopAlertSummary)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.JavascriptAlertTimer = MiscFN.SetJavascriptAlertTimer()

            Case "DesktopAllProjects.ascx"

                Dim ctrl As Webvantage.DesktopAllProjects
                ctrl = CType(LoadControl("~\DOS\DesktopAllProjects.ascx"), Webvantage.DesktopAllProjects)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopARCashForecast.ascx"

                Dim ctrl As Webvantage.DesktopARCashForecast
                If Request.QueryString("from") = "acct" Then
                    Session("DesktopObjectBookmark") = "acct"
                End If
                ctrl = CType(LoadControl("~\DOS\DesktopARCashForecast.ascx"), Webvantage.DesktopARCashForecast)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopARCashForecastProduct.ascx"

                Dim ctrl As Webvantage.DesktopARCashForecastProduct
                ctrl = CType(LoadControl("~\DOS\DesktopARCashForecastProduct.ascx"), Webvantage.DesktopARCashForecastProduct)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopBillableHoursGoal.ascx"

                Dim ctrl As Webvantage.DesktopBillableHoursGoal
                ctrl = CType(LoadControl("~\DOS\DesktopBillableHoursGoal.ascx"), Webvantage.DesktopBillableHoursGoal)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopBillingTrends.ascx"

                Dim ctrl As Webvantage.DesktopBillingTrends
                ctrl = CType(LoadControl("~\DOS\DesktopBillingTrends.ascx"), Webvantage.DesktopBillingTrends)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopBookmarks.ascx"

                Dim ctrl As Webvantage.DesktopBookmarks
                ctrl = CType(LoadControl("~\DOS\DesktopBookmarks.ascx"), Webvantage.DesktopBookmarks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.PageTitle = "Bookmarks"

            Case "DesktopCardsMyAssignments.ascx"

                Select Case Me._DesktopAlertAssignmentLoadType

                    Case DesktopCardsMyAssignments.LoadType.Alerts

                        Me.PageTitle = "My Alerts"

                    Case DesktopCardsMyAssignments.LoadType.Assignments

                        Me.PageTitle = "My Assignments"

                    Case DesktopCardsMyAssignments.LoadType.Reviews

                        Me.PageTitle = "My Reviews"

                End Select

                Dim ctrl As Webvantage.DesktopCardsMyAssignments

                ctrl = CType(LoadControl("~\DOS\DesktopCardsMyAssignments.ascx"), Webvantage.DesktopCardsMyAssignments)
                ctrl.LoadAlertType = Me._DesktopAlertAssignmentLoadType

                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopCardsMyBookmarks.ascx"

                Dim ctrl As Webvantage.DesktopCardsMyBookmarks
                ctrl = CType(LoadControl("~\DOS\DesktopCardsMyBookmarks.ascx"), Webvantage.DesktopCardsMyBookmarks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopCardsMyCalendar.ascx"

                Dim ctrl As Webvantage.DesktopCardsMyCalendar
                ctrl = CType(LoadControl("~\DOS\DesktopCardsMyCalendar.ascx"), Webvantage.DesktopCardsMyCalendar)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.PageTitle = "My Schedule"

            Case "DesktopCardsMyTasks.ascx"

                Dim ctrl As Webvantage.DesktopCardsMyTasks
                ctrl = CType(LoadControl("~\DOS\DesktopCardsMyTasks.ascx"), Webvantage.DesktopCardsMyTasks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.PageTitle = "Tasks (My)"

            Case "DesktopCardsMySummary.ascx"

                Dim ctrl As Webvantage.DesktopCardsMySummary
                ctrl = CType(LoadControl("~\DOS\DesktopCardsMySummary.ascx"), Webvantage.DesktopCardsMySummary)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.PageTitle = Now.DayOfWeek.ToString() & ", " & Now.ToShortDateString() ' & MonthName(Now.Month) & " " & Now.Day.ToString()

            Case "DesktopCashBalance.ascx"

                Dim ctrl As Webvantage.DesktopCashBalance
                ctrl = CType(LoadControl("~\DOS\DesktopCashBalance.ascx"), Webvantage.DesktopCashBalance)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopClientAging.ascx"

                Dim ctrl As Webvantage.DesktopClientAging
                ctrl = CType(LoadControl("~\DOS\DesktopClientAging.ascx"), Webvantage.DesktopClientAging)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopClock.ascx"

                Dim ctrl As Webvantage.DesktopClock
                ctrl = CType(LoadControl("~\DOS\DesktopClock.ascx"), Webvantage.DesktopClock)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopCurrentConditions.ascx"

                Dim ctrl As Webvantage.DesktopCurrentConditions
                ctrl = CType(LoadControl("~\DOS\DesktopCurrentConditions.ascx"), Webvantage.DesktopCurrentConditions)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopCurrentRatio.ascx"

                Dim ctrl As Webvantage.DesktopCurrentRatio
                ctrl = CType(LoadControl("~\DOS\DesktopCurrentRatio.ascx"), Webvantage.DesktopCurrentRatio)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopCurrentRatioGraph.ascx"

                Dim ctrl As Webvantage.DesktopCurrentRatioGraph
                ctrl = CType(LoadControl("~\DOS\DesktopCurrentRatioGraph.ascx"), Webvantage.DesktopCurrentRatioGraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopDirectExpenseAlert.ascx"

                Dim ctrl As Webvantage.DesktopDirectExpenseAlert
                If Request.QueryString("from") = "acct" Then
                    Session("DesktopObjectBookmark") = "acct"
                End If
                ctrl = CType(LoadControl("~\DOS\DesktopDirectExpenseAlert.ascx"), Webvantage.DesktopDirectExpenseAlert)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopEmployeeIndirectTime.ascx"

                Dim ctrl As Webvantage.DesktopEmployeeIndirectTime
                ctrl = CType(LoadControl("~\DOS\DesktopEmployeeIndirectTime.ascx"), Webvantage.DesktopEmployeeIndirectTime)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopEmployeeIndirectTimeAll.ascx"

                Dim ctrl As Webvantage.DesktopEmployeeIndirectTimeAll
                ctrl = CType(LoadControl("~\DOS\DesktopEmployeeIndirectTimeAll.ascx"), Webvantage.DesktopEmployeeIndirectTimeAll)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopExecutiveLinks.ascx"

                Dim ctrl As Webvantage.DesktopExecutiveLinks
                ctrl = CType(LoadControl("~\DOS\DesktopExecutiveLinks.ascx"), Webvantage.DesktopExecutiveLinks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopInOutBoard.ascx"

                Dim ctrl As Webvantage.DesktopInOutBoard
                ctrl = CType(LoadControl("~\DOS\DesktopInOutBoard.ascx"), Webvantage.DesktopInOutBoard)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.JavascriptAlertTimer = MiscFN.SetJavascriptAlertTimer()

            Case "DesktopInOutBoardAll.ascx"

                Dim ctrl As Webvantage.DesktopInOutBoardAll
                ctrl = CType(LoadControl("~\DOS\DesktopInOutBoardAll.ascx"), Webvantage.DesktopInOutBoardAll)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                Me.JavascriptAlertTimer = MiscFN.SetJavascriptAlertTimer()

            Case "DesktopMyARCashForecast.ascx"

                Dim ctrl As Webvantage.DesktopMyARCashForecast
                ctrl = CType(LoadControl("~\DOS\DesktopMyARCashForecast.ascx"), Webvantage.DesktopMyARCashForecast)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyClientAging.ascx"

                Dim ctrl As Webvantage.DesktopMyClientAging
                ctrl = CType(LoadControl("~\DOS\DesktopMyClientAging.ascx"), Webvantage.DesktopMyClientAging)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyDirectExpenseAlert.ascx"

                Dim ctrl As Webvantage.DesktopMyDirectExpenseAlert
                ctrl = CType(LoadControl("~\DOS\DesktopMyDirectExpenseAlert.ascx"), Webvantage.DesktopMyDirectExpenseAlert)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopEmployeeTimeForecast.ascx"

                Dim ctrl As Webvantage.DesktopEmployeeTimeForecast
                ctrl = CType(LoadControl("~\DOS\DesktopEmployeeTimeForecast.ascx"), Webvantage.DesktopEmployeeTimeForecast)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyEmployeeTimeForecast.ascx"

                Dim ctrl As Webvantage.DesktopMyEmployeeTimeForecast
                ctrl = CType(LoadControl("~\DOS\DesktopMyEmployeeTimeForecast.ascx"), Webvantage.DesktopMyEmployeeTimeForecast)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyProjects.ascx"

                Dim ctrl As Webvantage.DesktopMyProjects
                ctrl = CType(LoadControl("~\DOS\DesktopMyProjects.ascx"), Webvantage.DesktopMyProjects)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyQvA.ascx"

                Dim ctrl As Webvantage.DesktopQvA

                ctrl = CType(LoadControl("~\DOS\DesktopQvA.ascx"), Webvantage.DesktopQvA)
                ctrl.CurrentPageMode = DesktopQvA.PageMode.MyQvA

                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyTasks.ascx"

                Dim ctrl As Webvantage.DesktopMyTasks
                ctrl = CType(LoadControl("~\DOS\DesktopMyTasks.ascx"), Webvantage.DesktopMyTasks)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.PageTitle = "Task List (My)"

            Case "DesktopProjectStatistics.ascx"

                Dim ctrl As Webvantage.DesktopProjectStatistics
                ctrl = CType(LoadControl("~\DOS\DesktopProjectStatistics.ascx"), Webvantage.DesktopProjectStatistics)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopProjectStatisticsGraph.ascx"

                Dim ctrl As Webvantage.DesktopProjectStatisticsGraph
                ctrl = CType(LoadControl("~\DOS\DesktopProjectStatisticsGraph.ascx"), Webvantage.DesktopProjectStatisticsGraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopProjectViewpoint.ascx"

                Dim ctrl As Webvantage.DesktopProjectViewpoint
                ctrl = CType(LoadControl("~\DOS\DesktopProjectViewpoint.ascx"), Webvantage.DesktopProjectViewpoint)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopQOTD.ascx"

                Dim ctrl As Webvantage.DesktopQOTD
                ctrl = CType(LoadControl("~\DOS\DesktopQOTD.ascx"), Webvantage.DesktopQOTD)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopQvA.ascx"

                Dim ctrl As Webvantage.DesktopQvA

                ctrl = CType(LoadControl("~\DOS\DesktopQvA.ascx"), Webvantage.DesktopQvA)
                ctrl.CurrentPageMode = DesktopQvA.PageMode.AllQvA

                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopRSS.ascx"

                Dim ctrl As Webvantage.DesktopRSS
                ctrl = CType(LoadControl("~\DOS\DesktopRSS.ascx"), Webvantage.DesktopRSS)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopTaskList.ascx"

                Dim ctrl As Webvantage.DesktopTaskList
                ctrl = CType(LoadControl("~\DOS\DesktopTaskList.ascx"), Webvantage.DesktopTaskList)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopTimesheet.ascx"

                Dim ctrl As Webvantage.DesktopTimesheet
                ctrl = CType(LoadControl("~\DOS\DesktopTimesheet.ascx"), Webvantage.DesktopTimesheet)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopTrafficStatistics.ascx"

                Dim ctrl As Webvantage.DesktopTrafficStatistics
                ctrl = CType(LoadControl("~\DOS\DesktopTrafficStatistics.ascx"), Webvantage.DesktopTrafficStatistics)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopTrafficStatus.ascx"

                Dim ctrl As Webvantage.DesktopTrafficStatus
                ctrl = CType(LoadControl("~\DOS\DesktopTrafficStatus.ascx"), Webvantage.DesktopTrafficStatus)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopUSWeather.ascx"

                Dim ctrl As Webvantage.DesktopUSWeather
                ctrl = CType(LoadControl("~\DOS\DesktopUSWeather.ascx"), Webvantage.DesktopUSWeather)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopWeeklyTimegraph.ascx"

                Dim ctrl As Webvantage.DesktopWeeklyTimegraph
                ctrl = CType(LoadControl("~\DOS\DesktopWeeklyTimegraph.ascx"), Webvantage.DesktopWeeklyTimegraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopWOTD.ascx"

                Dim ctrl As Webvantage.DesktopWOTD
                ctrl = CType(LoadControl("~\DOS\DesktopWOTD.ascx"), Webvantage.DesktopWOTD)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "InOutBoard.ascx"

                Dim ctrl As Webvantage.InOutBoard
                ctrl = CType(LoadControl("~\DOS\InOutBoard.ascx"), Webvantage.InOutBoard)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopOfficeStatisticsV.ascx"

                Dim ctrl As Webvantage.DesktopOfficeStatisticsV
                ctrl = CType(LoadControl("~\DOS\DesktopOfficeStatisticsV.ascx"), Webvantage.DesktopOfficeStatisticsV)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopOfficeStatistics.ascx"

                Dim ctrl As Webvantage.DesktopOfficeStatistics
                ctrl = CType(LoadControl("~\DOS\DesktopOfficeStatistics.ascx"), Webvantage.DesktopOfficeStatistics)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopServiceFee.ascx"

                Dim ctrl As Webvantage.DesktopServiceFee
                ctrl = CType(LoadControl("~\DOS\DesktopServiceFee.ascx"), Webvantage.DesktopServiceFee)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyServiceFee.ascx"

                Dim ctrl As Webvantage.DesktopMyServiceFee
                ctrl = CType(LoadControl("~\DOS\DesktopMyServiceFee.ascx"), Webvantage.DesktopMyServiceFee)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopGrossIncomeGraph.ascx"

                Dim ctrl As Webvantage.DesktopGrossIncomeGraph
                ctrl = CType(LoadControl("~\DOS\DesktopGrossIncomeGraph.ascx"), Webvantage.DesktopGrossIncomeGraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyGrossIncomeGraph.ascx"

                Dim ctrl As Webvantage.DesktopMyGrossIncomeGraph
                ctrl = CType(LoadControl("~\DOS\DesktopMyGrossIncomeGraph.ascx"), Webvantage.DesktopMyGrossIncomeGraph)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)

            Case "DesktopMyJobRequests.ascx"

                Dim ctrl As Webvantage.DesktopMyJobRequests
                ctrl = CType(LoadControl("~\DOS\DesktopMyJobRequests.ascx"), Webvantage.DesktopMyJobRequests)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.PageTitle = "Job Requests (My)"

            Case "DesktopJobRequests.ascx"

                Dim ctrl As Webvantage.DesktopJobRequests
                ctrl = CType(LoadControl("~\DOS\DesktopJobRequests.ascx"), Webvantage.DesktopJobRequests)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.PageTitle = "Job Requests (All)"

            Case "DesktopMyDirectTime.ascx"

                Dim ctrl As Webvantage.DesktopMyDirectTime
                ctrl = CType(LoadControl("~\DOS\DesktopMyDirectTime.ascx"), Webvantage.DesktopMyDirectTime)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.PageTitle = "Direct Time (My)"

            Case "DesktopDirectTime.ascx"

                Dim ctrl As Webvantage.DesktopDirectTime
                ctrl = CType(LoadControl("~\DOS\DesktopDirectTime.ascx"), Webvantage.DesktopDirectTime)
                Me.PlaceHolderUserControl.Controls.Add(ctrl)
                'Me.PageTitle = "Direct Time (All)"

            Case Else

                Me.CloseThisWindow()

        End Select


    End Sub

End Class
