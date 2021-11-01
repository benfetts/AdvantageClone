Partial Public Class CreateAPIConnectionPage
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

    Private Sub SimpleButtonForm_Create_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Create.Click

        Me.WizardViewModel.PageCompleted()

    End Sub

#End Region

#End Region

End Class
