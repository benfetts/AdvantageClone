Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaRequestForProposalDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaRequestForProposalDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Generate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Default = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlPanel_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVendors_Vendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendors_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Vendors = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGuidelines_Guidelines = New DevComponents.DotNetBar.TabControlPanel()
            Me.RichEditGuidelines_Guidelines = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            Me.TabItemTabs_Guidelines = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMarkets_Markets = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMarkets_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Markets = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDemos_Demos = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDemos_Demos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Demos = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelStatus_Status = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewStatus_Statuses = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Status = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAvailLines_Lines = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAvailLines_AvailLines = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_AvailLines = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonItemAvailLines_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_AvailLines = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxAvailLines_Status = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_AvailLines = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemAvailLines_Status = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemAvailLines_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAvailLines_AddToWorksheet = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAvailLines_OmitSpots = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAvailLines_UpdateWorksheet = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAvailLines_AutoFill = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Dayparts = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemDayparts_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Templates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplates_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_View = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemView_Responses = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Markets = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemMarkets_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_Tabs.SuspendLayout()
            Me.TabControlPanelVendors_Vendors.SuspendLayout()
            Me.TabControlPanelGuidelines_Guidelines.SuspendLayout()
            Me.TabControlPanelMarkets_Markets.SuspendLayout()
            Me.TabControlPanelDemos_Demos.SuspendLayout()
            Me.TabControlPanelStatus_Status.SuspendLayout()
            Me.TabControlPanelAvailLines_Lines.SuspendLayout()
            Me.RibbonBarFilePanel_AvailLines.SuspendLayout()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.TabControlPanel_Tabs)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(985, 434)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(985, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Markets)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Dayparts)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_AvailLines)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Templates)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(985, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Templates, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_AvailLines, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Dayparts, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Markets, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 589)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(985, 18)
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Actions.DragDropSupport = True
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Upload, Me.ButtonItemActions_Import, Me.ButtonItemActions_Save, Me.ButtonItemActions_Generate, Me.ButtonItemActions_Default, Me.ButtonItemActions_AutoFill})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(72, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 1
            Me.RibbonBarFilePanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_Upload
            '
            Me.ButtonItemActions_Upload.AutoExpandOnClick = True
            Me.ButtonItemActions_Upload.BeginGroup = True
            Me.ButtonItemActions_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Upload.Name = "ButtonItemActions_Upload"
            Me.ButtonItemActions_Upload.RibbonWordWrap = False
            Me.ButtonItemActions_Upload.SecurityEnabled = True
            Me.ButtonItemActions_Upload.SplitButton = True
            Me.ButtonItemActions_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
            Me.ButtonItemActions_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Upload.Text = "Upload"
            '
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.RibbonWordWrap = False
            Me.ButtonItemActions_Import.SecurityEnabled = True
            Me.ButtonItemActions_Import.Stretch = True
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Generate
            '
            Me.ButtonItemActions_Generate.BeginGroup = True
            Me.ButtonItemActions_Generate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Generate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Generate.Name = "ButtonItemActions_Generate"
            Me.ButtonItemActions_Generate.RibbonWordWrap = False
            Me.ButtonItemActions_Generate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Generate.Text = "Generate"
            '
            'ButtonItemActions_Default
            '
            Me.ButtonItemActions_Default.BeginGroup = True
            Me.ButtonItemActions_Default.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Default.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Default.Name = "ButtonItemActions_Default"
            Me.ButtonItemActions_Default.RibbonWordWrap = False
            Me.ButtonItemActions_Default.SecurityEnabled = True
            Me.ButtonItemActions_Default.Stretch = True
            Me.ButtonItemActions_Default.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Default.Text = "Default"
            Me.ButtonItemActions_Default.Tooltip = "Load Default Guidelines"
            '
            'ButtonItemActions_AutoFill
            '
            Me.ButtonItemActions_AutoFill.BeginGroup = True
            Me.ButtonItemActions_AutoFill.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AutoFill.Name = "ButtonItemActions_AutoFill"
            Me.ButtonItemActions_AutoFill.RibbonWordWrap = False
            Me.ButtonItemActions_AutoFill.SecurityEnabled = True
            Me.ButtonItemActions_AutoFill.Stretch = True
            Me.ButtonItemActions_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AutoFill.Text = "Auto Fill"
            '
            'TabControlPanel_Tabs
            '
            Me.TabControlPanel_Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlPanel_Tabs.BackColor = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.CanReorderTabs = False
            Me.TabControlPanel_Tabs.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelVendors_Vendors)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelGuidelines_Guidelines)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelMarkets_Markets)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelDemos_Demos)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelStatus_Status)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelAvailLines_Lines)
            Me.TabControlPanel_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlPanel_Tabs.Location = New System.Drawing.Point(3, 6)
            Me.TabControlPanel_Tabs.Name = "TabControlPanel_Tabs"
            Me.TabControlPanel_Tabs.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlPanel_Tabs.SelectedTabIndex = 0
            Me.TabControlPanel_Tabs.Size = New System.Drawing.Size(979, 422)
            Me.TabControlPanel_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlPanel_Tabs.TabIndex = 4
            Me.TabControlPanel_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Vendors)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Status)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_AvailLines)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Demos)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Markets)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Guidelines)
            '
            'TabControlPanelVendors_Vendors
            '
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.DataGridViewVendors_Vendors)
            Me.TabControlPanelVendors_Vendors.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendors_Vendors.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendors_Vendors.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendors_Vendors.Name = "TabControlPanelVendors_Vendors"
            Me.TabControlPanelVendors_Vendors.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendors_Vendors.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelVendors_Vendors.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendors_Vendors.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendors_Vendors.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendors_Vendors.Style.GradientAngle = 90
            Me.TabControlPanelVendors_Vendors.TabIndex = 0
            Me.TabControlPanelVendors_Vendors.TabItem = Me.TabItemTabs_Vendors
            '
            'DataGridViewVendors_Vendors
            '
            Me.DataGridViewVendors_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVendors_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVendors_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewVendors_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVendors_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewVendors_Vendors.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewVendors_Vendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewVendors_Vendors.ModifyGridRowHeight = False
            Me.DataGridViewVendors_Vendors.MultiSelect = True
            Me.DataGridViewVendors_Vendors.Name = "DataGridViewVendors_Vendors"
            Me.DataGridViewVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewVendors_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewVendors_Vendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendors_Vendors.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewVendors_Vendors.TabIndex = 4
            Me.DataGridViewVendors_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewVendors_Vendors.ViewCaptionHeight = -1
            '
            'TabItemTabs_Vendors
            '
            Me.TabItemTabs_Vendors.AttachedControl = Me.TabControlPanelVendors_Vendors
            Me.TabItemTabs_Vendors.Name = "TabItemTabs_Vendors"
            Me.TabItemTabs_Vendors.Text = "Vendors"
            '
            'TabControlPanelGuidelines_Guidelines
            '
            Me.TabControlPanelGuidelines_Guidelines.Controls.Add(Me.RichEditGuidelines_Guidelines)
            Me.TabControlPanelGuidelines_Guidelines.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGuidelines_Guidelines.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGuidelines_Guidelines.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGuidelines_Guidelines.Name = "TabControlPanelGuidelines_Guidelines"
            Me.TabControlPanelGuidelines_Guidelines.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGuidelines_Guidelines.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelGuidelines_Guidelines.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGuidelines_Guidelines.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGuidelines_Guidelines.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGuidelines_Guidelines.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGuidelines_Guidelines.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGuidelines_Guidelines.Style.GradientAngle = 90
            Me.TabControlPanelGuidelines_Guidelines.TabIndex = 32
            Me.TabControlPanelGuidelines_Guidelines.TabItem = Me.TabItemTabs_Guidelines
            '
            'RichEditGuidelines_Guidelines
            '
            Me.RichEditGuidelines_Guidelines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichEditGuidelines_Guidelines.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RichEditGuidelines_Guidelines.HtmlText = resources.GetString("RichEditGuidelines_Guidelines.HtmlText")
            Me.RichEditGuidelines_Guidelines.Location = New System.Drawing.Point(9, 4)
            Me.RichEditGuidelines_Guidelines.Margin = New System.Windows.Forms.Padding(4)
            Me.RichEditGuidelines_Guidelines.MhtText = resources.GetString("RichEditGuidelines_Guidelines.MhtText")
            Me.RichEditGuidelines_Guidelines.Name = "RichEditGuidelines_Guidelines"
            Me.RichEditGuidelines_Guidelines.ReadOnly = False
            Me.RichEditGuidelines_Guidelines.RtfText = resources.GetString("RichEditGuidelines_Guidelines.RtfText")
            Me.RichEditGuidelines_Guidelines.SecurityEnabled = True
            Me.RichEditGuidelines_Guidelines.ShowEditButtons = True
            Me.RichEditGuidelines_Guidelines.Size = New System.Drawing.Size(961, 387)
            Me.RichEditGuidelines_Guidelines.TabIndex = 2
            Me.RichEditGuidelines_Guidelines.WordMLText = resources.GetString("RichEditGuidelines_Guidelines.WordMLText")
            '
            'TabItemTabs_Guidelines
            '
            Me.TabItemTabs_Guidelines.AttachedControl = Me.TabControlPanelGuidelines_Guidelines
            Me.TabItemTabs_Guidelines.Name = "TabItemTabs_Guidelines"
            Me.TabItemTabs_Guidelines.Text = "Guidelines"
            '
            'TabControlPanelMarkets_Markets
            '
            Me.TabControlPanelMarkets_Markets.Controls.Add(Me.DataGridViewMarkets_Markets)
            Me.TabControlPanelMarkets_Markets.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMarkets_Markets.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMarkets_Markets.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMarkets_Markets.Name = "TabControlPanelMarkets_Markets"
            Me.TabControlPanelMarkets_Markets.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMarkets_Markets.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelMarkets_Markets.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMarkets_Markets.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMarkets_Markets.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMarkets_Markets.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMarkets_Markets.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMarkets_Markets.Style.GradientAngle = 90
            Me.TabControlPanelMarkets_Markets.TabIndex = 45
            Me.TabControlPanelMarkets_Markets.TabItem = Me.TabItemTabs_Markets
            '
            'DataGridViewMarkets_Markets
            '
            Me.DataGridViewMarkets_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMarkets_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMarkets_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewMarkets_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMarkets_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewMarkets_Markets.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewMarkets_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewMarkets_Markets.ModifyGridRowHeight = False
            Me.DataGridViewMarkets_Markets.MultiSelect = True
            Me.DataGridViewMarkets_Markets.Name = "DataGridViewMarkets_Markets"
            Me.DataGridViewMarkets_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewMarkets_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewMarkets_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewMarkets_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMarkets_Markets.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewMarkets_Markets.TabIndex = 7
            Me.DataGridViewMarkets_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewMarkets_Markets.ViewCaptionHeight = -1
            '
            'TabItemTabs_Markets
            '
            Me.TabItemTabs_Markets.AttachedControl = Me.TabControlPanelMarkets_Markets
            Me.TabItemTabs_Markets.Name = "TabItemTabs_Markets"
            Me.TabItemTabs_Markets.Text = "Markets"
            '
            'TabControlPanelDemos_Demos
            '
            Me.TabControlPanelDemos_Demos.Controls.Add(Me.DataGridViewDemos_Demos)
            Me.TabControlPanelDemos_Demos.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDemos_Demos.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDemos_Demos.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDemos_Demos.Name = "TabControlPanelDemos_Demos"
            Me.TabControlPanelDemos_Demos.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDemos_Demos.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelDemos_Demos.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDemos_Demos.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDemos_Demos.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDemos_Demos.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDemos_Demos.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDemos_Demos.Style.GradientAngle = 90
            Me.TabControlPanelDemos_Demos.TabIndex = 15
            Me.TabControlPanelDemos_Demos.TabItem = Me.TabItemTabs_Demos
            '
            'DataGridViewDemos_Demos
            '
            Me.DataGridViewDemos_Demos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDemos_Demos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDemos_Demos.AutoUpdateViewCaption = True
            Me.DataGridViewDemos_Demos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDemos_Demos.ItemDescription = "Demo(s)"
            Me.DataGridViewDemos_Demos.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewDemos_Demos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDemos_Demos.ModifyGridRowHeight = False
            Me.DataGridViewDemos_Demos.MultiSelect = True
            Me.DataGridViewDemos_Demos.Name = "DataGridViewDemos_Demos"
            Me.DataGridViewDemos_Demos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDemos_Demos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDemos_Demos.ShowRowSelectionIfHidden = True
            Me.DataGridViewDemos_Demos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDemos_Demos.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewDemos_Demos.TabIndex = 6
            Me.DataGridViewDemos_Demos.UseEmbeddedNavigator = False
            Me.DataGridViewDemos_Demos.ViewCaptionHeight = -1
            '
            'TabItemTabs_Demos
            '
            Me.TabItemTabs_Demos.AttachedControl = Me.TabControlPanelDemos_Demos
            Me.TabItemTabs_Demos.Name = "TabItemTabs_Demos"
            Me.TabItemTabs_Demos.Text = "Demos"
            '
            'TabControlPanelStatus_Status
            '
            Me.TabControlPanelStatus_Status.Controls.Add(Me.DataGridViewStatus_Statuses)
            Me.TabControlPanelStatus_Status.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelStatus_Status.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStatus_Status.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelStatus_Status.Name = "TabControlPanelStatus_Status"
            Me.TabControlPanelStatus_Status.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStatus_Status.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelStatus_Status.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelStatus_Status.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelStatus_Status.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStatus_Status.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStatus_Status.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStatus_Status.Style.GradientAngle = 90
            Me.TabControlPanelStatus_Status.TabIndex = 19
            Me.TabControlPanelStatus_Status.TabItem = Me.TabItemTabs_Status
            '
            'DataGridViewStatus_Statuses
            '
            Me.DataGridViewStatus_Statuses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewStatus_Statuses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewStatus_Statuses.AutoUpdateViewCaption = True
            Me.DataGridViewStatus_Statuses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewStatus_Statuses.ItemDescription = "Status(es)"
            Me.DataGridViewStatus_Statuses.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewStatus_Statuses.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewStatus_Statuses.ModifyGridRowHeight = False
            Me.DataGridViewStatus_Statuses.MultiSelect = True
            Me.DataGridViewStatus_Statuses.Name = "DataGridViewStatus_Statuses"
            Me.DataGridViewStatus_Statuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewStatus_Statuses.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewStatus_Statuses.ShowRowSelectionIfHidden = True
            Me.DataGridViewStatus_Statuses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewStatus_Statuses.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewStatus_Statuses.TabIndex = 7
            Me.DataGridViewStatus_Statuses.UseEmbeddedNavigator = False
            Me.DataGridViewStatus_Statuses.ViewCaptionHeight = -1
            '
            'TabItemTabs_Status
            '
            Me.TabItemTabs_Status.AttachedControl = Me.TabControlPanelStatus_Status
            Me.TabItemTabs_Status.Name = "TabItemTabs_Status"
            Me.TabItemTabs_Status.Text = "Status"
            '
            'TabControlPanelAvailLines_Lines
            '
            Me.TabControlPanelAvailLines_Lines.Controls.Add(Me.DataGridViewAvailLines_AvailLines)
            Me.TabControlPanelAvailLines_Lines.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAvailLines_Lines.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAvailLines_Lines.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAvailLines_Lines.Name = "TabControlPanelAvailLines_Lines"
            Me.TabControlPanelAvailLines_Lines.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAvailLines_Lines.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelAvailLines_Lines.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAvailLines_Lines.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAvailLines_Lines.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAvailLines_Lines.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAvailLines_Lines.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAvailLines_Lines.Style.GradientAngle = 90
            Me.TabControlPanelAvailLines_Lines.TabIndex = 11
            Me.TabControlPanelAvailLines_Lines.TabItem = Me.TabItemTabs_AvailLines
            '
            'DataGridViewAvailLines_AvailLines
            '
            Me.DataGridViewAvailLines_AvailLines.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAvailLines_AvailLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAvailLines_AvailLines.AutoUpdateViewCaption = True
            Me.DataGridViewAvailLines_AvailLines.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAvailLines_AvailLines.ItemDescription = "Avail Line(s)"
            Me.DataGridViewAvailLines_AvailLines.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewAvailLines_AvailLines.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewAvailLines_AvailLines.ModifyGridRowHeight = False
            Me.DataGridViewAvailLines_AvailLines.MultiSelect = True
            Me.DataGridViewAvailLines_AvailLines.Name = "DataGridViewAvailLines_AvailLines"
            Me.DataGridViewAvailLines_AvailLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewAvailLines_AvailLines.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewAvailLines_AvailLines.ShowRowSelectionIfHidden = True
            Me.DataGridViewAvailLines_AvailLines.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAvailLines_AvailLines.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewAvailLines_AvailLines.TabIndex = 5
            Me.DataGridViewAvailLines_AvailLines.UseEmbeddedNavigator = False
            Me.DataGridViewAvailLines_AvailLines.ViewCaptionHeight = -1
            '
            'TabItemTabs_AvailLines
            '
            Me.TabItemTabs_AvailLines.AttachedControl = Me.TabControlPanelAvailLines_Lines
            Me.TabItemTabs_AvailLines.Name = "TabItemTabs_AvailLines"
            Me.TabItemTabs_AvailLines.Text = "Avail Lines"
            '
            'ButtonItemAvailLines_Delete
            '
            Me.ButtonItemAvailLines_Delete.BeginGroup = True
            Me.ButtonItemAvailLines_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAvailLines_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAvailLines_Delete.Name = "ButtonItemAvailLines_Delete"
            Me.ButtonItemAvailLines_Delete.RibbonWordWrap = False
            Me.ButtonItemAvailLines_Delete.SecurityEnabled = True
            Me.ButtonItemAvailLines_Delete.Stretch = True
            Me.ButtonItemAvailLines_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemAvailLines_Delete.Text = "Update Worksheet"
            '
            'RibbonBarFilePanel_AvailLines
            '
            Me.RibbonBarFilePanel_AvailLines.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_AvailLines.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_AvailLines.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_AvailLines.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_AvailLines.Controls.Add(Me.ComboBoxAvailLines_Status)
            Me.RibbonBarFilePanel_AvailLines.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_AvailLines.DragDropSupport = True
            Me.RibbonBarFilePanel_AvailLines.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_AvailLines, Me.ButtonItemAvailLines_AddToWorksheet, Me.ButtonItemAvailLines_UpdateWorksheet, Me.ButtonItemAvailLines_AutoFill})
            Me.RibbonBarFilePanel_AvailLines.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_AvailLines.Location = New System.Drawing.Point(253, 0)
            Me.RibbonBarFilePanel_AvailLines.Name = "RibbonBarFilePanel_AvailLines"
            Me.RibbonBarFilePanel_AvailLines.SecurityEnabled = True
            Me.RibbonBarFilePanel_AvailLines.Size = New System.Drawing.Size(462, 92)
            Me.RibbonBarFilePanel_AvailLines.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_AvailLines.TabIndex = 16
            Me.RibbonBarFilePanel_AvailLines.Text = "Avail Lines"
            '
            '
            '
            Me.RibbonBarFilePanel_AvailLines.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_AvailLines.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_AvailLines.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxAvailLines_Status
            '
            Me.ComboBoxAvailLines_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAvailLines_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAvailLines_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAvailLines_Status.AutoFindItemInDataSource = False
            Me.ComboBoxAvailLines_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAvailLines_Status.BookmarkingEnabled = False
            Me.ComboBoxAvailLines_Status.DisableMouseWheel = False
            Me.ComboBoxAvailLines_Status.DisplayMember = "Description"
            Me.ComboBoxAvailLines_Status.DisplayName = "Process Control"
            Me.ComboBoxAvailLines_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAvailLines_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAvailLines_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxAvailLines_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAvailLines_Status.FocusHighlightEnabled = True
            Me.ComboBoxAvailLines_Status.FormattingEnabled = True
            Me.ComboBoxAvailLines_Status.ItemHeight = 15
            Me.ComboBoxAvailLines_Status.Location = New System.Drawing.Point(6, 4)
            Me.ComboBoxAvailLines_Status.Name = "ComboBoxAvailLines_Status"
            Me.ComboBoxAvailLines_Status.ReadOnly = False
            Me.ComboBoxAvailLines_Status.SecurityEnabled = True
            Me.ComboBoxAvailLines_Status.Size = New System.Drawing.Size(133, 21)
            Me.ComboBoxAvailLines_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAvailLines_Status.TabIndex = 7
            Me.ComboBoxAvailLines_Status.TabOnEnter = True
            Me.ComboBoxAvailLines_Status.ValueMember = "ID"
            Me.ComboBoxAvailLines_Status.WatermarkText = "Select Status"
            '
            'ItemContainerVertical_AvailLines
            '
            '
            '
            '
            Me.ItemContainerVertical_AvailLines.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_AvailLines.BeginGroup = True
            Me.ItemContainerVertical_AvailLines.FixedSize = New System.Drawing.Size(140, 0)
            Me.ItemContainerVertical_AvailLines.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_AvailLines.Name = "ItemContainerVertical_AvailLines"
            Me.ItemContainerVertical_AvailLines.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemAvailLines_Status, Me.ButtonItemAvailLines_MarkSelected})
            '
            '
            '
            Me.ItemContainerVertical_AvailLines.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_AvailLines.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemAvailLines_Status
            '
            Me.ControlContainerItemAvailLines_Status.AllowItemResize = True
            Me.ControlContainerItemAvailLines_Status.BeginGroup = True
            Me.ControlContainerItemAvailLines_Status.Control = Me.ComboBoxAvailLines_Status
            Me.ControlContainerItemAvailLines_Status.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ControlContainerItemAvailLines_Status.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemAvailLines_Status.Name = "ControlContainerItemAvailLines_Status"
            '
            'ButtonItemAvailLines_MarkSelected
            '
            Me.ButtonItemAvailLines_MarkSelected.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemAvailLines_MarkSelected.Name = "ButtonItemAvailLines_MarkSelected"
            Me.ButtonItemAvailLines_MarkSelected.Text = "Mark Selected"
            '
            'ButtonItemAvailLines_AddToWorksheet
            '
            Me.ButtonItemAvailLines_AddToWorksheet.BeginGroup = True
            Me.ButtonItemAvailLines_AddToWorksheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAvailLines_AddToWorksheet.Name = "ButtonItemAvailLines_AddToWorksheet"
            Me.ButtonItemAvailLines_AddToWorksheet.RibbonWordWrap = False
            Me.ButtonItemAvailLines_AddToWorksheet.SplitButton = True
            Me.ButtonItemAvailLines_AddToWorksheet.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAvailLines_OmitSpots})
            Me.ButtonItemAvailLines_AddToWorksheet.SubItemsExpandWidth = 14
            Me.ButtonItemAvailLines_AddToWorksheet.Text = "Add to Worksheet"
            '
            'ButtonItemAvailLines_OmitSpots
            '
            Me.ButtonItemAvailLines_OmitSpots.Name = "ButtonItemAvailLines_OmitSpots"
            Me.ButtonItemAvailLines_OmitSpots.Text = "Omit Spots"
            '
            'ButtonItemAvailLines_UpdateWorksheet
            '
            Me.ButtonItemAvailLines_UpdateWorksheet.BeginGroup = True
            Me.ButtonItemAvailLines_UpdateWorksheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAvailLines_UpdateWorksheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAvailLines_UpdateWorksheet.Name = "ButtonItemAvailLines_UpdateWorksheet"
            Me.ButtonItemAvailLines_UpdateWorksheet.RibbonWordWrap = False
            Me.ButtonItemAvailLines_UpdateWorksheet.SecurityEnabled = True
            Me.ButtonItemAvailLines_UpdateWorksheet.Stretch = True
            Me.ButtonItemAvailLines_UpdateWorksheet.SubItemsExpandWidth = 14
            Me.ButtonItemAvailLines_UpdateWorksheet.Text = "Update Worksheet"
            '
            'ButtonItemAvailLines_AutoFill
            '
            Me.ButtonItemAvailLines_AutoFill.BeginGroup = True
            Me.ButtonItemAvailLines_AutoFill.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAvailLines_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAvailLines_AutoFill.Name = "ButtonItemAvailLines_AutoFill"
            Me.ButtonItemAvailLines_AutoFill.RibbonWordWrap = False
            Me.ButtonItemAvailLines_AutoFill.SecurityEnabled = True
            Me.ButtonItemAvailLines_AutoFill.Stretch = True
            Me.ButtonItemAvailLines_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemAvailLines_AutoFill.Text = "Auto Fill"
            '
            'RibbonBarFilePanel_Dayparts
            '
            Me.RibbonBarFilePanel_Dayparts.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Dayparts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Dayparts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Dayparts.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Dayparts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Dayparts.DragDropSupport = True
            Me.RibbonBarFilePanel_Dayparts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDayparts_Manage})
            Me.RibbonBarFilePanel_Dayparts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Dayparts.Location = New System.Drawing.Point(715, 0)
            Me.RibbonBarFilePanel_Dayparts.Name = "RibbonBarFilePanel_Dayparts"
            Me.RibbonBarFilePanel_Dayparts.Size = New System.Drawing.Size(80, 92)
            Me.RibbonBarFilePanel_Dayparts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Dayparts.TabIndex = 17
            Me.RibbonBarFilePanel_Dayparts.Text = "Dayparts"
            '
            '
            '
            Me.RibbonBarFilePanel_Dayparts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Dayparts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDayparts_Manage
            '
            Me.ButtonItemDayparts_Manage.BeginGroup = True
            Me.ButtonItemDayparts_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDayparts_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDayparts_Manage.Name = "ButtonItemDayparts_Manage"
            Me.ButtonItemDayparts_Manage.RibbonWordWrap = False
            Me.ButtonItemDayparts_Manage.SecurityEnabled = True
            Me.ButtonItemDayparts_Manage.Stretch = True
            Me.ButtonItemDayparts_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemDayparts_Manage.Text = "Manage"
            '
            'RibbonBarFilePanel_Templates
            '
            Me.RibbonBarFilePanel_Templates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_Templates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Templates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Templates.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Templates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Templates.DragDropSupport = True
            Me.RibbonBarFilePanel_Templates.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_Templates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplates_Edit})
            Me.RibbonBarFilePanel_Templates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Templates.Location = New System.Drawing.Point(175, 0)
            Me.RibbonBarFilePanel_Templates.Name = "RibbonBarFilePanel_Templates"
            Me.RibbonBarFilePanel_Templates.SecurityEnabled = True
            Me.RibbonBarFilePanel_Templates.Size = New System.Drawing.Size(78, 92)
            Me.RibbonBarFilePanel_Templates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Templates.TabIndex = 19
            Me.RibbonBarFilePanel_Templates.Text = "Templates"
            '
            '
            '
            Me.RibbonBarFilePanel_Templates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Templates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Templates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            'RibbonBarFilePanel_View
            '
            Me.RibbonBarFilePanel_View.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_View.DragDropSupport = True
            Me.RibbonBarFilePanel_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Responses})
            Me.RibbonBarFilePanel_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_View.Location = New System.Drawing.Point(795, 0)
            Me.RibbonBarFilePanel_View.Name = "RibbonBarFilePanel_View"
            Me.RibbonBarFilePanel_View.Size = New System.Drawing.Size(103, 92)
            Me.RibbonBarFilePanel_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_View.TabIndex = 20
            Me.RibbonBarFilePanel_View.Text = "View"
            '
            '
            '
            Me.RibbonBarFilePanel_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemView_Responses
            '
            Me.ButtonItemView_Responses.BeginGroup = True
            Me.ButtonItemView_Responses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_Responses.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Responses.Name = "ButtonItemView_Responses"
            Me.ButtonItemView_Responses.RibbonWordWrap = False
            Me.ButtonItemView_Responses.SecurityEnabled = True
            Me.ButtonItemView_Responses.Stretch = True
            Me.ButtonItemView_Responses.SubItemsExpandWidth = 14
            Me.ButtonItemView_Responses.Text = "Responses"
            '
            'RibbonBarFilePanel_Markets
            '
            Me.RibbonBarFilePanel_Markets.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Markets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Markets.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Markets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Markets.DragDropSupport = True
            Me.RibbonBarFilePanel_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarkets_Manage})
            Me.RibbonBarFilePanel_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Markets.Location = New System.Drawing.Point(898, 0)
            Me.RibbonBarFilePanel_Markets.Name = "RibbonBarFilePanel_Markets"
            Me.RibbonBarFilePanel_Markets.Size = New System.Drawing.Size(80, 92)
            Me.RibbonBarFilePanel_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Markets.TabIndex = 21
            Me.RibbonBarFilePanel_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarFilePanel_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemMarkets_Manage
            '
            Me.ButtonItemMarkets_Manage.BeginGroup = True
            Me.ButtonItemMarkets_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Manage.Name = "ButtonItemMarkets_Manage"
            Me.ButtonItemMarkets_Manage.RibbonWordWrap = False
            Me.ButtonItemMarkets_Manage.SecurityEnabled = True
            Me.ButtonItemMarkets_Manage.Stretch = True
            Me.ButtonItemMarkets_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Manage.Text = "Manage"
            '
            'MediaRequestForProposalDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(995, 609)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaRequestForProposalDialog"
            Me.Text = "Media Request For Proposal"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel_Tabs.ResumeLayout(False)
            Me.TabControlPanelVendors_Vendors.ResumeLayout(False)
            Me.TabControlPanelGuidelines_Guidelines.ResumeLayout(False)
            Me.TabControlPanelMarkets_Markets.ResumeLayout(False)
            Me.TabControlPanelDemos_Demos.ResumeLayout(False)
            Me.TabControlPanelStatus_Status.ResumeLayout(False)
            Me.TabControlPanelAvailLines_Lines.ResumeLayout(False)
            Me.RibbonBarFilePanel_AvailLines.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents TabControlPanel_Tabs As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVendors_Vendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Vendors As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAvailLines_Lines As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_AvailLines As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewVendors_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewAvailLines_AvailLines As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemAvailLines_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_AvailLines As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxAvailLines_Status As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainerVertical_AvailLines As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemAvailLines_Status As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemAvailLines_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAvailLines_UpdateWorksheet As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAvailLines_AutoFill As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Import As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelDemos_Demos As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewDemos_Demos As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Demos As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarFilePanel_Dayparts As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemDayparts_Manage As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Upload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelStatus_Status As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Status As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewStatus_Statuses As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelGuidelines_Guidelines As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Guidelines As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_Generate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Default As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Templates As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTemplates_Edit As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_View As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemView_Responses As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RichEditGuidelines_Guidelines As WinForm.Presentation.Controls.RichEditControl
        Friend WithEvents ButtonItemActions_AutoFill As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelMarkets_Markets As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewMarkets_Markets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Markets As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarFilePanel_Markets As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemMarkets_Manage As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAvailLines_AddToWorksheet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAvailLines_OmitSpots As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace