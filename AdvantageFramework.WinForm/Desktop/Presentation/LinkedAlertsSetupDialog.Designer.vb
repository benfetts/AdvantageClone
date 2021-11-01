Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LinkedAlertsSetupDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LinkedAlertsSetupDialog))
            Me.RibbonBarOptions_New = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_AddAlert = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_AddAlertAssignment = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_Alerts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxGroup_Group = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxShow_Show = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerView_View = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerView_Group = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemGroup_Group = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemGroup_Group = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerView_Show = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemSearch_Show = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemShow_Show = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemView_ShowCompleted = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_View.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1305, 190)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_New)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1305, 131)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_New, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(5, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(60, 126)
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
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Alerts)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1305, 372)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 563)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1305, 21)
            '
            'RibbonBarOptions_New
            '
            Me.RibbonBarOptions_New.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_New.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_New.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_New.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_New.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_New.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AddAlert, Me.ButtonItemActions_AddAlertAssignment})
            Me.RibbonBarOptions_New.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_New.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_New.Location = New System.Drawing.Point(65, 0)
            Me.RibbonBarOptions_New.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RibbonBarOptions_New.Name = "RibbonBarOptions_New"
            Me.RibbonBarOptions_New.Size = New System.Drawing.Size(201, 126)
            Me.RibbonBarOptions_New.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_New.TabIndex = 1
            Me.RibbonBarOptions_New.Text = "New"
            '
            '
            '
            Me.RibbonBarOptions_New.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_New.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_New.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_AddAlert
            '
            Me.ButtonItemActions_AddAlert.BeginGroup = True
            Me.ButtonItemActions_AddAlert.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AddAlert.Name = "ButtonItemActions_AddAlert"
            Me.ButtonItemActions_AddAlert.RibbonWordWrap = False
            Me.ButtonItemActions_AddAlert.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddAlert.Text = "Add Alert"
            '
            'ButtonItemActions_AddAlertAssignment
            '
            Me.ButtonItemActions_AddAlertAssignment.BeginGroup = True
            Me.ButtonItemActions_AddAlertAssignment.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AddAlertAssignment.Name = "ButtonItemActions_AddAlertAssignment"
            Me.ButtonItemActions_AddAlertAssignment.RibbonWordWrap = False
            Me.ButtonItemActions_AddAlertAssignment.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddAlertAssignment.Text = "Add Alert Assignment"
            '
            'DataGridViewForm_Alerts
            '
            Me.DataGridViewForm_Alerts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Alerts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Alerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Alerts.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Alerts.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Alerts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Alerts.DataSource = Nothing
            Me.DataGridViewForm_Alerts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Alerts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Alerts.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Alerts.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewForm_Alerts.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.DataGridViewForm_Alerts.MultiSelect = True
            Me.DataGridViewForm_Alerts.Name = "DataGridViewForm_Alerts"
            Me.DataGridViewForm_Alerts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Alerts.RunStandardValidation = True
            Me.DataGridViewForm_Alerts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Alerts.Size = New System.Drawing.Size(1295, 362)
            Me.DataGridViewForm_Alerts.TabIndex = 16
            Me.DataGridViewForm_Alerts.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Alerts.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_View.Controls.Add(Me.ComboBoxGroup_Group)
            Me.RibbonBarOptions_View.Controls.Add(Me.ComboBoxShow_Show)
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_View, Me.ButtonItemView_ShowCompleted})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(266, 0)
            Me.RibbonBarOptions_View.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(468, 126)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 5
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxGroup_Group
            '
            Me.ComboBoxGroup_Group.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGroup_Group.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGroup_Group.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGroup_Group.AutoFindItemInDataSource = False
            Me.ComboBoxGroup_Group.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGroup_Group.BookmarkingEnabled = False
            Me.ComboBoxGroup_Group.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxGroup_Group.DisableMouseWheel = False
            Me.ComboBoxGroup_Group.DisplayMember = "Name"
            Me.ComboBoxGroup_Group.DisplayName = ""
            Me.ComboBoxGroup_Group.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGroup_Group.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGroup_Group.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGroup_Group.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGroup_Group.FocusHighlightEnabled = True
            Me.ComboBoxGroup_Group.FormattingEnabled = True
            Me.ComboBoxGroup_Group.ItemHeight = 14
            Me.ComboBoxGroup_Group.Location = New System.Drawing.Point(65, 32)
            Me.ComboBoxGroup_Group.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.ComboBoxGroup_Group.Name = "ComboBoxGroup_Group"
            Me.ComboBoxGroup_Group.PreventEnterBeep = False
            Me.ComboBoxGroup_Group.ReadOnly = False
            Me.ComboBoxGroup_Group.SecurityEnabled = True
            Me.ComboBoxGroup_Group.Size = New System.Drawing.Size(199, 20)
            Me.ComboBoxGroup_Group.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGroup_Group.TabIndex = 1
            Me.ComboBoxGroup_Group.ValueMember = "Value"
            Me.ComboBoxGroup_Group.WatermarkText = "Select"
            '
            'ComboBoxShow_Show
            '
            Me.ComboBoxShow_Show.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxShow_Show.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxShow_Show.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxShow_Show.AutoFindItemInDataSource = False
            Me.ComboBoxShow_Show.AutoSelectSingleItemDatasource = False
            Me.ComboBoxShow_Show.BookmarkingEnabled = False
            Me.ComboBoxShow_Show.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxShow_Show.DisableMouseWheel = False
            Me.ComboBoxShow_Show.DisplayMember = "Name"
            Me.ComboBoxShow_Show.DisplayName = ""
            Me.ComboBoxShow_Show.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxShow_Show.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxShow_Show.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxShow_Show.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxShow_Show.FocusHighlightEnabled = True
            Me.ComboBoxShow_Show.FormattingEnabled = True
            Me.ComboBoxShow_Show.ItemHeight = 14
            Me.ComboBoxShow_Show.Location = New System.Drawing.Point(65, 55)
            Me.ComboBoxShow_Show.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.ComboBoxShow_Show.Name = "ComboBoxShow_Show"
            Me.ComboBoxShow_Show.PreventEnterBeep = False
            Me.ComboBoxShow_Show.ReadOnly = False
            Me.ComboBoxShow_Show.SecurityEnabled = True
            Me.ComboBoxShow_Show.Size = New System.Drawing.Size(199, 20)
            Me.ComboBoxShow_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxShow_Show.TabIndex = 1
            Me.ComboBoxShow_Show.ValueMember = "Value"
            Me.ComboBoxShow_Show.WatermarkText = "Select"
            '
            'ItemContainerView_View
            '
            '
            '
            '
            Me.ItemContainerView_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_View.Name = "ItemContainerView_View"
            Me.ItemContainerView_View.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_Group, Me.ItemContainerView_Show})
            '
            '
            '
            Me.ItemContainerView_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerView_Group
            '
            '
            '
            '
            Me.ItemContainerView_Group.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Group.Name = "ItemContainerView_Group"
            Me.ItemContainerView_Group.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemGroup_Group, Me.ControlContainerItemGroup_Group})
            '
            '
            '
            Me.ItemContainerView_Group.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemGroup_Group
            '
            Me.LabelItemGroup_Group.Name = "LabelItemGroup_Group"
            Me.LabelItemGroup_Group.Text = "Group:"
            Me.LabelItemGroup_Group.Width = 58
            '
            'ControlContainerItemGroup_Group
            '
            Me.ControlContainerItemGroup_Group.AllowItemResize = True
            Me.ControlContainerItemGroup_Group.Control = Me.ComboBoxGroup_Group
            Me.ControlContainerItemGroup_Group.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemGroup_Group.Name = "ControlContainerItemGroup_Group"
            Me.ControlContainerItemGroup_Group.Text = "ControlContainerItem2"
            '
            'ItemContainerView_Show
            '
            '
            '
            '
            Me.ItemContainerView_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Show.Name = "ItemContainerView_Show"
            Me.ItemContainerView_Show.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemSearch_Show, Me.ControlContainerItemShow_Show})
            '
            '
            '
            Me.ItemContainerView_Show.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemSearch_Show
            '
            Me.LabelItemSearch_Show.Name = "LabelItemSearch_Show"
            Me.LabelItemSearch_Show.Text = "Show: "
            Me.LabelItemSearch_Show.Width = 58
            '
            'ControlContainerItemShow_Show
            '
            Me.ControlContainerItemShow_Show.AllowItemResize = True
            Me.ControlContainerItemShow_Show.Control = Me.ComboBoxShow_Show
            Me.ControlContainerItemShow_Show.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemShow_Show.Name = "ControlContainerItemShow_Show"
            Me.ControlContainerItemShow_Show.Text = "ControlContainerItem2"
            '
            'ButtonItemView_ShowCompleted
            '
            Me.ButtonItemView_ShowCompleted.AutoCheckOnClick = True
            Me.ButtonItemView_ShowCompleted.BeginGroup = True
            Me.ButtonItemView_ShowCompleted.Checked = True
            Me.ButtonItemView_ShowCompleted.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowCompleted.Name = "ButtonItemView_ShowCompleted"
            Me.ButtonItemView_ShowCompleted.RibbonWordWrap = False
            Me.ButtonItemView_ShowCompleted.SecurityEnabled = True
            Me.ButtonItemView_ShowCompleted.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowCompleted.Text = "Show Completed"
            '
            'LinkedAlertsSetupDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1315, 586)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.Name = "LinkedAlertsSetupDialog"
            Me.Text = "Alerts"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_View.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_New As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_AddAlert As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_AddAlertAssignment As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_Alerts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxGroup_Group As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxShow_Show As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainerView_View As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerView_Group As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemGroup_Group As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemGroup_Group As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerView_Show As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemSearch_Show As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemShow_Show As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemView_ShowCompleted As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem

    End Class

End Namespace