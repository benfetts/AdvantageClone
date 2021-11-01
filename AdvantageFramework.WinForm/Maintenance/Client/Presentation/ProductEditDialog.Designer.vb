Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductEditDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductEditDialog))
			Me.ProductControlForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ProductControl()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Affiliations = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemAffiliations_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemAffiliations_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_SortOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemSortOptions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemSortOptions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemContacts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContacts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemContracts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContracts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContracts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContracts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Competitors = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemCompetitors_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemCompetitors_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Diary = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDiary_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDiary_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemText_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_MediaOverrides = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemMediaOverrides_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_Form.SuspendLayout()
			Me.RibbonControlForm_MainRibbon.SuspendLayout()
			Me.RibbonPanelFile_FilePanel.SuspendLayout()
			CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
			Me.PanelForm_Form.Controls.Add(Me.ProductControlForm_Product)
			Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
			Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
			Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
			'
			'RibbonControlForm_MainRibbon
			'
			'
			'
			'
			Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
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
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_MediaOverrides)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Text)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Diary)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Competitors)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarMergeContainerForm_Contracts)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Contacts)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Affiliations)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SortOptions)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarMergeContainerForm_Documents)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
			Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
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
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarMergeContainerForm_Documents, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SortOptions, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Affiliations, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Contacts, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarMergeContainerForm_Contracts, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Competitors, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Diary, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Text, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_MediaOverrides, 0)
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
			Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
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
			'Office2007StartButtonMainRibbon_Home
			'
			Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
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
			Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
			Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
			'
			'ProductControlForm_Product
			'
			Me.ProductControlForm_Product.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ProductControlForm_Product.Location = New System.Drawing.Point(3, 6)
			Me.ProductControlForm_Product.Name = "ProductControlForm_Product"
			Me.ProductControlForm_Product.Size = New System.Drawing.Size(976, 543)
			Me.ProductControlForm_Product.TabIndex = 3
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(194, 92)
			Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Actions.TabIndex = 12
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
			'ButtonItemActions_Cancel
			'
			Me.ButtonItemActions_Cancel.BeginGroup = True
			Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
			Me.ButtonItemActions_Cancel.RibbonWordWrap = False
			Me.ButtonItemActions_Cancel.SecurityEnabled = True
			Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Cancel.Text = "Cancel"
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
			'ButtonItemActions_Copy
			'
			Me.ButtonItemActions_Copy.BeginGroup = True
			Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
			Me.ButtonItemActions_Copy.RibbonWordWrap = False
			Me.ButtonItemActions_Copy.SecurityEnabled = True
			Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Copy.Text = "Copy"
			'
			'RibbonBarOptions_Affiliations
			'
			Me.RibbonBarOptions_Affiliations.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Affiliations.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Affiliations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Affiliations.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Affiliations.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Affiliations.DragDropSupport = True
			Me.RibbonBarOptions_Affiliations.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAffiliations_Delete, Me.ButtonItemAffiliations_Cancel})
			Me.RibbonBarOptions_Affiliations.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Affiliations.Location = New System.Drawing.Point(420, 0)
			Me.RibbonBarOptions_Affiliations.Name = "RibbonBarOptions_Affiliations"
			Me.RibbonBarOptions_Affiliations.SecurityEnabled = True
			Me.RibbonBarOptions_Affiliations.Size = New System.Drawing.Size(70, 92)
			Me.RibbonBarOptions_Affiliations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Affiliations.TabIndex = 15
			Me.RibbonBarOptions_Affiliations.Text = "Affiliations"
			'
			'
			'
			Me.RibbonBarOptions_Affiliations.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Affiliations.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Affiliations.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemAffiliations_Delete
			'
			Me.ButtonItemAffiliations_Delete.BeginGroup = True
			Me.ButtonItemAffiliations_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemAffiliations_Delete.Name = "ButtonItemAffiliations_Delete"
			Me.ButtonItemAffiliations_Delete.RibbonWordWrap = False
			Me.ButtonItemAffiliations_Delete.SecurityEnabled = True
			Me.ButtonItemAffiliations_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemAffiliations_Delete.Text = "Delete"
			'
			'ButtonItemAffiliations_Cancel
			'
			Me.ButtonItemAffiliations_Cancel.BeginGroup = True
			Me.ButtonItemAffiliations_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemAffiliations_Cancel.Name = "ButtonItemAffiliations_Cancel"
			Me.ButtonItemAffiliations_Cancel.RibbonWordWrap = False
			Me.ButtonItemAffiliations_Cancel.SecurityEnabled = True
			Me.ButtonItemAffiliations_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemAffiliations_Cancel.Text = "Cancel"
			'
			'RibbonBarOptions_SortOptions
			'
			Me.RibbonBarOptions_SortOptions.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_SortOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_SortOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_SortOptions.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_SortOptions.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_SortOptions.DragDropSupport = True
			Me.RibbonBarOptions_SortOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSortOptions_Delete, Me.ButtonItemSortOptions_Cancel})
			Me.RibbonBarOptions_SortOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_SortOptions.Location = New System.Drawing.Point(350, 0)
			Me.RibbonBarOptions_SortOptions.Name = "RibbonBarOptions_SortOptions"
			Me.RibbonBarOptions_SortOptions.SecurityEnabled = True
			Me.RibbonBarOptions_SortOptions.Size = New System.Drawing.Size(70, 92)
			Me.RibbonBarOptions_SortOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_SortOptions.TabIndex = 14
			Me.RibbonBarOptions_SortOptions.Text = "Sort Options"
			'
			'
			'
			Me.RibbonBarOptions_SortOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_SortOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_SortOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemSortOptions_Delete
			'
			Me.ButtonItemSortOptions_Delete.BeginGroup = True
			Me.ButtonItemSortOptions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSortOptions_Delete.Name = "ButtonItemSortOptions_Delete"
			Me.ButtonItemSortOptions_Delete.RibbonWordWrap = False
			Me.ButtonItemSortOptions_Delete.SecurityEnabled = True
			Me.ButtonItemSortOptions_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemSortOptions_Delete.Text = "Delete"
			'
			'ButtonItemSortOptions_Cancel
			'
			Me.ButtonItemSortOptions_Cancel.BeginGroup = True
			Me.ButtonItemSortOptions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSortOptions_Cancel.Name = "ButtonItemSortOptions_Cancel"
			Me.ButtonItemSortOptions_Cancel.RibbonWordWrap = False
			Me.ButtonItemSortOptions_Cancel.SecurityEnabled = True
			Me.ButtonItemSortOptions_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemSortOptions_Cancel.Text = "Cancel"
			'
			'RibbonBarMergeContainerForm_Documents
			'
			Me.RibbonBarMergeContainerForm_Documents.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_Documents.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_Documents.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_Documents.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
			Me.RibbonBarMergeContainerForm_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_Documents.Location = New System.Drawing.Point(249, 0)
			Me.RibbonBarMergeContainerForm_Documents.Name = "RibbonBarMergeContainerForm_Documents"
			Me.RibbonBarMergeContainerForm_Documents.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_Documents.Size = New System.Drawing.Size(101, 92)
			Me.RibbonBarMergeContainerForm_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Documents.TabIndex = 13
			Me.RibbonBarMergeContainerForm_Documents.Text = "Documents"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
			Me.RibbonBarOptions_Contacts.Location = New System.Drawing.Point(490, 0)
			Me.RibbonBarOptions_Contacts.Name = "RibbonBarOptions_Contacts"
			Me.RibbonBarOptions_Contacts.SecurityEnabled = True
			Me.RibbonBarOptions_Contacts.Size = New System.Drawing.Size(131, 92)
			Me.RibbonBarOptions_Contacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Contacts.TabIndex = 16
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
			'RibbonBarMergeContainerForm_Contracts
			'
			Me.RibbonBarMergeContainerForm_Contracts.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Contracts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Contracts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_Contracts.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_Contracts.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_Contracts.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_Contracts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContracts_Add, Me.ButtonItemContracts_Copy, Me.ButtonItemContracts_Edit, Me.ButtonItemContracts_Delete})
			Me.RibbonBarMergeContainerForm_Contracts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_Contracts.Location = New System.Drawing.Point(621, 0)
			Me.RibbonBarMergeContainerForm_Contracts.Name = "RibbonBarMergeContainerForm_Contracts"
			Me.RibbonBarMergeContainerForm_Contracts.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_Contracts.Size = New System.Drawing.Size(83, 92)
			Me.RibbonBarMergeContainerForm_Contracts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Contracts.TabIndex = 17
			Me.RibbonBarMergeContainerForm_Contracts.Text = "Contracts"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Contracts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Contracts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_Contracts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
			'RibbonBarOptions_Competitors
			'
			Me.RibbonBarOptions_Competitors.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Competitors.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Competitors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Competitors.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Competitors.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Competitors.DragDropSupport = True
			Me.RibbonBarOptions_Competitors.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCompetitors_Delete, Me.ButtonItemCompetitors_Cancel})
			Me.RibbonBarOptions_Competitors.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Competitors.Location = New System.Drawing.Point(704, 0)
			Me.RibbonBarOptions_Competitors.Name = "RibbonBarOptions_Competitors"
			Me.RibbonBarOptions_Competitors.SecurityEnabled = True
			Me.RibbonBarOptions_Competitors.Size = New System.Drawing.Size(70, 92)
			Me.RibbonBarOptions_Competitors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Competitors.TabIndex = 18
			Me.RibbonBarOptions_Competitors.Text = "Competitors"
			'
			'
			'
			Me.RibbonBarOptions_Competitors.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Competitors.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Competitors.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemCompetitors_Delete
			'
			Me.ButtonItemCompetitors_Delete.BeginGroup = True
			Me.ButtonItemCompetitors_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemCompetitors_Delete.Name = "ButtonItemCompetitors_Delete"
			Me.ButtonItemCompetitors_Delete.RibbonWordWrap = False
			Me.ButtonItemCompetitors_Delete.SecurityEnabled = True
			Me.ButtonItemCompetitors_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemCompetitors_Delete.Text = "Delete"
			'
			'ButtonItemCompetitors_Cancel
			'
			Me.ButtonItemCompetitors_Cancel.BeginGroup = True
			Me.ButtonItemCompetitors_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemCompetitors_Cancel.Name = "ButtonItemCompetitors_Cancel"
			Me.ButtonItemCompetitors_Cancel.RibbonWordWrap = False
			Me.ButtonItemCompetitors_Cancel.SecurityEnabled = True
			Me.ButtonItemCompetitors_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemCompetitors_Cancel.Text = "Cancel"
			'
			'RibbonBarOptions_Diary
			'
			Me.RibbonBarOptions_Diary.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Diary.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Diary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Diary.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Diary.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Diary.DragDropSupport = True
			Me.RibbonBarOptions_Diary.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDiary_Add, Me.ButtonItemDiary_Edit})
			Me.RibbonBarOptions_Diary.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Diary.Location = New System.Drawing.Point(774, 0)
			Me.RibbonBarOptions_Diary.Name = "RibbonBarOptions_Diary"
			Me.RibbonBarOptions_Diary.SecurityEnabled = True
			Me.RibbonBarOptions_Diary.Size = New System.Drawing.Size(70, 92)
			Me.RibbonBarOptions_Diary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Diary.TabIndex = 19
			Me.RibbonBarOptions_Diary.Text = "Diary"
			'
			'
			'
			Me.RibbonBarOptions_Diary.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Diary.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Diary.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemDiary_Add
			'
			Me.ButtonItemDiary_Add.BeginGroup = True
			Me.ButtonItemDiary_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDiary_Add.Name = "ButtonItemDiary_Add"
			Me.ButtonItemDiary_Add.RibbonWordWrap = False
			Me.ButtonItemDiary_Add.SecurityEnabled = True
			Me.ButtonItemDiary_Add.SubItemsExpandWidth = 14
			Me.ButtonItemDiary_Add.Text = "Add"
			'
			'ButtonItemDiary_Edit
			'
			Me.ButtonItemDiary_Edit.BeginGroup = True
			Me.ButtonItemDiary_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDiary_Edit.Name = "ButtonItemDiary_Edit"
			Me.ButtonItemDiary_Edit.RibbonWordWrap = False
			Me.ButtonItemDiary_Edit.SecurityEnabled = True
			Me.ButtonItemDiary_Edit.SubItemsExpandWidth = 14
			Me.ButtonItemDiary_Edit.Text = "Edit"
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
			Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(844, 0)
			Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
			Me.RibbonBarOptions_Text.SecurityEnabled = True
			Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(48, 92)
			Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Text.TabIndex = 20
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
			Me.ButtonItemText_CheckSpelling.SecurityEnabled = True
			Me.ButtonItemText_CheckSpelling.SubItemsExpandWidth = 14
			Me.ButtonItemText_CheckSpelling.Text = "Check Spelling"
			'
			'RibbonBarOptions_MediaOverrides
			'
			Me.RibbonBarOptions_MediaOverrides.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_MediaOverrides.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_MediaOverrides.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_MediaOverrides.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_MediaOverrides.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_MediaOverrides.DragDropSupport = True
			Me.RibbonBarOptions_MediaOverrides.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
			Me.RibbonBarOptions_MediaOverrides.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaOverrides_Edit})
			Me.RibbonBarOptions_MediaOverrides.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_MediaOverrides.Location = New System.Drawing.Point(892, 0)
			Me.RibbonBarOptions_MediaOverrides.MinimumSize = New System.Drawing.Size(90, 0)
			Me.RibbonBarOptions_MediaOverrides.Name = "RibbonBarOptions_MediaOverrides"
			Me.RibbonBarOptions_MediaOverrides.SecurityEnabled = True
			Me.RibbonBarOptions_MediaOverrides.Size = New System.Drawing.Size(90, 92)
			Me.RibbonBarOptions_MediaOverrides.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_MediaOverrides.TabIndex = 21
			Me.RibbonBarOptions_MediaOverrides.Text = "Media Overrides"
			'
			'
			'
			Me.RibbonBarOptions_MediaOverrides.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_MediaOverrides.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_MediaOverrides.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			Me.RibbonBarOptions_MediaOverrides.Visible = False
			'
			'ButtonItemMediaOverrides_Edit
			'
			Me.ButtonItemMediaOverrides_Edit.BeginGroup = True
			Me.ButtonItemMediaOverrides_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemMediaOverrides_Edit.Name = "ButtonItemMediaOverrides_Edit"
			Me.ButtonItemMediaOverrides_Edit.RibbonWordWrap = False
			Me.ButtonItemMediaOverrides_Edit.SecurityEnabled = True
			Me.ButtonItemMediaOverrides_Edit.SubItemsExpandWidth = 14
			Me.ButtonItemMediaOverrides_Edit.Text = "Edit"
			'
			'ButtonItemUpload_EmailLink
			'
			Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
			Me.ButtonItemUpload_EmailLink.Text = "Email Link"
			'
			'ProductEditDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.ClientSize = New System.Drawing.Size(992, 730)
			Me.CloseButtonVisible = False
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "ProductEditDialog"
			Me.Text = "Product"
			Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
			Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
			Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
			CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_Form.ResumeLayout(False)
			Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
			Me.RibbonControlForm_MainRibbon.PerformLayout()
			Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
			CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents ProductControlForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ProductControl
        Friend WithEvents RibbonBarOptions_Affiliations As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemAffiliations_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAffiliations_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_SortOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSortOptions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSortOptions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Contacts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContacts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Contracts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContracts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Competitors As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCompetitors_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCompetitors_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Diary As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDiary_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDiary_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_MediaOverrides As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaOverrides_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace