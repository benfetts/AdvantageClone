Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetOrderStatusDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetOrderStatusDialog))
            Me.TabControlPanel_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVendors_Vendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendors_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Vendors = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelStatus_Status = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewStatus_Statuses = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Status = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarFilePanel_Display = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainerDisplay = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemDisplay_HighestRevisionOnly = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDisplay_MostRecentStatus = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_View = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemView_Responses = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_Tabs.SuspendLayout()
            Me.TabControlPanelVendors_Vendors.SuspendLayout()
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Display)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_View)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Display, 0)
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
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Vendors)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Status)
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
            Me.DataGridViewVendors_Vendors.ItemDescription = "Vendor Status(es)"
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
            'RibbonBarFilePanel_Display
            '
            Me.RibbonBarFilePanel_Display.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Display.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Display.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Display.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Display.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Display.DragDropSupport = True
            Me.RibbonBarFilePanel_Display.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDisplay})
            Me.RibbonBarFilePanel_Display.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Display.Location = New System.Drawing.Point(206, 0)
            Me.RibbonBarFilePanel_Display.Name = "RibbonBarFilePanel_Display"
            Me.RibbonBarFilePanel_Display.Size = New System.Drawing.Size(183, 92)
            Me.RibbonBarFilePanel_Display.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Display.TabIndex = 2
            Me.RibbonBarFilePanel_Display.Text = "Display"
            '
            '
            '
            Me.RibbonBarFilePanel_Display.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Display.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerDisplay
            '
            '
            '
            '
            Me.ItemContainerDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDisplay.BeginGroup = True
            Me.ItemContainerDisplay.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDisplay.Name = "ItemContainerDisplay"
            Me.ItemContainerDisplay.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDisplay_HighestRevisionOnly, Me.ButtonItemDisplay_MostRecentStatus, Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine})
            '
            '
            '
            Me.ItemContainerDisplay.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDisplay.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDisplay_HighestRevisionOnly
            '
            Me.ButtonItemDisplay_HighestRevisionOnly.Name = "ButtonItemDisplay_HighestRevisionOnly"
            Me.ButtonItemDisplay_HighestRevisionOnly.SecurityEnabled = True
            Me.ButtonItemDisplay_HighestRevisionOnly.SubItemsExpandWidth = 14
            Me.ButtonItemDisplay_HighestRevisionOnly.Text = "Highest Revision Only"
            '
            'ButtonItemDisplay_MostRecentStatus
            '
            Me.ButtonItemDisplay_MostRecentStatus.Name = "ButtonItemDisplay_MostRecentStatus"
            Me.ButtonItemDisplay_MostRecentStatus.SecurityEnabled = True
            Me.ButtonItemDisplay_MostRecentStatus.SubItemsExpandWidth = 14
            Me.ButtonItemDisplay_MostRecentStatus.Text = "Most Recent Status"
            '
            'ButtonItemDisplay_MostRecentStatusByWorksheetLine
            '
            Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine.Name = "ButtonItemDisplay_MostRecentStatusByWorksheetLine"
            Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine.SecurityEnabled = True
            Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine.SubItemsExpandWidth = 14
            Me.ButtonItemDisplay_MostRecentStatusByWorksheetLine.Text = "Most Recent Status by WS Line"
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
            Me.RibbonBarFilePanel_View.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_View.Name = "RibbonBarFilePanel_View"
            Me.RibbonBarFilePanel_View.Size = New System.Drawing.Size(103, 92)
            Me.RibbonBarFilePanel_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_View.TabIndex = 21
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
            'MediaBroadcastWorksheetOrderStatusDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(995, 609)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetOrderStatusDialog"
            Me.Text = "Media Broadcast Worksheet Order Status"
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
            Me.TabControlPanelStatus_Status.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlPanel_Tabs As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVendors_Vendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Vendors As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewVendors_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelStatus_Status As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Status As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewStatus_Statuses As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarFilePanel_Display As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainerDisplay As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemDisplay_HighestRevisionOnly As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFilePanel_View As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemView_Responses As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDisplay_MostRecentStatus As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDisplay_MostRecentStatusByWorksheetLine As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace