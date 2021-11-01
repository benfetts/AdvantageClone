Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class dtp_BudgetViewpoint
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim mth1, mth2, yr1, yr2, PVForecast As String
            Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
            appVars.getAllAppVars()
            Dim tempDate As Date

            mth1 = CType(appVars.getAppVar("PVMonth"), String)
            yr1 = CType(appVars.getAppVar("PVYear"), String)
            mth2 = CType(appVars.getAppVar("PVMonth2"), String)
            yr2 = CType(appVars.getAppVar("PVYear2"), String)

            If mth1 = "" Or yr1 = "" Then
                tempDate = cEmployee.TimeZoneToday
                mth1 = CStr(tempDate.Month)
                yr1 = CStr(tempDate.Year)
            End If


            If mth2 = "" Or yr2 = "" Then
                tempDate = cEmployee.TimeZoneToday
                mth2 = CStr(tempDate.Month)
                yr2 = CStr(tempDate.Year)
            End If

            PVForecast = appVars.getAppVar("PVForecast", "Number")
            Me.Label1.Text = "Budget Viewpoint for Periods " & yr1 & mth1.ToString.PadLeft(2, "0") & " - " & yr2 & mth2.ToString.PadLeft(2, "0")

        End If

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try

            If Request.QueryString("view") = "BV" Then
                Dim str As String = "Budget_Viewpoint" & AdvantageFramework.StringUtilities.GUID_Date()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.BVRadGrid, str)
                BVRadGrid.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BVRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles BVRadGrid.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
                Dim oPV As cProjectViewpoint = New cProjectViewpoint()
                Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
                appVars.getAllAppVars()
                Dim cdpLevel As Integer
                Dim PVForecast As String
                PVForecast = appVars.getAppVar("PVForecast", "Number")

                Dim gridcolBilling As Telerik.Web.UI.GridColumn
                Dim gridcolGI As Telerik.Web.UI.GridColumn
                gridcolBilling = Me.BVRadGrid.Columns.FindByUniqueName("ACTUAL_BILLING")
                gridcolGI = Me.BVRadGrid.Columns.FindByUniqueName("ACTUAL_GI")

                Select Case PVForecast
                    Case 0
                        gridcolBilling.HeaderText = "Actual Billed<br/>Billing"
                        gridcolGI.HeaderText = "Actual Billed<br/>Gross Income"

                    Case 1
                        gridcolBilling.HeaderText = "Actual Posted<br/>Billing"
                        gridcolGI.HeaderText = "Actual Posted<br/>Gross Income"

                    Case Else
                        gridcolBilling.HeaderText = "Forecasted<br/>Billing"
                        gridcolGI.HeaderText = "Forecasted<br/>Gross Income"
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BVRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles BVRadGrid.NeedDataSource
        Try
            Dim oPV As cProjectViewpoint = New cProjectViewpoint()
            Dim cdpLevel As Integer

            If Not Session("ProjectViewpointGroup") Is Nothing Then
                cdpLevel = Session("ProjectViewpointGroup")   '1-All	2-Type	3-Sales Class
            Else
                cdpLevel = 1
            End If

            Me.BVRadGrid.DataSource = oPV.getBudgetViewpointDS(cdpLevel)
            Dim sort As String
            Dim sort2 As String
            If Not Session("BVDOSortExp") Is Nothing Then
                If Session("BVDOSortExp") <> "" Then
                    Dim expr As New Telerik.Web.UI.GridSortExpression
                    sort = Session("BVDOSortExp").ToString
                    'sort = sort.Substring(0, sort.Length - 1)
                    Dim sortexpr() As String = sort.Split(",")
                    For i As Integer = 0 To sortexpr.Length - 1
                        sortexpr(i) = sortexpr(i).Trim
                        Dim sortstr() As String = sortexpr(i).Split(" ")
                        expr = New Telerik.Web.UI.GridSortExpression
                        expr.FieldName = sortstr(0).Trim
                        If sortstr(1).Trim = "ASC" Then
                            expr.SortOrder = GridSortOrder.Ascending
                        ElseIf sortstr(1).Trim = "DESC" Then
                            expr.SortOrder = GridSortOrder.Descending
                        Else
                            expr.SortOrder = GridSortOrder.None
                        End If
                        Me.BVRadGrid.MasterTableView.SortExpressions.AddSortExpression(expr)
                    Next
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

End Class