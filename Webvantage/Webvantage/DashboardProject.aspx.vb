Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProject
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
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_ProjectStatisticsDQ) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Me.IsPostBack Then
                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Range")
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
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Year")
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
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Month")
                    If q.GetValue("month") <> "" Then
                        Me.DropMonth.SelectedValue = q.GetValue("month")
                    ElseIf taskVar <> "" Then
                        Me.DropMonth.SelectedValue = taskVar
                    End If
                    loadweeks()
                    taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Week")
                    If q.GetValue("week") <> "" Then
                        Me.DropWeek.SelectedValue = HttpContext.Current.Server.UrlDecode(q.GetValue("week"))
                    ElseIf taskVar <> "" Then
                        Me.DropWeek.SelectedValue = taskVar
                    End If
                End With
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "IsCancelled")
                If taskVar <> "" Then
                    Me.ChkIsClosedStatus.Checked = taskVar
                End If
                If Me.ChkIsClosedStatus.Checked = False Then
                    Me.RadToolbarProject.Items(9).Text = "Projects in Status"
                End If
                'Me.Title = "Project Statistics"
            Else
                Select Case Me.EventArgument
                    Case "Refresh"

                End Select
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

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
    '    End With
    '    dr = cdd.GetAccountExecutive("", "", "")
    '    With Me.DropAE
    '        .DataSource = dr
    '        .DataTextField = "Description"
    '        .DataValueField = "Code"
    '        .DataBind()
    '    End With
    '    dr = cdd.GetClientList(Session("UserCode"))
    '    With Me.DropClient
    '        .DataSource = dr
    '        .DataTextField = "Description"
    '        .DataValueField = "Code"
    '        .DataBind()
    '    End With
    '    ds = dash.GetDepts("", Session("UserCode"))
    '    With Me.DropDept
    '        .DataSource = ds
    '        .DataTextField = "DP_TM_DESC"
    '        .DataValueField = "DP_TM_CODE"
    '        .DataBind()
    '    End With
    '    dr = cdd.GetSalesClass()
    '    With Me.DropSalesClass
    '        .DataSource = dr
    '        .DataTextField = "description"
    '        .DataValueField = "code"
    '        .DataBind()
    '    End With
    '    dr = cdd.ddJobType()
    '    With Me.DropJobType
    '        .DataSource = dr
    '        .DataTextField = "description"
    '        .DataValueField = "code"
    '        .DataBind()
    '    End With
    'End Sub

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
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashdata&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=Stats', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "OfficeCode")
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "OfficeCode", "", officecode)
            Me.txt1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAE_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAE.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            Dim dv As DataView
            dt = cdd.GetAccountExecsDT(Session("UserCode"), False)
            dv = dt.DefaultView
            dv.Sort = "Description"
            dt = dv.ToTable
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "AECode")
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "AECode", "", aecode)
            Me.txt1.Focus()
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "ClientCode")
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "ClientCode", "", clcode)
            Me.txt1.Focus()
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "DeptCode")
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
                    deptcode &= gridDataItem.GetDataKeyValue("DP_TM_CODE") & ","
                End If
            Next
            deptcode = MiscFN.RemoveTrailingDelimiter(deptcode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardProject", "DeptCode", "", deptcode)
            Me.txt1.Focus()
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "SCCode")
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "SCCode", "", sccode)
            Me.txt1.Focus()
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "JobType")
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "JobType", "", jobtype)
            Me.txt1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCancelledStatus_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCancelledStatus.NeedDataSource
        Try
            Dim cdd As New cDropDowns(Session("ConnString"))
            Dim dt As DataTable
            dt = cdd.GetTrafficNames
            Dim newrow As DataRow
            newrow = dt.NewRow
            newrow.Item("Code") = ""
            newrow.Item("CodeDescription") = "No Status"
            dt.Rows.InsertAt(newrow, 0)
            Me.RadGridCancelledStatus.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCancelledStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridCancelledStatus.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "CancelCode")
            If taskVar <> "" Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCancelledStatus.MasterTableView.Items
                    If gridDataItem("column3").Text = taskVar Then
                        gridDataItem.Selected = True
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCancelledStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridCancelledStatus.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCancelledStatus.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    Me.cancel = gridDataItem.GetDataKeyValue("Code")
                    Me.cancelDesc = gridDataItem.GetDataKeyValue("CodeDescription")
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardProject", "CancelCode", "", cancel)
            otask.setAppVars(Session("UserCode"), "DashboardProject", "CancelDesc", "", cancelDesc)
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

            'ds = dash.GetPostPeriodsProject(Now.Date.Year)
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadmonths()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
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
            'ds = dash.GetPostPeriodsProject(year)
            'With Me.DropMonth
            '    .DataSource = ds.Tables(1)
            '    .DataTextField = "PPDESC"
            '    .DataValueField = "PPPERIOD"
            '    .DataBind()
            'End With

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

            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 0, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = ds.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With

            Me.DropWeek.SelectedValue = ds.Tables(1).Rows(0)("WEEK_END")

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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
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
        otask.setAppVars(Session("UserCode"), "DashboardProject", "Week", "", Me.DropWeek.SelectedValue)
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
                    download = dash.GetDataRefreshProject(Me.RadToolbarData.Items(0).Text, Me.RadToolbarData.Items(1).Text)
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
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                Case "Data"
                    download = dash.GetDataRefreshProject(Me.RadToolbarData.Items(0).Text, Me.RadToolbarData.Items(1).Text)
                Case "ExportAll"

                Case "Bookmark"
                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()
                    qs.Page = "DashboardProject.aspx"
                    qs.Add("bm", "1")

                    With b
                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectStatistics
                        .UserCode = Session("UserCode")
                        .Name = "Project Statistics"
                        .Description = "Project Statistics"
                        .PageURL = qs.ToString(True)
                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then
                        Me.ShowMessage(s)
                    End If

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

    Private Sub RadToolbarProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProject.ButtonClick
        Try
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
                .Page = "DashboardProjectComp.aspx"
                'setting some properties of the class
                '.Year = year
                'adding a "one time" value that doesn't need to be in the class
                .Add("year", year)
                .Add("month", Me.DropMonth.SelectedValue)
                .Add("range", type)
                .Add("week", Me.DropWeek.SelectedValue)
                Select Case e.Item.Value
                    Case "Created"
                        .Add("project", "Created")
                    Case "Completed"
                        .Add("project", "Completed")
                    Case "Due"
                        .Add("project", "Due")
                    Case "Pending"
                        .Add("project", "Pending")
                    Case "Cancelled"
                        .Add("project", "Cancelled")
                End Select
                .Add("dash", dash)
                .Go()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkIsClosedStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIsClosedStatus.CheckedChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "IsCancelled", "", Me.ChkIsClosedStatus.Checked)
            If Me.ChkIsClosedStatus.Checked = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
            Else
                Me.RadToolbarProject.Items(9).Text = "Projects Cancelled"
            End If
        Catch ex As Exception

        End Try
    End Sub

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
