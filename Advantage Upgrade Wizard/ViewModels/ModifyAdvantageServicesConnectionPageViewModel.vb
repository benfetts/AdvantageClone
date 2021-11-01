Friend Class ModifyAdvantageServicesConnectionPageViewModel
    Implements IWizardPageViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    'Private _IsComplete As Boolean = False

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

    'Public Sub SetIsComplete(IsComplete As Boolean)

    '    _IsComplete = IsComplete

    'End Sub

#End Region

End Class
