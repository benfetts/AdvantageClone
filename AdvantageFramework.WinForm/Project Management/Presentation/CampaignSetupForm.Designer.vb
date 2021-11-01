Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CampaignSetupForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CampaignSetupForm))
			Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.CampaignControlRightSection_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.CampaignControl()
			Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.DataGridViewLeftSection_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemSpelling_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Budget = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemBudget_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemBudget_ReAllocate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_CampaignDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemCampaignDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemCampaignDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_ChangeCode = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_RightSection.SuspendLayout()
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_LeftSection.SuspendLayout()
			Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
			Me.SuspendLayout()
			'
			'PanelForm_RightSection
			'
			Me.PanelForm_RightSection.Controls.Add(Me.CampaignControlRightSection_Campaign)
			Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
			Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
			Me.PanelForm_RightSection.Size = New System.Drawing.Size(658, 477)
			Me.PanelForm_RightSection.TabIndex = 5
			'
			'CampaignControlRightSection_Campaign
			'
			Me.CampaignControlRightSection_Campaign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.CampaignControlRightSection_Campaign.CampaignClosedEnabled = True
			Me.CampaignControlRightSection_Campaign.Location = New System.Drawing.Point(6, 12)
			Me.CampaignControlRightSection_Campaign.Name = "CampaignControlRightSection_Campaign"
			Me.CampaignControlRightSection_Campaign.Size = New System.Drawing.Size(640, 453)
			Me.CampaignControlRightSection_Campaign.TabIndex = 0
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
			Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 477)
			Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
			Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
			'
			'PanelForm_LeftSection
			'
			Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Campaigns)
			Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
			Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 477)
			Me.PanelForm_LeftSection.TabIndex = 3
			'
			'DataGridViewLeftSection_Campaigns
			'
			Me.DataGridViewLeftSection_Campaigns.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewLeftSection_Campaigns.AllowDragAndDrop = False
			Me.DataGridViewLeftSection_Campaigns.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewLeftSection_Campaigns.AllowSelectGroupHeaderRow = True
			Me.DataGridViewLeftSection_Campaigns.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewLeftSection_Campaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewLeftSection_Campaigns.AutoFilterLookupColumns = False
			Me.DataGridViewLeftSection_Campaigns.AutoloadRepositoryDatasource = True
			Me.DataGridViewLeftSection_Campaigns.AutoUpdateViewCaption = True
			Me.DataGridViewLeftSection_Campaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewLeftSection_Campaigns.DataSource = Nothing
			Me.DataGridViewLeftSection_Campaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewLeftSection_Campaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewLeftSection_Campaigns.ItemDescription = "Campaign(s)"
			Me.DataGridViewLeftSection_Campaigns.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewLeftSection_Campaigns.MultiSelect = True
			Me.DataGridViewLeftSection_Campaigns.Name = "DataGridViewLeftSection_Campaigns"
			Me.DataGridViewLeftSection_Campaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewLeftSection_Campaigns.RunStandardValidation = True
			Me.DataGridViewLeftSection_Campaigns.ShowColumnMenuOnRightClick = False
			Me.DataGridViewLeftSection_Campaigns.ShowSelectDeselectAllButtons = False
			Me.DataGridViewLeftSection_Campaigns.Size = New System.Drawing.Size(212, 453)
			Me.DataGridViewLeftSection_Campaigns.TabIndex = 1
			Me.DataGridViewLeftSection_Campaigns.UseEmbeddedNavigator = False
			Me.DataGridViewLeftSection_Campaigns.ViewCaptionHeight = -1
			'
			'RibbonBarMergeContainerForm_Options
			'
			Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CheckSpelling)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Budget)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CampaignDetails)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(28, 189)
			Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
			Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
			Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(865, 98)
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
			'RibbonBarOptions_CheckSpelling
			'
			Me.RibbonBarOptions_CheckSpelling.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_CheckSpelling.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_CheckSpelling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_CheckSpelling.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_CheckSpelling.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_CheckSpelling.DragDropSupport = True
			Me.RibbonBarOptions_CheckSpelling.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSpelling_CheckSpelling})
			Me.RibbonBarOptions_CheckSpelling.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_CheckSpelling.Location = New System.Drawing.Point(681, 0)
			Me.RibbonBarOptions_CheckSpelling.Name = "RibbonBarOptions_CheckSpelling"
			Me.RibbonBarOptions_CheckSpelling.SecurityEnabled = True
			Me.RibbonBarOptions_CheckSpelling.Size = New System.Drawing.Size(91, 98)
			Me.RibbonBarOptions_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_CheckSpelling.TabIndex = 9
			Me.RibbonBarOptions_CheckSpelling.Text = "Spelling"
			'
			'
			'
			Me.RibbonBarOptions_CheckSpelling.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_CheckSpelling.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_CheckSpelling.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
			'RibbonBarOptions_Documents
			'
			Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Documents.DragDropSupport = True
			Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
			Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(466, 0)
			Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
			Me.RibbonBarOptions_Documents.SecurityEnabled = True
			Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(215, 98)
			Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Documents.TabIndex = 8
			Me.RibbonBarOptions_Documents.Text = "Documents"
			'
			'
			'
			Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemDocuments_Upload
			'
			Me.ButtonItemDocuments_Upload.BeginGroup = True
			Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
			Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
			Me.ButtonItemDocuments_Upload.SecurityEnabled = True
			Me.ButtonItemDocuments_Upload.SplitButton = True
			Me.ButtonItemDocuments_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
			Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Upload.Text = "Upload"
			'
			'ButtonItemDocuments_Download
			'
			Me.ButtonItemDocuments_Download.BeginGroup = True
			Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
			Me.ButtonItemDocuments_Download.RibbonWordWrap = False
			Me.ButtonItemDocuments_Download.SecurityEnabled = True
			Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Download.Text = "Download"
			'
			'ButtonItemDocuments_OpenURL
			'
			Me.ButtonItemDocuments_OpenURL.BeginGroup = True
			Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
			Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
			Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
			Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
			'
			'ButtonItemDocuments_Delete
			'
			Me.ButtonItemDocuments_Delete.BeginGroup = True
			Me.ButtonItemDocuments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Delete.Name = "ButtonItemDocuments_Delete"
			Me.ButtonItemDocuments_Delete.RibbonWordWrap = False
			Me.ButtonItemDocuments_Delete.SecurityEnabled = True
			Me.ButtonItemDocuments_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Delete.Text = "Delete"
			'
			'RibbonBarOptions_Budget
			'
			Me.RibbonBarOptions_Budget.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Budget.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Budget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Budget.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Budget.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Budget.DragDropSupport = True
			Me.RibbonBarOptions_Budget.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBudget_Create, Me.ButtonItemBudget_ReAllocate})
			Me.RibbonBarOptions_Budget.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Budget.Location = New System.Drawing.Point(308, 0)
			Me.RibbonBarOptions_Budget.Name = "RibbonBarOptions_Budget"
			Me.RibbonBarOptions_Budget.SecurityEnabled = True
			Me.RibbonBarOptions_Budget.Size = New System.Drawing.Size(158, 98)
			Me.RibbonBarOptions_Budget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Budget.TabIndex = 2
			Me.RibbonBarOptions_Budget.Text = "Budget"
			'
			'
			'
			Me.RibbonBarOptions_Budget.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Budget.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Budget.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			Me.RibbonBarOptions_Budget.Visible = False
			'
			'ButtonItemBudget_Create
			'
			Me.ButtonItemBudget_Create.BeginGroup = True
			Me.ButtonItemBudget_Create.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemBudget_Create.Name = "ButtonItemBudget_Create"
			Me.ButtonItemBudget_Create.RibbonWordWrap = False
			Me.ButtonItemBudget_Create.SecurityEnabled = True
			Me.ButtonItemBudget_Create.SubItemsExpandWidth = 14
			Me.ButtonItemBudget_Create.Text = "Create"
			'
			'ButtonItemBudget_ReAllocate
			'
			Me.ButtonItemBudget_ReAllocate.BeginGroup = True
			Me.ButtonItemBudget_ReAllocate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemBudget_ReAllocate.Name = "ButtonItemBudget_ReAllocate"
			Me.ButtonItemBudget_ReAllocate.RibbonWordWrap = False
			Me.ButtonItemBudget_ReAllocate.SecurityEnabled = True
			Me.ButtonItemBudget_ReAllocate.SubItemsExpandWidth = 14
			Me.ButtonItemBudget_ReAllocate.Text = "Re-Allocate"
			'
			'RibbonBarOptions_CampaignDetails
			'
			Me.RibbonBarOptions_CampaignDetails.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_CampaignDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_CampaignDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_CampaignDetails.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_CampaignDetails.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_CampaignDetails.DragDropSupport = True
			Me.RibbonBarOptions_CampaignDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCampaignDetails_Delete, Me.ButtonItemCampaignDetails_Cancel})
			Me.RibbonBarOptions_CampaignDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_CampaignDetails.Location = New System.Drawing.Point(214, 0)
			Me.RibbonBarOptions_CampaignDetails.Name = "RibbonBarOptions_CampaignDetails"
			Me.RibbonBarOptions_CampaignDetails.SecurityEnabled = True
			Me.RibbonBarOptions_CampaignDetails.Size = New System.Drawing.Size(94, 98)
			Me.RibbonBarOptions_CampaignDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_CampaignDetails.TabIndex = 1
			Me.RibbonBarOptions_CampaignDetails.Text = "Details"
			'
			'
			'
			Me.RibbonBarOptions_CampaignDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_CampaignDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_CampaignDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			Me.RibbonBarOptions_CampaignDetails.Visible = False
			'
			'ButtonItemCampaignDetails_Delete
			'
			Me.ButtonItemCampaignDetails_Delete.BeginGroup = True
			Me.ButtonItemCampaignDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemCampaignDetails_Delete.Name = "ButtonItemCampaignDetails_Delete"
			Me.ButtonItemCampaignDetails_Delete.RibbonWordWrap = False
			Me.ButtonItemCampaignDetails_Delete.SecurityEnabled = True
			Me.ButtonItemCampaignDetails_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemCampaignDetails_Delete.Text = "Delete"
			'
			'ButtonItemCampaignDetails_Cancel
			'
			Me.ButtonItemCampaignDetails_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemCampaignDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemCampaignDetails_Cancel.Name = "ButtonItemCampaignDetails_Cancel"
			Me.ButtonItemCampaignDetails_Cancel.SecurityEnabled = True
			Me.ButtonItemCampaignDetails_Cancel.Stretch = True
			Me.ButtonItemCampaignDetails_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemCampaignDetails_Cancel.Text = "Cancel"
			Me.ButtonItemCampaignDetails_Cancel.Tooltip = "Cancel adding new row"
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_ChangeCode})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(214, 98)
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
			'ButtonItemActions_Delete
			'
			Me.ButtonItemActions_Delete.BeginGroup = True
			Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
			Me.ButtonItemActions_Delete.RibbonWordWrap = False
			Me.ButtonItemActions_Delete.SecurityEnabled = True
			Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Delete.Text = "Delete"
			'
			'ButtonItemActions_ChangeCode
			'
			Me.ButtonItemActions_ChangeCode.BeginGroup = True
			Me.ButtonItemActions_ChangeCode.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_ChangeCode.Name = "ButtonItemActions_ChangeCode"
			Me.ButtonItemActions_ChangeCode.RibbonWordWrap = False
			Me.ButtonItemActions_ChangeCode.SecurityEnabled = True
			Me.ButtonItemActions_ChangeCode.SubItemsExpandWidth = 14
			Me.ButtonItemActions_ChangeCode.Text = "Change Code"
			'
			'ButtonItemUpload_EmailLink
			'
			Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
			Me.ButtonItemUpload_EmailLink.Text = "Email Link"
			'
			'CampaignSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(894, 477)
			Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
			Me.Controls.Add(Me.PanelForm_RightSection)
			Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
			Me.Controls.Add(Me.PanelForm_LeftSection)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "CampaignSetupForm"
			Me.Text = "Campaigns"
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
        Friend WithEvents DataGridViewLeftSection_Campaigns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CampaignControlRightSection_Campaign As AdvantageFramework.WinForm.Presentation.Controls.CampaignControl
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Budget As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBudget_Create As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBudget_ReAllocate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CampaignDetails As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCampaignDetails_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCampaignDetails_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ChangeCode As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpelling_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace