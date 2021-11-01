Public Class timeline
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString
        qs.PassThroughTo("TimeLine2.aspx")

    End Sub

End Class
