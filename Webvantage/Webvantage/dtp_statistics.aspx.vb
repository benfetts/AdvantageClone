Imports Telerik.Web.UI
Public Class dtp_statistics
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim str As String = ""
            If Request.QueryString("export") = 1 Then
                If Request.QueryString("DO") = "officeV" Then
                    str = "OfficeStatistics_" & AdvantageFramework.StringUtilities.GUID_Date()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.OfficeStatsRadGridV, str)
                    Me.OfficeStatsRadGridV.MasterTableView.ExportToExcel()
                Else
                    str = "OfficeStatistics_" & AdvantageFramework.StringUtilities.GUID_Date()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.OfficeStatsRadGrid, str)
                    Me.OfficeStatsRadGrid.MasterTableView.ExportToExcel()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OfficeStatsRadGrid_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles OfficeStatsRadGrid.NeedDataSource
        Try
            Me.OfficeStatsRadGrid.DataSource = Me.CreateOfficeDT
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreateOfficeDT()
        Try
            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim sDate As Date = Nothing
            Dim eDate As Date = Nothing
            Dim ds As DataTable
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            Dim emp As String
            Dim traffic As String
            Dim chkclosedstatus As Boolean
            Dim manager As String

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sEmployee")
            If taskVar <> "" Then
                emp = taskVar
            Else
                emp = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sDropTrafficFunctions")
            If taskVar <> "" Then
                traffic = taskVar
            Else
                traffic = "none"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sChkClosedStatus")
            If taskVar <> "" Then
                chkclosedstatus = taskVar
            Else
                chkclosedstatus = False
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sManager")
            If taskVar <> "" Then
                manager = taskVar
            Else
                manager = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sDateStart")
            If taskVar <> "" Then
                sdate = LoGlo.FormatDate(taskVar)
            Else
                sdate = LoGlo.FirstOfMonth()
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatistics", "sDateEnd")
            If taskVar <> "" Then
                edate = LoGlo.FormatDate(taskVar)
            Else
                edate = LoGlo.LastOfMonth()
            End If
            
            If Me.IsClientPortal = True Then
                'ds = oDTO.GetJobStatisticsCP(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
            Else
                ds = oDTO.GetOfficeStatistics(Session("UserCode"), sDate, eDate, traffic, chkclosedstatus, emp, manager)
            End If
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                If i > ds.Rows.Count - 1 Then
                    Exit For
                End If
                If ds.Rows(i)(2).ToString() = "0" And ds.Rows(i)(3).ToString() = "0" And ds.Rows(i)(4).ToString() = "0" And ds.Rows(i)(5).ToString() = "0" And ds.Rows(i)(6).ToString() = "0" Then
                    ds.Rows.Remove(ds.Rows(i))
                    i = -1
                End If
            Next

            Dim dt As DataTable
            Dim row As DataRow
            Dim col As DataColumn
            Dim cancel As Boolean = False

            dt = New DataTable("office")
            col = New DataColumn("Type")
            dt.Columns.Add(col)
            For j As Integer = 0 To ds.Rows.Count - 1
                col = New DataColumn(ds.Rows(j)("OFFICE_DESCRIPT").ToString)
                dt.Columns.Add(col)
            Next
            For k As Integer = 2 To ds.Columns.Count - 1
                row = dt.NewRow
                If ds.Columns(k).ColumnName = "JOBS_CREATED" Then
                    row.Item("Type") = "Created"
                End If
                If ds.Columns(k).ColumnName = "JOBS_COMPLETED" Then
                    row.Item("Type") = "Completed"
                End If
                If ds.Columns(k).ColumnName = "JOBS_CANCELLED" Then
                    If traffic <> "none" And chkclosedstatus = False Then
                        row.Item("Type") = "Status<br />(" & traffic & ")"
                    ElseIf traffic <> "none" And chkclosedstatus = True Then
                        row.Item("Type") = "Cancelled"
                    Else
                        row.Item("Type") = ds.Columns(k).ColumnName
                    End If
                End If
                If ds.Columns(k).ColumnName = "JOBS_DUE" Then
                    row.Item("Type") = "Due"
                End If
                If ds.Columns(k).ColumnName = "JOBS_IN_PROGRESS" Then
                    row.Item("Type") = "In Progress"
                End If
                For m As Integer = 0 To ds.Rows.Count - 1
                    row.Item(m + 1) = ds.Rows(m)(k).ToString
                Next

                dt.Rows.Add(row)
            Next

            If traffic = "none" Then
                Dim dtr As DataRow
                For x As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(x)("Type").ToString = "JOBS_CANCELLED" Then
                        dtr = dt.Rows(x)
                    End If
                Next
                dt.Rows.Remove(dtr)
            End If

            Return dt
        Catch ex As Exception

        End Try
    End Function

    Private Sub OfficeStatsRadGridV_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles OfficeStatsRadGridV.NeedDataSource
        Try
            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim sDate As Date = Nothing
            Dim eDate As Date = Nothing
            Dim ds As DataTable
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            Dim emp As String
            Dim traffic As String
            Dim chkclosedstatus As Boolean
            Dim manager As String

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sEmployee")
            If taskVar <> "" Then
                emp = taskVar
            Else
                emp = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDropTrafficFunctions")
            If taskVar <> "" Then
                traffic = taskVar
            Else
                traffic = "none"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sChkClosedStatus")
            If taskVar <> "" Then
                chkclosedstatus = taskVar
            Else
                chkclosedstatus = False
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sManager")
            If taskVar <> "" Then
                manager = taskVar
            Else
                manager = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateStart")
            If taskVar <> "" Then
                sDate = LoGlo.FormatDate(taskVar)
            Else
                sDate = LoGlo.FirstOfMonth()
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateEnd")
            If taskVar <> "" Then
                eDate = LoGlo.FormatDate(taskVar)
            Else
                eDate = LoGlo.LastOfMonth()
            End If
            If Me.IsClientPortal = True Then
                'ds = oDTO.GetJobStatisticsCP(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
            Else
                ds = oDTO.GetOfficeStatistics(Session("UserCode"), sDate, eDate, traffic, chkclosedstatus, emp, manager)
            End If
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                If i > ds.Rows.Count - 1 Then
                    Exit For
                End If
                If ds.Rows(i)(2).ToString() = "0" And ds.Rows(i)(3).ToString() = "0" And ds.Rows(i)(4).ToString() = "0" And ds.Rows(i)(5).ToString() = "0" And ds.Rows(i)(6).ToString() = "0" Then
                    ds.Rows.Remove(ds.Rows(i))
                    i = -1
                End If
            Next
            Me.OfficeStatsRadGridV.DataSource = ds

            If traffic <> "none" And chkclosedstatus = False Then
                Me.OfficeStatsRadGridV.MasterTableView.GetColumn("colCancelled").HeaderText = "Status<br />(" & traffic & ")"
                'Me.RadGridJobStats.MasterTableView.GetColumn("colCancelled").HeaderText = Me.DropTrafficFunctions.SelectedItem.Text.ToString
            ElseIf traffic <> "none" And chkclosedstatus = True Then
                Me.OfficeStatsRadGridV.MasterTableView.GetColumn("colCancelled").HeaderText = "Cancelled"
            End If

            If traffic = "none" Then
                Me.OfficeStatsRadGridV.MasterTableView.GetColumn("colCancelled").Display = False
            Else
                Me.OfficeStatsRadGridV.MasterTableView.GetColumn("colCancelled").Display = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class