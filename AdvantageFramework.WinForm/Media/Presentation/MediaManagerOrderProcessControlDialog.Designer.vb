Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerOrderProcessControlDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerOrderProcessControlDialog))
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
            Me.DataGridViewForm_ProcessControl = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_ProcessControl)
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
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(106, 92)
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
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(161, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(209, 92)
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
            Me.RibbonBarOptions_ProcessControl.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ProcessControl, Me.ButtonItemProcessControl_CloseQualified})
            Me.RibbonBarOptions_ProcessControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProcessControl.Location = New System.Drawing.Point(370, 0)
            Me.RibbonBarOptions_ProcessControl.Name = "RibbonBarOptions_ProcessControl"
            Me.RibbonBarOptions_ProcessControl.SecurityEnabled = True
            Me.RibbonBarOptions_ProcessControl.Size = New System.Drawing.Size(243, 92)
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
            Me.ComboBoxProcessControl_JobProcess.Location = New System.Drawing.Point(6, 3)
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
            'DataGridViewForm_ProcessControl
            '
            Me.DataGridViewForm_ProcessControl.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProcessControl.AllowDragAndDrop = False
            Me.DataGridViewForm_ProcessControl.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProcessControl.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProcessControl.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProcessControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ProcessControl.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProcessControl.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_ProcessControl.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProcessControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ProcessControl.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProcessControl.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProcessControl.ItemDescription = "Order/Line(s)"
            Me.DataGridViewForm_ProcessControl.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewForm_ProcessControl.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_ProcessControl.MultiSelect = True
            Me.DataGridViewForm_ProcessControl.Name = "DataGridViewForm_ProcessControl"
            Me.DataGridViewForm_ProcessControl.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProcessControl.RunStandardValidation = True
            Me.DataGridViewForm_ProcessControl.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProcessControl.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProcessControl.Size = New System.Drawing.Size(974, 546)
            Me.DataGridViewForm_ProcessControl.TabIndex = 3
            Me.DataGridViewForm_ProcessControl.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProcessControl.ViewCaptionHeight = -1
            '
            'MediaManagerOrderProcessControlDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerOrderProcessControlDialog"
            Me.Text = "Media Manager Order Process Control"
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
        Friend WithEvents ItemContainerVertical_ProcessControl As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxProcessControl_JobProcess As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemProcessControl_JobProcess As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemProcessControl_MarkSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessControl_CloseQualified As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_ProcessControl As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace