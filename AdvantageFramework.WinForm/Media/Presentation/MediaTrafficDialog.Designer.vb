Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTrafficDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTrafficDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerVerticalOptions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemActions_AddToAllVendors = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_RemoveFromAllVendors = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Generate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Default = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AddBookend = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlPanel_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCreativeGroups_CreativeGroups = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewCreativeGroup_CreativeGroups = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelCreativeGroups_TrafficStartEndDescription = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_CreativeGroups = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDetails_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelDetails_CreativeGroup = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewDetails_Details = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Details = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocument_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelDocuments_CreativeGroupTitle = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DocumentManagerControlDocuments_DetailDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemTabs_Documents = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRevisions_Revisions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRevision_Revisions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Revisions = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMissing_Instructions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMTI_MissingTrafficInstructions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_MissingInstructions = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVendors_Vendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendors_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Vendors = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGuidelines_Guidelines = New DevComponents.DotNetBar.TabControlPanel()
            Me.RichEditGuidelines_Guidelines = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            Me.TabItemTabs_Guidelines = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelStatus_Status = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewStatus_Statuses = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Status = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarFilePanel_View = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemView_CreativeGroups = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_Responses = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Instruction = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInstruction_Preview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInstruction_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Revisions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerRevisions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemRevisions_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRevisions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerRevisions2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemRevisions_Revisions = New DevComponents.DotNetBar.ComboBoxItem()
            Me.RibbonBarFilePanel_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Creative = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEdit_AdNumbers = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_Tabs.SuspendLayout()
            Me.TabControlPanelCreativeGroups_CreativeGroups.SuspendLayout()
            Me.TabControlPanelDetails_Details.SuspendLayout()
            Me.TabControlPanelDocument_Documents.SuspendLayout()
            Me.TabControlPanelRevisions_Revisions.SuspendLayout()
            Me.TabControlPanelMissing_Instructions.SuspendLayout()
            Me.TabControlPanelVendors_Vendors.SuspendLayout()
            Me.TabControlPanelGuidelines_Guidelines.SuspendLayout()
            Me.TabControlPanelStatus_Status.SuspendLayout()
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Instruction)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Revisions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Creative)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Creative, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Revisions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Instruction, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Documents, 0)
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_CopyTo, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel, Me.ItemContainerVerticalOptions, Me.ButtonItemActions_Generate, Me.ButtonItemActions_Default, Me.ButtonItemActions_AddBookend})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(345, 92)
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
            'ButtonItemActions_CopyTo
            '
            Me.ButtonItemActions_CopyTo.BeginGroup = True
            Me.ButtonItemActions_CopyTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CopyTo.Name = "ButtonItemActions_CopyTo"
            Me.ButtonItemActions_CopyTo.RibbonWordWrap = False
            Me.ButtonItemActions_CopyTo.SecurityEnabled = True
            Me.ButtonItemActions_CopyTo.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CopyTo.Text = "Copy To"
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
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ItemContainerVerticalOptions
            '
            '
            '
            '
            Me.ItemContainerVerticalOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVerticalOptions.BeginGroup = True
            Me.ItemContainerVerticalOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVerticalOptions.Name = "ItemContainerVerticalOptions"
            Me.ItemContainerVerticalOptions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AddToAllVendors, Me.ButtonItemActions_RemoveFromAllVendors})
            '
            '
            '
            Me.ItemContainerVerticalOptions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVerticalOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_AddToAllVendors
            '
            Me.ButtonItemActions_AddToAllVendors.BeginGroup = True
            Me.ButtonItemActions_AddToAllVendors.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AddToAllVendors.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemActions_AddToAllVendors.Name = "ButtonItemActions_AddToAllVendors"
            Me.ButtonItemActions_AddToAllVendors.RibbonWordWrap = False
            Me.ButtonItemActions_AddToAllVendors.SecurityEnabled = True
            Me.ButtonItemActions_AddToAllVendors.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddToAllVendors.Text = "Add to All Vendors"
            Me.ButtonItemActions_AddToAllVendors.Tooltip = "Add Selected Instruction to All Vendors"
            '
            'ButtonItemActions_RemoveFromAllVendors
            '
            Me.ButtonItemActions_RemoveFromAllVendors.BeginGroup = True
            Me.ButtonItemActions_RemoveFromAllVendors.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_RemoveFromAllVendors.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemActions_RemoveFromAllVendors.Name = "ButtonItemActions_RemoveFromAllVendors"
            Me.ButtonItemActions_RemoveFromAllVendors.RibbonWordWrap = False
            Me.ButtonItemActions_RemoveFromAllVendors.SecurityEnabled = True
            Me.ButtonItemActions_RemoveFromAllVendors.SubItemsExpandWidth = 14
            Me.ButtonItemActions_RemoveFromAllVendors.Text = "Remove From All Vendors"
            Me.ButtonItemActions_RemoveFromAllVendors.Tooltip = "Remove Selected Instruction from All Vendors"
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
            'ButtonItemActions_AddBookend
            '
            Me.ButtonItemActions_AddBookend.BeginGroup = True
            Me.ButtonItemActions_AddBookend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AddBookend.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AddBookend.Name = "ButtonItemActions_AddBookend"
            Me.ButtonItemActions_AddBookend.RibbonWordWrap = False
            Me.ButtonItemActions_AddBookend.SecurityEnabled = True
            Me.ButtonItemActions_AddBookend.Stretch = True
            Me.ButtonItemActions_AddBookend.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddBookend.Text = "Add Bookend"
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
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelRevisions_Revisions)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelCreativeGroups_CreativeGroups)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelDetails_Details)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelDocument_Documents)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelMissing_Instructions)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelVendors_Vendors)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelGuidelines_Guidelines)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelStatus_Status)
            Me.TabControlPanel_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlPanel_Tabs.Location = New System.Drawing.Point(3, 6)
            Me.TabControlPanel_Tabs.Name = "TabControlPanel_Tabs"
            Me.TabControlPanel_Tabs.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlPanel_Tabs.SelectedTabIndex = 0
            Me.TabControlPanel_Tabs.Size = New System.Drawing.Size(979, 422)
            Me.TabControlPanel_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlPanel_Tabs.TabIndex = 4
            Me.TabControlPanel_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Revisions)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_CreativeGroups)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Details)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Documents)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Vendors)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Status)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Guidelines)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_MissingInstructions)
            '
            'TabControlPanelCreativeGroups_CreativeGroups
            '
            Me.TabControlPanelCreativeGroups_CreativeGroups.Controls.Add(Me.DataGridViewCreativeGroup_CreativeGroups)
            Me.TabControlPanelCreativeGroups_CreativeGroups.Controls.Add(Me.LabelCreativeGroups_TrafficStartEndDescription)
            Me.TabControlPanelCreativeGroups_CreativeGroups.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCreativeGroups_CreativeGroups.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCreativeGroups_CreativeGroups.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCreativeGroups_CreativeGroups.Name = "TabControlPanelCreativeGroups_CreativeGroups"
            Me.TabControlPanelCreativeGroups_CreativeGroups.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCreativeGroups_CreativeGroups.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCreativeGroups_CreativeGroups.Style.GradientAngle = 90
            Me.TabControlPanelCreativeGroups_CreativeGroups.TabIndex = 59
            Me.TabControlPanelCreativeGroups_CreativeGroups.TabItem = Me.TabItemTabs_CreativeGroups
            '
            'DataGridViewCreativeGroup_CreativeGroups
            '
            Me.DataGridViewCreativeGroup_CreativeGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCreativeGroup_CreativeGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCreativeGroup_CreativeGroups.AutoUpdateViewCaption = True
            Me.DataGridViewCreativeGroup_CreativeGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCreativeGroup_CreativeGroups.ItemDescription = "Creative Group(s)"
            Me.DataGridViewCreativeGroup_CreativeGroups.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewCreativeGroup_CreativeGroups.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewCreativeGroup_CreativeGroups.ModifyGridRowHeight = False
            Me.DataGridViewCreativeGroup_CreativeGroups.MultiSelect = False
            Me.DataGridViewCreativeGroup_CreativeGroups.Name = "DataGridViewCreativeGroup_CreativeGroups"
            Me.DataGridViewCreativeGroup_CreativeGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewCreativeGroup_CreativeGroups.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewCreativeGroup_CreativeGroups.ShowRowSelectionIfHidden = True
            Me.DataGridViewCreativeGroup_CreativeGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCreativeGroup_CreativeGroups.Size = New System.Drawing.Size(961, 361)
            Me.DataGridViewCreativeGroup_CreativeGroups.TabIndex = 13
            Me.DataGridViewCreativeGroup_CreativeGroups.UseEmbeddedNavigator = False
            Me.DataGridViewCreativeGroup_CreativeGroups.ViewCaptionHeight = -1
            '
            'LabelCreativeGroups_TrafficStartEndDescription
            '
            Me.LabelCreativeGroups_TrafficStartEndDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCreativeGroups_TrafficStartEndDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCreativeGroups_TrafficStartEndDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCreativeGroups_TrafficStartEndDescription.Location = New System.Drawing.Point(9, 4)
            Me.LabelCreativeGroups_TrafficStartEndDescription.Name = "LabelCreativeGroups_TrafficStartEndDescription"
            Me.LabelCreativeGroups_TrafficStartEndDescription.Size = New System.Drawing.Size(961, 20)
            Me.LabelCreativeGroups_TrafficStartEndDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCreativeGroups_TrafficStartEndDescription.TabIndex = 12
            '
            'TabItemTabs_CreativeGroups
            '
            Me.TabItemTabs_CreativeGroups.AttachedControl = Me.TabControlPanelCreativeGroups_CreativeGroups
            Me.TabItemTabs_CreativeGroups.Name = "TabItemTabs_CreativeGroups"
            Me.TabItemTabs_CreativeGroups.Text = "Creative Groups"
            '
            'TabControlPanelDetails_Details
            '
            Me.TabControlPanelDetails_Details.Controls.Add(Me.LabelDetails_CreativeGroup)
            Me.TabControlPanelDetails_Details.Controls.Add(Me.DataGridViewDetails_Details)
            Me.TabControlPanelDetails_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDetails_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetails_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetails_Details.Name = "TabControlPanelDetails_Details"
            Me.TabControlPanelDetails_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetails_Details.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelDetails_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDetails_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetails_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetails_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetails_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetails_Details.Style.GradientAngle = 90
            Me.TabControlPanelDetails_Details.TabIndex = 42
            Me.TabControlPanelDetails_Details.TabItem = Me.TabItemTabs_Details
            '
            'LabelDetails_CreativeGroup
            '
            Me.LabelDetails_CreativeGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelDetails_CreativeGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetails_CreativeGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetails_CreativeGroup.Location = New System.Drawing.Point(9, 4)
            Me.LabelDetails_CreativeGroup.Name = "LabelDetails_CreativeGroup"
            Me.LabelDetails_CreativeGroup.Size = New System.Drawing.Size(961, 20)
            Me.LabelDetails_CreativeGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetails_CreativeGroup.TabIndex = 8
            '
            'DataGridViewDetails_Details
            '
            Me.DataGridViewDetails_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDetails_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDetails_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDetails_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDetails_Details.ItemDescription = "Detail(s)"
            Me.DataGridViewDetails_Details.Location = New System.Drawing.Point(9, 30)
            Me.DataGridViewDetails_Details.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDetails_Details.ModifyGridRowHeight = False
            Me.DataGridViewDetails_Details.MultiSelect = True
            Me.DataGridViewDetails_Details.Name = "DataGridViewDetails_Details"
            Me.DataGridViewDetails_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDetails_Details.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDetails_Details.ShowRowSelectionIfHidden = True
            Me.DataGridViewDetails_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDetails_Details.Size = New System.Drawing.Size(961, 361)
            Me.DataGridViewDetails_Details.TabIndex = 6
            Me.DataGridViewDetails_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDetails_Details.ViewCaptionHeight = -1
            '
            'TabItemTabs_Details
            '
            Me.TabItemTabs_Details.AttachedControl = Me.TabControlPanelDetails_Details
            Me.TabItemTabs_Details.Name = "TabItemTabs_Details"
            Me.TabItemTabs_Details.Text = "Details"
            '
            'TabControlPanelDocument_Documents
            '
            Me.TabControlPanelDocument_Documents.Controls.Add(Me.LabelDocuments_CreativeGroupTitle)
            Me.TabControlPanelDocument_Documents.Controls.Add(Me.DocumentManagerControlDocuments_DetailDocuments)
            Me.TabControlPanelDocument_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocument_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocument_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocument_Documents.Name = "TabControlPanelDocument_Documents"
            Me.TabControlPanelDocument_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocument_Documents.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelDocument_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocument_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocument_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocument_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocument_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocument_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocument_Documents.TabIndex = 68
            Me.TabControlPanelDocument_Documents.TabItem = Me.TabItemTabs_Documents
            '
            'LabelDocuments_CreativeGroupTitle
            '
            Me.LabelDocuments_CreativeGroupTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelDocuments_CreativeGroupTitle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDocuments_CreativeGroupTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDocuments_CreativeGroupTitle.Location = New System.Drawing.Point(9, 4)
            Me.LabelDocuments_CreativeGroupTitle.Name = "LabelDocuments_CreativeGroupTitle"
            Me.LabelDocuments_CreativeGroupTitle.Size = New System.Drawing.Size(961, 20)
            Me.LabelDocuments_CreativeGroupTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDocuments_CreativeGroupTitle.TabIndex = 9
            '
            'DocumentManagerControlDocuments_DetailDocuments
            '
            Me.DocumentManagerControlDocuments_DetailDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_DetailDocuments.Location = New System.Drawing.Point(9, 30)
            Me.DocumentManagerControlDocuments_DetailDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_DetailDocuments.Name = "DocumentManagerControlDocuments_DetailDocuments"
            Me.DocumentManagerControlDocuments_DetailDocuments.Size = New System.Drawing.Size(961, 361)
            Me.DocumentManagerControlDocuments_DetailDocuments.TabIndex = 2
            '
            'TabItemTabs_Documents
            '
            Me.TabItemTabs_Documents.AttachedControl = Me.TabControlPanelDocument_Documents
            Me.TabItemTabs_Documents.Name = "TabItemTabs_Documents"
            Me.TabItemTabs_Documents.Text = "Documents"
            '
            'TabControlPanelRevisions_Revisions
            '
            Me.TabControlPanelRevisions_Revisions.Controls.Add(Me.DataGridViewRevision_Revisions)
            Me.TabControlPanelRevisions_Revisions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRevisions_Revisions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRevisions_Revisions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRevisions_Revisions.Name = "TabControlPanelRevisions_Revisions"
            Me.TabControlPanelRevisions_Revisions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRevisions_Revisions.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelRevisions_Revisions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRevisions_Revisions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRevisions_Revisions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRevisions_Revisions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRevisions_Revisions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRevisions_Revisions.Style.GradientAngle = 90
            Me.TabControlPanelRevisions_Revisions.TabIndex = 0
            Me.TabControlPanelRevisions_Revisions.TabItem = Me.TabItemTabs_Revisions
            '
            'DataGridViewRevision_Revisions
            '
            Me.DataGridViewRevision_Revisions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRevision_Revisions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRevision_Revisions.AutoUpdateViewCaption = True
            Me.DataGridViewRevision_Revisions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRevision_Revisions.ItemDescription = "Instruction(s)"
            Me.DataGridViewRevision_Revisions.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewRevision_Revisions.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRevision_Revisions.ModifyGridRowHeight = False
            Me.DataGridViewRevision_Revisions.MultiSelect = False
            Me.DataGridViewRevision_Revisions.Name = "DataGridViewRevision_Revisions"
            Me.DataGridViewRevision_Revisions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRevision_Revisions.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRevision_Revisions.ShowRowSelectionIfHidden = True
            Me.DataGridViewRevision_Revisions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRevision_Revisions.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewRevision_Revisions.TabIndex = 6
            Me.DataGridViewRevision_Revisions.UseEmbeddedNavigator = False
            Me.DataGridViewRevision_Revisions.ViewCaptionHeight = -1
            '
            'TabItemTabs_Revisions
            '
            Me.TabItemTabs_Revisions.AttachedControl = Me.TabControlPanelRevisions_Revisions
            Me.TabItemTabs_Revisions.Name = "TabItemTabs_Revisions"
            Me.TabItemTabs_Revisions.Text = "Instructions"
            '
            'TabControlPanelMissing_Instructions
            '
            Me.TabControlPanelMissing_Instructions.Controls.Add(Me.DataGridViewMTI_MissingTrafficInstructions)
            Me.TabControlPanelMissing_Instructions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMissing_Instructions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMissing_Instructions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMissing_Instructions.Name = "TabControlPanelMissing_Instructions"
            Me.TabControlPanelMissing_Instructions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMissing_Instructions.Size = New System.Drawing.Size(979, 395)
            Me.TabControlPanelMissing_Instructions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMissing_Instructions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMissing_Instructions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMissing_Instructions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMissing_Instructions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMissing_Instructions.Style.GradientAngle = 90
            Me.TabControlPanelMissing_Instructions.TabIndex = 90
            Me.TabControlPanelMissing_Instructions.TabItem = Me.TabItemTabs_MissingInstructions
            '
            'DataGridViewMTI_MissingTrafficInstructions
            '
            Me.DataGridViewMTI_MissingTrafficInstructions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMTI_MissingTrafficInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMTI_MissingTrafficInstructions.AutoUpdateViewCaption = True
            Me.DataGridViewMTI_MissingTrafficInstructions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMTI_MissingTrafficInstructions.ItemDescription = "Missing Traffic Instruction(s)"
            Me.DataGridViewMTI_MissingTrafficInstructions.Location = New System.Drawing.Point(9, 4)
            Me.DataGridViewMTI_MissingTrafficInstructions.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewMTI_MissingTrafficInstructions.ModifyGridRowHeight = False
            Me.DataGridViewMTI_MissingTrafficInstructions.MultiSelect = False
            Me.DataGridViewMTI_MissingTrafficInstructions.Name = "DataGridViewMTI_MissingTrafficInstructions"
            Me.DataGridViewMTI_MissingTrafficInstructions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMTI_MissingTrafficInstructions.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewMTI_MissingTrafficInstructions.ShowRowSelectionIfHidden = True
            Me.DataGridViewMTI_MissingTrafficInstructions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMTI_MissingTrafficInstructions.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewMTI_MissingTrafficInstructions.TabIndex = 7
            Me.DataGridViewMTI_MissingTrafficInstructions.UseEmbeddedNavigator = False
            Me.DataGridViewMTI_MissingTrafficInstructions.ViewCaptionHeight = -1
            '
            'TabItemTabs_MissingInstructions
            '
            Me.TabItemTabs_MissingInstructions.AttachedControl = Me.TabControlPanelMissing_Instructions
            Me.TabItemTabs_MissingInstructions.Name = "TabItemTabs_MissingInstructions"
            Me.TabItemTabs_MissingInstructions.Text = "Missing Traffic Instructions"
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
            Me.TabControlPanelVendors_Vendors.TabIndex = 55
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
            Me.DataGridViewVendors_Vendors.MultiSelect = False
            Me.DataGridViewVendors_Vendors.Name = "DataGridViewVendors_Vendors"
            Me.DataGridViewVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewVendors_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewVendors_Vendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendors_Vendors.Size = New System.Drawing.Size(961, 387)
            Me.DataGridViewVendors_Vendors.TabIndex = 11
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
            Me.RichEditGuidelines_Guidelines.TabIndex = 4
            Me.RichEditGuidelines_Guidelines.WordMLText = resources.GetString("RichEditGuidelines_Guidelines.WordMLText")
            '
            'TabItemTabs_Guidelines
            '
            Me.TabItemTabs_Guidelines.AttachedControl = Me.TabControlPanelGuidelines_Guidelines
            Me.TabItemTabs_Guidelines.Name = "TabItemTabs_Guidelines"
            Me.TabItemTabs_Guidelines.Text = "Guidelines"
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
            Me.RibbonBarFilePanel_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_CreativeGroups, Me.ButtonItemView_Responses})
            Me.RibbonBarFilePanel_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_View.Location = New System.Drawing.Point(623, 0)
            Me.RibbonBarFilePanel_View.Name = "RibbonBarFilePanel_View"
            Me.RibbonBarFilePanel_View.Size = New System.Drawing.Size(144, 92)
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
            'ButtonItemView_CreativeGroups
            '
            Me.ButtonItemView_CreativeGroups.AutoCheckOnClick = True
            Me.ButtonItemView_CreativeGroups.BeginGroup = True
            Me.ButtonItemView_CreativeGroups.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_CreativeGroups.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_CreativeGroups.Name = "ButtonItemView_CreativeGroups"
            Me.ButtonItemView_CreativeGroups.RibbonWordWrap = False
            Me.ButtonItemView_CreativeGroups.SecurityEnabled = True
            Me.ButtonItemView_CreativeGroups.Stretch = True
            Me.ButtonItemView_CreativeGroups.SubItemsExpandWidth = 14
            Me.ButtonItemView_CreativeGroups.Text = "Creative Groups"
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
            'RibbonBarFilePanel_Instruction
            '
            Me.RibbonBarFilePanel_Instruction.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_Instruction.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Instruction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Instruction.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Instruction.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Instruction.DragDropSupport = True
            Me.RibbonBarFilePanel_Instruction.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInstruction_Preview, Me.ButtonItemInstruction_Settings})
            Me.RibbonBarFilePanel_Instruction.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Instruction.Location = New System.Drawing.Point(767, 0)
            Me.RibbonBarFilePanel_Instruction.Name = "RibbonBarFilePanel_Instruction"
            Me.RibbonBarFilePanel_Instruction.SecurityEnabled = True
            Me.RibbonBarFilePanel_Instruction.Size = New System.Drawing.Size(95, 92)
            Me.RibbonBarFilePanel_Instruction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Instruction.TabIndex = 22
            Me.RibbonBarFilePanel_Instruction.Text = "Instruction"
            '
            '
            '
            Me.RibbonBarFilePanel_Instruction.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Instruction.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Instruction.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemInstruction_Preview
            '
            Me.ButtonItemInstruction_Preview.BeginGroup = True
            Me.ButtonItemInstruction_Preview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInstruction_Preview.Name = "ButtonItemInstruction_Preview"
            Me.ButtonItemInstruction_Preview.RibbonWordWrap = False
            Me.ButtonItemInstruction_Preview.SecurityEnabled = True
            Me.ButtonItemInstruction_Preview.SubItemsExpandWidth = 14
            Me.ButtonItemInstruction_Preview.Text = "Preview"
            '
            'ButtonItemInstruction_Settings
            '
            Me.ButtonItemInstruction_Settings.BeginGroup = True
            Me.ButtonItemInstruction_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInstruction_Settings.Name = "ButtonItemInstruction_Settings"
            Me.ButtonItemInstruction_Settings.RibbonWordWrap = False
            Me.ButtonItemInstruction_Settings.SecurityEnabled = True
            Me.ButtonItemInstruction_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemInstruction_Settings.Text = "Settings"
            '
            'RibbonBarFilePanel_Revisions
            '
            Me.RibbonBarFilePanel_Revisions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_Revisions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Revisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Revisions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Revisions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Revisions.DragDropSupport = True
            Me.RibbonBarFilePanel_Revisions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRevisions, Me.ItemContainerRevisions2})
            Me.RibbonBarFilePanel_Revisions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Revisions.Location = New System.Drawing.Point(515, 0)
            Me.RibbonBarFilePanel_Revisions.Name = "RibbonBarFilePanel_Revisions"
            Me.RibbonBarFilePanel_Revisions.SecurityEnabled = True
            Me.RibbonBarFilePanel_Revisions.Size = New System.Drawing.Size(108, 92)
            Me.RibbonBarFilePanel_Revisions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Revisions.TabIndex = 30
            Me.RibbonBarFilePanel_Revisions.Text = "Revisions"
            '
            '
            '
            Me.RibbonBarFilePanel_Revisions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Revisions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerRevisions
            '
            '
            '
            '
            Me.ItemContainerRevisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRevisions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerRevisions.Name = "ItemContainerRevisions"
            Me.ItemContainerRevisions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRevisions_Create, Me.ButtonItemRevisions_Delete})
            '
            '
            '
            Me.ItemContainerRevisions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRevisions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemRevisions_Create
            '
            Me.ButtonItemRevisions_Create.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRevisions_Create.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRevisions_Create.Name = "ButtonItemRevisions_Create"
            Me.ButtonItemRevisions_Create.RibbonWordWrap = False
            Me.ButtonItemRevisions_Create.SecurityEnabled = True
            Me.ButtonItemRevisions_Create.SubItemsExpandWidth = 14
            Me.ButtonItemRevisions_Create.Text = "Create"
            Me.ButtonItemRevisions_Create.Tooltip = "Create revision"
            '
            'ButtonItemRevisions_Delete
            '
            Me.ButtonItemRevisions_Delete.BeginGroup = True
            Me.ButtonItemRevisions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRevisions_Delete.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRevisions_Delete.Name = "ButtonItemRevisions_Delete"
            Me.ButtonItemRevisions_Delete.RibbonWordWrap = False
            Me.ButtonItemRevisions_Delete.SecurityEnabled = True
            Me.ButtonItemRevisions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemRevisions_Delete.Text = "Delete"
            Me.ButtonItemRevisions_Delete.Tooltip = "Delete revision"
            '
            'ItemContainerRevisions2
            '
            '
            '
            '
            Me.ItemContainerRevisions2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRevisions2.BeginGroup = True
            Me.ItemContainerRevisions2.Name = "ItemContainerRevisions2"
            Me.ItemContainerRevisions2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemRevisions_Revisions})
            '
            '
            '
            Me.ItemContainerRevisions2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRevisions2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemRevisions_Revisions
            '
            Me.ComboBoxItemRevisions_Revisions.ComboWidth = 45
            Me.ComboBoxItemRevisions_Revisions.DropDownHeight = 106
            Me.ComboBoxItemRevisions_Revisions.Name = "ComboBoxItemRevisions_Revisions"
            Me.ComboBoxItemRevisions_Revisions.Text = "ComboBoxItem1"
            Me.ComboBoxItemRevisions_Revisions.Tooltip = "Select to view revision"
            Me.ComboBoxItemRevisions_Revisions.Visible = False
            '
            'RibbonBarFilePanel_Documents
            '
            Me.RibbonBarFilePanel_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFilePanel_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Documents.DragDropSupport = True
            Me.RibbonBarFilePanel_Documents.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
            Me.RibbonBarFilePanel_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Documents.Location = New System.Drawing.Point(862, 0)
            Me.RibbonBarFilePanel_Documents.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarFilePanel_Documents.Name = "RibbonBarFilePanel_Documents"
            Me.RibbonBarFilePanel_Documents.SecurityEnabled = True
            Me.RibbonBarFilePanel_Documents.Size = New System.Drawing.Size(65, 92)
            Me.RibbonBarFilePanel_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Documents.TabIndex = 46
            Me.RibbonBarFilePanel_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarFilePanel_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
            'RibbonBarFilePanel_Creative
            '
            Me.RibbonBarFilePanel_Creative.AutoOverflowEnabled = False
            Me.RibbonBarFilePanel_Creative.AutoSizeIncludesTitle = True
            '
            '
            '
            Me.RibbonBarFilePanel_Creative.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Creative.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Creative.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Creative.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Creative.DragDropSupport = True
            Me.RibbonBarFilePanel_Creative.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEdit_AdNumbers})
            Me.RibbonBarFilePanel_Creative.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Creative.Location = New System.Drawing.Point(448, 0)
            Me.RibbonBarFilePanel_Creative.Name = "RibbonBarFilePanel_Creative"
            Me.RibbonBarFilePanel_Creative.SecurityEnabled = True
            Me.RibbonBarFilePanel_Creative.Size = New System.Drawing.Size(67, 92)
            Me.RibbonBarFilePanel_Creative.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Creative.TabIndex = 47
            Me.RibbonBarFilePanel_Creative.Text = "Creative"
            '
            '
            '
            Me.RibbonBarFilePanel_Creative.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Creative.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Creative.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEdit_AdNumbers
            '
            Me.ButtonItemEdit_AdNumbers.BeginGroup = True
            Me.ButtonItemEdit_AdNumbers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEdit_AdNumbers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEdit_AdNumbers.Name = "ButtonItemEdit_AdNumbers"
            Me.ButtonItemEdit_AdNumbers.RibbonWordWrap = False
            Me.ButtonItemEdit_AdNumbers.SecurityEnabled = True
            Me.ButtonItemEdit_AdNumbers.SubItemsExpandWidth = 14
            Me.ButtonItemEdit_AdNumbers.Text = "Ad Numbers"
            Me.ButtonItemEdit_AdNumbers.Tooltip = "Add or Edit Ad Numbers and Creative"
            '
            'MediaTrafficDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(995, 609)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTrafficDialog"
            Me.Text = "Media Traffic"
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
            Me.TabControlPanelCreativeGroups_CreativeGroups.ResumeLayout(False)
            Me.TabControlPanelDetails_Details.ResumeLayout(False)
            Me.TabControlPanelDocument_Documents.ResumeLayout(False)
            Me.TabControlPanelRevisions_Revisions.ResumeLayout(False)
            Me.TabControlPanelMissing_Instructions.ResumeLayout(False)
            Me.TabControlPanelVendors_Vendors.ResumeLayout(False)
            Me.TabControlPanelGuidelines_Guidelines.ResumeLayout(False)
            Me.TabControlPanelStatus_Status.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents TabControlPanel_Tabs As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelRevisions_Revisions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Revisions As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelStatus_Status As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Status As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewStatus_Statuses As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelGuidelines_Guidelines As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Guidelines As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_Generate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Default As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_View As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemView_Responses As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelDetails_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewDetails_Details As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Details As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewRevision_Revisions As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AddBookend As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelDetails_CreativeGroup As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabControlPanelVendors_Vendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewVendors_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_Vendors As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCreativeGroups_CreativeGroups As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_CreativeGroups As DevComponents.DotNetBar.TabItem
        Friend WithEvents RichEditGuidelines_Guidelines As WinForm.Presentation.Controls.RichEditControl
        Friend WithEvents LabelCreativeGroups_TrafficStartEndDescription As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewCreativeGroup_CreativeGroups As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemView_CreativeGroups As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Instruction As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInstruction_Preview As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Revisions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerRevisions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemRevisions_Create As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRevisions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerRevisions2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemRevisions_Revisions As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents TabControlPanelDocument_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Documents As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_DetailDocuments As WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents RibbonBarFilePanel_Documents As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerVerticalOptions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemActions_AddToAllVendors As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_RemoveFromAllVendors As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInstruction_Settings As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelDocuments_CreativeGroupTitle As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabControlPanelMissing_Instructions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_MissingInstructions As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewMTI_MissingTrafficInstructions As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_CopyTo As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Creative As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEdit_AdNumbers As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace