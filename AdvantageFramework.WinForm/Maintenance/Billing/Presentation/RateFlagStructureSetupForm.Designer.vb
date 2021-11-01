Namespace Maintenance.Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RateFlagStructureSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RateFlagStructureSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarDetails_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Calculate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_CopyByCDP = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_ShowDescriptions = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Update = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemUpdate_FeeFlagUpdate = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_MoveUp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_MoveDown = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ViewAll = New DevComponents.DotNetBar.ButtonItem()
            Me.BandedDataGridViewLeftSection_RateFlagLevels = New AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RateFlagEntryControlRightSection_RateFlag = New AdvantageFramework.WinForm.Presentation.Controls.RateFlagEntryControl()
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
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarDetails_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Update)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(7, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(840, 98)
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
            'RibbonBarDetails_Details
            '
            Me.RibbonBarDetails_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarDetails_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDetails_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDetails_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarDetails_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarDetails_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Export, Me.ButtonItemDetails_Save, Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel, Me.ButtonItemDetails_Calculate, Me.ButtonItemDetails_Copy, Me.ButtonItemDetails_CopyByCDP, Me.ButtonItemDetails_ShowDescriptions})
            Me.RibbonBarDetails_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarDetails_Details.Location = New System.Drawing.Point(362, 0)
            Me.RibbonBarDetails_Details.Name = "RibbonBarDetails_Details"
            Me.RibbonBarDetails_Details.Size = New System.Drawing.Size(459, 98)
            Me.RibbonBarDetails_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarDetails_Details.TabIndex = 1
            Me.RibbonBarDetails_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarDetails_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDetails_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDetails_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemDetails_Export
            '
            Me.ButtonItemDetails_Export.AutoExpandOnClick = True
            Me.ButtonItemDetails_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Export.Name = "ButtonItemDetails_Export"
            Me.ButtonItemDetails_Export.RibbonWordWrap = False
            Me.ButtonItemDetails_Export.SplitButton = True
            Me.ButtonItemDetails_Export.Stretch = True
            Me.ButtonItemDetails_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_CurrentView, Me.ButtonItemExport_All})
            Me.ButtonItemDetails_Export.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Export.Text = "Export"
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
            'ButtonItemDetails_Save
            '
            Me.ButtonItemDetails_Save.BeginGroup = True
            Me.ButtonItemDetails_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Save.Name = "ButtonItemDetails_Save"
            Me.ButtonItemDetails_Save.RibbonWordWrap = False
            Me.ButtonItemDetails_Save.Stretch = True
            Me.ButtonItemDetails_Save.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Save.Text = "Save"
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.Stretch = True
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.BeginGroup = True
            Me.ButtonItemDetails_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Cancel.Enabled = False
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.RibbonWordWrap = False
            Me.ButtonItemDetails_Cancel.Stretch = True
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
            Me.ButtonItemDetails_Cancel.Tooltip = "Cancel adding new row"
            '
            'ButtonItemDetails_Calculate
            '
            Me.ButtonItemDetails_Calculate.BeginGroup = True
            Me.ButtonItemDetails_Calculate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Calculate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Calculate.Name = "ButtonItemDetails_Calculate"
            Me.ButtonItemDetails_Calculate.RibbonWordWrap = False
            Me.ButtonItemDetails_Calculate.Stretch = True
            Me.ButtonItemDetails_Calculate.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Calculate.Text = "Calculate"
            '
            'ButtonItemDetails_Copy
            '
            Me.ButtonItemDetails_Copy.BeginGroup = True
            Me.ButtonItemDetails_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Copy.Name = "ButtonItemDetails_Copy"
            Me.ButtonItemDetails_Copy.RibbonWordWrap = False
            Me.ButtonItemDetails_Copy.Stretch = True
            Me.ButtonItemDetails_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Copy.Text = "Copy"
            '
            'ButtonItemDetails_CopyByCDP
            '
            Me.ButtonItemDetails_CopyByCDP.BeginGroup = True
            Me.ButtonItemDetails_CopyByCDP.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_CopyByCDP.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_CopyByCDP.Name = "ButtonItemDetails_CopyByCDP"
            Me.ButtonItemDetails_CopyByCDP.RibbonWordWrap = False
            Me.ButtonItemDetails_CopyByCDP.Stretch = True
            Me.ButtonItemDetails_CopyByCDP.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_CopyByCDP.Text = "Copy By C/D/P"
            '
            'ButtonItemDetails_ShowDescriptions
            '
            Me.ButtonItemDetails_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemDetails_ShowDescriptions.BeginGroup = True
            Me.ButtonItemDetails_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_ShowDescriptions.Name = "ButtonItemDetails_ShowDescriptions"
            Me.ButtonItemDetails_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemDetails_ShowDescriptions.Stretch = True
            Me.ButtonItemDetails_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_ShowDescriptions.Text = "Show Descriptions"
            '
            'RibbonBarOptions_Update
            '
            Me.RibbonBarOptions_Update.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Update.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Update.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Update.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Update.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Update.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpdate_FeeFlagUpdate})
            Me.RibbonBarOptions_Update.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Update.Location = New System.Drawing.Point(264, 0)
            Me.RibbonBarOptions_Update.Name = "RibbonBarOptions_Update"
            Me.RibbonBarOptions_Update.Size = New System.Drawing.Size(98, 98)
            Me.RibbonBarOptions_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Update.TabIndex = 2
            Me.RibbonBarOptions_Update.Text = "Update"
            '
            '
            '
            Me.RibbonBarOptions_Update.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Update.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Update.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemUpdate_FeeFlagUpdate
            '
            Me.ButtonItemUpdate_FeeFlagUpdate.BeginGroup = True
            Me.ButtonItemUpdate_FeeFlagUpdate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemUpdate_FeeFlagUpdate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemUpdate_FeeFlagUpdate.Name = "ButtonItemUpdate_FeeFlagUpdate"
            Me.ButtonItemUpdate_FeeFlagUpdate.RibbonWordWrap = False
            Me.ButtonItemUpdate_FeeFlagUpdate.Stretch = True
            Me.ButtonItemUpdate_FeeFlagUpdate.SubItemsExpandWidth = 14
            Me.ButtonItemUpdate_FeeFlagUpdate.Text = "Fee Flag Update"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_MoveUp, Me.ButtonItemActions_MoveDown, Me.ButtonItemActions_ViewAll})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(264, 98)
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
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            Me.ButtonItemActions_Cancel.Tooltip = "Cancel adding new row"
            '
            'ButtonItemActions_MoveUp
            '
            Me.ButtonItemActions_MoveUp.BeginGroup = True
            Me.ButtonItemActions_MoveUp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_MoveUp.Name = "ButtonItemActions_MoveUp"
            Me.ButtonItemActions_MoveUp.RibbonWordWrap = False
            Me.ButtonItemActions_MoveUp.Stretch = True
            Me.ButtonItemActions_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemActions_MoveUp.Text = "Move Up"
            '
            'ButtonItemActions_MoveDown
            '
            Me.ButtonItemActions_MoveDown.BeginGroup = True
            Me.ButtonItemActions_MoveDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_MoveDown.Name = "ButtonItemActions_MoveDown"
            Me.ButtonItemActions_MoveDown.RibbonWordWrap = False
            Me.ButtonItemActions_MoveDown.Stretch = True
            Me.ButtonItemActions_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemActions_MoveDown.Text = "Move Down"
            '
            'ButtonItemActions_ViewAll
            '
            Me.ButtonItemActions_ViewAll.AutoCheckOnClick = True
            Me.ButtonItemActions_ViewAll.BeginGroup = True
            Me.ButtonItemActions_ViewAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ViewAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ViewAll.Name = "ButtonItemActions_ViewAll"
            Me.ButtonItemActions_ViewAll.RibbonWordWrap = False
            Me.ButtonItemActions_ViewAll.Stretch = True
            Me.ButtonItemActions_ViewAll.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ViewAll.Text = "View All"
            '
            'BandedDataGridViewLeftSection_RateFlagLevels
            '
            Me.BandedDataGridViewLeftSection_RateFlagLevels.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewLeftSection_RateFlagLevels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewLeftSection_RateFlagLevels.AutoFilterLookupColumns = False
            Me.BandedDataGridViewLeftSection_RateFlagLevels.AutoloadRepositoryDatasource = True
            Me.BandedDataGridViewLeftSection_RateFlagLevels.ControlType = AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.Type.EditableGrid
            Me.BandedDataGridViewLeftSection_RateFlagLevels.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewLeftSection_RateFlagLevels.ItemDescription = ""
            Me.BandedDataGridViewLeftSection_RateFlagLevels.Location = New System.Drawing.Point(12, 12)
            Me.BandedDataGridViewLeftSection_RateFlagLevels.MultiSelect = True
            Me.BandedDataGridViewLeftSection_RateFlagLevels.Name = "BandedDataGridViewLeftSection_RateFlagLevels"
            Me.BandedDataGridViewLeftSection_RateFlagLevels.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.BandedDataGridViewLeftSection_RateFlagLevels.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewLeftSection_RateFlagLevels.Size = New System.Drawing.Size(315, 397)
            Me.BandedDataGridViewLeftSection_RateFlagLevels.TabIndex = 5
            Me.BandedDataGridViewLeftSection_RateFlagLevels.UseEmbeddedNavigator = False
            Me.BandedDataGridViewLeftSection_RateFlagLevels.ViewCaptionHeight = -1
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.BandedDataGridViewLeftSection_RateFlagLevels)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(332, 421)
            Me.PanelForm_LeftSection.TabIndex = 6
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(332, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 421)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 7
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.RateFlagEntryControlRightSection_RateFlag)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(338, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(537, 421)
            Me.PanelForm_RightSection.TabIndex = 8
            '
            'RateFlagEntryControlRightSection_RateFlag
            '
            Me.RateFlagEntryControlRightSection_RateFlag.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RateFlagEntryControlRightSection_RateFlag.DisableInactiveFilter = False
            Me.RateFlagEntryControlRightSection_RateFlag.HideStructureLevelSelection = False
            Me.RateFlagEntryControlRightSection_RateFlag.LimitToEmployeeLevels = False
            Me.RateFlagEntryControlRightSection_RateFlag.Location = New System.Drawing.Point(6, 12)
            Me.RateFlagEntryControlRightSection_RateFlag.Name = "RateFlagEntryControlRightSection_RateFlag"
            Me.RateFlagEntryControlRightSection_RateFlag.SelectedBillingRateLevel = CType(0, Short)
            Me.RateFlagEntryControlRightSection_RateFlag.ShowDescriptions = False
            Me.RateFlagEntryControlRightSection_RateFlag.Size = New System.Drawing.Size(519, 397)
            Me.RateFlagEntryControlRightSection_RateFlag.TabIndex = 0
            Me.RateFlagEntryControlRightSection_RateFlag.ViewInactiveBillingRateDetails = False
            '
            'RateFlagStructureSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(875, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RateFlagStructureSetupForm"
            Me.Text = "Rate Flag Structure/Entry"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_MoveUp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_MoveDown As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents BandedDataGridViewLeftSection_RateFlagLevels As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RateFlagEntryControlRightSection_RateFlag As AdvantageFramework.WinForm.Presentation.Controls.RateFlagEntryControl
        Friend WithEvents RibbonBarDetails_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Calculate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Update As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemUpdate_FeeFlagUpdate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ViewAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_ShowDescriptions As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_CopyByCDP As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

