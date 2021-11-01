Imports Telerik.Web.UI
Public Class dtp_myprojects
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim search As String = ""
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Try
                        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
                        Dim SortBy As String = Request.QueryString("sort")
                        If SortBy = "" Then
                            SortBy = "duedate"
                        End If
                        If Request.QueryString("type") = "all" Then
                            search = otask.getAppVars(Session("UserCode"), "AllProjects", "ProjectAllSearch")
                            Me.lblTitle.Text = "All Projects"
                            'Me.rpMyProjects.DataSource = oDO.DesktopObject_GetAllProjectsSort(CStr(Session("EmpCode")), SortBy, search)
                            Me.TasksRadGrid2.DataSource = oDO.DesktopObject_GetAllProjectsSort(CStr(Session("EmpCode")), SortBy, search)
                        ElseIf Request.QueryString("type") = "my" Then
                            search = otask.getAppVars(Session("UserCode"), "MyProjects", "ProjectMySearch")
                            Me.lblTitle.Text = "My Projects"
                            'Me.rpMyProjects.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), SortBy, search)
                            Me.TasksRadGrid2.DataSource = oDO.DesktopObject_GetMyProjectsSort(CStr(Session("EmpCode")), SortBy, search, Me.IsClientPortal, Session("UserID"))
                        End If
                        Me.TasksRadGrid2.DataBind()
                        'Me.rpMyProjects.DataBind()

                        Dim sort As String
                        Dim sort2 As String
                        If Request.QueryString("type") = "all" Then
                            If Not Session("AllProjectsDOSortExp") Is Nothing Then
                                If Session("AllProjectsDOSortExp") <> "" Then
                                    Dim expr As New GridSortExpression
                                    sort = Session("AllProjectsDOSortExp").ToString
                                    'sort = sort.Substring(0, sort.Length - 1)
                                    Dim sortexpr2() As String = sort.Split(",")
                                    For i As Integer = 0 To sortexpr2.Length - 1
                                        sortexpr2(i) = sortexpr2(i).Trim
                                        Dim sortstr2() As String = sortexpr2(i).Split(" ")
                                        expr = New GridSortExpression
                                        expr.FieldName = sortstr2(0).Trim
                                        If sortstr2(1).Trim = "ASC" Then
                                            expr.SortOrder = GridSortOrder.Ascending
                                        ElseIf sortstr2(1).Trim = "DESC" Then
                                            expr.SortOrder = GridSortOrder.Descending
                                        Else
                                            expr.SortOrder = GridSortOrder.None
                                        End If
                                        Me.TasksRadGrid2.MasterTableView.SortExpressions.AddSortExpression(expr)
                                    Next
                                End If
                            End If
                        End If
                        Dim sort3 As String
                        Dim sort4 As String
                        If Request.QueryString("type") = "my" Then
                            If Not Session("MyProjectsDOSortExp") Is Nothing Then
                                If Session("MyProjectsDOSortExp") <> "" Then
                                    Dim expr As New GridSortExpression
                                    sort3 = Session("MyProjectsDOSortExp").ToString
                                    'sort = sort.Substring(0, sort.Length - 1)
                                    Dim sortexpr3() As String = sort3.Split(",")
                                    For i As Integer = 0 To sortexpr3.Length - 1
                                        sortexpr3(i) = sortexpr3(i).Trim
                                        Dim sortstr3() As String = sortexpr3(i).Split(" ")
                                        expr = New GridSortExpression
                                        expr.FieldName = sortstr3(0).Trim
                                        If sortstr3(1).Trim = "ASC" Then
                                            expr.SortOrder = GridSortOrder.Ascending
                                        ElseIf sortstr3(1).Trim = "DESC" Then
                                            expr.SortOrder = GridSortOrder.Descending
                                        Else
                                            expr.SortOrder = GridSortOrder.None
                                        End If
                                        Me.TasksRadGrid2.MasterTableView.SortExpressions.AddSortExpression(expr)
                                    Next
                                End If
                            End If
                        End If

                        Me.TasksRadGrid2.Rebind()

                    Catch ex As Exception

                    End Try
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub LoadGrid(ByVal SortOrder As String)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        ' Me.rpMyProjects.DataSource = oDO.GetMyProjects(CStr(Session("EmpCode")), SortOrder)
        'Me.rpMyProjects.DataBind()

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                If Request.QueryString("type") = "all" Then
                    str = "Projects_All" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                ElseIf Request.QueryString("type") = "my" Then
                    str = "Projects_My" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                End If
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.TasksRadGrid2, str)
                TasksRadGrid2.MasterTableView.ExportToExcel()
            Else
                'Me.TasksRadGrid.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class