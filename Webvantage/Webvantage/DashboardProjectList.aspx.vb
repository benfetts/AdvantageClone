Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProjectList
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

#Region " Controls "
    Protected WithEvents DropMonth As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropWeek As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropLevel As Telerik.Web.UI.RadComboBox
#End Region

#Region " Variables and Properties "

    Public OfficeCode As String = ""
    Public DeptCode As String = ""
    Public EmpCode As String = ""
    Public month As String = ""
    Public year As String = ""
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public include As Integer = 0
    Public period As Integer = 0
    Public yearValue As String = ""
    Public cols As Integer
    Public cancel As String = ""
    Public cancelDesc As String = ""
    Public project As String = ""
    Public type As String = ""
    Public dash As String = ""
    Public ae As String = ""
    Public sc As String = ""
    Public jt As String = ""
    Public iscancel As Boolean = False

    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                Dim res As Object = Me.Session("_ds")
                If res Is Nothing Then

                End If
                Dim dt As DataTable = DirectCast(Me.Session("_ds"), DataTable)
                'RowCount = dt.Rows.Count
                Return dt
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function
#End Region

#Region " Page Functions "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Me.DropMonth = Me.RadToolbarDashProject.Items(5).FindControl("DropDownListMonth")
            Me.DropWeek = Me.RadToolbarDashProject.Items(7).FindControl("DropDownListWeek")
            Me.DropLevel = Me.RadToolbarPE.Items(1).FindControl("DropDownListLevel")
            'Me.CancelledStatus = Me.RadToolbarFilter.Items(13).FindControl("TextBoxCancelStatus")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Try
            If Not Me.IsPostBack Then
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_ProjectStatisticsDQ) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                End If
            End If
        Catch ex As Exception
        End Try

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "OfficeCode")
        If taskVar <> "" Then
            OfficeCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "DeptCode")
        If taskVar <> "" Then
            DeptCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "AECode")
        If taskVar <> "" Then
            ae = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "ClientCode")
        If taskVar <> "" Then
            client = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "SCCode")
        If taskVar <> "" Then
            sc = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "JobType")
        If taskVar <> "" Then
            jt = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "CancelCode")
        If taskVar <> "" Then
            cancel = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "IsCancelled")
        If taskVar <> "" Then
            iscancel = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "CancelDesc")
        If taskVar <> "" Then
            cancelDesc = taskVar
        End If

        If Not Me.IsPostBack Then
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                If q.GetValue("range") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarDashProject.Items.Count - 1
                        If Me.RadToolbarDashProject.Items(i).Value = q.GetValue("range") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(1)
                    rtb.Checked = True
                End If
                loadyears()
                If q.GetValue("year") <> "" Then
                    Dim stryear() As String = q.GetValue("year").Split("-")
                    For i As Integer = 0 To Me.RadToolbarData.Items.Count - 1
                        For j As Integer = 0 To stryear.Length - 1
                            If Me.RadToolbarData.Items(i).Text = stryear(j) Then
                                Dim rtb As RadToolBarButton = Me.RadToolbarData.Items(i)
                                rtb.Checked = True
                            End If
                        Next
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarData.Items(1)
                    rtb.Checked = True
                End If
                loadmonths()
                If q.GetValue("month") <> "" Then
                    Me.DropMonth.SelectedValue = q.GetValue("month")
                End If
                loadweeks()
                Dim test As String = HttpContext.Current.Server.UrlDecode(q.GetValue("week"))
                If q.GetValue("week") <> "" Then
                    Me.DropWeek.SelectedValue = q.GetValue("week")
                End If
                If q.GetValue("project") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarProject.Items.Count - 1
                        If Me.RadToolbarProject.Items(i).Value = q.GetValue("project") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(11)
                    rtb.Checked = True
                End If
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Level")
                If taskVar <> "" Then
                    Me.DropLevel.SelectedValue = taskVar
                End If
            End With

            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            If q.GetValue("project") = "Pending" Then
                Me.RadToolbarNav.Items(4).Enabled = False
                Me.RadToolbarNav.Items(6).Enabled = False
                Me.RadToolbarNav.Items(8).Enabled = False
                Me.RadToolbarDashProject.Items(1).Enabled = False
                Me.RadToolbarDashProject.Items(3).Enabled = False
                Me.RadToolbarDashProject.Items(5).Enabled = False
                Me.RadToolbarDashProject.Items(7).Enabled = False
            End If
            'LoadData(type)

            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    If Request.QueryString("type") = "div" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname")
                    ElseIf Request.QueryString("type") = "prd" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                    Else
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                    End If
                Else
                    If Request.QueryString("type") = "div" Then
                        Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname")
                    ElseIf Request.QueryString("type") = "prd" Then
                        Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                    Else
                        Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                    End If
                End If
            Else
                If Request.QueryString("type") = "div" Then
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname")
                ElseIf Request.QueryString("type") = "prd" Then
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name") & "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                Else
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                End If
            End If
            'LoadGrid()

            'Me.buildRG()
            'Me.buildRGMonth()
            'Me.buildRGYear()
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    'Me.RadWindowManagerEstimate.Windows(0).VisibleOnPageLoad = False
                    'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()
                Case "Data"
                    'Dim download As Boolean
                    'Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
                    ''If e.Item.Value = "Data" Then                    
                    'download = dash.GetDataRefreshProject("", "")
                    ''End If
                    ''Me.radMenu1.Items(0).Selected = False
                    'Me.buildRG()
                    'Me.buildRGMonth()
                    'Me.buildRGYear()
                    'Me.RadGridComps.Rebind()
                    'Me.RadGridMonth.Rebind()
                    'Me.RadGridYear.Rebind()
                Case "Prt"
                    'Me.radMenu4.Items(0).Selected = False
                    'Me.radMenu5.Items(0).Selected = False
            End Select
        End If

        'Clear off sessions from quote page
        Try
            If Not Me.IsPostBack Then
                'Session("DT_EST_QUOTE_FNC") = Nothing
                'Session("EstimateGridSort") = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                dash = qs.GetValue("dash")
            End With
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojlist&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "&type=" & Request.QueryString("type") & "&code=" & Request.QueryString("code") & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojlist&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "&type=" & Request.QueryString("type") & "&code=" & Request.QueryString("code") & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    Private Sub RadGridProjects_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjects.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(2).Text 'job
                Dim str2 As String = e.Item.Cells(3).Text
                Dim str3 As String = e.Item.Cells(4).Text
                Dim str4 As String = e.Item.Cells(5).Text

                'e.Item.Cells(2).Text = e.Item.Cells(2).Text.PadLeft(6, "0") & "-" & e.Item.Cells(4).Text.PadLeft(2, "0")

                Dim datetype As DateTime
                If e.Item.Cells(14).Text <> "" And e.Item.Cells(14).Text <> "&nbsp;" Then
                    datetype = CDate(e.Item.Cells(14).Text)
                    e.Item.Cells(14).Text = datetype.ToShortDateString
                End If
                If e.Item.Cells(15).Text <> "" And e.Item.Cells(15).Text <> "&nbsp;" Then
                    datetype = CDate(e.Item.Cells(15).Text)
                    e.Item.Cells(15).Text = datetype.ToShortDateString
                End If
                If e.Item.Cells(16).Text <> "" And e.Item.Cells(16).Text <> "&nbsp;" Then 'completed
                    datetype = CDate(e.Item.Cells(16).Text)
                    e.Item.Cells(16).Text = datetype.ToShortDateString
                End If
                If e.Item.Cells(15).Text <> "" And e.Item.Cells(15).Text <> "&nbsp;" And e.Item.Cells(16).Text <> "" And e.Item.Cells(16).Text <> "&nbsp;" Then
                    Dim due As DateTime = CDate(e.Item.Cells(15).Text)
                    Dim completed As DateTime = CDate(e.Item.Cells(16).Text)
                    Dim time As TimeSpan = completed.Subtract(due)
                    e.Item.Cells(17).Text = time.Days
                Else
                    e.Item.Cells(17).Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridProjects_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjects.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim count As Integer = 0
            Dim cde As String
            Dim prdcode As String
            Dim divcode As String
            Dim startvalue As String
            Dim endvalue As String
            Dim page As String
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            If Request.QueryString("page") <> "" Then
                page = Request.QueryString("page")
                If Request.QueryString("page") = "year" Then
                    If Request.QueryString("ddvalue") <> "" Then
                        startvalue = Request.QueryString("ddvalue")
                    End If
                    If count > 1 Then
                        If startvalue = Now.Date.Year.ToString() Then
                            startvalue = "1/1/" & startvalue
                            endvalue = Me.DropWeek.SelectedValue
                        Else
                            endvalue = "12/31/" & startvalue
                            startvalue = CDate(Me.DropWeek.SelectedValue).AddYears(-1).ToShortDateString
                        End If
                    Else
                        startvalue = "1/1/" & startvalue
                        endvalue = Me.DropWeek.SelectedValue
                    End If
                End If
                If Request.QueryString("page") = "month" Then
                    If Request.QueryString("ddstart") <> "" Then
                        startvalue = Request.QueryString("ddstart")
                    End If
                    If Request.QueryString("ddend") <> "" Then
                        endvalue = Request.QueryString("ddend")
                    End If
                End If
                If Request.QueryString("page") = "week" Then
                    If Request.QueryString("ddstart") <> "" Then
                        startvalue = Request.QueryString("ddstart")
                    End If
                    If Request.QueryString("ddend") <> "" Then
                        endvalue = Request.QueryString("ddend")
                    End If
                End If
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            cde = Request.QueryString("code").Replace("andcode", "&")
            If cde = "None" Or cde = "None," Then
                cde = "None"
            End If
            If Request.QueryString("divcode") <> "" Then
                divcode = Request.QueryString("divcode").Replace("andcode", "&")
            End If
            If Request.QueryString("prdcode") <> "" Then
                prdcode = Request.QueryString("prdcode").Replace("andcode", "&")
            End If
            If Request.QueryString("type") = "cli" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, cde, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, "", "", startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "div" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, cde, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divcode, "", startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "prd" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, cde, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divcode, prdcode, startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "acc" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, cde, "", DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, "", "", startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "dept" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, cde, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, "", "", startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "sc" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, cde, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, "", "", startvalue, endvalue, page)
            End If
            If Request.QueryString("type") = "jt" Then
                Me.RadGridProjects.DataSource = dash.GetProjectsList("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, cde, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, "", "", startvalue, endvalue, page)
            End If

        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet

            'ds = dash.GetPostPeriods(Now.Date.Year)
            'Me.radMenu2.DataSource = ds.Tables(0)
            'Me.radMenu2.DataTextField = "Year"
            'Me.radMenu2.DataValueField = "Value"
            'Me.radMenu2.DataBind()
            Dim i As Integer = 0
            Dim tbButton As RadToolBarButton
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            tbButton = New RadToolBarButton(Now.Date.AddYears(-1).Date.Year)
            tbButton.Value = 1
            tbButton.AllowSelfUnCheck = True
            tbButton.CheckOnClick = True
            tbButton.Group = "Year" & i + 1
            Me.RadToolbarData.Items.Insert(i, tbButton)
            i += 1
            tbButton = New RadToolBarButton(Now.Date.Year)
            tbButton.Value = 2
            tbButton.AllowSelfUnCheck = True
            tbButton.CheckOnClick = True
            tbButton.Group = "Year" & i + 1
            Me.RadToolbarData.Items.Insert(i, tbButton)
            'Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadmonths()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            'Dim month As String = Me.DropMonth.SelectedValue
            'ds = dash.GetPostPeriodsProject(year)
            'With Me.DropMonth
            '    .DataSource = ds.Tables(1)
            '    .DataTextField = "PPDESC"
            '    .DataValueField = "PPPERIOD"
            '    .DataBind()
            'End With
            'Me.DropMonth.SelectedValue = month
            Me.DropMonth.Items.Clear()
            With Me.DropMonth
                .DataSource = LoGlo.LoadMonths(True)
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jan"), CStr("1")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Feb"), CStr("2")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Mar"), CStr("3")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Apr"), CStr("4")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("May"), CStr("5")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jun"), CStr("6")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jul"), CStr("7")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Aug"), CStr("8")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Sep"), CStr("9")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Oct"), CStr("10")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Nov"), CStr("11")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Dec"), CStr("12")))
            Me.DropMonth.SelectedValue = CStr(Now.Date.Month)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadweeks()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim week As String = Me.DropWeek.SelectedValue
            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 0, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = ds.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With
            Me.DropWeek.SelectedValue = week
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            'Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            Me.RadGridProjects.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            'Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Week", "", Me.DropWeek.SelectedValue)
            Me.RadGridProjects.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            ' Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Level", "", Me.DropLevel.SelectedValue)
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            Me.RadGridProjects.Rebind()
            'Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
            If project = "Cancelled" Then
                If iscancel = False Then
                    If Request.QueryString("type") = "div" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("divname") '& "/" & Request.QueryString("divname")
                    ElseIf Request.QueryString("type") = "prd" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("prdname") '& "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                    Else
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                    End If
                Else
                    If Request.QueryString("type") = "div" Then
                        Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("divname") '& "/" & Request.QueryString("divname")
                    ElseIf Request.QueryString("type") = "prd" Then
                        Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("prdname") '& "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                    Else
                        Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                    End If
                End If
            Else
                'Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
                If Request.QueryString("type") = "div" Then
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("divname") '& "/" & Request.QueryString("divname")
                ElseIf Request.QueryString("type") = "prd" Then
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("prdname") '& "/" & Request.QueryString("divname") & "/" & Request.QueryString("prdname")
                Else
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " for " & Request.QueryString("name")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Data"
                    Dim download As Boolean
                    Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
                    'If e.Item.Value = "Data" Then                    
                    download = dash.GetDataRefreshProject("", "")
                    Me.RadGridProjects.Rebind()
                Case Else
                    For Each radtb As RadToolBarButton In Me.RadToolbarData.Items
                        If radtb.Checked = True And radtb.Text <> "Print" Then
                            year &= radtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Year", "", year)
                    loadmonths()
                    loadweeks()
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    Me.RadGridProjects.Rebind()
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    Me.RadGridProjects.Rebind()
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    Me.RadGridProjects.Rebind()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProject.ButtonClick
        Try
            'Dim type As String
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case "Created"
                    Me.RadGridProjects.Rebind()
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                    Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Completed"
                    Me.RadGridProjects.Rebind()
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                    Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Due"
                    Me.RadGridProjects.Rebind()
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                    Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Pending"
                    Me.RadGridProjects.Rebind()
                    Me.RadToolbarNav.Items(4).Enabled = False
                    Me.RadToolbarNav.Items(6).Enabled = False
                    Me.RadToolbarNav.Items(8).Enabled = False
                    Me.RadToolbarDashProject.Items(1).Enabled = False
                    Me.RadToolbarDashProject.Items(3).Enabled = False
                    Me.RadToolbarDashProject.Items(5).Enabled = False
                    Me.RadToolbarDashProject.Items(7).Enabled = False
                    Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Cancelled"
                    Me.RadGridProjects.Rebind()
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                    If iscancel = False Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                    Else
                        Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarNav_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarNav.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            Select Case e.Item.Value
                Case "Summary"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectComp.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
                Case "Year"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectYear.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                Case "Month"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectMonth.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                Case "Detail"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
                Case "Week"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectCompGraph.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectCompGraph.aspx")
                Case "Filter"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProject.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProject.aspx")
                Case "ProjectDetail"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectCompDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

#End Region
















   
End Class