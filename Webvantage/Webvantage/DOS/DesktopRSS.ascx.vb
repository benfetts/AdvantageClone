Imports RssToolkit.Web.WebControls.RssDataSource
Partial Public Class DesktopRSS
    Inherits Webvantage.BaseDesktopObject


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Try
                If Not Request.Cookies("RSS") Is Nothing Then

                    MiscFN.RadComboBoxSetIndex(Me.DropFeedSource, Request.Cookies("RSS").Value, False)

                Else

                    Me.DropFeedSource.SelectedIndex = 0
                    SaveRSSCookie()

                End If

            Catch ex As Exception
            End Try

        Else

            Me.RadGridNewsFeed.DataSourceID = Nothing

        End If
    End Sub

    Private Sub DropFeedSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropFeedSource.SelectedIndexChanged
        Try

            SaveRSSCookie()
            Me.RadGridNewsFeed.Rebind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRefresh.Click
        Try

            SaveRSSCookie()
            Me.RadGridNewsFeed.Rebind()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveRSSCookie()
        Try
            With Response
                .Cookies("RSS").Expires = DateTime.Now.AddDays(-1)
                .Cookies("RSS").Value = Me.DropFeedSource.SelectedValue
                .Cookies("RSS").Expires = DateTime.Now.AddDays(7)
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridNewsFeed_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridNewsFeed.NeedDataSource

        Try

            If MiscFN.IsValidRequest(Me.DropFeedSource.SelectedValue) = True Then

                Dim rssDS As New RssToolkit.Web.WebControls.RssDataSource()
                With rssDS

                    .ID = "NewsDataSource"
                    .MaxItems = 10
                    .Url = Me.DropFeedSource.SelectedValue

                End With

                Me.PlaceHolder1.Controls.Add(rssDS)
                RadGridNewsFeed.DataSourceID = rssDS.ID

            Else

                Me.LitMSG.Text = "<br/><br/>Cannot connect to news service at the moment.<br/>Please verify you have a connection to the Internet."

            End If
        Catch ex As Exception

            Me.LitMSG.Text = "<br/><br/>Cannot load news feed."

        End Try

    End Sub

End Class
