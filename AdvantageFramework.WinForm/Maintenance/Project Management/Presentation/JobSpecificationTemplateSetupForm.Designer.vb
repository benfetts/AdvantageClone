Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobSpecificationTemplateSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobSpecificationTemplateSetupForm))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.JobSpecificationTemplateControlRightSection_JobSpecification = New AdvantageFramework.WinForm.Presentation.Controls.JobSpecificationTemplateControl()
            Me.TabControlPanelFieldsTab_Fields = New DevComponents.DotNetBar.TabControlPanel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_JobSpecificationTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Fields = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFields_MoveUp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFields_MoveDown = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Categories = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCategories_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCategories_Activate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCategories_Deactivate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCategories_Rename = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCategories_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFields_Move = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.JobSpecificationTemplateControlRightSection_JobSpecification)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(704, 489)
            Me.PanelForm_RightSection.TabIndex = 5
            '
            'JobSpecificationTemplateControlRightSection_JobSpecification
            '
            Me.JobSpecificationTemplateControlRightSection_JobSpecification.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobSpecificationTemplateControlRightSection_JobSpecification.Location = New System.Drawing.Point(6, 12)
            Me.JobSpecificationTemplateControlRightSection_JobSpecification.Name = "JobSpecificationTemplateControlRightSection_JobSpecification"
            Me.JobSpecificationTemplateControlRightSection_JobSpecification.Size = New System.Drawing.Size(686, 465)
            Me.JobSpecificationTemplateControlRightSection_JobSpecification.TabIndex = 0
            '
            'TabControlPanelFieldsTab_Fields
            '
            Me.TabControlPanelFieldsTab_Fields.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFieldsTab_Fields.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelFieldsTab_Fields.Name = "TabControlPanelFieldsTab_Fields"
            Me.TabControlPanelFieldsTab_Fields.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFieldsTab_Fields.Size = New System.Drawing.Size(257, 331)
            Me.TabControlPanelFieldsTab_Fields.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelFieldsTab_Fields.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelFieldsTab_Fields.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFieldsTab_Fields.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFieldsTab_Fields.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFieldsTab_Fields.Style.GradientAngle = 90
            Me.TabControlPanelFieldsTab_Fields.TabIndex = 2
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(230, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 489)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobSpecificationTypes)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 489)
            Me.PanelForm_LeftSection.TabIndex = 3
            '
            'DataGridViewLeftSection_JobSpecificationTypes
            '
            Me.DataGridViewLeftSection_JobSpecificationTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobSpecificationTypes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobSpecificationTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_JobSpecificationTypes.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobSpecificationTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobSpecificationTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobSpecificationTypes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobSpecificationTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobSpecificationTypes.ItemDescription = ""
            Me.DataGridViewLeftSection_JobSpecificationTypes.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_JobSpecificationTypes.MultiSelect = True
            Me.DataGridViewLeftSection_JobSpecificationTypes.Name = "DataGridViewLeftSection_JobSpecificationTypes"
            Me.DataGridViewLeftSection_JobSpecificationTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobSpecificationTypes.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobSpecificationTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobSpecificationTypes.Size = New System.Drawing.Size(212, 465)
            Me.DataGridViewLeftSection_JobSpecificationTypes.TabIndex = 0
            Me.DataGridViewLeftSection_JobSpecificationTypes.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobSpecificationTypes.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Fields)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Categories)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(624, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 8
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Fields
            '
            Me.RibbonBarOptions_Fields.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Fields.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Fields.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Fields.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Fields.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Fields.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFields_MoveUp, Me.ButtonItemFields_MoveDown, Me.ButtonItemFields_Move})
            Me.RibbonBarOptions_Fields.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Fields.Location = New System.Drawing.Point(392, 0)
            Me.RibbonBarOptions_Fields.Name = "RibbonBarOptions_Fields"
            Me.RibbonBarOptions_Fields.Size = New System.Drawing.Size(190, 98)
            Me.RibbonBarOptions_Fields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Fields.TabIndex = 2
            Me.RibbonBarOptions_Fields.Text = "Fields"
            '
            '
            '
            Me.RibbonBarOptions_Fields.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Fields.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Fields.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemFields_MoveUp
            '
            Me.ButtonItemFields_MoveUp.BeginGroup = True
            Me.ButtonItemFields_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFields_MoveUp.Name = "ButtonItemFields_MoveUp"
            Me.ButtonItemFields_MoveUp.RibbonWordWrap = False
            Me.ButtonItemFields_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemFields_MoveUp.Text = "Move Up"
            '
            'ButtonItemFields_MoveDown
            '
            Me.ButtonItemFields_MoveDown.BeginGroup = True
            Me.ButtonItemFields_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFields_MoveDown.Name = "ButtonItemFields_MoveDown"
            Me.ButtonItemFields_MoveDown.RibbonWordWrap = False
            Me.ButtonItemFields_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemFields_MoveDown.Text = "Move Down"
            '
            'RibbonBarOptions_Categories
            '
            Me.RibbonBarOptions_Categories.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Categories.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Categories.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Categories.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Categories.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Categories.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCategories_Add, Me.ButtonItemCategories_Activate, Me.ButtonItemCategories_Deactivate, Me.ButtonItemCategories_Rename, Me.ButtonItemCategories_Delete})
            Me.RibbonBarOptions_Categories.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Categories.Location = New System.Drawing.Point(145, 0)
            Me.RibbonBarOptions_Categories.Name = "RibbonBarOptions_Categories"
            Me.RibbonBarOptions_Categories.Size = New System.Drawing.Size(247, 98)
            Me.RibbonBarOptions_Categories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Categories.TabIndex = 1
            Me.RibbonBarOptions_Categories.Text = "Categories"
            '
            '
            '
            Me.RibbonBarOptions_Categories.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Categories.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Categories.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemCategories_Add
            '
            Me.ButtonItemCategories_Add.BeginGroup = True
            Me.ButtonItemCategories_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCategories_Add.Name = "ButtonItemCategories_Add"
            Me.ButtonItemCategories_Add.RibbonWordWrap = False
            Me.ButtonItemCategories_Add.SubItemsExpandWidth = 14
            Me.ButtonItemCategories_Add.Text = "Add"
            '
            'ButtonItemCategories_Activate
            '
            Me.ButtonItemCategories_Activate.BeginGroup = True
            Me.ButtonItemCategories_Activate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCategories_Activate.Name = "ButtonItemCategories_Activate"
            Me.ButtonItemCategories_Activate.RibbonWordWrap = False
            Me.ButtonItemCategories_Activate.SubItemsExpandWidth = 14
            Me.ButtonItemCategories_Activate.Text = "Activate"
            '
            'ButtonItemCategories_Deactivate
            '
            Me.ButtonItemCategories_Deactivate.BeginGroup = True
            Me.ButtonItemCategories_Deactivate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCategories_Deactivate.Name = "ButtonItemCategories_Deactivate"
            Me.ButtonItemCategories_Deactivate.RibbonWordWrap = False
            Me.ButtonItemCategories_Deactivate.SubItemsExpandWidth = 14
            Me.ButtonItemCategories_Deactivate.Text = "Deactivate"
            '
            'ButtonItemCategories_Rename
            '
            Me.ButtonItemCategories_Rename.BeginGroup = True
            Me.ButtonItemCategories_Rename.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCategories_Rename.Name = "ButtonItemCategories_Rename"
            Me.ButtonItemCategories_Rename.RibbonWordWrap = False
            Me.ButtonItemCategories_Rename.SubItemsExpandWidth = 14
            Me.ButtonItemCategories_Rename.Text = "Rename"
            '
            'ButtonItemCategories_Delete
            '
            Me.ButtonItemCategories_Delete.BeginGroup = True
            Me.ButtonItemCategories_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCategories_Delete.Name = "ButtonItemCategories_Delete"
            Me.ButtonItemCategories_Delete.RibbonWordWrap = False
            Me.ButtonItemCategories_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemCategories_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(145, 98)
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
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemFields_Move
            '
            Me.ButtonItemFields_Move.BeginGroup = True
            Me.ButtonItemFields_Move.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFields_Move.Name = "ButtonItemFields_Move"
            Me.ButtonItemFields_Move.RibbonWordWrap = False
            Me.ButtonItemFields_Move.SubItemsExpandWidth = 14
            Me.ButtonItemFields_Move.Text = "Move"
            '
            'JobSpecificationTemplateSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(940, 489)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobSpecificationTemplateSetupForm"
            Me.Text = "Job Specification Template Maintenance"
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_JobSpecificationTypes As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelFieldsTab_Fields As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents RibbonBarOptions_Categories As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCategories_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCategories_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents JobSpecificationTemplateControlRightSection_JobSpecification As AdvantageFramework.WinForm.Presentation.Controls.JobSpecificationTemplateControl
        Friend WithEvents ButtonItemCategories_Activate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCategories_Deactivate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCategories_Rename As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Fields As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFields_MoveUp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFields_MoveDown As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFields_Move As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace