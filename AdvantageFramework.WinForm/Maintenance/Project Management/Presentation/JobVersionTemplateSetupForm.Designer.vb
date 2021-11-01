Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobVersionTemplateSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobVersionTemplateSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ListValues = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemListValues_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_JobVersionTemplateExport = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_JobVersionTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate = New AdvantageFramework.WinForm.Presentation.Controls.JobVersionTemplateControl()
            Me.ButtonItemActions_Sync = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ListValues)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 5)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(523, 95)
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
            'RibbonBarOptions_ListValues
            '
            Me.RibbonBarOptions_ListValues.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ListValues.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ListValues.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ListValues.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ListValues.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ListValues.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemListValues_Edit})
            Me.RibbonBarOptions_ListValues.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ListValues.Location = New System.Drawing.Point(464, 0)
            Me.RibbonBarOptions_ListValues.Name = "RibbonBarOptions_ListValues"
            Me.RibbonBarOptions_ListValues.Size = New System.Drawing.Size(47, 95)
            Me.RibbonBarOptions_ListValues.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ListValues.TabIndex = 3
            Me.RibbonBarOptions_ListValues.Text = "List"
            '
            '
            '
            Me.RibbonBarOptions_ListValues.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ListValues.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ListValues.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemListValues_Edit
            '
            Me.ButtonItemListValues_Edit.BeginGroup = True
            Me.ButtonItemListValues_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemListValues_Edit.Name = "ButtonItemListValues_Edit"
            Me.ButtonItemListValues_Edit.RibbonWordWrap = False
            Me.ButtonItemListValues_Edit.SecurityEnabled = True
            Me.ButtonItemListValues_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemListValues_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Details
            '
            Me.RibbonBarOptions_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_MoveUp, Me.ButtonItemDetails_MoveDown, Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(242, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(222, 95)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 2
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDetails_MoveUp
            '
            Me.ButtonItemDetails_MoveUp.BeginGroup = True
            Me.ButtonItemDetails_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_MoveUp.Name = "ButtonItemDetails_MoveUp"
            Me.ButtonItemDetails_MoveUp.RibbonWordWrap = False
            Me.ButtonItemDetails_MoveUp.SecurityEnabled = True
            Me.ButtonItemDetails_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_MoveUp.Text = "Move Up"
            '
            'ButtonItemDetails_MoveDown
            '
            Me.ButtonItemDetails_MoveDown.BeginGroup = True
            Me.ButtonItemDetails_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_MoveDown.Name = "ButtonItemDetails_MoveDown"
            Me.ButtonItemDetails_MoveDown.RibbonWordWrap = False
            Me.ButtonItemDetails_MoveDown.SecurityEnabled = True
            Me.ButtonItemDetails_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_MoveDown.Text = "Move Down"
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.SecurityEnabled = True
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.BeginGroup = True
            Me.ButtonItemDetails_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.SecurityEnabled = True
            Me.ButtonItemDetails_Cancel.Stretch = True
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
            Me.ButtonItemDetails_Cancel.Tooltip = "Cancel adding new row"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Sync})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(242, 95)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_CurrentView, Me.ButtonItemExport_All})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemExport_CurrentView
            '
            Me.ButtonItemExport_CurrentView.Name = "ButtonItemExport_CurrentView"
            Me.ButtonItemExport_CurrentView.Text = "Current View"
            '
            'ButtonItemExport_All
            '
            Me.ButtonItemExport_All.Name = "ButtonItemExport_All"
            Me.ButtonItemExport_All.Text = "All"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
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
            Me.ButtonItemActions_Save.Stretch = True
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
            Me.ButtonItemActions_Delete.Stretch = True
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
            Me.ButtonItemActions_Copy.Stretch = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobVersionTemplateExport)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobVersionTemplates)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(298, 492)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_JobVersionTemplateExport
            '
            Me.DataGridViewLeftSection_JobVersionTemplateExport.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobVersionTemplateExport.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobVersionTemplateExport.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobVersionTemplateExport.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobVersionTemplateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobVersionTemplateExport.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobVersionTemplateExport.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobVersionTemplateExport.ItemDescription = "Item(s)"
            Me.DataGridViewLeftSection_JobVersionTemplateExport.Location = New System.Drawing.Point(137, 370)
            Me.DataGridViewLeftSection_JobVersionTemplateExport.MultiSelect = True
            Me.DataGridViewLeftSection_JobVersionTemplateExport.Name = "DataGridViewLeftSection_JobVersionTemplateExport"
            Me.DataGridViewLeftSection_JobVersionTemplateExport.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobVersionTemplateExport.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobVersionTemplateExport.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobVersionTemplateExport.Size = New System.Drawing.Size(141, 92)
            Me.DataGridViewLeftSection_JobVersionTemplateExport.TabIndex = 1
            Me.DataGridViewLeftSection_JobVersionTemplateExport.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobVersionTemplateExport.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_JobVersionTemplates
            '
            Me.DataGridViewLeftSection_JobVersionTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobVersionTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobVersionTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_JobVersionTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobVersionTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobVersionTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobVersionTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobVersionTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobVersionTemplates.ItemDescription = ""
            Me.DataGridViewLeftSection_JobVersionTemplates.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_JobVersionTemplates.MultiSelect = False
            Me.DataGridViewLeftSection_JobVersionTemplates.Name = "DataGridViewLeftSection_JobVersionTemplates"
            Me.DataGridViewLeftSection_JobVersionTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobVersionTemplates.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobVersionTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobVersionTemplates.Size = New System.Drawing.Size(280, 468)
            Me.DataGridViewLeftSection_JobVersionTemplates.TabIndex = 0
            Me.DataGridViewLeftSection_JobVersionTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobVersionTemplates.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(298, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 492)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.JobVersionTemplateControlRightSection_JobVersionTemplate)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(304, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(637, 492)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'JobVersionTemplateControlRightSection_JobVersionTemplate
            '
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate.Location = New System.Drawing.Point(6, 12)
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate.Name = "JobVersionTemplateControlRightSection_JobVersionTemplate"
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate.Size = New System.Drawing.Size(619, 468)
            Me.JobVersionTemplateControlRightSection_JobVersionTemplate.TabIndex = 0
            '
            'ButtonItemActions_Sync
            '
            Me.ButtonItemActions_Sync.BeginGroup = True
            Me.ButtonItemActions_Sync.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Sync.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Sync.Name = "ButtonItemActions_Sync"
            Me.ButtonItemActions_Sync.SecurityEnabled = True
            Me.ButtonItemActions_Sync.Stretch = True
            Me.ButtonItemActions_Sync.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Sync.Text = "Sync"
            Me.ButtonItemActions_Sync.Tooltip = "Sync all job\comp with this template"
            '
            'JobVersionTemplateSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(941, 492)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobVersionTemplateSetupForm"
            Me.Text = "Job Version Template Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_JobVersionTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents JobVersionTemplateControlRightSection_JobVersionTemplate As AdvantageFramework.WinForm.Presentation.Controls.JobVersionTemplateControl
        Friend WithEvents ButtonItemDetails_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ListValues As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemListValues_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewLeftSection_JobVersionTemplateExport As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Sync As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

