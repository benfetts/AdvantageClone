Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorContractEditDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorContractEditDialog))
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemInternalContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemInternalContacts_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemText_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.VendorContractControlForm_Contract = New AdvantageFramework.WinForm.Presentation.Controls.VendorContractControl()
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
			Me.PanelForm_Form.Controls.Add(Me.VendorContractControlForm_Contract)
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
			Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(256, 0)
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
			'VendorContractControlForm_Contract
			'
			Me.VendorContractControlForm_Contract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.VendorContractControlForm_Contract.Location = New System.Drawing.Point(3, 6)
			Me.VendorContractControlForm_Contract.Name = "VendorContractControlForm_Contract"
			Me.VendorContractControlForm_Contract.Size = New System.Drawing.Size(795, 439)
			Me.VendorContractControlForm_Contract.TabIndex = 1
			'
			'ButtonItemUpload_EmailLink
			'
			Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
			Me.ButtonItemUpload_EmailLink.Text = "Email Link"
			'
			'VendorContractEditDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.ClientSize = New System.Drawing.Size(811, 626)
			Me.CloseButtonVisible = False
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "VendorContractEditDialog"
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
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents VendorContractControlForm_Contract As WinForm.Presentation.Controls.VendorContractControl
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace