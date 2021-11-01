Public Partial Class MobileTasks
    Inherits MobileBase
    Public strTaskStatus As String
    Public sRestrictBrowser() As String
    Protected WithEvents ViewHyperlink As System.Web.UI.WebControls.HyperLink

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sRestrictBrowser = Split(System.Configuration.ConfigurationManager.AppSettings("RestrictMobile").ToString(), ",")
        strTaskStatus = Me.ddType.SelectedValue
        LoadTasks()
        HideColumns()
    End Sub
    Public Sub HideColumns()
        If (Not IsNothing(Request.Headers("User-Agent"))) Then
            If Not IsNothing(sRestrictBrowser) Then
                For i As Integer = 0 To sRestrictBrowser.GetUpperBound(0)
                    If Request.Headers("User-Agent").Contains(sRestrictBrowser(i).ToString()) Then
                        Me.gvMyTasks.Columns(4).Visible = False
                        Me.gvMyTasks.Columns(5).Visible = False
                        Me.gvMyTasks.Columns(6).Visible = False
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub LoadTasks()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        If (Not IsNothing(Request.Headers("User-Agent"))) Then
            If Not IsNothing(sRestrictBrowser) Then
                For i As Integer = 0 To sRestrictBrowser.GetUpperBound(0)
                    If Request.Headers("User-Agent").Contains(sRestrictBrowser(i).ToString()) Then
                        Dim DtRepeater As New DataTable
                        Try
                            Select Case (Me.ddType.SelectedValue.ToUpper)
                                Case "PROJECTED"
                                    DtRepeater = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "P", Me.ddTaskShow.SelectedValue)
                                Case "ACTIVE"
                                    DtRepeater = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "A", Me.ddTaskShow.SelectedValue)
                                Case Else
                                    DtRepeater = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "", Me.ddTaskShow.SelectedValue)
                            End Select
                            rptTasks.Visible = True
                        Catch ex As Exception
                            DtRepeater = Nothing
                        End Try
                        Try
                            If Not DtRepeater Is Nothing Then
                                rptTasks.DataSource = DtRepeater
                                rptTasks.DataBind()
                            End If
                        Catch ex As Exception
                            Response.Write(ex.Message.ToString())
                        End Try
                        gvMyTasks.Visible = False
                        Exit Sub
                    End If
                Next
            End If
        End If

        'not a restricted browser
        Dim dt As New DataTable
        Try
            Select Case (Me.ddType.SelectedValue.ToUpper)
                Case "PROJECTED"
                    dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "P", Me.ddTaskShow.SelectedValue)
                Case "ACTIVE"
                    dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "A", Me.ddTaskShow.SelectedValue)
                Case Else
                    dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), "", Me.ddTaskShow.SelectedValue)
            End Select
        Catch ex As Exception
            dt = Nothing
        End Try
        Try
            If Not dt Is Nothing Then
                gvMyTasks.DataSource = dt
                gvMyTasks.DataBind()
            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try

    End Sub

    Private Sub gvMyTasks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMyTasks.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim ViewHyperlink As System.Web.UI.WebControls.HyperLink = e.Row.Cells(0).FindControl("ViewHyperlink")
                Dim IsEventTask As Boolean = False
                Try
                    IsEventTask = e.Row.DataItem("IS_EVENT")
                Catch ex As Exception
                    IsEventTask = False
                End Try
                If IsEventTask = False Then
                    ViewHyperlink.NavigateUrl = "~/Mobile/mobiletaskdetail.aspx?JobNo=" & e.Row.DataItem("JobNo") & "&JobComp=" & e.Row.DataItem("JobComp") & "&SeqNo=" & e.Row.DataItem("SeqNo") & "&EmpCode=" & e.Row.DataItem("EmpCode")
                    ViewHyperlink.ImageUrl = "~/images/view-trans.png"
                Else
                    ViewHyperlink.Visible = False
                End If

            Catch ex As Exception
            End Try
            Try
                If IsDate(e.Row.DataItem("DueDate")) = True Then
                    Dim DueDateLabel As New System.Web.UI.WebControls.Label
                    DueDateLabel = e.Row.FindControl("LabelDueDate")
                    DueDateLabel.Text = CType(e.Row.DataItem("DueDate"), Date).ToShortDateString()
                End If
            Catch ex As Exception
            End Try
            Try
                If Not e.Row.DataItem("TempCompleteDate") Is System.DBNull.Value Then
                    e.Row.Font.Strikeout = True
                    Dim i As Int16
                    For i = 0 To e.Row.Cells.Count - 1
                        e.Row.Cells(i).Font.Strikeout = True
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub ddType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddType.SelectedIndexChanged
        LoadTasks()
    End Sub

    Private Sub ddTaskShow_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddTaskShow.SelectedIndexChanged
        LoadTasks()
    End Sub

    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/default.aspx")
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Protected Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        LoadTasks()
    End Sub

    Private Sub rptTasks_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptTasks.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Try
                Dim ViewHyperlink As System.Web.UI.WebControls.HyperLink = e.Item.FindControl("ViewHyperlinkBB")
                ViewHyperlink.NavigateUrl = "~/Mobile/MobileTaskDetail.aspx?JobNo=" & e.Item.DataItem("JobNo") & "&JobComp=" & e.Item.DataItem("JobComp") & "&SeqNo=" & e.Item.DataItem("SeqNo") & "&EmpCode=" & e.Item.DataItem("EmpCode")
                ViewHyperlink.ImageUrl = "~/images/view-trans.png"
            Catch ex As Exception
            End Try

            Dim lblCDP As System.Web.UI.WebControls.Label
            Try
                lblCDP = e.Item.FindControl("lblCDP")
                If DataBinder.Eval(e.Item.DataItem, "CDP") IsNot DBNull.Value Then
                    lblCDP.Text = e.Item.DataItem("CDP")
                End If
            Catch ex As Exception
                lblCDP = Nothing
            End Try

            Dim lblJobData As System.Web.UI.WebControls.Label
            Try
                lblJobData = e.Item.FindControl("lblJobData")
                If DataBinder.Eval(e.Item.DataItem, "JobData") IsNot DBNull.Value Then
                    lblJobData.Text = e.Item.DataItem("JobData")
                End If
            Catch ex As Exception
                lblJobData = Nothing
            End Try

            Dim lblTask As System.Web.UI.WebControls.Label
            Try
                lblTask = e.Item.FindControl("lblTask")
                If DataBinder.Eval(e.Item.DataItem, "Task") IsNot DBNull.Value Then
                    lblTask.Text = e.Item.DataItem("Task")
                End If
            Catch ex As Exception
                lblTask = Nothing
            End Try

            Dim lblHoursAllowed As System.Web.UI.WebControls.Label
            Try
                lblHoursAllowed = e.Item.FindControl("lblHoursAllowed")
                If DataBinder.Eval(e.Item.DataItem, "HoursAllowed") IsNot DBNull.Value Then
                    lblHoursAllowed.Text = e.Item.DataItem("HoursAllowed")
                End If
            Catch ex As Exception
                lblHoursAllowed = Nothing
            End Try

            Dim lblDueDate As System.Web.UI.WebControls.Label
            Try
                lblDueDate = e.Item.FindControl("lblDueDate")
                If DataBinder.Eval(e.Item.DataItem, "DueDate") IsNot DBNull.Value Then
                    lblDueDate.Text = e.Item.DataItem("DueDate")
                End If
            Catch ex As Exception
                lblDueDate = Nothing
            End Try

            Dim lblTimeDue As System.Web.UI.WebControls.Label
            Try
                lblTimeDue = e.Item.FindControl("lblTimeDue")
                If DataBinder.Eval(e.Item.DataItem, "DueTime") IsNot DBNull.Value Then
                    lblTimeDue.Text = e.Item.DataItem("DueTime")
                End If
            Catch ex As Exception
                lblTimeDue = Nothing
            End Try

            Try
                If Not e.Item.DataItem("TempCompleteDate") Is System.DBNull.Value Then
                    If Not lblCDP Is Nothing Then
                        lblCDP.Font.Strikeout = True
                    End If
                    If Not lblCDP Is Nothing Then
                        lblJobData.Font.Strikeout = True
                    End If
                    If Not lblCDP Is Nothing Then
                        lblTask.Font.Strikeout = True
                    End If
                    If Not lblCDP Is Nothing Then
                        lblHoursAllowed.Font.Strikeout = True
                    End If
                    If Not lblCDP Is Nothing Then
                        lblDueDate.Font.Strikeout = True
                    End If
                    If Not lblCDP Is Nothing Then
                        lblTimeDue.Font.Strikeout = True
                    End If
                End If
            Catch ex As Exception
            End Try

        End If
    End Sub

End Class