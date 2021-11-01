Namespace Security.Presentation

    Public Class PasswordPolicySetupForm

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
            _SettingModuleID = 10

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PasswordPolicySetupForm As AdvantageFramework.Security.Presentation.PasswordPolicySetupForm = Nothing

            PasswordPolicySetupForm = New AdvantageFramework.Security.Presentation.PasswordPolicySetupForm()

            PasswordPolicySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PasswordPolicySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace