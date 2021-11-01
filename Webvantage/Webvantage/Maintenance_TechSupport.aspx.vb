Public Class Maintenance_TechSupport
    Inherits Webvantage.BaseChildPage

    Private Sub Maintenance_TechSupport_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If CType(Session("Admin"), BookmarkType) = False Then
            Me.CloseThisWindow()
        End If
    End Sub

End Class