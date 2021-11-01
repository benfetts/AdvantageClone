Public Class UI_Simple
    Inherits Page

    '   Only one layout now; go to the Default.aspx page!
    Private Sub UI_Simple_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent()
        qs.Page = "Default.aspx"
        qs.Go(False, True)

    End Sub

End Class