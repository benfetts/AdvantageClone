Public Class help
    Inherits Webvantage.BaseChildPage
    'Protected header As header
    Protected WithEvents hlHelp As System.Web.UI.WebControls.HyperLink

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Me.AllowFloat = True
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.IsClientPortal = False Then

            Me.hlHelp.NavigateUrl = "webhelp/Webvantage_Help.htm"
            Me.PageTitle = "Webvantage Help"

        Else

            Me.hlHelp.NavigateUrl = "cphelp/index.htm"
            Me.PageTitle = "Client Portal Help"

        End If

    End Sub

End Class
