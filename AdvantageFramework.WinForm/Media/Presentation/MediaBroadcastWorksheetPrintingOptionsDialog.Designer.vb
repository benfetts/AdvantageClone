Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetPrintingOptionsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetPrintingOptionsDialog))
            Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlForm_Options = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridProduction_Settings = New DevExpress.XtraVerticalGrid.VGridControl()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.categoryOutputOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPrintLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLocationCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryFields = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPrintOnHold = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintLineNumber = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintCableNetworkStationCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDaypart = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintLength = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDays = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintStartTime = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintEndTime = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintProgram = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintComments = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintBookend = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintValueAdded = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDefaultRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintTotalSpots = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintTotalDollars = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryPrimary = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.categoryPrimarySpotTV = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPrintPrimaryRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryShare = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryHPUT = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryTVCume = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryTVImpressions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryCPM = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryPrimarySpotRadio = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPrintPrimaryAQHRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryAQH = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryCumeRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryCume = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryPrimaryAll = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPrintPrimaryCPP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryGRP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryReach = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintPrimaryGrossImpressions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categorySecondary = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.categorySecondaryTV = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowSecondaryTVRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryTVShare = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryTVHPUT = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryTVCume = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryTVImpressions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintSecondaryCPM = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categorySecondaryRadio = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowSecondaryRadioAQHRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryRadioAQH = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryRadioCumeRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryRadioCume = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categorySecondaryAll = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowSecondaryAllCPP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryAllGRP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryAllReach = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSecondaryAllGrossImpressions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItem_Worksheet = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.rowOverrideConsolidation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowUseEmployeeSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowUsePrintedDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Options.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_Options)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(613, 524)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(613, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(613, 94)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Visible = False
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 679)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(613, 18)
            '
            'RepositoryItemDateEdit1
            '
            Me.RepositoryItemDateEdit1.AutoHeight = False
            Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(92, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'TabControlForm_Options
            '
            Me.TabControlForm_Options.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Options.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Options.CanReorderTabs = True
            Me.TabControlForm_Options.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_Options.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Options.Location = New System.Drawing.Point(12, 7)
            Me.TabControlForm_Options.Name = "TabControlForm_Options"
            Me.TabControlForm_Options.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Options.SelectedTabIndex = 1
            Me.TabControlForm_Options.Size = New System.Drawing.Size(589, 510)
            Me.TabControlForm_Options.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Options.TabIndex = 2
            Me.TabControlForm_Options.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Options.Tabs.Add(Me.TabItem_Worksheet)
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.VerticalGridProduction_Settings)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(589, 483)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 1
            Me.TabControlPanel1.TabItem = Me.TabItem_Worksheet
            '
            'VerticalGridProduction_Settings
            '
            Me.VerticalGridProduction_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridProduction_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridProduction_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1704, 698, 216, 265)
            Me.VerticalGridProduction_Settings.DataSource = Me.BindingSource
            Me.VerticalGridProduction_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridProduction_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridProduction_Settings.Name = "VerticalGridProduction_Settings"
            Me.VerticalGridProduction_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridProduction_Settings.OptionsMenu.EnableContextMenu = True
            Me.VerticalGridProduction_Settings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit2})
            Me.VerticalGridProduction_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryOutputOptions, Me.categoryFields, Me.categoryPrimary, Me.categorySecondary})
            Me.VerticalGridProduction_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridProduction_Settings.Size = New System.Drawing.Size(581, 475)
            Me.VerticalGridProduction_Settings.TabIndex = 3
            Me.VerticalGridProduction_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)
            '
            'RepositoryItemDateEdit2
            '
            Me.RepositoryItemDateEdit2.AutoHeight = False
            Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
            '
            'categoryOutputOptions
            '
            Me.categoryOutputOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPrintLocation, Me.rowLocationCode})
            Me.categoryOutputOptions.Name = "categoryOutputOptions"
            Me.categoryOutputOptions.Properties.Caption = "Output Options"
            '
            'rowPrintLocation
            '
            Me.rowPrintLocation.Name = "rowPrintLocation"
            Me.rowPrintLocation.Properties.Caption = "Print Location"
            Me.rowPrintLocation.Properties.FieldName = "PrintLocation"
            '
            'rowLocationCode
            '
            Me.rowLocationCode.Name = "rowLocationCode"
            Me.rowLocationCode.Properties.Caption = "Location Code"
            Me.rowLocationCode.Properties.FieldName = "LocationCode"
            '
            'categoryFields
            '
            Me.categoryFields.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPrintOnHold, Me.rowPrintLineNumber, Me.rowPrintCableNetworkStationCode, Me.rowPrintDaypart, Me.rowPrintLength, Me.rowPrintDays, Me.rowPrintStartTime, Me.rowPrintEndTime, Me.rowPrintProgram, Me.rowPrintComments, Me.rowPrintBookend, Me.rowPrintValueAdded, Me.rowPrintDefaultRate, Me.rowPrintTotalSpots, Me.rowPrintTotalDollars})
            Me.categoryFields.Name = "categoryFields"
            Me.categoryFields.Properties.Caption = "Fields"
            '
            'rowPrintOnHold
            '
            Me.rowPrintOnHold.Name = "rowPrintOnHold"
            Me.rowPrintOnHold.Properties.Caption = "On Hold"
            Me.rowPrintOnHold.Properties.FieldName = "PrintOnHold"
            '
            'rowPrintLineNumber
            '
            Me.rowPrintLineNumber.Name = "rowPrintLineNumber"
            Me.rowPrintLineNumber.Properties.Caption = "Line Number"
            Me.rowPrintLineNumber.Properties.FieldName = "PrintLineNumber"
            '
            'rowPrintCableNetworkStationCode
            '
            Me.rowPrintCableNetworkStationCode.Name = "rowPrintCableNetworkStationCode"
            Me.rowPrintCableNetworkStationCode.Properties.Caption = "Cable Network"
            Me.rowPrintCableNetworkStationCode.Properties.FieldName = "PrintCableNetworkStationCode"
            '
            'rowPrintDaypart
            '
            Me.rowPrintDaypart.Name = "rowPrintDaypart"
            Me.rowPrintDaypart.Properties.Caption = "Daypart"
            Me.rowPrintDaypart.Properties.FieldName = "PrintDaypart"
            '
            'rowPrintLength
            '
            Me.rowPrintLength.Name = "rowPrintLength"
            Me.rowPrintLength.Properties.Caption = "Length"
            Me.rowPrintLength.Properties.FieldName = "PrintLength"
            '
            'rowPrintDays
            '
            Me.rowPrintDays.Name = "rowPrintDays"
            Me.rowPrintDays.Properties.Caption = "Days"
            Me.rowPrintDays.Properties.FieldName = "PrintDays"
            '
            'rowPrintStartTime
            '
            Me.rowPrintStartTime.Name = "rowPrintStartTime"
            Me.rowPrintStartTime.Properties.Caption = "Start Time"
            Me.rowPrintStartTime.Properties.FieldName = "PrintStartTime"
            '
            'rowPrintEndTime
            '
            Me.rowPrintEndTime.Name = "rowPrintEndTime"
            Me.rowPrintEndTime.Properties.Caption = "End Time"
            Me.rowPrintEndTime.Properties.FieldName = "PrintEndTime"
            '
            'rowPrintProgram
            '
            Me.rowPrintProgram.Name = "rowPrintProgram"
            Me.rowPrintProgram.Properties.Caption = "Program"
            Me.rowPrintProgram.Properties.FieldName = "PrintProgram"
            '
            'rowPrintComments
            '
            Me.rowPrintComments.Name = "rowPrintComments"
            Me.rowPrintComments.Properties.Caption = "Comments"
            Me.rowPrintComments.Properties.FieldName = "PrintComments"
            '
            'rowPrintBookend
            '
            Me.rowPrintBookend.Name = "rowPrintBookend"
            Me.rowPrintBookend.Properties.Caption = "Bookend"
            Me.rowPrintBookend.Properties.FieldName = "PrintBookend"
            '
            'rowPrintValueAdded
            '
            Me.rowPrintValueAdded.Name = "rowPrintValueAdded"
            Me.rowPrintValueAdded.Properties.Caption = "Added Value"
            Me.rowPrintValueAdded.Properties.FieldName = "PrintValueAdded"
            '
            'rowPrintDefaultRate
            '
            Me.rowPrintDefaultRate.Name = "rowPrintDefaultRate"
            Me.rowPrintDefaultRate.Properties.Caption = "Rate"
            Me.rowPrintDefaultRate.Properties.FieldName = "PrintDefaultRate"
            '
            'rowPrintTotalSpots
            '
            Me.rowPrintTotalSpots.Name = "rowPrintTotalSpots"
            Me.rowPrintTotalSpots.Properties.Caption = "Total Spots"
            Me.rowPrintTotalSpots.Properties.FieldName = "PrintTotalSpots"
            '
            'rowPrintTotalDollars
            '
            Me.rowPrintTotalDollars.Name = "rowPrintTotalDollars"
            Me.rowPrintTotalDollars.Properties.Caption = "Total Dollars"
            Me.rowPrintTotalDollars.Properties.FieldName = "PrintTotalDollars"
            '
            'categoryPrimary
            '
            Me.categoryPrimary.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryPrimarySpotTV, Me.categoryPrimarySpotRadio, Me.categoryPrimaryAll})
            Me.categoryPrimary.Name = "categoryPrimary"
            Me.categoryPrimary.Properties.Caption = "Primary Demos"
            '
            'categoryPrimarySpotTV
            '
            Me.categoryPrimarySpotTV.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPrintPrimaryRating, Me.rowPrintPrimaryShare, Me.rowPrintPrimaryHPUT, Me.rowPrintPrimaryTVCume, Me.rowPrintPrimaryTVImpressions})
            Me.categoryPrimarySpotTV.Name = "categoryPrimarySpotTV"
            Me.categoryPrimarySpotTV.Properties.Caption = "TV"
            '
            'rowPrintPrimaryRating
            '
            Me.rowPrintPrimaryRating.Name = "rowPrintPrimaryRating"
            Me.rowPrintPrimaryRating.Properties.Caption = "Rating"
            Me.rowPrintPrimaryRating.Properties.FieldName = "PrintPrimaryRating"
            '
            'rowPrintPrimaryShare
            '
            Me.rowPrintPrimaryShare.Name = "rowPrintPrimaryShare"
            Me.rowPrintPrimaryShare.Properties.Caption = "Share"
            Me.rowPrintPrimaryShare.Properties.FieldName = "PrintPrimaryShare"
            '
            'rowPrintPrimaryHPUT
            '
            Me.rowPrintPrimaryHPUT.Name = "rowPrintPrimaryHPUT"
            Me.rowPrintPrimaryHPUT.Properties.Caption = "H/PUT"
            Me.rowPrintPrimaryHPUT.Properties.FieldName = "PrintPrimaryHPUT"
            '
            'rowPrintPrimaryTVCume
            '
            Me.rowPrintPrimaryTVCume.Name = "rowPrintPrimaryTVCume"
            Me.rowPrintPrimaryTVCume.Properties.Caption = "Cume"
            Me.rowPrintPrimaryTVCume.Properties.FieldName = "PrintPrimaryTVCume"
            '
            'rowPrintPrimaryTVImpressions
            '
            Me.rowPrintPrimaryTVImpressions.Name = "rowPrintPrimaryTVImpressions"
            Me.rowPrintPrimaryTVImpressions.Properties.Caption = "Impressions"
            Me.rowPrintPrimaryTVImpressions.Properties.FieldName = "PrintPrimaryTVImpressions"
            '
            'rowPrintPrimaryCPM
            '
            Me.rowPrintPrimaryCPM.Name = "rowPrintPrimaryCPM"
            Me.rowPrintPrimaryCPM.Properties.Caption = "CPM"
            Me.rowPrintPrimaryCPM.Properties.FieldName = "PrintPrimaryCPM"
            '
            'categoryPrimarySpotRadio
            '
            Me.categoryPrimarySpotRadio.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPrintPrimaryAQHRating, Me.rowPrintPrimaryAQH, Me.rowPrintPrimaryCumeRating, Me.rowPrintPrimaryCume})
            Me.categoryPrimarySpotRadio.Name = "categoryPrimarySpotRadio"
            Me.categoryPrimarySpotRadio.Properties.Caption = "Radio"
            '
            'rowPrintPrimaryAQHRating
            '
            Me.rowPrintPrimaryAQHRating.Name = "rowPrintPrimaryAQHRating"
            Me.rowPrintPrimaryAQHRating.Properties.Caption = "AQH Rating"
            Me.rowPrintPrimaryAQHRating.Properties.FieldName = "PrintPrimaryAQHRating"
            '
            'rowPrintPrimaryAQH
            '
            Me.rowPrintPrimaryAQH.Name = "rowPrintPrimaryAQH"
            Me.rowPrintPrimaryAQH.Properties.Caption = "AQH (00)"
            Me.rowPrintPrimaryAQH.Properties.FieldName = "PrintPrimaryAQH"
            '
            'rowPrintPrimaryCumeRating
            '
            Me.rowPrintPrimaryCumeRating.Name = "rowPrintPrimaryCumeRating"
            Me.rowPrintPrimaryCumeRating.Properties.Caption = "Cume Rating"
            Me.rowPrintPrimaryCumeRating.Properties.FieldName = "PrintPrimaryCumeRating"
            '
            'rowPrintPrimaryCume
            '
            Me.rowPrintPrimaryCume.Name = "rowPrintPrimaryCume"
            Me.rowPrintPrimaryCume.Properties.Caption = "Cume (00)"
            Me.rowPrintPrimaryCume.Properties.FieldName = "PrintPrimaryCume"
            '
            'categoryPrimaryAll
            '
            Me.categoryPrimaryAll.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPrintPrimaryCPP, Me.rowPrintPrimaryGRP, Me.rowPrintPrimaryReach, Me.rowPrintPrimaryGrossImpressions, Me.rowPrintPrimaryCPM})
            Me.categoryPrimaryAll.Name = "categoryPrimaryAll"
            Me.categoryPrimaryAll.Properties.Caption = "All"
            '
            'rowPrintPrimaryCPP
            '
            Me.rowPrintPrimaryCPP.Name = "rowPrintPrimaryCPP"
            Me.rowPrintPrimaryCPP.Properties.Caption = "CPP"
            Me.rowPrintPrimaryCPP.Properties.FieldName = "PrintPrimaryCPP"
            '
            'rowPrintPrimaryGRP
            '
            Me.rowPrintPrimaryGRP.Name = "rowPrintPrimaryGRP"
            Me.rowPrintPrimaryGRP.Properties.Caption = "GRP"
            Me.rowPrintPrimaryGRP.Properties.FieldName = "PrintPrimaryGRP"
            '
            'rowPrintPrimaryReach
            '
            Me.rowPrintPrimaryReach.Name = "rowPrintPrimaryReach"
            Me.rowPrintPrimaryReach.Properties.Caption = "Reach / Frequency"
            Me.rowPrintPrimaryReach.Properties.FieldName = "PrintPrimaryReach"
            '
            'rowPrintPrimaryGrossImpressions
            '
            Me.rowPrintPrimaryGrossImpressions.Name = "rowPrintPrimaryGrossImpressions"
            Me.rowPrintPrimaryGrossImpressions.Properties.Caption = "Gross Impressions"
            Me.rowPrintPrimaryGrossImpressions.Properties.FieldName = "PrintPrimaryGrossImpressions"
            '
            'categorySecondary
            '
            Me.categorySecondary.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categorySecondaryTV, Me.categorySecondaryRadio, Me.categorySecondaryAll})
            Me.categorySecondary.Name = "categorySecondary"
            Me.categorySecondary.Properties.Caption = "Secondary Demos"
            '
            'categorySecondaryTV
            '
            Me.categorySecondaryTV.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSecondaryTVRating, Me.rowSecondaryTVShare, Me.rowSecondaryTVHPUT, Me.rowSecondaryTVCume, Me.rowSecondaryTVImpressions})
            Me.categorySecondaryTV.Height = 17
            Me.categorySecondaryTV.Name = "categorySecondaryTV"
            Me.categorySecondaryTV.Properties.Caption = "TV"
            '
            'rowSecondaryTVRating
            '
            Me.rowSecondaryTVRating.Name = "rowSecondaryTVRating"
            Me.rowSecondaryTVRating.Properties.Caption = "Rating"
            Me.rowSecondaryTVRating.Properties.FieldName = "PrintSecondaryRating"
            '
            'rowSecondaryTVShare
            '
            Me.rowSecondaryTVShare.Name = "rowSecondaryTVShare"
            Me.rowSecondaryTVShare.Properties.Caption = "Share"
            Me.rowSecondaryTVShare.Properties.FieldName = "PrintSecondaryShare"
            '
            'rowSecondaryTVHPUT
            '
            Me.rowSecondaryTVHPUT.Name = "rowSecondaryTVHPUT"
            Me.rowSecondaryTVHPUT.Properties.Caption = "H/PUT"
            Me.rowSecondaryTVHPUT.Properties.FieldName = "PrintSecondaryHPUT"
            '
            'rowSecondaryTVCume
            '
            Me.rowSecondaryTVCume.Name = "rowSecondaryTVCume"
            Me.rowSecondaryTVCume.Properties.Caption = "Cume"
            Me.rowSecondaryTVCume.Properties.FieldName = "PrintSecondaryTVCume"
            '
            'rowSecondaryTVImpressions
            '
            Me.rowSecondaryTVImpressions.Name = "rowSecondaryTVImpressions"
            Me.rowSecondaryTVImpressions.Properties.Caption = "Impressions"
            Me.rowSecondaryTVImpressions.Properties.FieldName = "PrintSecondaryTVImpressions"
            '
            'rowPrintSecondaryCPM
            '
            Me.rowPrintSecondaryCPM.Name = "rowPrintSecondaryCPM"
            Me.rowPrintSecondaryCPM.Properties.Caption = "CPM"
            Me.rowPrintSecondaryCPM.Properties.FieldName = "PrintSecondaryCPM"
            '
            'categorySecondaryRadio
            '
            Me.categorySecondaryRadio.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSecondaryRadioAQHRating, Me.rowSecondaryRadioAQH, Me.rowSecondaryRadioCumeRating, Me.rowSecondaryRadioCume})
            Me.categorySecondaryRadio.Name = "categorySecondaryRadio"
            Me.categorySecondaryRadio.Properties.Caption = "Radio"
            '
            'rowSecondaryRadioAQHRating
            '
            Me.rowSecondaryRadioAQHRating.Name = "rowSecondaryRadioAQHRating"
            Me.rowSecondaryRadioAQHRating.Properties.Caption = "AQH Rating"
            Me.rowSecondaryRadioAQHRating.Properties.FieldName = "PrintSecondaryAQHRating"
            '
            'rowSecondaryRadioAQH
            '
            Me.rowSecondaryRadioAQH.Name = "rowSecondaryRadioAQH"
            Me.rowSecondaryRadioAQH.Properties.Caption = "AQH (00)"
            Me.rowSecondaryRadioAQH.Properties.FieldName = "PrintSecondaryAQH"
            '
            'rowSecondaryRadioCumeRating
            '
            Me.rowSecondaryRadioCumeRating.Name = "rowSecondaryRadioCumeRating"
            Me.rowSecondaryRadioCumeRating.Properties.Caption = "Cume Rating"
            Me.rowSecondaryRadioCumeRating.Properties.FieldName = "PrintSecondaryCumeRating"
            '
            'rowSecondaryRadioCume
            '
            Me.rowSecondaryRadioCume.Name = "rowSecondaryRadioCume"
            Me.rowSecondaryRadioCume.Properties.Caption = "Cume (00)"
            Me.rowSecondaryRadioCume.Properties.FieldName = "PrintSecondaryCume"
            '
            'categorySecondaryAll
            '
            Me.categorySecondaryAll.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSecondaryAllCPP, Me.rowSecondaryAllGRP, Me.rowSecondaryAllReach, Me.rowSecondaryAllGrossImpressions, Me.rowPrintSecondaryCPM})
            Me.categorySecondaryAll.Name = "categorySecondaryAll"
            Me.categorySecondaryAll.Properties.Caption = "All"
            '
            'rowSecondaryAllCPP
            '
            Me.rowSecondaryAllCPP.Name = "rowSecondaryAllCPP"
            Me.rowSecondaryAllCPP.Properties.Caption = "CPP"
            Me.rowSecondaryAllCPP.Properties.FieldName = "PrintSecondaryCPP"
            '
            'rowSecondaryAllGRP
            '
            Me.rowSecondaryAllGRP.Name = "rowSecondaryAllGRP"
            Me.rowSecondaryAllGRP.Properties.Caption = "GRP"
            Me.rowSecondaryAllGRP.Properties.FieldName = "PrintSecondaryGRP"
            '
            'rowSecondaryAllReach
            '
            Me.rowSecondaryAllReach.Name = "rowSecondaryAllReach"
            Me.rowSecondaryAllReach.Properties.Caption = "Reach / Frequency"
            Me.rowSecondaryAllReach.Properties.FieldName = "PrintSecondaryReach"
            '
            'rowSecondaryAllGrossImpressions
            '
            Me.rowSecondaryAllGrossImpressions.Name = "rowSecondaryAllGrossImpressions"
            Me.rowSecondaryAllGrossImpressions.Properties.Caption = "Gross Impressions"
            Me.rowSecondaryAllGrossImpressions.Properties.FieldName = "PrintSecondaryGrossImpressions"
            '
            'TabItem_Worksheet
            '
            Me.TabItem_Worksheet.AttachedControl = Me.TabControlPanel1
            Me.TabItem_Worksheet.Name = "TabItem_Worksheet"
            Me.TabItem_Worksheet.Text = "Worksheet"
            '
            'rowOverrideConsolidation
            '
            Me.rowOverrideConsolidation.Appearance.Options.UseTextOptions = True
            Me.rowOverrideConsolidation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.rowOverrideConsolidation.Height = 17
            Me.rowOverrideConsolidation.Name = "rowOverrideConsolidation"
            Me.rowOverrideConsolidation.Properties.Caption = "Override product consolidation"
            Me.rowOverrideConsolidation.Properties.FieldName = "ConsolidationOverride"
            '
            'rowUseEmployeeSignature
            '
            Me.rowUseEmployeeSignature.Name = "rowUseEmployeeSignature"
            Me.rowUseEmployeeSignature.Properties.Caption = "Use Employee Signature"
            Me.rowUseEmployeeSignature.Properties.FieldName = "UseEmployeeSignature"
            '
            'rowUsePrintedDate
            '
            Me.rowUsePrintedDate.Name = "rowUsePrintedDate"
            Me.rowUsePrintedDate.Properties.Caption = "Use Printed Date"
            Me.rowUsePrintedDate.Properties.FieldName = "DateToPrint"
            '
            'rowDate
            '
            Me.rowDate.Name = "rowDate"
            Me.rowDate.Properties.Caption = "Date"
            Me.rowDate.Properties.FieldName = "DatePrint"
            Me.rowDate.Properties.Format.FormatString = "d"
            Me.rowDate.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.rowDate.Properties.RowEdit = Me.RepositoryItemDateEdit1
            '
            'MediaBroadcastWorksheetPrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(623, 699)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "MediaBroadcastWorksheetPrintingOptionsDialog"
            Me.Text = "Broadcast Worksheet Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Options.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabControlForm_Options As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents rowOverrideConsolidation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowUseEmployeeSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents TabItem_Worksheet As DevComponents.DotNetBar.TabItem
        Friend WithEvents rowUsePrintedDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents VerticalGridProduction_Settings As DevExpress.XtraVerticalGrid.VGridControl
        Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents categoryOutputOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowPrintLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLocationCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryFields As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowPrintPrimaryGrossImpressions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintOnHold As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintLineNumber As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryReach As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintCableNetworkStationCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryCume As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDaypart As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryCumeRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintLength As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryAQH As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDays As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryGRP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintStartTime As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryCPP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintEndTime As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryAQHRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintProgram As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryHPUT As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintComments As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryShare As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintBookend As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintValueAdded As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintTotalDollars As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDefaultRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintTotalSpots As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryPrimary As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categoryPrimarySpotRadio As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categoryPrimaryAll As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categoryPrimarySpotTV As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categorySecondary As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categorySecondaryTV As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSecondaryTVShare As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryTVRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryTVHPUT As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categorySecondaryRadio As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSecondaryRadioAQHRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryRadioCume As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryRadioCumeRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryRadioAQH As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categorySecondaryAll As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSecondaryAllCPP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryAllGRP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryAllGrossImpressions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryAllReach As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryTVImpressions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryTVCume As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryTVImpressions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSecondaryTVCume As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintPrimaryCPM As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintSecondaryCPM As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

