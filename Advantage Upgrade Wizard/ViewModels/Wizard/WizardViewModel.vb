Friend Class WizardViewModel
    Implements IWizardViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _View As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView = Nothing
    Private _Pages() As IWizardPageViewModel = Nothing
    Private _MainForm As System.Windows.Forms.Form = Nothing
    Private _Index As Integer = 0
    Private _WizardInputs As WizardInputs = Nothing
    Private _HandsFreeMode As Boolean = False
    Private _BackupDatabase As Nullable(Of Boolean) = Nothing
    Private _CreateAdvantageUser As Nullable(Of Boolean) = Nothing
    Private _CreateAdvantageConnection As Boolean = False
    Private _CreateWebvantageConnection As Boolean = False
    Private _ModifyServicesConnection As Boolean = False
    Private _Errors As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "

    Public Property HandsFreeMode As Boolean
        Get
            HandsFreeMode = _HandsFreeMode
        End Get
        Set(value As Boolean)
            _HandsFreeMode = value
        End Set
    End Property
    Public Property BackupDatabase As Nullable(Of Boolean)
        Get
            BackupDatabase = _BackupDatabase
        End Get
        Set(value As Nullable(Of Boolean))
            _BackupDatabase = value
        End Set
    End Property
    Public Property CreateAdvantageUser As Nullable(Of Boolean)
        Get
            CreateAdvantageUser = _CreateAdvantageUser
        End Get
        Set(value As Nullable(Of Boolean))
            _CreateAdvantageUser = value
        End Set
    End Property
    Public Property CreateAdvantageConnection As Boolean
        Get
            CreateAdvantageConnection = _CreateAdvantageConnection
        End Get
        Set(value As Boolean)
            _CreateAdvantageConnection = value
        End Set
    End Property
    Public Property CreateWebvantageConnection As Boolean
        Get
            CreateWebvantageConnection = _CreateWebvantageConnection
        End Get
        Set(value As Boolean)
            _CreateWebvantageConnection = value
        End Set
    End Property
    Public Property ModifyServicesConnection As Boolean
        Get
            ModifyServicesConnection = _ModifyServicesConnection
        End Get
        Set(value As Boolean)
            _ModifyServicesConnection = value
        End Set
    End Property
    Public ReadOnly Property HasErrors As Boolean
        Get

            If _Errors IsNot Nothing Then

                HasErrors = _Errors.Any

            Else

                HasErrors = False

            End If

        End Get
    End Property
    Public ReadOnly Property CurrentPage() As IWizardPageViewModel Implements IWizardViewModel.CurrentPage
        Get
            CurrentPage = _Pages(_Index)
        End Get
    End Property
    Public ReadOnly Property WizardInputs() As WizardInputs Implements IWizardViewModel.WizardInputs
        Get
            WizardInputs = _WizardInputs
        End Get
    End Property
    Public ReadOnly Property View() As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView Implements IWizardViewModel.View
        Get
            View = _View
        End Get
    End Property
    Public ReadOnly Property Pages() As IWizardPageViewModel() Implements IWizardViewModel.Pages
        Get
            Pages = _Pages
        End Get
    End Property

#End Region

#Region " Methods "

    Public Sub New(Pages() As IWizardPageViewModel, View As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView, MainForm As System.Windows.Forms.Form)

        Me._Pages = Pages
        Me._View = View
        Me._MainForm = MainForm

        _WizardInputs = New WizardInputs

        _WizardInputs.ServerName = String.Empty
        _WizardInputs.Database = String.Empty
        _WizardInputs.UserName = String.Empty
        _WizardInputs.Password = String.Empty

        _WizardInputs.AdvantageUserName = String.Empty
        _WizardInputs.AdvantagePassword = String.Empty

        _WizardInputs.AdvantageConnectionFolder = String.Empty

        _Errors = New Generic.List(Of String)

    End Sub
    Public Sub [AddToErrors](Page As String, ErrorMessage As String)

        _Errors.Add(Page & " - " & ErrorMessage)

    End Sub
    Public Sub WriteAllErrorsToTextFile()

        Dim ErrorFileText As String = String.Empty

        If Me.HasErrors Then

            ErrorFileText = System.Environment.NewLine & System.Environment.NewLine & "Database: " & Me.WizardInputs.Database & System.Environment.NewLine & Join(_Errors.ToArray, System.Environment.NewLine)

            My.Computer.FileSystem.WriteAllText("UpgradeWizardErrors.txt", ErrorFileText, True)

        End If

    End Sub
    Public Function CanNext() As Boolean Implements IWizardViewModel.CanNext

        CanNext = (_Index >= 0) AndAlso (_Index < _Pages.Length - 1) AndAlso CurrentPage.IsComplete

    End Function
    Public Sub [Next]() Implements IWizardViewModel.Next

        'If _View.ActiveDocument IsNot Nothing Then

        '    Debug.WriteLine("[Next]  -  " & _View.ActiveDocument.Caption & "  -  " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ":" & System.DateTime.Now.Millisecond)

        'Else

        '    Debug.WriteLine("[Next]  -  " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ":" & System.DateTime.Now.Millisecond)

        'End If

        _Index += 1
        ActivatePage(_Index)

    End Sub
    Public Function CanPrev() As Boolean Implements IWizardViewModel.CanPrev

        CanPrev = _Index > 0 AndAlso _Index < _Pages.Length AndAlso CurrentPage.CanReturn

    End Function
    Public Sub Prev() Implements IWizardViewModel.Prev

        _Index -= 1
        ActivatePage(_Index)

    End Sub
    Public Sub PageCompleted() Implements IWizardViewModel.PageCompleted

        If CanNext() Then

            [Next]()

        End If

    End Sub
    Private Sub ActivatePage(Index As Integer)

        Dim PageGroup As DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup = Nothing

        PageGroup = TryCast(_View.ContentContainers("pageGroup"), DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup)

        _View.ActivateDocument(PageGroup.Items(Index))

        'If _HandsFreeMode Then

        '    If TypeOf PageGroup.Items(Index).Control Is SignInPage Then

        '        CType(PageGroup.Items(Index).Control, SignInPage).SignIn()

        '    End If

        'End If

    End Sub
    Public Sub GoToPage(Index As Integer) Implements IWizardViewModel.GoToPage

        _Index = Index
        ActivatePage(_Index)

    End Sub
    Public Function CanClose() As Boolean Implements IWizardViewModel.CanClose

        CanClose = (_Index = 0)

    End Function
    Public Sub Close(IsClosing As Boolean) Implements IWizardViewModel.Close

        Dim Flyout As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout = Nothing

        If IsClosing Then

            Flyout = TryCast(_View.ContentContainers("closeFlyout"), DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout)
            Flyout.Action = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction() With {.Caption = "Setup Wizard", .Description = "Are you sure you want to exit the setup?"}

            AddHandler _View.FlyoutHidden, AddressOf view_FlyoutHidden

            _View.ActivateContainer(Flyout)

        Else

            Close()

        End If

    End Sub
    Private Sub view_FlyoutHidden(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutResultEventArgs)

        RemoveHandler _View.FlyoutHidden, AddressOf view_FlyoutHidden

        If e.Result = System.Windows.Forms.DialogResult.Yes Then

            Close()

        End If

    End Sub
    Private Sub Close()

        _MainForm.BeginInvoke(New System.Action(AddressOf _MainForm.Close))

    End Sub

#End Region

End Class
