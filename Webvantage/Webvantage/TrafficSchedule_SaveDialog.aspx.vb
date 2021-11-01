Imports Webvantage.cGlobals
Partial Public Class TrafficSchedule_SaveDialog
    Inherits Webvantage.BaseChildPage

    Private ThisTask_JobNum As Integer = 0
    Private ThisTask_JobComp As Integer = 0
    Private CurrentTrafficCode As String = ""
    Private CurrentTrafficDescript As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ThisTask_JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            ThisTask_JobNum = 0
        End Try
        Try
            ThisTask_JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            ThisTask_JobComp = 0
        End Try
        Try
            CurrentTrafficCode = Request.QueryString("CurrTraffCode")
        Catch ex As Exception
            CurrentTrafficCode = ""
        End Try
        Try
            CurrentTrafficDescript = Request.QueryString("CurrTraffDescript")
        Catch ex As Exception
            CurrentTrafficDescript = ""
        End Try

        If Not Me.IsPostBack Then
            
            BindTaskCombo()
            SetNextTask()
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String = "RefreshGrid"
        Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Sub SetNextTask()
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable

        dt = s.GetNextScheduleStatusCode(ThisTask_JobNum, ThisTask_JobComp)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE")) = False Then
                HFNextTaskStatusCode.Value = dt.Rows(0)("NEXT_STATUS_CODE").ToString().Trim
            Else
                HFNextTaskStatusCode.Value = ""
            End If
            If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE_DESCRIPTION")) = False Then
                Me.LblNextTaskStatus.Text = dt.Rows(0)("NEXT_STATUS_CODE_DESCRIPTION").ToString().Trim
            Else
                Me.LblNextTaskStatus.Text = "NONE"
            End If
        Else
            HFNextTaskStatusCode.Value = ""
            Me.LblNextTaskStatus.Text = "NONE"
        End If

        If HFNextTaskStatusCode.Value = "" Then
            Me.RblStatusChangeNextTask.Checked = False
            Me.RblStatusChangeNextTask.Enabled = False
            Me.RblStatusChangeNone.Checked = True
        Else
            Me.RblStatusChangeNextTask.Enabled = True
            Me.RblStatusChangeNextTask.Checked = True
        End If
    End Sub

    Private Sub BindTaskCombo()
        Dim d As New cDropDowns(Session("ConnString"))
        Dim s As SqlClient.SqlDataReader = d.GetTrafficCodes()
        With Me.DropStatus
            .DataSource = s
            .DataTextField = "CodeDescription"
            .DataValueField = "Code"
            .DataBind()
        End With
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Me.RblStatusChangeNextTask.Checked = True Or Me.RblStatusChangeSelect.Checked = True Or Me.RblStatusChangeNone.Checked = True Then
            If ThisTask_JobNum > 0 And ThisTask_JobComp > 0 And (RblStatusChangeNextTask.Checked = True Or RblStatusChangeSelect.Checked = True) Then
                Dim ThisTrafficCode As String = ""
                If RblStatusChangeNextTask.Checked = True Then
                    If Me.HFNextTaskStatusCode.Value <> "" Then
                        ThisTrafficCode = Me.HFNextTaskStatusCode.Value
                    End If
                End If
                If RblStatusChangeSelect.Checked = True And HFNextTaskStatusCode.Value = "" Then
                    ThisTrafficCode = Me.DropStatus.SelectedValue
                End If
                If ThisTrafficCode <> "" Then
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    s.UpdateScheduleTrafficCode(ThisTask_JobNum, ThisTask_JobComp, ThisTrafficCode)
                End If
            End If
            'Back to main and trigger save:
            Me.LitScript.Text = "<script>CallFunctionOnParentPage('SaveFromPopUp');</" & "script>"
        Else
            Me.ShowMessage("Please selct a status option.")
        End If
    End Sub
End Class