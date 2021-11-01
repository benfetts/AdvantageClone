Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientEditDialog))
            Me.ClientControlForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ClientControl()
            Me.RibbonBarOptions_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContracts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContacts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_SortKeys = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSortKeys_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSortKeys_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemText_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Website = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemWebsite_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemWebsite_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonTabItemMainRibbon_DivisionProduct = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBarDivisionProduct_Product = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProduct_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarDivisionProduct_Division = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDivision_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDivision_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonPanel1.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.ClientControlForm_Client)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(968, 499)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanel1)
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home, Me.RibbonTabItemMainRibbon_DivisionProduct})
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(968, 154)
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
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanel1, 0)
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Contracts)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Contacts)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SortKeys)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Text)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Website)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(968, 95)
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
            Me.RibbonPanelFile_FilePanel.Visible = True
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Website, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Text, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SortKeys, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Contacts, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Contracts, 0)
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
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(10, 91)
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
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 2
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 654)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(2)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(968, 18)
            '
            'ClientControlForm_Client
            '
            Me.ClientControlForm_Client.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientControlForm_Client.Location = New System.Drawing.Point(5, 5)
            Me.ClientControlForm_Client.Margin = New System.Windows.Forms.Padding(5)
            Me.ClientControlForm_Client.Name = "ClientControlForm_Client"
            Me.ClientControlForm_Client.Size = New System.Drawing.Size(958, 487)
            Me.ClientControlForm_Client.TabIndex = 0
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
            Me.RibbonBarOptions_Contracts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContracts_Add, Me.ButtonItemContracts_Edit, Me.ButtonItemContracts_Delete, Me.ButtonItemContracts_Copy})
            Me.RibbonBarOptions_Contracts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Contracts.Location = New System.Drawing.Point(802, 0)
            Me.RibbonBarOptions_Contracts.Name = "RibbonBarOptions_Contracts"
            Me.RibbonBarOptions_Contracts.SecurityEnabled = True
            Me.RibbonBarOptions_Contracts.Size = New System.Drawing.Size(142, 91)
            Me.RibbonBarOptions_Contracts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contracts.TabIndex = 15
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
            Me.RibbonBarOptions_Contacts.Location = New System.Drawing.Point(695, 0)
            Me.RibbonBarOptions_Contacts.Name = "RibbonBarOptions_Contacts"
            Me.RibbonBarOptions_Contacts.SecurityEnabled = True
            Me.RibbonBarOptions_Contacts.Size = New System.Drawing.Size(107, 91)
            Me.RibbonBarOptions_Contacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contacts.TabIndex = 14
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
            'RibbonBarOptions_SortKeys
            '
            Me.RibbonBarOptions_SortKeys.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SortKeys.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SortKeys.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SortKeys.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SortKeys.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SortKeys.DragDropSupport = True
            Me.RibbonBarOptions_SortKeys.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSortKeys_Delete, Me.ButtonItemSortKeys_Cancel})
            Me.RibbonBarOptions_SortKeys.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SortKeys.Location = New System.Drawing.Point(602, 0)
            Me.RibbonBarOptions_SortKeys.Name = "RibbonBarOptions_SortKeys"
            Me.RibbonBarOptions_SortKeys.SecurityEnabled = True
            Me.RibbonBarOptions_SortKeys.Size = New System.Drawing.Size(93, 91)
            Me.RibbonBarOptions_SortKeys.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SortKeys.TabIndex = 13
            Me.RibbonBarOptions_SortKeys.Text = "Sort Keys"
            '
            '
            '
            Me.RibbonBarOptions_SortKeys.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SortKeys.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SortKeys.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_SortKeys.Visible = False
            '
            'ButtonItemSortKeys_Delete
            '
            Me.ButtonItemSortKeys_Delete.BeginGroup = True
            Me.ButtonItemSortKeys_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSortKeys_Delete.Name = "ButtonItemSortKeys_Delete"
            Me.ButtonItemSortKeys_Delete.RibbonWordWrap = False
            Me.ButtonItemSortKeys_Delete.SecurityEnabled = True
            Me.ButtonItemSortKeys_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemSortKeys_Delete.Text = "Delete"
            '
            'ButtonItemSortKeys_Cancel
            '
            Me.ButtonItemSortKeys_Cancel.BeginGroup = True
            Me.ButtonItemSortKeys_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSortKeys_Cancel.Name = "ButtonItemSortKeys_Cancel"
            Me.ButtonItemSortKeys_Cancel.RibbonWordWrap = False
            Me.ButtonItemSortKeys_Cancel.SecurityEnabled = True
            Me.ButtonItemSortKeys_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemSortKeys_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(511, 0)
            Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
            Me.RibbonBarOptions_Text.SecurityEnabled = True
            Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(91, 91)
            Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Text.TabIndex = 12
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
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(299, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(212, 91)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 11
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
            'RibbonBarOptions_Website
            '
            Me.RibbonBarOptions_Website.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Website.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Website.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Website.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Website.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Website.DragDropSupport = True
            Me.RibbonBarOptions_Website.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemWebsite_Delete, Me.ButtonItemWebsite_Cancel})
            Me.RibbonBarOptions_Website.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Website.Location = New System.Drawing.Point(206, 0)
            Me.RibbonBarOptions_Website.Name = "RibbonBarOptions_Website"
            Me.RibbonBarOptions_Website.SecurityEnabled = True
            Me.RibbonBarOptions_Website.Size = New System.Drawing.Size(93, 91)
            Me.RibbonBarOptions_Website.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Website.TabIndex = 10
            Me.RibbonBarOptions_Website.Text = "Website"
            '
            '
            '
            Me.RibbonBarOptions_Website.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Website.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Website.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemWebsite_Delete
            '
            Me.ButtonItemWebsite_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWebsite_Delete.Name = "ButtonItemWebsite_Delete"
            Me.ButtonItemWebsite_Delete.RibbonWordWrap = False
            Me.ButtonItemWebsite_Delete.SecurityEnabled = True
            Me.ButtonItemWebsite_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemWebsite_Delete.Text = "Delete"
            '
            'ButtonItemWebsite_Cancel
            '
            Me.ButtonItemWebsite_Cancel.BeginGroup = True
            Me.ButtonItemWebsite_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWebsite_Cancel.Name = "ButtonItemWebsite_Cancel"
            Me.ButtonItemWebsite_Cancel.RibbonWordWrap = False
            Me.ButtonItemWebsite_Cancel.SecurityEnabled = True
            Me.ButtonItemWebsite_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemWebsite_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(14, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(192, 91)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 9
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
            'RibbonTabItemMainRibbon_DivisionProduct
            '
            Me.RibbonTabItemMainRibbon_DivisionProduct.Name = "RibbonTabItemMainRibbon_DivisionProduct"
            Me.RibbonTabItemMainRibbon_DivisionProduct.Panel = Me.RibbonPanel1
            Me.RibbonTabItemMainRibbon_DivisionProduct.Text = "Division / Product"
            '
            'RibbonPanel1
            '
            Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel1.Controls.Add(Me.RibbonBarDivisionProduct_Product)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBarDivisionProduct_Division)
            Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RibbonPanel1.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanel1.Name = "RibbonPanel1"
            Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.RibbonPanel1.Size = New System.Drawing.Size(767, 95)
            '
            '
            '
            Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanel1.TabIndex = 2
            Me.RibbonPanel1.Visible = False
            '
            'RibbonBarDivisionProduct_Product
            '
            Me.RibbonBarDivisionProduct_Product.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarDivisionProduct_Product.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDivisionProduct_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDivisionProduct_Product.ContainerControlProcessDialogKey = True
            Me.RibbonBarDivisionProduct_Product.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarDivisionProduct_Product.DragDropSupport = True
            Me.RibbonBarDivisionProduct_Product.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProduct_Add, Me.ButtonItemProduct_CopyFrom, Me.ButtonItemProduct_CopyTo, Me.ButtonItemProduct_Edit, Me.ButtonItemProduct_Delete, Me.ButtonItemProduct_Print, Me.ButtonItemProduct_PrintFiltered})
            Me.RibbonBarDivisionProduct_Product.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarDivisionProduct_Product.Location = New System.Drawing.Point(342, 0)
            Me.RibbonBarDivisionProduct_Product.Name = "RibbonBarDivisionProduct_Product"
            Me.RibbonBarDivisionProduct_Product.SecurityEnabled = True
            Me.RibbonBarDivisionProduct_Product.Size = New System.Drawing.Size(332, 92)
            Me.RibbonBarDivisionProduct_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarDivisionProduct_Product.TabIndex = 4
            Me.RibbonBarDivisionProduct_Product.Text = "Product"
            '
            '
            '
            Me.RibbonBarDivisionProduct_Product.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDivisionProduct_Product.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDivisionProduct_Product.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemProduct_Add
            '
            Me.ButtonItemProduct_Add.BeginGroup = True
            Me.ButtonItemProduct_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Add.Name = "ButtonItemProduct_Add"
            Me.ButtonItemProduct_Add.RibbonWordWrap = False
            Me.ButtonItemProduct_Add.SecurityEnabled = True
            Me.ButtonItemProduct_Add.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Add.Text = "Add"
            '
            'ButtonItemProduct_CopyFrom
            '
            Me.ButtonItemProduct_CopyFrom.BeginGroup = True
            Me.ButtonItemProduct_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_CopyFrom.Name = "ButtonItemProduct_CopyFrom"
            Me.ButtonItemProduct_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemProduct_CopyFrom.SecurityEnabled = True
            Me.ButtonItemProduct_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_CopyFrom.Text = "Copy From"
            '
            'ButtonItemProduct_CopyTo
            '
            Me.ButtonItemProduct_CopyTo.BeginGroup = True
            Me.ButtonItemProduct_CopyTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_CopyTo.Name = "ButtonItemProduct_CopyTo"
            Me.ButtonItemProduct_CopyTo.RibbonWordWrap = False
            Me.ButtonItemProduct_CopyTo.SecurityEnabled = True
            Me.ButtonItemProduct_CopyTo.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_CopyTo.Text = "Copy To"
            '
            'ButtonItemProduct_Edit
            '
            Me.ButtonItemProduct_Edit.BeginGroup = True
            Me.ButtonItemProduct_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Edit.Name = "ButtonItemProduct_Edit"
            Me.ButtonItemProduct_Edit.RibbonWordWrap = False
            Me.ButtonItemProduct_Edit.SecurityEnabled = True
            Me.ButtonItemProduct_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Edit.Text = "Edit"
            '
            'ButtonItemProduct_Delete
            '
            Me.ButtonItemProduct_Delete.BeginGroup = True
            Me.ButtonItemProduct_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Delete.Name = "ButtonItemProduct_Delete"
            Me.ButtonItemProduct_Delete.RibbonWordWrap = False
            Me.ButtonItemProduct_Delete.SecurityEnabled = True
            Me.ButtonItemProduct_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Delete.Text = "Delete"
            '
            'ButtonItemProduct_Print
            '
            Me.ButtonItemProduct_Print.BeginGroup = True
            Me.ButtonItemProduct_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Print.Name = "ButtonItemProduct_Print"
            Me.ButtonItemProduct_Print.RibbonWordWrap = False
            Me.ButtonItemProduct_Print.SecurityEnabled = True
            Me.ButtonItemProduct_Print.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Print.Text = "Print"
            '
            'ButtonItemProduct_PrintFiltered
            '
            Me.ButtonItemProduct_PrintFiltered.BeginGroup = True
            Me.ButtonItemProduct_PrintFiltered.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_PrintFiltered.Name = "ButtonItemProduct_PrintFiltered"
            Me.ButtonItemProduct_PrintFiltered.RibbonWordWrap = False
            Me.ButtonItemProduct_PrintFiltered.SecurityEnabled = True
            Me.ButtonItemProduct_PrintFiltered.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_PrintFiltered.Text = "Print Filtered"
            '
            'RibbonBarDivisionProduct_Division
            '
            Me.RibbonBarDivisionProduct_Division.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarDivisionProduct_Division.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDivisionProduct_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDivisionProduct_Division.ContainerControlProcessDialogKey = True
            Me.RibbonBarDivisionProduct_Division.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarDivisionProduct_Division.DragDropSupport = True
            Me.RibbonBarDivisionProduct_Division.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDivision_Add, Me.ButtonItemDivision_CopyFrom, Me.ButtonItemDivision_CopyTo, Me.ButtonItemDivision_Edit, Me.ButtonItemDivision_Delete, Me.ButtonItemDivision_Print, Me.ButtonItemDivision_PrintFiltered})
            Me.RibbonBarDivisionProduct_Division.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarDivisionProduct_Division.Location = New System.Drawing.Point(3, 0)
            Me.RibbonBarDivisionProduct_Division.Name = "RibbonBarDivisionProduct_Division"
            Me.RibbonBarDivisionProduct_Division.SecurityEnabled = True
            Me.RibbonBarDivisionProduct_Division.Size = New System.Drawing.Size(339, 92)
            Me.RibbonBarDivisionProduct_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarDivisionProduct_Division.TabIndex = 3
            Me.RibbonBarDivisionProduct_Division.Text = "Division"
            '
            '
            '
            Me.RibbonBarDivisionProduct_Division.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarDivisionProduct_Division.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarDivisionProduct_Division.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDivision_Add
            '
            Me.ButtonItemDivision_Add.BeginGroup = True
            Me.ButtonItemDivision_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_Add.Name = "ButtonItemDivision_Add"
            Me.ButtonItemDivision_Add.RibbonWordWrap = False
            Me.ButtonItemDivision_Add.SecurityEnabled = True
            Me.ButtonItemDivision_Add.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_Add.Text = "Add"
            '
            'ButtonItemDivision_CopyFrom
            '
            Me.ButtonItemDivision_CopyFrom.BeginGroup = True
            Me.ButtonItemDivision_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_CopyFrom.Name = "ButtonItemDivision_CopyFrom"
            Me.ButtonItemDivision_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemDivision_CopyFrom.SecurityEnabled = True
            Me.ButtonItemDivision_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_CopyFrom.Text = "Copy From"
            '
            'ButtonItemDivision_CopyTo
            '
            Me.ButtonItemDivision_CopyTo.BeginGroup = True
            Me.ButtonItemDivision_CopyTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_CopyTo.Name = "ButtonItemDivision_CopyTo"
            Me.ButtonItemDivision_CopyTo.RibbonWordWrap = False
            Me.ButtonItemDivision_CopyTo.SecurityEnabled = True
            Me.ButtonItemDivision_CopyTo.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_CopyTo.Text = "Copy To"
            '
            'ButtonItemDivision_Edit
            '
            Me.ButtonItemDivision_Edit.BeginGroup = True
            Me.ButtonItemDivision_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_Edit.Name = "ButtonItemDivision_Edit"
            Me.ButtonItemDivision_Edit.RibbonWordWrap = False
            Me.ButtonItemDivision_Edit.SecurityEnabled = True
            Me.ButtonItemDivision_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_Edit.Text = "Edit"
            '
            'ButtonItemDivision_Delete
            '
            Me.ButtonItemDivision_Delete.BeginGroup = True
            Me.ButtonItemDivision_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_Delete.Name = "ButtonItemDivision_Delete"
            Me.ButtonItemDivision_Delete.RibbonWordWrap = False
            Me.ButtonItemDivision_Delete.SecurityEnabled = True
            Me.ButtonItemDivision_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_Delete.Text = "Delete"
            '
            'ButtonItemDivision_Print
            '
            Me.ButtonItemDivision_Print.BeginGroup = True
            Me.ButtonItemDivision_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_Print.Name = "ButtonItemDivision_Print"
            Me.ButtonItemDivision_Print.RibbonWordWrap = False
            Me.ButtonItemDivision_Print.SecurityEnabled = True
            Me.ButtonItemDivision_Print.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_Print.Text = "Print"
            '
            'ButtonItemDivision_PrintFiltered
            '
            Me.ButtonItemDivision_PrintFiltered.BeginGroup = True
            Me.ButtonItemDivision_PrintFiltered.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_PrintFiltered.Name = "ButtonItemDivision_PrintFiltered"
            Me.ButtonItemDivision_PrintFiltered.RibbonWordWrap = False
            Me.ButtonItemDivision_PrintFiltered.SecurityEnabled = True
            Me.ButtonItemDivision_PrintFiltered.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_PrintFiltered.Text = "Print Filtered"
            '
            'ClientEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(978, 674)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "ClientEditDialog"
            Me.Text = "Client"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ClientControlForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ClientControl
        Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonTabItemMainRibbon_DivisionProduct As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonBarOptions_Contracts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContracts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Contacts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContacts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_SortKeys As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSortKeys_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSortKeys_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Website As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemWebsite_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemWebsite_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarDivisionProduct_Product As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProduct_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarDivisionProduct_Division As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDivision_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDivision_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace