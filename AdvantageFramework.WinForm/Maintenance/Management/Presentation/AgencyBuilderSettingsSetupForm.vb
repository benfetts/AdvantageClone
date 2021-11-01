Namespace Maintenance.Management.Presentation

    Public Class AgencyBuilderSettingsSetupForm

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
            _SettingModuleID = 1

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AgencyBuilderSettingsSetupForm As AdvantageFramework.Maintenance.Management.Presentation.AgencyBuilderSettingsSetupForm = Nothing

            AgencyBuilderSettingsSetupForm = New AdvantageFramework.Maintenance.Management.Presentation.AgencyBuilderSettingsSetupForm()

            AgencyBuilderSettingsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AgencyBuilderSettingsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace