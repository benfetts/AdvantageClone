Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimateTemplatesSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimateTemplatesSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_EstimateTemplateExport = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_EstimateTemplate = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.EstimateTemplateControlRightSection_EstimateTemplate = New AdvantageFramework.WinForm.Presentation.Controls.EstimateTemplateControl()
            Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemText_CheckSpelling = New DevComponents.DotNetBar.ButtonItem()
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
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Text)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(152, 82)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(486, 95)
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
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Copy, Me.ButtonItemDetails_Cancel})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(161, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.SecurityEnabled = True
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(129, 95)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 1
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(161, 95)
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
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SplitButton = True
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
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_EstimateTemplateExport)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_EstimateTemplate)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(602, 520)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_EstimateTemplateExport
            '
            Me.DataGridViewLeftSection_EstimateTemplateExport.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_EstimateTemplateExport.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_EstimateTemplateExport.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_EstimateTemplateExport.Enabled = False
            Me.DataGridViewLeftSection_EstimateTemplateExport.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_EstimateTemplateExport.ItemDescription = ""
            Me.DataGridViewLeftSection_EstimateTemplateExport.Location = New System.Drawing.Point(322, 5)
            Me.DataGridViewLeftSection_EstimateTemplateExport.MultiSelect = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.Name = "DataGridViewLeftSection_EstimateTemplateExport"
            Me.DataGridViewLeftSection_EstimateTemplateExport.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_EstimateTemplateExport.RunStandardValidation = True
            Me.DataGridViewLeftSection_EstimateTemplateExport.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_EstimateTemplateExport.Size = New System.Drawing.Size(274, 219)
            Me.DataGridViewLeftSection_EstimateTemplateExport.TabIndex = 1
            Me.DataGridViewLeftSection_EstimateTemplateExport.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_EstimateTemplateExport.ViewCaptionHeight = -1
            Me.DataGridViewLeftSection_EstimateTemplateExport.Visible = False
            '
            'DataGridViewLeftSection_EstimateTemplate
            '
            Me.DataGridViewLeftSection_EstimateTemplate.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_EstimateTemplate.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_EstimateTemplate.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_EstimateTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_EstimateTemplate.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_EstimateTemplate.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_EstimateTemplate.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_EstimateTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_EstimateTemplate.DataSource = Nothing
            Me.DataGridViewLeftSection_EstimateTemplate.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_EstimateTemplate.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_EstimateTemplate.ItemDescription = ""
            Me.DataGridViewLeftSection_EstimateTemplate.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_EstimateTemplate.MultiSelect = True
            Me.DataGridViewLeftSection_EstimateTemplate.Name = "DataGridViewLeftSection_EstimateTemplate"
            Me.DataGridViewLeftSection_EstimateTemplate.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_EstimateTemplate.RunStandardValidation = True
            Me.DataGridViewLeftSection_EstimateTemplate.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_EstimateTemplate.Size = New System.Drawing.Size(584, 496)
            Me.DataGridViewLeftSection_EstimateTemplate.TabIndex = 0
            Me.DataGridViewLeftSection_EstimateTemplate.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_EstimateTemplate.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(602, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 520)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.EstimateTemplateControlRightSection_EstimateTemplate)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(608, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(366, 520)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'EstimateTemplateControlRightSection_EstimateTemplate
            '
            Me.EstimateTemplateControlRightSection_EstimateTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EstimateTemplateControlRightSection_EstimateTemplate.Location = New System.Drawing.Point(6, 12)
            Me.EstimateTemplateControlRightSection_EstimateTemplate.Name = "EstimateTemplateControlRightSection_EstimateTemplate"
            Me.EstimateTemplateControlRightSection_EstimateTemplate.Size = New System.Drawing.Size(348, 496)
            Me.EstimateTemplateControlRightSection_EstimateTemplate.TabIndex = 0
            '
            'RibbonBarOptions_Text
            '
            Me.RibbonBarOptions_Text.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Text.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Text.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemText_CheckSpelling})
            Me.RibbonBarOptions_Text.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(290, 0)
            Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
            Me.RibbonBarOptions_Text.SecurityEnabled = True
            Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(94, 95)
            Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Text.TabIndex = 2
            Me.RibbonBarOptions_Text.Text = "Text"
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemText_CheckSpelling
            '
            Me.ButtonItemText_CheckSpelling.BeginGroup = True
            Me.ButtonItemText_CheckSpelling.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemText_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemText_CheckSpelling.Name = "ButtonItemText_CheckSpelling"
            Me.ButtonItemText_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemText_CheckSpelling.Stretch = True
            Me.ButtonItemText_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemText_CheckSpelling.Text = "Check Spelling"
            '
            'EstimateTemplatesSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(974, 520)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EstimateTemplatesSetupForm"
            Me.Text = "Estimate Templates Maintenance"
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
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_EstimateTemplate As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents EstimateTemplateControlRightSection_EstimateTemplate As AdvantageFramework.WinForm.Presentation.Controls.EstimateTemplateControl
        Friend WithEvents RibbonBarOptions_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewLeftSection_EstimateTemplateExport As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

