Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobSpecificationTemplateControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobSpecificationTemplateControl))
            Me.PanelRightSection_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlRightSection_Categories = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTemplate_Template = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTemplate_TemplateGrid = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemCategories_TemplateTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonRightSection_AddCategory = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ExpandableSplitterControlRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonLeftSection_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonLeftSection_AddSelected = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelRightSection_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxTopSection_UseQuantitiesTab = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTopSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_UseVendorTab = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelTopSection_UseVendorTab = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_RightSection.SuspendLayout()
            CType(Me.TabControlRightSection_Categories, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_Categories.SuspendLayout()
            Me.TabControlPanelTemplate_Template.SuspendLayout()
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_LeftSection.SuspendLayout()
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelRightSection_RightSection
            '
            Me.PanelRightSection_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_RightSection.Controls.Add(Me.TabControlRightSection_Categories)
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_AddCategory)
            Me.PanelRightSection_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightSection.Location = New System.Drawing.Point(379, 78)
            Me.PanelRightSection_RightSection.Name = "PanelRightSection_RightSection"
            Me.PanelRightSection_RightSection.Size = New System.Drawing.Size(420, 418)
            Me.PanelRightSection_RightSection.TabIndex = 5
            '
            'TabControlRightSection_Categories
            '
            Me.TabControlRightSection_Categories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_Categories.CanReorderTabs = False
            Me.TabControlRightSection_Categories.Controls.Add(Me.TabControlPanelTemplate_Template)
            Me.TabControlRightSection_Categories.Location = New System.Drawing.Point(6, 0)
            Me.TabControlRightSection_Categories.Name = "TabControlRightSection_Categories"
            Me.TabControlRightSection_Categories.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_Categories.SelectedTabIndex = 0
            Me.TabControlRightSection_Categories.Size = New System.Drawing.Size(414, 418)
            Me.TabControlRightSection_Categories.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_Categories.TabIndex = 2
            Me.TabControlRightSection_Categories.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_Categories.Tabs.Add(Me.TabItemCategories_TemplateTab)
            Me.TabControlRightSection_Categories.Text = "TabControl1"
            '
            'TabControlPanelTemplate_Template
            '
            Me.TabControlPanelTemplate_Template.Controls.Add(Me.DataGridViewTemplate_TemplateGrid)
            Me.TabControlPanelTemplate_Template.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTemplate_Template.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTemplate_Template.Name = "TabControlPanelTemplate_Template"
            Me.TabControlPanelTemplate_Template.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTemplate_Template.Size = New System.Drawing.Size(414, 391)
            Me.TabControlPanelTemplate_Template.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTemplate_Template.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTemplate_Template.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTemplate_Template.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTemplate_Template.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTemplate_Template.Style.GradientAngle = 90
            Me.TabControlPanelTemplate_Template.TabIndex = 1
            Me.TabControlPanelTemplate_Template.TabItem = Me.TabItemCategories_TemplateTab
            '
            'DataGridViewTemplate_TemplateGrid
            '
            Me.DataGridViewTemplate_TemplateGrid.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTemplate_TemplateGrid.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTemplate_TemplateGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTemplate_TemplateGrid.AutoFilterLookupColumns = False
            Me.DataGridViewTemplate_TemplateGrid.AutoloadRepositoryDatasource = True
            Me.DataGridViewTemplate_TemplateGrid.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTemplate_TemplateGrid.DataSource = Nothing
            Me.DataGridViewTemplate_TemplateGrid.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTemplate_TemplateGrid.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTemplate_TemplateGrid.ItemDescription = ""
            Me.DataGridViewTemplate_TemplateGrid.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewTemplate_TemplateGrid.MultiSelect = True
            Me.DataGridViewTemplate_TemplateGrid.Name = "DataGridViewTemplate_TemplateGrid"
            Me.DataGridViewTemplate_TemplateGrid.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTemplate_TemplateGrid.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTemplate_TemplateGrid.Size = New System.Drawing.Size(406, 383)
            Me.DataGridViewTemplate_TemplateGrid.TabIndex = 1
            Me.DataGridViewTemplate_TemplateGrid.UseEmbeddedNavigator = False
            Me.DataGridViewTemplate_TemplateGrid.ViewCaptionHeight = -1
            '
            'TabItemCategories_TemplateTab
            '
            Me.TabItemCategories_TemplateTab.AttachedControl = Me.TabControlPanelTemplate_Template
            Me.TabItemCategories_TemplateTab.Name = "TabItemCategories_TemplateTab"
            Me.TabItemCategories_TemplateTab.Text = "Template"
            '
            'ButtonRightSection_AddCategory
            '
            Me.ButtonRightSection_AddCategory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddCategory.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddCategory.Location = New System.Drawing.Point(6, 0)
            Me.ButtonRightSection_AddCategory.Name = "ButtonRightSection_AddCategory"
            Me.ButtonRightSection_AddCategory.SecurityEnabled = True
            Me.ButtonRightSection_AddCategory.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddCategory.TabIndex = 6
            Me.ButtonRightSection_AddCategory.Text = "Add Category"
            '
            'ExpandableSplitterControlRightSection_LeftRight
            '
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandableControl = Me.PanelRightSection_LeftSection
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.Location = New System.Drawing.Point(373, 78)
            Me.ExpandableSplitterControlRightSection_LeftRight.Name = "ExpandableSplitterControlRightSection_LeftRight"
            Me.ExpandableSplitterControlRightSection_LeftRight.Size = New System.Drawing.Size(6, 418)
            Me.ExpandableSplitterControlRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlRightSection_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlRightSection_LeftRight.TabStop = False
            '
            'PanelRightSection_LeftSection
            '
            Me.PanelRightSection_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_LeftSection.Controls.Add(Me.ButtonLeftSection_Delete)
            Me.PanelRightSection_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableJobSpecificationFields)
            Me.PanelRightSection_LeftSection.Controls.Add(Me.ButtonLeftSection_AddSelected)
            Me.PanelRightSection_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRightSection_LeftSection.Location = New System.Drawing.Point(0, 78)
            Me.PanelRightSection_LeftSection.Name = "PanelRightSection_LeftSection"
            Me.PanelRightSection_LeftSection.Size = New System.Drawing.Size(373, 418)
            Me.PanelRightSection_LeftSection.TabIndex = 3
            '
            'ButtonLeftSection_Delete
            '
            Me.ButtonLeftSection_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_Delete.Location = New System.Drawing.Point(292, 26)
            Me.ButtonLeftSection_Delete.Name = "ButtonLeftSection_Delete"
            Me.ButtonLeftSection_Delete.SecurityEnabled = True
            Me.ButtonLeftSection_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_Delete.TabIndex = 5
            Me.ButtonLeftSection_Delete.Text = "<"
            '
            'DataGridViewLeftSection_AvailableJobSpecificationFields
            '
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.Name = "DataGridViewLeftSection_AvailableJobSpecificationFields"
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.Size = New System.Drawing.Size(286, 418)
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.TabIndex = 8
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableJobSpecificationFields.ViewCaptionHeight = -1
            '
            'ButtonLeftSection_AddSelected
            '
            Me.ButtonLeftSection_AddSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_AddSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_AddSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_AddSelected.Location = New System.Drawing.Point(292, 0)
            Me.ButtonLeftSection_AddSelected.Name = "ButtonLeftSection_AddSelected"
            Me.ButtonLeftSection_AddSelected.SecurityEnabled = True
            Me.ButtonLeftSection_AddSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_AddSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_AddSelected.TabIndex = 4
            Me.ButtonLeftSection_AddSelected.Text = ">"
            '
            'PanelRightSection_TopSection
            '
            Me.PanelRightSection_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_TopSection.Controls.Add(Me.CheckBoxTopSection_UseQuantitiesTab)
            Me.PanelRightSection_TopSection.Controls.Add(Me.CheckBoxTopSection_Inactive)
            Me.PanelRightSection_TopSection.Controls.Add(Me.TextBoxTopSection_Description)
            Me.PanelRightSection_TopSection.Controls.Add(Me.TextBoxTopSection_Code)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_Description)
            Me.PanelRightSection_TopSection.Controls.Add(Me.ComboBoxTopSection_UseVendorTab)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_UseVendorTab)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_Code)
            Me.PanelRightSection_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelRightSection_TopSection.Name = "PanelRightSection_TopSection"
            Me.PanelRightSection_TopSection.Size = New System.Drawing.Size(799, 78)
            Me.PanelRightSection_TopSection.TabIndex = 1
            '
            'CheckBoxTopSection_UseQuantitiesTab
            '
            Me.CheckBoxTopSection_UseQuantitiesTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTopSection_UseQuantitiesTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTopSection_UseQuantitiesTab.CheckValue = 0
            Me.CheckBoxTopSection_UseQuantitiesTab.CheckValueChecked = 1
            Me.CheckBoxTopSection_UseQuantitiesTab.CheckValueUnchecked = 0
            Me.CheckBoxTopSection_UseQuantitiesTab.ChildControls = CType(resources.GetObject("CheckBoxTopSection_UseQuantitiesTab.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_UseQuantitiesTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTopSection_UseQuantitiesTab.Location = New System.Drawing.Point(677, 52)
            Me.CheckBoxTopSection_UseQuantitiesTab.Name = "CheckBoxTopSection_UseQuantitiesTab"
            Me.CheckBoxTopSection_UseQuantitiesTab.OldestSibling = Nothing
            Me.CheckBoxTopSection_UseQuantitiesTab.SecurityEnabled = True
            Me.CheckBoxTopSection_UseQuantitiesTab.SiblingControls = CType(resources.GetObject("CheckBoxTopSection_UseQuantitiesTab.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_UseQuantitiesTab.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxTopSection_UseQuantitiesTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTopSection_UseQuantitiesTab.TabIndex = 7
            Me.CheckBoxTopSection_UseQuantitiesTab.Text = "Use Quantities Tab"
            '
            'CheckBoxTopSection_Inactive
            '
            Me.CheckBoxTopSection_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTopSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTopSection_Inactive.CheckValue = 0
            Me.CheckBoxTopSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxTopSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxTopSection_Inactive.ChildControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTopSection_Inactive.Location = New System.Drawing.Point(165, 0)
            Me.CheckBoxTopSection_Inactive.Name = "CheckBoxTopSection_Inactive"
            Me.CheckBoxTopSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxTopSection_Inactive.SecurityEnabled = True
            Me.CheckBoxTopSection_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.Size = New System.Drawing.Size(634, 20)
            Me.CheckBoxTopSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTopSection_Inactive.TabIndex = 2
            Me.CheckBoxTopSection_Inactive.Text = "Inactive"
            '
            'TextBoxTopSection_Description
            '
            Me.TextBoxTopSection_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Description.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Description.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Description.Location = New System.Drawing.Point(96, 26)
            Me.TextBoxTopSection_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Description.Name = "TextBoxTopSection_Description"
            Me.TextBoxTopSection_Description.Size = New System.Drawing.Size(703, 20)
            Me.TextBoxTopSection_Description.TabIndex = 4
            Me.TextBoxTopSection_Description.TabOnEnter = True
            '
            'TextBoxTopSection_Code
            '
            '
            '
            '
            Me.TextBoxTopSection_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Code.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Code.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Code.Location = New System.Drawing.Point(96, 0)
            Me.TextBoxTopSection_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Code.Name = "TextBoxTopSection_Code"
            Me.TextBoxTopSection_Code.Size = New System.Drawing.Size(63, 20)
            Me.TextBoxTopSection_Code.TabIndex = 1
            Me.TextBoxTopSection_Code.TabOnEnter = True
            '
            'LabelTopSection_Description
            '
            Me.LabelTopSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Description.Location = New System.Drawing.Point(0, 26)
            Me.LabelTopSection_Description.Name = "LabelTopSection_Description"
            Me.LabelTopSection_Description.Size = New System.Drawing.Size(90, 20)
            Me.LabelTopSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Description.TabIndex = 3
            Me.LabelTopSection_Description.Text = "Description:"
            '
            'ComboBoxTopSection_UseVendorTab
            '
            Me.ComboBoxTopSection_UseVendorTab.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTopSection_UseVendorTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTopSection_UseVendorTab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTopSection_UseVendorTab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTopSection_UseVendorTab.AutoFindItemInDataSource = False
            Me.ComboBoxTopSection_UseVendorTab.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTopSection_UseVendorTab.BookmarkingEnabled = False
            Me.ComboBoxTopSection_UseVendorTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobSpecificationVendorTab
            Me.ComboBoxTopSection_UseVendorTab.DisableMouseWheel = False
            Me.ComboBoxTopSection_UseVendorTab.DisplayMember = "Description"
            Me.ComboBoxTopSection_UseVendorTab.DisplayName = ""
            Me.ComboBoxTopSection_UseVendorTab.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTopSection_UseVendorTab.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxTopSection_UseVendorTab.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxTopSection_UseVendorTab.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTopSection_UseVendorTab.FocusHighlightEnabled = True
            Me.ComboBoxTopSection_UseVendorTab.FormattingEnabled = True
            Me.ComboBoxTopSection_UseVendorTab.ItemHeight = 14
            Me.ComboBoxTopSection_UseVendorTab.Location = New System.Drawing.Point(96, 52)
            Me.ComboBoxTopSection_UseVendorTab.Name = "ComboBoxTopSection_UseVendorTab"
            Me.ComboBoxTopSection_UseVendorTab.PreventEnterBeep = False
            Me.ComboBoxTopSection_UseVendorTab.ReadOnly = False
            Me.ComboBoxTopSection_UseVendorTab.Size = New System.Drawing.Size(575, 20)
            Me.ComboBoxTopSection_UseVendorTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_UseVendorTab.TabIndex = 6
            Me.ComboBoxTopSection_UseVendorTab.ValueMember = "ID"
            Me.ComboBoxTopSection_UseVendorTab.WatermarkText = "Select Job Specification Vendor Tab"
            '
            'LabelTopSection_UseVendorTab
            '
            Me.LabelTopSection_UseVendorTab.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_UseVendorTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_UseVendorTab.Location = New System.Drawing.Point(0, 52)
            Me.LabelTopSection_UseVendorTab.Name = "LabelTopSection_UseVendorTab"
            Me.LabelTopSection_UseVendorTab.Size = New System.Drawing.Size(90, 20)
            Me.LabelTopSection_UseVendorTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_UseVendorTab.TabIndex = 5
            Me.LabelTopSection_UseVendorTab.Text = "Use Vendor Tab:"
            '
            'LabelTopSection_Code
            '
            Me.LabelTopSection_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelTopSection_Code.Name = "LabelTopSection_Code"
            Me.LabelTopSection_Code.Size = New System.Drawing.Size(90, 20)
            Me.LabelTopSection_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Code.TabIndex = 0
            Me.LabelTopSection_Code.Text = "Code:"
            '
            'JobSpecificationTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelRightSection_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlRightSection_LeftRight)
            Me.Controls.Add(Me.PanelRightSection_LeftSection)
            Me.Controls.Add(Me.PanelRightSection_TopSection)
            Me.Name = "JobSpecificationTemplateControl"
            Me.Size = New System.Drawing.Size(799, 496)
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_RightSection.ResumeLayout(False)
            CType(Me.TabControlRightSection_Categories, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_Categories.ResumeLayout(False)
            Me.TabControlPanelTemplate_Template.ResumeLayout(False)
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_LeftSection.ResumeLayout(False)
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelRightSection_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxTopSection_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_UseVendorTab As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTopSection_UseVendorTab As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ExpandableSplitterControlRightSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonLeftSection_AddSelected As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelRightSection_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonLeftSection_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewTemplate_TemplateGrid As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewLeftSection_AvailableJobSpecificationFields As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxTopSection_UseQuantitiesTab As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlRightSection_Categories As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelTemplate_Template As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCategories_TemplateTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonRightSection_AddCategory As AdvantageFramework.WinForm.Presentation.Controls.Button

    End Class

End Namespace
