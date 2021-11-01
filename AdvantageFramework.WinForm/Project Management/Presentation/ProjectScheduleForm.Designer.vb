Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_TaskOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTasks_Details = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTasks_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerTasks_Add = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemTasks_AddFromTemplate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_AddFromEstimate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_AddFromSchedule = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTasks_Calculate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTasks_Team = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTeam_ApplyByFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTeam_ApplyByRole = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_Employees = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerTasks_Tasks = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemTasks_TempComplete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_ClearAssignments = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_Replace = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTasks_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTasks_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Spelling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSpelling_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerActions_SearchBy = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemActions_SearchBy = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ProjectScheduleControlRightSection_ProjectSchedule = New AdvantageFramework.WinForm.Presentation.Controls.ProjectScheduleControl()
            Me.DataGridViewRightSection_MutliView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_JobTraffic = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.RibbonBarOptions_Views = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItem1 = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Views)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TaskOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Spelling)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 327)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1285, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_TaskOptions
            '
            Me.RibbonBarOptions_TaskOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_TaskOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TaskOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TaskOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TaskOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TaskOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTasks_Details, Me.ButtonItemTasks_Add, Me.ItemContainerTasks_Add, Me.ButtonItemTasks_Delete, Me.ButtonItemTasks_Calculate, Me.ButtonItemTasks_Team, Me.ButtonItemTasks_Employees, Me.ItemContainerTasks_Tasks, Me.ButtonItemTasks_MoveUp, Me.ButtonItemTasks_MoveDown})
            Me.RibbonBarOptions_TaskOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TaskOptions.Location = New System.Drawing.Point(412, 0)
            Me.RibbonBarOptions_TaskOptions.Name = "RibbonBarOptions_TaskOptions"
            Me.RibbonBarOptions_TaskOptions.Size = New System.Drawing.Size(610, 98)
            Me.RibbonBarOptions_TaskOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TaskOptions.TabIndex = 2
            Me.RibbonBarOptions_TaskOptions.Text = "Tasks"
            '
            '
            '
            Me.RibbonBarOptions_TaskOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TaskOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TaskOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemTasks_Details
            '
            Me.ButtonItemTasks_Details.BeginGroup = True
            Me.ButtonItemTasks_Details.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Details.Name = "ButtonItemTasks_Details"
            Me.ButtonItemTasks_Details.RibbonWordWrap = False
            Me.ButtonItemTasks_Details.SecurityEnabled = True
            Me.ButtonItemTasks_Details.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Details.Text = "Details"
            '
            'ButtonItemTasks_Add
            '
            Me.ButtonItemTasks_Add.BeginGroup = True
            Me.ButtonItemTasks_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Add.Name = "ButtonItemTasks_Add"
            Me.ButtonItemTasks_Add.RibbonWordWrap = False
            Me.ButtonItemTasks_Add.SecurityEnabled = True
            Me.ButtonItemTasks_Add.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Add.Text = "Add"
            '
            'ItemContainerTasks_Add
            '
            '
            '
            '
            Me.ItemContainerTasks_Add.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerTasks_Add.BeginGroup = True
            Me.ItemContainerTasks_Add.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerTasks_Add.Name = "ItemContainerTasks_Add"
            Me.ItemContainerTasks_Add.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTasks_AddFromTemplate, Me.ButtonItemTasks_AddFromEstimate, Me.ButtonItemTasks_AddFromSchedule})
            '
            '
            '
            Me.ItemContainerTasks_Add.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemTasks_AddFromTemplate
            '
            Me.ButtonItemTasks_AddFromTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_AddFromTemplate.Name = "ButtonItemTasks_AddFromTemplate"
            Me.ButtonItemTasks_AddFromTemplate.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_AddFromTemplate.RibbonWordWrap = False
            Me.ButtonItemTasks_AddFromTemplate.Stretch = True
            Me.ButtonItemTasks_AddFromTemplate.Text = "Add from Template"
            '
            'ButtonItemTasks_AddFromEstimate
            '
            Me.ButtonItemTasks_AddFromEstimate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_AddFromEstimate.Name = "ButtonItemTasks_AddFromEstimate"
            Me.ButtonItemTasks_AddFromEstimate.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_AddFromEstimate.RibbonWordWrap = False
            Me.ButtonItemTasks_AddFromEstimate.Stretch = True
            Me.ButtonItemTasks_AddFromEstimate.Text = "Create from Estimate"
            '
            'ButtonItemTasks_AddFromSchedule
            '
            Me.ButtonItemTasks_AddFromSchedule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_AddFromSchedule.Name = "ButtonItemTasks_AddFromSchedule"
            Me.ButtonItemTasks_AddFromSchedule.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_AddFromSchedule.RibbonWordWrap = False
            Me.ButtonItemTasks_AddFromSchedule.Stretch = True
            Me.ButtonItemTasks_AddFromSchedule.Text = "Copy from Schedule"
            '
            'ButtonItemTasks_Delete
            '
            Me.ButtonItemTasks_Delete.BeginGroup = True
            Me.ButtonItemTasks_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Delete.Name = "ButtonItemTasks_Delete"
            Me.ButtonItemTasks_Delete.RibbonWordWrap = False
            Me.ButtonItemTasks_Delete.SecurityEnabled = True
            Me.ButtonItemTasks_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Delete.Text = "Delete"
            '
            'ButtonItemTasks_Calculate
            '
            Me.ButtonItemTasks_Calculate.BeginGroup = True
            Me.ButtonItemTasks_Calculate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Calculate.Name = "ButtonItemTasks_Calculate"
            Me.ButtonItemTasks_Calculate.RibbonWordWrap = False
            Me.ButtonItemTasks_Calculate.SecurityEnabled = True
            Me.ButtonItemTasks_Calculate.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Calculate.Text = "Calculate"
            '
            'ButtonItemTasks_Team
            '
            Me.ButtonItemTasks_Team.AutoExpandOnClick = True
            Me.ButtonItemTasks_Team.BeginGroup = True
            Me.ButtonItemTasks_Team.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Team.Name = "ButtonItemTasks_Team"
            Me.ButtonItemTasks_Team.RibbonWordWrap = False
            Me.ButtonItemTasks_Team.SecurityEnabled = True
            Me.ButtonItemTasks_Team.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTeam_ApplyByFunction, Me.ButtonItemTeam_ApplyByRole})
            Me.ButtonItemTasks_Team.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Team.Text = "Team"
            '
            'ButtonItemTeam_ApplyByFunction
            '
            Me.ButtonItemTeam_ApplyByFunction.Name = "ButtonItemTeam_ApplyByFunction"
            Me.ButtonItemTeam_ApplyByFunction.Text = "Apply by Function"
            '
            'ButtonItemTeam_ApplyByRole
            '
            Me.ButtonItemTeam_ApplyByRole.Name = "ButtonItemTeam_ApplyByRole"
            Me.ButtonItemTeam_ApplyByRole.Text = "Apply by Role"
            '
            'ButtonItemTasks_Employees
            '
            Me.ButtonItemTasks_Employees.BeginGroup = True
            Me.ButtonItemTasks_Employees.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_Employees.Name = "ButtonItemTasks_Employees"
            Me.ButtonItemTasks_Employees.RibbonWordWrap = False
            Me.ButtonItemTasks_Employees.SecurityEnabled = True
            Me.ButtonItemTasks_Employees.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_Employees.Text = "Employees"
            '
            'ItemContainerTasks_Tasks
            '
            '
            '
            '
            Me.ItemContainerTasks_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerTasks_Tasks.BeginGroup = True
            Me.ItemContainerTasks_Tasks.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerTasks_Tasks.Name = "ItemContainerTasks_Tasks"
            Me.ItemContainerTasks_Tasks.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTasks_TempComplete, Me.ButtonItemTasks_ClearAssignments, Me.ButtonItemTasks_Replace})
            '
            '
            '
            Me.ItemContainerTasks_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemTasks_TempComplete
            '
            Me.ButtonItemTasks_TempComplete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_TempComplete.Name = "ButtonItemTasks_TempComplete"
            Me.ButtonItemTasks_TempComplete.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_TempComplete.RibbonWordWrap = False
            Me.ButtonItemTasks_TempComplete.Stretch = True
            Me.ButtonItemTasks_TempComplete.Text = "Temp Complete"
            '
            'ButtonItemTasks_ClearAssignments
            '
            Me.ButtonItemTasks_ClearAssignments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_ClearAssignments.Name = "ButtonItemTasks_ClearAssignments"
            Me.ButtonItemTasks_ClearAssignments.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_ClearAssignments.RibbonWordWrap = False
            Me.ButtonItemTasks_ClearAssignments.Stretch = True
            Me.ButtonItemTasks_ClearAssignments.Text = "Clear Assignments"
            '
            'ButtonItemTasks_Replace
            '
            Me.ButtonItemTasks_Replace.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTasks_Replace.Name = "ButtonItemTasks_Replace"
            Me.ButtonItemTasks_Replace.OptionGroup = "SearchFilter"
            Me.ButtonItemTasks_Replace.RibbonWordWrap = False
            Me.ButtonItemTasks_Replace.Stretch = True
            Me.ButtonItemTasks_Replace.Text = "Search && Replace"
            '
            'ButtonItemTasks_MoveUp
            '
            Me.ButtonItemTasks_MoveUp.BeginGroup = True
            Me.ButtonItemTasks_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_MoveUp.Name = "ButtonItemTasks_MoveUp"
            Me.ButtonItemTasks_MoveUp.RibbonWordWrap = False
            Me.ButtonItemTasks_MoveUp.SecurityEnabled = True
            Me.ButtonItemTasks_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_MoveUp.Text = "Move Up"
            '
            'ButtonItemTasks_MoveDown
            '
            Me.ButtonItemTasks_MoveDown.BeginGroup = True
            Me.ButtonItemTasks_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTasks_MoveDown.Name = "ButtonItemTasks_MoveDown"
            Me.ButtonItemTasks_MoveDown.RibbonWordWrap = False
            Me.ButtonItemTasks_MoveDown.SecurityEnabled = True
            Me.ButtonItemTasks_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemTasks_MoveDown.Text = "Move Down"
            '
            'RibbonBarOptions_Spelling
            '
            Me.RibbonBarOptions_Spelling.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Spelling.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spelling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spelling.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Spelling.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Spelling.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSpelling_CheckSpelling})
            Me.RibbonBarOptions_Spelling.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Spelling.Location = New System.Drawing.Point(318, 0)
            Me.RibbonBarOptions_Spelling.Name = "RibbonBarOptions_Spelling"
            Me.RibbonBarOptions_Spelling.Size = New System.Drawing.Size(94, 98)
            Me.RibbonBarOptions_Spelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Spelling.TabIndex = 1
            Me.RibbonBarOptions_Spelling.Text = "Spelling"
            '
            '
            '
            Me.RibbonBarOptions_Spelling.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spelling.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spelling.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSpelling_CheckSpelling
            '
            Me.ButtonItemSpelling_CheckSpelling.BeginGroup = True
            Me.ButtonItemSpelling_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSpelling_CheckSpelling.Name = "ButtonItemSpelling_CheckSpelling"
            Me.ButtonItemSpelling_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemSpelling_CheckSpelling.SecurityEnabled = True
            Me.ButtonItemSpelling_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemSpelling_CheckSpelling.Text = "Check Spelling"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_SearchBy, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Settings})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(318, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerActions_SearchBy
            '
            '
            '
            '
            Me.ItemContainerActions_SearchBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_SearchBy.FixedSize = New System.Drawing.Size(150, 0)
            Me.ItemContainerActions_SearchBy.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_SearchBy.Name = "ItemContainerActions_SearchBy"
            Me.ItemContainerActions_SearchBy.ResizeItemsToFit = False
            Me.ItemContainerActions_SearchBy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemActions_SearchBy})
            '
            '
            '
            Me.ItemContainerActions_SearchBy.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemActions_SearchBy
            '
            Me.ComboBoxItemActions_SearchBy.ComboWidth = 135
            Me.ComboBoxItemActions_SearchBy.DropDownHeight = 106
            Me.ComboBoxItemActions_SearchBy.Name = "ComboBoxItemActions_SearchBy"
            Me.ComboBoxItemActions_SearchBy.Text = "ComboBoxItem1"
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
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemActions_Settings
            '
            Me.ButtonItemActions_Settings.BeginGroup = True
            Me.ButtonItemActions_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Settings.Name = "ButtonItemActions_Settings"
            Me.ButtonItemActions_Settings.RibbonWordWrap = False
            Me.ButtonItemActions_Settings.SecurityEnabled = True
            Me.ButtonItemActions_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Settings.Text = "Settings"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.ProjectScheduleControlRightSection_ProjectSchedule)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_MutliView)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(258, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1065, 453)
            Me.PanelForm_RightSection.TabIndex = 8
            '
            'ProjectScheduleControlRightSection_ProjectSchedule
            '
            Me.ProjectScheduleControlRightSection_ProjectSchedule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ProjectScheduleControlRightSection_ProjectSchedule.Location = New System.Drawing.Point(6, 12)
            Me.ProjectScheduleControlRightSection_ProjectSchedule.Name = "ProjectScheduleControlRightSection_ProjectSchedule"
            Me.ProjectScheduleControlRightSection_ProjectSchedule.Size = New System.Drawing.Size(1047, 429)
            Me.ProjectScheduleControlRightSection_ProjectSchedule.TabIndex = 0
            '
            'DataGridViewRightSection_MutliView
            '
            Me.DataGridViewRightSection_MutliView.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_MutliView.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_MutliView.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_MutliView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_MutliView.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_MutliView.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_MutliView.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_MutliView.DataSource = Nothing
            Me.DataGridViewRightSection_MutliView.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_MutliView.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_MutliView.ItemDescription = "Project Schedule(s)"
            Me.DataGridViewRightSection_MutliView.Location = New System.Drawing.Point(6, 12)
            Me.DataGridViewRightSection_MutliView.MultiSelect = True
            Me.DataGridViewRightSection_MutliView.Name = "DataGridViewRightSection_MutliView"
            Me.DataGridViewRightSection_MutliView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_MutliView.RunStandardValidation = True
            Me.DataGridViewRightSection_MutliView.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_MutliView.Size = New System.Drawing.Size(1047, 429)
            Me.DataGridViewRightSection_MutliView.TabIndex = 1
            Me.DataGridViewRightSection_MutliView.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_MutliView.ViewCaptionHeight = -1
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobTraffic)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(252, 453)
            Me.PanelForm_LeftSection.TabIndex = 10
            '
            'DataGridViewLeftSection_JobTraffic
            '
            Me.DataGridViewLeftSection_JobTraffic.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_JobTraffic.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobTraffic.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobTraffic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_JobTraffic.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobTraffic.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobTraffic.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobTraffic.DataSource = Nothing
            Me.DataGridViewLeftSection_JobTraffic.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobTraffic.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobTraffic.ItemDescription = ""
            Me.DataGridViewLeftSection_JobTraffic.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_JobTraffic.MultiSelect = True
            Me.DataGridViewLeftSection_JobTraffic.Name = "DataGridViewLeftSection_JobTraffic"
            Me.DataGridViewLeftSection_JobTraffic.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobTraffic.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobTraffic.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobTraffic.Size = New System.Drawing.Size(234, 429)
            Me.DataGridViewLeftSection_JobTraffic.TabIndex = 2
            Me.DataGridViewLeftSection_JobTraffic.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobTraffic.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl1
            '
            Me.ExpandableSplitterControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl1.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(252, 0)
            Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
            Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 453)
            Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl1.TabIndex = 11
            Me.ExpandableSplitterControl1.TabStop = False
            '
            'RibbonBarOptions_Views
            '
            Me.RibbonBarOptions_Views.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Views.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Views.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Views.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Views.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Views.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
            Me.RibbonBarOptions_Views.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Views.Location = New System.Drawing.Point(1022, 0)
            Me.RibbonBarOptions_Views.Name = "RibbonBarOptions_Views"
            Me.RibbonBarOptions_Views.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_Views.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Views.TabIndex = 3
            Me.RibbonBarOptions_Views.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_Views.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Views.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Views.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItem1
            '
            Me.ButtonItem1.BeginGroup = True
            Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.RibbonWordWrap = False
            Me.ButtonItem1.SecurityEnabled = True
            Me.ButtonItem1.SubItemsExpandWidth = 14
            Me.ButtonItem1.Text = "Gantt"
            '
            'ProjectScheduleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1323, 453)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl1)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleForm"
            Me.Text = "Project Schedule"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_JobTraffic As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ExpandableSplitterControl1 As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Spelling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpelling_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ProjectScheduleControlRightSection_ProjectSchedule As AdvantageFramework.WinForm.Presentation.Controls.ProjectScheduleControl
        Friend WithEvents RibbonBarOptions_TaskOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTasks_Employees As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTasks_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTasks_Team As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTeam_ApplyByFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTeam_ApplyByRole As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTasks_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTasks_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Settings As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTasks_Details As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewRightSection_MutliView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ItemContainerActions_SearchBy As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemActions_SearchBy As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ItemContainerTasks_Add As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemTasks_AddFromTemplate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_AddFromEstimate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_AddFromSchedule As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerTasks_Tasks As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemTasks_TempComplete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_ClearAssignments As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_Replace As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTasks_Calculate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Views As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItem1 As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem

    End Class

End Namespace

