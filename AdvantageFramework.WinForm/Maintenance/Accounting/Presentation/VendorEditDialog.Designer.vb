Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorEditDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintFiltered = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContacts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContacts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Representatives = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRepresentatives_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRepresentatives_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRepresentatives_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaSpecs = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaSpecs_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaSpecs_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSpelling_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Pricings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPricings_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPricings_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.VendorControlForm_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.VendorControl()
            Me.RibbonBarOptions_ComboStations = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComboStations_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.VendorControlForm_Vendor)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1307, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1307, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ComboStations)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Pricings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_CheckSpelling)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_MediaSpecs)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Representatives)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Contacts)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1307, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Contacts, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Representatives, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_MediaSpecs, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_CheckSpelling, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Pricings, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ComboStations, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(58, 92)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1307, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print, Me.ButtonItemActions_PrintFiltered})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(61, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(234, 92)
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
            Me.ButtonItemActions_PrintFiltered.Visible = False
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
            Me.RibbonBarOptions_Contacts.Location = New System.Drawing.Point(295, 0)
            Me.RibbonBarOptions_Contacts.Name = "RibbonBarOptions_Contacts"
            Me.RibbonBarOptions_Contacts.SecurityEnabled = True
            Me.RibbonBarOptions_Contacts.Size = New System.Drawing.Size(115, 92)
            Me.RibbonBarOptions_Contacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contacts.TabIndex = 2
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
            Me.RibbonBarOptions_Representatives.Location = New System.Drawing.Point(410, 0)
            Me.RibbonBarOptions_Representatives.Name = "RibbonBarOptions_Representatives"
            Me.RibbonBarOptions_Representatives.SecurityEnabled = True
            Me.RibbonBarOptions_Representatives.Size = New System.Drawing.Size(115, 92)
            Me.RibbonBarOptions_Representatives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Representatives.TabIndex = 3
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
            Me.RibbonBarOptions_MediaSpecs.Location = New System.Drawing.Point(525, 0)
            Me.RibbonBarOptions_MediaSpecs.Name = "RibbonBarOptions_MediaSpecs"
            Me.RibbonBarOptions_MediaSpecs.SecurityEnabled = True
            Me.RibbonBarOptions_MediaSpecs.Size = New System.Drawing.Size(93, 92)
            Me.RibbonBarOptions_MediaSpecs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaSpecs.TabIndex = 4
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
            Me.RibbonBarOptions_CheckSpelling.Location = New System.Drawing.Point(618, 0)
            Me.RibbonBarOptions_CheckSpelling.Name = "RibbonBarOptions_CheckSpelling"
            Me.RibbonBarOptions_CheckSpelling.SecurityEnabled = True
            Me.RibbonBarOptions_CheckSpelling.Size = New System.Drawing.Size(91, 92)
            Me.RibbonBarOptions_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CheckSpelling.TabIndex = 5
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
            Me.RibbonBarOptions_Pricings.Location = New System.Drawing.Point(709, 0)
            Me.RibbonBarOptions_Pricings.Name = "RibbonBarOptions_Pricings"
            Me.RibbonBarOptions_Pricings.SecurityEnabled = True
            Me.RibbonBarOptions_Pricings.Size = New System.Drawing.Size(96, 92)
            Me.RibbonBarOptions_Pricings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Pricings.TabIndex = 6
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
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(805, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(222, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 8
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
            'VendorControlForm_Vendor
            '
            Me.VendorControlForm_Vendor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorControlForm_Vendor.AutoScroll = True
            Me.VendorControlForm_Vendor.Location = New System.Drawing.Point(3, 6)
            Me.VendorControlForm_Vendor.Margin = New System.Windows.Forms.Padding(4)
            Me.VendorControlForm_Vendor.Name = "VendorControlForm_Vendor"
            Me.VendorControlForm_Vendor.Size = New System.Drawing.Size(1301, 543)
            Me.VendorControlForm_Vendor.TabIndex = 18
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
            Me.RibbonBarOptions_ComboStations.Location = New System.Drawing.Point(1027, 0)
            Me.RibbonBarOptions_ComboStations.Name = "RibbonBarOptions_ComboStations"
            Me.RibbonBarOptions_ComboStations.SecurityEnabled = True
            Me.RibbonBarOptions_ComboStations.Size = New System.Drawing.Size(91, 92)
            Me.RibbonBarOptions_ComboStations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ComboStations.TabIndex = 23
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
            'VendorEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1317, 730)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VendorEditDialog"
            Me.Text = "Vendor Maintenance"
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
        Friend WithEvents RibbonBarOptions_Pricings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPricings_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPricings_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpelling_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_MediaSpecs As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaSpecs_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaSpecs_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Representatives As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRepresentatives_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRepresentatives_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRepresentatives_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Contacts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContacts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContacts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintFiltered As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents VendorControlForm_Vendor As AdvantageFramework.WinForm.Presentation.Controls.VendorControl
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents RibbonBarOptions_ComboStations As WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemComboStations_Manage As WinForm.Presentation.Controls.ButtonItem
	End Class

End Namespace