Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterProductionVendorWriteoff
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterProductionVendorWriteoff))
            Me.DataGridViewForm_WriteOffs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Job = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_SetGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Job, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_JobComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_JobComponent, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1009, 154)
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
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1009, 94)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_JobComponent)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Job)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_JobComponent)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Job)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_WriteOffs)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1009, 532)
            Me.PanelForm_Form.TabIndex = 0
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 687)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1009, 18)
            '
            'DataGridViewForm_WriteOffs
            '
            Me.DataGridViewForm_WriteOffs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_WriteOffs.AllowDragAndDrop = False
            Me.DataGridViewForm_WriteOffs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_WriteOffs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_WriteOffs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_WriteOffs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_WriteOffs.AutoFilterLookupColumns = True
            Me.DataGridViewForm_WriteOffs.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_WriteOffs.AutoUpdateViewCaption = True
            Me.DataGridViewForm_WriteOffs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_WriteOffs.DataSource = Nothing
            Me.DataGridViewForm_WriteOffs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_WriteOffs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_WriteOffs.ItemDescription = "Write off Item(s)"
            Me.DataGridViewForm_WriteOffs.Location = New System.Drawing.Point(13, 59)
            Me.DataGridViewForm_WriteOffs.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_WriteOffs.MultiSelect = True
            Me.DataGridViewForm_WriteOffs.Name = "DataGridViewForm_WriteOffs"
            Me.DataGridViewForm_WriteOffs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_WriteOffs.RunStandardValidation = True
            Me.DataGridViewForm_WriteOffs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_WriteOffs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_WriteOffs.Size = New System.Drawing.Size(983, 466)
            Me.DataGridViewForm_WriteOffs.TabIndex = 4
            Me.DataGridViewForm_WriteOffs.UseEmbeddedNavigator = False
            Me.DataGridViewForm_WriteOffs.ViewCaptionHeight = -1
            '
            'LabelForm_Job
            '
            Me.LabelForm_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Job.Location = New System.Drawing.Point(13, 6)
            Me.LabelForm_Job.Name = "LabelForm_Job"
            Me.LabelForm_Job.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Job.TabIndex = 0
            Me.LabelForm_Job.Text = "Job:"
            '
            'LabelForm_JobComponent
            '
            Me.LabelForm_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_JobComponent.Location = New System.Drawing.Point(13, 32)
            Me.LabelForm_JobComponent.Name = "LabelForm_JobComponent"
            Me.LabelForm_JobComponent.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_JobComponent.TabIndex = 2
            Me.LabelForm_JobComponent.Text = "Job Component:"
            '
            'SearchableComboBoxForm_Job
            '
            Me.SearchableComboBoxForm_Job.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Job.AutoFillMode = False
            Me.SearchableComboBoxForm_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxForm_Job.DataSource = Nothing
            Me.SearchableComboBoxForm_Job.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Job.DisplayName = ""
            Me.SearchableComboBoxForm_Job.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_Job.Location = New System.Drawing.Point(109, 7)
            Me.SearchableComboBoxForm_Job.Name = "SearchableComboBoxForm_Job"
            Me.SearchableComboBoxForm_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxForm_Job.Properties.ReadOnly = True
            Me.SearchableComboBoxForm_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxForm_Job.Properties.View = Me.SearchableComboBoxView_Job
            Me.SearchableComboBoxForm_Job.SecurityEnabled = True
            Me.SearchableComboBoxForm_Job.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Job.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxForm_Job.TabIndex = 1
            Me.SearchableComboBoxForm_Job.TabStop = False
            '
            'SearchableComboBoxView_Job
            '
            Me.SearchableComboBoxView_Job.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Job.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Job.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Job.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Job.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Job.DataSourceClearing = False
            Me.SearchableComboBoxView_Job.EnableDisabledRows = False
            Me.SearchableComboBoxView_Job.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Job.Name = "SearchableComboBoxView_Job"
            Me.SearchableComboBoxView_Job.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Job.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Job.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Job.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Job.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Job.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Job.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Job.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Job.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Job.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Job.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Job.RunStandardValidation = True
            '
            'SearchableComboBoxForm_JobComponent
            '
            Me.SearchableComboBoxForm_JobComponent.ActiveFilterString = ""
            Me.SearchableComboBoxForm_JobComponent.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_JobComponent.AutoFillMode = False
            Me.SearchableComboBoxForm_JobComponent.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_JobComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxForm_JobComponent.DataSource = Nothing
            Me.SearchableComboBoxForm_JobComponent.DisableMouseWheel = True
            Me.SearchableComboBoxForm_JobComponent.DisplayName = ""
            Me.SearchableComboBoxForm_JobComponent.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_JobComponent.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_JobComponent.Location = New System.Drawing.Point(109, 33)
            Me.SearchableComboBoxForm_JobComponent.Name = "SearchableComboBoxForm_JobComponent"
            Me.SearchableComboBoxForm_JobComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_JobComponent.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_JobComponent.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxForm_JobComponent.Properties.ReadOnly = True
            Me.SearchableComboBoxForm_JobComponent.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_JobComponent.Properties.ValueMember = "Number"
            Me.SearchableComboBoxForm_JobComponent.Properties.View = Me.SearchableComboBoxView_JobComponent
            Me.SearchableComboBoxForm_JobComponent.SecurityEnabled = True
            Me.SearchableComboBoxForm_JobComponent.SelectedValue = Nothing
            Me.SearchableComboBoxForm_JobComponent.Size = New System.Drawing.Size(290, 20)
            Me.SearchableComboBoxForm_JobComponent.TabIndex = 3
            Me.SearchableComboBoxForm_JobComponent.TabStop = False
            '
            'SearchableComboBoxView_JobComponent
            '
            Me.SearchableComboBoxView_JobComponent.AFActiveFilterString = ""
            Me.SearchableComboBoxView_JobComponent.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_JobComponent.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_JobComponent.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_JobComponent.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_JobComponent.DataSourceClearing = False
            Me.SearchableComboBoxView_JobComponent.EnableDisabledRows = False
            Me.SearchableComboBoxView_JobComponent.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_JobComponent.Name = "SearchableComboBoxView_JobComponent"
            Me.SearchableComboBoxView_JobComponent.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_JobComponent.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_JobComponent.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_JobComponent.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_JobComponent.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_JobComponent.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_JobComponent.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_JobComponent.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_JobComponent.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_JobComponent.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_JobComponent.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_JobComponent.RunStandardValidation = True
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_SetGLAccount})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(181, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'ButtonItemActions_SetGLAccount
            '
            Me.ButtonItemActions_SetGLAccount.BeginGroup = True
            Me.ButtonItemActions_SetGLAccount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SetGLAccount.Name = "ButtonItemActions_SetGLAccount"
            Me.ButtonItemActions_SetGLAccount.RibbonWordWrap = False
            Me.ButtonItemActions_SetGLAccount.SecurityEnabled = True
            Me.ButtonItemActions_SetGLAccount.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SetGLAccount.Text = "Set GL Account"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Refresh})
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
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
            'BillingCommandCenterProductionVendorWriteoff
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1019, 707)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterProductionVendorWriteoff"
            Me.Text = "Billing Command Center - A/P Write-Off Vendor Detail"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Job, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_JobComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_JobComponent, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SearchableComboBoxForm_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Job As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_WriteOffs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_SetGLAccount As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace