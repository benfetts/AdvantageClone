Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionBillHoldDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionBillHoldDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxBillHold_BillHold = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerVertical_BillHold = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemBillHold_BillHold = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemBillHold_MarkSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemBillHold_AcceptRequested = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_ProductionBillHold = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_ProcessControl.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ProductionBillHold)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(117, 92)
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
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(172, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(194, 92)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 19
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
            Me.RibbonBarOptions_ProcessControl.Controls.Add(Me.ComboBoxBillHold_BillHold)
            Me.RibbonBarOptions_ProcessControl.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ProcessControl.DragDropSupport = True
            Me.RibbonBarOptions_ProcessControl.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_BillHold})
            Me.RibbonBarOptions_ProcessControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProcessControl.Location = New System.Drawing.Point(366, 0)
            Me.RibbonBarOptions_ProcessControl.Name = "RibbonBarOptions_ProcessControl"
            Me.RibbonBarOptions_ProcessControl.SecurityEnabled = True
            Me.RibbonBarOptions_ProcessControl.Size = New System.Drawing.Size(125, 92)
            Me.RibbonBarOptions_ProcessControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ProcessControl.TabIndex = 20
            Me.RibbonBarOptions_ProcessControl.Text = "Bill Hold"
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
            'ComboBoxBillHold_BillHold
            '
            Me.ComboBoxBillHold_BillHold.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxBillHold_BillHold.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxBillHold_BillHold.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxBillHold_BillHold.AutoFindItemInDataSource = False
            Me.ComboBoxBillHold_BillHold.AutoSelectSingleItemDatasource = False
            Me.ComboBoxBillHold_BillHold.BookmarkingEnabled = False
            Me.ComboBoxBillHold_BillHold.ClientCode = ""
            Me.ComboBoxBillHold_BillHold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxBillHold_BillHold.DisableMouseWheel = False
            Me.ComboBoxBillHold_BillHold.DisplayMember = "Description"
            Me.ComboBoxBillHold_BillHold.DisplayName = "Bill Hold Status"
            Me.ComboBoxBillHold_BillHold.DivisionCode = ""
            Me.ComboBoxBillHold_BillHold.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxBillHold_BillHold.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxBillHold_BillHold.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxBillHold_BillHold.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxBillHold_BillHold.FocusHighlightEnabled = True
            Me.ComboBoxBillHold_BillHold.FormattingEnabled = True
            Me.ComboBoxBillHold_BillHold.ItemHeight = 15
            Me.ComboBoxBillHold_BillHold.Location = New System.Drawing.Point(6, 3)
            Me.ComboBoxBillHold_BillHold.Name = "ComboBoxBillHold_BillHold"
            Me.ComboBoxBillHold_BillHold.ReadOnly = False
            Me.ComboBoxBillHold_BillHold.SecurityEnabled = True
            Me.ComboBoxBillHold_BillHold.Size = New System.Drawing.Size(109, 21)
            Me.ComboBoxBillHold_BillHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxBillHold_BillHold.TabIndex = 7
            Me.ComboBoxBillHold_BillHold.TabOnEnter = True
            Me.ComboBoxBillHold_BillHold.ValueMember = "Code"
            Me.ComboBoxBillHold_BillHold.WatermarkText = "Select"
            '
            'ItemContainerVertical_BillHold
            '
            '
            '
            '
            Me.ItemContainerVertical_BillHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_BillHold.BeginGroup = True
            Me.ItemContainerVertical_BillHold.FixedSize = New System.Drawing.Size(115, 0)
            Me.ItemContainerVertical_BillHold.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_BillHold.Name = "ItemContainerVertical_BillHold"
            Me.ItemContainerVertical_BillHold.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemBillHold_BillHold, Me.ButtonItemBillHold_MarkSelected, Me.ButtonItemBillHold_AcceptRequested})
            '
            '
            '
            Me.ItemContainerVertical_BillHold.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemBillHold_BillHold
            '
            Me.ControlContainerItemBillHold_BillHold.AllowItemResize = True
            Me.ControlContainerItemBillHold_BillHold.BeginGroup = True
            Me.ControlContainerItemBillHold_BillHold.Control = Me.ComboBoxBillHold_BillHold
            Me.ControlContainerItemBillHold_BillHold.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ControlContainerItemBillHold_BillHold.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBillHold_BillHold.Name = "ControlContainerItemBillHold_BillHold"
            '
            'ButtonItemBillHold_MarkSelected
            '
            Me.ButtonItemBillHold_MarkSelected.BeginGroup = True
            Me.ButtonItemBillHold_MarkSelected.FixedSize = New System.Drawing.Size(109, 0)
            Me.ButtonItemBillHold_MarkSelected.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemBillHold_MarkSelected.Name = "ButtonItemBillHold_MarkSelected"
            Me.ButtonItemBillHold_MarkSelected.Text = "Mark Selected"
            '
            'ButtonItemBillHold_AcceptRequested
            '
            Me.ButtonItemBillHold_AcceptRequested.BeginGroup = True
            Me.ButtonItemBillHold_AcceptRequested.FixedSize = New System.Drawing.Size(109, 0)
            Me.ButtonItemBillHold_AcceptRequested.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemBillHold_AcceptRequested.Name = "ButtonItemBillHold_AcceptRequested"
            Me.ButtonItemBillHold_AcceptRequested.Text = "Accept Requested"
            '
            'DataGridViewForm_ProductionBillHold
            '
            Me.DataGridViewForm_ProductionBillHold.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProductionBillHold.AllowDragAndDrop = False
            Me.DataGridViewForm_ProductionBillHold.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProductionBillHold.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProductionBillHold.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProductionBillHold.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ProductionBillHold.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProductionBillHold.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_ProductionBillHold.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProductionBillHold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ProductionBillHold.DataSource = Nothing
            Me.DataGridViewForm_ProductionBillHold.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProductionBillHold.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProductionBillHold.ItemDescription = "Job Component(s)"
            Me.DataGridViewForm_ProductionBillHold.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewForm_ProductionBillHold.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ProductionBillHold.MultiSelect = True
            Me.DataGridViewForm_ProductionBillHold.Name = "DataGridViewForm_ProductionBillHold"
            Me.DataGridViewForm_ProductionBillHold.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProductionBillHold.RunStandardValidation = True
            Me.DataGridViewForm_ProductionBillHold.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProductionBillHold.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductionBillHold.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_ProductionBillHold.TabIndex = 2
            Me.DataGridViewForm_ProductionBillHold.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProductionBillHold.ViewCaptionHeight = -1
            '
            'BillingCommandCenterProductionBillHoldDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionBillHoldDialog"
            Me.Text = "Billing Command Center Production Bill Hold"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_ProcessControl.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ProcessControl As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxBillHold_BillHold As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainerVertical_BillHold As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBillHold_BillHold As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemBillHold_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBillHold_AcceptRequested As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_ProductionBillHold As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace