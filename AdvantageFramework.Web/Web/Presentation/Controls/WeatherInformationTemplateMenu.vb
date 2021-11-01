Namespace Web.Presentation.Controls

    Public Class WeatherInformationTemplateMenu
        Implements System.Web.UI.ITemplate


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            'Try
            '    Dim ZipCode As Integer = 0

            '    Try
            '        ZipCode = CType(System.Data.Sql.SqlHelper.ExecuteScalar(System.Web.HttpContext.Current.Session("ConnString"), CommandType.Text, "SELECT ISNULL(EMP_ZIP,0) FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '" & HttpContext.Current.Session("EmpCode") & "';"), Integer)
            '    Catch ex As Exception
            '        ZipCode = 0
            '    End Try
            '    If ZipCode = 0 Then ZipCode = 28117
            '    If ZipCode > 0 Then
            '        Dim ThisFeedURL As String = "http://feeds.weatherbug.com/rss.aspx?zipcode=" & ZipCode & "&feed=curr&zcode=z4641"
            '        Dim BaseDescription As String = ""
            '        Dim sb As New System.Text.StringBuilder
            '        If MiscFN.IsValidRequest(ThisFeedURL) = True Then
            '            Dim Title As String = ""
            '            Dim rssDS As New RssToolkit.Web.WebControls.RssDataSource()
            '            With rssDS
            '                .MaxItems = 1
            '                .Url = ThisFeedURL
            '            End With

            '            Try
            '                Dim x As RssToolkit.Rss.RssItem
            '                For Each z As System.Data.DataRowView In rssDS.Rss.SelectItems
            '                    Title = z.Item("Title")
            '                    BaseDescription = z.Item("Description")
            '                    Exit For
            '                Next
            '            Catch ex As Exception
            '            End Try

            '            sb.Append(Now.ToLongDateString())
            '            sb.Append("<br />")

            '            Try
            '                sb.Append("<strong>")
            '                sb.Append(Title.Remove(0, Title.IndexOf(",", 0) + 1))
            '                sb.Append("</strong>")
            '                sb.Append("<br />")
            '            Catch ex As Exception
            '            End Try

            '            BaseDescription = BaseDescription.Replace("&nbsp;", "")
            '            Try
            '                Dim OpeningImageTagIndex As Integer
            '                Dim ClosingImageTagIndex As Integer
            '                OpeningImageTagIndex = BaseDescription.IndexOf("<img")
            '                ClosingImageTagIndex = BaseDescription.IndexOf("/>")
            '                If OpeningImageTagIndex > -1 And ClosingImageTagIndex > OpeningImageTagIndex Then
            '                    BaseDescription = BaseDescription.Remove(OpeningImageTagIndex, ((ClosingImageTagIndex + 2) - OpeningImageTagIndex))
            '                End If
            '            Catch ex As Exception

            '            End Try
            '            BaseDescription = BaseDescription.Replace("<b>", "")
            '            BaseDescription = BaseDescription.Replace("</b>", "")

            '            Dim StartRemoval As Integer = 0
            '            StartRemoval = BaseDescription.IndexOf("<em>")
            '            Dim StrLength As Integer = BaseDescription.Length
            '            If StartRemoval > -1 Then
            '                BaseDescription = BaseDescription.Remove(StartRemoval, StrLength - StartRemoval)
            '            End If
            '        End If
            '        BaseDescription = BaseDescription.Replace("Gusts", "<br />Wind Gusts")
            '        BaseDescription = BaseDescription.Replace("Dew", ",&nbsp;Dew")
            '        BaseDescription = BaseDescription.Replace("Rain Today", ",&nbsp;Rain")
            '        BaseDescription = BaseDescription.Remove(BaseDescription.LastIndexOf("<br />"), 6)

            '        sb.Append(BaseDescription)
            '        Dim lit As New Literal
            '        lit.Text = sb.ToString()
            '        container.Controls.Add(lit)

            '    End If

            'Catch ex As Exception
            'End Try

        End Sub

#End Region

    End Class

End Namespace