Partial Public Class JobComponent_Comments
    Inherits Webvantage.BaseChildPage

    Private AlertId As Integer = 0
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub RadGridAlertComments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAlertComments.NeedDataSource
        Try
            If Not Request.QueryString("a") Is Nothing Then
                AlertId = CType(Request.QueryString("a"), Integer)
            End If
        Catch ex As Exception
            AlertId = 0
        End Try
        Try
            If Not Request.QueryString("j") Is Nothing Then
                JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then
                JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            Dim Alert As New Alert(Session("ConnString"))
            If Me.AlertId > 0 And Me.JobNumber = 0 And Me.JobComponentNbr = 0 Then
                Alert.LoadByPrimaryKey(Me.AlertId)
                Dim Comments As vAlertComments = Alert.GetCommentsView()
                Comments.Sort = "Generated DESC"
                Me.RadGridAlertComments.DataSource = Comments.DefaultView
            ElseIf Me.AlertId = 0 And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                Me.RadGridAlertComments.DataSource = Alert.GetJobComments(Me.JobNumber, Me.JobComponentNbr)
            End If
        Catch ex As Exception
        End Try
        Try
            Me.RadGridAlertComments.MasterTableView.GroupByExpressions.Add("SUBJECT Subject Group By SUBJECT")
        Catch ex As Exception

        End Try
    End Sub
End Class