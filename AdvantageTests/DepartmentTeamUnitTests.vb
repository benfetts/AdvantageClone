<Microsoft.VisualStudio.TestTools.UnitTesting.TestClass()>
Public Class DepartmentTeamUnitTests

	Public Property TestContext As TestContext
	Private _Controller As AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController = Nothing
	Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel = Nothing
	Private _Session As AdvantageFramework.Security.Session = Nothing

	<TestInitialize>
	Public Sub Initialize()

        _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"), "SYSADM", 0, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"))

        _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController(_Session)

		_ViewModel = _Controller.Load()

	End Sub
	<TestCleanup>
	Public Sub Cleanup()

		_Session = Nothing
		_Controller = Nothing
		_ViewModel = Nothing

	End Sub
	<TestMethod()>
	Public Sub Load()

		Assert.IsTrue(_ViewModel IsNot Nothing)

	End Sub
	<TestMethod()>
	Public Sub Add()

		'objects
		Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

		DepartmentTeam = New AdvantageFramework.Database.Entities.DepartmentTeam

		DepartmentTeam.Code = "stw"
		DepartmentTeam.Description = "Steve T Walden"

		_Controller.Add(_ViewModel, DepartmentTeam)

		Assert.IsTrue(DepartmentTeam.IsEntityBeingAdded = False)

	End Sub
	<TestMethod()>
	Public Sub Add_Duplicate()

		'objects
		Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

		DepartmentTeam = New AdvantageFramework.Database.Entities.DepartmentTeam

		DepartmentTeam.Code = "as"

		_Controller.Add(_ViewModel, DepartmentTeam)

		Assert.IsTrue(DepartmentTeam.IsEntityBeingAdded)

	End Sub
	<TestMethod()>
	Public Sub Save()

		'objects
		Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

		_Controller.Save(_ViewModel)

		Assert.IsTrue(DepartmentTeam.EntityKey IsNot Nothing AndAlso DepartmentTeam.EntityKey.IsTemporary = False)

	End Sub

End Class