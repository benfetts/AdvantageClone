Imports EeekSoft
Partial Public Class DesktopAlertSummary
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadAlertSummary()

    End Sub
  
    Private Sub LoadAlertSummary()
        Dim AlertCount As Integer = 0
        Dim HighPriorityAlertCount As Integer = 0
        Dim AssignmentCount As Integer = 0

        Dim a As New cAlerts()
        Dim dt As New DataTable
        dt = a.GetAlertSummary(Session("EmpCode"))
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)("TOTAL_ALERTS")) = True Then
                    AlertCount = CType(dt.Rows(0)("TOTAL_ALERTS"), Integer)
                End If
                If Not IsDBNull(dt.Rows(0)("HIGH_PRIORITY_ALERTS")) = True Then
                    HighPriorityAlertCount = CType(dt.Rows(0)("HIGH_PRIORITY_ALERTS"), Integer)
                End If
                If Not IsDBNull(dt.Rows(0)("TOTAL_ASSIGNMENTS")) = True Then
                    AssignmentCount = CType(dt.Rows(0)("TOTAL_ASSIGNMENTS"), Integer)
                End If
            End If
        End If

        Select Case AlertCount
            Case 0
                Me.AlertSummaryLabel.Text = "You have no new alerts in your inbox."
            Case 1
                Me.AlertSummaryLabel.Text = "You have " & AlertCount & " new alert in your inbox."
            Case Is > 1
                Me.AlertSummaryLabel.Text = "You have " & AlertCount & " new alerts in your inbox."
        End Select

        Select Case HighPriorityAlertCount
            Case 1
                Me.AlertSummaryLabel.Text &= "<br/>Of them, " & HighPriorityAlertCount & " is marked as high priority."
            Case Is > 1
                Me.AlertSummaryLabel.Text &= "<br/>Of them, " & HighPriorityAlertCount & " are marked as high priority."
        End Select

        Select Case AssignmentCount
            Case 1
                Me.AlertSummaryLabel.Text &= "<br /><br />" & AssignmentCount.ToString() & " is an assignment."
            Case Is > 1
                Me.AlertSummaryLabel.Text &= "<br /><br />" & AssignmentCount.ToString() & " are assignments."
        End Select

    End Sub

    Protected Sub InboxLinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InboxLinkButton.Click
        Session("AlertsCurrentPageNumber") = 0
        Me.OpenWindow("", "Alert_Inbox.aspx")
    End Sub

End Class