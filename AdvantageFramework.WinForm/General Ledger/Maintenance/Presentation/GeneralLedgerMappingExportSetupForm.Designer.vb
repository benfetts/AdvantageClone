Namespace GeneralLedger.Maintenance.Views

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class GeneralLedgerMappingExportSetupForm
		Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()>
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
		<System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralLedgerMappingExportSetupForm))
			Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Sync = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarOptions_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ComboBoxRecordSource_RecordSource = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
			Me.ItemContainerRecordSource_RecordSource = New DevComponents.DotNetBar.ItemContainer()
			Me.ControlContainerItemRecordSource_RecordSource = New DevComponents.DotNetBar.ControlContainerItem()
			Me.ButtonItemRecordSource_Manage = New DevComponents.DotNetBar.ButtonItem()
			Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.DataGridViewForm_TargetAccounts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
			Me.DataGridViewForm_GeneralLedgerAccounts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
			Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
			Me.RibbonBarOptions_RecordSource.SuspendLayout()
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_LeftSection.SuspendLayout()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_RightSection.SuspendLayout()
			Me.SuspendLayout()
			'
			'RibbonBarMergeContainerForm_Options
			'
			Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_RecordSource)
			Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
			Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
			Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(700, 98)
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
			Me.RibbonBarOptions_Details.DragDropSupport = True
			Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel})
			Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(430, 0)
			Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
			Me.RibbonBarOptions_Details.SecurityEnabled = True
			Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(96, 98)
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
			Me.RibbonBarOptions_Actions.DragDropSupport = True
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Sync})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(264, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(166, 98)
			Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Actions.TabIndex = 1
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
			Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
			Me.ButtonItemActions_Export.RibbonWordWrap = False
			Me.ButtonItemActions_Export.Stretch = True
			Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Export.Text = "Export"
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
			'
			'ButtonItemActions_Sync
			'
			Me.ButtonItemActions_Sync.BeginGroup = True
			Me.ButtonItemActions_Sync.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Sync.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Sync.Name = "ButtonItemActions_Sync"
			Me.ButtonItemActions_Sync.RibbonWordWrap = False
			Me.ButtonItemActions_Sync.Stretch = True
			Me.ButtonItemActions_Sync.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Sync.Text = "Sync"
			'
			'RibbonBarOptions_RecordSource
			'
			Me.RibbonBarOptions_RecordSource.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_RecordSource.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_RecordSource.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_RecordSource.Controls.Add(Me.ComboBoxRecordSource_RecordSource)
			Me.RibbonBarOptions_RecordSource.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_RecordSource.DragDropSupport = True
			Me.RibbonBarOptions_RecordSource.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRecordSource_RecordSource, Me.ButtonItemRecordSource_Manage})
			Me.RibbonBarOptions_RecordSource.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_RecordSource.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_RecordSource.Name = "RibbonBarOptions_RecordSource"
			Me.RibbonBarOptions_RecordSource.SecurityEnabled = True
			Me.RibbonBarOptions_RecordSource.Size = New System.Drawing.Size(264, 98)
			Me.RibbonBarOptions_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_RecordSource.TabIndex = 0
			Me.RibbonBarOptions_RecordSource.Text = "Record Source"
			'
			'
			'
			Me.RibbonBarOptions_RecordSource.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_RecordSource.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_RecordSource.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ComboBoxRecordSource_RecordSource
			'
			Me.ComboBoxRecordSource_RecordSource.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxRecordSource_RecordSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxRecordSource_RecordSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxRecordSource_RecordSource.AutoFindItemInDataSource = False
			Me.ComboBoxRecordSource_RecordSource.AutoSelectSingleItemDatasource = False
			Me.ComboBoxRecordSource_RecordSource.BookmarkingEnabled = False
			Me.ComboBoxRecordSource_RecordSource.DisableMouseWheel = False
			Me.ComboBoxRecordSource_RecordSource.DisplayMember = "Display"
			Me.ComboBoxRecordSource_RecordSource.DisplayName = ""
			Me.ComboBoxRecordSource_RecordSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxRecordSource_RecordSource.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxRecordSource_RecordSource.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
			Me.ComboBoxRecordSource_RecordSource.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxRecordSource_RecordSource.FocusHighlightEnabled = True
			Me.ComboBoxRecordSource_RecordSource.FormattingEnabled = True
			Me.ComboBoxRecordSource_RecordSource.ItemHeight = 14
			Me.ComboBoxRecordSource_RecordSource.Location = New System.Drawing.Point(6, 54)
			Me.ComboBoxRecordSource_RecordSource.Name = "ComboBoxRecordSource_RecordSource"
			Me.ComboBoxRecordSource_RecordSource.ReadOnly = False
			Me.ComboBoxRecordSource_RecordSource.SecurityEnabled = True
			Me.ComboBoxRecordSource_RecordSource.Size = New System.Drawing.Size(200, 20)
			Me.ComboBoxRecordSource_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxRecordSource_RecordSource.TabIndex = 70
			Me.ComboBoxRecordSource_RecordSource.TabOnEnter = True
			Me.ComboBoxRecordSource_RecordSource.ValueMember = "Value"
			Me.ComboBoxRecordSource_RecordSource.WatermarkText = "Select Record Source"
			'
			'ItemContainerRecordSource_RecordSource
			'
			'
			'
			'
			Me.ItemContainerRecordSource_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainerRecordSource_RecordSource.Name = "ItemContainerRecordSource_RecordSource"
			Me.ItemContainerRecordSource_RecordSource.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemRecordSource_RecordSource})
			'
			'
			'
			Me.ItemContainerRecordSource_RecordSource.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.ItemContainerRecordSource_RecordSource.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ControlContainerItemRecordSource_RecordSource
			'
			Me.ControlContainerItemRecordSource_RecordSource.AllowItemResize = True
			Me.ControlContainerItemRecordSource_RecordSource.Control = Me.ComboBoxRecordSource_RecordSource
			Me.ControlContainerItemRecordSource_RecordSource.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
			Me.ControlContainerItemRecordSource_RecordSource.Name = "ControlContainerItemRecordSource_RecordSource"
			Me.ControlContainerItemRecordSource_RecordSource.Text = "ControlContainerItem2"
			'
			'ButtonItemRecordSource_Manage
			'
			Me.ButtonItemRecordSource_Manage.BeginGroup = True
			Me.ButtonItemRecordSource_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemRecordSource_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemRecordSource_Manage.Name = "ButtonItemRecordSource_Manage"
			Me.ButtonItemRecordSource_Manage.RibbonWordWrap = False
			Me.ButtonItemRecordSource_Manage.Stretch = True
			Me.ButtonItemRecordSource_Manage.SubItemsExpandWidth = 14
			Me.ButtonItemRecordSource_Manage.Text = "Manage"
			'
			'PanelForm_LeftSection
			'
			Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewForm_TargetAccounts)
			Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
			Me.PanelForm_LeftSection.Size = New System.Drawing.Size(281, 531)
			Me.PanelForm_LeftSection.TabIndex = 4
			'
			'DataGridViewForm_TargetAccounts
			'
			Me.DataGridViewForm_TargetAccounts.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_TargetAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_TargetAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_TargetAccounts.ItemDescription = "Target Account(s)"
			Me.DataGridViewForm_TargetAccounts.Location = New System.Drawing.Point(13, 12)
			Me.DataGridViewForm_TargetAccounts.Margin = New System.Windows.Forms.Padding(4)
			Me.DataGridViewForm_TargetAccounts.MultiSelect = True
			Me.DataGridViewForm_TargetAccounts.Name = "DataGridViewForm_TargetAccounts"
			Me.DataGridViewForm_TargetAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
			Me.DataGridViewForm_TargetAccounts.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_TargetAccounts.Size = New System.Drawing.Size(261, 506)
			Me.DataGridViewForm_TargetAccounts.TabIndex = 14
			Me.DataGridViewForm_TargetAccounts.ViewCaptionHeight = -1
			'
			'DataGridViewForm_GeneralLedgerAccounts
			'
			Me.DataGridViewForm_GeneralLedgerAccounts.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_GeneralLedgerAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_GeneralLedgerAccounts.DataSource = Nothing
			Me.DataGridViewForm_GeneralLedgerAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_GeneralLedgerAccounts.ItemDescription = "General Ledger Account(s)"
			Me.DataGridViewForm_GeneralLedgerAccounts.Location = New System.Drawing.Point(7, 13)
			Me.DataGridViewForm_GeneralLedgerAccounts.Margin = New System.Windows.Forms.Padding(4)
			Me.DataGridViewForm_GeneralLedgerAccounts.MultiSelect = True
			Me.DataGridViewForm_GeneralLedgerAccounts.Name = "DataGridViewForm_GeneralLedgerAccounts"
			Me.DataGridViewForm_GeneralLedgerAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
			Me.DataGridViewForm_GeneralLedgerAccounts.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_GeneralLedgerAccounts.Size = New System.Drawing.Size(496, 505)
			Me.DataGridViewForm_GeneralLedgerAccounts.TabIndex = 13
			Me.DataGridViewForm_GeneralLedgerAccounts.ViewCaptionHeight = -1
			'
			'ExpandableSplitterControl1
			'
			Me.ExpandableSplitterControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
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
			Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(0, 0)
			Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
			Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(3, 5)
			Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControl1.TabIndex = 0
			Me.ExpandableSplitterControl1.TabStop = False
			'
			'ExpandableSplitterControlForm_LeftRight
			'
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
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
			Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(281, 0)
			Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
			Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 531)
			Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
			Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
			'
			'PanelForm_RightSection
			'
			Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewForm_GeneralLedgerAccounts)
			Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelForm_RightSection.Location = New System.Drawing.Point(287, 0)
			Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
			Me.PanelForm_RightSection.Size = New System.Drawing.Size(516, 531)
			Me.PanelForm_RightSection.TabIndex = 6
			'
			'GeneralLedgerMappingExportSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(803, 531)
			Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
			Me.Controls.Add(Me.PanelForm_RightSection)
			Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
			Me.Controls.Add(Me.PanelForm_LeftSection)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "GeneralLedgerMappingExportSetupForm"
			Me.Text = "GL Mapping - Export"
			Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
			Me.RibbonBarOptions_RecordSource.ResumeLayout(False)
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_LeftSection.ResumeLayout(False)
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_RightSection.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
		Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
		Private WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
		Private WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents PanelForm_LeftSection As WinForm.Presentation.Controls.Panel
		Friend WithEvents ExpandableSplitterControl1 As WinForm.Presentation.Controls.ExpandableSplitterControl
		Friend WithEvents RibbonBarOptions_RecordSource As WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ComboBoxRecordSource_RecordSource As WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents ItemContainerRecordSource_RecordSource As DevComponents.DotNetBar.ItemContainer
		Friend WithEvents ControlContainerItemRecordSource_RecordSource As DevComponents.DotNetBar.ControlContainerItem
		Friend WithEvents ButtonItemRecordSource_Manage As DevComponents.DotNetBar.ButtonItem
		Private WithEvents ButtonItemActions_Sync As DevComponents.DotNetBar.ButtonItem
		Private WithEvents RibbonBarOptions_Details As WinForm.Presentation.Controls.RibbonBar
		Private WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem
		Private WithEvents ButtonItemDetails_Cancel As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents DataGridViewForm_GeneralLedgerAccounts As WinForm.MVC.Presentation.Controls.DataGridView
		Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents DataGridViewForm_TargetAccounts As WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents ExpandableSplitterControlForm_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
		Friend WithEvents PanelForm_RightSection As WinForm.Presentation.Controls.Panel
	End Class

End Namespace

