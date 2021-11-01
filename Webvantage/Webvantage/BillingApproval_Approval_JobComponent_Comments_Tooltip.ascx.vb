Public Partial Class BillingApproval_Approval_JobComponent_Comments_Tooltip
    Inherits System.Web.UI.UserControl

    Public BaDtlID As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim sAppr As String = ""
            Dim sCli As String = ""
            ba.ApprovalDetail_GetComment(BaDtlID, sAppr, sCli)
            If sAppr = "" Then sAppr = "None"
            If sCli = "" Then sCli = "None"
            Me.LblApprovalComments.Text = sAppr
            Me.LblClientComments.Text = sCli
        Catch ex As Exception
            Me.LblApprovalComments.Text = "Error getting tooltip data:<br />" & ex.Message.ToString()
        End Try
    End Sub

End Class