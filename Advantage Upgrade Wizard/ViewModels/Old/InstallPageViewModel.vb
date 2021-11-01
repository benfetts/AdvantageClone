Friend Class InstallPageViewModel
    Implements IWizardPageViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _IsComplete As Boolean = False

#End Region

#Region " Properties "

    Public ReadOnly Property IsComplete() As Boolean Implements IWizardPageViewModel.IsComplete
        Get
            IsComplete = _IsComplete
        End Get
    End Property
    Public ReadOnly Property CanReturn() As Boolean Implements IWizardPageViewModel.CanReturn
        Get
            CanReturn = Not IsComplete
        End Get
    End Property

#End Region

#Region " Methods "

    Public Sub SetComplete(value As Boolean)

        _IsComplete = value

    End Sub

#End Region

End Class
