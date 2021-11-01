Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UserSetupForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSetupForm))
            Me.DataGridViewLeftSection_Users = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonRightSection_RemoveFromUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddToUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_UserGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_AvailableGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_TimesheetFunction = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTimesheetFunctionCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CDP = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCDP_CDPCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCDPCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCDPCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Employee = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployee_EmployeeCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOffice_OfficeCopy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOfficeCopy_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOfficeCopy_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_UserSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemUserSettings_CheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUserSettings_UncheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ExpandAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_CollapseAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_UserLicenseInfo = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerUserLicenseInfo_Left = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_PowerUsers = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_StandardUsers = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_MediaToolUsers = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerUserLicenseInfo_Spacer = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_Spacer1 = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_Spacer2 = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_Spacer3 = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerUserLicenseInfo_Middle = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_PowerUsersTotal = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_StandardUsersTotal = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerUserLicenseInfo_Right = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Employees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployees_Terminated = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ChangePassword = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ComboBoxModuleAccess_Application = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelModuleAccess_Application = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxModuleAccess_IsBlocked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_CanPrint = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_CanUpdate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_CanAdd = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_Custom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxModuleAccess_Custom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelModuleAccess_Options = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlRightSection_UserDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelTimesheetFunctionLimits_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits = New AdvantageFramework.WinForm.Presentation.Controls.EmployeeTimesheetFunctionLimitsControl()
            Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGroupsTab_Groups = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelGroups_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlGroups_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelGroups_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabItemUserDetails_GroupsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelUserSettingsTab_UserSettings = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_IsMediaToolsUser = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_IsCRMUser = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_CheckForUserAccess = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_AllowProfileUpdate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxUserSettings_IsWebvantageUserOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemUserDetails_UserSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelWorkspacesTab_Workspaces = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonWorkspaces_Apply = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelWorkspaces_WorkspaceTemplates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxWorkspaces_WorkspaceTemplates = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemUserDetails_WorkspacesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits = New AdvantageFramework.WinForm.Presentation.Controls.EmployeeOfficeLimitControl()
            Me.TabItemUserDetails_EmployeeOfficeLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeesTab_Employees = New DevComponents.DotNetBar.TabControlPanel()
            Me.UserEmployeeLimitEmployees_EmployeeLimits = New AdvantageFramework.WinForm.Presentation.Controls.UserEmployeeLimitControl()
            Me.TabItemUserDetails_EmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct = New DevComponents.DotNetBar.TabControlPanel()
            Me.UserCDPLimitClientDivisionProduct_CDPLimits = New AdvantageFramework.WinForm.Presentation.Controls.UserCDPLimitControl()
            Me.TabItemUserDetails_ClientDivisionProductTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelUserDetails_ReportAccess = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewReportAccess_Reports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemUserDetails_ReportAccessTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelModuleAccessTab_ModuleAccess = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxModuleAccess_IsApplicationBlocked = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.AdvTreeModuleAccess_Modules = New DevComponents.AdvTree.AdvTree()
            Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
            Me.TabItemUserDetails_ModuleAccessTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxRightSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightSection_CheckForUserAccess = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxRightSection_Employee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelRightSection_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ItemContainerUserLicenseInfo_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerUserLicenseInfo_Bottom = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerUserLicenseInfo_BottomSpacer = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemUserLicenseInfo_Spacer = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlRightSection_UserDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_UserDetails.SuspendLayout()
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.SuspendLayout()
            CType(Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelGroupsTab_Groups.SuspendLayout()
            CType(Me.PanelGroups_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelGroups_RightSection.SuspendLayout()
            CType(Me.PanelGroups_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelGroups_LeftSection.SuspendLayout()
            Me.TabControlPanelUserSettingsTab_UserSettings.SuspendLayout()
            Me.TabControlPanelWorkspacesTab_Workspaces.SuspendLayout()
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.SuspendLayout()
            Me.TabControlPanelEmployeesTab_Employees.SuspendLayout()
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.SuspendLayout()
            Me.TabControlPanelUserDetails_ReportAccess.SuspendLayout()
            Me.TabControlPanelModuleAccessTab_ModuleAccess.SuspendLayout()
            CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_Users
            '
            Me.DataGridViewLeftSection_Users.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Users.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Users.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Users.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Users.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Users.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Users.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Users.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Users.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Users.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Users.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Users.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Users.ItemDescription = ""
            Me.DataGridViewLeftSection_Users.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Users.MultiSelect = True
            Me.DataGridViewLeftSection_Users.Name = "DataGridViewLeftSection_Users"
            Me.DataGridViewLeftSection_Users.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Users.RunStandardValidation = True
            Me.DataGridViewLeftSection_Users.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Users.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Users.Size = New System.Drawing.Size(183, 547)
            Me.DataGridViewLeftSection_Users.TabIndex = 0
            Me.DataGridViewLeftSection_Users.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Users.ViewCaptionHeight = -1
            '
            'ButtonRightSection_RemoveFromUser
            '
            Me.ButtonRightSection_RemoveFromUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveFromUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveFromUser.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSection_RemoveFromUser.Name = "ButtonRightSection_RemoveFromUser"
            Me.ButtonRightSection_RemoveFromUser.SecurityEnabled = True
            Me.ButtonRightSection_RemoveFromUser.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveFromUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveFromUser.TabIndex = 2
            Me.ButtonRightSection_RemoveFromUser.Text = "<"
            '
            'ButtonRightSection_AddToUser
            '
            Me.ButtonRightSection_AddToUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddToUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddToUser.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSection_AddToUser.Name = "ButtonRightSection_AddToUser"
            Me.ButtonRightSection_AddToUser.SecurityEnabled = True
            Me.ButtonRightSection_AddToUser.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddToUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddToUser.TabIndex = 1
            Me.ButtonRightSection_AddToUser.Text = ">"
            '
            'DataGridViewRightSection_UserGroups
            '
            Me.DataGridViewRightSection_UserGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_UserGroups.AllowDragAndDrop = False
            Me.DataGridViewRightSection_UserGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_UserGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_UserGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_UserGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_UserGroups.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_UserGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_UserGroups.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_UserGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_UserGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_UserGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_UserGroups.ItemDescription = "User Group(s)"
            Me.DataGridViewRightSection_UserGroups.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_UserGroups.MultiSelect = True
            Me.DataGridViewRightSection_UserGroups.Name = "DataGridViewRightSection_UserGroups"
            Me.DataGridViewRightSection_UserGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_UserGroups.RunStandardValidation = True
            Me.DataGridViewRightSection_UserGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_UserGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_UserGroups.Size = New System.Drawing.Size(368, 454)
            Me.DataGridViewRightSection_UserGroups.TabIndex = 3
            Me.DataGridViewRightSection_UserGroups.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_UserGroups.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_AvailableGroups
            '
            Me.DataGridViewLeftSection_AvailableGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableGroups.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableGroups.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableGroups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableGroups.ItemDescription = "Available Groups(s)"
            Me.DataGridViewLeftSection_AvailableGroups.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableGroups.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableGroups.Name = "DataGridViewLeftSection_AvailableGroups"
            Me.DataGridViewLeftSection_AvailableGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableGroups.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableGroups.Size = New System.Drawing.Size(329, 454)
            Me.DataGridViewLeftSection_AvailableGroups.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableGroups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableGroups.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TimesheetFunction)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CDP)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Employee)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Office)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_UserSettings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_UserLicenseInfo)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Employees)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(29, 431)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(966, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_TimesheetFunction
            '
            Me.RibbonBarOptions_TimesheetFunction.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TimesheetFunction.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TimesheetFunction.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TimesheetFunction.DragDropSupport = True
            Me.RibbonBarOptions_TimesheetFunction.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_TimesheetFunction.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy})
            Me.RibbonBarOptions_TimesheetFunction.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TimesheetFunction.Location = New System.Drawing.Point(893, 0)
            Me.RibbonBarOptions_TimesheetFunction.MinimumSize = New System.Drawing.Size(70, 0)
            Me.RibbonBarOptions_TimesheetFunction.Name = "RibbonBarOptions_TimesheetFunction"
            Me.RibbonBarOptions_TimesheetFunction.SecurityEnabled = True
            Me.RibbonBarOptions_TimesheetFunction.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_TimesheetFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TimesheetFunction.TabIndex = 14
            Me.RibbonBarOptions_TimesheetFunction.Text = "TS Function"
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TimesheetFunction.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TimesheetFunction.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTimesheetFunction_TimesheetFunctionCopy
            '
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.AutoExpandOnClick = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.BeginGroup = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.Name = "ButtonItemTimesheetFunction_TimesheetFunctionCopy"
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.RibbonWordWrap = False
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SecurityEnabled = True
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTimesheetFunctionCopy_CopyFrom, Me.ButtonItemTimesheetFunctionCopy_CopyTo})
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.SubItemsExpandWidth = 14
            Me.ButtonItemTimesheetFunction_TimesheetFunctionCopy.Text = "Copy"
            '
            'ButtonItemTimesheetFunctionCopy_CopyFrom
            '
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.Name = "ButtonItemTimesheetFunctionCopy_CopyFrom"
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemTimesheetFunctionCopy_CopyFrom.Text = "Copy From Employee"
            '
            'ButtonItemTimesheetFunctionCopy_CopyTo
            '
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.Name = "ButtonItemTimesheetFunctionCopy_CopyTo"
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemTimesheetFunctionCopy_CopyTo.Text = "Copy To Employee"
            '
            'RibbonBarOptions_CDP
            '
            Me.RibbonBarOptions_CDP.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CDP.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CDP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CDP.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CDP.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CDP.DragDropSupport = True
            Me.RibbonBarOptions_CDP.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_CDP.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCDP_CDPCopy})
            Me.RibbonBarOptions_CDP.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CDP.Location = New System.Drawing.Point(828, 0)
            Me.RibbonBarOptions_CDP.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_CDP.Name = "RibbonBarOptions_CDP"
            Me.RibbonBarOptions_CDP.SecurityEnabled = True
            Me.RibbonBarOptions_CDP.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_CDP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CDP.TabIndex = 13
            Me.RibbonBarOptions_CDP.Text = "C/D/P"
            '
            '
            '
            Me.RibbonBarOptions_CDP.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CDP.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CDP.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemCDP_CDPCopy
            '
            Me.ButtonItemCDP_CDPCopy.AutoExpandOnClick = True
            Me.ButtonItemCDP_CDPCopy.BeginGroup = True
            Me.ButtonItemCDP_CDPCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCDP_CDPCopy.Name = "ButtonItemCDP_CDPCopy"
            Me.ButtonItemCDP_CDPCopy.RibbonWordWrap = False
            Me.ButtonItemCDP_CDPCopy.SecurityEnabled = True
            Me.ButtonItemCDP_CDPCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCDPCopy_CopyFrom, Me.ButtonItemCDPCopy_CopyTo})
            Me.ButtonItemCDP_CDPCopy.SubItemsExpandWidth = 14
            Me.ButtonItemCDP_CDPCopy.Text = "Copy"
            '
            'ButtonItemCDPCopy_CopyFrom
            '
            Me.ButtonItemCDPCopy_CopyFrom.Name = "ButtonItemCDPCopy_CopyFrom"
            Me.ButtonItemCDPCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemCDPCopy_CopyFrom.Text = "Copy From User"
            '
            'ButtonItemCDPCopy_CopyTo
            '
            Me.ButtonItemCDPCopy_CopyTo.Name = "ButtonItemCDPCopy_CopyTo"
            Me.ButtonItemCDPCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemCDPCopy_CopyTo.Text = "Copy To User"
            '
            'RibbonBarOptions_Employee
            '
            Me.RibbonBarOptions_Employee.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Employee.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employee.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Employee.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Employee.DragDropSupport = True
            Me.RibbonBarOptions_Employee.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Employee.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployee_EmployeeCopy})
            Me.RibbonBarOptions_Employee.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Employee.Location = New System.Drawing.Point(763, 0)
            Me.RibbonBarOptions_Employee.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Employee.Name = "RibbonBarOptions_Employee"
            Me.RibbonBarOptions_Employee.SecurityEnabled = True
            Me.RibbonBarOptions_Employee.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employee.TabIndex = 12
            Me.RibbonBarOptions_Employee.Text = "Employee"
            '
            '
            '
            Me.RibbonBarOptions_Employee.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employee.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employee.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployee_EmployeeCopy
            '
            Me.ButtonItemEmployee_EmployeeCopy.AutoExpandOnClick = True
            Me.ButtonItemEmployee_EmployeeCopy.BeginGroup = True
            Me.ButtonItemEmployee_EmployeeCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployee_EmployeeCopy.Name = "ButtonItemEmployee_EmployeeCopy"
            Me.ButtonItemEmployee_EmployeeCopy.RibbonWordWrap = False
            Me.ButtonItemEmployee_EmployeeCopy.SecurityEnabled = True
            Me.ButtonItemEmployee_EmployeeCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployeeCopy_CopyFrom, Me.ButtonItemEmployeeCopy_CopyTo})
            Me.ButtonItemEmployee_EmployeeCopy.SubItemsExpandWidth = 14
            Me.ButtonItemEmployee_EmployeeCopy.Text = "Copy"
            '
            'ButtonItemEmployeeCopy_CopyFrom
            '
            Me.ButtonItemEmployeeCopy_CopyFrom.Name = "ButtonItemEmployeeCopy_CopyFrom"
            Me.ButtonItemEmployeeCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemEmployeeCopy_CopyFrom.Text = "Copy From User"
            '
            'ButtonItemEmployeeCopy_CopyTo
            '
            Me.ButtonItemEmployeeCopy_CopyTo.Name = "ButtonItemEmployeeCopy_CopyTo"
            Me.ButtonItemEmployeeCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemEmployeeCopy_CopyTo.Text = "Copy To User"
            '
            'RibbonBarOptions_Office
            '
            Me.RibbonBarOptions_Office.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Office.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Office.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Office.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Office.DragDropSupport = True
            Me.RibbonBarOptions_Office.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Office.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOffice_OfficeCopy})
            Me.RibbonBarOptions_Office.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Office.Location = New System.Drawing.Point(698, 0)
            Me.RibbonBarOptions_Office.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Office.Name = "RibbonBarOptions_Office"
            Me.RibbonBarOptions_Office.SecurityEnabled = True
            Me.RibbonBarOptions_Office.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Office.TabIndex = 11
            Me.RibbonBarOptions_Office.Text = "Office"
            '
            '
            '
            Me.RibbonBarOptions_Office.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Office.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Office.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOffice_OfficeCopy
            '
            Me.ButtonItemOffice_OfficeCopy.AutoExpandOnClick = True
            Me.ButtonItemOffice_OfficeCopy.BeginGroup = True
            Me.ButtonItemOffice_OfficeCopy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOffice_OfficeCopy.Name = "ButtonItemOffice_OfficeCopy"
            Me.ButtonItemOffice_OfficeCopy.RibbonWordWrap = False
            Me.ButtonItemOffice_OfficeCopy.SecurityEnabled = True
            Me.ButtonItemOffice_OfficeCopy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOfficeCopy_CopyFrom, Me.ButtonItemOfficeCopy_CopyTo})
            Me.ButtonItemOffice_OfficeCopy.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_OfficeCopy.Text = "Copy"
            '
            'ButtonItemOfficeCopy_CopyFrom
            '
            Me.ButtonItemOfficeCopy_CopyFrom.Name = "ButtonItemOfficeCopy_CopyFrom"
            Me.ButtonItemOfficeCopy_CopyFrom.SecurityEnabled = True
            Me.ButtonItemOfficeCopy_CopyFrom.Text = "Copy From Employee"
            '
            'ButtonItemOfficeCopy_CopyTo
            '
            Me.ButtonItemOfficeCopy_CopyTo.Name = "ButtonItemOfficeCopy_CopyTo"
            Me.ButtonItemOfficeCopy_CopyTo.SecurityEnabled = True
            Me.ButtonItemOfficeCopy_CopyTo.Text = "Copy To Employee"
            '
            'RibbonBarOptions_UserSettings
            '
            Me.RibbonBarOptions_UserSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_UserSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UserSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_UserSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_UserSettings.DragDropSupport = True
            Me.RibbonBarOptions_UserSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUserSettings_CheckAll, Me.ButtonItemUserSettings_UncheckAll})
            Me.RibbonBarOptions_UserSettings.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_UserSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_UserSettings.Location = New System.Drawing.Point(622, 0)
            Me.RibbonBarOptions_UserSettings.Name = "RibbonBarOptions_UserSettings"
            Me.RibbonBarOptions_UserSettings.SecurityEnabled = True
            Me.RibbonBarOptions_UserSettings.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_UserSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_UserSettings.TabIndex = 5
            Me.RibbonBarOptions_UserSettings.Text = "User Settings"
            '
            '
            '
            Me.RibbonBarOptions_UserSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UserSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemUserSettings_CheckAll
            '
            Me.ButtonItemUserSettings_CheckAll.Name = "ButtonItemUserSettings_CheckAll"
            Me.ButtonItemUserSettings_CheckAll.SecurityEnabled = True
            Me.ButtonItemUserSettings_CheckAll.Stretch = True
            Me.ButtonItemUserSettings_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemUserSettings_CheckAll.Text = "Check All"
            '
            'ButtonItemUserSettings_UncheckAll
            '
            Me.ButtonItemUserSettings_UncheckAll.BeginGroup = True
            Me.ButtonItemUserSettings_UncheckAll.Name = "ButtonItemUserSettings_UncheckAll"
            Me.ButtonItemUserSettings_UncheckAll.SecurityEnabled = True
            Me.ButtonItemUserSettings_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemUserSettings_UncheckAll.Text = "Uncheck All"
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
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(550, 0)
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
            Me.ButtonItemView_ExpandAll.SecurityEnabled = True
            Me.ButtonItemView_ExpandAll.Stretch = True
            Me.ButtonItemView_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_ExpandAll.Text = "Expand All"
            '
            'ButtonItemView_CollapseAll
            '
            Me.ButtonItemView_CollapseAll.BeginGroup = True
            Me.ButtonItemView_CollapseAll.Name = "ButtonItemView_CollapseAll"
            Me.ButtonItemView_CollapseAll.SecurityEnabled = True
            Me.ButtonItemView_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_CollapseAll.Text = "Collapse All"
            '
            'RibbonBarOptions_UserLicenseInfo
            '
            Me.RibbonBarOptions_UserLicenseInfo.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_UserLicenseInfo.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserLicenseInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_UserLicenseInfo.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_UserLicenseInfo.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_UserLicenseInfo.DragDropSupport = True
            Me.RibbonBarOptions_UserLicenseInfo.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerUserLicenseInfo_Top, Me.ItemContainerUserLicenseInfo_BottomSpacer, Me.ItemContainerUserLicenseInfo_Bottom})
            Me.RibbonBarOptions_UserLicenseInfo.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_UserLicenseInfo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_UserLicenseInfo.Location = New System.Drawing.Point(278, 0)
            Me.RibbonBarOptions_UserLicenseInfo.Name = "RibbonBarOptions_UserLicenseInfo"
            Me.RibbonBarOptions_UserLicenseInfo.SecurityEnabled = True
            Me.RibbonBarOptions_UserLicenseInfo.Size = New System.Drawing.Size(272, 98)
            Me.RibbonBarOptions_UserLicenseInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_UserLicenseInfo.TabIndex = 15
            Me.RibbonBarOptions_UserLicenseInfo.Text = "User License Info"
            '
            '
            '
            Me.RibbonBarOptions_UserLicenseInfo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_UserLicenseInfo.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerUserLicenseInfo_Left
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Left.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Left.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserLicenseInfo_Left.Name = "ItemContainerUserLicenseInfo_Left"
            Me.ItemContainerUserLicenseInfo_Left.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_PowerUsers, Me.LabelItemUserLicenseInfo_StandardUsers, Me.LabelItemUserLicenseInfo_MediaToolUsers})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Left.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Left.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_PowerUsers
            '
            Me.LabelItemUserLicenseInfo_PowerUsers.BeginGroup = True
            Me.LabelItemUserLicenseInfo_PowerUsers.Name = "LabelItemUserLicenseInfo_PowerUsers"
            Me.LabelItemUserLicenseInfo_PowerUsers.Stretch = True
            Me.LabelItemUserLicenseInfo_PowerUsers.Text = "Power Users"
            Me.LabelItemUserLicenseInfo_PowerUsers.Width = 100
            '
            'LabelItemUserLicenseInfo_StandardUsers
            '
            Me.LabelItemUserLicenseInfo_StandardUsers.BeginGroup = True
            Me.LabelItemUserLicenseInfo_StandardUsers.Name = "LabelItemUserLicenseInfo_StandardUsers"
            Me.LabelItemUserLicenseInfo_StandardUsers.Stretch = True
            Me.LabelItemUserLicenseInfo_StandardUsers.Text = "Standard Users"
            Me.LabelItemUserLicenseInfo_StandardUsers.Width = 100
            '
            'LabelItemUserLicenseInfo_MediaToolUsers
            '
            Me.LabelItemUserLicenseInfo_MediaToolUsers.BeginGroup = True
            Me.LabelItemUserLicenseInfo_MediaToolUsers.Name = "LabelItemUserLicenseInfo_MediaToolUsers"
            Me.LabelItemUserLicenseInfo_MediaToolUsers.Stretch = True
            Me.LabelItemUserLicenseInfo_MediaToolUsers.Text = "Media Tool Users"
            Me.LabelItemUserLicenseInfo_MediaToolUsers.Width = 100
            '
            'ItemContainerUserLicenseInfo_Spacer
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Spacer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Spacer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserLicenseInfo_Spacer.Name = "ItemContainerUserLicenseInfo_Spacer"
            Me.ItemContainerUserLicenseInfo_Spacer.ResizeItemsToFit = False
            Me.ItemContainerUserLicenseInfo_Spacer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_Spacer1, Me.LabelItemUserLicenseInfo_Spacer2, Me.LabelItemUserLicenseInfo_Spacer3})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Spacer.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Spacer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_Spacer1
            '
            Me.LabelItemUserLicenseInfo_Spacer1.BeginGroup = True
            Me.LabelItemUserLicenseInfo_Spacer1.Name = "LabelItemUserLicenseInfo_Spacer1"
            Me.LabelItemUserLicenseInfo_Spacer1.Stretch = True
            Me.LabelItemUserLicenseInfo_Spacer1.Text = "  "
            Me.LabelItemUserLicenseInfo_Spacer1.Width = 10
            '
            'LabelItemUserLicenseInfo_Spacer2
            '
            Me.LabelItemUserLicenseInfo_Spacer2.BeginGroup = True
            Me.LabelItemUserLicenseInfo_Spacer2.Name = "LabelItemUserLicenseInfo_Spacer2"
            Me.LabelItemUserLicenseInfo_Spacer2.Stretch = True
            Me.LabelItemUserLicenseInfo_Spacer2.Text = "  "
            Me.LabelItemUserLicenseInfo_Spacer2.Width = 10
            '
            'LabelItemUserLicenseInfo_Spacer3
            '
            Me.LabelItemUserLicenseInfo_Spacer3.BeginGroup = True
            Me.LabelItemUserLicenseInfo_Spacer3.Name = "LabelItemUserLicenseInfo_Spacer3"
            Me.LabelItemUserLicenseInfo_Spacer3.Stretch = True
            Me.LabelItemUserLicenseInfo_Spacer3.Text = "  "
            Me.LabelItemUserLicenseInfo_Spacer3.Width = 10
            '
            'ItemContainerUserLicenseInfo_Middle
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Middle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Middle.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserLicenseInfo_Middle.Name = "ItemContainerUserLicenseInfo_Middle"
            Me.ItemContainerUserLicenseInfo_Middle.ResizeItemsToFit = False
            Me.ItemContainerUserLicenseInfo_Middle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_PowerUsersTotal, Me.LabelItemUserLicenseInfo_StandardUsersTotal, Me.LabelItemUserLicenseInfo_MediaToolUsersTotal})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Middle.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Middle.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_PowerUsersTotal
            '
            Me.LabelItemUserLicenseInfo_PowerUsersTotal.BeginGroup = True
            Me.LabelItemUserLicenseInfo_PowerUsersTotal.Name = "LabelItemUserLicenseInfo_PowerUsersTotal"
            Me.LabelItemUserLicenseInfo_PowerUsersTotal.Stretch = True
            Me.LabelItemUserLicenseInfo_PowerUsersTotal.Text = "Total: 0000"
            Me.LabelItemUserLicenseInfo_PowerUsersTotal.Width = 65
            '
            'LabelItemUserLicenseInfo_StandardUsersTotal
            '
            Me.LabelItemUserLicenseInfo_StandardUsersTotal.BeginGroup = True
            Me.LabelItemUserLicenseInfo_StandardUsersTotal.Name = "LabelItemUserLicenseInfo_StandardUsersTotal"
            Me.LabelItemUserLicenseInfo_StandardUsersTotal.Stretch = True
            Me.LabelItemUserLicenseInfo_StandardUsersTotal.Text = "Total: 0000"
            Me.LabelItemUserLicenseInfo_StandardUsersTotal.Width = 65
            '
            'LabelItemUserLicenseInfo_MediaToolUsersTotal
            '
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal.BeginGroup = True
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal.Name = "LabelItemUserLicenseInfo_MediaToolUsersTotal"
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal.Stretch = True
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal.Text = "Total: 0000"
            Me.LabelItemUserLicenseInfo_MediaToolUsersTotal.Width = 65
            '
            'ItemContainerUserLicenseInfo_Right
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Right.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Right.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerUserLicenseInfo_Right.Name = "ItemContainerUserLicenseInfo_Right"
            Me.ItemContainerUserLicenseInfo_Right.ResizeItemsToFit = False
            Me.ItemContainerUserLicenseInfo_Right.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_PowerUsersAvailable, Me.LabelItemUserLicenseInfo_StandardUsersAvailable, Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Right.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Right.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_PowerUsersAvailable
            '
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable.BeginGroup = True
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable.Name = "LabelItemUserLicenseInfo_PowerUsersAvailable"
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable.Stretch = True
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable.Text = "Available: 0000"
            Me.LabelItemUserLicenseInfo_PowerUsersAvailable.Width = 85
            '
            'LabelItemUserLicenseInfo_StandardUsersAvailable
            '
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable.BeginGroup = True
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable.Name = "LabelItemUserLicenseInfo_StandardUsersAvailable"
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable.Stretch = True
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable.Text = "Available: 0000"
            Me.LabelItemUserLicenseInfo_StandardUsersAvailable.Width = 85
            '
            'LabelItemUserLicenseInfo_MediaToolUsersAvailable
            '
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable.BeginGroup = True
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable.Name = "LabelItemUserLicenseInfo_MediaToolUsersAvailable"
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable.Stretch = True
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable.Text = "Available: 0000"
            Me.LabelItemUserLicenseInfo_MediaToolUsersAvailable.Width = 85
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
            Me.RibbonBarOptions_Employees.Location = New System.Drawing.Point(202, 0)
            Me.RibbonBarOptions_Employees.Name = "RibbonBarOptions_Employees"
            Me.RibbonBarOptions_Employees.SecurityEnabled = True
            Me.RibbonBarOptions_Employees.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employees.TabIndex = 6
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_ChangePassword})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(202, 98)
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
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_ChangePassword
            '
            Me.ButtonItemActions_ChangePassword.BeginGroup = True
            Me.ButtonItemActions_ChangePassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ChangePassword.Name = "ButtonItemActions_ChangePassword"
            Me.ButtonItemActions_ChangePassword.RibbonWordWrap = False
            Me.ButtonItemActions_ChangePassword.SecurityEnabled = True
            Me.ButtonItemActions_ChangePassword.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ChangePassword.Text = "Change" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password"
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
            Me.ComboBoxModuleAccess_Application.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxModuleAccess_Application.ItemHeight = 16
            Me.ComboBoxModuleAccess_Application.Location = New System.Drawing.Point(69, 4)
            Me.ComboBoxModuleAccess_Application.Name = "ComboBoxModuleAccess_Application"
            Me.ComboBoxModuleAccess_Application.ReadOnly = False
            Me.ComboBoxModuleAccess_Application.SecurityEnabled = True
            Me.ComboBoxModuleAccess_Application.Size = New System.Drawing.Size(567, 22)
            Me.ComboBoxModuleAccess_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxModuleAccess_Application.TabIndex = 1
            Me.ComboBoxModuleAccess_Application.TabOnEnter = True
            Me.ComboBoxModuleAccess_Application.ValueMember = "ID"
            Me.ComboBoxModuleAccess_Application.WatermarkText = "Select Application"
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
            Me.CheckBoxModuleAccess_IsBlocked.Location = New System.Drawing.Point(721, 56)
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
            Me.CheckBoxModuleAccess_CanPrint.Location = New System.Drawing.Point(721, 82)
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
            Me.CheckBoxModuleAccess_CanUpdate.Location = New System.Drawing.Point(721, 108)
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
            Me.CheckBoxModuleAccess_CanAdd.Location = New System.Drawing.Point(721, 134)
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
            Me.CheckBoxModuleAccess_Custom1.Location = New System.Drawing.Point(721, 160)
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
            Me.CheckBoxModuleAccess_Custom2.Location = New System.Drawing.Point(721, 186)
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
            Me.LabelModuleAccess_Options.Location = New System.Drawing.Point(721, 30)
            Me.LabelModuleAccess_Options.Name = "LabelModuleAccess_Options"
            Me.LabelModuleAccess_Options.Size = New System.Drawing.Size(81, 20)
            Me.LabelModuleAccess_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelModuleAccess_Options.TabIndex = 3
            Me.LabelModuleAccess_Options.Text = "Options"
            '
            'CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached
            '
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.CheckValue = 0
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.CheckValueChecked = 1
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Location = New System.Drawing.Point(6, 56)
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Name = "CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached"
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.OldestSibling = Nothing
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.SecurityEnabled = True
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.TabIndex = 3
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.TabOnEnter = True
            Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Text = "Limit PO's to Employee Code Attached"
            '
            'CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee
            '
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.CheckValue = 0
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.CheckValueChecked = 1
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Location = New System.Drawing.Point(6, 30)
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Name = "CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee"
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.OldestSibling = Nothing
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.SecurityEnabled = True
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.TabIndex = 2
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.TabOnEnter = True
            Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Text = "Limit Timesheet Functions for Employee"
            '
            'CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached
            '
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.CheckValue = 0
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.CheckValueChecked = 1
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Location = New System.Drawing.Point(6, 4)
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Name = "CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached"
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.OldestSibling = Nothing
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.SecurityEnabled = True
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.TabIndex = 1
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.TabOnEnter = True
            Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Text = "Limit Time and Expense Report Entry to Employee Code Attached"
            '
            'TabControlRightSection_UserDetails
            '
            Me.TabControlRightSection_UserDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_UserDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlRightSection_UserDetails.CanReorderTabs = False
            Me.TabControlRightSection_UserDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlRightSection_UserDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelGroupsTab_Groups)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelUserSettingsTab_UserSettings)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelWorkspacesTab_Workspaces)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelEmployeesTab_Employees)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelUserDetails_ReportAccess)
            Me.TabControlRightSection_UserDetails.Controls.Add(Me.TabControlPanelModuleAccessTab_ModuleAccess)
            Me.TabControlRightSection_UserDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlRightSection_UserDetails.Location = New System.Drawing.Point(6, 66)
            Me.TabControlRightSection_UserDetails.Name = "TabControlRightSection_UserDetails"
            Me.TabControlRightSection_UserDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_UserDetails.SelectedTabIndex = 0
            Me.TabControlRightSection_UserDetails.Size = New System.Drawing.Size(807, 493)
            Me.TabControlRightSection_UserDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_UserDetails.TabIndex = 9
            Me.TabControlRightSection_UserDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_GroupsTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_EmployeeOfficeLimitsTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_ClientDivisionProductTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_EmployeesTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_ModuleAccessTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_ReportAccessTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_UserSettingsTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab)
            Me.TabControlRightSection_UserDetails.Tabs.Add(Me.TabItemUserDetails_WorkspacesTab)
            '
            'TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits
            '
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Controls.Add(Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Controls.Add(Me.LabelTimesheetFunctionLimits_DefaultFunction)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Controls.Add(Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Name = "TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits" &
    ""
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.TabIndex = 8
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.TabItem = Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab
            '
            'SearchableComboBoxTimesheetFunctionLimits_DefaultFunction
            '
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.ActiveFilterString = ""
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.AutoFillMode = False
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.BookmarkingEnabled = False
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.DataSource = Nothing
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.DisableMouseWheel = False
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.DisplayName = ""
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.EnterMoveNextControl = True
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Location = New System.Drawing.Point(120, 4)
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Name = "SearchableComboBoxTimesheetFunctionLimits_DefaultFunction"
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties.NullText = "Select Function"
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SecurityEnabled = True
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue = Nothing
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Size = New System.Drawing.Size(683, 20)
            Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.TabIndex = 1
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            Me.GridView3.SkipAddingControlsOnModifyColumn = False
            Me.GridView3.SkipSettingFontOnModifyColumn = False
            '
            'LabelTimesheetFunctionLimits_DefaultFunction
            '
            Me.LabelTimesheetFunctionLimits_DefaultFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimesheetFunctionLimits_DefaultFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimesheetFunctionLimits_DefaultFunction.Location = New System.Drawing.Point(3, 4)
            Me.LabelTimesheetFunctionLimits_DefaultFunction.Name = "LabelTimesheetFunctionLimits_DefaultFunction"
            Me.LabelTimesheetFunctionLimits_DefaultFunction.Size = New System.Drawing.Size(111, 20)
            Me.LabelTimesheetFunctionLimits_DefaultFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimesheetFunctionLimits_DefaultFunction.TabIndex = 0
            Me.LabelTimesheetFunctionLimits_DefaultFunction.Text = "Default Function:"
            '
            'EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits
            '
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Location = New System.Drawing.Point(5, 30)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Name = "EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTim" &
    "esheetFunctionLimits"
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Size = New System.Drawing.Size(798, 430)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.TabIndex = 2
            '
            'TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab
            '
            Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab.AttachedControl = Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits
            Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab.Name = "TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab"
            Me.TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab.Text = "Timesheet Functions"
            '
            'TabControlPanelGroupsTab_Groups
            '
            Me.TabControlPanelGroupsTab_Groups.Controls.Add(Me.PanelGroups_RightSection)
            Me.TabControlPanelGroupsTab_Groups.Controls.Add(Me.ExpandableSplitterControlGroups_LeftRight)
            Me.TabControlPanelGroupsTab_Groups.Controls.Add(Me.PanelGroups_LeftSection)
            Me.TabControlPanelGroupsTab_Groups.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGroupsTab_Groups.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGroupsTab_Groups.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGroupsTab_Groups.Name = "TabControlPanelGroupsTab_Groups"
            Me.TabControlPanelGroupsTab_Groups.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGroupsTab_Groups.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelGroupsTab_Groups.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGroupsTab_Groups.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGroupsTab_Groups.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGroupsTab_Groups.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGroupsTab_Groups.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGroupsTab_Groups.Style.GradientAngle = 90
            Me.TabControlPanelGroupsTab_Groups.TabIndex = 1
            Me.TabControlPanelGroupsTab_Groups.TabItem = Me.TabItemUserDetails_GroupsTab
            '
            'PanelGroups_RightSection
            '
            Me.PanelGroups_RightSection.Controls.Add(Me.ButtonRightSection_AddToUser)
            Me.PanelGroups_RightSection.Controls.Add(Me.ButtonRightSection_RemoveFromUser)
            Me.PanelGroups_RightSection.Controls.Add(Me.DataGridViewRightSection_UserGroups)
            Me.PanelGroups_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelGroups_RightSection.Location = New System.Drawing.Point(347, 1)
            Me.PanelGroups_RightSection.Name = "PanelGroups_RightSection"
            Me.PanelGroups_RightSection.Size = New System.Drawing.Size(459, 464)
            Me.PanelGroups_RightSection.TabIndex = 6
            '
            'ExpandableSplitterControlGroups_LeftRight
            '
            Me.ExpandableSplitterControlGroups_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlGroups_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlGroups_LeftRight.ExpandableControl = Me.PanelGroups_LeftSection
            Me.ExpandableSplitterControlGroups_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlGroups_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlGroups_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlGroups_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlGroups_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlGroups_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlGroups_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlGroups_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlGroups_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlGroups_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlGroups_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlGroups_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlGroups_LeftRight.Location = New System.Drawing.Point(341, 1)
            Me.ExpandableSplitterControlGroups_LeftRight.Name = "ExpandableSplitterControlGroups_LeftRight"
            Me.ExpandableSplitterControlGroups_LeftRight.Size = New System.Drawing.Size(6, 464)
            Me.ExpandableSplitterControlGroups_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlGroups_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlGroups_LeftRight.TabStop = False
            '
            'PanelGroups_LeftSection
            '
            Me.PanelGroups_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelGroups_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelGroups_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableGroups)
            Me.PanelGroups_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelGroups_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelGroups_LeftSection.Name = "PanelGroups_LeftSection"
            Me.PanelGroups_LeftSection.Size = New System.Drawing.Size(340, 464)
            Me.PanelGroups_LeftSection.TabIndex = 4
            '
            'TabItemUserDetails_GroupsTab
            '
            Me.TabItemUserDetails_GroupsTab.AttachedControl = Me.TabControlPanelGroupsTab_Groups
            Me.TabItemUserDetails_GroupsTab.Name = "TabItemUserDetails_GroupsTab"
            Me.TabItemUserDetails_GroupsTab.Text = "Groups"
            '
            'TabControlPanelUserSettingsTab_UserSettings
            '
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_IsMediaToolsUser)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_IsCRMUser)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_CheckForUserAccess)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_AllowProfileUpdate)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_IsWebvantageUserOnly)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee)
            Me.TabControlPanelUserSettingsTab_UserSettings.Controls.Add(Me.CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached)
            Me.TabControlPanelUserSettingsTab_UserSettings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelUserSettingsTab_UserSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelUserSettingsTab_UserSettings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelUserSettingsTab_UserSettings.Name = "TabControlPanelUserSettingsTab_UserSettings"
            Me.TabControlPanelUserSettingsTab_UserSettings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelUserSettingsTab_UserSettings.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelUserSettingsTab_UserSettings.Style.GradientAngle = 90
            Me.TabControlPanelUserSettingsTab_UserSettings.TabIndex = 0
            Me.TabControlPanelUserSettingsTab_UserSettings.TabItem = Me.TabItemUserDetails_UserSettingsTab
            '
            'CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly
            '
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.CheckValue = 0
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.CheckValueChecked = 1
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Location = New System.Drawing.Point(101, 160)
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Name = "CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly"
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.OldestSibling = Nothing
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.SecurityEnabled = True
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Size = New System.Drawing.Size(700, 20)
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.TabIndex = 8
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.TabOnEnter = True
            Me.CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Text = "Add/Edit/View New Business Clients Only"
            '
            'CheckBoxUserSettings_IsMediaToolsUser
            '
            Me.CheckBoxUserSettings_IsMediaToolsUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_IsMediaToolsUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_IsMediaToolsUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_IsMediaToolsUser.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_IsMediaToolsUser.CheckValue = 0
            Me.CheckBoxUserSettings_IsMediaToolsUser.CheckValueChecked = 1
            Me.CheckBoxUserSettings_IsMediaToolsUser.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_IsMediaToolsUser.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_IsMediaToolsUser.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_IsMediaToolsUser.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsMediaToolsUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_IsMediaToolsUser.Location = New System.Drawing.Point(6, 186)
            Me.CheckBoxUserSettings_IsMediaToolsUser.Name = "CheckBoxUserSettings_IsMediaToolsUser"
            Me.CheckBoxUserSettings_IsMediaToolsUser.OldestSibling = Nothing
            Me.CheckBoxUserSettings_IsMediaToolsUser.SecurityEnabled = True
            Me.CheckBoxUserSettings_IsMediaToolsUser.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_IsMediaToolsUser.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsMediaToolsUser.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_IsMediaToolsUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_IsMediaToolsUser.TabIndex = 9
            Me.CheckBoxUserSettings_IsMediaToolsUser.TabOnEnter = True
            Me.CheckBoxUserSettings_IsMediaToolsUser.Text = "Is Media Tools User"
            '
            'CheckBoxUserSettings_IsCRMUser
            '
            Me.CheckBoxUserSettings_IsCRMUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_IsCRMUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_IsCRMUser.CheckValue = 0
            Me.CheckBoxUserSettings_IsCRMUser.CheckValueChecked = 1
            Me.CheckBoxUserSettings_IsCRMUser.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_IsCRMUser.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_IsCRMUser.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_IsCRMUser.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsCRMUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_IsCRMUser.Location = New System.Drawing.Point(6, 160)
            Me.CheckBoxUserSettings_IsCRMUser.Name = "CheckBoxUserSettings_IsCRMUser"
            Me.CheckBoxUserSettings_IsCRMUser.OldestSibling = Nothing
            Me.CheckBoxUserSettings_IsCRMUser.SecurityEnabled = True
            Me.CheckBoxUserSettings_IsCRMUser.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_IsCRMUser.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsCRMUser.Size = New System.Drawing.Size(89, 20)
            Me.CheckBoxUserSettings_IsCRMUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_IsCRMUser.TabIndex = 7
            Me.CheckBoxUserSettings_IsCRMUser.TabOnEnter = True
            Me.CheckBoxUserSettings_IsCRMUser.Text = "Is CRM User"
            '
            'CheckBoxUserSettings_CheckForUserAccess
            '
            Me.CheckBoxUserSettings_CheckForUserAccess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_CheckForUserAccess.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_CheckForUserAccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_CheckForUserAccess.CheckValue = 0
            Me.CheckBoxUserSettings_CheckForUserAccess.CheckValueChecked = 1
            Me.CheckBoxUserSettings_CheckForUserAccess.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_CheckForUserAccess.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_CheckForUserAccess.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_CheckForUserAccess.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_CheckForUserAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_CheckForUserAccess.Location = New System.Drawing.Point(6, 134)
            Me.CheckBoxUserSettings_CheckForUserAccess.Name = "CheckBoxUserSettings_CheckForUserAccess"
            Me.CheckBoxUserSettings_CheckForUserAccess.OldestSibling = Nothing
            Me.CheckBoxUserSettings_CheckForUserAccess.SecurityEnabled = True
            Me.CheckBoxUserSettings_CheckForUserAccess.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_CheckForUserAccess.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_CheckForUserAccess.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_CheckForUserAccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_CheckForUserAccess.TabIndex = 6
            Me.CheckBoxUserSettings_CheckForUserAccess.TabOnEnter = True
            Me.CheckBoxUserSettings_CheckForUserAccess.Text = "Check For User Access"
            '
            'CheckBoxUserSettings_AllowProfileUpdate
            '
            Me.CheckBoxUserSettings_AllowProfileUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_AllowProfileUpdate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_AllowProfileUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_AllowProfileUpdate.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_AllowProfileUpdate.CheckValue = 0
            Me.CheckBoxUserSettings_AllowProfileUpdate.CheckValueChecked = 1
            Me.CheckBoxUserSettings_AllowProfileUpdate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_AllowProfileUpdate.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_AllowProfileUpdate.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_AllowProfileUpdate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_AllowProfileUpdate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_AllowProfileUpdate.Location = New System.Drawing.Point(6, 108)
            Me.CheckBoxUserSettings_AllowProfileUpdate.Name = "CheckBoxUserSettings_AllowProfileUpdate"
            Me.CheckBoxUserSettings_AllowProfileUpdate.OldestSibling = Nothing
            Me.CheckBoxUserSettings_AllowProfileUpdate.SecurityEnabled = True
            Me.CheckBoxUserSettings_AllowProfileUpdate.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_AllowProfileUpdate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_AllowProfileUpdate.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_AllowProfileUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_AllowProfileUpdate.TabIndex = 5
            Me.CheckBoxUserSettings_AllowProfileUpdate.TabOnEnter = True
            Me.CheckBoxUserSettings_AllowProfileUpdate.Text = "Allow Profile Update"
            '
            'CheckBoxUserSettings_IsWebvantageUserOnly
            '
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.BackgroundStyle.WordWrap = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValue = 0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueChecked = 1
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.CheckValueUnchecked = 0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.ChildControls = CType(resources.GetObject("CheckBoxUserSettings_IsWebvantageUserOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Location = New System.Drawing.Point(6, 82)
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Name = "CheckBoxUserSettings_IsWebvantageUserOnly"
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.OldestSibling = Nothing
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.SecurityEnabled = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.SiblingControls = CType(resources.GetObject("CheckBoxUserSettings_IsWebvantageUserOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Size = New System.Drawing.Size(795, 20)
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.TabIndex = 4
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.TabOnEnter = True
            Me.CheckBoxUserSettings_IsWebvantageUserOnly.Text = "Is Webvantage Only (Standard User)"
            '
            'TabItemUserDetails_UserSettingsTab
            '
            Me.TabItemUserDetails_UserSettingsTab.AttachedControl = Me.TabControlPanelUserSettingsTab_UserSettings
            Me.TabItemUserDetails_UserSettingsTab.Name = "TabItemUserDetails_UserSettingsTab"
            Me.TabItemUserDetails_UserSettingsTab.Text = "User Settings"
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
            Me.TabControlPanelWorkspacesTab_Workspaces.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelWorkspacesTab_Workspaces.Style.GradientAngle = 90
            Me.TabControlPanelWorkspacesTab_Workspaces.TabIndex = 4
            Me.TabControlPanelWorkspacesTab_Workspaces.TabItem = Me.TabItemUserDetails_WorkspacesTab
            '
            'ButtonWorkspaces_Apply
            '
            Me.ButtonWorkspaces_Apply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonWorkspaces_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonWorkspaces_Apply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonWorkspaces_Apply.Location = New System.Drawing.Point(726, 4)
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
            Me.LabelWorkspaces_WorkspaceTemplates.Location = New System.Drawing.Point(6, 4)
            Me.LabelWorkspaces_WorkspaceTemplates.Name = "LabelWorkspaces_WorkspaceTemplates"
            Me.LabelWorkspaces_WorkspaceTemplates.Size = New System.Drawing.Size(120, 20)
            Me.LabelWorkspaces_WorkspaceTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelWorkspaces_WorkspaceTemplates.TabIndex = 0
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
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxWorkspaces_WorkspaceTemplates.FormattingEnabled = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ItemHeight = 16
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Location = New System.Drawing.Point(132, 4)
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Name = "ComboBoxWorkspaces_WorkspaceTemplates"
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ReadOnly = False
            Me.ComboBoxWorkspaces_WorkspaceTemplates.SecurityEnabled = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Size = New System.Drawing.Size(588, 22)
            Me.ComboBoxWorkspaces_WorkspaceTemplates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxWorkspaces_WorkspaceTemplates.TabIndex = 1
            Me.ComboBoxWorkspaces_WorkspaceTemplates.TabOnEnter = True
            Me.ComboBoxWorkspaces_WorkspaceTemplates.ValueMember = "ID"
            Me.ComboBoxWorkspaces_WorkspaceTemplates.WatermarkText = "Select Workspace Template"
            '
            'TabItemUserDetails_WorkspacesTab
            '
            Me.TabItemUserDetails_WorkspacesTab.AttachedControl = Me.TabControlPanelWorkspacesTab_Workspaces
            Me.TabItemUserDetails_WorkspacesTab.Name = "TabItemUserDetails_WorkspacesTab"
            Me.TabItemUserDetails_WorkspacesTab.Text = "Workspaces"
            Me.TabItemUserDetails_WorkspacesTab.Visible = False
            '
            'TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits
            '
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Controls.Add(Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Name = "TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits"
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.TabIndex = 7
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.TabItem = Me.TabItemUserDetails_EmployeeOfficeLimitsTab
            '
            'EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits
            '
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.BackColor = System.Drawing.Color.White
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Location = New System.Drawing.Point(5, 5)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Name = "EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits"
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Size = New System.Drawing.Size(798, 457)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.TabIndex = 0
            '
            'TabItemUserDetails_EmployeeOfficeLimitsTab
            '
            Me.TabItemUserDetails_EmployeeOfficeLimitsTab.AttachedControl = Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits
            Me.TabItemUserDetails_EmployeeOfficeLimitsTab.Name = "TabItemUserDetails_EmployeeOfficeLimitsTab"
            Me.TabItemUserDetails_EmployeeOfficeLimitsTab.Text = "Offices"
            '
            'TabControlPanelEmployeesTab_Employees
            '
            Me.TabControlPanelEmployeesTab_Employees.Controls.Add(Me.UserEmployeeLimitEmployees_EmployeeLimits)
            Me.TabControlPanelEmployeesTab_Employees.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeesTab_Employees.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeesTab_Employees.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeesTab_Employees.Name = "TabControlPanelEmployeesTab_Employees"
            Me.TabControlPanelEmployeesTab_Employees.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeesTab_Employees.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeesTab_Employees.Style.GradientAngle = 90
            Me.TabControlPanelEmployeesTab_Employees.TabIndex = 5
            Me.TabControlPanelEmployeesTab_Employees.TabItem = Me.TabItemUserDetails_EmployeesTab
            '
            'UserEmployeeLimitEmployees_EmployeeLimits
            '
            Me.UserEmployeeLimitEmployees_EmployeeLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.UserEmployeeLimitEmployees_EmployeeLimits.Location = New System.Drawing.Point(5, 5)
            Me.UserEmployeeLimitEmployees_EmployeeLimits.Name = "UserEmployeeLimitEmployees_EmployeeLimits"
            Me.UserEmployeeLimitEmployees_EmployeeLimits.Size = New System.Drawing.Size(798, 457)
            Me.UserEmployeeLimitEmployees_EmployeeLimits.TabIndex = 0
            '
            'TabItemUserDetails_EmployeesTab
            '
            Me.TabItemUserDetails_EmployeesTab.AttachedControl = Me.TabControlPanelEmployeesTab_Employees
            Me.TabItemUserDetails_EmployeesTab.Name = "TabItemUserDetails_EmployeesTab"
            Me.TabItemUserDetails_EmployeesTab.Text = "Employees"
            '
            'TabControlPanelClientDivisionProductTab_ClientDivisionProduct
            '
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Controls.Add(Me.UserCDPLimitClientDivisionProduct_CDPLimits)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Name = "TabControlPanelClientDivisionProductTab_ClientDivisionProduct"
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.Style.GradientAngle = 90
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.TabIndex = 2
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.TabItem = Me.TabItemUserDetails_ClientDivisionProductTab
            '
            'UserCDPLimitClientDivisionProduct_CDPLimits
            '
            Me.UserCDPLimitClientDivisionProduct_CDPLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.UserCDPLimitClientDivisionProduct_CDPLimits.Location = New System.Drawing.Point(5, 5)
            Me.UserCDPLimitClientDivisionProduct_CDPLimits.Name = "UserCDPLimitClientDivisionProduct_CDPLimits"
            Me.UserCDPLimitClientDivisionProduct_CDPLimits.Size = New System.Drawing.Size(798, 457)
            Me.UserCDPLimitClientDivisionProduct_CDPLimits.TabIndex = 0
            '
            'TabItemUserDetails_ClientDivisionProductTab
            '
            Me.TabItemUserDetails_ClientDivisionProductTab.AttachedControl = Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct
            Me.TabItemUserDetails_ClientDivisionProductTab.Name = "TabItemUserDetails_ClientDivisionProductTab"
            Me.TabItemUserDetails_ClientDivisionProductTab.Text = "Client Division Product"
            '
            'TabControlPanelUserDetails_ReportAccess
            '
            Me.TabControlPanelUserDetails_ReportAccess.Controls.Add(Me.DataGridViewReportAccess_Reports)
            Me.TabControlPanelUserDetails_ReportAccess.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelUserDetails_ReportAccess.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelUserDetails_ReportAccess.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelUserDetails_ReportAccess.Name = "TabControlPanelUserDetails_ReportAccess"
            Me.TabControlPanelUserDetails_ReportAccess.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelUserDetails_ReportAccess.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelUserDetails_ReportAccess.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelUserDetails_ReportAccess.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelUserDetails_ReportAccess.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelUserDetails_ReportAccess.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelUserDetails_ReportAccess.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelUserDetails_ReportAccess.Style.GradientAngle = 90
            Me.TabControlPanelUserDetails_ReportAccess.TabIndex = 6
            Me.TabControlPanelUserDetails_ReportAccess.TabItem = Me.TabItemUserDetails_ReportAccessTab
            '
            'DataGridViewReportAccess_Reports
            '
            Me.DataGridViewReportAccess_Reports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewReportAccess_Reports.AllowDragAndDrop = False
            Me.DataGridViewReportAccess_Reports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewReportAccess_Reports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewReportAccess_Reports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewReportAccess_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewReportAccess_Reports.AutoFilterLookupColumns = False
            Me.DataGridViewReportAccess_Reports.AutoloadRepositoryDatasource = True
            Me.DataGridViewReportAccess_Reports.AutoUpdateViewCaption = True
            Me.DataGridViewReportAccess_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewReportAccess_Reports.DataSource = Nothing
            Me.DataGridViewReportAccess_Reports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewReportAccess_Reports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewReportAccess_Reports.ItemDescription = ""
            Me.DataGridViewReportAccess_Reports.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewReportAccess_Reports.MultiSelect = True
            Me.DataGridViewReportAccess_Reports.Name = "DataGridViewReportAccess_Reports"
            Me.DataGridViewReportAccess_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewReportAccess_Reports.RunStandardValidation = True
            Me.DataGridViewReportAccess_Reports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewReportAccess_Reports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewReportAccess_Reports.Size = New System.Drawing.Size(795, 456)
            Me.DataGridViewReportAccess_Reports.TabIndex = 0
            Me.DataGridViewReportAccess_Reports.UseEmbeddedNavigator = False
            Me.DataGridViewReportAccess_Reports.ViewCaptionHeight = -1
            '
            'TabItemUserDetails_ReportAccessTab
            '
            Me.TabItemUserDetails_ReportAccessTab.AttachedControl = Me.TabControlPanelUserDetails_ReportAccess
            Me.TabItemUserDetails_ReportAccessTab.Name = "TabItemUserDetails_ReportAccessTab"
            Me.TabItemUserDetails_ReportAccessTab.Text = "Report Access"
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
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Size = New System.Drawing.Size(807, 466)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.Style.GradientAngle = 90
            Me.TabControlPanelModuleAccessTab_ModuleAccess.TabIndex = 3
            Me.TabControlPanelModuleAccessTab_ModuleAccess.TabItem = Me.TabItemUserDetails_ModuleAccessTab
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
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Location = New System.Drawing.Point(642, 4)
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Name = "CheckBoxModuleAccess_IsApplicationBlocked"
            Me.CheckBoxModuleAccess_IsApplicationBlocked.OldestSibling = Nothing
            Me.CheckBoxModuleAccess_IsApplicationBlocked.SecurityEnabled = True
            Me.CheckBoxModuleAccess_IsApplicationBlocked.SiblingControls = CType(resources.GetObject("CheckBoxModuleAccess_IsApplicationBlocked.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Size = New System.Drawing.Size(73, 20)
            Me.CheckBoxModuleAccess_IsApplicationBlocked.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxModuleAccess_IsApplicationBlocked.TabIndex = 10
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
            Me.AdvTreeModuleAccess_Modules.Location = New System.Drawing.Point(6, 30)
            Me.AdvTreeModuleAccess_Modules.MultiSelect = True
            Me.AdvTreeModuleAccess_Modules.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode
            Me.AdvTreeModuleAccess_Modules.Name = "AdvTreeModuleAccess_Modules"
            Me.AdvTreeModuleAccess_Modules.NodesConnector = Me.NodeConnector1
            Me.AdvTreeModuleAccess_Modules.NodeStyle = Me.ElementStyle1
            Me.AdvTreeModuleAccess_Modules.PathSeparator = ";"
            Me.AdvTreeModuleAccess_Modules.Size = New System.Drawing.Size(709, 430)
            Me.AdvTreeModuleAccess_Modules.Styles.Add(Me.ElementStyle1)
            Me.AdvTreeModuleAccess_Modules.TabIndex = 2
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
            'TabItemUserDetails_ModuleAccessTab
            '
            Me.TabItemUserDetails_ModuleAccessTab.AttachedControl = Me.TabControlPanelModuleAccessTab_ModuleAccess
            Me.TabItemUserDetails_ModuleAccessTab.Name = "TabItemUserDetails_ModuleAccessTab"
            Me.TabItemUserDetails_ModuleAccessTab.Text = "Module Access"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Users)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(200, 571)
            Me.PanelForm_LeftSection.TabIndex = 9
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(200, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 571)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 10
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxRightSection_Inactive)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxRightSection_CheckForUserAccess)
            Me.PanelForm_RightSection.Controls.Add(Me.ComboBoxRightSection_Employee)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Employee)
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlRightSection_UserDetails)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(206, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(825, 571)
            Me.PanelForm_RightSection.TabIndex = 0
            '
            'CheckBoxRightSection_Inactive
            '
            '
            '
            '
            Me.CheckBoxRightSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightSection_Inactive.CheckValue = 0
            Me.CheckBoxRightSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxRightSection_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRightSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxRightSection_Inactive.ChildControls = Nothing
            Me.CheckBoxRightSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightSection_Inactive.Location = New System.Drawing.Point(222, 12)
            Me.CheckBoxRightSection_Inactive.Name = "CheckBoxRightSection_Inactive"
            Me.CheckBoxRightSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxRightSection_Inactive.SecurityEnabled = True
            Me.CheckBoxRightSection_Inactive.SiblingControls = Nothing
            Me.CheckBoxRightSection_Inactive.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxRightSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightSection_Inactive.TabIndex = 6
            Me.CheckBoxRightSection_Inactive.TabOnEnter = True
            Me.CheckBoxRightSection_Inactive.Text = "Inactive"
            '
            'CheckBoxRightSection_CheckForUserAccess
            '
            '
            '
            '
            Me.CheckBoxRightSection_CheckForUserAccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightSection_CheckForUserAccess.CheckValue = 0
            Me.CheckBoxRightSection_CheckForUserAccess.CheckValueChecked = 1
            Me.CheckBoxRightSection_CheckForUserAccess.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRightSection_CheckForUserAccess.CheckValueUnchecked = 0
            Me.CheckBoxRightSection_CheckForUserAccess.ChildControls = Nothing
            Me.CheckBoxRightSection_CheckForUserAccess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightSection_CheckForUserAccess.Location = New System.Drawing.Point(75, 12)
            Me.CheckBoxRightSection_CheckForUserAccess.Name = "CheckBoxRightSection_CheckForUserAccess"
            Me.CheckBoxRightSection_CheckForUserAccess.OldestSibling = Nothing
            Me.CheckBoxRightSection_CheckForUserAccess.SecurityEnabled = True
            Me.CheckBoxRightSection_CheckForUserAccess.SiblingControls = Nothing
            Me.CheckBoxRightSection_CheckForUserAccess.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxRightSection_CheckForUserAccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightSection_CheckForUserAccess.TabIndex = 5
            Me.CheckBoxRightSection_CheckForUserAccess.TabOnEnter = True
            Me.CheckBoxRightSection_CheckForUserAccess.Text = "Check For User Access"
            '
            'ComboBoxRightSection_Employee
            '
            Me.ComboBoxRightSection_Employee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_Employee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_Employee.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_Employee.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_Employee.BookmarkingEnabled = False
            Me.ComboBoxRightSection_Employee.ClientCode = ""
            Me.ComboBoxRightSection_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxRightSection_Employee.DisableMouseWheel = False
            Me.ComboBoxRightSection_Employee.DisplayMember = "FullName"
            Me.ComboBoxRightSection_Employee.DisplayName = ""
            Me.ComboBoxRightSection_Employee.DivisionCode = ""
            Me.ComboBoxRightSection_Employee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRightSection_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxRightSection_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_Employee.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_Employee.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxRightSection_Employee.ItemHeight = 16
            Me.ComboBoxRightSection_Employee.Location = New System.Drawing.Point(75, 38)
            Me.ComboBoxRightSection_Employee.Name = "ComboBoxRightSection_Employee"
            Me.ComboBoxRightSection_Employee.ReadOnly = False
            Me.ComboBoxRightSection_Employee.SecurityEnabled = True
            Me.ComboBoxRightSection_Employee.Size = New System.Drawing.Size(735, 22)
            Me.ComboBoxRightSection_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_Employee.TabIndex = 8
            Me.ComboBoxRightSection_Employee.TabOnEnter = True
            Me.ComboBoxRightSection_Employee.ValueMember = "Code"
            Me.ComboBoxRightSection_Employee.WatermarkText = "Select Employee"
            '
            'LabelRightSection_Employee
            '
            Me.LabelRightSection_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Employee.Location = New System.Drawing.Point(6, 40)
            Me.LabelRightSection_Employee.Name = "LabelRightSection_Employee"
            Me.LabelRightSection_Employee.Size = New System.Drawing.Size(63, 20)
            Me.LabelRightSection_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Employee.TabIndex = 7
            Me.LabelRightSection_Employee.Text = "Employee:"
            '
            'ItemContainerUserLicenseInfo_Top
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Top.Name = "ItemContainerUserLicenseInfo_Top"
            Me.ItemContainerUserLicenseInfo_Top.ResizeItemsToFit = False
            Me.ItemContainerUserLicenseInfo_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerUserLicenseInfo_Left, Me.ItemContainerUserLicenseInfo_Spacer, Me.ItemContainerUserLicenseInfo_Middle, Me.ItemContainerUserLicenseInfo_Right})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Top.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerUserLicenseInfo_Bottom
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Bottom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_Bottom.Name = "ItemContainerUserLicenseInfo_Bottom"
            Me.ItemContainerUserLicenseInfo_Bottom.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_StandardUserAstrisk})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Bottom.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_Bottom.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_StandardUserAstrisk
            '
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk.BeginGroup = True
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk.Name = "LabelItemUserLicenseInfo_StandardUserAstrisk"
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk.Stretch = True
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk.Text = "*Reflects 1 extra license for API use."
            Me.LabelItemUserLicenseInfo_StandardUserAstrisk.Visible = False
            '
            'ItemContainerUserLicenseInfo_BottomSpacer
            '
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_BottomSpacer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerUserLicenseInfo_BottomSpacer.Name = "ItemContainerUserLicenseInfo_BottomSpacer"
            Me.ItemContainerUserLicenseInfo_BottomSpacer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemUserLicenseInfo_Spacer})
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_BottomSpacer.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerUserLicenseInfo_BottomSpacer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemUserLicenseInfo_Spacer
            '
            Me.LabelItemUserLicenseInfo_Spacer.BeginGroup = True
            Me.LabelItemUserLicenseInfo_Spacer.Name = "LabelItemUserLicenseInfo_Spacer"
            Me.LabelItemUserLicenseInfo_Spacer.Stretch = True
            Me.LabelItemUserLicenseInfo_Spacer.Text = "   "
            '
            'UserSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1031, 571)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserSetupForm"
            Me.Text = "User Setup"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlRightSection_UserDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_UserDetails.ResumeLayout(False)
            Me.TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits.ResumeLayout(False)
            CType(Me.SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelGroupsTab_Groups.ResumeLayout(False)
            CType(Me.PanelGroups_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelGroups_RightSection.ResumeLayout(False)
            CType(Me.PanelGroups_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelGroups_LeftSection.ResumeLayout(False)
            Me.TabControlPanelUserSettingsTab_UserSettings.ResumeLayout(False)
            Me.TabControlPanelWorkspacesTab_Workspaces.ResumeLayout(False)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.ResumeLayout(False)
            Me.TabControlPanelEmployeesTab_Employees.ResumeLayout(False)
            Me.TabControlPanelClientDivisionProductTab_ClientDivisionProduct.ResumeLayout(False)
            Me.TabControlPanelUserDetails_ReportAccess.ResumeLayout(False)
            Me.TabControlPanelModuleAccessTab_ModuleAccess.ResumeLayout(False)
            CType(Me.AdvTreeModuleAccess_Modules, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_Users As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveFromUser As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddToUser As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_UserGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewLeftSection_AvailableGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ComboBoxModuleAccess_Application As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelModuleAccess_Application As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxModuleAccess_IsBlocked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_CanPrint As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_CanUpdate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_CanAdd As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_Custom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxModuleAccess_Custom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelModuleAccess_Options As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlRightSection_UserDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGroupsTab_Groups As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_GroupsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelClientDivisionProductTab_ClientDivisionProduct As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_ClientDivisionProductTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelModuleAccessTab_ModuleAccess As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_ModuleAccessTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelUserSettingsTab_UserSettings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_UserSettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ExpandAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_CollapseAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelGroups_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlGroups_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelGroups_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlPanelEmployeesTab_Employees As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_EmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxUserSettings_IsWebvantageUserOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelUserDetails_ReportAccess As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewReportAccess_Reports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemUserDetails_ReportAccessTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelWorkspacesTab_Workspaces As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_WorkspacesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonWorkspaces_Apply As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelWorkspaces_WorkspaceTemplates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxWorkspaces_WorkspaceTemplates As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxUserSettings_AllowProfileUpdate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents AdvTreeModuleAccess_Modules As DevComponents.AdvTree.AdvTree
        Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents CheckBoxUserSettings_CheckForUserAccess As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RibbonBarOptions_UserSettings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemUserSettings_CheckAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUserSettings_UncheckAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxModuleAccess_IsApplicationBlocked As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightSection_CheckForUserAccess As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxRightSection_Employee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelRightSection_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Employees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployees_Terminated As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxUserSettings_IsCRMUser As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUserSettings_IsMediaToolsUser As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents UserCDPLimitClientDivisionProduct_CDPLimits As AdvantageFramework.WinForm.Presentation.Controls.UserCDPLimitControl
        Friend WithEvents UserEmployeeLimitEmployees_EmployeeLimits As AdvantageFramework.WinForm.Presentation.Controls.UserEmployeeLimitControl
        Friend WithEvents TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUserDetails_EmployeeOfficeLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits As AdvantageFramework.WinForm.Presentation.Controls.EmployeeOfficeLimitControl
        Friend WithEvents TabControlPanelEmployeeTimesheetFunctionLimitsTab_EmployeeTimesheetFunctionLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits As AdvantageFramework.WinForm.Presentation.Controls.EmployeeTimesheetFunctionLimitsControl
        Friend WithEvents TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_TimesheetFunction As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTimesheetFunction_TimesheetFunctionCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTimesheetFunctionCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTimesheetFunctionCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CDP As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCDP_CDPCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCDPCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCDPCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Employee As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployee_EmployeeCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOffice_OfficeCopy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOfficeCopy_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOfficeCopy_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxRightSection_Inactive As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonItemActions_ChangePassword As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_UserLicenseInfo As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerUserLicenseInfo_Left As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_PowerUsers As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_StandardUsers As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_MediaToolUsers As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerUserLicenseInfo_Spacer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_Spacer1 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_Spacer2 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_Spacer3 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerUserLicenseInfo_Middle As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_PowerUsersTotal As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_StandardUsersTotal As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_MediaToolUsersTotal As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerUserLicenseInfo_Right As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_PowerUsersAvailable As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_StandardUsersAvailable As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemUserLicenseInfo_MediaToolUsersAvailable As DevComponents.DotNetBar.LabelItem
        Friend WithEvents CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxTimesheetFunctionLimits_DefaultFunction As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelTimesheetFunctionLimits_DefaultFunction As WinForm.Presentation.Controls.Label
        Friend WithEvents ItemContainerUserLicenseInfo_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerUserLicenseInfo_BottomSpacer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_Spacer As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerUserLicenseInfo_Bottom As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemUserLicenseInfo_StandardUserAstrisk As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace
