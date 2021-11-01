Namespace Maintenance.ProjectManagement.Presentation

    Public Class ProductionSettingsSetupForm

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
            _SettingModuleID = 2

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ProductionSettingsSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.ProductionSettingsSetupForm = Nothing

            ProductionSettingsSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.ProductionSettingsSetupForm()

            ProductionSettingsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductionSettingsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace