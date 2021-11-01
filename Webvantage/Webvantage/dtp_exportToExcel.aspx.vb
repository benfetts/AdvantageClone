Imports Telerik.Web.UI


Public Class dtp_exportToExcel
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Try
                        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
                        Dim PVExclJobsCompSched As Boolean = False
                        If Not Session("PVExclJobsCompSched") Is Nothing Then
                            PVExclJobsCompSched = Session("PVExclJobsCompSched") = "Y"
                        End If
                        If Request.QueryString("view") = "PV" Then
                            If IsClientPortal = True Then
                                Me.PVRadG.DataSource = cPV.getPVListCP(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"), Session("inclClosedJobsPV"), Session("PVMyProjectsOnly"), Session("UserID"), PVExclJobsCompSched)
                            Else
                                Me.PVRadG.DataSource = cPV.getPVList(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"),
                                                                     Session("inclClosedJobsPV"), Session("PVMyProjectsOnly"), PVExclJobsCompSched, 0, 5000)
                            End If
                            Me.PVRadG.DataBind()
                            Dim sort As String
                            Dim sort2 As String
                            If Not Session("PVDOSortExp") Is Nothing Then
                                If Session("PVDOSortExp") <> "" Then
                                    Dim expr As New Telerik.Web.UI.GridSortExpression
                                    sort = Session("PVDOSortExp").ToString
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
                                        Me.PVRadG.MasterTableView.SortExpressions.AddSortExpression(expr)
                                    Next
                                End If

                            End If
                        ElseIf Request.QueryString("view") = "HV" Then
                            'LoadGridHV()
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim str As String = ""
            If Request.QueryString("view") = "PV" Then

                str = "Project_Viewpoint" & AdvantageFramework.StringUtilities.GUID_Date()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.PVRadG, str)
                PVRadG.MasterTableView.ExportToExcel()
            ElseIf Request.QueryString("view") = "HV" Then
                str = "Hours_Viewpoint" & AdvantageFramework.StringUtilities.GUID_Date()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.HVRadGrid, str)
                HVRadGrid.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub HVRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles HVRadGrid.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
                Dim oPV As cProjectViewpoint = New cProjectViewpoint()
                Dim groupingLevel As Integer
                Dim groupDesc As String
                Dim gridcolGrouping As Telerik.Web.UI.GridColumn

                gridcolGrouping = Me.HVRadGrid.Columns.FindByUniqueName("GROUPING")

                groupingLevel = Session("ProjectViewpointGroupLevel")  '--> 0-none; 1-Function; 2-Job/Comp; 3-Employee
                Select Case groupingLevel
                    Case 0
                        gridcolGrouping.HeaderText = ""
                    Case 1
                        gridcolGrouping.HeaderText = "Function"
                    Case 2
                        gridcolGrouping.HeaderText = "Project"
                    Case 3
                        gridcolGrouping.HeaderText = "Employee"
                End Select
            End If
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
                Dim gridcol_BILLED_AMT As Telerik.Web.UI.GridColumn
                Dim gridcol_UNBILLED_AMT As Telerik.Web.UI.GridColumn
                Dim gridcol_NON_BILLABLE As Telerik.Web.UI.GridColumn
                Dim gridcol_ADJUSTED_AMT As Telerik.Web.UI.GridColumn

                gridcol_BILLED_AMT = Me.HVRadGrid.Columns.FindByUniqueName("BILLED_AMT")
                gridcol_UNBILLED_AMT = Me.HVRadGrid.Columns.FindByUniqueName("UNBILLED_AMT")
                gridcol_NON_BILLABLE = Me.HVRadGrid.Columns.FindByUniqueName("NON_BILLABLE")
                gridcol_ADJUSTED_AMT = Me.HVRadGrid.Columns.FindByUniqueName("ADJUSTED_AMT")

                If Request.QueryString("show") = "0" Then
                    gridcol_BILLED_AMT.Visible = False
                    gridcol_UNBILLED_AMT.Visible = False
                    gridcol_NON_BILLABLE.Visible = False
                    gridcol_ADJUSTED_AMT.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HVRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles HVRadGrid.NeedDataSource
        Try
            Dim oPV As cProjectViewpoint = New cProjectViewpoint()
            Dim groupingLevel As Integer

            groupingLevel = Session("ProjectViewpointGroupLevel")  '--> 0-none; 1-Function; 2-Job/Comp; 3-Employee

            Me.HVRadGrid.DataSource = oPV.getHoursViewpointDS(CStr(groupingLevel))

            Dim sort As String
            Dim sort2 As String
            If Not Session("HVDOSortExp") Is Nothing Then
                If Session("HVDOSortExp") <> "" Then
                    Dim expr As New Telerik.Web.UI.GridSortExpression
                    sort = Session("HVDOSortExp").ToString
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
                        Me.HVRadGrid.MasterTableView.SortExpressions.AddSortExpression(expr)
                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PVRadG_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles PVRadG.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
            Dim StartDateDisplay As String = ""
            Dim DueDateDisplay As String = "--"
            Dim CompletedDateDisplay As String = "--"

            If Not e.Item.DataItem("JC_START_DATE") Is Nothing _
            AndAlso IsDBNull(e.Item.DataItem("JC_START_DATE")) = False _
            AndAlso IsDate(e.Item.DataItem("JC_START_DATE")) = True Then

                StartDateDisplay = CType(e.Item.DataItem("JC_START_DATE"), Date).ToShortDateString()
                CurrentGridRow("openClosed").Text = StartDateDisplay

            End If


            If Not e.Item.DataItem("JOB_FIRST_USE_DATE") Is Nothing _
                        AndAlso IsDBNull(e.Item.DataItem("JOB_FIRST_USE_DATE")) = False _
                        AndAlso IsDate(e.Item.DataItem("JOB_FIRST_USE_DATE")) = True Then

                DueDateDisplay = CType(e.Item.DataItem("JOB_FIRST_USE_DATE"), Date).ToShortDateString()

            End If

            If Not e.Item.DataItem("COMPLETED_DATE") Is Nothing _
                        AndAlso IsDBNull(e.Item.DataItem("COMPLETED_DATE")) = False _
                        AndAlso IsDate(e.Item.DataItem("COMPLETED_DATE")) = True Then

                CompletedDateDisplay = CType(e.Item.DataItem("COMPLETED_DATE"), Date).ToShortDateString()

            End If

            If DueDateDisplay = "--" And CompletedDateDisplay = "--" Then

                CurrentGridRow("DueActualDate").Text = "&nbsp;"

            Else

                CurrentGridRow("DueActualDate").Text = DueDateDisplay & "<br />" & CompletedDateDisplay

            End If

        End If

    End Sub

End Class