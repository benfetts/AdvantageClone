Public Partial Class DesktopClock
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.litDate.Text = Today.ToLongDateString()
        Me.PanelFlashClock.Visible = Request.Browser.Browser.ToString().Contains("IE")
        Me.PanelHTML5Clock.Visible = Not Me.PanelFlashClock.Visible
    End Sub

End Class