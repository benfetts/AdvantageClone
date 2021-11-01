<Microsoft.VisualStudio.TestTools.UnitTesting.TestClass()>
Public Class GeneralLedgerMappingExportUnitTests

    Public Property TestContext As TestContext
    Private _Controller As AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerMappingExportController = Nothing
    Private _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel = Nothing
    Private _Session As AdvantageFramework.Security.Session = Nothing

    Private Sub Initialize()

        _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Database.CreateConnectionString("TPOINDEXTER-PC", "AQUAEF6", False, "SYSADM", "sysadm"), "SYSADM", 0, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"))

        _Controller = New AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerMappingExportController(_Session)

        _ViewModel = _Controller.Load()

    End Sub
    <TestMethod()>
    Public Sub Add()

        'objects
        Dim ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel = Nothing
		Dim GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount = Nothing
		Dim ErrorMessage As String = Nothing

        Initialize()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            _ViewModel.SelectedRecordSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList.FirstOrDefault

        End Using

		GeneralLedgerMappingExportTargetAccount = New AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount
		GeneralLedgerMappingExportTargetAccount.Code = "test" & System.DateTime.Now.ToString

		_Controller.Add(_ViewModel, GeneralLedgerMappingExportTargetAccount, ErrorMessage)

		Assert.IsTrue(ViewModel.SelectedGeneralLedgerMappingExportTargetAccount.IsEntityBeingAdded = False)

	End Sub
    <TestMethod()>
    Public Sub Add_Duplicate()

        'objects
        Dim ErrorMessage As String = Nothing
		Dim GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount = Nothing

		Initialize()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

			_ViewModel.SelectedRecordSource = (From Item In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
											   Join GlSrc In AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportTargetAccount.Load(DbContext) On Item.ID Equals GlSrc.RecordSourceID
											   Select Item).FirstOrDefault

			GeneralLedgerMappingExportTargetAccount = New AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount

			GeneralLedgerMappingExportTargetAccount.Code = AdvantageFramework.Database.Procedures.GeneralLedgerMappingExportTargetAccount.LoadByRecordSourceID(DbContext, _ViewModel.SelectedRecordSource.ID).FirstOrDefault.Code

		End Using

		_Controller.Add(_ViewModel, GeneralLedgerMappingExportTargetAccount, ErrorMessage)

		Assert.IsTrue(GeneralLedgerMappingExportTargetAccount.IsEntityBeingAdded)

	End Sub
    <TestMethod()>
    Public Sub CancelNewItemRow()

        Initialize()

        _Controller.CancelNewItemRow(_ViewModel)

        _ViewModel.SelectedGeneralLedgerMappingExportGLAccounts = Nothing

        Assert.IsTrue(_ViewModel.IsNewItemRow = False AndAlso _ViewModel.CancelEnabled = False AndAlso _ViewModel.DeleteEnabled = False)

    End Sub
    <TestMethod()>
    Public Sub Delete()

        'objects
        Dim ErrorMessage As String = Nothing
		Dim GeneralLedgerMappingExportSourceAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount = Nothing

		Initialize()

		GeneralLedgerMappingExportSourceAccount = _ViewModel.GeneralLedgerMappingExportTargetAccounts.FirstOrDefault

		_ViewModel.SelectedGeneralLedgerMappingExportTargetAccount = GeneralLedgerMappingExportSourceAccount

		_Controller.Delete(_ViewModel, ErrorMessage)

		Assert.IsTrue(_ViewModel.GeneralLedgerMappingExportTargetAccounts.Where(Function(GlSrc) GlSrc.ID = GeneralLedgerMappingExportSourceAccount.ID).Any = False)

	End Sub
    <TestMethod()>
    Public Sub InitNewRowEvent()

        Initialize()

        _Controller.InitNewRowEvent(_ViewModel, False)

        Assert.IsTrue(_ViewModel.IsNewItemRow AndAlso _ViewModel.CancelEnabled AndAlso Not _ViewModel.DeleteEnabled)

    End Sub
    <TestMethod()>
    Public Sub DetailInitNewRowEvent()

        Initialize()

        _Controller.InitNewRowEvent(_ViewModel, True)

        Assert.IsTrue(_ViewModel.DetailIsNewItemRow AndAlso _ViewModel.DetailCancelEnabled AndAlso Not _ViewModel.DetailDeleteEnabled)

    End Sub
    <TestMethod()>
    Public Sub Load()

        Initialize()

        Assert.IsTrue(_ViewModel IsNot Nothing)

    End Sub
    <TestMethod()>
    Public Sub ValidateEntity()

		'objects
		Dim GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount = Nothing
		Dim IsValid As Boolean = True

        Initialize()

		GeneralLedgerMappingExportTargetAccount = New AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount
		GeneralLedgerMappingExportTargetAccount.Code = "abcdefghijklmnopqrstuvwxyz"
		GeneralLedgerMappingExportTargetAccount.RecordSourceID = _ViewModel.SelectedRecordSource.ID

		_Controller.ValidateEntity(GeneralLedgerMappingExportTargetAccount, IsValid)

		Assert.IsTrue(Not IsValid)

    End Sub

End Class