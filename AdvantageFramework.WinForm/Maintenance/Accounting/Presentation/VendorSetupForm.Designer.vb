Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorSetupForm))
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ComboStations = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComboStations_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_QuickBooks = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickBooks_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Markets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarkets_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Nielsen = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemNielsen_UpdateStations = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContracts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Pricings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPricings_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPricings_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSpelling_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaSpecs = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaSpecs_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaSpecs_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Representatives = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRepresentatives_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRepresentatives_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRepresentatives_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContacts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.VendorControlRightSection_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.VendorControl()
            Me.RibbonBarMergeContainerForm_Import = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarImport_Import = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemImport_Wizard = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemImport_PendingRecords = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Import.SuspendLayout()
            Me.SuspendLayout()
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(181, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 563)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Vendors)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(181, 563)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_Vendors
            '
            Me.DataGridViewLeftSection_Vendors.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Vendors.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Vendors.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Vendors.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Vendors.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Vendors.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Vendors.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Vendors.DataSource = Nothing
            Me.DataGridViewLeftSection_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Vendors.ItemDescription = ""
            Me.DataGridViewLeftSection_Vendors.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Vendors.MultiSelect = True
            Me.DataGridViewLeftSection_Vendors.Name = "DataGridViewLeftSection_Vendors"
            Me.DataGridViewLeftSection_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Vendors.RunStandardValidation = True
            Me.DataGridViewLeftSection_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Vendors.Size = New System.Drawing.Size(163, 539)
            Me.DataGridViewLeftSection_Vendors.TabIndex = 0
            Me.DataGridViewLeftSection_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Vendors.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ComboStations)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_QuickBooks)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Markets)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Nielsen)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Contracts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Pricings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CheckSpelling)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaSpecs)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Representatives)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Contacts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1448, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 4
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_ComboStations
            '
            Me.RibbonBarOptions_ComboStations.AutoOverflowEnabled = False
            Me.RibbonBarOptions_ComboStations.AutoSizeIncludesTitle = True
            '
            '
            '
            Me.RibbonBarOptions_ComboStations.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ComboStations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ComboStations.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ComboStations.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ComboStations.DragDropSupport = True
            Me.RibbonBarOptions_ComboStations.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_ComboStations.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemComboStations_Manage})
            Me.RibbonBarOptions_ComboStations.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ComboStations.Location = New System.Drawing.Point(1181, 0)
            Me.RibbonBarOptions_ComboStations.Name = "RibbonBarOptions_ComboStations"
            Me.RibbonBarOptions_ComboStations.SecurityEnabled = True
            Me.RibbonBarOptions_ComboStations.Size = New System.Drawing.Size(91, 98)
            Me.RibbonBarOptions_ComboStations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ComboStations.TabIndex = 22
            Me.RibbonBarOptions_ComboStations.Text = "Combo Stations"
            '
            '
            '
            Me.RibbonBarOptions_ComboStations.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ComboStations.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ComboStations.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemComboStations_Manage
            '
            Me.ButtonItemComboStations_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemComboStations_Manage.Name = "ButtonItemComboStations_Manage"
            Me.ButtonItemComboStations_Manage.RibbonWordWrap = False
            Me.ButtonItemComboStations_Manage.SecurityEnabled = True
            Me.ButtonItemComboStations_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemComboStations_Manage.Text = "Manage"
            Me.ButtonItemComboStations_Manage.Tooltip = "Manage Combo Radio Stations"
            '
            'RibbonBarOptions_QuickBooks
            '
            Me.RibbonBarOptions_QuickBooks.AutoOverflowEnabled = False
            Me.RibbonBarOptions_QuickBooks.AutoSizeIncludesTitle = True
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickBooks.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickBooks.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickBooks.DragDropSupport = True
            Me.RibbonBarOptions_QuickBooks.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickBooks_Refresh})
            Me.RibbonBarOptions_QuickBooks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickBooks.Location = New System.Drawing.Point(1110, 0)
            Me.RibbonBarOptions_QuickBooks.Name = "RibbonBarOptions_QuickBooks"
            Me.RibbonBarOptions_QuickBooks.SecurityEnabled = True
            Me.RibbonBarOptions_QuickBooks.Size = New System.Drawing.Size(71, 98)
            Me.RibbonBarOptions_QuickBooks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickBooks.TabIndex = 21
            Me.RibbonBarOptions_QuickBooks.Text = "QuickBooks"
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickBooks.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemQuickBooks_Refresh
            '
            Me.ButtonItemQuickBooks_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickBooks_Refresh.Name = "ButtonItemQuickBooks_Refresh"
            Me.ButtonItemQuickBooks_Refresh.RibbonWordWrap = False
            Me.ButtonItemQuickBooks_Refresh.SecurityEnabled = True
            Me.ButtonItemQuickBooks_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemQuickBooks_Refresh.Text = "Refresh"
            Me.ButtonItemQuickBooks_Refresh.Tooltip = "Refresh Data from QuickBooks"
            '
            'RibbonBarOptions_Markets
            '
            Me.RibbonBarOptions_Markets.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Markets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Markets.DragDropSupport = True
            Me.RibbonBarOptions_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarkets_Manage})
            Me.RibbonBarOptions_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Markets.Location = New System.Drawing.Point(1019, 0)
            Me.RibbonBarOptions_Markets.Name = "RibbonBarOptions_Markets"
            Me.RibbonBarOptions_Markets.SecurityEnabled = True
            Me.RibbonBarOptions_Markets.Size = New System.Drawing.Size(91, 98)
            Me.RibbonBarOptions_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Markets.TabIndex = 20
            Me.RibbonBarOptions_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMarkets_Manage
            '
            Me.ButtonItemMarkets_Manage.BeginGroup = True
            Me.ButtonItemMarkets_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Manage.Name = "ButtonItemMarkets_Manage"
            Me.ButtonItemMarkets_Manage.RibbonWordWrap = False
            Me.ButtonItemMarkets_Manage.SecurityEnabled = True
            Me.ButtonItemMarkets_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Manage.Text = "Manage"
            '
            'RibbonBarOptions_Nielsen
            '
            Me.RibbonBarOptions_Nielsen.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Nielsen.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Nielsen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Nielsen.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Nielsen.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Nielsen.DragDropSupport = True
            Me.RibbonBarOptions_Nielsen.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNielsen_UpdateStations})
            Me.RibbonBarOptions_Nielsen.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Nielsen.Location = New System.Drawing.Point(921, 0)
            Me.RibbonBarOptions_Nielsen.Name = "RibbonBarOptions_Nielsen"
            Me.RibbonBarOptions_Nielsen.SecurityEnabled = True
            Me.RibbonBarOptions_Nielsen.Size = New System.Drawing.Size(98, 98)
            Me.RibbonBarOptions_Nielsen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Nielsen.TabIndex = 19
            Me.RibbonBarOptions_Nielsen.Text = "Nielsen"
            '
            '
            '
            Me.RibbonBarOptions_Nielsen.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Nielsen.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Nielsen.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemNielsen_UpdateStations
            '
            Me.ButtonItemNielsen_UpdateStations.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemNielsen_UpdateStations.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNielsen_UpdateStations.Name = "ButtonItemNielsen_UpdateStations"
            Me.ButtonItemNielsen_UpdateStations.RibbonWordWrap = False
            Me.ButtonItemNielsen_UpdateStations.Stretch = True
            Me.ButtonItemNielsen_UpdateStations.SubItemsExpandWidth = 14
            Me.ButtonItemNielsen_UpdateStations.Text = "Update Stations"
            '
            'RibbonBarOptions_Contracts
            '
            Me.RibbonBarOptions_Contracts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Contracts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contracts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contracts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Contracts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Contracts.DragDropSupport = True
            Me.RibbonBarOptions_Contracts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContracts_Add, Me.ButtonItemContracts_Copy, Me.ButtonItemContracts_Edit, Me.ButtonItemContracts_Delete})
            Me.RibbonBarOptions_Contracts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Contracts.Location = New System.Drawing.Point(838, 0)
            Me.RibbonBarOptions_Contracts.Name = "RibbonBarOptions_Contracts"
            Me.RibbonBarOptions_Contracts.SecurityEnabled = True
            Me.RibbonBarOptions_Contracts.Size = New System.Drawing.Size(83, 98)
            Me.RibbonBarOptions_Contracts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contracts.TabIndex = 18
            Me.RibbonBarOptions_Contracts.Text = "Contracts"
            '
            '
            '
            Me.RibbonBarOptions_Contracts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contracts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contracts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemContracts_Add
            '
            Me.ButtonItemContracts_Add.BeginGroup = True
            Me.ButtonItemContracts_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Add.Name = "ButtonItemContracts_Add"
            Me.ButtonItemContracts_Add.RibbonWordWrap = False
            Me.ButtonItemContracts_Add.SecurityEnabled = True
            Me.ButtonItemContracts_Add.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Add.Text = "Add"
            '
            'ButtonItemContracts_Copy
            '
            Me.ButtonItemContracts_Copy.BeginGroup = True
            Me.ButtonItemContracts_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Copy.Name = "ButtonItemContracts_Copy"
            Me.ButtonItemContracts_Copy.RibbonWordWrap = False
            Me.ButtonItemContracts_Copy.SecurityEnabled = True
            Me.ButtonItemContracts_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Copy.Text = "Copy"
            '
            'ButtonItemContracts_Edit
            '
            Me.ButtonItemContracts_Edit.BeginGroup = True
            Me.ButtonItemContracts_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Edit.Name = "ButtonItemContracts_Edit"
            Me.ButtonItemContracts_Edit.RibbonWordWrap = False
            Me.ButtonItemContracts_Edit.SecurityEnabled = True
            Me.ButtonItemContracts_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Edit.Text = "Edit"
            '
            'ButtonItemContracts_Delete
            '
            Me.ButtonItemContracts_Delete.BeginGroup = True
            Me.ButtonItemContracts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Delete.Name = "ButtonItemContracts_Delete"
            Me.ButtonItemContracts_Delete.RibbonWordWrap = False
            Me.ButtonItemContracts_Delete.SecurityEnabled = True
            Me.ButtonItemContracts_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(761, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(77, 98)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 7
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
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
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
            'RibbonBarOptions_Pricings
            '
            Me.RibbonBarOptions_Pricings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Pricings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Pricings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Pricings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Pricings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Pricings.DragDropSupport = True
            Me.RibbonBarOptions_Pricings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPricings_Delete, Me.ButtonItemPricings_Cancel})
            Me.RibbonBarOptions_Pricings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Pricings.Location = New System.Drawing.Point(665, 0)
            Me.RibbonBarOptions_Pricings.Name = "RibbonBarOptions_Pricings"
            Me.RibbonBarOptions_Pricings.SecurityEnabled = True
            Me.RibbonBarOptions_Pricings.Size = New System.Drawing.Size(96, 98)
            Me.RibbonBarOptions_Pricings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Pricings.TabIndex = 5
            Me.RibbonBarOptions_Pricings.Text = "Pricings"
            '
            '
            '
            Me.RibbonBarOptions_Pricings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Pricings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Pricings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPricings_Delete
            '
            Me.ButtonItemPricings_Delete.BeginGroup = True
            Me.ButtonItemPricings_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPricings_Delete.Name = "ButtonItemPricings_Delete"
            Me.ButtonItemPricings_Delete.RibbonWordWrap = False
            Me.ButtonItemPricings_Delete.SecurityEnabled = True
            Me.ButtonItemPricings_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemPricings_Delete.Text = "Delete"
            '
            'ButtonItemPricings_Cancel
            '
            Me.ButtonItemPricings_Cancel.BeginGroup = True
            Me.ButtonItemPricings_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPricings_Cancel.Name = "ButtonItemPricings_Cancel"
            Me.ButtonItemPricings_Cancel.RibbonWordWrap = False
            Me.ButtonItemPricings_Cancel.SecurityEnabled = True
            Me.ButtonItemPricings_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemPricings_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_CheckSpelling.Location = New System.Drawing.Point(574, 0)
            Me.RibbonBarOptions_CheckSpelling.Name = "RibbonBarOptions_CheckSpelling"
            Me.RibbonBarOptions_CheckSpelling.SecurityEnabled = True
            Me.RibbonBarOptions_CheckSpelling.Size = New System.Drawing.Size(91, 98)
            Me.RibbonBarOptions_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CheckSpelling.TabIndex = 4
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
            'RibbonBarOptions_MediaSpecs
            '
            Me.RibbonBarOptions_MediaSpecs.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaSpecs.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaSpecs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaSpecs.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaSpecs.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaSpecs.DragDropSupport = True
            Me.RibbonBarOptions_MediaSpecs.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaSpecs_Add, Me.ButtonItemMediaSpecs_Delete})
            Me.RibbonBarOptions_MediaSpecs.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaSpecs.Location = New System.Drawing.Point(481, 0)
            Me.RibbonBarOptions_MediaSpecs.Name = "RibbonBarOptions_MediaSpecs"
            Me.RibbonBarOptions_MediaSpecs.SecurityEnabled = True
            Me.RibbonBarOptions_MediaSpecs.Size = New System.Drawing.Size(93, 98)
            Me.RibbonBarOptions_MediaSpecs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaSpecs.TabIndex = 3
            Me.RibbonBarOptions_MediaSpecs.Text = "Media Specs"
            '
            '
            '
            Me.RibbonBarOptions_MediaSpecs.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaSpecs.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaSpecs.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMediaSpecs_Add
            '
            Me.ButtonItemMediaSpecs_Add.BeginGroup = True
            Me.ButtonItemMediaSpecs_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaSpecs_Add.Name = "ButtonItemMediaSpecs_Add"
            Me.ButtonItemMediaSpecs_Add.RibbonWordWrap = False
            Me.ButtonItemMediaSpecs_Add.SecurityEnabled = True
            Me.ButtonItemMediaSpecs_Add.SubItemsExpandWidth = 14
            Me.ButtonItemMediaSpecs_Add.Text = "Add"
            '
            'ButtonItemMediaSpecs_Delete
            '
            Me.ButtonItemMediaSpecs_Delete.BeginGroup = True
            Me.ButtonItemMediaSpecs_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaSpecs_Delete.Name = "ButtonItemMediaSpecs_Delete"
            Me.ButtonItemMediaSpecs_Delete.RibbonWordWrap = False
            Me.ButtonItemMediaSpecs_Delete.SecurityEnabled = True
            Me.ButtonItemMediaSpecs_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemMediaSpecs_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Representatives
            '
            Me.RibbonBarOptions_Representatives.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Representatives.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Representatives.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Representatives.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Representatives.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Representatives.DragDropSupport = True
            Me.RibbonBarOptions_Representatives.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRepresentatives_Add, Me.ButtonItemRepresentatives_Edit, Me.ButtonItemRepresentatives_Delete})
            Me.RibbonBarOptions_Representatives.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Representatives.Location = New System.Drawing.Point(366, 0)
            Me.RibbonBarOptions_Representatives.Name = "RibbonBarOptions_Representatives"
            Me.RibbonBarOptions_Representatives.SecurityEnabled = True
            Me.RibbonBarOptions_Representatives.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_Representatives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Representatives.TabIndex = 2
            Me.RibbonBarOptions_Representatives.Text = "Representatives"
            '
            '
            '
            Me.RibbonBarOptions_Representatives.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Representatives.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Representatives.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemRepresentatives_Add
            '
            Me.ButtonItemRepresentatives_Add.BeginGroup = True
            Me.ButtonItemRepresentatives_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRepresentatives_Add.Name = "ButtonItemRepresentatives_Add"
            Me.ButtonItemRepresentatives_Add.RibbonWordWrap = False
            Me.ButtonItemRepresentatives_Add.SecurityEnabled = True
            Me.ButtonItemRepresentatives_Add.SubItemsExpandWidth = 14
            Me.ButtonItemRepresentatives_Add.Text = "Add"
            '
            'ButtonItemRepresentatives_Edit
            '
            Me.ButtonItemRepresentatives_Edit.BeginGroup = True
            Me.ButtonItemRepresentatives_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRepresentatives_Edit.Name = "ButtonItemRepresentatives_Edit"
            Me.ButtonItemRepresentatives_Edit.RibbonWordWrap = False
            Me.ButtonItemRepresentatives_Edit.SecurityEnabled = True
            Me.ButtonItemRepresentatives_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemRepresentatives_Edit.Text = "Edit"
            '
            'ButtonItemRepresentatives_Delete
            '
            Me.ButtonItemRepresentatives_Delete.BeginGroup = True
            Me.ButtonItemRepresentatives_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRepresentatives_Delete.Name = "ButtonItemRepresentatives_Delete"
            Me.ButtonItemRepresentatives_Delete.RibbonWordWrap = False
            Me.ButtonItemRepresentatives_Delete.SecurityEnabled = True
            Me.ButtonItemRepresentatives_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemRepresentatives_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Contacts
            '
            Me.RibbonBarOptions_Contacts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Contacts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contacts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contacts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Contacts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Contacts.DragDropSupport = True
            Me.RibbonBarOptions_Contacts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContacts_Add, Me.ButtonItemContacts_Edit, Me.ButtonItemContacts_Delete})
            Me.RibbonBarOptions_Contacts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Contacts.Location = New System.Drawing.Point(251, 0)
            Me.RibbonBarOptions_Contacts.Name = "RibbonBarOptions_Contacts"
            Me.RibbonBarOptions_Contacts.SecurityEnabled = True
            Me.RibbonBarOptions_Contacts.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_Contacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contacts.TabIndex = 1
            Me.RibbonBarOptions_Contacts.Text = "Contacts"
            '
            '
            '
            Me.RibbonBarOptions_Contacts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contacts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contacts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemContacts_Add
            '
            Me.ButtonItemContacts_Add.BeginGroup = True
            Me.ButtonItemContacts_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContacts_Add.Name = "ButtonItemContacts_Add"
            Me.ButtonItemContacts_Add.RibbonWordWrap = False
            Me.ButtonItemContacts_Add.SecurityEnabled = True
            Me.ButtonItemContacts_Add.SubItemsExpandWidth = 14
            Me.ButtonItemContacts_Add.Text = "Add"
            '
            'ButtonItemContacts_Edit
            '
            Me.ButtonItemContacts_Edit.BeginGroup = True
            Me.ButtonItemContacts_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContacts_Edit.Name = "ButtonItemContacts_Edit"
            Me.ButtonItemContacts_Edit.RibbonWordWrap = False
            Me.ButtonItemContacts_Edit.SecurityEnabled = True
            Me.ButtonItemContacts_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemContacts_Edit.Text = "Edit"
            '
            'ButtonItemContacts_Delete
            '
            Me.ButtonItemContacts_Delete.BeginGroup = True
            Me.ButtonItemContacts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContacts_Delete.Name = "ButtonItemContacts_Delete"
            Me.ButtonItemContacts_Delete.RibbonWordWrap = False
            Me.ButtonItemContacts_Delete.SecurityEnabled = True
            Me.ButtonItemContacts_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemContacts_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print, Me.ButtonItemActions_PrintFiltered, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(251, 98)
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
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_PrintFiltered
            '
            Me.ButtonItemActions_PrintFiltered.BeginGroup = True
            Me.ButtonItemActions_PrintFiltered.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintFiltered.Name = "ButtonItemActions_PrintFiltered"
            Me.ButtonItemActions_PrintFiltered.RibbonWordWrap = False
            Me.ButtonItemActions_PrintFiltered.SecurityEnabled = True
            Me.ButtonItemActions_PrintFiltered.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintFiltered.Text = "Print Filtered"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.VendorControlRightSection_Vendor)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(187, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(742, 563)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'VendorControlRightSection_Vendor
            '
            Me.VendorControlRightSection_Vendor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorControlRightSection_Vendor.AutoScroll = True
            Me.VendorControlRightSection_Vendor.Location = New System.Drawing.Point(8, 12)
            Me.VendorControlRightSection_Vendor.Margin = New System.Windows.Forms.Padding(4)
            Me.VendorControlRightSection_Vendor.Name = "VendorControlRightSection_Vendor"
            Me.VendorControlRightSection_Vendor.Size = New System.Drawing.Size(722, 539)
            Me.VendorControlRightSection_Vendor.TabIndex = 0
            '
            'RibbonBarMergeContainerForm_Import
            '
            Me.RibbonBarMergeContainerForm_Import.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Import.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Import.Controls.Add(Me.RibbonBarImport_Import)
            Me.RibbonBarMergeContainerForm_Import.Location = New System.Drawing.Point(318, 201)
            Me.RibbonBarMergeContainerForm_Import.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Import.Name = "RibbonBarMergeContainerForm_Import"
            Me.RibbonBarMergeContainerForm_Import.RibbonTabText = "Import"
            Me.RibbonBarMergeContainerForm_Import.Size = New System.Drawing.Size(171, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Import.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Import.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Import.Visible = False
            '
            'RibbonBarImport_Import
            '
            Me.RibbonBarImport_Import.AutoOverflowEnabled = False
            Me.RibbonBarImport_Import.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarImport_Import.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImport_Import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImport_Import.ContainerControlProcessDialogKey = True
            Me.RibbonBarImport_Import.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarImport_Import.DragDropSupport = True
            Me.RibbonBarImport_Import.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarImport_Import.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemImport_Wizard, Me.ButtonItemImport_PendingRecords})
            Me.RibbonBarImport_Import.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarImport_Import.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarImport_Import.Name = "RibbonBarImport_Import"
            Me.RibbonBarImport_Import.SecurityEnabled = True
            Me.RibbonBarImport_Import.Size = New System.Drawing.Size(150, 98)
            Me.RibbonBarImport_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarImport_Import.TabIndex = 0
            Me.RibbonBarImport_Import.Text = "Import"
            '
            '
            '
            Me.RibbonBarImport_Import.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImport_Import.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImport_Import.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemImport_Wizard
            '
            Me.ButtonItemImport_Wizard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_Wizard.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_Wizard.Name = "ButtonItemImport_Wizard"
            Me.ButtonItemImport_Wizard.RibbonWordWrap = False
            Me.ButtonItemImport_Wizard.SecurityEnabled = True
            Me.ButtonItemImport_Wizard.SubItemsExpandWidth = 14
            Me.ButtonItemImport_Wizard.Text = "Wizard"
            '
            'ButtonItemImport_PendingRecords
            '
            Me.ButtonItemImport_PendingRecords.BeginGroup = True
            Me.ButtonItemImport_PendingRecords.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_PendingRecords.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_PendingRecords.Name = "ButtonItemImport_PendingRecords"
            Me.ButtonItemImport_PendingRecords.RibbonWordWrap = False
            Me.ButtonItemImport_PendingRecords.SecurityEnabled = True
            Me.ButtonItemImport_PendingRecords.SubItemsExpandWidth = 14
            Me.ButtonItemImport_PendingRecords.Text = "Pending Records"
            '
            'VendorSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(929, 563)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Import)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VendorSetupForm"
            Me.Text = "Vendor Maintenance"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Import.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Vendors As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Contacts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContacts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Representatives As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRepresentatives_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRepresentatives_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRepresentatives_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_MediaSpecs As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaSpecs_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpelling_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaSpecs_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Pricings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPricings_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPricings_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents VendorControlRightSection_Vendor As AdvantageFramework.WinForm.Presentation.Controls.VendorControl
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Import As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarImport_Import As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemImport_Wizard As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemImport_PendingRecords As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Contracts As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContracts_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Copy As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Edit As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Nielsen As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemNielsen_UpdateStations As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Markets As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMarkets_Manage As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_QuickBooks As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickBooks_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ComboStations As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemComboStations_Manage As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace