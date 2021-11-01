Imports RssToolkit.Web.WebControls.RssDataSource
Partial Public Class DesktopWOTD
    Inherits Webvantage.BaseDesktopObject


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If MiscFN.IsValidRequest("http://www.thefreedictionary.com/_/WoD/rss.aspx") = True Then
                Dim rssDS As New RssToolkit.Web.WebControls.RssDataSource()
                With rssDS
                    .MaxItems = 1
                    .Url = "http://www.thefreedictionary.com/_/WoD/rss.aspx"
                End With
                With Me.DataList1
                    .DataSource = rssDS
                    .DataBind()
                    .Visible = True
                End With
            Else
                Me.LitMSG.Text = "<br/><br/>Cannot connect to word source at the moment.<br/>Please verify you have a connection to the Internet."
                Me.DataList1.Visible = False
            End If
        Catch ex As Exception
            Me.LitMSG.Text = "<br/><br/>Cannot load word of the day."
            Me.DataList1.Visible = False
        End Try
    End Sub
    Private Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Then
            Try
                Dim lit As Literal = DirectCast(e.Item.FindControl("LitText"), Literal)
                Dim str As String = ""
                str = lit.Text
                str = str.Replace("DEFINITION:", "<br />")
                str = str.Replace("SYNONYMS:", "<br />Synonyms:")
                str = str.Replace("USAGE:", "Usage:")
                lit.Text = str
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    'Private Sub LinkButtonCloseDisclaimer_Click(sender As Object, e As System.EventArgs) Handles LinkButtonCloseDisclaimer.Click
    '    Me.FieldsetDisclaimer.Visible = False
    '    Me.DataList1.Visible = Not Me.FieldsetDisclaimer.Visible
    '    Me.LinkButtonDisclaimer.Visible = Not Me.FieldsetDisclaimer.Visible
    'End Sub

    'Private Sub LinkButtonDisclaimer_Click(sender As Object, e As EventArgs) Handles LinkButtonDisclaimer.Click
    '    Me.FieldsetDisclaimer.Visible = Not Me.FieldsetDisclaimer.Visible
    '    Me.DataList1.Visible = Not Me.FieldsetDisclaimer.Visible
    '    Me.LinkButtonDisclaimer.Visible = Not Me.FieldsetDisclaimer.Visible
    'End Sub
End Class