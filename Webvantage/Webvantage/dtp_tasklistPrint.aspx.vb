Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure


Partial Public Class dt_tasklistPrint
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim sortstr As String
        Dim sortarr(10) As String
        Dim sortExpr(2) As String
        Dim sortOrder As String
        Dim sortIdx, sortCount As Integer
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim sEmployee, sRole, dDateStart, dDateDue, sManager, sOffice, sStatus, sSearch, sAcctExec As String
        Dim onlymarkedtempcomplete, excludeunassigned, onlyunassigned As Boolean
        Dim ColDate As GridBoundColumn

        Dim str As String = String.Empty
        Dim strtype As String = String.Empty
        Dim taskVar As String
        str = "Date Range:  "
        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "dDateStart")
        If taskVar <> "" Then
            str &= LoGlo.FormatDate(taskVar)
        End If
        str &= " - "
        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "dDateDue")
        If taskVar <> "" Then
            str &= LoGlo.FormatDate(taskVar)
        End If

        Me.Label.Text = str

        sEmployee = otask.getAppVars(Session("UserCode"), "TaskList", "sEmployee")
        If sEmployee = "" Then
            sEmployee = "All"
        End If

        dDateStart = otask.getAppVars(Session("UserCode"), "TaskList", "dDateStart")
        dDateDue = otask.getAppVars(Session("UserCode"), "TaskList", "dDateDue")
        If dDateStart = "" Or dDateDue = "" Then
            Dim weekday As Int16
            Dim strt_date As Date

            weekday = Date.Today.DayOfWeek
            If weekday > 0 Then
                weekday = 0 - weekday
                strt_date = Date.Today.AddDays(weekday)
            Else
                strt_date = Today()
            End If

            dDateStart = strt_date
            dDateDue = strt_date.AddDays(6)
        End If

        sRole = otask.getAppVars(Session("UserCode"), "TaskList", "sRole")
        If sRole = "" Then
            sRole = "All"
        End If

        sManager = otask.getAppVars(Session("UserCode"), "TaskList", "sManager")
        If sManager = "" Then
            sManager = "All"
        End If

        sAcctExec = otask.getAppVars(Session("UserCode"), "TaskList", "sAcctExec")
        If sAcctExec = "" Then
            sAcctExec = "All"
        End If

        sOffice = otask.getAppVars(Session("UserCode"), "TaskList", "sOffice")
        If sOffice = "" Then
            sOffice = "All"
        End If

        sStatus = otask.getAppVars(Session("UserCode"), "TaskList", "sStatus")
        sSearch = otask.getAppVars(Session("UserCode"), "TaskList", "sSearch")

        Try
            If otask.getAppVars(Session("UserCode"), "TaskList", "OnlyMarkedComplete") <> "" Then
                onlymarkedtempcomplete = CType(otask.getAppVars(Session("UserCode"), "TaskList", "OnlyMarkedComplete"), Boolean)
            End If
            If otask.getAppVars(Session("UserCode"), "TaskList", "ExcludeUnassigned") <> "" Then
                excludeunassigned = CType(otask.getAppVars(Session("UserCode"), "TaskList", "ExcludeUnassigned"), Boolean)
            End If
            If otask.getAppVars(Session("UserCode"), "TaskList", "OnlyUnassigned") <> "" Then
                onlyunassigned = CType(otask.getAppVars(Session("UserCode"), "TaskList", "OnlyUnassigned"), Boolean)
            End If
        Catch ex As Exception

        End Try

        Dim filter As String = ""
        Dim dt As New DataTable
        dt = oDO.GetTasksNew(CStr(Session("UserCode")), sEmployee, sRole, dDateStart, dDateDue, sManager, sOffice, sStatus, sSearch, sAcctExec)
        Dim dv As New DataView(dt)

        If onlymarkedtempcomplete = True Then
            filter = "(NOT(TempCompleteDate IS NULL))"
        End If
        If excludeunassigned = True Then
            If filter = "" Then
                filter = "(EmpCode <> '')"
            Else
                filter &= " AND (EmpCode <> '')"
            End If
        End If
        If onlyunassigned = True Then
            If filter = "" Then
                filter = "(EmpCode = '')"
            Else
                filter &= " AND (EmpCode = '')"
            End If
        End If
        dv.RowFilter = filter
        Me.TasksRG.DataSource = dv
        
        sortstr = Session("TskLstSortExpr")
        sortCount = Session("TskLstSortCt")

        If sortstr <> Nothing And sortstr <> "" Then

            sortarr = sortstr.Split(",")

            For sortIdx = 0 To sortCount - 1
                Dim expression As Telerik.Web.UI.GridSortExpression = New Telerik.Web.UI.GridSortExpression

                sortstr = sortarr(sortIdx).Trim
                sortExpr = sortstr.Split(" ")

                expression.FieldName = sortExpr(0)

                sortOrder = sortExpr(1)
                If sortOrder = "ASC" Then
                    expression.SortOrder = Telerik.Web.UI.GridSortOrder.Ascending
                Else
                    expression.SortOrder = Telerik.Web.UI.GridSortOrder.Descending
                End If

                Me.TasksRG.MasterTableView.SortExpressions.AddSortExpression(expression)

            Next
        End If


        Me.TasksRG.DataBind()

        Dim sort As String
        Dim sort2 As String
        If Not Session("TasksListDOSortExp") Is Nothing Then
            If Session("TasksListDOSortExp") <> "" Then
                Dim expr As New Telerik.Web.UI.GridSortExpression
                sort = Session("TasksListDOSortExp").ToString
                'sort = sort.Substring(0, sort.Length - 1)
                Dim sortexpr2() As String = sort.Split(",")
                For i As Integer = 0 To sortexpr2.Length - 1
                    sortexpr2(i) = sortexpr2(i).Trim
                    Dim sortstr2() As String = sortexpr2(i).Split(" ")
                    expr = New Telerik.Web.UI.GridSortExpression
                    expr.FieldName = sortstr2(0).Trim
                    If sortstr2(1).Trim = "ASC" Then
                        expr.SortOrder = GridSortOrder.Ascending
                    ElseIf sortstr2(1).Trim = "DESC" Then
                        expr.SortOrder = GridSortOrder.Descending
                    Else
                        expr.SortOrder = GridSortOrder.None
                    End If
                    Me.TasksRG.MasterTableView.SortExpressions.AddSortExpression(expr)
                Next
            End If

        End If

        ColDate = CType(Me.TasksRG.Columns(10), GridBoundColumn)
        ColDate.DataFormatString = "{0:" & System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern() & "}"

        ColDate = CType(Me.TasksRG.Columns(11), GridBoundColumn)
        ColDate.DataFormatString = "{0:" & System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern() & "}"

        Me.TasksRG.Rebind()

    End Sub

    Private Sub TasksRG_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles TasksRG.BiffExporting
        Try
            Dim col As Column = e.ExportStructure.Tables(0).Columns(2)
            col.Width = 120
            col = e.ExportStructure.Tables(0).Columns(3)
            col.Width = 150
            col = e.ExportStructure.Tables(0).Columns(4)
            col.Width = 300
            col = e.ExportStructure.Tables(0).Columns(5)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(6)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(7)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(8)
            col.Width = 300
            col = e.ExportStructure.Tables(0).Columns(9)
            col.Width = 300
            col = e.ExportStructure.Tables(0).Columns(10)
            col.Width = 50
            col = e.ExportStructure.Tables(0).Columns(11)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(12)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(13)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(14)
            col.Width = 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TasksRG_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles TasksRG.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)
            If IsDBNull(e.Item.DataItem("DueDate")) = False Then

                AdvantageFramework.Web.Presentation.Controls.SetDue(e.Item.DataItem("DueDate"), "column66", GridRow)

            Else

                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

            End If

            If Not e.Item.DataItem("TempCompleteDate") Is System.DBNull.Value Then
                e.Item.Font.Strikeout = True

                Dim i As Int16
                For i = 0 To e.Item.Cells.Count - 1
                    e.Item.Cells(i).Font.Strikeout = True
                Next
            End If
            Dim str As String = e.Item.Cells(5).Text
            Dim str2 As String = e.Item.Cells(6).Text
            Dim str3 As String = e.Item.Cells(13).Text

            Dim PriorityColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivPriorityColor")
            Dim PriorityImage As Web.UI.WebControls.Image = e.Item.FindControl("ImagePriority")

            If e.Item.DataItem("TASK_STATUS").ToString.ToUpper = "H" Then
                e.Item.Cells(15).Text = "High Priority"
                PriorityImage.ToolTip = "High Priority"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
            ElseIf e.Item.DataItem("TASK_STATUS").ToString.ToUpper = "L" Then
                e.Item.Cells(15).Text = "Low Priority"
                PriorityImage.ToolTip = "Low Priority"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
            ElseIf e.Item.DataItem("TASK_STATUS").ToString.ToUpper = "A" Then
                e.Item.Cells(15).Text = "Active"
                PriorityImage.ToolTip = "Active"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-active")
            ElseIf e.Item.DataItem("TASK_STATUS").ToString.ToUpper = "P" Then
                e.Item.Cells(15).Text = "Projected"
                PriorityImage.ToolTip = "Projected"
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-pending")
            Else
                AdvantageFramework.Web.Presentation.Controls.DivHide(PriorityColorDiv)
            End If

            If e.Item.Cells(12).Text <> "" And e.Item.Cells(12).Text <> "&nbsp;" Then
                e.Item.Cells(12).Text = LoGlo.FormatDate(e.Item.Cells(12).Text) ' CDate(e.Item.Cells(11).Text).ToShortDateString
            End If
            If e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then
                e.Item.Cells(13).Text = LoGlo.FormatDate(e.Item.Cells(13).Text) 'CDate(e.Item.Cells(12).Text).ToShortDateString
            End If


            'Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            'Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(CInt(e.Item.DataItem("JobNo")), CInt(e.Item.DataItem("JobComp")), CInt(e.Item.DataItem("SeqNo")))
            'If strEmps <> "" Then
            '    e.Item.Cells(2).Text = strEmps
            'End If
        End If
    End Sub

    Private Sub dt_tasklistPrint_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "TaskList" & AdvantageFramework.StringUtilities.GUID_Date()
                Me.TasksRG.MasterTableView.Caption = "Task List - " & Me.Label.Text
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.TasksRG, str, True, False)
                If Me.TasksRG.MasterTableView.Items.Count > 0 Then
                    TasksRG.MasterTableView.ExportToExcel()
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
