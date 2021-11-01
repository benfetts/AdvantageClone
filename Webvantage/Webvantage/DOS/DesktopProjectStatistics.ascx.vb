Imports System.Data
Imports System.Data.SqlClient

Partial Public Class DesktopProjectStatistics
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me.DropTrafficFunctions.Items.Count <= 0 Then
                LoadTrafficStatus()
            End If
            If Me.ClientDropDownList.Items.Count <= 0 Then
                LoadClientDropdownlist()
            End If
            If Not Me.IsPostBack Then
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()
                LoadDropDowns()
                Dim s As New cSchedule()
                Me.LabelManager.Text = s.GetManagerLabel() & ":"
                LoadSelections()
                LoadData()
                LoadGrid()

            End If
            If Me.DropTrafficFunctions.SelectedIndex = 0 Then
                Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").Display = False
            Else
                Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").Display = True
            End If
            If Me.IsClientPortal = True Then
                Me.ClientDropDownList.Visible = False
                Me.ImageButtonBookmark.Visible = False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadClientDropdownlist()
        Try
            ' Me.ClientDropDownList.Items.Clear()
            Dim cli As String
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Me.ClientDropDownList.DataSource = oDD.GetClientList(Session("UserCode"))
            Me.ClientDropDownList.DataTextField = "Description"
            Me.ClientDropDownList.DataValueField = "Code"
            Me.ClientDropDownList.DataBind()
            Me.ClientDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", "ALL"))
            'Dim Security As New SEC_CLIENT(Session("ConnString"))
            'Security.Where.USER_ID.Value = Session("UserCode")
            'Dim clients As New CLIENT(Session("ConnString"))
            'If Security.Query.Load Then
            '    cli = ""
            '    Do Until Security.EOF
            '        If cli <> Security.CL_CODE Then
            '            clients = New CLIENT(Session("ConnString"))
            '            clients.Where.CL_CODE.Value = Security.CL_CODE
            '            cli = Security.CL_CODE
            '            clients.Where.ACTIVE_FLAG.Value = 1
            '            clients.Query.Load()
            '            Do Until clients.EOF
            '                Me.ClientDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(clients.CL_CODE & " - " & clients.CL_NAME, clients.CL_CODE))
            '                clients.MoveNext()
            '            Loop
            '        End If
            '        Security.MoveNext()
            '    Loop
            'Else
            '    clients.Where.ACTIVE_FLAG.Value = 1
            '    clients.Query.Load()
            '    Do Until clients.EOF
            '        Me.ClientDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(clients.CL_CODE & " - " & clients.CL_NAME, clients.CL_CODE))
            '        clients.MoveNext()
            '    Loop
            'End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
    Private Sub LoadGrid()
        If Me.DropTrafficFunctions.SelectedIndex > 0 And Me.ChkIsClosedStatus.Checked = False Then
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").HeaderText = "Status<br />(" & Me.DropTrafficFunctions.SelectedValue.ToString() & ")"
        ElseIf Me.DropTrafficFunctions.SelectedIndex > 0 And Me.ChkIsClosedStatus.Checked = True Then
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").HeaderText = "Cancelled"
        End If
        Me.JobStatsRadGrid.Rebind()
    End Sub

    Private Sub LoadTrafficStatus()
        Try
            Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem("[Select A Status]", "none"))
            Dim od As Webvantage.cDropDowns = New Webvantage.cDropDowns(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = od.GetTrafficCodes
            If dr.HasRows Then
                Do While dr.Read
                    Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dr(1).ToString(), dr(0).ToString()))
                Loop
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddEmployee
            .DataSource = oDD.GetAccountExecs(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddManager
            .DataSource = oDD.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

    End Sub

    Public Sub LoadSelections()
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sEmployee")
            If taskVar <> "" Then
                Me.ddEmployee.SelectedValue = taskVar
            Else
                Me.ddEmployee.SelectedValue = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatisticsGraph", "sClient")
            If taskVar <> "" Then
                Me.ClientDropDownList.SelectedValue = taskVar
            Else
                Me.ClientDropDownList.SelectedValue = "ALL"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sDropTrafficFunctions")
            If taskVar <> "" Then
                Me.DropTrafficFunctions.SelectedValue = taskVar
            Else
                Me.DropTrafficFunctions.SelectedValue = "none"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sChkClosedStatus")
            If taskVar <> "" Then
                Me.ChkIsClosedStatus.Checked = taskVar
            Else
                Me.ChkIsClosedStatus.Checked = False
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sManager")
            If taskVar <> "" Then
                Me.ddManager.SelectedValue = taskVar
            Else
                Me.ddManager.SelectedValue = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sDateStart")
            If taskVar <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(taskVar)
            Else
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "ProjectStatistics", "sDateEnd")
            If taskVar <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(taskVar)
            Else
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub butrefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butrefresh.Click
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDropTrafficFunctions", "", Me.DropTrafficFunctions.SelectedValue)
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sChkClosedStatus", "", Me.ChkIsClosedStatus.Checked)
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sEmployee", "", Me.ddEmployee.SelectedValue)
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sManager", "", Me.ddManager.SelectedValue)
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDateStart", "", Me.RadDatePickerStartDate.SelectedDate)
            otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDateEnd", "", Me.RadDatePickerEndDate.SelectedDate)
            LoadGrid()
            LoadData()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DropTrafficFunctions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropTrafficFunctions.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDropTrafficFunctions", "", Me.DropTrafficFunctions.SelectedValue)
        LoadGrid()
        LoadData()
    End Sub
    Private Sub ChkIsClosedStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIsClosedStatus.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sChkClosedStatus", "", Me.ChkIsClosedStatus.Checked)
        LoadGrid()
        LoadData()
    End Sub

    Private Sub JobStatsRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles JobStatsRadGrid.NeedDataSource
        Try
            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim sDate As Date = Nothing
            Dim eDate As Date = Nothing
            Dim ds As DataTable
            If Me.RadDatePickerStartDate.SelectedDate = Nothing Then
                sDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerStartDate.SelectedDate = sDate
                Me.RadDatePickerStartDate.DateInput.Text = LoGlo.FormatDate(sDate)
            Else
                sDate = Me.RadDatePickerStartDate.SelectedDate
            End If
            If Me.RadDatePickerEndDate.SelectedDate = Nothing Then
                eDate = LoGlo.LastOfMonth()
                Me.RadDatePickerEndDate.SelectedDate = eDate
                Me.RadDatePickerEndDate.DateInput.Text = LoGlo.FormatDate(eDate)
            Else
                eDate = Me.RadDatePickerEndDate.SelectedDate
            End If
            If Me.IsClientPortal = True Then
                ds = oDTO.GetJobStatisticsCP(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
            Else
                ds = oDTO.GetJobStatistics(Session("UserCode"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
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
            Me.JobStatsRadGrid.DataSource = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub CreateChart()

        Webvantage.cCharting.GetColumnChart_JobStatistics(RadHtmlChartProjectStatistics, Session("ds_DTO_JobStatistics"), Me.DropTrafficFunctions.SelectedValue, Me.ChkIsClosedStatus.Checked)

    End Sub
    Public Shared Function GetShortStringOf(ByVal str As String, ByVal tb As System.Web.UI.WebControls.TextBox) As String
        Dim tbWidth As Integer = CType(tb.Width.ToString.Replace("px", ""), Integer)
        Dim max As Integer '= CType(tb.Width.ToString.Replace("px", ""), Integer) - 4

        Select Case tbWidth
            Case 50
                max = tbWidth - 6
            Case 95
                max = tbWidth - 7
            Case 145
                max = tbWidth - 7
        End Select

        Dim currPos As Integer = str.IndexOf(" "c, 0)
        Dim nextPos As Integer = str.IndexOf(" "c, currPos + 1)
        While str.Substring(0, nextPos).Length <= max
            currPos = nextPos
            nextPos = str.IndexOf(" "c, currPos + 1)
            If nextPos = -1 Then Return str 'returns the full string becuase it is less than max length
        End While
        Return str.Substring(0, currPos) & "..." 'returns the shortened string

    End Function
    Private Sub LoadData()
        Session("ds_DTO_JobStatistics") = ""
        Session("ds_DTO_JobStatistics") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim sDate As Date
            Dim eDate As Date
            If Me.RadDatePickerStartDate.SelectedDate = Nothing Then
                sDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerStartDate.SelectedDate = sDate
                Me.RadDatePickerStartDate.DateInput.Text = LoGlo.FormatDate(sDate)
            Else
                sDate = Me.RadDatePickerStartDate.SelectedDate
            End If
            If Me.RadDatePickerEndDate.SelectedDate = Nothing Then
                eDate = LoGlo.LastOfMonth()
                Me.RadDatePickerEndDate.SelectedDate = eDate
                Me.RadDatePickerEndDate.DateInput.Text = LoGlo.FormatDate(eDate)
            Else
                eDate = Me.RadDatePickerEndDate.SelectedDate
            End If
            If Me.IsClientPortal = True Then
                dt = oDTO.GetJobStatisticsCP(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
            Else
                dt = oDTO.GetJobStatistics(Session("UserCode"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
            End If

            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                If i > dt.Rows.Count - 1 Then
                    Exit For
                End If
                If dt.Rows(i)(2).ToString() = "0" And dt.Rows(i)(3).ToString() = "0" And dt.Rows(i)(4).ToString() = "0" And dt.Rows(i)(5).ToString() = "0" And dt.Rows(i)(6).ToString() = "0" Then
                    dt.Rows.Remove(dt.Rows(i))
                    i = -1
                End If
            Next
            Dim dv As DataView = New DataView(dt)

            If Me.ClientDropDownList.SelectedIndex = 0 Then
                'show the all clients row
                dv.RowFilter = "CL_CODE = 'ALL_CLIENTS'"
            Else
                dv.RowFilter = "CL_CODE = '" & Me.ClientDropDownList.SelectedValue & "'"
            End If
            dt = dv.ToTable
            If dt.Rows.Count > 0 Then
                ds.Tables.Add(dt.Copy())
                Session("ds_DTO_JobStatistics") = ds
            Else
                Session("ds_DTO_JobStatistics") = Nothing
            End If
            'Me.PlaceHolderGraph.Controls.Clear()
            'Dim xml As String = Me.WriteXML
            ''FusionCharts.SetRenderer("javascript")
            'Dim lit As Literal
            'lit = New Literal
            'lit.ID = "literalchartPS"
            'lit.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", xml, "chartPS", "380", "350", False, True)
            'Me.PlaceHolderGraph.Controls.Add(lit)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        CreateChart()

    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatisticsGraph", "sClient", "", Me.ClientDropDownList.SelectedValue)
        LoadGrid()
        LoadData()
    End Sub

    Private Sub ddEmployee_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddEmployee.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sEmployee", "", Me.ddEmployee.SelectedValue)
        LoadGrid()
        LoadData()
    End Sub

    Private Sub ddManager_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddManager.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sManager", "", Me.ddManager.SelectedValue)
        LoadGrid()
        LoadData()
    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDateStart", "", Me.RadDatePickerStartDate.SelectedDate)
        LoadGrid()
        LoadData()
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "ProjectStatistics", "sDateEnd", "", Me.RadDatePickerEndDate.SelectedDate)
        LoadGrid()
        LoadData()
    End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible
        LoadData()

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectStatistics
                .UserCode = Session("UserCode")
                .Name = "Project Statistics (DO)"
                .Description = "Project Statistics (DO)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
