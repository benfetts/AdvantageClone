Namespace FinanceAndAccounting.Exports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VATExportForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VATExportForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemExport_ToAvalara = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_ToExcel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelData_Data = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewData_Data = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_Data = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCriteria_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxCriteria_CurrencyCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView_CurrencyCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelCriteria_CurrencyCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxCriteria_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxCriteria_VATNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelCriteria_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxCriteria_PPEnd = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView_PPEnd = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelCriteria_AgencyVATNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelCriteria_PostPeriodEnd = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelCriteria_PostPeriodStart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxCriteria_PPStart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView_PPStart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.TabItemTabs_Criteria = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Tabs.SuspendLayout()
            Me.TabControlPanelData_Data.SuspendLayout()
            Me.TabControlPanelCriteria_Criteria.SuspendLayout()
            CType(Me.SearchableComboBoxCriteria_CurrencyCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView_CurrencyCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCriteria_PPEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView_PPEnd, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCriteria_PPStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView_PPStart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(112, 4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(223, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(147, 98)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_ToAvalara, Me.ButtonItemExport_ToExcel})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemExport_ToAvalara
            '
            Me.ButtonItemExport_ToAvalara.Name = "ButtonItemExport_ToAvalara"
            Me.ButtonItemExport_ToAvalara.Text = "To Avalara"
            '
            'ButtonItemExport_ToExcel
            '
            Me.ButtonItemExport_ToExcel.Name = "ButtonItemExport_ToExcel"
            Me.ButtonItemExport_ToExcel.Text = "To Excel"
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.SecurityEnabled = True
            Me.ButtonItemActions_Process.Stretch = True
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'TabControlForm_Tabs
            '
            Me.TabControlForm_Tabs.BackColor = System.Drawing.Color.White
            Me.TabControlForm_Tabs.CanReorderTabs = True
            Me.TabControlForm_Tabs.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelCriteria_Criteria)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelData_Data)
            Me.TabControlForm_Tabs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlForm_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Tabs.Location = New System.Drawing.Point(0, 0)
            Me.TabControlForm_Tabs.Name = "TabControlForm_Tabs"
            Me.TabControlForm_Tabs.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Tabs.SelectedTabIndex = 0
            Me.TabControlForm_Tabs.Size = New System.Drawing.Size(689, 414)
            Me.TabControlForm_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Tabs.TabIndex = 0
            Me.TabControlForm_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Criteria)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_Data)
            Me.TabControlForm_Tabs.Text = "TabControl1"
            '
            'TabControlPanelData_Data
            '
            Me.TabControlPanelData_Data.Controls.Add(Me.DataGridViewData_Data)
            Me.TabControlPanelData_Data.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelData_Data.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelData_Data.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelData_Data.Name = "TabControlPanelData_Data"
            Me.TabControlPanelData_Data.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelData_Data.Size = New System.Drawing.Size(689, 387)
            Me.TabControlPanelData_Data.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelData_Data.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelData_Data.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelData_Data.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelData_Data.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelData_Data.Style.GradientAngle = 90
            Me.TabControlPanelData_Data.TabIndex = 5
            Me.TabControlPanelData_Data.TabItem = Me.TabItemTabs_Data
            '
            'DataGridViewData_Data
            '
            Me.DataGridViewData_Data.AllowSelectGroupHeaderRow = True
            Me.DataGridViewData_Data.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewData_Data.AutoUpdateViewCaption = True
            Me.DataGridViewData_Data.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewData_Data.ItemDescription = "VAT Export Row(s)"
            Me.DataGridViewData_Data.Location = New System.Drawing.Point(12, 4)
            Me.DataGridViewData_Data.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewData_Data.ModifyGridRowHeight = False
            Me.DataGridViewData_Data.MultiSelect = True
            Me.DataGridViewData_Data.Name = "DataGridViewData_Data"
            Me.DataGridViewData_Data.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewData_Data.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewData_Data.ShowRowSelectionIfHidden = True
            Me.DataGridViewData_Data.ShowSelectDeselectAllButtons = False
            Me.DataGridViewData_Data.Size = New System.Drawing.Size(665, 371)
            Me.DataGridViewData_Data.TabIndex = 1
            Me.DataGridViewData_Data.UseEmbeddedNavigator = False
            Me.DataGridViewData_Data.ViewCaptionHeight = -1
            '
            'TabItemTabs_Data
            '
            Me.TabItemTabs_Data.AttachedControl = Me.TabControlPanelData_Data
            Me.TabItemTabs_Data.Name = "TabItemTabs_Data"
            Me.TabItemTabs_Data.Text = "Data"
            '
            'TabControlPanelCriteria_Criteria
            '
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.SearchableComboBoxCriteria_CurrencyCode)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.LabelCriteria_CurrencyCode)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.TextBoxCriteria_OutputFolder)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.TextBoxCriteria_VATNumber)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.LabelCriteria_OutputFolder)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.SearchableComboBoxCriteria_PPEnd)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.LabelCriteria_AgencyVATNumber)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.LabelCriteria_PostPeriodEnd)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.LabelCriteria_PostPeriodStart)
            Me.TabControlPanelCriteria_Criteria.Controls.Add(Me.SearchableComboBoxCriteria_PPStart)
            Me.TabControlPanelCriteria_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCriteria_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCriteria_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCriteria_Criteria.Name = "TabControlPanelCriteria_Criteria"
            Me.TabControlPanelCriteria_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCriteria_Criteria.Size = New System.Drawing.Size(689, 387)
            Me.TabControlPanelCriteria_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCriteria_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCriteria_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCriteria_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCriteria_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCriteria_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelCriteria_Criteria.TabIndex = 1
            Me.TabControlPanelCriteria_Criteria.TabItem = Me.TabItemTabs_Criteria
            '
            'SearchableComboBoxCriteria_CurrencyCode
            '
            Me.SearchableComboBoxCriteria_CurrencyCode.ActiveFilterString = ""
            Me.SearchableComboBoxCriteria_CurrencyCode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCriteria_CurrencyCode.AutoFillMode = False
            Me.SearchableComboBoxCriteria_CurrencyCode.BookmarkingEnabled = False
            Me.SearchableComboBoxCriteria_CurrencyCode.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxCriteria_CurrencyCode.DataSource = Nothing
            Me.SearchableComboBoxCriteria_CurrencyCode.DisableMouseWheel = True
            Me.SearchableComboBoxCriteria_CurrencyCode.DisplayName = ""
            Me.SearchableComboBoxCriteria_CurrencyCode.EditValue = ""
            Me.SearchableComboBoxCriteria_CurrencyCode.EnterMoveNextControl = True
            Me.SearchableComboBoxCriteria_CurrencyCode.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCriteria_CurrencyCode.Location = New System.Drawing.Point(130, 57)
            Me.SearchableComboBoxCriteria_CurrencyCode.Name = "SearchableComboBoxCriteria_CurrencyCode"
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.NullText = "Select Currency"
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.PopupView = Me.GridView_CurrencyCode
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.ShowClearButton = False
            Me.SearchableComboBoxCriteria_CurrencyCode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCriteria_CurrencyCode.SecurityEnabled = True
            Me.SearchableComboBoxCriteria_CurrencyCode.SelectedValue = ""
            Me.SearchableComboBoxCriteria_CurrencyCode.Size = New System.Drawing.Size(129, 20)
            Me.SearchableComboBoxCriteria_CurrencyCode.TabIndex = 5
            '
            'GridView_CurrencyCode
            '
            Me.GridView_CurrencyCode.AFActiveFilterString = ""
            Me.GridView_CurrencyCode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_CurrencyCode.EnableDisabledRows = False
            Me.GridView_CurrencyCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView_CurrencyCode.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView_CurrencyCode.ModifyGridRowHeight = False
            Me.GridView_CurrencyCode.Name = "GridView_CurrencyCode"
            Me.GridView_CurrencyCode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_CurrencyCode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_CurrencyCode.OptionsBehavior.Editable = False
            Me.GridView_CurrencyCode.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView_CurrencyCode.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView_CurrencyCode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView_CurrencyCode.OptionsSelection.MultiSelect = True
            Me.GridView_CurrencyCode.OptionsView.ColumnAutoWidth = False
            Me.GridView_CurrencyCode.OptionsView.ShowGroupPanel = False
            Me.GridView_CurrencyCode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView_CurrencyCode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView_CurrencyCode.SkipAddingControlsOnModifyColumn = False
            Me.GridView_CurrencyCode.SkipSettingFontOnModifyColumn = False
            '
            'LabelCriteria_CurrencyCode
            '
            Me.LabelCriteria_CurrencyCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCriteria_CurrencyCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCriteria_CurrencyCode.Location = New System.Drawing.Point(12, 56)
            Me.LabelCriteria_CurrencyCode.Name = "LabelCriteria_CurrencyCode"
            Me.LabelCriteria_CurrencyCode.Size = New System.Drawing.Size(112, 20)
            Me.LabelCriteria_CurrencyCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCriteria_CurrencyCode.TabIndex = 4
            Me.LabelCriteria_CurrencyCode.Text = "Currency Code:"
            '
            'TextBoxCriteria_OutputFolder
            '
            Me.TextBoxCriteria_OutputFolder.AgencyImportPath = Nothing
            Me.TextBoxCriteria_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCriteria_OutputFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxCriteria_OutputFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCriteria_OutputFolder.ButtonCustom.Visible = True
            Me.TextBoxCriteria_OutputFolder.CheckSpellingOnValidate = False
            Me.TextBoxCriteria_OutputFolder.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxCriteria_OutputFolder.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxCriteria_OutputFolder.DisplayName = ""
            Me.TextBoxCriteria_OutputFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCriteria_OutputFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCriteria_OutputFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCriteria_OutputFolder.FocusHighlightEnabled = True
            Me.TextBoxCriteria_OutputFolder.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCriteria_OutputFolder.Location = New System.Drawing.Point(130, 109)
            Me.TextBoxCriteria_OutputFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxCriteria_OutputFolder.Name = "TextBoxCriteria_OutputFolder"
            Me.TextBoxCriteria_OutputFolder.PreventEnterBeep = True
            Me.TextBoxCriteria_OutputFolder.SecurityEnabled = True
            Me.TextBoxCriteria_OutputFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCriteria_OutputFolder.Size = New System.Drawing.Size(547, 20)
            Me.TextBoxCriteria_OutputFolder.StartingFolderName = Nothing
            Me.TextBoxCriteria_OutputFolder.TabIndex = 9
            Me.TextBoxCriteria_OutputFolder.TabOnEnter = True
            '
            'TextBoxCriteria_VATNumber
            '
            Me.TextBoxCriteria_VATNumber.AgencyImportPath = Nothing
            Me.TextBoxCriteria_VATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCriteria_VATNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxCriteria_VATNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCriteria_VATNumber.CheckSpellingOnValidate = False
            Me.TextBoxCriteria_VATNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCriteria_VATNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxCriteria_VATNumber.DisplayName = ""
            Me.TextBoxCriteria_VATNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCriteria_VATNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCriteria_VATNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCriteria_VATNumber.FocusHighlightEnabled = True
            Me.TextBoxCriteria_VATNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCriteria_VATNumber.Location = New System.Drawing.Point(130, 83)
            Me.TextBoxCriteria_VATNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxCriteria_VATNumber.MaxLength = 50
            Me.TextBoxCriteria_VATNumber.Name = "TextBoxCriteria_VATNumber"
            Me.TextBoxCriteria_VATNumber.PreventEnterBeep = True
            Me.TextBoxCriteria_VATNumber.SecurityEnabled = True
            Me.TextBoxCriteria_VATNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCriteria_VATNumber.Size = New System.Drawing.Size(322, 20)
            Me.TextBoxCriteria_VATNumber.StartingFolderName = Nothing
            Me.TextBoxCriteria_VATNumber.TabIndex = 7
            Me.TextBoxCriteria_VATNumber.TabOnEnter = True
            '
            'LabelCriteria_OutputFolder
            '
            Me.LabelCriteria_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCriteria_OutputFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCriteria_OutputFolder.Location = New System.Drawing.Point(12, 108)
            Me.LabelCriteria_OutputFolder.Name = "LabelCriteria_OutputFolder"
            Me.LabelCriteria_OutputFolder.Size = New System.Drawing.Size(112, 20)
            Me.LabelCriteria_OutputFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCriteria_OutputFolder.TabIndex = 8
            Me.LabelCriteria_OutputFolder.Text = "Output Folder:"
            '
            'SearchableComboBoxCriteria_PPEnd
            '
            Me.SearchableComboBoxCriteria_PPEnd.ActiveFilterString = ""
            Me.SearchableComboBoxCriteria_PPEnd.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCriteria_PPEnd.AutoFillMode = False
            Me.SearchableComboBoxCriteria_PPEnd.BookmarkingEnabled = False
            Me.SearchableComboBoxCriteria_PPEnd.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxCriteria_PPEnd.DataSource = Nothing
            Me.SearchableComboBoxCriteria_PPEnd.DisableMouseWheel = True
            Me.SearchableComboBoxCriteria_PPEnd.DisplayName = ""
            Me.SearchableComboBoxCriteria_PPEnd.EditValue = ""
            Me.SearchableComboBoxCriteria_PPEnd.EnterMoveNextControl = True
            Me.SearchableComboBoxCriteria_PPEnd.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCriteria_PPEnd.Location = New System.Drawing.Point(130, 30)
            Me.SearchableComboBoxCriteria_PPEnd.Name = "SearchableComboBoxCriteria_PPEnd"
            Me.SearchableComboBoxCriteria_PPEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCriteria_PPEnd.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCriteria_PPEnd.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxCriteria_PPEnd.Properties.PopupView = Me.GridView_PPEnd
            Me.SearchableComboBoxCriteria_PPEnd.Properties.ShowClearButton = False
            Me.SearchableComboBoxCriteria_PPEnd.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCriteria_PPEnd.SecurityEnabled = True
            Me.SearchableComboBoxCriteria_PPEnd.SelectedValue = ""
            Me.SearchableComboBoxCriteria_PPEnd.Size = New System.Drawing.Size(129, 20)
            Me.SearchableComboBoxCriteria_PPEnd.TabIndex = 3
            '
            'GridView_PPEnd
            '
            Me.GridView_PPEnd.AFActiveFilterString = ""
            Me.GridView_PPEnd.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPEnd.EnableDisabledRows = False
            Me.GridView_PPEnd.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView_PPEnd.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView_PPEnd.ModifyGridRowHeight = False
            Me.GridView_PPEnd.Name = "GridView_PPEnd"
            Me.GridView_PPEnd.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_PPEnd.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_PPEnd.OptionsBehavior.Editable = False
            Me.GridView_PPEnd.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView_PPEnd.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView_PPEnd.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView_PPEnd.OptionsSelection.MultiSelect = True
            Me.GridView_PPEnd.OptionsView.ColumnAutoWidth = False
            Me.GridView_PPEnd.OptionsView.ShowGroupPanel = False
            Me.GridView_PPEnd.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView_PPEnd.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView_PPEnd.SkipAddingControlsOnModifyColumn = False
            Me.GridView_PPEnd.SkipSettingFontOnModifyColumn = False
            '
            'LabelCriteria_AgencyVATNumber
            '
            Me.LabelCriteria_AgencyVATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCriteria_AgencyVATNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCriteria_AgencyVATNumber.Location = New System.Drawing.Point(12, 82)
            Me.LabelCriteria_AgencyVATNumber.Name = "LabelCriteria_AgencyVATNumber"
            Me.LabelCriteria_AgencyVATNumber.Size = New System.Drawing.Size(112, 20)
            Me.LabelCriteria_AgencyVATNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCriteria_AgencyVATNumber.TabIndex = 6
            Me.LabelCriteria_AgencyVATNumber.Text = "Agency VAT Number:"
            '
            'LabelCriteria_PostPeriodEnd
            '
            Me.LabelCriteria_PostPeriodEnd.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCriteria_PostPeriodEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCriteria_PostPeriodEnd.Location = New System.Drawing.Point(12, 30)
            Me.LabelCriteria_PostPeriodEnd.Name = "LabelCriteria_PostPeriodEnd"
            Me.LabelCriteria_PostPeriodEnd.Size = New System.Drawing.Size(112, 20)
            Me.LabelCriteria_PostPeriodEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCriteria_PostPeriodEnd.TabIndex = 2
            Me.LabelCriteria_PostPeriodEnd.Text = "Post Period End:"
            '
            'LabelCriteria_PostPeriodStart
            '
            Me.LabelCriteria_PostPeriodStart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCriteria_PostPeriodStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCriteria_PostPeriodStart.Location = New System.Drawing.Point(12, 4)
            Me.LabelCriteria_PostPeriodStart.Name = "LabelCriteria_PostPeriodStart"
            Me.LabelCriteria_PostPeriodStart.Size = New System.Drawing.Size(112, 20)
            Me.LabelCriteria_PostPeriodStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCriteria_PostPeriodStart.TabIndex = 0
            Me.LabelCriteria_PostPeriodStart.Text = "Post Period Start:"
            '
            'SearchableComboBoxCriteria_PPStart
            '
            Me.SearchableComboBoxCriteria_PPStart.ActiveFilterString = ""
            Me.SearchableComboBoxCriteria_PPStart.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCriteria_PPStart.AutoFillMode = False
            Me.SearchableComboBoxCriteria_PPStart.BookmarkingEnabled = False
            Me.SearchableComboBoxCriteria_PPStart.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxCriteria_PPStart.DataSource = Nothing
            Me.SearchableComboBoxCriteria_PPStart.DisableMouseWheel = True
            Me.SearchableComboBoxCriteria_PPStart.DisplayName = ""
            Me.SearchableComboBoxCriteria_PPStart.EditValue = ""
            Me.SearchableComboBoxCriteria_PPStart.EnterMoveNextControl = True
            Me.SearchableComboBoxCriteria_PPStart.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCriteria_PPStart.Location = New System.Drawing.Point(130, 4)
            Me.SearchableComboBoxCriteria_PPStart.Name = "SearchableComboBoxCriteria_PPStart"
            Me.SearchableComboBoxCriteria_PPStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCriteria_PPStart.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCriteria_PPStart.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxCriteria_PPStart.Properties.PopupView = Me.GridView_PPStart
            Me.SearchableComboBoxCriteria_PPStart.Properties.ShowClearButton = False
            Me.SearchableComboBoxCriteria_PPStart.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCriteria_PPStart.SecurityEnabled = True
            Me.SearchableComboBoxCriteria_PPStart.SelectedValue = ""
            Me.SearchableComboBoxCriteria_PPStart.Size = New System.Drawing.Size(129, 20)
            Me.SearchableComboBoxCriteria_PPStart.TabIndex = 1
            '
            'GridView_PPStart
            '
            Me.GridView_PPStart.AFActiveFilterString = ""
            Me.GridView_PPStart.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView_PPStart.EnableDisabledRows = False
            Me.GridView_PPStart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView_PPStart.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView_PPStart.ModifyGridRowHeight = False
            Me.GridView_PPStart.Name = "GridView_PPStart"
            Me.GridView_PPStart.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_PPStart.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView_PPStart.OptionsBehavior.Editable = False
            Me.GridView_PPStart.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView_PPStart.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView_PPStart.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView_PPStart.OptionsSelection.MultiSelect = True
            Me.GridView_PPStart.OptionsView.ColumnAutoWidth = False
            Me.GridView_PPStart.OptionsView.ShowGroupPanel = False
            Me.GridView_PPStart.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView_PPStart.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView_PPStart.SkipAddingControlsOnModifyColumn = False
            Me.GridView_PPStart.SkipSettingFontOnModifyColumn = False
            '
            'TabItemTabs_Criteria
            '
            Me.TabItemTabs_Criteria.AttachedControl = Me.TabControlPanelCriteria_Criteria
            Me.TabItemTabs_Criteria.Name = "TabItemTabs_Criteria"
            Me.TabItemTabs_Criteria.Text = "Criteria"
            '
            'VATExportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(689, 414)
            Me.Controls.Add(Me.TabControlForm_Tabs)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VATExportForm"
            Me.Text = "VAT Export"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Tabs.ResumeLayout(False)
            Me.TabControlPanelData_Data.ResumeLayout(False)
            Me.TabControlPanelCriteria_Criteria.ResumeLayout(False)
            CType(Me.SearchableComboBoxCriteria_CurrencyCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView_CurrencyCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCriteria_PPEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView_PPEnd, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCriteria_PPStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView_PPStart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents TabControlForm_Tabs As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelCriteria_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Criteria As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelData_Data As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Data As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Process As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents SearchableComboBoxCriteria_PPStart As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView_PPStart As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelCriteria_OutputFolder As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxCriteria_PPEnd As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView_PPEnd As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelCriteria_AgencyVATNumber As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelCriteria_PostPeriodEnd As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelCriteria_PostPeriodStart As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewData_Data As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxCriteria_OutputFolder As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxCriteria_VATNumber As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelCriteria_CurrencyCode As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxCriteria_CurrencyCode As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView_CurrencyCode As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents ButtonItemExport_ToAvalara As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_ToExcel As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace