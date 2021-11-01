Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal


Partial Public Class DashboardClientTimeGraph
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
    Protected WithEvents CancelledStatus As System.Web.UI.WebControls.TextBox
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
    Public datatype As String = ""

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
                'Dim oSec As New cSecurity(Session("ConnString"))
                'If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                '    Server.Transfer("NoAccess.aspx")
                'ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                '    Server.Transfer("NoAccess.aspx")
                'ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                '    'Me.RadToolbarFilter.Items(3).Enabled = False
                'End If
            End If
        Catch ex As Exception
        End Try

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "OfficeCode")
        If taskVar <> "" Then
            OfficeCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "DeptCode")
        If taskVar <> "" Then
            DeptCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "AECode")
        If taskVar <> "" Then
            ae = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "ClientCode")
        If taskVar <> "" Then
            client = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "SCCode")
        If taskVar <> "" Then
            sc = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "JobType")
        If taskVar <> "" Then
            jt = taskVar
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
                If q.GetValue("option") <> "" Then
                    project = q.GetValue("option").Replace("_", " ")
                End If
                If q.GetValue("dt") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarDataType.Items.Count - 1
                        If Me.RadToolbarDataType.Items(i).Value = q.GetValue("dt") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarDataType.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarDataType.Items(1)
                    rtb.Checked = True
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
            'For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
            '    If rtb.Value = "Hours" Then
            '        rtb.Checked = True
            '    End If
            'Next

            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            If datatype = "Hours" Then
                Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
            If datatype = "Dollars" Then
                Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Level")
            If taskVar <> "" Then
                Me.DropLevel.SelectedValue = taskVar
            End If
            LoadData(datatype)

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
                'Session("DT_EST_QUOTE_FNC") = Nothing
                'Session("EstimateGridSort") = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

    'Private Sub LoadDepts()
    '    Try
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet = dash.GetDepts(Me.OfficeCode, Session("UserCode"))
    '        With Me.DropDownListDept
    '            .DataTextField = "DP_TM_DESC"
    '            .DataValueField = "DP_TM_CODE"
    '            .DataSource = ds
    '            .DataBind()
    '        End With
    '        With Me.DropDownListDept2
    '            .DataTextField = "DP_TM_DESC"
    '            .DataValueField = "DP_TM_CODE"
    '            .DataSource = ds
    '            .DataBind()
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadSalesClass()
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
    '    Dim ds As DataSet
    '    Dim dr As SqlDataReader
    '    ds = dash.GetOffices(Session("UserCode"))
    '    With Me.DropOffice
    '        .DataSource = ds
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
    '    ds = dash.GetDepts("", Session("UserCode"))
    '    With Me.DropDept
    '        .DataSource = ds
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
            Dim iscancel As Boolean = False
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next

            If cancel <> "" Then
                iscancel = True
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?db=client&From=dashclientweek&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&datatype=" & datatype & "&ln=" & Me.DropLevel.SelectedItem.Text & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet

            ds = dash.GetPostPeriods(Now.Date.Year)
            'Me.radMenu2.DataSource = ds.Tables(0)
            'Me.radMenu2.DataTextField = "Year"
            'Me.radMenu2.DataValueField = "Value"
            'Me.radMenu2.DataBind()

            Dim tbButton As RadToolBarButton
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tbButton = New RadToolBarButton(ds.Tables(0).Rows(i)("Year"))
                tbButton.Value = ds.Tables(0).Rows(i)("Value")
                tbButton.AllowSelfUnCheck = True
                tbButton.CheckOnClick = True
                tbButton.Group = "Year" & ds.Tables(0).Rows(i)("Value").ToString
                Me.RadToolbarData.Items.Insert(i, tbButton)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadmonths()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim SortedPostPeriods As DataTable = Nothing
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim month As String = Me.DropMonth.SelectedValue
            ds = dash.GetPostPeriodsProject(year)

            With ds.Tables(1).DefaultView

                .Sort = "PPGLMONTH asc"
                SortedPostPeriods = .ToTable

            End With

            With Me.DropMonth
                .DataSource = SortedPostPeriods
                .DataTextField = "PPDESC"
                .DataValueField = "PPPERIOD"
                .DataBind()
            End With
            Me.DropMonth.SelectedValue = month
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To Me.DropMonth.Items.Count - 1
                For i As Integer = 0 To SortedPostPeriods.Rows.Count - 1
                    If Me.DropMonth.Items(i).Value = SortedPostPeriods.Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, SortedPostPeriods.Rows(i)("MONTH"), 1)
                        Me.DropMonth.Items(i).Text = String.Format(c, "{0:MMM}", d)
                    End If
                Next
            Next

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
            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 1, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = ds.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With
            Me.DropWeek.SelectedValue = ds.Tables(0).AsEnumerable.Last()("WEEK_END")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    LoadData(datatype)
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    LoadData(datatype)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            loadweeks()
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Month", "", Me.DropMonth.SelectedValue)
            Me.LoadData(datatype)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Week", "", Me.DropWeek.SelectedValue)
            Me.LoadData(datatype)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case ""
                Case Else
                    For Each radtb As RadToolBarButton In Me.RadToolbarData.Items
                        If radtb.Checked = True And radtb.Text <> "Print" Then
                            year &= radtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Year", "", year)
                    loadmonths()
                    loadweeks()
                    LoadData(datatype)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Level", "", Me.DropLevel.SelectedValue)
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            Me.LoadData(datatype)
            If datatype = "Hours" Then
                Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
            If datatype = "Dollars" Then
                Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarNav_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarNav.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option")
            End With
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case "Summary"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientTime.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Add("option", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
                Case "Detail"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
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
                    With q
                        'the page to go to
                        .Page = "DashboardClientTimeDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("dash", "W")
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
                Case "Year"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientYear.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                Case "Month"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientMonth.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                Case "Week"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
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
                    With q
                        'the page to go to
                        .Page = "DashboardClientTimeGraph.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectCompGraph.aspx")
                Case "Filter"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
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
                    With q
                        'the page to go to
                        .Page = "DashboardClient.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProject.aspx")
                Case "ProjectDetail"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
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
                    With q
                        'the page to go to
                        .Page = "DashboardClientTimeCompDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDataType_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDataType.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            Select Case e.Item.Value
                Case "Hours"
                    LoadData("Hours")
                    Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Week"
                Case "Dollars"
                    LoadData("Dollars")
                    Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Week"
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Function CreateChart() As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim Dashboard As Webvantage.cDashboard = Nothing

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

        For Each RadToolBarButton In Me.RadToolbarDataType.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                datatype = RadToolBarButton.Value

            End If

        Next

        year = MiscFN.RemoveTrailingDelimiter(year, "-")

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Select Case Me.DropLevel.SelectedValue

            Case "C"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByClient"), Session("DB_Client_Caption"), datatype)

            Case "CD"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByCD"), Session("DB_CD_Caption"), datatype)

            Case "CDP"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByCDP"), Session("DB_CDP_Caption"), datatype)

            Case "dept"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByDept"), Session("DB_Dept_Caption"), datatype)

            Case "SC"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), datatype)

            Case "AE"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), datatype)

            Case "JT"

                RadHtmlChart = Dashboard.GetColumnChart_Hours(Session("ds_DASH_CompsByJobType"), Session("DB_JobType_Caption"), datatype)

        End Select

        If RadHtmlChart IsNot Nothing Then

            RadHtmlChart.Height = System.Web.UI.WebControls.Unit.Pixel(300)
            RadHtmlChart.Width = System.Web.UI.WebControls.Unit.Pixel(1100)

        End If

        Return RadHtmlChart

    End Function

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
            If rtb.Checked = True And rtb.Value = "Month" Then
                type = rtb.Value
            End If
            If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                type = rtb.Value
            End If
        Next
        year = ""
        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
            If rtb.Checked = True Then
                year &= rtb.Text & "-"
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
            If rtb.Checked = True Then
                datatype = rtb.Value
            End If
        Next
        year = MiscFN.RemoveTrailingDelimiter(year, "-")
        If Me.DropLevel.SelectedValue = "C" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByClient"), Session("DB_Client_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByCD"), Session("DB_CD_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByCDP"), Session("DB_CDP_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByDept"), Session("DB_Dept_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), datatype)
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return dash.getFCXMLData_Bar3D_Hours(Session("ds_DASH_CompsByJobType"), Session("DB_JobType_Caption"), datatype)
        End If
    End Function

    Private Function BuildWeekDT(ByVal dept As String, ByVal datatype As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 2 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", ds.Tables(1).Rows(i)("DP_TM_CODE"), "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("DP_TM_DESC").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTSalesClass(ByVal sccode As String, ByVal datatype As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 2 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", ds.Tables(1).Rows(i)("SC_CODE"), "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("SC_DESCRIPTION").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTClient(ByVal clientcode As String, ByVal datatype As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTCD(ByVal clientcode As String, ByVal datatype As String, ByVal divisioncode As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString())
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString()& "/" & dt.Rows(j)("DIV_NAME").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTCDP(ByVal clientcode As String, ByVal datatype As String, ByVal divisioncode As String, ByVal productcode As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode, productcode)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count, divisioncode, productcode)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString())
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() & "/" & dt.Rows(w)("PRD_DESCRIPTION").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString() & "/" & dt.Rows(j)("DIV_NAME").ToString() & "/" & dt.Rows(j)("PRD_DESCRIPTION") Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTAccountExecutive(ByVal aecode As String, ByVal datatype As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, ae, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, ae, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("ACCT_NAME"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("ACCT_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("ACCT_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", ds.Tables(1).Rows(i)("ACCT_EXEC"), "", "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("ACCT_NAME").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDTJobType(ByVal jtcode As String, ByVal datatype As String)
        Try
            Dim count As Integer
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("JT_DESC"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("JT_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("JT_DESC").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            'Dim dsAvg As DataSet
            'For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '    dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", "", ds.Tables(1).Rows(i)("JOB_TYPE"), 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)
            '    For p As Integer = 0 To dtComps.Rows.Count - 1
            '        dtWeek = dsAvg.Tables(0).DefaultView
            '        dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
            '        dt = dtWeek.ToTable
            '        For j As Integer = 0 To dt.Rows.Count - 1
            '            For q As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(q).ColumnName = dt.Rows(j)("JT_DESC").ToString()Then
            '                    dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
            '                End If
            '            Next
            '        Next
            '    Next
            'Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Sub CreateChart_Department_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DepartmentList As String() = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If DeptCode <> "" Then

            DepartmentList = DeptCode.Split(",")

            For Each Department In DepartmentList

                DataTable = BuildWeekDT(Department.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsByDept") = DataTable
                Session("DB_Dept_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & Department.ToString.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDT("'" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "") & "'", "Hours")
                    Session("ds_DASH_CompsByDept") = DataTable
                    Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "literal" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Department_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DepartmentList As String() = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If DeptCode <> "" Then

            DepartmentList = DeptCode.Split(",")

            For Each Department In DepartmentList

                DataTable = BuildWeekDT(Department.Replace("&", "").Replace("@", ""), "Dollars")
                Session("ds_DASH_CompsByDept") = DataTable
                Session("DB_Dept_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & Department.ToString.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDT("'" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "") & "'", "Dollars")
                    Session("ds_DASH_CompsByDept") = DataTable
                    Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_SalesClass_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim SalesClassList As String() = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If sc <> "" Then

            SalesClassList = sc.Split(",")

            For Each SalesClass In SalesClassList

                DataTable = BuildWeekDTSalesClass(SalesClass.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsBySalesClass") = DataTable
                Session("DB_SalesClass_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & SalesClass.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTSalesClass(DataRow("SC_CODE").ToString.Replace("&", "").Replace("@", ""), "Hours")
                    Session("ds_DASH_CompsBySalesClass") = DataTable
                    Session("DB_SalesClass_Caption") = DataRow("SC_DESCRIPTION")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("SC_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_SalesClass_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim SalesClassList As String() = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If sc <> "" Then

            SalesClassList = sc.Split(",")

            For Each SalesClass In SalesClassList

                DataTable = BuildWeekDTSalesClass(SalesClass.Replace("&", "").Replace("@", ""), "Dollars")
                Session("ds_DASH_CompsBySalesClass") = DataTable
                Session("DB_SalesClass_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & SalesClass.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTSalesClass(DataRow("SC_CODE").ToString.Replace("&", "").Replace("@", ""), "Dollars")
                    Session("ds_DASH_CompsBySalesClass") = DataTable
                    Session("DB_SalesClass_Caption") = DataRow("SC_DESCRIPTION")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("SC_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Client_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTClient(ClientCode.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsByClient") = DataTable
                Session("DB_Client_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTClient(DataRow("CL_CODE"), "Hours")
                    Session("ds_DASH_CompsByClient") = DataTable
                    Session("DB_Client_Caption") = DataRow("CL_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("CL_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Client_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTClient(ClientCode.Replace("&", "").Replace("@", ""), "Dollars")
                Session("ds_DASH_CompsByClient") = DataTable
                Session("DB_Client_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTClient(DataRow("CL_CODE").ToString.Replace("&", "").Replace("@", ""), "Dollars")
                    Session("ds_DASH_CompsByClient") = DataTable
                    Session("DB_Client_Caption") = DataRow("CL_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("CL_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Division_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTClient(ClientCode.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsByCD") = DataTable
                Session("DB_CD_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTCD(DataRow("CL_CODE"), "Hours", DataRow("DIV_CODE"))
                    Session("ds_DASH_CompsByCD") = DataTable
                    Session("DB_CD_Caption") = DataRow("CL_CODE") & " | " & DataRow("DIV_CODE") & " - " & DataRow("DIV_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("DIV_CODE").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Division_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTCD(ClientCode.Replace("&", "").Replace("@", ""), "Hours", "")
                Session("ds_DASH_CompsByCD") = DataTable
                Session("DB_CD_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTCD(DataRow("CL_CODE"), "Hours", DataRow("DIV_CODE"))
                    Session("ds_DASH_CompsByCD") = DataTable
                    Session("DB_CD_Caption") = DataRow("CL_CODE") & " | " & DataRow("DIV_CODE") & " - " & DataRow("DIV_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("DIV_CODE").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Product_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTClient(ClientCode.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsByCDP") = DataTable
                Session("DB_CDP_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTCDP(DataRow("CL_CODE"), "Hours", DataRow("DIV_CODE"), DataRow("PRD_CODE"))
                    Session("ds_DASH_CompsByCDP") = DataTable
                    Session("DB_CDP_Caption") = DataRow("CL_CODE") & " | " & DataRow("DIV_CODE") & " | " & DataRow("PRD_CODE") & " - " & DataRow("PRD_DESCRIPTION")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("PRD_CODE").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_Product_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildWeekDTCDP(ClientCode.Replace("&", "").Replace("@", ""), "Hours", "", "")
                Session("ds_DASH_CompsByCDP") = DataTable
                Session("DB_CDP_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTCDP(DataRow("CL_CODE"), "Hours", DataRow("DIV_CODE"), DataRow("PRD_CODE"))
                    Session("ds_DASH_CompsByCDP") = DataTable
                    Session("DB_CDP_Caption") = DataRow("CL_CODE") & " | " & DataRow("DIV_CODE") & " | " & DataRow("PRD_CODE") & " - " & DataRow("PRD_DESCRIPTION")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("PRD_CODE").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_AccountExecutive_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim AEList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If ae <> "" Then

            AEList = ae.Split(",")

            For Each AcctExec In AEList

                If AcctExec <> "" Then

                    If AcctExec.Length = 1 Then

                        AcctExec = AcctExec & ","

                    End If

                    DataTable = BuildWeekDTAccountExecutive(AcctExec.Replace("&", "").Replace("@", ""), "Hours")
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataTable.Columns(3).ColumnName

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & AcctExec.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, ae, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTAccountExecutive(DataRow("ACCT_EXEC").ToString.Replace("&", "").Replace("@", ""), "Hours")
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataRow("ACCT_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("ACCT_EXEC").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_AccountExecutive_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim AEList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If ae <> "" Then

            AEList = ae.Split(",")

            For Each AcctExec In AEList

                If AcctExec <> "" Then

                    If AcctExec.Length = 1 Then

                        AcctExec = AcctExec & ","

                    End If

                    DataTable = BuildWeekDTAccountExecutive(AcctExec.Replace("&", "").Replace("@", ""), "Dollars")
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataTable.Columns(3).ColumnName

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & AcctExec.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, ae, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTAccountExecutive(DataRow("ACCT_EXEC").ToString.Replace("&", "").Replace("@", ""), "Dollars")
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataRow("ACCT_NAME")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("ACCT_EXEC").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_JobType_Hours(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim JobTypeList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If jt <> "" Then

            JobTypeList = jt.Split(",")

            For Each JobType In JobTypeList

                DataTable = BuildWeekDTJobType(JobType.Replace("&", "").Replace("@", ""), "Hours")
                Session("ds_DASH_CompsByJobType") = DataTable
                Session("DB_JobType_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & JobType.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTJobType(DataRow("JT_CODE").ToString.Replace("&", "").Replace("@", ""), "Hours")
                    Session("ds_DASH_CompsByJobType") = DataTable
                    Session("DB_JobType_Caption") = DataRow("JT_DESC")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("JT_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateChart_JobType_Dollars(ByVal Dashboard As Webvantage.cDashboard, ByVal Count As Integer)

        'objects
        Dim JobTypeList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If jt <> "" Then

            JobTypeList = jt.Split(",")

            For Each JobType In JobTypeList

                DataTable = BuildWeekDTJobType(JobType.Replace("&", "").Replace("@", ""), "Dollars")
                Session("ds_DASH_CompsByJobType") = DataTable
                Session("DB_JobType_Caption") = DataTable.Columns(3).ColumnName

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & JobType.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, Count)

            If DataSet.Tables(1).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(1).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildWeekDTJobType(DataRow("JT_CODE").ToString.Replace("&", "").Replace("@", ""), "Dollars")
                    Session("ds_DASH_CompsByJobType") = DataTable
                    Session("DB_JobType_Caption") = DataRow("JT_DESC")

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("JT_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub

    Private Sub LoadData(ByVal datatype As String)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim Literal As System.Web.UI.WebControls.Literal = Nothing
        Dim count As Integer = 0

        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year = RadToolBarButton.Text
                count += 1

            End If

        Next

        For Each RadToolBarButton In Me.RadToolbarDashProject.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "Month" Then

                type = RadToolBarButton.Value

            End If

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "YeartoDate" Then

                type = RadToolBarButton.Value

            End If

        Next

        Me.PlaceHolderGraph.Controls.Clear()

        Try

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            If datatype = "Hours" Then

                Select Case Me.DropLevel.SelectedValue

                    Case "dept"

                        CreateChart_Department_Hours(Dashboard, count)

                    Case "SC"

                        CreateChart_SalesClass_Hours(Dashboard, count)

                    Case "C"

                        CreateChart_Client_Hours(Dashboard, count)

                    Case "CD"

                        CreateChart_Division_Hours(Dashboard, count)

                    Case "CDP"

                        CreateChart_Product_Hours(Dashboard, count)

                    Case "AE"

                        CreateChart_AccountExecutive_Hours(Dashboard, count)

                    Case "JT"

                        CreateChart_JobType_Hours(Dashboard, count)

                End Select

            ElseIf datatype = "Dollars" Then

                Select Case Me.DropLevel.SelectedValue

                    Case "dept"

                        CreateChart_Department_Dollars(Dashboard, count)

                    Case "SC"

                        CreateChart_SalesClass_Dollars(Dashboard, count)

                    Case "C"

                        CreateChart_Client_Dollars(Dashboard, count)

                    Case "CD"

                        CreateChart_Division_Dollars(Dashboard, count)

                    Case "CDP"

                        CreateChart_Product_Dollars(Dashboard, count)

                    Case "AE"

                        CreateChart_AccountExecutive_Dollars(Dashboard, count)

                    Case "JT"

                        CreateChart_JobType_Dollars(Dashboard, count)

                End Select

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        If Me.PlaceHolderGraph.Controls.Count = 0 Then

            Literal = New Literal
            Literal.ID = "lit1"
            Literal.Text = "No data to display."
            Me.PlaceHolderGraph.Controls.Add(Literal)

        End If

    End Sub

#End Region

End Class