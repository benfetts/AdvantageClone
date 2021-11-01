Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ImportForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportForm))
            Me.RibbonBarOptions_Navigation = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxSettings_ImportType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxSettings_Batch = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerSearch_Search = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerSearch_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerVertical_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSettings_ImportType = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSettings_Batch = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.RibbonBarOptions_Templates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplates_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CSIPreferredPartner = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCSIPreferredPartner_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_OnHold = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOnHold_Check = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOnHold_Uncheck = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Orders = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaOrder_Match = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaOrder_MatchBroadcastMonth = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaOrder_MatchCalendarMonth = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaOrder_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaOrder_AddToWorksheet = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_AccountPayable = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemAccountPayable_ShowAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAccountPayable_UpdateDescription = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAccountPayable_WriteOff = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAccountPayable_ClearOrderLine = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAccountPayable_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAccountPayable_UpdateVendorToPayToVendor = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ClearedChecks = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemClearedChecks_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemClearedChecks_Valid = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemClearedChecks_Invalid = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Import = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemImport_NewBatch = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Validate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Mapping = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_ImportedItems = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ContextMenuStripForm_MappingMenu = New AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip()
            Me.MappingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.RibbonBarOptions_Navigation.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.ContextMenuStripForm_MappingMenu.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarOptions_Navigation
            '
            Me.RibbonBarOptions_Navigation.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Navigation.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Navigation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Navigation.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Navigation.Controls.Add(Me.ComboBoxSettings_ImportType)
            Me.RibbonBarOptions_Navigation.Controls.Add(Me.ComboBoxSettings_Batch)
            Me.RibbonBarOptions_Navigation.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Navigation.DragDropSupport = True
            Me.RibbonBarOptions_Navigation.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Search})
            Me.RibbonBarOptions_Navigation.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Navigation.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Navigation.Name = "RibbonBarOptions_Navigation"
            Me.RibbonBarOptions_Navigation.SecurityEnabled = True
            Me.RibbonBarOptions_Navigation.Size = New System.Drawing.Size(258, 98)
            Me.RibbonBarOptions_Navigation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Navigation.TabIndex = 4
            Me.RibbonBarOptions_Navigation.Text = "Navigation"
            '
            '
            '
            Me.RibbonBarOptions_Navigation.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Navigation.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Navigation.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxSettings_ImportType
            '
            Me.ComboBoxSettings_ImportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSettings_ImportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSettings_ImportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSettings_ImportType.AutoFindItemInDataSource = False
            Me.ComboBoxSettings_ImportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSettings_ImportType.BookmarkingEnabled = False
            Me.ComboBoxSettings_ImportType.ClientCode = ""
            Me.ComboBoxSettings_ImportType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxSettings_ImportType.DisableMouseWheel = False
            Me.ComboBoxSettings_ImportType.DisplayMember = "Text"
            Me.ComboBoxSettings_ImportType.DisplayName = ""
            Me.ComboBoxSettings_ImportType.DivisionCode = ""
            Me.ComboBoxSettings_ImportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSettings_ImportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSettings_ImportType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSettings_ImportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSettings_ImportType.FocusHighlightEnabled = True
            Me.ComboBoxSettings_ImportType.FormattingEnabled = True
            Me.ComboBoxSettings_ImportType.ItemHeight = 14
            Me.ComboBoxSettings_ImportType.Location = New System.Drawing.Point(77, 21)
            Me.ComboBoxSettings_ImportType.Name = "ComboBoxSettings_ImportType"
            Me.ComboBoxSettings_ImportType.ReadOnly = False
            Me.ComboBoxSettings_ImportType.SecurityEnabled = True
            Me.ComboBoxSettings_ImportType.Size = New System.Drawing.Size(175, 20)
            Me.ComboBoxSettings_ImportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSettings_ImportType.TabIndex = 70
            Me.ComboBoxSettings_ImportType.TabOnEnter = True
            '
            'ComboBoxSettings_Batch
            '
            Me.ComboBoxSettings_Batch.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSettings_Batch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSettings_Batch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSettings_Batch.AutoFindItemInDataSource = False
            Me.ComboBoxSettings_Batch.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSettings_Batch.BookmarkingEnabled = False
            Me.ComboBoxSettings_Batch.ClientCode = ""
            Me.ComboBoxSettings_Batch.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxSettings_Batch.DisableMouseWheel = True
            Me.ComboBoxSettings_Batch.DisplayMember = "Text"
            Me.ComboBoxSettings_Batch.DisplayName = ""
            Me.ComboBoxSettings_Batch.DivisionCode = ""
            Me.ComboBoxSettings_Batch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSettings_Batch.DropDownWidth = 350
            Me.ComboBoxSettings_Batch.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSettings_Batch.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxSettings_Batch.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSettings_Batch.FocusHighlightEnabled = True
            Me.ComboBoxSettings_Batch.FormattingEnabled = True
            Me.ComboBoxSettings_Batch.ItemHeight = 14
            Me.ComboBoxSettings_Batch.Location = New System.Drawing.Point(77, 44)
            Me.ComboBoxSettings_Batch.Name = "ComboBoxSettings_Batch"
            Me.ComboBoxSettings_Batch.ReadOnly = False
            Me.ComboBoxSettings_Batch.SecurityEnabled = True
            Me.ComboBoxSettings_Batch.Size = New System.Drawing.Size(175, 20)
            Me.ComboBoxSettings_Batch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSettings_Batch.TabIndex = 71
            Me.ComboBoxSettings_Batch.TabOnEnter = True
            '
            'ItemContainerSearch_Search
            '
            '
            '
            '
            Me.ItemContainerSearch_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Search.Name = "ItemContainerSearch_Search"
            Me.ItemContainerSearch_Search.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Vertical})
            '
            '
            '
            Me.ItemContainerSearch_Search.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerSearch_Vertical
            '
            '
            '
            '
            Me.ItemContainerSearch_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_Vertical.Name = "ItemContainerSearch_Vertical"
            Me.ItemContainerSearch_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_Top, Me.ItemContainer1})
            '
            '
            '
            Me.ItemContainerSearch_Vertical.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerVertical_Top
            '
            '
            '
            '
            Me.ItemContainerVertical_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_Top.Name = "ItemContainerVertical_Top"
            Me.ItemContainerVertical_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSettings_ImportType, Me.ControlContainerItem2})
            '
            '
            '
            Me.ItemContainerVertical_Top.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSettings_ImportType
            '
            Me.LabelItemSettings_ImportType.Name = "LabelItemSettings_ImportType"
            Me.LabelItemSettings_ImportType.Text = "Import Type:"
            Me.LabelItemSettings_ImportType.Width = 70
            '
            'ControlContainerItem2
            '
            Me.ControlContainerItem2.AllowItemResize = True
            Me.ControlContainerItem2.Control = Me.ComboBoxSettings_ImportType
            Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem2.Name = "ControlContainerItem2"
            Me.ControlContainerItem2.Text = "ControlContainerItem2"
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSettings_Batch, Me.ControlContainerItem1})
            '
            '
            '
            Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSettings_Batch
            '
            Me.LabelItemSettings_Batch.Name = "LabelItemSettings_Batch"
            Me.LabelItemSettings_Batch.Text = "Batch:"
            Me.LabelItemSettings_Batch.Width = 70
            '
            'ControlContainerItem1
            '
            Me.ControlContainerItem1.AllowItemResize = True
            Me.ControlContainerItem1.Control = Me.ComboBoxSettings_Batch
            Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem1.Name = "ControlContainerItem1"
            Me.ControlContainerItem1.Text = "ControlContainerItem1"
            '
            'RibbonBarOptions_Templates
            '
            Me.RibbonBarOptions_Templates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Templates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Templates.DragDropSupport = True
            Me.RibbonBarOptions_Templates.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Templates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplates_Edit})
            Me.RibbonBarOptions_Templates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Templates.Location = New System.Drawing.Point(366, 0)
            Me.RibbonBarOptions_Templates.Name = "RibbonBarOptions_Templates"
            Me.RibbonBarOptions_Templates.SecurityEnabled = True
            Me.RibbonBarOptions_Templates.Size = New System.Drawing.Size(41, 98)
            Me.RibbonBarOptions_Templates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Templates.TabIndex = 7
            Me.RibbonBarOptions_Templates.Text = "Templates"
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemTemplates_Edit
            '
            Me.ButtonItemTemplates_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTemplates_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Edit.Name = "ButtonItemTemplates_Edit"
            Me.ButtonItemTemplates_Edit.SecurityEnabled = True
            Me.ButtonItemTemplates_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Edit.Text = "Edit"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_GridOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CSIPreferredPartner)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_OnHold)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Orders)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AccountPayable)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ClearedChecks)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Templates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Import)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Navigation)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 22)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1064, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 69
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptions_ChooseColumns, Me.ButtonItemGridOptions_RestoreDefaults})
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(875, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(190, 98)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 18
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptions_ChooseColumns
            '
            Me.ButtonItemGridOptions_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptions_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_ChooseColumns.Name = "ButtonItemGridOptions_ChooseColumns"
            Me.ButtonItemGridOptions_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptions_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptions_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptions_RestoreDefaults
            '
            Me.ButtonItemGridOptions_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptions_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_RestoreDefaults.Name = "ButtonItemGridOptions_RestoreDefaults"
            Me.ButtonItemGridOptions_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptions_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptions_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_CSIPreferredPartner
            '
            Me.RibbonBarOptions_CSIPreferredPartner.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CSIPreferredPartner.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CSIPreferredPartner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CSIPreferredPartner.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CSIPreferredPartner.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CSIPreferredPartner.DragDropSupport = True
            Me.RibbonBarOptions_CSIPreferredPartner.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_CSIPreferredPartner.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCSIPreferredPartner_Import})
            Me.RibbonBarOptions_CSIPreferredPartner.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CSIPreferredPartner.Location = New System.Drawing.Point(753, 0)
            Me.RibbonBarOptions_CSIPreferredPartner.MinimumSize = New System.Drawing.Size(122, 0)
            Me.RibbonBarOptions_CSIPreferredPartner.Name = "RibbonBarOptions_CSIPreferredPartner"
            Me.RibbonBarOptions_CSIPreferredPartner.SecurityEnabled = True
            Me.RibbonBarOptions_CSIPreferredPartner.Size = New System.Drawing.Size(122, 98)
            Me.RibbonBarOptions_CSIPreferredPartner.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CSIPreferredPartner.TabIndex = 17
            Me.RibbonBarOptions_CSIPreferredPartner.Text = "CSI Preferred Partner"
            '
            '
            '
            Me.RibbonBarOptions_CSIPreferredPartner.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CSIPreferredPartner.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CSIPreferredPartner.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemCSIPreferredPartner_Import
            '
            Me.ButtonItemCSIPreferredPartner_Import.BeginGroup = True
            Me.ButtonItemCSIPreferredPartner_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCSIPreferredPartner_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCSIPreferredPartner_Import.Name = "ButtonItemCSIPreferredPartner_Import"
            Me.ButtonItemCSIPreferredPartner_Import.SecurityEnabled = True
            Me.ButtonItemCSIPreferredPartner_Import.SubItemsExpandWidth = 14
            Me.ButtonItemCSIPreferredPartner_Import.Text = "Import"
            '
            'RibbonBarOptions_OnHold
            '
            Me.RibbonBarOptions_OnHold.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_OnHold.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnHold.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OnHold.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OnHold.DragDropSupport = True
            Me.RibbonBarOptions_OnHold.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOnHold_Check, Me.ButtonItemOnHold_Uncheck})
            Me.RibbonBarOptions_OnHold.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_OnHold.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OnHold.Location = New System.Drawing.Point(677, 0)
            Me.RibbonBarOptions_OnHold.Name = "RibbonBarOptions_OnHold"
            Me.RibbonBarOptions_OnHold.SecurityEnabled = True
            Me.RibbonBarOptions_OnHold.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_OnHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OnHold.TabIndex = 16
            Me.RibbonBarOptions_OnHold.Text = "On Hold"
            '
            '
            '
            Me.RibbonBarOptions_OnHold.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnHold.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnHold.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOnHold_Check
            '
            Me.ButtonItemOnHold_Check.Name = "ButtonItemOnHold_Check"
            Me.ButtonItemOnHold_Check.SecurityEnabled = True
            Me.ButtonItemOnHold_Check.Stretch = True
            Me.ButtonItemOnHold_Check.SubItemsExpandWidth = 14
            Me.ButtonItemOnHold_Check.Text = "Check"
            '
            'ButtonItemOnHold_Uncheck
            '
            Me.ButtonItemOnHold_Uncheck.BeginGroup = True
            Me.ButtonItemOnHold_Uncheck.Name = "ButtonItemOnHold_Uncheck"
            Me.ButtonItemOnHold_Uncheck.SecurityEnabled = True
            Me.ButtonItemOnHold_Uncheck.SubItemsExpandWidth = 14
            Me.ButtonItemOnHold_Uncheck.Text = "Uncheck"
            '
            'RibbonBarOptions_Orders
            '
            Me.RibbonBarOptions_Orders.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Orders.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Orders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Orders.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Orders.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Orders.DragDropSupport = True
            Me.RibbonBarOptions_Orders.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Orders.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaOrder_Match, Me.ButtonItemMediaOrder_Create, Me.ButtonItemMediaOrder_AddToWorksheet})
            Me.RibbonBarOptions_Orders.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Orders.Location = New System.Drawing.Point(605, 0)
            Me.RibbonBarOptions_Orders.Name = "RibbonBarOptions_Orders"
            Me.RibbonBarOptions_Orders.SecurityEnabled = True
            Me.RibbonBarOptions_Orders.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_Orders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Orders.TabIndex = 14
            Me.RibbonBarOptions_Orders.Text = "Orders"
            '
            '
            '
            Me.RibbonBarOptions_Orders.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Orders.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Orders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMediaOrder_Match
            '
            Me.ButtonItemMediaOrder_Match.AutoExpandOnClick = True
            Me.ButtonItemMediaOrder_Match.BeginGroup = True
            Me.ButtonItemMediaOrder_Match.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaOrder_Match.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaOrder_Match.Name = "ButtonItemMediaOrder_Match"
            Me.ButtonItemMediaOrder_Match.SecurityEnabled = True
            Me.ButtonItemMediaOrder_Match.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaOrder_MatchBroadcastMonth, Me.ButtonItemMediaOrder_MatchCalendarMonth})
            Me.ButtonItemMediaOrder_Match.SubItemsExpandWidth = 14
            Me.ButtonItemMediaOrder_Match.Text = "Match"
            '
            'ButtonItemMediaOrder_MatchBroadcastMonth
            '
            Me.ButtonItemMediaOrder_MatchBroadcastMonth.Name = "ButtonItemMediaOrder_MatchBroadcastMonth"
            Me.ButtonItemMediaOrder_MatchBroadcastMonth.Text = "Broadcast Month"
            '
            'ButtonItemMediaOrder_MatchCalendarMonth
            '
            Me.ButtonItemMediaOrder_MatchCalendarMonth.Name = "ButtonItemMediaOrder_MatchCalendarMonth"
            Me.ButtonItemMediaOrder_MatchCalendarMonth.Text = "Calendar Month"
            '
            'ButtonItemMediaOrder_Create
            '
            Me.ButtonItemMediaOrder_Create.BeginGroup = True
            Me.ButtonItemMediaOrder_Create.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaOrder_Create.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaOrder_Create.Name = "ButtonItemMediaOrder_Create"
            Me.ButtonItemMediaOrder_Create.SecurityEnabled = True
            Me.ButtonItemMediaOrder_Create.SubItemsExpandWidth = 14
            Me.ButtonItemMediaOrder_Create.Text = "Create"
            '
            'ButtonItemMediaOrder_AddToWorksheet
            '
            Me.ButtonItemMediaOrder_AddToWorksheet.BeginGroup = True
            Me.ButtonItemMediaOrder_AddToWorksheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaOrder_AddToWorksheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaOrder_AddToWorksheet.Name = "ButtonItemMediaOrder_AddToWorksheet"
            Me.ButtonItemMediaOrder_AddToWorksheet.SecurityEnabled = True
            Me.ButtonItemMediaOrder_AddToWorksheet.SubItemsExpandWidth = 14
            Me.ButtonItemMediaOrder_AddToWorksheet.Text = "Add"
            Me.ButtonItemMediaOrder_AddToWorksheet.Tooltip = "Add lines to worksheet"
            '
            'RibbonBarOptions_AccountPayable
            '
            Me.RibbonBarOptions_AccountPayable.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AccountPayable.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AccountPayable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AccountPayable.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AccountPayable.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AccountPayable.DragDropSupport = True
            Me.RibbonBarOptions_AccountPayable.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAccountPayable_ShowAll, Me.ButtonItemAccountPayable_UpdateDescription, Me.ButtonItemAccountPayable_WriteOff, Me.ButtonItemAccountPayable_ClearOrderLine, Me.ButtonItemAccountPayable_Update})
            Me.RibbonBarOptions_AccountPayable.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AccountPayable.Location = New System.Drawing.Point(525, 0)
            Me.RibbonBarOptions_AccountPayable.Name = "RibbonBarOptions_AccountPayable"
            Me.RibbonBarOptions_AccountPayable.SecurityEnabled = True
            Me.RibbonBarOptions_AccountPayable.Size = New System.Drawing.Size(80, 98)
            Me.RibbonBarOptions_AccountPayable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AccountPayable.TabIndex = 11
            Me.RibbonBarOptions_AccountPayable.Text = "Account Payable"
            '
            '
            '
            Me.RibbonBarOptions_AccountPayable.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AccountPayable.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AccountPayable.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_AccountPayable.Visible = False
            '
            'ButtonItemAccountPayable_ShowAll
            '
            Me.ButtonItemAccountPayable_ShowAll.AutoCheckOnClick = True
            Me.ButtonItemAccountPayable_ShowAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAccountPayable_ShowAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAccountPayable_ShowAll.Name = "ButtonItemAccountPayable_ShowAll"
            Me.ButtonItemAccountPayable_ShowAll.RibbonWordWrap = False
            Me.ButtonItemAccountPayable_ShowAll.SecurityEnabled = True
            Me.ButtonItemAccountPayable_ShowAll.Stretch = True
            Me.ButtonItemAccountPayable_ShowAll.SubItemsExpandWidth = 14
            Me.ButtonItemAccountPayable_ShowAll.Text = "Show All"
            '
            'ButtonItemAccountPayable_UpdateDescription
            '
            Me.ButtonItemAccountPayable_UpdateDescription.BeginGroup = True
            Me.ButtonItemAccountPayable_UpdateDescription.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAccountPayable_UpdateDescription.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAccountPayable_UpdateDescription.Name = "ButtonItemAccountPayable_UpdateDescription"
            Me.ButtonItemAccountPayable_UpdateDescription.SecurityEnabled = True
            Me.ButtonItemAccountPayable_UpdateDescription.Stretch = True
            Me.ButtonItemAccountPayable_UpdateDescription.SubItemsExpandWidth = 14
            Me.ButtonItemAccountPayable_UpdateDescription.Text = "Description"
            '
            'ButtonItemAccountPayable_WriteOff
            '
            Me.ButtonItemAccountPayable_WriteOff.BeginGroup = True
            Me.ButtonItemAccountPayable_WriteOff.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAccountPayable_WriteOff.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAccountPayable_WriteOff.Name = "ButtonItemAccountPayable_WriteOff"
            Me.ButtonItemAccountPayable_WriteOff.SecurityEnabled = True
            Me.ButtonItemAccountPayable_WriteOff.Stretch = True
            Me.ButtonItemAccountPayable_WriteOff.SubItemsExpandWidth = 14
            Me.ButtonItemAccountPayable_WriteOff.Text = "Write Off"
            Me.ButtonItemAccountPayable_WriteOff.Tooltip = "Write Off Media Order Variance"
            '
            'ButtonItemAccountPayable_ClearOrderLine
            '
            Me.ButtonItemAccountPayable_ClearOrderLine.BeginGroup = True
            Me.ButtonItemAccountPayable_ClearOrderLine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAccountPayable_ClearOrderLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAccountPayable_ClearOrderLine.Name = "ButtonItemAccountPayable_ClearOrderLine"
            Me.ButtonItemAccountPayable_ClearOrderLine.SecurityEnabled = True
            Me.ButtonItemAccountPayable_ClearOrderLine.Stretch = True
            Me.ButtonItemAccountPayable_ClearOrderLine.SubItemsExpandWidth = 14
            Me.ButtonItemAccountPayable_ClearOrderLine.Text = "Clear Order/Line"
            Me.ButtonItemAccountPayable_ClearOrderLine.Tooltip = "Clear Order/Line"
            '
            'ButtonItemAccountPayable_Update
            '
            Me.ButtonItemAccountPayable_Update.AutoExpandOnClick = True
            Me.ButtonItemAccountPayable_Update.BeginGroup = True
            Me.ButtonItemAccountPayable_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAccountPayable_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAccountPayable_Update.Name = "ButtonItemAccountPayable_Update"
            Me.ButtonItemAccountPayable_Update.SecurityEnabled = True
            Me.ButtonItemAccountPayable_Update.Stretch = True
            Me.ButtonItemAccountPayable_Update.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAccountPayable_UpdateVendorToPayToVendor})
            Me.ButtonItemAccountPayable_Update.SubItemsExpandWidth = 14
            Me.ButtonItemAccountPayable_Update.Text = "Update"
            '
            'ButtonItemAccountPayable_UpdateVendorToPayToVendor
            '
            Me.ButtonItemAccountPayable_UpdateVendorToPayToVendor.Name = "ButtonItemAccountPayable_UpdateVendorToPayToVendor"
            Me.ButtonItemAccountPayable_UpdateVendorToPayToVendor.Text = "Vendor With Pay To Vendor"
            '
            'RibbonBarOptions_ClearedChecks
            '
            Me.RibbonBarOptions_ClearedChecks.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ClearedChecks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClearedChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClearedChecks.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ClearedChecks.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ClearedChecks.DragDropSupport = True
            Me.RibbonBarOptions_ClearedChecks.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClearedChecks_All, Me.ButtonItemClearedChecks_Valid, Me.ButtonItemClearedChecks_Invalid})
            Me.RibbonBarOptions_ClearedChecks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ClearedChecks.Location = New System.Drawing.Point(407, 0)
            Me.RibbonBarOptions_ClearedChecks.Name = "RibbonBarOptions_ClearedChecks"
            Me.RibbonBarOptions_ClearedChecks.SecurityEnabled = True
            Me.RibbonBarOptions_ClearedChecks.Size = New System.Drawing.Size(118, 98)
            Me.RibbonBarOptions_ClearedChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ClearedChecks.TabIndex = 10
            Me.RibbonBarOptions_ClearedChecks.Text = "Cleared Checks"
            '
            '
            '
            Me.RibbonBarOptions_ClearedChecks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClearedChecks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClearedChecks.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_ClearedChecks.Visible = False
            '
            'ButtonItemClearedChecks_All
            '
            Me.ButtonItemClearedChecks_All.AutoCheckOnClick = True
            Me.ButtonItemClearedChecks_All.BeginGroup = True
            Me.ButtonItemClearedChecks_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClearedChecks_All.Checked = True
            Me.ButtonItemClearedChecks_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClearedChecks_All.Name = "ButtonItemClearedChecks_All"
            Me.ButtonItemClearedChecks_All.OptionGroup = "ClearedChecks"
            Me.ButtonItemClearedChecks_All.SecurityEnabled = True
            Me.ButtonItemClearedChecks_All.Stretch = True
            Me.ButtonItemClearedChecks_All.SubItemsExpandWidth = 14
            Me.ButtonItemClearedChecks_All.Text = "All"
            '
            'ButtonItemClearedChecks_Valid
            '
            Me.ButtonItemClearedChecks_Valid.BeginGroup = True
            Me.ButtonItemClearedChecks_Valid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClearedChecks_Valid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClearedChecks_Valid.Name = "ButtonItemClearedChecks_Valid"
            Me.ButtonItemClearedChecks_Valid.OptionGroup = "ClearedChecks"
            Me.ButtonItemClearedChecks_Valid.SecurityEnabled = True
            Me.ButtonItemClearedChecks_Valid.Stretch = True
            Me.ButtonItemClearedChecks_Valid.SubItemsExpandWidth = 14
            Me.ButtonItemClearedChecks_Valid.Text = "Valid"
            '
            'ButtonItemClearedChecks_Invalid
            '
            Me.ButtonItemClearedChecks_Invalid.BeginGroup = True
            Me.ButtonItemClearedChecks_Invalid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClearedChecks_Invalid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClearedChecks_Invalid.Name = "ButtonItemClearedChecks_Invalid"
            Me.ButtonItemClearedChecks_Invalid.OptionGroup = "ClearedChecks"
            Me.ButtonItemClearedChecks_Invalid.SecurityEnabled = True
            Me.ButtonItemClearedChecks_Invalid.Stretch = True
            Me.ButtonItemClearedChecks_Invalid.SubItemsExpandWidth = 14
            Me.ButtonItemClearedChecks_Invalid.Text = "Invalid"
            '
            'RibbonBarOptions_Import
            '
            Me.RibbonBarOptions_Import.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Import.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Import.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Import.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Import.DragDropSupport = True
            Me.RibbonBarOptions_Import.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Import.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemImport_NewBatch})
            Me.RibbonBarOptions_Import.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Import.Location = New System.Drawing.Point(322, 0)
            Me.RibbonBarOptions_Import.Name = "RibbonBarOptions_Import"
            Me.RibbonBarOptions_Import.SecurityEnabled = True
            Me.RibbonBarOptions_Import.Size = New System.Drawing.Size(44, 98)
            Me.RibbonBarOptions_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Import.TabIndex = 9
            Me.RibbonBarOptions_Import.Text = "Import"
            '
            '
            '
            Me.RibbonBarOptions_Import.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Import.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Import.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemImport_NewBatch
            '
            Me.ButtonItemImport_NewBatch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_NewBatch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_NewBatch.Name = "ButtonItemImport_NewBatch"
            Me.ButtonItemImport_NewBatch.SecurityEnabled = True
            Me.ButtonItemImport_NewBatch.SubItemsExpandWidth = 14
            Me.ButtonItemImport_NewBatch.Text = "New Batch"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Validate, Me.ButtonItemActions_Import, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_AutoFill, Me.ButtonItemActions_Mapping, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(258, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(64, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 8
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
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            Me.ButtonItemActions_Export.Visible = False
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.SecurityEnabled = True
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
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Validate
            '
            Me.ButtonItemActions_Validate.BeginGroup = True
            Me.ButtonItemActions_Validate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Validate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Validate.Name = "ButtonItemActions_Validate"
            Me.ButtonItemActions_Validate.SecurityEnabled = True
            Me.ButtonItemActions_Validate.Stretch = True
            Me.ButtonItemActions_Validate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Validate.Text = "Validate"
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.SecurityEnabled = True
            Me.ButtonItemActions_Import.Stretch = True
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'ButtonItemActions_AutoFill
            '
            Me.ButtonItemActions_AutoFill.BeginGroup = True
            Me.ButtonItemActions_AutoFill.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AutoFill.Name = "ButtonItemActions_AutoFill"
            Me.ButtonItemActions_AutoFill.SecurityEnabled = True
            Me.ButtonItemActions_AutoFill.Stretch = True
            Me.ButtonItemActions_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AutoFill.Text = "Auto Fill"
            '
            'ButtonItemActions_Mapping
            '
            Me.ButtonItemActions_Mapping.BeginGroup = True
            Me.ButtonItemActions_Mapping.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Mapping.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Mapping.Name = "ButtonItemActions_Mapping"
            Me.ButtonItemActions_Mapping.SecurityEnabled = True
            Me.ButtonItemActions_Mapping.Stretch = True
            Me.ButtonItemActions_Mapping.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Mapping.Text = "Mapping"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'DataGridViewForm_ImportedItems
            '
            Me.DataGridViewForm_ImportedItems.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ImportedItems.AllowDragAndDrop = False
            Me.DataGridViewForm_ImportedItems.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ImportedItems.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ImportedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ImportedItems.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ImportedItems.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ImportedItems.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ImportedItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ImportedItems.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ImportedItems.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ImportedItems.ItemDescription = "Expense Import Item(s)"
            Me.DataGridViewForm_ImportedItems.Location = New System.Drawing.Point(12, 22)
            Me.DataGridViewForm_ImportedItems.MultiSelect = True
            Me.DataGridViewForm_ImportedItems.Name = "DataGridViewForm_ImportedItems"
            Me.DataGridViewForm_ImportedItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ImportedItems.RunStandardValidation = True
            Me.DataGridViewForm_ImportedItems.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ImportedItems.Size = New System.Drawing.Size(1080, 500)
            Me.DataGridViewForm_ImportedItems.TabIndex = 73
            Me.DataGridViewForm_ImportedItems.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ImportedItems.ViewCaptionHeight = -1
            '
            'ContextMenuStripForm_MappingMenu
            '
            Me.ContextMenuStripForm_MappingMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MappingToolStripMenuItem})
            Me.ContextMenuStripForm_MappingMenu.Name = "ContextMenuStripForm_MappingMenu"
            Me.ContextMenuStripForm_MappingMenu.Size = New System.Drawing.Size(127, 26)
            '
            'MappingToolStripMenuItem
            '
            Me.MappingToolStripMenuItem.Name = "MappingToolStripMenuItem"
            Me.MappingToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
            Me.MappingToolStripMenuItem.Text = "Mapping..."
            '
            'ImportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1104, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ImportedItems)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ImportForm"
            Me.Text = "Expense Import"
            Me.RibbonBarOptions_Navigation.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ContextMenuStripForm_MappingMenu.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Navigation As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Templates As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTemplates_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSearch_Search As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerSearch_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerVertical_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSettings_ImportType As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSettings_Batch As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemActions_AutoFill As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Import As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemImport_NewBatch As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ClearedChecks As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemClearedChecks_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemClearedChecks_Valid As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemClearedChecks_Invalid As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ComboBoxSettings_Batch As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxSettings_ImportType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents RibbonBarOptions_AccountPayable As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemAccountPayable_ShowAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_ImportedItems As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ContextMenuStripForm_MappingMenu As AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip
        Friend WithEvents MappingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ButtonItemActions_Validate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Mapping As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Orders As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaOrder_Create As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_OnHold As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOnHold_Check As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOnHold_Uncheck As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAccountPayable_UpdateDescription As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CSIPreferredPartner As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCSIPreferredPartner_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAccountPayable_WriteOff As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaOrder_Match As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAccountPayable_ClearOrderLine As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaOrder_MatchBroadcastMonth As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaOrder_MatchCalendarMonth As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaOrder_AddToWorksheet As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAccountPayable_Update As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAccountPayable_UpdateVendorToPayToVendor As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
