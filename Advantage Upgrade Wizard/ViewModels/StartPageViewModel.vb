Friend Class StartPageViewModel
    Implements IWizardPageViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public ReadOnly Property IsComplete() As Boolean Implements IWizardPageViewModel.IsComplete
        Get
            IsComplete = True
        End Get
    End Property
    Public ReadOnly Property CanReturn() As Boolean Implements IWizardPageViewModel.CanReturn
        Get
            CanReturn = False
        End Get
    End Property

#End Region

#Region " Methods "



#End Region

End Class
