Public Interface IWizardViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    ReadOnly Property CurrentPage() As IWizardPageViewModel
    ReadOnly Property WizardInputs() As WizardInputs
    ReadOnly Property View As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView
    ReadOnly Property Pages() As IWizardPageViewModel()

#End Region

#Region " Methods "

    Sub PageCompleted()
    Function CanPrev() As Boolean
    Sub Prev()
    Function CanNext() As Boolean
    Sub [Next]()
    Function CanClose() As Boolean
    Sub Close(isClosing As Boolean)
    Sub GoToPage(Index As Integer)

#End Region

End Interface

