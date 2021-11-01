Partial Public Class FinishPage
    Inherits BaseWizardPage

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

        InitializeComponent()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub finishButton_Click(sender As Object, e As System.EventArgs) Handles finishButton.Click

        WizardViewModel.Close(False)

    End Sub

#End Region

#End Region

End Class
