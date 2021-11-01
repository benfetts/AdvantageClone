Public Class DepartmentTeamUITests

	'Public Property TestContext As TestContext
	'Private _Application As TestStack.White.Application = Nothing
	'Private _MainWindow As TestStack.White.UIItems.WindowItems.Window = Nothing
	'Private _DepartmentTeamWindow As TestStack.White.UIItems.WindowItems.Window = Nothing
	'Private _Session As AdvantageFramework.Security.Session = Nothing

	'<TestInitialize>
	'Public Sub Initialize()

	'	TestStack.White.Configuration.CoreAppXmlConfiguration.Instance.RawElementBasedSearch = True
	'	TestStack.White.Configuration.CoreAppXmlConfiguration.Instance.UIAutomationZeroWindowBugTimeout = 5000

	'	_Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"), "SYSADM", 0)

	'	_Application = CreateApplication()

	'	_Application.WaitWhileBusy()

	'	_MainWindow = GetMainWindow(_Application)

	'	_Application.WaitWhileBusy()

	'End Sub
	'<TestCleanup>
	'Public Sub Cleanup()

	'	KillApplication(_Application)

	'End Sub
	'Private Function CreateApplication() As TestStack.White.Application

	'	'objects
	'	Dim Application As TestStack.White.Application = Nothing
	'	Dim ProcessStartInfo As System.Diagnostics.ProcessStartInfo = Nothing

	'	ProcessStartInfo = New ProcessStartInfo("C:\TFS_ROOT\Advantage\DevEF6\Output\Advantage Test.exe", "-sSTEVEW-NB -dADVKW7 -uSYSADM -psysadm")

	'	Application = TestStack.White.Application.AttachOrLaunch(ProcessStartInfo)

	'	CreateApplication = Application

	'End Function
	'Private Function GetMainWindow(Application As TestStack.White.Application) As TestStack.White.UIItems.WindowItems.Window

	'	'objects
	'	Dim MainWindow As TestStack.White.UIItems.WindowItems.Window = Nothing

	'	MainWindow = Application.GetWindow(TestStack.White.UIItems.Finders.SearchCriteria.ByAutomationId("AdvantageTestForm"), TestStack.White.Factory.InitializeOption.NoCache)

	'	GetMainWindow = MainWindow

	'End Function
	'Private Sub ClickHome_MaintenanceTab(MainWindow As TestStack.White.UIItems.WindowItems.Window)

	'	'objects
	'	Dim SuperTabMenu As TestStack.White.UIItems.Panel = Nothing
	'	Dim MaintenanceButton As TestStack.White.UIItems.Button = Nothing
	'	Dim MaintenanceTab As TestStack.White.UIItems.Panel = Nothing
	'	Dim MaintenanceTabUI As System.Windows.Automation.AutomationElement = Nothing
	'	Dim BackgroundControl As System.Windows.Automation.AutomationElement = Nothing
	'	Dim UIElement As System.Windows.Automation.AutomationElement = Nothing

	'	SuperTabMenu = MainWindow.Get(Of TestStack.White.UIItems.Panel)(TestStack.White.UIItems.Finders.SearchCriteria.ByAutomationId("SuperTabControlHome_Menu"))

	'	For Each UIElement In SuperTabMenu.AutomationElement.FindAll(Windows.Automation.TreeScope.Children, New System.Windows.Automation.PropertyCondition(System.Windows.Automation.AutomationElement.ControlTypeProperty, System.Windows.Automation.ControlType.Pane))

	'		If IsNumeric(UIElement.Current.AutomationId) Then

	'			BackgroundControl = UIElement
	'			Exit For

	'		End If

	'	Next

	'	For Each UIElement In BackgroundControl.FindAll(Windows.Automation.TreeScope.Descendants, New System.Windows.Automation.PropertyCondition(System.Windows.Automation.AutomationElement.NameProperty, "Maintenance"))

	'		If UIElement.Current.ControlType.Equals(System.Windows.Automation.ControlType.Button) Then

	'			MaintenanceTabUI = UIElement
	'			Exit For

	'		End If

	'	Next

	'	'MaintenanceTabUI = BackgroundControl.FindAll(Windows.Automation.TreeScope.Descendants, New System.Windows.Automation.PropertyCondition(System.Windows.Automation.AutomationElement.NameProperty, "Maintenance"))

	'	MaintenanceButton = New TestStack.White.UIItems.Button(MaintenanceTabUI, MainWindow)

	'	MaintenanceButton.Click()

	'End Sub
	'Private Function GetHome_MaintenanceTab_Accounting(MainWindow As TestStack.White.UIItems.WindowItems.Window) As TestStack.White.UIItems.TreeItems.TreeNode

	'	'objects
	'	Dim MenuItems As TestStack.White.UIItems.TreeItems.Tree = Nothing
	'	Dim AccountingNode As TestStack.White.UIItems.TreeItems.TreeNode = Nothing

	'	MenuItems = MainWindow.Get(Of TestStack.White.UIItems.TreeItems.Tree)(TestStack.White.UIItems.Finders.SearchCriteria.ByAutomationId("AdvTreeMaintenance_MenuItems"))

	'	For Each Node In MenuItems.Nodes

	'		If Node.NameMatches("Accounting") Then

	'			AccountingNode = Node
	'			Exit For

	'		End If

	'	Next

	'	GetHome_MaintenanceTab_Accounting = AccountingNode

	'End Function
	'Private Sub ClickHome_MaintenanceTab_Accounting(MainWindow As TestStack.White.UIItems.WindowItems.Window)

	'	'objects
	'	Dim AccountingNode As TestStack.White.UIItems.TreeItems.TreeNode = Nothing

	'	AccountingNode = GetHome_MaintenanceTab_Accounting(MainWindow)

	'	If AccountingNode.IsExpanded = False Then

	'		AccountingNode.Expand()

	'	End If

	'End Sub
	'Private Sub ClickHome_MaintenanceTab_Accounting_DeptTeam(MainWindow As TestStack.White.UIItems.WindowItems.Window)

	'	'objects
	'	Dim AccountingNode As TestStack.White.UIItems.TreeItems.TreeNode = Nothing
	'	Dim DeptTeamNode As TestStack.White.UIItems.TreeItems.TreeNode = Nothing

	'	AccountingNode = GetHome_MaintenanceTab_Accounting(MainWindow)

	'	DeptTeamNode = AccountingNode.Nodes.Find(Function(Node) Node.Name = "Dept/Team")

	'	DeptTeamNode.Click()

	'End Sub
	'Private Sub ClickHome(MainWindow As TestStack.White.UIItems.WindowItems.Window)

	'	'objects
	'	Dim Ribbon As TestStack.White.UIItems.Panel = Nothing
	'	Dim StartButton As TestStack.White.UIItems.Button = Nothing
	'	Dim StartButtonUI As System.Windows.Automation.AutomationElement = Nothing
	'	Dim SuperTabMenu As TestStack.White.UIItems.Panel = Nothing
	'	Dim SuperTabMenuUI As System.Windows.Automation.AutomationElement = Nothing

	'	For Each Panel In MainWindow.GetMultiple(Of TestStack.White.UIItems.Panel)

	'		If Panel.Id = "RibbonControlForm_MainRibbon" Then

	'			Ribbon = Panel

	'		ElseIf Panel.Id = "SuperTabControlHome_Menu" Then

	'			SuperTabMenu = Panel

	'		End If

	'	Next

	'	If SuperTabMenuUI Is Nothing Then

	'		StartButtonUI = Ribbon.AutomationElement.FindFirst(Windows.Automation.TreeScope.Descendants, New System.Windows.Automation.PropertyCondition(System.Windows.Automation.AutomationElement.NameProperty, "StartButton"))

	'		StartButton = New TestStack.White.UIItems.Button(StartButtonUI, MainWindow)

	'		StartButton.Focus()

	'		System.Threading.Thread.Sleep(1000)

	'		StartButton.Click()

	'	End If

	'End Sub
	'Private Sub KillApplication(Application As TestStack.White.Application)

	'	Application.Process.WaitForExit(3000)

	'	Application.Kill()

	'End Sub
	'Private Function OpenOrFocusWindow(MainWindow As TestStack.White.UIItems.WindowItems.Window, WindowName As String) As Boolean

	'	'objects
	'	Dim OpenedOrFocused As Boolean = False
	'	Dim Window As TestStack.White.UIItems.UIItemContainer = Nothing

	'	Window = GetWindow(MainWindow, WindowName)

	'	If Window Is Nothing Then

	'		OpenDepartmentTeamWindow(MainWindow)

	'		_Application.WaitWhileBusy()

	'		Window = GetWindow(MainWindow, WindowName)

	'	End If

	'	If Window IsNot Nothing Then

	'		_DepartmentTeamWindow = New TestStack.White.UIItems.WindowItems.Win32Window(Window.AutomationElement, TestStack.White.Factory.WindowFactory.Desktop, TestStack.White.Factory.InitializeOption.NoCache, _Application.ApplicationSession.WindowSession(TestStack.White.Factory.InitializeOption.NoCache))
	'		_DepartmentTeamWindow.Focus()
	'		OpenedOrFocused = True

	'	End If

	'	OpenOrFocusWindow = OpenedOrFocused

	'End Function
	'Private Sub OpenDepartmentTeamWindow(MainWindow As TestStack.White.UIItems.WindowItems.Window)

	'	ClickHome(_MainWindow)

	'	ClickHome_MaintenanceTab(_MainWindow)

	'	ClickHome_MaintenanceTab_Accounting(_MainWindow)

	'	ClickHome_MaintenanceTab_Accounting_DeptTeam(_MainWindow)

	'End Sub
	'Private Function IsWindowOpen(MainWindow As TestStack.White.UIItems.WindowItems.Window, WindowName As String) As Boolean

	'	'objects
	'	Dim IsOpen As Boolean = False
	'	Dim Window As TestStack.White.UIItems.UIItemContainer = Nothing

	'	Window = GetWindow(MainWindow, WindowName)

	'	If Window IsNot Nothing Then

	'		IsOpen = True

	'	End If

	'	IsWindowOpen = IsOpen

	'End Function
	'Private Function GetWindow(MainWindow As TestStack.White.UIItems.WindowItems.Window, WindowName As String) As TestStack.White.UIItems.UIItemContainer

	'	'objects
	'	Dim TabStrip As TestStack.White.UIItems.Panel = Nothing
	'	Dim Window As TestStack.White.UIItems.UIItemContainer = Nothing

	'	For Each Panel In MainWindow.GetMultiple(Of TestStack.White.UIItems.Panel)

	'		If Panel.Id = "TabStripForm_MDIChildren" Then

	'			TabStrip = Panel
	'			Exit For

	'		End If

	'	Next

	'	If TabStrip IsNot Nothing Then

	'		Window = MainWindow.MdiChild(TestStack.White.UIItems.Finders.SearchCriteria.ByAutomationId(WindowName))

	'	End If

	'	GetWindow = Window

	'End Function


	'<TestCategory("Test1")>
	'<TestMethod()>
	'Public Sub Load()

	'	Assert.IsTrue(OpenOrFocusWindow(_MainWindow, DepartmentTeamWindowName))

	'End Sub

	'<TestMethod()>
	'Public Sub Add()

	'	'objects
	'	Dim IsOpen As Boolean = False
	'	Dim Table As TestStack.White.UIItems.TableItems.Table = Nothing
	'	Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

	'	Load()

	'	If _DepartmentTeamWindow IsNot Nothing Then

	'		Table = _DepartmentTeamWindow.Get(Of TestStack.White.UIItems.TableItems.Table)(TestStack.White.UIItems.Finders.SearchCriteria.ByAutomationId("DataGridView_GridControl"))

	'		If Table IsNot Nothing Then

	'			Table.Rows(0).Cells(0).Value = "sw"
	'			Table.Rows(0).Cells(1).Value = "Steven Walden"
	'			Table.Rows(0).Cells(2).Value = False
	'			Table.Rows(0).Cells(3).Value = 85.0
	'			Table.Rows(0).Cells(4).Value = Nothing
	'			Table.Rows(0).Cells(5).Value = Nothing
	'			Table.Rows(0).Cells(6).Value = Nothing

	'			_DepartmentTeamWindow.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.TAB)

	'		End If

	'	End If

	'	Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

	'		DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, "sw")

	'		Assert.IsTrue(DepartmentTeam IsNot Nothing)

	'	End Using

	'End Sub
	''<TestMethod()>
	''Public Sub LoadMVC()

	''	Dim DepartmentTeamSetupForm As AdvantageFramework.Maintenance.Accounting.Views.DepartmentTeamSetupForm = Nothing
	''	Dim Session As AdvantageFramework.Security.Session = Nothing

	''	Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Database.CreateConnectionString("STEVEW-NB", "ADVKW7", False, "SYSADM", "sysadm"), "SYSADM", 0)

	''	DepartmentTeamSetupForm = New AdvantageFramework.Maintenance.Accounting.Views.DepartmentTeamSetupForm

	''	DepartmentTeamSetupForm.SetSession(Session)

	''	DepartmentTeamSetupForm.Show()

	''End Sub

End Class