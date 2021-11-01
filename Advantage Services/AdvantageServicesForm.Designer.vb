<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageServicesForm
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageServicesForm))
        Me.StyleManager = New DevComponents.DotNetBar.StyleManager()
        Me.RibbonControlForm_MainRibbon = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanelFile_FilePanel = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarFilePanel_Log = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemLog_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.RibbonBarFilePanel_Settings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemSettings_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.RibbonBarFilePanel_Service = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemService_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemService_Start = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemService_Stop = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemService_Enabled = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemService_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemService_QuickManage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.RibbonBarFilePanel_DatabaseProfiles = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItemSearch_Month = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ButtonItemDatabaseProfiles_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.RibbonBarFilePanel_System = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemSystem_Exit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemSystem_Hide = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.Office2007StartButtonMainRibbon_Home = New DevComponents.DotNetBar.Office2007StartButton()
        Me.RibbonTabItemMainRibbon_File = New DevComponents.DotNetBar.RibbonTabItem()
        Me.ButtonItemMainRibbon_Help = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemMainRibbon_ShowAndHide = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.NotifyIconForm_NotifyIcon = New System.Windows.Forms.NotifyIcon()
        Me.ContextMenuStripForm_Menu = New AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip()
        Me.ToolStripMenuItemMenu_ShowLogAndSettings = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem()
        Me.ToolStripSeparatorMenu_FirstSeparator = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripSeparator()
        Me.ToolStripMenuItemMenu_ShutDown = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem()
        Me.AdvantageServicesSettingsForm_Settings = New AdvantageFramework.WinForm.Presentation.Controls.AdvantageServicesSettingsControl()
        Me.RibbonControlForm_MainRibbon.SuspendLayout()
        Me.RibbonPanelFile_FilePanel.SuspendLayout()
        Me.RibbonBarFilePanel_DatabaseProfiles.SuspendLayout()
        Me.ContextMenuStripForm_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager
        '
        Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'RibbonControlForm_MainRibbon
        '
        Me.RibbonControlForm_MainRibbon.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControlForm_MainRibbon.CanCustomize = False
        Me.RibbonControlForm_MainRibbon.CaptionVisible = True
        Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanelFile_FilePanel)
        Me.RibbonControlForm_MainRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControlForm_MainRibbon.EnableQatPlacement = False
        Me.RibbonControlForm_MainRibbon.ForeColor = System.Drawing.Color.Black
        Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home, Me.RibbonTabItemMainRibbon_File, Me.ButtonItemMainRibbon_Help, Me.ButtonItemMainRibbon_ShowAndHide})
        Me.RibbonControlForm_MainRibbon.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControlForm_MainRibbon.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControlForm_MainRibbon.MdiSystemItemVisible = False
        Me.RibbonControlForm_MainRibbon.Name = "RibbonControlForm_MainRibbon"
        Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(968, 154)
        Me.RibbonControlForm_MainRibbon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        Me.RibbonControlForm_MainRibbon.TabGroupHeight = 14
        Me.RibbonControlForm_MainRibbon.TabGroupsVisible = True
        Me.RibbonControlForm_MainRibbon.TabIndex = 1
        '
        'RibbonPanelFile_FilePanel
        '
        Me.RibbonPanelFile_FilePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Log)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Settings)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Service)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_DatabaseProfiles)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_System)
        Me.RibbonPanelFile_FilePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 55)
        Me.RibbonPanelFile_FilePanel.Name = "RibbonPanelFile_FilePanel"
        Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(968, 99)
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
        Me.RibbonPanelFile_FilePanel.TabIndex = 1
        '
        'RibbonBarFilePanel_Log
        '
        Me.RibbonBarFilePanel_Log.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_Log.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Log.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Log.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_Log.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_Log.DragDropSupport = True
        Me.RibbonBarFilePanel_Log.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_Log.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemLog_Refresh})
        Me.RibbonBarFilePanel_Log.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_Log.Location = New System.Drawing.Point(876, 0)
        Me.RibbonBarFilePanel_Log.Name = "RibbonBarFilePanel_Log"
        Me.RibbonBarFilePanel_Log.SecurityEnabled = True
        Me.RibbonBarFilePanel_Log.Size = New System.Drawing.Size(100, 97)
        Me.RibbonBarFilePanel_Log.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_Log.TabIndex = 5
        Me.RibbonBarFilePanel_Log.Text = "Log"
        '
        '
        '
        Me.RibbonBarFilePanel_Log.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Log.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Log.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemLog_Refresh
        '
        Me.ButtonItemLog_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemLog_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemLog_Refresh.Name = "ButtonItemLog_Refresh"
        Me.ButtonItemLog_Refresh.SecurityEnabled = True
        Me.ButtonItemLog_Refresh.SubItemsExpandWidth = 14
        Me.ButtonItemLog_Refresh.Text = "Refresh"
        '
        'RibbonBarFilePanel_Settings
        '
        Me.RibbonBarFilePanel_Settings.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Settings.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_Settings.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_Settings.DragDropSupport = True
        Me.RibbonBarFilePanel_Settings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_Settings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSettings_Save})
        Me.RibbonBarFilePanel_Settings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_Settings.Location = New System.Drawing.Point(776, 0)
        Me.RibbonBarFilePanel_Settings.Name = "RibbonBarFilePanel_Settings"
        Me.RibbonBarFilePanel_Settings.SecurityEnabled = True
        Me.RibbonBarFilePanel_Settings.Size = New System.Drawing.Size(100, 97)
        Me.RibbonBarFilePanel_Settings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_Settings.TabIndex = 3
        Me.RibbonBarFilePanel_Settings.Text = "Settings"
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Settings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemSettings_Save
        '
        Me.ButtonItemSettings_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemSettings_Save.Name = "ButtonItemSettings_Save"
        Me.ButtonItemSettings_Save.SecurityEnabled = True
        Me.ButtonItemSettings_Save.SubItemsExpandWidth = 14
        Me.ButtonItemSettings_Save.Text = "Save"
        '
        'RibbonBarFilePanel_Service
        '
        Me.RibbonBarFilePanel_Service.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_Service.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Service.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Service.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_Service.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_Service.DragDropSupport = True
        Me.RibbonBarFilePanel_Service.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_Service.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemService_AutoStart, Me.ButtonItemService_Start, Me.ButtonItemService_Stop, Me.ButtonItemService_Enabled, Me.ButtonItemService_ProcessNow, Me.ButtonItemService_QuickManage})
        Me.RibbonBarFilePanel_Service.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_Service.Location = New System.Drawing.Point(439, 0)
        Me.RibbonBarFilePanel_Service.Name = "RibbonBarFilePanel_Service"
        Me.RibbonBarFilePanel_Service.SecurityEnabled = True
        Me.RibbonBarFilePanel_Service.Size = New System.Drawing.Size(337, 97)
        Me.RibbonBarFilePanel_Service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_Service.TabIndex = 6
        Me.RibbonBarFilePanel_Service.Text = "Service"
        '
        '
        '
        Me.RibbonBarFilePanel_Service.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Service.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Service.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemService_AutoStart
        '
        Me.ButtonItemService_AutoStart.AutoCheckOnClick = True
        Me.ButtonItemService_AutoStart.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_AutoStart.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_AutoStart.Name = "ButtonItemService_AutoStart"
        Me.ButtonItemService_AutoStart.SecurityEnabled = True
        Me.ButtonItemService_AutoStart.SubItemsExpandWidth = 14
        Me.ButtonItemService_AutoStart.Text = "Auto Start"
        '
        'ButtonItemService_Start
        '
        Me.ButtonItemService_Start.BeginGroup = True
        Me.ButtonItemService_Start.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_Start.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_Start.Name = "ButtonItemService_Start"
        Me.ButtonItemService_Start.SecurityEnabled = True
        Me.ButtonItemService_Start.SubItemsExpandWidth = 14
        Me.ButtonItemService_Start.Text = "Start"
        '
        'ButtonItemService_Stop
        '
        Me.ButtonItemService_Stop.BeginGroup = True
        Me.ButtonItemService_Stop.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_Stop.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_Stop.Name = "ButtonItemService_Stop"
        Me.ButtonItemService_Stop.SecurityEnabled = True
        Me.ButtonItemService_Stop.SubItemsExpandWidth = 14
        Me.ButtonItemService_Stop.Text = "Stop"
        '
        'ButtonItemService_Enabled
        '
        Me.ButtonItemService_Enabled.BeginGroup = True
        Me.ButtonItemService_Enabled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_Enabled.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_Enabled.Name = "ButtonItemService_Enabled"
        Me.ButtonItemService_Enabled.SecurityEnabled = True
        Me.ButtonItemService_Enabled.SubItemsExpandWidth = 14
        Me.ButtonItemService_Enabled.Text = "Enabled"
        '
        'ButtonItemService_ProcessNow
        '
        Me.ButtonItemService_ProcessNow.BeginGroup = True
        Me.ButtonItemService_ProcessNow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_ProcessNow.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_ProcessNow.Name = "ButtonItemService_ProcessNow"
        Me.ButtonItemService_ProcessNow.SecurityEnabled = True
        Me.ButtonItemService_ProcessNow.SubItemsExpandWidth = 14
        Me.ButtonItemService_ProcessNow.Text = "Process Now"
        '
        'ButtonItemService_QuickManage
        '
        Me.ButtonItemService_QuickManage.BeginGroup = True
        Me.ButtonItemService_QuickManage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemService_QuickManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemService_QuickManage.Name = "ButtonItemService_QuickManage"
        Me.ButtonItemService_QuickManage.SecurityEnabled = True
        Me.ButtonItemService_QuickManage.SubItemsExpandWidth = 14
        Me.ButtonItemService_QuickManage.Text = "Quick Manage"
        '
        'RibbonBarFilePanel_DatabaseProfiles
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.AutoOverflowEnabled = False
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_DatabaseProfiles.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_DatabaseProfiles.Controls.Add(Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile)
        Me.RibbonBarFilePanel_DatabaseProfiles.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_DatabaseProfiles.DragDropSupport = True
        Me.RibbonBarFilePanel_DatabaseProfiles.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDatabaseProfiles_DatabaseProfiles, Me.ButtonItemDatabaseProfiles_Manage})
        Me.RibbonBarFilePanel_DatabaseProfiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_DatabaseProfiles.Location = New System.Drawing.Point(103, 0)
        Me.RibbonBarFilePanel_DatabaseProfiles.MinimumSize = New System.Drawing.Size(125, 0)
        Me.RibbonBarFilePanel_DatabaseProfiles.Name = "RibbonBarFilePanel_DatabaseProfiles"
        Me.RibbonBarFilePanel_DatabaseProfiles.SecurityEnabled = True
        Me.RibbonBarFilePanel_DatabaseProfiles.Size = New System.Drawing.Size(336, 97)
        Me.RibbonBarFilePanel_DatabaseProfiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_DatabaseProfiles.TabIndex = 4
        Me.RibbonBarFilePanel_DatabaseProfiles.Text = "Database Profiles"
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_DatabaseProfiles.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile
        '
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.AutoFindItemInDataSource = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.AutoSelectSingleItemDatasource = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.BookmarkingEnabled = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ClientCode = ""
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DisableMouseWheel = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DisplayMember = "Name1"
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DisplayName = ""
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DivisionCode = ""
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.FocusHighlightEnabled = True
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.FormattingEnabled = True
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ItemHeight = 14
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.Location = New System.Drawing.Point(63, 32)
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.Name = "ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile"
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ReadOnly = False
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.SecurityEnabled = True
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.Size = New System.Drawing.Size(200, 20)
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.TabIndex = 0
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.TabOnEnter = True
        Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.ValueMember = "Name"
        '
        'ItemContainerDatabaseProfiles_DatabaseProfiles
        '
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.Name = "ItemContainerDatabaseProfiles_DatabaseProfiles"
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile})
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerDatabaseProfiles_DatabaseProfiles.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ItemContainerDatabaseProfiles_CurrentDatabaseProfile
        '
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.Name = "ItemContainerDatabaseProfiles_CurrentDatabaseProfile"
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile, Me.ControlContainerItemSearch_Month})
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile
        '
        Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Name = "LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile"
        Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Text = "Current:"
        Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Width = 58
        '
        'ControlContainerItemSearch_Month
        '
        Me.ControlContainerItemSearch_Month.AllowItemResize = True
        Me.ControlContainerItemSearch_Month.Control = Me.ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile
        Me.ControlContainerItemSearch_Month.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItemSearch_Month.Name = "ControlContainerItemSearch_Month"
        Me.ControlContainerItemSearch_Month.Text = "ControlContainerItem2"
        '
        'ButtonItemDatabaseProfiles_Manage
        '
        Me.ButtonItemDatabaseProfiles_Manage.BeginGroup = True
        Me.ButtonItemDatabaseProfiles_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemDatabaseProfiles_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemDatabaseProfiles_Manage.Name = "ButtonItemDatabaseProfiles_Manage"
        Me.ButtonItemDatabaseProfiles_Manage.SecurityEnabled = True
        Me.ButtonItemDatabaseProfiles_Manage.SubItemsExpandWidth = 14
        Me.ButtonItemDatabaseProfiles_Manage.Text = "Manage"
        '
        'RibbonBarFilePanel_System
        '
        Me.RibbonBarFilePanel_System.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_System.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_System.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_System.DragDropSupport = True
        Me.RibbonBarFilePanel_System.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSystem_Exit, Me.ButtonItemSystem_Hide})
        Me.RibbonBarFilePanel_System.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.RibbonBarFilePanel_System.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarFilePanel_System.Name = "RibbonBarFilePanel_System"
        Me.RibbonBarFilePanel_System.SecurityEnabled = True
        Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 97)
        Me.RibbonBarFilePanel_System.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_System.TabIndex = 0
        Me.RibbonBarFilePanel_System.Text = "System"
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_System.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemSystem_Exit
        '
        Me.ButtonItemSystem_Exit.BeginGroup = True
        Me.ButtonItemSystem_Exit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSystem_Exit.FixedSize = New System.Drawing.Size(90, 20)
        Me.ButtonItemSystem_Exit.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemSystem_Exit.Name = "ButtonItemSystem_Exit"
        Me.ButtonItemSystem_Exit.SecurityEnabled = True
        Me.ButtonItemSystem_Exit.Stretch = True
        Me.ButtonItemSystem_Exit.SubItemsExpandWidth = 14
        Me.ButtonItemSystem_Exit.Text = "Exit"
        '
        'ButtonItemSystem_Hide
        '
        Me.ButtonItemSystem_Hide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSystem_Hide.Name = "ButtonItemSystem_Hide"
        Me.ButtonItemSystem_Hide.SecurityEnabled = True
        Me.ButtonItemSystem_Hide.SubItemsExpandWidth = 14
        Me.ButtonItemSystem_Hide.Text = "Hide"
        '
        'Office2007StartButtonMainRibbon_Home
        '
        Me.Office2007StartButtonMainRibbon_Home.AutoExpandOnClick = True
        Me.Office2007StartButtonMainRibbon_Home.CanCustomize = False
        Me.Office2007StartButtonMainRibbon_Home.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
        Me.Office2007StartButtonMainRibbon_Home.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 0
        Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 1
        Me.Office2007StartButtonMainRibbon_Home.Name = "Office2007StartButtonMainRibbon_Home"
        Me.Office2007StartButtonMainRibbon_Home.ShowSubItems = False
        Me.Office2007StartButtonMainRibbon_Home.Text = "Menu"
        '
        'RibbonTabItemMainRibbon_File
        '
        Me.RibbonTabItemMainRibbon_File.Checked = True
        Me.RibbonTabItemMainRibbon_File.Name = "RibbonTabItemMainRibbon_File"
        Me.RibbonTabItemMainRibbon_File.Panel = Me.RibbonPanelFile_FilePanel
        Me.RibbonTabItemMainRibbon_File.Text = "File"
        '
        'ButtonItemMainRibbon_Help
        '
        Me.ButtonItemMainRibbon_Help.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMainRibbon_Help.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemMainRibbon_Help.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItemMainRibbon_Help.Name = "ButtonItemMainRibbon_Help"
        Me.ButtonItemMainRibbon_Help.SecurityEnabled = True
        '
        'ButtonItemMainRibbon_ShowAndHide
        '
        Me.ButtonItemMainRibbon_ShowAndHide.BeginGroup = True
        Me.ButtonItemMainRibbon_ShowAndHide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMainRibbon_ShowAndHide.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemMainRibbon_ShowAndHide.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItemMainRibbon_ShowAndHide.Name = "ButtonItemMainRibbon_ShowAndHide"
        Me.ButtonItemMainRibbon_ShowAndHide.SecurityEnabled = True
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'NotifyIconForm_NotifyIcon
        '
        Me.NotifyIconForm_NotifyIcon.ContextMenuStrip = Me.ContextMenuStripForm_Menu
        Me.NotifyIconForm_NotifyIcon.Text = "Advantage Services"
        Me.NotifyIconForm_NotifyIcon.Visible = True
        '
        'ContextMenuStripForm_Menu
        '
        Me.ContextMenuStripForm_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMenu_ShowLogAndSettings, Me.ToolStripSeparatorMenu_FirstSeparator, Me.ToolStripMenuItemMenu_ShutDown})
        Me.ContextMenuStripForm_Menu.Name = "ContextMenuStripForm_Menu"
        Me.ContextMenuStripForm_Menu.Size = New System.Drawing.Size(184, 54)
        '
        'ToolStripMenuItemMenu_ShowLogAndSettings
        '
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Name = "ToolStripMenuItemMenu_ShowLogAndSettings"
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Text = "Show Log and Settings"
        '
        'ToolStripSeparatorMenu_FirstSeparator
        '
        Me.ToolStripSeparatorMenu_FirstSeparator.Name = "ToolStripSeparatorMenu_FirstSeparator"
        Me.ToolStripSeparatorMenu_FirstSeparator.Size = New System.Drawing.Size(180, 6)
        '
        'ToolStripMenuItemMenu_ShutDown
        '
        Me.ToolStripMenuItemMenu_ShutDown.Name = "ToolStripMenuItemMenu_ShutDown"
        Me.ToolStripMenuItemMenu_ShutDown.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItemMenu_ShutDown.Text = "Shut Down"
        '
        'AdvantageServicesSettingsForm_Settings
        '
        Me.AdvantageServicesSettingsForm_Settings.BackColor = System.Drawing.Color.White
        Me.AdvantageServicesSettingsForm_Settings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvantageServicesSettingsForm_Settings.Location = New System.Drawing.Point(5, 155)
        Me.AdvantageServicesSettingsForm_Settings.Margin = New System.Windows.Forms.Padding(4)
        Me.AdvantageServicesSettingsForm_Settings.Name = "AdvantageServicesSettingsForm_Settings"
        Me.AdvantageServicesSettingsForm_Settings.Size = New System.Drawing.Size(968, 314)
        Me.AdvantageServicesSettingsForm_Settings.TabIndex = 2
        '
        'AdvantageServicesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 471)
        Me.Controls.Add(Me.AdvantageServicesSettingsForm_Settings)
        Me.Controls.Add(Me.RibbonControlForm_MainRibbon)
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdvantageServicesForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advantage Services"
        Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.PerformLayout()
        Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
        Me.RibbonBarFilePanel_DatabaseProfiles.ResumeLayout(False)
        Me.ContextMenuStripForm_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    Protected Friend WithEvents RibbonControlForm_MainRibbon As DevComponents.DotNetBar.RibbonControl
    Protected Friend WithEvents RibbonPanelFile_FilePanel As DevComponents.DotNetBar.RibbonPanel
    Protected Friend WithEvents RibbonBarFilePanel_System As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Protected Friend WithEvents ButtonItemSystem_Exit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Protected Friend WithEvents Office2007StartButtonMainRibbon_Home As DevComponents.DotNetBar.Office2007StartButton
    Protected Friend WithEvents RibbonTabItemMainRibbon_File As DevComponents.DotNetBar.RibbonTabItem
    Protected Friend WithEvents ButtonItemMainRibbon_Help As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Protected Friend WithEvents ButtonItemMainRibbon_ShowAndHide As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ButtonItemSystem_Hide As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents RibbonBarFilePanel_DatabaseProfiles As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemDatabaseProfiles_Manage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents RibbonBarFilePanel_Settings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemSettings_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents TabControlPanelLogTab_EmailListenerLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxEmailListenerLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents NotifyIconForm_NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripForm_Menu As AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemMenu_ShowLogAndSettings As AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorMenu_FirstSeparator As AdvantageFramework.WinForm.Presentation.Controls.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemMenu_ShutDown As AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem
    Friend WithEvents TabControlPanelCriteriaTab_ExportCriteria As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents DataGridViewExportCriteria_Campaigns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents RibbonBarFilePanel_Log As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemLog_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ItemContainerDatabaseProfiles_DatabaseProfiles As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainerDatabaseProfiles_CurrentDatabaseProfile As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerCurrentDatabaseProfile_CurrentDatabaseProfile As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents ControlContainerItemSearch_Month As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents RibbonBarFilePanel_Service As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemService_Enabled As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ButtonItemService_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents AdvantageServicesSettingsForm_Settings As AdvantageFramework.WinForm.Presentation.Controls.AdvantageServicesSettingsControl
    Private WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents ButtonItemService_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ButtonItemService_Start As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ButtonItemService_Stop As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    Friend WithEvents ButtonItemService_QuickManage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem

End Class
