Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TimesheetControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewForm_TimesheetEntries = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandablePanelControl_Options = New DevComponents.DotNetBar.ExpandablePanel()
            Me.TabControlOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOptions_CopyFromTimesheetTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewCopyFromProject_ProjectTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOptions_CopyFromProjectTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate = New DevComponents.DotNetBar.TabControlPanel()
            Me.ComboBoxCopyFromTemplate_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelCopyFromTemplate_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewCopyFromTemplate_Templates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOptions_CopyFromTemplateTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControlControl_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.ToolTipControllerControl_ToolTip = New DevExpress.Utils.ToolTipController(Me.components)
            Me.ExpandablePanelControl_Options.SuspendLayout()
            CType(Me.TabControlOptions_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlOptions_Options.SuspendLayout()
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.SuspendLayout()
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.SuspendLayout()
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_TimesheetEntries
            '
            Me.DataGridViewForm_TimesheetEntries.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_TimesheetEntries.AllowDragAndDrop = False
            Me.DataGridViewForm_TimesheetEntries.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_TimesheetEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_TimesheetEntries.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_TimesheetEntries.AutoFilterLookupColumns = False
            Me.DataGridViewForm_TimesheetEntries.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_TimesheetEntries.AutoUpdateViewCaption = True
            Me.DataGridViewForm_TimesheetEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_TimesheetEntries.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_TimesheetEntries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_TimesheetEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_TimesheetEntries.ItemDescription = ""
            Me.DataGridViewForm_TimesheetEntries.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_TimesheetEntries.MultiSelect = True
            Me.DataGridViewForm_TimesheetEntries.Name = "DataGridViewForm_TimesheetEntries"
            Me.DataGridViewForm_TimesheetEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_TimesheetEntries.RunStandardValidation = True
            Me.DataGridViewForm_TimesheetEntries.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_TimesheetEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_TimesheetEntries.Size = New System.Drawing.Size(743, 226)
            Me.DataGridViewForm_TimesheetEntries.TabIndex = 4
            Me.DataGridViewForm_TimesheetEntries.UseEmbeddedNavigator = False
            Me.DataGridViewForm_TimesheetEntries.ViewCaptionHeight = -1
            '
            'ExpandablePanelControl_Options
            '
            Me.ExpandablePanelControl_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_Options.Controls.Add(Me.TabControlOptions_Options)
            Me.ExpandablePanelControl_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelControl_Options.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ExpandablePanelControl_Options.HideControlsWhenCollapsed = True
            Me.ExpandablePanelControl_Options.Location = New System.Drawing.Point(0, 232)
            Me.ExpandablePanelControl_Options.Name = "ExpandablePanelControl_Options"
            Me.ExpandablePanelControl_Options.Size = New System.Drawing.Size(743, 170)
            Me.ExpandablePanelControl_Options.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_Options.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_Options.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_Options.Style.GradientAngle = 90
            Me.ExpandablePanelControl_Options.TabIndex = 16
            Me.ExpandablePanelControl_Options.TextDockConstrained = False
            Me.ExpandablePanelControl_Options.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_Options.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_Options.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_Options.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_Options.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_Options.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_Options.TitleText = "Options"
            '
            'TabControlOptions_Options
            '
            Me.TabControlOptions_Options.CanReorderTabs = True
            Me.TabControlOptions_Options.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlOptions_Options.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlOptions_Options.Controls.Add(Me.TabControlPanelCopyFromProjectTab_CopyFromProject)
            Me.TabControlOptions_Options.Controls.Add(Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet)
            Me.TabControlOptions_Options.Controls.Add(Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate)
            Me.TabControlOptions_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlOptions_Options.Location = New System.Drawing.Point(0, 26)
            Me.TabControlOptions_Options.Name = "TabControlOptions_Options"
            Me.TabControlOptions_Options.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlOptions_Options.SelectedTabIndex = 0
            Me.TabControlOptions_Options.Size = New System.Drawing.Size(743, 144)
            Me.TabControlOptions_Options.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlOptions_Options.TabIndex = 2
            Me.TabControlOptions_Options.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlOptions_Options.Tabs.Add(Me.TabItemOptions_CopyFromTimesheetTab)
            Me.TabControlOptions_Options.Tabs.Add(Me.TabItemOptions_CopyFromProjectTab)
            Me.TabControlOptions_Options.Tabs.Add(Me.TabItemOptions_CopyFromTemplateTab)
            Me.TabControlOptions_Options.Text = "TabControl1"
            '
            'TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet
            '
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Controls.Add(Me.DataGridViewCopyFromTimesheet_TimesheetTemplates)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Name = "TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet"
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Size = New System.Drawing.Size(743, 117)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.Style.GradientAngle = 90
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.TabIndex = 1
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.TabItem = Me.TabItemOptions_CopyFromTimesheetTab
            '
            'DataGridViewCopyFromTimesheet_TimesheetTemplates
            '
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AllowDragAndDrop = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.ItemDescription = "Item(s)"
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.MultiSelect = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.Name = "DataGridViewCopyFromTimesheet_TimesheetTemplates"
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.RunStandardValidation = True
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.Size = New System.Drawing.Size(735, 109)
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.TabIndex = 1
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewCopyFromTimesheet_TimesheetTemplates.ViewCaptionHeight = -1
            '
            'TabItemOptions_CopyFromTimesheetTab
            '
            Me.TabItemOptions_CopyFromTimesheetTab.AttachedControl = Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet
            Me.TabItemOptions_CopyFromTimesheetTab.Name = "TabItemOptions_CopyFromTimesheetTab"
            Me.TabItemOptions_CopyFromTimesheetTab.Text = "Copy from Timesheet"
            '
            'TabControlPanelCopyFromProjectTab_CopyFromProject
            '
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Controls.Add(Me.DataGridViewCopyFromProject_ProjectTemplates)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Name = "TabControlPanelCopyFromProjectTab_CopyFromProject"
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Size = New System.Drawing.Size(743, 117)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.Style.GradientAngle = 90
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.TabIndex = 2
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.TabItem = Me.TabItemOptions_CopyFromProjectTab
            '
            'DataGridViewCopyFromProject_ProjectTemplates
            '
            Me.DataGridViewCopyFromProject_ProjectTemplates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.AllowDragAndDrop = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCopyFromProject_ProjectTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCopyFromProject_ProjectTemplates.DataSource = Nothing
            Me.DataGridViewCopyFromProject_ProjectTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCopyFromProject_ProjectTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCopyFromProject_ProjectTemplates.ItemDescription = "Item(s)"
            Me.DataGridViewCopyFromProject_ProjectTemplates.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewCopyFromProject_ProjectTemplates.MultiSelect = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.Name = "DataGridViewCopyFromProject_ProjectTemplates"
            Me.DataGridViewCopyFromProject_ProjectTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCopyFromProject_ProjectTemplates.RunStandardValidation = True
            Me.DataGridViewCopyFromProject_ProjectTemplates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.Size = New System.Drawing.Size(735, 109)
            Me.DataGridViewCopyFromProject_ProjectTemplates.TabIndex = 2
            Me.DataGridViewCopyFromProject_ProjectTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewCopyFromProject_ProjectTemplates.ViewCaptionHeight = -1
            '
            'TabItemOptions_CopyFromProjectTab
            '
            Me.TabItemOptions_CopyFromProjectTab.AttachedControl = Me.TabControlPanelCopyFromProjectTab_CopyFromProject
            Me.TabItemOptions_CopyFromProjectTab.Name = "TabItemOptions_CopyFromProjectTab"
            Me.TabItemOptions_CopyFromProjectTab.Text = "Copy from My Projects"
            '
            'TabControlPanelCopyFromTemplateTab_CopyFromTemplate
            '
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Controls.Add(Me.ComboBoxCopyFromTemplate_GroupBy)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Controls.Add(Me.LabelCopyFromTemplate_GroupBy)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Controls.Add(Me.DataGridViewCopyFromTemplate_Templates)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Name = "TabControlPanelCopyFromTemplateTab_CopyFromTemplate"
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Size = New System.Drawing.Size(743, 117)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.Style.GradientAngle = 90
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.TabIndex = 3
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.TabItem = Me.TabItemOptions_CopyFromTemplateTab
            '
            'ComboBoxCopyFromTemplate_GroupBy
            '
            Me.ComboBoxCopyFromTemplate_GroupBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCopyFromTemplate_GroupBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCopyFromTemplate_GroupBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCopyFromTemplate_GroupBy.AutoFindItemInDataSource = False
            Me.ComboBoxCopyFromTemplate_GroupBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCopyFromTemplate_GroupBy.BookmarkingEnabled = False
            Me.ComboBoxCopyFromTemplate_GroupBy.ClientCode = ""
            Me.ComboBoxCopyFromTemplate_GroupBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxCopyFromTemplate_GroupBy.DisableMouseWheel = False
            Me.ComboBoxCopyFromTemplate_GroupBy.DisplayMember = "Description"
            Me.ComboBoxCopyFromTemplate_GroupBy.DisplayName = ""
            Me.ComboBoxCopyFromTemplate_GroupBy.DivisionCode = ""
            Me.ComboBoxCopyFromTemplate_GroupBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCopyFromTemplate_GroupBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCopyFromTemplate_GroupBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxCopyFromTemplate_GroupBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCopyFromTemplate_GroupBy.FocusHighlightEnabled = True
            Me.ComboBoxCopyFromTemplate_GroupBy.FormattingEnabled = True
            Me.ComboBoxCopyFromTemplate_GroupBy.ItemHeight = 14
            Me.ComboBoxCopyFromTemplate_GroupBy.Location = New System.Drawing.Point(69, 4)
            Me.ComboBoxCopyFromTemplate_GroupBy.Name = "ComboBoxCopyFromTemplate_GroupBy"
            Me.ComboBoxCopyFromTemplate_GroupBy.ReadOnly = False
            Me.ComboBoxCopyFromTemplate_GroupBy.SecurityEnabled = True
            Me.ComboBoxCopyFromTemplate_GroupBy.Size = New System.Drawing.Size(252, 20)
            Me.ComboBoxCopyFromTemplate_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCopyFromTemplate_GroupBy.TabIndex = 20
            Me.ComboBoxCopyFromTemplate_GroupBy.TabOnEnter = True
            Me.ComboBoxCopyFromTemplate_GroupBy.ValueMember = "Code"
            Me.ComboBoxCopyFromTemplate_GroupBy.WatermarkText = "Select"
            '
            'LabelCopyFromTemplate_GroupBy
            '
            Me.LabelCopyFromTemplate_GroupBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCopyFromTemplate_GroupBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCopyFromTemplate_GroupBy.Location = New System.Drawing.Point(4, 4)
            Me.LabelCopyFromTemplate_GroupBy.Name = "LabelCopyFromTemplate_GroupBy"
            Me.LabelCopyFromTemplate_GroupBy.Size = New System.Drawing.Size(59, 20)
            Me.LabelCopyFromTemplate_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCopyFromTemplate_GroupBy.TabIndex = 19
            Me.LabelCopyFromTemplate_GroupBy.Text = "Group By:"
            '
            'DataGridViewCopyFromTemplate_Templates
            '
            Me.DataGridViewCopyFromTemplate_Templates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewCopyFromTemplate_Templates.AllowDragAndDrop = False
            Me.DataGridViewCopyFromTemplate_Templates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCopyFromTemplate_Templates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCopyFromTemplate_Templates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCopyFromTemplate_Templates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCopyFromTemplate_Templates.AutoFilterLookupColumns = False
            Me.DataGridViewCopyFromTemplate_Templates.AutoloadRepositoryDatasource = True
            Me.DataGridViewCopyFromTemplate_Templates.AutoUpdateViewCaption = True
            Me.DataGridViewCopyFromTemplate_Templates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCopyFromTemplate_Templates.DataSource = Nothing
            Me.DataGridViewCopyFromTemplate_Templates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCopyFromTemplate_Templates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCopyFromTemplate_Templates.ItemDescription = "Item(s)"
            Me.DataGridViewCopyFromTemplate_Templates.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewCopyFromTemplate_Templates.MultiSelect = True
            Me.DataGridViewCopyFromTemplate_Templates.Name = "DataGridViewCopyFromTemplate_Templates"
            Me.DataGridViewCopyFromTemplate_Templates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCopyFromTemplate_Templates.RunStandardValidation = True
            Me.DataGridViewCopyFromTemplate_Templates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewCopyFromTemplate_Templates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCopyFromTemplate_Templates.Size = New System.Drawing.Size(735, 83)
            Me.DataGridViewCopyFromTemplate_Templates.TabIndex = 2
            Me.DataGridViewCopyFromTemplate_Templates.UseEmbeddedNavigator = False
            Me.DataGridViewCopyFromTemplate_Templates.ViewCaptionHeight = -1
            '
            'TabItemOptions_CopyFromTemplateTab
            '
            Me.TabItemOptions_CopyFromTemplateTab.AttachedControl = Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate
            Me.TabItemOptions_CopyFromTemplateTab.Name = "TabItemOptions_CopyFromTemplateTab"
            Me.TabItemOptions_CopyFromTemplateTab.Text = "Copy from Template"
            '
            'ExpandableSplitterControlControl_TopBottom
            '
            Me.ExpandableSplitterControlControl_TopBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlControl_TopBottom.Cursor = System.Windows.Forms.Cursors.HSplit
            Me.ExpandableSplitterControlControl_TopBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ExpandableSplitterControlControl_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlControl_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlControl_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlControl_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlControl_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlControl_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlControl_TopBottom.Location = New System.Drawing.Point(0, 226)
            Me.ExpandableSplitterControlControl_TopBottom.Name = "ExpandableSplitterControlControl_TopBottom"
            Me.ExpandableSplitterControlControl_TopBottom.Size = New System.Drawing.Size(743, 6)
            Me.ExpandableSplitterControlControl_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlControl_TopBottom.TabIndex = 17
            Me.ExpandableSplitterControlControl_TopBottom.TabStop = False
            '
            'ToolTipControllerControl_ToolTip
            '
            '
            'TimesheetControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_TimesheetEntries)
            Me.Controls.Add(Me.ExpandableSplitterControlControl_TopBottom)
            Me.Controls.Add(Me.ExpandablePanelControl_Options)
            Me.Name = "TimesheetControl"
            Me.Size = New System.Drawing.Size(743, 402)
            Me.ExpandablePanelControl_Options.ResumeLayout(False)
            CType(Me.TabControlOptions_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlOptions_Options.ResumeLayout(False)
            Me.TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet.ResumeLayout(False)
            Me.TabControlPanelCopyFromProjectTab_CopyFromProject.ResumeLayout(False)
            Me.TabControlPanelCopyFromTemplateTab_CopyFromTemplate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_TimesheetEntries As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandablePanelControl_Options As DevComponents.DotNetBar.ExpandablePanel
        Friend WithEvents TabControlOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelCopyFromTimesheetTab_CopyFromTimesheet As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewCopyFromTimesheet_TimesheetTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemOptions_CopyFromTimesheetTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCopyFromProjectTab_CopyFromProject As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewCopyFromProject_ProjectTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemOptions_CopyFromProjectTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCopyFromTemplateTab_CopyFromTemplate As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewCopyFromTemplate_Templates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemOptions_CopyFromTemplateTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterControlControl_TopBottom As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents LabelCopyFromTemplate_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxCopyFromTemplate_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Private WithEvents ToolTipControllerControl_ToolTip As DevExpress.Utils.ToolTipController

    End Class

End Namespace
