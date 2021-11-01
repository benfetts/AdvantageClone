Public Class QuoteVsActualSummary
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs.PassThroughTo("QuoteVsActualSummaryPopup.aspx")

    End Sub

End Class
