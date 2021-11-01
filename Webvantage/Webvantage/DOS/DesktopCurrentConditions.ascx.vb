Imports RssToolkit.Web.WebControls.RssDataSource
Imports System.Text.RegularExpressions

Partial Public Class DesktopCurrentConditions
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim t As New UserTheme(HttpContext.Current.Session("EmpCode"), _
                                  HttpContext.Current.Session("UserCode"), _
                                  HttpContext.Current.Session("ConnString"))

        t.Load()

        If t.Settings.EnableWeather = True Then

            If Not Me.IsPostBack Then

                'check for cookie:
                Try
                    If Not Request.Cookies("CurrentConditions") Is Nothing Then

                        Me.TxtZip.Text = Request.Cookies("CurrentConditions").Value

                    End If
                Catch ex As Exception

                    Me.TxtZip.Text = ""

                End Try

            End If

            If IsNumeric(Me.TxtZip.Text) = True Then

                Me.LitMSG.Text = AdvantageFramework.Web.Presentation.GetWeatherString(Me.TxtZip.Text)

            End If

        Else

            Me.LitMSG.Text = "Weather is not enabled."

        End If

    End Sub

    Private Sub SaveWeatherCookie()

        Try

            If IsNumeric(Me.TxtZip.Text) Then

                With Response

                    .Cookies("CurrentConditions").Expires = DateTime.Now.AddDays(-1)
                    .Cookies("CurrentConditions").Value = Me.TxtZip.Text
                    .Cookies("CurrentConditions").Expires = DateTime.Now.AddDays(7)

                End With

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRefresh.Click

        SaveWeatherCookie()

    End Sub

End Class