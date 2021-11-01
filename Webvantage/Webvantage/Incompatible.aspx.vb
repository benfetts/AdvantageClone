Public Class Incompatible
    Inherits System.Web.UI.Page

    'We are really only blocking lower than IE9

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MajorVersion As Integer = CType(Request.Browser.MajorVersion.ToString().Trim(), Integer)
        Me.LabelBrowserType.Text = Request.Browser.Browser.ToString().Trim().ToUpper()
        Me.LabelBrowserVersion.Text = MajorVersion.ToString()

        'If Request.Browser.Browser.ToString().Trim().ToUpper() = "IE" And _
        '     MajorVersion >= 9 Then

        '    MiscFN.ResponseRedirect("SignIn.aspx", True)

        'End If

        If Request.Browser.Browser.ToString().Trim().ToUpper() <> "IE" Then

            Me.PanelYouShouldNotBeHere.Visible = True

        Else 'it is IE

            If MajorVersion >= 9 Then

                Me.PanelYouShouldNotBeHere.Visible = True

            End If

        End If

    End Sub

End Class