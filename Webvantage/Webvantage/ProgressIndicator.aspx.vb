Public Class ProgressIndicator
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Request.QueryString("destPage") = Nothing Then

            Select Case Request.QueryString("destPage")

                Case "TrafficSchedule_Workload2.aspx"

                    Page.Title = "Workload Analysis"
                    LblTitle.Text = "Please wait..."
                    LblText.Text = "...calculating workload."
                    Response.Redirect(Request.QueryString("destPage"))

                Case Else

                    Page.Title = "Webvantage"
                    LblTitle.Text = "Please wait..."
                    LblText.Text = "...loading."

            End Select

        End If
    End Sub

End Class