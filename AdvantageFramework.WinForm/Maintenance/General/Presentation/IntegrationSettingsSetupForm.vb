Namespace Maintenance.General.Presentation

    Public Class IntegrationSettingsSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _SettingModuleID = 7

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim IntegrationSettingsSetupForm As AdvantageFramework.Maintenance.General.Presentation.IntegrationSettingsSetupForm = Nothing

            IntegrationSettingsSetupForm = New AdvantageFramework.Maintenance.General.Presentation.IntegrationSettingsSetupForm()

            IntegrationSettingsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IntegrationSettingsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace