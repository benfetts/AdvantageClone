Public Partial Class TrafficSchedule_TaskEmployees_Tooltip
    Inherits System.Web.UI.UserControl
    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public SeqNbr As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.LblMSG.Visible = False
            If Me.JobNumber > 0 And Me.JobComponentNbr > 0 And Me.SeqNbr >= 0 Then
                Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim dt As New DataTable
                dt = oSchedule.GetTaskEmpList(JobNumber, JobComponentNbr, SeqNbr)
                Me.GridView1.DataSource = dt
                Me.GridView1.DataBind()
            End If
        Catch ex As Exception
            Me.GridView1.Visible = False
            Me.LblMSG.Text = "Error getting tooltip data:<br/>" & ex.Message.ToString()
            Me.LblMSG.Visible = True
        End Try
    End Sub

End Class