Public Partial Class BillingApproval_Approval_JobComponent_Comments
    Inherits Webvantage.BaseChildPage
    Private BaDtlId As Integer = -1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            BaDtlId = CType(Request.QueryString("BA_DTL_ID"), Integer)
        Catch ex As Exception
            BaDtlId = -1
        End Try
        If Not Me.IsPostBack Then
            Try
                Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                Dim sApprCmt As String = ""
                Dim sCliCmt As String = ""
                ba.ApprovalDetail_GetComment(Me.BaDtlId, sApprCmt, sCliCmt)
                Me.TxtApprovalComments.Text = sApprCmt
                Me.TxtClientComments.Text = sCliCmt
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        ba.ApprovalDetail_UpdateComment(Me.BaDtlId, Me.TxtApprovalComments.Text, Me.TxtClientComments.Text)
        CloseAndRefresh()
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("BillingApproval_Approval_JobComponent.aspx")
    End Sub

End Class