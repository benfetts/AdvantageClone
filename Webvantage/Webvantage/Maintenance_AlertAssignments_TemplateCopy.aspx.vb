Public Class Maintenance_AlertAssignments_TemplateCopy
    Inherits Webvantage.BaseChildPage

    Private AlertNotifyHdrId As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim q As New AdvantageFramework.Web.QueryString()
        q = q.FromCurrent()
        With q
            Me.AlertNotifyHdrId = .AlertTemplateID
        End With
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        If Me.TxtAlertNotifyName.Text.Trim() = "" Then
            Me.ShowMessage("Please enter a Template name")
        Else
            Dim a As New cAlerts()
            Dim s As String = ""
            s = a.CopyNotifyTemplate(Me.AlertNotifyHdrId, Me.TxtAlertNotifyName.Text.Trim(), Me.ChkCopyTeam.Checked)
            If IsNumeric(s) = True Then
                Dim NewAlrtNotifyHdrId As Integer = CType(s, Integer)
                If NewAlrtNotifyHdrId > 0 Then
                    Dim RefreshURL As New AdvantageFramework.Web.QueryString()
                    With RefreshURL
                        .Page = "Maintenance_AlertAssignments.aspx"
                        .Add("t", "2")
                        .Add("AlertTemplateID", NewAlrtNotifyHdrId.ToString())
                    End With
                    Me.CloseThisWindowAndRefreshCaller(RefreshURL.ToString(True), True)
                Else
                    Me.ShowMessage("A Template exists with this name; please change the name")
                End If
            Else
                Me.ShowMessage(s)
            End If
        End If
    End Sub

End Class