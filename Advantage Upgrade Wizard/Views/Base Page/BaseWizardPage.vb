Partial Public Class BaseWizardPage
    Inherits DevExpress.XtraEditors.XtraUserControl
    Implements DevExpress.XtraBars.Docking2010.Views.WindowsUI.ISupportNavigation

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _WizardViewModel As IWizardViewModel = Nothing

#End Region

#Region " Properties "

    Protected ReadOnly Property PageViewModel() As IWizardPageViewModel
        Get
            PageViewModel = WizardViewModel.CurrentPage
        End Get
    End Property
    Public Property WizardViewModel() As IWizardViewModel
        Get
            WizardViewModel = _WizardViewModel
        End Get
        Set(value As IWizardViewModel)
            _WizardViewModel = value
        End Set
    End Property

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

#Region "ISupportNavigation Members"

    Private Sub OnNavigatedTo(args As DevExpress.XtraBars.Docking2010.Views.WindowsUI.INavigationArgs) Implements DevExpress.XtraBars.Docking2010.Views.WindowsUI.ISupportNavigation.OnNavigatedTo

        _WizardViewModel = TryCast(args.Parameter, IWizardViewModel)

        'If CType(_WizardViewModel, WizardViewModel).HandsFreeMode Then

        '    If TypeOf Me Is StartPage Then

        '        CType(Me, StartPage).Next()

        '    End If

        'End If

    End Sub
    Private Sub OnNavigatedFrom(args As DevExpress.XtraBars.Docking2010.Views.WindowsUI.INavigationArgs) Implements DevExpress.XtraBars.Docking2010.Views.WindowsUI.ISupportNavigation.OnNavigatedFrom



    End Sub

#End Region

#End Region

#End Region

End Class
