Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PaymentManagerDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentManagerDialog))
            Me.SearchableComboBoxForm_Bank = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Bank = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_CheckRunID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_CheckRunID = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_CheckRunID = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Bank = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Transmit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.CheckBoxForm_AutoFTP = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.StepProgressBarForm_Progress = New DevExpress.XtraEditors.StepProgressBar()
            Me.StepProgressBarItemProgress_Step1 = New DevExpress.XtraEditors.StepProgressBarItem()
            Me.StepProgressBarItemProgress_Step2 = New DevExpress.XtraEditors.StepProgressBarItem()
            Me.StepProgressBarItemProgress_Step3 = New DevExpress.XtraEditors.StepProgressBarItem()
            Me.StepProgressBarItemProgress_Step4 = New DevExpress.XtraEditors.StepProgressBarItem()
            Me.CheckBoxForm_IncludeExported = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.StepProgressBarItem1 = New DevExpress.XtraEditors.StepProgressBarItem()
            Me.StepProgressBarItem2 = New DevExpress.XtraEditors.StepProgressBarItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Bank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Bank, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_CheckRunID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_CheckRunID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.StepProgressBarForm_Progress, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_IncludeExported)
            Me.PanelForm_Form.Controls.Add(Me.StepProgressBarForm_Progress)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_AutoFTP)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Bank)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_CheckRunID)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_CheckRunID)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Bank)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(687, 271)
            Me.PanelForm_Form.TabIndex = 1
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(687, 154)
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
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(687, 94)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(55, 92)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 426)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(687, 18)
            '
            'SearchableComboBoxForm_Bank
            '
            Me.SearchableComboBoxForm_Bank.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Bank.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Bank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Bank.AutoFillMode = False
            Me.SearchableComboBoxForm_Bank.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Bank.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Bank
            Me.SearchableComboBoxForm_Bank.DataSource = Nothing
            Me.SearchableComboBoxForm_Bank.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Bank.DisplayName = ""
            Me.SearchableComboBoxForm_Bank.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Bank.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Bank.Location = New System.Drawing.Point(95, 6)
            Me.SearchableComboBoxForm_Bank.Name = "SearchableComboBoxForm_Bank"
            Me.SearchableComboBoxForm_Bank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Bank.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Bank.Properties.NullText = "Select Bank"
            Me.SearchableComboBoxForm_Bank.Properties.PopupView = Me.SearchableComboBoxView_Bank
            Me.SearchableComboBoxForm_Bank.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Bank.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Bank.SecurityEnabled = True
            Me.SearchableComboBoxForm_Bank.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Bank.Size = New System.Drawing.Size(349, 20)
            Me.SearchableComboBoxForm_Bank.TabIndex = 1
            '
            'SearchableComboBoxView_Bank
            '
            Me.SearchableComboBoxView_Bank.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Bank.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Bank.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Bank.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Bank.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Bank.DataSourceClearing = False
            Me.SearchableComboBoxView_Bank.EnableDisabledRows = False
            Me.SearchableComboBoxView_Bank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Bank.Name = "SearchableComboBoxView_Bank"
            Me.SearchableComboBoxView_Bank.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Bank.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Bank.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Bank.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Bank.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Bank.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Bank.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Bank.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Bank.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Bank.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Bank.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Bank.RunStandardValidation = True
            Me.SearchableComboBoxView_Bank.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_Bank.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_CheckRunID
            '
            Me.LabelForm_CheckRunID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CheckRunID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CheckRunID.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_CheckRunID.Name = "LabelForm_CheckRunID"
            Me.LabelForm_CheckRunID.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_CheckRunID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CheckRunID.TabIndex = 2
            Me.LabelForm_CheckRunID.Text = "Check Run ID:"
            '
            'SearchableComboBoxForm_CheckRunID
            '
            Me.SearchableComboBoxForm_CheckRunID.ActiveFilterString = ""
            Me.SearchableComboBoxForm_CheckRunID.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_CheckRunID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_CheckRunID.AutoFillMode = False
            Me.SearchableComboBoxForm_CheckRunID.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_CheckRunID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CheckRegister
            Me.SearchableComboBoxForm_CheckRunID.DataSource = Nothing
            Me.SearchableComboBoxForm_CheckRunID.DisableMouseWheel = True
            Me.SearchableComboBoxForm_CheckRunID.DisplayName = ""
            Me.SearchableComboBoxForm_CheckRunID.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_CheckRunID.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_CheckRunID.Location = New System.Drawing.Point(95, 32)
            Me.SearchableComboBoxForm_CheckRunID.Name = "SearchableComboBoxForm_CheckRunID"
            Me.SearchableComboBoxForm_CheckRunID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_CheckRunID.Properties.DisplayMember = "CheckRunID"
            Me.SearchableComboBoxForm_CheckRunID.Properties.NullText = "Select Check Run ID"
            Me.SearchableComboBoxForm_CheckRunID.Properties.PopupView = Me.SearchableComboBoxView_CheckRunID
            Me.SearchableComboBoxForm_CheckRunID.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_CheckRunID.Properties.ValueMember = "CheckRunID"
            Me.SearchableComboBoxForm_CheckRunID.SecurityEnabled = True
            Me.SearchableComboBoxForm_CheckRunID.SelectedValue = Nothing
            Me.SearchableComboBoxForm_CheckRunID.Size = New System.Drawing.Size(349, 20)
            Me.SearchableComboBoxForm_CheckRunID.TabIndex = 3
            '
            'SearchableComboBoxView_CheckRunID
            '
            Me.SearchableComboBoxView_CheckRunID.AFActiveFilterString = ""
            Me.SearchableComboBoxView_CheckRunID.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_CheckRunID.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_CheckRunID.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_CheckRunID.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_CheckRunID.DataSourceClearing = False
            Me.SearchableComboBoxView_CheckRunID.EnableDisabledRows = False
            Me.SearchableComboBoxView_CheckRunID.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_CheckRunID.Name = "SearchableComboBoxView_CheckRunID"
            Me.SearchableComboBoxView_CheckRunID.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_CheckRunID.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_CheckRunID.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_CheckRunID.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_CheckRunID.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_CheckRunID.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_CheckRunID.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_CheckRunID.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_CheckRunID.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_CheckRunID.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_CheckRunID.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_CheckRunID.RunStandardValidation = True
            Me.SearchableComboBoxView_CheckRunID.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_CheckRunID.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_Bank
            '
            Me.LabelForm_Bank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Bank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Bank.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_Bank.Name = "LabelForm_Bank"
            Me.LabelForm_Bank.Size = New System.Drawing.Size(77, 20)
            Me.LabelForm_Bank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Bank.TabIndex = 0
            Me.LabelForm_Bank.Text = "Bank:"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Search, Me.ButtonItemActions_Print, Me.ButtonItemActions_Process, Me.ButtonItemActions_Transmit, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(58, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(255, 92)
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
            'ButtonItemActions_Search
            '
            Me.ButtonItemActions_Search.BeginGroup = True
            Me.ButtonItemActions_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Search.Name = "ButtonItemActions_Search"
            Me.ButtonItemActions_Search.RibbonWordWrap = False
            Me.ButtonItemActions_Search.SecurityEnabled = True
            Me.ButtonItemActions_Search.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Search.Text = "Search"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SecurityEnabled = True
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'ButtonItemActions_Transmit
            '
            Me.ButtonItemActions_Transmit.BeginGroup = True
            Me.ButtonItemActions_Transmit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Transmit.Name = "ButtonItemActions_Transmit"
            Me.ButtonItemActions_Transmit.RibbonWordWrap = False
            Me.ButtonItemActions_Transmit.SecurityEnabled = True
            Me.ButtonItemActions_Transmit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Transmit.Text = "Transmit"
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
            'CheckBoxForm_AutoFTP
            '
            Me.CheckBoxForm_AutoFTP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_AutoFTP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AutoFTP.CheckValue = 0
            Me.CheckBoxForm_AutoFTP.CheckValueChecked = 1
            Me.CheckBoxForm_AutoFTP.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AutoFTP.CheckValueUnchecked = 0
            Me.CheckBoxForm_AutoFTP.ChildControls = CType(resources.GetObject("CheckBoxForm_AutoFTP.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AutoFTP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AutoFTP.Location = New System.Drawing.Point(95, 58)
            Me.CheckBoxForm_AutoFTP.Name = "CheckBoxForm_AutoFTP"
            Me.CheckBoxForm_AutoFTP.OldestSibling = Nothing
            Me.CheckBoxForm_AutoFTP.SecurityEnabled = True
            Me.CheckBoxForm_AutoFTP.SiblingControls = CType(resources.GetObject("CheckBoxForm_AutoFTP.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AutoFTP.Size = New System.Drawing.Size(580, 20)
            Me.CheckBoxForm_AutoFTP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AutoFTP.TabIndex = 5
            Me.CheckBoxForm_AutoFTP.TabOnEnter = True
            Me.CheckBoxForm_AutoFTP.Text = "Auto FTP"
            '
            'StepProgressBarForm_Progress
            '
            Me.StepProgressBarForm_Progress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.StepProgressBarForm_Progress.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = CType(resources.GetObject("StepProgressBarForm_Progress.ItemOptions.Indicator.ActiveStateImageOptions.SvgIma" &
        "ge"), DevExpress.Utils.Svg.SvgImage)
            Me.StepProgressBarForm_Progress.ItemOptions.Indicator.ActiveStateImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
            Me.StepProgressBarForm_Progress.Items.Add(Me.StepProgressBarItemProgress_Step1)
            Me.StepProgressBarForm_Progress.Items.Add(Me.StepProgressBarItemProgress_Step2)
            Me.StepProgressBarForm_Progress.Items.Add(Me.StepProgressBarItemProgress_Step3)
            Me.StepProgressBarForm_Progress.Items.Add(Me.StepProgressBarItemProgress_Step4)
            Me.StepProgressBarForm_Progress.LayoutMode = DevExpress.XtraEditors.StepProgressBarLayoutMode.FullSize
            Me.StepProgressBarForm_Progress.Location = New System.Drawing.Point(12, 84)
            Me.StepProgressBarForm_Progress.Name = "StepProgressBarForm_Progress"
            Me.StepProgressBarForm_Progress.Size = New System.Drawing.Size(663, 181)
            Me.StepProgressBarForm_Progress.TabIndex = 6
            Me.StepProgressBarForm_Progress.Visible = False
            '
            'StepProgressBarItemProgress_Step1
            '
            Me.StepProgressBarItemProgress_Step1.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step1.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step1.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step1.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step1.ContentBlock2.Caption = "Checks Selected"
            Me.StepProgressBarItemProgress_Step1.Name = "StepProgressBarItemProgress_Step1"
            '
            'StepProgressBarItemProgress_Step2
            '
            Me.StepProgressBarItemProgress_Step2.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step2.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step2.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step2.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step2.ContentBlock2.Caption = "Report Printed"
            Me.StepProgressBarItemProgress_Step2.Name = "StepProgressBarItemProgress_Step2"
            '
            'StepProgressBarItemProgress_Step3
            '
            Me.StepProgressBarItemProgress_Step3.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step3.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step3.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step3.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step3.ContentBlock2.Caption = "Checks Exported"
            Me.StepProgressBarItemProgress_Step3.Name = "StepProgressBarItemProgress_Step3"
            '
            'StepProgressBarItemProgress_Step4
            '
            Me.StepProgressBarItemProgress_Step4.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step4.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step4.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItemProgress_Step4.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItemProgress_Step4.ContentBlock2.Caption = "File Transmitted"
            Me.StepProgressBarItemProgress_Step4.Name = "StepProgressBarItemProgress_Step4"
            '
            'CheckBoxForm_IncludeExported
            '
            Me.CheckBoxForm_IncludeExported.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeExported.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeExported.CheckValue = 0
            Me.CheckBoxForm_IncludeExported.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeExported.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeExported.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeExported.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeExported.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeExported.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeExported.Location = New System.Drawing.Point(450, 32)
            Me.CheckBoxForm_IncludeExported.Name = "CheckBoxForm_IncludeExported"
            Me.CheckBoxForm_IncludeExported.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeExported.SecurityEnabled = True
            Me.CheckBoxForm_IncludeExported.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeExported.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeExported.Size = New System.Drawing.Size(106, 20)
            Me.CheckBoxForm_IncludeExported.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeExported.TabIndex = 7
            Me.CheckBoxForm_IncludeExported.TabOnEnter = True
            Me.CheckBoxForm_IncludeExported.Text = "Include Exported"
            '
            'StepProgressBarItem1
            '
            Me.StepProgressBarItem1.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItem1.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItem1.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItem1.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItem1.ContentBlock2.Caption = "Checks Exported"
            Me.StepProgressBarItem1.Name = "StepProgressBarItem1"
            '
            'StepProgressBarItem2
            '
            Me.StepProgressBarItem2.ContentBlock1.ActiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItem2.ContentBlock1.ActiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItem2.ContentBlock1.InactiveStateImageOptions.Image = CType(resources.GetObject("StepProgressBarItem2.ContentBlock1.InactiveStateImageOptions.Image"), System.Drawing.Image)
            Me.StepProgressBarItem2.ContentBlock2.Caption = "Checks Exported"
            Me.StepProgressBarItem2.Name = "StepProgressBarItem2"
            '
            'PaymentManagerDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(697, 446)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PaymentManagerDialog"
            Me.Text = "Payment Manager"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Bank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Bank, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_CheckRunID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_CheckRunID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.StepProgressBarForm_Progress, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SearchableComboBoxForm_Bank As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Bank As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_CheckRunID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_CheckRunID As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_CheckRunID As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Bank As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Transmit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxForm_AutoFTP As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents StepProgressBarForm_Progress As DevExpress.XtraEditors.StepProgressBar
        Friend WithEvents StepProgressBarItemProgress_Step1 As DevExpress.XtraEditors.StepProgressBarItem
        Friend WithEvents StepProgressBarItemProgress_Step2 As DevExpress.XtraEditors.StepProgressBarItem
        Friend WithEvents StepProgressBarItemProgress_Step3 As DevExpress.XtraEditors.StepProgressBarItem
        Friend WithEvents CheckBoxForm_IncludeExported As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents StepProgressBarItemProgress_Step4 As DevExpress.XtraEditors.StepProgressBarItem
        Friend WithEvents StepProgressBarItem1 As DevExpress.XtraEditors.StepProgressBarItem
        Friend WithEvents StepProgressBarItem2 As DevExpress.XtraEditors.StepProgressBarItem
    End Class

End Namespace
