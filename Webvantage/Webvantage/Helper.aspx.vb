Imports Telerik.Web.UI

Public Enum HelperAction
    Alerts_UnmarkNew = 1
    Alerts_MarkAllAsRead = 2
End Enum

Public Class HelperChildPage
    Inherits Webvantage.BaseChildPage

    Private Sub HelperChildPage_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("help") Is Nothing Then
                If IsNumeric(Request.QueryString("help")) = True Then
                    Dim DoAction As Webvantage.HelperAction
                    DoAction = CType(CType(Request.QueryString("help"), Integer), Webvantage.HelperAction)
                    Select Case DoAction
                        Case HelperAction.Alerts_MarkAllAsRead
                            Try
                                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "UPDATE ALERT_RCPT SET READ_ALERT = 1 WHERE (READ_ALERT IS NULL) AND (PROCESSED IS NULL) AND EMP_CODE = '" & Session("EmpCode") & "';")
                            Catch ex As Exception
                            End Try
                    End Select
                End If
            End If
            Me.CloseThisWindow()
        Catch ex As Exception
            Me.CloseThisWindow()
        End Try
    End Sub


End Class