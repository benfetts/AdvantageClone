Public Class AdvantageSecuritySetupAssistantForm

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

        _Application = AdvantageFramework.Security.Application.Advantage_Update

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageSecuritySetupAssistantForm_CloseProgressBarEvent() Handles Me.CloseProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Visible = False

        Me.Refresh()

    End Sub
    Private Sub AdvantageSecuritySetupAssistantForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub AdvantageSecuritySetupAssistantForm_SetProgressBarValueEvent(CurrentValue As Integer) Handles Me.SetProgressBarValueEvent

        ProgressBarItemStatusBar_ProgressBar.Value = CurrentValue

        Me.Refresh()

    End Sub
    Private Sub AdvantageSecuritySetupAssistantForm_SetupProgressBarEvent(MinimumValue As Integer, MaximumValue As Integer, StartValue As Integer) Handles Me.SetupProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Minimum = MinimumValue
        ProgressBarItemStatusBar_ProgressBar.Maximum = MaximumValue
        ProgressBarItemStatusBar_ProgressBar.Value = StartValue

        ProgressBarItemStatusBar_ProgressBar.Visible = True

        Me.Refresh()

    End Sub
    Private Sub AdvantageSecuritySetupAssistantForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        AdvantageFramework.Security.Presentation.SecuritySetupAssistantForm.ShowForm()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
