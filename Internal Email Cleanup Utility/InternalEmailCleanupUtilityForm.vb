Public Class InternalEmailCleanupUtilityForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Outlook_Addin

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub InternalEmailCleanupUtilityForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub InternalEmailCleanupUtilityForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        AdvantageFramework.WinForm.Presentation.EmailCleanupForm.ShowForm()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class