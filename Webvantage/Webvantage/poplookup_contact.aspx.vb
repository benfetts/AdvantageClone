Public Partial Class poplookup_contact
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim q As New AdvantageFramework.Web.QueryString()
        q.PassThroughTo("LookUp_Quick.aspx")
    End Sub

End Class