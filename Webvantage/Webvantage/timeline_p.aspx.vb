Imports System
Imports System.Data.SqlClient

Public Class timeline_p
    Inherits Webvantage.BaseChildPage

    Protected WithEvents tblPrintButton As System.Web.UI.HtmlControls.HtmlTable

    Private Sub timeline_p_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            loadgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Function loadgrid()
        Dim otimeline As cTraffic = New cTraffic(Session("ConnString"), Session("UserID"))
        Dim ds As DataSet
        Dim dr As SqlDataReader
        Dim strMinStartDate As String
        Dim strMaxEndDate As String
        Dim i As Integer


        If Request.QueryString("JobNo") = "" Then
            Me.lblNorecords.Text = "No Records Returned"
            Me.tblPrintButton.Visible = False
        Else
            Try
                Me.dlJobs.DataSource = otimeline.GetJobHeader(CInt(Request.QueryString("JobNo")), CInt(Request.QueryString("JobCompNo")))

                ds = otimeline.GetTimeline(CInt(Request.QueryString("JobNo")), CInt(Request.QueryString("JobCompNo")), Request.QueryString("Period"), Session("UserCode"))
                If ds.Tables(0).Rows.Count > 0 Then
                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns(1))
                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns(7))
                    Me.dgTimeline.DataSource = ds.Tables(0).DefaultView
                    Page.DataBind()
                    'Me.tblPrintButton.Visible = True
                    Me.lblNorecords.Visible = False
                Else
                    Me.dgTimeline.DataSource = Nothing
                    Page.DataBind()
                    Me.lblNorecords.Text = "No Records Returned"
                    ' Me.tblPrintButton.Visible = False
                End If

                ds.Dispose()
            Catch ex As Exception
                If InStr(ex.Message.ToString(), "DataTable") > 0 Or InStr(ex.Message.ToString(), "Column") > 0 Then
                    Me.ShowMessage("Schedules spanning more than a year will not display properly in this view.")
                Else
                    Me.ShowMessage(ex.Message.ToString.Replace("/", "_").Replace("'", ""))
                End If
            End Try
        End If

    End Function


    Private Sub dgTimeline_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTimeline.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Not IsDBNull(e.Item.DataItem(5)) And Not IsDBNull(e.Item.DataItem(6)) Then
                Dim lcStart As String = e.Item.DataItem(5)
                Dim lcEnd As String = e.Item.DataItem(6)
                Dim ldStart As Date = e.Item.DataItem(5)
                Dim ldEnd As Date = e.Item.DataItem(6)
                e.Item.Cells(5).Text = ldStart.ToShortDateString
                e.Item.Cells(6).Text = ldEnd.ToShortDateString
                If ldStart > ldEnd Then
                    e.Item.Cells(5).ForeColor = System.Drawing.Color.Red
                    e.Item.Cells(6).ForeColor = System.Drawing.Color.Red
                End If
            End If
        ElseIf e.Item.ItemType = ListItemType.Header Then

        End If
    End Sub
End Class