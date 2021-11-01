Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardClient
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
    Protected WithEvents CancelledStatus As System.Web.UI.WebControls.TextBox

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
    Public type As String = ""
    Public dash As String = ""
    Public project As String = ""

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
                '    ' Me.RadToolbarDashDetail.Items(3).Enabled = False
                'End If
                Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
                Dim dsYears As DataSet

                dsYears = dash.GetPostPeriodsProject(Now.Date.Year)
                If dsYears.Tables(0).Rows.Count = 0 Then
                    Me.ShowMessage("No post periods for current year were found.")
                    Me.RadToolbarOptions.Enabled = False
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Me.IsPostBack Then
                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Range")
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
                    ElseIf taskVar <> "" Then
                        For i As Integer = 0 To Me.RadToolbarDashProject.Items.Count - 1
                            If Me.RadToolbarDashProject.Items(i).Value = taskVar Then
                                Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(i)
                                rtb.Checked = True
                            End If
                        Next
                    Else
                        Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(1)
                        rtb.Checked = True
                    End If
                    loadyears()
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Year")
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
                    ElseIf taskVar <> "" Then
                        Dim stryear2() As String = taskVar.Split("-")
                        For i As Integer = 0 To Me.RadToolbarData.Items.Count - 1
                            For j As Integer = 0 To stryear2.Length - 1
                                If Me.RadToolbarData.Items(i).Text = stryear2(j) Then
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
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Month")
                    If q.GetValue("month") <> "" Then
                        Me.DropMonth.SelectedValue = q.GetValue("month")
                    ElseIf taskVar <> "" Then
                        Me.DropMonth.SelectedValue = taskVar
                    End If
                    loadweeks()
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Week")
                    If q.GetValue("week") <> "" Then
                        Me.DropWeek.SelectedValue = q.GetValue("week")
                    ElseIf taskVar <> "" Then
                        Me.DropWeek.SelectedValue = taskVar
                    End If
                End With
                'Me.Title = "Client Time Analysis Selection"


            Else
                Select Case Me.EventArgument
                    Case "Refresh"
                        'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                        Me.RefreshGrid()
                    Case "HidePopups"

                End Select
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Me.IsPostBack Then
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try

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
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Value = "ExportAll" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashdata&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=Client', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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

    Private Sub RadGridOffice_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridOffice.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetOffices(Session("UserCode"))
            Dim newrow As DataRow
            newrow = ds.Tables(0).NewRow
            newrow.Item("OFFICE_CODE") = ""
            newrow.Item("OFFICE_NAME") = "All Offices"
            ds.Tables(0).Rows.InsertAt(newrow, 0)
            Me.RadGridOffice.DataSource = ds
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridOffice_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridOffice.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "OfficeCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridOffice.SelectedIndexChanged
        Try
            Dim officecode As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    officecode &= gridDataItem.GetDataKeyValue("OFFICE_CODE") & ","
                End If
            Next
            officecode = MiscFN.RemoveTrailingDelimiter(officecode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardClient", "OfficeCode", "", officecode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAE_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAE.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            dt = cdd.GetAccountExecsDT(Session("UserCode"), False)
            Dim newrow As DataRow
            newrow = dt.NewRow
            newrow.Item("Code") = ""
            newrow.Item("Description") = "All Account Executives"
            dt.Rows.InsertAt(newrow, 0)
            Me.RadGridAE.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAE_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAE.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "AECode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAE.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAE.SelectedIndexChanged
        Try
            Dim aecode As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAE.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    aecode &= gridDataItem.GetDataKeyValue("Code") & ","
                End If
            Next
            aecode = MiscFN.RemoveTrailingDelimiter(aecode, ",")
            If aecode.Length = 1 Then
                aecode = aecode & ","
            End If
            otask.setAppVars(Session("UserCode"), "DashboardClient", "AECode", "", aecode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridClient_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridClient.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            dt = cdd.GetClientNames(Session("UserCode"))
            Dim newrow As DataRow
            newrow = dt.NewRow
            newrow.Item("Code") = ""
            newrow.Item("Description") = "All Clients"
            dt.Rows.InsertAt(newrow, 0)
            Me.RadGridClient.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridClient_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridClient.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "ClientCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridClient.SelectedIndexChanged
        Try
            Dim clcode As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    clcode &= gridDataItem.GetDataKeyValue("Code") & ","
                End If
            Next
            clcode = MiscFN.RemoveTrailingDelimiter(clcode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardClient", "ClientCode", "", clcode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDepartment_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDepartment.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetDepts("", Session("UserCode"))
            Dim newrow As DataRow
            newrow = ds.Tables(0).NewRow
            newrow.Item("DP_TM_CODE") = ""
            newrow.Item("DP_TM_DESC") = "All Departments"
            ds.Tables(0).Rows.InsertAt(newrow, 0)
            Me.RadGridDepartment.DataSource = ds
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDepartment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDepartment.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "DeptCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDepartment.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDepartment.SelectedIndexChanged
        Try
            Dim deptcode As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDepartment.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    deptcode &= "''" & gridDataItem.GetDataKeyValue("DP_TM_CODE") & "'',"
                End If
            Next
            deptcode = MiscFN.RemoveTrailingDelimiter(deptcode, ",")
            If deptcode = "''''" Then
                otask.setAppVars(Session("UserCode"), "DashboardClient", "DeptCode", "", "")
            Else
                otask.setAppVars(Session("UserCode"), "DashboardClient", "DeptCode", "", deptcode)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSalesClass_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSalesClass.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            dt = cdd.GetSalesClassDT("DPS")
            Dim newrow As DataRow
            newrow = dt.NewRow
            newrow.Item("code") = ""
            newrow.Item("description") = "All Sales Classes"
            dt.Rows.InsertAt(newrow, 0)
            Me.RadGridSalesClass.DataSource = dt
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridSalesClass_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridSalesClass.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "SCCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSalesClass.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSalesClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridSalesClass.SelectedIndexChanged
        Try
            Dim sccode As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSalesClass.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    sccode &= gridDataItem.GetDataKeyValue("code") & ","
                End If
            Next
            sccode = MiscFN.RemoveTrailingDelimiter(sccode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardClient", "SCCode", "", sccode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobType_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobType.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            dt = cdd.ddJobName()
            Dim newrow As DataRow
            newrow = dt.NewRow
            newrow.Item("code") = ""
            newrow.Item("description") = "All Job Types"
            dt.Rows.InsertAt(newrow, 0)
            Me.RadGridJobType.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobType_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridJobType.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "JobType")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobType.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem("column3").Text = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridJobType.SelectedIndexChanged
        Try
            Dim jobtype As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobType.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    jobtype &= gridDataItem.GetDataKeyValue("code") & ","
                End If
            Next
            jobtype = MiscFN.RemoveTrailingDelimiter(jobtype, ",")
            otask.setAppVars(Session("UserCode"), "DashboardClient", "JobType", "", jobtype)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridProjects_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjects.NeedDataSource
    '    Try
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet

    '        ds = dash.GetProjectsByWeek("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", 0, 1)
    '        RadGridProjects.DataSource = ds.Tables(1)
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet

            ds = dash.GetPostPeriodsProject(Now.Date.Year)
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
            Dim tbButton As RadToolBarButton
            Dim count As Integer = 0
            Dim value As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    value = rtb.Value
                    count += 1
                End If
            Next
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

            Me.DropMonth.SelectedValue = ds.Tables(2).Rows(0)("PPPERIOD")
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To Me.DropMonth.Items.Count - 1
                For i As Integer = 0 To SortedPostPeriods.Rows.Count - 1
                    If Me.DropMonth.Items(i).Value = SortedPostPeriods.Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, SortedPostPeriods.Rows(i)("MONTH"), 1)
                        Me.DropMonth.Items(i).Text = String.Format(c, "{0:MMM}", d)
                    End If
                Next
            Next


            'Me.radMenu1.DataSource = ds.Tables(1)
            'Me.radMenu1.DataTextField = "PPDESC"
            'Me.radMenu1.DataValueField = "PPPERIOD"
            'Me.radMenu1.DataBind()
            'Me.radMenu1.Items.Add(New RadMenuItem("All"))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadweeks()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim tbButton As RadToolBarButton
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next

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

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Month", "", Me.DropMonth.SelectedValue)
            LoadData(type)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Dim type As String
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
            If rtb.Checked = True And rtb.Value = "Month" Then
                type = rtb.Value
            End If
            If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                type = rtb.Value
            End If
        Next
        otask.setAppVars(Session("UserCode"), "DashboardClient", "Week", "", Me.DropWeek.SelectedValue)
        Me.LoadData(type)
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim rtb As RadToolBarButton
            Dim rtb2 As RadToolBarButton
            Dim download As Boolean
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Data"

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
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim rtb As RadToolBarButton
            Dim rtb2 As RadToolBarButton
            Dim download As Boolean
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Bookmark"
                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()
                    qs.Page = "DashboardClient.aspx"
                    qs.Add("bm", "1")

                    With b
                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_ClientTimeAnalysis
                        .UserCode = Session("UserCode")
                        .Name = "Client Time Analysis"
                        .Description = "Client Time Analysis"
                        .PageURL = qs.ToString(True)
                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then
                        Me.ShowMessage(s)
                    End If
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                Case "Data"
                    download = dash.GetDataRefreshProject(Me.RadToolbarData.Items(0).Text, Me.RadToolbarData.Items(1).Text)
                    download = dash.GetDataRefreshClient(Me.RadToolbarData.Items(0).Text, Me.RadToolbarData.Items(1).Text)
                Case "ExportAll"

                    'Case "Summary"
                    '    Dim q As New AdvantageFramework.Web.QueryString()
                    '    Dim iscancel As Boolean = False
                    '    For Each rtbb As RadToolBarButton In Me.RadToolbarData.Items
                    '        If rtbb.Checked = True Then
                    '            year &= rtbb.Text & "-"
                    '        End If
                    '    Next
                    '    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    '    If cancel <> "" Then
                    '        iscancel = True
                    '    End If
                    '    For Each rtbb As RadToolBarButton In Me.RadToolbarDashProject.Items
                    '        If rtbb.Checked = True And rtbb.Value = "Month" Then
                    '            type = rtbb.Value
                    '        End If
                    '        If rtbb.Checked = True And rtbb.Value = "YeartoDate" Then
                    '            type = rtbb.Value
                    '        End If
                    '    Next
                    '    With q
                    '        .Page = "DashboardClientTime.aspx"
                    '        'setting some properties of the class
                    '        '.Year = year
                    '        'adding a "one time" value that doesn't need to be in the class
                    '        .Add("year", year)
                    '        .Add("month", Me.DropMonth.SelectedValue)
                    '        .Add("range", type)
                    '        .Add("week", Me.DropWeek.SelectedValue)
                    '        .Go()
                    '    End With
                Case Else
                    For Each radtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If radtb.Checked = True And radtb.Text <> "Month" And radtb.Text <> "Year to Date" Then
                            year = radtb.Text
                        End If
                    Next
                    loadmonths()
                    loadweeks()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarOptions_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarOptions.ButtonClick
        Try
            Dim q As New AdvantageFramework.Web.QueryString()
            Dim iscancel As Boolean = False
            For Each rtbb As RadToolBarButton In Me.RadToolbarData.Items
                If rtbb.Checked = True Then
                    year &= rtbb.Text & "-"
                End If
            Next
            year = MiscFN.RemoveTrailingDelimiter(year, "-")
            If cancel <> "" Then
                iscancel = True
            End If
            For Each rtbb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtbb.Checked = True And rtbb.Value = "Month" Then
                    type = rtbb.Value
                End If
                If rtbb.Checked = True And rtbb.Value = "YeartoDate" Then
                    type = rtbb.Value
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
                Select Case e.Item.Value
                    Case "Estimated"
                        .Add("option", "Estimated")
                    Case "Actual"
                        .Add("option", "Actual")
                    Case "Billable"
                        .Add("option", "Billable")
                    Case "Fee"
                        .Add("option", "Fee")
                    Case "Non Billable"
                        .Add("option", "Non_Billable")
                End Select
                .Go()
            End With

            'Me.OpenWindow(q)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadToolbarSummary_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSummary.ButtonClick
    '    Try
    '        Select Case e.Item.Value
    '            Case "Summary"
    '                Dim q As New AdvantageFramework.Web.QueryString()
    '                Dim iscancel As Boolean = False
    '                For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '                    If rtb.Checked = True Then
    '                        year &= rtb.Text & "-"
    '                    End If
    '                Next
    '                year = MiscFN.RemoveTrailingDelimiter(year, "-")
    '                If cancel <> "" Then
    '                    iscancel = True
    '                End If
    '                For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
    '                    If rtb.Checked = True And rtb.Value = "Month" Then
    '                        type = rtb.Value
    '                    End If
    '                    If rtb.Checked = True And rtb.Value = "YeartoDate" Then
    '                        type = rtb.Value
    '                    End If
    '                Next
    '                With q
    '                    .Page = "DashboardClientTime.aspx"
    '                    'setting some properties of the class
    '                    '.Year = year
    '                    'adding a "one time" value that doesn't need to be in the class
    '                    .Add("year", year)
    '                    .Add("month", Me.DropMonth.SelectedValue)
    '                    .Add("range", type)
    '                    .Add("week", Me.DropWeek.SelectedValue)
    '                    .Add("project", project)
    '                    .Add("dash", dash)
    '                    .Go()
    '                End With
    '                'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region " Functions "

    Private Sub LoadData(Optional ByVal type As String = "Month")
        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable
        Dim dtWeek As DataView
        Dim iscancel As Boolean = False

        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
            If rtb.Checked = True Then
                year = rtb.Text
            End If
        Next
        If cancel <> "" Then
            iscancel = True
        End If
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If type = "Month" Then
                'ds = dash.GetProjects("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", "", 0, 1, "", cancel, iscancel, Session("UserCode"), "Month")
            Else
                'ds = dash.GetProjects("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", "", 0, 1, "", cancel, iscancel, Session("UserCode"), "YeartoDate")
            End If
            'dt = dash.GetJobStatistics(Session("UserCode"), year, Me.DropWeek.SelectedValue, "", False)
            'Dim dv As DataView = New DataView(dt)
            'dv.RowFilter = "CL_CODE = 'ALL_CLIENTS'"
            ' dt = dv.ToTable
            'ds.Tables.Add(dt.Copy())
            Session("ds_DASH_Comps") = ds

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region




















    
End Class
