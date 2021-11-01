Public Partial Class MobileBTest
    Inherits MobileBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("User Agent: " + Request.UserAgent.ToString() + "<BR />")
        Response.Write("IsMobileDevice: " + Request.Browser.IsMobileDevice.ToString() + "<BR />")
        Response.Write("Browser: " + Request.Browser.Browser.ToString() + "<BR />")
        Response.Write("Version: " + Request.Browser.Version.ToString() + "<BR />")
        Response.Write("Major: " + Request.Browser.MajorVersion.ToString() + "<BR />")
        Response.Write("Minor: " + Request.Browser.MinorVersion.ToString() + "<BR />")
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/default.aspx")
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub
End Class