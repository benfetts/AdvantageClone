Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SecurityInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityInitialLoadingDialog))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_ViewReport = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelGroupVersionAndOptions_ReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectGroups_Groups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectGroups_AllGroups = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectGroups_ChooseGroups = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectGroupsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectUsers_Users = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectUsers_AllUsers = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectUsers_ChooseUsers = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectUsersTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxFrom_IncludeTerminated = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ShowOnlyAccessibleModules = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabItemJDA_SelectJobsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectJobsTab_SelectJobs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSelectJobs_JobStatus = New System.Windows.Forms.Panel()
            Me.DataGridViewSelectJobs_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectJobs_AllJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectJobs_ChooseJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenClosedJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobStatus_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ButtonForm_View = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.TabControlPanelSelectJobsTab_SelectJobs.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(107, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ViewReport})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(81, 98)
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
            'ButtonItemActions_ViewReport
            '
            Me.ButtonItemActions_ViewReport.BeginGroup = True
            Me.ButtonItemActions_ViewReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ViewReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ViewReport.Name = "ButtonItemActions_ViewReport"
            Me.ButtonItemActions_ViewReport.RibbonWordWrap = False
            Me.ButtonItemActions_ViewReport.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ViewReport.Text = "View Report"
            '
            'LabelGroupVersionAndOptions_ReportOptions
            '
            Me.LabelGroupVersionAndOptions_ReportOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGroupVersionAndOptions_ReportOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGroupVersionAndOptions_ReportOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroupVersionAndOptions_ReportOptions.Location = New System.Drawing.Point(4, 4)
            Me.LabelGroupVersionAndOptions_ReportOptions.Name = "LabelGroupVersionAndOptions_ReportOptions"
            Me.LabelGroupVersionAndOptions_ReportOptions.Size = New System.Drawing.Size(792, 20)
            Me.LabelGroupVersionAndOptions_ReportOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroupVersionAndOptions_ReportOptions.TabIndex = 1
            Me.LabelGroupVersionAndOptions_ReportOptions.Text = "Report Options"
            '
            'TabControlForm_JDA
            '
            Me.TabControlForm_JDA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_JDA.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_JDA.CanReorderTabs = False
            Me.TabControlForm_JDA.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(800, 580)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 0
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectGroupsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectUsersTab)
            '
            'TabControlPanelSelectOfficesTab_SelectOffices
            '
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.DataGridViewSelectGroups_Groups)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectGroups_AllGroups)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectGroups_ChooseGroups)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Name = "TabControlPanelSelectOfficesTab_SelectOffices"
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabItem = Me.TabItemJDA_SelectGroupsTab
            '
            'DataGridViewSelectGroups_Groups
            '
            Me.DataGridViewSelectGroups_Groups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectGroups_Groups.AllowDragAndDrop = False
            Me.DataGridViewSelectGroups_Groups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectGroups_Groups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectGroups_Groups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectGroups_Groups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectGroups_Groups.AutoFilterLookupColumns = False
            Me.DataGridViewSelectGroups_Groups.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectGroups_Groups.AutoUpdateViewCaption = True
            Me.DataGridViewSelectGroups_Groups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectGroups_Groups.DataSource = Nothing
            Me.DataGridViewSelectGroups_Groups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectGroups_Groups.Enabled = False
            Me.DataGridViewSelectGroups_Groups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectGroups_Groups.ItemDescription = "Group(s)"
            Me.DataGridViewSelectGroups_Groups.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectGroups_Groups.MultiSelect = False
            Me.DataGridViewSelectGroups_Groups.Name = "DataGridViewSelectGroups_Groups"
            Me.DataGridViewSelectGroups_Groups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectGroups_Groups.RunStandardValidation = True
            Me.DataGridViewSelectGroups_Groups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectGroups_Groups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectGroups_Groups.Size = New System.Drawing.Size(792, 519)
            Me.DataGridViewSelectGroups_Groups.TabIndex = 2
            Me.DataGridViewSelectGroups_Groups.UseEmbeddedNavigator = False
            Me.DataGridViewSelectGroups_Groups.ViewCaptionHeight = -1
            '
            'RadioButtonSelectGroups_AllGroups
            '
            Me.RadioButtonSelectGroups_AllGroups.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectGroups_AllGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectGroups_AllGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectGroups_AllGroups.Checked = True
            Me.RadioButtonSelectGroups_AllGroups.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectGroups_AllGroups.CheckValue = "Y"
            Me.RadioButtonSelectGroups_AllGroups.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectGroups_AllGroups.Name = "RadioButtonSelectGroups_AllGroups"
            Me.RadioButtonSelectGroups_AllGroups.SecurityEnabled = True
            Me.RadioButtonSelectGroups_AllGroups.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectGroups_AllGroups.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectGroups_AllGroups.TabIndex = 0
            Me.RadioButtonSelectGroups_AllGroups.TabOnEnter = True
            Me.RadioButtonSelectGroups_AllGroups.Text = "All Groups"
            '
            'RadioButtonSelectGroups_ChooseGroups
            '
            Me.RadioButtonSelectGroups_ChooseGroups.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectGroups_ChooseGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectGroups_ChooseGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectGroups_ChooseGroups.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectGroups_ChooseGroups.Name = "RadioButtonSelectGroups_ChooseGroups"
            Me.RadioButtonSelectGroups_ChooseGroups.SecurityEnabled = True
            Me.RadioButtonSelectGroups_ChooseGroups.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectGroups_ChooseGroups.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectGroups_ChooseGroups.TabIndex = 1
            Me.RadioButtonSelectGroups_ChooseGroups.TabOnEnter = True
            Me.RadioButtonSelectGroups_ChooseGroups.TabStop = False
            Me.RadioButtonSelectGroups_ChooseGroups.Text = "Choose Groups"
            '
            'TabItemJDA_SelectGroupsTab
            '
            Me.TabItemJDA_SelectGroupsTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectOffices
            Me.TabItemJDA_SelectGroupsTab.Name = "TabItemJDA_SelectGroupsTab"
            Me.TabItemJDA_SelectGroupsTab.Text = "Select Groups"
            '
            'TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            '
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.DataGridViewSelectUsers_Users)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectUsers_AllUsers)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Controls.Add(Me.RadioButtonSelectUsers_ChooseUsers)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Name = "TabControlPanelSelectSalesClassesTab_SelectSalesClasses"
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.Style.GradientAngle = 90
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabIndex = 0
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.TabItem = Me.TabItemJDA_SelectUsersTab
            '
            'DataGridViewSelectUsers_Users
            '
            Me.DataGridViewSelectUsers_Users.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectUsers_Users.AllowDragAndDrop = False
            Me.DataGridViewSelectUsers_Users.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectUsers_Users.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectUsers_Users.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectUsers_Users.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectUsers_Users.AutoFilterLookupColumns = False
            Me.DataGridViewSelectUsers_Users.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectUsers_Users.AutoUpdateViewCaption = True
            Me.DataGridViewSelectUsers_Users.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectUsers_Users.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectUsers_Users.Enabled = False
            Me.DataGridViewSelectUsers_Users.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectUsers_Users.ItemDescription = "User(s)"
            Me.DataGridViewSelectUsers_Users.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectUsers_Users.MultiSelect = False
            Me.DataGridViewSelectUsers_Users.Name = "DataGridViewSelectUsers_Users"
            Me.DataGridViewSelectUsers_Users.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectUsers_Users.RunStandardValidation = True
            Me.DataGridViewSelectUsers_Users.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectUsers_Users.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectUsers_Users.Size = New System.Drawing.Size(792, 519)
            Me.DataGridViewSelectUsers_Users.TabIndex = 2
            Me.DataGridViewSelectUsers_Users.UseEmbeddedNavigator = False
            Me.DataGridViewSelectUsers_Users.ViewCaptionHeight = -1
            '
            'RadioButtonSelectUsers_AllUsers
            '
            Me.RadioButtonSelectUsers_AllUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectUsers_AllUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectUsers_AllUsers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectUsers_AllUsers.Checked = True
            Me.RadioButtonSelectUsers_AllUsers.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectUsers_AllUsers.CheckValue = "Y"
            Me.RadioButtonSelectUsers_AllUsers.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectUsers_AllUsers.Name = "RadioButtonSelectUsers_AllUsers"
            Me.RadioButtonSelectUsers_AllUsers.SecurityEnabled = True
            Me.RadioButtonSelectUsers_AllUsers.Size = New System.Drawing.Size(113, 20)
            Me.RadioButtonSelectUsers_AllUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectUsers_AllUsers.TabIndex = 0
            Me.RadioButtonSelectUsers_AllUsers.TabOnEnter = True
            Me.RadioButtonSelectUsers_AllUsers.Text = "All Users"
            '
            'RadioButtonSelectUsers_ChooseUsers
            '
            Me.RadioButtonSelectUsers_ChooseUsers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectUsers_ChooseUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectUsers_ChooseUsers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectUsers_ChooseUsers.Location = New System.Drawing.Point(123, 4)
            Me.RadioButtonSelectUsers_ChooseUsers.Name = "RadioButtonSelectUsers_ChooseUsers"
            Me.RadioButtonSelectUsers_ChooseUsers.SecurityEnabled = True
            Me.RadioButtonSelectUsers_ChooseUsers.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectUsers_ChooseUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectUsers_ChooseUsers.TabIndex = 1
            Me.RadioButtonSelectUsers_ChooseUsers.TabOnEnter = True
            Me.RadioButtonSelectUsers_ChooseUsers.TabStop = False
            Me.RadioButtonSelectUsers_ChooseUsers.Text = "Choose Users"
            '
            'TabItemJDA_SelectUsersTab
            '
            Me.TabItemJDA_SelectUsersTab.AttachedControl = Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses
            Me.TabItemJDA_SelectUsersTab.Name = "TabItemJDA_SelectUsersTab"
            Me.TabItemJDA_SelectUsersTab.Text = "Select Users"
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxFrom_IncludeTerminated)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_ShowOnlyAccessibleModules)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelGroupVersionAndOptions_ReportOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.GradientAngle = 90
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabIndex = 0
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabItem = Me.TabItemJDA_VersionAndOptionsTab
            '
            'CheckBoxFrom_IncludeTerminated
            '
            Me.CheckBoxFrom_IncludeTerminated.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxFrom_IncludeTerminated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrom_IncludeTerminated.CheckValue = 0
            Me.CheckBoxFrom_IncludeTerminated.CheckValueChecked = 1
            Me.CheckBoxFrom_IncludeTerminated.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrom_IncludeTerminated.CheckValueUnchecked = 0
            Me.CheckBoxFrom_IncludeTerminated.ChildControls = CType(resources.GetObject("CheckBoxFrom_IncludeTerminated.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrom_IncludeTerminated.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrom_IncludeTerminated.Location = New System.Drawing.Point(4, 59)
            Me.CheckBoxFrom_IncludeTerminated.Name = "CheckBoxFrom_IncludeTerminated"
            Me.CheckBoxFrom_IncludeTerminated.OldestSibling = Nothing
            Me.CheckBoxFrom_IncludeTerminated.SecurityEnabled = True
            Me.CheckBoxFrom_IncludeTerminated.SiblingControls = CType(resources.GetObject("CheckBoxFrom_IncludeTerminated.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrom_IncludeTerminated.Size = New System.Drawing.Size(189, 20)
            Me.CheckBoxFrom_IncludeTerminated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrom_IncludeTerminated.TabIndex = 36
            Me.CheckBoxFrom_IncludeTerminated.TabOnEnter = True
            Me.CheckBoxFrom_IncludeTerminated.Text = "Include Terminated Employees"
            '
            'CheckBoxForm_ShowOnlyAccessibleModules
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValue = 0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValueChecked = 1
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Location = New System.Drawing.Point(4, 33)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Name = "CheckBoxForm_ShowOnlyAccessibleModules"
            Me.CheckBoxForm_ShowOnlyAccessibleModules.OldestSibling = Nothing
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SecurityEnabled = True
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Size = New System.Drawing.Size(189, 20)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowOnlyAccessibleModules.TabIndex = 35
            Me.CheckBoxForm_ShowOnlyAccessibleModules.TabOnEnter = True
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Text = "Show Only Accessible Modules"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Options"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(737, 598)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabItemJDA_SelectJobsTab
            '
            Me.TabItemJDA_SelectJobsTab.AttachedControl = Me.TabControlPanelSelectJobsTab_SelectJobs
            Me.TabItemJDA_SelectJobsTab.Name = "TabItemJDA_SelectJobsTab"
            Me.TabItemJDA_SelectJobsTab.Text = "Select Jobs"
            '
            'TabControlPanelSelectJobsTab_SelectJobs
            '
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.PanelSelectJobs_JobStatus)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.DataGridViewSelectJobs_Jobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_AllJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Controls.Add(Me.RadioButtonSelectJobs_ChooseJobs)
            Me.TabControlPanelSelectJobsTab_SelectJobs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectJobsTab_SelectJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectJobsTab_SelectJobs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Name = "TabControlPanelSelectJobsTab_SelectJobs"
            Me.TabControlPanelSelectJobsTab_SelectJobs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Size = New System.Drawing.Size(800, 553)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectJobsTab_SelectJobs.Style.GradientAngle = 90
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabIndex = 0
            Me.TabControlPanelSelectJobsTab_SelectJobs.TabItem = Me.TabItemJDA_SelectJobsTab
            '
            'PanelSelectJobs_JobStatus
            '
            Me.PanelSelectJobs_JobStatus.BackColor = System.Drawing.Color.White
            Me.PanelSelectJobs_JobStatus.Enabled = False
            Me.PanelSelectJobs_JobStatus.Location = New System.Drawing.Point(4, 30)
            Me.PanelSelectJobs_JobStatus.Name = "PanelSelectJobs_JobStatus"
            Me.PanelSelectJobs_JobStatus.Size = New System.Drawing.Size(221, 20)
            Me.PanelSelectJobs_JobStatus.TabIndex = 2
            '
            'DataGridViewSelectJobs_Jobs
            '
            Me.DataGridViewSelectJobs_Jobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectJobs_Jobs.AllowDragAndDrop = False
            Me.DataGridViewSelectJobs_Jobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectJobs_Jobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectJobs_Jobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectJobs_Jobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectJobs_Jobs.AutoFilterLookupColumns = False
            Me.DataGridViewSelectJobs_Jobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectJobs_Jobs.AutoUpdateViewCaption = True
            Me.DataGridViewSelectJobs_Jobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectJobs_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectJobs_Jobs.Enabled = False
            Me.DataGridViewSelectJobs_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectJobs_Jobs.ItemDescription = "Job(s)"
            Me.DataGridViewSelectJobs_Jobs.Location = New System.Drawing.Point(4, 56)
            Me.DataGridViewSelectJobs_Jobs.MultiSelect = False
            Me.DataGridViewSelectJobs_Jobs.Name = "DataGridViewSelectJobs_Jobs"
            Me.DataGridViewSelectJobs_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectJobs_Jobs.RunStandardValidation = True
            Me.DataGridViewSelectJobs_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectJobs_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectJobs_Jobs.Size = New System.Drawing.Size(792, 493)
            Me.DataGridViewSelectJobs_Jobs.TabIndex = 3
            Me.DataGridViewSelectJobs_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewSelectJobs_Jobs.ViewCaptionHeight = -1
            '
            'RadioButtonSelectJobs_AllJobs
            '
            Me.RadioButtonSelectJobs_AllJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectJobs_AllJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectJobs_AllJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectJobs_AllJobs.Checked = True
            Me.RadioButtonSelectJobs_AllJobs.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectJobs_AllJobs.CheckValue = "Y"
            Me.RadioButtonSelectJobs_AllJobs.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectJobs_AllJobs.Name = "RadioButtonSelectJobs_AllJobs"
            Me.RadioButtonSelectJobs_AllJobs.SecurityEnabled = True
            Me.RadioButtonSelectJobs_AllJobs.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectJobs_AllJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectJobs_AllJobs.TabIndex = 0
            Me.RadioButtonSelectJobs_AllJobs.TabOnEnter = True
            '
            'RadioButtonSelectJobs_ChooseJobs
            '
            Me.RadioButtonSelectJobs_ChooseJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectJobs_ChooseJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectJobs_ChooseJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectJobs_ChooseJobs.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectJobs_ChooseJobs.Name = "RadioButtonSelectJobs_ChooseJobs"
            Me.RadioButtonSelectJobs_ChooseJobs.SecurityEnabled = True
            Me.RadioButtonSelectJobs_ChooseJobs.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectJobs_ChooseJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectJobs_ChooseJobs.TabIndex = 1
            Me.RadioButtonSelectJobs_ChooseJobs.TabOnEnter = True
            Me.RadioButtonSelectJobs_ChooseJobs.TabStop = False
            '
            'RadioButtonJobStatus_OpenClosedJobs
            '
            Me.RadioButtonJobStatus_OpenClosedJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobStatus_OpenClosedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobStatus_OpenClosedJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobStatus_OpenClosedJobs.Location = New System.Drawing.Point(83, 0)
            Me.RadioButtonJobStatus_OpenClosedJobs.Name = "RadioButtonJobStatus_OpenClosedJobs"
            Me.RadioButtonJobStatus_OpenClosedJobs.SecurityEnabled = True
            Me.RadioButtonJobStatus_OpenClosedJobs.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonJobStatus_OpenClosedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobStatus_OpenClosedJobs.TabIndex = 1
            Me.RadioButtonJobStatus_OpenClosedJobs.TabOnEnter = True
            Me.RadioButtonJobStatus_OpenClosedJobs.TabStop = False
            '
            'RadioButtonJobStatus_OpenJobs
            '
            Me.RadioButtonJobStatus_OpenJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobStatus_OpenJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobStatus_OpenJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobStatus_OpenJobs.Checked = True
            Me.RadioButtonJobStatus_OpenJobs.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonJobStatus_OpenJobs.CheckValue = "Y"
            Me.RadioButtonJobStatus_OpenJobs.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonJobStatus_OpenJobs.Name = "RadioButtonJobStatus_OpenJobs"
            Me.RadioButtonJobStatus_OpenJobs.SecurityEnabled = True
            Me.RadioButtonJobStatus_OpenJobs.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonJobStatus_OpenJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobStatus_OpenJobs.TabIndex = 0
            Me.RadioButtonJobStatus_OpenJobs.TabOnEnter = True
            '
            'ButtonForm_View
            '
            Me.ButtonForm_View.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_View.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_View.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_View.Location = New System.Drawing.Point(656, 598)
            Me.ButtonForm_View.Name = "ButtonForm_View"
            Me.ButtonForm_View.SecurityEnabled = True
            Me.ButtonForm_View.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_View.TabIndex = 10
            Me.ButtonForm_View.Text = "View"
            '
            'SecurityInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(824, 630)
            Me.Controls.Add(Me.ButtonForm_View)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TabControlForm_JDA)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SecurityInitialLoadingDialog"
            Me.Text = "Security"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanelSelectSalesClassesTab_SelectSalesClasses.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.TabControlPanelSelectJobsTab_SelectJobs.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_ViewReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelGroupVersionAndOptions_ReportOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_JDA As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_SelectGroupsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RadioButtonSelectGroups_AllGroups As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectGroups_ChooseGroups As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSelectGroups_Groups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelSelectSalesClassesTab_SelectSalesClasses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectUsers_Users As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectUsers_AllUsers As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectUsers_ChooseUsers As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectUsersTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabItemJDA_SelectJobsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectJobsTab_SelectJobs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSelectJobs_JobStatus As Windows.Forms.Panel
        Friend WithEvents DataGridViewSelectJobs_Jobs As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectJobs_AllJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectJobs_ChooseJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenClosedJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonJobStatus_OpenJobs As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonForm_View As WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxFrom_IncludeTerminated As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ShowOnlyAccessibleModules As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace