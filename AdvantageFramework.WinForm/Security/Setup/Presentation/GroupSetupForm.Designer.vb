Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GroupSetupForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupSetupForm))
            Me.DataGridViewLeftSection_Groups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonRightSection_RemoveFromGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddToGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_GroupUsers = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_AvailableUsers = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerRightSection_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Employees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployees_Terminated = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TextBoxRightSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRightSection_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRightSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlRightSection_GroupDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelUsersTab_Users = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelUsers_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlUsers_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelUsers_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabItemGroupDetails_UsersTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelModuleAccessTab_ModuleAccess = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxModuleAccess_IsApplicationBlocked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.AdvTreeModuleAccess_Modules = New DevComponents.AdvTree.AdvTree()
            Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
            Me.LabelModuleAccess_Options = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelModuleAccess_Application = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxModuleAccess_IsBlocked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_CanAdd = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_CanPrint = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_Custom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxModuleAccess_Application = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxModuleAccess_CanUpdate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_Custom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemGroupDetails_ModuleAccessTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGroupSettingsTab_GroupSettings = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelGroupSettings_WorkspaceTemplateSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGroupSettings_ViewPrivateDocuments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGroupSettings_DocumentManagerSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGroupSettings_CanUpload = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGroupSettings_AllowTaskEdit = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGroupSettings_AllowMediaPageEdit = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGroupSettings_AlertInboxSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGroupSettings_ShowAllAssignments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGroupSettings_CalendarSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemGroupDetails_GroupSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelWorkspacesTab_Workspaces = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonWorkspaces_Apply = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelWorkspaces_WorkspaceTemplates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxWorkspaces_WorkspaceTemplates = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemGroupDetails_WorkspacesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerRightSection_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlRightSection_GroupDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_GroupDetails.SuspendLayout()
            Me.TabControlPanelUsersTab_Users.SuspendLayout()
            CType(Me.PanelUsers_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelUsers_RightSection.SuspendLayout()
            CType(Me.PanelUsers_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelUsers_LeftSection.SuspendLayout()
            Me.TabControlPanelModuleAccessTab_ModuleAccess.SuspendLayout()
            CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelGroupSettingsTab_GroupSettings.SuspendLayout()
            Me.TabControlPanelWorkspacesTab_Workspaces.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_Groups
            '
            Me.DataGridViewLeftSection_Groups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Groups.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Groups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Groups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Groups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Groups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Groups.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Groups.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Groups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Groups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Groups.DataSource = Nothing
            Me.DataGridViewLeftSection_Groups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Groups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Groups.ItemDescription = ""
            Me.DataGridViewLeftSection_Groups.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Groups.MultiSelect = True
            Me.DataGridViewLeftSection_Groups.Name = "DataGridViewLeftSection_Groups"
            Me.DataGridViewLeftSection_Groups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Groups.RunStandardValidation = True
            Me.DataGridViewLeftSection_Groups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Groups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Groups.Size = New System.Drawing.Size(257, 516)
            Me.DataGridViewLeftSection_Groups.TabIndex = 0
            Me.DataGridViewLeftSection_Groups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Groups.ViewCaptionHeight = -1
            '
            'CheckBoxLeftSection_ShowOnlyUsersWithNoGroup
            '
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.CheckValue = 0
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.CheckValueChecked = 1
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.ChildControls = CType(resources.GetObject("CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Location = New System.Drawing.Point(5, 410)
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Name = "CheckBoxLeftSection_ShowOnlyUsersWithNoGroup"
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.OldestSibling = Nothing
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.SecurityEnabled = True
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.SiblingControls = CType(resources.GetObject("CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Size = New System.Drawing.Size(371, 20)
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.TabIndex = 7
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.TabOnEnter = True
            Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Text = "Show Only Users With No Group"
            '
            'ButtonRightSection_RemoveFromGroup
            '
            Me.ButtonRightSection_RemoveFromGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveFromGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveFromGroup.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSection_RemoveFromGroup.Name = "ButtonRightSection_RemoveFromGroup"
            Me.ButtonRightSection_RemoveFromGroup.SecurityEnabled = True
            Me.ButtonRightSection_RemoveFromGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveFromGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveFromGroup.TabIndex = 2
            Me.ButtonRightSection_RemoveFromGroup.Text = "<"
            '
            'ButtonRightSection_AddToGroup
            '
            Me.ButtonRightSection_AddToGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddToGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddToGroup.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSection_AddToGroup.Name = "ButtonRightSection_AddToGroup"
            Me.ButtonRightSection_AddToGroup.SecurityEnabled = True
            Me.ButtonRightSection_AddToGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddToGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddToGroup.TabIndex = 1
            Me.ButtonRightSection_AddToGroup.Text = ">"
            '
            'DataGridViewRightSection_GroupUsers
            '
            Me.DataGridViewRightSection_GroupUsers.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_GroupUsers.AllowDragAndDrop = False
            Me.DataGridViewRightSection_GroupUsers.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_GroupUsers.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_GroupUsers.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_GroupUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_GroupUsers.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_GroupUsers.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_GroupUsers.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_GroupUsers.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_GroupUsers.DataSource = Nothing
            Me.DataGridViewRightSection_GroupUsers.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_GroupUsers.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_GroupUsers.ItemDescription = "Group User(s)"
            Me.DataGridViewRightSection_GroupUsers.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_GroupUsers.MultiSelect = True
            Me.DataGridViewRightSection_GroupUsers.Name = "DataGridViewRightSection_GroupUsers"
            Me.DataGridViewRightSection_GroupUsers.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_GroupUsers.RunStandardValidation = True
            Me.DataGridViewRightSection_GroupUsers.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_GroupUsers.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_GroupUsers.Size = New System.Drawing.Size(241, 425)
            Me.DataGridViewRightSection_GroupUsers.TabIndex = 3
            Me.DataGridViewRightSection_GroupUsers.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_GroupUsers.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_AvailableUsers
            '
            Me.DataGridViewLeftSection_AvailableUsers.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableUsers.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableUsers.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableUsers.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableUsers.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableUsers.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableUsers.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableUsers.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableUsers.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableUsers.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableUsers.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableUsers.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableUsers.ItemDescription = "Available User(s)"
            Me.DataGridViewLeftSection_AvailableUsers.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableUsers.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableUsers.Name = "DataGridViewLeftSection_AvailableUsers"
            Me.DataGridViewLeftSection_AvailableUsers.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableUsers.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableUsers.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableUsers.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableUsers.Size = New System.Drawing.Size(371, 399)
            Me.DataGridViewLeftSection_AvailableUsers.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableUsers.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableUsers.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerRightSection_Options
            '
            Me.RibbonBarMergeContainerRightSection_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_Employees)
            Me.RibbonBarMergeContainerRightSection_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerRightSection_Options.Location = New System.Drawing.Point(45, 110)
            Me.RibbonBarMergeContainerRightSection_Options.Name = "RibbonBarMergeContainerRightSection_Options"
            Me.RibbonBarMergeContainerRightSection_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerRightSection_Options.Size = New System.Drawing.Size(524, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerRightSection_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerRightSection_Options.TabIndex = 2
            Me.RibbonBarMergeContainerRightSection_Options.Visible = False
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ExpandAll, Me.ButtonItemView_CollapseAll})
            Me.RibbonBarOptions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(248, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 4
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemView_ExpandAll
            '
            Me.ButtonItemView_ExpandAll.Name = "ButtonItemView_ExpandAll"
            Me.ButtonItemView_ExpandAll.Stretch = True
            Me.ButtonItemView_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_ExpandAll.Text = "Expand All"
            '
            'ButtonItemView_CollapseAll
            '
            Me.ButtonItemView_CollapseAll.BeginGroup = True
            Me.ButtonItemView_CollapseAll.Name = "ButtonItemView_CollapseAll"
            Me.ButtonItemView_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_CollapseAll.Text = "Collapse All"
            '
            'RibbonBarOptions_Employees
            '
            Me.RibbonBarOptions_Employees.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Employees.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Employees.DragDropSupport = True
            Me.RibbonBarOptions_Employees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployees_Terminated})
            Me.RibbonBarOptions_Employees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Employees.Location = New System.Drawing.Point(172, 0)
            Me.RibbonBarOptions_Employees.Name = "RibbonBarOptions_Employees"
            Me.RibbonBarOptions_Employees.SecurityEnabled = True
            Me.RibbonBarOptions_Employees.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employees.TabIndex = 8
            Me.RibbonBarOptions_Employees.Text = "Employees"
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployees_Terminated
            '
            Me.ButtonItemEmployees_Terminated.AutoCheckOnClick = True
            Me.ButtonItemEmployees_Terminated.BeginGroup = True
            Me.ButtonItemEmployees_Terminated.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployees_Terminated.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_Terminated.Name = "ButtonItemEmployees_Terminated"
            Me.ButtonItemEmployees_Terminated.RibbonWordWrap = False
            Me.ButtonItemEmployees_Terminated.SecurityEnabled = True
            Me.ButtonItemEmployees_Terminated.Stretch = True
            Me.ButtonItemEmployees_Terminated.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_Terminated.Text = "Terminated"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(172, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Groups)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(275, 540)
            Me.PanelForm_LeftSection.TabIndex = 12
            '
            'ExpandableSplitterControForm_LeftRight
            '
            Me.ExpandableSplitterControForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControForm_LeftRight.Location = New System.Drawing.Point(275, 0)
            Me.ExpandableSplitterControForm_LeftRight.Name = "ExpandableSplitterControForm_LeftRight"
            Me.ExpandableSplitterControForm_LeftRight.Size = New System.Drawing.Size(6, 540)
            Me.ExpandableSplitterControForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControForm_LeftRight.TabIndex = 13
            Me.ExpandableSplitterControForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxRightSection_Description)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxRightSection_Name)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Description)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Name)
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlRightSection_GroupDetails)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(281, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(740, 540)
            Me.PanelForm_RightSection.TabIndex = 14
            '
            'TextBoxRightSection_Description
            '
            Me.TextBoxRightSection_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Description.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Description.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Description.Location = New System.Drawing.Point(77, 38)
            Me.TextBoxRightSection_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Description.Name = "TextBoxRightSection_Description"
            Me.TextBoxRightSection_Description.SecurityEnabled = True
            Me.TextBoxRightSection_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Description.Size = New System.Drawing.Size(651, 21)
            Me.TextBoxRightSection_Description.StartingFolderName = Nothing
            Me.TextBoxRightSection_Description.TabIndex = 4
            Me.TextBoxRightSection_Description.TabOnEnter = True
            '
            'TextBoxRightSection_Name
            '
            Me.TextBoxRightSection_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Name.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Name.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Name.Location = New System.Drawing.Point(77, 12)
            Me.TextBoxRightSection_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Name.Name = "TextBoxRightSection_Name"
            Me.TextBoxRightSection_Name.SecurityEnabled = True
            Me.TextBoxRightSection_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Name.Size = New System.Drawing.Size(651, 21)
            Me.TextBoxRightSection_Name.StartingFolderName = Nothing
            Me.TextBoxRightSection_Name.TabIndex = 2
            Me.TextBoxRightSection_Name.TabOnEnter = True
            '
            'LabelRightSection_Description
            '
            Me.LabelRightSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Description.Location = New System.Drawing.Point(6, 38)
            Me.LabelRightSection_Description.Name = "LabelRightSection_Description"
            Me.LabelRightSection_Description.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Description.TabIndex = 3
            Me.LabelRightSection_Description.Text = "Description:"
            '
            'LabelRightSection_Name
            '
            Me.LabelRightSection_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Name.Location = New System.Drawing.Point(6, 12)
            Me.LabelRightSection_Name.Name = "LabelRightSection_Name"
            Me.LabelRightSection_Name.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Name.TabIndex = 1
            Me.LabelRightSection_Name.Text = "Name:"
            '
            'TabControlRightSection_GroupDetails
            '
            Me.TabControlRightSection_GroupDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_GroupDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlRightSection_GroupDetails.CanReorderTabs = False
            Me.TabControlRightSection_GroupDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlRightSection_GroupDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlRightSection_GroupDetails.Controls.Add(Me.TabControlPanelGroupSettingsTab_GroupSettings)
            Me.TabControlRightSection_GroupDetails.Controls.Add(Me.TabControlPanelWorkspacesTab_Workspaces)
            Me.TabControlRightSection_GroupDetails.Controls.Add(Me.TabControlPanelUsersTab_Users)
            Me.TabControlRightSection_GroupDetails.Controls.Add(Me.TabControlPanelModuleAccessTab_ModuleAccess)
            Me.TabControlRightSection_GroupDetails.Location = New System.Drawing.Point(6, 64)
            Me.TabControlRightSection_GroupDetails.Name = "TabControlRightSection_GroupDetails"
            Me.TabControlRightSection_GroupDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_GroupDetails.SelectedTabIndex = 0
            Me.TabControlRightSection_GroupDetails.Size = New System.Drawing.Size(722, 464)
            Me.TabControlRightSection_GroupDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_GroupDetails.TabIndex = 12
            Me.TabControlRightSection_GroupDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_GroupDetails.Tabs.Add(Me.TabItemGroupDetails_UsersTab)
            Me.TabControlRightSection_GroupDetails.Tabs.Add(Me.TabItemGroupDetails_ModuleAccessTab)
            Me.TabControlRightSection_GroupDetails.Tabs.Add(Me.TabItemGroupDetails_GroupSettingsTab)
            Me.TabControlRightSection_GroupDetails.Tabs.Add(Me.TabItemGroupDetails_WorkspacesTab)
            '
            'TabControlPanelUsersTab_Users
            '
            Me.TabControlPanelUsersTab_Users.Controls.Add(Me.PanelUsers_RightSection)
            Me.TabControlPanelUsersTab_Users.Controls.Add(Me.ExpandableSplitterControlUsers_LeftRight)
            Me.TabControlPanelUsersTab_Users.Controls.Add(Me.PanelUsers_LeftSection)
            Me.TabControlPanelUsersTab_Users.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelUsersTab_Users.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelUsersTab_Users.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelUsersTab_Users.Name = "TabControlPanelUsersTab_Users"
            Me.TabControlPanelUsersTab_Users.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelUsersTab_Users.Size = New System.Drawing.Size(722, 437)
            Me.TabControlPanelUsersTab_Users.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelUsersTab_Users.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelUsersTab_Users.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelUsersTab_Users.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelUsersTab_Users.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelUsersTab_Users.Style.GradientAngle = 90
            Me.TabControlPanelUsersTab_Users.TabIndex = 1
            Me.TabControlPanelUsersTab_Users.TabItem = Me.TabItemGroupDetails_UsersTab
            '
            'PanelUsers_RightSection
            '
            Me.PanelUsers_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelUsers_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelUsers_RightSection.Controls.Add(Me.DataGridViewRightSection_GroupUsers)
            Me.PanelUsers_RightSection.Controls.Add(Me.ButtonRightSection_AddToGroup)
            Me.PanelUsers_RightSection.Controls.Add(Me.ButtonRightSection_RemoveFromGroup)
            Me.PanelUsers_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUsers_RightSection.Location = New System.Drawing.Point(389, 1)
            Me.PanelUsers_RightSection.Name = "PanelUsers_RightSection"
            Me.PanelUsers_RightSection.Size = New System.Drawing.Size(332, 435)
            Me.PanelUsers_RightSection.TabIndex = 10
            '
            'ExpandableSplitterControlUsers_LeftRight
            '
            Me.ExpandableSplitterControlUsers_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlUsers_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlUsers_LeftRight.ExpandableControl = Me.PanelUsers_LeftSection
            Me.ExpandableSplitterControlUsers_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlUsers_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlUsers_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlUsers_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlUsers_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlUsers_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlUsers_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlUsers_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlUsers_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlUsers_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlUsers_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlUsers_LeftRight.Location = New System.Drawing.Point(383, 1)
            Me.ExpandableSplitterControlUsers_LeftRight.Name = "ExpandableSplitterControlUsers_LeftRight"
            Me.ExpandableSplitterControlUsers_LeftRight.Size = New System.Drawing.Size(6, 435)
            Me.ExpandableSplitterControlUsers_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlUsers_LeftRight.TabIndex = 9
            Me.ExpandableSplitterControlUsers_LeftRight.TabStop = False
            '
            'PanelUsers_LeftSection
            '
            Me.PanelUsers_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelUsers_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelUsers_LeftSection.Controls.Add(Me.CheckBoxLeftSection_ShowOnlyUsersWithNoGroup)
            Me.PanelUsers_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableUsers)
            Me.PanelUsers_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelUsers_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelUsers_LeftSection.Name = "PanelUsers_LeftSection"
            Me.PanelUsers_LeftSection.Size = New System.Drawing.Size(382, 435)
            Me.PanelUsers_LeftSection.TabIndex = 8
            '
            'TabItemGroupDetails_UsersTab
            '
            Me.TabItemGroupDetails_UsersTab.AttachedControl = Me.TabControlPanelUsersTab_Users
            Me.TabItemGroupDetails_UsersTab.Name = "TabItemGroupDetails_UsersTab"
            Me.TabItemGroupDetails_UsersTab.Text = "Users"
            '
            'TabControlPanelModuleAccessTab_ModuleAccess
            '
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_IsApplicationBlocked)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.AdvTreeModuleAccess_Modules)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.LabelModuleAccess_Options)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.LabelModuleAccess_Application)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_IsBlocked)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_CanAdd)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_CanPrint)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_Custom1)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.ComboBoxModuleAccess_Application)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_CanUpdate)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Controls.Add(Me.CheckBoxModuleAccess_Custom2)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Name = "TabControlPanelModuleAccessTab_ModuleAccess"
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Size = New System.Drawing.Size(722, 437)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.GradientAngle = 90
            Me.TabControlPanelModuleAccessTab_ModuleAccess.TabIndex = 3
            Me.TabControlPanelModuleAccessTab_ModuleAccess.TabItem = Me.TabItemGroupDetails_ModuleAccessTab
            '
            'CheckBoxModuleAccess_IsApplicationBlocked
            '
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_IsApplicationBlocked.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_IsApplicationBlocked.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_IsApplicationBlocked.CheckValue = 0
            Me.CheckBoxModuleAccess_IsApplicationBlocked.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_IsApplicationBlocked.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_IsApplicationBlocked.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_IsApplicationBlocked.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_IsApplicationBlocked.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_IsApplicationBlocked.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Location = New System.Drawing.Point(557, 4)
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Name = "CheckBoxModuleAccess_IsApplicationBlocked"
            Me.CheckBoxModuleAccess_IsApplicationBlocked.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_IsApplicationBlocked.SecurityEnabled = True
            Me.CheckBoxModuleAccess_IsApplicationBlocked.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_IsApplicationBlocked.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Size = New System.Drawing.Size(73, 20)
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_IsApplicationBlocked.TabIndex = 16
            Me.CheckBoxModuleAccess_IsApplicationBlocked.TabOnEnter = True
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Text = "Is Blocked"
            '
            'AdvTreeModuleAccess_Modules
            '
            Me.AdvTreeModuleAccess_Modules.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
            Me.AdvTreeModuleAccess_Modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AdvTreeModuleAccess_Modules.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.AdvTreeModuleAccess_Modules.BackgroundStyle.Class = "TreeBorderKey"
            Me.AdvTreeModuleAccess_Modules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.AdvTreeModuleAccess_Modules.DragDropEnabled = False
            Me.AdvTreeModuleAccess_Modules.DragDropNodeCopyEnabled = False
            Me.AdvTreeModuleAccess_Modules.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AdvTreeModuleAccess_Modules.Location = New System.Drawing.Point(4, 30)
            Me.AdvTreeModuleAccess_Modules.MultiSelect = True
            Me.AdvTreeModuleAccess_Modules.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode
            Me.AdvTreeModuleAccess_Modules.Name = "AdvTreeModuleAccess_Modules"
            Me.AdvTreeModuleAccess_Modules.NodesConnector = Me.NodeConnector1
            Me.AdvTreeModuleAccess_Modules.NodeStyle = Me.ElementStyle1
            Me.AdvTreeModuleAccess_Modules.PathSeparator = ";"
            Me.AdvTreeModuleAccess_Modules.Size = New System.Drawing.Size(626, 403)
            Me.AdvTreeModuleAccess_Modules.Styles.Add(Me.ElementStyle1)
            Me.AdvTreeModuleAccess_Modules.TabIndex = 15
            '
            'NodeConnector1
            '
            Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
            '
            'ElementStyle1
            '
            Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ElementStyle1.Name = "ElementStyle1"
            Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
            '
            'LabelModuleAccess_Options
            '
            Me.LabelModuleAccess_Options.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelModuleAccess_Options.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelModuleAccess_Options.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelModuleAccess_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelModuleAccess_Options.Location = New System.Drawing.Point(636, 30)
            Me.LabelModuleAccess_Options.Name = "LabelModuleAccess_Options"
            Me.LabelModuleAccess_Options.Size = New System.Drawing.Size(81, 20)
            Me.LabelModuleAccess_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleAccess_Options.TabIndex = 3
            Me.LabelModuleAccess_Options.Text = "Options"
            '
            'LabelModuleAccess_Application
            '
            Me.LabelModuleAccess_Application.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelModuleAccess_Application.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelModuleAccess_Application.Location = New System.Drawing.Point(4, 4)
            Me.LabelModuleAccess_Application.Name = "LabelModuleAccess_Application"
            Me.LabelModuleAccess_Application.Size = New System.Drawing.Size(59, 20)
            Me.LabelModuleAccess_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleAccess_Application.TabIndex = 0
            Me.LabelModuleAccess_Application.Text = "Application:"
            '
            'CheckBoxModuleAccess_IsBlocked
            '
            Me.CheckBoxModuleAccess_IsBlocked.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_IsBlocked.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_IsBlocked.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_IsBlocked.CheckValue = 0
            Me.CheckBoxModuleAccess_IsBlocked.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_IsBlocked.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_IsBlocked.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_IsBlocked.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlocked.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_IsBlocked.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_IsBlocked.Location = New System.Drawing.Point(636, 56)
            Me.CheckBoxModuleAccess_IsBlocked.Name = "CheckBoxModuleAccess_IsBlocked"
            Me.CheckBoxModuleAccess_IsBlocked.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_IsBlocked.SecurityEnabled = True
            Me.CheckBoxModuleAccess_IsBlocked.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_IsBlocked.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_IsBlocked.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_IsBlocked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_IsBlocked.TabIndex = 4
            Me.CheckBoxModuleAccess_IsBlocked.TabOnEnter = True
            Me.CheckBoxModuleAccess_IsBlocked.Text = "Is Blocked"
            '
            'CheckBoxModuleAccess_CanAdd
            '
            Me.CheckBoxModuleAccess_CanAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_CanAdd.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_CanAdd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_CanAdd.CheckValue = 0
            Me.CheckBoxModuleAccess_CanAdd.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_CanAdd.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_CanAdd.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_CanAdd.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_CanAdd.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanAdd.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_CanAdd.Location = New System.Drawing.Point(636, 134)
            Me.CheckBoxModuleAccess_CanAdd.Name = "CheckBoxModuleAccess_CanAdd"
            Me.CheckBoxModuleAccess_CanAdd.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_CanAdd.SecurityEnabled = True
            Me.CheckBoxModuleAccess_CanAdd.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_CanAdd.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanAdd.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_CanAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_CanAdd.TabIndex = 7
            Me.CheckBoxModuleAccess_CanAdd.TabOnEnter = True
            Me.CheckBoxModuleAccess_CanAdd.Text = "Can Add"
            '
            'CheckBoxModuleAccess_CanPrint
            '
            Me.CheckBoxModuleAccess_CanPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_CanPrint.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_CanPrint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_CanPrint.CheckValue = 0
            Me.CheckBoxModuleAccess_CanPrint.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_CanPrint.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_CanPrint.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_CanPrint.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_CanPrint.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanPrint.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_CanPrint.Location = New System.Drawing.Point(636, 82)
            Me.CheckBoxModuleAccess_CanPrint.Name = "CheckBoxModuleAccess_CanPrint"
            Me.CheckBoxModuleAccess_CanPrint.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_CanPrint.SecurityEnabled = True
            Me.CheckBoxModuleAccess_CanPrint.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_CanPrint.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanPrint.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_CanPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_CanPrint.TabIndex = 5
            Me.CheckBoxModuleAccess_CanPrint.TabOnEnter = True
            Me.CheckBoxModuleAccess_CanPrint.Text = "Can Print"
            '
            'CheckBoxModuleAccess_Custom1
            '
            Me.CheckBoxModuleAccess_Custom1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_Custom1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_Custom1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_Custom1.CheckValue = 0
            Me.CheckBoxModuleAccess_Custom1.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_Custom1.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_Custom1.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_Custom1.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_Custom1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_Custom1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_Custom1.Location = New System.Drawing.Point(636, 160)
            Me.CheckBoxModuleAccess_Custom1.Name = "CheckBoxModuleAccess_Custom1"
            Me.CheckBoxModuleAccess_Custom1.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_Custom1.SecurityEnabled = True
            Me.CheckBoxModuleAccess_Custom1.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_Custom1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_Custom1.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_Custom1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_Custom1.TabIndex = 8
            Me.CheckBoxModuleAccess_Custom1.TabOnEnter = True
            Me.CheckBoxModuleAccess_Custom1.Text = "Custom 1"
            '
            'ComboBoxModuleAccess_Application
            '
            Me.ComboBoxModuleAccess_Application.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxModuleAccess_Application.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxModuleAccess_Application.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxModuleAccess_Application.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxModuleAccess_Application.AutoFindItemInDataSource = False
            Me.ComboBoxModuleAccess_Application.AutoSelectSingleItemDatasource = False
            Me.ComboBoxModuleAccess_Application.BookmarkingEnabled = False
            Me.ComboBoxModuleAccess_Application.ClientCode = ""
            Me.ComboBoxModuleAccess_Application.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Application
            Me.ComboBoxModuleAccess_Application.DisableMouseWheel = False
            Me.ComboBoxModuleAccess_Application.DisplayMember = "Name"
            Me.ComboBoxModuleAccess_Application.DisplayName = ""
            Me.ComboBoxModuleAccess_Application.DivisionCode = ""
            Me.ComboBoxModuleAccess_Application.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxModuleAccess_Application.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxModuleAccess_Application.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxModuleAccess_Application.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxModuleAccess_Application.FocusHighlightEnabled = True
            Me.ComboBoxModuleAccess_Application.ItemHeight = 16
            Me.ComboBoxModuleAccess_Application.Location = New System.Drawing.Point(69, 4)
            Me.ComboBoxModuleAccess_Application.Name = "ComboBoxModuleAccess_Application"
            Me.ComboBoxModuleAccess_Application.ReadOnly = False
            Me.ComboBoxModuleAccess_Application.SecurityEnabled = True
            Me.ComboBoxModuleAccess_Application.Size = New System.Drawing.Size(482, 22)
            Me.ComboBoxModuleAccess_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxModuleAccess_Application.TabIndex = 1
            Me.ComboBoxModuleAccess_Application.TabOnEnter = True
            Me.ComboBoxModuleAccess_Application.ValueMember = "ID"
            Me.ComboBoxModuleAccess_Application.WatermarkText = "Select Application"
            '
            'CheckBoxModuleAccess_CanUpdate
            '
            Me.CheckBoxModuleAccess_CanUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_CanUpdate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_CanUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_CanUpdate.CheckValue = 0
            Me.CheckBoxModuleAccess_CanUpdate.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_CanUpdate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_CanUpdate.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_CanUpdate.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_CanUpdate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanUpdate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_CanUpdate.Location = New System.Drawing.Point(636, 108)
            Me.CheckBoxModuleAccess_CanUpdate.Name = "CheckBoxModuleAccess_CanUpdate"
            Me.CheckBoxModuleAccess_CanUpdate.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_CanUpdate.SecurityEnabled = True
            Me.CheckBoxModuleAccess_CanUpdate.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_CanUpdate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_CanUpdate.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_CanUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_CanUpdate.TabIndex = 6
            Me.CheckBoxModuleAccess_CanUpdate.TabOnEnter = True
            Me.CheckBoxModuleAccess_CanUpdate.Text = "Can Update"
            '
            'CheckBoxModuleAccess_Custom2
            '
            Me.CheckBoxModuleAccess_Custom2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxModuleAccess_Custom2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxModuleAccess_Custom2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxModuleAccess_Custom2.CheckValue = 0
            Me.CheckBoxModuleAccess_Custom2.CheckValueChecked = 1
            Me.CheckBoxModuleAccess_Custom2.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxModuleAccess_Custom2.CheckValueUnchecked = 0
            Me.CheckBoxModuleAccess_Custom2.ChildControls = CType(resources.GetObject("CheckBoxModuleAccess_Custom2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_Custom2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxModuleAccess_Custom2.Location = New System.Drawing.Point(636, 186)
            Me.CheckBoxModuleAccess_Custom2.Name = "CheckBoxModuleAccess_Custom2"
            Me.CheckBoxModuleAccess_Custom2.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_Custom2.SecurityEnabled = True
            Me.CheckBoxModuleAccess_Custom2.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_Custom2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_Custom2.Size = New System.Drawing.Size(81, 20)
            Me.CheckBoxModuleAccess_Custom2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_Custom2.TabIndex = 9
            Me.CheckBoxModuleAccess_Custom2.TabOnEnter = True
            Me.CheckBoxModuleAccess_Custom2.Text = "Custom 2"
            '
            'TabItemGroupDetails_ModuleAccessTab
            '
            Me.TabItemGroupDetails_ModuleAccessTab.AttachedControl = Me.TabControlPanelModuleAccessTab_ModuleAccess
            Me.TabItemGroupDetails_ModuleAccessTab.Name = "TabItemGroupDetails_ModuleAccessTab"
            Me.TabItemGroupDetails_ModuleAccessTab.Text = "Module Access"
            '
            'TabControlPanelGroupSettingsTab_GroupSettings
            '
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.LabelGroupSettings_WorkspaceTemplateSettings)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_CreateWorkspaceTemplate)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_ViewPrivateDocuments)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.LabelGroupSettings_DocumentManagerSettings)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_CanUpload)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_AllowTaskEdit)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_AllowMediaPageEdit)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_ShowUnassignedAssignments)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.LabelGroupSettings_AlertInboxSettings)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_ShowAllAssignments)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.LabelGroupSettings_CalendarSettings)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Controls.Add(Me.CheckBoxGroupSettings_AllowGroupToAddHolidays)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Name = "TabControlPanelGroupSettingsTab_GroupSettings"
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Size = New System.Drawing.Size(722, 437)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGroupSettingsTab_GroupSettings.Style.GradientAngle = 90
            Me.TabControlPanelGroupSettingsTab_GroupSettings.TabIndex = 4
            Me.TabControlPanelGroupSettingsTab_GroupSettings.TabItem = Me.TabItemGroupDetails_GroupSettingsTab
            '
            'LabelGroupSettings_WorkspaceTemplateSettings
            '
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_WorkspaceTemplateSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Location = New System.Drawing.Point(4, 289)
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Name = "LabelGroupSettings_WorkspaceTemplateSettings"
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Size = New System.Drawing.Size(714, 20)
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupSettings_WorkspaceTemplateSettings.TabIndex = 18
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Text = "Workspace Template Settings"
            Me.LabelGroupSettings_WorkspaceTemplateSettings.Visible = False
            '
            'CheckBoxGroupSettings_CreateWorkspaceTemplate
            '
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.CheckValue = 0
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_CreateWorkspaceTemplate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Location = New System.Drawing.Point(4, 315)
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Name = "CheckBoxGroupSettings_CreateWorkspaceTemplate"
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.SecurityEnabled = True
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_CreateWorkspaceTemplate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.TabIndex = 17
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.TabOnEnter = True
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Text = "Create Workspace Template"
            Me.CheckBoxGroupSettings_CreateWorkspaceTemplate.Visible = False
            '
            'CheckBoxGroupSettings_ViewPrivateDocuments
            '
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.CheckValue = 0
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_ViewPrivateDocuments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Location = New System.Drawing.Point(4, 263)
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Name = "CheckBoxGroupSettings_ViewPrivateDocuments"
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.SecurityEnabled = True
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_ViewPrivateDocuments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.TabIndex = 16
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.TabOnEnter = True
            Me.CheckBoxGroupSettings_ViewPrivateDocuments.Text = "View Private Documents"
            '
            'LabelGroupSettings_DocumentManagerSettings
            '
            Me.LabelGroupSettings_DocumentManagerSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupSettings_DocumentManagerSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_DocumentManagerSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupSettings_DocumentManagerSettings.Location = New System.Drawing.Point(4, 211)
            Me.LabelGroupSettings_DocumentManagerSettings.Name = "LabelGroupSettings_DocumentManagerSettings"
            Me.LabelGroupSettings_DocumentManagerSettings.Size = New System.Drawing.Size(714, 20)
            Me.LabelGroupSettings_DocumentManagerSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupSettings_DocumentManagerSettings.TabIndex = 15
            Me.LabelGroupSettings_DocumentManagerSettings.Text = "Document Manager Settings"
            '
            'CheckBoxGroupSettings_CanUpload
            '
            Me.CheckBoxGroupSettings_CanUpload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_CanUpload.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_CanUpload.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_CanUpload.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_CanUpload.CheckValue = 0
            Me.CheckBoxGroupSettings_CanUpload.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_CanUpload.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_CanUpload.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_CanUpload.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_CanUpload.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_CanUpload.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_CanUpload.Location = New System.Drawing.Point(4, 237)
            Me.CheckBoxGroupSettings_CanUpload.Name = "CheckBoxGroupSettings_CanUpload"
            Me.CheckBoxGroupSettings_CanUpload.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_CanUpload.SecurityEnabled = True
            Me.CheckBoxGroupSettings_CanUpload.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_CanUpload.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_CanUpload.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_CanUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_CanUpload.TabIndex = 14
            Me.CheckBoxGroupSettings_CanUpload.TabOnEnter = True
            Me.CheckBoxGroupSettings_CanUpload.Text = "Can Upload"
            '
            'CheckBoxGroupSettings_AllowTaskEdit
            '
            Me.CheckBoxGroupSettings_AllowTaskEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_AllowTaskEdit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_AllowTaskEdit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_AllowTaskEdit.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_AllowTaskEdit.CheckValue = 0
            Me.CheckBoxGroupSettings_AllowTaskEdit.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_AllowTaskEdit.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_AllowTaskEdit.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_AllowTaskEdit.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowTaskEdit.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowTaskEdit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_AllowTaskEdit.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxGroupSettings_AllowTaskEdit.Name = "CheckBoxGroupSettings_AllowTaskEdit"
            Me.CheckBoxGroupSettings_AllowTaskEdit.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_AllowTaskEdit.SecurityEnabled = True
            Me.CheckBoxGroupSettings_AllowTaskEdit.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowTaskEdit.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowTaskEdit.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_AllowTaskEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_AllowTaskEdit.TabIndex = 13
            Me.CheckBoxGroupSettings_AllowTaskEdit.TabOnEnter = True
            Me.CheckBoxGroupSettings_AllowTaskEdit.Text = "Allow Task Edit"
            '
            'CheckBoxGroupSettings_AllowMediaPageEdit
            '
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.CheckValue = 0
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.ChildControls = Nothing
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Location = New System.Drawing.Point(4, 29)
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Name = "CheckBoxGroupSettings_AllowMediaPageEdit"
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.SecurityEnabled = True
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.SiblingControls = Nothing
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.TabIndex = 13
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.TabOnEnter = True
            Me.CheckBoxGroupSettings_AllowMediaPageEdit.Text = "Allow Media Page Edit"
            '
            'CheckBoxGroupSettings_ShowUnassignedAssignments
            '
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.CheckValue = 0
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_ShowUnassignedAssignments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Location = New System.Drawing.Point(4, 185)
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Name = "CheckBoxGroupSettings_ShowUnassignedAssignments"
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.SecurityEnabled = True
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_ShowUnassignedAssignments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.TabIndex = 12
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.TabOnEnter = True
            Me.CheckBoxGroupSettings_ShowUnassignedAssignments.Text = "Show Unassigned Assignments"
            '
            'LabelGroupSettings_AlertInboxSettings
            '
            Me.LabelGroupSettings_AlertInboxSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupSettings_AlertInboxSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_AlertInboxSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupSettings_AlertInboxSettings.Location = New System.Drawing.Point(4, 133)
            Me.LabelGroupSettings_AlertInboxSettings.Name = "LabelGroupSettings_AlertInboxSettings"
            Me.LabelGroupSettings_AlertInboxSettings.Size = New System.Drawing.Size(714, 20)
            Me.LabelGroupSettings_AlertInboxSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupSettings_AlertInboxSettings.TabIndex = 11
            Me.LabelGroupSettings_AlertInboxSettings.Text = "Alert Inbox Settings"
            '
            'CheckBoxGroupSettings_ShowAllAssignments
            '
            Me.CheckBoxGroupSettings_ShowAllAssignments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_ShowAllAssignments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_ShowAllAssignments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_ShowAllAssignments.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_ShowAllAssignments.CheckValue = 0
            Me.CheckBoxGroupSettings_ShowAllAssignments.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_ShowAllAssignments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_ShowAllAssignments.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_ShowAllAssignments.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_ShowAllAssignments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ShowAllAssignments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_ShowAllAssignments.Location = New System.Drawing.Point(4, 159)
            Me.CheckBoxGroupSettings_ShowAllAssignments.Name = "CheckBoxGroupSettings_ShowAllAssignments"
            Me.CheckBoxGroupSettings_ShowAllAssignments.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_ShowAllAssignments.SecurityEnabled = True
            Me.CheckBoxGroupSettings_ShowAllAssignments.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_ShowAllAssignments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_ShowAllAssignments.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_ShowAllAssignments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_ShowAllAssignments.TabIndex = 10
            Me.CheckBoxGroupSettings_ShowAllAssignments.TabOnEnter = True
            Me.CheckBoxGroupSettings_ShowAllAssignments.Text = "Show All Assignments"
            '
            'CheckBoxGroupSettings_AllowGroupToViewOtherEmployees
            '
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.CheckValue = 0
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Location = New System.Drawing.Point(4, 107)
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Name = "CheckBoxGroupSettings_AllowGroupToViewOtherEmployees"
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.SecurityEnabled = True
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.TabIndex = 9
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.TabOnEnter = True
            Me.CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Text = "Allow User to View Other Employees"
            '
            'LabelGroupSettings_CalendarSettings
            '
            Me.LabelGroupSettings_CalendarSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupSettings_CalendarSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupSettings_CalendarSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupSettings_CalendarSettings.Location = New System.Drawing.Point(4, 55)
            Me.LabelGroupSettings_CalendarSettings.Name = "LabelGroupSettings_CalendarSettings"
            Me.LabelGroupSettings_CalendarSettings.Size = New System.Drawing.Size(714, 20)
            Me.LabelGroupSettings_CalendarSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupSettings_CalendarSettings.TabIndex = 8
            Me.LabelGroupSettings_CalendarSettings.Text = "Calendar Settings"
            '
            'CheckBoxGroupSettings_AllowGroupToAddHolidays
            '
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.BackgroundStyle.WordWrap = True
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.CheckValue = 0
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.CheckValueChecked = 1
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.CheckValueUnchecked = 0
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.ChildControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowGroupToAddHolidays.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Location = New System.Drawing.Point(4, 81)
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Name = "CheckBoxGroupSettings_AllowGroupToAddHolidays"
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.OldestSibling = Nothing
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.SecurityEnabled = True
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.SiblingControls = CType(resources.GetObject("CheckBoxGroupSettings_AllowGroupToAddHolidays.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Size = New System.Drawing.Size(714, 20)
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.TabIndex = 7
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.TabOnEnter = True
            Me.CheckBoxGroupSettings_AllowGroupToAddHolidays.Text = "Allow User to Add Holidays"
            '
            'TabItemGroupDetails_GroupSettingsTab
            '
            Me.TabItemGroupDetails_GroupSettingsTab.AttachedControl = Me.TabControlPanelGroupSettingsTab_GroupSettings
            Me.TabItemGroupDetails_GroupSettingsTab.Name = "TabItemGroupDetails_GroupSettingsTab"
            Me.TabItemGroupDetails_GroupSettingsTab.Text = "Group Settings"
            '
            'TabControlPanelWorkspacesTab_Workspaces
            '
            Me.TabControlPanelWorkspacesTab_Workspaces.Controls.Add(Me.ButtonWorkspaces_Apply)
            Me.TabControlPanelWorkspacesTab_Workspaces.Controls.Add(Me.LabelWorkspaces_WorkspaceTemplates)
            Me.TabControlPanelWorkspacesTab_Workspaces.Controls.Add(Me.ComboBoxWorkspaces_WorkspaceTemplates)
            Me.TabControlPanelWorkspacesTab_Workspaces.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelWorkspacesTab_Workspaces.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelWorkspacesTab_Workspaces.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelWorkspacesTab_Workspaces.Name = "TabControlPanelWorkspacesTab_Workspaces"
            Me.TabControlPanelWorkspacesTab_Workspaces.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelWorkspacesTab_Workspaces.Size = New System.Drawing.Size(722, 437)
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.GradientAngle = 90
            Me.TabControlPanelWorkspacesTab_Workspaces.TabIndex = 5
            Me.TabControlPanelWorkspacesTab_Workspaces.TabItem = Me.TabItemGroupDetails_WorkspacesTab
            '
            'ButtonWorkspaces_Apply
            '
            Me.ButtonWorkspaces_Apply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonWorkspaces_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonWorkspaces_Apply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonWorkspaces_Apply.Location = New System.Drawing.Point(643, 4)
            Me.ButtonWorkspaces_Apply.Name = "ButtonWorkspaces_Apply"
            Me.ButtonWorkspaces_Apply.SecurityEnabled = True
            Me.ButtonWorkspaces_Apply.Size = New System.Drawing.Size(75, 20)
            Me.ButtonWorkspaces_Apply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonWorkspaces_Apply.TabIndex = 2
            Me.ButtonWorkspaces_Apply.Text = "Apply"
            '
            'LabelWorkspaces_WorkspaceTemplates
            '
            Me.LabelWorkspaces_WorkspaceTemplates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelWorkspaces_WorkspaceTemplates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelWorkspaces_WorkspaceTemplates.Location = New System.Drawing.Point(4, 4)
            Me.LabelWorkspaces_WorkspaceTemplates.Name = "LabelWorkspaces_WorkspaceTemplates"
            Me.LabelWorkspaces_WorkspaceTemplates.Size = New System.Drawing.Size(120, 20)
            Me.LabelWorkspaces_WorkspaceTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelWorkspaces_WorkspaceTemplates.TabIndex = 1
            Me.LabelWorkspaces_WorkspaceTemplates.Text = "Workspace Templates:"
            '
            'ComboBoxWorkspaces_WorkspaceTemplates
            '
            Me.ComboBoxWorkspaces_WorkspaceTemplates.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxWorkspaces_WorkspaceTemplates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxWorkspaces_WorkspaceTemplates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxWorkspaces_WorkspaceTemplates.AutoFindItemInDataSource = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.AutoSelectSingleItemDatasource = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.BookmarkingEnabled = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ClientCode = ""
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.WorkspaceTemplate
            Me.ComboBoxWorkspaces_WorkspaceTemplates.DisableMouseWheel = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.DisplayMember = "Name"
            Me.ComboBoxWorkspaces_WorkspaceTemplates.DisplayName = ""
            Me.ComboBoxWorkspaces_WorkspaceTemplates.DivisionCode = ""
            Me.ComboBoxWorkspaces_WorkspaceTemplates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxWorkspaces_WorkspaceTemplates.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxWorkspaces_WorkspaceTemplates.FocusHighlightEnabled = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.FormattingEnabled = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ItemHeight = 16
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Location = New System.Drawing.Point(130, 4)
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Name = "ComboBoxWorkspaces_WorkspaceTemplates"
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ReadOnly = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.SecurityEnabled = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Size = New System.Drawing.Size(507, 22)
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxWorkspaces_WorkspaceTemplates.TabIndex = 0
            Me.ComboBoxWorkspaces_WorkspaceTemplates.TabOnEnter = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ValueMember = "ID"
            Me.ComboBoxWorkspaces_WorkspaceTemplates.WatermarkText = "Select Workspace Template"
            '
            'TabItemGroupDetails_WorkspacesTab
            '
            Me.TabItemGroupDetails_WorkspacesTab.AttachedControl = Me.TabControlPanelWorkspacesTab_Workspaces
            Me.TabItemGroupDetails_WorkspacesTab.Name = "TabItemGroupDetails_WorkspacesTab"
            Me.TabItemGroupDetails_WorkspacesTab.Text = "Workspaces"
            Me.TabItemGroupDetails_WorkspacesTab.Visible = False
            '
            'GroupSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1021, 540)
            Me.Controls.Add(Me.RibbonBarMergeContainerRightSection_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GroupSetupForm"
            Me.Text = "Group Setup"
            Me.RibbonBarMergeContainerRightSection_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlRightSection_GroupDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_GroupDetails.ResumeLayout(False)
            Me.TabControlPanelUsersTab_Users.ResumeLayout(False)
            CType(Me.PanelUsers_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelUsers_RightSection.ResumeLayout(False)
            CType(Me.PanelUsers_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelUsers_LeftSection.ResumeLayout(False)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.ResumeLayout(False)
            CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelGroupSettingsTab_GroupSettings.ResumeLayout(False)
            Me.TabControlPanelWorkspacesTab_Workspaces.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_Groups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveFromGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddToGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_GroupUsers As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewLeftSection_AvailableUsers As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerRightSection_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CheckBoxLeftSection_ShowOnlyUsersWithNoGroup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlRightSection_GroupDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelUsersTab_Users As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemGroupDetails_UsersTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelModuleAccessTab_ModuleAccess As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelModuleAccess_Options As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelModuleAccess_Application As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxModuleAccess_IsBlocked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_CanAdd As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_CanPrint As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_Custom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxModuleAccess_Application As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxModuleAccess_CanUpdate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_Custom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemGroupDetails_ModuleAccessTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterControlUsers_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelUsers_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelUsers_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemView_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelGroupSettingsTab_GroupSettings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemGroupDetails_GroupSettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxGroupSettings_AllowGroupToViewOtherEmployees As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGroupSettings_CalendarSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGroupSettings_AllowGroupToAddHolidays As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGroupSettings_ShowUnassignedAssignments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGroupSettings_AlertInboxSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGroupSettings_ShowAllAssignments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGroupSettings_AllowTaskEdit As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGroupSettings_AllowMediaPageEdit As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGroupSettings_ViewPrivateDocuments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGroupSettings_DocumentManagerSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGroupSettings_CanUpload As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelWorkspacesTab_Workspaces As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonWorkspaces_Apply As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelWorkspaces_WorkspaceTemplates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxWorkspaces_WorkspaceTemplates As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabItemGroupDetails_WorkspacesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelGroupSettings_WorkspaceTemplateSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGroupSettings_CreateWorkspaceTemplate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents AdvTreeModuleAccess_Modules As DevComponents.AdvTree.AdvTree
        Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CheckBoxModuleAccess_IsApplicationBlocked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxRightSection_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRightSection_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRightSection_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Employees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployees_Terminated As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace