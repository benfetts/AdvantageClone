Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTrafficGenerateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTrafficGenerateDialog))
            Me.ButtonItemAvailLines_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Generate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewDetails_Details = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_ContactsDocumentSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContactsDocumentSettings_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_ContactTypes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContactsDocumentSettings_DocumentTypes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSendTo_AlertRecipients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_Recipients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ContactsDocumentSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(985, 97)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 589)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(985, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Generate, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(128, 95)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 19
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
            'DataGridViewDetails_Details
            '
            Me.DataGridViewDetails_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDetails_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDetails_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDetails_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDetails_Details.ItemDescription = ""
            Me.DataGridViewDetails_Details.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewDetails_Details.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDetails_Details.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDetails_Details.ModifyGridRowHeight = False
            Me.DataGridViewDetails_Details.MultiSelect = True
            Me.DataGridViewDetails_Details.Name = "DataGridViewDetails_Details"
            Me.DataGridViewDetails_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDetails_Details.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDetails_Details.ShowRowSelectionIfHidden = True
            Me.DataGridViewDetails_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDetails_Details.Size = New System.Drawing.Size(959, 420)
            Me.DataGridViewDetails_Details.TabIndex = 3
            Me.DataGridViewDetails_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDetails_Details.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_ContactsDocumentSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContactsDocumentSettings_Save, Me.ButtonItemContactsDocumentSettings_ContactTypes, Me.ButtonItemContactsDocumentSettings_DocumentTypes, Me.ButtonItemSendTo_AlertRecipients})
            Me.RibbonBarOptions_ContactsDocumentSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ContactsDocumentSettings.Location = New System.Drawing.Point(316, 0)
            Me.RibbonBarOptions_ContactsDocumentSettings.Name = "RibbonBarOptions_ContactsDocumentSettings"
            Me.RibbonBarOptions_ContactsDocumentSettings.SecurityEnabled = True
            Me.RibbonBarOptions_ContactsDocumentSettings.Size = New System.Drawing.Size(336, 95)
            Me.RibbonBarOptions_ContactsDocumentSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ContactsDocumentSettings.TabIndex = 22
            Me.RibbonBarOptions_ContactsDocumentSettings.Text = "Send To"
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
            Me.ButtonItemContactsDocumentSettings_DocumentTypes.Visible = False
            '
            'ButtonItemSendTo_AlertRecipients
            '
            Me.ButtonItemSendTo_AlertRecipients.BeginGroup = True
            Me.ButtonItemSendTo_AlertRecipients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSendTo_AlertRecipients.Name = "ButtonItemSendTo_AlertRecipients"
            Me.ButtonItemSendTo_AlertRecipients.RibbonWordWrap = False
            Me.ButtonItemSendTo_AlertRecipients.SecurityEnabled = True
            Me.ButtonItemSendTo_AlertRecipients.SubItemsExpandWidth = 14
            Me.ButtonItemSendTo_AlertRecipients.Text = "Alert Recipients"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Recipients})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(231, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(85, 95)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 23
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemView_Recipients
            '
            Me.ButtonItemView_Recipients.BeginGroup = True
            Me.ButtonItemView_Recipients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Recipients.Name = "ButtonItemView_Recipients"
            Me.ButtonItemView_Recipients.RibbonWordWrap = False
            Me.ButtonItemView_Recipients.SecurityEnabled = True
            Me.ButtonItemView_Recipients.SubItemsExpandWidth = 14
            Me.ButtonItemView_Recipients.Text = "Recipients"
            '
            'MediaTrafficGenerateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(995, 609)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTrafficGenerateDialog"
            Me.Text = "Media Traffic Generate"
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
        Friend WithEvents ButtonItemAvailLines_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Generate As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewDetails_Details As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_ContactsDocumentSettings As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContactsDocumentSettings_ContactTypes As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_DocumentTypes As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContactsDocumentSettings_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_Recipients As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSendTo_AlertRecipients As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace