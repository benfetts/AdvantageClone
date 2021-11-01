Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RateCardContractSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RateCardContractSetupForm))
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_RateCardContracts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemText_CheckSpelling = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_ColorCharges = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemColorCharges_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemColorCharges_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_RateDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRateDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRateDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RateCardContractControlRightSection_RateCardContract = New AdvantageFramework.WinForm.Presentation.Controls.RateCardContractControl()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
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
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 668)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_RateCardContracts)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 668)
            Me.PanelForm_LeftSection.TabIndex = 3
            '
            'DataGridViewLeftSection_RateCardContracts
            '
            Me.DataGridViewLeftSection_RateCardContracts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_RateCardContracts.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_RateCardContracts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_RateCardContracts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_RateCardContracts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_RateCardContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_RateCardContracts.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_RateCardContracts.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_RateCardContracts.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_RateCardContracts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_RateCardContracts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_RateCardContracts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_RateCardContracts.ItemDescription = ""
            Me.DataGridViewLeftSection_RateCardContracts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_RateCardContracts.MultiSelect = True
            Me.DataGridViewLeftSection_RateCardContracts.Name = "DataGridViewLeftSection_RateCardContracts"
            Me.DataGridViewLeftSection_RateCardContracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_RateCardContracts.RunStandardValidation = True
            Me.DataGridViewLeftSection_RateCardContracts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_RateCardContracts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_RateCardContracts.Size = New System.Drawing.Size(212, 644)
            Me.DataGridViewLeftSection_RateCardContracts.TabIndex = 0
            Me.DataGridViewLeftSection_RateCardContracts.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_RateCardContracts.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Text)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_ColorCharges)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_RateDetails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 406)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(692, 98)
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
            Me.RibbonBarOptions_Text.DragDropSupport = True
            Me.RibbonBarOptions_Text.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemText_CheckSpelling})
            Me.RibbonBarOptions_Text.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(429, 0)
            Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
            Me.RibbonBarOptions_Text.SecurityEnabled = True
            Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(99, 98)
            Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Text.TabIndex = 7
            Me.RibbonBarOptions_Text.Text = "Text"
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Text.Visible = False
            '
            'ButtonItemText_CheckSpelling
            '
            Me.ButtonItemText_CheckSpelling.BeginGroup = True
            Me.ButtonItemText_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemText_CheckSpelling.Name = "ButtonItemText_CheckSpelling"
            Me.ButtonItemText_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemText_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemText_CheckSpelling.Text = "Check Spelling"
            '
            'RibbonBarMergeContainerForm_ColorCharges
            '
            Me.RibbonBarMergeContainerForm_ColorCharges.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ColorCharges.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ColorCharges.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_ColorCharges.ContainerControlProcessDialogKey = True
            Me.RibbonBarMergeContainerForm_ColorCharges.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarMergeContainerForm_ColorCharges.DragDropSupport = True
            Me.RibbonBarMergeContainerForm_ColorCharges.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemColorCharges_Delete, Me.ButtonItemColorCharges_Cancel})
            Me.RibbonBarMergeContainerForm_ColorCharges.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarMergeContainerForm_ColorCharges.Location = New System.Drawing.Point(313, 0)
            Me.RibbonBarMergeContainerForm_ColorCharges.Name = "RibbonBarMergeContainerForm_ColorCharges"
            Me.RibbonBarMergeContainerForm_ColorCharges.SecurityEnabled = True
            Me.RibbonBarMergeContainerForm_ColorCharges.Size = New System.Drawing.Size(116, 98)
            Me.RibbonBarMergeContainerForm_ColorCharges.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_ColorCharges.TabIndex = 5
            Me.RibbonBarMergeContainerForm_ColorCharges.Text = "Color Charges"
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ColorCharges.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ColorCharges.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_ColorCharges.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemColorCharges_Delete
            '
            Me.ButtonItemColorCharges_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemColorCharges_Delete.Name = "ButtonItemColorCharges_Delete"
            Me.ButtonItemColorCharges_Delete.Text = "Delete"
            '
            'ButtonItemColorCharges_Cancel
            '
            Me.ButtonItemColorCharges_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemColorCharges_Cancel.Name = "ButtonItemColorCharges_Cancel"
            Me.ButtonItemColorCharges_Cancel.Text = "Cancel"
            '
            'RibbonBarMergeContainerForm_RateDetails
            '
            Me.RibbonBarMergeContainerForm_RateDetails.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarMergeContainerForm_RateDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_RateDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_RateDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarMergeContainerForm_RateDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarMergeContainerForm_RateDetails.DragDropSupport = True
            Me.RibbonBarMergeContainerForm_RateDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRateDetails_Delete, Me.ButtonItemRateDetails_Cancel})
            Me.RibbonBarMergeContainerForm_RateDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarMergeContainerForm_RateDetails.Location = New System.Drawing.Point(196, 0)
            Me.RibbonBarMergeContainerForm_RateDetails.Name = "RibbonBarMergeContainerForm_RateDetails"
            Me.RibbonBarMergeContainerForm_RateDetails.SecurityEnabled = True
            Me.RibbonBarMergeContainerForm_RateDetails.Size = New System.Drawing.Size(117, 98)
            Me.RibbonBarMergeContainerForm_RateDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_RateDetails.TabIndex = 4
            Me.RibbonBarMergeContainerForm_RateDetails.Text = "Rate Details"
            '
            '
            '
            Me.RibbonBarMergeContainerForm_RateDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_RateDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_RateDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemRateDetails_Delete
            '
            Me.ButtonItemRateDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRateDetails_Delete.Name = "ButtonItemRateDetails_Delete"
            Me.ButtonItemRateDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemRateDetails_Delete.Stretch = True
            Me.ButtonItemRateDetails_Delete.Text = "Delete"
            '
            'ButtonItemRateDetails_Cancel
            '
            Me.ButtonItemRateDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRateDetails_Cancel.Name = "ButtonItemRateDetails_Cancel"
            Me.ButtonItemRateDetails_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(196, 98)
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
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.RateCardContractControlRightSection_RateCardContract)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(947, 668)
            Me.PanelForm_RightSection.TabIndex = 5
            '
            'RateCardContractControlRightSection_RateCardContract
            '
            Me.RateCardContractControlRightSection_RateCardContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RateCardContractControlRightSection_RateCardContract.Location = New System.Drawing.Point(6, 12)
            Me.RateCardContractControlRightSection_RateCardContract.Name = "RateCardContractControlRightSection_RateCardContract"
            Me.RateCardContractControlRightSection_RateCardContract.Size = New System.Drawing.Size(929, 644)
            Me.RateCardContractControlRightSection_RateCardContract.TabIndex = 0
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RateCardContractSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1183, 668)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RateCardContractSetupForm"
            Me.Text = "Rate Card/Contract Maintenance"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_RateCardContracts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RateCardContractControlRightSection_RateCardContract As AdvantageFramework.WinForm.Presentation.Controls.RateCardContractControl
        Friend WithEvents RibbonBarMergeContainerForm_ColorCharges As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemColorCharges_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemColorCharges_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_RateDetails As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRateDetails_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRateDetails_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace