Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportForm))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxExportType_ExportType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxTemplate_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerActions_Export = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerExport_ExportType = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemExportType_ExportType = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemExportType_ExportType = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerExport_Template = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTemplate_Template = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemTemplate_Template = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemActions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Preview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Clear = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_ExportData = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Manage = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemManage_Templates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Mappings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMappings_GeneralLedger = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
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
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxExportType_ExportType)
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxTemplate_Template)
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_Export, Me.ButtonItemActions_Filter, Me.ButtonItemActions_Preview, Me.ButtonItemActions_Export, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_Clear, Me.ButtonItemActions_AutoFill})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(521, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 4
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
            'ComboBoxExportType_ExportType
            '
            Me.ComboBoxExportType_ExportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxExportType_ExportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxExportType_ExportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxExportType_ExportType.AutoFindItemInDataSource = False
            Me.ComboBoxExportType_ExportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxExportType_ExportType.BookmarkingEnabled = False
            Me.ComboBoxExportType_ExportType.ClientCode = ""
            Me.ComboBoxExportType_ExportType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxExportType_ExportType.DisableMouseWheel = False
            Me.ComboBoxExportType_ExportType.DisplayMember = "Description"
            Me.ComboBoxExportType_ExportType.DisplayName = ""
            Me.ComboBoxExportType_ExportType.DivisionCode = ""
            Me.ComboBoxExportType_ExportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxExportType_ExportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxExportType_ExportType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxExportType_ExportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxExportType_ExportType.FocusHighlightEnabled = True
            Me.ComboBoxExportType_ExportType.FormattingEnabled = True
            Me.ComboBoxExportType_ExportType.ItemHeight = 14
            Me.ComboBoxExportType_ExportType.Location = New System.Drawing.Point(77, 37)
            Me.ComboBoxExportType_ExportType.Name = "ComboBoxExportType_ExportType"
            Me.ComboBoxExportType_ExportType.PreventEnterBeep = False
            Me.ComboBoxExportType_ExportType.ReadOnly = False
            Me.ComboBoxExportType_ExportType.SecurityEnabled = True
            Me.ComboBoxExportType_ExportType.Size = New System.Drawing.Size(175, 20)
            Me.ComboBoxExportType_ExportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxExportType_ExportType.TabIndex = 70
            Me.ComboBoxExportType_ExportType.ValueMember = "Code"
            Me.ComboBoxExportType_ExportType.WatermarkText = "Select"
            '
            'ComboBoxTemplate_Template
            '
            Me.ComboBoxTemplate_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTemplate_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTemplate_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTemplate_Template.AutoFindItemInDataSource = False
            Me.ComboBoxTemplate_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTemplate_Template.BookmarkingEnabled = False
            Me.ComboBoxTemplate_Template.ClientCode = ""
            Me.ComboBoxTemplate_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ExportTemplate
            Me.ComboBoxTemplate_Template.DisableMouseWheel = False
            Me.ComboBoxTemplate_Template.DisplayMember = "Name"
            Me.ComboBoxTemplate_Template.DisplayName = ""
            Me.ComboBoxTemplate_Template.DivisionCode = ""
            Me.ComboBoxTemplate_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTemplate_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTemplate_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxTemplate_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTemplate_Template.FocusHighlightEnabled = True
            Me.ComboBoxTemplate_Template.FormattingEnabled = True
            Me.ComboBoxTemplate_Template.ItemHeight = 14
            Me.ComboBoxTemplate_Template.Location = New System.Drawing.Point(77, 60)
            Me.ComboBoxTemplate_Template.Name = "ComboBoxTemplate_Template"
            Me.ComboBoxTemplate_Template.PreventEnterBeep = False
            Me.ComboBoxTemplate_Template.ReadOnly = False
            Me.ComboBoxTemplate_Template.SecurityEnabled = True
            Me.ComboBoxTemplate_Template.Size = New System.Drawing.Size(175, 20)
            Me.ComboBoxTemplate_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTemplate_Template.TabIndex = 70
            Me.ComboBoxTemplate_Template.ValueMember = "ID"
            Me.ComboBoxTemplate_Template.WatermarkText = "Select Export Template"
            '
            'ItemContainerActions_Export
            '
            '
            '
            '
            Me.ItemContainerActions_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Export.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_Export.Name = "ItemContainerActions_Export"
            Me.ItemContainerActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerExport_ExportType, Me.ItemContainerExport_Template})
            '
            '
            '
            Me.ItemContainerActions_Export.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Export.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerExport_ExportType
            '
            '
            '
            '
            Me.ItemContainerExport_ExportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerExport_ExportType.Name = "ItemContainerExport_ExportType"
            Me.ItemContainerExport_ExportType.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemExportType_ExportType, Me.ControlContainerItemExportType_ExportType})
            '
            '
            '
            Me.ItemContainerExport_ExportType.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemExportType_ExportType
            '
            Me.LabelItemExportType_ExportType.Name = "LabelItemExportType_ExportType"
            Me.LabelItemExportType_ExportType.Text = "Export Type:"
            Me.LabelItemExportType_ExportType.Width = 70
            '
            'ControlContainerItemExportType_ExportType
            '
            Me.ControlContainerItemExportType_ExportType.AllowItemResize = True
            Me.ControlContainerItemExportType_ExportType.Control = Me.ComboBoxExportType_ExportType
            Me.ControlContainerItemExportType_ExportType.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemExportType_ExportType.Name = "ControlContainerItemExportType_ExportType"
            '
            'ItemContainerExport_Template
            '
            '
            '
            '
            Me.ItemContainerExport_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerExport_Template.Name = "ItemContainerExport_Template"
            Me.ItemContainerExport_Template.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTemplate_Template, Me.ControlContainerItemTemplate_Template})
            '
            '
            '
            Me.ItemContainerExport_Template.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemTemplate_Template
            '
            Me.LabelItemTemplate_Template.Name = "LabelItemTemplate_Template"
            Me.LabelItemTemplate_Template.Text = "Template:"
            Me.LabelItemTemplate_Template.Width = 70
            '
            'ControlContainerItemTemplate_Template
            '
            Me.ControlContainerItemTemplate_Template.AllowItemResize = True
            Me.ControlContainerItemTemplate_Template.Control = Me.ComboBoxTemplate_Template
            Me.ControlContainerItemTemplate_Template.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemTemplate_Template.Name = "ControlContainerItemTemplate_Template"
            '
            'ButtonItemActions_Filter
            '
            Me.ButtonItemActions_Filter.BeginGroup = True
            Me.ButtonItemActions_Filter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Filter.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Filter.Name = "ButtonItemActions_Filter"
            Me.ButtonItemActions_Filter.SecurityEnabled = True
            Me.ButtonItemActions_Filter.Stretch = True
            Me.ButtonItemActions_Filter.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Filter.Text = "Filter"
            '
            'ButtonItemActions_Preview
            '
            Me.ButtonItemActions_Preview.BeginGroup = True
            Me.ButtonItemActions_Preview.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Preview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Preview.Name = "ButtonItemActions_Preview"
            Me.ButtonItemActions_Preview.SecurityEnabled = True
            Me.ButtonItemActions_Preview.Stretch = True
            Me.ButtonItemActions_Preview.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Preview.Text = "Preview"
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
            'ButtonItemActions_Clear
            '
            Me.ButtonItemActions_Clear.BeginGroup = True
            Me.ButtonItemActions_Clear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Clear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Clear.Name = "ButtonItemActions_Clear"
            Me.ButtonItemActions_Clear.SecurityEnabled = True
            Me.ButtonItemActions_Clear.Stretch = True
            Me.ButtonItemActions_Clear.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Clear.Text = "Clear"
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
            'DataGridViewForm_ExportData
            '
            Me.DataGridViewForm_ExportData.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ExportData.AllowDragAndDrop = False
            Me.DataGridViewForm_ExportData.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ExportData.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ExportData.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ExportData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ExportData.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ExportData.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ExportData.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ExportData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ExportData.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ExportData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ExportData.ItemDescription = "Export Item(s)"
            Me.DataGridViewForm_ExportData.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ExportData.MultiSelect = True
            Me.DataGridViewForm_ExportData.Name = "DataGridViewForm_ExportData"
            Me.DataGridViewForm_ExportData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ExportData.RunStandardValidation = True
            Me.DataGridViewForm_ExportData.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ExportData.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ExportData.Size = New System.Drawing.Size(1080, 510)
            Me.DataGridViewForm_ExportData.TabIndex = 41
            Me.DataGridViewForm_ExportData.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ExportData.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_Manage
            '
            Me.RibbonBarOptions_Manage.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Manage.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Manage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Manage.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Manage.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Manage.DragDropSupport = True
            Me.RibbonBarOptions_Manage.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Manage.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemManage_Templates})
            Me.RibbonBarOptions_Manage.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Manage.Location = New System.Drawing.Point(521, 0)
            Me.RibbonBarOptions_Manage.Name = "RibbonBarOptions_Manage"
            Me.RibbonBarOptions_Manage.SecurityEnabled = True
            Me.RibbonBarOptions_Manage.Size = New System.Drawing.Size(81, 98)
            Me.RibbonBarOptions_Manage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Manage.TabIndex = 7
            Me.RibbonBarOptions_Manage.Text = "Manage"
            '
            '
            '
            Me.RibbonBarOptions_Manage.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Manage.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Manage.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemManage_Templates
            '
            Me.ButtonItemManage_Templates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemManage_Templates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemManage_Templates.Name = "ButtonItemManage_Templates"
            Me.ButtonItemManage_Templates.SecurityEnabled = True
            Me.ButtonItemManage_Templates.SubItemsExpandWidth = 14
            Me.ButtonItemManage_Templates.Text = "Templates"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Mappings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Manage)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1080, 98)
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
            'RibbonBarOptions_Mappings
            '
            Me.RibbonBarOptions_Mappings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Mappings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Mappings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Mappings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Mappings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Mappings.DragDropSupport = True
            Me.RibbonBarOptions_Mappings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Mappings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMappings_GeneralLedger})
            Me.RibbonBarOptions_Mappings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Mappings.Location = New System.Drawing.Point(602, 0)
            Me.RibbonBarOptions_Mappings.Name = "RibbonBarOptions_Mappings"
            Me.RibbonBarOptions_Mappings.SecurityEnabled = True
            Me.RibbonBarOptions_Mappings.Size = New System.Drawing.Size(161, 98)
            Me.RibbonBarOptions_Mappings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Mappings.TabIndex = 20
            Me.RibbonBarOptions_Mappings.Text = "Mappings"
            '
            '
            '
            Me.RibbonBarOptions_Mappings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Mappings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Mappings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMappings_GeneralLedger
            '
            Me.ButtonItemMappings_GeneralLedger.BeginGroup = True
            Me.ButtonItemMappings_GeneralLedger.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMappings_GeneralLedger.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMappings_GeneralLedger.Name = "ButtonItemMappings_GeneralLedger"
            Me.ButtonItemMappings_GeneralLedger.SecurityEnabled = True
            Me.ButtonItemMappings_GeneralLedger.SubItemsExpandWidth = 14
            Me.ButtonItemMappings_GeneralLedger.Text = "General Ledger"
            '
            'ExportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1104, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ExportData)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportForm"
            Me.Text = "Export"
            Me.RibbonBarOptions_Actions.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_ExportData As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Manage As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemManage_Templates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents ItemContainerActions_Export As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerExport_ExportType As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemExportType_ExportType As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerExport_Template As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTemplate_Template As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Preview As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ControlContainerItemExportType_ExportType As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxExportType_ExportType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemTemplate_Template As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxTemplate_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Filter As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Clear As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AutoFill As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Mappings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMappings_GeneralLedger As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem

    End Class

End Namespace