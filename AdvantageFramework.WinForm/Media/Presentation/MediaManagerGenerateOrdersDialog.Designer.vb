Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerGenerateOrdersDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerGenerateOrdersDialog))
            Me.RibbonBarOptions_ContactsDocumentSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContactsDocumentSettings_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerContactsDocumentSettings_Spacer = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemContactsDocumentSettings_Spacer = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerContactsDocumentSettings_Reps = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemContactsDocumentSettings_OrderReps = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_VendorReps = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_ContactTypes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_DocumentTypes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_AlertRecipients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Generate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Recipients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelItemAdvanceBilling_PercenToBill = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemAdvanceBilling_PercentBilled = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerBillingSelectionVertical_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemBS_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewDetails_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSeach_StatusGroup1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemFilter_Quote = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFilter_Order = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSeach_StatusGroup2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemFilter_Revision = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFilter_Cancellation = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Order = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOrder_Preview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOrder_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewDetails_Details)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Export)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 370)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ContactsDocumentSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Order)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Order, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ContactsDocumentSettings, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 525)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'RibbonBarOptions_ContactsDocumentSettings
            '
            Me.RibbonBarOptions_ContactsDocumentSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ContactsDocumentSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ContactsDocumentSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ContactsDocumentSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ContactsDocumentSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ContactsDocumentSettings.DragDropSupport = True
            Me.RibbonBarOptions_ContactsDocumentSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContactsDocumentSettings_Save, Me.ItemContainerContactsDocumentSettings_Spacer, Me.ItemContainerContactsDocumentSettings_Reps, Me.ButtonItemContactsDocumentSettings_ContactTypes, Me.ButtonItemContactsDocumentSettings_DocumentTypes, Me.ButtonItemContactsDocumentSettings_AlertRecipients})
            Me.RibbonBarOptions_ContactsDocumentSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ContactsDocumentSettings.Location = New System.Drawing.Point(513, 0)
            Me.RibbonBarOptions_ContactsDocumentSettings.Name = "RibbonBarOptions_ContactsDocumentSettings"
            Me.RibbonBarOptions_ContactsDocumentSettings.SecurityEnabled = True
            Me.RibbonBarOptions_ContactsDocumentSettings.Size = New System.Drawing.Size(402, 92)
            Me.RibbonBarOptions_ContactsDocumentSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ContactsDocumentSettings.TabIndex = 13
            Me.RibbonBarOptions_ContactsDocumentSettings.Text = "Send To and Document Attachment Settings"
            '
            '
            '
            Me.RibbonBarOptions_ContactsDocumentSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ContactsDocumentSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ContactsDocumentSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemContactsDocumentSettings_Save
            '
            Me.ButtonItemContactsDocumentSettings_Save.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContactsDocumentSettings_Save.Name = "ButtonItemContactsDocumentSettings_Save"
            Me.ButtonItemContactsDocumentSettings_Save.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_Save.SecurityEnabled = True
            Me.ButtonItemContactsDocumentSettings_Save.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_Save.Text = "Save"
            '
            'ItemContainerContactsDocumentSettings_Spacer
            '
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Spacer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerContactsDocumentSettings_Spacer.BeginGroup = True
            Me.ItemContainerContactsDocumentSettings_Spacer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerContactsDocumentSettings_Spacer.Name = "ItemContainerContactsDocumentSettings_Spacer"
            Me.ItemContainerContactsDocumentSettings_Spacer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemContactsDocumentSettings_Spacer})
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Spacer.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Spacer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemContactsDocumentSettings_Spacer
            '
            Me.LabelItemContactsDocumentSettings_Spacer.BeginGroup = True
            Me.LabelItemContactsDocumentSettings_Spacer.BorderSide = DevComponents.DotNetBar.eBorderSide.Left
            Me.LabelItemContactsDocumentSettings_Spacer.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.LabelItemContactsDocumentSettings_Spacer.DividerStyle = True
            Me.LabelItemContactsDocumentSettings_Spacer.Name = "LabelItemContactsDocumentSettings_Spacer"
            Me.LabelItemContactsDocumentSettings_Spacer.Text = "<span width=""25"">    </span>"
            Me.LabelItemContactsDocumentSettings_Spacer.Width = 15
            '
            'ItemContainerContactsDocumentSettings_Reps
            '
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Reps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerContactsDocumentSettings_Reps.BeginGroup = True
            Me.ItemContainerContactsDocumentSettings_Reps.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerContactsDocumentSettings_Reps.Name = "ItemContainerContactsDocumentSettings_Reps"
            Me.ItemContainerContactsDocumentSettings_Reps.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContactsDocumentSettings_OrderReps, Me.ButtonItemContactsDocumentSettings_VendorReps})
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Reps.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerContactsDocumentSettings_Reps.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerContactsDocumentSettings_Reps.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemContactsDocumentSettings_OrderReps
            '
            Me.ButtonItemContactsDocumentSettings_OrderReps.AutoCheckOnClick = True
            Me.ButtonItemContactsDocumentSettings_OrderReps.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_OrderReps.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemContactsDocumentSettings_OrderReps.Checked = True
            Me.ButtonItemContactsDocumentSettings_OrderReps.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemContactsDocumentSettings_OrderReps.Name = "ButtonItemContactsDocumentSettings_OrderReps"
            Me.ButtonItemContactsDocumentSettings_OrderReps.OptionGroup = "Reps"
            Me.ButtonItemContactsDocumentSettings_OrderReps.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_OrderReps.Stretch = True
            Me.ButtonItemContactsDocumentSettings_OrderReps.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_OrderReps.Text = "Order Reps"
            '
            'ButtonItemContactsDocumentSettings_VendorReps
            '
            Me.ButtonItemContactsDocumentSettings_VendorReps.AutoCheckOnClick = True
            Me.ButtonItemContactsDocumentSettings_VendorReps.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_VendorReps.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemContactsDocumentSettings_VendorReps.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemContactsDocumentSettings_VendorReps.Name = "ButtonItemContactsDocumentSettings_VendorReps"
            Me.ButtonItemContactsDocumentSettings_VendorReps.OptionGroup = "Reps"
            Me.ButtonItemContactsDocumentSettings_VendorReps.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_VendorReps.Stretch = True
            Me.ButtonItemContactsDocumentSettings_VendorReps.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_VendorReps.Text = "Vendor Reps"
            '
            'ButtonItemContactsDocumentSettings_ContactTypes
            '
            Me.ButtonItemContactsDocumentSettings_ContactTypes.AutoExpandOnClick = True
            Me.ButtonItemContactsDocumentSettings_ContactTypes.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_ContactTypes.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemContactsDocumentSettings_ContactTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContactsDocumentSettings_ContactTypes.Name = "ButtonItemContactsDocumentSettings_ContactTypes"
            Me.ButtonItemContactsDocumentSettings_ContactTypes.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_ContactTypes.SecurityEnabled = True
            Me.ButtonItemContactsDocumentSettings_ContactTypes.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_ContactTypes.Text = "Contact Types"
            '
            'ButtonItemContactsDocumentSettings_DocumentTypes
            '
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.AutoExpandOnClick = True
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.Name = "ButtonItemContactsDocumentSettings_DocumentTypes"
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.SecurityEnabled = True
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.Text = "Document Types"
            '
            'ButtonItemContactsDocumentSettings_AlertRecipients
            '
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.BeginGroup = True
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.Name = "ButtonItemContactsDocumentSettings_AlertRecipients"
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.RibbonWordWrap = False
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.SecurityEnabled = True
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.SubItemsExpandWidth = 14
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.Text = "Alert Recipients"
            Me.ButtonItemContactsDocumentSettings_AlertRecipients.Visible = False
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Generate, Me.ButtonItemActions_Recipients, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(222, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 18
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Generate
            '
            Me.ButtonItemActions_Generate.BeginGroup = True
            Me.ButtonItemActions_Generate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Generate.Name = "ButtonItemActions_Generate"
            Me.ButtonItemActions_Generate.RibbonWordWrap = False
            Me.ButtonItemActions_Generate.SecurityEnabled = True
            Me.ButtonItemActions_Generate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Generate.Text = "Generate"
            '
            'ButtonItemActions_Recipients
            '
            Me.ButtonItemActions_Recipients.BeginGroup = True
            Me.ButtonItemActions_Recipients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Recipients.Name = "ButtonItemActions_Recipients"
            Me.ButtonItemActions_Recipients.RibbonWordWrap = False
            Me.ButtonItemActions_Recipients.SecurityEnabled = True
            Me.ButtonItemActions_Recipients.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Recipients.Text = "Recipients"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'LabelItemAdvanceBilling_PercenToBill
            '
            Me.LabelItemAdvanceBilling_PercenToBill.Name = "LabelItemAdvanceBilling_PercenToBill"
            Me.LabelItemAdvanceBilling_PercenToBill.Text = "% to Bill:"
            Me.LabelItemAdvanceBilling_PercenToBill.Width = 55
            '
            'LabelItemAdvanceBilling_PercentBilled
            '
            Me.LabelItemAdvanceBilling_PercentBilled.Name = "LabelItemAdvanceBilling_PercentBilled"
            Me.LabelItemAdvanceBilling_PercentBilled.Text = "% Billed:"
            Me.LabelItemAdvanceBilling_PercentBilled.Width = 55
            '
            'ItemContainerBillingSelectionVertical_Top
            '
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillingSelectionVertical_Top.Name = "ItemContainerBillingSelectionVertical_Top"
            Me.ItemContainerBillingSelectionVertical_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemAdvanceBilling_PercenToBill, Me.ControlContainerItemBS_InvoiceDate})
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemBS_InvoiceDate
            '
            Me.ControlContainerItemBS_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemBS_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBS_InvoiceDate.Name = "ControlContainerItemBS_InvoiceDate"
            Me.ControlContainerItemBS_InvoiceDate.Text = "ControlContainerItem2"
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Export.AllowDragAndDrop = False
            Me.DataGridViewForm_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_Export.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(956, 356)
            Me.DataGridViewForm_Export.TabIndex = 11
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'DataGridViewDetails_Details
            '
            Me.DataGridViewDetails_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDetails_Details.AllowDragAndDrop = False
            Me.DataGridViewDetails_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDetails_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDetails_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDetails_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDetails_Details.AutoFilterLookupColumns = False
            Me.DataGridViewDetails_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewDetails_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDetails_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDetails_Details.DataSource = Nothing
            Me.DataGridViewDetails_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDetails_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDetails_Details.ItemDescription = ""
            Me.DataGridViewDetails_Details.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewDetails_Details.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDetails_Details.MultiSelect = True
            Me.DataGridViewDetails_Details.Name = "DataGridViewDetails_Details"
            Me.DataGridViewDetails_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDetails_Details.RunStandardValidation = True
            Me.DataGridViewDetails_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDetails_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDetails_Details.Size = New System.Drawing.Size(956, 356)
            Me.DataGridViewDetails_Details.TabIndex = 2
            Me.DataGridViewDetails_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDetails_Details.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSeach_StatusGroup1, Me.ItemContainerSeach_StatusGroup2})
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(277, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(128, 92)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 19
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerSeach_StatusGroup1
            '
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_StatusGroup1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSeach_StatusGroup1.Name = "ItemContainerSeach_StatusGroup1"
            Me.ItemContainerSeach_StatusGroup1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_Quote, Me.ButtonItemFilter_Order})
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_StatusGroup1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemFilter_Quote
            '
            Me.ButtonItemFilter_Quote.AutoCheckOnClick = True
            Me.ButtonItemFilter_Quote.BeginGroup = True
            Me.ButtonItemFilter_Quote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_Quote.Checked = True
            Me.ButtonItemFilter_Quote.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemFilter_Quote.Name = "ButtonItemFilter_Quote"
            Me.ButtonItemFilter_Quote.RibbonWordWrap = False
            Me.ButtonItemFilter_Quote.Stretch = True
            Me.ButtonItemFilter_Quote.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_Quote.Text = "Quote"
            '
            'ButtonItemFilter_Order
            '
            Me.ButtonItemFilter_Order.AutoCheckOnClick = True
            Me.ButtonItemFilter_Order.BeginGroup = True
            Me.ButtonItemFilter_Order.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_Order.Checked = True
            Me.ButtonItemFilter_Order.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemFilter_Order.Name = "ButtonItemFilter_Order"
            Me.ButtonItemFilter_Order.RibbonWordWrap = False
            Me.ButtonItemFilter_Order.Stretch = True
            Me.ButtonItemFilter_Order.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_Order.Text = "Order"
            '
            'ItemContainerSeach_StatusGroup2
            '
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_StatusGroup2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSeach_StatusGroup2.Name = "ItemContainerSeach_StatusGroup2"
            Me.ItemContainerSeach_StatusGroup2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_Revision, Me.ButtonItemFilter_Cancellation})
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSeach_StatusGroup2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSeach_StatusGroup2.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemFilter_Revision
            '
            Me.ButtonItemFilter_Revision.AutoCheckOnClick = True
            Me.ButtonItemFilter_Revision.BeginGroup = True
            Me.ButtonItemFilter_Revision.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_Revision.Checked = True
            Me.ButtonItemFilter_Revision.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemFilter_Revision.Name = "ButtonItemFilter_Revision"
            Me.ButtonItemFilter_Revision.RibbonWordWrap = False
            Me.ButtonItemFilter_Revision.Stretch = True
            Me.ButtonItemFilter_Revision.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_Revision.Text = "Revision"
            '
            'ButtonItemFilter_Cancellation
            '
            Me.ButtonItemFilter_Cancellation.AutoCheckOnClick = True
            Me.ButtonItemFilter_Cancellation.BeginGroup = True
            Me.ButtonItemFilter_Cancellation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_Cancellation.Checked = True
            Me.ButtonItemFilter_Cancellation.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemFilter_Cancellation.Name = "ButtonItemFilter_Cancellation"
            Me.ButtonItemFilter_Cancellation.RibbonWordWrap = False
            Me.ButtonItemFilter_Cancellation.Stretch = True
            Me.ButtonItemFilter_Cancellation.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_Cancellation.Text = "Cancellation"
            '
            'RibbonBarOptions_Order
            '
            Me.RibbonBarOptions_Order.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Order.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Order.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Order.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Order.DragDropSupport = True
            Me.RibbonBarOptions_Order.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOrder_Preview, Me.ButtonItemOrder_Settings})
            Me.RibbonBarOptions_Order.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Order.Location = New System.Drawing.Point(405, 0)
            Me.RibbonBarOptions_Order.Name = "RibbonBarOptions_Order"
            Me.RibbonBarOptions_Order.SecurityEnabled = True
            Me.RibbonBarOptions_Order.Size = New System.Drawing.Size(108, 92)
            Me.RibbonBarOptions_Order.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Order.TabIndex = 20
            Me.RibbonBarOptions_Order.Text = "Order"
            '
            '
            '
            Me.RibbonBarOptions_Order.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Order.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Order.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOrder_Preview
            '
            Me.ButtonItemOrder_Preview.BeginGroup = True
            Me.ButtonItemOrder_Preview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrder_Preview.Name = "ButtonItemOrder_Preview"
            Me.ButtonItemOrder_Preview.RibbonWordWrap = False
            Me.ButtonItemOrder_Preview.SecurityEnabled = True
            Me.ButtonItemOrder_Preview.SubItemsExpandWidth = 14
            Me.ButtonItemOrder_Preview.Text = "Preview"
            '
            'ButtonItemOrder_Settings
            '
            Me.ButtonItemOrder_Settings.BeginGroup = True
            Me.ButtonItemOrder_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOrder_Settings.Name = "ButtonItemOrder_Settings"
            Me.ButtonItemOrder_Settings.RibbonWordWrap = False
            Me.ButtonItemOrder_Settings.SecurityEnabled = True
            Me.ButtonItemOrder_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemOrder_Settings.Text = "Settings"
            '
            'MediaManagerGenerateOrdersDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 545)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerGenerateOrdersDialog"
            Me.Text = "Media Manager Generate Orders"
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
        Friend WithEvents RibbonBarOptions_ContactsDocumentSettings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerBillingSelectionVertical_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBS_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents LabelItemAdvanceBilling_PercenToBill As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemAdvanceBilling_PercentBilled As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Generate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewDetails_Details As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ItemContainerContactsDocumentSettings_Reps As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemContactsDocumentSettings_OrderReps As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_VendorReps As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerSeach_StatusGroup1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemFilter_Quote As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFilter_Order As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSeach_StatusGroup2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemFilter_Revision As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFilter_Cancellation As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerContactsDocumentSettings_Spacer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemContactsDocumentSettings_Spacer As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemContactsDocumentSettings_ContactTypes As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_DocumentTypes As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Recipients As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Order As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOrder_Preview As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrder_Settings As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_AlertRecipients As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace