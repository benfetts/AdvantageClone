Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ContractEditDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContractEditDialog))
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemInternalContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemInternalContacts_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ContractControlForm_Contract = New AdvantageFramework.WinForm.Presentation.Controls.ContractControl()
			Me.RibbonBarOptions_ContractFees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemContractFees_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemContractFees_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_ValueAdded = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemValueAdded_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemValueAdded_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_ValueAddedDocument = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemValueAddedDocument_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemValueAddedDocument_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemValueAddedDocument_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemValueAddedDocument_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Reports = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemReports_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReports_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReports_Documents = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_ReportsDocument = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemReportsDocument_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReportsDocumentUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemReportsDocument_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReportsDocument_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemReportsDocument_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemText_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemValueAddedDocumentUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
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
			Me.PanelForm_Form.Controls.Add(Me.ContractControlForm_Contract)
			Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
			Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
			Me.PanelForm_Form.Size = New System.Drawing.Size(801, 451)
			'
			'RibbonControlForm_MainRibbon
			'
			'
			'
			'
			Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(801, 154)
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
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Text)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ReportsDocument)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Reports)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ValueAddedDocument)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ValueAdded)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ContractFees)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Contacts)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
			Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(801, 94)
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
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Contacts, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ContractFees, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ValueAdded, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ValueAddedDocument, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Reports, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ReportsDocument, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Text, 0)
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
			Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 606)
			Me.BarForm_StatusBar.Size = New System.Drawing.Size(801, 18)
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
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(57, 92)
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
			Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(112, 0)
			Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
			Me.RibbonBarOptions_Documents.SecurityEnabled = True
			Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(78, 92)
			Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Documents.TabIndex = 2
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
			Me.RibbonBarOptions_Contacts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInternalContacts_Delete, Me.ButtonItemInternalContacts_Cancel})
			Me.RibbonBarOptions_Contacts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Contacts.Location = New System.Drawing.Point(190, 0)
			Me.RibbonBarOptions_Contacts.Name = "RibbonBarOptions_Contacts"
			Me.RibbonBarOptions_Contacts.SecurityEnabled = True
			Me.RibbonBarOptions_Contacts.Size = New System.Drawing.Size(66, 92)
			Me.RibbonBarOptions_Contacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Contacts.TabIndex = 3
			Me.RibbonBarOptions_Contacts.Text = "Internal Contacts"
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
			'ButtonItemInternalContacts_Delete
			'
			Me.ButtonItemInternalContacts_Delete.BeginGroup = True
			Me.ButtonItemInternalContacts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemInternalContacts_Delete.Name = "ButtonItemInternalContacts_Delete"
			Me.ButtonItemInternalContacts_Delete.RibbonWordWrap = False
			Me.ButtonItemInternalContacts_Delete.SecurityEnabled = True
			Me.ButtonItemInternalContacts_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemInternalContacts_Delete.Text = "Delete"
			'
			'ButtonItemInternalContacts_Cancel
			'
			Me.ButtonItemInternalContacts_Cancel.BeginGroup = True
			Me.ButtonItemInternalContacts_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemInternalContacts_Cancel.Name = "ButtonItemInternalContacts_Cancel"
			Me.ButtonItemInternalContacts_Cancel.RibbonWordWrap = False
			Me.ButtonItemInternalContacts_Cancel.SecurityEnabled = True
			Me.ButtonItemInternalContacts_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemInternalContacts_Cancel.Text = "Cancel"
			'
			'ContractControlForm_Contract
			'
			Me.ContractControlForm_Contract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ContractControlForm_Contract.Location = New System.Drawing.Point(3, 6)
			Me.ContractControlForm_Contract.Name = "ContractControlForm_Contract"
			Me.ContractControlForm_Contract.Size = New System.Drawing.Size(795, 439)
			Me.ContractControlForm_Contract.TabIndex = 0
			'
			'RibbonBarOptions_ContractFees
			'
			Me.RibbonBarOptions_ContractFees.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_ContractFees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ContractFees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ContractFees.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_ContractFees.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_ContractFees.DragDropSupport = True
			Me.RibbonBarOptions_ContractFees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContractFees_Delete, Me.ButtonItemContractFees_Cancel})
			Me.RibbonBarOptions_ContractFees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_ContractFees.Location = New System.Drawing.Point(256, 0)
			Me.RibbonBarOptions_ContractFees.Name = "RibbonBarOptions_ContractFees"
			Me.RibbonBarOptions_ContractFees.SecurityEnabled = True
			Me.RibbonBarOptions_ContractFees.Size = New System.Drawing.Size(68, 92)
			Me.RibbonBarOptions_ContractFees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_ContractFees.TabIndex = 4
			Me.RibbonBarOptions_ContractFees.Text = "Contract Fees"
			'
			'
			'
			Me.RibbonBarOptions_ContractFees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ContractFees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ContractFees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemContractFees_Delete
			'
			Me.ButtonItemContractFees_Delete.BeginGroup = True
			Me.ButtonItemContractFees_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemContractFees_Delete.Name = "ButtonItemContractFees_Delete"
			Me.ButtonItemContractFees_Delete.RibbonWordWrap = False
			Me.ButtonItemContractFees_Delete.SecurityEnabled = True
			Me.ButtonItemContractFees_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemContractFees_Delete.Text = "Delete"
			'
			'ButtonItemContractFees_Cancel
			'
			Me.ButtonItemContractFees_Cancel.BeginGroup = True
			Me.ButtonItemContractFees_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemContractFees_Cancel.Name = "ButtonItemContractFees_Cancel"
			Me.ButtonItemContractFees_Cancel.RibbonWordWrap = False
			Me.ButtonItemContractFees_Cancel.SecurityEnabled = True
			Me.ButtonItemContractFees_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemContractFees_Cancel.Text = "Cancel"
			'
			'RibbonBarOptions_ValueAdded
			'
			Me.RibbonBarOptions_ValueAdded.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_ValueAdded.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ValueAdded.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ValueAdded.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_ValueAdded.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_ValueAdded.DragDropSupport = True
			Me.RibbonBarOptions_ValueAdded.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemValueAdded_Delete, Me.ButtonItemValueAdded_Cancel})
			Me.RibbonBarOptions_ValueAdded.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_ValueAdded.Location = New System.Drawing.Point(324, 0)
			Me.RibbonBarOptions_ValueAdded.Name = "RibbonBarOptions_ValueAdded"
			Me.RibbonBarOptions_ValueAdded.SecurityEnabled = True
			Me.RibbonBarOptions_ValueAdded.Size = New System.Drawing.Size(74, 92)
			Me.RibbonBarOptions_ValueAdded.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_ValueAdded.TabIndex = 5
			Me.RibbonBarOptions_ValueAdded.Text = "Value Added"
			'
			'
			'
			Me.RibbonBarOptions_ValueAdded.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ValueAdded.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ValueAdded.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemValueAdded_Delete
			'
			Me.ButtonItemValueAdded_Delete.BeginGroup = True
			Me.ButtonItemValueAdded_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAdded_Delete.Name = "ButtonItemValueAdded_Delete"
			Me.ButtonItemValueAdded_Delete.RibbonWordWrap = False
			Me.ButtonItemValueAdded_Delete.SecurityEnabled = True
			Me.ButtonItemValueAdded_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemValueAdded_Delete.Text = "Delete"
			'
			'ButtonItemValueAdded_Cancel
			'
			Me.ButtonItemValueAdded_Cancel.BeginGroup = True
			Me.ButtonItemValueAdded_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAdded_Cancel.Name = "ButtonItemValueAdded_Cancel"
			Me.ButtonItemValueAdded_Cancel.RibbonWordWrap = False
			Me.ButtonItemValueAdded_Cancel.SecurityEnabled = True
			Me.ButtonItemValueAdded_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemValueAdded_Cancel.Text = "Cancel"
			'
			'RibbonBarOptions_ValueAddedDocument
			'
			Me.RibbonBarOptions_ValueAddedDocument.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_ValueAddedDocument.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ValueAddedDocument.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ValueAddedDocument.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_ValueAddedDocument.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_ValueAddedDocument.DragDropSupport = True
			Me.RibbonBarOptions_ValueAddedDocument.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemValueAddedDocument_Upload, Me.ButtonItemValueAddedDocument_Download, Me.ButtonItemValueAddedDocument_OpenURL, Me.ButtonItemValueAddedDocument_Delete})
			Me.RibbonBarOptions_ValueAddedDocument.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_ValueAddedDocument.Location = New System.Drawing.Point(398, 0)
			Me.RibbonBarOptions_ValueAddedDocument.Name = "RibbonBarOptions_ValueAddedDocument"
			Me.RibbonBarOptions_ValueAddedDocument.SecurityEnabled = True
			Me.RibbonBarOptions_ValueAddedDocument.Size = New System.Drawing.Size(56, 92)
			Me.RibbonBarOptions_ValueAddedDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_ValueAddedDocument.TabIndex = 6
			Me.RibbonBarOptions_ValueAddedDocument.Text = "Value Added Document"
			'
			'
			'
			Me.RibbonBarOptions_ValueAddedDocument.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ValueAddedDocument.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ValueAddedDocument.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemValueAddedDocument_Upload
			'
			Me.ButtonItemValueAddedDocument_Upload.BeginGroup = True
			Me.ButtonItemValueAddedDocument_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAddedDocument_Upload.Name = "ButtonItemValueAddedDocument_Upload"
			Me.ButtonItemValueAddedDocument_Upload.RibbonWordWrap = False
			Me.ButtonItemValueAddedDocument_Upload.SecurityEnabled = True
			Me.ButtonItemValueAddedDocument_Upload.SplitButton = True
			Me.ButtonItemValueAddedDocument_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemValueAddedDocumentUpload_EmailLink})
			Me.ButtonItemValueAddedDocument_Upload.SubItemsExpandWidth = 14
			Me.ButtonItemValueAddedDocument_Upload.Text = "Upload"
			'
			'ButtonItemValueAddedDocument_Download
			'
			Me.ButtonItemValueAddedDocument_Download.BeginGroup = True
			Me.ButtonItemValueAddedDocument_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAddedDocument_Download.Name = "ButtonItemValueAddedDocument_Download"
			Me.ButtonItemValueAddedDocument_Download.RibbonWordWrap = False
			Me.ButtonItemValueAddedDocument_Download.SecurityEnabled = True
			Me.ButtonItemValueAddedDocument_Download.SubItemsExpandWidth = 14
			Me.ButtonItemValueAddedDocument_Download.Text = "Download"
			'
			'ButtonItemValueAddedDocument_OpenURL
			'
			Me.ButtonItemValueAddedDocument_OpenURL.BeginGroup = True
			Me.ButtonItemValueAddedDocument_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAddedDocument_OpenURL.Name = "ButtonItemValueAddedDocument_OpenURL"
			Me.ButtonItemValueAddedDocument_OpenURL.RibbonWordWrap = False
			Me.ButtonItemValueAddedDocument_OpenURL.SecurityEnabled = True
			Me.ButtonItemValueAddedDocument_OpenURL.SubItemsExpandWidth = 14
			Me.ButtonItemValueAddedDocument_OpenURL.Text = "Open URL"
			'
			'ButtonItemValueAddedDocument_Delete
			'
			Me.ButtonItemValueAddedDocument_Delete.BeginGroup = True
			Me.ButtonItemValueAddedDocument_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemValueAddedDocument_Delete.Name = "ButtonItemValueAddedDocument_Delete"
			Me.ButtonItemValueAddedDocument_Delete.RibbonWordWrap = False
			Me.ButtonItemValueAddedDocument_Delete.SecurityEnabled = True
			Me.ButtonItemValueAddedDocument_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemValueAddedDocument_Delete.Text = "Delete"
			'
			'RibbonBarOptions_Reports
			'
			Me.RibbonBarOptions_Reports.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Reports.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Reports.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Reports.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Reports.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Reports.DragDropSupport = True
			Me.RibbonBarOptions_Reports.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReports_Delete, Me.ButtonItemReports_Cancel, Me.ButtonItemReports_Documents})
			Me.RibbonBarOptions_Reports.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Reports.Location = New System.Drawing.Point(454, 0)
			Me.RibbonBarOptions_Reports.Name = "RibbonBarOptions_Reports"
			Me.RibbonBarOptions_Reports.SecurityEnabled = True
			Me.RibbonBarOptions_Reports.Size = New System.Drawing.Size(78, 92)
			Me.RibbonBarOptions_Reports.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Reports.TabIndex = 7
			Me.RibbonBarOptions_Reports.Text = "Reports"
			'
			'
			'
			Me.RibbonBarOptions_Reports.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Reports.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Reports.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemReports_Delete
			'
			Me.ButtonItemReports_Delete.BeginGroup = True
			Me.ButtonItemReports_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReports_Delete.Name = "ButtonItemReports_Delete"
			Me.ButtonItemReports_Delete.RibbonWordWrap = False
			Me.ButtonItemReports_Delete.SecurityEnabled = True
			Me.ButtonItemReports_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemReports_Delete.Text = "Delete"
			'
			'ButtonItemReports_Cancel
			'
			Me.ButtonItemReports_Cancel.BeginGroup = True
			Me.ButtonItemReports_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReports_Cancel.Name = "ButtonItemReports_Cancel"
			Me.ButtonItemReports_Cancel.RibbonWordWrap = False
			Me.ButtonItemReports_Cancel.SecurityEnabled = True
			Me.ButtonItemReports_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemReports_Cancel.Text = "Cancel"
			'
			'ButtonItemReports_Documents
			'
			Me.ButtonItemReports_Documents.BeginGroup = True
			Me.ButtonItemReports_Documents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReports_Documents.Name = "ButtonItemReports_Documents"
			Me.ButtonItemReports_Documents.RibbonWordWrap = False
			Me.ButtonItemReports_Documents.SecurityEnabled = True
			Me.ButtonItemReports_Documents.SubItemsExpandWidth = 14
			Me.ButtonItemReports_Documents.Text = "Documents"
			Me.ButtonItemReports_Documents.Visible = False
			'
			'RibbonBarOptions_ReportsDocument
			'
			Me.RibbonBarOptions_ReportsDocument.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_ReportsDocument.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ReportsDocument.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ReportsDocument.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_ReportsDocument.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_ReportsDocument.DragDropSupport = True
			Me.RibbonBarOptions_ReportsDocument.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReportsDocument_Upload, Me.ButtonItemReportsDocument_Download, Me.ButtonItemReportsDocument_OpenURL, Me.ButtonItemReportsDocument_Delete})
			Me.RibbonBarOptions_ReportsDocument.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_ReportsDocument.Location = New System.Drawing.Point(532, 0)
			Me.RibbonBarOptions_ReportsDocument.Name = "RibbonBarOptions_ReportsDocument"
			Me.RibbonBarOptions_ReportsDocument.SecurityEnabled = True
			Me.RibbonBarOptions_ReportsDocument.Size = New System.Drawing.Size(82, 92)
			Me.RibbonBarOptions_ReportsDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_ReportsDocument.TabIndex = 8
			Me.RibbonBarOptions_ReportsDocument.Text = "Reports Document"
			'
			'
			'
			Me.RibbonBarOptions_ReportsDocument.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_ReportsDocument.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_ReportsDocument.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemReportsDocument_Upload
			'
			Me.ButtonItemReportsDocument_Upload.BeginGroup = True
			Me.ButtonItemReportsDocument_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReportsDocument_Upload.Name = "ButtonItemReportsDocument_Upload"
			Me.ButtonItemReportsDocument_Upload.RibbonWordWrap = False
			Me.ButtonItemReportsDocument_Upload.SecurityEnabled = True
			Me.ButtonItemReportsDocument_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReportsDocumentUpload_EmailLink})
			Me.ButtonItemReportsDocument_Upload.SubItemsExpandWidth = 14
			Me.ButtonItemReportsDocument_Upload.Text = "Upload"
			'
			'ButtonItemReportsDocumentUpload_EmailLink
			'
			Me.ButtonItemReportsDocumentUpload_EmailLink.Name = "ButtonItemReportsDocumentUpload_EmailLink"
			Me.ButtonItemReportsDocumentUpload_EmailLink.Text = "Email Link"
			'
			'ButtonItemReportsDocument_Download
			'
			Me.ButtonItemReportsDocument_Download.BeginGroup = True
			Me.ButtonItemReportsDocument_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReportsDocument_Download.Name = "ButtonItemReportsDocument_Download"
			Me.ButtonItemReportsDocument_Download.RibbonWordWrap = False
			Me.ButtonItemReportsDocument_Download.SecurityEnabled = True
			Me.ButtonItemReportsDocument_Download.SubItemsExpandWidth = 14
			Me.ButtonItemReportsDocument_Download.Text = "Download"
			'
			'ButtonItemReportsDocument_OpenURL
			'
			Me.ButtonItemReportsDocument_OpenURL.BeginGroup = True
			Me.ButtonItemReportsDocument_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReportsDocument_OpenURL.Name = "ButtonItemReportsDocument_OpenURL"
			Me.ButtonItemReportsDocument_OpenURL.RibbonWordWrap = False
			Me.ButtonItemReportsDocument_OpenURL.SecurityEnabled = True
			Me.ButtonItemReportsDocument_OpenURL.SubItemsExpandWidth = 14
			Me.ButtonItemReportsDocument_OpenURL.Text = "Open URL"
			'
			'ButtonItemReportsDocument_Delete
			'
			Me.ButtonItemReportsDocument_Delete.BeginGroup = True
			Me.ButtonItemReportsDocument_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemReportsDocument_Delete.Name = "ButtonItemReportsDocument_Delete"
			Me.ButtonItemReportsDocument_Delete.RibbonWordWrap = False
			Me.ButtonItemReportsDocument_Delete.SecurityEnabled = True
			Me.ButtonItemReportsDocument_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemReportsDocument_Delete.Text = "Delete"
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
			Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(671, 0)
			Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
			Me.RibbonBarOptions_Text.SecurityEnabled = True
			Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(43, 92)
			Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Text.TabIndex = 21
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
			'RibbonBarOptions_Filter
			'
			Me.RibbonBarOptions_Filter.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Filter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Filter.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Filter.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Filter.DragDropSupport = True
			Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_All, Me.ButtonItemFilter_SelectedLineItem})
			Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(614, 0)
			Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
			Me.RibbonBarOptions_Filter.SecurityEnabled = True
			Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(57, 92)
			Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Filter.TabIndex = 37
			Me.RibbonBarOptions_Filter.Text = "Filter"
			'
			'
			'
			Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			Me.RibbonBarOptions_Filter.Visible = False
			'
			'ButtonItemFilter_All
			'
			Me.ButtonItemFilter_All.AutoCheckOnClick = True
			Me.ButtonItemFilter_All.BeginGroup = True
			Me.ButtonItemFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemFilter_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFilter_All.Name = "ButtonItemFilter_All"
			Me.ButtonItemFilter_All.RibbonWordWrap = False
			Me.ButtonItemFilter_All.SecurityEnabled = True
			Me.ButtonItemFilter_All.Stretch = True
			Me.ButtonItemFilter_All.SubItemsExpandWidth = 14
			Me.ButtonItemFilter_All.Text = "All"
			'
			'ButtonItemFilter_SelectedLineItem
			'
			Me.ButtonItemFilter_SelectedLineItem.AutoCheckOnClick = True
			Me.ButtonItemFilter_SelectedLineItem.BeginGroup = True
			Me.ButtonItemFilter_SelectedLineItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemFilter_SelectedLineItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFilter_SelectedLineItem.Name = "ButtonItemFilter_SelectedLineItem"
			Me.ButtonItemFilter_SelectedLineItem.RibbonWordWrap = False
			Me.ButtonItemFilter_SelectedLineItem.SecurityEnabled = True
			Me.ButtonItemFilter_SelectedLineItem.Stretch = True
			Me.ButtonItemFilter_SelectedLineItem.SubItemsExpandWidth = 14
			Me.ButtonItemFilter_SelectedLineItem.Text = "Selected Line Item(s)"
			'
			'ButtonItemValueAddedDocumentUpload_EmailLink
			'
			Me.ButtonItemValueAddedDocumentUpload_EmailLink.Name = "ButtonItemValueAddedDocumentUpload_EmailLink"
			Me.ButtonItemValueAddedDocumentUpload_EmailLink.Text = "Email Link"
			'
			'ContractEditDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.ClientSize = New System.Drawing.Size(811, 626)
			Me.CloseButtonVisible = False
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "ContractEditDialog"
			Me.Text = "Contract"
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
		Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
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
		Friend WithEvents ButtonItemInternalContacts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemInternalContacts_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ContractControlForm_Contract As AdvantageFramework.WinForm.Presentation.Controls.ContractControl
		Friend WithEvents RibbonBarOptions_ContractFees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemContractFees_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemContractFees_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_ValueAdded As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemValueAdded_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemValueAdded_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_ValueAddedDocument As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemValueAddedDocument_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemValueAddedDocument_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemValueAddedDocument_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_ReportsDocument As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemReportsDocument_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemReportsDocument_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemReportsDocument_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_Reports As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemReports_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemReports_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemReportsDocument_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemValueAddedDocument_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemText_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemReports_Documents As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemReportsDocumentUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemValueAddedDocumentUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace