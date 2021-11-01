Imports Webvantage.cGlobals


Partial Public Class BillingApproval_AlertList
    Inherits Webvantage.BaseChildPage

    Private BatchID As Integer = 0
    'FromPage = 1 --> Batch List
    'FromPage = 2 --> Approval List
    Private FromPage As Integer = 0
    Private TheMonth As String = ""
    Private TheYear As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.SetQSVars()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGridBatchAlerts_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBatchAlerts.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        If e.CommandName = "OpenAlert" Then
            'Dim GoToPage As String = "Alert_View.aspx?Alert=" & e.CommandArgument.ToString() & "&P=" & Me.FromPage.ToString() & "&m=" & Me.TheMonth & "&y=" & Me.TheYear
            Dim GoToPage As String = "Desktop_AlertView?SprintID=0&AlertID=" & e.CommandArgument.ToString() & "&P=" & Me.FromPage.ToString() & "&m=" & Me.TheMonth & "&y=" & Me.TheYear
            Me.OpenWindow("", GoToPage)
        End If
    End Sub

    Private Sub RadGridBatchAlerts_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBatchAlerts.NeedDataSource
        Me.SetQSVars()
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Me.RadGridBatchAlerts.DataSource = b.GetAlertList(Me.BatchID)
    End Sub

    Private Sub SetQSVars()
        Try
            If Not Request.QueryString("BAID") = Nothing Then
                Me.BatchID = CType(Request.QueryString("BAID"), Integer)
                Me.PageTitle = "Alerts for Batch:  " & Me.BatchID.ToString().PadLeft(6, "0")
            Else
                Me.BatchID = 0
            End If
        Catch ex As Exception
            Me.BatchID = 0
        End Try
        Try
            If Not Request.QueryString("P") = Nothing Then
                Me.FromPage = CType(Request.QueryString("P"), Integer)
            Else
                Me.FromPage = 0
            End If
        Catch ex As Exception
            Me.FromPage = 0
        End Try
        Try
            If Not Request.QueryString("m") = Nothing Then
                Me.TheMonth = Request.QueryString("m")
            Else
                Me.TheMonth = Now.Month.ToString().PadLeft(2, "0")
            End If
        Catch ex As Exception
            Me.TheMonth = Now.Month.ToString().PadLeft(2, "0")
        End Try
        Try
            If Not Request.QueryString("y") = Nothing Then
                Me.TheYear = Request.QueryString("y")
            Else
                Me.TheYear = Now.Year.ToString()
            End If
        Catch ex As Exception
            Me.TheYear = Now.Year.ToString()
        End Try
        If BatchID > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Desc As String = String.Empty

                Try

                    Desc = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BA_BATCH_DESC FROM BILL_APPR_BATCH WITH(NOLOCK) WHERE BA_BATCH_ID = {0};", BatchID)).SingleOrDefault

                Catch ex As Exception
                    Desc = String.Empty
                End Try

                Me.LabelHeader.Text = BatchID.ToString.PadLeft(6, "0")

                If String.IsNullOrWhiteSpace(Desc) = False Then

                    Me.LabelHeader.Text &= " - " & Desc
                    Me.LabelHeader.ToolTip = "Batch: " & Me.LabelHeader.Text

                End If

            End Using

        End If
    End Sub

End Class
