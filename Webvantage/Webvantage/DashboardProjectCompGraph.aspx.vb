Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal


Partial Public Class DashboardProjectCompGraph
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
    Protected WithEvents DropOffice As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropAE As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropClient As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropDept As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropSalesClass As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropJobType As Telerik.Web.UI.RadComboBox
    Protected WithEvents CancelleDataSettatus As System.Web.UI.WebControls.TextBox
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
                Dim res As Object = Me.Session("_DataSet")
                If res Is Nothing Then

                End If
                Dim DataTable As DataTable = DirectCast(Me.Session("_DataSet"), DataTable)
                'RowCount = DataTable.Rows.Count
                Return DataTable
            Catch ex As Exception
                BlankDataTable()
            End Try
        End Get
    End Property
    Private Function BlankDataTable() As DataTable
        Dim DataTable As New DataTable
        Return DataTable
    End Function
#End Region

#Region " Page Functions "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Me.DropMonth = Me.RadToolbarDashProject.Items(5).FindControl("DropDownListMonth")
            Me.DropWeek = Me.RadToolbarDashProject.Items(7).FindControl("DropDownListWeek")
            Me.DropLevel = Me.RadToolbarPE.Items(1).FindControl("DropDownListLevel")
            'Me.CancelleDataSettatus = Me.RaDataTableoolbarFilter.Items(13).FindControl("TextBoxCancelStatus")
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
                    Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(1)
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
            Me.RadToolbarProject.Items(7).Enabled = False
            LoadData()
            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
                Me.RadToolbarProject.Items(9).Enabled = False
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Week"
                Else
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " by Week"
                End If
            Else
                Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()
                Case "HidePopups"

            End Select
        End If
        'Dim xmlstring As String = LoadData()

        'Clear off sessions from quote page
        Try
            If Not Me.IsPostBack Then
                'Session("DataTable_EST_QUOTE_FNC") = Nothing
                'Session("EstimateGriDataSetort") = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_DataSet") = Nothing
    End Function

    'Private Sub LoadDepts()
    '    Try
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim DataSet As DataSet = dash.GetDepts(Me.OfficeCode, Session("UserCode"))
    '        With Me.DropDownListDept
    '            .DataTextField = "DP_TM_DESC"
    '            .DataValueField = "DP_TM_CODE"
    '            .DataSource = DataSet
    '            .DataBind()
    '        End With
    '        With Me.DropDownListDept2
    '            .DataTextField = "DP_TM_DESC"
    '            .DataValueField = "DP_TM_CODE"
    '            .DataSource = DataSet
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoaDataSetalesClass()
    '    Try
    '        Dim cdd As New cDropDowns(Session("ConnString"))
    '        Dim dr As SqlDataReader = cdd.GetSalesClass()
    '        Dim dr2 As SqlDataReader = cdd.GetSalesClass()
    '        With Me.DropDownListSalesClass
    '            .DataTextField = "description"
    '            .DataValueField = "code"
    '            .DataSource = dr
    '            .DataBind()
    '        End With
    '        With Me.DropDownListSalesClass2
    '            .DataTextField = "description"
    '            .DataValueField = "code"
    '            .DataSource = dr2
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadClient()
    '    Try
    '        Dim cdd As New cDropDowns(Session("ConnString"))
    '        Dim dr As SqlDataReader = cdd.GetClientList(Session("UserCode"))
    '        Dim dr2 As SqlDataReader = cdd.GetClientList(Session("UserCode"))
    '        With Me.DropDownListClient
    '            .DataTextField = "Description"
    '            .DataValueField = "Code"
    '            .DataSource = dr
    '            .DataBind()
    '        End With
    '        With Me.DropDownListClient2
    '            .DataTextField = "Description"
    '            .DataValueField = "Code"
    '            .DataSource = dr2
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadAE()
    '    Try
    '        Dim cdd As New cDropDowns(Session("ConnString"))
    '        Dim dr As SqlDataReader = cdd.GetAccountExecutive("", "", "")
    '        Dim dr2 As SqlDataReader = cdd.GetAccountExecutive("", "", "")
    '        With Me.DropDownListAE
    '            .DataTextField = "Description"
    '            .DataValueField = "Code"
    '            .DataSource = dr
    '            .DataBind()
    '        End With
    '        With Me.DropDownListAE2
    '            .DataTextField = "Description"
    '            .DataValueField = "Code"
    '            .DataSource = dr2
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadJobType()
    '    Try
    '        Dim cdd As New cDropDowns(Session("ConnString"))
    '        Dim dr As SqlDataReader = cdd.ddJobType()
    '        Dim dr2 As SqlDataReader = cdd.ddJobType()
    '        With Me.DropDownListJobType
    '            .DataTextField = "description"
    '            .DataValueField = "code"
    '            .DataSource = dr
    '            .DataBind()
    '        End With
    '        With Me.DropDownListJobType2
    '            .DataTextField = "description"
    '            .DataValueField = "code"
    '            .DataSource = dr2
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadDropDowns()
    '    Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '    Dim cdd As New cDropDowns(Session("ConnString"))
    '    Dim DataSet As DataSet
    '    Dim dr As SqlDataReader
    '    DataSet = dash.GetOffices(Session("UserCode"))
    '    With Me.DropOffice
    '        .DataSource = DataSet
    '        .DataTextField = "OFFICE_NAME"
    '        .DataValueField = "OFFICE_CODE"
    '        .DataBind()
    '        .Items.Insert(0, "All Offices")
    '    End With
    '    dr = cdd.GetAccountExecutive("", "", "")
    '    With Me.DropAE
    '        .DataSource = dr
    '        .DataTextField = "Description"
    '        .DataValueField = "Code"
    '        .DataBind()
    '        .Items.Insert(0, "All Employees")
    '    End With
    '    dr = cdd.GetClientList(Session("UserCode"))
    '    With Me.DropClient
    '        .DataSource = dr
    '        .DataTextField = "Description"
    '        .DataValueField = "Code"
    '        .DataBind()
    '        .Items.Insert(0, "All Clients")
    '    End With
    '    DataSet = dash.GetDepts("", Session("UserCode"))
    '    With Me.DropDept
    '        .DataSource = DataSet
    '        .DataTextField = "DP_TM_DESC"
    '        .DataValueField = "DP_TM_CODE"
    '        .DataBind()
    '        .Items.Insert(0, "All Departments")
    '    End With
    '    dr = cdd.GetSalesClass()
    '    With Me.DropSalesClass
    '        .DataSource = dr
    '        .DataTextField = "description"
    '        .DataValueField = "code"
    '        .DataBind()
    '        .Items.Insert(0, "All Sales Classes")
    '    End With
    '    dr = cdd.ddJobType()
    '    With Me.DropJobType
    '        .DataSource = dr
    '        .DataTextField = "description"
    '        .DataValueField = "code"
    '        .DataBind()
    '        .Items.Insert(0, "All Job Types")
    '    End With
    'End Sub

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
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojgraph&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,wiDataTableh=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_DataSet") = Nothing
    End Sub

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet

            'DataSet = dash.GetPostPerioDataSet(Now.Date.Year)
            'Me.radMenu2.DataSource = DataSet.Tables(0)
            'Me.radMenu2.DataTextField = "Year"
            'Me.radMenu2.DataValueField = "Value"
            'Me.radMenu2.DataBind()
            Dim i As Integer = 0
            Dim tbButton As RadToolBarButton
            'For i As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
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
            Dim DataSet As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            'Dim month As String = Me.DropMonth.SelectedValue
            'DataSet = dash.GetPostPerioDataSetProject(year)
            'With Me.DropMonth
            '    .DataSource = DataSet.Tables(1)
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadweeks()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim week As String = Me.DropWeek.SelectedValue
            DataSet = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 0, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = DataSet.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With
            Me.DropWeek.SelectedValue = week
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RaDataTableoolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    LoadData()
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    LoadData()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Week", "", Me.DropWeek.SelectedValue)
            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RaDataTableoolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case ""
                Case Else
                    For Each raDataTableb As RadToolBarButton In Me.RadToolbarData.Items
                        If raDataTableb.Checked = True And raDataTableb.Text <> "Print" Then
                            year &= raDataTableb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Year", "", year)
                    loadmonths()
                    loadweeks()
                    LoadData()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Level", "", Me.DropLevel.SelectedValue)
            Me.LoadData()
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            'Me.Title = "Projects " & project & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Week"
                Else
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " by Week"
                End If
            Else
                Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RaDataTableoolbarNav_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarNav.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            Select Case e.Item.Value
                Case "Summary"
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
                        .Add("dash", "W")
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
                Case "Week"
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

    Private Sub RaDataTableoolbarProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProject.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Created"
                    LoadData()
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
                Case "Completed"
                    LoadData()
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
                Case "Due"
                    LoadData()
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
                Case "Pending"
                    LoadData()
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
                Case "Cancelled"
                    LoadData()
                    'Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
                    If iscancel = False Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Week"
                    Else
                        Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text & " by Week"
                    End If
                Case "All"
                    LoadData()
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Function CreateChart(Optional ByVal code As String = "", Optional ByVal code2 As String = "", Optional ByVal code3 As String = "", Optional ByVal name As String = "") As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing

        For Each RadToolBarButton In Me.RadToolbarDashProject.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "Month" Then

                type = RadToolBarButton.Value

            End If

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "YeartoDate" Then

                type = RadToolBarButton.Value

            End If

        Next

        year = ""

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year &= RadToolBarButton.Text & "-"

            End If

        Next

        year = MiscFN.RemoveTrailingDelimiter(year, "-")

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Select Case Me.DropLevel.SelectedValue

            Case "C"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByClient"), Session("DB_Client_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "CD"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByCD"), Session("DB_CD_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "CDP"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByCDP"), Session("DB_CDP_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "dept"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByDept"), Session("DB_Dept_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "SC"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "AE"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

            Case "JT"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("DataSet_DASH_CompsByJobType"), Session("DB_JobType_Caption"), "", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "week", name)

        End Select

        If RadHtmlChart IsNot Nothing Then

            RadHtmlChart.Height = System.Web.UI.WebControls.Unit.Pixel(300)
            RadHtmlChart.Width = System.Web.UI.WebControls.Unit.Pixel(1100)
            RadHtmlChart.ClientEvents.OnSeriesClick = "RadHtmlChartOnSeriesClick"

        End If

        Return RadHtmlChart

    End Function
    Private Sub CreateCharts_Department(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim DepartmentList As String() = Nothing

        If DeptCode <> "" Then

            DepartmentList = DeptCode.Split(",")

            For Each Department In DepartmentList

                DataTable = BuildWeekDataTable(Department.Replace("&", "").Replace("@", ""))
                Session("DataSet_DASH_CompsByDept") = DataTable
                Session("DB_Dept_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(Department.Replace("&", "").Replace("@", ""), "", "", Department)

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & Department.ToString.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDepts("", Session("UserCode"))

            If DataSet.Tables(0).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDataTable(DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByDept") = DataTable
                    Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    RadHtmlChart = CreateChart(DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", ""), "", "", DataRow("DP_TM_DESC"))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateCharts_SalesClass(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim SalesClassList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If sc <> "" Then

            SalesClassList = sc.Split(",")

            For Each SalesClass In SalesClassList

                DataTable = BuildWeekDataTableSalesClass(SalesClass.Replace("&", "").Replace("@", ""))
                Session("DataSet_DASH_CompsBySalesClass") = DataTable
                Session("DB_SalesClass_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(SalesClass.Replace("&", "").Replace("@", ""), "", "", SalesClass)

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & SalesClass.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetSalesClass()

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildWeekDataTableSalesClass(SqlDataReader("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsBySalesClass") = DataTable
                    SalesClassList = SqlDataReader("description").ToString.Split("-")
                    Session("DB_SalesClass_Caption") = SalesClassList(1).Trim

                    RadHtmlChart = CreateChart(SqlDataReader("code").ToString.Replace("&", "").Replace("@", ""), "", "", SalesClassList(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)
                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Client(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDataTableClient(ClientCode.Replace("&", "").Replace("@", ""))
                Session("DataSet_DASH_CompsByClient") = DataTable
                Session("DB_Client_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetClientList(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildWeekDataTableClient(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByClient") = DataTable
                    ClientList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_Client_Caption") = ClientList(1).Trim

                    RadHtmlChart = CreateChart(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""), "", "", ClientList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Division(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DescriptionList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDataTableCD(ClientCode.Replace("&", "").Replace("@", ""), "")
                Session("DataSet_DASH_CompsByCD") = DataTable
                Session("DB_CD_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetDivisionsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")
                    DataTable = BuildWeekDataTableCD(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByCD") = DataTable
                    DescriptionList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_CD_Caption") = SqlDataReader("Description")

                    RadHtmlChart = CreateChart(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), "", DescriptionList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Product(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DescriptionList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDataTableCDP(ClientCode.Replace("&", "").Replace("@", ""), "", "")
                Session("DataSet_DASH_CompsByCDP") = DataTable
                Session("DB_CDP_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetProductsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")
                    DataTable = BuildWeekDataTableCDP(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), ClientList(2).ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByCDP") = DataTable
                    DescriptionList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_CDP_Caption") = SqlDataReader("Description")

                    RadHtmlChart = CreateChart(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), ClientList(2).ToString.Replace("&", "").Replace("@", ""), DescriptionList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_AccountExecutive(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim AEList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If ae <> "" Then

            AEList = ae.Split(",")

            For Each AcctExec In AEList

                If AcctExec <> "" Then

                    If AcctExec.Length = 1 Then

                        AcctExec = AcctExec & ","

                    End If

                    DataTable = BuildWeekDataTableAccountExecutive(AcctExec.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataTable.Columns(4).ColumnName

                    RadHtmlChart = CreateChart(AcctExec.Replace("&", "").Replace("@", ""), "", "", AcctExec)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & AcctExec.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetAccountExecutive("", "", "", Session("UserCodE"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildWeekDataTableAccountExecutive(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByAccountExecutive") = DataTable
                    AEList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_AccountExecutive_Caption") = AEList(1).Trim

                    RadHtmlChart = CreateChart(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""), "", "", AEList(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_JobType(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim JobNameDataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim JobTypeList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If jt <> "" Then

            JobTypeList = jt.Split(",")

            For Each JobType In JobTypeList

                DataTable = BuildWeekDataTableJobType(JobType.Replace("&", "").Replace("@", ""))
                Session("DataSet_DASH_CompsByJobType") = DataTable
                Session("DB_JobType_Caption") = DataTable.Columns(4).ColumnName

                RadHtmlChart = CreateChart(JobType.Replace("&", "").Replace("@", ""), "", "", JobType)

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & JobType.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            JobNameDataTable = DropDowns.ddJobName()

            If JobNameDataTable.Rows.Count > 0 Then

                For Each DataRow In JobNameDataTable.Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDataTableJobType(DataRow("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("DataSet_DASH_CompsByJobType") = DataTable
                    Session("DB_JobType_Caption") = DataRow("description").ToString

                    RadHtmlChart = CreateChart(DataRow("code").ToString.Replace("&", "").Replace("@", ""), "", "", Str(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub

    Private Function BuildWeekDataTable(ByVal dept As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("DP_TM_DESC"), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)
                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)
                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 2 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("DP_TM_DESC").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DataSet.Tables(1).Rows(i)("DP_TM_CODE"), sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("DP_TM_DESC").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableSalesClass(ByVal sccode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("SC_DESCRIPTION"), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)
                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)
                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 2 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("SC_DESCRIPTION").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, DataSet.Tables(1).Rows(i)("SC_CODE"), jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("SC_DESCRIPTION").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableClient(ByVal clientcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME"), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 3 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("CL_NAME").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, DataSet.Tables(1).Rows(i)("CL_CODE"), DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("CL_NAME").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableCD(ByVal clientcode As String, ByVal divisioncode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("DIV_NAME").ToString(), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("DIV_NAME").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 3 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("CL_NAME").ToString() & "/" & DataTable.Rows(w)("DIV_NAME").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, DataSet.Tables(1).Rows(i)("CL_CODE"), DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("CL_NAME").ToString() & "/" & DataTable.Rows(j)("DIV_NAME").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableCDP(ByVal clientcode As String, ByVal divisioncode As String, ByVal productcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode, productcode)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString(), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & DataSet.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 3 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("CL_NAME").ToString() & "/" & DataTable.Rows(w)("DIV_NAME").ToString() & "/" & DataTable.Rows(w)("PRD_DESCRIPTION").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, DataSet.Tables(1).Rows(i)("CL_CODE"), DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode, productcode)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("CL_NAME").ToString() & "/" & DataTable.Rows(j)("DIV_NAME").ToString() & "/" & DataTable.Rows(j)("PRD_DESCRIPTION") Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableAccountExecutive(ByVal aecode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("ACCT_NAME"), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("ACCT_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 3 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("ACCT_NAME").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, DataSet.Tables(1).Rows(i)("ACCT_EXEC"), client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("ACCT_NAME").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDataTableJobType(ByVal jtcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
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

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As DataSet
            Dim DataTableComps As DataTable
            DataTableComps = New DataTable("comps")
            DataSet = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            DataTableComps.Columns.Add(dateOpened)
            DataTableComps.Columns.Add(dateRange)
            DataTableComps.Columns.Add(ws)
            DataTableComps.Columns.Add(we)

            Dim dc As DataColumn
            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("JT_DESC"), System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            DataTableComps.Columns.Add("Total")

            If DataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                    dc = New DataColumn(DataSet.Tables(1).Rows(i)("JT_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    DataTableComps.Columns.Add(dc)

                Next
            End If

            Dim DataTableWeek As DataView
            Dim DataTable As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To DataSet.Tables(0).Rows.Count - 1
                newrow = DataTableComps.NewRow
                newrow.Item("Date Opened") = DataSet.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(DataSet.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = DataSet.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = DataSet.Tables(0).Rows(j)("WEEK_END")
                DataTableWeek = DataSet.Tables(2).DefaultView
                DataTableWeek.RowFilter = "DATE_OPENED = " & DataSet.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & DataSet.Tables(0).Rows(j)("WEEK_START") & "'"
                DataTable = DataTableWeek.ToTable
                For w As Integer = 0 To DataTable.Rows.Count - 1
                    For x As Integer = 3 To DataTableComps.Columns.Count - 1
                        If DataTableComps.Columns(x).ColumnName = DataTable.Rows(w)("JT_DESC").ToString() Then
                            newrow.Item(x) = DataTable.Rows(w)("COMPS")
                            total += CInt(DataTable.Rows(w)("COMPS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                DataTableComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To DataTableComps.Rows.Count - 1
                For q As Integer = 0 To DataTableComps.Columns.Count - 1
                    If DataTableComps.Rows(p)(q).ToString() = "" Then
                        DataTableComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Dim DataSetAvg As DataSet
            For i As Integer = 0 To DataSet.Tables(1).Rows.Count - 1
                DataSetAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, DataSet.Tables(1).Rows(i)("JOB_TYPE"), 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
                For p As Integer = 0 To DataTableComps.Rows.Count - 1
                    DataTableWeek = DataSetAvg.Tables(0).DefaultView
                    DataTableWeek.RowFilter = "DATE_OPENED = " & DataTableComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & DataTableComps.Rows(p)("WS") & "'"
                    DataTable = DataTableWeek.ToTable
                    For j As Integer = 0 To DataTable.Rows.Count - 1
                        For q As Integer = 0 To DataTableComps.Columns.Count - 1
                            If DataTableComps.Columns(q).ColumnName = DataTable.Rows(j)("JT_DESC").ToString() Then
                                DataTableComps.Rows(p)(q) = DataTable.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return DataTableComps
        Catch ex As Exception

        End Try
    End Function

    Private Sub LoadData()

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim literal As Literal = Nothing

        Session("DataSet_DASH_NonDirect") = ""
        Session("DataSet_DASH_NonDirect") = Nothing

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year = RadToolBarButton.Text

            End If

        Next

        Me.PlaceHolderGraph.Controls.Clear()

        Try

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Select Case Me.DropLevel.SelectedValue

                Case "dept"

                    CreateCharts_Department(Dashboard)

                Case "SC"

                    CreateCharts_SalesClass(Dashboard)

                Case "C"

                    CreateCharts_Client(Dashboard)

                Case "CD"

                    CreateCharts_Division(Dashboard)

                Case "CDP"

                    CreateCharts_Product(Dashboard)

                Case "AE"

                    CreateCharts_AccountExecutive(Dashboard)

                Case "JT"

                    CreateCharts_JobType(Dashboard)

            End Select

            If Me.PlaceHolderGraph.Controls.Count = 0 Then

                literal = New Literal
                literal.ID = "lit1"
                literal.Text = "No data to display."
                Me.PlaceHolderGraph.Controls.Add(literal)

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region

End Class