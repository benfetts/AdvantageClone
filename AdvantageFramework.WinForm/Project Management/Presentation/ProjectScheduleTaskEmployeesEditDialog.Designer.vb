Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleTaskEmployeesEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleTaskEmployeesEditDialog))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarDetails_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_LimitToTaskRoles = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_CheckAvailability = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlMain_Details = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelEmployeesTab_Employees = New DevComponents.DotNetBar.TabControlPanel()
            Me.ExpandableSplitterControlEmployees_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.TabItemDetails_EmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRolesTab_Roles = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRoles_Roles = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemDetails_RolesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_TimeDue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DefaultHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TimeDuePlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DefaultHoursPlaceholder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlMain_Details, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlMain_Details.SuspendLayout()
            Me.TabControlPanelEmployeesTab_Employees.SuspendLayout()
            Me.TabControlPanelRolesTab_Roles.SuspendLayout()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(700, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarDetails_Options)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(700, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarDetails_Options, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DefaultHoursPlaceholder)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_TimeDuePlaceholder)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DefaultHours)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_TimeDue)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_DueDate)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DueDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_StartDate)
            Me.PanelForm_Form.Controls.Add(Me.TabControlMain_Details)
            Me.PanelForm_Form.Size = New System.Drawing.Size(700, 387)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 542)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(700, 18)
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableEmployees)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(252, 294)
            Me.PanelForm_LeftSection.TabIndex = 11
            '
            'DataGridViewLeftSection_AvailableEmployees
            '
            Me.DataGridViewLeftSection_AvailableEmployees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableEmployees.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableEmployees.ItemDescription = "Available Employee(s)"
            Me.DataGridViewLeftSection_AvailableEmployees.Location = New System.Drawing.Point(5, 6)
            Me.DataGridViewLeftSection_AvailableEmployees.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableEmployees.Name = "DataGridViewLeftSection_AvailableEmployees"
            Me.DataGridViewLeftSection_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableEmployees.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableEmployees.Size = New System.Drawing.Size(241, 282)
            Me.DataGridViewLeftSection_AvailableEmployees.TabIndex = 12
            Me.DataGridViewLeftSection_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableEmployees.ViewCaptionHeight = -1
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.ButtonRightSection_RemoveEmployee)
            Me.PanelForm_RightSection.Controls.Add(Me.ButtonRightSection_AddEmployee)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedEmployees)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(259, 1)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(434, 294)
            Me.PanelForm_RightSection.TabIndex = 13
            '
            'ButtonRightSection_RemoveEmployee
            '
            Me.ButtonRightSection_RemoveEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveEmployee.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveEmployee.Name = "ButtonRightSection_RemoveEmployee"
            Me.ButtonRightSection_RemoveEmployee.SecurityEnabled = True
            Me.ButtonRightSection_RemoveEmployee.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveEmployee.TabIndex = 14
            Me.ButtonRightSection_RemoveEmployee.Text = "<"
            '
            'ButtonRightSection_AddEmployee
            '
            Me.ButtonRightSection_AddEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddEmployee.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddEmployee.Name = "ButtonRightSection_AddEmployee"
            Me.ButtonRightSection_AddEmployee.SecurityEnabled = True
            Me.ButtonRightSection_AddEmployee.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddEmployee.TabIndex = 13
            Me.ButtonRightSection_AddEmployee.Text = ">"
            '
            'DataGridViewRightSection_SelectedEmployees
            '
            Me.DataGridViewRightSection_SelectedEmployees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_SelectedEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_SelectedEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedEmployees.ItemDescription = "Selected Employee(s)"
            Me.DataGridViewRightSection_SelectedEmployees.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_SelectedEmployees.MultiSelect = True
            Me.DataGridViewRightSection_SelectedEmployees.Name = "DataGridViewRightSection_SelectedEmployees"
            Me.DataGridViewRightSection_SelectedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedEmployees.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedEmployees.Size = New System.Drawing.Size(342, 282)
            Me.DataGridViewRightSection_SelectedEmployees.TabIndex = 12
            Me.DataGridViewRightSection_SelectedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedEmployees.ViewCaptionHeight = -1
            '
            'RibbonBarDetails_Options
            '
            Me.RibbonBarDetails_Options.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarDetails_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDetails_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDetails_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarDetails_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarDetails_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Save, Me.ButtonItemOptions_Refresh, Me.ButtonItemOptions_LimitToTaskRoles, Me.ButtonItemOptions_CheckAvailability})
            Me.RibbonBarDetails_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarDetails_Options.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarDetails_Options.Name = "RibbonBarDetails_Options"
            Me.RibbonBarDetails_Options.Size = New System.Drawing.Size(312, 92)
            Me.RibbonBarDetails_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarDetails_Options.TabIndex = 4
            Me.RibbonBarDetails_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarDetails_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDetails_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDetails_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOptions_Save
            '
            Me.ButtonItemOptions_Save.BeginGroup = True
            Me.ButtonItemOptions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Save.Name = "ButtonItemOptions_Save"
            Me.ButtonItemOptions_Save.RibbonWordWrap = False
            Me.ButtonItemOptions_Save.SecurityEnabled = True
            Me.ButtonItemOptions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Save.Text = "Save"
            '
            'ButtonItemOptions_Refresh
            '
            Me.ButtonItemOptions_Refresh.BeginGroup = True
            Me.ButtonItemOptions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Refresh.Name = "ButtonItemOptions_Refresh"
            Me.ButtonItemOptions_Refresh.RibbonWordWrap = False
            Me.ButtonItemOptions_Refresh.SecurityEnabled = True
            Me.ButtonItemOptions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Refresh.Text = "Refresh"
            '
            'ButtonItemOptions_LimitToTaskRoles
            '
            Me.ButtonItemOptions_LimitToTaskRoles.AutoCheckOnClick = True
            Me.ButtonItemOptions_LimitToTaskRoles.BeginGroup = True
            Me.ButtonItemOptions_LimitToTaskRoles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_LimitToTaskRoles.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_LimitToTaskRoles.Name = "ButtonItemOptions_LimitToTaskRoles"
            Me.ButtonItemOptions_LimitToTaskRoles.RibbonWordWrap = False
            Me.ButtonItemOptions_LimitToTaskRoles.Stretch = True
            Me.ButtonItemOptions_LimitToTaskRoles.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_LimitToTaskRoles.Text = "Limit List to Task Roles"
            '
            'ButtonItemOptions_CheckAvailability
            '
            Me.ButtonItemOptions_CheckAvailability.AutoCheckOnClick = True
            Me.ButtonItemOptions_CheckAvailability.BeginGroup = True
            Me.ButtonItemOptions_CheckAvailability.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_CheckAvailability.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_CheckAvailability.Name = "ButtonItemOptions_CheckAvailability"
            Me.ButtonItemOptions_CheckAvailability.RibbonWordWrap = False
            Me.ButtonItemOptions_CheckAvailability.Stretch = True
            Me.ButtonItemOptions_CheckAvailability.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_CheckAvailability.Text = "Check Availability"
            '
            'TabControlMain_Details
            '
            Me.TabControlMain_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlMain_Details.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlMain_Details.CanReorderTabs = True
            Me.TabControlMain_Details.Controls.Add(Me.TabControlPanelEmployeesTab_Employees)
            Me.TabControlMain_Details.Controls.Add(Me.TabControlPanelRolesTab_Roles)
            Me.TabControlMain_Details.Location = New System.Drawing.Point(3, 58)
            Me.TabControlMain_Details.Name = "TabControlMain_Details"
            Me.TabControlMain_Details.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlMain_Details.SelectedTabIndex = 0
            Me.TabControlMain_Details.Size = New System.Drawing.Size(694, 323)
            Me.TabControlMain_Details.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlMain_Details.TabIndex = 14
            Me.TabControlMain_Details.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlMain_Details.Tabs.Add(Me.TabItemDetails_EmployeesTab)
            Me.TabControlMain_Details.Tabs.Add(Me.TabItemDetails_RolesTab)
            Me.TabControlMain_Details.Text = "TabControl1"
            '
            'TabControlPanelEmployeesTab_Employees
            '
            Me.TabControlPanelEmployeesTab_Employees.Controls.Add(Me.PanelForm_RightSection)
            Me.TabControlPanelEmployeesTab_Employees.Controls.Add(Me.ExpandableSplitterControlEmployees_LeftRight)
            Me.TabControlPanelEmployeesTab_Employees.Controls.Add(Me.PanelForm_LeftSection)
            Me.TabControlPanelEmployeesTab_Employees.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeesTab_Employees.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeesTab_Employees.Name = "TabControlPanelEmployeesTab_Employees"
            Me.TabControlPanelEmployeesTab_Employees.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeesTab_Employees.Size = New System.Drawing.Size(694, 296)
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeesTab_Employees.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeesTab_Employees.Style.GradientAngle = 90
            Me.TabControlPanelEmployeesTab_Employees.TabIndex = 1
            Me.TabControlPanelEmployeesTab_Employees.TabItem = Me.TabItemDetails_EmployeesTab
            '
            'ExpandableSplitterControlEmployees_LeftRight
            '
            Me.ExpandableSplitterControlEmployees_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlEmployees_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlEmployees_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlEmployees_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlEmployees_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlEmployees_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlEmployees_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlEmployees_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlEmployees_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlEmployees_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlEmployees_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlEmployees_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlEmployees_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlEmployees_LeftRight.Location = New System.Drawing.Point(253, 1)
            Me.ExpandableSplitterControlEmployees_LeftRight.Name = "ExpandableSplitterControlEmployees_LeftRight"
            Me.ExpandableSplitterControlEmployees_LeftRight.Size = New System.Drawing.Size(6, 294)
            Me.ExpandableSplitterControlEmployees_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlEmployees_LeftRight.TabIndex = 12
            Me.ExpandableSplitterControlEmployees_LeftRight.TabStop = False
            '
            'TabItemDetails_EmployeesTab
            '
            Me.TabItemDetails_EmployeesTab.AttachedControl = Me.TabControlPanelEmployeesTab_Employees
            Me.TabItemDetails_EmployeesTab.Name = "TabItemDetails_EmployeesTab"
            Me.TabItemDetails_EmployeesTab.Text = "Employees"
            '
            'TabControlPanelRolesTab_Roles
            '
            Me.TabControlPanelRolesTab_Roles.Controls.Add(Me.DataGridViewRoles_Roles)
            Me.TabControlPanelRolesTab_Roles.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRolesTab_Roles.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRolesTab_Roles.Name = "TabControlPanelRolesTab_Roles"
            Me.TabControlPanelRolesTab_Roles.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRolesTab_Roles.Size = New System.Drawing.Size(694, 296)
            Me.TabControlPanelRolesTab_Roles.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRolesTab_Roles.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRolesTab_Roles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRolesTab_Roles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRolesTab_Roles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRolesTab_Roles.Style.GradientAngle = 90
            Me.TabControlPanelRolesTab_Roles.TabIndex = 2
            Me.TabControlPanelRolesTab_Roles.TabItem = Me.TabItemDetails_RolesTab
            '
            'DataGridViewRoles_Roles
            '
            Me.DataGridViewRoles_Roles.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRoles_Roles.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRoles_Roles.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRoles_Roles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRoles_Roles.AutoFilterLookupColumns = False
            Me.DataGridViewRoles_Roles.AutoloadRepositoryDatasource = True
            Me.DataGridViewRoles_Roles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewRoles_Roles.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRoles_Roles.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRoles_Roles.ItemDescription = "Item(s)"
            Me.DataGridViewRoles_Roles.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewRoles_Roles.MultiSelect = True
            Me.DataGridViewRoles_Roles.Name = "DataGridViewRoles_Roles"
            Me.DataGridViewRoles_Roles.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRoles_Roles.RunStandardValidation = True
            Me.DataGridViewRoles_Roles.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRoles_Roles.Size = New System.Drawing.Size(687, 288)
            Me.DataGridViewRoles_Roles.TabIndex = 0
            Me.DataGridViewRoles_Roles.UseEmbeddedNavigator = False
            Me.DataGridViewRoles_Roles.ViewCaptionHeight = -1
            '
            'TabItemDetails_RolesTab
            '
            Me.TabItemDetails_RolesTab.AttachedControl = Me.TabControlPanelRolesTab_Roles
            Me.TabItemDetails_RolesTab.Name = "TabItemDetails_RolesTab"
            Me.TabItemDetails_RolesTab.Text = "Roles"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(4, 6)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 15
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'LabelForm_DueDate
            '
            Me.LabelForm_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DueDate.Location = New System.Drawing.Point(199, 6)
            Me.LabelForm_DueDate.Name = "LabelForm_DueDate"
            Me.LabelForm_DueDate.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DueDate.TabIndex = 16
            Me.LabelForm_DueDate.Text = "Due Date:"
            '
            'DateTimePickerForm_StartDate
            '
            Me.DateTimePickerForm_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_StartDate.CustomFormat = ""
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(92, 6)
            Me.DateTimePickerForm_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_StartDate.Name = "DateTimePickerForm_StartDate"
            Me.DateTimePickerForm_StartDate.ReadOnly = False
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(101, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 17
            Me.DateTimePickerForm_StartDate.Value = New Date(2013, 12, 4, 12, 23, 46, 756)
            '
            'DateTimePickerForm_DueDate
            '
            Me.DateTimePickerForm_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DueDate.CustomFormat = ""
            Me.DateTimePickerForm_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DueDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DueDate.Location = New System.Drawing.Point(287, 6)
            Me.DateTimePickerForm_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.DisplayMonth = New Date(2013, 12, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DueDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DueDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DueDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DueDate.Name = "DateTimePickerForm_DueDate"
            Me.DateTimePickerForm_DueDate.ReadOnly = False
            Me.DateTimePickerForm_DueDate.Size = New System.Drawing.Size(101, 20)
            Me.DateTimePickerForm_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DueDate.TabIndex = 18
            Me.DateTimePickerForm_DueDate.Value = New Date(2013, 12, 4, 12, 23, 46, 773)
            '
            'LabelForm_TimeDue
            '
            Me.LabelForm_TimeDue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TimeDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TimeDue.Location = New System.Drawing.Point(4, 32)
            Me.LabelForm_TimeDue.Name = "LabelForm_TimeDue"
            Me.LabelForm_TimeDue.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_TimeDue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TimeDue.TabIndex = 19
            Me.LabelForm_TimeDue.Text = "Time Due:"
            '
            'LabelForm_DefaultHours
            '
            Me.LabelForm_DefaultHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultHours.Location = New System.Drawing.Point(199, 32)
            Me.LabelForm_DefaultHours.Name = "LabelForm_DefaultHours"
            Me.LabelForm_DefaultHours.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_DefaultHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultHours.TabIndex = 20
            Me.LabelForm_DefaultHours.Text = "Default Hours:"
            '
            'LabelForm_TimeDuePlaceholder
            '
            Me.LabelForm_TimeDuePlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TimeDuePlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TimeDuePlaceholder.Location = New System.Drawing.Point(92, 32)
            Me.LabelForm_TimeDuePlaceholder.Name = "LabelForm_TimeDuePlaceholder"
            Me.LabelForm_TimeDuePlaceholder.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_TimeDuePlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TimeDuePlaceholder.TabIndex = 21
            Me.LabelForm_TimeDuePlaceholder.Text = "{0}"
            '
            'LabelForm_DefaultHoursPlaceholder
            '
            Me.LabelForm_DefaultHoursPlaceholder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultHoursPlaceholder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultHoursPlaceholder.Location = New System.Drawing.Point(287, 32)
            Me.LabelForm_DefaultHoursPlaceholder.Name = "LabelForm_DefaultHoursPlaceholder"
            Me.LabelForm_DefaultHoursPlaceholder.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_DefaultHoursPlaceholder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultHoursPlaceholder.TabIndex = 22
            Me.LabelForm_DefaultHoursPlaceholder.Text = "{0}"
            '
            'ProjectScheduleTaskEmployeesEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(710, 562)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleTaskEmployeesEditDialog"
            Me.Text = "Employees"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlMain_Details, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlMain_Details.ResumeLayout(False)
            Me.TabControlPanelEmployeesTab_Employees.ResumeLayout(False)
            Me.TabControlPanelRolesTab_Roles.ResumeLayout(False)
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_SelectedEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSection_RemoveEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RibbonBarDetails_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOptions_LimitToTaskRoles As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptions_CheckAvailability As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlMain_Details As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelEmployeesTab_Employees As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ExpandableSplitterControlEmployees_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents TabItemDetails_EmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRolesTab_Roles As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewRoles_Roles As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemDetails_RolesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelForm_DefaultHoursPlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TimeDuePlaceholder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DefaultHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TimeDue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_DueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemOptions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace