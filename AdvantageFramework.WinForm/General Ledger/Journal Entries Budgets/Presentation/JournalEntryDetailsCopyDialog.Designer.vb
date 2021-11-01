Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JournalEntryDetailsCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalEntryDetailsCopyDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.SearchableComboBoxForm_PostPeriodTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_PostPeriodTo = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_PostPeriodTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_PostPeriodFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_PostPeriodFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_PostPeriodFrom = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DataGridViewForm_JournalEntries = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_PostPeriodTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriodTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_PostPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriodFrom, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_PostPeriodTo)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_PostPeriodTo)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_PostPeriodFrom)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_PostPeriodFrom)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_JournalEntries)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(751, 374)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(751, 154)
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
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(751, 94)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 529)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(751, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Copy, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 2
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
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
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
            'SearchableComboBoxForm_PostPeriodTo
            '
            Me.SearchableComboBoxForm_PostPeriodTo.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriodTo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriodTo.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriodTo.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriodTo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriodTo.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriodTo.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriodTo.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriodTo.EditValue = ""
            Me.SearchableComboBoxForm_PostPeriodTo.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_PostPeriodTo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriodTo.Location = New System.Drawing.Point(355, 6)
            Me.SearchableComboBoxForm_PostPeriodTo.Name = "SearchableComboBoxForm_PostPeriodTo"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.PopupView = Me.SearchableComboBoxViewControl_PostPeriodTo
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriodTo.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriodTo.SelectedValue = ""
            Me.SearchableComboBoxForm_PostPeriodTo.Size = New System.Drawing.Size(125, 20)
            Me.SearchableComboBoxForm_PostPeriodTo.TabIndex = 14
            '
            'SearchableComboBoxViewControl_PostPeriodTo
            '
            Me.SearchableComboBoxViewControl_PostPeriodTo.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_PostPeriodTo.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodTo.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_PostPeriodTo.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_PostPeriodTo.Name = "SearchableComboBoxViewControl_PostPeriodTo"
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_PostPeriodTo.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_PostPeriodTo.RunStandardValidation = True
            Me.SearchableComboBoxViewControl_PostPeriodTo.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewControl_PostPeriodTo.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_PostPeriodTo
            '
            Me.LabelForm_PostPeriodTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodTo.Location = New System.Drawing.Point(249, 6)
            Me.LabelForm_PostPeriodTo.Name = "LabelForm_PostPeriodTo"
            Me.LabelForm_PostPeriodTo.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_PostPeriodTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodTo.TabIndex = 13
            Me.LabelForm_PostPeriodTo.Text = "Post Period To:"
            '
            'LabelForm_PostPeriodFrom
            '
            Me.LabelForm_PostPeriodFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodFrom.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_PostPeriodFrom.Name = "LabelForm_PostPeriodFrom"
            Me.LabelForm_PostPeriodFrom.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_PostPeriodFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodFrom.TabIndex = 11
            Me.LabelForm_PostPeriodFrom.Text = "Post Period From:"
            '
            'SearchableComboBoxForm_PostPeriodFrom
            '
            Me.SearchableComboBoxForm_PostPeriodFrom.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriodFrom.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriodFrom.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriodFrom.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriodFrom.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriodFrom.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriodFrom.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.EditValue = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_PostPeriodFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriodFrom.Location = New System.Drawing.Point(118, 6)
            Me.SearchableComboBoxForm_PostPeriodFrom.Name = "SearchableComboBoxForm_PostPeriodFrom"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.PopupView = Me.SearchableComboBoxViewControl_PostPeriodFrom
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriodFrom.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriodFrom.SelectedValue = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.Size = New System.Drawing.Size(125, 20)
            Me.SearchableComboBoxForm_PostPeriodFrom.TabIndex = 12
            '
            'SearchableComboBoxViewControl_PostPeriodFrom
            '
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_PostPeriodFrom.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_PostPeriodFrom.Name = "SearchableComboBoxViewControl_PostPeriodFrom"
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_PostPeriodFrom.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_PostPeriodFrom.RunStandardValidation = True
            Me.SearchableComboBoxViewControl_PostPeriodFrom.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewControl_PostPeriodFrom.SkipSettingFontOnModifyColumn = False
            '
            'DataGridViewForm_JournalEntries
            '
            Me.DataGridViewForm_JournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_JournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_JournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewForm_JournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_JournalEntries.ItemDescription = "Journal Entry(ies)"
            Me.DataGridViewForm_JournalEntries.Location = New System.Drawing.Point(12, 32)
            Me.DataGridViewForm_JournalEntries.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_JournalEntries.ModifyGridRowHeight = False
            Me.DataGridViewForm_JournalEntries.MultiSelect = False
            Me.DataGridViewForm_JournalEntries.Name = "DataGridViewForm_JournalEntries"
            Me.DataGridViewForm_JournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_JournalEntries.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_JournalEntries.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_JournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_JournalEntries.Size = New System.Drawing.Size(727, 336)
            Me.DataGridViewForm_JournalEntries.TabIndex = 10
            Me.DataGridViewForm_JournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewForm_JournalEntries.ViewCaptionHeight = -1
            '
            'JournalEntryDetailsCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(761, 549)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JournalEntryDetailsCopyDialog"
            Me.Text = "Journal Entry Detail Copy"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_PostPeriodTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriodTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_PostPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriodFrom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Copy As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents SearchableComboBoxForm_PostPeriodTo As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_PostPeriodTo As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_PostPeriodTo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostPeriodFrom As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_PostPeriodFrom As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_PostPeriodFrom As WinForm.Presentation.Controls.GridView
        Friend WithEvents DataGridViewForm_JournalEntries As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace