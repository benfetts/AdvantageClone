Namespace FinanceAndAccounting.Presentation

    Public Class IRS1099ProcessingSettingsSetupForm

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
            '_SettingModuleID = 6

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim IRS1099ProcessingSettingsSetupForm As AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSettingsSetupForm = Nothing

            IRS1099ProcessingSettingsSetupForm = New AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSettingsSetupForm()

            IRS1099ProcessingSettingsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IRS1099ProcessingSettingsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace