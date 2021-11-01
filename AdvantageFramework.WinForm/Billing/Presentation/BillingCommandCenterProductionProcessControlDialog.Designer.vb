Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionProcessControlDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionProcessControlDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxProcessControl_JobProcess = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_ProcessControl = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemProcessControl_JobProcess = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemProcessControl_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProcessControl_CloseQualified = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ScheduleStatus = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxScheduleStatus_Status = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_ScheduleStatus = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemScheduleStatus_Status = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemScheduleStatus_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_ProductionProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonItemProcessControl_ClearComments = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_ProcessControl.SuspendLayout()
            Me.RibbonBarOptions_ScheduleStatus.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ProductionProcessControl)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ScheduleStatus)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ProcessControl)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_GridOptions)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_GridOptions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ProcessControl, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ScheduleStatus, 0)
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(91, 92)
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
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptions_ChooseColumns, Me.ButtonItemGridOptions_RestoreDefaults})
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(146, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(143, 92)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 14
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptions_ChooseColumns
            '
            Me.ButtonItemGridOptions_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptions_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_ChooseColumns.Name = "ButtonItemGridOptions_ChooseColumns"
            Me.ButtonItemGridOptions_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptions_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptions_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptions_RestoreDefaults
            '
            Me.ButtonItemGridOptions_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptions_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_RestoreDefaults.Name = "ButtonItemGridOptions_RestoreDefaults"
            Me.ButtonItemGridOptions_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptions_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptions_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_ProcessControl
            '
            Me.RibbonBarOptions_ProcessControl.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ProcessControl.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessControl.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ProcessControl.Controls.Add(Me.ComboBoxProcessControl_JobProcess)
            Me.RibbonBarOptions_ProcessControl.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ProcessControl.DragDropSupport = True
            Me.RibbonBarOptions_ProcessControl.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ProcessControl, Me.ButtonItemProcessControl_ClearComments, Me.ButtonItemProcessControl_CloseQualified})
            Me.RibbonBarOptions_ProcessControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProcessControl.Location = New System.Drawing.Point(289, 0)
            Me.RibbonBarOptions_ProcessControl.Name = "RibbonBarOptions_ProcessControl"
            Me.RibbonBarOptions_ProcessControl.SecurityEnabled = True
            Me.RibbonBarOptions_ProcessControl.Size = New System.Drawing.Size(365, 92)
            Me.RibbonBarOptions_ProcessControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ProcessControl.TabIndex = 15
            Me.RibbonBarOptions_ProcessControl.Text = "Process Control"
            '
            '
            '
            Me.RibbonBarOptions_ProcessControl.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessControl.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessControl.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxProcessControl_JobProcess
            '
            Me.ComboBoxProcessControl_JobProcess.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProcessControl_JobProcess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProcessControl_JobProcess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProcessControl_JobProcess.AutoFindItemInDataSource = False
            Me.ComboBoxProcessControl_JobProcess.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProcessControl_JobProcess.BookmarkingEnabled = False
            Me.ComboBoxProcessControl_JobProcess.ClientCode = ""
            Me.ComboBoxProcessControl_JobProcess.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobProcess
            Me.ComboBoxProcessControl_JobProcess.DisableMouseWheel = False
            Me.ComboBoxProcessControl_JobProcess.DisplayMember = "Description"
            Me.ComboBoxProcessControl_JobProcess.DisplayName = "Process Control"
            Me.ComboBoxProcessControl_JobProcess.DivisionCode = ""
            Me.ComboBoxProcessControl_JobProcess.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProcessControl_JobProcess.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProcessControl_JobProcess.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxProcessControl_JobProcess.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProcessControl_JobProcess.FocusHighlightEnabled = True
            Me.ComboBoxProcessControl_JobProcess.FormattingEnabled = True
            Me.ComboBoxProcessControl_JobProcess.ItemHeight = 15
            Me.ComboBoxProcessControl_JobProcess.Location = New System.Drawing.Point(6, 4)
            Me.ComboBoxProcessControl_JobProcess.Name = "ComboBoxProcessControl_JobProcess"
            Me.ComboBoxProcessControl_JobProcess.ReadOnly = False
            Me.ComboBoxProcessControl_JobProcess.SecurityEnabled = True
            Me.ComboBoxProcessControl_JobProcess.Size = New System.Drawing.Size(133, 21)
            Me.ComboBoxProcessControl_JobProcess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProcessControl_JobProcess.TabIndex = 7
            Me.ComboBoxProcessControl_JobProcess.TabOnEnter = True
            Me.ComboBoxProcessControl_JobProcess.ValueMember = "ID"
            Me.ComboBoxProcessControl_JobProcess.WatermarkText = "Select Job Process"
            '
            'ItemContainerVertical_ProcessControl
            '
            '
            '
            '
            Me.ItemContainerVertical_ProcessControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ProcessControl.BeginGroup = True
            Me.ItemContainerVertical_ProcessControl.FixedSize = New System.Drawing.Size(140, 0)
            Me.ItemContainerVertical_ProcessControl.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ProcessControl.Name = "ItemContainerVertical_ProcessControl"
            Me.ItemContainerVertical_ProcessControl.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemProcessControl_JobProcess, Me.ButtonItemProcessControl_MarkSelected})
            '
            '
            '
            Me.ItemContainerVertical_ProcessControl.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemProcessControl_JobProcess
            '
            Me.ControlContainerItemProcessControl_JobProcess.AllowItemResize = True
            Me.ControlContainerItemProcessControl_JobProcess.BeginGroup = True
            Me.ControlContainerItemProcessControl_JobProcess.Control = Me.ComboBoxProcessControl_JobProcess
            Me.ControlContainerItemProcessControl_JobProcess.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ControlContainerItemProcessControl_JobProcess.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemProcessControl_JobProcess.Name = "ControlContainerItemProcessControl_JobProcess"
            '
            'ButtonItemProcessControl_MarkSelected
            '
            Me.ButtonItemProcessControl_MarkSelected.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemProcessControl_MarkSelected.Name = "ButtonItemProcessControl_MarkSelected"
            Me.ButtonItemProcessControl_MarkSelected.Text = "Mark Selected"
            '
            'ButtonItemProcessControl_CloseQualified
            '
            Me.ButtonItemProcessControl_CloseQualified.BeginGroup = True
            Me.ButtonItemProcessControl_CloseQualified.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessControl_CloseQualified.Name = "ButtonItemProcessControl_CloseQualified"
            Me.ButtonItemProcessControl_CloseQualified.RibbonWordWrap = False
            Me.ButtonItemProcessControl_CloseQualified.SecurityEnabled = True
            Me.ButtonItemProcessControl_CloseQualified.SubItemsExpandWidth = 14
            Me.ButtonItemProcessControl_CloseQualified.Text = "Close Qualified"
            '
            'RibbonBarOptions_ScheduleStatus
            '
            Me.RibbonBarOptions_ScheduleStatus.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ScheduleStatus.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ScheduleStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ScheduleStatus.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ScheduleStatus.Controls.Add(Me.ComboBoxScheduleStatus_Status)
            Me.RibbonBarOptions_ScheduleStatus.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ScheduleStatus.DragDropSupport = True
            Me.RibbonBarOptions_ScheduleStatus.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ScheduleStatus})
            Me.RibbonBarOptions_ScheduleStatus.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ScheduleStatus.Location = New System.Drawing.Point(654, 0)
            Me.RibbonBarOptions_ScheduleStatus.Name = "RibbonBarOptions_ScheduleStatus"
            Me.RibbonBarOptions_ScheduleStatus.SecurityEnabled = True
            Me.RibbonBarOptions_ScheduleStatus.Size = New System.Drawing.Size(169, 92)
            Me.RibbonBarOptions_ScheduleStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ScheduleStatus.TabIndex = 16
            Me.RibbonBarOptions_ScheduleStatus.Text = "Schedule Status"
            '
            '
            '
            Me.RibbonBarOptions_ScheduleStatus.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ScheduleStatus.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ScheduleStatus.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxScheduleStatus_Status
            '
            Me.ComboBoxScheduleStatus_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxScheduleStatus_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxScheduleStatus_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxScheduleStatus_Status.AutoFindItemInDataSource = False
            Me.ComboBoxScheduleStatus_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxScheduleStatus_Status.BookmarkingEnabled = False
            Me.ComboBoxScheduleStatus_Status.ClientCode = ""
            Me.ComboBoxScheduleStatus_Status.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Status
            Me.ComboBoxScheduleStatus_Status.DisableMouseWheel = False
            Me.ComboBoxScheduleStatus_Status.DisplayMember = "Description"
            Me.ComboBoxScheduleStatus_Status.DisplayName = "Process Control"
            Me.ComboBoxScheduleStatus_Status.DivisionCode = ""
            Me.ComboBoxScheduleStatus_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxScheduleStatus_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxScheduleStatus_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxScheduleStatus_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxScheduleStatus_Status.FocusHighlightEnabled = True
            Me.ComboBoxScheduleStatus_Status.FormattingEnabled = True
            Me.ComboBoxScheduleStatus_Status.ItemHeight = 15
            Me.ComboBoxScheduleStatus_Status.Location = New System.Drawing.Point(6, 4)
            Me.ComboBoxScheduleStatus_Status.Name = "ComboBoxScheduleStatus_Status"
            Me.ComboBoxScheduleStatus_Status.ReadOnly = False
            Me.ComboBoxScheduleStatus_Status.SecurityEnabled = True
            Me.ComboBoxScheduleStatus_Status.Size = New System.Drawing.Size(150, 21)
            Me.ComboBoxScheduleStatus_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxScheduleStatus_Status.TabIndex = 7
            Me.ComboBoxScheduleStatus_Status.TabOnEnter = True
            Me.ComboBoxScheduleStatus_Status.ValueMember = "Code"
            Me.ComboBoxScheduleStatus_Status.WatermarkText = "Select Status"
            '
            'ItemContainerVertical_ScheduleStatus
            '
            '
            '
            '
            Me.ItemContainerVertical_ScheduleStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ScheduleStatus.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ScheduleStatus.Name = "ItemContainerVertical_ScheduleStatus"
            Me.ItemContainerVertical_ScheduleStatus.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemScheduleStatus_Status, Me.ButtonItemScheduleStatus_MarkSelected})
            '
            '
            '
            Me.ItemContainerVertical_ScheduleStatus.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemScheduleStatus_Status
            '
            Me.ControlContainerItemScheduleStatus_Status.AllowItemResize = True
            Me.ControlContainerItemScheduleStatus_Status.Control = Me.ComboBoxScheduleStatus_Status
            Me.ControlContainerItemScheduleStatus_Status.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemScheduleStatus_Status.Name = "ControlContainerItemScheduleStatus_Status"
            Me.ControlContainerItemScheduleStatus_Status.Text = "ControlContainerItem3"
            '
            'ButtonItemScheduleStatus_MarkSelected
            '
            Me.ButtonItemScheduleStatus_MarkSelected.BeginGroup = True
            Me.ButtonItemScheduleStatus_MarkSelected.Name = "ButtonItemScheduleStatus_MarkSelected"
            Me.ButtonItemScheduleStatus_MarkSelected.Text = "Mark Selected"
            '
            'DataGridViewForm_ProductionProcessControl
            '
            Me.DataGridViewForm_ProductionProcessControl.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProductionProcessControl.AllowDragAndDrop = False
            Me.DataGridViewForm_ProductionProcessControl.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProductionProcessControl.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProductionProcessControl.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProductionProcessControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ProductionProcessControl.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProductionProcessControl.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_ProductionProcessControl.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProductionProcessControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ProductionProcessControl.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProductionProcessControl.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProductionProcessControl.ItemDescription = "Job Component(s)"
            Me.DataGridViewForm_ProductionProcessControl.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewForm_ProductionProcessControl.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ProductionProcessControl.MultiSelect = True
            Me.DataGridViewForm_ProductionProcessControl.Name = "DataGridViewForm_ProductionProcessControl"
            Me.DataGridViewForm_ProductionProcessControl.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProductionProcessControl.RunStandardValidation = True
            Me.DataGridViewForm_ProductionProcessControl.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProductionProcessControl.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductionProcessControl.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_ProductionProcessControl.TabIndex = 3
            Me.DataGridViewForm_ProductionProcessControl.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProductionProcessControl.ViewCaptionHeight = -1
            '
            'ButtonItemProcessControl_ClearComments
            '
            Me.ButtonItemProcessControl_ClearComments.BeginGroup = True
            Me.ButtonItemProcessControl_ClearComments.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessControl_ClearComments.Name = "ButtonItemProcessControl_ClearComments"
            Me.ButtonItemProcessControl_ClearComments.RibbonWordWrap = False
            Me.ButtonItemProcessControl_ClearComments.SecurityEnabled = True
            Me.ButtonItemProcessControl_ClearComments.SubItemsExpandWidth = 14
            Me.ButtonItemProcessControl_ClearComments.Text = "Clear Comments"
            '
            'BillingCommandCenterProductionProcessControlDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionProcessControlDialog"
            Me.Text = "Billing Command Center Production Process Control"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_ProcessControl.ResumeLayout(False)
            Me.RibbonBarOptions_ScheduleStatus.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ProcessControl As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ProcessControl As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents RibbonBarOptions_ScheduleStatus As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ScheduleStatus As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemScheduleStatus_Status As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxScheduleStatus_Status As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonItemScheduleStatus_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ComboBoxProcessControl_JobProcess As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemProcessControl_JobProcess As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemProcessControl_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessControl_CloseQualified As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_ProductionProcessControl As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemProcessControl_ClearComments As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace