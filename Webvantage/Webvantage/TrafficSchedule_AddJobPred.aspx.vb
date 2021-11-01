Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class TrafficSchedule_AddJobPred
    Inherits Webvantage.BaseChildPage

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private CurrJobNum As Integer = 0
    Private CurrJobCompNum As Integer = 0
    Private CurrClient As String = String.Empty
    Private CurrDivision As String = String.Empty
    Private CurrProduct As String = String.Empty
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private IsValidJobAndComp As Boolean = False
    Private Msg1 As String = ""
    Private DtJobAndComp As New DataTable

#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
        Me.PageTitle = ""
        Try
            If Not Page.IsPostBack And Not Me.IsCallback Then
                LoadClientDropdownlist()
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Me.ClientDropDownList.SelectedValue = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, CurrJobNum).Client.Code
                End Using
                LoadDivisionDropdownlist()
                LoadProductDropdownlist()
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub RadGridJobs_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobs.ItemDataBound
        Try
            'If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            '    Dim data As Telerik.Web.UI.GridDataItem
            '    data = e.Item
            '    Dim j As Integer = CType(data.GetDataKeyValue("JobNumber"), Integer)
            '    Dim c As Integer = CType(data.GetDataKeyValue("Number"), Integer)
            '    If CType(data.GetDataKeyValue("JobNumber"), Integer) = CurrJobNum And CType(data.GetDataKeyValue("Number"), Integer) = CurrJobCompNum Then
            '        e.Item.Visible = False
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobs_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobs.NeedDataSource
        Try
            RadGridJobs.DataSource = GetJobs()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub BtnAddJobPred_Click(sender As Object, e As System.EventArgs) Handles BtnAddJobPred.Click
    '    Try
    '        Dim chk As CheckBox
    '        Dim exists As Boolean = False
    '        Dim NewJobPred As Integer
    '        Dim NewCompPred As Integer
    '        Dim JobCompPred As AdvantageFramework.Database.Entities.JobTrafficPredecessors
    '        Dim JobCompPreds As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
    '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
    '            JobCompPreds = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, Me.CurrJobNum, Me.CurrJobCompNum).ToList
    '            'For Each JobTrafficPredecessors In JobCompPreds
    '            '    AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(DbContext, JobTrafficPredecessors)
    '            'Next
    '            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobs.MasterTableView.Items
    '                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
    '                If chk.Checked = True Then
    '                    NewJobPred = gridDataItem("ColJOB_NUMBER").Text.Trim().Replace("&nbsp;", "")
    '                    NewCompPred = gridDataItem("ColJOB_COMPONENT_NBR").Text.Trim().Replace("&nbsp;", "")
    '                    Try
    '                        If JobCompPreds.Count > 0 Then
    '                            For Each JobTrafficPredecessors In JobCompPreds
    '                                If JobTrafficPredecessors.JobPredecessor = NewJobPred And JobTrafficPredecessors.JobComponentPredecessor = NewCompPred Then
    '                                    exists = True
    '                                End If
    '                            Next
    '                            If exists = False Then
    '                                If NewJobPred <> 0 And NewCompPred <> 0 And ((NewJobPred = CurrJobNum And NewCompPred <> CurrJobCompNum) Or (NewJobPred <> CurrJobNum)) Then
    '                                    AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Insert(DbContext, Me.CurrJobNum, Me.CurrJobCompNum, NewJobPred, NewCompPred, JobCompPred)
    '                                End If
    '                            End If
    '                        Else
    '                            If NewJobPred <> 0 And NewCompPred <> 0 And ((NewJobPred = CurrJobNum And NewCompPred <> CurrJobCompNum) Or (NewJobPred <> CurrJobNum)) Then
    '                                AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Insert(DbContext, Me.CurrJobNum, Me.CurrJobCompNum, NewJobPred, NewCompPred, JobCompPred)
    '                            End If
    '                        End If
    '                    Catch ex As Exception

    '                    End Try
    '                End If
    '            Next
    '        End Using
    '        CloseAndRefresh()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim jobs() As String = GetRelatedJobs().ToString.Split("|")
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobs.MasterTableView.Items
                Dim str As String = gridDataItem.GetDataKeyValue("JobNumber") & "," & gridDataItem.GetDataKeyValue("Number")
                If jobs.Count > 0 Then
                    For i As Integer = 0 To jobs.Count - 1
                        If jobs(i) <> "" Then
                            If str = jobs(i) Then
                                gridDataItem.Visible = False
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_PreInit1(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Try
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With q
                Me.CurrJobNum = .JobNumber
                Me.CurrJobCompNum = .JobComponentNumber
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetJobs() As SqlDataReader

        Try
            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim count As Int16

            SQL_STRING = "SELECT JOB_COMPONENT.JOB_NUMBER AS JobNumber, JOB_LOG.JOB_DESC AS JobDesc, JOB_COMPONENT.JOB_COMPONENT_NBR AS Number, JOB_COMPONENT.JOB_COMP_DESC AS Description, CLIENT.CL_NAME AS Client FROM JOB_COMPONENT "
            SQL_STRING &= " INNER JOIN JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER "
            SQL_STRING &= " INNER JOIN JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR "
            SQL_STRING &= " INNER JOIN CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE "

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then
                    SQL_STRING &= " INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & _Session.User.EmployeeCode & "' "
                End If
            End Using

            If Me.ClientDropDownList.SelectedValue <> "" And Me.DivisionDropDownList.SelectedValue <> "" And Me.ProductDropDownList.SelectedValue <> "" Then
                SQL_STRING &= " WHERE [JOB_PROCESS_CONTRL] NOT IN (6,12) AND JOB_LOG.CL_CODE = '" & Me.ClientDropDownList.SelectedValue & "' AND JOB_LOG.DIV_CODE = '" & Me.DivisionDropDownList.SelectedValue & "' AND JOB_LOG.PRD_CODE = '" & Me.ProductDropDownList.SelectedValue & "' ORDER BY JOB_COMPONENT.JOB_NUMBER DESC"
            ElseIf Me.ClientDropDownList.SelectedValue <> "" And Me.DivisionDropDownList.SelectedValue <> "" Then
                SQL_STRING &= " WHERE [JOB_PROCESS_CONTRL] NOT IN (6,12) AND JOB_LOG.CL_CODE = '" & Me.ClientDropDownList.SelectedValue & "' AND JOB_LOG.DIV_CODE = '" & Me.DivisionDropDownList.SelectedValue & "' ORDER BY JOB_COMPONENT.JOB_NUMBER DESC"
            ElseIf Me.ClientDropDownList.SelectedValue <> "" Then
                SQL_STRING &= " WHERE [JOB_PROCESS_CONTRL] NOT IN (6,12) AND JOB_LOG.CL_CODE = '" & Me.ClientDropDownList.SelectedValue & "' ORDER BY JOB_COMPONENT.JOB_NUMBER DESC"
            Else
                SQL_STRING &= " WHERE [JOB_PROCESS_CONTRL] NOT IN (6,12) ORDER BY JOB_COMPONENT.JOB_NUMBER DESC"
            End If

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getJobData", Err.Description)
            Finally
            End Try

            Return dr
        Catch ex As Exception

        End Try


    End Function

    Private Sub CloseAndRefresh()
        'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx?pnl=1&JobNum=" & CurrJobNum & "&JobComp=" & CurrJobCompNum, True)
        Me.CloseThisWindow()
    End Sub

    Private Sub LoadClientDropdownlist()
        Try
            Me.ClientDropDownList.Items.Clear()

            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.ClientDropDownList
                .DataSource = oDD.GetClientList(Session("UserCode"))
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", ""))
                .SelectedIndex = 0
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadDivisionDropdownlist()
        Try
            Dim cli As String

            Me.DivisionDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.DivisionDropDownList
                .DataSource = oDD.GetDivisionList(Session("UserCode"), cli)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", ""))
                .SelectedIndex = 0
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadProductDropdownlist()
        Try
            Dim cli, div As String

            Me.ProductDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            div = Me.DivisionDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.ProductDropDownList
                .DataSource = oDD.GetProductList(Session("UserCode"), cli, div)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", ""))
                .SelectedIndex = 0
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        Try
            LoadDivisionDropdownlist()
            LoadProductDropdownlist()
            Me.RadGridJobs.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DivisionDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DivisionDropDownList.SelectedIndexChanged
        Try
            LoadProductDropdownlist()
            Me.RadGridJobs.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProductDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductDropDownList.SelectedIndexChanged
        Try
            Me.RadGridJobs.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetRelatedJobs()
        Try
            Dim sb As New System.Text.StringBuilder
            Dim strJobs As String
            Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim row As DataRow
            Dim dtJobs As New DataTable
            Dim dv As DataView
            Dim ct As Integer = 0
            Dim colJob As DataColumn = New DataColumn("Job")
            Dim colComp As DataColumn = New DataColumn("Comp")
            Dim colsd As DataColumn = New DataColumn("START_DATE", System.Type.GetType("System.DateTime"))
            dtJobs.Columns.Add(colJob)
            dtJobs.Columns.Add(colComp)
            dtJobs.Columns.Add(colsd)
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, CurrJobNum, CurrJobCompNum)
                row = dtJobs.NewRow
                row.Item("Job") = CurrJobNum.ToString
                row.Item("Comp") = CurrJobCompNum
                If Not JobComp.StartDate Is Nothing Then
                    row.Item("START_DATE") = JobComp.StartDate
                Else
                    row.Item("START_DATE") = DBNull.Value
                End If
                dtJobs.Rows.Add(row)
                Do While ct < dtJobs.Rows.Count
                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).Include("JobTraffic").ToList
                    If JobPred.Count > 0 Then
                        For x As Integer = 0 To JobPred.Count - 1
                            If ct >= 1 Then
                                dv = dtJobs.DefaultView
                                dv.RowFilter = "Job = '" & JobPred(x).JobNumber.ToString & "' AND Comp = '" & JobPred(x).JobComponentNumber.ToString & "'"
                                If dv.Count = 0 Then
                                    row = dtJobs.NewRow
                                    row.Item("Job") = JobPred(x).JobNumber.ToString
                                    row.Item("Comp") = JobPred(x).JobComponentNumber.ToString
                                    If Not JobComp.StartDate Is Nothing Then
                                        row.Item("START_DATE") = JobPred(x).JobTraffic.JobComponent.StartDate
                                    Else
                                        row.Item("START_DATE") = DBNull.Value
                                    End If
                                    dtJobs.Rows.Add(row)
                                End If
                            Else
                                row = dtJobs.NewRow
                                row.Item("Job") = JobPred(x).JobNumber.ToString
                                row.Item("Comp") = JobPred(x).JobComponentNumber.ToString
                                If Not JobComp.StartDate Is Nothing Then
                                    row.Item("START_DATE") = JobPred(x).JobTraffic.JobComponent.StartDate
                                Else
                                    row.Item("START_DATE") = DBNull.Value
                                End If
                                dtJobs.Rows.Add(row)
                            End If
                        Next
                    End If
                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).ToList
                    If JobPred.Count > 0 Then
                        For x As Integer = 0 To JobPred.Count - 1
                            If ct >= 1 Then
                                dv = dtJobs.DefaultView
                                dv.RowFilter = "Job = '" & JobPred(x).JobPredecessor.ToString & "' AND Comp = '" & JobPred(x).JobComponentPredecessor.ToString & "'"
                                If dv.Count = 0 Then
                                    JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(x).JobPredecessor, JobPred(x).JobComponentPredecessor)
                                    row = dtJobs.NewRow
                                    row.Item("Job") = JobPred(x).JobPredecessor.ToString
                                    row.Item("Comp") = JobPred(x).JobComponentPredecessor.ToString
                                    If Not JobComp.StartDate Is Nothing Then
                                        row.Item("START_DATE") = JobComp.StartDate
                                    Else
                                        row.Item("START_DATE") = DBNull.Value
                                    End If
                                    dtJobs.Rows.Add(row)
                                End If
                            Else
                                row = dtJobs.NewRow
                                JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(x).JobPredecessor, JobPred(x).JobComponentPredecessor)
                                row.Item("Job") = JobPred(x).JobPredecessor.ToString
                                row.Item("Comp") = JobPred(x).JobComponentPredecessor.ToString
                                If Not JobComp.StartDate Is Nothing Then
                                    row.Item("START_DATE") = JobComp.StartDate
                                Else
                                    row.Item("START_DATE") = DBNull.Value
                                End If
                                dtJobs.Rows.Add(row)
                            End If
                        Next
                    End If
                    ct += 1
                Loop
                If dtJobs.Rows.Count > 0 Then
                    For i As Integer = 0 To dtJobs.Rows.Count - 1
                        With sb
                            .Append(dtJobs.Rows(i)("Job").ToString)
                            .Append(",")
                            .Append(dtJobs.Rows(i)("Comp").ToString)
                            .Append("|")
                        End With
                    Next
                End If
                strJobs = MiscFN.RemoveDuplicatesFromString(sb.ToString, "|", True)
                Return strJobs
            End Using

        Catch ex As Exception

        End Try
    End Function

    Private Sub RadToolbarJobPredessors_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarJobPredessors.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Add"
                    Dim chk As CheckBox
                    Dim exists As Boolean = False
                    Dim NewJobPred As Integer
                    Dim NewCompPred As Integer
                    Dim JobCompPred As AdvantageFramework.Database.Entities.JobTrafficPredecessors
                    Dim JobCompPreds As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        JobCompPreds = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, Me.CurrJobNum, Me.CurrJobCompNum).ToList
                        'For Each JobTrafficPredecessors In JobCompPreds
                        '    AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(DbContext, JobTrafficPredecessors)
                        'Next
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobs.MasterTableView.Items
                            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                NewJobPred = gridDataItem("ColJOB_NUMBER").Text.Trim().Replace("&nbsp;", "")
                                NewCompPred = gridDataItem("ColJOB_COMPONENT_NBR").Text.Trim().Replace("&nbsp;", "")
                                Try
                                    If JobCompPreds.Count > 0 Then
                                        For Each JobTrafficPredecessors In JobCompPreds
                                            If JobTrafficPredecessors.JobPredecessor = NewJobPred And JobTrafficPredecessors.JobComponentPredecessor = NewCompPred Then
                                                exists = True
                                            End If
                                        Next
                                        If exists = False Then
                                            If NewJobPred <> 0 And NewCompPred <> 0 And ((NewJobPred = CurrJobNum And NewCompPred <> CurrJobCompNum) Or (NewJobPred <> CurrJobNum)) Then
                                                AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Insert(DbContext, Me.CurrJobNum, Me.CurrJobCompNum, NewJobPred, NewCompPred, JobCompPred)
                                            End If
                                        End If
                                    Else
                                        If NewJobPred <> 0 And NewCompPred <> 0 And ((NewJobPred = CurrJobNum And NewCompPred <> CurrJobCompNum) Or (NewJobPred <> CurrJobNum)) Then
                                            AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Insert(DbContext, Me.CurrJobNum, Me.CurrJobCompNum, NewJobPred, NewCompPred, JobCompPred)
                                        End If
                                    End If
                                Catch ex As Exception

                                End Try
                            End If
                        Next
                    End Using
                    CloseAndRefresh()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
