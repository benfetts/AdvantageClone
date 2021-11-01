Public Partial Class KeepAlive
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.ShowMessage(Session.Timeout.ToString())
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - 45))
    End Sub

End Class