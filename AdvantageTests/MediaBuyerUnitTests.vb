<Microsoft.VisualStudio.TestTools.UnitTesting.TestClass()>
Public Class MediaBuyerUnitTests

    Public Property TestContext As TestContext
    Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController = Nothing
    Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel = Nothing
    Private _Session As AdvantageFramework.Security.Session = Nothing

    Private Sub Initialize()

        _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Database.CreateConnectionString("MCHRISTMAN-PC", "ADVAN67001", False, "SYSADM", "sysadm"), "SYSADM", 0, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"))

        _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController(_Session)

        _ViewModel = _Controller.Load()

    End Sub
    <TestMethod()>
    Public Sub Add()

        'objects
        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim ErrorMessage As String = Nothing

        Initialize()

        MediaBuyerSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel()

        MediaBuyerSetupDetailViewModel.EmployeeCode = "jh"

        _Controller.Add(MediaBuyerSetupDetailViewModel, ErrorMessage)

        Assert.IsTrue(MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.IsEntityBeingAdded = False)

    End Sub
    <TestMethod()>
    Public Sub Add_Duplicate()

        'objects
        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim ErrorMessage As String = Nothing

        Initialize()

        MediaBuyerSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel()

        MediaBuyerSetupDetailViewModel.EmployeeCode = "ali"

        _Controller.Add(MediaBuyerSetupDetailViewModel, ErrorMessage)

        Assert.IsTrue(MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.IsEntityBeingAdded)

    End Sub
    <TestMethod()>
    Public Sub CancelNewItemRow()

        Initialize()

        _Controller.CancelNewItemRow(_ViewModel)

        _ViewModel.SelectedMediaBuyers = Nothing

        Assert.IsTrue(_ViewModel.IsNewRow = False AndAlso _ViewModel.CancelEnabled = False AndAlso _ViewModel.DeleteEnabled = False)

    End Sub
    <TestMethod()>
    Public Sub Delete()

        'objects
        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim ErrorMessage As String = Nothing

        Initialize()

        MediaBuyerSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel

        _ViewModel.SelectedMediaBuyers = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel)

        _ViewModel.SelectedMediaBuyers.Add(_ViewModel.MediaBuyers.Where(Function(MB) MB.EmployeeCode = "mike").FirstOrDefault)

        _Controller.Delete(_ViewModel, ErrorMessage)

        Assert.IsTrue(_ViewModel.MediaBuyers.Where(Function(MB) MB.EmployeeCode = "mike").Any = False)

    End Sub
    <TestMethod()>
    Public Sub InitNewRowEvent()

        Initialize()

        _Controller.InitNewRowEvent(_ViewModel)

        Assert.IsTrue(_ViewModel.IsNewRow AndAlso _ViewModel.CancelEnabled AndAlso Not _ViewModel.DeleteEnabled)

    End Sub
    <TestMethod()>
    Public Sub Load()

        Initialize()

        Assert.IsTrue(_ViewModel IsNot Nothing)

    End Sub
    <TestMethod()>
    Sub MediaBuyerSelectionChanged()

        'objects
        Dim IsNewItemRow As Boolean = True

        Initialize()

        _Controller.MediaBuyerSelectionChanged(_ViewModel, IsNewItemRow, Nothing)

        Assert.IsTrue(_ViewModel.IsNewRow = IsNewItemRow AndAlso _ViewModel.CancelEnabled = IsNewItemRow AndAlso _ViewModel.DeleteEnabled = Not IsNewItemRow AndAlso _ViewModel.SelectedMediaBuyers Is Nothing)

    End Sub
    <TestMethod()>
    Sub UpdateInactiveFlag()

        'objects
        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim ErrorMessage As String = Nothing

        Initialize()

        MediaBuyerSetupDetailViewModel = _ViewModel.MediaBuyers.Where(Function(MB) MB.EmployeeCode = "ali").First

		_Controller.UpdateInactiveFlag(MediaBuyerSetupDetailViewModel, 1, ErrorMessage)

		Assert.IsTrue(MediaBuyerSetupDetailViewModel.IsInactive = True)

    End Sub
    <TestMethod()>
    Public Sub ValidateEntity()

        'objects
        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim IsValid As Boolean = True

        Initialize()

        MediaBuyerSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel

        _Controller.ValidateEntity(MediaBuyerSetupDetailViewModel, IsValid)

        Assert.IsTrue(Not IsValid)

    End Sub
    <TestMethod()>
    Public Sub ValidateProperty_BadEmployeeCode()

        Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
        Dim IsValid As Boolean = True
        Dim ErrorMessage As String = Nothing

        Initialize()

        MediaBuyerSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel

        MediaBuyerSetupDetailViewModel.EmployeeCode = "!"

        ErrorMessage = _Controller.ValidateProperty(MediaBuyerSetupDetailViewModel, AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeCode.ToString, IsValid, "!")

        Assert.IsTrue(IsValid = False)

    End Sub

End Class