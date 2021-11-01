Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure
Public Class dtp_tasks
    Inherits Webvantage.BaseChildPage

    Private Sub RadGridTaskList_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles RadGridTaskList.BiffExporting
        Try
            'Client
            Dim col As Column = e.ExportStructure.Tables(0).Columns(2)
            col.Width = 150
            'Project
            col = e.ExportStructure.Tables(0).Columns(3)
            col.Width = 300
            'Job/Comp
            col = e.ExportStructure.Tables(0).Columns(4)
            col.Width = 100
            'Job Description
            col = e.ExportStructure.Tables(0).Columns(5)
            col.Width = 250
            'Comp Description
            col = e.ExportStructure.Tables(0).Columns(6)
            col.Width = 250
            'Task
            col = e.ExportStructure.Tables(0).Columns(7)
            col.Width = 300
            'Task Comment
            col = e.ExportStructure.Tables(0).Columns(8)
            col.Width = 300
            'Hours
            col = e.ExportStructure.Tables(0).Columns(9)
            col.Width = 70
            'Start
            col = e.ExportStructure.Tables(0).Columns(10)
            col.Width = 70
            'Due
            col = e.ExportStructure.Tables(0).Columns(11)
            col.Width = 70
            'Due by
            col = e.ExportStructure.Tables(0).Columns(12)
            col.Width = 70
            'Status
            col = e.ExportStructure.Tables(0).Columns(13)
            col.Width = 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTaskList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTaskList.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)
            Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

            If IsDBNull(e.Item.DataItem("DueDate")) = False Then

                AdvantageFramework.Web.Presentation.Controls.SetDue(e.Item.DataItem("DueDate"), "column78", GridRow)

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

            End If
            If Not e.Item.DataItem("TempCompleteDate") Is System.DBNull.Value Then
                e.Item.Font.Strikeout = True
                Dim i As Int16
                For i = 0 To e.Item.Cells.Count - 1
                    e.Item.Cells(i).Font.Strikeout = True
                Next
            End If

            Dim TaskStatus As String = e.Item.DataItem("TASK_STATUS").ToString

            Dim PriorityColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivPriorityColor")
            Dim PriorityImage As Web.UI.WebControls.Image = e.Item.FindControl("ImagePriority")

            If TaskStatus = "H" Then
                e.Item.Cells(14).Text = "High Priority"
                PriorityImage.ToolTip = "High Priority"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
            ElseIf TaskStatus = "L" Then
                e.Item.Cells(14).Text = "Low Priority"
                PriorityImage.ToolTip = "Low Priority"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
            ElseIf TaskStatus = "A" Then
                e.Item.Cells(14).Text = "Active"
                PriorityImage.ToolTip = "Active"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-active")
            ElseIf TaskStatus = "P" Then
                e.Item.Cells(14).Text = "Projected"
                PriorityImage.ToolTip = "Projected"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-pending")
            Else
                AdvantageFramework.Web.Presentation.Controls.DivHide(PriorityColorDiv)
            End If

        End If
    End Sub

    Private Sub RadGridTaskList_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTaskList.NeedDataSource
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim show As String = ""
        Dim search As String = ""
        Dim ColDate As GridBoundColumn

        ColDate = CType(Me.RadGridTaskList.Columns(9), GridBoundColumn)
        ColDate.DataFormatString = "{0:" & System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern() & "}"

        ColDate = CType(Me.RadGridTaskList.Columns(10), GridBoundColumn)
        ColDate.DataFormatString = "{0:" & System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern() & "}"

        Try
            show = otask.getAppVars(Session("UserCode"), "MyTasks", "ddTaskShow")
        Catch ex As Exception
            show = ""
        End Try

        If show <> "Today" Then
            show = ""
        End If

        search = otask.getAppVars(Session("UserCode"), "MyTasks", "sSearch")

        Select Case (UCase(otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")))
            Case "PROJECTED"
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "P", show, search, Me.IsClientPortal, Session("UserID"))
            Case "ACTIVE"
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "A", show, search, Me.IsClientPortal, Session("UserID"))
            Case "EVENT_TASKS"
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "E", show, search, Me.IsClientPortal, Session("UserID"))
            Case "H"
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "H", show, search, Me.IsClientPortal, Session("UserID"))
            Case "L"
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "L", show, search, Me.IsClientPortal, Session("UserID"))
            Case Else
                Me.RadGridTaskList.DataSource = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "", show, search, Me.IsClientPortal, Session("UserID"))
        End Select

        Dim sort As String
        Dim sort2 As String

        If Not Session("TasksDOSortExp") Is Nothing Then
            If Session("TasksDOSortExp") <> "" Then
                Dim expr As New GridSortExpression
                sort = Session("TasksDOSortExp").ToString
                'sort = sort.Substring(0, sort.Length - 1)
                Dim sortexpr() As String = sort.Split(",")
                For i As Integer = 0 To sortexpr.Length - 1
                    sortexpr(i) = sortexpr(i).Trim
                    Dim sortstr() As String = sortexpr(i).Split(" ")
                    expr = New GridSortExpression
                    expr.FieldName = sortstr(0).Trim
                    If sortstr(1).Trim = "ASC" Then
                        expr.SortOrder = GridSortOrder.Ascending
                    ElseIf sortstr(1).Trim = "DESC" Then
                        expr.SortOrder = GridSortOrder.Descending
                    Else
                        expr.SortOrder = GridSortOrder.None
                    End If
                    Me.RadGridTaskList.MasterTableView.SortExpressions.AddSortExpression(expr)
                Next
            End If
        End If

    End Sub

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "MyTaskList" & AdvantageFramework.StringUtilities.GUID_Date()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridTaskList, str, True, False)
                Me.RadGridTaskList.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
