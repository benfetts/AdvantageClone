Public Class dtp_alerts
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadAlerts()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub LoadAlerts()
        Dim oDesktop As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim strEmpCode As String = Session("EmpCode")
        Me.rpAlerts.DataSource = oDesktop.LoadAlerts(strEmpCode)
        Me.rpAlerts.DataBind()
    End Sub

End Class