Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PartnerAllocationSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartnerAllocationSetupForm))
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_CampaignsOrOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Partners = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPartners_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPartners_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxSearch_AllocateBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxSearch_OrderType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_AllocateBy = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_OrderType = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSearch_Month = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemSearch_Search = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PartnerAllocationControlRightSection_PartnerAllocation = New AdvantageFramework.WinForm.Presentation.Controls.PartnerAllocationControl()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
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
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 399)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_CampaignsOrOrders)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 399)
            Me.PanelForm_LeftSection.TabIndex = 3
            '
            'DataGridViewLeftSection_CampaignsOrOrders
            '
            Me.DataGridViewLeftSection_CampaignsOrOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_CampaignsOrOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_CampaignsOrOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_CampaignsOrOrders.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_CampaignsOrOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_CampaignsOrOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_CampaignsOrOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_CampaignsOrOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_CampaignsOrOrders.ItemDescription = ""
            Me.DataGridViewLeftSection_CampaignsOrOrders.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_CampaignsOrOrders.MultiSelect = True
            Me.DataGridViewLeftSection_CampaignsOrOrders.Name = "DataGridViewLeftSection_CampaignsOrOrders"
            Me.DataGridViewLeftSection_CampaignsOrOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_CampaignsOrOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_CampaignsOrOrders.Size = New System.Drawing.Size(212, 375)
            Me.DataGridViewLeftSection_CampaignsOrOrders.TabIndex = 0
            Me.DataGridViewLeftSection_CampaignsOrOrders.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_CampaignsOrOrders.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Partners)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 296)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(506, 98)
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
            'RibbonBarOptions_Partners
            '
            Me.RibbonBarOptions_Partners.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Partners.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Partners.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Partners.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Partners.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Partners.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPartners_Delete, Me.ButtonItemPartners_Cancel})
            Me.RibbonBarOptions_Partners.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Partners.Location = New System.Drawing.Point(381, 0)
            Me.RibbonBarOptions_Partners.Name = "RibbonBarOptions_Partners"
            Me.RibbonBarOptions_Partners.Size = New System.Drawing.Size(99, 98)
            Me.RibbonBarOptions_Partners.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Partners.TabIndex = 6
            Me.RibbonBarOptions_Partners.Text = "Partners"
            '
            '
            '
            Me.RibbonBarOptions_Partners.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Partners.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Partners.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPartners_Cancel
            '
            Me.ButtonItemPartners_Cancel.BeginGroup = True
            Me.ButtonItemPartners_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPartners_Cancel.Name = "ButtonItemPartners_Cancel"
            Me.ButtonItemPartners_Cancel.RibbonWordWrap = False
            Me.ButtonItemPartners_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemPartners_Cancel.Text = "Cancel"
            '
            'ButtonItemPartners_Delete
            '
            Me.ButtonItemPartners_Delete.BeginGroup = True
            Me.ButtonItemPartners_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPartners_Delete.Name = "ButtonItemPartners_Delete"
            Me.ButtonItemPartners_Delete.RibbonWordWrap = False
            Me.ButtonItemPartners_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemPartners_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Controls.Add(Me.ComboBoxSearch_AllocateBy)
            Me.RibbonBarOptions_Search.Controls.Add(Me.ComboBoxSearch_OrderType)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ButtonItemSearch_Search})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(87, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(294, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 5
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxSearch_AllocateBy
            '
            Me.ComboBoxSearch_AllocateBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSearch_AllocateBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSearch_AllocateBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSearch_AllocateBy.AutoFindItemInDataSource = False
            Me.ComboBoxSearch_AllocateBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSearch_AllocateBy.BookmarkingEnabled = False
            Me.ComboBoxSearch_AllocateBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxSearch_AllocateBy.DisableMouseWheel = False
            Me.ComboBoxSearch_AllocateBy.DisplayMember = "Description"
            Me.ComboBoxSearch_AllocateBy.DisplayName = ""
            Me.ComboBoxSearch_AllocateBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSearch_AllocateBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSearch_AllocateBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSearch_AllocateBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSearch_AllocateBy.FocusHighlightEnabled = True
            Me.ComboBoxSearch_AllocateBy.FormattingEnabled = True
            Me.ComboBoxSearch_AllocateBy.ItemHeight = 14
            Me.ComboBoxSearch_AllocateBy.Location = New System.Drawing.Point(72, 54)
            Me.ComboBoxSearch_AllocateBy.Name = "ComboBoxSearch_AllocateBy"
            Me.ComboBoxSearch_AllocateBy.PreventEnterBeep = False
            Me.ComboBoxSearch_AllocateBy.ReadOnly = False
            Me.ComboBoxSearch_AllocateBy.Size = New System.Drawing.Size(150, 20)
            Me.ComboBoxSearch_AllocateBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSearch_AllocateBy.TabIndex = 1
            Me.ComboBoxSearch_AllocateBy.ValueMember = "Code"
            Me.ComboBoxSearch_AllocateBy.WatermarkText = "Select"
            '
            'ComboBoxSearch_OrderType
            '
            Me.ComboBoxSearch_OrderType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSearch_OrderType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSearch_OrderType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSearch_OrderType.AutoFindItemInDataSource = False
            Me.ComboBoxSearch_OrderType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSearch_OrderType.BookmarkingEnabled = False
            Me.ComboBoxSearch_OrderType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxSearch_OrderType.DisableMouseWheel = False
            Me.ComboBoxSearch_OrderType.DisplayMember = "Description"
            Me.ComboBoxSearch_OrderType.DisplayName = ""
            Me.ComboBoxSearch_OrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSearch_OrderType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSearch_OrderType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSearch_OrderType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSearch_OrderType.FocusHighlightEnabled = True
            Me.ComboBoxSearch_OrderType.FormattingEnabled = True
            Me.ComboBoxSearch_OrderType.ItemHeight = 14
            Me.ComboBoxSearch_OrderType.Location = New System.Drawing.Point(72, 77)
            Me.ComboBoxSearch_OrderType.Name = "ComboBoxSearch_OrderType"
            Me.ComboBoxSearch_OrderType.PreventEnterBeep = False
            Me.ComboBoxSearch_OrderType.ReadOnly = False
            Me.ComboBoxSearch_OrderType.Size = New System.Drawing.Size(150, 20)
            Me.ComboBoxSearch_OrderType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSearch_OrderType.TabIndex = 1
            Me.ComboBoxSearch_OrderType.ValueMember = "Code"
            Me.ComboBoxSearch_OrderType.WatermarkText = "Select"
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4, Me.ItemContainer2})
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainer4
            '
            '
            '
            '
            Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer4.Name = "ItemContainer4"
            Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_AllocateBy, Me.ControlContainerItem1})
            '
            '
            '
            Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_AllocateBy
            '
            Me.LabelItemSearch_AllocateBy.Name = "LabelItemSearch_AllocateBy"
            Me.LabelItemSearch_AllocateBy.Text = "Allocate By:"
            Me.LabelItemSearch_AllocateBy.Width = 65
            '
            'ControlContainerItem1
            '
            Me.ControlContainerItem1.AllowItemResize = True
            Me.ControlContainerItem1.Control = Me.ComboBoxSearch_AllocateBy
            Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem1.Name = "ControlContainerItem1"
            Me.ControlContainerItem1.Text = "ControlContainerItem1"
            '
            'ItemContainer2
            '
            '
            '
            '
            Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.Name = "ItemContainer2"
            Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_OrderType, Me.ControlContainerItemSearch_Month})
            '
            '
            '
            Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_OrderType
            '
            Me.LabelItemSearch_OrderType.Name = "LabelItemSearch_OrderType"
            Me.LabelItemSearch_OrderType.Text = "Order Type:"
            Me.LabelItemSearch_OrderType.Width = 65
            '
            'ControlContainerItemSearch_Month
            '
            Me.ControlContainerItemSearch_Month.AllowItemResize = True
            Me.ControlContainerItemSearch_Month.Control = Me.ComboBoxSearch_OrderType
            Me.ControlContainerItemSearch_Month.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_Month.Name = "ControlContainerItemSearch_Month"
            Me.ControlContainerItemSearch_Month.Text = "ControlContainerItem2"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Search.Text = "Search"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(87, 98)
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
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PartnerAllocationControlRightSection_PartnerAllocation)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(467, 399)
            Me.PanelForm_RightSection.TabIndex = 5
            '
            'PartnerAllocationControlRightSection_PartnerAllocation
            '
            Me.PartnerAllocationControlRightSection_PartnerAllocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PartnerAllocationControlRightSection_PartnerAllocation.Location = New System.Drawing.Point(6, 12)
            Me.PartnerAllocationControlRightSection_PartnerAllocation.Name = "PartnerAllocationControlRightSection_PartnerAllocation"
            Me.PartnerAllocationControlRightSection_PartnerAllocation.Size = New System.Drawing.Size(449, 375)
            Me.PartnerAllocationControlRightSection_PartnerAllocation.TabIndex = 0
            '
            'PartnerAllocationSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(703, 399)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PartnerAllocationSetupForm"
            Me.Text = "Partner Allocation Maintenance"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_CampaignsOrOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_Partners As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPartners_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPartners_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxSearch_AllocateBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxSearch_OrderType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_AllocateBy As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_OrderType As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSearch_Month As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemSearch_Search As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PartnerAllocationControlRightSection_PartnerAllocation As AdvantageFramework.WinForm.Presentation.Controls.PartnerAllocationControl
    End Class

End Namespace