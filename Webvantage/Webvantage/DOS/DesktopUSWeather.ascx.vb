Public Partial Class DesktopUSWeather
    Inherits Webvantage.BaseDesktopObject


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LitData.Text = "<br/><br/>The beta object is no longer available.<br/><br/>Please use the ""X"" in the upper right hand corner of the object to remove it from your desktop."
        'If Not Me.IsPostBack Then
        '    'check for cookie:
        '    Try
        '        If Not Request.Cookies("USWeather") Is Nothing Then
        '            Me.TxtZip.Text = Request.Cookies("USWeather").Value
        '        End If
        '    Catch ex As Exception
        '        Me.TxtZip.Text = ""
        '    End Try
        'End If
        ''Load:
        'If IsNumeric(Me.TxtZip.Text) Then
        '    Me.LitData.Text = GetWeatherTable(Me.TxtZip.Text)
        'End If
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRefresh.Click
        ''resave cookie
        'SaveWeatherCookie()
    End Sub

    Private Sub SaveWeatherCookie()
        'If IsNumeric(Me.TxtZip.Text) Then
        '    Try
        '        With Response
        '            .Cookies("USWeather").Expires = DateTime.Now.AddDays(-1)
        '            .Cookies("USWeather").Value = Me.TxtZip.Text
        '            .Cookies("USWeather").Expires = DateTime.Now.AddDays(7)
        '        End With
        '    Catch ex As Exception
        '        Exit Sub
        '    End Try
        'End If
    End Sub

    Private Function GetWeatherTable(ByVal zip As Integer) As String
        ''Try
        ''    If IsNumeric(zip) Then

        ''        Try
        ''            Dim wsWeather As New webservicex.www.WeatherForecast
        ''            Dim wsForecasts As New webservicex.www.WeatherForecasts
        ''            wsForecasts = wsWeather.GetWeatherByZipCode(zip)
        ''            Dim lati As Decimal = wsForecasts.Latitude
        ''            Dim longi As Decimal = wsForecasts.Longitude
        ''            If lati <= 0 And longi <= 0 Then
        ''                Return "Can't find zip.<br />Please try the zip code of the closest metropolitan area."
        ''            Else
        ''                Dim sb As New System.Text.StringBuilder
        ''                sb.Append("<br/><br/><strong>WEATHER FOR:  " & wsForecasts.PlaceName & ", " & wsForecasts.StateCode.ToUpper & "</strong>")
        ''                sb.Append("<br/>")
        ''                Try
        ''                    For Each wd As webservicex.www.WeatherData In wsForecasts.Details
        ''                        If wd.Day <> "" Then
        ''                            sb.Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"">")
        ''                            sb.Append("  <tr>")
        ''                            sb.Append("    <td width=""2%"" rowspan=""2"" align=""center"" valign=""middle""><img src=""" & wd.WeatherImage & """/></td>")
        ''                            sb.Append("    <td width=""98%"" align=""left"" valign=""middle"">" & wd.Day & "</td>")
        ''                            sb.Append("  </tr>")
        ''                            sb.Append("  <tr>")
        ''                            sb.Append("    <td align=""left"" valign=""middle"">" & wd.MaxTemperatureF & "&deg;F / " & wd.MinTemperatureF & "&deg;F</td>")
        ''                            sb.Append("  </tr>")
        ''                            sb.Append("</table>")
        ''                        End If
        ''                    Next
        ''                    Return sb.ToString
        ''                Catch ex As Exception
        ''                    Return "Can't get weather data."
        ''                End Try
        ''            End If
        ''        Catch ex As Exception
        ''            Return "Can't connect to NOAA web service."
        ''        End Try
        ''    Else
        ''        Return "Zip is not a number."
        ''    End If
        ''Catch ex As Exception
        ''    Return "Problem getting data"
        ''End Try
    End Function

End Class