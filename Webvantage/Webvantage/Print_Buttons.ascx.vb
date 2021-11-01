Public Class Print_Buttons
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim bc As HttpBrowserCapabilities = Request.Browser
            If bc.Browser = "Chrome" Then
                Me.BtnPrint.Attributes.Add("onclick", "window.print();window.close();return false;")
            Else
                Me.BtnPrint.Attributes.Add("onclick", "window.print();window.close();")
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class