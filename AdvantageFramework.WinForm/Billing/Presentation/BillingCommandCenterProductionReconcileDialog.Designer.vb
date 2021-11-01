Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionReconcileDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionReconcileDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ProcessReconciliations = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_ProductionReconcileRecognize = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Reconcile = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxReconcile_Reconcile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_Reconcile = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemReconcile_Reconcile = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemReconcile_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcile_JobDetails = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReconcile_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_Reconcile.SuspendLayout()
            Me.SuspendLayout()
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Reconcile)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Reconcile, 0)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ProductionReconcileRecognize)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_ProcessReconciliations})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(228, 92)
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
            'ButtonItemActions_ProcessReconciliations
            '
            Me.ButtonItemActions_ProcessReconciliations.BeginGroup = True
            Me.ButtonItemActions_ProcessReconciliations.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ProcessReconciliations.Name = "ButtonItemActions_ProcessReconciliations"
            Me.ButtonItemActions_ProcessReconciliations.RibbonWordWrap = False
            Me.ButtonItemActions_ProcessReconciliations.SecurityEnabled = True
            Me.ButtonItemActions_ProcessReconciliations.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ProcessReconciliations.Text = "Process Reconciliations"
            '
            'DataGridViewForm_ProductionReconcileRecognize
            '
            Me.DataGridViewForm_ProductionReconcileRecognize.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProductionReconcileRecognize.AllowDragAndDrop = False
            Me.DataGridViewForm_ProductionReconcileRecognize.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProductionReconcileRecognize.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProductionReconcileRecognize.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProductionReconcileRecognize.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ProductionReconcileRecognize.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProductionReconcileRecognize.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ProductionReconcileRecognize.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProductionReconcileRecognize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ProductionReconcileRecognize.DataSource = Nothing
            Me.DataGridViewForm_ProductionReconcileRecognize.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProductionReconcileRecognize.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProductionReconcileRecognize.ItemDescription = "Reconciliation Item(s)"
            Me.DataGridViewForm_ProductionReconcileRecognize.Location = New System.Drawing.Point(4, 5)
            Me.DataGridViewForm_ProductionReconcileRecognize.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ProductionReconcileRecognize.MultiSelect = True
            Me.DataGridViewForm_ProductionReconcileRecognize.Name = "DataGridViewForm_ProductionReconcileRecognize"
            Me.DataGridViewForm_ProductionReconcileRecognize.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProductionReconcileRecognize.RunStandardValidation = True
            Me.DataGridViewForm_ProductionReconcileRecognize.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProductionReconcileRecognize.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductionReconcileRecognize.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_ProductionReconcileRecognize.TabIndex = 1
            Me.DataGridViewForm_ProductionReconcileRecognize.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProductionReconcileRecognize.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(283, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(212, 92)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 20
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
            'RibbonBarOptions_Reconcile
            '
            Me.RibbonBarOptions_Reconcile.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Reconcile.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Reconcile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Reconcile.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Reconcile.Controls.Add(Me.ComboBoxReconcile_Reconcile)
            Me.RibbonBarOptions_Reconcile.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Reconcile.DragDropSupport = True
            Me.RibbonBarOptions_Reconcile.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_Reconcile, Me.ButtonItemReconcile_JobDetails, Me.ButtonItemReconcile_Delete})
            Me.RibbonBarOptions_Reconcile.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Reconcile.Location = New System.Drawing.Point(495, 0)
            Me.RibbonBarOptions_Reconcile.Name = "RibbonBarOptions_Reconcile"
            Me.RibbonBarOptions_Reconcile.SecurityEnabled = True
            Me.RibbonBarOptions_Reconcile.Size = New System.Drawing.Size(310, 92)
            Me.RibbonBarOptions_Reconcile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Reconcile.TabIndex = 21
            Me.RibbonBarOptions_Reconcile.Text = "Reconcile"
            '
            '
            '
            Me.RibbonBarOptions_Reconcile.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Reconcile.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Reconcile.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ComboBoxReconcile_Reconcile
            '
            Me.ComboBoxReconcile_Reconcile.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxReconcile_Reconcile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxReconcile_Reconcile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxReconcile_Reconcile.AutoFindItemInDataSource = False
            Me.ComboBoxReconcile_Reconcile.AutoSelectSingleItemDatasource = False
            Me.ComboBoxReconcile_Reconcile.BookmarkingEnabled = False
            Me.ComboBoxReconcile_Reconcile.ClientCode = ""
            Me.ComboBoxReconcile_Reconcile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxReconcile_Reconcile.DisableMouseWheel = False
            Me.ComboBoxReconcile_Reconcile.DisplayMember = "Description"
            Me.ComboBoxReconcile_Reconcile.DisplayName = "Reconcile Status"
            Me.ComboBoxReconcile_Reconcile.DivisionCode = ""
            Me.ComboBoxReconcile_Reconcile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxReconcile_Reconcile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxReconcile_Reconcile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxReconcile_Reconcile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxReconcile_Reconcile.FocusHighlightEnabled = True
            Me.ComboBoxReconcile_Reconcile.FormattingEnabled = True
            Me.ComboBoxReconcile_Reconcile.ItemHeight = 14
            Me.ComboBoxReconcile_Reconcile.Location = New System.Drawing.Point(6, 3)
            Me.ComboBoxReconcile_Reconcile.Name = "ComboBoxReconcile_Reconcile"
            Me.ComboBoxReconcile_Reconcile.ReadOnly = False
            Me.ComboBoxReconcile_Reconcile.SecurityEnabled = True
            Me.ComboBoxReconcile_Reconcile.Size = New System.Drawing.Size(168, 20)
            Me.ComboBoxReconcile_Reconcile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxReconcile_Reconcile.TabIndex = 7
            Me.ComboBoxReconcile_Reconcile.TabOnEnter = True
            Me.ComboBoxReconcile_Reconcile.ValueMember = "Code"
            Me.ComboBoxReconcile_Reconcile.WatermarkText = "Select"
            '
            'ItemContainerVertical_Reconcile
            '
            '
            '
            '
            Me.ItemContainerVertical_Reconcile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_Reconcile.BeginGroup = True
            Me.ItemContainerVertical_Reconcile.FixedSize = New System.Drawing.Size(175, 0)
            Me.ItemContainerVertical_Reconcile.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_Reconcile.Name = "ItemContainerVertical_Reconcile"
            Me.ItemContainerVertical_Reconcile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemReconcile_Reconcile, Me.ButtonItemReconcile_MarkSelected})
            '
            '
            '
            Me.ItemContainerVertical_Reconcile.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemReconcile_Reconcile
            '
            Me.ControlContainerItemReconcile_Reconcile.AllowItemResize = True
            Me.ControlContainerItemReconcile_Reconcile.BeginGroup = True
            Me.ControlContainerItemReconcile_Reconcile.Control = Me.ComboBoxReconcile_Reconcile
            Me.ControlContainerItemReconcile_Reconcile.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ControlContainerItemReconcile_Reconcile.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemReconcile_Reconcile.Name = "ControlContainerItemReconcile_Reconcile"
            '
            'ButtonItemReconcile_MarkSelected
            '
            Me.ButtonItemReconcile_MarkSelected.BeginGroup = True
            Me.ButtonItemReconcile_MarkSelected.FixedSize = New System.Drawing.Size(168, 0)
            Me.ButtonItemReconcile_MarkSelected.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemReconcile_MarkSelected.Name = "ButtonItemReconcile_MarkSelected"
            Me.ButtonItemReconcile_MarkSelected.Text = "Mark Selected"
            '
            'ButtonItemReconcile_JobDetails
            '
            Me.ButtonItemReconcile_JobDetails.BeginGroup = True
            Me.ButtonItemReconcile_JobDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_JobDetails.Name = "ButtonItemReconcile_JobDetails"
            Me.ButtonItemReconcile_JobDetails.RibbonWordWrap = False
            Me.ButtonItemReconcile_JobDetails.SecurityEnabled = True
            Me.ButtonItemReconcile_JobDetails.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_JobDetails.Text = "Job Details"
            '
            'ButtonItemReconcile_Delete
            '
            Me.ButtonItemReconcile_Delete.BeginGroup = True
            Me.ButtonItemReconcile_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReconcile_Delete.Name = "ButtonItemReconcile_Delete"
            Me.ButtonItemReconcile_Delete.RibbonWordWrap = False
            Me.ButtonItemReconcile_Delete.SecurityEnabled = True
            Me.ButtonItemReconcile_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemReconcile_Delete.Text = "Delete"
            '
            'BillingCommandCenterProductionReconcileDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionReconcileDialog"
            Me.Text = "Billing Command Center Production Reconciliation"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_Reconcile.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_ProductionReconcileRecognize As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Reconcile As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxReconcile_Reconcile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainerVertical_Reconcile As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemReconcile_Reconcile As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemReconcile_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcile_JobDetails As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReconcile_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ProcessReconciliations As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace