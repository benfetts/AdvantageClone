Imports System.Data.SqlClient
Imports System.Drawing

Public Class Alert_Notification
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _HasItems As Boolean = False

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ImageButtonDismissAlerts_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonDismissAlerts.Click

        Dim HasAlertDismissed As Boolean = False
        Dim DtForDismiss As New DataTable

        DtForDismiss = Me.LoadAlertNotificationDataTable()

        If DtForDismiss IsNot Nothing AndAlso DtForDismiss.Rows.Count > 0 Then

            Dim PromptForFullCompleteTask As Boolean = False
            Dim PromptForTempCompleteTask As Boolean = False
            Dim s As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For i As Integer = 0 To DtForDismiss.Rows.Count - 1

                    Try

                        If DtForDismiss.Rows(i)("IsAssignment") = "0" OrElse DtForDismiss.Rows(i)("CurrentNotify") = "0" Then

                            AdvantageFramework.AlertSystem.DismissAlert(DbContext, CInt(DtForDismiss.Rows(i).Item(0)), HttpContext.Current.Session("EmpCode"), _Session.UserCode,
                                                                        HttpContext.Current.Session("UserID"),
                                                                        False, PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                            HasAlertDismissed = True

                        End If

                    Catch ex As Exception
                    End Try

                Next

            End Using

        End If

        If HasAlertDismissed = True Then

            Me.LoadAlerts()
            Me.RefreshAlertWindows(False)

        End If

    End Sub
    Private Sub ListViewLinks_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListViewLinks.ItemDataBound

        Select Case e.Item.ItemType
            Case ListViewItemType.DataItem

                Dim DivAlert As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivAlert")
                Dim AlertID As Integer = CType(e.Item.DataItem("AlertID"), Integer)
                Dim CommentLiteral As Literal = e.Item.FindControl("LiteralComment")

                If CommentLiteral IsNot Nothing AndAlso IsDBNull(e.Item.DataItem("Subject")) = False Then CommentLiteral.Text = Me.Sanitize(e.Item.DataItem("Subject"))
                If DivAlert IsNot Nothing Then DivAlert.Attributes.Add("title", CommentLiteral.Text)

                If AlertID = -1 Then

                    DivAlert.Attributes.Add("onclick", "OpenRadWindow('','Alert_Inbox.aspx');return false;")
                    DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-highest")

                Else

                    Dim IsCSReview As Boolean = False
                    Dim qs As New AdvantageFramework.Web.QueryString

                    Try
                        IsCSReview = e.Item.DataItem("IsConceptShareReview")
                    Catch ex As Exception
                        IsCSReview = False
                    End Try

                    If IsCSReview = False Then

                        If CType(e.Item.DataItem("IsWorkItem"), Boolean) = False OrElse CType(e.Item.DataItem("CurrentNotify"), Boolean) = False Then

                            qs.Page = "Alert_View.aspx"
                            qs.AlertID = e.Item.DataItem("AlertID")
                            qs.Add("Alert", e.Item.DataItem("AlertID"))

                        Else

                            qs.Page = "Desktop_AlertView"
                            qs.Add("AlertID", e.Item.DataItem("AlertID").ToString)
                            Try

                                qs.Add("SprintID", e.Item.DataItem("SprintID").ToString)

                            Catch ex As Exception
                                qs.Add("SprintID", "0")
                            End Try

                        End If

                    Else

                        qs.Page = "Alert_DigitalAssetReview.aspx"
                        qs.AlertID = e.Item.DataItem("AlertID")
                        qs.JobNumber = e.Item.DataItem("JobNumber")
                        qs.JobComponentNumber = e.Item.DataItem("JobComponentNumber")
                        qs.ConceptShareProjectID = e.Item.DataItem("ConceptShareProjectID")
                        qs.ConceptShareReviewID = e.Item.DataItem("ConceptShareReviewID")

                    End If

                    DivAlert.Attributes.Add("onclick", String.Format("OpenRadWindow('','{0}');return false;", qs.ToString(True)))

                    Select Case e.Item.DataItem("Priority")
                        Case 5

                            DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-lowest")

                        Case 4

                            DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-low")

                        Case 2

                            DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-high")

                        Case 1

                            DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-highest")

                        Case Else

                            DivAlert.Attributes.Add("class", "alert-notification-container alert-priority-normal")

                    End Select

                End If

        End Select

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_Notification_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LoadAlerts()

        Else

            Select Case Me.EventTarget
                'Case "GoAndRefresh"

                '    Dim AlertId As Integer = CType(Me.EventArgument, Integer)
                '    Dim a As New cAlerts()
                '    a.MarkAlertRead(AlertId)
                '    Me.OpenWindow("", "Alert_View.aspx?alert=" & AlertId.ToString())
                '    Me.LoadAlerts()

                Case "RebindGrid"

                    Me.LoadAlerts()


            End Select

        End If
    End Sub

#End Region

    Private Sub LoadAlerts()

        With Me.ListViewLinks

            .Items.Clear()
            .DataSource = Me.LoadAlertNotificationDataTable()
            .DataBind()

        End With

        If _HasItems = False Then

            Me.HideAlertNotificationWindow()

        Else

            Me.ShowAlertNotificationWindow()

        End If

    End Sub
    Private Function LoadAlertNotificationDataTable() As DataTable

        Dim app As New cApplication(Session("ConnString"))

        If app.AlertNotify() = True Then

            Dim SQL As New System.Text.StringBuilder

            If Me.IsClientPortal = False Then

                SQL.Append(String.Format("EXEC [dbo].[advsp_alert_notifications] '{0}', NULL;", Session("EmpCode").ToString()))

            Else

                SQL.Append(String.Format("EXEC [dbo].[advsp_alert_notifications] NULL, {0};", Session("UserID").ToString()))

            End If

            Dim DtNewAlerts As New DataTable
            DtNewAlerts = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL.ToString(), "DtData")

            If Not DtNewAlerts Is Nothing AndAlso DtNewAlerts.Rows.Count > 0 Then Me._HasItems = True

            Return DtNewAlerts

        End If

    End Function

#End Region

End Class
