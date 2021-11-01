Imports RssToolkit.Web.WebControls.RssDataSource

Partial Public Class DesktopQOTD
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If MiscFN.IsValidRequest("http://feedproxy.google.com/quotationspage/qotd") = True Then
                Dim rssDS As New RssToolkit.Web.WebControls.RssDataSource()
                With rssDS
                    .MaxItems = 1
                    .Url = "http://feedproxy.google.com/quotationspage/qotd"
                End With
                With Me.DataList1
                    .DataSource = rssDS
                    .DataBind()
                    .Visible = True
                End With
            Else
                Me.LitMSG.Text = "<br/><br/>Cannot connect to quote service at the moment.<br/>Please verify you have a connection to the Internet."
                Me.DataList1.Visible = False
            End If
        Catch ex As Exception
            Me.LitMSG.Text = "<br/><br/>Cannot get quote."
        End Try
    End Sub
    Private Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Try
                Dim lit As Literal = DirectCast(e.Item.FindControl("Literal1"), Literal)
                Dim pTag As Integer = lit.Text.IndexOf("<p>")
                Dim pTagClose As Integer = lit.Text.IndexOf("</p>") + 4
                Dim l As Integer = lit.Text.Length
                If pTag > 0 Then
                    lit.Text = lit.Text.Remove(pTag, l - pTag - 1).Replace(">", "")
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

End Class