Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Partial Public Class Resources_Select
    Inherits Webvantage.BaseChildPage
    Private DtResources As New DataTable
    Private ThisEventId As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ThisEventId = CType(Request.QueryString("evt"), Integer)
        Catch ex As Exception
            ThisEventId = 0
        End Try
        If Not Session("EventsResources") Is Nothing And ThisEventId > 0 Then
            DtResources = CType(Session("EventsResources"), DataTable)
        End If
    End Sub

    Private Sub RadGridResources_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridResources.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "SelectResource"
                Dim SelectedResourceCode As String = ""
                SelectedResourceCode = e.CommandArgument
                Dim StrTBId As String = ""
                StrTBId = Request.QueryString("tb")

                'Send back if normal pop up:
                Dim StrJS As String = "<script type=""text/javascript"">opener.document.forms[0]." & StrTBId & ".value = '" & SelectedResourceCode & "';window.close();</script>"
                Me.LitScript.Text = StrJS

                ''''update the rec if coming from radwindow...
                '''If ThisEventId > 0 And SelectedResourceCode <> "" Then
                '''    'Update the actual event...we don't want this....
                '''    'Try
                '''    '    Using MyConn As New SqlConnection(Session("ConnString"))
                '''    '        MyConn.Open()
                '''    '        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                '''    '        Dim MyCmd As New SqlCommand("UPDATE EVENT WITH(ROWLOCK) SET RESOURCE_CODE = '" & SelectedResourceCode & "' WHERE EVENT_ID = " & Me.ThisEventId & ";", MyConn, MyTrans)
                '''    '        Try
                '''    '            MyCmd.ExecuteNonQuery()
                '''    '            MyTrans.Commit()
                '''    '        Catch ex As Exception
                '''    '            MyTrans.Rollback()
                '''    '        Finally
                '''    '            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                '''    '        End Try
                '''    '    End Using
                '''    'Catch ex As Exception
                '''    'End Try

                '''End If

        End Select
    End Sub

    Private Sub RadGridResources_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridResources.NeedDataSource
        If ThisEventId > 0 And Not Me.DtResources Is Nothing Then
            Dim dv As DataView = New DataView(DtResources)
            dv.RowFilter = "EVENT_ID = " & ThisEventId
            Me.RadGridResources.DataSource = dv
        End If
    End Sub

End Class