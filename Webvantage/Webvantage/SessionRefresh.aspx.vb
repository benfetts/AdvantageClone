Public Partial Class SessionRefresh
    Inherits System.Web.UI.Page
    Protected WindowStatusText As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MetaRefresh.Attributes("content") = Convert.ToString((Session.Timeout * 60) - 60) + ";url=KeepSessionAlive.aspx?q=" + DateTime.Now.Ticks.ToString
        WindowStatusText = "Last refresh " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
        'Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - 10))
    End Sub

End Class