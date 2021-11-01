Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardClientTimeDetail
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
    Protected WithEvents CheckBoxExport As CheckBox
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
            Me.CheckBoxExport = Me.RadToolbarPE.Items(7).FindControl("CheckBoxExport")
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
                '    'Me.RadToolbarDash.Items(3).Enabled = False
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
                dash = q.GetValue("dash")
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Level")
                If taskVar <> "" Then
                    Me.DropLevel.SelectedValue = taskVar
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
            If dash = "M" Then
                'buildRGMonthEmployee()
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridComps.Visible = False
                Me.RadGridYear.Visible = False
                If datatype = "Hours" Then
                    Me.Title = project & " Hours Each Month By " & Me.DropLevel.SelectedItem.Text
                End If
                If datatype = "Dollars" Then
                    Me.Title = project & " Dollars Each Month By " & Me.DropLevel.SelectedItem.Text
                End If
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridMonth.Visible = False
                Me.RadGridYear.Visible = False
                If datatype = "Hours" Then
                    Me.Title = project & " Hours Each Week By " & Me.DropLevel.SelectedItem.Text
                End If
                If datatype = "Dollars" Then
                    Me.Title = project & " Dollars Each Week By " & Me.DropLevel.SelectedItem.Text
                End If
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridComps.Visible = False
                Me.RadGridMonth.Visible = False
                If datatype = "Hours" Then
                    Me.Title = project & " Hours Each Year By " & Me.DropLevel.SelectedItem.Text
                End If
                If datatype = "Dollars" Then
                    Me.Title = project & " Dollars Each Year By " & Me.DropLevel.SelectedItem.Text
                End If
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"

            End Select
        End If


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
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?db=client&From=dashclientdetail&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&datatype=" & datatype & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?db=client&From=dashclientdetail&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&datatype=" & datatype & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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

    Private Sub RadGridComps_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComps.ItemDataBound
        Try
            Dim countyear As Integer
            Dim grandTotal As Decimal
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    countyear += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            Dim dashdata As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            If datatype = "Hours" Then
                'If dash = "W" Then
                ds = dashdata.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If
            If datatype = "Dollars" Then
                'If dash = "W" Then
                ds = dashdata.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If

            Dim total As Decimal
            Dim totalmonth As Decimal
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                For i As Integer = 3 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                    End If
                Next

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                If datatype = "Hours" Then
                    If dash = "W" Then
                        e.Item.Cells(3).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("HOURS")))
                                        total += ds.Tables(3).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                    End If
                End If
                If datatype = "Dollars" Then
                    If dash = "W" Then
                        e.Item.Cells(3).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", CDec(ds.Tables(3).Rows(j)("DOLLARS")))
                                        total += ds.Tables(3).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                            Next
                        End If
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridComps_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComps.NeedDataSource
        Try
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            'If dash = "W" Then
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridComps.DataSource = BuildWeekDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridComps.DataSource = BuildWeekDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridComps.DataSource = BuildWeekDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridComps.DataSource = BuildWeekDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridComps.DataSource = BuildWeekDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridComps.DataSource = BuildWeekDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridComps.DataSource = BuildWeekDTJobType()
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridMonth_DetailTableDataBind(sender As Object, e As GridDetailTableDataBindEventArgs) Handles RadGridMonth.DetailTableDataBind
    '    Try
    '        e.DetailTableView.DataSource = BuildMonthDTEmployee()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub RadGridMonth_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMonth.ItemDataBound
        Try
            Dim countyear As Integer
            Dim grandTotal As Decimal
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    countyear += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            Dim dashdata As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            If datatype = "Hours" Then
                'If dash = "M" Then
                ds = dashdata.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If
            If datatype = "Dollars" Then
                'If dash = "M" Then
                ds = dashdata.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If

            Dim total As Decimal
            Dim totalmonth As Decimal
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                For i As Integer = 3 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                    End If
                Next
            ElseIf e.Item.ItemType = GridItemType.GroupFooter Then

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                If datatype = "Hours" Then
                    If dash = "M" Then
                        e.Item.Cells(2).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Department" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Product" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                    End If
                End If
                If datatype = "Dollars" Then
                    If dash = "M" Then
                        e.Item.Cells(2).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Department" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Product" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                                    e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridMonth_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMonth.NeedDataSource
        Try
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridMonth.DataSource = BuildMonthDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridMonth.DataSource = BuildMonthDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridMonth.DataSource = BuildMonthDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridMonth.DataSource = BuildMonthDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridMonth.DataSource = BuildMonthDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridMonth.DataSource = BuildMonthDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridMonth.DataSource = BuildMonthDTJobType()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridMonth_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGridMonth.SortCommand
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridYear_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridYear.ItemDataBound
        Try
            Dim countyear As Integer
            Dim grandTotal As Decimal
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    countyear += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            Dim dashdata As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            If datatype = "Hours" Then
                'If dash = "Y" Then
                ds = dashdata.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If
            If datatype = "Dollars" Then
                'If dash = "Y" Then
                ds = dashdata.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
                'End If
            End If

            Dim total As Decimal
            Dim totalmonth As Decimal
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                For i As Integer = 3 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                    End If
                Next

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                If datatype = "Hours" Then
                    If dash = "Y" Then
                        e.Item.Cells(2).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Department" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Product" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("HOURS"))
                                        total += ds.Tables(2).Rows(j)("HOURS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                    End If
                End If
                If datatype = "Dollars" Then
                    If dash = "Y" Then
                        e.Item.Cells(2).Text = "Totals:"
                        If Me.DropLevel.SelectedValue = "dept" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Department" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Product" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                                totalmonth = 0
                                For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                        totalmonth += CDec(ds.Tables(2).Rows(j)("DOLLARS"))
                                        total += ds.Tables(2).Rows(j)("DOLLARS")
                                    End If
                                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", total)
                                    End If
                                Next
                                If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                                    e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = String.Format("{0:#,##0.00}", totalmonth)
                                End If
                            Next
                        End If
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridYear_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridYear.NeedDataSource
        Try
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridYear.DataSource = BuildYearDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridYear.DataSource = BuildYearDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridYear.DataSource = BuildYearDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridYear.DataSource = BuildYearDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridYear.DataSource = BuildYearDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridYear.DataSource = BuildYearDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridYear.DataSource = BuildYearDTJobType()
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridMonth_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMonth.ItemDataBound
    '    Try
    '        Dim countyear As Integer
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '                countyear += 1
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
    '        Dim total As Decimal
    '        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

    '        ElseIf e.Item.ItemType = GridItemType.Footer Then
    '            e.Item.Cells(2).Text = "Totals:"
    '            If Me.DropLevel.SelectedValue = "dept" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "SC" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "C" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "CD" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "CDP" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "AE" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "JT" Then
    '                For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridMonth_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMonth.NeedDataSource
    '    Try
    '        'If Me.DropLevel.SelectedValue = "dept" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDT()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "SC" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTSalesClass()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "C" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTClient()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "CD" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTCD()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "CDP" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTCDP()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "AE" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTAccountExecutive()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "JT" Then
    '        '    Me.RadGridMonth.DataSource = BuildMonthDTJobType()
    '        'End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridYear_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridYear.ItemDataBound
    '    Try
    '        Dim countyear As Integer
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '                countyear += 1
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
    '        Dim total As Decimal
    '        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

    '        ElseIf e.Item.ItemType = GridItemType.Footer Then
    '            e.Item.Cells(2).Text = "Totals:"
    '            If Me.DropLevel.SelectedValue = "dept" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "SC" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "C" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "CD" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "CDP" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "AE" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If Me.DropLevel.SelectedValue = "JT" Then
    '                For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                    For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                        Dim str As String = Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "")
    '                        If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                            total += ds.Tables(3).Rows(j)("COMPS")
    '                        End If
    '                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                        End If
    '                    Next
    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridYear_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridYear.NeedDataSource
    '    Try
    '        'If Me.DropLevel.SelectedValue = "dept" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDT()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "SC" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTSalesClass()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "C" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTClient()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "CD" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTCD()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "CDP" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTCDP()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "AE" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTAccountExecutive()
    '        'End If
    '        'If Me.DropLevel.SelectedValue = "JT" Then
    '        '    Me.RadGridYear.DataSource = BuildYearDTJobType()
    '        'End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function BuildWeekDT()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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
            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDT()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Department")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Department") = ds.Tables(1).Rows(j)("DP_TM_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "DP_TM_CODE = '" & ds.Tables(1).Rows(j)("DP_TM_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Department") = ds.Tables(3).Rows(n)("DP_TM_DESC") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTSalesClass()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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


            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTSalesClass()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Sales Class")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Sales Class") = ds.Tables(1).Rows(j)("SC_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "SC_CODE = '" & ds.Tables(1).Rows(j)("SC_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Sales Class") = ds.Tables(3).Rows(n)("SC_DESCRIPTION") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTClient()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTClient()
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
            Dim dsEmp As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Client")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Client") = ds.Tables(3).Rows(n)("CL_NAME") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTCD()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCD()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            dtComps.Columns.Add(colclient)
            dtComps.Columns.Add(coldivision)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Client") = ds.Tables(3).Rows(n)("CL_NAME") And dtComps.Rows(z)("Division") = ds.Tables(3).Rows(n)("DIV_NAME") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTCDP()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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


            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCDP()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            Dim colproduct As DataColumn = New DataColumn("Product")
            dtComps.Columns.Add(colclient)
            dtComps.Columns.Add(coldivision)
            dtComps.Columns.Add(colproduct)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                newrow.Item("Product") = ds.Tables(1).Rows(j)("PRD_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "' AND PRD_CODE = '" & ds.Tables(1).Rows(j)("PRD_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Client") = ds.Tables(3).Rows(n)("CL_NAME") And dtComps.Rows(z)("Division") = ds.Tables(3).Rows(n)("DIV_NAME") And dtComps.Rows(z)("Product") = ds.Tables(3).Rows(n)("PRD_DESCRIPTION") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTAccountExecutive()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTAccountExecutive()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Account Executive")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Account Executive") = ds.Tables(1).Rows(j)("ACCT_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "ACCT_EXEC = '" & ds.Tables(1).Rows(j)("ACCT_EXEC") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Account Executive") = ds.Tables(3).Rows(n)("ACCT_NAME") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildWeekDTJobType()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTJobType()
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
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Job Type")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Job Type") = ds.Tables(1).Rows(j)("JT_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "JT_CODE = '" & ds.Tables(1).Rows(j)("JT_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Job Type") = ds.Tables(3).Rows(n)("JT_DESC") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function


    Private Function buildRG()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonth()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Department"
            boundColumn.HeaderText = "Department"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGSalesClass()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthSalesClass()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Sales Class"
            boundColumn.HeaderText = "Sales Class"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGClient()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthClient()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.SortExpression = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    'boundColumn.Aggregate = GridAggregateFunction.Sum
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            ' boundColumn.Aggregate = GridAggregateFunction.Sum
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.SortExpression = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGCD()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthCD()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGCDP()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthCDP()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Product"
            boundColumn.HeaderText = "Product"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGAccountExecutive()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("ACCT_NAME")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthAccountExecutive()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Account Executive"
            boundColumn.HeaderText = "Account Executive"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGJobType()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            If Me.datatype = "Hours" Then
                ds = dash.GetHoursByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If Me.datatype = "Dollars" Then
                ds = dash.GetDollarsByWeek("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    'boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("JT_DESC")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthJobType()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Job Type"
            boundColumn.HeaderText = "Job Type"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function

    Private Function BuildYearDT()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Department")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Department") = ds.Tables(1).Rows(j)("DP_TM_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "DP_TM_CODE = '" & ds.Tables(1).Rows(j)("DP_TM_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTSalesClass()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Sales Class")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Sales Class") = ds.Tables(1).Rows(j)("SC_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "SC_CODE = '" & ds.Tables(1).Rows(j)("SC_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTClient()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Client")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTCD()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            dtComps.Columns.Add(colclient)
            dtComps.Columns.Add(coldivision)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTCDP()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            Dim colproduct As DataColumn = New DataColumn("Product")
            dtComps.Columns.Add(colclient)
            dtComps.Columns.Add(coldivision)
            dtComps.Columns.Add(colproduct)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                newrow.Item("Product") = ds.Tables(1).Rows(j)("PRD_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "' AND PRD_CODE = '" & ds.Tables(1).Rows(j)("PRD_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTAccountExecutive()
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
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Account Executive")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Account Executive") = ds.Tables(1).Rows(j)("ACCT_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "ACCT_EXEC = '" & ds.Tables(1).Rows(j)("ACCT_EXEC") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildYearDTJobType()
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
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Job Type")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Job Type") = ds.Tables(1).Rows(j)("JT_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "JT_CODE = '" & ds.Tables(1).Rows(j)("JT_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function buildRGYear()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Department"
            boundColumn.HeaderText = "Department"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearSalesClass()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Sales Class"
            boundColumn.HeaderText = "Sales Class"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearClient()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearCD()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearCDP()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Product"
            boundColumn.HeaderText = "Product"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearAccountExecutive()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Account Executive"
            boundColumn.HeaderText = "Account Executive"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearJobType()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByYear("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Job Type"
            boundColumn.HeaderText = "Job Type"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function


    Private Function buildRGMonthEmployee()
        Try
            'Me.RadGridMonth.MasterTableView.DetailTables(0).Columns.Clear()
            Dim ct As Integer = Me.RadGridMonth.MasterTableView.DetailTables.Count
            Dim tableEmps As GridTableView = Me.RadGridMonth.MasterTableView.DetailTables(0)
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
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, "EMP", cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, "EMP", cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Employee"
            boundColumn.HeaderText = "Employee"
            boundColumn.SortExpression = "Employee"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            tableEmps.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "colEmp" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    'boundColumn.Aggregate = GridAggregateFunction.Sum
                    tableEmps.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            ' boundColumn.Aggregate = GridAggregateFunction.Sum
            tableEmps.Columns.Add(boundColumn)

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Percent"
            boundColumn.HeaderText = "Percent"
            boundColumn.SortExpression = "Percent"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            tableEmps.Columns.Add(boundColumn)

            ' RadGridMonth.MasterTableView.DetailTables.Add(tableEmps)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTEmployee()
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
            Dim dsEmp As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, "amerx", DeptCode, sc, jt, 0, 1, "EMP", cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, "EMP", cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Employee")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")
            dtComps.Columns.Add("Percent")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Employee") = ds.Tables(1).Rows(j)("EMP_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "EMP_CODE = '" & ds.Tables(1).Rows(j)("EMP_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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

            For z As Integer = 0 To dtComps.Rows.Count - 1
                For n As Integer = 0 To ds.Tables(3).Rows.Count - 1
                    If dtComps.Rows(z)("Employee") = ds.Tables(3).Rows(n)("EMP_NAME") Then
                        If datatype = "Hours" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_HOURS")
                        End If
                        If datatype = "Dollars" Then
                            dtComps.Rows(z)("Percent") = ds.Tables(3).Rows(n)("PERCENT_DOLLARS")
                        End If
                    End If
                Next
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

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
            'For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
            '    If MenuItem.Selected = True Then
            '        year = MenuItem.Text
            '    End If
            'Next
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim month As String = Me.DropMonth.SelectedValue
            ds = dash.GetPostPeriodsProject(year)
            With Me.DropMonth
                .DataSource = ds.Tables(1)
                .DataTextField = "PPDESC"
                .DataValueField = "PPPERIOD"
                .DataBind()
            End With
            Me.DropMonth.SelectedValue = month
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To Me.DropMonth.Items.Count - 1
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    If Me.DropMonth.Items(i).Value = ds.Tables(1).Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, ds.Tables(1).Rows(i)("PPGLMONTH"), 1)
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
            'For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
            '    If MenuItem.Selected = True Then
            '        year = MenuItem.Text
            '    End If
            'Next
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
            Me.DropWeek.SelectedValue = week
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim type As String
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Month", "", Me.DropMonth.SelectedValue)
            loadweeks()
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Week", "", Me.DropWeek.SelectedValue)
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
            End If


            'Me.RadGridMonth.Rebind()
            'Me.RadGridYear.Rebind()
            'Me.LoadData(type)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Level", "", Me.DropLevel.SelectedValue)
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.Title = project & " Hours Each Month By " & Me.DropLevel.SelectedItem.Text
                Me.RadGridMonth.Rebind()
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.Title = project & " Hours Each Week By " & Me.DropLevel.SelectedItem.Text
                Me.RadGridComps.Rebind()
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.Title = project & " Hours Each Year By " & Me.DropLevel.SelectedItem.Text
                Me.RadGridYear.Rebind()
            End If


            'Me.RadGridComps.Rebind()
            'Me.RadGridMonth.Rebind()
            'Me.RadGridYear.Rebind()
            ' Me.LoadData(type)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Data"
                    Dim download As Boolean
                    Dim dashdata As New cDashboard(Session("ConnString"), Session("UserCode"))
                    'If e.Item.Value = "Data" Then                    
                    download = dashdata.GetDataRefreshProject("", "")
                    'End If
                    'Me.radMenu1.Items(0).Selected = False
                    Dim q As New AdvantageFramework.Web.QueryString()
                    q = q.FromCurrent()
                    With Response
                        dash = q.GetValue("dash")
                    End With
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If


                    '
                    'Me.RadGridYear.Rebind()
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
                    Dim q As New AdvantageFramework.Web.QueryString()
                    q = q.FromCurrent()
                    With Response
                        dash = q.GetValue("dash")
                    End With
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If

                    'Me.RadGridComps.Rebind()
                    ' Me.RadGridMonth.Rebind()
                    'Me.RadGridYear.Rebind()
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    Dim q As New AdvantageFramework.Web.QueryString()
                    q = q.FromCurrent()
                    With Response
                        dash = q.GetValue("dash")
                    End With
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If

                    ' Me.RadGridComps.Rebind()
                    'Me.RadGridMonth.Rebind()
                    'Me.RadGridYear.Rebind()
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    Dim q As New AdvantageFramework.Web.QueryString()
                    q = q.FromCurrent()
                    With Response
                        dash = q.GetValue("dash")
                    End With
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If

                    Me.RadGridComps.Rebind()
                    'Me.RadGridMonth.Rebind()
                    'Me.RadGridYear.Rebind()

            End Select
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
                        .Add("project", project)
                        .Add("dash", dash)
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
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
                project = q.GetValue("option").Replace("_", " ")
            End With
            Select Case e.Item.Value
                Case "Hours"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.Title = project & " Hours Each Month By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.Title = project & " Hours Each Week By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.Title = project & " Hours Each Year By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridYear.Rebind()
                    End If
                Case "Dollars"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.Title = project & " Dollars Each Month By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.Title = project & " Dollars Each Week By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.Title = project & " Dollars Each Year By " & Me.DropLevel.SelectedItem.Text
                        Me.RadGridYear.Rebind()
                    End If
            End Select
            'Me.RadGridComps.Rebind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_JobStatistics(Session("ds_DASH_Comps"), "")
    End Function

    Public Function WriteXMLPie() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_PieProjects(Session("ds_DASH_Comps_Pie"), "", "", "", True)
    End Function

    Public Function WriteXMLPieSelection() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        If Me.DropLevel.SelectedValue = "C" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "CL_NAME", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "DIV_NAME", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "PRD_DESCRIPTION", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "ACCT_NAME", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "DP_TM_DESC", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "SC_DESCRIPTION", project, "", True)
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return dash.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "JT_DESC", project, "", True)
        End If

    End Function

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
            Session("ds_DASH_Comps") = ds
            Session("ds_DASH_Comps_Pie") = ds
            If type = "Month" Then
                'ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project)
            Else
                'ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project)
            End If
            Session("ds_DASH_Comps_Pie_ByLevel") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region
















    
    
End Class