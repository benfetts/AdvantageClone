Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleTaskSelectionDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleTaskSelectionDialog))
            Me.DataGridViewTemplates_Tasks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelTemplates_TaskTemplates = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelTaskTemplates_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelTaskTemplates_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewTemplates_TaskTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelTop_WorkingDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTop_JobDueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarDetails_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_Tasks = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelEstimatesTab_Estimate = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxEstimate_IncludeHours = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxEstimate_IncludeEmployees = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewEstimate_Tasks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemTasks_EstimatesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTasks_Tasks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemTasks_AvailableTasksTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates = New DevComponents.DotNetBar.TabControlPanel()
            Me.RadioButtonControlTemplates_Rush = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlTemplates_Standard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemTasks_TaskTemplatesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarOptions_Templates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplates_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelTop_WorkingDaysLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTop_JobDueDateLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelTemplates_TaskTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTemplates_TaskTemplates.SuspendLayout()
            CType(Me.PanelTaskTemplates_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTaskTemplates_RightSection.SuspendLayout()
            CType(Me.PanelTaskTemplates_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTaskTemplates_LeftSection.SuspendLayout()
            CType(Me.TabControlForm_Tasks, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Tasks.SuspendLayout()
            Me.TabControlPanelEstimatesTab_Estimate.SuspendLayout()
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.SuspendLayout()
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(772, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Templates)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarDetails_Options)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(772, 95)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Templates, 0)
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
            Me.PanelForm_Form.Controls.Add(Me.LabelTop_JobDueDateLbl)
            Me.PanelForm_Form.Controls.Add(Me.LabelTop_WorkingDaysLbl)
            Me.PanelForm_Form.Controls.Add(Me.LabelTop_WorkingDays)
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_Tasks)
            Me.PanelForm_Form.Controls.Add(Me.LabelTop_JobDueDate)
            Me.PanelForm_Form.Size = New System.Drawing.Size(772, 338)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 493)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(772, 18)
            '
            'DataGridViewTemplates_Tasks
            '
            Me.DataGridViewTemplates_Tasks.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTemplates_Tasks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTemplates_Tasks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTemplates_Tasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTemplates_Tasks.AutoFilterLookupColumns = False
            Me.DataGridViewTemplates_Tasks.AutoloadRepositoryDatasource = True
            Me.DataGridViewTemplates_Tasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTemplates_Tasks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTemplates_Tasks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTemplates_Tasks.ItemDescription = "Task(s)"
            Me.DataGridViewTemplates_Tasks.Location = New System.Drawing.Point(6, 0)
            Me.DataGridViewTemplates_Tasks.MultiSelect = True
            Me.DataGridViewTemplates_Tasks.Name = "DataGridViewTemplates_Tasks"
            Me.DataGridViewTemplates_Tasks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTemplates_Tasks.RunStandardValidation = True
            Me.DataGridViewTemplates_Tasks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTemplates_Tasks.Size = New System.Drawing.Size(565, 239)
            Me.DataGridViewTemplates_Tasks.TabIndex = 0
            Me.DataGridViewTemplates_Tasks.UseEmbeddedNavigator = False
            Me.DataGridViewTemplates_Tasks.ViewCaptionHeight = -1
            '
            'PanelTemplates_TaskTemplates
            '
            Me.PanelTemplates_TaskTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTemplates_TaskTemplates.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTemplates_TaskTemplates.Controls.Add(Me.PanelTaskTemplates_RightSection)
            Me.PanelTemplates_TaskTemplates.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.PanelTemplates_TaskTemplates.Controls.Add(Me.PanelTaskTemplates_LeftSection)
            Me.PanelTemplates_TaskTemplates.Location = New System.Drawing.Point(4, 30)
            Me.PanelTemplates_TaskTemplates.Name = "PanelTemplates_TaskTemplates"
            Me.PanelTemplates_TaskTemplates.Size = New System.Drawing.Size(758, 239)
            Me.PanelTemplates_TaskTemplates.TabIndex = 11
            '
            'PanelTaskTemplates_RightSection
            '
            Me.PanelTaskTemplates_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTaskTemplates_RightSection.Controls.Add(Me.DataGridViewTemplates_Tasks)
            Me.PanelTaskTemplates_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTaskTemplates_RightSection.Location = New System.Drawing.Point(187, 0)
            Me.PanelTaskTemplates_RightSection.Name = "PanelTaskTemplates_RightSection"
            Me.PanelTaskTemplates_RightSection.Size = New System.Drawing.Size(571, 239)
            Me.PanelTaskTemplates_RightSection.TabIndex = 14
            '
            'ExpandableSplitterControl_LeftRight
            '
            Me.ExpandableSplitterControl_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.Location = New System.Drawing.Point(181, 0)
            Me.ExpandableSplitterControl_LeftRight.Name = "ExpandableSplitterControl_LeftRight"
            Me.ExpandableSplitterControl_LeftRight.Size = New System.Drawing.Size(6, 239)
            Me.ExpandableSplitterControl_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl_LeftRight.TabIndex = 13
            Me.ExpandableSplitterControl_LeftRight.TabStop = False
            '
            'PanelTaskTemplates_LeftSection
            '
            Me.PanelTaskTemplates_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelTaskTemplates_LeftSection.Controls.Add(Me.DataGridViewTemplates_TaskTemplates)
            Me.PanelTaskTemplates_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelTaskTemplates_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelTaskTemplates_LeftSection.Name = "PanelTaskTemplates_LeftSection"
            Me.PanelTaskTemplates_LeftSection.Size = New System.Drawing.Size(181, 239)
            Me.PanelTaskTemplates_LeftSection.TabIndex = 12
            '
            'DataGridViewTemplates_TaskTemplates
            '
            Me.DataGridViewTemplates_TaskTemplates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTemplates_TaskTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTemplates_TaskTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTemplates_TaskTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTemplates_TaskTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewTemplates_TaskTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewTemplates_TaskTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewTemplates_TaskTemplates.DataSource = Nothing
            Me.DataGridViewTemplates_TaskTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTemplates_TaskTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTemplates_TaskTemplates.ItemDescription = "Item(s)"
            Me.DataGridViewTemplates_TaskTemplates.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewTemplates_TaskTemplates.MultiSelect = True
            Me.DataGridViewTemplates_TaskTemplates.Name = "DataGridViewTemplates_TaskTemplates"
            Me.DataGridViewTemplates_TaskTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTemplates_TaskTemplates.RunStandardValidation = True
            Me.DataGridViewTemplates_TaskTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTemplates_TaskTemplates.Size = New System.Drawing.Size(175, 239)
            Me.DataGridViewTemplates_TaskTemplates.TabIndex = 0
            Me.DataGridViewTemplates_TaskTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewTemplates_TaskTemplates.ViewCaptionHeight = -1
            '
            'LabelTop_WorkingDays
            '
            Me.LabelTop_WorkingDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTop_WorkingDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTop_WorkingDays.Location = New System.Drawing.Point(181, 6)
            Me.LabelTop_WorkingDays.Name = "LabelTop_WorkingDays"
            Me.LabelTop_WorkingDays.Size = New System.Drawing.Size(75, 20)
            Me.LabelTop_WorkingDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTop_WorkingDays.TabIndex = 2
            Me.LabelTop_WorkingDays.Text = "Working Days:"
            '
            'LabelTop_JobDueDate
            '
            Me.LabelTop_JobDueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTop_JobDueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTop_JobDueDate.Location = New System.Drawing.Point(3, 6)
            Me.LabelTop_JobDueDate.Name = "LabelTop_JobDueDate"
            Me.LabelTop_JobDueDate.Size = New System.Drawing.Size(75, 20)
            Me.LabelTop_JobDueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTop_JobDueDate.TabIndex = 0
            Me.LabelTop_JobDueDate.Text = "Job Due Date:"
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
            Me.RibbonBarDetails_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add})
            Me.RibbonBarDetails_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarDetails_Options.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarDetails_Options.Name = "RibbonBarDetails_Options"
            Me.RibbonBarDetails_Options.Size = New System.Drawing.Size(57, 92)
            Me.RibbonBarDetails_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarDetails_Options.TabIndex = 5
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
            'TabControlForm_Tasks
            '
            Me.TabControlForm_Tasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Tasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Tasks.CanReorderTabs = True
            Me.TabControlForm_Tasks.Controls.Add(Me.TabControlPanelEstimatesTab_Estimate)
            Me.TabControlForm_Tasks.Controls.Add(Me.TabControlPanelTaskTemplatesTab_TaskTemplates)
            Me.TabControlForm_Tasks.Controls.Add(Me.TabControlPanelAvailableTasksTab_AvailableTasks)
            Me.TabControlForm_Tasks.Location = New System.Drawing.Point(3, 32)
            Me.TabControlForm_Tasks.Name = "TabControlForm_Tasks"
            Me.TabControlForm_Tasks.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Tasks.SelectedTabIndex = 1
            Me.TabControlForm_Tasks.Size = New System.Drawing.Size(766, 300)
            Me.TabControlForm_Tasks.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Tasks.TabIndex = 12
            Me.TabControlForm_Tasks.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Tasks.Tabs.Add(Me.TabItemTasks_AvailableTasksTab)
            Me.TabControlForm_Tasks.Tabs.Add(Me.TabItemTasks_TaskTemplatesTab)
            Me.TabControlForm_Tasks.Tabs.Add(Me.TabItemTasks_EstimatesTab)
            Me.TabControlForm_Tasks.Text = "TabControl1"
            '
            'TabControlPanelEstimatesTab_Estimate
            '
            Me.TabControlPanelEstimatesTab_Estimate.Controls.Add(Me.CheckBoxEstimate_IncludeHours)
            Me.TabControlPanelEstimatesTab_Estimate.Controls.Add(Me.CheckBoxEstimate_IncludeEmployees)
            Me.TabControlPanelEstimatesTab_Estimate.Controls.Add(Me.DataGridViewEstimate_Tasks)
            Me.TabControlPanelEstimatesTab_Estimate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEstimatesTab_Estimate.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEstimatesTab_Estimate.Name = "TabControlPanelEstimatesTab_Estimate"
            Me.TabControlPanelEstimatesTab_Estimate.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEstimatesTab_Estimate.Size = New System.Drawing.Size(766, 273)
            Me.TabControlPanelEstimatesTab_Estimate.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimate.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEstimatesTab_Estimate.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEstimatesTab_Estimate.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEstimatesTab_Estimate.Style.GradientAngle = 90
            Me.TabControlPanelEstimatesTab_Estimate.TabIndex = 3
            Me.TabControlPanelEstimatesTab_Estimate.TabItem = Me.TabItemTasks_EstimatesTab
            '
            'CheckBoxEstimate_IncludeHours
            '
            Me.CheckBoxEstimate_IncludeHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxEstimate_IncludeHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimate_IncludeHours.CheckValue = 0
            Me.CheckBoxEstimate_IncludeHours.CheckValueChecked = 1
            Me.CheckBoxEstimate_IncludeHours.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxEstimate_IncludeHours.CheckValueUnchecked = 0
            Me.CheckBoxEstimate_IncludeHours.ChildControls = CType(resources.GetObject("CheckBoxEstimate_IncludeHours.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimate_IncludeHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimate_IncludeHours.Location = New System.Drawing.Point(245, 4)
            Me.CheckBoxEstimate_IncludeHours.Name = "CheckBoxEstimate_IncludeHours"
            Me.CheckBoxEstimate_IncludeHours.OldestSibling = Nothing
            Me.CheckBoxEstimate_IncludeHours.SecurityEnabled = True
            Me.CheckBoxEstimate_IncludeHours.SiblingControls = CType(resources.GetObject("CheckBoxEstimate_IncludeHours.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimate_IncludeHours.Size = New System.Drawing.Size(235, 20)
            Me.CheckBoxEstimate_IncludeHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimate_IncludeHours.TabIndex = 2
            Me.CheckBoxEstimate_IncludeHours.Text = "Include hours assigned to functions"
            '
            'CheckBoxEstimate_IncludeEmployees
            '
            Me.CheckBoxEstimate_IncludeEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxEstimate_IncludeEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimate_IncludeEmployees.CheckValue = 0
            Me.CheckBoxEstimate_IncludeEmployees.CheckValueChecked = 1
            Me.CheckBoxEstimate_IncludeEmployees.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxEstimate_IncludeEmployees.CheckValueUnchecked = 0
            Me.CheckBoxEstimate_IncludeEmployees.ChildControls = CType(resources.GetObject("CheckBoxEstimate_IncludeEmployees.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimate_IncludeEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimate_IncludeEmployees.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxEstimate_IncludeEmployees.Name = "CheckBoxEstimate_IncludeEmployees"
            Me.CheckBoxEstimate_IncludeEmployees.OldestSibling = Nothing
            Me.CheckBoxEstimate_IncludeEmployees.SecurityEnabled = True
            Me.CheckBoxEstimate_IncludeEmployees.SiblingControls = CType(resources.GetObject("CheckBoxEstimate_IncludeEmployees.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimate_IncludeEmployees.Size = New System.Drawing.Size(235, 20)
            Me.CheckBoxEstimate_IncludeEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimate_IncludeEmployees.TabIndex = 1
            Me.CheckBoxEstimate_IncludeEmployees.Text = "Include employees assigned to functions"
            '
            'DataGridViewEstimate_Tasks
            '
            Me.DataGridViewEstimate_Tasks.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEstimate_Tasks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEstimate_Tasks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEstimate_Tasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEstimate_Tasks.AutoFilterLookupColumns = False
            Me.DataGridViewEstimate_Tasks.AutoloadRepositoryDatasource = True
            Me.DataGridViewEstimate_Tasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewEstimate_Tasks.DataSource = Nothing
            Me.DataGridViewEstimate_Tasks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEstimate_Tasks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEstimate_Tasks.ItemDescription = "Item(s)"
            Me.DataGridViewEstimate_Tasks.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewEstimate_Tasks.MultiSelect = True
            Me.DataGridViewEstimate_Tasks.Name = "DataGridViewEstimate_Tasks"
            Me.DataGridViewEstimate_Tasks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEstimate_Tasks.RunStandardValidation = True
            Me.DataGridViewEstimate_Tasks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEstimate_Tasks.Size = New System.Drawing.Size(758, 239)
            Me.DataGridViewEstimate_Tasks.TabIndex = 0
            Me.DataGridViewEstimate_Tasks.UseEmbeddedNavigator = False
            Me.DataGridViewEstimate_Tasks.ViewCaptionHeight = -1
            '
            'TabItemTasks_EstimatesTab
            '
            Me.TabItemTasks_EstimatesTab.AttachedControl = Me.TabControlPanelEstimatesTab_Estimate
            Me.TabItemTasks_EstimatesTab.Name = "TabItemTasks_EstimatesTab"
            Me.TabItemTasks_EstimatesTab.Text = "Estimate"
            '
            'TabControlPanelAvailableTasksTab_AvailableTasks
            '
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Controls.Add(Me.DataGridViewTasks_Tasks)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Name = "TabControlPanelAvailableTasksTab_AvailableTasks"
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Size = New System.Drawing.Size(766, 273)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.Style.GradientAngle = 90
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.TabIndex = 1
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.TabItem = Me.TabItemTasks_AvailableTasksTab
            '
            'DataGridViewTasks_Tasks
            '
            Me.DataGridViewTasks_Tasks.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTasks_Tasks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTasks_Tasks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTasks_Tasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTasks_Tasks.AutoFilterLookupColumns = False
            Me.DataGridViewTasks_Tasks.AutoloadRepositoryDatasource = True
            Me.DataGridViewTasks_Tasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTasks_Tasks.DataSource = Nothing
            Me.DataGridViewTasks_Tasks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTasks_Tasks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTasks_Tasks.ItemDescription = "Task(s)"
            Me.DataGridViewTasks_Tasks.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewTasks_Tasks.MultiSelect = True
            Me.DataGridViewTasks_Tasks.Name = "DataGridViewTasks_Tasks"
            Me.DataGridViewTasks_Tasks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTasks_Tasks.RunStandardValidation = True
            Me.DataGridViewTasks_Tasks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTasks_Tasks.Size = New System.Drawing.Size(758, 265)
            Me.DataGridViewTasks_Tasks.TabIndex = 1
            Me.DataGridViewTasks_Tasks.UseEmbeddedNavigator = False
            Me.DataGridViewTasks_Tasks.ViewCaptionHeight = -1
            '
            'TabItemTasks_AvailableTasksTab
            '
            Me.TabItemTasks_AvailableTasksTab.AttachedControl = Me.TabControlPanelAvailableTasksTab_AvailableTasks
            Me.TabItemTasks_AvailableTasksTab.Name = "TabItemTasks_AvailableTasksTab"
            Me.TabItemTasks_AvailableTasksTab.Text = "Tasks"
            '
            'TabControlPanelTaskTemplatesTab_TaskTemplates
            '
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Controls.Add(Me.RadioButtonControlTemplates_Rush)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Controls.Add(Me.RadioButtonControlTemplates_Standard)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Controls.Add(Me.PanelTemplates_TaskTemplates)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Name = "TabControlPanelTaskTemplatesTab_TaskTemplates"
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Size = New System.Drawing.Size(766, 273)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.Style.GradientAngle = 90
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.TabIndex = 2
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.TabItem = Me.TabItemTasks_TaskTemplatesTab
            '
            'RadioButtonControlTemplates_Rush
            '
            Me.RadioButtonControlTemplates_Rush.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTemplates_Rush.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTemplates_Rush.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTemplates_Rush.Location = New System.Drawing.Point(81, 4)
            Me.RadioButtonControlTemplates_Rush.Name = "RadioButtonControlTemplates_Rush"
            Me.RadioButtonControlTemplates_Rush.SecurityEnabled = True
            Me.RadioButtonControlTemplates_Rush.Size = New System.Drawing.Size(71, 20)
            Me.RadioButtonControlTemplates_Rush.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTemplates_Rush.TabIndex = 14
            Me.RadioButtonControlTemplates_Rush.TabStop = False
            Me.RadioButtonControlTemplates_Rush.Text = "Rush"
            '
            'RadioButtonControlTemplates_Standard
            '
            Me.RadioButtonControlTemplates_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTemplates_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTemplates_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTemplates_Standard.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonControlTemplates_Standard.Name = "RadioButtonControlTemplates_Standard"
            Me.RadioButtonControlTemplates_Standard.SecurityEnabled = True
            Me.RadioButtonControlTemplates_Standard.Size = New System.Drawing.Size(71, 20)
            Me.RadioButtonControlTemplates_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTemplates_Standard.TabIndex = 13
            Me.RadioButtonControlTemplates_Standard.TabStop = False
            Me.RadioButtonControlTemplates_Standard.Text = "Standard"
            '
            'TabItemTasks_TaskTemplatesTab
            '
            Me.TabItemTasks_TaskTemplatesTab.AttachedControl = Me.TabControlPanelTaskTemplatesTab_TaskTemplates
            Me.TabItemTasks_TaskTemplatesTab.Name = "TabItemTasks_TaskTemplatesTab"
            Me.TabItemTasks_TaskTemplatesTab.Text = "Templates"
            '
            'RibbonBarOptions_Templates
            '
            Me.RibbonBarOptions_Templates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Templates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Templates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplates_Add})
            Me.RibbonBarOptions_Templates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Templates.Location = New System.Drawing.Point(160, 0)
            Me.RibbonBarOptions_Templates.Name = "RibbonBarOptions_Templates"
            Me.RibbonBarOptions_Templates.Size = New System.Drawing.Size(57, 92)
            Me.RibbonBarOptions_Templates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Templates.TabIndex = 6
            Me.RibbonBarOptions_Templates.Text = "Templates"
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemTemplates_Add
            '
            Me.ButtonItemTemplates_Add.BeginGroup = True
            Me.ButtonItemTemplates_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Add.Name = "ButtonItemTemplates_Add"
            Me.ButtonItemTemplates_Add.RibbonWordWrap = False
            Me.ButtonItemTemplates_Add.SecurityEnabled = True
            Me.ButtonItemTemplates_Add.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Add.Text = "New"
            '
            'LabelTop_WorkingDaysLbl
            '
            Me.LabelTop_WorkingDaysLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTop_WorkingDaysLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTop_WorkingDaysLbl.Location = New System.Drawing.Point(262, 6)
            Me.LabelTop_WorkingDaysLbl.Name = "LabelTop_WorkingDaysLbl"
            Me.LabelTop_WorkingDaysLbl.Size = New System.Drawing.Size(91, 20)
            Me.LabelTop_WorkingDaysLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTop_WorkingDaysLbl.TabIndex = 13
            Me.LabelTop_WorkingDaysLbl.Text = "{0}"
            '
            'LabelTop_JobDueDateLbl
            '
            Me.LabelTop_JobDueDateLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTop_JobDueDateLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTop_JobDueDateLbl.Location = New System.Drawing.Point(84, 6)
            Me.LabelTop_JobDueDateLbl.Name = "LabelTop_JobDueDateLbl"
            Me.LabelTop_JobDueDateLbl.Size = New System.Drawing.Size(91, 20)
            Me.LabelTop_JobDueDateLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTop_JobDueDateLbl.TabIndex = 14
            Me.LabelTop_JobDueDateLbl.Text = "{0}"
            '
            'ProjectScheduleTaskSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(782, 513)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleTaskSelectionDialog"
            Me.Text = "Add Project Schedule"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelTemplates_TaskTemplates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTemplates_TaskTemplates.ResumeLayout(False)
            CType(Me.PanelTaskTemplates_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTaskTemplates_RightSection.ResumeLayout(False)
            CType(Me.PanelTaskTemplates_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTaskTemplates_LeftSection.ResumeLayout(False)
            CType(Me.TabControlForm_Tasks, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Tasks.ResumeLayout(False)
            Me.TabControlPanelEstimatesTab_Estimate.ResumeLayout(False)
            Me.TabControlPanelAvailableTasksTab_AvailableTasks.ResumeLayout(False)
            Me.TabControlPanelTaskTemplatesTab_TaskTemplates.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewTemplates_Tasks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelTemplates_TaskTemplates As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelTaskTemplates_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelTaskTemplates_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewTemplates_TaskTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarDetails_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelTop_WorkingDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTop_JobDueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_Tasks As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelTaskTemplatesTab_TaskTemplates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTasks_TaskTemplatesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAvailableTasksTab_AvailableTasks As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewTasks_Tasks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTasks_AvailableTasksTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RadioButtonControlTemplates_Rush As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlTemplates_Standard As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RibbonBarOptions_Templates As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTemplates_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelTop_JobDueDateLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTop_WorkingDaysLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelEstimatesTab_Estimate As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewEstimate_Tasks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTasks_EstimatesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxEstimate_IncludeHours As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxEstimate_IncludeEmployees As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace